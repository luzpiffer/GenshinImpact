Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports ADGenshinImpact

Partial Public Class Clientes
    Inherits Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
        End If
    End Sub

    Private Sub CargarClientes()
        Dim connectionString As String = "Server = LAPTOP-I85C1DHM; Database = BD_GenshinImpact; Integrated Security = True" ' Reemplaza con tu cadena de conexión

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("sp_ObtenerClientes", conn)
                cmd.CommandType = CommandType.StoredProcedure
                conn.Open()

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    GridViewClientes.DataSource = reader
                    GridViewClientes.DataBind()
                End Using
            End Using
        End Using
    End Sub

    Protected Sub btnConsultarPedidos_Click(sender As Object, e As EventArgs) Handles btnConsultarPedidos.Click
        Response.Redirect("ConsultarPedidos.aspx")
    End Sub
End Class
