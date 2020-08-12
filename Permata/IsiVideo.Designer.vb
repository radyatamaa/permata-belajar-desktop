<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IsiVideo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IsiVideo))
        Me.videoplay = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.videoplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'videoplay
        '
        Me.videoplay.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.videoplay.Enabled = True
        Me.videoplay.Location = New System.Drawing.Point(1, 1)
        Me.videoplay.Name = "videoplay"
        Me.videoplay.OcxState = CType(resources.GetObject("videoplay.OcxState"), System.Windows.Forms.AxHost.State)
        Me.videoplay.Size = New System.Drawing.Size(1058, 529)
        Me.videoplay.TabIndex = 0
        '
        'IsiVideo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1060, 532)
        Me.Controls.Add(Me.videoplay)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "IsiVideo"
        Me.Text = "IsiVideo"
        CType(Me.videoplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents videoplay As AxWMPLib.AxWindowsMediaPlayer
End Class
