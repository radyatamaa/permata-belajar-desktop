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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IsiRIngkasan))
        Me.PictureBox0 = New System.Windows.Forms.PictureBox()
        Me.Guna2Button7 = New Guna.UI2.WinForms.Guna2Button()
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox0
        '
        Me.PictureBox0.Location = New System.Drawing.Point(3, 1)
        Me.PictureBox0.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox0.Name = "PictureBox0"
        Me.PictureBox0.Size = New System.Drawing.Size(197, 58)
        Me.PictureBox0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox0.TabIndex = 0
        Me.PictureBox0.TabStop = False
        '
        'Guna2Button7
        '
        Me.Guna2Button7.AutoRoundedCorners = True
        Me.Guna2Button7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button7.BorderRadius = 34
        Me.Guna2Button7.CheckedState.Parent = Me.Guna2Button7
        Me.Guna2Button7.CustomImages.Parent = Me.Guna2Button7
        Me.Guna2Button7.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button7.ForeColor = System.Drawing.Color.White
        Me.Guna2Button7.HoverState.Parent = Me.Guna2Button7
        Me.Guna2Button7.Image = CType(resources.GetObject("Guna2Button7.Image"), System.Drawing.Image)
        Me.Guna2Button7.ImageSize = New System.Drawing.Size(30, 30)
        Me.Guna2Button7.Location = New System.Drawing.Point(3, 1)
        Me.Guna2Button7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Guna2Button7.Name = "Guna2Button7"
        Me.Guna2Button7.PressedColor = System.Drawing.Color.White
        Me.Guna2Button7.ShadowDecoration.Parent = Me.Guna2Button7
        Me.Guna2Button7.Size = New System.Drawing.Size(71, 71)
        Me.Guna2Button7.TabIndex = 55
        Me.Guna2Button7.UseTransparentBackground = True
        '
        'IsiRIngkasan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1505, 825)
        Me.Controls.Add(Me.Guna2Button7)
        Me.Controls.Add(Me.PictureBox0)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "IsiRIngkasan"
        Me.Text = "IsiRIngkasan"
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox0 As PictureBox
    Friend WithEvents Guna2Button7 As Guna.UI2.WinForms.Guna2Button
End Class
