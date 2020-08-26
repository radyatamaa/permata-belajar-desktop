Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Form2

    Public Function ShowVideo(idKelas As Integer, idFeature As Integer, idJurusan As Integer)
        Dim materiPelajaran As List(Of RingkasanMataPelajaran) = GetMatapelajaranVideo(idKelas, idFeature, idJurusan)
        Dim lastIndex As Integer = 0

        For i As Integer = 0 To materiPelajaran.Count
            Dim rmButton As Control() = Me.Controls.Find("btnvb" + i.ToString(), True)

            Dim rmLabel As Control() = Me.Controls.Find("lblvb" + i.ToString(), True)


            Try

                rmLabel.FirstOrDefault().Text = materiPelajaran(i).Bidang_Studi
                rmLabel.FirstOrDefault().Show()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(materiPelajaran(i).Image)))
                rmButton.FirstOrDefault().BackgroundImage = downloadImage
                rmButton.FirstOrDefault().Tag = materiPelajaran(i).Id_Bidang_Studi
                rmButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i

        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 8
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnvb" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblvb" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            kelasLabel.FirstOrDefault().Hide()
            'End If
        Next

        If materiPelajaran.Count = 0 Then
            For i As Integer = 0 To 8

                Dim kelasButton As Control() = Me.Controls.Find("btnvb" + i.ToString(), True)

                Dim kelasLabel As Control() = Me.Controls.Find("lblvb" + i.ToString(), True)

                kelasButton.FirstOrDefault().Hide()
                kelasLabel.FirstOrDefault().Hide()

            Next i
        End If
    End Function
    Public Function ShowVideoTopik(idJurusan As Integer, idFeature As Integer, idKelas As Integer, idBidangStudi As Integer, idPelanggan As String)
        Dim topik As List(Of VideoTopik) = GetTopik(idJurusan, idFeature, idKelas, idBidangStudi, idPelanggan)
        Dim lastIndex As Integer = 0
        Dim lastIndexDrop As New List(Of Integer)

        For i As Integer = 0 To topik.Count - 1
            If i <= 2 Then
                Dim tpkButton As Control() = Me.Controls.Find("btnvideo" + i.ToString(), True)
                Dim videolabel As Control() = Me.Controls.Find("lblvideo" + i.ToString(), True)
                Dim videoPanelKotak As Control() = Me.Controls.Find("Pnlvb" + i.ToString(), True)

                Try
                    Dim buttonFeature As Guna.UI2.WinForms.Guna2Button = CType(tpkButton.FirstOrDefault(), Guna.UI2.WinForms.Guna2Button)
                    videolabel.FirstOrDefault().Text = topik(i).File(0).Title
                    videolabel.FirstOrDefault().Show()
                    Dim tClient As WebClient = New WebClient
                    Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(topik(i).File(0).Banner)))
                    buttonFeature.Image = downloadImage
                    'tpkButton.FirstOrDefault().Text = topik(i).Topik
                    Dim anonymousEvent = New With
                    {
                        .Id_Content = topik(i).Id_Content,
                        .id_Video = topik(i).File(0).Id_Video,
                        .Id_Bidang_studi = idBidangStudi
                        }
                    tpkButton.FirstOrDefault().Tag = anonymousEvent
                    tpkButton.FirstOrDefault().Show()
                    videoPanelKotak.FirstOrDefault().Show()
                    lastIndex = lastIndex + 1
                Catch ex As Exception

                End Try

            End If

        Next i

        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 2
            Dim kelasButton As Control() = Me.Controls.Find("btnvideo" + i.ToString(), True)
            Dim videolabel As Control() = Me.Controls.Find("lblvideo" + i.ToString(), True)
            Dim videoPanelKotak As Control() = Me.Controls.Find("Pnlvb" + i.ToString(), True)

            videolabel.FirstOrDefault().Hide()
            kelasButton.FirstOrDefault().Hide()
            videoPanelKotak.FirstOrDefault().Hide()
        Next i

        If topik.Count = 0 Then
            For i As Integer = 0 To 2

                Dim kelasButton As Control() = Me.Controls.Find("btnvideo" + i.ToString(), True)
                Dim videolabel As Control() = Me.Controls.Find("lblvideo" + i.ToString(), True)
                Dim videoPanelKotak As Control() = Me.Controls.Find("Pnlvb" + i.ToString(), True)

                videolabel.FirstOrDefault().Hide()

                kelasButton.FirstOrDefault().Hide()
                videoPanelKotak.FirstOrDefault().Hide()

            Next i
        End If
    End Function
    Public Function GetMatapelajaranVideo(idKelas As Integer, idFeature As Integer, idJurusan As Integer)
        Dim result As New List(Of RingkasanMataPelajaran)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/video/mata-pelajaran?id_kelas=" + idKelas.ToString + "&id_feature=" + idFeature.ToString + "&id_jurusan=" + idJurusan.ToString)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of RingkasanMateriResponse)(response)
            For Each item As MataPelajaran In responseConvert.Data.Mata_Pelajaran
                For Each itemRingkasan As RingkasanMataPelajaran In item.Data
                    Dim ringkasan As New RingkasanMataPelajaran
                    With ringkasan
                        .Id_Bidang_Studi = itemRingkasan.Id_Bidang_Studi
                        .Bidang_Studi = itemRingkasan.Bidang_Studi
                        .Id_kelas = itemRingkasan.Id_kelas
                        .Icon = itemRingkasan.Icon
                        .Image = itemRingkasan.Image
                    End With
                    result.Add(ringkasan)
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
    Public Function GetTopik(idJurusan As Integer, idFeature As Integer, idKelas As Integer, idBidangStudi As Integer, idPelanggan As String) As List(Of VideoTopik)
        Dim result As New List(Of VideoTopik)
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/video/topik-belajar"
        Dim strPostData As String = String.Format("id_feature={0}&id_jurusan={1}&id_kelas={2}&id_bidang_studi={3}&id_pelanggan={4}",
        idFeature.ToString, idJurusan.ToString, idKelas.ToString, idBidangStudi.ToString, idPelanggan.ToString)

        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        myrequest.ContentLength = strPostData.Length
        myrequest.ContentType = "application/x-www-form-urlencoded"
        myrequest.CookieContainer = New CookieContainer()

        ' Post to the login form.
        Dim swRequestWriter As StreamWriter = New StreamWriter(myrequest.GetRequestStream())
        swRequestWriter.Write(strPostData)
        swRequestWriter.Close()

        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of VideoTopikResponse)(response)
            For Each item As VideoTopik In responseConvert.Data
                Dim videoTopik As New VideoTopik
                With videoTopik
                    .Id_Content = item.Id_Content
                    .Topik = item.Topik
                    .Sort = item.Sort
                    .Available = item.Available
                    .File = item.File
                    .Quiz = item.Quiz
                    .QuizSubmit = item.QuizSubmit
                    .Final = item.Final
                End With
                result.Add(videoTopik)
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
    Public Function SubmitVideo(idContent As Integer, idVideo As Integer, IdPelanggan As String)
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/video/submit/read"
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        Dim strPostData As String = String.Format("id_content={0}&id_video={1}&id_pelanggan={2}",
        idContent.ToString, idVideo.ToString, IdPelanggan.ToString)

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
            sr.Close()
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.Timeout Then
                'result = "Error: The request has timed out"
            Else
                'result = "Error: " + ex.Message
            End If
        End Try

    End Function

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        MenuUtama.Panel5.Visible = False
        Panel3.Visible = False
        Me.Hide()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ShowVideo(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0)
    End Sub

    Private Sub btnvb0_Click(sender As Object, e As EventArgs) Handles btnvb0.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb0.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb2_Click(sender As Object, e As EventArgs) Handles btnvb2.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb2.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Pnlvb0.Paint

    End Sub

    Private Sub video0_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles lblvideo0.Click

    End Sub

    Private Sub btnvb1_Click(sender As Object, e As EventArgs) Handles btnvb1.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb1.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb3_Click(sender As Object, e As EventArgs) Handles btnvb3.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb3.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb4_Click(sender As Object, e As EventArgs) Handles btnvb4.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb4.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb5_Click(sender As Object, e As EventArgs) Handles btnvb5.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb5.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb6_Click(sender As Object, e As EventArgs) Handles btnvb6.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb6.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb7_Click(sender As Object, e As EventArgs) Handles btnvb7.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb7.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvb8_Click(sender As Object, e As EventArgs) Handles btnvb8.Click
        ShowVideoTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvb8.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnvideo0_Click(sender As Object, e As EventArgs) Handles btnvideo0.Click
        If Me.btnvideo0.Tag IsNot Nothing And Me.btnvideo0.Tag.Id_Video IsNot Nothing Then
            SubmitVideo(Integer.Parse(Me.btnvideo0.Tag.Id_Content), Integer.Parse(Me.btnvideo0.Tag.Id_Video), Me.Label1.Tag)
            Dim topik As List(Of VideoTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvideo0.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As VideoTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btnvideo0.Tag.Id_Content)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As VideoTopikFile = imagePath.File.Where(Function(x) x.Id_Video = Integer.Parse(Me.btnvideo0.Tag.Id_Video)).FirstOrDefault()
                If url.Free = "false" Then
                    MsgBox("Hanya Untuk User Berlanggan")
                Else
                    IsiVideo.videoplay.URL = url.File
                    IsiVideo.Show()
                End If
            Else
                MsgBox("File dalam Video Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam Video Tersebut Kosong!")
        End If
    End Sub

    Private Sub btnvideo1_Click(sender As Object, e As EventArgs) Handles btnvideo1.Click
        If Me.btnvideo1.Tag IsNot Nothing And Me.btnvideo1.Tag.Id_Video IsNot Nothing Then
            SubmitVideo(Integer.Parse(Me.btnvideo1.Tag.Id_Content), Integer.Parse(Me.btnvideo1.Tag.Id_Video), Me.Label1.Tag)
            Dim topik As List(Of VideoTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvideo1.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As VideoTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btnvideo1.Tag.Id_Content)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As VideoTopikFile = imagePath.File.Where(Function(x) x.Id_Video = Integer.Parse(Me.btnvideo1.Tag.Id_Video)).FirstOrDefault()
                If url.Free = "false" Then
                    MsgBox("Hanya Untuk User Berlanggan")
                Else

                    IsiVideo.videoplay.URL = url.File
                    IsiVideo.Show()
                End If
            Else
                MsgBox("File dalam Video Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam Video Tersebut Kosong!")
        End If
    End Sub

    Private Sub btnvideo2_Click(sender As Object, e As EventArgs) Handles btnvideo2.Click
        If Me.btnvideo2.Tag IsNot Nothing And Me.btnvideo2.Tag.Id_Video IsNot Nothing Then
            SubmitVideo(Integer.Parse(Me.btnvideo2.Tag.Id_Content), Integer.Parse(Me.btnvideo2.Tag.Id_Video), Me.Label1.Tag)
            Dim topik As List(Of VideoTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnvideo2.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As VideoTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btnvideo2.Tag.Id_Content)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As VideoTopikFile = imagePath.File.Where(Function(x) x.Id_Video = Integer.Parse(Me.btnvideo2.Tag.Id_Video)).FirstOrDefault()
                If url.Free = "false" Then
                    MsgBox("Hanya Untuk User Berlanggan")
                Else

                    IsiVideo.videoplay.URL = url.File
                    IsiVideo.Show()
                End If
            Else
                MsgBox("File dalam Video Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam Video Tersebut Kosong!")
        End If
    End Sub
End Class