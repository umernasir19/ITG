Imports Microsoft.VisualBasic
Imports System.Data
Public Class CuttingRevisedDate
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "CuttingprogramRevisedDateHistory"
        m_strPrimaryFieldName = "CuttingprogramRevisedDateHistoryID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lCuttingprogramRevisedDateHistoryID As Long
    Private m_lCuttingProMasterID As Long
    Private m_dtRevisedDate As Date
    Private m_lUserID As Long
    Public Property CuttingprogramRevisedDateHistoryID() As Long
        Get
            CuttingprogramRevisedDateHistoryID = m_lCuttingprogramRevisedDateHistoryID
        End Get
        Set(ByVal Value As Long)
            m_lCuttingprogramRevisedDateHistoryID = Value
        End Set
    End Property
    Public Property CuttingProMasterID() As Long
        Get
            CuttingProMasterID = m_lCuttingProMasterID
        End Get
        Set(ByVal Value As Long)
            m_lCuttingProMasterID = Value
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

