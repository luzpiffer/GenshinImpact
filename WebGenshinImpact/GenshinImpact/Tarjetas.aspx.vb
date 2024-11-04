Imports System.Data.SqlClient
Imports ADGenshinImpact
Imports System.Data
Imports System.Net.Mail

Public Class Tarjetas
    Inherits System.Web.UI.Page

    ' Método para obtener la imagen del producto
    Protected Function GetImage(ByVal imageData As Object) As String
        If imageData IsNot DBNull.Value AndAlso imageData IsNot Nothing Then
            Return "data:image/png;base64," & imageData.ToString()
        End If
        Return "~/images/default.png" ' Imagen por defecto si no hay imagen
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim oDs As New DataSet
            Dim o_productos As New Personajes
            oDs = o_productos.Cargar_Grilla()
            ProductRepeater.DataSource = oDs.Tables(0)
            ProductRepeater.DataBind()
        End If
    End Sub


    ' Método para manejar el botón de "Agregar al carrito"
    Protected Sub AddToCartButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As Button = CType(sender, Button)
        Dim ID_Personaje As Integer = Convert.ToInt32(button.CommandArgument)
        Dim oDs As New DataSet
        Dim oObjeto As New Personajes
        oDs = oObjeto.ConsultarPorID_Personaje(ID_Personaje)
        If oDs.Tables(0).Rows.Count > 0 Then
            Dim nombre As String = oDs.Tables(0).Rows(0).Item("Nombre").ToString()
            Dim precio As Decimal = Convert.ToDecimal(oDs.Tables(0).Rows(0).Item("Precio"))
            AddProductToCart(ID_Personaje, nombre, precio, 1)
        End If
    End Sub

    Private Sub AddProductToCart(ID_Personaje As Integer, Nombre As String, Precio As Decimal, Cantidad As Integer)
        Dim cart As List(Of CartItem) = TryCast(Session("Cart"), List(Of CartItem))
        If cart Is Nothing Then
            cart = New List(Of CartItem)()
        End If
        Dim existingItem As CartItem = cart.FirstOrDefault(Function(c) c.ID_Personaje = ID_Personaje)
        If existingItem IsNot Nothing Then
            existingItem.Cantidad += Cantidad
            existingItem.Total = existingItem.Precio * existingItem.Cantidad
        Else
            Dim newItem As New CartItem(ID_Personaje, Nombre, Precio, Cantidad)
            newItem.Total = Precio * Cantidad
            cart.Add(newItem)
        End If
        Session("Cart") = cart
    End Sub


    ' Método auxiliar para generar el código JavaScript en el lado del cliente
    Public Function GetOnClientClick(ByVal ID_Personaje As Object, ByVal Nombre As Object, ByVal Precio As Object) As String
        Return String.Format("addToCart({0}, '{1}', {2}); return false;", ID_Personaje, Nombre.ToString().Replace("'", "\'"), Precio)
    End Function

    Protected Sub ProductRepeater_ItemCommand(source As Object, e As RepeaterCommandEventArgs)

    End Sub

    Protected Sub btnSuscribirse_Click(sender As Object, e As EventArgs)
        Dim email As String = txtEmail.Text.Trim()
        If Not String.IsNullOrEmpty(email) Then
            If EmailExiste(email) Then
                MostrarMensaje("Este email ya está suscrito.", "error")
            Else
                GuardarEmail(email)
                EnviarCorreo(email)
                MostrarMensaje("Te has suscrito correctamente!", "success")
            End If
        Else
            MostrarMensaje("Por favor, introduce un email válido.", "error")
        End If
    End Sub

    Protected Sub GuardarEmail(email As String)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("sp_InsertarEmail", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Email", email)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MostrarMensaje("Error al guardar el email: " & ex.Message, "error")
        End Try
    End Sub

    Protected Function EmailExiste(email As String) As Boolean
        Dim existe As Boolean = False
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Conn").ConnectionString
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand("sp_VerificarEmailExistente", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Email", email)
                    conn.Open()
                    existe = Convert.ToBoolean(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MostrarMensaje("Error al verificar el email: " & ex.Message, "error")
        End Try
        Return existe
    End Function

    Protected Sub EnviarCorreo(email As String)
        Try
            Dim mensaje As New MailMessage()
            mensaje.From = New MailAddress("lulupiffer2018@gmail.com")
            mensaje.To.Add(email)
            mensaje.Subject = "Bienvenido a nuestra tienda"
            mensaje.Body = "Gracias por suscribirte a nuestras novedades. ¡Te mantendremos informado! (˶˃ ᵕ ˂˶) ⋆˙⟡"
            mensaje.IsBodyHtml = True

            Using smtp As New SmtpClient("smtp.gmail.com", 587)
                smtp.Credentials = New System.Net.NetworkCredential("lulupiffer2018@gmail.com", "unjojsyfgbakzfzp")
                smtp.EnableSsl = True
                smtp.Send(mensaje)
            End Using

            MostrarMensaje("Te has suscripto exitosamente", "success")
        Catch ex As Exception
            MostrarMensaje("Error al enviar el correo: " & ex.Message, "error")
        End Try
    End Sub

    Protected Sub MostrarMensaje(mensaje As String, tipo As String)
        Dim script As String = $"Swal.fire({{ title: 'Información', text: '{mensaje}', icon: '{tipo}', confirmButtonText: 'OK' }});"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sweetalert", script, True)
    End Sub
End Class

' Clase de ayuda para el carrito
Public Class CartItem
    Public Property ID_Personaje As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Cantidad As Integer
    Public Property Total As Decimal

    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal precio As Decimal, ByVal cantidad As Integer)
        Me.ID_Personaje = id
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Cantidad = cantidad
        Me.Total = precio * cantidad
    End Sub

End Class