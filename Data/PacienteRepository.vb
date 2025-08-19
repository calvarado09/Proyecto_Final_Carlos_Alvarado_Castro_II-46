Imports System.Data.SqlClient

Public Class PacienteRepository

    ' Método para insertar un paciente en la base de datos
    Public Function Insertar(paciente As Paciente) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "INSERT INTO Pacientes (Nombre, Apellido1, Apellido2, Cedula, FechaNacimiento, Genero, Telefono, Email) 
                               VALUES (@Nombre, @Apellido1, @Apellido2, @Cedula, @FechaNacimiento, @Genero, @Telefono, @Email)"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", paciente.Nombre),
            New SqlParameter("@Apellido1", paciente.Apellido1),
            New SqlParameter("@Apellido2", paciente.Apellido2),
            New SqlParameter("@Cedula", paciente.Cedula),
            New SqlParameter("@FechaNacimiento", paciente.FechaNacimiento),
            New SqlParameter("@Genero", paciente.Genero),
            New SqlParameter("@Telefono", paciente.Telefono),
            New SqlParameter("@Email", paciente.Email)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Método para actualizar paciente
    Public Function Actualizar(paciente As Paciente) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "UPDATE Pacientes 
                               SET Nombre = @Nombre, Apellido1 = @Apellido1, Apellido2 = @Apellido2, Cedula = @Cedula,
                                   FechaNacimiento = @FechaNacimiento, Genero = @Genero, Telefono = @Telefono, Email = @Email
                               WHERE PacienteID = @PacienteID"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", paciente.Nombre),
            New SqlParameter("@Apellido1", paciente.Apellido1),
            New SqlParameter("@Apellido2", paciente.Apellido2),
            New SqlParameter("@Cedula", paciente.Cedula),
            New SqlParameter("@FechaNacimiento", paciente.FechaNacimiento),
            New SqlParameter("@Genero", paciente.Genero),
            New SqlParameter("@Telefono", paciente.Telefono),
            New SqlParameter("@Email", paciente.Email),
            New SqlParameter("@PacienteID", paciente.PacienteID)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Método para eliminar un paciente por ID
    Public Function Eliminar(pacienteId As Integer) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "DELETE FROM Pacientes WHERE PacienteID = @PacienteID"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@PacienteID", pacienteId)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Método para listar todos los pacientes
    Public Function ReadPacientes() As DataTable
        Dim db As New DatabaseHelper()
        Try
            Dim query As String = "SELECT * FROM Pacientes"
            Dim dt As DataTable = db.ExecuteQuery(query)
            dt.TableName = "Pacientes"
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class

