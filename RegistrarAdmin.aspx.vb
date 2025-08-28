Public Class RegistrarAdmin
    Inherits System.Web.UI.Page

    Private usuarioRepo As New UsuarioRepository()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarUsuarios()
        End If
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        Try
            Dim encriptador As New Simple3Des("Clave") ' Clave de encriptasion
            Dim claveEncriptada As String = encriptador.EncryptData(txtContraseña.Text.Trim()) ' Encriptar la contraseña
            Dim nuevoUsuario As New Usuario With {
                .Usuario = txtUsuario.Text.Trim(),
                .Contraseña = claveEncriptada,
                .Rol = "Administrador",
                .PacienteID = Nothing,
                .DoctorID = Nothing
            }

            If usuarioRepo.Insertar(nuevoUsuario) Then
                lblMensaje.ForeColor = Drawing.Color.Green
                lblMensaje.Text = "Usuario administrativo registrado con éxito."
                txtUsuario.Text = ""
                txtContraseña.Text = ""
                CargarUsuarios()
            Else
                lblMensaje.ForeColor = Drawing.Color.Red
                lblMensaje.Text = "No se pudo registrar el usuario."
            End If

        Catch ex As Exception
            lblMensaje.ForeColor = Drawing.Color.Red
            lblMensaje.Text = "Error: " & ex.Message
        End Try
    End Sub

    Private Sub CargarUsuarios()
        Dim dt As DataTable = usuarioRepo.ObtenerUsuariosConRelaciones()
        gvUsuarios.DataSource = dt
        gvUsuarios.DataBind()
    End Sub

    Protected Sub gvUsuarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim repo As New UsuarioRepository() 'se istancia el repositorio
            Dim usuarioID As Integer = Convert.ToInt32(gvUsuarios.DataKeys(e.RowIndex).Value)

            Dim exito As Boolean = repo.EliminarUsuario(usuarioID) 'Se llama al metodo eliminar del repositorio
            If exito Then
                lblMensaje.Text = "Usuario eliminado exitosamente."
                CargarUsuarios()
            Else
                lblMensaje.Text = "Error al eliminar el usuario"
            End If
        Catch ex As Exception
            lblMensaje.Text = "Ocurrio un error al eliminar el usuario: " & ex.Message 'Mensaje por si hay errores
        End Try
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs)
        Response.Redirect("AdminPanel.aspx")
    End Sub
End Class