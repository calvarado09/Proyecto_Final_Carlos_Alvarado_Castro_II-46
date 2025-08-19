Public Class RegistrodePacientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarGridView() 'llamada al metodo para cargar el gridview con los pacientes
    End Sub

    Private Sub cargarGridView() 'mtodo para cargar el gridview con los pacientes usando el repositorio
        Dim repo As New PacienteRepository()
        Dim dt As DataTable = repo.ReadPacientes()
        gvPacientes.DataSource = dt
        gvPacientes.DataBind()
    End Sub

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
    End Sub

    Protected Sub gvPacientes_SelectedIndexChanged(sender As Object, e As EventArgs) 'Evento de seleccion en el grid
        Dim index As Integer = gvPacientes.SelectedIndex
        Dim idDelPaciente As Integer = Convert.ToInt32(gvPacientes.SelectedDataKey.Value)
        If index >= 0 Then
            Dim row As GridViewRow = gvPacientes.Rows(index)


            Dim paciente As New Paciente() With {
            .Nombre = row.Cells(2).Text,
            .Apellido1 = row.Cells(3).Text,
            .Apellido2 = row.Cells(4).Text,
            .FechaNacimiento = Convert.ToDateTime(row.Cells(5).Text),
            .Genero = row.Cells(6).Text,
            .Telefono = row.Cells(7).Text,
            .Email = row.Cells(8).Text,
            .Cedula = row.Cells(9).Text
        }


            IdPaciente.Value = idDelPaciente.ToString()

            txtNombre.Text = paciente.Nombre
            txtApellido1.Text = paciente.Apellido1
            txtApellido2.Text = paciente.Apellido2
            txtFechaNacimiento.Text = paciente.FechaNacimiento.ToString("yyyy-MM-dd")
            ddlGenero.SelectedValue = paciente.Genero
            txtTelefono.Text = paciente.Telefono
            txtEmail.Text = paciente.Email
            txtCedula.Text = paciente.Cedula
        End If

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido1.Text) OrElse   'Validar que todos los campos esten llenos
           String.IsNullOrWhiteSpace(txtApellido2.Text) OrElse
           String.IsNullOrWhiteSpace(txtFechaNacimiento.Text) OrElse
           ddlGenero.SelectedIndex = 0 OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtCedula.Text) Then

                lblMensaje.Text = "Todos los campos son obligatorios." 'mensaje si hay alguno vacio
                Return
            End If

            If Not IsNumeric(txtTelefono.Text.Trim()) OrElse
               Not IsNumeric(txtCedula.Text.Trim()) Then  'Validar que el telefono y la cedula sean solo numeros
                lblMensaje.Text = "Ingrese solo numeros en el telefono y la cedula."
                Return
            End If

            'Comvertir la fecha de nacimiento a aateTime y validar que sea correcta
            Dim fechaNacimiento As DateTime
            If Not DateTime.TryParse(txtFechaNacimiento.Text.Trim(), fechaNacimiento) Then
                lblMensaje.Text = "Ingrese una fecha valida."
                Return
            End If

            'Crear objeto paciente
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

            Dim repo As New PacienteRepository() 'Instantiar el repositorio
            If String.IsNullOrWhiteSpace(IdPaciente.Value) Then
                Dim exito As Boolean = repo.Insertar(paciente) 'Inesrtar nuevo paciente
                If exito Then
                    lblMensaje.Text = "Paciente agregado exitosamente."
                    LimpiarFormulario()
                    cargarGridView()
                Else
                    lblMensaje.Text = "Error al agregar el paciente"
                End If
            Else
                paciente.PacienteID = Convert.ToInt32(IdPaciente.Value)
                Dim resultado As Boolean = repo.Actualizar(paciente) 'Actualizar paciente existente con el id
                If resultado Then
                    lblMensaje.Text = "Paciente actualizado correctamente"
                    LimpiarFormulario()
                    cargarGridView()
                    IdPaciente.Value = String.Empty 'limpiar el hiddenfield 
                Else
                    lblMensaje.Text = "Error al actualizar el paciente"
                End If
            End If

        Catch ex As Exception
            lblMensaje.Text = "Ocurrió un error: " & ex.Message 'Mensaje en caso de errores
        End Try
    End Sub


    Protected Sub gvPacientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim repo As New PacienteRepository() 'se istancia el repositorio
            Dim pacienteId As Integer = Convert.ToInt32(gvPacientes.DataKeys(e.RowIndex).Value)

            Dim exito As Boolean = repo.Eliminar(pacienteId) 'Se llama al metodo eliminar del repositorio
            If exito Then
                lblMensaje.Text = "Paciente eliminado exitosamente."
                cargarGridView()
                LimpiarFormulario()
            Else
                lblMensaje.Text = "Error al eliminar el paciente"
            End If
        Catch ex As Exception
            lblMensaje.Text = "Ocurrio un error al eliminar el paciente: " & ex.Message 'Mensaje por si hay errores
        End Try
    End Sub


    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario() 'Llamar al metodo para limpiar el formulario
    End Sub




End Class