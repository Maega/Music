<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompactMode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompactMode))
        Me.musicView = New EO.WebBrowser.WinForm.WebControl()
        Me.musicControl = New EO.WebBrowser.WebView()
        Me.tmrAnimation = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'musicView
        '
        Me.musicView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.musicView.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.musicView.Location = New System.Drawing.Point(2, 24)
        Me.musicView.Name = "musicView"
        Me.musicView.Size = New System.Drawing.Size(511, 734)
        Me.musicView.TabIndex = 2
        Me.musicView.Text = "WebControl1"
        Me.musicView.WebView = Me.musicControl
        '
        'musicControl
        '
        Me.musicControl.Url = ""
        '
        'tmrAnimation
        '
        Me.tmrAnimation.Interval = 1
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(438, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CompactMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 761)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.musicView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CompactMode"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Maega Music"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents musicView As EO.WebBrowser.WinForm.WebControl
    Friend WithEvents musicControl As EO.WebBrowser.WebView
    Friend WithEvents tmrAnimation As Timer
    Friend WithEvents Button1 As Button
End Class
