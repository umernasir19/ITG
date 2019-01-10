Imports Microsoft.VisualBasic

Public Class myDirection
    Public _fromaddress As String '= ""
    Public _toaddress As String '= ""
    Public _locale As String = "en_US"
    Public Property FromAddress() As String
        Get
            FromAddress = _fromaddress
        End Get
        Set(ByVal value As String)
            _fromaddress = value
        End Set
    End Property
    Public Property toaddress() As String
        Get
            toaddress = _toaddress
        End Get
        Set(ByVal value As String)
            _toaddress = value
        End Set
    End Property
    Public Property locale() As String
        Get
            locale = _locale
        End Get
        Set(ByVal value As String)
            _locale = value
        End Set
    End Property

    Public Function GoogleDirections(ByVal pFromAddress As String, ByVal pToAddress As String)
        FromAddress = pFromAddress
        toaddress = pToAddress
        locale = "en_US"
    End Function
    Public Function GoogleDirections(ByVal pFromAddress As String, ByVal pToAddress As String, ByVal pLocale As String)
        FromAddress = pFromAddress
        toaddress = pToAddress
        locale = pLocale

    End Function
End Class

