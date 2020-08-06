Public Class RingkasanMateriTopik
    Public Property Id_Content As Integer
    Public Property Topik As String
    Public Property Sort As String
    Public Property Available As Boolean
    Public Property File As List(Of RingkasanMateriTopikFile)
    Public Property Quiz As String
    Public Property QuizSubmit As String
    Public Property Final As String
End Class
Public Class RingkasanMateriTopikFile
    Public Property Id_Content As Integer
    Public Property Id_Ringkasan_Materi As Integer?
    Public Property Title As String
    Public Property File As String
    Public Property Free As String
    Public Property Url As String
    Public Property Access As Boolean
    Public Property Read As String
End Class