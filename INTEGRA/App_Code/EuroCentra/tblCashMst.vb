Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class tblCashMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblCashMst"
            m_strPrimaryFieldName = "tblCashMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_ltblCashMstID As Long
        Private m_strCompanyId As String
        Private m_strVoucherNo As String
        Private m_dtVoucherDate As Date
        Private m_strBookAccount As String
        Private m_strDescription As String
        Private m_strVoucherType As String
        Private m_strCancel As String
        Private m_dtEntryDate As Date
        Private m_strUserId As String
        Private m_strVoucherNoOld As String
        Private m_strVoucherNoNew As String
        Private m_lUID As Long
        Private m_dTotalAmount As Decimal
        Private m_strInvoiceType As String
        Private m_strVNo As String
        Private m_bChkDate As Boolean
        Public Property ChkDate() As Boolean
            Get
                ChkDate = m_bChkDate
            End Get
            Set(ByVal Value As Boolean)
                m_bChkDate = Value
            End Set
        End Property
        Public Property tblCashMstID() As Long
            Get
                tblCashMstID = m_ltblCashMstID
            End Get
            Set(ByVal Value As Long)
                m_ltblCashMstID = Value
            End Set
        End Property
        Public Property CompanyId() As String
            Get
                CompanyId = m_strCompanyId
            End Get
            Set(ByVal Value As String)
                m_strCompanyId = Value
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
        Public Property VoucherDate() As Date
            Get
                VoucherDate = m_dtVoucherDate
            End Get
            Set(ByVal Value As Date)
                m_dtVoucherDate = Value
            End Set
        End Property
        Public Property BookAccount() As String
            Get
                BookAccount = m_strBookAccount
            End Get
            Set(ByVal Value As String)
                m_strBookAccount = Value
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
        Public Property VoucherType() As String
            Get
                VoucherType = m_strVoucherType
            End Get
            Set(ByVal Value As String)
                m_strVoucherType = Value
            End Set
        End Property
        Public Property Cancel() As String
            Get
                Cancel = m_strCancel
            End Get
            Set(ByVal Value As String)
                m_strCancel = Value
            End Set
        End Property
        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate
            End Get
            Set(ByVal Value As Date)
                m_dtEntryDate = Value
            End Set
        End Property
        Public Property UserId() As String
            Get
                UserId = m_strUserId
            End Get
            Set(ByVal Value As String)
                m_strUserId = Value
            End Set
        End Property
        Public Property VoucherNoOld() As String
            Get
                VoucherNoOld = m_strVoucherNoOld
            End Get
            Set(ByVal Value As String)
                m_strVoucherNoOld = Value
            End Set
        End Property
        Public Property VoucherNoNew() As String
            Get
                VoucherNoNew = m_strVoucherNoNew
            End Get
            Set(ByVal Value As String)
                m_strVoucherNoNew = Value
            End Set
        End Property
        Public Property UID() As Long
            Get
                UID = m_lUID
            End Get
            Set(ByVal Value As Long)
                m_lUID = Value
            End Set
        End Property
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = m_dTotalAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dTotalAmount = Value
            End Set
        End Property
        Public Property InvoiceType() As String
            Get
                InvoiceType = m_strInvoiceType
            End Get
            Set(ByVal Value As String)
                m_strInvoiceType = Value
            End Set
        End Property
        Public Property VNo() As String
            Get
                VNo = m_strVNo
            End Get
            Set(ByVal Value As String)
                m_strVNo = Value
            End Set
        End Property
        Public Function SavetblCashMst()
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

        Public Function GetBookAccount() As DataTable
            Dim str As String
            ''str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail'"
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Control'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCashNAME() As DataTable
            Dim str As String
            ''str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail'"
            str = " select * from tblAccounts where AccountCode like '0102009002%' and AccountLevel ='Detail'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTime() As DataTable
            Dim str As String
            '  str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountCode='0103002001'"
            ''str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0103002' "

            'str = "select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Control' and AccountNature=10 and actleveldigit =3 and Groupact='10'"
            'str = "select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Control' and AccountNature=10 and actleveldigit =3 and Groupact='1002'"
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102005'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountName(ByVal AccountCode As String)
            Dim str As String
            str = " select AccountName from tblAccounts where AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTopSNO()
            Dim str As String
            str = " select Top 1 SNo from tblCashDtl order by tblCashDtlID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUserName(ByVal UserID As Long)
            Dim str As String
            str = " select UserName from UMUser where UserId='" & UserID & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastVoucherNo(ByVal Month As Integer, ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            str = " select Top 1 VoucherNo from tblCashMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' order By tblCashMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBankVoucherforView() As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.tblBankMstID DESC"
            '  str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.voucherNo DESC"
            str = "select  TBM.tblCashMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,CONVERT(varchar,CAST((TBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblCashMst TBM "
            str &= " order By TBM.tblCashMstID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBankVoucherforViewNew(ByVal FirstYear As String, ByVal SecondYear As String) As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.tblBankMstID DESC"
            '  str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.voucherNo DESC"
            str = "select  TBM.tblCashMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,CONVERT(varchar,CAST((TBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblCashMst TBM where TBM.VoucherDate between '" & FirstYear & "' and '" & SecondYear & "'  "
            str &= " order By TBM.tblCashMstID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJoborderforView() As DataTable
            Dim str As String

            str = "select *,convert(varchar,JM.JobOrderDate,103) as JobOrderDatee from tblJobOrderMst JM "
            str &= " join SupplierDatabase SD ON SD.SupplierDatabaseId=JM.SupplierId"
            str &= " join SupplierDatabaseDetail SDD on SD.SupplierDatabaseId=SDD.SupplierDatabaseId"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteBrandDatabase(ByVal ltblBankMstID As Long)
            Dim Str As String
            Str = " Delete from tblCashMst where tblCashMstID=" & ltblBankMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Edit(ByVal tblBankMstID As Long) As DataTable
            Dim str As String
            'str = " Select * from tblBankMst TBM "
            'str &= " join tblBankDtl TBD on TBM.tblBankMstID=TBD.tblBankMstID"
            'str &= " join tblAccounts AA on AA.AccountCode=TBM.BookAccount"
            'str &= " where TBM.tblBankMstID=" & tblBankMstID

            str = " Select ISNULL(CC.CostCenterId,0) AS CostCenterId,ISNULL(CC.Cost,'') AS Cost,* from tblCashMst TBM "
            str &= " left join tblCashDtl TBD on TBM.tblCashMstID=TBD.tblCashMstID"
            str &= " left  join tblAccounts AA on AA.AccountCode=TBD.AccountCode  left JOIN CostCenter CC ON CC.CostCenterId=TBD.CostCenterId "
            str &= " where TBM.tblCashMstID=" & tblBankMstID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMasterData() As DataTable
            Dim str As String
            str = " Select * from tblCashMst "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDetailData(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = " Select * from tblCashDtl where VoucherNo='" & VoucherNo & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateDetail(ByVal tblCashMstID As Long, ByVal tblCashDtlID As Long)
            Dim str As String
            str = " Update tblCashDtl set tblCashMstID=" & tblCashMstID & " where tblCashDtlID=" & tblCashDtlID & ""
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateAmount(ByVal tblCashMstID As Long, ByVal TotalAmount As Decimal)
            Dim str As String
            str = " Update tblCashMst set TotalAmount=" & TotalAmount & " where tblCashMstID=" & tblCashMstID & ""
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAmount(ByVal tblCashMstID As Long) As DataTable
            Dim str As String
            str = " Select isnull(Sum(amount),0) as amount from tblCashDtl where tblCashMstID=" & tblCashMstID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVoucherNo() As DataTable
            Dim str As String
            str = " select tblCashMstID,VoucherNo from tblCashMst"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountCode() As DataTable
            Dim str As String
            ' str = " select distinct BookAccount from tblBankMst "
            str = " Select distinct AccountCode as BookAccount from tblAccounts  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTO(ByVal VoucherNo As String)
            Dim Str As String
            Str = "Select VoucherNo as Name from tblCashMst where VoucherNo like '%" & VoucherNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOAccountName(ByVal AccountName As String)
            Dim Str As String
            Str = "Select AccountName as Name from tblAccounts where AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVoucherNoAllInfo(ByVal VoucherNo As String) As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID   order By TBM.voucherNo DESC"
            str = " select  TBM.tblCashMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblCashMst TBM "
            str &= " where VoucherNo ='" & VoucherNo & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUniqueAccountName(ByVal AccountName As String)
            Dim str As String
            'str = " Select * from tblAccounts where AccountName ='" & AccountName & "' "
            str = " Select * from tblAccounts where (AccountName+'-'+AccountCode) ='" & AccountName & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountNameMaster(ByVal AccountCode As String)
            Dim str As String
            str = " Select AccountName from tblAccounts where AccountCode ='" & AccountCode & "' "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetUniqueAccountNameForPrintOB()
            Dim str As String
            ' str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA join  tblOpeningBalance TOB on TA.AccountCode=TOB.AccountCode "
            str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA  order by TA.AccountName ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '''---------FunctionsFor Ledger report
        Public Function TruncateTempLedgerTable()
            Dim str As String = "TRUNCATE TABLE  TempLedger"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVData(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= " TBD.ChequeNo,TBD.ChequeDate,"
            str &= " TBM.Description,TBD.DescriptionEntry,"
            str &= " (select distinct AccountName from TblAccounts TT "
            str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= " Case When TBD.Type = 'C' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'D' then TBD.Amount else 0 end as Credit"
            str &= " from tblBankMst TBM  "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBM.BookAccount= '" & AccountCode & " ' "


            str &= " order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataWithOutBank(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= " TBD.ChequeNo,TBD.ChequeDate,"
            str &= " TBM.Description,TBD.DescriptionEntry,"
            str &= " (select distinct AccountName from TblAccounts TT "
            str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= " from tblBankMst TBM  "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "

            str &= " order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function InsertJVData(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger   select TBM.VoucherNo,TBM.VoucherDate , "
            str &= "  '' as ChequeNo,''as ChequeDate, TBM.Description, TBD.DescriptionEntry,"
            str &= " 'Journal Voucher' as 'AccountName',TBD.Debit, TBD.Credit"
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "

            str &= " order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetGroupAct(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from tblAccounts where AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningBalance(ByVal AccountCode As String)
            Dim str As String
            If AccountCode = 0 Then
                str = " select isnull(Sum(OpeningBalance),0) as OpeningBalance from tblOpeningBalance "
            Else
                str = " select isnull(Sum(OpeningBalance),0)  as OpeningBalance from tblOpeningBalance where AccountCode ='" & AccountCode & "'"
            End If

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrint(ByVal OpeningBalance As Decimal) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.VoucherDate,103) as VoucherDatee,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedger a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "') + "
            str &= "TBM.Debit)- TBM.Credit) AS Balance,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedger a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= "from TempLedger TBM "
            ' str &= "--where TBM.VoucherDate between '01/07/2013' and  '30/06/2014' "
            str &= "order By TBM.VoucherDate ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCashVoucherforLedgerView(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = "select  TBM.tblCashMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblCashMst TBM where TBM.VoucherNo='" & VoucherNo & "'"
            str &= " order By TBM.voucherNo DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeletetblBankMst(ByVal tblCashMstID As Long)
            Dim Str As String
            Str = " delete from tblCashMst where tblCashMstID=" & tblCashMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeletetblBankDtl(ByVal tblBankMstID As Long)
            Dim Str As String
            Str = " delete from tblCashDtl where tblCashMstID=" & tblCashMstID
            Try
                MyBase.ExecuteNonQuery(Str)
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
End Namespace

