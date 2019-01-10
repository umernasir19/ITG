Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class GodownIssueDetailForProcess
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSGodownIssueDetailForProcess"
            m_strPrimaryFieldName = "GodownIssueDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lGodownIssueDetailID As Long
        Private m_lGodownIssueID As Long
        Private m_lIMSItemID As Long
        Private m_dbQtyIssue As Decimal
        Private m_dbQtyInHand As Decimal
        Private m_lTransactionMethodID As Long
        Private m_lFromLocationID As Long
        Private m_lToLocationID As Long
        Private m_dbRate As Decimal
        Public Property Rate() As Decimal
            Get
                Rate = m_dbRate
            End Get
            Set(ByVal value As Decimal)
                m_dbRate = value
            End Set
        End Property
        Public Property FromLocationID() As Long
            Get
                FromLocationID = m_lFromLocationID
            End Get
            Set(ByVal Value As Long)
                m_lFromLocationID = Value
            End Set
        End Property
        Public Property ToLocationID() As Long
            Get
                ToLocationID = m_lToLocationID
            End Get
            Set(ByVal Value As Long)
                m_lToLocationID = Value
            End Set
        End Property

        Public Property GodownIssueDetailID() As Long
            Get
                GodownIssueDetailID = m_lGodownIssueDetailID
            End Get
            Set(ByVal Value As Long)
                m_lGodownIssueDetailID = Value
            End Set
        End Property
        Public Property GodownIssueID() As Long
            Get
                GodownIssueID = m_lGodownIssueID
            End Get
            Set(ByVal Value As Long)
                m_lGodownIssueID = Value
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

