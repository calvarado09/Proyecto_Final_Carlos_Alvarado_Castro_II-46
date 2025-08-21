Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Try
            Dim usuarioRepo As New UsuarioRepository()
            Dim usuario As Usuario = usuarioRepo.ValidarLogin(txtUsuario.Text.Trim(), txtPassword.Text.Trim())

            If usuario IsNot Nothing Then
                ' Guardar datos en Session
                Session("UsuarioID") = usuario.UsuarioID
                Session("Rol") = usuario.Rol
                Session("PacienteID") = usuario.PacienteID

                ' Redireccionar según rol
                If usuario.Rol = "Admin" Then
                    Response.Redirect("AdminPanel.aspx")
                Else
                    Response.Redirect("DoctoresPublico.aspx")
                End If
            Else
                lblMensaje.Text = "Usuario o contraseña incorrectos."
            End If

        Catch ex As Exception
            lblMensaje.Text = "Ocurrió un error: " & ex.Message
        End Try
    End Sub



End Class