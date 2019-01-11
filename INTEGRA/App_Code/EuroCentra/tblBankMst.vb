Imports Microsoft.VisualBasic
Imports System.Data
Namespace classes
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
        Private m_cashTypeID As Long
        Private m_PresentedID As Long
        Private m_LockBit As Boolean


        Public Property LockBit() As Boolean
            Get
                LockBit = m_LockBit
            End Get
            Set(ByVal Value As Boolean)
                m_LockBit = Value
            End Set
        End Property

        Public Property CashTypeID() As Long
            Get
                CashTypeID = m_cashTypeID
            End Get
            Set(ByVal Value As Long)
                m_cashTypeID = Value
            End Set
        End Property

        Public Property PresentedID() As Long
            Get
                PresentedID = m_PresentedID
            End Get
            Set(ByVal Value As Long)
                m_PresentedID = Value
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
        Function GETOrderbysearch(ByVal AcidName As String)
            Dim Str As String
            Str = "  select REPLACE(KMMM.OrderNo, '/', '_')  from POMasterForOrderSheet PO"
            Str &= "  left join  PODetailForOrderSheet POD on PO.POMasterForOrderSheetID=POD.POMasterForOrderSheetID "
            Str &= "  left join ItemProduct IP on  IP.ItemID=POD.ITEMID  "
            Str &= "   left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            Str &= "  left join KAIORDERMASTER KMMM on KMMM.KAIORDERMASTERID=POD.KAIORDERMASTERID where REPLACE(KMMM.OrderNo, '/', '/') Like '" & AcidName & "%'"
            Str &= "   order by PO.POMasterForOrderSheetID DESC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETBuyerbysearch(ByVal AcidName As String)
            Dim Str As String
            Str = "  select  distinct CD.CustomerName  from POMasterForOrderSheet PO"
            Str &= "  left join  PODetailForOrderSheet POD on PO.POMasterForOrderSheetID=POD.POMasterForOrderSheetID "
            Str &= "  left join ItemProduct IP on  IP.ItemID=POD.ITEMID  "
            Str &= "   left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            Str &= "  left join KAIORDERMASTER KMMM on KMMM.KAIORDERMASTERID=POD.KAIORDERMASTERID "
            Str &= " left join  CustomerDatabase CD on CD.CustomerDatabaseID=KMMM.CustomerID where CD.CustomerName Like '" & AcidName & "%'"
            Str &= "   order by   CD.CustomerName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETBuyerbysearchNew(ByVal AcidName As String)
            Dim Str As String
            Str = "  select  distinct CD.CustomerName  from  KAIORDERMASTER KMMM "
            Str &= " join  CustomerDatabase CD on CD.CustomerDatabaseID=KMMM.CustomerID where CD.CustomerName Like '" & AcidName & "%'"
            Str &= "   order by   CD.CustomerName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderbysearchForKnittingProgram(ByVal AcidName As String)
            Dim Str As String
            Str = "  select REPLACE(KMMM.OrderNo, '/', '_')  from KAIOrderFabricationSamplingMaster PO"
            Str &= "  left join KAIORDERMASTER KMMM on KMMM.KAIORDERMASTERID=PO.KAIORDERMASTERID where REPLACE(KMMM.OrderNo, '/', '/') Like '" & AcidName & "%'"
            Str &= "   order by PO.KAIOrderFabricationSamplingMasterID DESC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItembysearch(ByVal AcidName As String)
            Dim Str As String
            Str = "  select  distinct IP.ItemName  from POMasterForOrderSheet PO"
            Str &= "  left join  PODetailForOrderSheet POD on PO.POMasterForOrderSheetID=POD.POMasterForOrderSheetID "
            Str &= "  left join ItemProduct IP on  IP.ItemID=POD.ITEMID  "
            Str &= "   left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            Str &= "  left join KAIORDERMASTER KMMM on KMMM.KAIORDERMASTERID=POD.KAIORDERMASTERID "
            Str &= " left join  CustomerDatabase CD on CD.CustomerDatabaseID=KMMM.CustomerID where IP.ItemName Like '" & AcidName & "%'"
            Str &= "   order by   IP.ItemName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETSupplierbysearch(ByVal AcidName As String)
            Dim Str As String
            Str = "  select  distinct SD.SupplierName  from POMasterForOrderSheet PO"
            Str &= "  left join  PODetailForOrderSheet POD on PO.POMasterForOrderSheetID=POD.POMasterForOrderSheetID "
            Str &= "  left join KAIORDERMASTER KMMM on KMMM.KAIORDERMASTERID=POD.KAIORDERMASTERID  join SupplierDatabase SD on SD.SupplierDatabaseId= POD.AccountPayablePartyid  "
            Str &= "  where SD.SupplierName Like '" & AcidName & "%'"
            Str &= "   order by   SD.SupplierName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductNamebySearch(ByVal ItemName As String, ByVal ItemCode As String)
            Dim Str As String
            Str = "select distinct ItemName  From ItemProduct  where ItemName Like '%" & ItemName & "%' and Itemcode Like '" & ItemCode & "%' and ItemLevel =2 "
            'Str = " select ItemCode,ItemName From ItemProduct  where left(ItemCode,2)='" & ItemCode & "'  and ItemLevel=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductNamebySearchNew(ByVal ItemName As String, ByVal ItemCode As String)
            Dim Str As String
            Str = "select distinct REPLACE(ItemName, '''', '-')  From ItemProduct  where REPLACE(ItemName, '''', '''') Like '%" & ItemName & "%' and Itemcode Like '" & ItemCode & "%' and ItemLevel =2 "
            'Str = " select ItemCode,ItemName From ItemProduct  where left(ItemCode,2)='" & ItemCode & "'  and ItemLevel=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetMillForFabricRecv(ByVal Mill As String)
            Dim Str As String
            Str = "  select Distinct  (Isnull(Fd.MillOne,'')+','+ Isnull(Fd.MillTwo,'')+','+ Isnull(Fd.MillThree,'')+','+Isnull(Fd.DyedMillOne,'')+','+ Isnull(Fd.DyedMillTwo,'')+','+ Isnull(Fd.DyedMillThree,''))  AS Name from FabricReceivingDetail Fd"
            Str &= " where (Isnull(Fd.MillOne,'')+','+ Isnull(Fd.MillTwo,'')+','+ Isnull(Fd.MillThree,'')+','+Isnull(Fd.DyedMillOne,'')+','+ Isnull(Fd.DyedMillTwo,'')+','+ Isnull(Fd.DyedMillThree,''))  Like '%" & Mill & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetYarnCountForFabricRecv(ByVal YarnCount As String)
            Dim Str As String
            Str = "  select Distinct (Isnull(One.YarnCount,'')+','+ Isnull(Two.YarnCount,'')+','+ Isnull(Three.YarnCount,'')+','+ Isnull(dyedThree.YarnCount,'')+','+ Isnull(dyedone.YarnCount,'')+','+ Isnull(dyedtwo.YarnCount,'')) AS Name from FabricReceivingDetail Fd"
            Str &= " left join YarnDatabase One on One.YarnDatabaseID=Fd.YarnDatabaseID"
            Str &= " left join YarnDatabase Two on Two.YarnDatabaseID=Fd.YarnDatabaseID2"
            Str &= " left join YarnDatabase Three on Three.YarnDatabaseID=Fd.YarnDatabaseID3  left join YarnDatabase dyedOne on dyedOne.YarnDatabaseID=Fd.YarnDyedDataBaseID1    left join YarnDatabase dyedTwo on dyedTwo.YarnDatabaseID=Fd.YarnDyedDataBaseID2    left join YarnDatabase dyedThree on dyedThree.YarnDatabaseID=Fd.YarnDyedDataBaseID3   "
            Str &= " where  (Isnull(One.YarnCount,'')+','+ Isnull(Two.YarnCount,'')+','+ Isnull(Three.YarnCount,'')+','+ Isnull(dyedThree.YarnCount,'')+','+ Isnull(dyedone.YarnCount,'')+','+ Isnull(dyedtwo.YarnCount,'')) Like '%" & YarnCount & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByOrderForFabricRecv(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct REPLACE(m.OrderNo, '/', '_') As Name  from FabricReceiving PO join KaiorderMaster m on m.KaiorderMasterID=PO.KaiorderMstID"
            Str &= "   where REPLACE(m.OrderNo, '/', '/') Like '" & OrderNo & "%'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETFabricForFBRecv(ByVal Fabric As String)
            Dim Str As String
            Str = " Select Distinct FR.Fabric as Name from FabricReceivingDetail FR"
            Str &= " where FR.Fabric like '%" & Fabric & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETSupplierNameWise(ByVal SupplierName As String)
            Dim Str As String
            Str = " Select Distinct SD.SupplierName as Name from FabricReceiving FR"
            Str &= "  join SupplierDatabase SD on SD.SupplierDatabaseId= FR.SupplierDatabaseId   "
            Str &= " where SD.SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderNoFroStitchProduction(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct   REPLACE(KOM.OrderNo, '/', '_') as OrderNo from TblDailyProduction TDP   join KAIOrderMaster KOM on KOM.KAIOrderMasterID=TDP.KAIOrderMasterID  where REPLACE(KOM.OrderNo, '/', '_') like '%" & OrderNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETUnitFroStitchProduction(ByVal UserName As String)
            Dim Str As String
            Str = "  select  distinct U.UserName from TblDailyProduction TDP      join UMUser U on U.UserId=TDP.UserID   where U.UserName like '%" & UserName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETDateFroStitchProduction(ByVal ProductionDate As String)
            Dim Str As String
            Str = "   select distinct REPLACE( CONVERT(varchar,TDP.ProductionDate,103), '/', '_') as ProDate  from TblDailyProduction TDP where REPLACE( CONVERT(varchar,TDP.ProductionDate,103), '/', '_') like '%" & ProductionDate & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETOrderNoFroPackingProduction(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct   REPLACE(KOM.OrderNo, '/', '_') as OrderNo from TblDailyPacking TDP   join KAIOrderMaster KOM on KOM.KAIOrderMasterID=TDP.KAIOrderMasterID  where REPLACE(KOM.OrderNo, '/', '_') like '%" & OrderNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETUnitFroPackingProduction(ByVal UserName As String)
            Dim Str As String
            Str = "  select  distinct U.UserName from TblDailyPacking TDP      join UMUser U on U.UserId=TDP.UserID   where U.UserName like '%" & UserName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETDateFroPackingProduction(ByVal ProductionDate As String)
            Dim Str As String
            Str = "   select distinct REPLACE( CONVERT(varchar,TDP.ProductionDate,103), '/', '_') as ProDate  from TblDailyPacking TDP where REPLACE( CONVERT(varchar,TDP.ProductionDate,103), '/', '_') like '%" & ProductionDate & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETContractNo(ByVal ContractNo As String)
            Dim Str As String
            Str = " Select ContractNo as Name from TblYarnPurchaseContractMaster where ContractNo like '%" & ContractNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETMillName(ByVal Mill As String)
            Dim Str As String
            Str = " Select distinct upper(Mill) as Name from TblYarnPurchaseContractMaster where Mill like '%" & Mill & "%'"

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
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=3 and actleveldigit=5 and Groupact='0302003006' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTimeForNaeemBank() As DataTable
            Dim str As String
            'str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            'str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            ' str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=3 and actleveldigit=5 and Groupact='0302003006' "
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where  Groupact='0102009001' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPayType() As DataTable
            Dim str As String
            'str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            'str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            ' str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=3 and actleveldigit=5 and Groupact='0302003006' "
            str = "select * from tblType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetPresentedType() As DataTable
            Dim str As String
            'str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            'str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102004' "
            ' str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=3 and actleveldigit=5 and Groupact='0302003006' "
            str = "select * from tblpresentation"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetBookAccountFirstTimeForNaeemBankForContraVoucher() As DataTable
            Dim str As String
            '  str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=3 and actleveldigit=5 and Groupact='0302003006' "
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where   Groupact='0102009001' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTimeForNaeemCash() As DataTable
            Dim str As String
            ' str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0102005' "
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
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' order By tblBankMstID DESC"
            str = " select  Max(substring( VoucherNo,11,5)) as VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "'  "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastVoucherNoNew(ByVal Month As Integer, ByVal year As Integer, ByVal VoucherType As String)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' order By tblBankMstID DESC"
            str = " select  isnull(Max(substring( VoucherNo,11,5)),0) as VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "'  and VoucherType='" & VoucherType & "' "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBankVoucherforViewForHd() As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.tblBankMstID DESC"
            '  str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID  order By TBM.voucherNo DESC"
            str = "select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,CONVERT(varchar,CAST((TBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " ,TBM.LockBit from tblBankMst TBM where TBM.tblBankMstID=0"
            str &= " order By TBM.tblBankMstID DESC"
            Try
                Return MyBase.GetDataTable(str)
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
            str &= " ,TBM.LockBit,(case when TBM.VoucherDate < '07/01/2017' then '1' else '0' end ) as BitBackDate from tblBankMst TBM "
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

        Function GETAUTOAccountName(ByVal AccountName As String)
            Dim Str As String
            Str = " Select AccountName as Name from tblAccounts where AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOAccountNameForKAI(ByVal AccountName As String)
            Dim Str As String
            Str = " Select AccountName as Name from tblAccounts where AccountName like '" & AccountName & "%' and AccountLevel='Detail'"
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
        'Public Function GetVoucherNoAllInfo(ByVal VoucherNo As String) As DataTable
        '    Dim str As String
        '    ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID   order By TBM.voucherNo DESC"
        '    str = " select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
        '    str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
        '    str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
        '    str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
        '    str &= " from tblBankMst TBM "
        '    str &= " where VoucherNo ='" & VoucherNo & "' "

        '    Try
        '        Return MyBase.GetDataTable(str)
        '    Catch ex As Exception

        '    End Try
        'End Function
        Public Function GetVoucherNoAllInfo(ByVal VoucherNo As String) As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID   order By TBM.voucherNo DESC"
            str = " select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " ,TBM.LockBit,(case when TBM.VoucherDate < '07/01/2017' then '1' else '0' end ) as BitBackDate from tblBankMst TBM "
            str &= " where VoucherNo ='" & VoucherNo & "' OR (Select TOP 1 accountname from tblBankMst TM join tblBankDtl TB ON TM.tblBankMstid=TB.tblBankMstid"
            str &= " JOIN TBLACCOUNTS AC ON AC.Accountcode=TB.Accountcode WHERE TM.tblBankMstid=TBM.tblBankMstid)='" & VoucherNo & "' "
            str &= " OR (Select TM.description from tblBankMst TM where TM.tblBankMstid=TBM.tblBankMstid)='" & VoucherNo & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVoucherNoAllInfoForDrCr(ByVal VoucherNo As String) As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID   order By TBM.voucherNo DESC"
            str = " select  TBM.tblBankMstID,TBM.VoucherNo,convert(varchar,TBM.VoucherDate,103) as VoucherDate"
            str &= " ,TBM.Description,TBM.VoucherType,TBM.UserId,TBM.TotalAmount,"
            str &= " Case When VoucherType = 'P' Then TotalAmount Else 0 End As Debit,"
            str &= " Case When VoucherType = 'R' then TotalAmount else 0 end as Credit"
            str &= " ,TBM.LockBit,(case when TBM.VoucherDate < '07/01/2017' then '1' else '0' end ) as BitBackDate from tblBankMst TBM "
            str &= " where (Select TotalAmount from tblBankMst TM where VoucherType = 'P' and TM.tblBankMstid=TBM.tblBankMstid)='" & VoucherNo & "' "
            str &= " OR (Select TotalAmount from tblBankMst TM where VoucherType = 'R' and TM.tblBankMstid=TBM.tblBankMstid)='" & VoucherNo & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOParty(ByVal VoucherNo As String)
            Dim Str As String
            Str = "  Select DISTINCT accountname as Name from tblBankMst TM join tblBankDtl TB ON TM.tblBankMstid=TB.tblBankMstid"
            Str &= " JOIN TBLACCOUNTS AC ON AC.Accountcode=TB.Accountcode  where accountname like '%" & VoucherNo & "%' and ac.AccountLevel='Detail'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTODBAmt(ByVal VoucherNo As String)
            Dim Str As String
            Str = "  Select DISTINCT Case When VoucherType = 'P' Then TotalAmount Else 0 End  as Name from tblBankMst TM join tblBankDtl TB ON TM.tblBankMstid=TB.tblBankMstid"
            Str &= " where TM.TotalAmount like '%" & VoucherNo & "%' and  VoucherType = 'P'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOCRAmt(ByVal VoucherNo As String)
            Dim Str As String
            Str = "  Select DISTINCT Case When VoucherType = 'R' Then TotalAmount Else 0 End  as Name from tblBankMst TM join tblBankDtl TB ON TM.tblBankMstid=TB.tblBankMstid"
            Str &= " where TM.TotalAmount like '%" & VoucherNo & "%' and  VoucherType = 'R'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOTblBankMstDescription(ByVal VoucherNo As String)
            Dim Str As String
            Str = "  Select DISTINCT TM.description as Name from tblBankMst TM join tblBankDtl TB ON TM.tblBankMstid=TB.tblBankMstid"
            Str &= " where TM.description like '%" & VoucherNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
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
        Public Function GetUniqueAccountNameForPrintOBAccountCode(ByVal AccountName As String)
            Dim str As String
            str = " Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA  where (TA.AccountName+'-'+ TA.AccountCode)='" & AccountName & "'"

            Try
                Return MyBase.GetDataTable(str)
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
        Public Function InsertBPVData(ByVal AccountCode As String, ByVal Startdate As String, ByVal EndDate As String)

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
            str &= " where VoucherDate between '" & Startdate & "' and  '" & EndDate & "' and TBM.BookAccount= '" & AccountCode & " ' "


            str &= " order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataNew(ByVal AccountCode As String)

            'Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            'str &= " TBD.ChequeNo,TBD.ChequeDate,"
            'str &= " TBM.Description,TBD.DescriptionEntry,"
            'str &= " (select distinct AccountName from TblAccounts TT "
            'str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            'str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            'str &= " Case When TBD.Type = 'C' Then TBD.Amount Else 0 End As Debit, "
            'str &= " Case When TBD.Type = 'D' then TBD.Amount else 0 end as Credit"
            'str &= " from tblBankMst TBM  "
            'str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            'str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            'str &= " where   TBM.BookAccount= '" & AccountCode & " ' "
            'str &= " order By TBM.VoucherDate ASC"



            Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            Str &= " (select Top 1 TBD.ChequeNo from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as ChequeNo,"
            Str &= " (select Top 1 TBD.ChequeDate from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as ChequeDate,"
            Str &= " TBM.Description,TBM.Description as DescriptionEntry,"
            Str &= " (select distinct AccountName from TblAccounts TT "
            Str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            Str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            Str &= " Case When TBM.VoucherType = 'R' Then TBM.TotalAmount Else 0 End As Debit, "
            Str &= " Case When TBM.VoucherType = 'P' Then TBM.TotalAmount else 0 end as Credit"
            Str &= " from tblBankMst TBM  "
            Str &= " join TblAccounts A on A.AccountCode=TBM.BookAccount "
            str &= " where  TBM.BookAccount= '" & AccountCode & "' "
            str &= " order By TBM.VoucherDate  ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataWithOutBank(ByVal AccountCode As String, ByVal Startdate As String, ByVal EndDate As String)

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
            str &= " where  VoucherDate between '" & Startdate & "' and  '" & EndDate & "' and  TBD.AccountCode= '" & AccountCode & " ' "

            str &= " order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataWithOutBankNew(ByVal AccountCode As String)

            'Dim str As String = "INSERT INTO TempLedger select TBM.VoucherNo,TBM.VoucherDate ,"
            'str &= " TBD.ChequeNo,TBD.ChequeDate,"
            'str &= " TBM.Description,TBD.DescriptionEntry,"
            'str &= " (select distinct AccountName from TblAccounts TT "
            'str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            'str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            'str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            'str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            'str &= " from tblBankMst TBM  "
            'str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            'str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            'str &= " where TBD.AccountCode= '" & AccountCode & " ' "

            'str &= " order By TBM.VoucherDate ASC"

            Dim str As String = "   INSERT INTO TempLedger"
            str &= " select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
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
            str &= "    order By TBM.VoucherDate  ASC"

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
        Public Function InsertJVData(ByVal AccountCode As String, ByVal Startdate As String, ByVal EndDate As String)

            Dim str As String = "INSERT INTO TempLedger   select TBM.VoucherNo,TBM.VoucherDate , "
            str &= "  '' as ChequeNo,''as ChequeDate, TBM.Description, TBD.DescriptionEntry,"
            str &= " 'Journal Voucher' as 'AccountName',TBD.Debit, TBD.Credit"
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where  TBM.VoucherDate between '" & Startdate & "' and  '" & EndDate & "' and TBD.AccountCode= '" & AccountCode & " ' "
            str &= " order By TBM.VoucherDate ASC"


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
            str &= " order By TBM.VoucherDate  ASC"


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
            str = " select isnull(Opening_Debit,0) as Opening_Debit,isnull(Opening_Credit,0) as Opening_Credit,* from tblAccounts where AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpDate(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " select isnull(Opening_Debit,0) as Opening_Debit,isnull(Opening_Credit,0) as Opening_Credit,* from tblAccounts where AccountCode='" & AccountCode & "'"
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
        Public Function GetOpeningBalance(ByVal AccountCode As String) As DataTable
            Dim str As String
            str = " Select * from tblOpeningBal where AccountCode ='" & AccountCode & "'"
            If AccountCode = 0 Then
                str = " select * from tblAccounts "
            Else
                '   str = " select isnull(Sum(OpeningBalance),0)  as OpeningBalance from tblOpeningBalance where AccountCode ='" & AccountCode & "'"
                str = " Select * from tblAccounts where AccountCode ='" & AccountCode & "'"

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOpeningBalanceNew(ByVal AccountCode As String) As DataTable
            Dim str As String
            If AccountCode = 0 Then
                str = " select * from tblAccounts "
            Else
                '   str = " select isnull(Sum(OpeningBalance),0)  as OpeningBalance from tblOpeningBalance where AccountCode ='" & AccountCode & "'"
                str = " Select * from tblAccounts where AccountCode ='" & AccountCode & "'"

            End If

            Try
                Return MyBase.GetDataTable(str)
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
        Public Function GetLedgerForPrintNew(ByVal OpeningBalance As Decimal, ByVal Startdate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.VoucherDate,103) as VoucherDatee,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedgerFinal a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "') + "
            str &= "TBM.Debit)- TBM.Credit) AS Balance,"
            str &= "((ISNULL((SELECT sum(a.Debit) - sum(a.Credit) FROM TempLedgerFinal a "
            str &= "WHERE a.TempID<TBM.TempID ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= "from TempLedgerFinal TBM "
            str &= "where TBM.VoucherDate between '" & Startdate & "' and  '" & EndDate & "' "
            str &= "order By TBM.VoucherDate,TBM.VoucherNo ASC"

            Try
                Return MyBase.GetDataTable(str)
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
            str &= "order By TBM.VoucherDate ,TBM.VoucherNo ASC"

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
        Public Function GetInvoice()
            Dim str As String
            str = "select * from POInvoiceMaster  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GETAUTOAccountNamewithCode(ByVal AccountName As String)
            Dim Str As String
            Str = " Select (AccountName +'-'+ AccountCode) as Name,AccountName as Name2, AccountCode as Code2,ChartOfAccountID from tblAccounts where AccountName like '" & AccountName & "%'"
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
        Public Function GetCurrency() As DataTable
            Dim str As String
            str = " select *  from Currency "
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
        Public Function InsertJVDataGropuSummary(ByVal GroupAct As String, ByVal StartDate As String, ByVal EndDate As String)

            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct, TBD.Accountcode,TBM.VoucherDate ,TBD.VoucherNo ,TBD.Debit, TBD.Credit "
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where  TBM.VoucherDate between '" & StartDate & "' and  '" & EndDate & "' and  A.GroupAct= '" & GroupAct & "'"
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
        Public Function InsertbvDataGropuSummary(ByVal GroupAct As String, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct,TBD.AccountCode,TBM.VoucherDate ,TBM.VoucherNo,"
            str &= " Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit "
            str &= " from tblBankMst TBM   "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode  "
            str &= " where VoucherDate between '" & StartDate & "' and  '" & EndDate & "' and  A.GroupAct= '" & GroupAct & "'   order By TBM.VoucherDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertbvDataGropuSummaryBank(ByVal GroupAct As String)
            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct,TBM.BookAccount,TBM.VoucherDate ,TBM.VoucherNo,"
            str &= " Case When TBD.Type = 'C' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'D' then TBD.Amount else 0 end as Credit "
            str &= " from tblBankMst TBM   "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
            str &= " join TblAccounts A on A.AccountCode=TBM.BookAccount"
            str &= " where   A.GroupAct= '" & GroupAct & "'   order By TBM.VoucherDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertbvDataGropuSummaryBank(ByVal GroupAct As String, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            str = " INSERT INTO TempGroupSummary "
            str &= " select '" & GroupAct & "' as GroupAct,TBM.BookAccount,TBM.VoucherDate ,TBM.VoucherNo,"
            str &= " Case When TBD.Type = 'C' Then TBD.Amount Else 0 End As Debit, "
            str &= " Case When TBD.Type = 'D' then TBD.Amount else 0 end as Credit "
            str &= " from tblBankMst TBM   "
            str &= " join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID  "
            str &= " join TblAccounts A on A.AccountCode=TBM.BookAccount"
            str &= " where VoucherDate between '" & StartDate & "' and  '" & EndDate & "' and  A.GroupAct= '" & GroupAct & "'   order By TBM.VoucherDate ASC"
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
        Public Function TruncateTempLedgerFinal()
            Dim str As String
            str = " truncate table TempLedgerFinal "
            Try
                MyBase.ExecuteNonQuery(str)
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

        Public Function InsertTempLedgerIntoTempFinal()
            Dim str As String
            str = " insert into TempLedgerFinal select VoucherNo,VoucherDate,ChequeNo,ChequeDate,Description,DescriptionEntry,AccountName,Debit,"
            str &= " Credit from TempLedger order by voucherdate,VoucherNo asc"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckInsertdata()
            Dim str As String
            str = " Select * from TempLedgerFinal"
            Try
                Return MyBase.GetDataTable(str)
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
        '---------------------------------------New for Pand L
        '----------------Revenew-->SALES
        Public Function SALESJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0401001%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------Expense-->COST OF SALES
        Public Function COSTOFSALESJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0501%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '------Expence--->ADMINSTRATION EXPENSE
        Public Function ADMINSTRATIONEXPENSEJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0502%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        ' ------Expence-->FINANCIAL EXPENSE--->OTHER OPERTING EXPENSES
        Public Function OTHEROPERTINGEXPENSESJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504001004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '----Revenew-->OTHER INCOME/CREDITS
        Public Function OTHERINCOMECREDITSJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0401001006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '---Libilities--noncurrentlibilities--provission--provisionforaccount-->PROVISION FOR TAXATION
        Public Function PROVISIONFORTAXATIONJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.accountcode = '0202002001004'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '----------------Revenew-->SALES
        Public Function SALESPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0401001%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------Expense-->COST OF SALES
        Public Function COSTOFSALESPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0501%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '------Expence--->ADMINSTRATION EXPENSE
        Public Function ADMINSTRATIONEXPENSEPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0502%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        ' ------Expence-->FINANCIAL EXPENSE--->OTHER OPERTING EXPENSES
        Public Function OTHEROPERTINGEXPENSESPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504001004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '----Revenew-->OTHER INCOME/CREDITS
        Public Function OTHERINCOMECREDITSPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0401001006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '---Libilities--noncurrentlibilities--provission--provisionforaccount-->PROVISION FOR TAXATION
        Public Function PROVISIONFORTAXATIONPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.accountcode = '0202002001004'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        '------Expence-->SELLING EXPENSE--->SELLING EXPENSES
        '--for Distribution cost=SELLING EXPENSE

        Public Function DistributioncostPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0503001001%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '------Expence-->SELLING EXPENSE--->SELLING EXPENSES
        '--for Distribution cost=SELLING EXPENSE
        Public Function DistributioncostJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0503001001%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        '------------Expence-->FINANCIAL  EXPENSE--->FINANCIAL  EXPENSES
        '----for Finance  cost=FINANCIAL  EXPENSES

        Public Function FinancecostPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504001%' and groupact not like '0504001004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '------------Expence-->FINANCIAL  EXPENSE--->FINANCIAL  EXPENSES
        '----for Finance  cost=FINANCIAL  EXPENSES
        Public Function FinancecostJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504001%' and groupact not like '0504001004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        '------Expence-->FINANCIAL  EXPENSE--->FINANCIAL  EXPENSES--OTHER OPERTING EXPENSES-->GAIN / LOSS ON SALE OF FIXED ASSETS
        '---for Gain on derivative financial instruments
        Public Function GainonderivativefinancialinstrumentsPVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.AccountCode = '0504001002011'  "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '------Expence-->FINANCIAL  EXPENSE--->FINANCIAL  EXPENSES--OTHER OPERTING EXPENSES-->GAIN / LOSS ON SALE OF FIXED ASSETS
        '---for Gain on derivative financial instruments
        Public Function GainonderivativefinancialinstrumentsJVDB(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.AccountCode = '0504001002011'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function



        '-------------------For data insert in TempProfit and loss table

        Public Function TruncateTempProfitAndLoss()
            Dim str As String
            str = " truncate table TempProfitAndLoss "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '---BPV21
        Public Function InsertintoPLJVdata21(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            Dim notlike As String = "0504001004"
            str = "   insert into TempProfitAndLoss  select A.AccountName, TBD.accountcode,'Journal Voucher' as 'VoucherType','0' as OB,"
            str &= "  TBD.Credit,TBD.Debit, '0' as Balance"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '" & groupact & "%' and A.groupact Not like '" & notlike & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------JV21
        Public Function InsertintoPLPVdata21(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            Dim notlike As String = "0504001004"
            str = "  insert into TempProfitAndLoss  select A.AccountName,A.accountcode,'Payment Voucher' as 'VoucherType','0' as OB,"
            str &= "    Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit,"
            str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, '0' as Balance"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '" & groupact & "%' and A.groupact Not like '" & notlike & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '---BPV23
        Public Function InsertintoPLJVdata23(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   insert into TempProfitAndLoss  select A.AccountName, TBD.accountcode,'Journal Voucher' as 'VoucherType','0' as OB,"
            str &= "  TBD.Credit,TBD.Debit, '0' as Balance"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.AccountCode = '" & groupact & " '"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------JV23
        Public Function InsertintoPLPVdata23(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "  insert into TempProfitAndLoss  select A.AccountName,A.accountcode,'Payment Voucher' as 'VoucherType','0' as OB,"
            str &= "    Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit,"
            str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, '0' as Balance"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.AccountCode = '" & groupact & "'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '---BPV
        Public Function InsertintoPLJVdata(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   insert into TempProfitAndLoss  select A.AccountName, TBD.accountcode,'Journal Voucher' as 'VoucherType','0' as OB,"
            str &= "  TBD.Credit,TBD.Debit, '0' as Balance"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '" & groupact & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------JV
        Public Function InsertintoPLPVdata(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "  insert into TempProfitAndLoss  select A.AccountName,A.accountcode,'Payment Voucher' as 'VoucherType','0' as OB,"
            str &= "    Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit,"
            str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, '0' as Balance"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '" & groupact & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETPLDATA()
            Dim str As String
            str = " select AccountName,AccountCode,sum(Credit) as Credit ,Sum(Debit) as Debit,(sum(Debit)-Sum(Credit)) as Balance,CONVERT(varchar,CAST((sum(Debit)-Sum(Credit))As money),1)As Balancee from  TempProfitAndLoss  group by AccountName,AccountCode "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetPLdataonFirsttime() As DataTable
            Dim str As String
            ' str = " select distinct BookAccount from tblBankMst "
            str = " Select * from ProfitAndLoss  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        '------------===============
        '-------Balance sheet
        '-------------=======================
        Public Function GetBalanceSheetdataonFirsttime() As DataTable
            Dim str As String
            ' str = " select distinct BookAccount from tblBankMst "
            str = " Select * from BalanceSheet  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '-------ASSETS-->NON CURRENT ASSETS  '4
        '--For Property, plant and equipment
        Public Function dtPropertyplantandequipmentJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301%' and   groupact not like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtPropertyplantandequipmentPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301%' and   groupact not like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->NON CURRENT ASSETS-->LONG TERM DEPOSITS & DEFFERED COST
        '--For Long term deposits
        Public Function dtLongtermdepositsJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtLongtermdepositsPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->--CURRENT ASSETS-->ADVANCES, DEPOSITS OTHER RECEIVEABLES-->STAFF LOAN & ADVANCES  '3
        '--For Loan to employees
        Public Function dtLoantoemployeesJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003001%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtLoantoemployeesPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003001%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->--CURRENT ASSETS-->TRADE DEBTORS   '6
        '--For Trade debts
        Public Function dtTradedebtsJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302007%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtTradedebtsPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302007%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->--CURRENT ASSETS-->ADVANCES, DEPOSITS OTHER RECEIVEABLES-->OTHER ADVANCES ,PREPAYMENTS & RECEIVABLES '7
        '--For Loan and advances
        Public Function dtLoanandadvancesJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003002%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtLoanandadvancesPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003002%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->--NON CURRENT ASSETS -->LONG TERM DEPOSITS & DEFFERED COST
        '--For Trade deposits
        Public Function dtTradedepositsJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtTradedepositsPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->--CURRENT ASSETS--> ADVANCES, DEPOSITS OTHER RECEIVEABLES-->LONG TERM DEPOSITS & DEFFERED COST '8
        '--For Other receivables
        Public Function dtOtherReceivablesJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtOtherReceivablesPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------ASSETS-->--CURRENT ASSETS--> TAXES REFUNDABLE '9
        '--For Taxes Refundable
        Public Function dtTaxesRefundableJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtTaxesRefundablePV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '--------EQUITY-->--Share Capital '11
        '--For Share Capital '11
        Public Function dtShareCapitalJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0101%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtShareCapitalPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0101%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '--------EQUITY-->--Reserves
        '--For Reserves
        Public Function dtReservesJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0102%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtReservesPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0102%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------EXPENSE--->FINANCIAL EXPENSE-->--MARK UP ON SHORT TERM BORROWINGS '14
        '--For Short term borrowings
        Public Function dtShortTermBorrowingsJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504001002%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtShortTermBorrowingsPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504001002%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function TruncateTempBalanceSheet()
            Dim str As String
            str = " truncate table TempBalanceSheet "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '---BPV4
        Public Function InsertintoBSJVdata4(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            Dim notlike As String = "0301004"
            str = "   insert into TempProfitAndLoss  select A.AccountName, TBD.accountcode,'Journal Voucher' as 'VoucherType','0' as OB,"
            str &= "  TBD.Credit,TBD.Debit, '0' as Balance"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '" & groupact & "%' and A.groupact Not like '" & notlike & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------JV4
        Public Function InsertintoBSPVdata4(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            Dim notlike As String = "0301004"
            str = "  insert into TempBalanceSheet  select A.AccountName,A.accountcode,'Payment Voucher' as 'VoucherType','0' as OB,"
            str &= "    Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit,"
            str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, '0' as Balance"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '" & groupact & "%' and A.groupact Not like '" & notlike & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '---BPV
        Public Function InsertintoBSJVdata(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   insert into TempBalanceSheet  select A.AccountName, TBD.accountcode,'Journal Voucher' as 'VoucherType','0' as OB,"
            str &= "  TBD.Credit,TBD.Debit, '0' as Balance"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '" & groupact & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        '----------------JV
        Public Function InsertintoBSPVdata(ByVal groupact As String, ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "  insert into TempBalanceSheet  select A.AccountName,A.accountcode,'Payment Voucher' as 'VoucherType','0' as OB,"
            str &= "    Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit,"
            str &= "  Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, '0' as Balance"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '" & groupact & "%'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETPLDATABS()
            Dim str As String
            str = " select AccountName,AccountCode,sum(Credit) as Credit ,Sum(Debit) as Debit,(sum(Debit)-Sum(Credit)) as Balance,CONVERT(varchar,CAST((sum(Debit)-Sum(Credit))As money),1)As Balancee from  TempBalanceSheet  group by AccountName,AccountCode "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function



        '------------===============
        '-------CASH FLOW STATEMENT
        '-------------=======================
        Public Function GetCashFlowStatementdataonFirsttime() As DataTable
            Dim str As String
            ' str = " select distinct BookAccount from tblBankMst "
            str = " Select * from CashFlowStatement  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-------------------CFS Report
        '  -------LIABILITIES-->NON CURRENT LIABILITIES--->PROVISIONS--->PROVISON FOR ACCOUNTS--->PROVISION FOR STAFF GRATUITY
        '--For  Provision for staff retirement gratuity
        Public Function dtProvisionforstaffretirementgratuityJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.AccountCode = '0202002001006' "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtProvisionforstaffretirementgratuityPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.AccountCode = '0202002001006' "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------REVENUE-->SALES--->PROVISIONS--->OTHER INCOME/CREDITS--->INTEREST INCOME/PROFIT ON TFC
        '--FOr Interest income
        Public Function dtInterestincomeJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.AccountCode = '0401001006003' "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtInterestincomePV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.AccountCode = '0401001006003' "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------EXPENSES-->FINANCIAL EXPENSE
        '--FOr Finance cost
        Public Function dtFinancecostJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '0504%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtFinancecostPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0504%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------ASSETS-->CURRENT ASSETS --->TRADE DEBTORS
        '--FOr TRADE DEBTORS

        Public Function dtTradedebtsCFJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302007%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtTradedebtsCFPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '0302007%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------ASSETS-->CURRENT ASSETS --->ADVANCES, DEPOSITS OTHER RECEIVEABLES-->OTHER ADVANCES ,PREPAYMENTS & RECEIVABLES
        '-- FOr Loan and advances

        Public Function dtLoanandadvancesCFJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003002%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtLoanandadvancesCFPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003002%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '  -------ASSETS-->NON CURRENT ASSETS --->LONG TERM DEPOSITS & DEFFERED COST
        '--   FOr Trade deposits

        Public Function dtTradedepositsCFJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtTradedepositsCFPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        '  -------ASSETS-->CURRENT ASSETS  --->TAXES REFUNDABLE
        '--  FOr  Sales tax refundable

        Public Function dtSalestaxrefundableJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtSalestaxrefundablePV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '0302006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------ASSETS-->CURRENT ASSETS  --->ADVANCES, DEPOSITS OTHER RECEIVEABLES--->RECEIVABLE FRM TENANTS & OTHERS

        '--   FOr  Other receivables

        Public Function dtOtherreceivablesCFJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and A.groupact like '0302003006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtOtherreceivablesCFPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0302003006%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '  -------ASSETS-->NON CURRENT ASSETS

        '--  FOr   Purchase of property, plant and equipment

        Public Function dtPurchaseofpropertyplantandequipmentJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtPurchaseofpropertyplantandequipmentPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and  A.groupact like '0301%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------ASSETS-->CURRENT ASSETS -->STOCK -->CLOSING STOCK IN TRADE-->WORK IN PROCESS CA


        '--  FOr  Addition to capital work in process

        Public Function dtAdditiontocapitalworkinprocessJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.AccountCode = '0302004001002' "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtAdditiontocapitalworkinprocessPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.AccountCode = '0302004001002' "
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        '  -------ASSETS-->NON CURRENT ASSETS -->LONG TERM DEPOSITS & DEFFERED COST


        '--   For Long term deposit - net

        Public Function dtLongtermdepositnetJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and    A.groupact like  '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtLongtermdepositnetPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.groupact like  '0301004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '  -------EQUITIES-->NON CURRENT ASSETS -->LONG TERM DEPOSITS & DEFFERED COST


        '--   For Long term deposit - net

        Public Function dtSharecapitalissuedJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and    A.groupact like  '0101%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtSharecapitalissuedPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.groupact like  '0101%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '  -------LIABILITIES-->CURRENT LIABILITIES -->LOAN FROM DIRECTORS-->LOAN FROM DIRECTORS

        '--   For Loan received from directors

        Public Function dtLoanreceivedfromdirectorsJV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "    select  TBD.accountcode,TBM.VoucherNo,TBM.VoucherDate , '' as ChequeNo,''as ChequeDate,"
            str &= " TBM.Description, TBD.DescriptionEntry, 'Journal Voucher' as 'AccountName',"
            str &= "  TBD.Debit, TBD.Credit"
            str &= "  from tblJVMst TBM  "
            str &= "   join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= "   join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and    A.groupact like  '0201004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function dtLoanreceivedfromdirectorsPV(ByVal startdate As String, ByVal enddate As String)
            Dim str As String
            str = "   select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   Case When TBD.Type = 'D' Then TBD.Amount Else 0 End As Debit, "
            str &= "  Case When TBD.Type = 'C' then TBD.Amount else 0 end as Credit"
            str &= "   from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "  join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= "  where TBM.VoucherDate between '" & startdate & "' and '" & enddate & "'"
            str &= " and A.accountlevel='Detail' and   A.groupact like  '0201004%'"
            str &= " order By TBM.VoucherDate ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOo(ByVal SupplierName As String)
            Dim Str As String
            Str = " Select distinct upper(SupplierName) as Name from SupplierDatabase where SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETAUTO(ByVal VoucherNo As String)
            Dim Str As String
            Str = "Select distinct VoucherNo as Name from tblBankMst where VoucherNo like '%" & VoucherNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccountNameForLedgerPDFKAI(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " select distinct  (AccountName+'-'+ AccountCode) as Name from TblAccounts  where  AccountName like '%" & ItemName & "%'   order by (AccountName+'-'+ AccountCode) ASC  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetYarnCountForYarnStockLedgerPDf(ByVal yarncount As String) As DataTable
            Dim str As String
            '  str = " select distinct  (AccountName+'-'+ AccountCode) as Name from TblAccounts  where  AccountName like '%" & ItemName & "%'   order by (AccountName+'-'+ AccountCode) ASC  "

            'str = " select distinct  yd.yarncount from YarnRecvDetail SD"
            'str &= "  join yarndatabase yd on yd.yarndatabaseId=SD.Yarncountid where  yd.yarncount like '%" & yarncount & "%'   order by  yd.yarncount ASC  "


            str = " select distinct idl.YarnCount      from  YarnRecvDetail  y"
            str &= "     join YarnDatabase YDB on YDB.YarnDatabaseID=y.YarnCountID"
            str &= "    join YarnType YT on YT.YarnTypeID=YDB.YarnTypeID   join YarnIssuedtl idl"
            str &= " on y.BatchNo =idl.BatchNo and y.MFGDate =idl.MfgDate and y.YarnCountID =idl.YarnDatabaseID where  idl.YarnCount like '%" & yarncount & "%'   order by  idl.YarnCount ASC  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetYarnCountForYarnStockPDf(ByVal yarncount As String) As DataTable
            Dim str As String
            '  str = " select distinct  (AccountName+'-'+ AccountCode) as Name from TblAccounts  where  AccountName like '%" & ItemName & "%'   order by (AccountName+'-'+ AccountCode) ASC  "

            str = " select distinct  yd.yarncount from YarnRecvDetail SD"
            str &= "  join yarndatabase yd on yd.yarndatabaseId=SD.Yarncountid where  yd.yarncount like '%" & yarncount & "%'   order by  yd.yarncount ASC  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMachineParts(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " select distinct ItemName as Name from ItemProduct  where itemcode like '18%' and ItemName like '%" & ItemName & "%' and ItemLevel='2' order by ItemName ASC  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindYarnCountForOpenCaseNew(ByVal YarnCount As String) As DataTable
            Dim str As String
            str = " select distinct YarnCount as Name from YarnDatabase  where YarnCount like '%" & YarnCount & "%' order by YarnCount ASC  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindYarnCountForOpenCaseNewNew(ByVal YarnCount As String) As DataTable
            Dim str As String
            str = " select  YD.YarnCount + ' ('+ BD.BlendName +')' as Name from YarnDatabase YD"
            str &= "  JOIN BlendDropdown BD on BD.BlendID =YD.BlendID "
            str &= " where YarnCount like '%" & YarnCount & "%' order by YarnCount ASC  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETSupplierNameFromYarnContract(ByVal SupplierName As String)
            Dim Str As String
            Str = " Select distinct SD.SupplierName as Name from  TblYarnPurchaseContractDetail DTL join SupplierDatabase SD on SD.SupplierDatabaseID=DTL.SupplierDatabaseID  where SD.SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETYarnCountForYarnSetup(ByVal SupplierName As String)
            Dim Str As String
            Str = " Select distinct DTL.YarnCount as Name from  YarnDatabase DTL   where DTL.YarnCount like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function



        Function GETyarnCountFroYarnRecv(ByVal YarnCount As String)
            Dim Str As String
            Str = " Select distinct YD.YarnCount as Name from YarnRecvDetail DTL join yarndatabase YD on YD.yarndatabaseID=DTL.YarnCountID where YD.YarnCount like '%" & YarnCount & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETyarnCount(ByVal YarnCount As String)
            Dim Str As String
            Str = " Select distinct YD.YarnCount as Name from TblYarnPurchaseContractDetail DTL join yarndatabase YD on YD.yarndatabaseID=DTL.yarndatabaseID where YD.YarnCount like '%" & YarnCount & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function ChkVoucherNoDuplication(ByVal VoucherNo As String)
            Dim Str As String
            Str = " Select * from tblBankMst  where  VoucherNo ='" & VoucherNo & "'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function ChkNoDuplication(ByVal ChkNo As String)
            Dim Str As String
            Str = " Select * from tblBankdtl  where  ChequeNo ='" & ChkNo & "'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSRQNO() As DataTable
            Dim str As String
            str = " Select distinct SRQMAsterID,SRQNO   from SRQMaster order by SRQMAsterID DESC  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOMerchand(ByVal UserName As String)
            Dim Str As String
            Str = " select distinct UserName  from KAIOrderMaster kai"
            Str &= " join UMUser u on u.UserId =kai.Userid   where UserName like '%" & UserName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function


        Function GETAUTOBuyer(ByVal CustomerName As String)
            Dim Str As String
            Str = " select distinct CustomerName   from KAIOrderMaster kai"
            Str &= " join CustomerDatabase cd on cd.CustomerDatabaseID =kai.CustomerID where CustomerName like '%" & CustomerName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempBankVoucherDataTable()
            Dim str As String = "TRUNCATE TABLE  TempBankVoucherData"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataTempBankVoucherData(ByVal Startdate As String, ByVal EndDate As String)



            Dim str As String = "INSERT INTO TempBankVoucherData select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= " (select Top 1 TBD.ChequeNo from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as ChequeNo,"
            str &= " (select Top 1 TBD.ChequeDate from TblBankDtl TBD Where TBD.tblBankMstID=TBM.tblBankMstID  ) as ChequeDate,"
            str &= " TBM.Description,TBM.Description as DescriptionEntry,"
            str &= " (select distinct AccountName from TblAccounts TT "
            str &= " join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            str &= " where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= " Case When TBM.VoucherType = 'R' Then TBM.TotalAmount Else 0 End As Debit, "
            str &= " Case When TBM.VoucherType = 'P' Then TBM.TotalAmount else 0 end as Credit,'1' as orderno"
            str &= " from tblBankMst TBM  "
            str &= " join TblAccounts A on A.AccountCode=TBM.BookAccount "
            str &= " where  TBM.VoucherDate between '" & Startdate & "' and '" & EndDate & "'"
            str &= " order By TBM.VoucherDate ASC"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertBPVDataWithOutBankTempBankVoucherData(ByVal Startdate As String, ByVal EndDate As String)

            Dim str As String = "   INSERT INTO TempBankVoucherData"
            str &= " select TBM.VoucherNo,TBM.VoucherDate ,"
            str &= "   TBD.ChequeNo,TBD.ChequeDate,"
            str &= "   TBM.Description,TBD.DescriptionEntry,"
            str &= "   (select distinct AccountName from TblAccounts TT "
            str &= "   join tblBankMst TM on TM.BookAccount=TT.AccountCode "
            str &= "   where TM.BookAccount = TBM.BookAccount  ) as 'AccountName', "
            str &= "   Case When TBD.Type = 'D' and TBD.Amount>0 Then TBD.Amount"
            str &= " When TBD.Type = 'C' and TBD.Amount<0 then  -1*TBD.Amount Else 0 End As Debit, "
            str &= "   Case When TBD.Type = 'C' and TBD.Amount>0 then TBD.Amount"
            str &= " When TBD.Type = 'D' and TBD.Amount<0 THEN -1*TBD.Amount else 0 end as Credit,'2' as orderno"
            str &= " from tblBankMst TBM  "
            str &= "   join TblBankDtl TBD on TBD.tblBankMstID=TBM.tblBankMstID "
            str &= "    join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBM.VoucherDate between '" & Startdate & "' and '" & EndDate & "'"
            str &= "    order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTempJVVoucherDataTable()
            Dim str As String = "TRUNCATE TABLE  TempJVVoucherData"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertJVDataTempJVVoucherData(ByVal Startdate As String, ByVal EndDate As String)

            Dim str As String = "INSERT INTO TempJVVoucherData   select TBM.VoucherNo,TBM.VoucherDate , "
            str &= "  '' as ChequeNo,''as ChequeDate, TBM.Description, TBD.DescriptionEntry,"
            str &= " AccountName as 'AccountName',TBD.Debit, TBD.Credit"
            str &= " from tblJVMst TBM  "
            str &= " join TblJVDtl TBD on TBD.tblJVMstID=TBM.tblJVMstID "
            str &= " join TblAccounts A on A.AccountCode=TBD.AccountCode "
            str &= " where TBM.VoucherDate between '" & Startdate & "' and '" & EndDate & "'"
            str &= " order By TBM.VoucherDate ASC"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function BindYarnCountForOrdersheet(ByVal yarncount As String)
            Dim Str As String
            Str = " select distinct  YarnCount+' ('+ BlendName+')' as YarnCount from YarnDatabase YDB join BlendDropdown B on B.BlendID=YDB.BlendID   where YarnCount+' ('+ BlendName+')' like '%" & yarncount & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function BindRemarksWisebyText(ByVal RECVReamrks As String)
            Dim Str As String
            Str = " select distinct YRM.RECVReamrks from YarnRecvMaster YRM  where YRM.RECVReamrks like '%" & RECVReamrks & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function BindDCNOWisebyText(ByVal DcNo As String)
            Dim Str As String
            Str = " select distinct PartyDCNo from YarnRecvMaster YRM  where PartyDCNo like '%" & DcNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataVoucherNoWiseForAutoBind(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = " select distinct VoucherNo from YarnIssueMst"
            str &= " where VoucherNo LIKE'%" & VoucherNo & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataByYarnCountForAutoBind(ByVal YarnCount As String) As DataTable
            Dim str As String
            str = " select distinct YarnCount   from YarnIssueDtl where YarnCount LIKE '%" & YarnCount & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataByYarnCountForAutoBindIssue(ByVal YarnCount As String) As DataTable
            Dim str As String
            str = " select distinct YarnCount as Name from YarnIssueDtl where YarnCount LIKE '%" & YarnCount & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataByMillForAutoBindIssue(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select distinct Brand As Name from YarnIssueDtl where Brand LIKE '%" & Brand & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataByKnitterForAutoBindIssue(ByVal Knitter As String) As DataTable
            Dim str As String
            str = " select distinct Knitter As Name from YarnIssueDtl where Knitter LIKE '%" & Knitter & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByOrderForAutoBindIssue(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct REPLACE(PO.OrderNo, '/', '_') As Name  from YarnIssueMst PO"
            Str &= "   where REPLACE(PO.OrderNo, '/', '/') Like '" & OrderNo & "%'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByOrderSRQForDyeingIssueView(ByVal OrderNo As String)
            Dim Str As String
            'Str = "  select distinct    Case    when po.KAIOrderMasterID > 0 then REPLACE(PO.OrderNo, '/', '_') else REPLACE(PO.SRQNo, '/', '_')end    As Name  from YarnIssueMst PO"
            'Str &= "   where REPLACE(PO.OrderNo, '/', '_')Like '" & OrderNo & "%' or REPLACE(PO.SRQNo, '/', '_') Like '" & OrderNo & "%'  "
            Str = "  select distinct     REPLACE(PO.OrderNo, '/', '_')    As Name  from DyeingIssueChallanMst PO"
            Str &= "   where REPLACE(PO.OrderNo, '/', '_') Like '" & OrderNo & "%'    "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByDyerForDyeingIssueView(ByVal SupplierName As String)
            Dim Str As String

            Str = "  select distinct sd.SupplierName as Name from DyeingIssueChallanMst mst join SupplierDatabase sd on sd.SupplierDatabaseid =mst.DyerID  "
            Str &= "   where sd.SupplierName Like '%" & SupplierName & "%'    "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByBUYERForDyeingIssueView(ByVal Buyer As String)
            Dim Str As String
            Str = "  select distinct mst.Buyer as Name from DyeingIssueChallanMst mst   "
            Str &= "   where mst.Buyer Like '%" & Buyer & "%'    "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByCOLORForDyeingIssueView(ByVal Shade As String)
            Dim Str As String
            Str = "  select distinct mst.Shade as Name from DyeingIssueChallanMst mst   "
            Str &= "   where mst.Shade Like '%" & Shade & "%'    "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByLotNoForDyeingIssueView(ByVal LotNo As String)
            Dim Str As String
            Str = "  select distinct mst.LotNo as Name from DyeingIssueChallanMst mst   "
            Str &= "   where mst.LotNo Like '%" & LotNo & "%'    "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataOrderForGrossSearch(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select  distinct REPLACE(OrderNo, '/', '_')  as Name  from DyeingIssueChallanMst"
            Str &= "   where REPLACE(OrderNo, '/', '_')Like '" & OrderNo & "%' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataBuyerForGrossSearch(ByVal Buyer As String)
            Dim Str As String
            Str = "  select  distinct Buyer  as Name  from DyeingIssueChallanMst  "
            Str &= "   where Buyer Like '%" & Buyer & "%'    "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByLoosYarIssueTiKnitterViewPageYarnCount(ByVal YarnCount As String)
            Dim Str As String
            Str = "  select  distinct sd.YarnCount  as Name  from IssueToKnitterLooseYarn k join YarnDatabase  sd on sd.YarnDatabaseid =k.YarnCountID  "
            Str &= "   where sd.YarnCount Like '%" & YarnCount & "%'    "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByLoosYarIssueTiKnitterViewPageKnitter(ByVal Knitter As String)
            Dim Str As String
            Str = "  select  distinct sd.SupplierName  as Name  from IssueToKnitterLooseYarn k join SupplierDatabase sd on sd.SupplierDatabaseId =k.KnitterID "
            Str &= "   where sd.SupplierName Like '%" & Knitter & "%'    "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByLoosYarIssueTiKnitterViewPageOrderSRQ(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct    Case    when po.KAIOrderMasterID > 0 then REPLACE(m.OrderNo, '/', '_') else REPLACE(sm.SRQNo, '/', '_')end    As Name  from IssueToKnitterLooseYarn PO left join Kaiordermaster m on m.KaiordermasterID=po.KaiordermasterID left join SRQMaster sm on sm.SRQMasterID=po.SRQMasterID"
            Str &= "   where REPLACE(m.OrderNo, '/', '_')Like '" & OrderNo & "%' or REPLACE(sm.SRQNo, '/', '_') Like '" & OrderNo & "%'  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        '-------------------
        Function GetDataByLoosYarReturnViewPageYarnCount(ByVal YarnCount As String)
            Dim Str As String
            Str = "  select  distinct sd.YarnCount  as Name  from ReturnLooseYarnFromKnitter k join YarnDatabase  sd on sd.YarnDatabaseid =k.YarnCountID  "
            Str &= "   where sd.YarnCount Like '%" & YarnCount & "%'    "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByLoosYarReturnViewPageKnitter(ByVal Knitter As String)
            Dim Str As String
            Str = "  select  distinct sd.SupplierName  as Name  from ReturnLooseYarnFromKnitter k join SupplierDatabase sd on sd.SupplierDatabaseId =k.KnitterID "
            Str &= "   where sd.SupplierName Like '%" & Knitter & "%'    "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByLoosYarReturnViewPageOrderSRQ(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct    Case    when po.KAIOrderMasterID > 0 then REPLACE(m.OrderNo, '/', '_') else REPLACE(sm.SRQNo, '/', '_')end    As Name  from ReturnLooseYarnFromKnitter PO left join Kaiordermaster m on m.KaiordermasterID=po.KaiordermasterID left join SRQMaster sm on sm.SRQMasterID=po.SRQMasterID"
            Str &= "   where REPLACE(m.OrderNo, '/', '_')Like '" & OrderNo & "%' or REPLACE(sm.SRQNo, '/', '_') Like '" & OrderNo & "%'  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDataByOrderForAutoBindIssueOrderSRQ(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct    Case    when po.KAIOrderMasterID > 0 then REPLACE(PO.OrderNo, '/', '_') else REPLACE(PO.SRQNo, '/', '_')end    As Name  from YarnIssueMst PO"
            Str &= "   where REPLACE(PO.OrderNo, '/', '_')Like '" & OrderNo & "%' or REPLACE(PO.SRQNo, '/', '_') Like '" & OrderNo & "%'  "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CHKLocked(ByVal Month As Integer, ByVal year As Integer) As DataTable
            Dim str As String
            str = " select * from tblbankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "'  and LockBit='1'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function BindPONOForManualTNA(ByVal PONO As String, ByVal BuyerID As Long)
            Dim Str As String
            Str = " select distinct PONO from KAIOrderMaster  where PONO like '%" & PONO & "%' and CustomerID='" & BuyerID & "'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderbysearchNew(ByVal AcidName As String)
            Dim Str As String
            Str = "  select REPLACE(KMMM.OrderNo, '/', '_')  from  KAIORDERMASTER KMMM  where REPLACE(KMMM.OrderNo, '/', '/') Like '" & AcidName & "%'"
            Str &= "   order by KMMM.KAIORDERMASTERID DESC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETOrderbysearchNewForYarnSearchEngine(ByVal AcidName As String)
            Dim Str As String
            Str = "  select distinct REPLACE(KMMM.OrderNo, '/', '_')  from  KAIORDERMASTER KMMM  Join yarnissuemst m on M.KAIORDERMASTERID=KMMM.KAIORDERMASTERID where REPLACE(KMMM.OrderNo, '/', '/') Like '" & AcidName & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderNoForACCESSPOVIEWPAGE(ByVal OrderNo As String)
            Dim Str As String
            Str = " Select distinct REPLACE(OrderNo, '/', '_') as Name from KAIOrderMaster where REPLACE(OrderNo, '/', '/') like '%" & OrderNo & "%' and KAIOrderMasterID not in (Select KAIOrderMasterID from podetailforordersheet)and  KAIOrderMasterID not in (Select KAIOrderMasterID from posizedetailforordersheet)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderNoForACCESSPOVIEWPAGENew(ByVal OrderNo As String)
            Dim Str As String
            Str = " Select distinct REPLACE(OrderNo, '/', '_') as Name from KAIOrderMaster where REPLACE(OrderNo, '/', '/') like '%" & OrderNo & "%' and  year(CreationDate)>=2017 and KAIOrderMasterID not in (Select KAIOrderMasterID from podetailforordersheet)and  KAIOrderMasterID not in (Select KAIOrderMasterID from posizedetailforordersheet)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderNoForACCESSPOVIEWPAGEUpdatedPO(ByVal OrderNo As String)
            Dim Str As String
            Str = " Select distinct REPLACE(OrderNo, '/', '_') as Name from KAIOrderMaster where REPLACE(OrderNo, '/', '/') like '%" & OrderNo & "%' and (KAIOrderMasterID   in (Select KAIOrderMasterID from podetailforordersheet) or  KAIOrderMasterID   in (Select KAIOrderMasterID from posizedetailforordersheet))"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETBuyerForACCESSPOVIEWPAGE(ByVal CustomerName As String)
            Dim Str As String
            Str = " Select distinct cd.CustomerName as Name from KAIOrderMaster kai join CustomerDatabase cd on cd.CustomerDatabaseID =kai.CustomerID  where cd.CustomerName like '%" & CustomerName & "%' and KAIOrderMasterID not in (Select KAIOrderMasterID from podetailforordersheet)and  KAIOrderMasterID not in (Select KAIOrderMasterID from posizedetailforordersheet)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETBuyerForACCESSPOVIEWPAGENew(ByVal CustomerName As String)
            Dim Str As String
            Str = " Select distinct cd.CustomerName as Name from KAIOrderMaster kai join CustomerDatabase cd on cd.CustomerDatabaseID =kai.CustomerID  where cd.CustomerName like '%" & CustomerName & "%' and  year(kai.CreationDate)>=2017 and KAIOrderMasterID not in (Select KAIOrderMasterID from podetailforordersheet)and  KAIOrderMasterID not in (Select KAIOrderMasterID from posizedetailforordersheet)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETBuyerForACCESSPOVIEWPAGEUpdatedPO(ByVal CustomerName As String)
            Dim Str As String
            Str = " Select distinct cd.CustomerName as Name from KAIOrderMaster kai join CustomerDatabase cd on cd.CustomerDatabaseID =kai.CustomerID  where cd.CustomerName like '%" & CustomerName & "%' and (KAIOrderMasterID   in (Select KAIOrderMasterID from podetailforordersheet) or  KAIOrderMasterID   in (Select KAIOrderMasterID from posizedetailforordersheet))"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETITEMForACCESSPOVIEWPAGE(ByVal ItemName As String)
            Dim Str As String
            Str = " Select distinct IP.ItemName as Name from KAIOrderMaster kai join KAIOrderAccessorieseDetail cd on cd.KAIOrderMasterID =kai.KAIOrderMasterID join ItemProduct IP on IP.ItemID=CD.ItemID  where IP.ItemName like '%" & ItemName & "%' and kai.KAIOrderMasterID not in (Select KAIOrderMasterID from podetailforordersheet)and  kai.KAIOrderMasterID not in (Select KAIOrderMasterID from posizedetailforordersheet)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETITEMForACCESSPOVIEWPAGENew(ByVal ItemName As String)
            Dim Str As String
            Str = " Select distinct IP.ItemName as Name from KAIOrderMaster kai join KAIOrderAccessorieseDetail cd on cd.KAIOrderMasterID =kai.KAIOrderMasterID join ItemProduct IP on IP.ItemID=CD.ItemID  where IP.ItemName like '%" & ItemName & "%' and  year(kai.CreationDate)>=2017 and kai.KAIOrderMasterID not in (Select KAIOrderMasterID from podetailforordersheet)and  kai.KAIOrderMasterID not in (Select KAIOrderMasterID from posizedetailforordersheet)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETITEMForACCESSPOVIEWPAGEUpdatedPO(ByVal ItemName As String)
            Dim Str As String
            Str = " Select distinct IP.ItemName as Name from KAIOrderMaster kai join KAIOrderAccessorieseDetail cd on cd.KAIOrderMasterID =kai.KAIOrderMasterID join ItemProduct IP on IP.ItemID=CD.ItemID  where IP.ItemName like '%" & ItemName & "%' and (kai.KAIOrderMasterID   in (Select KAIOrderMasterID from podetailforordersheet) or  kai.KAIOrderMasterID   in (Select KAIOrderMasterID from posizedetailforordersheet))"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETPONOForACCESSPOVIEWPAGEUpdatedPO(ByVal PONO As String)
            Dim Str As String
            Str = " Select distinct  PONO as Name from POMasterforOrderSheet where PONO like '%" & PONO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductNamebySearchNewForEditPage(ByVal ItemName As String)
            Dim Str As String
            Str = "select distinct REPLACE(ItemName, '''', '-')  From ItemProduct  where REPLACE(ItemName, '''', '''') Like '%" & ItemName & "%'   and ItemLevel =2 "
            'Str = " select ItemCode,ItemName From ItemProduct  where left(ItemCode,2)='" & ItemCode & "'  and ItemLevel=1"
            Try
                Return MyBase.GetDataTable(Str)
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
        Function GETPONOFORPOMASTER(ByVal AcidName As String)
            Dim Str As String
            Str = "  select distinct KMMM.PONO  from  kaipomaster KMMM  where KMMM.PONO Like '" & AcidName & "%'"
            Str &= "   order by KMMM.PONO DESC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETBuyerbysearchForPOMaster(ByVal AcidName As String)
            Dim Str As String
            Str = "  select  distinct CD.CustomerName  from  kaipomaster KMMM "
            Str &= " join  CustomerDatabase CD on CD.CustomerDatabaseID=KMMM.CustomerID where CD.CustomerName Like '" & AcidName & "%'"
            Str &= "   order by   CD.CustomerName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETDateFrotblDailyCutting(ByVal ProductionDate As String)
            Dim Str As String
            Str = "   select distinct REPLACE( CONVERT(varchar,TDP.ProductionDate,103), '/', '_') as ProDate  from tblDailyCutting TDP where REPLACE( CONVERT(varchar,TDP.ProductionDate,103), '/', '_') like '%" & ProductionDate & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETOrderNoFrotblDailyCutting(ByVal OrderNo As String)
            Dim Str As String
            Str = "  select distinct   REPLACE(KOM.OrderNo, '/', '_') as OrderNo from tblDailyCutting TDP   join KAIOrderMaster KOM on KOM.KAIOrderMasterID=TDP.KAIOrderMasterID  where REPLACE(KOM.OrderNo, '/', '_') like '%" & OrderNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        '===============
        Function GetAutonumberForYarnDyed(ByVal AutoNo As String)
            Dim Str As String
            Str = " select  distinct PurchaseNo     from YarnDyeingReciveProgramMst  where AutoNo like '%" & AutoNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetOrderNoForYarnDyed(ByVal OrderNo As String)
            Dim Str As String
            Str = " select  distinct   REPLACE(KOM.OrderNo, '/', '_') as OrderNo   from YarnDyeingReciveProgramMst m join KAIOrderMaster KOM on KOM.KAIOrderMasterID=m.KAIOrderMasterID   where REPLACE(KOM.OrderNo, '/', '_') like '%" & OrderNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        '-----------
        Function GetBuyerForYarnDyedIssue(ByVal CustomerName As String)
            Dim Str As String
            Str = " select  distinct   ccc.CustomerName as Buyer   from YarnDyedIssueProgramMst m join KAIOrderMaster KOM on KOM.KAIOrderMasterID=m.KAIOrderMasterID    join   CustomerDatabase     ccc      on ccc.CustomerDatabaseID =KOM.CustomerID    where ccc.CustomerName like '%" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetColorForYarnDyedIssue(ByVal YarnDyedIssueColor As String)
            Dim Str As String
            Str = " select  distinct   m.YarnDyedIssueColor as YarnDyedIssueColor   from YarnDyedIssueProgramDtl m  where m.YarnDyedIssueColor like '%" & YarnDyedIssueColor & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetMillForYarnDyedIssue(ByVal YarnDyeingReciveMill As String)
            Dim Str As String
            Str = " select  distinct   m.YarnDyeingReciveMill as YarnDyeingReciveMill   from YarnDyedIssueProgramDtl m  where m.YarnDyeingReciveMill like '%" & YarnDyeingReciveMill & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetYarnCountForYarnDyedIssue(ByVal YarnCount As String)
            Dim Str As String
            Str = " select  distinct   ydb.YarnCount as YarnDyeingReciveColor   from YarnDyedIssueProgramDtl m join   YarnDatabase  ydb  on ydb.YarnDatabaseID=m.YarnCountID  where ydb.YarnCount like '%" & YarnCount & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDyerForYarnDyedIssue(ByVal SupplierName As String)
            Dim Str As String
            Str = " select  distinct   ydb.SupplierName as SupplierName   from YarnDyedIssueProgramMst m join   SupplierDatabase  ydb  on ydb.SupplierDatabaseID=m.KnitterID  where ydb.SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        '----------------------------
        Function GetBuyerForYarnDyed(ByVal CustomerName As String)
            Dim Str As String
            Str = " select  distinct   ccc.CustomerName as Buyer   from YarnDyeingReciveProgramMst m join KAIOrderMaster KOM on KOM.KAIOrderMasterID=m.KAIOrderMasterID    join   CustomerDatabase     ccc      on ccc.CustomerDatabaseID =KOM.CustomerID    where ccc.CustomerName like '%" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetColorForYarnDyed(ByVal YarnDyeingReciveColor As String)
            Dim Str As String
            Str = " select  distinct   m.YarnDyeingReciveColor as YarnDyeingReciveColor   from YarnDyeingReciveProgramdtl m  where m.YarnDyeingReciveColor like '%" & YarnDyeingReciveColor & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetMillForYarnDyed(ByVal YarnDyeingReciveMill As String)
            Dim Str As String
            Str = " select  distinct   m.YarnDyeingReciveMill as YarnDyeingReciveColor   from YarnDyeingReciveProgramdtl m  where m.YarnDyeingReciveMill like '%" & YarnDyeingReciveMill & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetYarnCountForYarnDyed(ByVal YarnCount As String)
            Dim Str As String
            Str = " select  distinct   ydb.YarnCount as YarnDyeingReciveColor   from YarnDyeingReciveProgramdtl m join   YarnDatabase  ydb  on ydb.YarnDatabaseID=m.YarnCountID  where ydb.YarnCount like '%" & YarnCount & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDyerForYarnDyed(ByVal SupplierName As String)
            Dim Str As String
            Str = " select  distinct   ydb.SupplierName as SupplierName   from YarnDyeingReciveProgramdtl m join   SupplierDatabase  ydb  on ydb.SupplierDatabaseID=m.DyerID  where ydb.SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAutonumberForYarnDyedIssue(ByVal PurchaseNo As String)
            Dim Str As String
            Str = " select  distinct PurchaseNo     from YarnDyedIssueProgramMst  where PurchaseNo like '%" & PurchaseNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetOrderNoForYarnDyedIssue(ByVal OrderNo As String)
            Dim Str As String
            Str = " select  distinct   REPLACE(KOM.OrderNo, '/', '_') as OrderNo   from YarnDyedIssueProgramMst m join KAIOrderMaster KOM on KOM.KAIOrderMasterID=m.KAIOrderMasterID   where REPLACE(KOM.OrderNo, '/', '_') like '%" & OrderNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CHKOrderNoForOrderGrossReport(ByVal OrderNo As String)
            Dim str As String
            str = " select distinct OrderNo,KAIOrderMasterID from KAIOrderMaster where REPLACE(OrderNo, '/', '_')='" & OrderNo & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CHKBuyerForOrderGrossReport(ByVal Buyer As String)
            Dim str As String
            str = " select distinct CustomerName,CustomerDatabaseID from CustomerDatabase where CustomerName='" & Buyer & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetPONOForDyeHouseIssueViewSearch(ByVal PONO As String) As DataTable
            Dim str As String
            str = " select distinct subDpt.PONO     from DyehouseIssueMst mst            LEFT JOIN GeneralPurchaseOrder subDpt ON subDpt.GeneralPurchaseOrderMstID = mst.GeneralPurchaseOrderMstID        where subDpt.PONO LIKE '%" & PONO & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNOForDyeHouseIssueViewSearch(ByVal GSNNO As String) As DataTable
            Dim str As String
            str = " select distinct mst.GSNNO     from DyehouseIssueMst mst     where mst.GSNNO  LIKE '%" & GSNNO & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPONOForDyeHouseViewSearch(ByVal PONO As String) As DataTable
            Dim str As String
            str = " select distinct subDpt.PONO     from DyeHouseReceiveMst mst            LEFT JOIN GeneralPurchaseOrder subDpt ON subDpt.GeneralPurchaseOrderMstID = mst.GeneralPurchaseOrderMstID        where subDpt.PONO LIKE '%" & PONO & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNOForDyeHouseViewSearch(ByVal GSNNO As String) As DataTable
            Dim str As String
            str = " select distinct mst.GSNNO     from DyeHouseReceiveMst mst     where mst.GSNNO  LIKE '%" & GSNNO & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-----------LOT ISSUE TO UNIT
        Public Function GetLotNoForIssueToUnitd(ByVal LotNo As String) As DataTable
            Dim str As String
            str = " select distinct m.LotNo    FROM LotReceiveFromDyeing m join SupplierDatabase sd on m.DyerID=Sd.SupplierDatabaseid where m.LotNo  LIKE '%" & LotNo & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetOrderNoForIssueToUnitd(ByVal OrderNo As String) As DataTable
            Dim str As String
            str = " select distinct   REPLACE(m.OrderNo, '/', '_') as OrderNo  FROM LotReceiveFromDyeing m join SupplierDatabase sd on m.DyerID=Sd.SupplierDatabaseid where REPLACE(m.OrderNo, '/', '_')  LIKE '%" & OrderNo & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShadeForIssueToUnitd(ByVal Shade As String) As DataTable
            Dim str As String
            str = " select distinct m.Shade  FROM LotReceiveFromDyeing m join SupplierDatabase sd on m.DyerID=Sd.SupplierDatabaseid where m.Shade LIKE '%" & Shade & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerForIssueToUnitd(ByVal Buyer As String) As DataTable
            Dim str As String
            str = " select distinct m.Buyer    FROM LotReceiveFromDyeing m join SupplierDatabase sd on m.DyerID=Sd.SupplierDatabaseid where  m.Buyer LIKE '%" & Buyer & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetKnitterForIssueToUnitd(ByVal Knitter As String) As DataTable
            Dim str As String
            str = " select distinct sd.SupplierName  FROM LotReceiveFromDyeing m join SupplierDatabase sd on m.DyerID=Sd.SupplierDatabaseid where sd.SupplierName LIKE '%" & Knitter & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        '-----------end LOT ISSUE TO UNIT
    End Class
End Namespace

