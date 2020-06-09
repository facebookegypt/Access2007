Public Class CrystlalForm
    Private Sub CrystlalForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim Frm As New Form1
        Frm.Show()
    End Sub
    Private Sub CrystlalForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub CrystlalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class