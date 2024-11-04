Imports Microsoft.Practices.EnterpriseLibrary.Data
Public Class Armas
    Dim o_DataBase As Database

    Public Sub New()
        o_DataBase = DatabaseFactory.CreateDatabase("Conn")
    End Sub

    Public Function Cargar_Arma(ByVal Arma As String) As Double
        Try
            Return o_DataBase.ExecuteScalar("Cargar_Arma", Arma)
        Catch ex As Exception
            Throw New Exception("Error al cargar el arma: " & ex.Message, ex)
        End Try
    End Function

    Public Function Cargar_Grilla() As DataSet
        Try
            Return o_DataBase.ExecuteDataSet("Consultar_Armas")
        Catch ex As Exception
            Throw New Exception("Error al cargar la grilla de armas: " & ex.Message, ex)
        End Try
    End Function

    Public Function Modificar_Arma(ByVal ID As Integer, ByVal Arma As String) As Double
        Return o_DataBase.ExecuteScalar("Modificar_Arma", ID, Arma)
    End Function

    Public Function Eliminar_Arma(ByVal ID As Integer) As Double
        Return o_DataBase.ExecuteScalar("Eliminar_Arma", ID)
    End Function

    Public Function Consultar_Arma_ID(ByVal ID As Integer) As DataSet
        Return o_DataBase.ExecuteDataSet("Consultar_Arma_ID", ID)
    End Function

    Public Function Consultar_Por_Arma(ByVal Arma As String) As DataSet
        Return o_DataBase.ExecuteDataSet("Consultar_Por_Arma", Arma)
    End Function
End Class
