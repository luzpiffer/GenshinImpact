Imports System.Data.SqlClient
Imports System.Configuration
Imports ADGenshinImpact

Public Class ConsultarPedidosDetalles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDetallesPedidos()
        End If
    End Sub

    Private Sub CargarDetallesPedidos()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString

        Using conn As New SqlConnection(connectionString)
            Dim query As String = "SELECT DetalleId, PedidoId, ID_Personaje, Cantidad, PrecioUnitario FROM DetallesPedidos"
            Dim cmd As New SqlCommand(query, conn)

            conn.Open()

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            GridViewDetalles.DataSource = reader
            GridViewDetalles.DataBind()

            conn.Close()
        End Using
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("ConsultarPedidos.aspx")
    End Sub
End Class
