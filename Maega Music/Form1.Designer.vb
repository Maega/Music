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
        Me.WebControl1 = New EO.WebBrowser.WinForm.WebControl()
        Me.WebView1 = New EO.WebBrowser.WebView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DragPane = New System.Windows.Forms.Panel()
        Me.DragPaneDark = New System.Windows.Forms.Panel()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblLoading = New System.Windows.Forms.Label()
        Me.tmrLoading = New System.Windows.Forms.Timer(Me.components)
        Me.tmrLoadGone = New System.Windows.Forms.Timer(Me.components)
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ttpPrototype = New System.Windows.Forms.ToolTip(Me.components)
        Me.DragPaneDark.SuspendLayout()
        Me.pnlLogo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebControl1
        '
        Me.WebControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.WebControl1.Location = New System.Drawing.Point(1, 23)
        Me.WebControl1.Name = "WebControl1"
        Me.WebControl1.Size = New System.Drawing.Size(1299, 676)
        Me.WebControl1.TabIndex = 0
        Me.WebControl1.Text = "WebControl1"
        Me.WebControl1.WebView = Me.WebView1
        '
        'WebView1
        '
        Me.WebView1.Url = "maeganetwork.com/music/premium"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1047, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 21)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "X"
        Me.ttpPrototype.SetToolTip(Me.Button1, "Terminate the application (Application.Exit)")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DragPane
        '
        Me.DragPane.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.DragPane.Location = New System.Drawing.Point(1, 2)
        Me.DragPane.Name = "DragPane"
        Me.DragPane.Size = New System.Drawing.Size(222, 21)
        Me.DragPane.TabIndex = 2
        '
        'DragPaneDark
        '
        Me.DragPaneDark.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.DragPaneDark.Controls.Add(Me.btnAdmin)
        Me.DragPaneDark.Controls.Add(Me.Button5)
        Me.DragPaneDark.Controls.Add(Me.Button4)
        Me.DragPaneDark.Controls.Add(Me.Button3)
        Me.DragPaneDark.Controls.Add(Me.Button2)
        Me.DragPaneDark.Controls.Add(Me.Button1)
        Me.DragPaneDark.Location = New System.Drawing.Point(222, 2)
        Me.DragPaneDark.Name = "DragPaneDark"
        Me.DragPaneDark.Size = New System.Drawing.Size(1078, 21)
        Me.DragPaneDark.TabIndex = 3
        '
        'btnAdmin
        '
        Me.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnAdmin.ForeColor = System.Drawing.Color.White
        Me.btnAdmin.Location = New System.Drawing.Point(797, 0)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(63, 21)
        Me.btnAdmin.TabIndex = 6
        Me.btnAdmin.Text = "Admin"
        Me.ttpPrototype.SetToolTip(Me.btnAdmin, "Displays program information")
        Me.btnAdmin.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(1004, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(37, 21)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Kill"
        Me.ttpPrototype.SetToolTip(Me.Button5, "Terminate the application immediately (unsafe)")
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(728, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(63, 21)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "About"
        Me.ttpPrototype.SetToolTip(Me.Button4, "Displays program information")
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(866, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 21)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Reset"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(935, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(63, 21)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Debug"
        Me.ttpPrototype.SetToolTip(Me.Button2, "Launches debugging implementation")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblLoading
        '
        Me.lblLoading.BackColor = System.Drawing.Color.White
        Me.lblLoading.Font = New System.Drawing.Font("Segoe UI Light", 40.0!)
        Me.lblLoading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoading.Location = New System.Drawing.Point(445, 319)
        Me.lblLoading.Name = "lblLoading"
        Me.lblLoading.Size = New System.Drawing.Size(424, 84)
        Me.lblLoading.TabIndex = 4
        Me.lblLoading.Text = "Loading Engine..."
        '
        'tmrLoading
        '
        Me.tmrLoading.Enabled = True
        Me.tmrLoading.Interval = 5
        '
        'tmrLoadGone
        '
        Me.tmrLoadGone.Enabled = True
        Me.tmrLoadGone.Interval = 7000
        '
        'pnlLogo
        '
        Me.pnlLogo.BackColor = System.Drawing.Color.White
        Me.pnlLogo.Controls.Add(Me.Label2)
        Me.pnlLogo.Controls.Add(Me.Label1)
        Me.pnlLogo.Controls.Add(Me.PictureBox1)
        Me.pnlLogo.Location = New System.Drawing.Point(456, 442)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(406, 191)
        Me.pnlLogo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label2.Location = New System.Drawing.Point(178, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "PROTOTYPE B6.1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 48.0!)
        Me.Label1.Location = New System.Drawing.Point(163, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 92)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Music"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Maega_Music.My.Resources.Resources.logo_light
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(460, 184)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(1300, 700)
        Me.Controls.Add(Me.pnlLogo)
        Me.Controls.Add(Me.lblLoading)
        Me.Controls.Add(Me.DragPaneDark)
        Me.Controls.Add(Me.DragPane)
        Me.Controls.Add(Me.WebControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.DragPaneDark.ResumeLayout(False)
        Me.pnlLogo.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebControl1 As EO.WebBrowser.WinForm.WebControl
    Friend WithEvents WebView1 As EO.WebBrowser.WebView
    Friend WithEvents Button1 As Button
    Friend WithEvents DragPane As Panel
    Friend WithEvents DragPaneDark As Panel
    Friend WithEvents lblLoading As Label
    Friend WithEvents tmrLoading As Timer
    Friend WithEvents tmrLoadGone As Timer
    Friend WithEvents pnlLogo As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ttpPrototype As ToolTip
    Friend WithEvents Button5 As Button
    Friend WithEvents btnAdmin As Button
End Class
