Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports Microsoft.Win32
Imports Microsoft.Office.Interop.Access.Dao

Public Class DatabaseSettings
    Private FirstDBFile, SecondDBFile As String
    Private DaoDB As New DBEngine
    Private Shared DatabaseName, DataBasePath As String
    Public Shared Function GetFileInfo(file As String) As TreeNode
        Dim information = My.Computer.FileSystem.GetFileInfo(file)
        Dim MainTree As New TreeNode
        With MainTree
            .Name = ("Database")
            .Text = ("Properties")
        End With

        Dim ListInfo(6) As String
        ListInfo(0) = ("Full Name : ") & information.FullName
        ListInfo(1) = ("Creation Time : ") & information.CreationTime.ToString
        ListInfo(2) = ("Last Access : ") & information.LastAccessTime.ToString
        ListInfo(3) = ("Last Write : ") & information.LastWriteTime.ToString
        ListInfo(4) = ("Lengh : ") & information.Length.ToString & (" Byte(s)")
        ListInfo(5) = ("Name : ") & information.Name
        Dim ThisList As New List(Of String)
        For I As Integer = 0 To 5
            MainTree.Nodes.Add(ListInfo(I))
        Next
        Return MainTree
    End Function
    Private Shared Function GetAccessVersionNiceName() As String
        Try
            Dim ClassName As String = GetAccessClassName()
            Select Case GetAccessVersionNumber(ClassName)
                Case 8
                    Return "MicroSoft Access 97"
                Case 9
                    Return "MicroSoft Access 2000"
                Case 10
                    Return "MicroSoft Access XP"
                Case 11
                    Return "MicroSoft Access 2003"
                Case 12
                    Return "MicroSoft Access 2007"
                Case 14
                    Return "MicroSoft Access 2010"
                Case 15
                    Return "MicroSoft Access 2013"
                Case 16
                    Return "MicroSoft Access 2016 & MicroSoft Access 2019"
                Case Else
                    Return "unknown"
            End Select
        Catch ex As Exception
            Return "unknown"
        End Try
    End Function
    Private Shared Function GetAccessClassName() As String
        Dim RegKey As RegistryKey = Registry.ClassesRoot.OpenSubKey("Access.Application\CurVer")
        If RegKey Is Nothing Then
            Throw New ApplicationException("Can not find MS Access version number in registry")
        Else
            Return CType(RegKey.GetValue(""), String)
        End If
    End Function
    Private Shared Function GetAccessVersionNumber(ByVal ClassName As String) As Integer
        Dim VersionNumber As String = ClassName
        While VersionNumber.IndexOf(".") > -1
            VersionNumber = VersionNumber.Substring(VersionNumber.IndexOf(".") + 1)
        End While
        Return CInt(VersionNumber.Trim)
    End Function
    Public Shared Function AccessInstalleds() As List(Of String)
        Dim ListOAccess As New List(Of String)
        ListOAccess.Clear()
        ListOAccess.Add(GetAccessVersionNiceName)
        Return ListOAccess
    End Function
    Public Shared Function GetMSProvider() As List(Of String)
        Dim Providers = New List(Of String)
        Dim provider = String.Empty
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
        For Each provider In list
            'Debug.WriteLine(Provider)
            If provider.StartsWith("Microsoft") Then
                Providers.Add(provider)
            End If
        Next
        Return Providers
    End Function
    Public Shared Function GetHeader(File As String) As String
        Dim Result As String = String.Empty
        Try
            Using fsSource As FileStream = New FileStream(File,
                FileMode.Open, FileAccess.Read)
                ' Read the source file into a byte array.
                Dim bytes() As Byte = New Byte(255) {}
                Dim numBytesToRead As Integer = 256 'CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, numBytesToRead)
                    ' Break when the end of the file is reached.
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)
                    '
                    Dim AsciiToHex As StringBuilder = New StringBuilder
                    For I As Integer = 0 To bytes.Length - 1
                        AsciiToHex.Append(bytes(I).ToString("X") + (" "))
                    Next
                    Result = (AsciiToHex.ToString())
                    'Debug.WriteLine(Result) '0 1 0 0 53 74 61 6E 64 61 72 64 20 41 43 45
                End While
                numBytesToRead = bytes.Length
                ' Write the byte array to the other FileStream.
                Using fsNew As FileStream = New FileStream(Application.StartupPath & "\New.txt",
                FileMode.Create, FileAccess.Write)
                    fsNew.Write(bytes, 0, numBytesToRead)
                End Using
            End Using
        Catch ioEx As FileNotFoundException
            Console.WriteLine(ioEx.Message)
        End Try
        Return Result
    End Function
    Public Shared Function GetTables(ByVal DBName As String, Optional DBPass As String = "evry1falls") As TreeNode
        Dim TableTree As TreeNode = New TreeNode("Tables")
        Dim ImgLst As New ImageList
        With ImgLst.Images
            .Add(Image.FromFile(Application.StartupPath & "\Icons\Primary_Key.png"))
        End With
        Try
            Dim userTables As DataTable = New DataTable("Table")    'TABLES
            Using Conn As New OleDbConnection With {.ConnectionString = GetBuilderCNString(DBName, DBPass)}
                Try
                    Conn.Open()
                Catch ex As OleDbException
                    MsgBox(ex.Message)
                    Return (New TreeNode("Error"))
                    Exit Function
                End Try
                userTables = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                                                      New String() {Nothing, Nothing, Nothing, "Table"})
                For Each row As DataRow In userTables.Rows
                    TableTree.Nodes.Add(row.Field(Of String)("Table_Name"))
                Next
            End Using
        Catch ex As OleDbException
            MsgBox(ex.Message)
        End Try
        Return TableTree
    End Function
    Public Shared Function GetOledbSchemaToDataGridView(ByVal DatabaseName As String,
                                                 ByVal TableName As String,
                                                 ByVal GridView As DataGridView,
                                                        Optional DBPass As String = ("evry1falls")) As Boolean
        Try
            Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString(DatabaseName, DBPass)}
                Dim Table As New DataTable With {.TableName = String.Format("tbl{0}", TableName)}
                CN.Open()
                Table = CN.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, TableName, Nothing})
                Dim dt As DataTable = Table.DefaultView.ToTable(String.Format("{0}_schema", TableName.ToString), True, New String() _
                                      {"Column_Name", "Data_Type", "is_nullable", "Character_Maximum_Length", "Description"})
                ' Fields which may be null are casted as Object even though we could do various forms of checks and conversions 
                ' this is better as our DataGridView treats items as objects. A good example is the 'Description' field which
                ' more times than not will not be populated.
                Dim query =
                   (
                      From fd In dt.AsEnumerable
                      Select New With
                      {
                            .Column = fd.Field(Of String)("Column_Name"),
                            .DataType = GetNameOfType(fd("Data_Type")),
                            .Size = fd.Field(Of Object)("Character_Maximum_Length"),
                            .Description = fd.Field(Of Object)("Description"),
                            .Nullable = fd.Field(Of Boolean)("is_nullable").ToString
                      }).ToList
                CN.Close()
                GridView.DataSource = query
                For Each dt1 As DataRow In dt.Rows
                    Debug.WriteLine(String.Join(",", dt1.ItemArray))
                Next
                'GridView.AutoFillLastColumn()
                Return True
            End Using
        Catch ex As OleDbException
            Return False
        End Try
    End Function
    Public Shared Function GetViews(ByVal DBName As String, Optional DBPass As String = "evry1falls") As TreeNode
        Dim ViewTree As TreeNode = New TreeNode("Views")
        Try
            Dim userViews As DataTable = New DataTable
            Using Conn As New OleDbConnection With {.ConnectionString = GetBuilderCNString(DBName, DBPass)}
                Conn.Open()
                userViews = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "VIEW"})
                For Iv As Integer = 0 To userViews.Rows.Count - 1
                    ViewTree.Nodes.Add(userViews.Rows(Iv)(2).ToString())
                Next
            End Using
        Catch ex As OleDbException
            MsgBox(ex.Message)
        End Try
        Return ViewTree
    End Function
    Public Shared Function GetContents(TableName As String, Optional DBName As String = "ThisDb.accdb",
                                          Optional DBPass As String = "evry1falls") As DataTable
        Dim SqlStr As String = ("SELECT * FROM [" & TableName & "]")
        Using MyTable As DataTable = New DataTable
            Try
                Using Conn As New OleDbConnection With {.ConnectionString = GetBuilderCNString(DBName, DBPass)},
           CMD As New OleDbCommand(SqlStr, Conn)
                    Conn.Open()
                    Try
                        Using MyReader As OleDbDataReader = CMD.ExecuteReader
                            MyTable.Load(MyReader)
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        Conn.Close()
                    End Try
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
            Return MyTable
        End Using
    End Function
    Public Shared Function GetSchemaTable(Optional DBName As String = "ThisDb.accdb",
                                          Optional DBPass As String = "evry1falls") As DataTable
        Dim schemaTable As DataTable = New DataTable
        Try
            Using Conn As New OleDbConnection With {.ConnectionString = GetBuilderCNString(DBName, DBPass)}
                Conn.Open()
                schemaTable = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                New Object() {Nothing, Nothing, Nothing, "TABLE"})
            End Using
        Catch ex As OleDbException
            MsgBox(ex.Message)
        End Try
        Return schemaTable
    End Function

    ' Map OLEDB data types to their respective string descriptions.
    'https://docs.microsoft.com/en-us/iis/extensions/database-manager-reference/column-length-property-microsoft-web-management-databasemanager
    Friend Shared Function OleDbTypeToString(ByVal type As OleDbType) As String
        Select Case (type)
            Case OleDbType.Binary
                Return "Binary"
            Case OleDbType.Boolean
                Return "Bit"
            Case OleDbType.UnsignedTinyInt
                Return "Byte"
            Case OleDbType.TinyInt
                Return "TinyInt"
            Case OleDbType.Integer
                Return "Integer"
            Case OleDbType.Currency
                Return "Currency"
            Case OleDbType.Date
                Return "DateTime"
            Case OleDbType.Double
                Return "Float"
            Case OleDbType.Guid
                Return "UniqueIdentifier"
            Case OleDbType.Char, OleDbType.WChar
                Return "Text"
            Case OleDbType.Single
                Return "Real"
            Case OleDbType.SmallInt
                Return "SmallInt"
            Case OleDbType.Numeric, OleDbType.Decimal
                Return "Decimal"
            Case Else
                Return "Unknown"
        End Select
    End Function
    Private Shared Function GetNameOfType() As Dictionary(Of Integer, String)
        Dim names() As String = CType([Enum].GetNames(GetType(OleDbType)), String())
        Dim Values As Integer() = CType([Enum].GetValues(GetType(OleDbType)), Integer())
        Dim ThisTypO As New Dictionary(Of Integer, String)
        For Row As Integer = 0 To names.Count - 1
            ThisTypO.Add(Values(Row), names(Row))
        Next
        Return ThisTypO
    End Function
    Public Shared Property _GetDBName As String
        Get
            Return DatabaseName
        End Get
        Set(value As String)
            DatabaseName = value
        End Set
    End Property
    Public Shared Property _GetDPath As String
        Get
            Return DataBasePath
        End Get
        Set(value As String)
            DataBasePath = value
        End Set
    End Property
End Class
