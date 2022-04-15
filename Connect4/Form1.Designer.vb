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
        Me.BtnPanel = New System.Windows.Forms.Panel()
        Me.pnlBoxes = New System.Windows.Forms.Panel()
        Me.restartBtn = New System.Windows.Forms.Button()
        Me.turnLbl = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnPanel
        '
        Me.BtnPanel.Location = New System.Drawing.Point(12, 12)
        Me.BtnPanel.Name = "BtnPanel"
        Me.BtnPanel.Size = New System.Drawing.Size(420, 50)
        Me.BtnPanel.TabIndex = 0
        '
        'pnlBoxes
        '
        Me.pnlBoxes.Location = New System.Drawing.Point(12, 68)
        Me.pnlBoxes.Name = "pnlBoxes"
        Me.pnlBoxes.Size = New System.Drawing.Size(420, 370)
        Me.pnlBoxes.TabIndex = 1
        '
        'restartBtn
        '
        Me.restartBtn.Location = New System.Drawing.Point(547, 68)
        Me.restartBtn.Name = "restartBtn"
        Me.restartBtn.Size = New System.Drawing.Size(140, 23)
        Me.restartBtn.TabIndex = 2
        Me.restartBtn.Text = "Opnieuw spelen"
        Me.restartBtn.UseVisualStyleBackColor = True
        Me.restartBtn.Visible = False
        '
        'turnLbl
        '
        Me.turnLbl.AutoSize = True
        Me.turnLbl.Location = New System.Drawing.Point(533, 155)
        Me.turnLbl.Name = "turnLbl"
        Me.turnLbl.Size = New System.Drawing.Size(0, 15)
        Me.turnLbl.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.turnLbl)
        Me.Controls.Add(Me.restartBtn)
        Me.Controls.Add(Me.pnlBoxes)
        Me.Controls.Add(Me.BtnPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnPanel As Panel
    Friend WithEvents pnlBoxes As Panel
    Friend WithEvents restartBtn As Button
    Friend WithEvents turnLbl As Label
End Class
