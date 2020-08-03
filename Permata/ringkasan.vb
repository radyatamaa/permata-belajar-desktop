Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Ringkasan
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        MenuUtama.Panel5.Visible = False
        Panel3.Visible = False
        Me.Hide()
    End Sub

    Public Function GetTopik(idJurusan As Integer, idFeature As Integer, idKelas As Integer, idBidangStudi As Integer, idPelanggan As String) As List(Of RingkasanMateriTopik)
        Dim result As New List(Of RingkasanMateriTopik)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/ringkasan-materi/topik-belajar?id_jurusan=" + idJurusan.ToString + "&id_feature=" + idFeature.ToString + "&id_kelas=" + idKelas.ToString + "&id_bidang_studi=" + idBidangStudi.ToString + "&id_pelanggan=" + idPelanggan)
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

        For i As Integer = 0 To 5
            Dim tpkButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)

            Try

                tpkButton.FirstOrDefault().Text = topik(i).Topik
                tpkButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i

        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 5
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            'End If
        Next

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

    Private Sub btntpk0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk0.SelectedIndexChanged
        gray0.Visible = False
        green0.Visible = True
        yellow0.Visible = False
    End Sub

    Private Sub btntpk1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk1.SelectedIndexChanged
        gray1.Visible = False
        green1.Visible = True
        yellow1.Visible = False
        yellow0.Visible = True
    End Sub

    Private Sub btntpk2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk2.SelectedIndexChanged
        gray2.Visible = False
        green2.Visible = True
        yellow2.Visible = False
        yellow1.Visible = True
    End Sub

    Private Sub btntpk3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk3.SelectedIndexChanged
        gray3.Visible = False
        green3.Visible = True
        yellow3.Visible = False
        yellow2.Visible = True
    End Sub

    Private Sub btntpk4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk4.SelectedIndexChanged
        gray4.Visible = False
        green4.Visible = True
        yellow4.Visible = False
        yellow3.Visible = True
    End Sub

    Private Sub btntpk5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk5.SelectedIndexChanged
        gray5.Visible = False
        green5.Visible = True
        yellow5.Visible = False
        yellow4.Visible = True
    End Sub

    Private Sub btntpk6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk6.SelectedIndexChanged
        gray6.Visible = False
        green6.Visible = True
        yellow6.Visible = False
        yellow5.Visible = True
    End Sub

    Private Sub btntpk7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk7.SelectedIndexChanged
        gray7.Visible = False
        green7.Visible = True
        yellow7.Visible = False
        yellow6.Visible = True
    End Sub

    Private Sub btntpk8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk8.SelectedIndexChanged
        gray8.Visible = False
        green8.Visible = True
        yellow8.Visible = False
        yellow7.Visible = True
    End Sub

    Private Sub btntpk9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk9.SelectedIndexChanged
        gray9.Visible = False
        green9.Visible = True
        yellow9.Visible = False
        yellow8.Visible = True
    End Sub

    Private Sub btntpk10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk10.SelectedIndexChanged
        gray10.Visible = False
        green10.Visible = True
        yellow10.Visible = False
        yellow9.Visible = True
    End Sub

    Private Sub btntpk11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles btntpk11.SelectedIndexChanged
        gray11.Visible = False
        green11.Visible = True
        yellow11.Visible = False
        yellow10.Visible = True
    End Sub
End Class
