Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text
Public Class FormRolesRights

    Inherits SQLManager


    '************* Definition of Class Constructor *************

    ' Defining parameter less constructor
    Public Sub New()
        m_strTableName = "RMFormRolesRights"
        m_strPrimaryFieldName = "ID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
    End Sub
    Private m_nRightsID As Integer
    Private m_nID As Integer
    Private m_strAddStatus As String
    Private m_strViewStatus As String
    Private m_strDeleteStatus As String
    Private m_nUserId As Integer
    Public Property UserId() As Integer
        Get
            UserId = m_nUserId
        End Get
        Set(ByVal Value As Integer)
            m_nUserId = Value
        End Set
    End Property
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
    Public Property RightsID() As Integer
        Get
            RightsID = m_nRightsID
        End Get
        Set(ByVal Value As Integer)
            m_nRightsID = Value
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
    Public Function Save(Optional ByVal nFormRoleId As Integer = 0)

        Try
            MyBase.Save()
        Catch ex As Exception
            Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        End Try
    End Function
End Class
