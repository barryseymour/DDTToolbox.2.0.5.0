Public Class clsUserSettings
    Private DefaultConnectionType_value As Integer
    Private DefaultConnectionName_value As String
    Private MainWindowAutoCenter_value As Boolean
    Private CurrentServer_value As String

    Public Property DefaultConnectionType() As Integer
        Get
            Return DefaultConnectionType_value
        End Get
        Set(ByVal value As Integer)
            DefaultConnectionType_value = value
        End Set
    End Property

    Public Property DefaultConnectionName() As String
        Get
            Return DefaultConnectionName_value
        End Get
        Set(ByVal value As String)
            DefaultConnectionName_value = value
        End Set
    End Property

    Public Property MainWindowAutoCenter() As Boolean
        Get
            Return MainWindowAutoCenter_value
        End Get
        Set(ByVal value As Boolean)
            MainWindowAutoCenter_value = value
        End Set
    End Property

    Public Property CurrentServer() As String
        Get
            Return CurrentServer_value
        End Get
        Set(ByVal Value As String)
            CurrentServer_value = Value
        End Set
    End Property

End Class

