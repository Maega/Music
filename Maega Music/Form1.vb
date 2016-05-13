Public Class Form1
    'Declarations
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

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

        e.Graphics.DrawRectangle(Pens.White, rect)
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
        If My.Settings.savedwidth <= 500 Then My.Settings.savedwidth = 1300
        My.Settings.Save()
        Application.Exit()
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.BackColor = Color.Red
    End Sub
    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.BackColor = Color.FromArgb(37, 37, 40)
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnAbout.LinkClicked
        MsgBox("Maega Music" + vbNewLine + "Maega Music Client for Microsoft Windows" + vbNewLine + "Version: 1.0 - Milestone 1" + vbNewLine + vbNewLine + "This milestone beta is not intended for production use. It's designed for development testing and for bleeding edge users interested in trying out pre-release software. This beta uses unlicensed libraries from Essential Objects, these will be purchased or removed before a production release." + vbNewLine + vbNewLine + "Known Issues:" + vbNewLine + "Resizing the form too small will cause the resize handles to disappear.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnDebug.LinkClicked
        frmDBGSettings.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnAdmin.LinkClicked
        If My.Settings.adminenabled = True Then
            WebView1.LoadUrl("http://music.maeganetwork.com/#/admin/settings")
        Else
            MsgBox("The admin link is currently disabled. You can enable it from 'Debug'.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = My.Settings.savedheight
        Me.Width = My.Settings.savedwidth
        If My.Settings.userbeta = True Then
            btnAdmin.Hide()
            btnDebug.Hide()
            btnReset.Hide()
        End If
        CenterForm()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnReset.LinkClicked
        WebView1.LoadUrl("http://music.maeganetwork.com")
    End Sub

    Private Sub btnMini_Click(sender As Object, e As EventArgs) Handles btnMini.LinkClicked
        If minimumWidth = 430 Then
            minimumWidth = 900
            Me.Width = My.Settings.savedwidth
            Me.Height = My.Settings.savedheight
            btnMini.Text = "Minify"
            btnAdmin.Show()
            btnDebug.Show()
            btnReset.Show()
            CenterForm()
            Invalidate()
            WebView1.LoadUrl("http://music.maeganetwork.com")
        Else
            minimumWidth = 430
            Me.Width = 430
            btnMini.Text = "Maxify"
            btnAdmin.Hide()
            btnDebug.Hide()
            btnReset.Hide()
            CenterForm()
            Invalidate()
            WebView1.LoadUrl("http://music.maeganetwork.com")
        End If
    End Sub
End Class
