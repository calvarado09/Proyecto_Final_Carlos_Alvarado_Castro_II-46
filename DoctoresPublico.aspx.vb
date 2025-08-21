Public Class DoctoresPublico
    Inherits System.Web.UI.Page

    Private Sub CargarDoctores()
        Dim repo As New DoctorRepository()
        Dim dt As DataTable = repo.ReadDoctores()
        rptDoctores.DataSource = dt
        rptDoctores.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDoctores()
        End If
    End Sub




End Class