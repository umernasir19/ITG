'**************************************************************************************
'*      Class Name         :    UDException.vb
'*      Class Description  :    Manages the User defined Exceptions for entire Application
'*      Core Table         :    N/A
'**************************************************************************************

Public Class UDException
    Inherits ApplicationException

    ' Constants & Data Members
    Dim strNEW_LINE_CHR As String = vbCrLf
    Private m_colUDExceptions As Collections.ArrayList

    '*******************************************************
    '                   Memory Variables
    '*******************************************************

    Private m_strExceptionType As String
    Private m_strDescription As String
    Private m_strAssemblyName As String
    Private m_strClassName As String
    Private m_strMethodName As String
    Private m_strLineNo As String

    'Private m_nErrorId As Integer
    'Private m_strTitle As String
    'Private m_strFieldName As String
    'Private m_strClassName As String
    'Private m_strProvidedValue As String
    'Private m_CreatedDateTime As DateTime = DateTime.Now

    '*******************************************************
    '                   Properties
    '*******************************************************


    'Exception Type
    Public Property ExceptionType() As String
        Get
            ExceptionType = m_strExceptionType
        End Get

        Set(ByVal Value As String)
            m_strExceptionType = Value
        End Set
    End Property

    'Exception Description
    Public Property Description() As String
        Get
            Description = m_strDescription
        End Get

        Set(ByVal Value As String)
            m_strDescription = Value
        End Set
    End Property

    'Assembly Name
    Public Property AssemblyName() As String
        Get
            Return m_strAssemblyName
        End Get
        Set(ByVal Value As String)
            m_strAssemblyName = Value
        End Set
    End Property

    'Class Name
    Public Property ClassName() As String
        Get
            Return m_strClassName
        End Get
        Set(ByVal Value As String)
            m_strClassName = Value
        End Set
    End Property

    'Method Name
    Public Property MethodName() As String
        Get
            Return m_strMethodName
        End Get
        Set(ByVal Value As String)
            m_strMethodName = Value
        End Set
    End Property

    'Line Number
    Public Property LineNumber() As String
        Get
            LineNumber = m_strLineNo
        End Get

        Set(ByVal Value As String)
            m_strLineNo = Value
        End Set
    End Property


    '*******************************************************
    '                   Functions
    '*******************************************************

    Public Sub New()

    End Sub
    ' A class constructor that receives Methodbase and Exception's Objects
    Public Sub New(ByRef objMethodBase As System.Reflection.MethodBase, ByRef objException As Exception) ', ByVal bIsFinal As Boolean)

        If objException.GetType().ToString() = "Hr.UDException" Then
            'If Not bIsFinal Then
            Throw objException
            'Else

            'End If
        Else
            Dim objUDException As New UDException
            Dim objArr(2) As Object
            objArr = objMethodBase.DeclaringType.FullName.Split(".".ToCharArray())
            objUDException.AssemblyName = objArr(0)
            objUDException.ClassName = objArr(1)
            objUDException.MethodName = objMethodBase.Name
            objUDException.Description = objException.Message
            objUDException.ExceptionType = objException.GetType().ToString()
            objUDException.LineNumber = objException.StackTrace.Substring(objException.StackTrace.LastIndexOf(":") + 6).ToString()
            'If Not bIsFinal Then
            Throw objUDException
            'Else

            'End If
        End If
    End Sub

    ' The method returns a string containing all the contents of the Excetion 
    Public Overrides Function ToString() As String

        ' Declare Local variables
        Dim strException As String
        ' Appending error details in string
        strException = strException & "Exception Type : " & Me.ExceptionType & strNEW_LINE_CHR
        strException = strException & "Description : " & Me.Description & strNEW_LINE_CHR
        strException = strException & "Assembly Name : " & Me.AssemblyName & strNEW_LINE_CHR
        strException = strException & "Class Name: " & Me.ClassName & strNEW_LINE_CHR
        strException = strException & "Method Name: " & Me.MethodName & strNEW_LINE_CHR
        strException = strException & "Line No.: " & Me.LineNumber & strNEW_LINE_CHR

        Return strException
    End Function

End Class
