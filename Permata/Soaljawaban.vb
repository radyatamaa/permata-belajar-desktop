Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Soaljawaban
    Public Property IdExamp As Integer
    Public Property IdExecute As Integer
    Public Property CurrentPage As Integer
    Public Property IdPelanggan As String
    Public Property IdContent As Integer
    Public Property PembahasanJawaban As String
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
            Dim responseConvert = JsonConvert.DeserializeObject(Of SoalLatihanResponse)(response)
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
    Public Function SubmitAnswerJawaban(idExecute As Integer, jawaban As String)
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/soal/latihan/answer"
        Dim request = New With
       {
            .id_execute = idExecute,
            .jawaban = jawaban
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
    Public Function SubmitFinishSelesai(idExamp As Integer) As FinishSoalResponse
        Dim result As New FinishSoalResponse
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/soal/latihan/finish"
        Dim request = New With
       {
            .id_examp = idExamp
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
            Dim responseConvert = JsonConvert.DeserializeObject(Of FinishSoalResponse)(response)
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
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Soal.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim finish As FinishSoalResponse = SubmitFinishSelesai(IdExamp)
        Prestasi.jawaban_benar.Text = finish.Data.Betul
        Prestasi.jawaban_kosong.Text = finish.Data.Blank
        Prestasi.jawaban_salah.Text = finish.Data.Salah
        Prestasi.Show()
    End Sub

    Private Sub Soaljawaban_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CurrentPage = 1 Then
            Button9.Enabled = False
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim latihan As SoalLatihanResponse = GetLatihanSoal(IdContent, IdPelanggan, CurrentPage + 1)
        CurrentPage = latihan.Data.Page
        If CurrentPage = latihan.Data.LastPage Then
            Button10.Enabled = False
        Else
            Button10.Enabled = True
        End If
        If CurrentPage = 1 Then
            Button9.Enabled = False
        Else
            Button9.Enabled = True
        End If
        CurrentPage = latihan.Data.Page
        Dim tClient As WebClient = New WebClient
        Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(latihan.Data.Data(0).Soal)))
        Me.PictureBox1.BackgroundImage = downloadImage
        Me.Label3.Text = latihan.Data.Data(0).Title
        PembahasanJawaban = latihan.Data.Data(0).Pembahasan
        IdExecute = latihan.Data.Data(0).Id_Execute
        IdExamp = latihan.Data.Data(0).Id_Examp
        Me.PictureBox2.BackgroundImage = Nothing
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim latihan As SoalLatihanResponse = GetLatihanSoal(IdContent, IdPelanggan, CurrentPage - 1)
        CurrentPage = latihan.Data.Page
        If CurrentPage = latihan.Data.LastPage Then
            Button10.Enabled = False
        Else
            Button10.Enabled = True
        End If
        If CurrentPage = 1 Then
            Button9.Enabled = False
        Else
            Button9.Enabled = True
        End If
        CurrentPage = latihan.Data.Page
        Dim tClient As WebClient = New WebClient
        Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(latihan.Data.Data(0).Soal)))
        Me.PictureBox1.BackgroundImage = downloadImage
        Me.Label3.Text = latihan.Data.Data(0).Title
        PembahasanJawaban = latihan.Data.Data(0).Pembahasan
        IdExecute = latihan.Data.Data(0).Id_Execute
        IdExamp = latihan.Data.Data(0).Id_Examp
        Me.PictureBox2.BackgroundImage = Nothing
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim tClient As WebClient = New WebClient
        Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(PembahasanJawaban)))
        Me.PictureBox2.BackgroundImage = downloadImage
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SubmitAnswerJawaban(IdExecute, Button4.Text)
        MsgBox("Jawaban Telah Di pilih " + Button4.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SubmitAnswerJawaban(IdExecute, Button5.Text)
        MsgBox("Jawaban Telah Di pilih " + Button5.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SubmitAnswerJawaban(IdExecute, Button6.Text)
        MsgBox("Jawaban Telah Di pilih " + Button6.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SubmitAnswerJawaban(IdExecute, Button7.Text)
        MsgBox("Jawaban Telah Di pilih " + Button7.Text)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SubmitAnswerJawaban(IdExecute, Button8.Text)
        MsgBox("Jawaban Telah Di pilih " + Button8.Text)
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class