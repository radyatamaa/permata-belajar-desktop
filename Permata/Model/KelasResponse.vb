Public Class KelasResponse
    Public Property Status As String
    Public Property Response As String
    Public Property Data As DataKelas
End Class
Public Class DataKelas
    Public Property Result As List(Of ResultKelas)
End Class
Public Class ResultKelas
    Public Property Page As Integer
    Public Property Data As List(Of DataResultKelas)
End Class
Public Class DataResultKelas
    Public Property Id_Kelas As Integer
    Public Property Kelas As String
    Public Property Icon As String
    Public Property Image As String
End Class
