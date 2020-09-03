Imports System.IO
Imports System.Net

Public Class Notifikasi
    Public Property NotificationList As New NotificationResponse
    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        MenuUtama.Show()
        Me.Close()
    End Sub

    Private Sub Notifikasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Dim lastIndex As Integer = 0
        For i As Integer = 0 To NotificationList.Data.Count

            Dim featureButton As Control() = Me.Controls.Find("ntf" + i.ToString(), True)

            Try
                featureButton.FirstOrDefault().Text = NotificationList.Data(i).Title
                featureButton.FirstOrDefault().Tag = NotificationList.Data(i).Id_Notification
                featureButton.FirstOrDefault().Visible = True
                lastIndex = lastIndex + 1
            Catch ex As Exception

            End Try

        Next i

        For i As Integer = (lastIndex) To 4
            If lastIndex <> NotificationList.Data.Count + 1 Then
                Dim featureButton As Control() = Me.Controls.Find("ntf" + i.ToString(), True)

                featureButton.FirstOrDefault().Visible = False
            End If
        Next

        If NotificationList.Data.Count = 0 Then
            For i As Integer = 0 To 4

                Dim featureButton As Control() = Me.Controls.Find("ntf" + i.ToString(), True)

                featureButton.FirstOrDefault().Visible = False

            Next i
        End If
    End Sub

    Private Sub ntf0_Click(sender As Object, e As EventArgs) Handles ntf0.Click
        Dim notification = NotificationList.Data.Where(Function(x) x.Id_Notification = ntf0.Tag).FirstOrDefault()
        If notification IsNot Nothing Then
            TextBox1.Text = notification.Description
        End If
    End Sub

    Private Sub ntf1_Click(sender As Object, e As EventArgs) Handles ntf1.Click
        Dim notification = NotificationList.Data.Where(Function(x) x.Id_Notification = ntf1.Tag).FirstOrDefault()
        If notification IsNot Nothing Then
            TextBox1.Text = notification.Description
        End If
    End Sub

    Private Sub ntf2_Click(sender As Object, e As EventArgs) Handles ntf2.Click
        Dim notification = NotificationList.Data.Where(Function(x) x.Id_Notification = ntf2.Tag).FirstOrDefault()
        If notification IsNot Nothing Then
            TextBox1.Text = notification.Description
        End If
    End Sub

    Private Sub ntf3_Click(sender As Object, e As EventArgs) Handles ntf3.Click
        Dim notification = NotificationList.Data.Where(Function(x) x.Id_Notification = ntf3.Tag).FirstOrDefault()
        If notification IsNot Nothing Then
            TextBox1.Text = notification.Description
        End If
    End Sub

    Private Sub ntf4_Click(sender As Object, e As EventArgs) Handles ntf4.Click
        Dim notification = NotificationList.Data.Where(Function(x) x.Id_Notification = ntf4.Tag).FirstOrDefault()
        If notification IsNot Nothing Then
            TextBox1.Text = notification.Description
        End If
    End Sub
End Class