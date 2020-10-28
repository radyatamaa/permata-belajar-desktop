Public Class TahunPTNResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As DataTahunJurusan
End Class

Public Class DataTahun
    Public Property Tahun As String
End Class
Public Class DataTahunJurusan
    Public Property TahunData As List(Of DataTahun)
    Public Property Tahun As String
    Public Property Jurusan As List(Of Jurusan)
End Class

Public Class Jurusan
    Public Property Page As Integer
    Public Property Data As List(Of TahunPTNJurusan)
End Class
