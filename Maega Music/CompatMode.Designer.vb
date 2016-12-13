<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompatMode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompatMode))
        Me.musicView = New EO.WebBrowser.WinForm.WebControl()
        Me.musicControl = New EO.WebBrowser.WebView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlDark = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tmrLoadCheck = New System.Windows.Forms.Timer(Me.components)
        Me.ntfTray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cxtTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowCompactPlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowMuseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMuseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlDark.SuspendLayout()
        Me.cxtTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'musicView
        '
        Me.musicView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.musicView.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.musicView.Location = New System.Drawing.Point(3, 1)
        Me.musicView.Name = "musicView"
        Me.musicView.Size = New System.Drawing.Size(1399, 727)
        Me.musicView.TabIndex = 1
        Me.musicView.Text = "WebControl1"
        Me.musicView.WebView = Me.musicControl
        '
        'musicControl
        '
        Me.musicControl.Url = ""
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(6, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "File"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(39, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 20)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Edit"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'pnlDark
        '
        Me.pnlDark.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.pnlDark.Controls.Add(Me.Button4)
        Me.pnlDark.Controls.Add(Me.Button3)
        Me.pnlDark.Controls.Add(Me.Button2)
        Me.pnlDark.Location = New System.Drawing.Point(3, -3)
        Me.pnlDark.Name = "pnlDark"
        Me.pnlDark.Size = New System.Drawing.Size(220, 27)
        Me.pnlDark.TabIndex = 5
        Me.pnlDark.Visible = False
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(76, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 20)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Preferences"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'tmrLoadCheck
        '
        Me.tmrLoadCheck.Enabled = True
        Me.tmrLoadCheck.Interval = 2000
        '
        'ntfTray
        '
        Me.ntfTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ntfTray.BalloonTipText = "To restore Maega Muse, double click its icon in the tray"
        Me.ntfTray.BalloonTipTitle = "Maega Muse Minimised"
        Me.ntfTray.ContextMenuStrip = Me.cxtTray
        Me.ntfTray.Icon = CType(resources.GetObject("ntfTray.Icon"), System.Drawing.Icon)
        Me.ntfTray.Text = "Maega Muse"
        Me.ntfTray.Visible = True
        '
        'cxtTray
        '
        Me.cxtTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowCompactPlayerToolStripMenuItem, Me.ShowMuseToolStripMenuItem, Me.ExitMuseToolStripMenuItem})
        Me.cxtTray.Name = "cxtTray"
        Me.cxtTray.Size = New System.Drawing.Size(191, 70)
        '
        'ShowCompactPlayerToolStripMenuItem
        '
        Me.ShowCompactPlayerToolStripMenuItem.Name = "ShowCompactPlayerToolStripMenuItem"
        Me.ShowCompactPlayerToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ShowCompactPlayerToolStripMenuItem.Text = "Show Compact Player"
        '
        'ShowMuseToolStripMenuItem
        '
        Me.ShowMuseToolStripMenuItem.Name = "ShowMuseToolStripMenuItem"
        Me.ShowMuseToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ShowMuseToolStripMenuItem.Text = "Show Muse"
        '
        'ExitMuseToolStripMenuItem
        '
        Me.ExitMuseToolStripMenuItem.Name = "ExitMuseToolStripMenuItem"
        Me.ExitMuseToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ExitMuseToolStripMenuItem.Text = "Exit Muse"
        '
        'CompatMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1404, 731)
        Me.Controls.Add(Me.musicView)
        Me.Controls.Add(Me.pnlDark)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CompatMode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maega Muse Beta 1 (Codename Bombay Rock)"
        Me.pnlDark.ResumeLayout(False)
        Me.cxtTray.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents musicView As EO.WebBrowser.WinForm.WebControl
    Friend WithEvents musicControl As EO.WebBrowser.WebView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents pnlDark As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents tmrLoadCheck As Timer
    Friend WithEvents ntfTray As NotifyIcon
    Friend WithEvents cxtTray As ContextMenuStrip
    Friend WithEvents ExitMuseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowCompactPlayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowMuseToolStripMenuItem As ToolStripMenuItem
End Class
