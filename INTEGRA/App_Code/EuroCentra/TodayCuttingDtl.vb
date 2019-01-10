Imports Microsoft.VisualBasic
Imports System.Data
Public Class TodayCuttingDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "TodayCuttingDtl"
        m_strPrimaryFieldName = "TodayCuttingDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lTodayCuttingDtlID As Long
    Private m_lTodayCuttingMstID As Long
    Private m_lJobOrderId As Long
    Private m_strStyle As String
    Private m_lJobOrderDetailId As Long
    Private m_dtCuttingDate As Date
    Private m_dTodayCut As Decimal
    Private m_dTodayIssue As Decimal
    Private m_lSeasonDatabaseID As Long
    Public Property SeasonDatabaseID() As Long
        Get
            SeasonDatabaseID = m_lSeasonDatabaseID
        End Get
        Set(ByVal Value As Long)
            m_lSeasonDatabaseID = Value
        End Set
    End Property
    Public Property TodayCuttingDtlID() As Long
        Get
            TodayCuttingDtlID = m_lTodayCuttingDtlID
        End Get
        Set(ByVal Value As Long)
            m_lTodayCuttingDtlID = Value
        End Set
    End Property
    Public Property TodayCuttingMstID() As Long
        Get
            TodayCuttingMstID = m_lTodayCuttingMstID
        End Get
        Set(ByVal Value As Long)
            m_lTodayCuttingMstID = Value
        End Set
    End Property
    Public Property CuttingDate() As Date
        Get
            CuttingDate = m_dtCuttingDate
        End Get
        Set(ByVal Value As Date)
            m_dtCuttingDate = Value
        End Set
    End Property
    Public Property JobOrderId() As Long
        Get
            JobOrderId = m_lJobOrderId
        End Get
        Set(ByVal Value As Long)
            m_lJobOrderId = Value
        End Set
    End Property
    Public Property Style() As String
        Get
            Style = m_strStyle
        End Get
        Set(ByVal Value As String)
            m_strStyle = Value
        End Set
    End Property
    Public Property JobOrderDetailId() As Long
        Get
            JobOrderDetailId = m_lJobOrderDetailId
        End Get
        Set(ByVal Value As Long)
            m_lJobOrderDetailId = Value
        End Set
    End Property
    Public Property TodayCut() As Decimal
        Get
            TodayCut = m_dTodayCut
        End Get
        Set(ByVal Value As Decimal)
            m_dTodayCut = Value
        End Set
    End Property
    Public Property TodayIssue() As Decimal
        Get
            TodayIssue = m_dTodayIssue
        End Get
        Set(ByVal Value As Decimal)
            m_dTodayIssue = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetCuttingDetailByID(ByVal DtlID As Long) As DataTable
        Dim Str As String
        Str = " select * from TodayCuttingDtl  where TodayCuttingDtlID='" & DtlID & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function

End Class
