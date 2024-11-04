Imports ADGenshinImpact
Public Class CRUDNaciones1
    Inherits System.Web.UI.Page
    Dim oDs As New DataSet
    Dim o_Naciones As New Naciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            cargargrilla()
        End If
    End Sub

    Public Sub limpiar()
        txtid.Text = Nothing
        txtnacion.Text = Nothing
    End Sub

    Private Sub cargargrilla()
        Try
            oDs = New DataSet
            o_Naciones = New Naciones
            oDs = o_Naciones.Cargar_Grilla
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
        Catch ex As Exception
            MostrarMensaje("Error", "Error al cargar la grilla de naciones: " & ex.Message, "error")
        End Try
    End Sub

    Protected Sub btncargar_Click1(sender As Object, e As EventArgs) Handles btncargar.Click
        If txtnacion.Text <> Nothing Then
            Try
                oDs = New DataSet
                o_Naciones = New Naciones
                o_Naciones.Cargar_Nacion(txtnacion.Text)
                MostrarMensaje("Carga Exitosa", "Se agregó con éxito", "success")
                limpiar()
                cargargrilla()
            Catch ex As Exception
                MostrarMensaje("Error", "Error: " & ex.Message, "error")
            End Try
        Else
            MostrarMensaje("Cargar Nacion", "Complete los datos", "warning")
        End If
    End Sub

    Protected Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        If txtid.Text <> Nothing And txtnacion.Text <> Nothing Then
            oDs = New DataSet
            o_Naciones = New Naciones
            o_Naciones.Modificar_Nacion(txtid.Text, txtnacion.Text)
            MostrarMensaje("Carga Exitosa", "Se modificó con éxito", "success")
            limpiar()
            cargargrilla()
        Else
            MostrarMensaje("Cargar Nacion", "Complete los datos", "warning")
        End If
    End Sub

    Protected Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If txtid.Text <> Nothing Then
            oDs = New DataSet
            o_Naciones = New Naciones
            o_Naciones.Eliminar_Nacion(txtid.Text)
            MostrarMensaje("Eliminación Exitosa", "Nación eliminada con éxito", "success")
            limpiar()
            cargargrilla()
        Else
            MostrarMensaje("Cargar datos", "Ingrese un ID", "warning")
        End If
    End Sub

    Protected Sub btnmostartodo_Click(sender As Object, e As EventArgs) Handles btnmostartodo.Click
        cargargrilla()
    End Sub

    Protected Sub btnconsultarid_Click(sender As Object, e As EventArgs) Handles btnconsultarid.Click
        If txtid.Text <> Nothing Then
            oDs = New DataSet
            oDs = o_Naciones.Consultar_Nacion_ID(txtid.Text)
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
            limpiar()
        Else
            MostrarMensaje("Consultar Datos", "Ingrese un ID", "warning")
        End If
    End Sub

    Protected Sub btnconsultarnacion_Click(sender As Object, e As EventArgs) Handles btnconsultarnacion.Click
        If txtnacion.Text <> Nothing Then
            oDs = New DataSet
            o_Naciones = New Naciones
            oDs = o_Naciones.Consultar_Por_Nacion(txtnacion.Text)
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
            limpiar()
        Else
            MostrarMensaje("Consultar Datos", "Ingrese una nación", "warning")
        End If
    End Sub

    Protected Sub MostrarMensaje(titulo As String, mensaje As String, tipo As String)
        Dim script As String = $"Swal.fire({{ title: '{titulo}', text: '{mensaje}', icon: '{tipo}', confirmButtonText: 'OK' }});"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sweetalert", script, True)
    End Sub
End Class
