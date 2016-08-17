Imports System.IO
Imports System.Net
Imports EO.WebBrowser

Public Class CompatMode
    Dim nPrefCommand As Integer = CommandIds.RegisterUserCommand("Preferences")
    Dim nExitCommand As Integer = CommandIds.RegisterUserCommand("Quit Maega Music")
    Public gocompact As Boolean = False
    Public appload As String = System.IO.Directory.GetCurrentDirectory + "/appload.htm"
    Private Sub CompatMode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LicenseEO()
        If My.Settings.useexperimental = True Then
            Form1.Show()
            Me.Close()
        End If
        Me.Height = My.Settings.savedheight
        Me.Width = My.Settings.savedwidth
        Me.Opacity = My.Settings.mainopacity
        CenterForm()
        VerifyMarkup()
        musicControl.LoadUrl("file:///" + appload)
        Try
            Dim address As String = "http://update.maeganetwork.com/music/betaver.txt"
            Dim client As WebClient = New WebClient()
            Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
            Dim downver As Decimal = CDec(reader.ReadToEnd)
            If downver > Form1.localver Then
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
        Dim veriStream As System.IO.StreamWriter
        Dim veriStr As String
        veriStreamReaderL1 = System.IO.File.OpenText(appload)
        veriStr = veriStreamReaderL1.ReadToEnd()
        veriStreamReaderL1.Close()
        If Not veriStr.Contains("<!--HTMLKEY=[" + My.Settings.htmlkey + "]-->") Then
            MsgBox("Whoa! It looks like we couldn't verify the authenticity of an important file associated with Maega Music." + vbNewLine + vbNewLine + "Please reinstall Maega Music. If the problem persists, please contact support at support@maeganetwork.com." + vbNewLine + vbNewLine + "Advanced Details: Phase One Markup Verification Failed. Markup key does not match the application key.", MsgBoxStyle.Critical)
            End
        Else
            If Not veriStr.Contains("<!--PHA2KEY=[" + My.Settings.pha2key + "]-->") Then
                MsgBox("Whoa! It looks like we couldn't verify the authenticity of an important file associated with Maega Music." + vbNewLine + vbNewLine + "Please reinstall Maega Music. If the problem persists, please contact support at support@maeganetwork.com." + vbNewLine + vbNewLine + "Advanced Details: Phase Two Markup Verification Failed. Markup key does not match the application key.", MsgBoxStyle.Critical)
                End
            End If
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
            Form1.ExitMusic()
        End If
    End Sub

    Private Sub WebView_NewWindow(sender As Object, e As NewWindowEventArgs)
        'The new WebView has already been created (e.WebView). Here we
        'associates it with a new WebViewItem object and creates a
        'new tab button for it (by adding it to m_Pages)
        'Dim item As WebViewItem = NewWebViewItem(e.WebView)

        'Signifies that we accept the new WebView. Without this line
        'the newly created WebView will be immediately destroyed

        'REMEMBER TO ASSIGN THIS TARGETURL TO A NEW, SMALLER FORM WITH THE TOPMOST AND CENTERPARENT PROPERTIES!
        'THAT WAY SHIT'S SEAMLESS INSTEAD OF OPENING SOME TRASH LIKE EDGE FOR SOCIAL SHARING AND AD IMPRESSIONS!!!
        'ALSO GET THOSE FUCKING BANNER ADS SORTED! POPUPS AND INTERSTITIALS ARE CANCER!

        Process.Start(e.TargetUrl)
        'e.Accepted = True

        'If you do not want to open a new window but wish to open
        'the new Url in the same window, comment the code above
        'and uncomment the code below. The code below set the existing
        'WebView's Url to the new Url. Also because it did not set
        'e.Accepted to true, so the new WebView will be discarded.
        'EO.WebBrowser.WebView webView = (EO.WebBrowser.WebView)sender;
        'webView.Url = e.TargetUrl;
    End Sub

    Sub LicenseEO()
        EO.WebBrowser.Runtime.AddLicense("yuGhWabCnrWfWbP3+hLtmuv5AxC9seLXCNzDf9vKyN/QgbrNwdvBfLDZ+Oi8dab3+hLtmuv5AxC9RoGkseeupeDn9hnynrWRm3Xj7fQQ7azcwp61n1mz8PoO5Kfq6doPvWmstMjitWqstcXnrqXg5/YZ8p7A6M+4iVmXwP0U4p7l9/YQn6fY8fbooX7GsugQ4Xvp8wge5KuZws3a66La6f8e5J61kZvLn3XY8P0a9neEjrHLu5rb6LEf+KncwbPwzme67AMa7J6ZpLEh5Kvq7QAZvFuour/boVmmwp61n1mzs/IX66juwp61n1mz8wMP5KvA8vcan53Y+PbooWmps8HdrmuntcfNn6/c9gQU7qe0psI=")
    End Sub
End Class