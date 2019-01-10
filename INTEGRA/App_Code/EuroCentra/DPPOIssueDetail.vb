Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class DPPOIssueDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPPOIssueDtl"
            m_strPrimaryFieldName = "DPPOIssueDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPPOIssueDtlID As Long
        Private m_lDPPOIssueMstID As Long
        Private m_lDeptDatabaseID As Long
        Private m_lFabricDbMstID As Long
        Private m_dAvailableFabric As Decimal
        Private m_dIssueQty As Decimal
        Private m_strDalNo As String
        Public Property DPPOIssueDtlID() As Long
            Get
                DPPOIssueDtlID = m_lDPPOIssueDtlID
            End Get
            Set(ByVal value As Long)
                m_lDPPOIssueDtlID = value
            End Set
        End Property
        Public Property DPPOIssueMstID() As Long
            Get
                DPPOIssueMstID = m_lDPPOIssueMstID
            End Get
            Set(ByVal value As Long)
                m_lDPPOIssueMstID = value
            End Set
        End Property
        Public Property DeptDatabaseID() As Long
            Get
                DeptDatabaseID = m_lDeptDatabaseID
            End Get
            Set(ByVal value As Long)
                m_lDeptDatabaseID = value
            End Set
        End Property
        Public Property FabricDbMstID() As Long
            Get
                FabricDbMstID = m_lFabricDbMstID
            End Get
            Set(ByVal value As Long)
                m_lFabricDbMstID = value
            End Set
        End Property
        Public Property AvailableFabric() As Decimal
            Get
                AvailableFabric = m_dAvailableFabric
            End Get
            Set(ByVal value As Decimal)
                m_dAvailableFabric = value
            End Set
        End Property
        Public Property IssueQty() As Decimal
            Get
                IssueQty = m_dIssueQty
            End Get
            Set(ByVal value As Decimal)
                m_dIssueQty = value
            End Set
        End Property
        Public Property DalNo() As String
            Get
                DalNo = m_strDalNo
            End Get
            Set(ByVal value As String)
                m_strDalNo = value
            End Set
        End Property
        Public Function SaveDPPOIssueDtl()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        
    End Class
End Namespace

