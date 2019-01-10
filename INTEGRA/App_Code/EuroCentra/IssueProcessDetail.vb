Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class IssueProcessDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IssueProcessDetail"
            m_strPrimaryFieldName = "IssueProcessDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lIssueProcessDtlID As Long
        Private m_lIssueProcessID As Long
        Private m_lPOProcessRecvDetailID As Long
        Private m_lItemID As Long
        Private m_lDeptDatabaseID As Long
        Private m_strContractor As String
        Private m_dRecvQty As Decimal
        Private m_dIssueQty As Decimal
        Private m_strRemarks As String

        Private m_strEntryType As String
        Private m_dcIssueReturn As Decimal
        Public Property IssueProcessDtlID() As Long
            Get
                IssueProcessDtlID = m_lIssueProcessDtlID
            End Get
            Set(ByVal Value As Long)
                m_lIssueProcessDtlID = Value
            End Set
        End Property
        Public Property IssueProcessID() As Long
            Get
                IssueProcessID = m_lIssueProcessID
            End Get
            Set(ByVal Value As Long)
                m_lIssueProcessID = Value
            End Set
        End Property
        Public Property POProcessRecvDetailID() As Long
            Get
                POProcessRecvDetailID = m_lPOProcessRecvDetailID
            End Get
            Set(ByVal Value As Long)
                m_lPOProcessRecvDetailID = Value
            End Set
        End Property
        Public Property ItemID() As Long
            Get
                ItemID = m_lItemID
            End Get
            Set(ByVal Value As Long)
                m_lItemID = Value
            End Set
        End Property
        Public Property DeptDatabaseID() As Long
            Get
                DeptDatabaseID = m_lDeptDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lDeptDatabaseID = Value
            End Set
        End Property
        Public Property Contractor() As String
            Get
                Contractor = m_strContractor
            End Get
            Set(ByVal Value As String)
                m_strContractor = Value
            End Set
        End Property
        Public Property RecvQty() As Decimal
            Get
                RecvQty = m_dRecvQty
            End Get
            Set(ByVal Value As Decimal)
                m_dRecvQty = Value
            End Set
        End Property
        Public Property IssueQty() As Decimal
            Get
                IssueQty = m_dIssueQty
            End Get
            Set(ByVal Value As Decimal)
                m_dIssueQty = Value
            End Set

        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Property EntryType() As String
            Get
                EntryType = m_strEntryType
            End Get
            Set(ByVal Value As String)
                m_strEntryType = Value
            End Set
        End Property
        Public Property IssueReturn() As Decimal
            Get
                IssueReturn = m_dcIssueReturn
            End Get
            Set(ByVal Value As Decimal)
                m_dcIssueReturn = Value
            End Set
        End Property
        Public Function saveIssueDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
