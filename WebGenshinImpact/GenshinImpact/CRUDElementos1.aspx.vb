Imports ADGenshinImpact

Public Class CRUDElementos1
    Inherits System.Web.UI.Page

    Dim oDs As New DataSet
    Dim o_Elementos As New Elementos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            cargargrilla()
        End If
    End Sub

    Public Sub limpiar()
        txtid.Text = Nothing
        txtelemento.Text = Nothing
        txtdescripcion.Text = Nothing
    End Sub

    Private Sub cargargrilla()
        Try
            oDs = New DataSet
            o_Elementos = New Elementos
            oDs = o_Elementos.Cargar_Grilla
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
        Catch ex As Exception
            MostrarMensaje("Error", "Error al cargar la grilla de elementos: " & ex.Message, "error")
        End Try
    End Sub


    Protected Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click
        If txtelemento.Text <> Nothing And txtdescripcion.Text <> Nothing Then
            Try
                oDs = New DataSet
                o_Elementos = New Elementos
                o_Elementos.Cargar_Elemento(txtelemento.Text, txtdescripcion.Text)
                MostrarMensaje("Carga Exitosa", "Se agregó con éxito", "success")
                limpiar()
                cargargrilla()
            Catch ex As Exception
                MostrarMensaje("Error", "Error: " & ex.Message, "error")
            End Try
        Else
            MostrarMensaje("Cargar Elemento", "Complete los datos", "warning")
        End If
    End Sub

    Protected Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        If txtid.Text <> Nothing And txtelemento.Text <> Nothing And txtdescripcion.Text <> Nothing Then
            oDs = New DataSet
            o_Elementos = New Elementos
            o_Elementos.Modificar_Elemento(txtid.Text, txtelemento.Text, txtdescripcion.Text)
            MostrarMensaje("Carga Exitosa", "Se modificó con éxito", "success")
            limpiar()
            cargargrilla()
        Else
            MostrarMensaje("Cargar Elemento", "Complete los datos", "warning")
        End If
    End Sub


    Protected Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If txtid.Text <> Nothing Then
            oDs = New DataSet
            o_Elementos = New Elementos
            o_Elementos.Eliminar_Elemento(txtid.Text)
            MostrarMensaje("Eliminación Exitosa", "Elemento eliminado con éxito", "success")
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
            o_Elementos = New Elementos
            oDs = o_Elementos.Consultar_Elemento_ID(txtid.Text)
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
            limpiar()
        Else
            MostrarMensaje("Consultar Datos", "Ingrese un ID", "warning")
        End If
    End Sub


    Protected Sub btnconsultarelemento_Click(sender As Object, e As EventArgs) Handles btnconsultarelemento.Click
        If txtelemento.Text <> Nothing Then
            oDs = New DataSet
            o_Elementos = New Elementos
            oDs = o_Elementos.Consultar_Por_Elemento(txtelemento.Text)
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
            limpiar()
        Else
            MostrarMensaje("Consultar Datos", "Ingrese un elemento", "warning")
        End If
    End Sub

    Protected Sub MostrarMensaje(titulo As String, mensaje As String, tipo As String)
        Dim script As String = $"Swal.fire({{ title: '{titulo}', text: '{mensaje}', icon: '{tipo}', confirmButtonText: 'OK' }});"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sweetalert", script, True)
    End Sub
End Class
