Public Class Doctor
    Inherits Persona
    Private _DoctorID As Integer
    Private _Especialidad As String
    Private _CodigoColegiado As String

    Public Property DoctorID As Integer
        Get
            Return _DoctorID
        End Get
        Set(value As Integer)
            _DoctorID = value
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

    Public Property Especialidad As String
        Get
            Return _Especialidad
        End Get
        Set(value As String)
            _Especialidad = value
        End Set
    End Property

    Public Sub New()
        MyBase.New() 'Llamada al constructor de la clase base Persona
        Especialidad = String.Empty
        CodigoColegiado = String.Empty
        DoctorID = 0
    End Sub

End Class

