Public Class Ringkasan
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        lblbab1.Visible = True
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = False

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        lblbab1.Visible = False
        lblbab2.Visible = True
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = True
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = True
        lblbab5.Visible = False
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = True
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = True
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        Me.Hide()
    End Sub
End Class
