Public Class Doctor
    Private _DoctorID As Integer
    Private _Nombre As String
    Private _Apellido1 As String
    Private _Apellido2 As String
    Private _Especialidad As String
    Private _Telefono As String
    Private _Email As String
    Private _CodigoColegiado As String

    Public Property DoctorID As Integer
        Get
            Return _DoctorID
        End Get
        Set(value As Integer)
            _DoctorID = value
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

    Public Property Especialidad As String
        Get
            Return _Especialidad
        End Get
        Set(value As String)
            _Especialidad = value
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

    Public Property CodigoColegiado As String
        Get
            Return _CodigoColegiado
        End Get
        Set(value As String)
            _CodigoColegiado = value
        End Set
    End Property
End Class

