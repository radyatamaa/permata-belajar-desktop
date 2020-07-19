<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Location = New System.Drawing.Point(126, 220)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(110, 153)
        Me.Button9.TabIndex = 0
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.White
        Me.Button17.BackgroundImage = CType(resources.GetObject("Button17.BackgroundImage"), System.Drawing.Image)
        Me.Button17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button17.Location = New System.Drawing.Point(126, 379)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(110, 145)
        Me.Button17.TabIndex = 6
        Me.Button17.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.Location = New System.Drawing.Point(126, 58)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(110, 156)
        Me.Button12.TabIndex = 3
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Button12)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button17)
        Me.Panel1.Location = New System.Drawing.Point(12, 187)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(348, 582)
        Me.Panel1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(521, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Label1"
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1254, 667)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form7"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
