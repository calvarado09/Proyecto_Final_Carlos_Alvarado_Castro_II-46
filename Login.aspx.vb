Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Try
            Dim encriptador As New Simple3Des("Clave") ' Clave de encriptasion
            Dim claveEncriptada As String = encriptador.EncryptData(txtPassword.Text.Trim()) ' Encriptar la contraseña


            Dim usuarioRepo As New UsuarioRepository()
            Dim usuario As Usuario = usuarioRepo.ValidarLogin(txtUsuario.Text.Trim(), claveEncriptada)

            If usuario IsNot Nothing Then
                'guardar datos en Session
                Session("NombreUsuario") = usuario.Usuario
                Session("UsuarioID") = usuario.UsuarioID
                Session("Rol") = usuario.Rol
                Session("PacienteID") = usuario.PacienteID
                Session("DoctorID") = usuario.DoctorID


                If usuario.Rol = "Administrador" Then
                    Response.Redirect("AdminPanel.aspx")
                ElseIf usuario.Rol = "Paciente" Then
                    Response.Redirect("DoctoresPublico.aspx")
                ElseIf usuario.Rol = "Doctor" Then
                    Response.Redirect("DoctorPanel.aspx")
                Else
                    lblMensaje.Text = "Rol no reconocido."
                End If
            Else
                lblMensaje.Text = "Usuario o contraseña incorrectos."
            End If

        Catch ex As Exception
            lblMensaje.Text = "Ocurrió un error: " & ex.Message
        End Try
    End Sub



End Class