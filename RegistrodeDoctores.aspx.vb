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
            'Verificar que los campos no esten vacios
            If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido1.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido2.Text) OrElse
           String.IsNullOrWhiteSpace(txtCedula.Text) OrElse
           String.IsNullOrWhiteSpace(txtEspecialidad.Text) OrElse
           String.IsNullOrWhiteSpace(txtCodigo.Text) OrElse
           String.IsNullOrWhiteSpace(txtTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) Then
                lblMensaje.Text = "Todos los campos son obligatorios."
                Return
            End If

            If Not IsNumeric(txtTelefono.Text.Trim()) Then
                lblMensaje.Text = "Ingrese solo números en el teléfono."
                Return
            End If

            'Se hace de un bjet doctor con los datos que haya en el from
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

            If fuFoto.HasFile Then 'Verifica si hay una foto subida
                Dim fileName As String = Guid.NewGuid().ToString() & System.IO.Path.GetExtension(fuFoto.FileName) 'Aqui se hace un GUID y lo pasa a string, el systemIO obtiene la extension del archivo
                Dim folderPath As String = Server.MapPath("~/FotosDoctores/") 'Esto nos sirve para comvertir una ruta virtual en una real del server
                If Not System.IO.Directory.Exists(folderPath) Then 'verifica si ftrosdocores existe  y si no la crea para guardar la imagen
                    System.IO.Directory.CreateDirectory(folderPath)
                End If
                Dim filePath As String = System.IO.Path.Combine(folderPath, fileName) 'pathcombine une la carpeta y el nombre en una ruta completa
                fuFoto.SaveAs(filePath) 'Guarda el arcghico en el servidor


                doctor.Foto = "~/FotosDoctores/" & fileName 'Guarda la ruta relativa para despues insertarla en la base de datos
            Else

                If Not String.IsNullOrWhiteSpace(IdDoctor.Value) Then 'Si es una actualizacion
                    Dim repo As New DoctorRepository() 'Se instancia el repositorio
                    Dim dt As DataTable = repo.ReadDoctorById(Convert.ToInt32(IdDoctor.Value)) 'lee el doctor por el id del hidenfield
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then 'Si el dtatable no esta vacio
                        doctor.Foto = dt.Rows(0)("Foto").ToString() 'Obtiene la foto del doctor y la guarda en el objeto doctor la que ya habia
                    End If
                End If
            End If


            Dim repoDoctor As New DoctorRepository()
            If String.IsNullOrWhiteSpace(IdDoctor.Value) Then
                ' Insertar nuevo doctor
                Dim exito As Boolean = repoDoctor.Insertar(doctor)
                If exito Then
                    lblMensaje.Text = "Doctor agregado exitosamente."
                    LimpiarFormulario()
                    cargarGridView()
                Else
                    lblMensaje.Text = "Error al agregar el doctor."
                End If
            Else
                ' Actualizar doctor existente
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
            Dim doctorId As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)

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
End Class