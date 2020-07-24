Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class MenuUtama
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnkelas0.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnkelas1.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnkelas2.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnkelas3.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnkelas4.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnkelas5.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles btnkelas6.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles btnkelas7.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnkelas8.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles btnkelas9.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles btnkelas10.Click
        Panel5.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Lainnya.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Ringkasan.Show()
        Me.Hide()
    End Sub
    Public Function GetKelas() As List(Of Kelas)
        Dim result As New List(Of Kelas)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/kelas")
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of KelasResponse)(response)
            For Each item As ResultKelas In responseConvert.Data.Result
                For Each itemKelas As DataResultKelas In item.Data
                    Dim kelas As New Kelas
                    With kelas
                        .Id_Kelas = itemKelas.Id_Kelas
                        .Kelas = itemKelas.Kelas
                        .Icon = itemKelas.Icon
                        .Image = itemKelas.Image
                    End With
                    result.Add(kelas)
                Next
                'Do something with "item" here
            Next
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Soal.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        Dim DataKelas As List(Of Kelas) = GetKelas()
        Dim lastIndex As Integer = 0
        For i As Integer = 0 To DataKelas.Count
            Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)


            Try

                kelasLabel.FirstOrDefault().Text = DataKelas(i).Kelas
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(DataKelas(i).Image)))
                kelasButton.FirstOrDefault().BackgroundImage = downloadImage
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i
        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To DataKelas.Count + 1
            Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            kelasLabel.FirstOrDefault().Hide()
        Next
    End Sub
End Class