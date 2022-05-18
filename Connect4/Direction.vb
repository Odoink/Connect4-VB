Public Class Direction
    Public matchCount As Integer
    Public isValid As Boolean
    Public dir As Array

    Public Sub New(counter As Integer, valid As Boolean, direction As Array)
        matchCount = counter
        isValid = valid
        dir = direction
    End Sub
End Class
