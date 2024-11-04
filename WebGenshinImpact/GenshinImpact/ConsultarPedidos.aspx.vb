Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports ADGenshinImpact

Public Class ConsultarPedidos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
            Dim clienteId As String = ddlClientes.SelectedValue
            If Not String.IsNullOrEmpty(clienteId) Then
                ConsultarPedidosPorCliente(clienteId)
            End If
        End If
    End Sub

    Private Sub CargarClientes()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT ClienteId, Nombre + ' ' + Apellido AS NombreCompleto FROM Clientes"
            Using cmd As New SqlCommand(query, conn)
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                ddlClientes.DataSource = reader
                ddlClientes.DataTextField = "NombreCompleto"
                ddlClientes.DataValueField = "ClienteId"
                ddlClientes.DataBind()
            End Using
        End Using

        ddlClientes.Items.Insert(0, New ListItem("Seleccione un cliente", String.Empty))
    End Sub

    Protected Sub btnConsultar_Click(sender As Object, e As EventArgs)
        Dim clienteId As String = ddlClientes.SelectedValue
        If Not String.IsNullOrEmpty(clienteId) Then
            ConsultarPedidosPorCliente(clienteId)
        End If
    End Sub

    Private Sub ConsultarPedidosPorCliente(clienteId As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString
        Dim dt As New DataTable()

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("sp_ObtenerPedidosPorCliente", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ClienteId", clienteId)
                conn.Open()

                Dim adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using

        GridViewPedidos.DataSource = dt
        GridViewPedidos.DataBind()
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Clientes.aspx")
    End Sub

    Protected Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Response.Redirect("ConsultarPedidosDetalles.aspx")
    End Sub

    Protected Sub ddlEstado_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim ddlEstado As DropDownList = CType(sender, DropDownList)
        Dim row As GridViewRow = CType(ddlEstado.NamingContainer, GridViewRow)
        Dim pedidoId As Integer = Convert.ToInt32(GridViewPedidos.DataKeys(row.RowIndex).Value)
        Dim nuevoEstado As String = ddlEstado.SelectedValue

        ActualizarEstadoPedido(pedidoId, nuevoEstado)
    End Sub

    Private Sub ActualizarEstadoPedido(pedidoId As Integer, estado As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("sp_ActualizarEstadoPedido", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@PedidoId", pedidoId)
                cmd.Parameters.AddWithValue("@Estado", estado)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class


