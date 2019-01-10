Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class BankTransaction
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BankTransaction"
            m_strPrimaryFieldName = "BankTransactionID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lBankTransactionID As Long
        Private m_dtTransactionDate As Date
        Private m_strTranscationType As String
        Private m_dtCreationDate As Date
        Private m_strCurrency As String
        Private m_dDeduction As Decimal
        Private m_strIsTaxable As Boolean
        Private m_lDeductionChartofAccountID As Long
        Private m_dDeductionTotalAmount As Decimal
        Private m_strTaxChequeNo As String
        Private m_dTotalSumAmount As Decimal
        Public Property BankTransactionID() As Long
            Get
                BankTransactionID = m_lBankTransactionID
            End Get
            Set(ByVal value As Long)
                m_lBankTransactionID = value
            End Set
        End Property
        Public Property TransactionDate() As Date
            Get
                TransactionDate = m_dtTransactionDate
            End Get
            Set(ByVal value As Date)
                m_dtTransactionDate = value
            End Set
        End Property
        Public Property TranscationType() As String
            Get
                TranscationType = m_strTranscationType
            End Get
            Set(ByVal value As String)
                m_strTranscationType = value
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
        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal value As String)
                m_strCurrency = value
            End Set
        End Property
        Public Property Deduction() As Decimal
            Get
                Deduction = m_dDeduction
            End Get
            Set(ByVal value As Decimal)
                m_dDeduction = value
            End Set
        End Property
        Public Property IsTaxable() As Boolean
            Get
                IsTaxable = m_strIsTaxable
            End Get
            Set(ByVal value As Boolean)
                m_strIsTaxable = value
            End Set
        End Property
        Public Property DeductionChartofAccountID() As Long
            Get
                DeductionChartofAccountID = m_lDeductionChartofAccountID
            End Get
            Set(ByVal value As Long)
                m_lDeductionChartofAccountID = value
            End Set
        End Property
        Public Property DeductionTotalAmount() As Decimal
            Get
                DeductionTotalAmount = m_dDeductionTotalAmount
            End Get
            Set(ByVal value As Decimal)
                m_dDeductionTotalAmount = value
            End Set
        End Property
        Public Property TaxChequeNo() As String
            Get
                TaxChequeNo = m_strTaxChequeNo
            End Get
            Set(ByVal value As String)
                m_strTaxChequeNo = value
            End Set
        End Property
        Public Property TotalSumAmount() As Decimal
            Get
                TotalSumAmount = m_dTotalSumAmount
            End Get
            Set(ByVal value As Decimal)
                m_dTotalSumAmount = value
            End Set
        End Property
        Public Function SaveBankTransaction()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetData(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = "   select BT.BankTransactionID,BT.TranscationType,BT.IsTaxable, BTD.ChequeNo ,left( DATENAME(Month, BT.TransactionDate),3) as month, Convert(varchar,BT.TransactionDate,106) as Date"
            str &= "  , (case when cast( BT.BankTransactionID as varchar(4000)) > 0 and cast( BT.BankTransactionID as varchar(4000)) <= 9 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '00000'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  when cast( BT.BankTransactionID as varchar(4000)) >= 10 and cast( BT.BankTransactionID as varchar(4000)) <= 99 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '0000'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  when cast( BT.BankTransactionID as varchar(4000)) >= 100 and cast( BT.BankTransactionID as varchar(4000)) <= 999 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '000'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  when cast( BT.BankTransactionID as varchar(4000))>= 1000 and cast( BT.BankTransactionID as varchar(4000)) <= 9999 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '00'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  when cast( BT.BankTransactionID as varchar(4000)) >= 10000 and cast( BT.BankTransactionID as varchar(4000)) <= 99999 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '0'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  else"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-' + cast( BT.BankTransactionID as varchar(4000)) end) as VoucherNo"
            str &= "  ,BTD.Narration as Particulars , BTD.Amount , COA.AccountType as AccountsHead"
            str &= "  , NameOfPayee as Payee ,HKCode as HKAnalysisCode,ECPCode as ECPAnalysisCode"
            str &= "  from BankTransaction BT"
            str &= "  join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= "  join ChartofAccount COA on COA.ChartofAccountID=BTD.ChartofAccountID  "
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMasterData(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = "  select BT.BankTransactionID,BT.TranscationType,BT.IsTaxable,"
            str &= "  (Select distinct top 1 BTD.ChequeNo  from BankTransactionDetail BTD where BT.BankTransactionID =BTD.BankTransactionID  )as ChequeNo"
            str &= "  ,left( DATENAME(Month, BT.TransactionDate),3) as month, Convert(varchar,BT.TransactionDate,106) as Date"
            str &= "  , (case when cast( BT.BankTransactionID as varchar(4000)) > 0 and cast( BT.BankTransactionID as varchar(4000)) <= 9 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '00000'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "   when cast( BT.BankTransactionID as varchar(4000)) >= 10 and cast( BT.BankTransactionID as varchar(4000)) <= 99 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '0000'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "   when cast( BT.BankTransactionID as varchar(4000)) >= 100 and cast( BT.BankTransactionID as varchar(4000)) <= 999 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '000'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  when cast( BT.BankTransactionID as varchar(4000))>= 1000 and cast( BT.BankTransactionID as varchar(4000)) <= 9999 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '00'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  when cast( BT.BankTransactionID as varchar(4000)) >= 10000 and cast( BT.BankTransactionID as varchar(4000)) <= 99999 then"
            str &= "  convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-'+ '0'+ cast( BT.BankTransactionID as varchar(4000))"
            str &= "  else"
            str &= "   convert(varchar,cast( BT.TranscationType as varchar(4000)))+ '-' + cast( BT.BankTransactionID as varchar(4000)) end) as VoucherNo"
            str &= "  , (Select abs(SUM(Amount)) from BankTransactionDetail BTD where BT.BankTransactionID =BTD.BankTransactionID) as Amount "
            str &= "  , (Select  Top 1 BT.DeductionTotalAmount from BankTransactionDetail BTD where BT.BankTransactionID =BTD.BankTransactionID) as TaxAmount "
            str &= "  , (Select abs(SUM(Amount)- BT.DeductionTotalAmount) from BankTransactionDetail BTD where BT.BankTransactionID =BTD.BankTransactionID) as TotalAmount "
            str &= "  ,(Select top 1 COA.AccountType from BankTransactionDetail BTD"
            str &= "  join ChartofAccount COA on COA.ChartofAccountID=BTD.ChartofAccountID  "
            str &= "  where BT.BankTransactionID =BTD.BankTransactionID) as AccountsHead "
            str &= "   ,(Select distinct top 1 BTD.NameOfPayee  from BankTransactionDetail BTD where BT.BankTransactionID =BTD.BankTransactionID  )as Payee"
            str &= "  , (Select  Top 1 BT.TaxChequeNo from BankTransactionDetail BTD where BT.BankTransactionID =BTD.BankTransactionID) as TaxChequeNo"
            str &= "  from BankTransaction BT"
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMonthYear()
            Dim str As String
            str = "  select distinct left( DATENAME(Month, Bt.TransactionDate),3)+ ','+ "
            str &= "  convert(varchar,year(Bt.TransactionDate)) as MonthYear, "
            str &= "  Month(Bt.TransactionDate) as Monthh "
            str &= "   from BankTransaction Bt "
            str &= "  order by Month(Bt.TransactionDate) ASC  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBalanceCF(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = " select  Top 1 isnull(BT.TotalSumAmount,0) as BalanceCF   from BankTransaction BT "
            str &= "  join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            str &= "  and BT.TotalSumAmount > 0  order by BT.BankTransactionID ASC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Getbank(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str &= "  select  isnull(Sum(BT.TotalSumAmount),0) as bank   from BankTransaction BT"
            str &= "  join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            str &= " and BT.TotalSumAmount > 0 and BT.BankTransactionID not in "
            str &= " (Select Top 1 BT.BankTransactionID from BankTransaction BT"
            str &= "  join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            str &= " and BT.TotalSumAmount > 0  order by BT.BankTransactionID ASC )"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTotalExpense(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = " select  isnull(Sum(BT.TotalSumAmount),0) as TotalExpense  from BankTransaction BT "
            str &= "  join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            str &= "  and BT.TotalSumAmount < 0 "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTotalAmount(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = " select  isnull(Sum(BT.TotalSumAmount),0) as TotalExpense  from BankTransaction BT "
            str &= "  join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= "  where Year(BT.TransactionDate)=" & Year
            str &= "  and month(BT.TransactionDate)=" & month
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditMode(ByVal BankTransactionID As Long)
            Dim str As String
            str = "  select *,abs(BTD.amount) as Amount1,abs(TotalSumAmount) as TotalSumAmount1,abs(DeductionTotalAmount) as DeductionTotalAmount1 "
            str &= " from BankTransaction BT"
            str &= " join BankTransactionDetail BTD on BT.BankTransactionID =BTD.BankTransactionID "
            str &= " join ChartofAccount COA on COA.ChartofAccountID=BTD.ChartofAccountID "
            str &= "  where BT.BankTransactionID=" & BankTransactionID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetHKCodeID(ByVal HKCode As String)
            Dim str As String
            str = " Select HKCodeID from HKCode where HKCode = '" & HKCode & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetECPCodeID(ByVal ECPCode As String)
            Dim str As String
            str = " Select ECPCodeID from ECPCode where ECPCode = '" & ECPCode & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMonthNames()
            Dim str As String
            Try
                str = " select distinct DATENAME(month, (TransactionDate)) as MonthName,month(TransactionDate)as MonthNo from BankTransaction"
                str &= " order by   month(TransactionDate)   ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetYearNames()
            Dim str As String
            Try
                str = " select distinct DATENAME(year, (TransactionDate)) as YearName,year(TransactionDate)as YearNo from BankTransaction "
                str &= " order by   year(TransactionDate)   DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getExcelSheet(ByVal MonthNo As String, ByVal YearNo As String)
            Try
                ' Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection")
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("Sp_BankSheetXLL", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.VarChar)).Value = MonthNo
                sqlCmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.VarChar)).Value = YearNo
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function getExcelSheetBankLedger(ByVal MonthNo As String, ByVal YearNo As String)
            Try
                ' Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection")
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("Sp_BankSheetXLLedger", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.VarChar)).Value = MonthNo
                sqlCmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.VarChar)).Value = YearNo
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetHKCodeIndex(ByVal HKCode As String)
            Dim str As String
            Try
                str = "Select HKCodeID  from HKCode where HKCode='" & HKCode & "'"
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetECPCodeIndex(ByVal ECPCode As String)
            Dim str As String
            Try
                str = "Select ECPCodeID  from ECPCode where ECPCode='" & ECPCode & "'"
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace