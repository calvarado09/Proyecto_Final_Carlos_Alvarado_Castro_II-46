Public Class DoctorPanel
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDatosDoctor()
            CargarCitas()
        End If
    End Sub
    Private Sub CargarDatosDoctor()
        Dim doctorIdObj = Session("DoctorID")
        If doctorIdObj Is Nothing Then
            Response.Redirect("Login.aspx")
        End If

        Dim doctorId As Integer = Convert.ToInt32(doctorIdObj)
        Dim repo As New DoctorRepository()
        Dim dt As DataTable = repo.ReadDoctorById(doctorId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row = dt.Rows(0)
            lblNombre.Text = row("Nombre").ToString() & " " & row("Apellido1").ToString() & " " & row("Apellido2").ToString()
            lblEspecialidad.Text = row("Especialidad").ToString()
            lblEmail.Text = row("Email").ToString()
            lblTelefono.Text = row("Telefono").ToString()
            imgDoctor.ImageUrl = ResolveUrl(row("Foto").ToString())
        End If
    End Sub

    Private Sub CargarCitas()
        Dim doctorIdObj = Session("DoctorID")
        If doctorIdObj Is Nothing Then Return

        Dim doctorId As Integer = Convert.ToInt32(doctorIdObj)
        Dim repo As New CitaRepository()
        Dim dt As DataTable = repo.ObtenerCitasPorDoctor(doctorId)

        gvCitas.DataSource = dt
        gvCitas.DataBind()
    End Sub
End Class