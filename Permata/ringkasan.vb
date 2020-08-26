Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Ringkasan
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        MenuUtama.Panel5.Visible = False
        Panel3.Visible = False
        'Panel6.Visible = True
        Me.Hide()
    End Sub

    Public Function GetTopik(idJurusan As Integer, idFeature As Integer, idKelas As Integer, idBidangStudi As Integer, idPelanggan As String) As List(Of RingkasanMateriTopik)
        Dim result As New List(Of RingkasanMateriTopik)
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/ringkasan-materi/topik-belajar?id_jurusan=" + idJurusan.ToString + "&id_feature=" + idFeature.ToString + "&id_kelas=" + idKelas.ToString + "&id_bidang_studi=" + idBidangStudi.ToString + "&id_pelanggan=" + idPelanggan
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of RingkasanMateriTopikResponse)(response)
            For Each item As RingkasanMateriTopik In responseConvert.Data
                Dim ringkasanTopik As New RingkasanMateriTopik
                With ringkasanTopik
                    .Id_Content = item.Id_Content
                    .Topik = item.Topik
                    .Sort = item.Sort
                    .Available = item.Available
                    .File = item.File
                    .Quiz = item.Quiz
                    .QuizSubmit = item.QuizSubmit
                    .Final = item.Final
                End With
                result.Add(ringkasanTopik)
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
    Public Function GetMataPelajaran(idKelas As Integer, idFeature As Integer, idJurusan As Integer) As List(Of RingkasanMataPelajaran)
        Dim result As New List(Of RingkasanMataPelajaran)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/ringkasan-materi/mata-pelajaran?id_kelas=" + idKelas.ToString + "&id_feature=" + idFeature.ToString + "&id_jurusan=" + idJurusan.ToString)
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
    Public Function SubmitRingkasanMateri(idContent As Integer, IdRingkasanMateri As Integer, IdPelanggan As String)
        Dim baseUrl As String = "https://api.permatamall.com/api/v2/belajar/home/ringkasan-materi/submit/read?id_content=" + idContent.ToString() + "&id_ringkasan_materi=" + IdRingkasanMateri.ToString() + "&id_pelanggan=" + IdPelanggan
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create(baseUrl)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
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

    Public Function ShowRingkasan(idKelas As Integer, idFeature As Integer, idJurusan As Integer)
        Dim materiPelajaran As List(Of RingkasanMataPelajaran) = GetMataPelajaran(idKelas, idFeature, idJurusan)
        Dim lastIndex As Integer = 0

        For i As Integer = 0 To materiPelajaran.Count
            Dim rmButton As Control() = Me.Controls.Find("btnrm" + i.ToString(), True)

            Dim rmLabel As Control() = Me.Controls.Find("lblrm" + i.ToString(), True)


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
        For i As Integer = (lastIndex) To 11
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnrm" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblrm" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            kelasLabel.FirstOrDefault().Hide()
            'End If
        Next

        If materiPelajaran.Count = 0 Then
            For i As Integer = 0 To 11

                Dim kelasButton As Control() = Me.Controls.Find("btnrm" + i.ToString(), True)

                Dim kelasLabel As Control() = Me.Controls.Find("lblrm" + i.ToString(), True)

                kelasButton.FirstOrDefault().Hide()
                kelasLabel.FirstOrDefault().Hide()

            Next i
        End If
    End Function
    Public Function ShowRingkasanTopik(idJurusan As Integer, idFeature As Integer, idKelas As Integer, idBidangStudi As Integer, idPelanggan As String)
        Dim topik As List(Of RingkasanMateriTopik) = GetTopik(idJurusan, idFeature, idKelas, idBidangStudi, idPelanggan)
        Dim lastIndex As Integer = 0
        Dim lastIndexDrop As New List(Of Integer)
        For i As Integer = 0 To 5
            Dim tpkButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)

            Try

                tpkButton.FirstOrDefault().Text = topik(i).Topik
                tpkButton.FirstOrDefault().Tag = topik(i).Id_Content
                tpkButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
                For idrop As Integer = 0 To 4
                    Dim dtopButton As Control() = Me.Controls.Find("btndrop" + idrop.ToString() + i.ToString(), True)
                    dtopButton.FirstOrDefault().Text = topik(i).File(idrop).Title
                    Dim anonymousEvent = New With
                    {
                        .Id_Ringkasan_Materi = topik(i).File(idrop).Id_Ringkasan_Materi,
                        .Id_Bidang_studi = idBidangStudi
                        }

                    dtopButton.FirstOrDefault().Tag = anonymousEvent
                    dtopButton.FirstOrDefault().Show()
                    Dim last = idrop + 1
                    lastIndexDrop.Add(last)

                Next idrop
            Catch ex As Exception

            End Try

        Next i

        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 5
            Dim kelasButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()

        Next i

        For i As Integer = 0 To 5
            For Each item As Integer In lastIndexDrop
                For idRop As Integer = item To 4
                    Dim dtopButton As Control() = Me.Controls.Find("btndrop" + idRop.ToString() + i.ToString(), True)
                    dtopButton.FirstOrDefault().Hide()
                Next idRop
            Next item
        Next i

        If topik.Count = 0 Then
            For i As Integer = 0 To 5

                Dim kelasButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)


                kelasButton.FirstOrDefault().Hide()


            Next i
        End If
    End Function
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ShowRingkasan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnrm4.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm4.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles btnrm9.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm9.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm2_Click(sender As Object, e As EventArgs) Handles btnrm2.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm2.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub btnrm0_Click(sender As Object, e As EventArgs) Handles btnrm0.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm0.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm1_Click(sender As Object, e As EventArgs) Handles btnrm1.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm1.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm3_Click(sender As Object, e As EventArgs) Handles btnrm3.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm3.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm5_Click(sender As Object, e As EventArgs) Handles btnrm5.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm5.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm6_Click(sender As Object, e As EventArgs) Handles btnrm6.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm6.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm7_Click(sender As Object, e As EventArgs) Handles btnrm7.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm7.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm8_Click(sender As Object, e As EventArgs) Handles btnrm8.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm7.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm10_Click(sender As Object, e As EventArgs) Handles btnrm10.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm10.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnrm11_Click(sender As Object, e As EventArgs) Handles btnrm11.Click
        ShowRingkasanTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btnrm11.Tag, Me.Label1.Tag)
        Panel3.Visible = True
    End Sub


    Private Sub btntpk0_Click(sender As Object, e As EventArgs) Handles btntpk0.Click
        green0.Visible = True

        If drop0.Visible = False Then
            drop0.Visible = True
        ElseIf drop0.Visible = True Then
            drop0.Visible = False
        End If
    End Sub

    Private Sub btntpk1_Click(sender As Object, e As EventArgs) Handles btntpk1.Click
        green1.Visible = True
        If drop1.Visible = False Then
            drop1.Visible = True
        ElseIf drop1.Visible = True Then
            drop1.Visible = False
        End If
    End Sub

    Private Sub btntpk2_Click(sender As Object, e As EventArgs) Handles btntpk2.Click
        green2.Visible = True
        If drop2.Visible = False Then
            drop2.Visible = True
        ElseIf drop2.Visible = True Then
            drop2.Visible = False
        End If
    End Sub

    Private Sub btntpk3_Click(sender As Object, e As EventArgs) Handles btntpk3.Click
        green3.Visible = True
        If drop3.Visible = False Then
            drop3.Visible = True
        ElseIf drop3.Visible = True Then
            drop3.Visible = False
        End If
    End Sub

    Private Sub btntpk4_Click(sender As Object, e As EventArgs) Handles btntpk4.Click
        green4.Visible = True
        If drop4.Visible = False Then
            drop4.Visible = True
        ElseIf drop4.Visible = True Then
            drop4.Visible = False
        End If
    End Sub

    Private Sub btntpk5_Click(sender As Object, e As EventArgs) Handles btntpk5.Click
        green5.Visible = True
        If drop5.Visible = False Then
            drop5.Visible = True
        ElseIf drop5.Visible = True Then
            drop5.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btndrop00.Click

        If Me.btndrop00.Tag IsNot Nothing And Me.btndrop00.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk0.Tag), Integer.Parse(Me.btndrop00.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop00.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk0.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop00.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If

    End Sub

    Private Sub btndrop10_Click(sender As Object, e As EventArgs) Handles btndrop10.Click
        If Me.btndrop10.Tag IsNot Nothing And Me.btndrop10.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk0.Tag), Integer.Parse(Me.btndrop10.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop10.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk0.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop10.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop20_Click(sender As Object, e As EventArgs) Handles btndrop20.Click
        If Me.btndrop20.Tag IsNot Nothing And Me.btndrop20.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk0.Tag), Integer.Parse(Me.btndrop20.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop20.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk0.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop20.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop30_Click(sender As Object, e As EventArgs) Handles btndrop30.Click
        If Me.btndrop30.Tag IsNot Nothing And Me.btndrop30.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk0.Tag), Integer.Parse(Me.btndrop30.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop30.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk0.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop30.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop40_Click(sender As Object, e As EventArgs) Handles btndrop30.Click
        If Me.btndrop30.Tag IsNot Nothing And Me.btndrop30.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk0.Tag), Integer.Parse(Me.btndrop30.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop30.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk0.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop30.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop01_Click(sender As Object, e As EventArgs) Handles btndrop01.Click
        If Me.btndrop01.Tag IsNot Nothing And Me.btndrop01.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk1.Tag), Integer.Parse(Me.btndrop01.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop01.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk1.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop01.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop11_Click(sender As Object, e As EventArgs) Handles btndrop11.Click
        If Me.btndrop11.Tag IsNot Nothing And Me.btndrop11.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk1.Tag), Integer.Parse(Me.btndrop11.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop11.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk1.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop11.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop21_Click(sender As Object, e As EventArgs) Handles btndrop21.Click
        If Me.btndrop21.Tag IsNot Nothing And Me.btndrop21.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk1.Tag), Integer.Parse(Me.btndrop21.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop21.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk1.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop21.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop31_Click(sender As Object, e As EventArgs) Handles btndrop31.Click
        If Me.btndrop31.Tag IsNot Nothing And Me.btndrop31.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk1.Tag), Integer.Parse(Me.btndrop31.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop31.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk1.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop31.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop41_Click(sender As Object, e As EventArgs) Handles btndrop41.Click
        If Me.btndrop41.Tag IsNot Nothing And Me.btndrop41.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk1.Tag), Integer.Parse(Me.btndrop41.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop41.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk1.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop41.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop02_Click(sender As Object, e As EventArgs) Handles btndrop02.Click
        If Me.btndrop02.Tag IsNot Nothing And Me.btndrop02.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk2.Tag), Integer.Parse(Me.btndrop02.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop02.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk2.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop02.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop12_Click(sender As Object, e As EventArgs) Handles btndrop12.Click
        If Me.btndrop12.Tag IsNot Nothing And Me.btndrop12.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk2.Tag), Integer.Parse(Me.btndrop12.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop12.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk2.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop12.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop22_Click(sender As Object, e As EventArgs) Handles btndrop22.Click
        If Me.btndrop22.Tag IsNot Nothing And Me.btndrop22.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk2.Tag), Integer.Parse(Me.btndrop22.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop22.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk2.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop22.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop32_Click(sender As Object, e As EventArgs) Handles btndrop32.Click
        If Me.btndrop32.Tag IsNot Nothing And Me.btndrop32.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk2.Tag), Integer.Parse(Me.btndrop32.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop32.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk2.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop32.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop42_Click(sender As Object, e As EventArgs) Handles btndrop42.Click
        If Me.btndrop42.Tag IsNot Nothing And Me.btndrop42.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk2.Tag), Integer.Parse(Me.btndrop42.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop42.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk2.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop42.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop03_Click(sender As Object, e As EventArgs) Handles btndrop03.Click
        If Me.btndrop03.Tag IsNot Nothing And Me.btndrop03.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk3.Tag), Integer.Parse(Me.btndrop03.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop03.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk3.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop03.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop13_Click(sender As Object, e As EventArgs) Handles btndrop13.Click
        If Me.btndrop13.Tag IsNot Nothing And Me.btndrop13.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk3.Tag), Integer.Parse(Me.btndrop13.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop13.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk3.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop13.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop23_Click(sender As Object, e As EventArgs) Handles btndrop23.Click
        If Me.btndrop23.Tag IsNot Nothing And Me.btndrop23.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk3.Tag), Integer.Parse(Me.btndrop23.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop23.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk3.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop23.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop33_Click(sender As Object, e As EventArgs) Handles btndrop33.Click
        If Me.btndrop33.Tag IsNot Nothing And Me.btndrop33.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk3.Tag), Integer.Parse(Me.btndrop33.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop33.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk3.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop33.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub
    Private Sub btndrop43_Click(sender As Object, e As EventArgs) Handles btndrop43.Click
        If Me.btndrop43.Tag IsNot Nothing And Me.btndrop43.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk3.Tag), Integer.Parse(Me.btndrop43.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop43.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk3.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop43.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop04_Click(sender As Object, e As EventArgs) Handles btndrop04.Click
        If Me.btndrop04.Tag IsNot Nothing And Me.btndrop04.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk4.Tag), Integer.Parse(Me.btndrop04.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop04.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk4.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop04.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop14_Click(sender As Object, e As EventArgs) Handles btndrop14.Click
        If Me.btndrop14.Tag IsNot Nothing And Me.btndrop14.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk4.Tag), Integer.Parse(Me.btndrop14.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop14.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk4.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop14.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop24_Click(sender As Object, e As EventArgs) Handles btndrop24.Click
        If Me.btndrop24.Tag IsNot Nothing And Me.btndrop24.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk4.Tag), Integer.Parse(Me.btndrop24.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop24.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk4.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop24.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop34_Click(sender As Object, e As EventArgs) Handles btndrop34.Click
        If Me.btndrop34.Tag IsNot Nothing And Me.btndrop34.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk4.Tag), Integer.Parse(Me.btndrop34.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop34.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk4.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop34.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop44_Click(sender As Object, e As EventArgs) Handles btndrop44.Click
        If Me.btndrop44.Tag IsNot Nothing And Me.btndrop44.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk4.Tag), Integer.Parse(Me.btndrop44.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop44.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk4.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop44.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop05_Click(sender As Object, e As EventArgs) Handles btndrop05.Click
        If Me.btndrop05.Tag IsNot Nothing And Me.btndrop05.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk5.Tag), Integer.Parse(Me.btndrop05.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop05.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk5.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop05.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop15_Click(sender As Object, e As EventArgs) Handles btndrop15.Click
        If Me.btndrop15.Tag IsNot Nothing And Me.btndrop15.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk5.Tag), Integer.Parse(Me.btndrop15.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop15.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk5.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop15.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop25_Click(sender As Object, e As EventArgs) Handles btndrop25.Click
        If Me.btndrop25.Tag IsNot Nothing And Me.btndrop25.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk5.Tag), Integer.Parse(Me.btndrop25.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop25.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk5.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop25.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop35_Click(sender As Object, e As EventArgs) Handles btndrop35.Click
        If Me.btndrop35.Tag IsNot Nothing And Me.btndrop35.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk5.Tag), Integer.Parse(Me.btndrop35.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop35.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk5.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop35.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub btndrop45_Click(sender As Object, e As EventArgs) Handles btndrop45.Click
        If Me.btndrop45.Tag IsNot Nothing And Me.btndrop45.Tag.Id_Ringkasan_Materi IsNot Nothing Then
            SubmitRingkasanMateri(Integer.Parse(Me.btntpk5.Tag), Integer.Parse(Me.btndrop45.Tag.Id_Ringkasan_Materi), Me.Label1.Tag)
            Dim topik As List(Of RingkasanMateriTopik) = GetTopik(0, Integer.Parse(Me.Label2.Tag), Integer.Parse(Me.Label26.Tag), Me.btndrop45.Tag.Id_Bidang_studi, Me.Label1.Tag)
            Dim imagePath As RingkasanMateriTopik = topik.Where(Function(x) x.Id_Content = Integer.Parse(Me.btntpk5.Tag)).FirstOrDefault()
            If imagePath IsNot Nothing Then
                Dim url As RingkasanMateriTopikFile = imagePath.File.Where(Function(x) x.Id_Ringkasan_Materi = Integer.Parse(Me.btndrop45.Tag.Id_Ringkasan_Materi)).FirstOrDefault()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(url.File)))
                Dim width = downloadImage.Width
                Dim height = downloadImage.Height

                IsiRIngkasan.Width = width
                IsiRIngkasan.Height = height
                IsiRIngkasan.PictureBox0.Width = width
                IsiRIngkasan.PictureBox0.Height = height
                IsiRIngkasan.PictureBox0.Image = downloadImage
                IsiRIngkasan.Show()
            Else
                MsgBox("File dalam ringkasan Tersebut Kosong!")
            End If

        Else
            MsgBox("File dalam ringkasan Tersebut Kosong!")
        End If
    End Sub

    Private Sub Panel3_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub lblrm0_Click(sender As Object, e As EventArgs) Handles lblrm0.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Ringkasan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Panel6.Visible = True
    End Sub

    Private Sub btndrop40_Click_1(sender As Object, e As EventArgs) Handles btndrop40.Click

    End Sub
End Class