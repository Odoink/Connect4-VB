Public Class Form1
    Private game As Game
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        game = New Game(Me)
        game.Start()
    End Sub

    Private Sub RestartClick(sender As Object, e As EventArgs) Handles restartBtn.Click
        game.Start()
    End Sub
End Class
