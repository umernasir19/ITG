Imports System.Data
Imports Microsoft.VisualBasic
Public Class InvoiceMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "tblInvoiceMst"
        m_strPrimaryFieldName = "InvoiceMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lInvoiceMstID As Long
    Private m_lSupplierID As Long
    Private m_strInvoiceNo As String
    Private m_dInvoiceDate As Date
    Private m_dPayableAmount As Decimal
    Private m_dAdjustedAmount As Decimal
    Private m_dBalanceAmount As Decimal
    Private m_strRemarks As String
    Private m_strStatus As String
    Public Property InvoiceMstID() As Long
        Get
            InvoiceMstID = m_lInvoiceMstID
        End Get
        Set(ByVal value As Long)
            m_lInvoiceMstID = value
        End Set
    End Property
    Public Property SupplierID() As Long
        Get
            SupplierID = m_lSupplierID
        End Get
        Set(ByVal value As Long)
            m_lSupplierID = value
        End Set
    End Property
    Public Property InvoiceNo() As String
        Get
            InvoiceNo = m_strInvoiceNo
        End Get
        Set(ByVal value As String)
            m_strInvoiceNo = value
        End Set
    End Property
    Public Property InvoiceDate() As Date
        Get
            InvoiceDate = m_dInvoiceDate
        End Get
        Set(ByVal value As Date)
            m_dInvoiceDate = value
        End Set
    End Property

    Public Property PayableAmount() As Decimal
        Get
            PayableAmount = m_dPayableAmount
        End Get
        Set(ByVal value As Decimal)
            m_dPayableAmount = value
        End Set
    End Property
    Public Property AdjustedAmount() As Decimal
        Get
            AdjustedAmount = m_dAdjustedAmount
        End Get
        Set(ByVal value As Decimal)
            m_dAdjustedAmount = value
        End Set
    End Property
    Public Property BalanceAmount() As Decimal
        Get
            BalanceAmount = m_dBalanceAmount
        End Get
        Set(ByVal value As Decimal)
            m_dBalanceAmount = value
        End Set
    End Property
    
    Public Property Remarks() As String
        Get
            Remarks = m_strRemarks
        End Get
        Set(ByVal value As String)
            m_strRemarks = value
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
    Public Function SaveInvoiceMst()
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
    ' ''Temp 
    'Public Function GetSupplier() As DataTable
    '    Dim str As String

    '    str = "select * from Supplier "
    '    Try
    '        Return MyBase.GetDataTable(str)
    '    Catch ex As Exception

    '    End Try
    'End Function
    Public Function GetInvoice()
        Dim str As String
        str = "select * from tblinvoicemst "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function View() As DataTable
        Dim str As String
        str = "select *,convert(varchar,TIM.InvoiceDate,103) as InvoiceDatee from tblinvoicemst TIM "
        str &= " join tblinvoiceDTL TID on TIM.InvoiceMstID = TID.InvoiceMstID "
        str &= " join SupplierDatabase S on S.SupplierDatabaseId= TIM.SupplierID  "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetForEdit(ByVal InvoiceMstID As Long) As DataTable
        Dim str As String
        str = "select *,convert(varchar,TIM.InvoiceDate,103) as InvoiceDatee from tblinvoicemst TIM "
        str &= " join tblinvoiceDTL TID on TIM.InvoiceMstID = TID.InvoiceMstID "
        str &= " join supplier S on S.SupplierID= TIM.SupplierID "
        str &= " where TIM.InvoiceMstID='" & InvoiceMstID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GettblInvoiceMstDataForPopUp(ByVal SupplierName As String) As DataTable
        Dim str As String

        'str = "select TIM.*,convert(varchar,TIM.InvoiceDate,103) as InvoiceDatee from tblInvoiceMst TIM"
        'str = "select *,convert(varchar,TIM.InvoiceDate,103) as InvoiceDatee from tblinvoicemst TIM "
        'str &= " join tblinvoiceDTL TID on TIM.InvoiceMstID = TID.InvoiceMstID "
        'str &= " join SupplierDatabase S on S.SupplierDatabaseId= TIM.SupplierID  "
        'str &= " where TIM.InvoiceMstID='" & InvoiceMstID & "' "
        str = "select  *,convert(varchar,TIM.InvoiceDate,103) as InvoiceDatee "
        str &= " from tblinvoicemst TIM join tblinvoiceDTL TID on TIM.InvoiceMstID = TID.InvoiceMstID "
        str &= " join SupplierDatabase S on S.SupplierDatabaseId= TIM.SupplierID  "
        str &= " join tblAccounts A on A.AccountName = S.SupplierName "
        str &= " join tblBankDtl TBD on TBD.AccountCode = A.AccountCode  "
        str &= " join tblBankMst TDM on TBD.tblBankMstID = TDM.tblBankMstID  "
        str &= " where S.SupplierName ='" & SupplierName & "' and InvoiceType ='Adjust Invoice' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GettblInvoiceMst(ByVal SupplierName As String, ByVal POInvoiceMasterID As Long) As DataTable
        Dim str As String
        str = " select PIM.POInvoiceMasterID as InvoiceMstID,PIM.AccountPayable as SupplierName ,"
        str &= " PIM.SaleTaxInvoiceNo as InvoiceNo,convert(varchar,PIM.CreationDate,103) as InvoiceDatee,"
        str &= " (select Sum(NetAmount) from POInvoiceDetail where POInvoiceMasterID=PIM.POInvoiceMasterID) as PayableAmount"
        str &= " , (select Sum(AdjustedAmount) from POInvoiceAdjDetail where POInvoiceMasterID=PIM.POInvoiceMasterID) as TotalAdjustAmount,"
        str &= " (select Sum(NetAmount) from POInvoiceDetail where POInvoiceMasterID=PIM.POInvoiceMasterID)-"
        str &= "  (select Sum(AdjustedAmount) from POInvoiceAdjDetail where POInvoiceMasterID=PIM.POInvoiceMasterID) as RemainingAdjustAmount"
        str &= "  from POInvoiceMaster PIM"
        str &= " where PIM.AccountPayable ='" & SupplierName & "' and PIM.POInvoiceMasterID='" & POInvoiceMasterID & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    'Get supplier after saving it exist or not
    Public Function SupplierAfterSavingItExistOrNot(ByVal SupplierName As Long) As DataTable
        Dim str As String

        str = "select AccountName from tblAccounts where AccountName= ("
        str &= " select S.SupplierName from tblInvoiceMst IM join SupplierDatabase S on S.SupplierDatabaseId= IM.InvoiceMstID  "
        str &= " join SupplierDatabase S on S.SupplierDatabaseId= TIM.SupplierID  "
        str &= " where S.SupplierName ='" & SupplierName & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getInvoiceMstForLabelShow(ByVal InvoiceMstID As Long, ByVal SupplierName As String) As DataTable
        Dim str As String

        str = " select *,PODA.POInvoiceAdjDetailID as InvoiceDtlID,PO.POInvoiceMasterID as InvoiceMstID,convert(varchar,PODA.Creationdate,(103)) as InvoiceDatee ,PO.SaleTaxInvoiceNo as InvoiceNo from POInvoiceMaster PO"
        str &= " join POInvoiceAdjDetail  PODA on PODA.POInvoiceMasterID=PO.POInvoiceMasterID"
        str &= " join SupplierDatabase SDB on SDB.SupplierDatabaseID=SupplierID "
        str &= "  where  SDB.supplierName='" & SupplierName & "' and PODA.POInvoiceMasterID='" & InvoiceMstID & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    ''' <summary>
    ''' ''''''''''''
    ''' </summary>
    ''' <param name="AccountName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getInvoiceMstForAdjustButton(ByVal AccountName As String) As DataTable
        Dim str As String

        'str = " select convert(varchar,TBM.VoucherDate,103) as VoucherDatee,* from tblBankMst  TBM join tblBankDtl TBD on TBM.tblBankMstID = TBD.tblBankMstID "
        'str &= " join tblAccounts A on A.AccountCode = TBD.AccountCode  join SupplierDatabase S on S.SupplierName= A.AccountName "
        'str &= " join tblInvoiceMst TIM on TIM.SupplierID = S.SupplierDatabaseId  join tblInvoiceDtl TID on TID.InvoiceMstID = TIM.InvoiceMstID "
        'str &= " where A.AccountName ='" & AccountName & "' and InvoiceType='Adjust Invoice'"
        str = " select convert(varchar,TBM.VoucherDate,103) as VoucherDatee,* from tblBankMst  TBM join tblBankDtl TBD on TBM.tblBankMstID = TBD.tblBankMstID "
        str &= " join tblAccounts A on A.AccountCode = TBD.AccountCode  join SupplierDatabase S on S.SupplierName= A.AccountName "
        str &= " join tblInvoiceMst TIM on TIM.SupplierID = S.SupplierDatabaseId  join tblInvoiceDtl TID on TID.InvoiceMstID = TIM.InvoiceMstID "
        str &= " where A.AccountName ='" & AccountName & "'  "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetSupplierForPopUp() As DataTable
        Dim str As String

        ''str = "select TIM.* from tblInvoiceMst TIM"
        str = "select distinct(SupplierName)  from tblinvoicemst"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetInvoiceBySupplierForPopUp(ByVal Invoice As String) As DataTable
        Dim str As String

        str = "select * from tblinvoicemst WHERE SupplierName = '" & Invoice & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GettblInvoiceMstForBindGridForPopUp(ByVal Invoice As String) As DataTable
        Dim str As String

        str = "select * from tblinvoicemst WHERE InvoiceNo = '" & Invoice & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function


End Class
