Public Class ReservarCita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim doctorIdStr As String = Request.QueryString("doctorId")
            If String.IsNullOrEmpty(doctorIdStr) Then
                Response.Redirect("DoctoresPublico.aspx")
            End If

            Dim doctorId As Integer = Convert.ToInt32(doctorIdStr)
            hfDoctorID.Value = doctorId.ToString()
            CargarDatosDoctor(doctorId)
        End If
    End Sub



    Private Sub CargarDatosDoctor(doctorId As Integer)
        Dim repo As New DoctorRepository()
        Dim dt As DataTable = repo.ReadDoctorById(doctorId)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row = dt.Rows(0)
            imgDoctor.ImageUrl = ResolveUrl(row("Foto").ToString())
            lblNombreDoctor.InnerText = row("Nombre").ToString()
            lblEspecialidadDoctor.InnerText = "Especialidad: " & row("Especialidad").ToString()
        End If
    End Sub



    Protected Sub txtFechaCita_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtFechaCita.Text) Then Return

        ddlHorasCita.Items.Clear()
        Dim doctorId As Integer = Convert.ToInt32(hfDoctorID.Value)
        Dim fecha As Date = Convert.ToDateTime(txtFechaCita.Text)

        Dim repo As New CitaRepository()
        Dim horasOcupadas As List(Of String) = repo.GetHorasOcupadas(doctorId, fecha)

        Dim horasDisponibles As String() = {"08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "15:00"}
        For Each h In horasDisponibles
            If Not horasOcupadas.Contains(h) Then
                ddlHorasCita.Items.Add(h)
            End If
        Next
    End Sub



    Protected Sub btnConfirmarCita_Click(sender As Object, e As EventArgs)
        Try

            If String.IsNullOrWhiteSpace(txtFechaCita.Text) OrElse ddlHorasCita.SelectedIndex = -1 Then
                lblMensajeCita.Text = "Seleccione fecha y hora."
                Return
            End If


            Dim pacienteId As Object = Session("PacienteID")
            If pacienteId Is Nothing OrElse Convert.ToInt32(pacienteId) = 0 Then
                lblMensajeCita.Text = "Debes iniciar sesión como paciente para reservar una cita."
                Return
            End If

            Dim cita As New Cita() With {
                .PacienteID = Convert.ToInt32(Session("PacienteID")),
                .DoctorID = Convert.ToInt32(hfDoctorID.Value),
                .Fecha = Convert.ToDateTime(txtFechaCita.Text),
                .Hora = ddlHorasCita.SelectedValue
            }

            Dim repo As New CitaRepository()

            If repo.Insertar(cita) Then
                lblMensajeCita.Text = "Cita reservada correctamente."


                Try
                    ddlHorasCita.Items.Clear()
                    Dim doctorId As Integer = Convert.ToInt32(hfDoctorID.Value)
                    Dim fecha As Date = Convert.ToDateTime(txtFechaCita.Text)

                    Dim horasOcupadas As List(Of String) = repo.GetHorasOcupadas(doctorId, fecha)
                    Dim horasDisponibles As String() = {"08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00"}

                    For Each h In horasDisponibles
                        If Not horasOcupadas.Contains(h) Then
                            ddlHorasCita.Items.Add(h)
                        End If
                    Next
                Catch ex As Exception
                    lblMensajeCita.Text &= " (No se pudieron actualizar las horas: " & ex.Message & ")"
                End Try


                txtFechaCita.Text = ""
            Else
                lblMensajeCita.Text = "Error al reservar la cita."
            End If

        Catch ex As Exception
            lblMensajeCita.Text = "Ocurrió un error: " & ex.Message
        End Try
    End Sub

End Class