Imports Microsoft.VisualBasic
Imports System.Data
Public Class TodayCutting
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "TodayCuttingMst"
        m_strPrimaryFieldName = "TodayCuttingMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lTodayCuttingMstID As Long
    Private m_lUserID As Long
    Private m_dtCreationDate As Date
  Public Property TodayCuttingMstID() As Long
        Get
            TodayCuttingMstID = m_lTodayCuttingMstID
        End Get
        Set(ByVal Value As Long)
            m_lTodayCuttingMstID = Value
        End Set
    End Property
    Public Property UserID() As Long
        Get
            UserID = m_lUserID
        End Get
        Set(ByVal Value As Long)
            m_lUserID = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal Value As Date)
            m_dtCreationDate = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
End Class
