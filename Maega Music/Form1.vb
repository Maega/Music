Imports System.IO
Imports System.Net

Public Class Form1
    'Declarations
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim bordercolour As Pen = Pens.White
    Dim dbgstatus As Boolean = False
    Public localver As Decimal = 1.1

#Region "Mouse Click"
    Public Declare Auto Function SetCursorPos Lib "User32.dll" (ByVal X As Integer, ByVal Y As Integer) As Long
    Public Declare Auto Function GetCursorPos Lib "User32.dll" (ByRef lpPoint As Point) As Long
    Public Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cButtons As Long, ByVal dwExtraInfo As Long)
    Public Const MOUSEEVENTF_LEFTDOWN = &H2
    Public Const MOUSEEVENTF_LEFTUP = &H4

    Sub BypassMsg()
        Try
            Dim xl As Integer = Screen.PrimaryScreen.WorkingArea.Width - 10
            Dim yl As Integer = Screen.PrimaryScreen.WorkingArea.Height - 95
            SetCursorPos(xl, yl)
            Dim tempPos As Point
            Dim R As Long = GetCursorPos(tempPos)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        Catch ex As Exception
            'I should probably make something happen here...
        End Try
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'UNCOMMENT THE FOLLOWING LINE AFTER TESTING AND BEFORE DEPLOYING TO PRODUCTION
        tmrBypassMsg.Start()
    End Sub

    Private Sub tmrBypassMsg_Tick(sender As Object, e As EventArgs) Handles tmrBypassMsg.Tick
        tmrBypassMsg.Stop()
        BypassMsg()
    End Sub
#End Region


