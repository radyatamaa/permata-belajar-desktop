Public Class RingkasanMateriResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As DataRingkasanMateri

End Class
Public Class DataRingkasanMateri
    Public Property Jurusan As List(Of RingkasanMateriJurusan)
    Public Property Jurusan_Active As Integer
    Public Property Mata_Pelajaran As List(Of MataPelajaran)

End Class
Public Class RingkasanMateriJurusan
    Public Property Id_Jurusan As Integer
    Public Property Jurusan As String
    Public Property Sort As String
End Class
Public Class MataPelajaran
    Public Property Page As Integer
    Public Property Data As List(Of RingkasanMataPelajaran)
End Class
