Public Class SemesterResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As List(Of DataSemester)
End Class
Public Class DataSemester
    Public Property Id_Content As Integer
    Public Property Id_Semester As Integer
    Public Property Semester As String
    Public Property Sort As Integer
    Public Property Page As String
End Class
