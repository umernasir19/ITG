Imports Microsoft.VisualBasic
Imports System.Data
Public Class ContraVoucherMst

    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ContraVoucherMst"
        m_strPrimaryFieldName = "ContraVoucherMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lContraVoucherMstID As Long
    Private m_dContraPaymentDate As Date
    Private m_strAccountCode As String
    Private m_strAccount As String
    Private m_strContraNo As String
    Private m_strChkNo As String
    Private m_strDrCr As String
   

    Public Property ContraVoucherMstID() As Long
        Get
            ContraVoucherMstID = m_lContraVoucherMstID
        End Get
        Set(ByVal Value As Long)
            m_lContraVoucherMstID = Value
        End Set
    End Property
    Public Property ContraPaymentDate() As Date
        Get
            ContraPaymentDate = m_dContraPaymentDate
        End Get
        Set(ByVal Value As Date)
            m_dContraPaymentDate = Value
        End Set
    End Property
    
    Public Property AccountCode() As String
        Get
            AccountCode = m_strAccountCode
        End Get
        Set(ByVal Value As String)
            m_strAccountCode = Value
        End Set
    End Property
    Private m_bChkDate As Boolean
    Public Property ChkDate() As Boolean
        Get
            ChkDate = m_bChkDate
        End Get
        Set(ByVal Value As Boolean)
            m_bChkDate = Value
        End Set
    End Property
    Public Property Account() As String
        Get
            Account = m_strAccount
        End Get
        Set(ByVal Value As String)
            m_strAccount = Value
        End Set
    End Property
    Public Property ContraNo() As String
        Get
            ContraNo = m_strContraNo
        End Get
        Set(ByVal Value As String)
            m_strContraNo = Value
        End Set
    End Property
   
    Public Property ChkNo() As String
        Get
            ChkNo = m_strChkNo
        End Get
        Set(ByVal Value As String)
            m_strChkNo = Value
        End Set
    End Property
    Public Property DrCr() As String
        Get
            DrCr = m_strDrCr
        End Get
        Set(ByVal Value As String)
            m_strDrCr = Value
        End Set
    End Property
    Public Function Save()
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
    Public Function BookAccountName()
        Dim str As String
        str = " select * from tblAccounts where GroupAct in('0102005' ,'0102004') "
        str &= " and AccountLevel ='Detail'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetLastVoucherNo(ByVal Month As Integer, ByVal year As Integer)
        Dim str As String
        ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
        str = " select Top 1 ContraNo from ContraVoucherMst where month(ContraPaymentDate)='" & Month & "' and year(ContraPaymentDate)='" & year & "' order By ContraVoucherMstID DESC"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetView() As DataTable
        Dim str As String
        str = " Select *,convert(varchar,ContraPaymentDate,103)as ContraPaymentDatee  from ContraVoucherMst order by ContraVoucherMstID desc "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetViewNew(ByVal FirstYear As String, ByVal SecondYear As String) As DataTable
        Dim str As String
        str = " Select *,convert(varchar,ContraPaymentDate,103)as ContraPaymentDatee  from ContraVoucherMst where ContraPaymentDate between '" & FirstYear & "' and '" & SecondYear & "' order by ContraVoucherMstID desc "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetEdit(ByVal ContraVoucherMstID As Long) As DataTable
        Dim str As String
        str = " select * from ContraVoucherMst DM "
        str &= " join  ContraVoucherDtl cd on cd.ContraVoucherMstID =DM.ContraVoucherMstID "
        str &= " join  CostCenter c on c.CostCenterID = cd.CostCenterID "
        str &= " where DM.ContraVoucherMstID='" & ContraVoucherMstID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetUniqueAccountName(ByVal AccountName As String)
        Dim str As String
        'str = " Select * from tblAccounts where AccountName ='" & AccountName & "' "
        str = " Select * from tblAccounts where AccountName ='" & AccountName & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetUniqueCostCenter(ByVal Cost As String)
        Dim str As String
        'str = " Select * from tblAccounts where AccountName ='" & AccountName & "' "
        str = " select * from CostCenter where Cost ='" & Cost & "' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
