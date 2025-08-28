Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("UsuarioID") IsNot Nothing Then
                phNoLogin.Visible = False
                phLogged.Visible = True

                ' Mostrar el nombre del usuario si lo tienes en sesión
                If Session("NombreUsuario") IsNot Nothing Then
                    lblUsuario.Text = Session("NombreUsuario").ToString()
                Else
                    lblUsuario.Text = "Usuario"
                End If
            Else
                phNoLogin.Visible = True
                phLogged.Visible = False
            End If
        End If
    End Sub

    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub

End Class