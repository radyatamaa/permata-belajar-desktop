Imports System.Net
Imports Newtonsoft.Json

Public Class Signin
    Public Function Login(username As String, password As String) As LoginResponse
        Dim result As New LoginResponse
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/auth/login/pelanggan?username=" + username + "&password=" + password)
        myrequest.Method = "POST"
        'myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of LoginResponse)(response)
            result = responseConvert
            sr.Close()
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                'result = "Error: The request has timed out"
            Else
                'result = "Error: " + ex.Message
            End If
        End Try
        Return result
    End Function
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim usernameText As Control() = Me.Controls.Find("Guna2TextBox1", True)
        Dim passwordText As Control() = Me.Controls.Find("Guna2TextBox2", True)

        Dim usernameGuna As Guna.UI2.WinForms.Guna2TextBox = CType(usernameText.FirstOrDefault(), Guna.UI2.WinForms.Guna2TextBox)
        Dim passwordGuna As Guna.UI2.WinForms.Guna2TextBox = CType(passwordText.FirstOrDefault(), Guna.UI2.WinForms.Guna2TextBox)

        Dim username As String = usernameGuna.Text
        Dim password As String = passwordGuna.Text
        Dim checkUser As LoginResponse = Login(username, password)
        If checkUser.Status = "true" Then
            MenuUtama.Show()
            Me.Hide()
        Else
            MsgBox("Email dan Password Salah!")
        End If
    End Sub
End Class