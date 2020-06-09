Imports System.ComponentModel
Imports System.Data.OleDb
Public Class Form1
    Private UserSelectedID As Integer
    Private UserSelectedRow As Integer
    Dim BGW_Reslt As String = ("SELECT * FROM BasicInfo LEFT JOIN MaritalStatus ON MaritalStatus.MStatusID = BasicInfo.MStatusID " &
            "ORDER BY BasicInfo.UserID ASC;")
    Sub clearAllCntrls()
        For Each Ctrl As Control In BasicInfoGroupBox.Controls
            If TypeOf Ctrl Is TextBox Then
                Ctrl.Text = String.Empty
            End If
        Next
        With PersonalPictureBox
            .Image = My.Resources.no_photo
            .BackColor = Color.Empty
            .Invalidate()
        End With
        'Default Value for MenuItems
        MaritalComboBox.SelectedIndex = -1
        UpdateToolStripMenuItem.Enabled = False
        DeleteToolStripMenuItem.Enabled = False
        SaveToolStripMenuItem.Enabled = True
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim AreYouSure As String =
            MsgBox("Close ?", MsgBoxStyle.YesNo, "Close")
        If AreYouSure = MsgBoxResult.Yes Then
            If ToolStripProgressBar1.Value <> 0 Then
                e.Cancel = True
                Exit Sub
            End If
            End
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        'DataGridView
        With DisplayDGV
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
        End With
        'Textbox accepts only 0 to 9 children Integer
        ChildrenTextBox.MaxLength = 1
        AddHandler NewToolStripMenuItem.Click, AddressOf clearAllCntrls
        'Populate ComboBox-------------------------
        BackgroundWorker1.WorkerSupportsCancellation = True
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
        End If
        BackgroundWorker1.RunWorkerAsync()
        '--------------------------------------
        'Populate DataGridView---------------------
        BackgroundWorker2.WorkerSupportsCancellation = True
        If BackgroundWorker2.IsBusy Then
            BackgroundWorker2.CancelAsync()
        End If
        BackgroundWorker2.RunWorkerAsync(BGW_Reslt)
        '------------------------------------------
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DateLabel.Text = Now.ToString("dddd, dd/MMMM/yyyy hh:mm:ss tt")
    End Sub
    Private Sub PersonalPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles PersonalPictureBox.MouseClick
        Try
            If e.Button = MouseButtons.Left Then
                Using OFD As New OpenFileDialog
                    With OFD
                        .Filter = ("Image JPEGs|*.jpg|Image GIFs|*.gif|Image Bitmaps|*.bmp|Image PNGs|*.png|Icons ICOs|*.ico")
                        .FilterIndex = 1
                        .RestoreDirectory = True
                        .CheckFileExists = True
                        .CheckPathExists = True
                        .Multiselect = False
                        If .ShowDialog = DialogResult.OK Then
                            PersonalPictureBox.Image = Image.FromFile(.FileName)
                            PersonalPictureBox.SizeMode = PictureBoxSizeMode.Zoom
                        End If
                    End With
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            PersonalPictureBox.Image = My.Resources.no_photo
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If String.IsNullOrEmpty(FullNameTextBox.Text) Then
            MsgBox("Full name : Required", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString()}
            Dim SqlStr As String =
                        ("INSERT INTO BasicInfo (UserName,UserAddrs,UserChildrn,UserBdate,UserImg,MStatusID) VALUES (?,?,?,?,?,?)")
            CN.Open()
            Using InsertCmd As New OleDbCommand With {.Connection = CN, .CommandType = CommandType.Text, .CommandText = SqlStr}
                Try
                    'Validate ComboBox
                    Dim M_ID As Integer
                    If MaritalComboBox.SelectedIndex = -1 Then
                        MaritalComboBox.SelectedIndex = MaritalComboBox.FindStringExact("NotSet")
                        MaritalComboBox.SelectedItem = MaritalComboBox.Items(MaritalComboBox.SelectedIndex)
                        M_ID = DirectCast(MaritalComboBox.SelectedItem, KeyValuePair(Of Integer, String)).Key()
                    Else
                        MaritalComboBox.SelectedItem = MaritalComboBox.Items(MaritalComboBox.SelectedIndex)
                        M_ID = DirectCast(MaritalComboBox.SelectedItem, KeyValuePair(Of Integer, String)).Key()
                    End If
                    Dim IMG As Bitmap = New Bitmap(PersonalPictureBox.Image)
                    With InsertCmd.Parameters
                        .AddWithValue("?", FullNameTextBox.Text)
                        .AddWithValue("?", FullAddressTextBox.Text)
                        .AddWithValue("?", CInt(ChildrenTextBox.Text))
                        .AddWithValue("?", BirthDateDTP.Value.ToShortDateString)
                        Using MyStream As New IO.MemoryStream
                            IMG.Save(MyStream, Imaging.ImageFormat.Png)
                            .AddWithValue("?", OleDbType.VarBinary).Value = MyStream.GetBuffer()
                        End Using
                        .AddWithValue("?", M_ID)
                    End With
                    LblStatus.Text = (InsertCmd.ExecuteNonQuery().ToString & " Saved successfully.")
                    'DataGridView------------------------
                    If BackgroundWorker2.IsBusy Then
                        BackgroundWorker2.CancelAsync()
                    End If
                    BackgroundWorker2.RunWorkerAsync()
                    '------------------------------------
                    clearAllCntrls()
                    UserSelectedRow = DisplayDGV.Rows.Count
                Catch ex As OleDbException
                    Debug.WriteLine("Save Error : " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub ChildrenTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ChildrenTextBox.KeyPress
        If (Not Char.IsControl(e.KeyChar) _
                AndAlso (Not Char.IsDigit(e.KeyChar) _
                AndAlso (e.KeyChar <> ChrW(46)))) Then
            e.Handled = True
        End If
    End Sub
    Private Sub ChildrenTextBox_TextChanged(sender As Object, e As EventArgs) Handles ChildrenTextBox.TextChanged
        If String.IsNullOrEmpty(ChildrenTextBox.Text) Then
            ChildrenTextBox.Text = 0
        End If
    End Sub
    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        'Search Term : Returns UserName that contains Any
        Dim SqlStr As String = String.Empty
        Dim SearchTerm As String = InputBox("Enter any part of User Name.")
        If String.IsNullOrEmpty(SearchTerm) Then
            SqlStr = ("SELECT * FROM BasicInfo LEFT JOIN MaritalStatus ON MaritalStatus.MStatusID = BasicInfo.MStatusID " &
                "ORDER BY BasicInfo.UserID ASC")
        Else
            SqlStr = ("SELECT * FROM BasicInfo LEFT JOIN MaritalStatus ON MaritalStatus.MStatusID = BasicInfo.MStatusID " &
                "WHERE BasicInfo.UserName Like '%" & SearchTerm & "%' ORDER BY BasicInfo.UserID ASC")
        End If
        If BackgroundWorker2.IsBusy Then
            BackgroundWorker2.CancelAsync()
        End If
        BGW_Reslt = SqlStr
        BackgroundWorker2.RunWorkerAsync(BGW_Reslt)
    End Sub
    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        'Update works only when DataGridView returns Data to Controls.
        Dim AreYouSure As MsgBoxResult = MsgBox("Update Data ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
        If AreYouSure = MsgBoxResult.No Then
            Exit Sub
        Else
            Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString()}
                Dim SqlStr As String =
                            ("Update BasicInfo SET UserName=?,UserAddrs=?,UserChildrn=?,UserBdate=?,UserImg=?,MStatusID=? WHERE UserID=?")
                CN.Open()
                Using UpdateCMD As New OleDbCommand With {.Connection = CN, .CommandType = CommandType.Text, .CommandText = SqlStr}
                    Try
                        'Validate ComboBox
                        Dim M_ID As Integer
                        If MaritalComboBox.SelectedIndex = -1 Then
                            MaritalComboBox.SelectedIndex = MaritalComboBox.FindStringExact("NotSet")
                        Else
                            MaritalComboBox.SelectedItem = MaritalComboBox.Items(MaritalComboBox.SelectedIndex)
                            M_ID = DirectCast(MaritalComboBox.SelectedItem, KeyValuePair(Of Integer, String)).Key()
                        End If
                        Dim IMG As Bitmap = New Bitmap(PersonalPictureBox.Image)
                        With UpdateCMD.Parameters
                            .AddWithValue("?", FullNameTextBox.Text)
                            .AddWithValue("?", FullAddressTextBox.Text)
                            .AddWithValue("?", CInt(ChildrenTextBox.Text))
                            .AddWithValue("?", BirthDateDTP.Value.ToShortDateString)
                            Using MyStream As New IO.MemoryStream
                                IMG.Save(MyStream, Imaging.ImageFormat.Png)
                                .AddWithValue("?", OleDbType.VarBinary).Value = MyStream.GetBuffer()
                            End Using
                            .AddWithValue("?", M_ID)
                            .AddWithValue("?", UserSelectedID)
                        End With
                        LblStatus.Text = (UpdateCMD.ExecuteNonQuery().ToString & " Updated successfully.")
                        'DataGridView---------------------
                        If BackgroundWorker2.IsBusy Then
                            BackgroundWorker2.CancelAsync()
                        End If
                        BackgroundWorker2.RunWorkerAsync()
                        '---------------------------------
                        clearAllCntrls()
                    Catch ex As OleDbException
                        Debug.WriteLine("Update Error : " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub
    Private Sub DisplayDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DisplayDGV.CellDoubleClick
        If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
        Try
            UserSelectedID = DisplayDGV(0, e.RowIndex).Value.ToString
            FullNameTextBox.Text = DisplayDGV(1, e.RowIndex).Value.ToString
            FullAddressTextBox.Text = DisplayDGV(2, e.RowIndex).Value.ToString
            ChildrenTextBox.Text = DisplayDGV(3, e.RowIndex).Value.ToString
            BirthDateDTP.Value = CDate(DisplayDGV(4, e.RowIndex).Value)
            Dim bytes As Byte() = DisplayDGV(5, e.RowIndex).Value
            Using ms As New IO.MemoryStream(bytes)
                PersonalPictureBox.Image = Image.FromStream(ms)
            End Using
            MaritalComboBox.SelectedIndex = MaritalComboBox.FindStringExact(DisplayDGV(8, e.RowIndex).Value.ToString)
            UpdateToolStripMenuItem.Enabled = True
            DeleteToolStripMenuItem.Enabled = True
            SaveToolStripMenuItem.Enabled = False
            UserSelectedRow = e.RowIndex
        Catch ex As Exception
            Debug.WriteLine("DataGridView Error : " & ex.Message)
        End Try
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        'Delete works only when DataGridView returns Data to Controls.
        Dim AreYouSure As MsgBoxResult = MsgBox("Delete Data ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
        If AreYouSure = MsgBoxResult.No Then
            Exit Sub
        Else
            Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString()}
                Dim SqlStr As String =
                            ("DELETE * FROM BasicInfo WHERE UserID=?")
                CN.Open()
                Using UpdateCMD As New OleDbCommand With {.Connection = CN, .CommandType = CommandType.Text, .CommandText = SqlStr}
                    Try
                        With UpdateCMD.Parameters
                            .AddWithValue("?", UserSelectedID)
                        End With
                        LblStatus.Text = (UpdateCMD.ExecuteNonQuery().ToString & " Deleted successfully.")
                        'DataGridView-------------------------
                        If BackgroundWorker2.IsBusy Then
                            BackgroundWorker2.CancelAsync()
                        End If
                        BackgroundWorker2.RunWorkerAsync()
                        '-------------------------------------
                        UserSelectedRow = 0
                        clearAllCntrls()
                    Catch ex As OleDbException
                        Debug.WriteLine("Delete Error : " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub
    Private Sub DisplayDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DisplayDGV.CellFormatting
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        Try
            If Not IsNothing(e.Value) Then
                If DisplayDGV.Columns(e.ColumnIndex).ValueType = GetType(Byte()) Then
                    Dim imageColumn = DirectCast(DisplayDGV.Columns("UserImg"), DataGridViewImageColumn)
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error Display Image : " & ex.Message)
        End Try
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(500)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString()}
            Try
                CN.Open()
                LblStatus.Text = ("Database connected")
                MaritalComboBox.Items.Clear()
                MaritalComboBox.DataSource = Nothing
                Dim SqlStr As String = ("SELECT * FROM MaritalStatus")
                Dim M_ComboItems As New Dictionary(Of Integer, String)()
                Using M_Cmd As New OleDbCommand With
                    {.Connection = CN, .CommandType = CommandType.Text, .CommandText = SqlStr}
                    Using M_Reader As OleDbDataReader = M_Cmd.ExecuteReader
                        If M_Reader.HasRows Then
                            While M_Reader.Read
                                M_ComboItems.Add(M_Reader!MStatusID, M_Reader!Mname)
                            End While
                        End If
                    End Using
                End Using
                With MaritalComboBox
                    .BeginUpdate()
                    .DataSource = New BindingSource(M_ComboItems, Nothing)
                    .DisplayMember = "Value"
                    .ValueMember = "key"
                    .Sorted = True
                    .SelectedIndex = -1
                    .EndUpdate()
                End With
            Catch ex As OleDbException
                LblStatus.Text = ("Database Error")
                Debug.WriteLine(ex.Message)
            End Try
        End Using
    End Sub
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        e.Result = BGW_Reslt
        Threading.Thread.Sleep(500)
    End Sub
    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Using CN As New OleDbConnection With {.ConnectionString = GetBuilderCNString()}
            Try
                CN.Open()
                DisplayDGV.DataSource = Nothing
                Using M_Cmd As New OleDbCommand With
                    {.Connection = CN, .CommandType = CommandType.Text, .CommandText = BGW_Reslt}
                    Using M_Reader As OleDbDataReader = M_Cmd.ExecuteReader
                        If M_Reader.HasRows Then
                            Using MyTable As New DataTable
                                For I As Integer = 0 To MyTable.Rows.Count - 1
                                    M_Reader.Read()
                                Next
                                MyTable.Load(M_Reader)
                                DisplayDGV.DataSource = MyTable
                                With DisplayDGV
                                    .Columns(0).HeaderText = ("ID")
                                    .Columns(1).HeaderText = ("Full Name")
                                    .Columns(2).HeaderText = ("Full Address")
                                    .Columns(3).HeaderText = ("Children")
                                    .Columns(4).HeaderText = ("Birth Date")
                                    .Columns(5).HeaderText = ("Image")
                                    .Columns(6).Visible = False
                                    .Columns(7).Visible = False
                                    .Columns(8).HeaderText = ("Martial Status")
                                End With
                            End Using
                        Else
                            MsgBox("No search results.")
                        End If
                    End Using
                End Using
                DisplayDGV.Rows(UserSelectedRow).Selected = True
                DisplayDGV.FirstDisplayedScrollingRowIndex = UserSelectedRow
            Catch ex As OleDbException
                Debug.WriteLine("Search Error : " & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub SAPCrystalReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAPCrystalReportsToolStripMenuItem.Click
        Dim CrysFrm As New CrystlalForm
        CrysFrm.Show()
        Hide()
    End Sub
    Private Async Sub DropboxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DropboxToolStripMenuItem.Click
        'Uploads Backed up Database file (*.accdb) to DropBox Application Folder.
        'Install Dropbox from Nuget that suits your .Net version first.
        Dim DropThis As New Drobbox
        Dim NewBakFile As String = "ThisDB.accdb" & Now.Date.ToShortDateString
        Try
            If ToolStripProgressBar1.Value <> 100 Then
                Try
                    IO.File.Copy("ThisDB.accdb", NewBakFile, True)
                Catch ex As IO.IOException
                    MsgBox("Error Copy : " & ex.Message)
                End Try
                ToolStripProgressBar1.Visible = True
                BackupToolStripMenuItem.Enabled = False
                DropLblUid.Text = Await DropThis.Run()
                Await DropThis.ChunkUpload(NewBakFile, ToolStripProgressBar1)
                BackupToolStripMenuItem.Enabled = True
                ToolStripProgressBar1.Visible = False
                DropLblUid.Text = ("Uploaded successfully. (" & Now.ToString("hh:mm:ss tt") & ")")
                Try
                    IO.File.Delete(NewBakFile)
                Catch ex As IO.IOException
                    MsgBox("Delete Error : " & ex.Message)
                End Try
            End If
        Catch ex As IO.IOException
            MsgBox(ex.Message)
        Finally
            DropboxToolStripMenuItem.Enabled = True
        End Try
    End Sub
End Class
