Imports System.Data.SqlClient
Imports ADGenshinImpact
Imports System.Data
Imports System.Net.Mail

Public Class Contactanos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    Protected Sub EnviarCorreoContacto(ByVal sender As Object, ByVal e As EventArgs)
        Dim nombre As String = Request.Form("nombre")
        Dim email As String = Request.Form("email")
        Dim mensaje As String = Request.Form("mensaje")

        If String.IsNullOrEmpty(nombre) Or String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(mensaje) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'Completa todos los datos', icon: 'warning', confirmButtonText: 'OK' });", True)
            Return
        End If

        Try
            Dim mail As New MailMessage()
            mail.From = New MailAddress("lulupiffer2018@gmail.com")
            mail.To.Add("lulupiffer2018@gmail.com")
            mail.Subject = "Nuevo mensaje de contacto"
            mail.Body = "Nombre: " & nombre & vbCrLf & "Email: " & email & vbCrLf & "Mensaje: " & mensaje
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.Credentials = New Net.NetworkCredential("lulupiffer2018@gmail.com", "qbmnmtqzuycdqbfe")
            smtp.EnableSsl = True
            smtp.Send(mail)
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Éxito', text: 'Tu comentario se ha enviado', icon: 'success', confirmButtonText: 'OK' }).then((result) => { if (result.isConfirmed) { window.location.href='Contactanos.aspx'; } });", True)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'Tu comentario no se ha podido enviar, intenta de nuevo', icon: 'error', confirmButtonText: 'OK' });", True)
        End Try
    End Sub

    Protected Sub btnSuscribirse_Click(sender As Object, e As EventArgs)
        Dim email As String = txtEmail.Text.Trim()
        If Not String.IsNullOrEmpty(email) Then
            If EmailExiste(email) Then
                MostrarMensaje("Este email ya está suscrito.", "error")
            Else
                GuardarEmail(email)
                EnviarCorreoSuscripcion(email)
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

    Protected Sub EnviarCorreoSuscripcion(email As String)
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
