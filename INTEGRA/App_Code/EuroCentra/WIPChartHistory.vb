Imports System.Data
Imports Microsoft.VisualBasic


Public Class WIPChartHistory
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "WIPChartHistory"
        m_strPrimaryFieldName = "WIPChartHistoryId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lWIPChartHistoryId As Long
    Private m_lWIPChartId As Long
    Private m_lWIPProcessID As Long
    Private m_dtCreationDate As Date
    Private m_strStatus As String
    ''---------------- Properties
    Public Property WIPChartHistoryId() As Long
        Get
            WIPChartHistoryId = m_lWIPChartHistoryId
        End Get
        Set(ByVal value As Long)
            m_lWIPChartHistoryId = value
        End Set
    End Property
    Public Property WIPChartId() As Long
        Get
            WIPChartId = m_lWIPChartId
        End Get
        Set(ByVal value As Long)
            m_lWIPChartId = value
        End Set
    End Property
    Public Property WIPProcessID() As Long
        Get
            WIPProcessID = m_lWIPProcessID
        End Get
        Set(ByVal value As Long)
            m_lWIPProcessID = value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal value As Date)
            m_dtCreationDate = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Status = m_strStatus
        End Get
        Set(ByVal value As String)
            m_strStatus = value
        End Set
    End Property
    Public Function SaveWIPChartHistory()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function

End Class
