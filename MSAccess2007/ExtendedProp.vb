Imports System.ComponentModel

Public Class ExtendedProp
    Private DBName As String = DatabaseSettings._GetDBName
    Private DBPath As String = DatabaseSettings._GetDPath
    Private DBPass As String = connection._DBPassword
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        Try
            If Not IsNothing(e.Value) Then
                For Each Icolumn As DataGridViewColumn In DataGridView1.Columns
                    If TypeOf Icolumn Is DataGridViewImageColumn Then
                        Dim imageColumn = DirectCast(Icolumn, DataGridViewImageColumn)
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        'Generate SQL Script (*.sql)
        '  Dim Thisdbname As String = dbname.Remove(dbname.LastIndexOf("."), 6)
        'Dim Cont As New List(Of String)
        'Try
        ' Using CN As New OleDb.OleDbConnection With {.ConnectionString =
        ' GetBuilderCNString(LocationTxt.Text, AppConfig.ReadSetting("ThisPassword"))}
        ' CN.Open()
        ' End Using
        ' Catch ex As OleDb.OleDbException
        ' MsgBox(ex.Message)
        ' Exit Sub
        ' End Try
        ' Cont.Add(GenerateSQL._GfirstPart(Thisdbname))
        'Dim parentNode As TreeNode
        ''Dim childNode As TreeNode
        'For Each parentNode In TreeView2.Nodes
        ' For Each childNode In parentNode.Nodes
        ' Cont.Add(GenerateSQL._CreateTables(childNode.Text))
        'Next
        ''Next
        'Debug.WriteLine(String.Join(",", nodes.ToArray))

        'GenerateSQL._WriteToSqlScript(String.Join(" ", Cont), Application.StartupPath & "\", Thisdbname & ".sql", False)
    End Sub

    Private Sub ExtendedProp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
        End If
        BackgroundWorker1.RunWorkerAsync()
        connection.ConnectAsDAO()
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(500)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        With TreeView2
            .Nodes.Clear()
            .BeginUpdate()
            .Nodes.Add(DatabaseSettings.GetTables(DBPath, DBPass))
            .Nodes.Add(DatabaseSettings.GetViews(DBPath, DBPass))
            .EndUpdate()
        End With
    End Sub
    Private Sub ExtendedProp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        DBSettings.Show()
    End Sub

    Private Sub TreeView2_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterSelect
        If IsNothing(e.Node.Parent) Then Exit Sub
        If e.Node.Parent.Text = ("Tables") Then
            Dim ThisTable As String = e.Node.Text
            With DataGridView1
                .AllowUserToAddRows = False
                With .ColumnHeadersDefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .BackColor = Color.LightGray
                    .ForeColor = Color.DarkBlue
                End With
                .EnableHeadersVisualStyles = False
                .DataSource = DatabaseSettings.GetContents(TableName:=ThisTable,
                DBName:=DBPath, DBPass:=DBPass)
            End With
            With DataGridView2
                .AllowUserToAddRows = False
                With .ColumnHeadersDefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .BackColor = Color.LightGray
                    .ForeColor = Color.DarkBlue
                End With
                .EnableHeadersVisualStyles = False
            End With
            DatabaseSettings.GetOledbSchemaToDataGridView(DBPath, ThisTable, DataGridView2,
                  AppConfig.ReadSetting("ThisPassword"))
        Else
            Exit Sub
        End If
    End Sub
End Class