Public Class Form1
    'Declarations
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DragPane.MouseDown, DragPaneDark.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = System.Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = System.Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DragPane.MouseMove, DragPaneDark.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = System.Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = System.Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DragPane.MouseUp, DragPaneDark.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub tmrLoading_Tick(sender As Object, e As EventArgs) Handles tmrLoading.Tick
        If My.Settings.dosequential = True Then
            tmrLoading.Enabled = False
            pnlLogo.Visible = False
            lblLoading.Visible = False
        End If
        If Not lblLoading.Top <= 0 Then
            lblLoading.Top = lblLoading.Top - 2
        End If
        If Not lblLoading.Left <= 0 Then
            lblLoading.Left = lblLoading.Left - 2.6
        Else
            lblLoading.BackColor = Color.FromArgb(37, 37, 40)
            lblLoading.ForeColor = Color.White
            lblLoading.Width = 222
            lblLoading.Height = 21
            lblLoading.Font = New Font("Segoe UI Light", 12) 'FontStyle.Bold)
        End If
        If Not lblLoading.Font.Size <= 12 Then
            lblLoading.Font = New Font("Segoe UI Light", lblLoading.Font.Size - 0.2) 'FontStyle.Bold)
        End If
        If Not pnlLogo.Top <= 260 Then
            pnlLogo.Top = pnlLogo.Top - 2
        End If
        'lblLoading.Width = lblLoading.Width - 1
        'lblLoading.Height = lblLoading.Height - 1

        'lblLoading.Visible = False
    End Sub

    Private Sub tmrLoadGone_Tick(sender As Object, e As EventArgs) Handles tmrLoadGone.Tick
        lblLoading.Visible = False
        pnlLogo.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MsgBox("Maega Music" + vbNewLine + "Maega Music Client for Microsoft Windows" + vbNewLine + "Version: 1.0 - Milestone 1" + vbNewLine + vbNewLine + "This prototype software is not intended for release. It's designed for inhouse testing of different technologies that could be used to develop a Windows client for Maega Music. THIS SOFTWARE IS NOT FOR DISTRIBUTION!")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnKill.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        frmDBGSettings.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        If My.Settings.adminenabled = True Then
            WebView1.LoadUrl("http://music.maeganetwork.com/#/admin/settings")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.userbeta = True Then
            btnAdmin.Hide()
            btnDebug.Hide()
            btnKill.Hide()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        WebView1.LoadUrl("http://music.maeganetwork.com")
    End Sub
End Class
