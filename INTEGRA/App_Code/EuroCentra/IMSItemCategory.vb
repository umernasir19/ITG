Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSItemCategory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSItemCategory"
            m_strPrimaryFieldName = "IMSItemCategoryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lIMSItemCategoryID As Long
        Private m_dtCreationDate As Date
        Private m_lIMSItemClassID As Long
        Dim m_strItemCategoryName As String
        Dim m_strItemCategoryCode As String
        Private m_bIsActive As Boolean
        Dim m_strRemarks As String
        Private m_lCategoryManagedBy As Long
        Public Property IMSItemCategoryID() As Long
            Get
                IMSItemCategoryID = m_lIMSItemCategoryID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemCategoryID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property IMSItemClassID() As Long
            Get
                IMSItemClassID = m_lIMSItemClassID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemClassID = Value
            End Set
        End Property
        Public Property ItemCategoryName() As String
            Get
                ItemCategoryName = m_strItemCategoryName
            End Get
            Set(ByVal Value As String)
                m_strItemCategoryName = Value
            End Set
        End Property
        Public Property ItemCategoryCode() As String
            Get
                ItemCategoryCode = m_strItemCategoryCode
            End Get
            Set(ByVal Value As String)
                m_strItemCategoryCode = Value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal Value As Boolean)
                m_bIsActive = Value
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
        Public Property CategoryManagedBy() As Long
            Get
                CategoryManagedBy = m_lCategoryManagedBy
            End Get
            Set(ByVal Value As Long)
                m_lCategoryManagedBy = Value
            End Set
        End Property
        Public Function SaveIMSItemCategory()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function GETSRNoAutoSearchForGetSeasonId()
            Dim Str As String

            Str = " Select top 1 SeasondatabaseID from Seasondatabase order by SeasonDatabaseId desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETSRNoAutoSearch(ByVal SeasonDatabaseID As Long, ByVal SRNO As String)
            Dim Str As String

            Str = " Select SRNO from Joborderdatabase where SeasonDatabaseID ='" & SeasonDatabaseID & "' and SRNO like  '" & SRNO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETColorAutoSearch(ByVal SeasonDatabaseID As Long, ByVal Joborderid As Long, ByVal BuyerColor As String)
            Dim Str As String

            Str = " Select BuyerColor  from Joborderdatabase jo join JobOrderdatabaseDetail jod on jod.Joborderid =jo.Joborderid  where jo.SeasonDatabaseID ='" & SeasonDatabaseID & "' and jo.Joborderid ='" & Joborderid & "' and BuyerColor like '" & BuyerColor & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandFromStyleAssormentForChecklist(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select  Distinct BD.Brand AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where BD.Brand like '" & Brand & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerFromStyleAssormentForChecklist(ByVal CustomerName As String) As DataTable
            Dim str As String
            str = " select  Distinct CD.CustomerName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where CD.CustomerName like '" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFromStyleAssormentForChecklist(ByVal Style As String) As DataTable
            Dim str As String
            str = " select  Distinct JOd.Style AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JOd.Style like '" & Style & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromStyleAssormentForChecklist(ByVal SRNO As String) As DataTable
            Dim str As String
            str = " select  Distinct JO.SRNO AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JO.SRNO like '" & SRNO & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromStyleAssormentForChecklist(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select  Distinct SD.SeasonName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where SD.SeasonName like '" & SeasonName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreDalNoForAuditor(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select Distinct FDB.DalNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where FDB.DalNo like '" & DalNo & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreDalNo(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select Distinct FDB.DalNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1  AND FDB.DalNo like '" & DalNo & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOFOrDigital(ByVal VoucherNo As String)
            Dim Str As String
            Str = "Select VoucherNo as Name from tblBankMst where VoucherNo like '%" & VoucherNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETInvAutoSearch(ByVal InvoiceNo As String)
            Dim Str As String

            Str = " select distinct POIM.SaleTaxInvoiceNo from POInvoiceMst POIM  join  SupplierDatabase SD on POIM.Accountpayablepartyid=SD.SupplierdatabaseID where   POIM.SaleTaxInvoiceNo like '" & InvoiceNo & "%'"
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
        Function GETAUTOAccountNameForNaeem(ByVal AccountName As String)
            Dim Str As String
            Str = " Select AccountName as Name from tblAccounts where AccountLevel='Detail' and AccountName like '" & AccountName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETInvAutoSearch2(ByVal InvoiceNo As String, ByVal Supplier As String)
            Dim Str As String

            Str = " select distinct POIM.SaleTaxInvoiceNo from POInvoiceMst POIM  join  SupplierDatabase SD on POIM.Accountpayablepartyid=SD.SupplierdatabaseID where   SD.SupplierName='" & Supplier & "' and POIM.SaleTaxInvoiceNo like '" & InvoiceNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
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
        Public Function GetAstoreDalNo(ByVal DalNo As String) As DataTable
            Dim str As String

            str = " Select Distinct FDB.DalNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2  AND FDB.DalNo like '" & DalNo & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreDalNoGStore(ByVal DalNo As String) As DataTable
            Dim str As String

            str = " Select Distinct FDB.DalNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4  AND FDB.DalNo like '" & DalNo & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreDalNoForAccess(ByVal DalNo As String) As DataTable
            Dim str As String

            str = " Select Distinct FDB.DalNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_ICL.ItemClassName ='DYEING PROCESS' AND FDB.DalNo like '" & DalNo & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreDalRefForAuditor(ByVal DalRefNo As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.DalRefNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            'str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_I.DalRefNo like '" & DalRefNo & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreDalRef(ByVal DalRefNo As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.DalRefNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            'str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1  AND IMS_I.DalRefNo like '" & DalRefNo & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandFromSizeWeight(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select  Distinct BD.Brand AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where BD.Brand like '" & Brand & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandFromStyleAssorment(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select  Distinct BD.Brand AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where BD.Brand like '" & Brand & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandFromStyleAssormentForBarCodeView(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select  Distinct BD.Brand AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join DPCuttingProMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where BD.Brand like '" & Brand & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ColorBarCodeView(ByVal BuyerColor As String) As DataTable
            Dim str As String
            str = " select  Distinct JOd.BuyerColor AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join DPCuttingProMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JOd.BuyerColor like '" & BuyerColor & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierNameForRND(ByVal SupplierName As String) As DataTable
            Dim str As String
            str = " select Distinct SD.SupplierName AS Name from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId"
            str &= " where SD.SupplierName like '" & SupplierName & "%' and SD.Userid=237"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSuppliereCodeForRND(ByVal SupplierCode As String) As DataTable
            Dim str As String
            str = " select Distinct SD.SupplierCode AS Name from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId"
            str &= " where SD.SupplierCode like '" & SupplierCode & "%' and SD.Userid=237"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSuppliereCategoryForRND(ByVal SupplierCategory As String) As DataTable
            Dim str As String
            str = " select Distinct SC.SupplierCategory AS Name from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId"
            str &= " where SC.SupplierCategory like '" & SupplierCategory & "%' and SD.Userid=237"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerFromStyleAssorment(ByVal CustomerName As String) As DataTable
            Dim str As String
            str = " select  Distinct CD.CustomerName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where CD.CustomerName like '" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerFromSizeWeight(ByVal CustomerName As String) As DataTable
            Dim str As String
            str = " select  Distinct CD.CustomerName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where CD.CustomerName like '" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerFromStyleAssormentForBarCodeView(ByVal CustomerName As String) As DataTable
            Dim str As String
            str = " select  Distinct CD.CustomerName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join DPCuttingProMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where CD.CustomerName like '" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFromStyleAssormentForBarCodeView(ByVal Style As String) As DataTable
            Dim str As String
            str = " select  Distinct JOd.Style AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join DPCuttingProMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JOd.Style like '" & Style & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFromSizeWeight(ByVal Style As String) As DataTable
            Dim str As String
            str = " select  Distinct JOd.Style AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JOd.Style like '" & Style & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFromStyleAssorment(ByVal Style As String) As DataTable
            Dim str As String
            str = " select  Distinct JOd.Style AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JOd.Style like '" & Style & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromSeasonAssormentForBarCodeView(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select  Distinct SD.SeasonName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join DPCuttingProMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where SD.SeasonName like '" & SeasonName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromStyleAssormentForBarCodeView(ByVal SRNO As String) As DataTable
            Dim str As String
            str = " select  Distinct JO.SRNO AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join DPCuttingProMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JO.SRNO like '" & SRNO & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromStyleAssormentNew(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select  Distinct SD.SeasonName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where SD.SeasonName like '" & SeasonName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromStyleAssorment(ByVal SRNO As String) As DataTable
            Dim str As String
            str = " select  Distinct JO.SRNO AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JO.SRNO like '" & SRNO & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromSizeWeight(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select  Distinct SD.SeasonName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where SD.SeasonName like '" & SeasonName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrNoFromSizeWeight(ByVal SRNO As String) As DataTable
            Dim str As String
            str = " select  Distinct JO.SRNO AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where JO.SRNO like '" & SRNO & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonFromStyleAssorment(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select  Distinct SD.SeasonName AS Name from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " where SD.SeasonName like '" & SeasonName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreDalRef(ByVal DalRefNo As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.DalRefNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            'str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2  AND IMS_I.DalRefNo like '" & DalRefNo & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreDalRefGStore(ByVal DalRefNo As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.DalRefNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            'str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4  AND IMS_I.DalRefNo like '" & DalRefNo & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreDalRefForAccess(ByVal DalRefNo As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.DalRefNo AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            'str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_ICL.ItemClassName ='DYEING PROCESS' AND IMS_I.DalRefNo like '" & DalRefNo & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIIMSItemCategoryEdit(ByVal IMSItemCategoryID As Long) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory where IMSItemCategoryID=" & IMSItemCategoryID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAll() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= " join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  where IMS_IC .IMSItemClassID NOT IN(6) order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryFabric() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =1 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryFabricForSearch(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =1 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAccForSearchForAuditor(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAccForSearch(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAccForSearchGStore(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryDForSearch(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =3 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryGForSearch(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryChemicalStoreForSearch(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSFabricForSearch(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =1 and IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSAccForSearchForAuditor(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where  IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSAccForSearch(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 and IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSAccForSearchGstore(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 and IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSDForSearch(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =3 and IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSGForSearch(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 and IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCLASSChemicalForSearch(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 and IMS_ICL.ItemClassName='" & ItemClassName & "' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreCategoryNameAndClass(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 AND IMS_IC.ItemCategoryName  like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreCategoryNameAndClassForAccess(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 AND IMS_ICL.ItemClassName ='DYEING PROCESS' and IMS_IC.ItemCategoryName  like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreCategoryNameAndClassForAuditor(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where IMS_IC.ItemCategoryName like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreCategoryNameAndClass(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =1 AND IMS_IC.ItemCategoryName like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreCategoryNameAndClassGStore(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 AND IMS_IC.ItemCategoryName like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetChemicalstoreCategoryNameAndClass(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 AND IMS_IC.ItemCategoryName like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreClassNameForAuditor(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where  IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreClassName(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =1 AND IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreClassNameGStore(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 AND IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetChemicalstoreClassName(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 AND IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreClassName(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 AND IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreClassNameForAccess(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 AND IMS_ICL.ItemClassName ='DYEING PROCESS' and IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreShadeForAuditor(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where  IMS_I.Shade like '" & Shade & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreShade(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=1  AND IMS_I.Shade like '" & Shade & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCHstoreShade(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=5  AND IMS_I.Shade like '" & Shade & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreShade(ByVal Shade As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=2  AND IMS_I.Shade like '" & Shade & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreShadeGSTORE(ByVal Shade As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=4  AND IMS_I.Shade like '" & Shade & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreShadeForAccess(ByVal Shade As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_ICL.ItemClassName ='DYEING PROCESS' AND IMS_I.Shade like '" & Shade & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDstoreShade(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=3  AND IMS_I.Shade like '" & Shade & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGstoreShade(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.Shade AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=4 AND IMS_I.Shade like '" & Shade & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDstoreClassName(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =3 AND IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGstoreClassName(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_ICL.ItemClassName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 AND IMS_ICL.ItemClassName like '%" & ItemClassName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDstoreCategoryNameAndClass(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =3 AND IMS_IC.ItemCategoryName like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGstoreCategoryNameAndClass(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 AND IMS_IC.ItemCategoryName  like '%" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAccessoriesForAcc() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 and IMS_ICL.ItemClassName ='DYEING PROCESS' order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAccessoriesForAuditor() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "   order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAccessories() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =2 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryGStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryDead() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =3 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryGeneral() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =4 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryChemicalStoree() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryChemicalStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryChemical() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= "  join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= "  where ST.StoreTypeID =5 order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryAllNew() As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= " join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= " where IMS_IC.IMSItemClassID=6 "
            str &= " order by IMS_IC.IMSItemCategoryID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetIMSItemCategoryAllD(ByVal IMSItemClassID As Long) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= " join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= " where IMS_IC.IMSItemClassID=" & IMSItemClassID
            str &= " order by IMS_IC.ItemCategoryName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategoryD(ByVal IMSItemCategoryID As Long) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory IMS_IC "
            str &= " join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= " where IMS_IC.IMSItemCategoryID=" & IMSItemCategoryID
            str &= " order by IMS_IC.ItemCategoryName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreItemCodeForAuditor(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_I.ItemCodee like '" & ItemCodee & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFstoreItemCode(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=1  AND IMS_I.ItemCodee like '" & ItemCodee & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetstoreItemCategoryForInventoryReportForFSTORE(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " where IMS_ICL.StoreTypeID=1  AND IMS_IC.ItemCategoryName like '" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetstoreItemCategoryForInventoryReportForFSTOREForProcess(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " where IMS_ICL.IMSItemClassID=26  AND IMS_IC.ItemCategoryName like '" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetstoreItemCategoryForInventoryReportForASTORE(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " where IMS_ICL.StoreTypeID=2  AND IMS_IC.ItemCategoryName like '" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetstoreItemCategoryForInventoryReportForAUDITOR(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_IC.ItemCategoryName AS Name from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " where  IMS_IC.ItemCategoryName like '" & ItemCategoryName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetChemicalstoreItemCode(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=5 AND IMS_I.ItemCodee like '" & ItemCodee & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreItemCodee(ByVal ItemCodee As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=2  AND IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreItemCodeeGStore(ByVal ItemCodee As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=4  AND IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAstoreItemCodeeForAccess(ByVal ItemCodee As String) As DataTable
            Dim str As String

            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_ICL.ItemClassName ='DYEING PROCESS' AND IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDstoreItemCodee(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=3  AND IMS_I.ItemCodee like '" & ItemCodee & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGstoreItemCodee(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select Distinct IMS_I.ItemCodee AS Name, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=4 AND IMS_I.ItemCodee like '" & ItemCodee & "%'"
            Try
                Return MyBase.GetDataTable(str)
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
    End Class
End Namespace