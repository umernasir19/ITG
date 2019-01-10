Imports Microsoft.VisualBasic
Imports System.Data
Public Class AccRevisedDate
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "AccCheckListRevisedDateHistory"
        m_strPrimaryFieldName = "AccCheckListRevisedDateHistoryID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lAccCheckListRevisedDateHistoryID As Long
    Private m_lAccCheckListMstID As Long
    Private m_dtRevisedDate As Date
    Private m_lUserID As Long
    
    Public Property AccCheckListRevisedDateHistoryID() As Long
        Get
            AccCheckListRevisedDateHistoryID = m_lAccCheckListRevisedDateHistoryID
        End Get
        Set(ByVal Value As Long)
            m_lAccCheckListRevisedDateHistoryID = Value
        End Set
    End Property
    Public Property AccCheckListMstID() As Long
        Get
            AccCheckListMstID = m_lAccCheckListMstID
        End Get
        Set(ByVal Value As Long)
            m_lAccCheckListMstID = Value
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
    Public Property RevisedDate() As Date
        Get
            RevisedDate = m_dtRevisedDate
        End Get
        Set(ByVal Value As Date)
            m_dtRevisedDate = Value
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
End Class
