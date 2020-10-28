Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class MenuUtama
    Dim NamaKelas As String
    Private Sub btnkelas0_Click(sender As Object, e As EventArgs) Handles btnkelas0.Click
        ShowFeature(Integer.Parse(Me.btnkelas0.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas0.Text, 0)
        Panel5.Visible = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnkelas1.Click
        ShowFeature(Integer.Parse(Me.btnkelas1.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas1.Text, 1)
        Panel5.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnkelas2.Click
        ShowFeature(Integer.Parse(Me.btnkelas2.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas2.Text, 2)
        Panel5.Visible = True
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles btnkelas3.Click
        ShowFeature(Integer.Parse(Me.btnkelas3.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas3.Text, 3)
        Panel5.Visible = True
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnkelas4.Click
        ShowFeature(Integer.Parse(Me.btnkelas4.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas4.Text, 4)
        Panel5.Visible = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnkelas5.Click
        ShowFeature(Integer.Parse(Me.btnkelas5.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas5.Text, 5)
        Panel5.Visible = True

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles btnkelas6.Click
        ShowFeature(Integer.Parse(Me.btnkelas6.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas6.Text, 6)
        Panel5.Visible = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles btnkelas7.Click
        ShowFeature(Integer.Parse(Me.btnkelas7.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas7.Text, 7)
        Panel5.Visible = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnkelas8.Click
        ShowFeature(Integer.Parse(Me.btnkelas8.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas8.Text, 8)
        Panel5.Visible = True
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles btnkelas9.Click
        ShowFeature(Integer.Parse(Me.btnkelas9.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas9.Text, 9)
        Panel5.Visible = True
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles btnkelas10.Click
        ShowFeature(Integer.Parse(Me.btnkelas10.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas10.Text, 10)
        Panel5.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Lainnya.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnfeature0.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
                Ringkasan.Label26.Text = Me.Label26.Text
                Ringkasan.Label26.Tag = Me.Label26.Tag
                Ringkasan.Label2.Text = Me.Label13.Tag
                Ringkasan.Label2.Tag = Me.lblfeature0.Tag
                Ringkasan.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "sbmptnPages"
                SBMPTN.Show()
                SBMPTN.Label26.Text = Me.Label26.Text
                SBMPTN.Label26.Tag = Me.Label26.Tag
                SBMPTN.Label2.Text = Me.Label13.Tag
                SBMPTN.Label2.Tag = Me.lblfeature0.Tag
                SBMPTN.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "videoPages"
                Form2.Show()
                Form2.Label26.Text = Me.Label26.Text
                Form2.Label26.Tag = Me.Label26.Tag
                Form2.Label2.Text = Me.Label13.Tag
                Form2.Label2.Tag = Me.lblfeature0.Tag
                Form2.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "latihansoalPages"
                Soal.Show()
                Soal.Label26.Text = Me.Label26.Text
                Soal.Label26.Tag = Me.Label26.Tag
                Soal.Label2.Text = Me.Label13.Tag
                Soal.Label2.Tag = Me.lblfeature0.Tag
                Soal.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
        End Select
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles btnfeature1.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
                Ringkasan.Label26.Text = Me.Label26.Text
                Ringkasan.Label26.Tag = Me.Label26.Tag
                Ringkasan.Label2.Text = Me.Label13.Tag
                Ringkasan.Label2.Tag = Me.lblfeature1.Tag
                Ringkasan.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "sbmptnPages"
                SBMPTN.Show()
                SBMPTN.Label26.Text = Me.Label26.Text
                SBMPTN.Label26.Tag = Me.Label26.Tag
                SBMPTN.Label2.Text = Me.Label13.Tag
                SBMPTN.Label2.Tag = Me.lblfeature1.Tag
                SBMPTN.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "videoPages"
                Form2.Show()
                Form2.Label26.Text = Me.Label26.Text
                Form2.Label26.Tag = Me.Label26.Tag
                Form2.Label2.Text = Me.Label13.Tag
                Form2.Label2.Tag = Me.lblfeature1.Tag
                Form2.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "latihansoalPages"
                Soal.Show()
                Soal.Label26.Text = Me.Label26.Text
                Soal.Label26.Tag = Me.Label26.Tag
                Soal.Label2.Text = Me.Label13.Tag
                Soal.Label2.Tag = Me.lblfeature1.Tag
                Soal.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
        End Select
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles btnfeature2.Click
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
                Ringkasan.Label26.Text = Me.Label26.Text
                Ringkasan.Label26.Tag = Me.Label26.Tag
                Ringkasan.Label2.Text = Me.Label13.Tag
                Ringkasan.Label2.Tag = Me.lblfeature2.Tag
                Ringkasan.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "sbmptnPages"
                SBMPTN.Show()
                SBMPTN.Label26.Text = Me.Label26.Text
                SBMPTN.Label26.Tag = Me.Label26.Tag
                SBMPTN.Label2.Text = Me.Label13.Tag
                SBMPTN.Label2.Tag = Me.lblfeature2.Tag
                SBMPTN.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "videoPages"
                Form2.Show()
                Form2.Label26.Text = Me.Label26.Text
                Form2.Label26.Tag = Me.Label26.Tag
                Form2.Label2.Text = Me.Label13.Tag
                Form2.Label2.Tag = Me.lblfeature2.Tag
                Form2.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "latihansoalPages"
                Soal.Show()
                Soal.Label26.Text = Me.Label26.Text
                Soal.Label26.Tag = Me.Label26.Tag
                Soal.Label2.Text = Me.Label13.Tag
                Soal.Label2.Tag = Me.lblfeature2.Tag
                Soal.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
        End Select
        Me.Hide()
    End Sub
    Public Function GetKelas() As List(Of Kelas)
        Dim result As New List(Of Kelas)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/kelas")
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of KelasResponse)(response)
            For Each item As ResultKelas In responseConvert.Data.Result
                For Each itemKelas As DataResultKelas In item.Data
                    Dim kelas As New Kelas
                    With kelas
                        .Id_Kelas = itemKelas.Id_Kelas
                        .Kelas = itemKelas.Kelas
                        .Icon = itemKelas.Icon
                        .Image = itemKelas.Image
                    End With
                    result.Add(kelas)
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

    Public Function GetFeatureByKelasId(kelasId As Integer, pelangganId As String) As List(Of Feature)
        Dim result As New List(Of Feature)
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/belajar/home/feature?id_kelas=" + kelasId.ToString() + "&id_pelanggan=" + pelangganId)
        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
        Try
            Dim resp As System.Net.HttpWebResponse = myrequest.GetResponse()
            Dim sr As New System.IO.StreamReader(resp.GetResponseStream())
            Dim response = sr.ReadToEnd()
            Dim responseConvert = JsonConvert.DeserializeObject(Of FeatureResponse)(response)
            For Each item As FeatureWithPage In responseConvert.Data.Feature
                For Each itemFeature As Feature In item.Data
                    Dim feature As New Feature
                    With feature
                        .Id_Feature = itemFeature.Id_Feature
                        .Feature = itemFeature.Feature
                        .Pages = itemFeature.Pages
                        .Icon = itemFeature.Icon
                        .Background = itemFeature.Background
                        .Image = itemFeature.Image
                        .Active = itemFeature.Active
                        .Paket = responseConvert.Data.Paket
                        .DataBerlangganan = responseConvert.Data.DataLangganan
                    End With
                    result.Add(feature)
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
    Public Function GetNotification(pelangganId As String) As NotificationResponse
        Dim result As New NotificationResponse
        Dim myrequest As HttpWebRequest = HttpWebRequest.Create("https://api.permatamall.com/api/v2/notification/list")
        Dim strPostData As String = String.Format("id_pelanggan={0}",
        pelangganId)

        myrequest.Method = "POST"
        myrequest.Headers.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOjMsImlhdCI6MTU5NTI5ODMwN30.i4GWwTPyp853fcwO4f71qJTmQzu06qcSrh2_vw71tYE")
        'myrequest.Timeout = reqtimeout
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
            Dim responseConvert = JsonConvert.DeserializeObject(Of NotificationResponse)(response)
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
    Public Function ShowKelas()
        Dim DataKelas As List(Of Kelas) = GetKelas()
        Dim lastIndex As Integer = 0

        For i As Integer = 0 To DataKelas.Count
            Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)


            Try

                kelasLabel.FirstOrDefault().Text = DataKelas(i).Kelas
                kelasLabel.FirstOrDefault().Show()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(DataKelas(i).Image)))
                kelasButton.FirstOrDefault().BackgroundImage = downloadImage
                kelasButton.FirstOrDefault().Tag = DataKelas(i).Id_Kelas
                kelasButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i

        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 14
            'If lastIndex <> DataKelas.Count Then
            Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

            Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)

            kelasButton.FirstOrDefault().Hide()
            kelasLabel.FirstOrDefault().Hide()
            'End If
        Next

        If DataKelas.Count = 0 Then
            For i As Integer = 0 To 14

                Dim kelasButton As Control() = Me.Controls.Find("btnkelas" + i.ToString(), True)

                Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + i.ToString(), True)

                kelasButton.FirstOrDefault().Hide()
                kelasLabel.FirstOrDefault().Hide()

            Next i
        End If

    End Function

    Public Function ShowFeature(kelasId As Integer, pelangganId As String, kelasName As String, buttonIndex As Integer)
        Dim Datafeature As List(Of Feature) = GetFeatureByKelasId(kelasId, pelangganId)
        Dim kelasLabel As Control() = Me.Controls.Find("lblkelas" + buttonIndex.ToString(), True)
        Me.Label5.Text = kelasLabel.FirstOrDefault().Text
        Dim lastIndex As Integer = 0
        Me.Label26.Tag = kelasId
        Me.Label13.Tag = kelasName
        If Datafeature.Count <> 0 Then
            Me.Label26.Text = Datafeature(0).Paket
            Me.btn_expired.Text = Datafeature(0).DataBerlangganan.Title
        End If

        For i As Integer = 0 To Datafeature.Count

            Dim featureButton As Control() = Me.Controls.Find("btnfeature" + i.ToString(), True)

            Dim featureLabel As Control() = Me.Controls.Find("lblfeature" + i.ToString(), True)


            Try
                Dim buttonFeature As Guna.UI2.WinForms.Guna2Button = CType(featureButton.FirstOrDefault(), Guna.UI2.WinForms.Guna2Button)
                featureLabel.FirstOrDefault().Text = Datafeature(i).Feature
                featureLabel.FirstOrDefault().Tag = Datafeature(i).Id_Feature
                featureLabel.FirstOrDefault().Show()
                Dim tClient As WebClient = New WebClient
                Dim downloadImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(Datafeature(i).Image)))
                buttonFeature.Image = downloadImage
                featureButton.FirstOrDefault().Tag = Datafeature(i).Pages
                featureButton.FirstOrDefault().Show()
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i



        Dim test As Integer = (lastIndex + 2)
        For i As Integer = (lastIndex) To 3
            If lastIndex <> Datafeature.Count Then
                Dim featureButton As Control() = Me.Controls.Find("btnfeature" + i.ToString(), True)

                Dim featureLabel As Control() = Me.Controls.Find("lblfeature" + i.ToString(), True)


                featureButton.FirstOrDefault().Hide()
                featureLabel.FirstOrDefault().Hide()
            End If
        Next

        If Datafeature.Count = 0 Then
            For i As Integer = 0 To 3

                Dim featureButton As Control() = Me.Controls.Find("btnfeature" + i.ToString(), True)

                Dim featureLabel As Control() = Me.Controls.Find("lblfeature" + i.ToString(), True)

                featureButton.FirstOrDefault().Hide()
                featureLabel.FirstOrDefault().Hide()

            Next i
        End If
    End Function

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        ShowKelas()
    End Sub

    Private Sub MenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        'Dim BT As Button = CType(sender, Button)
        'Select Case BT.Tag
        '    Case Me.btnkelas0.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas0.Tag))
        '    Case Me.btnkelas1.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas1.Tag))
        '    Case Me.btnkelas2.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas2.Tag))
        '    Case Me.btnkelas3.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas3.Tag))
        '    Case Me.btnkelas4.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas4.Tag))
        '    Case Me.btnkelas5.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas5.Tag))
        '    Case Me.btnkelas6.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas6.Tag))
        '    Case Me.btnkelas7.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas7.Tag))
        '    Case Me.btnkelas8.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas8.Tag))
        '    Case Me.btnkelas9.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas9.Tag))
        '    Case Me.btnkelas10.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas10.Tag))
        '    Case Me.btnkelas11.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas11.Tag))
        '    Case Me.btnkelas12.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas12.Tag))
        '    Case Me.btnkelas13.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas13.Tag))
        '    Case Me.btnkelas14.Tag
        '        ShowFeature(Integer.Parse(Me.btnkelas14.Tag))
        'End Select
    End Sub

    Private Sub btnkelas11_Click(sender As Object, e As EventArgs) Handles btnkelas11.Click
        ShowFeature(Integer.Parse(Me.btnkelas11.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas11.Text, 11)
        Panel5.Visible = True
    End Sub

    Private Sub btnkelas12_Click(sender As Object, e As EventArgs) Handles btnkelas12.Click
        ShowFeature(Integer.Parse(Me.btnkelas12.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas12.Text, 12)
        Panel5.Visible = True
    End Sub

    Private Sub btnkelas13_Click(sender As Object, e As EventArgs) Handles btnkelas13.Click
        ShowFeature(Integer.Parse(Me.btnkelas13.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas13.Text, 13)
        Panel5.Visible = True
    End Sub

    Private Sub btnkelas14_Click(sender As Object, e As EventArgs) Handles btnkelas14.Click
        ShowFeature(Integer.Parse(Me.btnkelas14.Tag), Me.Guna2PictureBox3.Tag, Me.lblkelas14.Text, 14)
        Panel5.Visible = True
    End Sub

    Private Sub btnfeature3_Click(sender As Object, e As EventArgs) Handles btnfeature3.Click
        kontak.Show()
        Me.Hide()
        Dim BT As Guna.UI2.WinForms.Guna2Button = CType(sender, Guna.UI2.WinForms.Guna2Button)
        Select Case BT.Tag
            Case "ringkasanmateriPages"
                Ringkasan.Show()
                Ringkasan.Label26.Text = Me.Label26.Text
                Ringkasan.Label26.Tag = Me.Label26.Tag
                Ringkasan.Label2.Text = Me.Label13.Tag
                Ringkasan.Label2.Tag = Me.lblfeature3.Tag
                Ringkasan.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "sbmptnPages"
                SBMPTN.Show()
                SBMPTN.Label26.Text = Me.Label26.Text
                SBMPTN.Label26.Tag = Me.Label26.Tag
                SBMPTN.Label2.Text = Me.Label13.Tag
                SBMPTN.Label2.Tag = Me.lblfeature3.Tag
                SBMPTN.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "videoPages"
                Form2.Show()
                Form2.Label26.Text = Me.Label26.Text
                Form2.Label26.Tag = Me.Label26.Tag
                Form2.Label2.Text = Me.Label13.Tag
                Form2.Label2.Tag = Me.lblfeature3.Tag
                Form2.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
            Case "latihansoalPages"
                Soal.Show()
                Soal.Label26.Text = Me.Label26.Text
                Soal.Label26.Tag = Me.Label26.Tag
                Soal.Label2.Text = Me.Label13.Tag
                Soal.Label2.Tag = Me.lblfeature3.Tag
                Soal.Label1.Tag = Me.Guna2PictureBox3.Tag
                Me.Hide()
        End Select



    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click


        Signin.Show()
        Signin.Guna2TextBox1.Text = ""
        Signin.Guna2TextBox2.Text = ""
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim listNotif = GetNotification(Me.Guna2PictureBox3.Tag)
        Notifikasi.NotificationList = listNotif
        Notifikasi.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        kontak.Show()
        Me.Hide()
    End Sub
End Class