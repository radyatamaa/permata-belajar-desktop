Public Class LoginGoogle
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) 
        Signin.Show()
        Me.Close()
    End Sub

    Private Sub btn_show_Click(sender As Object, e As EventArgs) Handles btn_show.Click
        txt_password.UseSystemPasswordChar = False
    End Sub
End Class