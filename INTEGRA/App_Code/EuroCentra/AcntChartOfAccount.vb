Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class AcntChartOfAccount
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblAccounts"
            m_strPrimaryFieldName = "ChartOfAccountID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lChartOfAccountID As Long
        Private m_strAccountCode As String
        Private m_strGroupAct As String
        Private m_strAccountName As String
        Private m_strAccountType As String
        Private m_strAccountLevel As String
        Private m_lAccountNature As Long
        Private m_lActLevelDigit As Long
        Private m_strRelatedAccount As String
        Private m_strRelatedTaxAccount As String
        Private m_strPartyBookAccount As String
        Private m_strAddress1 As String
        Private m_strAddress2 As String
        Private m_strPhone As String
        Private m_strFax As String
        Private m_strEmail As String
        Private m_strContactPerson As String
        Private m_strMobileNo As String
        Private m_strGstNo As String
        Private m_strNtnNo As String
        Private m_lCreditDays As Long
        Private m_lCreditLimit As Long
        Private m_lJanuary As Long
        Private m_lFebuary As Long
        Private m_lMarch As Long
        Private m_lApril As Long
        Private m_lMay As Long
        Private m_lJune As Long
        Private m_lJuly As Long
        Private m_lAugust As Long
        Private m_lSeptember As Long
        Private m_lOctober As Long
        Private m_lNovember As Long
        Private m_lDecember As Long
        Private m_strRemarks As String
        Private m_strCancel As String
        Private m_lClosingBalance As Long
        Private m_lTaxType As Long
        Private m_lLcValue As Long

        Private m_lCloseLC As Long
        Private m_strLCType As String
        Private m_dMaturityDate As Date
        Private m_strSectorCode As String
        Private m_lOpening_Debit As Long
        Private m_lOpening_Credit As Long
        Private m_strOld_Code As String
        Private m_strSwift_Code As String
        Private m_strAccount_Title As String
        Private m_strAccount_No As String

        Private m_strBranch_Name As String
        Private m_strBank_Name As String
        '-------------New Naeem
        Private m_dCurrency As Decimal
        Private m_strMaintainbalancebillbybill As String
        Private m_strInventoryvaluesareaffected As String
        Private m_strCostCentresareapplicable As String
        Private m_strAlowCostallocationStockItem As String
        Private m_strActivateInterestCalculation As String
        Private m_strIsCostAffected As String




        Public Property ChartOfAccountID() As Long
            Get
                ChartOfAccountID = m_lChartOfAccountID
            End Get
            Set(ByVal Value As Long)
                m_lChartOfAccountID = Value
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
        Public Property GroupAct() As String
            Get
                GroupAct = m_strGroupAct
            End Get
            Set(ByVal Value As String)
                m_strGroupAct = Value
            End Set
        End Property
        Public Property AccountName() As String
            Get
                AccountName = m_strAccountName
            End Get
            Set(ByVal Value As String)
                m_strAccountName = Value
            End Set
        End Property
        Public Property AccountType() As String
            Get
                AccountType = m_strAccountType
            End Get
            Set(ByVal Value As String)
                m_strAccountType = Value
            End Set
        End Property
        Public Property AccountLevel() As String
            Get
                AccountLevel = m_strAccountLevel
            End Get
            Set(ByVal Value As String)
                m_strAccountLevel = Value
            End Set
        End Property
        Public Property AccountNature() As Long
            Get
                AccountNature = m_lAccountNature
            End Get
            Set(ByVal Value As Long)
                m_lAccountNature = Value
            End Set
        End Property
        Public Property ActLevelDigit() As Long
            Get
                ActLevelDigit = m_lActLevelDigit
            End Get
            Set(ByVal Value As Long)
                m_lActLevelDigit = Value
            End Set
        End Property
        Public Property RelatedAccount() As String
            Get
                RelatedAccount = m_strRelatedAccount
            End Get
            Set(ByVal Value As String)
                m_strRelatedAccount = Value
            End Set
        End Property
        Public Property RelatedTaxAccount() As String
            Get
                RelatedTaxAccount = m_strRelatedTaxAccount
            End Get
            Set(ByVal Value As String)
                m_strRelatedTaxAccount = Value
            End Set
        End Property

        Public Property PartyBookAccount() As String
            Get
                PartyBookAccount = m_strPartyBookAccount
            End Get
            Set(ByVal Value As String)
                m_strPartyBookAccount = Value
            End Set
        End Property
        Public Property Address1() As String
            Get
                Address1 = m_strAddress1
            End Get
            Set(ByVal Value As String)
                m_strAddress1 = Value
            End Set
        End Property
        Public Property Address2() As String
            Get
                Address2 = m_strAddress2
            End Get
            Set(ByVal Value As String)
                m_strAddress2 = Value
            End Set
        End Property
        Public Property Phone() As String
            Get
                Phone = m_strPhone
            End Get
            Set(ByVal Value As String)
                m_strPhone = Value
            End Set
        End Property
        Public Property Fax() As String
            Get
                Fax = m_strFax
            End Get
            Set(ByVal Value As String)
                m_strFax = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Email = m_strEmail
            End Get
            Set(ByVal Value As String)
                m_strEmail = Value
            End Set

        End Property
        Public Property ContactPerson() As String
            Get
                ContactPerson = m_strContactPerson
            End Get
            Set(ByVal Value As String)
                m_strContactPerson = Value
            End Set
        End Property
        Public Property MobileNo() As String
            Get
                MobileNo = m_strMobileNo
            End Get
            Set(ByVal Value As String)
                m_strMobileNo = Value
            End Set
        End Property
        Public Property GstNo() As String
            Get
                GstNo = m_strGstNo
            End Get
            Set(ByVal Value As String)
                m_strGstNo = Value
            End Set
        End Property
        Public Property NtnNo() As String
            Get
                NtnNo = m_strNtnNo
            End Get
            Set(ByVal Value As String)
                m_strNtnNo = Value
            End Set
        End Property

        Public Property CreditDays() As Long
            Get
                CreditDays = m_lCreditDays
            End Get
            Set(ByVal Value As Long)
                m_lCreditDays = Value
            End Set
        End Property
        Public Property CreditLimit() As Long
            Get
                CreditLimit = m_lCreditLimit
            End Get
            Set(ByVal Value As Long)
                m_lCreditLimit = Value
            End Set
        End Property
        Public Property January() As Long
            Get
                January = m_lJanuary
            End Get
            Set(ByVal Value As Long)
                m_lJanuary = Value
            End Set
        End Property
        Public Property Febuary() As Long
            Get
                Febuary = m_lFebuary
            End Get
            Set(ByVal Value As Long)
                m_lFebuary = Value
            End Set
        End Property
        Public Property March() As Long
            Get
                March = m_lMarch
            End Get
            Set(ByVal Value As Long)
                m_lMarch = Value
            End Set
        End Property
        Public Property April() As Long
            Get
                April = m_lApril
            End Get
            Set(ByVal Value As Long)
                m_lApril = Value
            End Set
        End Property
        Public Property May() As Long
            Get
                May = m_lMay
            End Get
            Set(ByVal Value As Long)
                m_lMay = Value
            End Set
        End Property
        Public Property June() As Long
            Get
                June = m_lJune
            End Get
            Set(ByVal Value As Long)
                m_lJune = Value
            End Set
        End Property
        Public Property July() As Long
            Get
                July = m_lJuly
            End Get
            Set(ByVal Value As Long)
                m_lJuly = Value
            End Set
        End Property
        Public Property August() As Long
            Get
                August = m_lAugust
            End Get
            Set(ByVal Value As Long)
                m_lAugust = Value
            End Set
        End Property


        Public Property September() As Long
            Get
                September = m_lSeptember
            End Get
            Set(ByVal Value As Long)
                m_lSeptember = Value
            End Set
        End Property
        Public Property October() As Long
            Get
                October = m_lOctober
            End Get
            Set(ByVal Value As Long)
                m_lOctober = Value
            End Set
        End Property
        Public Property November() As Long
            Get
                November = m_lNovember
            End Get
            Set(ByVal Value As Long)
                m_lNovember = Value
            End Set
        End Property
        Public Property December() As Long
            Get
                December = m_lDecember
            End Get
            Set(ByVal Value As Long)
                m_lDecember = Value
            End Set

        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
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
        Public Property ClosingBalance() As Long
            Get
                ClosingBalance = m_lClosingBalance
            End Get
            Set(ByVal Value As Long)
                m_lClosingBalance = Value
            End Set
        End Property
        Public Property TaxType() As Long
            Get
                TaxType = m_lTaxType
            End Get
            Set(ByVal Value As Long)
                m_lTaxType = Value
            End Set
        End Property
        Public Property LcValue() As Long
            Get
                LcValue = m_lLcValue
            End Get
            Set(ByVal Value As Long)
                m_lLcValue = Value
            End Set
        End Property


        Public Property CloseLC() As Long
            Get
                CloseLC = m_lCloseLC
            End Get
            Set(ByVal Value As Long)
                m_lCloseLC = Value
            End Set
        End Property
        Public Property LCType() As String
            Get
                LCType = m_strLCType
            End Get
            Set(ByVal Value As String)
                m_strLCType = Value
            End Set
        End Property
        Public Property MaturityDate() As Date
            Get
                MaturityDate = m_dMaturityDate
            End Get
            Set(ByVal Value As Date)
                m_dMaturityDate = Value
            End Set
        End Property
        Public Property SectorCode() As String
            Get
                SectorCode = m_strSectorCode
            End Get
            Set(ByVal Value As String)
                m_strSectorCode = Value
            End Set
        End Property
        Public Property Opening_Debit() As Long
            Get
                Opening_Debit = m_lOpening_Debit
            End Get
            Set(ByVal Value As Long)
                m_lOpening_Debit = Value
            End Set
        End Property
        Public Property Opening_Credit() As Long
            Get
                Opening_Credit = m_lOpening_Credit
            End Get
            Set(ByVal Value As Long)
                m_lOpening_Credit = Value
            End Set
        End Property
        Public Property Old_Code() As String
            Get
                Old_Code = m_strOld_Code
            End Get
            Set(ByVal Value As String)
                m_strOld_Code = Value
            End Set
        End Property
        Public Property Swift_Code() As String
            Get
                Swift_Code = m_strSwift_Code
            End Get
            Set(ByVal Value As String)
                m_strSwift_Code = Value
            End Set
        End Property
        Public Property Account_Title() As String
            Get
                Account_Title = m_strAccount_Title
            End Get
            Set(ByVal Value As String)
                m_strAccount_Title = Value
            End Set
        End Property
        Public Property Account_No() As String
            Get
                Account_No = m_strAccount_No
            End Get
            Set(ByVal Value As String)
                m_strAccount_No = Value
            End Set
        End Property
        Public Property Branch_Name() As String
            Get
                Branch_Name = m_strBranch_Name
            End Get
            Set(ByVal Value As String)
                m_strBranch_Name = Value
            End Set
        End Property
        Public Property Bank_Name() As String
            Get
                Bank_Name = m_strBank_Name
            End Get
            Set(ByVal Value As String)
                m_strBank_Name = Value
            End Set
        End Property
        '-------------New  Naeem
        Public Property Currency() As Decimal
            Get
                Currency = m_dCurrency
            End Get
            Set(ByVal Value As Decimal)
                m_dCurrency = Value
            End Set
        End Property
        Public Property Maintainbalancebillbybill() As String
            Get
                Maintainbalancebillbybill = m_strMaintainbalancebillbybill
            End Get
            Set(ByVal Value As String)
                m_strMaintainbalancebillbybill = Value
            End Set
        End Property
        Public Property Inventoryvaluesareaffected() As String
            Get
                Inventoryvaluesareaffected = m_strInventoryvaluesareaffected
            End Get
            Set(ByVal Value As String)
                m_strInventoryvaluesareaffected = Value
            End Set
        End Property
        Public Property CostCentresareapplicable() As String
            Get
                CostCentresareapplicable = m_strCostCentresareapplicable
            End Get
            Set(ByVal Value As String)
                m_strCostCentresareapplicable = Value
            End Set
        End Property
        Public Property AlowCostallocationStockItem() As String
            Get
                AlowCostallocationStockItem = m_strAlowCostallocationStockItem
            End Get
            Set(ByVal Value As String)
                m_strAlowCostallocationStockItem = Value
            End Set
        End Property
        Public Property ActivateInterestCalculation() As String
            Get
                ActivateInterestCalculation = m_strActivateInterestCalculation
            End Get
            Set(ByVal Value As String)
                m_strActivateInterestCalculation = Value
            End Set
        End Property
        Public Property IsCostAffected() As String
            Get
                IsCostAffected = m_strIsCostAffected
            End Get
            Set(ByVal Value As String)
                m_strIsCostAffected = Value
            End Set
        End Property

        Public Function SaveChartOfAccount()
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
        ''''''''''''''
        Public Function GetAccountLevel()
            Dim str As String
            str = " select * from TblAccountLevel"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFiveBasic()
            Dim str As String
            '  str = " select * from tblAccounts AC where ChartOfAccountID in(1,2,3,4,5)"
            str = " select * from tblAccounts AC where AccountCode ='01' or AccountCode='02' or AccountCode='03' or AccountCode='04' or AccountCode='05'  order by AccountCode asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountCode()
            Dim str As String
            str = " Select Top 1(COA.AccountCode) From tblAccounts COA  order by COA.ChartOfAccountID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAssestsChild(ByVal ActLevelDigit As Integer, ByVal AccountNature As Integer)
            Dim str As String
            str = " Select * From tblAccounts where  ActLevelDigit= '" & ActLevelDigit & "' and AccountNature= '" & AccountNature & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAssestsChildLevelOne(ByVal strAccountName As String)
            Dim str As String
            ' str = " Select * From tblAccounts where  ActLevelDigit= 3 and AccountNature= 1"
            str = "  Select * From tblAccounts where GroupAct = '" & strAccountName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAssestsChildLevelTwo(ByVal strAccountName As String)
            Dim str As String
            ' str = " Select * From tblAccounts where  ActLevelDigit= 3 and AccountNature= 1"
            str = "  Select * From tblAccounts where GroupAct = '" & strAccountName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountCodeAssestsForChildLevelOne(ByVal AccountCode As String)
            Dim str As String
            ' str = " Select Top 1(COA.AccountCode),coa.GroupAct,COA.ActLevelDigit From tblAccounts COA  where COA.GroupAct='01' order by COA.AccountCode DESC "
            str = " Select Top 1(COA.AccountCode),coa.GroupAct,COA.ActLevelDigit From tblAccounts COA  where COA.GroupAct='" & AccountCode & "' order by COA.AccountCode DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountCodeAssestsForChildLevelTwo(ByVal strGroupAct As String)
            Dim str As String
            'str = " Select Top 1(COA.AccountCode),coa.GroupAct,COA.ActLevelDigit From tblAccounts COA  where COA.GroupAct='0101' order by COA.AccountCode DESC "
            str = " Select Top 1(COA.AccountCode),coa.GroupAct,COA.ActLevelDigit From tblAccounts COA  where COA.GroupAct='" & strGroupAct & "' order by COA.AccountCode DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDiffGroupValuebyAccountName(ByVal AccountName As String)
            Dim str As String
            str = " Select * From tblAccounts where  AccountName= '" & AccountName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '---For tree
        Public Function GetMembersTree(Optional ByVal memberid As String = "0")
            Dim Str As String
            '----(01)
            If memberid = 0 Then
                Str = "select AccountCode,AccountName,"
                Str &= " (select count(*) FROM tblAccounts WHERE ActLevelDigit=sc.ActLevelDigit)"
                Str &= " childnodecount FROM tblAccounts sc where ActLevelDigit=1  order by  AccountCode asc "
            Else
                Str = "select AccountCode,AccountName,"
                Str &= "(select count(*) FROM tblAccounts WHERE ActLevelDigit=sc.ActLevelDigit) childnodecount FROM tblAccounts sc"
                '----(01)
                If Len(memberid) = 2 Then
                    Str &= " where left(AccountCode,2)='" & memberid & "' and ActLevelDigit=2 order by  AccountCode asc "
                    '----(0101)
                ElseIf Len(memberid) = 4 Then
                    Str &= " where left(AccountCode,4)='" & memberid & "' and ActLevelDigit=3 order by  AccountCode asc"
                    '----(0101001)
                ElseIf Len(memberid) = 7 Then
                    Str &= " where left(AccountCode,7)='" & memberid & "' and ActLevelDigit=4  order by  AccountCode asc"
                    '----(0101001001)
                ElseIf Len(memberid) = 10 Then
                    Str &= " where left(AccountCode,10)='" & memberid & "' and ActLevelDigit=5 order by  AccountCode asc"
                    '----(0101001001001)
                ElseIf Len(memberid) = 13 Then
                    Str &= " where left(AccountCode,13)='" & memberid & "' and ActLevelDigit=6 order by  AccountCode asc"
                End If

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        ''Click on Tree and Show Information
        Public Function GetAccountCodeForInformation(ByVal AccountCode As String)
            Dim str As String
            str = " Select * From tblAccounts where  AccountCode= '" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOForSupplierName(ByVal AccountName As String)
            Dim Str As String
            '   Str = "select AccountName,AccountCode from tblAccounts where AccountNature=2 and ActLevelDigit=2   and AccountName like '" & AccountName & "%'"
            Str = "select AccountName,AccountCode from tblAccounts where AccountNature=2  and AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAccountLevel(ByVal strAccountName As String)
            Dim str As String
            ' str = " Select * From tblAccounts where  ActLevelDigit= 3 and AccountNature= 1"
            str = "  Select * From tblAccounts where AccountName = '" & strAccountName & "' and  AccountLevel='Detail'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckCustomer(ByVal ID As Long)
            Dim str As String
            ' str = " select * from tblaccounts where groupact like '0102%' and AccountLevel='Detail' and  ChartOfAccountID='" & ID & "'"
            str = " select * from tblaccounts where groupact like '0102003%' and AccountLevel='Detail' and  ChartOfAccountID='" & ID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierCurrentLibilities(ByVal ID As Long)
            Dim str As String
            str = " select * from tblaccounts where groupact like '0202%'    and AccountLevel='Detail' and  ChartOfAccountID='" & ID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierTradeCreaditor(ByVal ID As Long)
            Dim str As String
            str = " select * from tblaccounts where groupact like '0204%'  and AccountLevel='Detail' and  ChartOfAccountID='" & ID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerID(ByVal AccountCode As String)
            Dim str As String
            str = " select * from Customerdatabase where AccountCode='" & AccountCode & "'"

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerDetailID(ByVal CustomerDetailID As Long)
            Dim str As String
            str = " select * from CustomerDatabaseDetail where CustomerdatabaseID='" & CustomerDetailID & "'"

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierID(ByVal AccountCode As String)
            Dim str As String
            str = " select * from SupplierDatabase where SupplierCode='" & AccountCode & "'"

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierDetailID(ByVal SupplierDatabaseID As Long)
            Dim str As String
            str = " select * from SupplierDatabaseDetail where SupplierDatabaseID='" & SupplierDatabaseID & "'"

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetdataForAccountInfoPage(ByVal Bit As String)
            Dim str As String
            If Bit = "Group" Then
                str = " select * from tblaccounts where  AccountLevel='Control'  and Accountcode not in ('01','02','03','04','05')"
            Else
                str = " select * from tblaccounts where  AccountLevel='Detail' "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountNameForAccountInfoSearch(ByVal AccountName As String, ByVal Bit As String)
            Dim str As String
            If Bit = "Group" Then
                str = " select * from tblaccounts where  AccountLevel='Control' and AccountName like '" & AccountName & "%'"
            Else
                str = " select * from tblaccounts where  AccountLevel='Detail' and AccountName like '" & AccountName & "%'"
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountGroupSearch(ByVal AccountName As String, ByVal Bit As String)
            Dim str As String
            If Bit = "Group" Then
                'str = " select * from tblaccounts where  AccountLevel='Control' and AccountName = '" & AccountName & "%'"
                str = " select (select top 1 Accountname from tblAccounts tb where tb.accountcode=tbbb.GroupAct) "
                str &= " as groupActname,*  from tblaccounts tbbb"
                str &= " where  AccountLevel='Control' and accountname='" & AccountName & "'"
            Else
                'str = " select * from tblaccounts where  AccountLevel='Detail' and AccountName = '" & AccountName & "%'"
                str = " select (select top 1 Accountname from tblAccounts tb where tb.accountcode=tbbb.GroupAct) "
                str &= " as groupActname,*  from tblaccounts tbbb"
                str &= " where  AccountLevel='Detail' and accountname='" & AccountName & "'"
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountGroupGroupSearch(ByVal AccountCode As String)
            Dim str As String

            'str = " select * from tblaccounts where  AccountLevel='Control' and AccountName = '" & AccountName & "%'"
            'str = " select (select top 1 Accountname from tblAccounts tb where tb.accountcode=tbbb.GroupAct) "
            'str = " as groupActname,*  from tblaccounts tbbb"
            'str = " where  AccountLevel='Control' and accountname='" & AccountName & "'"
            str = " select (select top 1 Accountname from tblAccounts tb where tb.accountcode=tbbb.GroupAct) "
            str &= " as groupActname,*  from tblaccounts tbbb where accountcode='" & AccountCode & "'"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTO(ByVal AccountName As String, ByVal Bit As String)
            Dim Str As String
            If Bit = "Group" Then
                Str = " Select AccountName as Name from tblaccounts where AccountLevel='Control' and AccountName like '%" & AccountName & "%'"
            Else
                Str = " Select AccountName as Name from tblaccounts where AccountLevel='Detail' and AccountName like '%" & AccountName & "%'"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOAllLedger(ByVal AccountName As String)
            Dim Str As String
            ' Str = " Select AccountName as Name from tblaccounts where AccountLevel='Control' and AccountName like '%" & AccountName & "%' and Accountcode not in ('01','02','03','04','05')"
            Str = " Select AccountName as Name from tblaccounts where AccountLevel='Control' and AccountName like '%" & AccountName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETGroupActOfSelectedGroup(ByVal AccountName As String, ByVal ClickBitL As String)
            Dim Str As String
            If ClickBitL = "Ledger" Then
                Str = " Select AccountCode as GroupAct ,* from tblaccounts where  AccountLevel='Detail' and AccountName like '" & AccountName & "'"
            Else
                Str = " Select AccountCode as GroupAct ,* from tblaccounts where AccountLevel='Control' and  AccountName like '" & AccountName & "'"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETToInformationOfSelectedGroup(ByVal groupact As String, ByVal ClickBitL As String)
            Dim Str As String

            If ClickBitL = "Ledger" Then
                Str = " select top 1 AccountCode ,* from tblaccounts where AccountLevel='Detail' and groupact='" & groupact & "' order by Chartofaccountid desc"
            Else
                Str = " select top 1 AccountCode ,* from tblaccounts where AccountLevel='Control' and groupact='" & groupact & "' order by Chartofaccountid desc"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETCheckAccountcode(ByVal groupact As String)
            Dim Str As String


            Str = " select top 1 AccountCode  from tblaccounts where AccountLevel='Detail' and groupact='" & groupact & "' order by Chartofaccountid desc"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        '-----Check Deleted

        Public Function CheckcustomerinJobtable(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from joborderdatabase JO Join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID join Tblaccounts tblb on tblb.AccountCode=CD.AccountCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromYarnPurContract(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from TblYarnPurchaseContractDetail JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierDatabaseID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromYarnReturnYarnPurContract(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from YarnReturnForYarnContract JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierDatabaseID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromYarnRecvMaster(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from YarnRecvMaster JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromYarnIssueDtl(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from YarnIssueDtl JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.KnitterID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromYarnReturn(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from YarnReturn JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.KnitterID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromFabricReceiving(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from FabricReceiving JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierDatabaseID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromFabricReturn(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from FabricReturn JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierDatabaseID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromInspection(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from Inspection JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.KnitterID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromInspectionMst(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from InspectionMst JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.KnitterID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromPODetail(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from PODetail JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.AccountPayablePartyID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromPORecvMaster(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from PORecvMaster JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromPORecvDetailTwo(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from PORecvDetailTwo JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.SupplierID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromPOInvoiceMst(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from POInvoiceMst JO Join SupplierDatabase CD on CD.SupplierDatabaseID=JO.AccountPayablePartyID join Tblaccounts tblb on tblb.AccountCode=CD.SupplierCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromtblBankMst(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from tblBankMst JO  join Tblaccounts tblb on tblb.AccountCode=JO.BookAccount where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromtblBankDtl(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from tblBankDtl JO  join Tblaccounts tblb on tblb.AccountCode=JO.AccountCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataforView() As DataTable
            Dim str As String
            str = " select *, case when AccountLevel='Control' then 'Group' else 'Ledger'  end as AccountTypee from tblAccounts order by accountcode"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSupplierFromtblJvDtl(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from tblJvDtl JO  join Tblaccounts tblb on tblb.AccountCode=JO.AccountCode where tblb.AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Checktblaccounts(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select * from tblaccounts tblb  where tblb.GroupAct='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteCustomerDatabase(ByVal AccountCode As String)
            Dim Str As String
            Str = " delete from CustomerDatabase where AccountCode='" & AccountCode & " '"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertIntoDeleteAccountsTabale(ByVal AccountCode As String)
            Dim Str As String
            Str = " Insert into tblDeleteAccounts  "
            Str &= " select AccountCode, GroupAct, AccountName, AccountType , AccountLevel , AccountNature , ActLevelDigit , RelatedAccount ,"
            Str &= " RelatedTaxAccount , PartyBookAccount , Address1, Address2 , Phone, Fax ,Email ,ContactPerson , MobileNo ,GstNo ,"
            Str &= " NtnNo, CreditDays, CreditLimit, January, Febuary, March, April, May, June, July, August, September, October"
            Str &= " ,November ,December ,Remarks ,Cancel,ClosingBalance ,TaxType,LcValue , Currency , CloseLC , LCType,MaturityDate, "
            Str &= " SectorCode ,Opening_Debit ,Opening_Credit ,Old_Code ,Swift_Code ,Account_Title, Account_No ,Branch_Name ,Bank_Name,"
            Str &= " Maintainbalancebillbybill ,Inventoryvaluesareaffected,CostCentresareapplicable , AlowCostallocationStockItem ,"
            Str &= " ActivateInterestCalculation , IsCostAffected from tblaccounts where AccountCode='" & AccountCode & " '"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        '-----Delete


        Public Function DeleteCustomerDatabaseDetail(ByVal AccountCode As String)
            Dim Str As String
            Str = " Delete from CustomerDatabaseDetail where CustomerDatabaseid in ( select CustomerDatabaseid from CustomerDatabase  where AccountCode='" & AccountCode & " ')"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteSupplierDatabaseDatabase(ByVal AccountCode As String)
            Dim Str As String
            Str = " delete from SupplierDatabase where SupplierCode='" & AccountCode & " '"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteSupplierDatabaseDatabaseDetail(ByVal AccountCode As String)
            Dim Str As String
            Str = " Delete from SupplierDatabaseDetail where SupplierDatabaseID in ( select SupplierDatabaseID from SupplierDatabase  where SupplierCode='" & AccountCode & " ')"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteCustomerChrtaccount(ByVal AccountCode As String)
            Dim Str As String
            Str = " delete from tblaccounts where AccountCode='" & AccountCode & " '"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckNTNNO(ByVal NTNNO As String)
            Dim str As String
            str = " select * from tblaccounts where  NTNNO='" & NTNNO & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckGSTNO(ByVal GSTNO As String)
            Dim str As String
            str = " select * from tblaccounts where GSTNo='" & GSTNO & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAccountName(ByVal AccountName As String)
            Dim str As String
            str = " select * from tblaccounts where AccountName='" & AccountName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAccountNameWithConNDetail(ByVal AccountName As String, ByVal AccountLevel As String)
            Dim str As String
            str = " select * from tblaccounts where AccountLevel='" & AccountLevel & "' and  AccountName='" & AccountName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteGroupChrtaccount(ByVal AccountCode As String)
            Dim Str As String
            Str = " delete from tblaccounts where AccountCode='" & AccountCode & " '"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateAccount(ByVal ChartOfAccountID As String, ByVal AccountNamee As String, ByVal OpeningDebit As String, ByVal OpeninpCredit As String)
            Dim Str As String
            Str = " update  tblaccounts set AccountName='" & AccountNamee & "',Opening_Debit='" & OpeningDebit & "',Opening_Credit='" & OpeninpCredit & "' where ChartOfAccountID = '" & ChartOfAccountID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAllChartAccountControlData()
            Dim str As String
            str = " Select AccountCode,accountName,GroupAct From tblAccounts COA where actLeveldigit=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllChartAccountControlDataForSecondPhase(ByVal AccountCode As String)
            Dim str As String
            str = " Select AccountCode,accountName,GroupAct From tblAccounts COA where GroupAct='" & AccountCode & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetAccountsOfDetailLevel() As DataTable
            Dim str As String
            str = "select * from tblAccounts where AccountLevel ='Detail'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function UpdateAccountOpenings(ByVal ChartOfAccountID As String, ByVal OpeningDebit As String, ByVal OpeninpCredit As String)
            Dim Str As String
            Str = " update  tblaccounts set Opening_Credit='" & OpeninpCredit & "',Opening_Debit='" & OpeningDebit & "' where ChartOfAccountID = '" & ChartOfAccountID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function


        Public Function IsRecordExistInOtherTables(ByVal AccountCode As String) As Boolean

            Dim Str As String
            Str = "select AccountCode from tblBankDtlDetail WHERE AccountCode = '" & AccountCode & "'  UNION ALL select AccountCode from tblBankDtl WHERE AccountCode = '" & AccountCode & "' UNION ALL select AccountCode from contraVoucherDtl WHERE AccountCode = '" & AccountCode & "' UNION All select AccountCode from contraVoucherMSt WHERE AccountCode = '" & AccountCode & "' UNION ALL select AccountCode from tblJvDtl WHERE AccountCode = '" & AccountCode & "' UNION ALL select AccountCode from tblCashDtl WHERE AccountCode = '" & AccountCode & "'"
            Try
                Return MyBase.IsRecordExists(Str)
            Catch ex As Exception

            End Try
        End Function


        Public Function UpdateAccountName(ByVal ChartOfAccountID As String, ByVal Account_Name As String)
            Dim Str As String
            Str = " update  tblaccounts set AccountName='" & Account_Name & "' where ChartOfAccountID = '" & ChartOfAccountID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function DeleteAccount(ByVal ChartOfAccountID As String)
            Dim Str As String
            Str = " Delete From tblaccounts where ChartOfAccountID = '" & ChartOfAccountID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


