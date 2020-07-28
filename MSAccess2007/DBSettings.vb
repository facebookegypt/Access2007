Imports System.ComponentModel
Public Class DBSettings
    Private StrOutPuts As String = String.Empty
    Private StrSignature As String = String.Empty
    Dim dbname As String = String.Empty
    Private Sub DBSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
    End Sub
    Private Sub DBSettings_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub DBSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LocationTxt.Text = DatabaseSettings._GetDPath
        Try
            AccssInstledTxt.Text = String.Join(",", DatabaseSettings.AccessInstalleds)
            DBENGTxt.Text = String.Join(vbCrLf, DatabaseSettings.GetMSProvider)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub lblBrowse_Click(sender As Object, e As EventArgs) Handles lblBrowse.Click
        Try
            Using OFD As New OpenFileDialog
                With OFD
                    .Filter = ("Microsoft Access Database 07~19 (*.accdb)|*.accdb|All files(*.*)|*.*")
                    .FilterIndex = 1
                    .RestoreDirectory = True
                    .CheckFileExists = True
                    .CheckPathExists = True
                    .Multiselect = False
                    If .ShowDialog = DialogResult.OK Then
                        LocationTxt.Text = OFD.FileName
                        dbname = OFD.SafeFileName
                        If BackgroundWorker1.IsBusy Then
                            BackgroundWorker1.CancelAsync()
                        End If
                        BackgroundWorker1.RunWorkerAsync()
                    Else
                        Exit Sub
                    End If
                End With
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        StrOutPuts = DatabaseSettings.GetHeader(LocationTxt.Text)
        Dim AsciiOutPuts As Text.StringBuilder = New Text.StringBuilder
        Dim ThisList As New List(Of String)
        ThisList.AddRange(StrOutPuts.Split(String.Empty.ToCharArray, StringSplitOptions.RemoveEmptyEntries))
        For Each Str As String In ThisList
            If Str.Length = 2 Then
                AsciiOutPuts.Append(Chr(CInt("&H" & Str)))
                StrSignature = AsciiOutPuts.ToString
            End If
        Next
        FileSignText.Text = StrSignature.Remove(15)
        DatabaseSettings._GetDBName = dbname
        DatabaseSettings._GetDPath = LocationTxt.Text
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(500)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DBPass1 = InputBox("Enter Database Password")
        AppConfig.AddUpdateAppSettings("ThisPassword", DBPass1)
        With TreeView1
            .Nodes.Clear()
            .BeginUpdate()
            .Nodes.Add(DatabaseSettings.GetFileInfo(LocationTxt.Text))
            .ExpandAll()
            .EndUpdate()
        End With
    End Sub
    Private Sub FileSignText_TextChanged(sender As Object, e As EventArgs) Handles FileSignText.TextChanged
        Try
            Label7.Text = String.Empty
            If FileSignText.Text.Contains("Standard ACE") Then
                Label7.Text = ("Microsoft Access 2007")
            ElseIf FileSignText.Text.Contains("Standard Jet") Then
                Label7.Text = ("Microsoft Access 2003")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Label8_Click_1(sender As Object, e As EventArgs) Handles Label8.Click
        Dim sQLfRM As New ExtendedProp
        sQLfRM.Show()
        Hide()
    End Sub
End Class