Imports System.IO
Imports System.Net
Imports EO.WebBrowser

Public Class CompatMode
    Dim nPrefCommand As Integer = CommandIds.RegisterUserCommand("Preferences")
    Dim nExitCommand As Integer = CommandIds.RegisterUserCommand("Quit Maega Music")
    Public gocompact As Boolean = False
    Public appload As String = System.IO.Directory.GetCurrentDirectory + "/appload.htd"
    Public appintro As String = System.IO.Directory.GetCurrentDirectory + "/intro/intro.htd"

    Private Sub CompatMode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LicenseEO()
        Directory.SetCurrentDirectory(My.Application.Info.DirectoryPath)
        Me.Height = My.Settings.savedheight
        Me.Width = My.Settings.savedwidth
        Me.Opacity = My.Settings.mainopacity
        CenterForm()
        VerifyMarkup()
        'My.Settings.firstrun = True 'BOOLEAN OVERRIDE - REMOVE BEFORE PRODUCTION BUILD
        If My.Settings.firstrun = True Then
            My.Settings.firstrun = False
            My.Settings.Save()
            musicControl.LoadUrl("file:///" + appintro)
        Else
            musicControl.LoadUrl("file:///" + appload)
        End If

        '|--------------------------------------------------------------------------------------|
        '| Update Check. Add this to the initial form load event alongside the Maega Update API |
        '|--------------------------------------------------------------------------------------|
        My.Computer.Registry.SetValue(RegLoc, "AppDir", My.Application.Info.DirectoryPath)
        My.Computer.Registry.SetValue(RegLoc, "AppExe", Application.ExecutablePath)
        My.Computer.Registry.SetValue(RegLoc, "AppVer", CurrentVer)
        CheckForUpdates()
        '|--------------------------------------------------------------------------------------|
        '|                              End of Update Check.                                    |
        '|--------------------------------------------------------------------------------------|

        'Attach event handler
        AddHandler musicControl.BeforeContextMenu, New BeforeContextMenuHandler(AddressOf WebView_BeforeContextMenu)
        AddHandler musicControl.Command, New CommandHandler(AddressOf nRef_Command)
        AddHandler CompactMode.musicControl.BeforeContextMenu, New BeforeContextMenuHandler(AddressOf WebView_BeforeContextMenu)
        AddHandler CompactMode.musicControl.Command, New CommandHandler(AddressOf nRef_Command)
        AddHandler musicControl.NewWindow, New NewWindowHandler(AddressOf WebView_NewWindow)
        AddHandler CompactMode.musicControl.NewWindow, New NewWindowHandler(AddressOf WebView_NewWindow)
        CompactMode.Show()
    End Sub

    Public Sub VerifyMarkup()
        Dim veriStreamReaderL1 As System.IO.StreamReader
        'Dim veriStream As System.IO.StreamWriter
        Dim veriStr As String
        veriStreamReaderL1 = System.IO.File.OpenText(appload)
        veriStr = veriStreamReaderL1.ReadToEnd()
        veriStreamReaderL1.Close()
        If Not veriStr.Contains("<!--HTMLKEY=[" + My.Settings.htmlkey + "]-->") Then
            MsgBox("Whoa! It looks like we couldn't verify the authenticity of an important file associated with Maega Music." + vbNewLine + vbNewLine + "Please reinstall Maega Music. If the problem persists, please contact support at support@maeganetwork.com." + vbNewLine + vbNewLine + "Advanced Details: Phase One Markup Verification Failed. Markup key does not match the application key.", MsgBoxStyle.Critical)
            End
        ElseIf Not veriStr.Contains("<!--PHA2KEY=[" + My.Settings.pha2key + "]-->") Then
            MsgBox("Whoa! It looks like we couldn't verify the authenticity of an important file associated with Maega Music." + vbNewLine + vbNewLine + "Please reinstall Maega Music. If the problem persists, please contact support at support@maeganetwork.com." + vbNewLine + vbNewLine + "Advanced Details: Phase Two Markup Verification Failed. Markup key does not match the application key.", MsgBoxStyle.Critical)
            End
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmSettings.Show()
    End Sub

    Private Sub tmrLoadCheck_Tick(sender As Object, e As EventArgs) Handles tmrLoadCheck.Tick
        If musicControl.Url = "http://music.maeganetwork.com/" Or musicControl.Url = "http://music.maeganetwork.com/#/" Or musicControl.Url = "http://music.maeganetwork.com/#/new-releases/" Then
            tmrLoadCheck.Stop()
            Console.WriteLine("Maega Music server has been resolved. Now loading content...")
            'pnlDark.Visible = True
        End If
    End Sub

    Private Sub CompatMode_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing
        My.Settings.savedheight = Me.Height
        My.Settings.savedwidth = Me.Width
        My.Settings.Save()

        'CompactMode.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 535, Screen.PrimaryScreen.WorkingArea.Height - 805)
        'CompactMode.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 535, Screen.PrimaryScreen.WorkingArea.Height - 0)

        'gocompact = True
        'CompactMode.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 535, Screen.PrimaryScreen.WorkingArea.Height - -100)
        'CompactMode.Show()
        'CompactMode.tmrAnimation.Start()

        e.Cancel = True
        Me.Hide()

        'Form1.ntfTray.ShowBalloonTip()
    End Sub

    Private Sub CenterForm()
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub

    'Custom Context Menu - Refer to BeforeContextMenu event handler
    Private Sub WebView_BeforeContextMenu(sender As Object, e As BeforeContextMenuEventArgs)
        e.Menu.Items.Clear()
        e.Menu.Items.Add(
            New EO.WebBrowser.MenuItem("Refresh Maega Music", CommandIds.ReloadNoCache))
        'e.Menu.Items.Add(EO.WebBrowser.MenuItem.CreateSeparator())
        e.Menu.Items.Add(New EO.WebBrowser.MenuItem("Preferences", nPrefCommand))
        e.Menu.Items.Add(New EO.WebBrowser.MenuItem("Quit Maega Music", nExitCommand))
        'e.Menu.Items.Add(New EO.WebBrowser.MenuItem("Forward", CommandIds.Forward))
    End Sub

    Private Sub nRef_Command(sender As Object, e As CommandEventArgs)
        Dim webView As WebView = DirectCast(sender, WebView)
        If e.CommandId = nPrefCommand Then
            frmSettings.Show()
            'NotifyUser.Show()
        ElseIf e.CommandId = nExitCommand Then
            ExitMusic()
        End If
    End Sub

    Sub ExitMusic()
        Dim result As Integer = MessageBox.Show("Are you sure you would like to quit Maega Music?", "Maega Music", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            If My.Settings.savedwidth <= 500 Then My.Settings.savedwidth = 1300
            My.Settings.safeclose = True
            My.Settings.Save()
            CompactMode.Close()
            Me.Close()
            'Application.Exit() ''Figure out why this isn't working
            End
        End If
    End Sub

    Private Sub WebView_NewWindow(sender As Object, e As NewWindowEventArgs)
        'Below signifies that we accept the new WebView. Without this line
        'the newly created WebView will be immediately destroyed...
        'e.Accepted = True

        'REMEMBER TO ASSIGN THIS TARGETURL TO A NEW, SMALLER FORM WITH THE TOPMOST AND CENTERPARENT PROPERTIES!
        'THAT WAY IT'S SEAMLESS INSTEAD OF OPENING SOME TRASH LIKE EDGE FOR SOCIAL SHARING AND AD IMPRESSIONS!!!

        Process.Start(e.TargetUrl)

        'Below line would set the current WebView's URL to the target
        'That loads the page in the current WebView, instead of launching a browser or some other shit, duh.
        'webView.Url = e.TargetUrl
    End Sub

    Sub LicenseEO()
        'Here we add the license for EO.Total so that we can use the EO.WebBrowser library uninhibited by notifications
        EO.WebBrowser.Runtime.AddLicense("yuGhWabCnrWfWbP3+hLtmuv5AxC9seLXCNzDf9vKyN/QgbrNwdvBfLDZ+Oi8dab3+hLtmuv5AxC9RoGkseeupeDn9hnynrWRm3Xj7fQQ7azcwp61n1mz8PoO5Kfq6doPvWmstMjitWqstcXnrqXg5/YZ8p7A6M+4iVmXwP0U4p7l9/YQn6fY8fbooX7GsugQ4Xvp8wge5KuZws3a66La6f8e5J61kZvLn3XY8P0a9neEjrHLu5rb6LEf+KncwbPwzme67AMa7J6ZpLEh5Kvq7QAZvFuour/boVmmwp61n1mzs/IX66juwp61n1mz8wMP5KvA8vcan53Y+PbooWmps8HdrmuntcfNn6/c9gQU7qe0psI=")
    End Sub

    Private Sub ntfTray_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ntfTray.MouseDoubleClick
        ShowHideCompact()
    End Sub

    Private Sub ExitMuseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitMuseToolStripMenuItem.Click
        ExitMusic()
    End Sub

    Private Sub ShowCompactPlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowCompactPlayerToolStripMenuItem.Click
        ShowHideCompact()
    End Sub

    Private Sub ShowMuseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowMuseToolStripMenuItem.Click
        ShowHide()
    End Sub

    Sub ShowHide()
        If Me.Visible = False Then
            Me.Show()
        Else
            Me.Hide()
        End If
    End Sub

    Sub ShowHideCompact()
        If CompactMode.displayed = True Then
            CompactMode.tmrAnimation.Start()
        ElseIf CompactMode.displayed = False And Me.Visible = False Then
            gocompact = True
            CompactMode.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 535, Screen.PrimaryScreen.WorkingArea.Height - -100)
            CompactMode.Show()
            CompactMode.tmrAnimation.Start()
        Else
            Me.Hide()
        End If
    End Sub
End Class