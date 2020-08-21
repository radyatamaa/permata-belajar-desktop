Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class Soal
    Public Function GetMatapelajaranSoal(idKelas As Integer, idFeature As Integer, idJurusan As Integer)
        Dim result As New List(Of RingkasanMataPelajaran)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/soal/mata-pelajaran?id_kelas=" + idKelas.ToString + "&id_feature=" + idFeature.ToString + "&id_jurusan=" + idJurusan.ToString)
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
    Public Function GetSemester(idKelas As Integer, idFeature As Integer, idJurusan As Integer, idbidangStudi As Integer)
        Dim result As New List(Of DataSemester)

        Dim request = New With
       {
            .id_kelas = idKelas,
            .id_feature = idFeature,
            .id_jurusan = idJurusan,
            .id_bidang_studi = idbidangStudi
        }

        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/soal/mata-pelajaran/semester")
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Headers("content-type") = "application/json"
        myrequest.ContentType = "application/json"
        Dim reqString = JsonConvert.SerializeObject(request, Formatting.Indented)
        myrequest.ContentLength = reqString.Length
        myrequest.CookieContainer = New CookieContainer()

        ' Post to the login form.
        Dim swRequestWriter As StreamWriter = New StreamWriter(myrequest.GetRequestStream())
        swRequestWriter.Write(reqString)
        swRequestWriter.Close()

        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of SemesterResponse)(response)
            For Each item As DataSemester In responseConvert.Data
                Dim ringkasan As New DataSemester
                With ringkasan
                    .Id_Content = item.Id_Content
                    .Id_Semester = item.Id_Semester
                    .Semester = item.Semester
                    .Sort = item.Sort
                    .Page = item.Page
                End With
                result.Add(ringkasan)
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
    Public Function ShowSoal(idKelas As Integer, idFeature As Integer, idJurusan As Integer)
        Dim materiPelajaran As List(Of RingkasanMataPelajaran) = GetMatapelajaranSoal(idKelas, idFeature, idJurusan)
        Dim lastIndex As Integer = 0

        For i As Integer = 0 To materiPelajaran.Count
            Dim rmButton As Control() = Me.Controls.Find("btnsl" + i.ToString(), True)

            Dim rmLabel As Control() = Me.Controls.Find("lblsl" + i.ToString(), True)


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
        For i As Integer = (lastIndex) To 10
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnsl" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblsl" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            kelasLabel.FirstOrDefault().Hide()
            'End If
        Next

        If materiPelajaran.Count = 0 Then
            For i As Integer = 0 To 10

                Dim kelasButton As Control() = Me.Controls.Find("btnsl" + i.ToString(), True)

                Dim kelasLabel As Control() = Me.Controls.Find("lblsl" + i.ToString(), True)

                kelasButton.FirstOrDefault().Hide()
                kelasLabel.FirstOrDefault().Hide()

            Next i
        End If
    End Function
    Public Function ShowSemester(idKelas As Integer, idFeature As Integer, idJurusan As Integer, idbidangStudi As Integer)
        Dim topik As List(Of DataSemester) = GetSemester(idKelas, idFeature, idJurusan, idbidangStudi)
        Dim lastIndex As Integer = 0
        Dim lastIndexDrop As New List(Of Integer)
        For i As Integer = 0 To 5
            Dim tpkButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)

            Try

                tpkButton.FirstOrDefault().Text = topik(i).Semester
                tpkButton.FirstOrDefault().Tag = topik(i).Id_Content
                tpkButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
                'For idrop As Integer = 0 To 4
                '    Dim dtopButton As Control() = Me.Controls.Find("btndrop" + idrop.ToString() + i.ToString(), True)
                '    dtopButton.FirstOrDefault().Text = topik(i).File(idrop).Title
                '    Dim anonymousEvent = New With
                '    {
                '        .Id_Ringkasan_Materi = topik(i).File(idrop).Id_Ringkasan_Materi,
                '        .Id_Bidang_studi = idbidangStudi
                '        }

                '    dtopButton.FirstOrDefault().Tag = anonymousEvent
                '    dtopButton.FirstOrDefault().Show()
                '    Dim last = idrop + 1
                '    lastIndexDrop.Add(last)

                'Next idrop
            Catch ex As Exception

            End Try

        Next i

        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 5
            Dim kelasButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()

        Next i

        'For i As Integer = 0 To 5
        '    For Each item As Integer In lastIndexDrop
        '        For idRop As Integer = item To 4
        '            Dim dtopButton As Control() = Me.Controls.Find("btndrop" + idRop.ToString() + i.ToString(), True)
        '            dtopButton.FirstOrDefault().Hide()
        '        Next idRop
        '    Next item
        'Next i

        If topik.Count = 0 Then
            For i As Integer = 0 To 5

                Dim kelasButton As Control() = Me.Controls.Find("btntpk" + i.ToString(), True)


                kelasButton.FirstOrDefault().Hide()


            Next i
        End If
    End Function
    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click

    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        MenuUtama.Panel5.Visible = False
        Panel3.Visible = False
        Me.Hide()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ShowSoal(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0)
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles btntpk2.Click

    End Sub

    Private Sub btnsl8_Click(sender As Object, e As EventArgs) Handles btnsl8.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl8.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl0_Click(sender As Object, e As EventArgs) Handles btnsl0.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl0.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl1_Click(sender As Object, e As EventArgs) Handles btnsl1.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl1.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl2_Click(sender As Object, e As EventArgs) Handles btnsl2.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl2.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl3_Click(sender As Object, e As EventArgs) Handles btnsl3.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl3.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl4_Click(sender As Object, e As EventArgs) Handles btnsl4.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl4.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl5_Click(sender As Object, e As EventArgs) Handles btnsl5.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl5.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl6_Click(sender As Object, e As EventArgs) Handles btnsl6.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl6.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl7_Click(sender As Object, e As EventArgs) Handles btnsl7.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl7.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl9_Click(sender As Object, e As EventArgs) Handles btnsl9.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl9.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btnsl10_Click(sender As Object, e As EventArgs) Handles btnsl10.Click
        '0 = id jurusan , Integer.Parse(Me.Label2.Tag = idFeature , Integer.Parse(Me.Label26.Tag) = id kelas
        'Me.btnrm3.Tag = id bidang studi,Me.Label1.Tag = id Pelanggan
        ShowSemester(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0, Me.btnsl10.Tag)
        Panel3.Visible = True
    End Sub

    Private Sub btntpk0_Click(sender As Object, e As EventArgs) Handles btntpk0.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class