Imports Microsoft.Practices.EnterpriseLibrary.Data
Public Class Elementos
    Dim o_DataBase As Database

    Public Sub New()
        o_DataBase = DatabaseFactory.CreateDatabase("Conn")
    End Sub

    Public Function Cargar_Elemento(ByVal Elemento As String, ByVal Descripcion As String) As Double
        Try
            Return o_DataBase.ExecuteScalar("Cargar_Elemento", Elemento, Descripcion)
        Catch ex As Exception
            Throw New Exception("Error al cargar el elemento: " & ex.Message, ex)
        End Try
    End Function

    Public Function Cargar_Grilla() As DataSet
        Try
            Return o_DataBase.ExecuteDataSet("Consultar_Elementos")
        Catch ex As Exception
            Throw New Exception("Error al cargar la grilla de elementos: " & ex.Message, ex)
        End Try
    End Function

    Public Function Modificar_Elemento(ByVal ID As Integer, ByVal Elemento As String, ByVal Descripcion As String) As Double
        Return o_DataBase.ExecuteScalar("Modificar_Elemento", ID, Elemento, Descripcion)
    End Function

    Public Function Eliminar_Elemento(ByVal ID As Integer) As Double
        Return o_DataBase.ExecuteScalar("Eliminar_Elemento", ID)
    End Function

    Public Function Consultar_Elemento_ID(ByVal ID As Integer) As DataSet
        Return o_DataBase.ExecuteDataSet("Consultar_Elemento_ID", ID)
    End Function

    Public Function Consultar_Por_Elemento(ByVal Elemento As String) As DataSet
        Return o_DataBase.ExecuteDataSet("Consultar_Por_Elemento", Elemento)
    End Function
End Class
