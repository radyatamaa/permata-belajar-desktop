Public Class TahunPTNJurusan
    Public Property Id_Jurusan As Integer
    Public Property Jurusan As String
    Public Property Id_Kelas As Integer
    Public Property Icon As String
    Public Property Image As String
End Class

Public Class TahunPTNJurusanDto
    Public Property SelectedTahun As String
    Public Property Tahun As List(Of DataTahun)
    Public Property Data As List(Of TahunPTNJurusan)
End Class
