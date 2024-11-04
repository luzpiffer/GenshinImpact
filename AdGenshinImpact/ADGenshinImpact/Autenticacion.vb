Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Data.SqlClient

Public Class Autenticacion
    Dim o_Database As Database

    Public Sub New()
        o_Database = DatabaseFactory.CreateDatabase("Conn")
    End Sub

    Public Function VerificarCorreo(email As String) As Boolean
        Dim existe As Boolean = False
        Using comando As DbCommand = o_Database.GetStoredProcCommand("VerificarCorreo")
            o_Database.AddInParameter(comando, "@Email", DbType.String, email)
            Dim count As Integer = Convert.ToInt32(o_Database.ExecuteScalar(comando))
            existe = (count > 0)
        End Using
        Return existe
    End Function

    ' Método para registrar un nuevo cliente
    Public Function RegistrarCliente(Nombre As String, Apellido As String, Email As String, Telefono As String, Direccion As String, Contrasena As String) As Boolean
        Dim resultado As Boolean = False
        Using comando As DbCommand = o_Database.GetStoredProcCommand("RegistrarCliente")
            o_Database.AddInParameter(comando, "@Nombre", DbType.String, Nombre)
            o_Database.AddInParameter(comando, "@Apellido", DbType.String, Apellido)
            o_Database.AddInParameter(comando, "@Email", DbType.String, Email)
            o_Database.AddInParameter(comando, "@Telefono", DbType.String, Telefono)
            o_Database.AddInParameter(comando, "@Direccion", DbType.String, Direccion)
            o_Database.AddInParameter(comando, "@FechaRegistro", DbType.DateTime, DateTime.Now)
            o_Database.AddInParameter(comando, "@Contrasena", DbType.String, Contrasena)
            Try
                o_Database.ExecuteNonQuery(comando)
                resultado = True
            Catch ex As SqlException
            End Try
        End Using
        Return resultado
    End Function

    Public Function VerificarAdmin(email As String, contrasena As String) As Boolean
        Dim query As String = "sp_VerificarAdmin"
        Using dbCommand As DbCommand = o_Database.GetStoredProcCommand(query)
            o_Database.AddInParameter(dbCommand, "@Email", DbType.String, email)
            o_Database.AddInParameter(dbCommand, "@Contrasena", DbType.String, contrasena)
            Using reader As IDataReader = o_Database.ExecuteReader(dbCommand)
                Return reader.Read()
            End Using
        End Using
    End Function

    Public Function VerificarCliente(email As String, contrasena As String) As Boolean
        Dim query As String = "sp_VerificarCliente"
        Using dbCommand As DbCommand = o_Database.GetStoredProcCommand(query)
            o_Database.AddInParameter(dbCommand, "@Email", DbType.String, email)
            o_Database.AddInParameter(dbCommand, "@Contrasena", DbType.String, contrasena)
            Using reader As IDataReader = o_Database.ExecuteReader(dbCommand)
                Return reader.Read()
            End Using
        End Using
    End Function

    ' Nueva función para obtener ClienteId por email
    Public Function ObtenerClienteIdPorEmail(email As String) As Integer
        Dim clienteId As Integer = 0
        Using comando As DbCommand = o_Database.GetStoredProcCommand("ObtenerClienteIdPorEmail")
            o_Database.AddInParameter(comando, "@Email", DbType.String, email)
            clienteId = Convert.ToInt32(o_Database.ExecuteScalar(comando))
        End Using
        Return clienteId
    End Function
End Class
