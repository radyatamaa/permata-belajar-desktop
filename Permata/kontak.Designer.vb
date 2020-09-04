<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class kontak
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(kontak))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Guna2Button7 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Guna2Button7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(682, 308)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Abhaya Libre", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(129, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(363, 68)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "Email : @permatabelajar.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Phone/Whatsapp: 0811811306" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Guna2Button7
        '
        Me.Guna2Button7.AutoRoundedCorners = True
        Me.Guna2Button7.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button7.BorderRadius = 28
        Me.Guna2Button7.CheckedState.Parent = Me.Guna2Button7
        Me.Guna2Button7.CustomImages.Parent = Me.Guna2Button7
        Me.Guna2Button7.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button7.ForeColor = System.Drawing.Color.White
        Me.Guna2Button7.HoverState.Parent = Me.Guna2Button7
        Me.Guna2Button7.Image = CType(resources.GetObject("Guna2Button7.Image"), System.Drawing.Image)
        Me.Guna2Button7.ImageSize = New System.Drawing.Size(30, 30)
        Me.Guna2Button7.Location = New System.Drawing.Point(0, 2)
        Me.Guna2Button7.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Guna2Button7.Name = "Guna2Button7"
        Me.Guna2Button7.PressedColor = System.Drawing.Color.White
        Me.Guna2Button7.ShadowDecoration.Parent = Me.Guna2Button7
        Me.Guna2Button7.Size = New System.Drawing.Size(58, 70)
        Me.Guna2Button7.TabIndex = 56
        Me.Guna2Button7.UseTransparentBackground = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Abhaya Libre Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Hubungi Kami Melalui" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'kontak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 308)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "kontak"
        Me.Text = "kontak"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button7 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label4 As Label
End Class
