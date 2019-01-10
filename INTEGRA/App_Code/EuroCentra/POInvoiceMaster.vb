Imports System.Data.SqlClient
Imports System.Text
Imports System.Data

Public Class POInvoiceMaster

    Inherits SQLManager

    Public Sub New()
        m_strTableName = "POInvoiceMaster"
        m_strPrimaryFieldName = "POInvoiceMasterID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
    End Sub
    Private m_lPOInvoiceMasterID As Long
    Private m_lPOID As Long
    Private m_strTransactionNo As String
    Private m_strVoucherNo As String
    Private m_strSaleTaxInvoiceNo As String
    Private m_strPurchaseAccount As String
    Private m_strAccountPayable As String
    Private m_strSaleTaxType As String
    Private m_dtCreationDate As Date
    Private m_strGSTType As Boolean
    Private m_dtBillDate As Date
    Private m_strRefNo As String
    Private m_strCreditDays As String
    Private m_strTerms As String
    Private m_strComments As String
    Private m_lSNO As Long
    Private m_lAccountPayablePartyID As Long    '=-----SupplierdatabaseID
    Private m_lJobOrderId As Long
    Public Property AccountPayablePartyID() As Long
        Get
            AccountPayablePartyID = m_lAccountPayablePartyID
        End Get
        Set(ByVal Value As Long)
            m_lAccountPayablePartyID = Value
        End Set
    End Property
    Public Property POInvoiceMasterID() As Long
        Get
            POInvoiceMasterID = m_lPOInvoiceMasterID
        End Get
        Set(ByVal Value As Long)
            m_lPOInvoiceMasterID = Value
        End Set
    End Property
    Public Property POID() As Long
        Get
            POID = m_lPOID
        End Get
        Set(ByVal Value As Long)
            m_lPOID = Value
        End Set
    End Property
    Public Property TransactionNo() As String
        Get
            TransactionNo = m_strTransactionNo
        End Get
        Set(ByVal Value As String)
            m_strTransactionNo = Value
        End Set
    End Property
    Public Property VoucherNo() As String
        Get
            VoucherNo = m_strVoucherNo
        End Get
        Set(ByVal Value As String)
            m_strVoucherNo = Value
        End Set
    End Property
    Public Property SaleTaxInvoiceNo() As String
        Get
            SaleTaxInvoiceNo = m_strSaleTaxInvoiceNo
        End Get
        Set(ByVal value As String)
            m_strSaleTaxInvoiceNo = value
        End Set
    End Property
    Public Property PurchaseAccount() As String
        Get
            PurchaseAccount = m_strPurchaseAccount
        End Get
        Set(ByVal value As String)
            m_strPurchaseAccount = value
        End Set
    End Property
    Public Property AccountPayable() As String
        Get
            AccountPayable = m_strAccountPayable
        End Get
        Set(ByVal value As String)
            m_strAccountPayable = value
        End Set
    End Property
    Public Property SaleTaxType() As String
        Get
            SaleTaxType = m_strSaleTaxType
        End Get
        Set(ByVal value As String)
            m_strSaleTaxType = value
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
    Public Property GSTType() As String
        Get
            GSTType = m_strGSTType
        End Get
        Set(ByVal value As String)
            m_strGSTType = value
        End Set
    End Property

    Public Property BillDate() As Date
        Get
            BillDate = m_dtBillDate
        End Get
        Set(ByVal value As Date)
            m_dtBillDate = value
        End Set
    End Property
    Public Property RefNo() As String
        Get
            RefNo = m_strRefNo
        End Get
        Set(ByVal value As String)
            m_strRefNo = value
        End Set
    End Property
    Public Property CreditDays() As String
        Get
            CreditDays = m_strCreditDays
        End Get
        Set(ByVal value As String)
            m_strCreditDays = value
        End Set
    End Property
    Public Property Terms() As String
        Get
            Terms = m_strTerms
        End Get
        Set(ByVal value As String)
            m_strTerms = value
        End Set
    End Property
    Public Property Comments() As String
        Get
            Comments = m_strComments
        End Get
        Set(ByVal value As String)
            m_strComments = value
        End Set
    End Property

    Public Property SNO() As Long
        Get
            SNO = m_lSNO
        End Get
        Set(ByVal Value As Long)
            m_lSNO = Value
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
    Public Function SavePOInvoiceMaster()
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
    Function DeleteDetail(ByVal lPoInvoiceDetailId As Long)
        Dim Str As String
        Str = " Delete from POInvoiceDetail where PoInvoiceDetailId=" & lPoInvoiceDetailId
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetTopSNO()
        Dim str As String
        str = " select Top 1 SNo from POInvoiceMaster order by POInvoiceMasterID DESC"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetLastTransactionNo()
        Dim str As String
        str = " select Top 1 TransactionNo from POInvoiceMaster  order By POInvoiceMasterID DESC"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    ' Public Function GetLastVoucherNo(ByVal Month As Integer, ByVal year As Integer)
    Public Function GetLastVoucherNo(ByVal year As Integer)
        Dim str As String
        ' str = " select Top 1 VoucherNo from POInvoiceMaster where month(Creationdate)='" & Month & "' and year(Creationdate)='" & year & "' order By POInvoiceMasterID DESC"
        str = " select Top 1 VoucherNo from POInvoiceMaster where year(Creationdate)='" & year & "' order By POInvoiceMasterID DESC"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function

    Function DeleteFromPOInvoiceMAster(ByVal POInvoiceMAsterID As Long)
        Dim Str As String
        Str = " Delete from POInvoiceMaster where POInvoiceMAsterID=" & POInvoiceMAsterID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function DeleteFromPOInvoiceDetail(ByVal POID As Long)
        Dim Str As String
        Str = " Delete from POInvoiceDetail where POInvoiceMAsterID=" & POInvoiceMasterID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetPOInvoiceforView()
        Dim Str As String
        'Str = " select *,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.BillDate,103) BillDatee from POInvoiceMaster PO  "


        Str = " select *,convert(varchar,PO.Creationdate,103) Creationdatee ,"
        Str &= " convert(varchar,PO.BillDate,103) BillDatee,"
        Str &= " (select sum (netamount) from POInvoiceDetail POD WHERE POD.POInvoiceMasterID= PO.POInvoiceMasterID) AS AMOUNT   "
        Str &= " from POInvoiceMaster PO WHERE jOBORDERID=0"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetPOInvoiceforjoView()
        Dim Str As String
        'Str = " select *,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.BillDate,103) BillDatee from POInvoiceMaster PO  "


        Str = " select *,convert(varchar,PO.Creationdate,103) Creationdatee ,"
        Str &= " convert(varchar,PO.BillDate,103) BillDatee,"
        Str &= " (select sum (netamount) from POInvoiceDetail POD WHERE POD.POInvoiceMasterID= PO.POInvoiceMasterID) AS AMOUNT   "
        Str &= " from POInvoiceMaster PO where JobOrderid>0"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function Edit(ByVal POInvoiceMasterID As String)
        Dim Str As String
        Str = " select *,A.AccountName as 'AdditionalChargesAccountName' from POInvoiceMAster PO "
        Str &= " join  POInvoiceDetail POD on PO.POInvoiceMasterID=POD.POInvoiceMasterID "
        Str &= " join ItemProduct IP on  IP.ItemID=POD.ITEMID"
        Str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=PO.AccountPayablePartyID"
        Str &= " left join tblaccounts a on a.Accountcode=POD.AdditionalChargesAccountCode"
        Str &= " where PO.POInvoiceMasterID='" & POInvoiceMasterID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function EditNew(ByVal POInvoiceMasterID As String, ByVal AccountPayablePartyID As Long)
        Dim Str As String
        Str = " select *,A.AccountName as 'AdditionalChargesAccountName' from POInvoiceMAster PO "
        Str &= " join  POInvoiceDetail POD on PO.POInvoiceMasterID=POD.POInvoiceMasterID "
        Str &= " join ItemProduct IP on  IP.ItemID=POD.ITEMID"
        Str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=PO.AccountPayablePartyID"
        Str &= " left join tblaccounts a on a.Accountcode=POD.AdditionalChargesAccountCode"
        Str &= " where PO.POInvoiceMasterID='" & POInvoiceMasterID & "' and  PO.AccountPayablePartyID='" & AccountPayablePartyID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetAccountLedger(ByVal AccountLedger As String)
        Dim Str As String
        Str = " select AccountName,accountcode from 	tblaccounts where accountcode like '0501%' and Accountlevel='Detail' and AccountName='" & AccountLedger & "'"
        'Str &= " where PO.POInvoiceMasterID='" & POInvoiceMasterID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function EditExpense(ByVal POInvoiceMasterID As String)
        Dim Str As String
        Str = " select * from tblExpenses where PoiNvoiceMstid='" & POInvoiceMasterID & "'"
        'Str &= " where PO.POInvoiceMasterID='" & POInvoiceMasterID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetItemCode(ByVal ItemID As String)
        Dim Str As String
        Str = " select ItemCode From ItemProduct  where ItemID='" & ItemID & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetYarnCodeCode(ByVal yarndatabaseid As String)
        Dim Str As String
        Str = " select YarnCode From yarndatabase  where yarndatabaseid='" & yarndatabaseid & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetItemName(ByVal ItemCode As String)
        Dim Str As String
        Str = " select ItemName From ItemProduct  where ItemCode='" & ItemCode & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetProductTypeFirstLevel()
        Dim Str As String
        Str = " select ItemID,ItemCode,ItemName From ItemProduct  where ItemLevel=0 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetProductTypeFirstLevelForJobInvoice()
        Dim Str As String
        Str = " select ItemID,ItemCode,ItemName From ItemProduct  where ItemLevel=0 and ITEMID=1"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetProductName(ByVal ItemCode As String)
        Dim Str As String
        Str = " select ItemID,ItemName  From ItemProduct  where Itemcode Like '" & ItemCode & "%' and ItemLevel <> 0 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetYarncountbyJobOrder(ByVal JonOrderID As Long, ByVal KnitterID As Long)
        Dim Str As String
        Str = " select distinct YDB.YarnDatabaseID,YDB.YarnCount from YarnIssueMst Mst"
        Str &= " join YarnIssuedtl dtl on mst.YarnIssueMstID=dtl.YarnIssueMstID"
        Str &= "  join YarnDatabase YDB on YDB.YarnDatabaseID=dtl.YarnDatabaseID where dtl.KnitterID='" & KnitterID & "'and Mst.JoborderId='" & JonOrderID & "'and dtl.InvoiceStatus=0"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetPONO()
        Dim Str As String
        Str = " select * From POMAster  "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetPONONew()
        Dim Str As String
        Str = " select Distinct PO.POID,PO.PONO from POMaster PO join PORecvMaster POR on POr.POID=PO.POID where CEOApproval=1 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetJobOrderNo()
        Dim Str As String
        Str = " select * From JobOrderdatabase  "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetInvoice(ByVal AccountPayable As String)
        Dim str As String
        str = " select * from POInvoiceMaster where AccountPayable='" & AccountPayable & "'  "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetVoucher(ByVal AccountCode As String)
        Dim str As String
        str = "select distinct tblBankMstId, VoucherNo from tblBankDtl "
        'where  AccountCode='" & AccountCode & "'   "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetSupplierForInvoiceeReport()
        Dim str As String
        str = "select * from SupplierDatabase "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetPodetail(ByVal POMasterId As Long) As DataTable
        Dim str As String

        str = " SELECT 'Head Office'as store,*,(por.RecvQuantity - pd.InvoiceQty) as TotalQty,'0' as POInvoiceDetailId ,"
        str &= "  '0' as AdditionalChargesAccountCode,'0' as AdditionalCharges,'N/A' as AdditionalChargesAccountName "
        str &= " FROM PoMaster PM  JOIN PoDetail pd on PM.POID=pd.POID "
        str &= " join PORecvDetail por on por.PoDetailID=pd.PoDetailID join IMSDepartmentDataBase imd on imd.Deptdatabaseid=pd.Deptdatabaseid"
        str &= " join ItemProduct IT ON PD.ItemID=IT.ItemID  WHERE PM.POID='" & POMasterId & "' "
        '  str = " SELECT 'Head Office'as store,*,(pd.Qunatity - pd.InvoiceQty) as TotalQty,'0' as POInvoiceDetailId ,'0' as AdditionalChargesAccountCode,'0' as AdditionalCharges,'N/A' as AdditionalChargesAccountName FROM PoMaster PM "
        'str &= " JOIN PoDetail pd on PM.POID=pd.POID join ItemProduct IT ON PD.ItemID=IT.ItemID  WHERE PM.POID='" & POMasterId & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPodetailNew(ByVal POMasterId As Long, ByVal AccountPayablePartyID As Long) As DataTable
        Dim str As String

        str = " SELECT 'Head Office'as store,*,(por.RecvQuantity - pd.InvoiceQty) as TotalQty,'0' as POInvoiceDetailId ,"
        str &= "  '0' as AdditionalChargesAccountCode,'0' as AdditionalCharges,'N/A' as AdditionalChargesAccountName "
        str &= " FROM PoMaster PM  JOIN PoDetail pd on PM.POID=pd.POID "
        str &= " join PORecvDetail por on por.PoDetailID=pd.PoDetailID join IMSDepartmentDataBase imd on imd.Deptdatabaseid=pd.Deptdatabaseid"
        str &= " join ItemProduct IT ON PD.ItemID=IT.ItemID  WHERE PM.POID='" & POMasterId & "' and PD.AccountPayablePartyID='" & AccountPayablePartyID & "'"
        '  str = " SELECT 'Head Office'as store,*,(pd.Qunatity - pd.InvoiceQty) as TotalQty,'0' as POInvoiceDetailId ,'0' as AdditionalChargesAccountCode,'0' as AdditionalCharges,'N/A' as AdditionalChargesAccountName FROM PoMaster PM "
        'str &= " JOIN PoDetail pd on PM.POID=pd.POID join ItemProduct IT ON PD.ItemID=IT.ItemID  WHERE PM.POID='" & POMasterId & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbItemUnit(ByVal ItemID As Long)
        Dim str As String
        str = " select * from ItemProduct  I join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID where ItemID=" & ItemID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbItemUnitByJobwise(ByVal ItemID As Long, ByVal Joborderid As Long)
        Dim str As String
        'str = " select * from ItemProduct  I join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID "
        'str &= " JobOrDBAccessoriesDetail JOA  ON I.ItemID =JOA.ItemID where JOA.Joborderid='" & Joborderid & "' and ItemID = " & ItemID

        str = "   select * ,"
        str &= " (select distinct Sum(Qty) from JobOrDBAccessoriesDetail JOA "
        str &= " where I.ItemID =JOA.ItemID and JOA.Joborderid='" & Joborderid & "' and  JOA.ItemID ='" & ItemID & "') as Qty from ItemProduct  I "
        str &= " join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID  "
        str &= " where I.ItemID = " & ItemID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbItemUnitByJobwiseNew(ByVal ItemID As Long, ByVal Joborderid As Long)
        Dim str As String

        'str = "    select   JOA.POQty,JOA.Qty,JOA.JobOrDBAccessoriesDetailID,Iu.Symbol,Iu.ItemUnitID,IU.Name,I.OpeningRate from ItemProduct  I "
        'str &= " join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID  "
        'str &= " join JobOrDBAccessoriesDetail JOA on  I.ItemID =JOA.ItemID "
        'str &= " where I.ItemID = '" & ItemID & "' and JOA.Joborderid='" & Joborderid & "'"
        'str &= " group by Iu.Symbol,Iu.ItemUnitID,IU.Name,I.OpeningRate"

        str = "    select   JOA.POQty,JOA.Qty,JOA.JobOrDBAccessoriesDetailID,Iu.Symbol,Iu.ItemUnitID,IU.Name,I.OpeningRate,JOA.Color ,JOA.Content ,JOA.JobDtlQTy from ItemProduct  I "
        str &= " join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID  "
        str &= " join JobOrDBAccessoriesDetail JOA on  I.ItemID =JOA.ItemID "
        str &= " where I.ItemID = '" & ItemID & "' and JOA.Joborderid='" & Joborderid & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbItemUnitByJobwiseNewNew(ByVal ItemID As Long, ByVal Joborderid As Long, ByVal JobOrDBAccessoriesDetailID As Long)
        Dim str As String

        'str = "    select   JOA.POQty,JOA.Qty,JOA.JobOrDBAccessoriesDetailID,Iu.Symbol,Iu.ItemUnitID,IU.Name,I.OpeningRate from ItemProduct  I "
        'str &= " join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID  "
        'str &= " join JobOrDBAccessoriesDetail JOA on  I.ItemID =JOA.ItemID "
        'str &= " where I.ItemID = '" & ItemID & "' and JOA.Joborderid='" & Joborderid & "'"
        'str &= " group by Iu.Symbol,Iu.ItemUnitID,IU.Name,I.OpeningRate"

        str = "    select   JOA.POQty,JOA.Qty,JOA.JobOrDBAccessoriesDetailID,Iu.Symbol,Iu.ItemUnitID,IU.Name,I.OpeningRate,JOA.Color ,JOA.Content ,JOA.JobDtlQTy from ItemProduct  I "
        str &= " join ItemUnit Iu on IU.ItemUnitID=I.ItemUnitID  "
        str &= " join JobOrDBAccessoriesDetail JOA on  I.ItemID =JOA.ItemID "
        str &= " where I.ItemID = '" & ItemID & "' and JOA.Joborderid='" & Joborderid & "' and JOA.JobOrDBAccessoriesDetailID='" & JobOrDBAccessoriesDetailID & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function BindColor(ByVal ItemID As Long, ByVal Joborderid As Long)
        Dim str As String


        'str = "    select * from JobOrDBAccessoriesDetail"
        'str &= " where ItemID = '" & ItemID & "' and Joborderid='" & Joborderid & "'"
        str = "    select JobOrDBAccessoriesDetailID,(Color +'-' +cast( JobOrDBAccessoriesDetailID as varchar)) as Color from JobOrDBAccessoriesDetail where ItemID = '" & ItemID & "' and Joborderid='" & Joborderid & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbStore()
        Dim str As String
        str = " SELECT * FROM StoreAdd"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbFrom()
        Dim str As String
        str = " SELECT DeptDatabaseName+ '  ('+ DeptAbbrivation+')' as DeptDatabaseName,DeptDatabaseId FROM IMSDepartmentDataBase"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetCmbFromForJobInvoice()
        Dim str As String
        str = " SELECT DeptDatabaseName+ '  ('+ DeptAbbrivation+')' as DeptDatabaseName,DeptDatabaseId FROM IMSDepartmentDataBase where DeptDatabaseId=91"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetAdditionalchargesaccount()
        Dim str As String
        str = " select * from tblaccounts where Accountnature='5' and Groupact='05'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetExpensechargesaccount()
        Dim str As String
        str = " select * from tblaccounts where Accountnature='5' and Groupact='05'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPOQUANTITY(ByVal PODetailId As Long) As DataTable
        Dim str As String
        str = " SELECT * FROM PoDetail WHERE PoDetailiD='" & PODetailId & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetPOPreviousQUANTITY(ByVal POId As Long) As DataTable
        Dim str As String
        str = " SELECT  SUM(qUNATITY) AS PREVOIUSSUM FROM  POInvoicemaster 	POM join POInvoiceDetail POD  "
        str &= " on POM.POInvoicemasterid=POD.POInvoicemasterid"
        str &= " WHERE POM.poid = '" & POId & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function


    Public Function UPDATEInVOICEqTY(ByVal PODetailId As Long, ByVal InvoiceQty As Decimal)
        Dim str As String
        str = "  update PoDetail set InvoiceQTY='" & InvoiceQty & "' where PoDetailId='" & PODetailId & "'   "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function GetYarnCountData(ByVal JobOrderID As Long, ByVal yardatabaseID As Long, ByVal KnitterId As Long)
        Dim Str As String
        Str = " select Mst.JoborderID,dtl.YarnDatabaseID,dtl.YarnCount,dtl.IssueQty,dtl.Weight,dtl.Rate,"
        Str &= " dtl.KnitterId,dtl.Knitter,isnull((select Sum(ReturnQty) from YarnReturn YR "
        Str &= " where YR.YarnIssueMstID = MST.YarnIssueMstID "
        Str &= " and MST.JoborderID=YR.JoborderID"
        Str &= " and dtl.YarnIssuedtlID=YR.YarnIssuedtlID"
        Str &= " and dtl.KnitterID=YR.KnitterID"
        Str &= " and dtl.FabricTypeID=YR.FabricTypeID),0)  as ReturnBag"
        Str &= " ,((dtl.IssueQty-isnull((select Sum(ReturnQty) from YarnReturn YR "
        Str &= " where YR.YarnIssueMstID = MST.YarnIssueMstID"
        Str &= " and MST.JoborderID=YR.JoborderID"
        Str &= " and dtl.YarnIssuedtlID=YR.YarnIssuedtlID"
        Str &= " and dtl.KnitterID=YR.KnitterID"
        Str &= " and dtl.FabricTypeID=YR.FabricTypeID),0))* (45.36)+(dtl.Weight)) as FinalWeight"
        Str &= " ,((dtl.IssueQty-isnull((select Sum(ReturnQty) from YarnReturn YR "
        Str &= " where YR.YarnIssueMstID = MST.YarnIssueMstID "
        Str &= " and MST.JoborderID=YR.JoborderID"
        Str &= " and dtl.YarnIssuedtlID=YR.YarnIssuedtlID"
        Str &= " and dtl.KnitterID=YR.KnitterID"
        Str &= " and dtl.FabricTypeID=YR.FabricTypeID),0))* (45.36)+(dtl.Weight)) * (dtl.Rate) as Amount"
        Str &= " from YarnIssueMst Mst"
        Str &= " join YarnIssuedtl dtl on mst.YarnIssueMstID=dtl.YarnIssueMstID"
        Str &= "   where Mst.JoborderID = '" & JobOrderID & "' And dtl.YarnDatabaseID = '" & yardatabaseID & " ' and dtl.KnitterId='" & KnitterId & "' and dtl.InvoiceStatus=0 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try

    End Function

    Public Function GetKnittert(ByVal JoborderId As Long)
        Dim Str As String
        Str = " select distinct dtl.KnitterId,dtl.Knitter from YarnIssueMst Mst"
        Str &= " join YarnIssuedtl dtl on mst.YarnIssueMstID=dtl.YarnIssueMstID where Mst.JoborderId=" & JoborderId
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindSupplierForRecPONew(ByVal POID As Long) As DataTable
        Dim str As String
        str = " select Distinct SDB.SupplierName, SDB.SupplierDatabaseId from SupplierDatabase SDB"
        str &= " join  PODetail POM on POM.AccountpayablePartyid=SDB.SupplierDatabaseId join POMaster PO on PO.POID=POM.POID where PO.POID=' " & POID & "  ' and PO.CEOApproval=1"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

End Class


