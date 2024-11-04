Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security
Imports ADGenshinImpact
Imports Microsoft.Win32
Public Class RegistroUsuario
    Inherits System.Web.UI.Page
    Dim oDs As New DataSet
    Dim o_Login As New Autenticacion
    Dim o_SignUp As New Autenticacion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub btnregistrarse_Click(sender As Object, e As EventArgs) Handles btnregistrarse.Click
        If Not String.IsNullOrEmpty(txtnombre.Text) AndAlso Not String.IsNullOrEmpty(txtapellido.Text) AndAlso
       Not String.IsNullOrEmpty(txttelefono.Text) AndAlso Not String.IsNullOrEmpty(txtdireccion.Text) AndAlso
       Not String.IsNullOrEmpty(txtemail.Text) AndAlso Not String.IsNullOrEmpty(txtcontrasena.Text) Then

            Dim o_SignUp As New Autenticacion

            If o_SignUp.VerificarCorreo(txtemail.Text) Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'El correo electrónico ya está registrado', icon: 'error', confirmButtonText: 'OK' });", True)
            Else
                Dim exito As Boolean = o_SignUp.RegistrarCliente(txtnombre.Text, txtapellido.Text, txttelefono.Text,
                                                            txtdireccion.Text, txtemail.Text, txtcontrasena.Text)

                If exito Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Éxito', text: 'Registro exitoso', icon: 'success', confirmButtonText: 'OK' }).then((result) => { if (result.isConfirmed) { window.location.href='login.aspx'; } });", True)
                Else
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'Error al registrar, inténtelo de nuevo', icon: 'error', confirmButtonText: 'OK' });", True)
                End If
            End If
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Swal.fire({ title: 'Error', text: 'Todos los campos son obligatorios', icon: 'error', confirmButtonText: 'OK' });", True)
        End If
    End Sub

    Protected Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged

    End Sub

    Protected Sub txtdireccion_TextChanged(sender As Object, e As EventArgs) Handles txtdireccion.TextChanged

    End Sub
End Class