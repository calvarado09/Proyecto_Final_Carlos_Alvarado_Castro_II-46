Public Class RegistrodeDoctores
    Inherits System.Web.UI.Page

    Private Sub cargarGridView() 'mtodo para cargar el gridview con los pacientes usando el repositorio
        Dim repo As New DoctorRepository()
        Dim dt As DataTable = repo.ReadDoctores()
        gvDoctores.DataSource = dt
        gvDoctores.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarGridView() 'llamada al metodo para cargar el gridview con los pacientes
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub gvDoctores_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub gvDoctores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub
End Class