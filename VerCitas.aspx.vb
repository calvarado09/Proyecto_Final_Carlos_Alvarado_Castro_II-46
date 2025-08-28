Public Class VerCitas
    Inherits System.Web.UI.Page

    Private Sub CargarCitas()
        Dim repo As New CitaRepository()
        gvCitas.DataSource = repo.ObtenerCitasConDetalles()
        gvCitas.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarCitas()
    End Sub


    Protected Sub gvCitas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim citaID As Integer = Convert.ToInt32(gvCitas.DataKeys(e.RowIndex).Value)
        Try
            Dim repo As New CitaRepository()
            If repo.CancelarCita(citaID) Then
                lblMensaje.Text = "Cita cancelada correctamente."
                CargarCitas() 'Actualizar Grid
            Else
                lblMensaje.Text = "No se pudo cancelar la cita."
            End If
        Catch ex As Exception
            lblMensaje.Text = "Error al cancelar la cita: " & ex.Message
        End Try
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs)
        Response.Redirect("AdminPanel.aspx")
    End Sub
End Class