Public Class FeatureResponse
    Public Property Status As String
    Public Property Response As String
    Public Property Data As DataFeature
End Class
Public Class DataFeature
    Public Property Paket As String
    Public Property Langganan As Boolean
    Public Property Feature As List(Of FeatureWithPage)
End Class
Public Class FeatureWithPage
    Public Property Page As Integer
    Public Property Data As List(Of Feature)
End Class
Public Class DataLangganan
    Public Property Title As String
    Public Property Langganan As Boolean
    Public Property Command As String
    Public Property Page As String
End Class