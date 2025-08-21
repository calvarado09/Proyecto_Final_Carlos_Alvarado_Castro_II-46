Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Public Class UsuarioRepository
    Public Function Insertar(usuario As Usuario) As Boolean
        Try
            Dim helper As New DatabaseHelper()
            Dim query As String = "INSERT INTO Usuarios (Usuario, Contraseña, Rol, PacienteID) " &
                                  "VALUES (@Usuario, @Contraseña, @Rol, @PacienteID)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Usuario", usuario.Usuario),
                New SqlParameter("@Contraseña", usuario.Contraseña),
                New SqlParameter("@Rol", usuario.Rol),
                New SqlParameter("@PacienteID", usuario.PacienteID)
            }
            Return helper.ExecuteNonQuery(query, parametros)
        Catch ex As Exception
            Throw New Exception("Error al insertar usuario: " & ex.Message)
        End Try
    End Function

    Public Function ValidarLogin(usuario As String, contraseña As String) As Usuario
        Dim helper As New DatabaseHelper()
        Dim query As String = "SELECT * FROM Usuarios WHERE Usuario=@Usuario AND Contraseña=@Contraseña"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Usuario", usuario),
            New SqlParameter("@Contraseña", contraseña)
        }
        Dim dt As DataTable = helper.ExecuteQuery(query, parameters)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row = dt.Rows(0)
            Dim user As New Usuario() With {
                .UsuarioID = Convert.ToInt32(row("UsuarioID")),
                .Usuario = row("Usuario").ToString(),
                .Contraseña = row("Contraseña").ToString(),
                .Rol = row("Rol").ToString(),
                .PacienteID = Convert.ToInt32(row("PacienteID"))
            }
            Return user
        End If
        Return Nothing
    End Function


End Class
