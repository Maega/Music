<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.WebControl1 = New EO.WebBrowser.WinForm.WebControl()
        Me.WebView1 = New EO.WebBrowser.WebView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DragPane = New System.Windows.Forms.Panel()
        Me.DragPaneDark = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnDebug = New System.Windows.Forms.Button()
        Me.btnCompact = New System.Windows.Forms.Button()
        Me.btnMinimise = New System.Windows.Forms.Button()
        Me.btnxsmall = New System.Windows.Forms.Button()
        Me.tmrLoading = New System.Windows.Forms.Timer(Me.components)
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ttpPrototype = New System.Windows.Forms.ToolTip(Me.components)
        Me.ntfTray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cxtTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxtShowHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMaegaMusicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrLoadGone = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBypassMsg = New System.Windows.Forms.Timer(Me.components)
        Me.DragPaneDark.SuspendLayout()
        Me.pnlLogo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cxtTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebControl1
        '
        Me.WebControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.WebControl1.Location = New System.Drawing.Point(1, 26)
        Me.WebControl1.Name = "WebControl1"
        Me.WebControl1.Size = New System.Drawing.Size(1296, 673)
        Me.WebControl1.TabIndex = 0
        Me.WebControl1.Text = "WebControl1"
        Me.WebControl1.WebView = Me.WebView1
        '
        'WebView1
        '
        Me.WebView1.Url = "music.maeganetwork.com/appload.html"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(1041, -2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "X"
        Me.ttpPrototype.SetToolTip(Me.Button1, "Quit Maega Music")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DragPane
        '
        Me.DragPane.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.DragPane.Location = New System.Drawing.Point(1, 2)
        Me.DragPane.Name = "DragPane"
        Me.DragPane.Size = New System.Drawing.Size(222, 25)
        Me.DragPane.TabIndex = 2
        '
        'DragPaneDark
        '
        Me.DragPaneDark.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DragPaneDark.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.DragPaneDark.Controls.Add(Me.btnDebug)
        Me.DragPaneDark.Controls.Add(Me.Button1)
        Me.DragPaneDark.Controls.Add(Me.btnSettings)
        Me.DragPaneDark.Controls.Add(Me.btnCompact)
        Me.DragPaneDark.Controls.Add(Me.btnxsmall)
        Me.DragPaneDark.Controls.Add(Me.btnMinimise)
        Me.DragPaneDark.Location = New System.Drawing.Point(222, 2)
        Me.DragPaneDark.Name = "DragPaneDark"
        Me.DragPaneDark.Size = New System.Drawing.Size(1075, 25)
        Me.DragPaneDark.TabIndex = 3
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.btnSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnSettings.Location = New System.Drawing.Point(939, -2)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(34, 27)
        Me.btnSettings.TabIndex = 19
        Me.btnSettings.Text = "[ ]"
        Me.ttpPrototype.SetToolTip(Me.btnSettings, "Enter Settings")
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnDebug
        '
        Me.btnDebug.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDebug.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnDebug.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnDebug.FlatAppearance.BorderSize = 0
        Me.btnDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDebug.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.btnDebug.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnDebug.Location = New System.Drawing.Point(871, -2)
        Me.btnDebug.Name = "btnDebug"
        Me.btnDebug.Size = New System.Drawing.Size(34, 27)
        Me.btnDebug.TabIndex = 18
        Me.btnDebug.Text = "!"
        Me.ttpPrototype.SetToolTip(Me.btnDebug, "Enter Debug Settings")
        Me.btnDebug.UseVisualStyleBackColor = False
        '
        'btnCompact
        '
        Me.btnCompact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCompact.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnCompact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnCompact.FlatAppearance.BorderSize = 0
        Me.btnCompact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCompact.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.btnCompact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnCompact.Location = New System.Drawing.Point(1007, -2)
        Me.btnCompact.Name = "btnCompact"
        Me.btnCompact.Size = New System.Drawing.Size(34, 27)
        Me.btnCompact.TabIndex = 17
        Me.btnCompact.Text = "<"
        Me.ttpPrototype.SetToolTip(Me.btnCompact, "Enter Compact Mode")
        Me.btnCompact.UseVisualStyleBackColor = False
        '
        'btnMinimise
        '
        Me.btnMinimise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimise.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnMinimise.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnMinimise.FlatAppearance.BorderSize = 0
        Me.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimise.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.btnMinimise.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnMinimise.Location = New System.Drawing.Point(905, -2)
        Me.btnMinimise.Name = "btnMinimise"
        Me.btnMinimise.Size = New System.Drawing.Size(34, 27)
        Me.btnMinimise.TabIndex = 16
        Me.btnMinimise.Text = "_"
        Me.ttpPrototype.SetToolTip(Me.btnMinimise, "Minimise Maega Music")
        Me.btnMinimise.UseVisualStyleBackColor = False
        '
        'btnxsmall
        '
        Me.btnxsmall.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnxsmall.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnxsmall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.btnxsmall.FlatAppearance.BorderSize = 0
        Me.btnxsmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnxsmall.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.btnxsmall.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnxsmall.Location = New System.Drawing.Point(973, -2)
        Me.btnxsmall.Name = "btnxsmall"
        Me.btnxsmall.Size = New System.Drawing.Size(34, 27)
        Me.btnxsmall.TabIndex = 14
        Me.btnxsmall.Text = "<<"
        Me.ttpPrototype.SetToolTip(Me.btnxsmall, "Enter MiniPlayer Mode")
        Me.btnxsmall.UseVisualStyleBackColor = False
        '
        'tmrLoading
        '
        Me.tmrLoading.Interval = 5
        '
        'pnlLogo
        '
        Me.pnlLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.pnlLogo.Controls.Add(Me.Label2)
        Me.pnlLogo.Controls.Add(Me.PictureBox1)
        Me.pnlLogo.Location = New System.Drawing.Point(456, 442)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(406, 191)
        Me.pnlLogo.TabIndex = 5
        Me.pnlLogo.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(200, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CLOSED BETA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PictureBox1.Image = Global.Maega_Music.My.Resources.Resources.logo_light
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(399, 184)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ttpPrototype
        '
        Me.ttpPrototype.AutomaticDelay = 0
        Me.ttpPrototype.AutoPopDelay = 0
        Me.ttpPrototype.InitialDelay = 0
        Me.ttpPrototype.IsBalloon = True
        Me.ttpPrototype.ReshowDelay = 0
        Me.ttpPrototype.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ttpPrototype.ToolTipTitle = "Information"
        '
        'ntfTray
        '
        Me.ntfTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ntfTray.BalloonTipText = "To restore Maega Music, double click its icon in the tray"
        Me.ntfTray.BalloonTipTitle = "Maega Music Minimised"
        Me.ntfTray.ContextMenuStrip = Me.cxtTray
        Me.ntfTray.Icon = CType(resources.GetObject("ntfTray.Icon"), System.Drawing.Icon)
        Me.ntfTray.Text = "Maega Music"
        Me.ntfTray.Visible = True
        '
        'cxtTray
        '
        Me.cxtTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxtShowHide, Me.PreferencesToolStripMenuItem, Me.ExitMaegaMusicToolStripMenuItem})
        Me.cxtTray.Name = "cxtTray"
        Me.cxtTray.Size = New System.Drawing.Size(167, 70)
        '
        'cxtShowHide
        '
        Me.cxtShowHide.Name = "cxtShowHide"
        Me.cxtShowHide.Size = New System.Drawing.Size(166, 22)
        Me.cxtShowHide.Text = "Show/Hide"
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'ExitMaegaMusicToolStripMenuItem
        '
        Me.ExitMaegaMusicToolStripMenuItem.Name = "ExitMaegaMusicToolStripMenuItem"
        Me.ExitMaegaMusicToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ExitMaegaMusicToolStripMenuItem.Text = "Exit Maega Music"
        '
        'tmrLoadGone
        '
        Me.tmrLoadGone.Interval = 50
        '
        'tmrBypassMsg
        '
        Me.tmrBypassMsg.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(1300, 700)
        Me.Controls.Add(Me.pnlLogo)
        Me.Controls.Add(Me.DragPaneDark)
        Me.Controls.Add(Me.DragPane)
        Me.Controls.Add(Me.WebControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.DragPaneDark.ResumeLayout(False)
        Me.pnlLogo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cxtTray.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebControl1 As EO.WebBrowser.WinForm.WebControl
    Friend WithEvents WebView1 As EO.WebBrowser.WebView
    Friend WithEvents Button1 As Button
    Friend WithEvents DragPane As Panel
    Friend WithEvents DragPaneDark As Panel
    Friend WithEvents tmrLoading As Timer
    Friend WithEvents pnlLogo As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ttpPrototype As ToolTip
    Friend WithEvents btnxsmall As Button
    Friend WithEvents btnMinimise As Button
    Friend WithEvents btnCompact As Button
    Friend WithEvents btnDebug As Button
    Friend WithEvents ntfTray As NotifyIcon
    Friend WithEvents cxtTray As ContextMenuStrip
    Friend WithEvents cxtShowHide As ToolStripMenuItem
    Friend WithEvents tmrLoadGone As Timer
    Friend WithEvents tmrBypassMsg As Timer
    Friend WithEvents btnSettings As Button
    Friend WithEvents PreferencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitMaegaMusicToolStripMenuItem As ToolStripMenuItem
End Class
