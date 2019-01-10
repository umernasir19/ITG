Imports Microsoft.VisualBasic
Imports System.Data
Public Class PanalMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PanalMst"
        m_strPrimaryFieldName = "PanalMstid"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPanalMstid As Long
    Private m_lUserId As Long
    Private m_lSeasonDatabaseID As Long
    Private m_dCreationDate As Date
    Public Property PanalMstid() As Long
        Get
            PanalMstid = m_lPanalMstid
        End Get
        Set(ByVal Value As Long)
            m_lPanalMstid = Value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal Value As Long)
            m_lUserId = Value
        End Set
    End Property
    Public Property SeasonDatabaseID() As Long
        Get
            SeasonDatabaseID = m_lSeasonDatabaseID
        End Get
        Set(ByVal Value As Long)
            m_lSeasonDatabaseID = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dCreationDate
        End Get
        Set(ByVal value As Date)
            m_dCreationDate = value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function GetJobId(ByVal SRNO As String) As DataTable
        Dim str As String
        str = " Select * from Joborderdatabase where SRNO ='" & SRNO & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class

