﻿Imports System.Data.OleDb
Imports System.IO
Imports System.Configuration
Imports dao
Module connection
    Private MyDirectory As String = Application.StartupPath
    Public DBPass1 As String
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
    Public Property _DBPassword As String
        Get
            Return DBPass1
        End Get
        Set(ByVal value As String)
            DBPass1 = value
        End Set
    End Property
    Function GetBuilderCNString(Optional DBPath As String = ("") _
                                , Optional DBPass As String = ("")) As String
        Dim ThisConnectionString As String = String.Empty
        Dim builder As New OleDbConnectionStringBuilder() With {.PersistSecurityInfo = False}
        Try
            With builder
                .OleDbServices = -1
                .Provider = GetProvider()
                If String.IsNullOrEmpty(DBPath) Then
                    DBPath = GetDataSource(IO.Path.Combine(Application.StartupPath, "ThisDB.accdb"))
                End If
                .DataSource = GetDataSource(DBPath)
                .Add("Jet OLEDB:Database Password", DBPass)
            End With
            ThisConnectionString = builder.ConnectionString
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
                ";pwd=" & My.Settings.MyPass)
        Catch ex As Exception
            MsgBox("Error Compact : " & ex.Message)
        Finally
            Engine = Nothing
        End Try
    End Sub
    Public Sub ConnectAsDAO()
        Dim Attrib As String
        Dim prpLoop As dao.Property
        Dim DBEngin As New Microsoft.Office.Interop.Access.Dao.DBEngine
        Dim wrkMain As Microsoft.Office.Interop.Access.Dao.Workspace = DBEngin.Workspaces(0)
        Dim dbsPubs As Microsoft.Office.Interop.Access.Dao.Database =
            wrkMain.OpenDatabase(DatabaseSettings._GetDPath, False, False, ";pwd=" & _DBPassword)
        Dim tBldef As TableDef

        For I As Integer = 0 To dbsPubs.TableDefs.Count - 1
            tBldef = dbsPubs.TableDefs(I)
            Attrib = (tBldef.Attributes And -2147483646)
            If Attrib = 0 Then
                For Each prpLoop In tBldef.Properties
                    Try
                        Debug.WriteLine("  " & prpLoop.Name & " - " &
                   IIf(IsNothing(prpLoop), "[empty]", prpLoop.Value))
                    Catch ex As Exception
                        Debug.WriteLine(prpLoop.Name)
                    End Try
                Next
                prpLoop = Nothing
                'Debug.WriteLine(tBldef.Name)
                Dim fldLoop As Fields = tBldef.Fields
                For Each fldloop1 As dao.Field In fldLoop
                    Debug.WriteLine("Table::" & tBldef.Name & "::Field::" & fldloop1.Name)
                Next
                fldLoop = Nothing
            End If
            'Debug.WriteLine(tBldef.Name & IIf(Attrib, ": System Table", ": Not System" & "Table"))
        Next
        dbsPubs = Nothing
        tBldef = Nothing
        DBEngin = Nothing
    End Sub
End Module
