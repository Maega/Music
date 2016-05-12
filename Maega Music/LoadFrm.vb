Public Class LoadFrm
    Private Sub LoadFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Dim result As Integer = MessageBox.Show("Maega Music can be loaded normally or in SAFE mode." + vbNewLine + "Would you like to load in SAFE to attempt to prevent a hang?", "Maega Music Prototype B6r1", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Application.Exit()
        ElseIf result = DialogResult.No Then
            Form1.Show()
            Me.Close()
        ElseIf result = DialogResult.Yes Then
            My.Settings.dosequential = True
            'Form1.WebControl1.Enabled = False
            Form1.Show()
            Me.Close()
        End If
    End Sub
End Class