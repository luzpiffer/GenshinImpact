Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports ADGenshinImpact

Public Class CRUDPersonajes1
    Inherits System.Web.UI.Page
    Dim oDs As New DataSet
    Dim o_Personajes As New Personajes

    Public Sub Cargar_Combo_Naciones()
        Dim o_Personajes As New Personajes
        oDs = o_Personajes.Cargar_Combo_Naciones
        With cbonaciones
            .DataSource = oDs.Tables(0)
            .DataTextField = oDs.Tables(0).Columns(1).ToString
            .DataValueField = oDs.Tables(0).Columns(0).ToString
            .DataBind()
        End With
    End Sub

    Public Sub Cargar_Combo_Elementos()
        Dim o_Personajes As New Personajes
        oDs = o_Personajes.Cargar_Combo_Elementos
        With cboelementos
            .DataSource = oDs.Tables(0)
            .DataTextField = oDs.Tables(0).Columns(1).ToString
            .DataValueField = oDs.Tables(0).Columns(0).ToString
            .DataBind()
        End With
    End Sub

    Public Sub Cargar_Combo_Armas()
        Dim o_Personajes As New Personajes
        oDs = o_Personajes.Cargar_Combo_Armas
        With cboarmas
            .DataSource = oDs.Tables(0)
            .DataTextField = oDs.Tables(0).Columns(1).ToString
            .DataValueField = oDs.Tables(0).Columns(0).ToString
            .DataBind()
        End With
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Cargargrilla()
            Cargar_Combo_Naciones()
            Cargar_Combo_Elementos()
            Cargar_Combo_Armas()
        End If
    End Sub

    Protected Sub btncargar_Click(sender As Object, e As EventArgs) Handles btncargar.Click
        If FileUpload1.HasFile Then
            Dim imageBytes As Byte() = Nothing
            Using br As New BinaryReader(FileUpload1.PostedFile.InputStream)
                imageBytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength)
            End Using
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Dim base64ImagenRedimensionada As String = RedimensionarImagen(base64String, 300, 300)
            Image1.ImageUrl = "data:image/jpeg;base64," & base64ImagenRedimensionada
            Dim precio As Decimal
            Dim cantidad As Integer
            If Decimal.TryParse(txtprecio.Text, precio) AndAlso Integer.TryParse(txtcantidad.Text, cantidad) Then

                Dim oObjeto As New Personajes
                oObjeto.Cargar_Personaje(txtnombre.Text, txtaltura.Text, txtsexo.Text, cbonaciones.SelectedValue, cboelementos.SelectedValue, cboarmas.SelectedValue, precio, cantidad, base64String)
                MostrarMensaje("Éxito", "Producto guardado exitosamente", "success")
                Cargargrilla()
            Else
                MostrarMensaje("Error", "Por favor ingresa valores válidos para Precio y Cantidad.", "error")
            End If
        Else
            MostrarMensaje("Error", "No se pudo guardar la imagen", "error")
        End If
        Limpiar()
    End Sub

    Public Function RedimensionarImagen(base64String As String, maxWidth As Integer, maxHeight As Integer) As String
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Using ms As New MemoryStream(imageBytes)
            Dim imagenOriginal As Image = Image.FromStream(ms)
            Dim imgWidth As Integer = imagenOriginal.Width
            Dim imgHeight As Integer = imagenOriginal.Height
            Dim ratioX As Double = maxWidth / imgWidth
            Dim ratioY As Double = maxHeight / imgHeight
            Dim ratio As Double = Math.Min(ratioX, ratioY)
            Dim nuevoAncho As Integer = Convert.ToInt32(imgWidth * ratio)
            Dim nuevoAlto As Integer = Convert.ToInt32(imgHeight * ratio)
            Dim imagenRedimensionada As New Bitmap(nuevoAncho, nuevoAlto)
            Using g As Graphics = Graphics.FromImage(imagenRedimensionada)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(imagenOriginal, 0, 0, nuevoAncho, nuevoAlto)
            End Using
            Using msRedimensionada As New MemoryStream()
                imagenRedimensionada.Save(msRedimensionada, ImageFormat.Jpeg)
                Dim imagenRedimensionadaBytes As Byte() = msRedimensionada.ToArray()
                Return Convert.ToBase64String(imagenRedimensionadaBytes)
            End Using
        End Using
    End Function

    Private Sub Cargargrilla()
        Try
            oDs = New DataSet
            o_Personajes = New Personajes
            oDs = o_Personajes.Cargar_Grilla
            With grilla
                .DataSource = oDs.Tables(0)
                .DataBind()
            End With
        Catch ex As Exception
            MostrarMensaje("Error", "Error al cargar la grilla de personajes: " & ex.Message, "error")
        End Try
    End Sub

    ' Método para convertir la imagen Base64 a un formato visible
    Protected Function GetImage(ByVal imageData As Object) As String
        If imageData IsNot DBNull.Value Then
            Return "data:image/png;base64," & imageData.ToString()
        End If
        Return Nothing
    End Function

    Public Sub Limpiar()
        txtid.Text = Nothing
        txtnombre.Text = Nothing
        txtaltura.Text = Nothing
        txtsexo.Text = Nothing
        txtprecio.Text = Nothing
    End Sub

    Protected Sub btnconsultarnombre_Click(sender As Object, e As EventArgs) Handles btnconsultarnombre.Click
        Dim oDs As New DataSet
        Dim oObjeto As New Personajes()
        Dim Nombre As String = txtnombre.Text.Trim()

        If Not String.IsNullOrEmpty(Nombre) Then
            oDs = oObjeto.ConsultarPorNombre(Nombre)
            If oDs.Tables(0).Rows.Count > 0 Then
                grilla.DataSource = oDs.Tables(0)
                grilla.DataBind()
            Else
                MostrarMensaje("Consulta", "No se encontraron personajes con el nombre ingresado.", "warning")
            End If
        Else
            MostrarMensaje("Error", "Por favor ingrese un nombre para realizar la búsqueda.", "error")
        End If
    End Sub


    Protected Sub Btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim base64String As String = Nothing

        If FileUpload1.HasFile Then
            Dim imageBytes As Byte() = Nothing
            Using br As New BinaryReader(FileUpload1.PostedFile.InputStream)
                imageBytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength)
            End Using
            base64String = Convert.ToBase64String(imageBytes)
        Else
            Dim oPersonajes As New Personajes()
            Dim idPersonaje As Integer
            If Integer.TryParse(txtid.Text, idPersonaje) Then
                base64String = oPersonajes.ObtenerImagenActual(idPersonaje)
            Else
                MostrarMensaje("Error", "ID no válido.", "error")
                Exit Sub
            End If
        End If

        Dim precio As Decimal
        Dim cantidad As Integer
        If Decimal.TryParse(txtprecio.Text, precio) AndAlso Integer.TryParse(txtcantidad.Text, cantidad) Then
            Dim oObjeto As New Personajes
            oObjeto.Modificar_Personaje(txtid.Text, txtnombre.Text, txtaltura.Text, txtsexo.Text, cbonaciones.SelectedValue, cboelementos.SelectedValue, cboarmas.SelectedValue, precio, cantidad, base64String)
            MostrarMensaje("Éxito", "Personaje modificado exitosamente", "success")
            Cargargrilla()
        Else
            MostrarMensaje("Error", "Por favor ingresa valores válidos para Precio y Cantidad.", "error")
        End If
        Limpiar()
    End Sub

    Protected Sub Btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If txtid.Text <> Nothing Then
            oDs = New DataSet
            o_Personajes = New Personajes
            o_Personajes.Eliminar_Personaje(CInt(txtid.Text))
            MostrarMensaje("Éxito", "Personaje eliminado exitosamente", "success")
            Limpiar()
            Cargargrilla()
        Else
            MostrarMensaje("Error", "Por favor ingrese el ID.", "error")
        End If
    End Sub

    Protected Sub btnmostartodo_Click(sender As Object, e As EventArgs) Handles btnmostartodo.Click
        Cargargrilla()
    End Sub

    Protected Sub btnconsultarnaciones_Click(sender As Object, e As EventArgs) Handles btnconsultarnaciones.Click
        Dim oDs As New DataSet
        Dim oObjeto As New Personajes
        Dim ID_Nacion As Integer
        If Integer.TryParse(cbonaciones.SelectedValue, ID_Nacion) Then
            oDs = oObjeto.ConsultarPorNacion(ID_Nacion)
            If oDs.Tables(0).Rows.Count > 0 Then
                grilla.DataSource = oDs.Tables(0)
                grilla.DataBind()
            Else
                MostrarMensaje("Consulta", "No se encontraron personajes para la nación seleccionada.", "warning")
            End If
        Else
            MostrarMensaje("Error", "Por favor, selecciona una nación válida.", "error")
        End If
    End Sub

    Protected Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Dim oDs As New DataSet
        Dim oObjeto As New Personajes
        oDs = oObjeto.ConsultarPorID_Personaje(txtid.Text)
        If oDs.Tables(0).Rows.Count > 0 Then
            Dim imagenBase64 As String = oDs.Tables(0).Rows(0).Item("Imagen").ToString()
            If Not String.IsNullOrEmpty(imagenBase64) Then
                Image1.ImageUrl = "data:image/jpeg;base64," & imagenBase64
            End If
            txtnombre.Text = oDs.Tables(0).Rows(0).Item("Nombre")
            txtaltura.Text = oDs.Tables(0).Rows(0).Item("Altura")
            txtsexo.Text = oDs.Tables(0).Rows(0).Item("Sexo")
            cbonaciones.SelectedValue = oDs.Tables(0).Rows(0).Item("ID_Nacion")
            cboelementos.SelectedValue = oDs.Tables(0).Rows(0).Item("ID_Elemento")
            cboarmas.SelectedValue = oDs.Tables(0).Rows(0).Item("ID_Arma")
            txtprecio.Text = oDs.Tables(0).Rows(0).Item("Precio")
            txtcantidad.Text = oDs.Tables(0).Rows(0).Item("Cantidad")
        Else
            MostrarMensaje("Error", "Producto no existente", "error")
        End If
    End Sub

    Protected Sub btnconsultarelementos_Click(sender As Object, e As EventArgs) Handles btnconsultarelementos.Click
        Dim oDs As New DataSet
        Dim oObjeto As New Personajes
        Dim ID_Elemento As Integer
        If Integer.TryParse(cboelementos.SelectedValue, ID_Elemento) Then
            oDs = oObjeto.ConsultarPorElemento(ID_Elemento)
            If oDs.Tables(0).Rows.Count > 0 Then
                grilla.DataSource = oDs.Tables(0)
                grilla.DataBind()
            Else
                MostrarMensaje("Consulta", "No se encontraron personajes para el elemento seleccionado.", "warning")
            End If
        Else
            MostrarMensaje("Error", "Por favor, selecciona un elemento válido.", "error")
        End If
    End Sub

    Protected Sub btnconsultararmas_Click(sender As Object, e As EventArgs) Handles btnconsultararmas.Click
        Dim oDs As New DataSet
        Dim oObjeto As New Personajes
        Dim ID_Arma As Integer
        If Integer.TryParse(cboarmas.SelectedValue, ID_Arma) Then
            oDs = oObjeto.ConsultarPorArma(ID_Arma)
            If oDs.Tables(0).Rows.Count > 0 Then
                grilla.DataSource = oDs.Tables(0)
                grilla.DataBind()
            Else
                MostrarMensaje("Consulta", "No se encontraron personajes para el arma seleccionada.", "warning")
            End If
        Else
            MostrarMensaje("Error", "Por favor, selecciona una arma válida.", "error")
        End If
    End Sub

    Protected Sub MostrarMensaje(titulo As String, mensaje As String, tipo As String)
        Dim script As String = $"Swal.fire({{ title: '{titulo}', text: '{mensaje}', icon: '{tipo}', confirmButtonText: 'OK' }});"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "sweetalert", script, True)
    End Sub
End Class