#Region "Resize"

    Dim onFullScreen As Boolean
    Dim maximized As Boolean
    Dim on_MinimumSize As Boolean
    Dim minimumWidth As Short = 900
    Dim minimumHeight As Short = 400
    Dim borderSpace As Short = 20
    Dim borderDiameter As Short = 8

    Dim onBorderRight As Boolean
    Dim onBorderLeft As Boolean
    Dim onBorderTop As Boolean
    Dim onBorderBottom As Boolean
    Dim onCornerTopRight As Boolean
    Dim onCornerTopLeft As Boolean
    Dim onCornerBottomRight As Boolean
    Dim onCornerBottomLeft As Boolean

    Dim movingRight As Boolean
    Dim movingLeft As Boolean
    Dim movingTop As Boolean
    Dim movingBottom As Boolean
    Dim movingCornerTopRight As Boolean
    Dim movingCornerTopLeft As Boolean
    Dim movingCornerBottomRight As Boolean
    Dim movingCornerBottomLeft As Boolean

    Private Sub Borderless_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WebView1.MouseDown
        If Me.Width >= 410 And Me.Width <= 450 Then
            Exit Sub
        ElseIf Me.Width >= 250 And Me.Width <= 300 Then
            Exit Sub
        End If
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If onBorderRight Then movingRight = True Else movingRight = False
            If onBorderLeft Then movingLeft = True Else movingLeft = False
            If onBorderTop Then movingTop = True Else movingTop = False
            If onBorderBottom Then movingBottom = True Else movingBottom = False
            If onCornerTopRight Then movingCornerTopRight = True Else movingCornerTopRight = False
            If onCornerTopLeft Then movingCornerTopLeft = True Else movingCornerTopLeft = False
            If onCornerBottomRight Then movingCornerBottomRight = True Else movingCornerBottomRight = False
            If onCornerBottomLeft Then movingCornerBottomLeft = True Else movingCornerBottomLeft = False
        End If
    End Sub

    Private Sub Borderless_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WebView1.MouseUp
        stopResizer()
        If Me.Width >= 410 And Me.Width <= 450 Then
            Exit Sub
        ElseIf Me.Width >= 250 And Me.Width <= 300 Then
            Exit Sub
        End If
        My.Settings.savedheight = Me.Height
        My.Settings.savedwidth = Me.Width
        Invalidate()
    End Sub

    Private Sub Borderless_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WebView1.MouseMove
        If onFullScreen Or maximized Then Exit Sub

        If Me.Width <= minimumWidth Then Me.Width = (minimumWidth + 5) : on_MinimumSize = True
        If Me.Height <= minimumHeight Then Me.Height = (minimumHeight + 5) : on_MinimumSize = True
        If on_MinimumSize Then stopResizer() Else startResizer()


        If (Cursor.Position.X > (Me.Location.X + Me.Width) - borderDiameter) _
            And (Cursor.Position.Y > (Me.Location.Y + borderSpace)) _
            And (Cursor.Position.Y < ((Me.Location.Y + Me.Height) - borderSpace)) Then
            Me.Cursor = Cursors.SizeWE
            onBorderRight = True

        ElseIf (Cursor.Position.X < (Me.Location.X + borderDiameter)) _
            And (Cursor.Position.Y > (Me.Location.Y + borderSpace)) _
            And (Cursor.Position.Y < ((Me.Location.Y + Me.Height) - borderSpace)) Then
            Me.Cursor = Cursors.SizeWE
            onBorderLeft = True

        ElseIf (Cursor.Position.Y < (Me.Location.Y + borderDiameter)) _
            And (Cursor.Position.X > (Me.Location.X + borderSpace)) _
            And (Cursor.Position.X < ((Me.Location.X + Me.Width) - borderSpace)) Then
            Me.Cursor = Cursors.SizeNS
            onBorderTop = True

        ElseIf (Cursor.Position.Y > ((Me.Location.Y + Me.Height) - borderDiameter)) _
            And (Cursor.Position.X > (Me.Location.X + borderSpace)) _
            And (Cursor.Position.X < ((Me.Location.X + Me.Width) - borderSpace)) Then
            Me.Cursor = Cursors.SizeNS
            onBorderBottom = True

        ElseIf (Cursor.Position.X = ((Me.Location.X + Me.Width) - 1)) _
            And (Cursor.Position.Y = Me.Location.Y) Then
            Me.Cursor = Cursors.SizeNESW
            onCornerTopRight = True

        ElseIf (Cursor.Position.X = Me.Location.X) _
            And (Cursor.Position.Y = Me.Location.Y) Then
            Me.Cursor = Cursors.SizeNWSE
            onCornerTopLeft = True

        ElseIf (Cursor.Position.X = ((Me.Location.X + Me.Width) - 1)) _
            And (Cursor.Position.Y = ((Me.Location.Y + Me.Height) - 1)) Then
            Me.Cursor = Cursors.SizeNWSE
            onCornerBottomRight = True

        ElseIf (Cursor.Position.X = Me.Location.X) _
            And (Cursor.Position.Y = ((Me.Location.Y + Me.Height) - 1)) Then
            Me.Cursor = Cursors.SizeNESW
            onCornerBottomLeft = True

        Else
            onBorderRight = False
            onBorderLeft = False
            onBorderTop = False
            onBorderBottom = False
            onCornerTopRight = False
            onCornerTopLeft = False
            onCornerBottomRight = False
            onCornerBottomLeft = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub startResizer()
        Select Case True

            Case movingRight
                Me.Width = (Cursor.Position.X - Me.Location.X)

            Case movingLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)

            Case movingTop
                Me.Height = ((Me.Height + Me.Location.Y) - Cursor.Position.Y)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingBottom
                Me.Height = (Cursor.Position.Y - Me.Location.Y)

            Case movingCornerTopRight
                Me.Width = (Cursor.Position.X - Me.Location.X)
                Me.Height = ((Me.Location.Y - Cursor.Position.Y) + Me.Height)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingCornerTopLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)
                Me.Height = ((Me.Height + Me.Location.Y) - Cursor.Position.Y)
                Me.Location = New Point(Me.Location.X, Cursor.Position.Y)

            Case movingCornerBottomRight
                Me.Size = New Point((Cursor.Position.X - Me.Location.X), (Cursor.Position.Y - Me.Location.Y))

            Case movingCornerBottomLeft
                Me.Width = ((Me.Width + Me.Location.X) - Cursor.Position.X)
                Me.Height = (Cursor.Position.Y - Me.Location.Y)
                Me.Location = New Point(Cursor.Position.X, Me.Location.Y)

        End Select
    End Sub

    Private Sub stopResizer()
        movingRight = False
        movingLeft = False
        movingTop = False
        movingBottom = False
        movingCornerTopRight = False
        movingCornerTopLeft = False
        movingCornerBottomRight = False
        movingCornerBottomLeft = False
        Me.Cursor = Cursors.Default
        Threading.Thread.Sleep(300)
        on_MinimumSize = False
    End Sub
