Public Class VideoTopik
    Public Property Id_Content As Integer
    Public Property Topik As String
    Public Property Sort As String
    Public Property Available As Boolean
    Public Property File As List(Of VideoTopikFile)
    Public Property Quiz As String
    Public Property QuizSubmit As String
    Public Property Final As String
End Class

Public Class VideoTopikFile
    Public Property Id_Content As Integer
    Public Property Id_Video As Integer?
    Public Property Title As String
    Public Property File As String
    Public Property Banner As String
    Public Property Free As String
    Public Property Timeline As String
    Public Property Duration As String
    Public Property Read As String
End Class
