﻿Public Class Game
    Private MainForm As Form1
    Private LstLabels As List(Of List(Of Label))
    Private colorCurrentPlayer As Color
    Public Sub New(form As Form1)
        MainForm = form
    End Sub

    'Stop the game if someone has won'
    Private Sub Break()
        For i As Integer = 0 To MainForm.BtnPanel.Controls.Count - 1 Step 1
            Dim btn As Button = MainForm.BtnPanel.Controls(i)
            btn.Enabled = False
            MainForm.restartBtn.Visible = True
        Next
    End Sub

    'Change field to default colors'
    Private Sub SetDefaultColors()
        For i As Integer = 0 To LstLabels.Count - 1 Step 1
            For j As Integer = 0 To LstLabels(i).Count - 1 Step 1
                LstLabels(i)(j).BackColor = Color.Gray
            Next
        Next
    End Sub

    'Start new game'
    Public Sub Start()
        'Set all buttons to enabled'
        For i As Integer = 0 To MainForm.BtnPanel.Controls.Count - 1 Step 1
            Dim btn As Button = MainForm.BtnPanel.Controls(i)
            btn.Enabled = True
            MainForm.restartBtn.Visible = False
        Next
        MainForm.restartBtn.Visible = False
        colorCurrentPlayer = Color.Red
        If LstLabels IsNot Nothing Then
            SetDefaultColors()
        Else
            CreateLabels()
            CreateButtons()
        End If
    End Sub

    'Check for a draw
    Private Function IsDraw() As Boolean
        For x = 0 To LstLabels.Count - 1 Step 1
            For y = 0 To LstLabels(x).Count - 1 Step 1
                If Equals(LstLabels(x)(y), Color.Gray) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Function CheckFor4InARow(selectedLabel As Label, col As Integer) As Boolean
        'check Vertical'
        For i As Integer = 0 To 2 Step 1
            If Equals(LstLabels(col)(i).BackColor, colorCurrentPlayer) And Equals(LstLabels(col)(i + 1).BackColor, colorCurrentPlayer) And Equals(LstLabels(col)(i + 2).BackColor, colorCurrentPlayer) And Equals(LstLabels(col)(i + 3).BackColor, colorCurrentPlayer) Then
                Return True
            End If
        Next

        'check horizontal'
        For i As Integer = 0 To 3 Step 1
            If Equals(LstLabels(i)(selectedLabel.Tag.Ycoor).BackColor, colorCurrentPlayer) And Equals(LstLabels(i + 1)(selectedLabel.Tag.Ycoor).BackColor, colorCurrentPlayer) And Equals(LstLabels(i + 2)(selectedLabel.Tag.Ycoor).BackColor, colorCurrentPlayer) And Equals(LstLabels(i + 3)(selectedLabel.Tag.Ycoor).BackColor, colorCurrentPlayer) Then
                Return True
            End If
        Next

        'check diagonal'
        'top left bottom right'
        For x As Integer = 0 To 3 Step 1
            For y As Integer = 0 To 2 Step 1
                If Equals(LstLabels(x)(y).BackColor, colorCurrentPlayer) And Equals(LstLabels(x + 1)(y + 1).BackColor, colorCurrentPlayer) And Equals(LstLabels(x + 2)(y + 2).BackColor, colorCurrentPlayer) And Equals(LstLabels(x + 3)(y + 3).BackColor, colorCurrentPlayer) Then
                    Return True
                End If
            Next
        Next
        'top right bottom left'
        For x As Integer = LstLabels.Count - 1 To 3 Step -1
            For y As Integer = 0 To 2 Step 1
                If Equals(LstLabels(x)(y).BackColor, colorCurrentPlayer) And Equals(LstLabels(x - 1)(y + 1).BackColor, colorCurrentPlayer) And Equals(LstLabels(x - 2)(y + 2).BackColor, colorCurrentPlayer) And Equals(LstLabels(x - 3)(y + 3).BackColor, colorCurrentPlayer) Then
                    Return True
                End If
            Next
        Next
        Return False

    End Function

    'Change current player'
    Private Sub SwitchPlayer()
        If colorCurrentPlayer = Color.Red Then
            colorCurrentPlayer = Color.Yellow
        Else
            colorCurrentPlayer = Color.Red
        End If

        MainForm.turnLbl.Text = $"{colorCurrentPlayer} is aan de beurt"
    End Sub

    'Returns if exists first unused box in column else returns nothing'
    Private Function GetFirstUnusedBox(sender As Object) As Label
        Dim col As Integer = sender.Tag
        For i As Integer = LstLabels(col).Count - 1 To 0 Step -1
            If Equals(LstLabels(col)(i).BackColor, Color.Gray) Then
                Dim selectLbl = LstLabels(col)(i)
                If LstLabels(col).Contains(selectLbl) Then
                    Return selectLbl
                End If
            End If
        Next
        Return Nothing
    End Function

    'set box to current color'
    Private Sub BtnOnClick(sender As Object, e As EventArgs)
        Dim LblselectedBox = GetFirstUnusedBox(sender)
        If LblselectedBox IsNot Nothing Then
            LblselectedBox.BackColor = colorCurrentPlayer
            If CheckFor4InARow(LblselectedBox, sender.Tag) Or IsDraw() Then
                MessageBox.Show($"{colorCurrentPlayer} heeft gewonnen!")
                Break()
            End If
            SwitchPlayer()
            End If
    End Sub

    'Create buttons to place fiche'
    Public Sub CreateButtons()
        For i = 0 To 6
            Dim btn = New Button()
            btn.Text = $"Kolom {i + 1}"
            btn.Tag = i
            btn.Size = New Size(60, 50)
            btn.Location = New Point(i * 60, 0)

            AddHandler btn.Click, AddressOf BtnOnClick

            MainForm.BtnPanel.Controls.Add(btn)
        Next
    End Sub

    'create field'
    Private Sub CreateLabels()
        LstLabels = New List(Of List(Of Label))
        For x = 0 To 6
            Dim LstRow As List(Of Label) = New List(Of Label)
            For y = 0 To 5
                Dim lblBox = New Label()
                lblBox.Tag = New Coordinates(x, y)
                lblBox.BackColor = Color.Gray
                lblBox.AutoSize = False
                lblBox.Size = New Size(60, 60)
                lblBox.Location = New Point(x * 60, y * 60)
                lblBox.Margin = New Padding(100, 100, 0, 0)
                lblBox.BorderStyle = BorderStyle.Fixed3D
                MainForm.pnlBoxes.Controls.Add(lblBox)
                LstRow.Add(lblBox)
            Next
            LstLabels.Add(LstRow)
        Next
    End Sub
End Class
