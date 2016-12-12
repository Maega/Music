Public Class frmSettings
    Dim miniopacityS As String
    Dim miniopacityD As Decimal
    Dim miniopacityL As Decimal
    Dim miniopacityC As Integer
    Dim compactopacityS As String
    Dim compactopacityD As Decimal
    Dim compactopacityL As Decimal
    Dim compactopacityC As Integer
    Dim mainopacityS As String
    Dim mainopacityD As Decimal
    Dim mainopacityL As Decimal
    Dim mainopacityC As Integer

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles tbOMiniPlayer.Scroll
        TrackBarMPChanged()
    End Sub

    Sub TrackBarMPChanged()
        miniopacityS = "0." + tbOMiniPlayer.Value.ToString
        miniopacityD = CDec(miniopacityS)
        If miniopacityD = 0.1 Then miniopacityD = 1
        My.Settings.miniopacity = miniopacityD.ToString
        miniopacityL = My.Settings.miniopacity.ToString
        lblMiniOpacity.Text = "MiniPlayer Opacity: " + CStr(miniopacityL * 100) + "%"
        My.Settings.Save()
        'If Form1.Button1.Text = ">" Then Form1.Opacity = My.Settings.miniopacity
    End Sub

    Private Sub CenterForm()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.useexperimental = False Then
            'GroupBox1.Enabled = False
            'GroupBox1.Text = "Transparency Settings - Only takes effect in Experimental Mode"
            'GroupBox2.Enabled = False
            GroupBox2.Text = "Border Colour - Only takes effect in Experimental Mode"
        End If

        CenterForm()
        miniopacityL = My.Settings.miniopacity.ToString
        lblMiniOpacity.Text = CStr(miniopacityL * 100) + "%"
        miniopacityC = CInt(lblMiniOpacity.Text.Trim("0", "%", "."))
        If miniopacityC = 1 Then miniopacityC = 10
        tbOMiniPlayer.Value = miniopacityC
        lblMiniOpacity.Text = "MiniPlayer Opacity: " + CStr(miniopacityL * 100) + "%"

        compactopacityL = My.Settings.compactopacity.ToString
        lblCompactOpacity.Text = CStr(compactopacityL * 100) + "%"
        compactopacityC = CInt(lblCompactOpacity.Text.Trim("0", "%", "."))
        If compactopacityC = 1 Then compactopacityC = 10
        tbOCompact.Value = compactopacityC
        lblCompactOpacity.Text = "Compact Mode Opacity: " + CStr(compactopacityL * 100) + "%"

        mainopacityL = My.Settings.mainopacity.ToString
        lblMainOpacity.Text = CStr(mainopacityL * 100) + "%"
        mainopacityC = CInt(lblMainOpacity.Text.Trim("0", "%", "."))
        If mainopacityC = 1 Then mainopacityC = 10
        tbOMain.Value = mainopacityC
        lblMainOpacity.Text = "Normal Opacity: " + CStr(mainopacityL * 100) + "%"

        If My.Settings.bordercolour = "white" Then radWhite.Checked = True
        If My.Settings.bordercolour = "blue" Then radBlue.Checked = True
        If My.Settings.bordercolour = "red" Then radRed.Checked = True
        If My.Settings.bordercolour = "green" Then radGreen.Checked = True
        If My.Settings.bordercolour = "yellow" Then radYellow.Checked = True

        If My.Settings.useexperimental = True Then chkAlwaysSafe.Checked = True
    End Sub

    Private Sub btnMiniPlayerOpacityDefault_Click(sender As Object, e As EventArgs) Handles btnMiniPlayerOpacityDefault.Click
        tbOMiniPlayer.Value = 5
        TrackBarMPChanged()
    End Sub

    Private Sub GenuineButton1_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tbOCompact_Scroll(sender As Object, e As EventArgs) Handles tbOCompact.Scroll
        tbOCompactChanged()
    End Sub

    Sub tbOCompactChanged()
        compactopacityS = "0." + tbOCompact.Value.ToString
        compactopacityD = CDec(compactopacityS)
        If compactopacityD = 0.1 Then compactopacityD = 1
        My.Settings.compactopacity = compactopacityD.ToString
        compactopacityL = My.Settings.compactopacity.ToString
        lblCompactOpacity.Text = "Compact Mode Opacity: " + CStr(compactopacityL * 100) + "%"
        My.Settings.Save()
        'If Form1.btnCompact.Text = ">" Then Form1.Opacity = My.Settings.compactopacity
    End Sub

    Private Sub Bordercolour_CheckedChanged(sender As Object, e As EventArgs) Handles radWhite.CheckedChanged, radBlue.CheckedChanged, radGreen.CheckedChanged, radRed.CheckedChanged, radYellow.CheckedChanged
        If radWhite.Checked = True Then My.Settings.bordercolour = "white"
        If radBlue.Checked = True Then My.Settings.bordercolour = "blue"
        If radRed.Checked = True Then My.Settings.bordercolour = "red"
        If radGreen.Checked = True Then My.Settings.bordercolour = "green"
        If radYellow.Checked = True Then My.Settings.bordercolour = "yellow"
        CompatMode.Invalidate()
    End Sub

    Private Sub btnCompactOpacityDefault_Click(sender As Object, e As EventArgs) Handles btnCompactOpacityDefault.Click
        tbOCompact.Value = 10
        tbOCompactChanged()
    End Sub

    Private Sub tbOMainFrm_Scroll(sender As Object, e As EventArgs) Handles tbOMain.Scroll
        tbMainChanged()
    End Sub

    Sub tbMainChanged()
        mainopacityS = "0." + tbOMain.Value.ToString
        mainopacityD = CDec(mainopacityS)
        If mainopacityD = 0.1 Then mainopacityD = 1
        My.Settings.mainopacity = mainopacityD.ToString
        mainopacityL = My.Settings.mainopacity.ToString
        lblMainOpacity.Text = "Normal Opacity: " + CStr(mainopacityL * 100) + "%"
        My.Settings.Save()
        'If Form1.Width >= 700 Then Form1.Opacity = My.Settings.mainopacity
        CompatMode.Opacity = My.Settings.mainopacity
    End Sub

    Private Sub btnMainOpacityDefault_Click(sender As Object, e As EventArgs) Handles btnMainOpacityDefault.Click
        tbOMain.Value = 10
        tbMainChanged()
    End Sub

    Private Sub GenuineButton1_Click_1(sender As Object, e As EventArgs) Handles GenuineButton1.Click
        MsgBox("Maega Muse" + vbNewLine + "Maega Muse Client for Microsoft Windows" + vbNewLine + "Version: " + CurrentVer.ToString + vbNewLine + "Release Channel: Beta" + vbNewLine + vbNewLine + "This beta release is designed for consumer testing and bleeding edge users interested in trying out pre-release software. The software may change significantly before release and updates may be discontinued for this release channel without notification." + vbNewLine + vbNewLine + "Known Issues:" + vbNewLine + "Switching between players causes the currently playing track to stop.", MsgBoxStyle.Information, "About Maega Music")
    End Sub

    Private Sub GenuineButton2_Click(sender As Object, e As EventArgs) Handles btnResetAll.Click
        Dim result As Integer = MessageBox.Show("Are you sure you would like to reset all settings associated with Maega Music? Music will need to restart.", "Maega Music", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            My.Settings.Reset()
            My.Settings.Save()
            Application.Restart()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlwaysSafe.CheckedChanged
        If chkAlwaysSafe.Checked = True Then
            My.Settings.useexperimental = True
            My.Settings.safeclose = True
        Else
            My.Settings.useexperimental = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub GenuineTheme1_Click(sender As Object, e As EventArgs)

    End Sub
End Class