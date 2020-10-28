Imports System.Net
Imports Newtonsoft.Json

Public Class SBMPTN
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Public Function GetJurusan(idKelas As Integer, idFeature As Integer)
        Dim result As New List(Of RingkasanMataPelajaran)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/ptn/jurusan?id_kelas=" + idKelas.ToString + "&id_feature=" + idFeature.ToString)
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
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class