Public Class Paciente
    Inherits Persona


    Private _PacienteID As Integer
    Private _FechaNacimiento As DateTime
    Private _Genero As String

    Public Property PacienteID As Integer
        Get
            Return _PacienteID
        End Get
        Set(value As Integer)
            _PacienteID = value
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


    Public Sub New()
        MyBase.New() 'Llamada al constructor de la clase base Persona
        FechaNacimiento = DateTime.MinValue
        Genero = String.Empty
        PacienteID = 0
    End Sub

End Class

