<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IsiRIngkasan
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
        Me.PictureBox0 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox0
        '
        Me.PictureBox0.Location = New System.Drawing.Point(2, 1)
        Me.PictureBox0.Name = "PictureBox0"
        Me.PictureBox0.Size = New System.Drawing.Size(197, 58)
        Me.PictureBox0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox0.TabIndex = 0
        Me.PictureBox0.TabStop = False
        '
        'IsiRIngkasan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(828, 465)
        Me.Controls.Add(Me.PictureBox0)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "IsiRIngkasan"
        Me.Text = "IsiRIngkasan"
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox0 As PictureBox
End Class
