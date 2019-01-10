Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text
Public Class FormRolesNew
    Inherits SQLManager


    '************* Definition of Class Constructor *************

    ' Defining parameter less constructor
    Public Sub New()
        m_strTableName = "RMFormRolesNew"
        m_strPrimaryFieldName = "ID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
    End Sub
    Private m_nFormRoleId As Integer
    Private m_strTextToDisplay As String = ""
    Private m_sSequence As Short
    Private m_bIsActive As Boolean
    Private m_nParentFormRoleId As Integer
    Private m_nFormId As Integer
    Private m_sRoleId As Short
    Private m_nID As Integer
    Private m_strAddStatus As String
    Private m_strViewStatus As String
    Private m_strDeleteStatus As String
    Public Property AddStatus() As String
        Get
            AddStatus = m_strAddStatus
        End Get
        Set(ByVal Value As String)
            m_strAddStatus = Value
        End Set
    End Property
    Public Property ViewStatus() As String
        Get
            ViewStatus = m_strViewStatus
        End Get
        Set(ByVal Value As String)
            m_strViewStatus = Value
        End Set
    End Property
    Public Property DeleteStatus() As String
        Get
            DeleteStatus = m_strDeleteStatus
        End Get
        Set(ByVal Value As String)
            m_strDeleteStatus = Value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            ID = m_nID
        End Get
        Set(ByVal Value As Integer)
            m_nID = Value
        End Set
    End Property

    Public Property FormRoleId() As Integer
        Get
            FormRoleId = m_nFormRoleId
        End Get
        Set(ByVal Value As Integer)
            m_nFormRoleId = Value
        End Set
    End Property

    Public Property TextToDisplay() As String
        Get
            TextToDisplay = m_strTextToDisplay
        End Get
        Set(ByVal Value As String)
            m_strTextToDisplay = Value
        End Set
    End Property

    Public Property Sequence() As Short
        Get
            Sequence = m_sSequence
        End Get
        Set(ByVal Value As Short)
            m_sSequence = Value
        End Set
    End Property

    Public Property IsActive() As Boolean
        Get
            IsActive = m_bIsActive
        End Get
        Set(ByVal Value As Boolean)
            m_bIsActive = Value
        End Set
    End Property

    Public Property ParentFormRoleId() As Integer
        Get
            ParentFormRoleId = m_nParentFormRoleId
        End Get
        Set(ByVal Value As Integer)
            m_nParentFormRoleId = Value
        End Set
    End Property
    Public Property FormId() As Integer
        Get
            FormId = m_nFormId
        End Get
        Set(ByVal Value As Integer)
            m_nFormId = Value
        End Set
    End Property
    Public Property RoleId() As Short
        Get
            RoleId = m_sRoleId
        End Get
        Set(ByVal Value As Short)
            m_sRoleId = Value
        End Set
    End Property
    Public Function Save(Optional ByVal nFormRoleId As Integer = 0)

        Try
            MyBase.Save()
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Function
    Function UpdateAddStatus(ByVal ID As Long)
        Dim Str As String
        Str = " update  RMFormRolesNew set AddStatus=1  where ID=" & ID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function DisUpdateAddStatus(ByVal ID As Long)
        Dim Str As String
        Str = " update  RMFormRolesNew set AddStatus=0  where ID=" & ID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function UpdateViewStatus(ByVal ID As Long)
        Dim Str As String
        Str = " update  RMFormRolesNew set ViewStatus=1  where ID=" & ID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function DisUpdateViewStatus(ByVal ID As Long)
        Dim Str As String
        Str = " update  RMFormRolesNew set ViewStatus=0  where ID=" & ID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function UpdateDeleteStatus(ByVal ID As Long)
        Dim Str As String
        Str = " update  RMFormRolesNew set DeleteStatus=1  where ID=" & ID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function DisUpdateDeleteStatus(ByVal ID As Long)
        Dim Str As String
        Str = " update  RMFormRolesNew set DeleteStatus=0  where ID=" & ID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
End Class
