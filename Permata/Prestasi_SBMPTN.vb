Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Prestasi_SBMPTN
    Public Property IdPelanggan As String
    Public Property IdContent As Integer
    Public Function GetLatihanSoal(idContent As Integer, idPelanggan As String, page As Integer) As SoalLatihanResponse
        Dim result As New SoalLatihanResponse
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/ptn/latihan-soal/result"
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        Dim strPostData As String = String.Format("id_content={0}&page={1}&id_pelanggan={2}",
        idContent.ToString, page.ToString, idPelanggan.ToString)

        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjEsImlhdCI6MTU5MTY5MjEwOH0.dy9E2oEca87xXJil8rOMdA2Syn8e5OmTBFco6jh5Gpo")
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
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/ptn/latihan-soal/request"
        Dim request = New With
       {
            .id_content = idContent,
            .id_pelanggan = IdPelanggan
        }
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjEsImlhdCI6MTU5MTY5MjEwOH0.dy9E2oEca87xXJil8rOMdA2Syn8e5OmTBFco6jh5Gpo")
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
        Soal_SBMPTN.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Soal_SBMPTN.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim latihan As SoalLatihanResponse = GetLatihanSoal(IdContent, IdPelanggan, 1)
        If latihan IsNot Nothing And latihan.Responses = "200" Then
            For Each item As SoalLatihan In latihan.Data.Data
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(item.Soal)))
                Soaljawaban_SBMPTN.PictureBox1.BackgroundImage = downloadImage
                Soaljawaban_SBMPTN.Label2.Text = Me.Label2.Text
                Soaljawaban_SBMPTN.IdPelanggan = IdPelanggan
                Soaljawaban_SBMPTN.IdContent = IdContent
                Soaljawaban_SBMPTN.CurrentPage = 1
                Soaljawaban_SBMPTN.Label3.Text = latihan.Data.Data(0).Title
                Soaljawaban_SBMPTN.PembahasanJawaban = latihan.Data.Data(0).Pembahasan
                Soaljawaban_SBMPTN.IdExecute = latihan.Data.Data(0).Id_Execute
                Soaljawaban_SBMPTN.IdExamp = latihan.Data.Data(0).Id_Examp
                Soaljawaban_SBMPTN.PictureBox2.BackgroundImage = Nothing
                Soaljawaban_SBMPTN.Show()
                SubmitSoal(IdContent, IdPelanggan)
                Me.Hide()
            Next
        Else
            MsgBox("Soal Tidak Tersedia!")
        End If
    End Sub
    Private Sub Prestasi_SBMPTN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class