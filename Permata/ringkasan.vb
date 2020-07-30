Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Ringkasan
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btntpk0.Click
        lblbab1.Visible = True
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = False

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btntpk1.Click
        lblbab1.Visible = False
        lblbab2.Visible = True
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles btntpk2.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = True
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles btntpk3.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = True
        lblbab5.Visible = False
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles btntpk4.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = True
        lblbab6.Visible = False
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles btntpk5.Click
        lblbab1.Visible = False
        lblbab2.Visible = False
        lblbab3.Visible = False
        lblbab4.Visible = False
        lblbab5.Visible = False
        lblbab6.Visible = True
    End Sub

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

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

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
End Class
