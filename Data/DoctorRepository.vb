Imports System.Data.SqlClient

Public Class DoctorRepository

    ' Insertar un doctor en la base de datos
    Public Function Insertar(doctor As Doctor) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "
        INSERT INTO Doctores (Nombre, Apellido1, Apellido2, Especialidad, Telefono, Email, CodigoColegiado, Cedula, Foto)
        VALUES (@Nombre, @Apellido1, @Apellido2, @Especialidad, @Telefono, @Email, @CodigoColegiado, @Cedula, @Foto)"
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@Nombre", doctor.Nombre),
        New SqlParameter("@Apellido1", doctor.Apellido1),
        New SqlParameter("@Apellido2", doctor.Apellido2),
        New SqlParameter("@Especialidad", doctor.Especialidad),
        New SqlParameter("@Telefono", doctor.Telefono),
        New SqlParameter("@Email", doctor.Email),
        New SqlParameter("@CodigoColegiado", doctor.CodigoColegiado),
        New SqlParameter("@Cedula", doctor.Cedula),
        New SqlParameter("@Foto", If(doctor.Foto, DBNull.Value))
    }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function


    ' Actualizar un doctor existente
    Public Function Actualizar(doctor As Doctor) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "
        UPDATE Doctores
        SET Nombre = @Nombre,
            Apellido1 = @Apellido1,
            Apellido2 = @Apellido2,
            Especialidad = @Especialidad,
            Telefono = @Telefono,
            Email = @Email,
            CodigoColegiado = @CodigoColegiado,
            Cedula = @Cedula,
            Foto = @Foto
        WHERE DoctorID = @DoctorID"
        Dim parameters As New List(Of SqlParameter) From {
        New SqlParameter("@Nombre", doctor.Nombre),
        New SqlParameter("@Apellido1", doctor.Apellido1),
        New SqlParameter("@Apellido2", doctor.Apellido2),
        New SqlParameter("@Especialidad", doctor.Especialidad),
        New SqlParameter("@Telefono", doctor.Telefono),
        New SqlParameter("@Email", doctor.Email),
        New SqlParameter("@CodigoColegiado", doctor.CodigoColegiado),
        New SqlParameter("@Cedula", doctor.Cedula),
        New SqlParameter("@Foto", If(doctor.Foto, DBNull.Value)),
        New SqlParameter("@DoctorID", doctor.DoctorID)
    }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function


    ' Eliminar un doctor por ID
    Public Function Eliminar(doctorID As Integer) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "DELETE FROM Doctores WHERE DoctorID = @DoctorID"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@DoctorID", doctorID)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Listar todos los doctores
    Public Function ReadDoctores() As DataTable
        Dim helper As New DatabaseHelper()
        Try
            Dim query As String = "SELECT * FROM Doctores"
            Dim dt As DataTable = helper.ExecuteQuery(query)
            dt.TableName = "Doctores"
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


End Class


