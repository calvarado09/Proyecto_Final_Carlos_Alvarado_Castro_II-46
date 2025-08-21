Public Class RegistrodePacientesPublico
    Inherits System.Web.UI.Page



    Private Sub LimpiarFormulario()  'Metodo para vaciar los campos del formulario
        txtNombre.Text = String.Empty
        txtApellido1.Text = String.Empty
        txtApellido2.Text = String.Empty
        txtCedula.Text = String.Empty
        txtFechaNacimiento.Text = String.Empty
        ddlGenero.SelectedIndex = 0
        txtTelefono.Text = String.Empty
        txtEmail.Text = String.Empty
        IdPaciente.Value = String.Empty
        lblMensaje.Text = String.Empty
        txtUsuario.Text = String.Empty
        txtPassword.Text = String.Empty
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try

            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido1.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido2.Text) OrElse
           String.IsNullOrWhiteSpace(txtFechaNacimiento.Text) OrElse
           ddlGenero.SelectedIndex = 0 OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsuario.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtCedula.Text) Then

                lblMensaje.Text = "Todos los campos son obligatorios."
                Return
            End If

            If Not IsNumeric(txtTelefono.Text.Trim()) OrElse Not IsNumeric(txtCedula.Text.Trim()) Then
                lblMensaje.Text = "Ingrese solo números en teléfono y cédula."
                Return
            End If

            Dim fechaNacimiento As DateTime
            If Not DateTime.TryParse(txtFechaNacimiento.Text.Trim(), fechaNacimiento) Then
                lblMensaje.Text = "Ingrese una fecha válida."
                Return
            End If


            Dim paciente As New Paciente() With {
            .Nombre = txtNombre.Text.Trim(),
            .Apellido1 = txtApellido1.Text.Trim(),
            .Apellido2 = txtApellido2.Text.Trim(),
            .Cedula = txtCedula.Text.Trim(),
            .FechaNacimiento = fechaNacimiento,
            .Genero = ddlGenero.SelectedValue,
            .Telefono = txtTelefono.Text.Trim(),
            .Email = txtEmail.Text.Trim()
        }

            Dim repoPac As New PacienteRepository()


            Dim pacienteId As Integer = repoPac.InsertarRetornarId(paciente)

            If pacienteId > 0 Then

                Dim usuario As New Usuario() With {
                .Usuario = txtUsuario.Text.Trim(),
                .Contraseña = txtPassword.Text.Trim(),
                .Rol = "Paciente",
                .PacienteID = pacienteId
            }

                Dim repoUsr As New UsuarioRepository()
                Dim exitoUsuario As Boolean = repoUsr.Insertar(usuario)

                If exitoUsuario Then
                    lblMensaje.Text = "Paciente y usuario registrados correctamente."
                    LimpiarFormulario()
                Else
                    lblMensaje.Text = "Paciente registrado, pero ocurrió un error al crear el usuario."
                End If
            Else
                lblMensaje.Text = "Error al registrar el paciente."
            End If

        Catch ex As Exception
            lblMensaje.Text = "Ocurrió un error: " & ex.Message
        End Try
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario()
    End Sub
End Class