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
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        Me.Hide()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        ShowVideo(Integer.Parse(Me.Label26.Tag), Integer.Parse(Me.Label2.Tag), 0)
    End Sub
End Class