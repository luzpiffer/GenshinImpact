Imports System.Net.Mail
Imports System.Data.SqlClient

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

