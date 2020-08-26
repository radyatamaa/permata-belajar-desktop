Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Prestasi
    Public Property IdPelanggan As String
    Public Property IdContent As Integer
    Public Function GetLatihanSoal(idContent As Integer, idPelanggan As String, page As Integer) As SoalLatihanResponse
        Dim result As New SoalLatihanResponse
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/soal/latihan/result"
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        Dim strPostData As String = String.Format("id_content={0}&page={1}&id_pelanggan={2}",
        idContent.ToString, page.ToString, idPelanggan.ToString)

        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        myrequest.ContentLength = strPostData.Length
        myrequest.ContentType = "application/x-www-form-urlencoded"
        myrequest.CookieContainer = New CookieContainer()

        ' Post to the login form.
        Dim swRequestWriter As StreamWriter = New StreamWriter(myrequest.GetRequestStream())
        swRequestWriter.Write(strPostData)
        swRequestWriter.Close()

        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Try
                Dim responseConvert = JsonConvert.DeserializeObject(Of SoalLatihanResponse)(response)

                result = responseConvert
                sr.Close()
            Catch ex As Exception
                'MsgBox("Soal Tersebut kosong")
            End Try
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                'result = "Error: The request has timed out"
            Else
                'result = "Error: " + ex.Message
            End If
        End Try
        Return result
    End Function
    Public Function SubmitSoal(idContent As Integer, IdPelanggan As String)
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/soal/submit/request"
        Dim request = New With
       {
            .id_content = idContent,
            .id_pelanggan = IdPelanggan
        }
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        myrequest.ContentType = "application/json"
        Dim reqString = JsonConvert.SerializeObject(request, Formatting.Indented)
        myrequest.ContentLength = reqString.Length
        myrequest.CookieContainer = New CookieContainer()

        ' Post to the login form.
        Dim swRequestWriter As StreamWriter = New StreamWriter(myrequest.GetRequestStream())
        swRequestWriter.Write(reqString)
        swRequestWriter.Close()

        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            sr.Close()
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                'result = "Error: The request has timed out"
            Else
                'result = "Error: " + ex.Message
            End If
        End Try

    End Function
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs)
        Soal.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Soal.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim latihan As SoalLatihanResponse = GetLatihanSoal(IdContent, IdPelanggan, 1)
        If latihan IsNot Nothing And latihan.Responses = "200" Then
            For Each item As SoalLatihan In latihan.Data.Data
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(item.Soal)))
                Soaljawaban.PictureBox1.BackgroundImage = downloadImage
                Soaljawaban.Label2.Text = Me.Label2.Text
                Soaljawaban.IdPelanggan = IdPelanggan
                Soaljawaban.IdContent = IdContent
                Soaljawaban.CurrentPage = 1
                Soaljawaban.Label3.Text = latihan.Data.Data(0).Title
                Soaljawaban.PembahasanJawaban = latihan.Data.Data(0).Pembahasan
                Soaljawaban.IdExecute = latihan.Data.Data(0).Id_Execute
                Soaljawaban.IdExamp = latihan.Data.Data(0).Id_Examp
                Soaljawaban.PictureBox2.BackgroundImage = Nothing
                Soaljawaban.Show()
                SubmitSoal(IdContent, IdPelanggan)
                Me.Hide()
            Next
        Else
            MsgBox("Soal Tidak Tersedia!")
        End If
    End Sub
End Class