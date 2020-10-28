Public Class FeaturePTNResponse
    Public Property Status As String
    Public Property Responses As String
    Public Property Data As List(Of FeaturePTN)
End Class

Public Class FeaturePTN
    Public Property Id_Content As Integer
    Public Property Kelas As String
    Public Property Feauture As String
    Public Property Tahun As Integer
    Public Property Ujian As String
    Public Property Bid_Studi As String
    Public Property Free As Boolean
    Public Property Jumlah As String
    Public Property Jumlah_Soal As String
    Public Property NullCommand As String
End Class
