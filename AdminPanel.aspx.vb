Public Class AdminPanel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Rol") Is Nothing OrElse Session("Rol").ToString() <> "Administrador" Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

End Class