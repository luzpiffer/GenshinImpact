Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.UI.WebControls
Imports ADGenshinImpact
Imports System.Web.Script.Serialization

Public Class ConfirmarCompra
    Inherits System.Web.UI.Page

    Private pedidos As New Pedidos()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCarrito()
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub CargarCarrito()
        If Request.QueryString("carritoData") IsNot Nothing Then
            Dim carritoData As String = Request.QueryString("carritoData")
            Dim serializer As New JavaScriptSerializer()
            Dim productos As List(Of Producto) = serializer.Deserialize(Of List(Of Producto))(carritoData)
            Session("Carrito") = productos
        End If

        Dim productosEnSesion As List(Of Producto) = CType(Session("Carrito"), List(Of Producto))

        If productosEnSesion IsNot Nothing AndAlso productosEnSesion.Count > 0 Then
            OrderGridView.DataSource = productosEnSesion
            OrderGridView.DataBind()

            Dim total As Decimal = productosEnSesion.Sum(Function(p) p.Precio * p.Cantidad)
            txtTotal.Text = total.ToString("C")
        Else
            Response.Redirect("Tarjetas.aspx")
        End If
    End Sub

    Protected Sub FinalizarCompraButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Session("Usuario") Is Nothing OrElse Not Integer.TryParse(Session("Usuario").ToString(), Nothing) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Error: ClienteId no encontrado o inválido en la sesión. Por favor, inicia sesión nuevamente.');", True)
            Return
        End If

        Dim ClienteId As Integer = Convert.ToInt32(Session("Usuario"))

        Dim total As Decimal = Convert.ToDecimal(txtTotal.Text.Replace("$", "").Trim())

        Dim productosEnSesion As List(Of Producto) = CType(Session("Carrito"), List(Of Producto))

        Dim pedidoId As Integer = pedidos.FinalizarCompra(ClienteId, total)

        pedidos.InsertarDetallesPedido(pedidoId, productosEnSesion)

        Response.Redirect("CompraFinalizada.aspx")
    End Sub

    Protected Sub CancelarCompraButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelarCompra.Click
        Response.Redirect("Tarjetas.aspx")
    End Sub
End Class






