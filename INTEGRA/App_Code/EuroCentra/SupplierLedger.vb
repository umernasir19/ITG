Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Data

Public Class SupplierLedger
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "SupplierLedger"
        m_strPrimaryFieldName = "SupplierLedgerID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lSupplierLedgerID As Long
    Private m_lIMSSupplierId As Long
    Private m_dInvoiceDate As Date
    Private m_dAmountDebits As Decimal
    Private m_dAmountCredits As Decimal

    Private m_strDescription As String
    Private m_lPOInvoiceMstId As Long

    Public Property SupplierLedgerID() As Long
        Get
            SupplierLedgerID = m_lSupplierLedgerID
        End Get
        Set(ByVal Value As Long)
            m_lSupplierLedgerID = Value
        End Set
    End Property
    Public Property IMSSupplierId() As Long
        Get
            IMSSupplierId = m_lIMSSupplierId
        End Get
        Set(ByVal Value As Long)
            m_lIMSSupplierId = Value
        End Set
    End Property
    Public Property InvoiceDate() As Date
        Get
            InvoiceDate = m_dInvoiceDate
        End Get
        Set(ByVal Value As Date)
            m_dInvoiceDate = Value
        End Set
    End Property
    Public Property AmountDebits() As Decimal
        Get
            AmountDebits = m_dAmountDebits
        End Get
        Set(ByVal Value As Decimal)
            m_dAmountDebits = Value
        End Set
    End Property
    Public Property AmountCredits() As Decimal
        Get
            AmountCredits = m_dAmountCredits
        End Get
        Set(ByVal Value As Decimal)
            m_dAmountCredits = Value
        End Set
    End Property
    Public Property Description() As String
        Get
            Description = m_strDescription
        End Get
        Set(ByVal Value As String)
            m_strDescription = Value
        End Set
    End Property
    Public Property POInvoiceMstId() As String
        Get
            POInvoiceMstId = m_lPOInvoiceMstId
        End Get
        Set(ByVal Value As String)
            m_lPOInvoiceMstId = Value
        End Set
    End Property
    Public Function SaveSupplierLedger()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetALLLedgerForLedgerReport()
        Dim str As String
        'str = "select distinct im.customerid,cmd.customerName from tblInvoiceMst im join CustomerDatabaseMst cmd on cmd.CustomerDatabaseID=IM.CUSTOMERID"

        ' str = " select distinct IMS.IMSSupplierId,IMS.IMSSupplierName  from SettlePayMst sm "
        'str &= " FULL join IMSStoreReceived IM ON sm.SupplierId=IM.IMSSupplierId"
        'str &= " JOIN IMSSupplier IMS ON IMS.IMSSupplierid=IM.IMSSupplierid or IMS.IMSSupplierid=sm.Supplierid"

        'str = " select distinct IMS.Supplierdatabaseid,IMS.SupplierName  from POInvoiceMst POM  "
        'str &= " JOIN SupplierDatabase IMS ON IMS.Supplierdatabaseid=POM.aCCOUNTpAYABLEpARTYid "

        str &= " select distinct AccountCode,AccountName from tblaccounts order by AccountName ASC"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSupplierForLedgerReport()
        Dim str As String
        'str = "select distinct im.customerid,cmd.customerName from tblInvoiceMst im join CustomerDatabaseMst cmd on cmd.CustomerDatabaseID=IM.CUSTOMERID"

        ' str = " select distinct IMS.IMSSupplierId,IMS.IMSSupplierName  from SettlePayMst sm "
        'str &= " FULL join IMSStoreReceived IM ON sm.SupplierId=IM.IMSSupplierId"
        'str &= " JOIN IMSSupplier IMS ON IMS.IMSSupplierid=IM.IMSSupplierid or IMS.IMSSupplierid=sm.Supplierid"

        str = " select distinct IMS.Supplierdatabaseid,IMS.SupplierName  from POInvoiceMst POM  "
        str &= " JOIN SupplierDatabase IMS ON IMS.Supplierdatabaseid=POM.aCCOUNTpAYABLEpARTYid "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    '''---------FunctionsFor Ledger report
    Public Function TruncateTempLedgerTable()
        Dim str As String = "TRUNCATE TABLE  TempLedgerSupplier"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerTableNew()
        Dim str As String = "TRUNCATE TABLE  TempLedgerSupplierINVBPV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerINVBPVCVJV()
        Dim str As String = "TRUNCATE TABLE  TempLedgerINVBPVCVJV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerTableNewForSalesTax()
        Dim str As String = "TRUNCATE TABLE  TempLedgerSalesTaxINV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerTableNewForProduct()
        Dim str As String = "TRUNCATE TABLE  TempLedgerProductINV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerEXPTable()
        Dim str As String = "TRUNCATE TABLE  TempLedgerExpenses"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerEXPTableOnly()
        Dim str As String = "TRUNCATE TABLE  TempLedgerExpensesOnly"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerEXPTableOnlyInvoice()
        Dim str As String = "TRUNCATE TABLE  TempLedgerInvoice"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalexpTable()
        Dim str As String = "TRUNCATE TABLE  TempLedgerExpensesFinal"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalexpTableOnly()
        Dim str As String = "TRUNCATE TABLE  TempLedgerExpensesFinalOnly"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalexpTableOnlyInvoice()
        Dim str As String = "TRUNCATE TABLE  TempLedgerInvoiceFinal"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function


    '''---------FunctionsFor Ledger report
    Public Function TruncateTempLedgerFinalTable()
        Dim str As String = "TRUNCATE TABLE  TempLedgerSupplierFinal"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalINVBPVCVJV()
        Dim str As String = "TRUNCATE TABLE  TempLedgerFinalINVBPVCVJV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalTableNew()
        Dim str As String = "TRUNCATE TABLE  TempLedgerSupplierFinalINVBPV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalTableNewForSalesTax()
        Dim str As String = "TRUNCATE TABLE  TempLedgerSalesTaxFinalINV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function TruncateTempLedgerFinalTableNewForProduct()
        Dim str As String = "TRUNCATE TABLE  TempLedgerProductFinalINV"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertJVData(ByVal FirstYear As String, ByVal SecondYear As String, ByVal AccountCode As String)

        Dim str As String = "INSERT INTO TempLedgerSupplier  select TBM.VoucherDate , "
        str &= "  '' as ChequeNo,''as ChequeDate,TBD.VoucherNo + ' ' + TBD.DescriptionEntry AS DescriptionEntry,"
        str &= " '" & AccountCode & "' as AccountCode ,TBD.Debit, TBD.Credit"
        str &= " from tblJVMst TBM  "
        str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
        str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
        str &= " where VoucherDate between '" & FirstYear & "' and  '" & SecondYear & "'"
        str &= " and  TBD.AccountCode= '" & AccountCode & " ' "
        'str &= " order By TBM.VoucherNo ASC"
        str &= " order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertJVDataWithOut(ByVal AccountCode As String)

        Dim str As String = "INSERT INTO TempLedgerSupplier  select TBM.VoucherDate , "
        str &= "  '' as ChequeNo,''as ChequeDate,TBD.VoucherNo + ' ' + TBD.DescriptionEntry AS DescriptionEntry,"
        str &= " '" & AccountCode & "' as AccountCode ,TBD.Debit, TBD.Credit"
        str &= " from tblJVMst TBM  "
        str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
        str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
        str &= " where   TBD.AccountCode= '" & AccountCode & " ' "
        'str &= " order By TBM.VoucherNo ASC"
        str &= " order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertJVDataWithOutNew(ByVal AccountCode As String)

        Dim str As String = "INSERT INTO TempLedgerSupplierINVBPV  select TBM.VoucherDate , "
        str &= "  '' as ChequeNo,TBD.VoucherNo  as VNoNo, 'Journal Voucher' as VType,''as ChequeDate, TBD.DescriptionEntry AS DescriptionEntry,"
        str &= " '" & AccountCode & "' as AccountCode ,TBD.Debit, TBD.Credit"
        str &= " from tblJVMst TBM  "
        str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
        str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
        str &= " where   TBD.AccountCode= '" & AccountCode & " ' "
        'str &= " order By TBM.VoucherNo ASC"
        str &= " order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertJVDatainTempLedgerINVBPVCVJV(ByVal AccountCode As String)

        Dim str As String = "INSERT INTO TempLedgerINVBPVCVJV  select TBM.VoucherDate , "
        str &= "  '' as ChequeNo,TBD.VoucherNo  as VNoNo, 'Journal Voucher' as VType,''as ChequeDate, TBD.DescriptionEntry AS DescriptionEntry,"
        str &= " '" & AccountCode & "' as AccountCode ,TBD.Debit, TBD.Credit"
        str &= " from tblJVMst TBM  "
        str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
        str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
        str &= " where   TBD.AccountCode= '" & AccountCode & " ' "
        'str &= " order By TBM.VoucherNo ASC"
        str &= " order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertbvDataWithOut(ByVal AccountCode As String)

        'Dim str As String = "INSERT INTO TempLedgerSupplier  select TBM.VoucherDate , "
        'str &= "  '' as ChequeNo,''as ChequeDate,TBD.VoucherNo + ' ' + TBD.DescriptionEntry AS DescriptionEntry,"
        'str &= " '" & AccountCode & "' as AccountCode ,TBD.Debit, TBD.Credit"
        ' str &= " from tblBankMst TBM  "
        ' str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
        ' str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
        ' str &= " where   TBD.AccountCode= '" & AccountCode & " ' "
        'str &= " order By TBM.VoucherNo ASC"
        '  str &= " order By TBM.VoucherDate ASC"


        Dim str As String = "INSERT INTO TempLedgerSupplier  select TBM.VoucherDate , TBD.ChequeNo, TBD.ChequeDate"
        str &= "  ,TBD.VoucherNo + ' ' + TBD.DescriptionEntry AS DescriptionEntry, '" & AccountCode & "'  as AccountCode ,"
        str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
        str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit from tblBankMst TBM   "
        str &= "  join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
        str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode  "
        str &= "  where   TBD.AccountCode='" & AccountCode & "'   order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertbvDataWithOutNew(ByVal AccountCode As String)

        Dim str As String = "INSERT INTO TempLedgerSupplierINVBPV  select TBM.VoucherDate , TBD.ChequeNo,TBD.VoucherNo as  VNoNo,'Bank Voucher' as VType, TBD.ChequeDate"
        str &= "  ,  TBD.DescriptionEntry AS DescriptionEntry, '" & AccountCode & "'  as AccountCode ,"
        str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
        str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit from tblBankMst TBM   "
        str &= "  join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
        str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode  "
        str &= "  where   TBD.AccountCode='" & AccountCode & "'   order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertbvDataTempLedgerINVBPVCVJV(ByVal AccountCode As String)

        Dim str As String = "INSERT INTO TempLedgerINVBPVCVJV  select TBM.VoucherDate , TBD.ChequeNo,TBD.VoucherNo as  VNoNo,'Bank Voucher' as VType, TBD.ChequeDate"
        str &= "  ,  TBD.DescriptionEntry AS DescriptionEntry, '" & AccountCode & "'  as AccountCode ,"
        str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
        str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit from tblBankMst TBM   "
        str &= "  join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
        str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode  "
        str &= "  where   TBD.AccountCode='" & AccountCode & "'   order By TBM.VoucherDate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertCVDataTempLedgerINVBPVCVJV(ByVal AccountCode As String)

        'Dim str As String = "INSERT INTO TempLedgerINVBPVCVJV  select TBM.VoucherDate , TBD.ChequeNo,TBD.VoucherNo as  VNoNo,'Cash Voucher' as VType, TBD.ChequeDate"
        'str &= "  ,  TBD.DescriptionEntry AS DescriptionEntry, '" & AccountCode & "'  as AccountCode ,"
        'str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
        'str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit from tblcashMst TBM   "
        'str &= "  join tblcashdtl TBD on TBD.tblcashMstID=TBM.tblcashMstID  "
        'str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode  "
        'str &= "  where   TBD.AccountCode='" & AccountCode & "'   order By TBM.VoucherDate ASC"


        Dim str As String = "INSERT INTO TempLedger  select TBD.VoucherNo as "
        str &= "  VNoNo,"
        str &= "  TBM.VoucherDate ,TBD.ChequeNo,TBD.ChequeDate,'N/A' as Description,TBD.DescriptionEntry AS DescriptionEntry,a.AccountName ,"
        str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
        str &= "   Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit "
        str &= "  from tblcashMst TBM     "
        str &= "  join tblcashdtl TBD on TBD.tblcashMstID=TBM.tblcashMstID    "
        str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode   "
        str &= "   where   TBD.AccountCode='" & AccountCode & "'  "
        str &= "   order By TBM.VoucherDate ASC"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertCOntraVDataTempLedgerINVBPVCVJV(ByVal AccountCode As String)

        'Dim str As String = "INSERT INTO TempLedgerINVBPVCVJV  select TBM.ContraPaymentDate as VoucherDate , TBM.ChkNo as ChequeNo,TBM.ContraNo as  VNoNo,'Contra Voucher' as VType, '' as ChequeDate"
        'str &= "  ,  TBD.Particulars AS DescriptionEntry, '" & AccountCode & "'  as AccountCode ,"
        'str &= "  Case When TBD.DrCr = 'Dr' Then TBD.Amount Else 0 End As Debit, "
        'str &= "  Case When TBD.DrCr = 'Cr' then TBD.Amount else 0 end as Credit from ContraVoucherMst TBM   "
        'str &= "  join ContraVoucherDtl TBD on TBD.ContraVoucherMstID=TBM.ContraVoucherMstID  "
        'str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode  "
        'str &= "  where   TBD.AccountCode='" & AccountCode & "'   order By TBM.ContraPaymentDate ASC"


        Dim str As String = "INSERT INTO TempLedger      select TBM.ContraNo as "
        str &= "  VNoNo,"
        str &= "  TBM.ContraPaymentDate as VoucherDate ,TBM.ChkNo as ChequeNo,'' as ChequeDate,'N/A' as Description,TBD.Particulars AS DescriptionEntry"
        str &= "  ,a.AccountName ,"
        str &= "    Case When TBD.DrCr = 'Dr' Then TBD.Amount Else 0 End As Debit, "
        str &= "  Case When TBD.DrCr = 'Cr' then TBD.Amount else 0 end as Credit"
        str &= "  from ContraVoucherMst TBM     "
        str &= "  join ContraVoucherDtl TBD on TBD.ContraVoucherMstID=TBM.ContraVoucherMstID  "
        str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode   "
        str &= "   where   TBD.AccountCode='" & AccountCode & "'  "
        str &= "  order By TBM.ContraPaymentDate ASC"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function InsertSupplierLedgerData(ByVal FirstYear As String, ByVal SecondYear As String, ByVal AccountCode As String, ByVal Supplierid As Long)

        Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
        str &= " from SupplierLedger "
        str &= " where VoucherDate between '" & FirstYear & "' and '" & SecondYear & "' and   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerDataWithOUtDate(ByVal AccountCode As String, ByVal Supplierid As Long)

        ' Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
        'str &= " from SupplierLedger "
        ' str &= " where   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


        'Dim str As String = "INSERT INTO TempLedgerSupplier select Invoicedate,'' as ChequeNo,'' as ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " AmountDebits as Debit,AmountCredits as credit  from SupplierLedger  "
        'str &= " where   imssupplierid='" & Supplierid & "' order By  Invoicedate ASC"

        Dim str As String = " insert into TempLedgerSupplier select Billdate,'' as ChequeNo,'' as ChequeDate,'Invoice#'+ VoucherNo as Description,'" & AccountCode & "' as AccountCode,"
        str &= "'0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
        str &= " where   AccountPayablePartyID='" & Supplierid & "' order By  Billdate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerDataWithOUtDateNew(ByVal AccountCode As String, ByVal Supplierid As Long)
        Dim str As String
        If Supplierid = 0 Then
            str = " insert into TempLedgerSupplierINVBPV select Billdate,'' as ChequeNo,SaleTaxInvoiceNo as VNoNo,'Purchase' as VType,'' as ChequeDate,  LedgerAccountName as Description,'" & AccountCode & "' as AccountCode,"
            str &= "'0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
            str &= " where   LedgerAccountCode='" & AccountCode & "' order By  Billdate ASC"
        Else
            str = " insert into TempLedgerSupplierINVBPV select Billdate,'' as ChequeNo,SaleTaxInvoiceNo as VNoNo,'Purchase' as VType,'' as ChequeDate,  LedgerAccountName as Description,'" & AccountCode & "' as AccountCode,"
            str &= "'0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
            str &= " where   AccountPayablePartyID='" & Supplierid & "' order By  Billdate ASC"
        End If


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertTempLedgerINVBPVCVJV(ByVal AccountCode As String, ByVal Supplierid As Long)
        Dim str As String
        If Supplierid = 0 Then
            'str = " insert into TempLedgerINVBPVCVJV select Billdate,'' as ChequeNo,SaleTaxInvoiceNo as VNoNo,'Purchase' as VType,'' as ChequeDate,  LedgerAccountName as Description,'" & AccountCode & "' as AccountCode,"
            'str &= "'0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
            'str &= " where   LedgerAccountCode='" & AccountCode & "' order By  Billdate ASC"
            str = " insert into TempLedger  select SaleTaxInvoiceNo as VNoNo,Billdate,'' as ChequeNo,'' as ChequeDate,  LedgerAccountName as Description"
            str &= ",'' as DescriptionEntry,LedgerAccountName ,"
            str &= "     '0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
            str &= "where   LedgerAccountCode='" & AccountCode & "' "
            str &= "order By  Billdate ASC"
        Else
            str = " insert into TempLedger  select SaleTaxInvoiceNo as VNoNo,Billdate,'' as ChequeNo,'' as ChequeDate,  LedgerAccountName as Description"
            str &= ",'' as DescriptionEntry,LedgerAccountName ,"
            str &= "     '0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
            str &= "where   AccountPayablePartyID='" & Supplierid & "' "
            str &= "order By  Billdate ASC"
            'str = " insert into TempLedgerINVBPVCVJV select Billdate,'' as ChequeNo,SaleTaxInvoiceNo as VNoNo,'Purchase' as VType,'' as ChequeDate,  LedgerAccountName as Description,'" & AccountCode & "' as AccountCode,"
            'str &= "'0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
            'str &= " where   AccountPayablePartyID='" & Supplierid & "' order By  Billdate ASC"
        End If
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSalesTaxLedgerDataWithOUtDateNew(ByVal Startdate As String, ByVal enddate As String)



        Dim str As String = " insert into TempLedgerSalesTaxINV select Billdate,'' as ChequeNo,SaleTaxInvoiceNo as VNoNo,'Invoice' as VType,'' as ChequeDate,  '' as Description,'0102002001' as AccountCode"
        str &= " ,(Select Sum(SalesTaxAmount) from POInvoicedtl dtl where dtl.POInvoiceMstID=mst.POInvoiceMstID)  as Debit,'0' as credit  from POInvoiceMst mst "
        str &= " where  GSTType='With GST' and Creationdate between '" & Startdate & "' and '" & enddate & "' order By  Billdate ASC"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertProductLedgerDataWithOUtDateNew(ByVal Startdate As String, ByVal enddate As String, ByVal ItemID As Long)
        Dim str As String = " insert into TempLedgerProductINV select '' as Billdate,'' as ChequeNo,'' as SaleTaxInvoiceNo"
        str &= " ,'Invoice' as VType,'' as ChequeDate,  IP.ItemName as Description,"
        str &= " IP.ItemCode as AccountCode"
        str &= " ,sum(GrossAmount) as Debit,'0' as credit from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join ItemProduct IP on IP.ItemID=SD.ItemID"
        str &= "  where   POIM.Creationdate between '" & Startdate & "' and '" & enddate & "' "
        str &= " and IP.ItemID='" & ItemID & "'"
        str &= " group by IP.ItemName,IP.ItemCode"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertProductLedgerDataWithOUtDateNew2(ByVal ItemID As Long)
        Dim str As String = " insert into TempLedgerProductINV select '' as Billdate,'' as ChequeNo,'' as SaleTaxInvoiceNo"
        str &= " ,'Invoice' as VType,'' as ChequeDate,  IP.ItemName as Description,"
        str &= " IP.ItemCode as AccountCode"
        str &= " ,sum(GrossAmount) as Debit,'0' as credit from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join ItemProduct IP on IP.ItemID=SD.ItemID"
        str &= "  where   IP.ItemID='" & ItemID & "'"
        str &= " group by IP.ItemName,IP.ItemCode"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertAccountLedgerDataWithOUtDateNew2(ByVal accountcode As String)
        Dim str As String = " insert into TempLedgerProductINV select POIM.Billdate as Billdate,'' as ChequeNo,'' as SaleTaxInvoiceNo"
        str &= " ,'Purchase' as VType,'' as ChequeDate,  Sdd.SupplierName as Description,"
        str &= " IP.accountcode as AccountCode"
        str &= " ,sum(GrossAmount) as Debit,'0' as credit from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join tblaccounts IP on IP.accountcode=POIM.LedgerAccountCode join supplierdatabase Sdd on Sdd.supplierdatabaseID=POIM.AccountPayablePartyid"
        str &= "  where   IP.accountcode='" & accountcode & "'"
        str &= " group by Sdd.SupplierName,IP.accountcode,POIM.Billdate"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertProductLedgerDataWithOUtDateNew2All()
        Dim str As String = " insert into TempLedgerProductINV select '' as Billdate,'' as ChequeNo,'' as SaleTaxInvoiceNo"
        str &= " ,'Invoice' as VType,'' as ChequeDate,  IP.ItemName as Description,"
        str &= " IP.ItemCode as AccountCode"
        str &= " ,sum(GrossAmount) as Debit,'0' as credit from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join ItemProduct IP on IP.ItemID=SD.ItemID"
        str &= " group by IP.ItemName,IP.ItemCode"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertAccountLedgerDataWithOUtDateNew2All()
        Dim str As String = " insert into TempLedgerProductINV select POIM.Billdate as Billdate,'' as ChequeNo,'' as SaleTaxInvoiceNo"
        str &= " ,'Purchase' as VType,'' as ChequeDate,  Sdd.SupplierName as Description,"
        str &= " IP.accountcode as AccountCode"
        str &= " ,sum(GrossAmount) as Debit,'0' as credit from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join tblaccounts IP on IP.accountcode=POIM.LedgerAccountCode join supplierdatabase Sdd on Sdd.supplierdatabaseID=POIM.AccountPayablePartyid"
        str &= " group by Sdd.SupplierName,IP.accountcode,POIM.Billdate"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    'Public Function InsertSupplierLedgerDataForExpensesLedger(ByVal AccountCode As String, ByVal Supplierid As Long)

    '    ' Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
    '    'str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
    '    'str &= " from SupplierLedger "
    '    ' str &= " where   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


    '    Dim str As String = "INSERT INTO TempLedgerExpenses select Invoicedate,'' as ChequeNo,'' as ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
    '    str &= " AmountDebits as Debit,AmountCredits as credit  from SupplierLedger  "
    '    str &= " where   imssupplierid='" & Supplierid & "' order By  Invoicedate ASC"


    '    Try
    '        MyBase.ExecuteNonQuery(str)
    '    Catch ex As Exception
    '    End Try
    'End Function
    Public Function InsertSupplierLedgerDataForExpensesLedger(ByVal AccountCode As String, ByVal Supplierid As Long)

        ' Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
        'str &= " from SupplierLedger "
        ' str &= " where   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


        Dim str As String = "INSERT INTO TempLedgerExpenses select Invoicedate,'' as ChequeNo,'' as ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        str &= " AmountDebits as Debit,AmountCredits as credit  from SupplierLedger  "
        str &= " where   imssupplierid='" & Supplierid & "'  and POInvoiceMstid>0 order By  Invoicedate ASC"



        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerDataForInvoiceLedger(ByVal AccountCode As String, ByVal Supplierid As Long, ByVal description As String)

        ' Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
        'str &= " from SupplierLedger "
        ' str &= " where   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


        Dim str As String = "INSERT INTO TempLedgerInvoice select Billdate as Invoicedate,'' as ChequeNo,'' as ChequeDate, '" & description & "' as Description,'" & AccountCode & "' as AccountCode,"
        str &= " '0' as Debit,InvoiceNetAmount as credit  from POInvoiceMst  "
        str &= " where   AccountPayablePartyID='" & Supplierid & "'  order By  Billdate ASC"




        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function




    Public Function InsertSupplierLedgerDataForExpensesLedgerOnly(ByVal AccountCode As String, ByVal Supplierid As Long)

        ' Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
        'str &= " from SupplierLedger "
        ' str &= " where   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


        Dim str As String = " INSERT INTO TempLedgerExpensesOnly select POM.BillDate,'' as ChequeNo,'' as ChequeDate,'Expenses of '+ExpensesChargesAccountName as Description,AccountCode,"
        str &= " ExpensesCharges, '0' as credit from tblExpenses EX "
        str &= " join POInvoiceMaster POM ON POM.POInvoiceMasterID=EX.POInvoiceMSTID"
        str &= "  Where POM.AccountPayAblePartyId = '" & Supplierid & "'"



        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function



    Public Function InsertRxpensesDataForExpensesLedger(ByVal AccountCode As String, ByVal Supplierid As Long)

        ' Dim str As String = "INSERT INTO TempLedgerSupplier select Voucherdate,ChequeNo,ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " PayedAmountDebit as Debit,ReceiveableAmountCredit as credit "
        'str &= " from SupplierLedger "
        ' str &= " where   supplierid='" & Supplierid & "'  order By  Voucherdate ASC "


        'Dim str As String = "INSERT INTO TempLedgerSupplier select Invoicedate,'' as ChequeNo,'' as ChequeDate,Description,'" & AccountCode & "' as AccountCode,"
        'str &= " AmountDebits as Debit,AmountCredits as credit  from SupplierLedger  "
        'str &= " where   imssupplierid='" & Supplierid & "' order By  Invoicedate ASC"
        Dim str As String = " INSERT INTO TempLedgerExpenses select POM.BillDate,'' as ChequeNo,'' as ChequeDate,'Expenses of '+ExpensesChargesAccountName as Description,AccountCode,"
        str &= " ExpensesCharges, '0' as credit from tblExpenses EX "
        str &= " join POInvoiceMaster POM ON POM.POInvoiceMasterID=EX.POInvoiceMSTID"
        str &= "  Where POM.AccountPayAblePartyId = '" & Supplierid & "'"


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerFinalDataExpenses()

        Dim str As String = "INSERT INTO TempLedgerExpensesFinal select Voucherdate,ChequeNo,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerExpenses   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerFinalDataExpensesOnly()

        Dim str As String = "INSERT INTO TempLedgerExpensesFinalOnly select Voucherdate,ChequeNo,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerExpensesOnly   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerFinalDataInvoiceLedger()

        Dim str As String = "INSERT INTO TempLedgerInvoiceFinal select Voucherdate,ChequeNo,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerInvoice   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function


    Public Function InsertSupplierLedgerFinalData(ByVal FirstYear As String, ByVal SecondYear As String)

        Dim str As String = "INSERT INTO TempLedgerSupplierFinal select Voucherdate,ChequeNo,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerSupplier "
        str &= " where VoucherDate between '" & FirstYear & "' and '" & SecondYear & "'  order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerFinalDataWithOutDate()

        Dim str As String = "INSERT INTO TempLedgerSupplierFinal select Voucherdate,ChequeNo,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerSupplier   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSupplierLedgerFinalDataWithOutDateNew()

        Dim str As String = "INSERT INTO TempLedgerSupplierFinalINVBPV select Voucherdate,ChequeNo,VNoNo,VType,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerSupplierINVBPV   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertTempLedgerFinalINVBPVCVJV()

        Dim str As String = "INSERT INTO TempLedgerFinalINVBPVCVJV select Voucherdate,ChequeNo,VNoNo,VType,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerINVBPVCVJV   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertSalesTaxLedgerFinalDataWithOutDateNew()

        Dim str As String = "INSERT INTO TempLedgerSalesTaxFinalINV select Voucherdate,ChequeNo,VNoNo,VType,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerSalesTaxINV   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertProductFinalDataWithOutDateNew()

        Dim str As String = "INSERT INTO TempLedgerProductFinalINV select Voucherdate,ChequeNo,VNoNo,VType,ChequeDate,Description, AccountCode,"
        str &= " Debit, credit "
        str &= " from TempLedgerProductINV   order By  Voucherdate ASC "


        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function getAccountCodeForLedger(ByVal AccountName As String) As DataTable
        Dim str As String
        str = " select   * from tblaccounts where AccountName='" & AccountName & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getPartyIDByAccountCodeForLedger(ByVal SupplierName As String) As DataTable
        Dim str As String
        str = " select   * from SupplierDatabase where SupplierName='" & SupplierName & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getPartyIDByAccountCode(ByVal SupplierCode As String) As DataTable
        Dim str As String
        str = " select   * from SupplierDatabase where SupplierCode='" & SupplierCode & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getAccountCode(ByVal supplierid As Long) As DataTable
        Dim str As String
        str = " select   * from SupplierDatabase where SupplierDatabaseId='" & supplierid & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getProductCode(ByVal ItemID As Long) As DataTable
        Dim str As String
        str = " select   * from ItemProduct where ItemID='" & ItemID & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getSupplier(ByVal SupplierName As String) As DataTable
        Dim str As String
        str = " select distinct Sd.Supplierdatabaseid,Sd.SupplierName "
        str &= " from POInvoiceMst POM   "
        str &= " join SupplierDatabase Sd on Sd.Supplierdatabaseid=POM.AccountPayablePartyID"
        str &= " where sd.SupplierName ='" & SupplierName & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Function GETSupplierSearch(ByVal SupplierName As String)
        Dim Str As String
        Str = " select distinct Sd.SupplierName "
        Str &= " from POInvoiceMst POM "
        Str &= " join SupplierDatabase Sd on Sd.Supplierdatabaseid=POM.AccountPayablePartyID"
        Str &= " where sd.SupplierName like '" & SupplierName & "%'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GETAccountNameSearch(ByVal AccountName As String)
        Dim Str As String
        Str = "  Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA"
        Str &= " where AccountName like '" & AccountName & "%'"
        Str &= " order by TA.AccountName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GETInvAutoSearch(ByVal InvoiceNo As String)
        Dim Str As String
       
        Str = " select distinct POIM.SaleTaxInvoiceNo from POInvoiceMst POIM  join  SupplierDatabase SD on POIM.Accountpayablepartyid=SD.SupplierdatabaseID where   POIM.SaleTaxInvoiceNo like '" & InvoiceNo & "%'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GETInvAutoSearch2(ByVal InvoiceNo As String, ByVal Supplier As String)
        Dim Str As String

        Str = " select distinct POIM.SaleTaxInvoiceNo from POInvoiceMst POIM  join  SupplierDatabase SD on POIM.Accountpayablepartyid=SD.SupplierdatabaseID where   SD.SupplierName='" & Supplier & "' and POIM.SaleTaxInvoiceNo like '" & InvoiceNo & "%'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetUniqueAccountCode(ByVal AccountName As String)
        Dim str As String
        ' str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA join  tblOpeningBalance TOB on TA.AccountCode=TOB.AccountCode "
        str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA  "
        str &= " where TA.AccountName+'-'+ TA.AccountCode ='" & AccountName & "'"
        str &= " order by TA.AccountName ASC"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Function GETAccountLedgerAutoSearch(ByVal ItemName As String)
        Dim Str As String

        Str = " select AccountName from 	tblaccounts where accountcode like '0501%' and Accountlevel='Detail' and accountname like '" & ItemName & "%' order by AccountName asc"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GETProductAutoSearch(ByVal ItemName As String)
        Dim Str As String

        Str = " select distinct AccountName from 	tblaccounts a join POInvoiceMst POIM on a.accountcode=POIM.LedgerAccountCode where accountcode like '0501%' and Accountlevel='Detail' and accountname like '%" & ItemName & "%'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getItemProduct(ByVal ItemName As String) As DataTable
        Dim str As String
        str = " select distinct IP.ItemName,IP.ItemID from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join ItemProduct IP on IP.ItemID=SD.ItemID"
        str &= "  where IP.ItemName='" & ItemName & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getLedgerAccount(ByVal AccountName As String) As DataTable
        Dim str As String
        str = " select distinct IP.accountName,IP.accountcode from POInvoiceMst POIM "
        str &= " join  POInvoicedtl SD on POIM.POInvoiceMstId=SD.POInvoiceMstId"
        str &= " join tblaccounts IP on IP.accountcode=POIM.LedgerAccountCode"
        str &= "  where IP.AccountName='" & AccountName & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function TruncateTempPOcleared()
        Dim str As String = "TRUNCATE TABLE  TempPOcleared"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function InsertTempPOclearedPOData(ByVal StartDate As String, ByVal EndDate As String)
        Dim str As String = "INSERT INTO TempPOcleared select PO.CreationDate as PODate,"
        str &= "  isnull((select Top 1 PORM.PORecvdate from PORecvMaster PORM "
        str &= "  join PORecvDetailTwo PORD on PORD.PORecvMasterID=PORM.PORecvMasterID"
        str &= "  where PORD.PODetailID=POD.PODetailID and PORM.POId=PO.POID order by PORM.PORecvdate DESC),'') as RecvDate"
        str &= "  ,isnull((select Top 1 Pinvm.CreationDate from  POInvoiceMst Pinvm"
        str &= "  join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        str &= "  where Pinvdt.PODetailID=POD.PODetailID order by Pinvm.CreationDate DESC),'') as InvDate"
        str &= " ,PO.PONO,"
        str &= "  isnull((select top 1 PORM.PartyDCNo from PORecvMaster PORM "
        str &= "  join PORecvDetailTwo PORD on PORD.PORecvMasterID=PORM.PORecvMasterID"
        str &= "  where PORD.PODetailID=POD.PODetailID and PORM.POId=PO.POID order by PORM.PORecvdate DESC),'') as DCNo"
        str &= "  ,isnull((select Top 1 Pinvm.VoucherNo from  POInvoiceMst Pinvm"
        str &= "  join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        str &= "  where Pinvdt.PODetailID=POD.PODetailID order by Pinvm.CreationDate DESC),'') as INVNo"
        str &= "  ,POD.Qunatity as  POQTY,"
        str &= "  isnull((select Sum(PORD.RecvQuantity) from PORecvMaster PORM "
        str &= "  join PORecvDetailTwo PORD on PORD.PORecvMasterID=PORM.PORecvMasterID"
        str &= "  where PORD.PODetailID=POD.PODetailID and PORM.POId=PO.POID),0) as RecvQTY"
        str &= "  ,isnull((select sum( Pinvdt.Qunatity) from  POInvoiceMst Pinvm"
        str &= "  join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        str &= "  where Pinvdt.PODetailID=POD.PODetailID),0) as INVQTY"
        str &= "  ,POd.Rate,SD.supplierName as Supplier,"
        str &= "  isnull((select distinct II.ItemType from JobOrDBAccessoriesDetail II"
        str &= "  where POd.JobOrDBAccessoriesDetailID=II.JobOrDBAccessoriesDetailID),'') as  Item"
        '  str &= "   IP.ItemName as Item"
        str &= "  from  POMaster PO"
        str &= "  join  PODetail POd on POD.POId=PO.POID"
        str &= "   join ItemProduct IP on  IP.ItemID=POD.ITEMID "
        str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=POD.AccountPayablePartyID "
        str &= "  where PO.CreationDate >='" & StartDate & "' and  PO.CreationDate <= '" & EndDate & "'"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertTempPOclearedYarnData(ByVal StartDate As String, ByVal EndDate As String)

        Dim str As String = " INSERT INTO TempPOcleared select PO.ContractDate as PODate,"
        str &= "  isnull((select Top 1 PORM.YarnRecvdate from   YarnRecvmaster PORM  "
        str &= "   join YarnRecvDetail PORD on PORD.YarnRecvmasterID=PORM.YarnRecvmasterID"
        str &= "   where PORD.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID"
        str &= "  and PORM.tblyarnPurchaseContractMasterID=PO.tblyarnPurchaseContractMasterID order by PORM.YarnRecvdate desc),'')   as RecvDate,"
        str &= "   isnull((select top 1 Pinvm.CreationDate from  POInvoiceMst Pinvm"
        str &= "    join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        str &= "      where Pinvdt.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID order by Pinvm.CreationDate desc),'') as InvDate"
        str &= "  ,PO.ContractNo as PONO,"
        str &= "  isnull((select Top 1 PORM.PartyDCNo from   YarnRecvmaster PORM  "
        str &= "   join YarnRecvDetail PORD on PORD.YarnRecvmasterID=PORM.YarnRecvmasterID"
        str &= "   where PORD.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID"
        str &= "  and PORM.tblyarnPurchaseContractMasterID=PO.tblyarnPurchaseContractMasterID order by PORM.YarnRecvdate desc),'')   as DCNo,"
        str &= "   isnull((select top 1 Pinvm.VoucherNo from  POInvoiceMst Pinvm"
        str &= "    join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        str &= "     where Pinvdt.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID order by Pinvm.CreationDate desc ),'') as INVNo"
        str &= "   ,POD.KG as  POQTY,"
        str &= "  isnull((select Sum(PORD.ReceivedNetWeightKg) from   YarnRecvmaster PORM  "
        str &= "  join YarnRecvDetail PORD on PORD.YarnRecvmasterID=PORM.YarnRecvmasterID"
        str &= "   where PORD.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID"
        str &= "  and PORM.tblyarnPurchaseContractMasterID=PO.tblyarnPurchaseContractMasterID ),'0')   as RecvQTY"
        str &= "  ,isnull((select sum( Pinvdt.Qunatity) from  POInvoiceMst Pinvm"
        str &= "   join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        str &= "   where Pinvdt.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID),0) as INVQTY"
        str &= "   ,POd.Rate,SD.SupplierName as Supplier,  IP.YarnCount as Item"
        str &= "    from  tblyarnPurchaseContractMaster PO"
        str &= "   join  tblyarnPurchaseContractDetail POd on POD.tblyarnPurchaseContractMasterID=PO.tblyarnPurchaseContractMasterID"
        str &= "    join Yarndatabase IP on  IP.YarndatabaseID=POD.YarndatabaseID "
        str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=POD.SupplierDatabaseID "
        str &= "   where PO.ContractDate >='" & StartDate & "' and  PO.ContractDate <= '" & EndDate & "'"

        'Dim str As String = "INSERT INTO TempPOcleared select PO.ContractDate as PODate,isnull(PORM.YarnRecvdate,'') as RecvDate,"
        'str &= " isnull((select distinct Pinvm.CreationDate from  POInvoiceMst Pinvm"
        'str &= "  join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        'str &= "   where Pinvdt.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID "
        'str &= "  and Pinvdt.YarnRecvDetailID=PORD.YarnRecvDetailID"
        'str &= "  and Pinvdt.YarnRecvmasterID=PORD.YarnRecvmasterID"
        'str &= "  and Pinvdt.tblyarnPurchaseContractDetailID=PORD.tblyarnPurchaseContractDetailID),'') as InvDate"
        'str &= " ,PO.ContractNo as PONO,isnull(PORM.PartyDCNo,'') as DCNo ,"
        'str &= "  isnull((select distinct Pinvm.VoucherNo from  POInvoiceMst Pinvm"
        'str &= "   join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        'str &= "    where Pinvdt.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID "
        'str &= "  and Pinvdt.YarnRecvDetailID=PORD.YarnRecvDetailID"
        'str &= "  and Pinvdt.YarnRecvmasterID=PORD.YarnRecvmasterID"
        'str &= "  and Pinvdt.tblyarnPurchaseContractDetailID=PORD.tblyarnPurchaseContractDetailID),'') as INVNo"
        'str &= " ,POD.KG as  POQTY,isnull(PORD.ReceivedNetWeightKg,'0') as RecvQTY"
        'str &= "  ,isnull((select sum( Pinvdt.Qunatity) from  POInvoiceMst Pinvm"
        'str &= "  join POInvoiceDtl Pinvdt on Pinvm.POInvoiceMstId=Pinvdt.POInvoiceMstId"
        'str &= "  where Pinvdt.tblyarnPurchaseContractDetailID = POD.tblyarnPurchaseContractDetailID"
        'str &= "  and Pinvdt.YarnRecvDetailID=PORD.YarnRecvDetailID"
        'str &= "  and Pinvdt.YarnRecvmasterID=PORD.YarnRecvmasterID"
        'str &= "  and Pinvdt.tblyarnPurchaseContractDetailID=PORD.tblyarnPurchaseContractDetailID),0) as INVQTY"
        'str &= "  ,POd.Rate,SD.SupplierName as Supplier,  IP.YarnCount as Item"
        'str &= "   from  tblyarnPurchaseContractMaster PO"
        'str &= "  join  tblyarnPurchaseContractDetail POd on POD.tblyarnPurchaseContractMasterID=POD.tblyarnPurchaseContractMasterID"
        'str &= "  join Yarndatabase IP on  IP.YarndatabaseID=POD.YarndatabaseID "
        'str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=POD.SupplierDatabaseID "
        'str &= "  left join YarnRecvmaster PORM on PORM.tblyarnPurchaseContractMasterID=PO.tblyarnPurchaseContractMasterID"
        'str &= "  left join YarnRecvDetail PORD on PORD.YarnRecvmasterID=PORM.YarnRecvmasterID"
        'str &= "  and PORD.tblyarnPurchaseContractDetailID=POD.tblyarnPurchaseContractDetailID"
        'str &= "  where PO.ContractDate >='" & StartDate & "' and  PO.ContractDate <= '" & EndDate & "'"

        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function TruncateTempPOOutStandingSummary()
        Dim str As String = "TRUNCATE TABLE  TempPOOutStandingSummary"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function InsertTempPOOutStandingSummary(ByVal StartDate As String, ByVal EndDate As String)
        Dim str As String = "INSERT INTO TempPOOutStandingSummary  select PO.CreationDate as PODate,"
        str &= "  isnull((select Top 1 PORM.PORecvdate from PORecvMaster PORM  "
        str &= "  join PORecvDetailTwo PORD on PORD.PORecvMasterID=PORM.PORecvMasterID  "
        str &= "  where PORD.PODetailID=POD.PODetailID and PORM.POId=PO.POID order by PORM.PORecvdate DESC),'') as RecvDate "
        str &= "  ,PO.PONO,j.JoborderNo, "
        str &= "  isnull((select top 1 PORM.PartyDCNo from PORecvMaster PORM  "
        str &= "  join PORecvDetailTwo PORD on PORD.PORecvMasterID=PORM.PORecvMasterID "
        str &= "  where PORD.PODetailID=POD.PODetailID and PORM.POId=PO.POID order by PORM.PORecvdate DESC),'') as DCNo "
        str &= "  ,POD.Qunatity as  POQTY, Ims.Symbol as Per,"
        str &= "  isnull((select Sum(PORD.RecvQuantity) from PORecvMaster PORM  "
        str &= "  join PORecvDetailTwo PORD on PORD.PORecvMasterID=PORM.PORecvMasterID "
        str &= "  where PORD.PODetailID=POD.PODetailID and PORM.POId=PO.POID),0) as RecvQTY "
        str &= "  ,POd.Rate,SD.supplierName as Supplier, "
        str &= "  isnull((select distinct II.ItemType from JobOrDBAccessoriesDetail II"
        str &= "  where POd.JobOrDBAccessoriesDetailID=II.JobOrDBAccessoriesDetailID),'') as  Item "
        str &= "  from  POMaster PO  "
        str &= "  join  PODetail POd on POD.POId=PO.POID  "
        str &= "  join ItemProduct IP on  IP.ItemID=POD.ITEMID  "
        str &= "  join IMSItemUnit Ims on Ims.ItemUnitId=IP.ItemUnitId"
        str &= "  join JobOrDBAccessoriesDetail Jod on Jod.JobOrDBAccessoriesDetailID=POD.JobOrDBAccessoriesDetailID  "
        str &= "  join joborderdatabase j on j.joborderid=Jod.joborderid"
        str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=POD.AccountPayablePartyID   "
        str &= "  where PO.CreationDate >='" & StartDate & "' and  PO.CreationDate <= '" & EndDate & "'"
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception
        End Try
    End Function

End Class
