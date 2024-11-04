Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Pedidos

    Private connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString

    ' Obtener los productos del carrito
    Public Function ObtenerCarrito() As List(Of Producto)
        Dim productos As New List(Of Producto)()

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("ObtenerCarrito", con)
                cmd.CommandType = CommandType.StoredProcedure
                con.Open()

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim producto As New Producto() With {
                            .ID_Personaje = Convert.ToInt32(reader("ID_Personaje")),
                            .Nombre = reader("Nombre").ToString(),
                            .Precio = Convert.ToDecimal(reader("Precio")),
                            .Cantidad = Convert.ToInt32(reader("Cantidad"))
                        }
                        productos.Add(producto)
                    End While
                End Using
            End Using
        End Using

        Return productos
    End Function

    Public Function FinalizarCompra(clienteId As Integer, total As Decimal) As Integer
        Dim pedidoId As Integer = 0

        If Not ClienteExiste(clienteId) Then
            Throw New Exception("Error: El ClienteId no existe.")
        End If

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("FinalizarCompra", con)
                cmd.CommandType = CommandType.StoredProcedure
                ' Agregar parámetros
                cmd.Parameters.AddWithValue("@ClienteId", clienteId)
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now)
                cmd.Parameters.AddWithValue("@Total", total)
                cmd.Parameters.AddWithValue("@Estado", "P") ' Estado: "P" = Pendiente
                con.Open()
                pedidoId = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
        Return pedidoId
    End Function

    Private Function ClienteExiste(clienteId As Integer) As Boolean
        Dim existe As Boolean = False
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM Clientes WHERE ClienteId = @ClienteId", con)
                cmd.Parameters.AddWithValue("@ClienteId", clienteId)
                con.Open()
                existe = Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using
        Return existe
    End Function

    Public Sub InsertarDetallesPedido(pedidoId As Integer, productos As List(Of Producto))
        Using con As New SqlConnection(connectionString)
            con.Open()
            Using tran As SqlTransaction = con.BeginTransaction()
                Try
                    For Each producto As Producto In productos
                        Using cmd As New SqlCommand("InsertarDetallesPedido", con, tran)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.AddWithValue("@PedidoId", pedidoId)
                            cmd.Parameters.AddWithValue("@ID_Personaje", producto.ID_Personaje)
                            cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad)
                            cmd.Parameters.AddWithValue("@PrecioUnitario", producto.Precio)
                            cmd.ExecuteNonQuery()
                        End Using
                    Next
                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    Throw New Exception("Error al insertar detalles del pedido: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


End Class




