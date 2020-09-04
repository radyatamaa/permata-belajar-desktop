<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Prestasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Prestasi))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.jawaban_kosong = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.jawaban_salah = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.jawaban_benar = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(438, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(933, 780)
        Me.Panel2.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Blue
        Me.Button2.Font = New System.Drawing.Font("Ubuntu Light", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(497, 571)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(164, 65)
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "Coba Lagi"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Ubuntu Light", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(299, 571)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(164, 65)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "Latihan Lainya"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.jawaban_kosong)
        Me.Panel5.Location = New System.Drawing.Point(299, 433)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(367, 82)
        Me.Panel5.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Abhaya Libre SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(56, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 28)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Tidak Dijawab"
        '
        'jawaban_kosong
        '
        Me.jawaban_kosong.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.jawaban_kosong.DefaultText = ""
        Me.jawaban_kosong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.jawaban_kosong.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.jawaban_kosong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.jawaban_kosong.DisabledState.Parent = Me.jawaban_kosong
        Me.jawaban_kosong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.jawaban_kosong.Enabled = False
        Me.jawaban_kosong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.jawaban_kosong.FocusedState.Parent = Me.jawaban_kosong
        Me.jawaban_kosong.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.jawaban_kosong.HoverState.Parent = Me.jawaban_kosong
        Me.jawaban_kosong.Location = New System.Drawing.Point(252, 4)
        Me.jawaban_kosong.Margin = New System.Windows.Forms.Padding(5)
        Me.jawaban_kosong.Name = "jawaban_kosong"
        Me.jawaban_kosong.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.jawaban_kosong.PlaceholderText = ""
        Me.jawaban_kosong.SelectedText = ""
        Me.jawaban_kosong.ShadowDecoration.Parent = Me.jawaban_kosong
        Me.jawaban_kosong.Size = New System.Drawing.Size(111, 74)
        Me.jawaban_kosong.TabIndex = 2
        Me.jawaban_kosong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Red
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.jawaban_salah)
        Me.Panel4.Location = New System.Drawing.Point(299, 313)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(367, 82)
        Me.Panel4.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Abhaya Libre SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(56, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 28)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Jawaban Salah" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'jawaban_salah
        '
        Me.jawaban_salah.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.jawaban_salah.DefaultText = ""
        Me.jawaban_salah.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.jawaban_salah.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.jawaban_salah.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.jawaban_salah.DisabledState.Parent = Me.jawaban_salah
        Me.jawaban_salah.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.jawaban_salah.Enabled = False
        Me.jawaban_salah.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.jawaban_salah.FocusedState.Parent = Me.jawaban_salah
        Me.jawaban_salah.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.jawaban_salah.HoverState.Parent = Me.jawaban_salah
        Me.jawaban_salah.Location = New System.Drawing.Point(252, 4)
        Me.jawaban_salah.Margin = New System.Windows.Forms.Padding(5)
        Me.jawaban_salah.Name = "jawaban_salah"
        Me.jawaban_salah.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.jawaban_salah.PlaceholderText = ""
        Me.jawaban_salah.SelectedText = ""
        Me.jawaban_salah.ShadowDecoration.Parent = Me.jawaban_salah
        Me.jawaban_salah.Size = New System.Drawing.Size(111, 74)
        Me.jawaban_salah.TabIndex = 1
        Me.jawaban_salah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.jawaban_benar)
        Me.Panel3.Location = New System.Drawing.Point(299, 187)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(367, 82)
        Me.Panel3.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Abhaya Libre SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(56, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 28)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Jawaban Benar"
        '
        'jawaban_benar
        '
        Me.jawaban_benar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.jawaban_benar.DefaultText = ""
        Me.jawaban_benar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.jawaban_benar.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.jawaban_benar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.jawaban_benar.DisabledState.Parent = Me.jawaban_benar
        Me.jawaban_benar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.jawaban_benar.Enabled = False
        Me.jawaban_benar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.jawaban_benar.FocusedState.Parent = Me.jawaban_benar
        Me.jawaban_benar.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.jawaban_benar.HoverState.Parent = Me.jawaban_benar
        Me.jawaban_benar.Location = New System.Drawing.Point(252, 4)
        Me.jawaban_benar.Margin = New System.Windows.Forms.Padding(5)
        Me.jawaban_benar.Name = "jawaban_benar"
        Me.jawaban_benar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.jawaban_benar.PlaceholderText = ""
        Me.jawaban_benar.SelectedText = ""
        Me.jawaban_benar.ShadowDecoration.Parent = Me.jawaban_benar
        Me.jawaban_benar.Size = New System.Drawing.Size(111, 74)
        Me.jawaban_benar.TabIndex = 0
        Me.jawaban_benar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Ubuntu Light", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(376, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(216, 38)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Prestasi Kamu"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(438, 780)
        Me.Panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Abhaya Libre SemiBold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(152, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 28)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Kelas 12"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Abhaya Libre SemiBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(103, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 35)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Soal dan Materi"
        '
        'Prestasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1371, 780)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Prestasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prestasi"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents jawaban_kosong As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents jawaban_salah As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents jawaban_benar As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
End Class
