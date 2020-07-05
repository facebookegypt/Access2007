Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration
Module connection
    Private MyDirectory As String = Application.StartupPath
    Private DBPass As String = My.Settings.MyPass
    Function GetDataSource(Optional ThisDB As String = "ThisDB.accdb") As String
        'Valid Path + Microsoft Access Database file + extension
        Dim MyDataSource As String = String.Empty
        If File.Exists(ThisDB) Then
            MyDataSource = (ThisDB)
        Else
            MyDataSource = CType(MsgBox("Database file doesn't exist.", MsgBoxStyle.Critical), String)
            End
        End If
        Return MyDataSource
    End Function
    Private Function GetConnectionStrings() As String
        Dim settings As ConnectionStringSettingsCollection =
            ConfigurationManager.ConnectionStrings
        Dim Provider As String = String.Empty
        If settings IsNot Nothing Then
            For Each cs As ConnectionStringSettings In settings
                If cs.Name = "connectionString" Then
                    Provider = cs.ProviderName
                End If
            Next
        End If
        Return Provider
    End Function
    Function GetProvider() As String
        Dim Provider As String = String.Empty
        Dim reader = OleDbEnumerator.GetRootEnumerator()
        Dim list = New List(Of String)
        While reader.Read()
            For I As Integer = 0 To reader.FieldCount - 1
                'Debug.WriteLine(reader.GetName(i))
                If reader.GetName(I) = "SOURCES_NAME" Then
                    list.Add(reader.GetValue(I).ToString())
                    'Debug.WriteLine(reader.GetValue(i).ToString())
                End If
            Next
        End While
        reader.Close()
        For Each Provider In list
            'Debug.WriteLine(Provider)
            If Provider.StartsWith(GetConnectionStrings) Then
                Provider = Provider.ToString()
                Exit For
            End If
        Next
        Return Provider
    End Function
    Function GetBuilderCNString(Optional ThisDB As String = "ThisDB.accdb", Optional DBPass As String = "evry1falls") As String
        Dim ThisConnectionString As String = String.Empty
        Dim builder As New OleDbConnectionStringBuilder() With {
        .PersistSecurityInfo = False,
        .Provider = GetProvider(),
        .DataSource = GetDataSource(ThisDB)
        }
        Try
            With builder
                .Add("Jet OLEDB:Database Password", DBPass)
                .Add("Jet OLEDB:Database Locking Mode", 1)
            End With
            ThisConnectionString = (builder.ConnectionString)
        Catch ex As OleDbException
            MsgBox("Database Error : " & ex.Message)
            Return ThisConnectionString
            Exit Function
        End Try
        Return ThisConnectionString
    End Function
    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New Net.WebClient()
                Using stream = client.OpenRead("https://www.google.com")
                    Return True
                End Using
            End Using
        Catch ex As Net.WebException
            Debug.WriteLine(ex.Message)
            Return False
        End Try
    End Function
    Public Sub CompactRepDB(ByVal src As String, ByVal Dest As String)
        Dim Engine As Microsoft.Office.Interop.Access.Dao.DBEngine
        Try
            Engine = New Microsoft.Office.Interop.Access.Dao.DBEngine
            Engine.CompactDatabase(
                src,
                Dest,
                Microsoft.Office.Interop.Access.Dao.LanguageConstants.dbLangGeneral,
                Microsoft.Office.Interop.Access.Dao.DatabaseTypeEnum.dbVersion150,
                ";pwd=" & My.Settings.MyPass)
        Catch ex As Exception
            Debug.WriteLine("Error Compact : " & ex.Message)
        Finally
            Engine = Nothing
        End Try
    End Sub
End Module
