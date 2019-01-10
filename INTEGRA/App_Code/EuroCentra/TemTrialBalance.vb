Imports Microsoft.VisualBasic
Imports System.Data
Namespace eurocentra
    Public Class TemTrialBalance
        Inherits SQLManager

        Dim m_dCreditContra As Decimal

        Public Sub New()
            m_strTableName = "TemTrialBalance"
            m_strPrimaryFieldName = "TempTrialID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempTrialID As Long
        Private m_strAccountcode As String
        Private m_dDebitBPV As Decimal
        Private m_dCreditBPV As Decimal
        Private m_dJVDebit As Decimal
        Private m_dJVCredit As Decimal
        Private m_dDebitCV As Decimal
        Private m_dCreditCV As Decimal
        Private m_dDebitPV As Decimal
        Private m_dCreditPV As Decimal 
        Private m_dOB As Decimal
        Private m_dDebitContra As Decimal
        Private m_dOBCR As Decimal
         

        Public Property TempTrialID() As Long
            Get
                TempTrialID = m_lTempTrialID
            End Get
            Set(ByVal Value As Long)
                m_lTempTrialID = Value
            End Set
        End Property
        Public Property Accountcode() As String
            Get
                Accountcode = m_strAccountcode
            End Get
            Set(ByVal Value As String)
                m_strAccountcode = Value
            End Set
        End Property
        Public Property DebitBPV() As Decimal
            Get
                DebitBPV = m_dDebitBPV
            End Get
            Set(ByVal Value As Decimal)
                m_dDebitBPV = Value
            End Set
        End Property
        Public Property CreditBPV() As Decimal
            Get
                CreditBPV = m_dCreditBPV
            End Get
            Set(ByVal Value As Decimal)
                m_dCreditBPV = Value
            End Set
        End Property
        Public Property JVDebit() As Decimal
            Get
                JVDebit = m_dJVDebit
            End Get
            Set(ByVal Value As Decimal)
                m_dJVDebit = Value
            End Set
        End Property
        Public Property JVCredit() As Decimal
            Get
                JVCredit = m_dJVCredit
            End Get
            Set(ByVal Value As Decimal)
                m_dJVCredit = Value
            End Set
        End Property
        Public Property DebitCV() As Decimal
            Get
                DebitCV = m_dDebitCV
            End Get
            Set(ByVal Value As Decimal)
                m_dDebitCV = Value
            End Set
        End Property
        Public Property CreditCV() As Decimal
            Get
                CreditCV = m_dCreditCV
            End Get
            Set(ByVal Value As Decimal)
                m_dCreditCV = Value
            End Set
        End Property
        Public Property DebitPV() As Decimal
            Get
                DebitPV = m_dDebitPV
            End Get
            Set(ByVal Value As Decimal)
                m_dDebitPV = Value
            End Set
        End Property
        Public Property CreditPV() As Decimal
            Get
                CreditPV = m_dCreditPV
            End Get
            Set(ByVal Value As Decimal)
                m_dCreditPV = Value
            End Set
        End Property
        Public Property DebitContra() As Decimal
            Get
                DebitContra = m_dDebitContra
            End Get
            Set(ByVal Value As Decimal)
                m_dDebitContra = Value
            End Set
        End Property
        Public Property CreditContra() As Decimal
            Get
                CreditContra = m_dCreditContra
            End Get
            Set(ByVal Value As Decimal)
                m_dCreditContra = Value
            End Set
        End Property
        Public Property OB() As Decimal
            Get
                OB = m_dOB
            End Get
            Set(ByVal Value As Decimal)
                m_dOB = Value
            End Set
        End Property
        Public Property OBCR() As Decimal
            Get
                OBCR = m_dOBCR
            End Get
            Set(ByVal Value As Decimal)
                m_dOBCR = Value
            End Set
        End Property

        Public Function SaveTemTrialBalance()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllAccounts()
            Dim str As String
            str = " Select * from tblAccounts "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '---BPV
        Public Function GetSumDebitBPV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitBPV from tblBankdtl TBD"
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditBPV from tblBankdtl TBD"
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        '----- PV
        Public Function GetSumDebitPV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Debit) ,0.00)  as DebitPV from tblPVdtl TBD"
            str &= " join tblPVmst TBM on TBM.tblPVMstID=TBD.tblPVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditPV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Credit) ,0.00)  as CreditPV from tblPVdtl TBD"
            str &= " join tblPVmst TBM on TBM.tblPVMstID=TBD.tblPVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        '----- CV
        Public Function GetSumDebitCPV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitCPV from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditCPV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditCPV from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        '----- JV
        Public Function GetSumDebitJV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Debit) ,0.00)  as DebitJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and Convert(varchar, TBM.voucherdate, 103) between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditJV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Credit) ,0.00)  as CreditJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and Convert(varchar, TBM.voucherdate, 103) between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetOB(ByVal AccountCode As String, ByVal FiscalYear As String)
            Dim str As String
            str = " select isnull(OpeningBalance,0) as OpeningBalance from tblOpeningBalance O"
            str &= " where O.AccountCode='" & AccountCode & "' and O.FiscalYear='" & FiscalYear & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        '---BPV
        Public Function GetSumDebitBPVBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitBPV from tblBankdtl TBD"
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditBPV from tblBankdtl TBD"
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        '----- Bank PV
        Public Function GetSumDebitPVBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Debit) ,0.00) as DebitPV from tblPVdtl TBD"
            str &= " join tblPVmst TBM on TBM.tblPVMstID=TBD.tblPVMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditPVBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Credit) ,0.00)  as CreditPV from tblPVdtl TBD"
            str &= " join tblPVmst TBM on TBM.tblPVMstID=TBD.tblPVMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        '----- Bank CV
        Public Function GetSumDebitCPVBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitCPV from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditCPVBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditCPV from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by TBD.Type"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAccountCodetTB(ByVal ACCOUNTCODE As String) As DataTable
            Dim str As String
            ' str = " select distinct BookAccount from tblBankMst "
            str = " Select * from tblAccounts WHERE AccountCode='" & ACCOUNTCODE & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetNAmeForTBNotin2(ByVal Accountcode As String)
            Dim str As String
            str = "  select * from tblaccounts a"
            str &= " left join TemTrialBalance o  on a.accountcode=o.accountcode "
            str &= " where  a.groupact = '" & Accountcode & "' and a.actleveldigit not in (1,2)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditCV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditCPVOB from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate <  '" & Startdate & "'   "
            str &= " group by TBD.Type"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitCPVMaster(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select Case When TBM.VoucherType = 'P' Then isnull(sum(TBD.Amount),0) Else 0 End as DebitCPV from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '  "
            str &= " group by TBM.VoucherType"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitCVMaster(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select Case When TBM.VoucherType = 'P' Then isnull(sum(TBD.Amount),0) Else 0 End  as DebitCPVOB from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate <  '" & Startdate & "'   "
            str &= " group by TBM.VoucherType"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetSumDebitContra(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Amount),0.00)  as DebitContra from ContraVoucherMst TBM"
            str &= " join ContraVoucherDtl TBD on TBM.ContraVoucherMstID=TBD.ContraVoucherMstID"
            str &= " where TBM.AccountCode='" & AccountCode & "'"
            str &= " and TBM.ContraPaymentDate between '" & Startdate & "' and '" & Enddate & " '  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditCVMaster(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select Case When TBM.VoucherType = 'R' Then isnull(sum(TBD.Amount),0) Else 0 End as CreditCPVOB from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate <  '" & Startdate & "'  "
            str &= " group by TBM.VoucherType"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitCV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitCPVOB from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate <  '" & Startdate & "' "
            str &= " group by TBD.Type"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQTYForTBNotin2(ByVal Accountcode As String)
            Dim str As String
            str = "  select o.Accountcode,a.AccountName ,(isnull(Sum(o.DebitBPV),0)+isnull(Sum(o.JVDebit),0)+isnull(Sum(o.DebitPV),0)+isnull(Sum(o.DebitCV),0)+isnull(Sum(o.DebitContra),0)) as DB"
            str &= " ,(isnull(Sum(o.CreditBPV),0)+isnull(Sum(o.JVCredit),0)+isnull(Sum(o.CreditCV),0)+isnull(Sum(o.CreditPV),0)+isnull(Sum(o.CreditContra),0)) as CR"
            str &= " ,(isnull(Sum(o.OB),0)-isnull(Sum(o.OBCR),0)) as OB"
            str &= " from tblaccounts  a"
            str &= " left join TemTrialBalance o on a.accountcode=o.accountcode"
            str &= " where  a.accountcode like '" & Accountcode & "%' and a.actleveldigit not in (1,2)"
            str &= " group by o.Accountcode,a.AccountName"
            str &= " order by o.Accountcode asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditContraOB(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select isnull(sum(Amount),0.00)  as CreditContraOB from ContraVoucherMst TBM"
            str &= " join ContraVoucherDtl TBD on TBM.ContraVoucherMstID=TBD.ContraVoucherMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.ContraPaymentDate < '" & Startdate & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditCPVMaster(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select Case When TBM.VoucherType = 'R' Then isnull(sum(TBD.Amount),0) Else 0 End  as CreditCPV from tblCashDtl TBD"
            str &= " join tblCashmst TBM on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " where TBM.BookAccount='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '  "
            str &= " group by TBM.VoucherType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitContraOB(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select isnull(sum(Amount),0.00)  as DebitContraOB from ContraVoucherMst TBM"
            str &= " join ContraVoucherDtl TBD on TBM.ContraVoucherMstID=TBD.ContraVoucherMstID"
            str &= " where TBM.AccountCode='" & AccountCode & "'"
            str &= " and TBM.ContraPaymentDate < '" & Startdate & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditContra(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Amount),0.00)  as CreditContra from ContraVoucherMst TBM"
            str &= " join ContraVoucherDtl TBD on TBM.ContraVoucherMstID=TBD.ContraVoucherMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.ContraPaymentDate between '" & Startdate & "' and '" & Enddate & " '  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAllAccountsNew()
            Dim str As String
            str = " Select distinct isnull(Opening_Debit,0) as Opening_Debit,isnull(Opening_Credit,0) as Opening_Credit,AccountCode from tblAccounts  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitBPVNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
           
            str = " select  isnull(Case When TBD.Type = 'D' and TBD.Amount>0 Then TBD.Amount "
            str &= "   When TBD.Type = 'C' and TBD.Amount<0 then  -1*TBD.Amount Else 0 End,0.00) As DebitBPV"
            str &= " from tblBankdtl TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and  Convert(varchar,TBM.voucherdate, 103) between  '" & Startdate & "' and '" & Enddate & " '"
            Try


                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitBPV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
           
            str = " select  isnull(Case When TBD.Type = 'D' and TBD.Amount>0 Then TBD.Amount "
            str &= "   When TBD.Type = 'C' and TBD.Amount<0 then  -1*TBD.Amount Else 0 End,0.00) As DebitBPV"
            str &= " from tblBankdtl TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and Convert(varchar,TBM.voucherdate, 103) <  '" & Startdate & "' "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            
            str = "  select    isnull(Case When TBD.Type = 'C' and (TBD.Amount)>0 then TBD.Amount "
            str &= "   When TBD.Type = 'D' and (TBD.Amount)<0 THEN -1*TBD.Amount else 0 end,0.00) as CreditBPV "
            str &= " from tblBankdtl TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID "
            str &= "  where TBD.AccountCode='" & AccountCode & "'"
            str &= "  and Convert(varchar,TBM.voucherdate, 103) between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditBPV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
           

            str = "  select    isnull(Case When TBD.Type = 'C' and (TBD.Amount)>0 then TBD.Amount "
            str &= "   When TBD.Type = 'D' and (TBD.Amount)<0 THEN -1*TBD.Amount else 0 end,0.00) as CreditBPV "
            str &= " from tblBankdtl TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID "
            str &= "  where TBD.AccountCode='" & AccountCode & "'"
            str &= "  and Convert(varchar,TBM.voucherdate, 103) < '" & Startdate & "'  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVMasterNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String


            str = "  select    Case When a.VoucherType = 'P' Then isnull(sum(a.TotalAmount),0) Else 0 End As DebitBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= " where   a.BookAccount='" & AccountCode & "'"
            str &= " and Convert(varchar, a.voucherdate, 103) between '" & Startdate & "' and '" & Enddate & " '"
            str &= " group by a.VoucherType"
            Try

                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditBPVMaster(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            

            str = "  select    Case When a.VoucherType = 'P' Then isnull(sum(a.TotalAmount),0) Else 0 End As DebitBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= " where   a.BookAccount='" & AccountCode & "'"
            str &= " and Convert(varchar, a.voucherdate, 103) < '" & Startdate & "'  "
            str &= " group by a.VoucherType"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitBPVMasterNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
          
            str = "  select  Case When a.VoucherType = 'R' Then isnull(sum(a.TotalAmount),0) Else 0 End As CreditBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= "  where   a.BookAccount='" & AccountCode & "'"
            str &= "  and  a.VoucherType = 'R'"
            str &= "  and Convert(varchar, a.voucherdate, 103) between '" & Startdate & "' and '" & Enddate & " '"
            str &= "  group by a.VoucherType"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitBPVMaster(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
           

            str = "  select  Case When a.VoucherType = 'R' Then isnull(sum(a.TotalAmount),0) Else 0 End As CreditBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= "  where   a.BookAccount='" & AccountCode & "'"
            str &= "  and  a.VoucherType = 'R'"
            str &= "  and Convert(varchar, a.voucherdate, 103) < '" & Startdate & "'  "
            str &= "  group by a.VoucherType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitJV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            
            str = " select isnull(sum(Debit) ,0.00)  as DebitJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and Convert(varchar, TBM.voucherdate, 103) < '" & Startdate & "'  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditJV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
          
            str = " select isnull(sum(Credit) ,0.00)  as CreditJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and Convert(varchar, TBM.voucherdate, 103) < '" & Startdate & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOBNew(ByVal AccountCode As String)
            Dim str As String
            str = "  select isnull(op.Opening_Debit,0) as Opening_Debit,"
            str &= " isnull(op.Opening_Credit,0) as Opening_Credit"
            str &= " from tblaccounts  a"
            str &= " left join tblOpeningBal op on op.Accountcode=a.Accountcode where  a.AccountLevel='Detail' and a.AccountCode='" & AccountCode & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBPVData()
            Dim str As String
            str = "    select a.tblBankMstID,a.VoucherNo ,a.VoucherType ,a.TotalAmount,						"
            str &= " (select Sum(aa.Amount) from  						"
            str &= "  tblBankDtl aa where a.tblBankMstID =aa.tblBankMstID) Amountdtl from tblBankMst a						"
            str &= " where a.TotalAmount<>						"
            str &= " (select Sum(aa.Amount) from 			"
            str &= " tblBankDtl aa where a.tblBankMstID =aa.tblBankMstID)						"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateTblBankMstGetBPVData(ByVal tblBankMstID As Long, ByVal Amount As Decimal)
            Dim str As String
            str = "    update tblBankMst set TotalAmount='" & Amount & "' where tblBankMstID='" & tblBankMstID & "'					"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

