Public Class SoalLatihanResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As DataSoalLatihan
End Class
Public Class DataSoalLatihan
    Public Property Total As String
    Public Property PerPage As Integer
    Public Property Page As Integer
    Public Property LastPage As Integer
    Public Property Data As List(Of SoalLatihan)
End Class

Public Class SoalLatihan
    Public Property Id_Execute As Integer
    Public Property Title As String
    Public Property Soal As String
    Public Property Pembahasan As String
    Public Property Free As Boolean
    Public Property Jawaban As String
    Public Property Jawaban_User As String
    Public Property Id_Examp As Integer
End Class
