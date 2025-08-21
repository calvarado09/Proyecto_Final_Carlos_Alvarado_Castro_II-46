Public Class Usuario
    Private _UsuarioID As Integer
    Private _Usuario As String
    Private _Contraseña As String
    Private _Rol As String
    Public Property PacienteID As Integer?  '
    Public Property DoctorID As Integer?

    Public Property UsuarioID As Integer
        Get
            Return _UsuarioID
        End Get
        Set(value As Integer)
            _UsuarioID = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Contraseña As String
        Get
            Return _Contraseña
        End Get
        Set(value As String)
            _Contraseña = value
        End Set
    End Property

    Public Property Rol As String
        Get
            Return _Rol
        End Get
        Set(value As String)
            _Rol = value
        End Set
    End Property


End Class
