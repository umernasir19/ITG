Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class tblBankMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblBankMst"
            m_strPrimaryFieldName = "tblBankMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_ltblBankMstID As Long
        Private m_strCompanyId As String
        Private m_strVoucherNo As String
        Private m_dtVoucherDate As Date
        Private m_dtOriginalVoucherDate As Date
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
        Private m_lVoucherTypeID As Long
        Private m_bChkDate As Boolean
        Public Property ChkDate() As Boolean
            Get
                ChkDate = m_bChkDate
            End Get
            Set(ByVal Value As Boolean)
                m_bChkDate = Value
            End Set
        End Property
        Public Property tblBankMstID() As Long
            Get
                tblBankMstID = m_ltblBankMstID
            End Get
            Set(ByVal Value As Long)
                m_ltblBankMstID = Value
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
        Public Property OriginalVoucherDate() As Date
            Get
                OriginalVoucherDate = m_dtOriginalVoucherDate
            End Get
            Set(ByVal Value As Date)
                m_dtOriginalVoucherDate = Value
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

        Public Property VoucherTypeID() As Long
            Get
                VoucherTypeID = m_lVoucherTypeID
            End Get
            Set(ByVal Value As Long)
                m_lVoucherTypeID = Value
            End Set
        End Property
        Public Function SavetblBankMst()
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
        Public Function GetBankName() As DataTable
            Dim str As String
            str = " select * from tblAccounts where AccountCode like '0102009001%' and AccountLevel ='Detail' "
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
        Public Function GetBankVoucherforViewNew(ByVal FirstYear As String, ByVal SecondYear As String) As DataTable
            Dim str As String
            


            'str = "select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            'str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,CONVERT(varchar,CAST((TBM.TotalAmount)As money),1)As TotalAmount,"
            'str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            'str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            'str &= " from tblBankMst TBM  where VoucherDate between '" & FirstYear & "' and '" & SecondYear & "' "
            'str &= "    order By TBM.VoucherDate desc "

            str = "select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,CONVERT(varchar,CAST((TBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " from tblBankMst TBM  "
            str &= "    order By TBM.VoucherDate desc "

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

            str = " Select ISNULL(CC.CostCenterId,0) AS CostCenterId,ISNULL(CC.Cost,'') AS Cost,* from tblBankMst TBM "
            str &= " join tblBankDtl TBD on TBM.tblBankMstID=TBD.tblBankMstID"
            str &= " left join tblAccounts AA on AA.AccountCode=TBD.AccountCode left JOIN CostCenter CC ON CC.CostCenterId=TBD.CostCenterId"
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
        Public Function GetUniqueCostCenter(ByVal Cost As String)
            Dim str As String
            'str = " Select * from tblAccounts where AccountName ='" & AccountName & "' "
            str = " select * from CostCenter where Cost ='" & Cost & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        ' added by Atif On 27 July 2018

        Public Function ChkWHT(ByVal AccountCode As String)
            Dim str As String
            str &= " select * from tblaccounts where AccountCode = '" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetAllAccountsNew()
            Dim str As String
            str = " Select distinct isnull(Opening_Debit,0) as Opening_Debit,isnull(Opening_Credit,0) as Opening_Credit,AccountCode,AccountName from tblAccounts  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncatingTemTrialBalancefinalTables()
            Dim str As String = "TRUNCATE TABLE  TemTrialBalancefinal"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetMainHeadForTB()
            Dim str As String
            str = "  select * from TemTrialBalance o"
            str &= " join tblaccounts a on a.accountcode=o.accountcode"
            str &= " where  a.accountcode   in ('01','02','03','04','05') "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNAmeForTB(ByVal Accountcode As String)
            Dim str As String
            str = "  select * from tblaccounts a"
            str &= " left join TemTrialBalance o  on a.accountcode=o.accountcode "
            str &= " where  a.groupact = '" & Accountcode & "' and a.actleveldigit<>1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQTYForTB(ByVal Accountcode As String)
            Dim str As String
            str = "  select o.Accountcode,a.AccountName ,(Sum(o.DebitBPV)+Sum(o.JVDebit)+Sum(o.DebitPV)+Sum(o.DebitCV)) as DB"
            str &= " ,(Sum(o.CreditBPV)+Sum(o.JVCredit)+Sum(o.CreditCV)+Sum(o.CreditPV)) as CR"
            str &= " ,(isnull(Sum(o.OB),0)-isnull(Sum(o.OBCR),0)) as OB"
            str &= " from tblaccounts  a"
            str &= " left join TemTrialBalance o on a.accountcode=o.accountcode"
            str &= " where  a.groupact like '" & Accountcode & "%' and a.actleveldigit<>1"
            str &= " group by o.Accountcode,a.AccountName"
            str &= " order by o.Accountcode asc "
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
        Public Function GetSumDebitBPVNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBD.AccountCode='" & AccountCode & "'"
            'str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by TBD.Type"
            str = " select  isnull(Case When TBD.Type = 'D' and TBD.Amount>0 Then TBD.Amount "
            str &= "   When TBD.Type = 'C' and TBD.Amount<0 then  -1*TBD.Amount Else 0 End,0.00) As DebitBPV"
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between  '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditBPV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBD.AccountCode='" & AccountCode & "'"
            'str &= " and TBM.voucherdate < '" & Startdate & "'"
            'str &= " group by TBD.Type"

            str = "  select    isnull(Case When TBD.Type = 'C' and (TBD.Amount)>0 then TBD.Amount "
            str &= "   When TBD.Type = 'D' and (TBD.Amount)<0 THEN -1*TBD.Amount else 0 end,0.00) as CreditBPV "
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID "
            str &= "  where TBD.AccountCode='" & AccountCode & "'"
            str &= "  and TBM.voucherdate < '" & Startdate & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditBPVMaster(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBM.BookAccount='" & AccountCode & "'"
            'str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by TBD.Type"

            'str = "  select  isnull(sum(Amount),0) as  DebitBPV from tblbankmst a"
            'str &= " join tblbankdtl b on b.tblbankmstID=a.tblbankmstID"
            'str &= " where  b.Type = 'D' and  a.BookAccount='" & AccountCode & "'"
            'str &= " and a.voucherdate < '" & Startdate & "' "
            'str &= " group by b.Type"

            str = "  select    Case When a.VoucherType = 'P' Then isnull(sum(a.TotalAmount),0) Else 0 End As DebitBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= " where   a.BookAccount='" & AccountCode & "'"
            str &= " and a.voucherdate < '" & Startdate & "'  "
            str &= " group by a.VoucherType"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitBPVMasterNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBM.BookAccount='" & AccountCode & "'"
            'str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by TBD.Type"

            'str = "  select  isnull(sum(Amount),0) as  CreditBPV from tblbankmst a"
            'str &= " join tblbankdtl b on b.tblbankmstID=a.tblbankmstID"
            'str &= " where  b.Type = 'C' and  a.BookAccount='" & AccountCode & "'"
            'str &= " and a.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by b.Type"

            str = "  select  Case When a.VoucherType = 'R' Then isnull(sum(a.TotalAmount),0) Else 0 End As CreditBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= "  where   a.BookAccount='" & AccountCode & "'"
            str &= "  and  a.VoucherType = 'R'"
            str &= "  and a.voucherdate between '" & Startdate & "' and '" & Enddate & " '   "
            str &= "  group by a.VoucherType"

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
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumCreditJV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            'str = " select isnull(sum(Credit) ,0.00)  as CreditJV from tblJVDtl TBD"
            'str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            'str &= " where TBD.AccountCode='" & AccountCode & "'"
            'str &= " and TBM.voucherdate < '" & Startdate & "' "

            str = " select isnull(sum(Credit) ,0.00)  as CreditJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate < '" & Startdate & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitBPV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBD.AccountCode='" & AccountCode & "'"
            'str &= " and TBM.voucherdate < '" & Startdate & "' "
            'str &= " group by TBD.Type"

            str = " select  isnull(Case When TBD.Type = 'D' and TBD.Amount>0 Then TBD.Amount "
            str &= "   When TBD.Type = 'C' and TBD.Amount<0 then  -1*TBD.Amount Else 0 End,0.00) As DebitBPV"
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate <  '" & Startdate & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitBPVMaster(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBM.BookAccount='" & AccountCode & "'"
            'str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by TBD.Type"
            'str = "  select  isnull(sum(Amount),0) as  CreditBPV from tblbankmst a"
            'str &= " join tblbankdtl b on b.tblbankmstID=a.tblbankmstID"
            'str &= " where  b.Type = 'C' and  a.BookAccount='" & AccountCode & "'"
            'str &= " and a.voucherdate < '" & Startdate & "' "
            'str &= " group by b.Type"

            str = "  select  Case When a.VoucherType = 'R' Then isnull(sum(a.TotalAmount),0) Else 0 End As CreditBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= "  where   a.BookAccount='" & AccountCode & "'"
            str &= "  and  a.VoucherType = 'R'"
            str &= "  and a.voucherdate < '" & Startdate & "'   "
            str &= "  group by a.VoucherType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumDebitJV(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            'str = " select isnull(sum(Debit) ,0.00)  as DebitJV from tblJVDtl TBD"
            'str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            'str &= " where TBD.AccountCode='" & AccountCode & "'"
            'str &= " and TBM.voucherdate < '" & Startdate & "' "

            str = " select isnull(sum(Debit) ,0.00)  as DebitJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & " '"
            str &= " and TBM.voucherdate < '" & Startdate & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningSumInvoiceAmountFromTransactio(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select isnull(sum(TBD.Debit) ,0.00)  as OBDebitINV,isnull(sum(TBD.Credit) ,0.00)  as OBCreditINV  from poinvoicemst TBM"
            str &= " join PoInvoiceTransaction TBD on TBM.poinvoicemstID=TBD.poinvoicemstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.Creationdate < '" & Startdate & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVMasterNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'D' then sum(Amount)  Else 0 End ,0.00)  as DebitBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBM.BookAccount='" & AccountCode & "'"
            'str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by TBD.Type"

            'str = "  select  isnull(sum(Amount),0) as  DebitBPV from tblbankmst a"
            'str &= " join tblbankdtl b on b.tblbankmstID=a.tblbankmstID"
            'str &= " where  b.Type = 'D' and  a.BookAccount='" & AccountCode & "'"
            'str &= " and a.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by b.Type"


            str = "  select    Case When a.VoucherType = 'P' Then isnull(sum(a.TotalAmount),0) Else 0 End As DebitBPV"
            str &= " from tblbankmst a "
            str &= " join TblAccounts Aa on Aa.AccountCode=a.BookAccount"
            str &= " where   a.BookAccount='" & AccountCode & "'"
            str &= " and a.voucherdate between '" & Startdate & "' and '" & Enddate & " ' "
            str &= " group by a.VoucherType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVWHT(ByVal AccountName As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select  isnull( TBD.WHTaxAmountDB,0)  As WHTaxAmountCR"
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.WhtaxPercentage <> 0 and  TBD.WhtaxPercentage='" & AccountName & "'"
            str &= " and TBM.voucherdate between  '" & Startdate & "' and '" & Enddate & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVWHTOB(ByVal AccountName As String, ByVal Startdate As String)
            Dim str As String
            str = " select  isnull( TBD.WHTaxAmountDB,0)  As WHTaxAmountCROB"
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.WhtaxPercentage <> 0 and  TBD.WhtaxPercentage='" & AccountName & "'"
            str &= " and TBM.voucherdate  <  '" & Startdate & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumCreditBPVNew(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            'str = " select isnull(Case When TBD.Type = 'C' then sum(Amount)  Else 0 End ,0.00)  as CreditBPV from tblBankdtl TBD"
            'str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            'str &= " where TBD.AccountCode='" & AccountCode & "'"
            'str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            'str &= " group by TBD.Type"

            str = "  select    isnull(Case When TBD.Type = 'C' and (TBD.Amount)>0 then TBD.Amount "
            str &= "   When TBD.Type = 'D' and (TBD.Amount)<0 THEN -1*TBD.Amount else 0 end,0.00) as CreditBPV "
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID "
            str &= "  where TBD.AccountCode='" & AccountCode & "'"
            str &= "  and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitBPVWHTOB(ByVal AccountCode As String, ByVal Startdate As String)
            Dim str As String
            str = " select  isnull( TBD.WHTaxAmountDB,0)  As WHTaxAmountDBOB"
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.WhtaxPercentage <> 0 and TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate  <  '" & Startdate & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitJV(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(Debit) ,0.00)  as DebitJV from tblJVDtl TBD"
            str &= " join tblJVmst TBM on TBM.tblJVMstID=TBD.tblJVMstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumDebitBPVWHT(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select  isnull( TBD.WHTaxAmountDB,0)  As WHTaxAmountDB"
            str &= " from tblBankdtldetail TBD "
            str &= " join tblBankmst TBM on TBM.tblBankmstID=TBD.tblBankmstID"
            str &= " where TBD.WhtaxPercentage <> 0 and TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.voucherdate between  '" & Startdate & "' and '" & Enddate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSumInvoiceAmountFromTransaction(ByVal AccountCode As String, ByVal Startdate As String, ByVal Enddate As String)
            Dim str As String
            str = " select isnull(sum(TBD.Debit) ,0.00)  as DebitINV,isnull(sum(TBD.Credit) ,0.00)  as CreditINV  from poinvoicemst TBM"
            str &= " join PoInvoiceTransaction TBD on TBM.poinvoicemstID=TBD.poinvoicemstID"
            str &= " where TBD.AccountCode='" & AccountCode & "'"
            str &= " and TBM.Creationdate between '" & Startdate & "' and '" & Enddate & " '"



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function




        Public Function GetOpeningBalanceDate(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " Select convert(varchar,OpenDate,103) as OpenDate from tblOpeningBal where AccountCode ='" & AccountCode & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertBPVDataNew(ByVal AccountCode As String)
            Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            Str &= " (select Top 1 TBD.ChequeNo from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as ChequeNo,"
            Str &= " (select Top 1 TBD.ChequeDate from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as ChequeDate,"
            str &= " TBM.Description,"
            str &= "  (select Top 1 TBD.DescriptionEntry from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as DescriptionEntry,"
            Str &= " (select distinct AccountName from TblAccounts TT "
            Str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            Str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            Str &= " Case When TBM.VoucherType = 'R' Then TBM.TotalAmount Else 0 End As Debit, "
            Str &= " Case When TBM.VoucherType = 'P' Then TBM.TotalAmount else 0 end as Credit"
            Str &= " from tblBankMst TBM  "
            Str &= " join TblAccounts A on A.AccountCode=TBM.BookAccount "
            str &= " where  TBM.BookAccount= '" & AccountCode & "' "
            Str &= " order By TBM.VoucherDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataWithOutBankNew(ByVal AccountCode As String)

            Dim str As String = "   INSERT INTO TempLedger"
            str &= " select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,"
            str &= "  (select Top 1 TBD.DescriptionEntry from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as DescriptionEntry,"
            str &= "   (select distinct AccountName from TblAccounts TT "
            str &= "   join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            str &= "   where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= "   Case When TBD.Type = 'D' and TBD.Amount>0 Then TBD.Amount"
            str &= " When TBD.Type = 'C' and TBD.Amount<0 then  -1*TBD.Amount Else 0 End As Debit, "
            str &= "   Case When TBD.Type = 'C' and TBD.Amount>0 then TBD.Amount"
            str &= " When TBD.Type = 'D' and TBD.Amount<0 THEN -1*TBD.Amount else 0 end as Credit"
            str &= " from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "    join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBD.AccountCode= '" & AccountCode & "' "
            str &= "    order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertJVDataNew(ByVal AccountCode As String)

            Dim str As String = "INSERT INTO TempLedger   select TBM.VoucherNo,TBM.VoucherDate , "
            str &= "  '' as ChequeNo,''as ChequeDate, TBM.Description, TBD.DescriptionEntry,"
            str &= " 'Journal Voucher' as 'AccountName',TBD.Debit, TBD.Credit"
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBD.AccountCode= '" & AccountCode & "' "
            str &= " order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLedgerForPrintNew2(ByVal OpeningBalance As Decimal) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.VoucherDate,103) as VoucherDatee,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedgerFinal a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "') + "
            str &= "TBM.Debit)- TBM.Credit) AS Balance,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedgerFinal a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= "from TempLedgerFinal TBM "
            str &= "order By TBM.VoucherDate ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUniqueAccountNameForPrintOBAccountCode(ByVal AccountName As String)
            Dim str As String
            str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA  where (TA.AccountName+'-'+ TA.AccountCode)='" & AccountName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempLedgerFinal()
            Dim str As String
            str = " truncate table TempLedgerFinal "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempLedgerIntoTempFinal()
            Dim str As String
            str = " insert into TempLedgerFinal select VoucherNo,VoucherDate,ChequeNo,ChequeDate,Description,DescriptionEntry,AccountName,Debit,"
            str &= " Credit from TempLedger order by voucherdate asc"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckInsertdataBackDate(ByVal Startdate As String)
            Dim str As String
            str = " Select * from TempLedgerFinal where VoucherDate < '" & Startdate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNew(ByVal OpeningBalance As Decimal, ByVal Startdate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.VoucherDate,103) as VoucherDatee,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedgerFinal a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "') + "
            str &= "TBM.Debit)- TBM.Credit) AS Balance,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedgerFinal a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= "from TempLedgerFinal TBM "
            str &= "where TBM.VoucherDate  between '" & Startdate & "' and  '" & EndDate & "' "
            str &= "order By TBM.VoucherDate ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempLedgerIntoTempFinalJustOPInsert(ByVal DescriptionEntry As String, ByVal openDate As String, ByVal OpeningBalance As String)
            Dim str As String
            If OpeningBalance > 0 Then
                OpeningBalance = OpeningBalance
                str = " insert into TempLedgerFinal '' as VoucherNo,'" & openDate & "' as VoucherDate,'' as ChequeNo,'' as ChequeDate,'' as Description,'" & DescriptionEntry & "' as DescriptionEntry,AccountName,'" & OpeningBalance & "' as Debit,"
                str &= " '0.00' as Credit "
            Else
                OpeningBalance = (-1) * OpeningBalance
                str = " insert into TempLedgerFinal '' as  VoucherNo,'" & openDate & "' as VoucherDate,'' as ChequeNo,'' as ChequeDate,'' as Description,'" & DescriptionEntry & "' as DescriptionEntry,AccountName,'0.0' as Debit,"
                str &= " '" & OpeningBalance & "' as Credit  "
            End If

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

