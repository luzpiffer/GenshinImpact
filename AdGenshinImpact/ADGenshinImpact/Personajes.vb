Imports System.Data.SqlClient
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.Practices.EnterpriseLibrary.Data
Public Class Personajes
    Dim o_DataBase As Database

    Public Sub New()
        o_DataBase = DatabaseFactory.CreateDatabase("Conn")
    End Sub

    Public Function Cargar_Combo_Naciones() As DataSet
        Return o_DataBase.ExecuteDataSet("Cargar_Combo_Naciones")
    End Function

    Public Function Cargar_Combo_Elementos() As DataSet
        Return o_DataBase.ExecuteDataSet("Cargar_Combo_Elementos")
    End Function

    Public Function Cargar_Combo_Armas() As DataSet
        Return o_DataBase.ExecuteDataSet("Cargar_Combo_Armas")
    End Function

    Public Function Cargar_Grilla() As DataSet
        Try
            Return o_DataBase.ExecuteDataSet("Consultar_Personajes")
        Catch ex As Exception
            Throw New Exception("Error al cargar la grilla de personajes: " & ex.Message, ex)
        End Try
    End Function

    Public Function Cargar_Personaje(ByVal Nombre As String, ByVal Altura As Decimal, ByVal Sexo As String, ByVal ID_Nacion As Integer, ByVal ID_Elemento As Integer, ByVal ID_Arma As Integer, ByVal Precio As Decimal, ByVal Cantidad As Integer, ByVal Imagen As String) As Double
        Try
            ' Ejecutar el procedimiento almacenado con el nuevo parámetro
            Return o_DataBase.ExecuteScalar("Cargar_Personaje", Nombre, Altura, Sexo, ID_Nacion, ID_Elemento, ID_Arma, Precio, Cantidad, Imagen)
        Catch ex As Exception
            Throw New Exception("Error al cargar el personaje: " & ex.Message, ex)
        End Try
    End Function


    Public Function Modificar_Personaje(ByVal ID As Integer, ByVal Nombre As String, ByVal Altura As Decimal, ByVal Sexo As String, ByVal ID_Nacion As Integer, ByVal ID_Elemento As Integer, ByVal ID_Arma As Integer, ByVal Precio As Decimal, ByVal Cantidad As Integer, ByVal Imagen As String) As Double
        Try
            Return o_DataBase.ExecuteScalar("Modificar_Personaje", ID, Nombre, Altura, Sexo, ID_Nacion, ID_Elemento, ID_Arma, Precio, Cantidad, Imagen)
        Catch ex As Exception
            Throw New Exception("Error al modificar el personaje: " & ex.Message, ex)
        End Try
    End Function

    Public Function ObtenerImagenActual(ByVal ID As Integer) As String
        Try
            Dim storedProcedure As String = "ObtenerImagenPersonaje"
            Dim connectionString As String = "Server = LAPTOP-I85C1DHM; Database = BD_GenshinImpact; Integrated Security = True;"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(storedProcedure, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ID_Personaje", ID)

                    connection.Open()

                    Dim imagenActual As Object = command.ExecuteScalar()

                    If imagenActual IsNot Nothing Then
                        Return imagenActual.ToString()
                    Else
                        Return String.Empty
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al obtener la imagen: " & ex.Message, ex)
        End Try
    End Function

    Public Function Eliminar_Personaje(ByVal ID As Integer) As Double
        Return o_DataBase.ExecuteScalar("Eliminar_Personaje", ID)
    End Function

    Public Function ConsultarPorNacion(idNacion As Integer) As DataSet
        Dim oDs As New DataSet()
        Using conn As New SqlConnection("Server = LAPTOP-I85C1DHM; Database = BD_GenshinImpact; Integrated Security = True;")
            Using cmd As New SqlCommand("ConsultarPersonajesPorNacion", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ID_Nacion", idNacion)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(oDs)
                End Using
            End Using
        End Using
        Return oDs
    End Function

    Public Function ConsultarPorElemento(idElemento As Integer) As DataSet
        Dim oDs As New DataSet()
        Using conn As New SqlConnection("Server = LAPTOP-I85C1DHM; Database = BD_GenshinImpact; Integrated Security = True;")
            Using cmd As New SqlCommand("ConsultarPersonajesPorElemento", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ID_Elemento", idElemento)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(oDs)
                End Using
            End Using
        End Using
        Return oDs
    End Function

    Public Function ConsultarPorArma(idArma As Integer) As DataSet
        Dim oDs As New DataSet()
        Using conn As New SqlConnection("Server = LAPTOP-I85C1DHM; Database = BD_GenshinImpact; Integrated Security = True;")
            Using cmd As New SqlCommand("ConsultarPersonajesPorArma", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ID_Arma", idArma)

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(oDs)
                End Using
            End Using
        End Using
        Return oDs
    End Function

    Public Function ConsultarPorNombre(ByVal Nombre As String) As DataSet
        Return o_DataBase.ExecuteDataSet("Productos_BuscarporNombre_Personaje", Nombre)
    End Function



    Public Function ConsultarPorID_Personaje(ByVal ID As Integer) As DataSet
        Return o_DataBase.ExecuteDataSet("Productos_BuscarporID_Personaje", ID)
    End Function
End Class
