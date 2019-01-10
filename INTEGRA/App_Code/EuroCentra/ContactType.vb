Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class ContactType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ContactType"
            m_strPrimaryFieldName = "Contact_Type_ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lContact_Type_ID As Long
        Private m_strContact_Type As String


        '.............Properties
        Public Property ContactTypeID() As Long
            Get
                ContactTypeID = m_lContact_Type_ID
            End Get
            Set(ByVal value As Long)
                m_lContact_Type_ID = value
            End Set
        End Property

        Public Property ContactType() As String
            Get
                ContactType = m_strContact_Type
            End Get
            Set(ByVal value As String)
                m_strContact_Type = value
            End Set
        End Property

        Public Sub SaveContactType()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetContactTypeByID(ByVal lContactTypeID As Long)
            Try
                Return MyBase.GetById(lContactTypeID)
            Catch ex As Exception

            End Try

        End Function

        Function DeleteDetailsFromContactType(ByVal Contact_Type_ID As Long)
            Dim str As String
            str = "Delete From Contact_Type where Contact_Type_ID =" & Contact_Type_ID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try

        End Function

        Function GETColor(ByVal DyesName As String)
            Dim Str As String
            Str = "Select DyesName from DyeingDyes Where DyesName like '" & DyesName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETFullBleachProcess(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='F/Bleach' and DyeingTypeId='1' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETFullBleachDyeingProcess(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='F/Dyeing' and DyeingTypeId='1' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETHalfBleachProcess(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='H/Bleach' and DyeingTypeId='2' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETHalfBleachDyeingProcess(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='H/Dyeing' and DyeingTypeId='2' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETHalfBleachSTRIPProcess(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='H/Strips' and DyeingTypeId='2' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETDISPRESEPROCESS(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='Disperse H.Bleach' and DyeingTypeId='4' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETDISPRESEDYEINGPROCESS(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='Disperse/Dyeing' and DyeingTypeId='4' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETDISPRESESTRIPSPROCESS(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='Disperse/Strips' and DyeingTypeId='4' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETJobNo(ByVal JobOrderNo As String)
            Dim Str As String
            Str = " select JobOrderNo from JobOrderdatabase Where   JobOrderNo like '" & JobOrderNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetBookAccount() As DataTable
            Dim str As String
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Function GETAUTOCV(ByVal VoucherNo As String)
            Dim Str As String
            Str = "Select VoucherNo as Name from tblCashMst where VoucherNo like '%" & VoucherNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetBookAccountFirstTime() As DataTable
            Dim str As String
            '  str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountCode='0103002001'"
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0103002' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTimeForNaeemBank() As DataTable
            Dim str As String
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTimeForNaeemBankForContraVoucher() As DataTable
            Dim str As String
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' or Groupact='0102005' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTimeForNaeemCash() As DataTable
            Dim str As String
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102005' "
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
            str = " select Top 1 SNo from tblBankDtl order by tblBankDtlID DESC"
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
            str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' order By tblBankMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBankVoucherforView() As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.tblBankMstID DESC"
            '  str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.voucherNo DESC"
            str = "select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,CONVERT(varchar,CAST((TBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblBankMst TBM "
            str &= " order By TBM.tblBankMstID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteBrandDatabase(ByVal ltblBankMstID As Long)
            Dim Str As String
            Str = " Delete from tblBankMst where tblBankMstID=" & ltblBankMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBankVoucherforLedgerView(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = "select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblBankMst TBM where TBM.VoucherNo='" & VoucherNo & "'"
            str &= " order By TBM.voucherNo DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeletetblBankMst(ByVal tblBankMstID As Long)
            Dim Str As String
            Str = " delete from tblBankMst where tblBankMstID=" & tblBankMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeletetblBankDtl(ByVal tblBankMstID As Long)
            Dim Str As String
            Str = " delete from tblBankDtl where tblBankMstID=" & tblBankMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function InsertCVData(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= " TBD.ChequeNo,TBD.ChequeDate,"
            str &= " TBM.Description,TBD.DescriptionEntry,"
            str &= " (select distinct AccountName from TblAccounts TT "
            str &= " join tblCashMst TM on TM.BookAccount=TT.AccountCode "
            str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= " Case When TBD.Type = 'C' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'D' then TBD.Amount else 0 end as Credit"
            str &= " from tblCashMst TBM  "
            str &= " join tblCashDtl TBD on TBD.tblCashMstID=TBM.tblCashMstID "
            str &= " join tblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBM.BookAccount= '" & AccountCode & " ' "

            str &= " order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function InsertCVDataWithOutBank(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= " TBD.ChequeNo,TBD.ChequeDate,"
            str &= " TBM.Description,TBD.DescriptionEntry,"
            str &= " (select distinct AccountName from TblAccounts TT "
            str &= " join tblCashMst TM on TM.BookAccount=TT.AccountCode "
            str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= " from tblCashMst TBM  "
            str &= " join tblCashDtl TBD on TBD.tblCashMstID=TBM.tblCashMstID "
            str &= " join tblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "

            str &= " order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertPVData(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger   select TBM.VoucherNo,TBM.VoucherDate , "
            str &= "  '' as ChequeNo,''as ChequeDate, TBM.Description, TBD.DescriptionEntry,"
            str &= " 'Purchase Voucher' as 'AccountName',TBD.Debit, TBD.Credit"
            str &= " from tblPVMst TBM  "
            str &= " join TblPVDtl TBD on TBD.tblPVMstID=TBM.tblPVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "

            str &= " order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncatingTemTrialBalanceTables()
            Dim str As String = "TRUNCATE TABLE  TemTrialBalance"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function Edit(ByVal tblBankMstID As Long) As DataTable
            Dim str As String
            'str = " Select * from tblBankMst TBM "
            'str &= " join tblBankDtl TBD on TBM.tblBankMstID=TBD.tblBankMstID"
            'str &= " join tblAccounts AA on AA.AccountCode=TBM.BookAccount"
            'str &= " where TBM.tblBankMstID=" & tblBankMstID

            str = " Select * from tblBankMst TBM "
            str &= " join tblBankDtl TBD on TBM.tblBankMstID=TBD.tblBankMstID"
            str &= " join tblAccounts AA on AA.AccountCode=TBD.AccountCode"
            str &= " where TBM.tblBankMstID=" & tblBankMstID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMasterData() As DataTable
            Dim str As String
            str = " Select * from tblBankMst "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDetailData(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = " Select * from tblBankDtl where VoucherNo='" & VoucherNo & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateDetail(ByVal tblBankMstID As Long, ByVal tblBankDtlID As Long)
            Dim str As String
            str = " Update tblBankDtl set tblBankMstID=" & tblBankMstID & " where tblBankDtlID=" & tblBankDtlID & ""
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateAmount(ByVal tblBankMstID As Long, ByVal TotalAmount As Decimal)
            Dim str As String
            str = " Update tblBankMst set TotalAmount=" & TotalAmount & " where tblBankMstID=" & tblBankMstID & ""
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAmount(ByVal tblBankMstID As Long) As DataTable
            Dim str As String
            str = " Select isnull(Sum(amount),0) as amount from tblBankDtl where tblBankMstID=" & tblBankMstID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVoucherNo() As DataTable
            Dim str As String
            str = " select tblBankMstID,VoucherNo from tblBankMst"
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
        Function GETAllLedgerForLedgerRPT(ByVal AccountName As String)
            Dim Str As String
            Str = " select   AccountName from tblaccounts where AccountName like '%" & AccountName & "%' order by AccountName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTO(ByVal VoucherNo As String)
            Dim Str As String
            Str = "Select VoucherNo as Name from tblBankMst where VoucherNo like '%" & VoucherNo & "%'"
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

        Function GETAUTOAccountNameForNaeem(ByVal AccountName As String)
            Dim Str As String
            Str = " Select AccountName as Name from tblAccounts where AccountLevel='Detail' and AccountName like '" & AccountName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETAUTOAccountNameForNaeemContraVoucher(ByVal AccountName As String)
            Dim Str As String
            Str = " Select AccountName as Name from tblAccounts where AccountLevel='Detail' and actleveldigit=4 and Groupact='0102004' or Groupact='0102005' and AccountName like '" & AccountName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVoucherNoAllInfo(ByVal VoucherNo As String) As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID   order By TBM.voucherNo DESC"
            str = " select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblBankMst TBM "
            str &= " where VoucherNo ='" & VoucherNo & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUniqueAccountName(ByVal AccountName As String)
            Dim str As String
            str = " Select * from tblAccounts where AccountLevel='Detail' and AccountName ='" & AccountName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUniqueAccountNameNewNaeem(ByVal AccountName As String)
            Dim str As String
            str = " Select * from tblAccounts where AccountName ='" & AccountName & "'  and AccountLevel='Detail' "
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

        Public Function GetUniqueAccountNameForGroupSummary()
            Dim str As String
            ' str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA join  tblOpeningBalance TOB on TA.AccountCode=TOB.AccountCode "
            ' str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA  order by TA.AccountName ASC"
            str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode"
            str &= " from tblAccounts TA  where AccountLevel='Control'"
            str &= " order by TA.AccountName ASC"
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
        Public Function GetBPVDataForLedger(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select "
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= " from tblBankMst TBM  "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBD.AccountCode= '" & AccountCode & " ' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetJVDataForLedger(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select TBD.Debit, TBD.Credit"
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCVDataForLedger(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select "
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= " from tblCashMst TBM  "
            str &= " join tblCashDtl TBD on TBD.tblCashMstID=TBM.tblCashMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetContraDataForLedger(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select "
            str &= " Case When TBD.DrCr = 'Dr' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.DrCr = 'Cr' then TBD.Amount else 0 end as Credit"
            str &= " from ContraVoucherMst TBM  "
            str &= " join ContraVoucherDtl TBD on TBD.ContraVoucherMstID=TBM.ContraVoucherMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBPVData(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select "
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= " from tblBankMst TBM  "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBM.BookAccount= '" & AccountCode & " ' "
            str &= " order By TBM.VoucherDate ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetJVData(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select TBD.Debit, TBD.Credit"
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   TBD.AccountCode= '" & AccountCode & " ' "
            str &= " order By TBM.VoucherDate ASC "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCVData(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select "
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= " from tblCashMst TBM  "
            str &= " join tblCashDtl TBD on TBD.tblCashMstID=TBM.tblCashMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBM.BookAccount= '" & AccountCode & " ' "
            str &= " order By TBM.VoucherDate ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCCONTRData(ByVal AccountCode As String) As DataTable

            Dim str As String
            str = " select "
            str &= " Case When TBD.DrCr = 'Dr' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.DrCr = 'Cr' then TBD.Amount else 0 end as Credit"
            str &= " from ContraVoucherMst TBM  "
            str &= " join ContraVoucherDtl TBD on TBD.ContraVoucherMstID=TBM.ContraVoucherMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBM.AccountCode= '" & AccountCode & " ' "
            str &= " order By TBM.ContraPaymentDate ASC"

            Try
                Return MyBase.GetDataTable(str)
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
        Public Function GetLedgerForPrintNewDateWise(ByVal OpeningBalance As Decimal, ByVal startdate As String, ByVal enddate As String) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.VoucherDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedger a "
            str &= " WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.Debit)- TBM.Credit) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedger a "
            str &= " WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempLedger TBM "
            str &= " where TBM.VoucherDate between '" & startdate & "' and  '" & enddate & "' "
            str &= " order By TBM.VoucherDate ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBackup(ByVal path As String, ByVal FileName As String)
            Dim Str As String
            Dim File As String = path + FileName
            Str = "backup database IdealAccounts to DISK='" & File & "' "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInvoice(ByVal AccountPayable As String)
            Dim str As String
            str = "select * from POInvoiceMaster POIM   join  POInvoiceAdjDetail POIJD on POIM.POInvoiceMasterID=POIJD.POInvoiceMasterID where POIJD.tblBankMstId = '0' and POIM.AccountPayable='" & AccountPayable & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInvoiceNaeem(ByVal AccountPayable As String)
            Dim str As String
            str = "select * from POInvoiceMst POIM  join  SupplierDatabase SD on POIM.Accountpayablepartyid=SD.SupplierdatabaseID where  SD.SupplierName='" & AccountPayable & "' and POIM.PaymentBit=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInvoiceNaeemWithDCAutoSearch(ByVal AccountPayable As String, ByVal SaleTaxInvoiceNo As String)
            Dim str As String
            str = "select * from POInvoiceMst POIM  join  SupplierDatabase SD on POIM.Accountpayablepartyid=SD.SupplierdatabaseID where  SD.SupplierName='" & AccountPayable & "' and POIM.SaleTaxInvoiceNo='" & SaleTaxInvoiceNo & "' and POIM.PaymentBit=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInvoice()
            Dim str As String
            str = "select * from POInvoiceMaster  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GETAUTOAccountNamewithCodeNew(ByVal AccountName As String)
            Dim Str As String
            Str = " Select (AccountName +'-'+ AccountCode) as Name,AccountName as Name2, AccountCode as Code2,ChartOfAccountID from tblAccounts where AccountLevel='Detail' and  AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOAccountNamewithCode(ByVal AccountName As String)
            Dim Str As String
            Str = " Select (AccountName +'-'+ AccountCode) as Name,AccountName as Name2, AccountCode as Code2,ChartOfAccountID from tblAccounts where AccountLevel='Detail' and AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPaymentTerm() As DataTable
            Dim str As String
            str = " select * from tblPaymentTerms"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateInvoicePaymentComplete(ByVal POInvoiceMstID As Long, ByVal PaymentAmount As Decimal)
            Dim str As String
            str = "  update POInvoiceMst set PaymentAmount='" & PaymentAmount & "',PaymentBit=1 where POInvoiceMstID='" & POInvoiceMstID & "'   "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateInvoicePayment(ByVal POInvoiceMstID As Long, ByVal PaymentAmount As Decimal)
            Dim str As String
            str = "  update POInvoiceMst set PaymentAmount='" & PaymentAmount & "' where POInvoiceMstID='" & POInvoiceMstID & "'   "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckCheckNo(ByVal ChequeNo As String) As DataTable
            Dim str As String
            str = " select * from tblBankDtl where ChequeNo='" & ChequeNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        ''Group Summary Report
        Public Function TruncateTempGroupSummaryTable()
            Dim str As String = "TRUNCATE TABLE  TempGroupSummary"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertJVDataGropuSummary(ByVal GroupAct As String)

            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct, TBD.Accountcode,TBM.VoucherDate ,TBD.VoucherNo ,TBD.Debit, TBD.Credit "
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where   A.GroupAct= '" & GroupAct & "'"
            str &= " order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertAll(ByVal GroupAct As String)

            Dim str As String

            str = "  INSERT INTO TempGroupSummary "
            str &= " select GroupAct,A.AccountCode,'01/01/2016' as VoucherDate ,'' as VoucherNo,'0' AS Debit,"
            str &= " '0' AS Credit from TblAccounts A where   A.GroupAct= '" & GroupAct & "'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertbvDataGropuSummary(ByVal GroupAct As String)
            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct,TBD.AccountCode,TBM.VoucherDate ,TBM.VoucherNo,"
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit "
            str &= " from tblBankMst TBM   "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode  "
            str &= " where   A.GroupAct= '" & GroupAct & "'   order By TBM.VoucherDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertCVDataGropuSummary(ByVal GroupAct As String)
            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct,TBD.AccountCode,TBM.VoucherDate ,TBM.VoucherNo,"
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit "
            str &= " from tblCashMst TBM   "
            str &= " join TblCashDtl TBD on TBD.tblCashMstID=TBM.tblCashMstID  "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode  "
            str &= " where   A.GroupAct= '" & GroupAct & "' order By TBM.VoucherDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function CheckGroupDetail(ByVal AccountCode As String)
            Dim str As String
            ' str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA join  tblOpeningBalance TOB on TA.AccountCode=TOB.AccountCode "
            ' str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA  order by TA.AccountName ASC"
            str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode"
            str &= " from tblAccounts TA  where GroupAct='" & AccountCode & "' and AccountLevel='Detail'"
            str &= " order by TA.AccountName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

