Public Class RegistrodeDoctores
    Inherits System.Web.UI.Page

    Private Sub cargarGridView() 'mtodo para cargar el gridview con los pacientes usando el repositorio
        Dim repo As New DoctorRepository()
        Dim dt As DataTable = repo.ReadDoctores()
        gvDoctores.DataSource = dt
        gvDoctores.DataBind()
    End Sub

    Private Sub LimpiarFormulario() 'Metodo para vaciar los campos del formulario
        txtNombre.Text = String.Empty
        txtApellido1.Text = String.Empty
        txtApellido2.Text = String.Empty
        txtCedula.Text = String.Empty
        txtEspecialidad.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtEmail.Text = String.Empty
        txtCodigo.Text = String.Empty
        IdDoctor.Value = String.Empty
        lblMensaje.Text = String.Empty
        txtUsuario.Text = String.Empty
        txtPassword.Text = String.Empty
        imgDoctor.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarGridView() 'llamada al metodo para cargar el gridview con los pacientes
    End Sub



    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        LimpiarFormulario() 'Llama al metodo para limpiar el formulario
    End Sub

    Protected Sub gvDoctores_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim index As Integer = gvDoctores.SelectedIndex
        If index >= 0 Then
            Dim row As GridViewRow = gvDoctores.Rows(index)

            ' Leer los campos de texto como antes
            txtNombre.Text = row.Cells(2).Text
            txtApellido1.Text = row.Cells(3).Text
            txtApellido2.Text = row.Cells(4).Text
            txtEspecialidad.Text = row.Cells(5).Text
            txtCodigo.Text = row.Cells(6).Text
            txtTelefono.Text = row.Cells(7).Text
            txtEmail.Text = row.Cells(8).Text
            txtCedula.Text = row.Cells(9).Text

            ' Leer la foto desde el control Image dentro de la TemplateField
            Dim img As Image = CType(row.FindControl("imgGridFoto"), Image)
            If img IsNot Nothing Then
                imgDoctor.ImageUrl = img.ImageUrl
                imgDoctor.Visible = True
            End If

            ' Guardar el ID en hiddenfield
            IdDoctor.Value = gvDoctores.SelectedDataKey.Value.ToString()
        End If
    End Sub



    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Try

            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido1.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido2.Text) OrElse
           String.IsNullOrWhiteSpace(txtCedula.Text) OrElse
           String.IsNullOrWhiteSpace(txtEspecialidad.Text) OrElse
           String.IsNullOrWhiteSpace(txtCodigo.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
           String.IsNullOrWhiteSpace(txtCodigo.Text) OrElse
                lblMensaje.Text = "Todos los campos son obligatorios." Then
                Return
            End If

            If Not IsNumeric(txtTelefono.Text.Trim()) Then
                lblMensaje.Text = "Ingrese solo números en el teléfono."
                Return
            End If


            Dim doctor As New Doctor() With {
            .Nombre = txtNombre.Text.Trim(),
            .Apellido1 = txtApellido1.Text.Trim(),
            .Apellido2 = txtApellido2.Text.Trim(),
            .Cedula = txtCedula.Text.Trim(),
            .Especialidad = txtEspecialidad.Text.Trim(),
            .CodigoColegiado = txtCodigo.Text.Trim(),
            .Telefono = txtTelefono.Text.Trim(),
            .Email = txtEmail.Text.Trim()
        }


            If fuFoto.HasFile Then
                Dim fileName As String = Guid.NewGuid().ToString() & System.IO.Path.GetExtension(fuFoto.FileName)
                Dim folderPath As String = Server.MapPath("~/FotosDoctores/")
                If Not System.IO.Directory.Exists(folderPath) Then
                    System.IO.Directory.CreateDirectory(folderPath)
                End If
                Dim filePath As String = System.IO.Path.Combine(folderPath, fileName)
                fuFoto.SaveAs(filePath)
                doctor.Foto = "~/FotosDoctores/" & fileName
            Else
                If Not String.IsNullOrWhiteSpace(IdDoctor.Value) Then
                    Dim repo As New DoctorRepository()
                    Dim dt As DataTable = repo.ReadDoctorById(Convert.ToInt32(IdDoctor.Value))
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        doctor.Foto = dt.Rows(0)("Foto").ToString()
                    End If
                End If
            End If

            Dim repoDoctor As New DoctorRepository()
            Dim repoUsuario As New UsuarioRepository()


            If String.IsNullOrWhiteSpace(IdDoctor.Value) Then

                Dim doctorId As Integer = repoDoctor.InsertarRetornarId(doctor)
                If doctorId > 0 Then
                    doctor.DoctorID = doctorId
                    Dim encriptador As New Simple3Des("Clave") ' Clave de encriptasion
                    Dim claveEncriptada As String = encriptador.EncryptData(txtPassword.Text.Trim()) ' Encriptar la contraseña
                    Dim usuario As New Usuario() With {
                    .Usuario = txtUsuario.Text.Trim(),
                    .Contraseña = claveEncriptada,
                    .Rol = "Doctor",
                    .DoctorID = doctorId,
                    .PacienteID = Nothing
                    }
                    Dim exitoUsuario As Boolean = repoUsuario.Insertar(usuario)
                    If exitoUsuario Then
                        lblMensaje.Text = "Doctor y usuario creados exitosamente."
                        LimpiarFormulario()
                        cargarGridView()
                    Else
                        lblMensaje.Text = "Doctor creado, pero hubo un error al crear el usuario."
                    End If
                Else
                    lblMensaje.Text = "Error al agregar el doctor."
                End If

            Else

                doctor.DoctorID = Convert.ToInt32(IdDoctor.Value)
                Dim resultado As Boolean = repoDoctor.Actualizar(doctor)
                If resultado Then
                    lblMensaje.Text = "Doctor actualizado correctamente."
                    LimpiarFormulario()
                    cargarGridView()
                    IdDoctor.Value = String.Empty
                Else
                    lblMensaje.Text = "Error al actualizar el doctor."
                End If
            End If

        Catch ex As Exception
            lblMensaje.Text = "Ocurrió un error: " & ex.Message
        End Try
    End Sub





    Protected Sub gvDoctores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Try
            Dim repo As New DoctorRepository() 'se istancia el repositorio
            Dim repoUsuario As New UsuarioRepository() 'se instancia el repositorio de usuario
            Dim repoCita As New CitaRepository()
            Dim doctorId As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)

            repoCita.EliminarCitasPorDoctor(doctorId)

            repoUsuario.EliminarPorDoctorID(doctorId) 'Elimina el usuario asociado al doctor antes de eliminar el doctor

            Dim exito As Boolean = repo.Eliminar(doctorID) 'Se llama al metodo eliminar del repositorio
            If exito Then
                lblMensaje.Text = "Doctor eliminado exitosamente."
                cargarGridView()
                LimpiarFormulario()
            Else
                lblMensaje.Text = "Error al eliminar el doctor"
            End If
        Catch ex As Exception
            lblMensaje.Text = "Ocurrio un error al eliminar el doctor: " & ex.Message 'Mensaje por si hay errores
        End Try
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs)
        Response.Redirect("AdminPanel.aspx")
    End Sub
End Class