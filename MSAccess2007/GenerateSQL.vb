Imports System.IO
Imports System.Text
Public Class GenerateSQL
    Public Shared Function _GfirstPart(dbname As String) As String
        Dim FirstPart As StringBuilder = New StringBuilder
        With FirstPart
            .AppendLine("CREATE DATABASE IF NOT EXISTS " & dbname & ";")
            .AppendLine("USE " & dbname & ";")
        End With
        Return FirstPart.ToString
    End Function
    Public Shared Function _CreateTables(TableName As String) As String
        Dim CreateTables As StringBuilder = New StringBuilder
        With CreateTables
            .AppendLine("CREATE TABLE IF NOT EXISTS " & TableName & " (")
        End With
        Return CreateTables.ToString
    End Function
    Public Shared Function _CreateTableFields(FieldName As String, FieldType As String,
                                              FieldSize As String, FieldConstr As String) As String
        Dim CreateTableFields As StringBuilder = New StringBuilder
        With CreateTableFields
            If String.IsNullOrEmpty(FieldSize) Then
                .AppendLine(FieldName & " " & FieldType & " " & FieldConstr)
            Else
                .AppendLine(FieldName & " " & FieldType & "(" & FieldSize & ")" & " " & FieldConstr)
            End If
        End With
        Return CreateTableFields.ToString
    End Function
    Public Shared Function _EndPart() As String
        Dim EndPart As StringBuilder = New StringBuilder
        With EndPart
            .AppendLine(")")
        End With
        Return EndPart.ToString
    End Function
    Public Shared Sub _WriteToSqlScript(ByVal Content As String,
            Optional Dest As String = "C:\", Optional SqlFile As String = "SqlScript.sql",
                                        Optional Overwrite As Boolean = True)
        Using SW As StreamWriter = New StreamWriter(Dest & SqlFile, Overwrite)
            SW.Write(Content)
        End Using
    End Sub
End Class
