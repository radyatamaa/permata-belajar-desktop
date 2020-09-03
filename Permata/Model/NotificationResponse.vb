Public Class NotificationResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As List(Of DataNotification)
End Class

Public Class DataNotification
    Public Property Id_Notification As Integer
    Public Property Too As String
    Public Property Id_Pelanggan As String
    Public Property Title As String
    Public Property Description As String
    Public Property Status As String
    Public Property Created_At As String
    Public Property Updated_At As String
End Class
