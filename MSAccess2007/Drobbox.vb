Imports Dropbox.Api
Imports System.Net.Http
Imports System.Threading

Public Class Drobbox
    Private ReadOnly RedirectUri As Uri = New Uri(My.Settings.LoopBackHost & "authorize")
    Private ReadOnly JSRedirectUri As Uri = New Uri(My.Settings.LoopBackHost & "token")
    Public cts As CancellationTokenSource
    Public Async Function Run() As Task(Of String)
        'Check for internet connection
        Dim Result As String = String.Empty
        If Not CheckForInternetConnection() Then
            Result = ("Sorry, No Internet")
            Return Result
            Exit Function
        End If
        DropboxCertHelper.InitializeCertPinning()
        Dim accessToken = Await GetAccessToken()
        If String.IsNullOrEmpty(accessToken) Then
            Result = ("Something went wrong")
            Return Result
            Exit Function
        End If
        ' Specify socket level timeout which decides maximum waiting time when no bytes are
        ' received by the socket.
        Dim httpClient = New HttpClient(New WebRequestHandler() With {.ReadWriteTimeout = 10 * 1000})
        Try
            Dim config = New DropboxClientConfig("MSAccess2007.vb")
            Dim client = New DropboxClient(accessToken, config)
            Result = ("OK : ") & Await GetCurrentAccount(client)
        Catch e As HttpException
            Debug.WriteLine("Exception reported from RPC layer")
            Debug.WriteLine("    Status code: {0}", e.StatusCode)
            Debug.WriteLine("    Message    : {0}", e.Message)
            If (Not (e.RequestUri) Is Nothing) Then
                Debug.WriteLine("    Request uri: {0}", e.RequestUri)
            End If
        End Try
        Return Result
    End Function
    Private Async Function GetAccessToken() As Task(Of String)
        Dim accessToken = My.Settings.AccessToken
        If String.IsNullOrEmpty(accessToken) Then
            Try
                Dim authorizeUri =
                    DropboxOAuth2Helper.GetAuthorizeUri(OAuthResponseType.Token, My.Settings.ApiKey, RedirectUri, state:="N",
                                                        forceReapprove:=False, disableSignup:=False, requireRole:=Nothing,
                                                        forceReauthentication:=False)
                Using http As New Net.HttpListener
                    http.Prefixes.Add(My.Settings.LoopBackHost)
                    http.Start()
                    Process.Start(authorizeUri.ToString)
                    ' Handle OAuth redirect and send URL fragment to local server using JS.
                    Await HandleOAuth2Redirect(http)
                    ' Handle redirect from JS and process OAuth response.
                    Dim Result = Await HandleJSRedirect(http)
                    If Result.State <> "N" Then
                        ' The state in the response doesn't match the state in the request.
                        Return Nothing
                    End If
                    accessToken = Result.AccessToken
                    Dim uid = Result.Uid
                    My.Settings.AccessToken = accessToken
                    My.Settings.Uid = uid
                    My.Settings.Save()
                End Using
            Catch e As Exception
                Debug.WriteLine("Error: {0}", e.Message)
                Return Nothing
            End Try
        End If
        Return accessToken
    End Function
    Private Async Function HandleJSRedirect(ByVal http As Net.HttpListener) As Task(Of OAuth2Response)
        Dim context = Await http.GetContextAsync
        ' We only care about request to TokenRedirectUri endpoint.
        While (context.Request.Url.AbsolutePath <> JSRedirectUri.AbsolutePath)
            context = Await http.GetContextAsync
        End While
        Dim redirectUri = New Uri(context.Request.QueryString("url_with_fragment"))
        Dim result = DropboxOAuth2Helper.ParseTokenFragment(redirectUri)
        Return result
    End Function
    Private Async Function HandleOAuth2Redirect(ByVal http As Net.HttpListener) As Task
        Dim context = Await http.GetContextAsync
        ' We only care about request to RedirectUri endpoint.
        While (context.Request.Url.AbsolutePath <> RedirectUri.AbsolutePath)
            context = Await http.GetContextAsync
        End While
        context.Response.ContentType = "text/html"
        ' Respond with a page which runs JS and sends URL fragment as query string
        ' to TokenRedirectUri.
        Dim File As IO.FileStream =
            New IO.FileStream(IO.Path.Combine(IO.Directory.GetCurrentDirectory(), "index.html"), IO.FileMode.Open)
        File.CopyTo(context.Response.OutputStream)
        context.Response.OutputStream.Close()
    End Function
    Private Async Function GetCurrentAccount(ByVal client As DropboxClient) As Task(Of String)
        Dim full = Await client.Users.GetCurrentAccountAsync
        Return full.Name.DisplayName
    End Function
    Public Async Function ChunkUpload(ByVal ThisFilePath As String,
                                      Progress1 As ToolStripProgressBar,
                                      CT As CancellationToken,
                                      Optional folder As String = ("/Tests")) As Task
        cts = New CancellationTokenSource
        Dim config = New DropboxClientConfig("MSAccess2007.vb")
        Dim client = New DropboxClient(My.Settings.AccessToken, config)
        Const chunkSize As Integer = 1024 * 1024
        Dim LocalFileName As String = ThisFilePath.Remove(0, ThisFilePath.LastIndexOf("\") + 1)
        '       chunkSize = 8192 * 1024 '8mb
        Dim fs As IO.FileStream = New IO.FileStream(ThisFilePath, IO.FileMode.Open)
        Dim data As Byte() = New Byte(fs.Length) {}
        fs.Read(data, 0, data.Length)
        fs.Close()
        Try
            Await Task.Delay(250)
            Using thisstream = New IO.MemoryStream(data)
                Dim numChunks As Integer = CType(Math.Ceiling((CType(thisstream.Length, Double) / chunkSize)), Integer)
                Dim buffer() As Byte = New Byte((chunkSize) - 1) {}
                Dim sessionId As String = Nothing
                Dim idx = 0
                Do While idx < numChunks And CT.IsCancellationRequested = False
                    Dim byteRead = thisstream.Read(buffer, 0, chunkSize)
                    Dim memStream As IO.MemoryStream = New IO.MemoryStream(buffer, 0, byteRead)
                    If idx = 0 And CT.IsCancellationRequested = False Then
                        Dim result = Await client.Files.UploadSessionStartAsync(body:=memStream)
                        sessionId = result.SessionId
                        'Debug.WriteLine("1) Session ID : " & sessionId)
                    Else
                        Dim cursor As Files.UploadSessionCursor = New Files.UploadSessionCursor(sessionId, chunkSize * idx)
                        'Debug.WriteLine("2) Uploaded : " & (idx * chunkSize))
                        If idx = numChunks - 1 And CT.IsCancellationRequested = False Then
                            'Overwrite, if existed
                            Await client.Files.UploadSessionFinishAsync(cursor,
                                                                        New Files.CommitInfo(
                                                                        (folder + ("/" + ThisFilePath)),
                                                                        Files.WriteMode.Overwrite.Instance, False, Nothing, False), memStream)
                            '   Debug.WriteLine("3) Uploaded : " & (idx * chunkSize))
                        Else
                            Await client.Files.UploadSessionAppendV2Async(cursor, body:=memStream)
                            '  Debug.WriteLine("4) Uploaded : " & (idx * chunkSize))
                        End If
                    End If
                    idx += 1
                    Application.DoEvents()
                    Progress1.Value = CInt((idx / numChunks) * 100)
                    Progress1.ToolTipText = Progress1.Value & "%"
                Loop
                If Progress1.Value = 100 Then
                    Progress1.Value = 0
                    Progress1.ToolTipText = Progress1.Value & "%"
                End If
            End Using
        Catch ex As DropboxException
            MsgBox(ex.Message)
        End Try
    End Function
    Public Sub Reset()
        cts = Nothing
    End Sub
End Class