#End Region

    Private Sub CenterForm()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Dim rect As New Rectangle(0, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height - 1)
        If My.Settings.bordercolour = "white" Then bordercolour = Pens.White
        If My.Settings.bordercolour = "blue" Then bordercolour = Pens.RoyalBlue
        If My.Settings.bordercolour = "red" Then bordercolour = Pens.Red
        If My.Settings.bordercolour = "green" Then bordercolour = Pens.Green
        If My.Settings.bordercolour = "yellow" Then bordercolour = Pens.Yellow
        e.Graphics.DrawRectangle(bordercolour, rect)
    End Sub

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
        DragPane.Focus()
        If Button1.Text = ">" Then
            Me.Height = My.Settings.savedheight
            Me.Width = My.Settings.savedwidth
            CenterForm()
            Invalidate()
            btnSettings.Show()
            If dbgstatus = True Then btnDebug.Show()
            btnCompact.Show()
            btnxsmall.Show()
            Me.TopMost = False
            Me.Opacity = 1
            ttpPrototype.SetToolTip(Me.Button1, "Quit Maega Music")
            Button1.Text = "X"
            WebView1.LoadUrl("http://music.maeganetwork.com")
        Else
            Dim result As Integer = MessageBox.Show("Are you sure you would like to quit Maega Music?", "Maega Music", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If My.Settings.savedwidth <= 500 Then My.Settings.savedwidth = 1300
                My.Settings.safeclose = True
                My.Settings.Save()
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub tmrLoading_Tick(sender As Object, e As EventArgs) Handles tmrLoading.Tick
        If My.Settings.dosequential = True Then
            tmrLoading.Enabled = False
            pnlLogo.Visible = False
        End If
        If Not pnlLogo.Top <= 260 Then
            pnlLogo.Top = pnlLogo.Top - 2
        Else
            tmrLoading.Stop()
            tmrLoadGone.Start()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.useexperimental = False Then
            CompatMode.Show()
            Me.Close()
            Exit Sub
        End If
        If My.Settings.safeclose = False Then
            Dim result As Integer = MessageBox.Show("It looks like Maega Music didn't close properly last session." + vbNewLine + "Would you like to leave experimental mode? ", "Maega Music", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                My.Settings.useexperimental = False
                My.Settings.Save()
                CompatMode.Show()
                Me.Close()
                Exit Sub
            End If
        End If
        My.Settings.safeclose = False
        My.Settings.Save()
        WebView1.LoadUrl("file:///" + System.IO.Directory.GetCurrentDirectory + "/appload.htm")
        Me.Height = My.Settings.savedheight
        Me.Width = My.Settings.savedwidth
        If dbgstatus = False Then btnDebug.Hide()
        CenterForm()
        Try
            Dim address As String = "http://update.maeganetwork.com/music/betaver.txt"
            Dim client As WebClient = New WebClient()
            Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
            Dim downver As Decimal = CDec(reader.ReadToEnd)
            If downver > localver Then
                Dim result As Integer = MessageBox.Show("An update is available for Maega Music, update now?", "Perform Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Try
                        Process.Start(Directory.GetCurrentDirectory + "\MaegaUpdate.exe")
                        Application.Exit()
                    Catch ex As Exception
                        MsgBox("The Maega Update tool appears to be missing, please reinstall Maega Music.", MsgBoxStyle.Critical, "Update Aborted")
                    End Try
                End If
            End If
        Catch exo As Exception
            MsgBox("Checking for updates has failed. The servers may be experiencing issues or Maega Music might need a manual update." + vbNewLine + vbNewLine + "Please try again later. If the problem persists, check https://music.maeganetwork.com/windows for more information.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub WebControl1_MouseEnter(sender As Object, e As EventArgs) Handles WebControl1.MouseEnter, DragPane.MouseEnter, DragPaneDark.MouseEnter, Me.MouseEnter, WebView1.MouseEnter
        If Button1.Text = ">" Then Me.Opacity = 1
    End Sub

    Private Sub WebControl1_MouseLeave(sender As Object, e As EventArgs) Handles WebControl1.MouseLeave, DragPane.MouseLeave, DragPaneDark.MouseLeave, Me.MouseLeave, WebView1.MouseEnter
        If Button1.Text = ">" Then Me.Opacity = My.Settings.miniopacity
    End Sub

#Region "Button Enter and Leave Events"
    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.Red
        Button1.ForeColor = Color.White
        If Button1.Text = ">" Then Me.Opacity = 1
    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(243, 243, 244)
        Button1.ForeColor = Color.FromArgb(51, 51, 51)
        If Button1.Text = ">" Then Me.Opacity = My.Settings.miniopacity
    End Sub

    Private Sub SteelBlue_MouseEnter(sender As Object, e As EventArgs) Handles btnxsmall.MouseEnter
        btnxsmall.BackColor = Color.FromArgb(153, 128, 255)
    End Sub

    Private Sub btnxsmall_MouseLeave(sender As Object, e As EventArgs) Handles btnxsmall.MouseLeave
        btnxsmall.BackColor = Color.FromArgb(243, 243, 244)
    End Sub

    Private Sub btnCompact_MouseEnter(sender As Object, e As EventArgs) Handles btnCompact.MouseEnter
        btnCompact.BackColor = Color.FromArgb(153, 128, 255)
    End Sub

    Private Sub btnCompact_MouseLeave(sender As Object, e As EventArgs) Handles btnCompact.MouseLeave
        btnCompact.BackColor = Color.FromArgb(243, 243, 244)
    End Sub
    Private Sub btnHelp_MouseEnter(sender As Object, e As EventArgs) Handles btnSettings.MouseEnter
        btnSettings.BackColor = Color.FromArgb(153, 128, 255)
    End Sub

    Private Sub btnHelp_MouseLeave(sender As Object, e As EventArgs) Handles btnSettings.MouseLeave
        btnSettings.BackColor = Color.FromArgb(243, 243, 244)
    End Sub

    Private Sub btnMinimise_MouseEnter(sender As Object, e As EventArgs) Handles btnMinimise.MouseEnter
        btnMinimise.BackColor = Color.FromArgb(153, 128, 255)
    End Sub

    Private Sub btnMinimise_MouseLeave(sender As Object, e As EventArgs) Handles btnMinimise.MouseLeave
        btnMinimise.BackColor = Color.FromArgb(243, 243, 244)
    End Sub

    Private Sub btnDebug_MouseEnter(sender As Object, e As EventArgs) Handles btnDebug.MouseEnter
        btnDebug.BackColor = Color.Red
    End Sub

    Private Sub btnDebug_MouseLeave(sender As Object, e As EventArgs) Handles btnDebug.MouseLeave
        btnDebug.BackColor = Color.FromArgb(243, 243, 244)
    End Sub
#End Region

    Private Sub btnxsmall_Click(sender As Object, e As EventArgs) Handles btnxsmall.Click
        DragPane.Focus()
        minimumHeight = 5
        minimumWidth = 5
        Me.Width = 280
        Me.Height = 73
        Invalidate()
        btnSettings.Hide()
        btnDebug.Hide()
        btnCompact.Hide()
        btnxsmall.Hide()
        Me.TopMost = True
        Me.Opacity = My.Settings.miniopacity
        Dim xloc As Integer = Screen.PrimaryScreen.WorkingArea.Width - 300
        Dim yloc As Integer = Screen.PrimaryScreen.WorkingArea.Height - 80
        Me.Location = New Point(xloc, yloc)
        ttpPrototype.SetToolTip(Me.Button1, "Return to Maega Music")
        Button1.Text = ">"
        WebView1.LoadUrl("http://music.maeganetwork.com")
    End Sub

    Private Sub btnCompact_Click(sender As Object, e As EventArgs) Handles btnCompact.Click
        DragPane.Focus()
        If minimumWidth = 425 Then
            minimumWidth = 900
            Me.Width = My.Settings.savedwidth
            Me.Height = My.Settings.savedheight
            ttpPrototype.SetToolTip(Me.btnCompact, "Enter Compact Mode")
            btnCompact.Text = "<"
            If dbgstatus = True Then btnDebug.Show()
            CenterForm()
            Me.Opacity = 1
            Invalidate()
            WebView1.LoadUrl("http://music.maeganetwork.com")
        Else
            minimumWidth = 425
            Me.Width = 430
            ttpPrototype.SetToolTip(Me.btnCompact, "Exit Compact Mode")
            btnCompact.Text = ">"
            btnDebug.Hide()
            CenterForm()
            Me.Opacity = My.Settings.compactopacity
            Invalidate()
            WebView1.LoadUrl("http://music.maeganetwork.com")
        End If
    End Sub

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        DragPane.Focus()
        frmDBGSettings.Show()
    End Sub

    Private Sub btnMinimise_Click(sender As Object, e As EventArgs) Handles btnMinimise.Click
        DragPane.Focus()
        Me.Hide()
        ntfTray.ShowBalloonTip(500)
    End Sub

    Private Sub cxtShowHide_Click(sender As Object, e As EventArgs) Handles cxtShowHide.Click
        ShowHide()
    End Sub

    Sub ShowHide()
        If My.Settings.useexperimental = True Then
            If Me.Visible = False Then
                Me.Show()
            Else
                Me.Hide()
            End If
        Else
            If CompatMode.Visible = False Then
                CompatMode.Show()
            Else
                CompatMode.Hide()
            End If
        End If
    End Sub

    Private Sub tmrLoadGone_Tick(sender As Object, e As EventArgs) Handles tmrLoadGone.Tick
        If WebView1.Url = "http://music.maeganetwork.com/" Or WebView1.Url = "http://music.maeganetwork.com/#/" Or WebView1.Url = "http://music.maeganetwork.com/#/new-releases/" Then
            tmrLoadGone.Stop()
            pnlLogo.Visible = False
        End If
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        DragPane.Focus()
        frmSettings.Show()
    End Sub

    Private Sub ntfTray_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ntfTray.MouseDoubleClick
        'ShowHide()
        If CompactMode.displayed = True Then
            CompactMode.tmrAnimation.Start()
        ElseIf CompactMode.displayed = False And CompatMode.Visible = False Then
            CompatMode.gocompact = True
            CompactMode.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 535, Screen.PrimaryScreen.WorkingArea.Height - -100)
            CompactMode.Show()
            CompactMode.tmrAnimation.Start()
        Else
            CompatMode.Hide()
        End If
    End Sub

    Private Sub WebURLChanged(sender As Object, e As EventArgs) Handles WebView1.UrlChanged
        If Not WebView1.Url.Contains("maeganetwork") And Not WebView1.Url.Contains("appload") Then
            WebView1.Url = "http://music.maeganetwork.com/"
        End If
    End Sub

    'Private Sub WebURLLoaded(sender As Object, e As EventArgs) Handles WebView1.LoadCompleted
    'If WebView1.Url.Contains("appload") Then
    'WebView1.LoadUrlAndWait("http://music.maeganetwork.com")
    'End If
    'End Sub

    Private Sub WebNewWindow(sender As Object, e As EO.WebBrowser.NewWindowEventArgs) Handles WebView1.NewWindow
        Dim result As Integer = MessageBox.Show("This will open a share link in your default browser, would you like to continue?", "Open External Link", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Process.Start(e.TargetUrl)
        End If
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreferencesToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub ExitMaegaMusicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitMaegaMusicToolStripMenuItem.Click
        ExitMusic()
    End Sub

    Sub ExitMusic()
        Dim result As Integer = MessageBox.Show("Are you sure you would like to quit Maega Music?", "Maega Music", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If My.Settings.savedwidth <= 500 Then My.Settings.savedwidth = 1300
            My.Settings.safeclose = True
            My.Settings.Save()
            CompactMode.Close()
            CompatMode.Close()
            Me.Close()
            'Application.Exit() ''Figure out why the hell this isn't working
            End
        End If
    End Sub

    'Private Sub WebLoadFailed(sender As Object, e As EventArgs) Handles WebView1.LoadFailed
    '   WebView1.LoadUrl("http://music.maeganetwork.com/")
    'End Sub
End Class
