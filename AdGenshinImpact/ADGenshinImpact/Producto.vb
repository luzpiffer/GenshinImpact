Public Class Producto
    Public Property ID_Personaje As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Cantidad As Integer

    Public ReadOnly Property Total As Decimal
        Get
            Return Precio * Cantidad
        End Get
    End Property
End Class
