Imports Microsoft.Practices.EnterpriseLibrary.Data
Public Class Naciones
    Dim o_DataBase As Database

    Public Sub New()
        o_DataBase = DatabaseFactory.CreateDatabase("Conn")
    End Sub

    Public Function Cargar_Nacion(ByVal Nacion As String) As Double
        Try
            Return o_DataBase.ExecuteScalar("Cargar_Nacion", Nacion)
        Catch ex As Exception
            Throw New Exception("Error al cargar la nación: " & ex.Message, ex)
        End Try
    End Function

    Public Function Cargar_Grilla() As DataSet
        Try
            Return o_DataBase.ExecuteDataSet("Consultar_Naciones")
        Catch ex As Exception
            Throw New Exception("Error al cargar la grilla de naciones: " & ex.Message, ex)
        End Try
    End Function

    Public Function Modificar_Nacion(ByVal ID As Integer, ByVal Nacion As String) As Double
        Return o_DataBase.ExecuteScalar("Modificar_Nacion", ID, Nacion)
    End Function

    Public Function Eliminar_Nacion(ByVal ID As Integer) As Double
        Return o_DataBase.ExecuteScalar("Eliminar_Nacion", ID)
    End Function

    Public Function Consultar_Nacion_ID(ByVal ID As Integer) As DataSet
        Return o_DataBase.ExecuteDataSet("Consultar_Nacion_ID", ID)
    End Function

    Public Function Consultar_Por_Nacion(ByVal Nacion As String) As DataSet
        Return o_DataBase.ExecuteDataSet("Consultar_Por_Nacion", Nacion)
    End Function
End Class
