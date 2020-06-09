Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration
Module connection
    Private MyDirectory As String = Application.StartupPath
    Function GetDataSource(Optional ThisDB As String = "ThisDB.accdb") As String
        'Valid Path + Microsoft Access Database file + extension
        Dim MyDataSource As String = String.Empty
        If File.Exists(Path.Combine(MyDirectory, ThisDB)) Then
            MyDataSource = Path.Combine(MyDirectory, ThisDB)
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
            For i = 0 To reader.FieldCount - 1
                'Debug.WriteLine(reader.GetName(i))
                If reader.GetName(i) = "SOURCES_NAME" Then
                    list.Add(reader.GetValue(i).ToString())
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
    Function GetBuilderCNString()
        Dim ThisConnectionString As String = String.Empty
        Dim builder As New OleDbConnectionStringBuilder() With {
        .PersistSecurityInfo = False,
        .Provider = GetProvider(),
        .DataSource = GetDataSource()
        }
        Try
            With builder
                .Add("Jet OLEDB:Database Password", My.Settings.MyPass)
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
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
End Module
