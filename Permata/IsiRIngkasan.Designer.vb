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
        Me.Guna2Button7 = New Guna.UI2.WinForms.Guna2Button()
        Me.PictureBox0 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Button7
        '
        Me.Guna2Button7.AutoRoundedCorners = True
        Me.Guna2Button7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button7.BorderRadius = 28
        Me.Guna2Button7.CheckedState.Parent = Me.Guna2Button7
        Me.Guna2Button7.CustomImages.Parent = Me.Guna2Button7
        Me.Guna2Button7.FillColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Guna2Button7, "Guna2Button7")
        Me.Guna2Button7.ForeColor = System.Drawing.Color.White
        Me.Guna2Button7.HoverState.Parent = Me.Guna2Button7
        Me.Guna2Button7.Image = CType(resources.GetObject("Guna2Button7.Image"), System.Drawing.Image)
        Me.Guna2Button7.ImageSize = New System.Drawing.Size(30, 30)
        Me.Guna2Button7.Name = "Guna2Button7"
        Me.Guna2Button7.PressedColor = System.Drawing.Color.White
        Me.Guna2Button7.ShadowDecoration.Parent = Me.Guna2Button7
        Me.Guna2Button7.UseTransparentBackground = True
        '
        'PictureBox0
        '
        resources.ApplyResources(Me.PictureBox0, "PictureBox0")
        Me.PictureBox0.Name = "PictureBox0"
        Me.PictureBox0.TabStop = False
        '
        'IsiRIngkasan
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Guna2Button7)
        Me.Controls.Add(Me.PictureBox0)
        Me.Name = "IsiRIngkasan"
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Guna2Button7 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents PictureBox0 As PictureBox
End Class
