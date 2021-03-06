﻿Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class SBMPTN
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Public Function GetJurusan(idKelas As Integer, idFeature As Integer, tahun As String)
        Dim result As New TahunPTNJurusanDto
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/ptn/jurusan?id_kelas=" + idKelas.ToString + "&id_feature=" + idFeature.ToString + "&tahun=" + tahun.ToString)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjEsImlhdCI6MTU5MTY5MjEwOH0.dy9E2oEca87xXJil8rOMdA2Syn8e5OmTBFco6jh5Gpo")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of TahunPTNResponse)(response)
            Dim ringkasan As New TahunPTNJurusanDto
            With ringkasan
                .Tahun = responseConvert.Data.TahunData
                .SelectedTahun = responseConvert.Data.Tahun
                .Data = New List(Of TahunPTNJurusan)
            End With

            For Each item As Jurusan In responseConvert.Data.Jurusan

                For Each itemRingkasan As TahunPTNJurusan In item.Data
                    Dim jurusan As New TahunPTNJurusan
                    With jurusan
                        .Id_Jurusan = itemRingkasan.Id_Jurusan
                        .Jurusan = itemRingkasan.Jurusan
                        .Id_Kelas = itemRingkasan.Id_Kelas
                        .Icon = itemRingkasan.Icon
                        .Image = itemRingkasan.Image
                    End With
                    ringkasan.Data.Add(jurusan)
                Next
                'Do something with "item" here
            Next
            result = ringkasan
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
    Public Function ShowJurusan(idKelas As Integer, idFeature As Integer, tahun As String)
        Dim materiPelajaran As TahunPTNJurusanDto = GetJurusan(idKelas, idFeature, tahun)


        'jurusan
        Dim lastIndex As Integer = 0

        For i As Integer = 0 To materiPelajaran.Data.Count
            Dim rmButton As Control() = Me.Controls.Find("btnsl" + i.ToString(), True)

            Dim rmLabel As Control() = Me.Controls.Find("lbls" + i.ToString(), True)


            Try

                rmLabel.FirstOrDefault().Text = materiPelajaran.Data(i).Jurusan
                rmLabel.FirstOrDefault().Show()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(materiPelajaran.Data(i).Image)))
                rmButton.FirstOrDefault().BackgroundImage = downloadImage
                Dim tag = New With {
                    .jurusan = materiPelajaran.Data(i).Id_Jurusan,
                    .tahun = materiPelajaran.SelectedTahun
                }
                rmButton.FirstOrDefault().Tag = tag
                rmButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i

        For i As Integer = (lastIndex) To 2
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnsl" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lbls" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            kelasLabel.FirstOrDefault().Hide()
            'End If
        Next

        If materiPelajaran.Data.Count = 0 Then
            For i As Integer = 0 To 2

                Dim kelasButton As Control() = Me.Controls.Find("btnsl" + i.ToString(), True)

                Dim kelasLabel As Control() = Me.Controls.Find("lbls" + i.ToString(), True)

                kelasButton.FirstOrDefault().Hide()
                kelasLabel.FirstOrDefault().Hide()

            Next i
        End If

        'tahun
        Dim lastIndexTahun As Integer = 0

        For i As Integer = 0 To materiPelajaran.Tahun.Count
            Dim rmButton As Control() = Me.Controls.Find("btnth" + i.ToString(), True)


            Try

                rmButton.FirstOrDefault().Tag = materiPelajaran.Tahun(i).Tahun
                rmButton.FirstOrDefault().Text = materiPelajaran.Tahun(i).Tahun
                If materiPelajaran.Tahun(i).Tahun = materiPelajaran.SelectedTahun Then
                    rmButton.FirstOrDefault().BackColor = Color.FromArgb(0, 192, 0)
                    rmButton.FirstOrDefault().ForeColor = Color.White
                Else
                    rmButton.FirstOrDefault().BackColor = Color.White
                    rmButton.FirstOrDefault().ForeColor = Color.Black
                End If
                rmButton.FirstOrDefault().Show()
                lastIndexTahun = lastIndexTahun + 1
            Catch ex As Exception

            End Try

        Next i

        For i As Integer = (lastIndexTahun) To 4
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnth" + i.ToString(), True)


            kelasButton.FirstOrDefault().Hide()
            'End If
        Next

        If materiPelajaran.Tahun.Count = 0 Then
            For i As Integer = 0 To 4

                Dim kelasButton As Control() = Me.Controls.Find("btnth" + i.ToString(), True)


                kelasButton.FirstOrDefault().Hide()

            Next i
        End If
    End Function
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ShowJurusan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), "Tahun 2017")
    End Sub

    Private Sub btnth0_Click(sender As Object, e As EventArgs) Handles btnth0.Click
        ShowJurusan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), btnth0.Tag)
    End Sub

    Private Sub btnth1_Click(sender As Object, e As EventArgs) Handles btnth1.Click
        ShowJurusan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), btnth1.Tag)
    End Sub

    Private Sub btnth2_Click(sender As Object, e As EventArgs) Handles btnth2.Click

        ShowJurusan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), btnth2.Tag)
    End Sub

    Private Sub btnth3_Click(sender As Object, e As EventArgs) Handles btnth3.Click

        ShowJurusan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), btnth3.Tag)
    End Sub

    Private Sub btnth4_Click(sender As Object, e As EventArgs) Handles btnth4.Click

        ShowJurusan(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), btnth4.Tag)
    End Sub

    Private Sub btnsl0_Click(sender As Object, e As EventArgs) Handles btnsl0.Click
        Soal_SBMPTN.Show()
        Soal_SBMPTN.Label26.Text = Me.Label26.Text
        Soal_SBMPTN.Label26.Tag = Me.Label26.Tag
        Soal_SBMPTN.Label2.Text = Me.lbls0.Text
        Soal_SBMPTN.Label2.Tag = Me.Label2.Tag
        Soal_SBMPTN.Label1.Tag = Me.Label1.Tag
        Soal_SBMPTN.btnsmstr0.Tag = Me.btnsl0.Tag
        Me.Hide()
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Panel5.Visible = False
        Me.Hide()
    End Sub

    Private Sub btnsl1_Click(sender As Object, e As EventArgs) Handles btnsl1.Click
        Soal_SBMPTN.Show()
        Soal_SBMPTN.Label26.Text = Me.Label26.Text
        Soal_SBMPTN.Label26.Tag = Me.Label26.Tag
        Soal_SBMPTN.Label2.Text = Me.lbls1.Text
        Soal_SBMPTN.Label2.Tag = Me.Label2.Tag
        Soal_SBMPTN.Label1.Tag = Me.Label1.Tag
        Soal_SBMPTN.btnsmstr0.Tag = Me.btnsl1.Tag
        Me.Hide()
    End Sub

    Private Sub btnsl2_Click(sender As Object, e As EventArgs) Handles btnsl2.Click
        Soal_SBMPTN.Show()
        Soal_SBMPTN.Label26.Text = Me.Label26.Text
        Soal_SBMPTN.Label26.Tag = Me.Label26.Tag
        Soal_SBMPTN.Label2.Text = Me.lbls2.Text
        Soal_SBMPTN.Label2.Tag = Me.Label2.Tag
        Soal_SBMPTN.Label1.Tag = Me.Label1.Tag
        Soal_SBMPTN.btnsmstr0.Tag = Me.btnsl2.Tag
        Me.Hide()
    End Sub

    Private Sub lbls1_Click(sender As Object, e As EventArgs) Handles lbls1.Click

    End Sub
End Class