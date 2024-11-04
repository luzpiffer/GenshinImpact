Imports ADGenshinImpact

Public Class CRUDArmas1
    Inherits System.Web.UI.Page
    Dim oDs As New DataSet
    Dim o_Armas As New Armas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            cargargrilla()
        End If
    End Sub

    Public Sub limpiar()
        txtid.Text = Nothing
        txtarma.Text = Nothing
    End Sub

    Private Sub cargargrilla()
        Try
            oDs = New DataSet
            o_Armas = New Armas
            oDs = o_Armas.Cargar_Grilla
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
        Catch ex As Exception
            MostrarMensaje("Error", "Error al cargar la grilla de armas: " & ex.Message, "error")
        End Try
    End Sub

    Protected Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click
        If txtarma.Text <> Nothing Then
            Try
                oDs = New DataSet
                o_Armas = New Armas
                o_Armas.Cargar_Arma(txtarma.Text)
                MostrarMensaje("Carga Exitosa", "Se agregó con éxito", "success")
                limpiar()
                cargargrilla()
            Catch ex As Exception
                MostrarMensaje("Error", "Error: " & ex.Message, "error")
            End Try
        Else
            MostrarMensaje("Cargar Arma", "Complete los datos", "warning")
        End If
    End Sub

    Protected Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        If txtid.Text <> Nothing And txtarma.Text <> Nothing Then
            oDs = New DataSet
            o_Armas = New Armas
            o_Armas.Modificar_Arma(txtid.Text, txtarma.Text)
            MostrarMensaje("Carga Exitosa", "Se modificó con éxito", "success")
            limpiar()
            cargargrilla()
        Else
            MostrarMensaje("Cargar Arma", "Complete los datos", "warning")
        End If
    End Sub

    Protected Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If txtid.Text <> Nothing Then
            oDs = New DataSet
            o_Armas = New Armas
            o_Armas.Eliminar_Arma(txtid.Text)
            MostrarMensaje("Eliminación Exitosa", "Arma eliminada con éxito", "success")
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
            o_Armas = New Armas
            oDs = o_Armas.Consultar_Arma_ID(txtid.Text)
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
            limpiar()
        Else
            MostrarMensaje("Consultar Datos", "Ingrese un ID", "warning")
        End If
    End Sub
    Protected Sub btnconsultararma_Click(sender As Object, e As EventArgs) Handles btnconsultararma.Click
        If txtarma.Text <> Nothing Then
            oDs = New DataSet
            o_Armas = New Armas
            oDs = o_Armas.Consultar_Por_Arma(txtarma.Text)
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
            limpiar()
        Else
            MostrarMensaje("Consultar Datos", "Ingrese un arma", "warning")
        End If
    End Sub

    Protected Sub MostrarMensaje(titulo As String, mensaje As String, tipo As String)
        Dim script As String = $"Swal.fire({{ title: '{titulo}', text: '{mensaje}', icon: '{tipo}', confirmButtonText: 'OK' }});"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sweetalert", script, True)
    End Sub
End Class
