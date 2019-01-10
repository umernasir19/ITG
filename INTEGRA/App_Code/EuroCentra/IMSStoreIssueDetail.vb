Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSStoreIssueDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSStoreIssueDetail"
            m_strPrimaryFieldName = "StoreIssueDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lStoreIssueDetailID As Long
        Private m_lStoreIssueID As Long
        Private m_lIMSItemID As Long
        Private m_lDeptDatabaseId As Long
        Private m_dbQtyIssue As Decimal
        Private m_dbQtyInHand As Decimal
        Private m_dbAVGRATE As Decimal
        Private m_dbAmount As Decimal
        Private m_lTransactionMethodID As Long
       
        Public Property StoreIssueDetailID() As Long
            Get
                StoreIssueDetailID = m_lStoreIssueDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStoreIssueDetailID = Value
            End Set
        End Property
        Public Property StoreIssueID() As Long
            Get
                StoreIssueID = m_lStoreIssueID
            End Get
            Set(ByVal Value As Long)
                m_lStoreIssueID = Value
            End Set
        End Property
        Public Property IMSItemID() As Long
            Get
                IMSItemID = m_lIMSItemID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemID = Value
            End Set
        End Property
        Public Property DeptDatabaseId() As Long
            Get
                DeptDatabaseId = m_lDeptDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lDeptDatabaseId = Value
            End Set
        End Property
        Public Property QtyIssue() As Decimal
            Get
                QtyIssue = m_dbQtyIssue
            End Get
            Set(ByVal value As Decimal)
                m_dbQtyIssue = value
            End Set
        End Property
        Public Property QtyInHand() As Decimal
            Get
                QtyInHand = m_dbQtyInHand
            End Get
            Set(ByVal value As Decimal)
                m_dbQtyInHand = value
            End Set
        End Property
        Public Property AVGRATE() As Decimal
            Get
                AVGRATE = m_dbAVGRATE
            End Get
            Set(ByVal value As Decimal)
                m_dbAVGRATE = value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dbAmount
            End Get
            Set(ByVal value As Decimal)
                m_dbAmount = value
            End Set
        End Property
        Public Property TransactionMethodID() As Long
            Get
                TransactionMethodID = m_lTransactionMethodID
            End Get
            Set(ByVal Value As Long)
                m_lTransactionMethodID = Value
            End Set
        End Property
        Public Function SaveIMSStoreIssueDetail()
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
End Namespace