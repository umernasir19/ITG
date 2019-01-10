Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class tblDeleteAccounts

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblAccounts"
            m_strPrimaryFieldName = "DeleteChartOfAccountID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDeleteChartOfAccountID As Long
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




        Public Property DeleteChartOfAccountID() As Long
            Get
                DeleteChartOfAccountID = m_lDeleteChartOfAccountID
            End Get
            Set(ByVal Value As Long)
                m_lDeleteChartOfAccountID = Value
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
        Public Function GetdataOfDeleteAccounts()
            Dim str As String
            str = " select * from tblDeleteAccounts  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace



