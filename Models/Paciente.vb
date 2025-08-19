Public Class Paciente
    Private _PacienteID As Integer
    Private _Nombre As String
    Private _Apellido1 As String
    Private _Apellido2 As String
    Private _FechaNacimiento As DateTime
    Private _Genero As String
    Private _Telefono As String
    Private _Email As String
    Private _Cedula As String

    Public Property PacienteID As Integer
        Get
            Return _PacienteID
        End Get
        Set(value As Integer)
            _PacienteID = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property Apellido1 As String
        Get
            Return _Apellido1
        End Get
        Set(value As String)
            _Apellido1 = value
        End Set
    End Property

    Public Property Apellido2 As String
        Get
            Return _Apellido2
        End Get
        Set(value As String)
            _Apellido2 = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            _FechaNacimiento = value
        End Set
    End Property

    Public Property Genero As String
        Get
            Return _Genero
        End Get
        Set(value As String)
            _Genero = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _Telefono
        End Get
        Set(value As String)
            _Telefono = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property

    Public Property Cedula As String
        Get
            Return _Cedula
        End Get
        Set(value As String)
            _Cedula = value
        End Set
    End Property
End Class

