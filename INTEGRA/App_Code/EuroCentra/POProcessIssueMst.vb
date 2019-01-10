Imports Microsoft.VisualBasic
Imports System.Data
Public Class POProcessIssueMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "processIssueMst"
        m_strPrimaryFieldName = "processIssueID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lprocessIssueID As Long
    Private m_strPOType As String
    Private m_dCreationDate As Date
    Private m_lProcessOrderMstID As Long

    Private m_BolFabricStatus As Boolean
    Private m_lLocationId As Long
    Private m_strManualChallanNo As String
    
    Public Property ManualChallanNo() As String
        Get
            ManualChallanNo = m_strManualChallanNo
        End Get
        Set(ByVal Value As String)
            m_strManualChallanNo = Value
        End Set
    End Property

    Public Property LocationId() As Long
        Get
            LocationId = m_lLocationId
        End Get
        Set(ByVal Value As Long)
            m_lLocationId = Value
        End Set
    End Property
    Public Property processIssueID() As Long
        Get
            processIssueID = m_lprocessIssueID
        End Get
        Set(ByVal Value As Long)
            m_lprocessIssueID = Value
        End Set
    End Property
    Public Property POType() As String
        Get
            POType = m_strPOType
        End Get
        Set(ByVal Value As String)
            m_strPOType = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dCreationDate
        End Get
        Set(ByVal Value As Date)
            m_dCreationDate = Value
        End Set
    End Property
    Public Property ProcessOrderMstID() As Long
        Get
            ProcessOrderMstID = m_lProcessOrderMstID
        End Get
        Set(ByVal Value As Long)
            m_lProcessOrderMstID = Value
        End Set
    End Property
    
    Public Property FabricStatus() As Boolean
        Get
            FabricStatus = m_BolFabricStatus
        End Get
        Set(ByVal Value As Boolean)
            m_BolFabricStatus = Value
        End Set
    End Property

    Public Function saveIssue()
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
    Public Function GetRate(ByVal POID As Long, ByVal ItemID As Long) As DataTable
        Dim str As String
        str = "  select TOP 1 (POD.Rate+pod.PORate) as Rate from ProcessOrderMst Mst"
        str &= " join ProcessOrderDtl POD on POD.ProcessOrderMstID =Mst.ProcessOrderMstID "
        str &= " WHERE mst.ProcessOrderMstID ='" & POID & "' and POD.ProcessItemNameID ='" & ItemID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
