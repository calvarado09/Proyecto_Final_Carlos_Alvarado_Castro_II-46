Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging

Public Class CitaRepository
    Public Function Insertar(cita As Cita) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "
            INSERT INTO Citas (PacienteID, DoctorID, Fecha, Hora)
            VALUES (@PacienteID, @DoctorID, @Fecha, @Hora)"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@PacienteID", cita.PacienteID),
            New SqlParameter("@DoctorID", cita.DoctorID),
            New SqlParameter("@Fecha", cita.Fecha),
            New SqlParameter("@Hora", cita.Hora)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Actualizar cita existente
    Public Function Actualizar(cita As Cita) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String =
            "
            UPDATE Citas
            SET PacienteID = @PacienteID, DoctorID = @DoctorID, Fecha = @Fecha, Hora = @Hora
            WHERE CitaID = @CitaID"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@PacienteID", cita.PacienteID),
            New SqlParameter("@DoctorID", cita.DoctorID),
            New SqlParameter("@Fecha", cita.Fecha),
            New SqlParameter("@Hora", cita.Hora),
            New SqlParameter("@CitaID", cita.CitaID)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Eliminar cita por ID
    Public Function Eliminar(citaID As Integer) As Boolean
        Dim helper As New DatabaseHelper()
        Dim query As String = "DELETE FROM Citas WHERE CitaID = @CitaID"
        Dim parameters As New List(Of SqlParameter) From {
            New SqlParameter("@CitaID", citaID)
        }
        Return helper.ExecuteNonQuery(query, parameters)
    End Function

    ' Listar todas las citas
    Public Function ReadCitas() As DataTable
        Dim helper As New DatabaseHelper()
        Try
            Dim query As String = "SELECT * FROM Citas"
            Dim dt As DataTable = helper.ExecuteQuery(query)
            dt.TableName = "Citas"
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' Obtener horas ocupadas de un doctor en una fecha espesifica
    Public Function GetHorasOcupadas(doctorId As Integer, fecha As Date) As List(Of String)
        Dim helper As New DatabaseHelper()
        Dim horas As New List(Of String)

        Dim query As String = "SELECT Hora FROM Citas 
                           WHERE DoctorID = @DoctorID 
                             AND CONVERT(date, Fecha) = @Fecha
                             AND Estado IN ('Pendiente','Confirmada')"
        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@DoctorID", doctorId),
            New SqlParameter("@Fecha", fecha.Date)
        }

        Dim dt As DataTable = helper.ExecuteQuery(query, params)
        For Each row As DataRow In dt.Rows
            horas.Add(TimeSpan.Parse(row("Hora").ToString()).ToString("hh\:mm"))
        Next

        Return horas
    End Function


    Public Function ObtenerCitasPorDoctor(doctorId As Integer) As DataTable
        Try
            Dim query As String = "SELECT c.Fecha, c.Hora, p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 AS PacienteNombre " &
                                  "FROM Citas c " &
                                  "INNER JOIN Pacientes p ON c.PacienteID = p.PacienteID " &
                                  "WHERE c.DoctorID = @DoctorID " &
                                  "ORDER BY c.Fecha, c.Hora"

            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@DoctorID", doctorId)
            }

            Dim helper As New DatabaseHelper()
            Return helper.ExecuteQuery(query, parametros)
        Catch ex As Exception
            Throw New Exception("Error al obtener citas por doctor: " & ex.Message)
        End Try
    End Function

    Public Function ObtenerCitasConDetalles() As DataTable
        Dim helper As New DatabaseHelper()
        Dim query As String = "
            SELECT 
                c.CitaID,
                p.Nombre + ' ' + p.Apellido1 + ' ' + p.Apellido2 AS Paciente,
                d.Nombre + ' ' + d.Apellido1 + ' ' + d.Apellido2 AS Doctor,
                c.Fecha,
                c.Hora,
                c.Estado
            FROM Citas c
            INNER JOIN Pacientes p ON c.PacienteID = p.PacienteID
            INNER JOIN Doctores d ON c.DoctorID = d.DoctorID"
        Return helper.ExecuteQuery(query)
    End Function

    Public Function CancelarCita(citaID As Integer) As Boolean
        Try
            Dim helper As New DatabaseHelper()
            Dim query As String = "UPDATE Citas SET Estado = 'Cancelada' WHERE CitaID = @CitaID"
            Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@CitaID", citaID)
        }
            Return helper.ExecuteNonQuery(query, parametros)
        Catch ex As Exception
            Throw New Exception("Error al cancelar la cita: " & ex.Message)
        End Try
    End Function

    ' Elimina todas las citas de un doctor
    Public Function EliminarCitasPorDoctor(doctorId As Integer) As Boolean
        Try
            Dim helper As New DatabaseHelper()
            Dim query As String = "DELETE FROM Citas WHERE DoctorID = @DoctorID"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@DoctorID", doctorId)
            }
            Return helper.ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Throw New Exception("Error al eliminar citas del doctor: " & ex.Message)
        End Try
    End Function

    Public Function EliminarCitasPorPaciente(pacienteId As Integer) As Boolean
        Try
            Dim helper As New DatabaseHelper()
            Dim query As String = "DELETE FROM Citas WHERE PacienteID = @PacienteID"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@PacienteID", pacienteId)
            }
            Return helper.ExecuteNonQuery(query, parameters)
        Catch ex As Exception
            Throw New Exception("Error al eliminar citas del paciente: " & ex.Message)
        End Try
    End Function


End Class
