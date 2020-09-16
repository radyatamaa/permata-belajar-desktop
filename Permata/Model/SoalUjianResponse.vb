Public Class SoalUjianResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As DataUjian
    Public Property TextInformation As String
End Class
Public Class DataUjian
    Public Property Ujian As List(Of Ujian)
    Public Property UjianActive As Integer
    Public Property DataUjian As String
    Public Property Kumpulan As List(Of SoalUjian)
End Class
Public Class Ujian
    Public Property Id_Content As Integer
    Public Property Ujian As String
    Public Property Sort As Integer
End Class
Public Class SoalUjian
    Public Property Id_Content As Integer
    Public Property Id_Kumpulan As Integer
    Public Property Kumpulan As String
    Public Property Sort As String
    Public Property Free As Boolean
End Class
