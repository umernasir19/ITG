Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class CashTransaction
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CashTransaction"
            m_strPrimaryFieldName = "CashTransactionID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lCashTransactionID As Long
        Private m_dtTransactionDate As Date
        Private m_strTranscationType As String
        Private m_dtCreationDate As Date

        Public Property CashTransactionID() As Long
            Get
                CashTransactionID = m_lCashTransactionID
            End Get
            Set(ByVal value As Long)
                m_lCashTransactionID = value
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
        Public Function SaveCashTransaction()
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
            str = "   select CT.CashTransactionID ,CT.TranscationType,left( DATENAME(Month, CT.TransactionDate),3) as month, Convert(varchar,CT.TransactionDate,106) as Date"
            str &= "  , (case when cast( CT.CashTransactionID as varchar(4000)) > 0 and cast( CT.CashTransactionID as varchar(4000)) <= 9 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '00000'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000)) >= 10 and cast( CT.CashTransactionID as varchar(4000)) <= 99 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '0000'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000)) >= 100 and cast( CT.CashTransactionID as varchar(4000)) <= 999 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '000'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000))>= 1000 and cast( CT.CashTransactionID as varchar(4000)) <= 9999 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '00'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000)) >= 10000 and cast( CT.CashTransactionID as varchar(4000)) <= 99999 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '0'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  else"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-' + cast( CT.CashTransactionID as varchar(4000)) end) as VoucherNo"
            str &= "  ,CTD.Narration as Particulars , CTD.Amount , COA.AccountType as AccountsHead"
            str &= "  , CTD.NameOfPayee as Payee ,CTD.HKCode as HKAnalysisCode,CTD.ECPCode as ECPAnalysisCode"
            str &= "  from CashTransaction CT"
            str &= "  join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  join ChartofAccount COA on COA.ChartofAccountID=CTD.ChartofAccountID"
            str &= "  where Year(CT.TransactionDate)=" & Year
            str &= "  and month(CT.TransactionDate)=" & month
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMonthYear()
            Dim str As String
            str = "  select distinct left( DATENAME(Month, CT.TransactionDate),3)+ ','+ "
            str &= "  convert(varchar,year(CT.TransactionDate)) as MonthYear, "
            str &= "  Month(CT.TransactionDate) as Monthh "
            str &= "   from CashTransaction ct "
            str &= "  order by Month(CT.TransactionDate) ASC  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBalanceCF(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = " select  Top 1 isnull(CTD.Amount,0) as BalanceCF   from CashTransaction CT "
            str &= "  join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  where Year(CT.TransactionDate)=" & Year
            str &= "  and month(CT.TransactionDate)=" & month
            str &= "  and CTD.Amount > 0  order by CT.CashTransactionID ASC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPettyCash(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str &= "  select  isnull(Sum(CTD.Amount),0) as PettyCash   from CashTransaction CT"
            str &= "  join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  where Year(CT.TransactionDate)=" & Year
            str &= "  and month(CT.TransactionDate)=" & month
            str &= " and CTD.Amount > 0 and CT.CashTransactionID not in "
            str &= " (Select Top 1 CT.CashTransactionID from CashTransaction CT"
            str &= "  join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  where Year(CT.TransactionDate)=" & Year
            str &= "  and month(CT.TransactionDate)=" & month
            str &= " and CTD.Amount > 0  order by CT.CashTransactionID ASC )"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTotalExpense(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = " select  isnull(Sum(CTD.Amount),0) as TotalExpense  from CashTransaction CT "
            str &= "  join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  where Year(CT.TransactionDate)=" & Year
            str &= "  and month(CT.TransactionDate)=" & month
            str &= "  and CTD.Amount < 0 "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTotalAmount(ByVal month As Long, ByVal Year As String)
            Dim str As String
            str = " select  isnull(Sum(CTD.Amount),0) as TotalExpense  from CashTransaction CT "
            str &= "  join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  where Year(CT.TransactionDate)=" & Year
            str &= "  and month(CT.TransactionDate)=" & month
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditData(ByVal CashTransactionID As Long)
            Dim str As String
            str = "   select * "
            str &= "  , (case when cast( CT.CashTransactionID as varchar(4000)) > 0 and cast( CT.CashTransactionID as varchar(4000)) <= 9 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '00000'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000)) >= 10 and cast( CT.CashTransactionID as varchar(4000)) <= 99 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '0000'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000)) >= 100 and cast( CT.CashTransactionID as varchar(4000)) <= 999 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '000'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000))>= 1000 and cast( CT.CashTransactionID as varchar(4000)) <= 9999 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '00'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  when cast( CT.CashTransactionID as varchar(4000)) >= 10000 and cast( CT.CashTransactionID as varchar(4000)) <= 99999 then"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-'+ '0'+ cast( CT.CashTransactionID as varchar(4000))"
            str &= "  else"
            str &= "  convert(varchar,cast( CT.TranscationType as varchar(4000)))+ '-' + cast( CT.CashTransactionID as varchar(4000)) end) as VoucherNo"
            str &= "    ,AG.AccountGroup + '/' + ASG.AccountSubGroup + '/' + CoA.AccountType as AccountHead "
            str &= "  from CashTransaction CT"
            str &= "   join CashTransactionDetail CTD on CTD.CashTransactionID=CT.CashTransactionID"
            str &= "  join ChartofAccount COA on COA.ChartofAccountID=CTD.ChartofAccountID"
            str &= " join AccountGroup AG on AG.AccountGroupID=CoA.AccountGroupID "
            str &= " join AccountSubGroup ASG on ASG.AccountSubGroupID=CoA.AccountSubGroupID "
            str &= "  where CT.CashTransactionID =" & CashTransactionID
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
                str = " select distinct DATENAME(month, (TransactionDate)) as MonthName,month(TransactionDate)as MonthNo from CashTransaction"
                str &= " order by   month(TransactionDate)   ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetYearNames()
            Dim str As String
            Try
                str = " select distinct DATENAME(year, (TransactionDate)) as YearName,year(TransactionDate)as YearNo from CashTransaction "
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
                sqlCmd = New SqlCommand("Sp_CashSheetXLL", objSqlConnection)
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