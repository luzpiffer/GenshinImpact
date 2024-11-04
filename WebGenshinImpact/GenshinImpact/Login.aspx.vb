Imports ADGenshinImpact

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtemail.Text = String.Empty
            txtcontrasena.Text = String.Empty
        End If
    End Sub

    Protected Sub btniniciarsesion_Click(sender As Object, e As EventArgs) Handles btniniciarsesion.Click
        Dim email As String = txtemail.Text.Trim()
        Dim contrasena As String = txtcontrasena.Text.Trim()

        If String.IsNullOrEmpty(email) OrElse String.IsNullOrEmpty(contrasena) Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'Por favor, complete todos los campos', icon: 'error', confirmButtonText: 'OK' });", True)
        Else
            Dim o_Auth As New Autenticacion()
            If o_Auth.VerificarAdmin(email, contrasena) Then
                Session("Usuario") = o_Auth.ObtenerClienteIdPorEmail(email)
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Éxito', text: 'Iniciando sesión como administrador', icon: 'success', confirmButtonText: 'OK' }).then((result) => { if (result.isConfirmed) { window.location.href='CRUDPersonajes1.aspx'; } });", True)
            ElseIf o_Auth.VerificarCliente(email, contrasena) Then
                Session("Usuario") = o_Auth.ObtenerClienteIdPorEmail(email)
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Éxito', text: 'Iniciando sesión como cliente', icon: 'success', confirmButtonText: 'OK' }).then((result) => { if (result.isConfirmed) { window.location.href='index.aspx'; } });", True)
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'Email o contraseña incorrectos', icon: 'error', confirmButtonText: 'OK' });", True)
            End If
        End If
    End Sub
End Class

