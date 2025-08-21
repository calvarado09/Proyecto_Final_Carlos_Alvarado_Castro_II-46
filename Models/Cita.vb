Public Class Cita
    Private _CitaID As Integer
    Private _PacienteID As Integer
    Private _DoctorID As Integer
    Private _Fecha As Date
    Private _Hora As String
    Private _Notas As String
    Private _Estado As String

    Public Property CitaID As Integer
        Get
            Return _CitaID
        End Get
        Set(value As Integer)
            _CitaID = value
        End Set
    End Property

    Public Property PacienteID As Integer
        Get
            Return _PacienteID
        End Get
        Set(value As Integer)
            _PacienteID = value
        End Set
    End Property

    Public Property DoctorID As Integer
        Get
            Return _DoctorID
        End Get
        Set(value As Integer)
            _DoctorID = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Hora As String
        Get
            Return _Hora
        End Get
        Set(value As String)
            _Hora = value
        End Set
    End Property

    Public Property Notas As String
        Get
            Return _Notas
        End Get
        Set(value As String)
            _Notas = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property
End Class
