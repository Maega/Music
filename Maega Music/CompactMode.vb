Public Class CompactMode
    Public displayed As Boolean = False
    Dim dheight As Integer = Screen.PrimaryScreen.WorkingArea.Height - 785
    Dim dwidth As Integer = Screen.PrimaryScreen.WorkingArea.Width - 535
    Private Sub CompactMode_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If CompatMode.gocompact = False Then
            musicControl.LoadUrl("file:///" + CompatMode.appload)
            Me.Hide()
        End If
    End Sub

    Private Sub tmrAnimation_Tick(sender As Object, e As EventArgs) Handles tmrAnimation.Tick
        If displayed = False Then
            If Me.Top <= dheight Then
                tmrAnimation.Stop()
                CompatMode.musicControl.Reload() 'Reloads Compat Mode to stop any currently playing music so that it doesn't conflict with the compact player.
                'MsgBox(Screen.PrimaryScreen.WorkingArea.Height.ToString)
                Me.Location = New Point(dwidth, dheight)
                displayed = True
            Else
                Me.Top -= 30
            End If
        Else
            If Me.Top >= Screen.PrimaryScreen.WorkingArea.Height Then
                tmrAnimation.Stop()
                Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 535, Screen.PrimaryScreen.WorkingArea.Height - -100)
                displayed = False
                'MsgBox("DONE!")
                Me.Hide()
            Else
                Me.Top += 30
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tmrAnimation.Start()
    End Sub
End Class