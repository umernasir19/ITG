Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSStoreLedger
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSStoreLedger"
            m_strPrimaryFieldName = "StoreLedgerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lStoreLedgerID As Long
        Private m_dtCreationDate As Date
        Private m_dtTransactionDate As Date
        Private m_lIMSItemID As Long
        Dim m_strTransactionType As String
        Private m_dbOpenQty As Decimal
        Private m_dbOpenAmount As Decimal
        Private m_dbReceiveQty As Decimal
        Private m_dbReceiveAmount As Decimal
        Private m_dbIssueQty As Decimal
        Private m_dbIssueAmount As Decimal
        Private m_dbCloseQty As Decimal
        Private m_dbCloseAmount As Decimal
        Private m_lLocationID As Long
        Public Property LocationID() As Long
            Get
                LocationID = m_lLocationID
            End Get
            Set(ByVal Value As Long)
                m_lLocationID = Value
            End Set
        End Property
        Public Property StoreLedgerID() As Long
            Get
                StoreLedgerID = m_lStoreLedgerID
            End Get
            Set(ByVal Value As Long)
                m_lStoreLedgerID = Value
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
        Public Property TransactionDate() As Date
            Get
                TransactionDate = m_dtTransactionDate
            End Get
            Set(ByVal Value As Date)
                m_dtTransactionDate = Value
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
        Public Property TransactionType() As String
            Get
                TransactionType = m_strTransactionType
            End Get
            Set(ByVal Value As String)
                m_strTransactionType = Value
            End Set
        End Property
        Public Property OpenQty() As Decimal
            Get
                OpenQty = m_dbOpenQty
            End Get
            Set(ByVal value As Decimal)
                m_dbOpenQty = value
            End Set
        End Property
        Public Property OpenAmount() As Decimal
            Get
                OpenAmount = m_dbOpenAmount
            End Get
            Set(ByVal value As Decimal)
                m_dbOpenAmount = value
            End Set
        End Property
        Public Property ReceiveQty() As Decimal
            Get
                ReceiveQty = m_dbReceiveQty
            End Get
            Set(ByVal value As Decimal)
                m_dbReceiveQty = value
            End Set
        End Property
        Public Property ReceiveAmount() As Decimal
            Get
                ReceiveAmount = m_dbReceiveAmount
            End Get
            Set(ByVal value As Decimal)
                m_dbReceiveAmount = value
            End Set
        End Property
        Public Property IssueQty() As Decimal
            Get
                IssueQty = m_dbIssueQty
            End Get
            Set(ByVal value As Decimal)
                m_dbIssueQty = value
            End Set
        End Property
        Public Property IssueAmount() As Decimal
            Get
                IssueAmount = m_dbIssueAmount
            End Get
            Set(ByVal value As Decimal)
                m_dbIssueAmount = value
            End Set
        End Property
        Public Property CloseQty() As Decimal
            Get
                CloseQty = m_dbCloseQty
            End Get
            Set(ByVal value As Decimal)
                m_dbCloseQty = value
            End Set
        End Property
        Public Property CloseAmount() As Decimal
            Get
                CloseAmount = m_dbCloseAmount
            End Get
            Set(ByVal value As Decimal)
                m_dbCloseAmount = value
            End Set
        End Property
        Public Function SaveIMSStoreLedger()
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
        Public Function GetBindItemFromReturn(ByVal POID As Long)
            Dim str As String
            str = " select DISTINCT IM.IMSItemID,IM.ItemCodee  from PODetail Dtl"
            str &= " join IMSItem IM on IM.IMSItemID =DTL.ItemId "
            str &= "    where POID = " & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindGatePassNo(ByVal POID As Long)
            Dim str As String
            str = " select * from PORecvMaster"
            str &= "    where POID = " & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindCustomerFROMfABRIC()
            Dim str As String
            str = " select distinct C.CustomerId,C.CustomerNAme from Customer C"
            str &= "   JOIN JobOrderdatabase JO ON JO.CustomerDatabaseID =C.CustomerID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPONOFromReturn(ByVal POID As Long)
            Dim str As String
            str = " Select * from POMaster where POID=" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStoreLedgerID(ByVal IMSItemID As Long)
            Dim str As String
            str = " Select StoreLedgerID from IMSStoreLedger where TransactionType='Open' and IMSItemID=" & IMSItemID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCloseQty(ByVal IMSItemID As Long)
            Dim str As String
            str = " Select Top 1 isnull(CloseQty,0) as CloseQty from IMSStoreLedger where  IMSItemID=" & IMSItemID
            str &= " order by StoreLedgerID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreayReturnQty(ByVal PORecvMasterID As Long, ByVal POID As Long) As DataTable
            Dim str As String

            str = "  select PD.PoDetailId,ItemCodee,CONVERT(VARCHAR,PD.DeliveryDate,103) AS DeliveryDatee,pd.Quantity as POQty"
            str &= " ,(case when isnull(PR.DCNO,'') ='' then '' else DCNO end ) as DCNO"
            str &= " ,(case when isnull(PR.ReturnRemarks,'') ='' then '' else ReturnRemarks end ) as Remarks"
            str &= " ,isnull(PR.ReturnQty,0) as PreReturnQty"
            str &= " ,PD.Quantity -ISNULL(pr.ReturnQty,0) as BalanceQty"
            str &= " ,isnull(pr.POReturnId ,0) as POReturnId"
            str &= "  from PORecvMaster mst"
            str &= " join PORecvDetail PRD on PRD.PORecvMasterID =MST.PORecvMasterID "
            str &= " JOIN PODetail PD on PD.PoDetailId =PRD.PODetailID"
            str &= " JOIN IMSItem IM on IM.IMSItemID=PD.ItemId"
            str &= " left join POReturn PR on PR.PoDetailId=PD.PoDetailId"
            str &= "  where  MST.POID='" & POID & "' and MST.PORecvMasterID='" & PORecvMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCloseQtyWithLocation(ByVal IMSItemID As Long, ByVal LocationID As Long) As DataTable
            Dim str As String
            str = " Select Top 1 isnull(CloseQty,0) as CloseQty from IMSStoreLedger where  IMSItemID='" & IMSItemID & "' and Locationid='" & LocationID & "'"
            str &= " order by StoreLedgerID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCloseAmountWithLocation(ByVal IMSItemID As Long, ByVal LocationID As Long) As DataTable
            Dim str As String
            str = " Select Top 1 isnull(CloseAmount,0) as CloseAmount from IMSStoreLedger where  IMSItemID='" & IMSItemID & "' and Locationid='" & LocationID & "'"
            str &= " order by StoreLedgerID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCloseAmount(ByVal IMSItemID As Long)
            Dim str As String
            str = " Select Top 1 isnull(CloseAmount,0) as CloseAmount from IMSStoreLedger where  IMSItemID=" & IMSItemID
            str &= " order by StoreLedgerID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace