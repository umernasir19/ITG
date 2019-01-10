Imports System.Data
    Namespace EuroCentra
Public Class DPPoRecevMst
 Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPPOReceiveMst"
            m_strPrimaryFieldName = "POReceiveMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lPOReceiveMstID As Long
        Private m_dtCreationDate As Date
        Private m_dtReceiveDate As Date

        Private m_strReceiveTime As String
        Private m_strGRNo As String
        Private m_lSupplierID As Long
        Private m_DPFabricMstID As Long
        Private m_strDCNo As String
        Public Property DCNo() As String
            Get
                DCNo = m_strDCNo
            End Get
            Set(ByVal value As String)
                m_strDCNo = value
            End Set
        End Property
        Public Property POReceiveMstID() As Long
            Get
                POReceiveMstID = m_lPOReceiveMstID
            End Get
            Set(ByVal value As Long)
                m_lPOReceiveMstID = value
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
        Public Property ReceiveDate() As Date
            Get
                ReceiveDate = m_dtReceiveDate
            End Get
            Set(ByVal value As Date)
                m_dtReceiveDate = value
            End Set
        End Property
       
       
        Public Property ReceiveTime() As String
            Get
                ReceiveTime = m_strReceiveTime
            End Get
            Set(ByVal value As String)
                m_strReceiveTime = value
            End Set
        End Property
        Public Property GRNo() As String
            Get
                GRNo = m_strGRNo
            End Get
            Set(ByVal value As String)
                m_strGRNo = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal value As Long)
                m_lSupplierID = value
            End Set
        End Property
        Public Property DPFabricMstID() As Long
            Get
                DPFabricMstID = m_DPFabricMstID
            End Get
            Set(ByVal value As Long)
                m_DPFabricMstID = value
            End Set
        End Property
        Public Function Save()
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
        Public Function GetGrNnoFromPurchaseForAuditor()
            Dim str As String
            Try
                str = " select * from PORecvMaster Mst "
                str &= "  join POMaster po on po.POID =mst.POID "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetGrNnoFromPurchaseForAcc()
            Dim str As String
            Try
                str = " select * from PORecvMaster Mst "
                str &= "  join POMaster po on po.POID =mst.POID "
                str &= "  where po.FabricPOrder = 0 and po.GStoreStatus=0"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetGrNnoFromPurchaseForGStore()
            Dim str As String
            Try
                str = " select * from PORecvMaster Mst "
                str &= "  join POMaster po on po.POID =mst.POID "
                str &= "  where po.GStoreStatus=1"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetGrNnoFromPurchaseForProcess()
            Dim str As String
            Try
                str = " select * from POProcessRecvMaster Mst "
                str &= "  join ProcessOrderMst po on po.ProcessOrderMstID =mst.ProcessOrderMstID "
                str &= "  where po.FabricPOrder = 1"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetGrNnoFromPurchase()
            Dim str As String
            Try
                str = " select * from PORecvMaster Mst "
                str &= "  join POMaster po on po.POID =mst.POID "
                str &= "  where po.FabricPOrder = 1"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportForAuditorNew(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= " where pm.PORecvdate between '" & StartDate & "' and  '" & EndDate & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportForAuditor()
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportForAcc()
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= "  where POM.FabricPOrder = 0"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportForAccNew(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= "  where POM.FabricPOrder = 0 and POM.GStoreStatus =0 and pm.PORecvdate between '" & StartDate & "' and  '" & EndDate & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportForAccNewGStore(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= "  where  POM.GStoreStatus =1 and pm.PORecvdate between '" & StartDate & "' and  '" & EndDate & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportForProcess()
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate+Pod.PORate),0)as RecvRate"
                str &= " ,* from POProcessRecvMaster pm"
                str &= " join POProcessRecvDetail pd on pd.POProcessRecvMasterID =pm.POProcessRecvMasterID"
                str &= " join ProcessOrderDtl Pod On POD.ProcessOrderDtlId = pd.ProcessOrderDtlId"
                str &= " JOIN ProcessOrderMst POM ON POM.ProcessOrderMstID =POD.ProcessOrderMstID AND POM.ProcessOrderMstID=PM.ProcessOrderMstID "
                str &= " join IMSItem im on im.IMSItemID =POD.ProcessItemNameID "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= "    where POM.FabricPOrder = 1"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReport()
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= "  where POM.FabricPOrder = 1"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPurchaseRegisterReportNew(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            Try
                str = " select ISNULL((pd.RecvQuantity),0)as RecvQty, ISNULL((Pod.Rate),0)as RecvRate"
                str &= " ,* from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= "  where POM.FabricPOrder = 1 and pm.PORecvdate between '" & StartDate & "' and  '" & EndDate & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSecondLastPurchase(ByVal ItemId As Long, ByVal PORecvdate As Date)
            Dim str As String
            Try
                str = " select top 1  isnull(Pod.Rate,0) as SecondLastPurchaseRate,isnull(convert(varchar,pm.PORecvdate,103),'') as SecondLastPurchaseDate from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= " where Pod.ItemId='" & ItemId & "' and  pm.PORecvdate <'" & PORecvdate & "' order by pm.PORecvMasterID desc"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastPurchase(ByVal ItemId As Long, ByVal PORecvdate As String)
            Dim str As String
            Try
                str = " select top 2  isnull(Pod.Rate,0) as LastPurchaserate,isnull(convert(varchar,pm.PORecvdate,103),'') AS LastPurchaseDate from PORecvMaster pm"
                str &= " join PORecvDetail pd on pd.PORecvMasterID =pm.PORecvMasterID"
                str &= " join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
                str &= " JOIN POMaster POM ON POM.POID =POD.POID AND POM.POID=PM.POID "
                str &= " join IMSItem im on im.IMSItemID =POD.ItemId "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= " where Pod.ItemId='" & ItemId & "' and  convert(Varchar,pm.PORecvdate,103) <'" & PORecvdate & "'  order by pm.PORecvMasterID desc"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastPurchaseForProcess(ByVal ItemId As Long, ByVal PORecvdate As String)
            Dim str As String
            Try
                str = " select top 2  isnull(Pod.Rate+Pod.PORate,0) as LastPurchaserate,isnull(convert(varchar,pm.PORecvdate,103),'') AS"
                str &= " LastPurchaseDate from POProcessRecvMaster pm"
                str &= " join POProcessRecvDetail pd on pd.POProcessRecvMasterID =pm.POProcessRecvMasterID"
                str &= " join ProcessOrderDtl Pod On POD.ProcessOrderDtlId = pd.ProcessOrderDtlId"
                str &= " JOIN ProcessOrderMst POM ON POM.ProcessOrderMstID =POD.ProcessOrderMstID AND POM.ProcessOrderMstID=PM.ProcessOrderMstID "
                str &= " join IMSItem im on im.IMSItemID =POD.ProcessItemNameID  "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =pm.SupplierID "
                str &= " where Pod.ProcessItemNameID='" & ItemId & "' and  convert(Varchar,pm.PORecvdate,103) <'" & PORecvdate & "'  order by pm.POProcessRecvMasterID desc"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleForStyleDatabase()
            Dim str As String
            Try
                str = " select Distinct DPStyleDatabaseID,StyleCode from DPStyleDatabase"
                str &= " order by StyleCode  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDescriptionForStyleDatabase()
            Dim str As String
            Try
                str = " select Distinct Description,DPStyleDatabaseID from DPStyleDatabase"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierForFabricStock()
            Dim str As String
            Try
                str = " select Distinct SupplierDatabaseID,SupplierName from SupplierDatabase "
                str &= " order by SupplierName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameaLLAstore()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.Itemname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameaLLFstoreMonthylComparision()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=1"
                str &= " order by IMC.Itemname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameaLLAstoreMonthylComparision()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.Itemname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemCategoryAstore()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSItemCategoryID,IMC.ItemCategoryname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMC On IMC.IMSItemClassID=IM.IMSItemClassID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.ItemCategoryname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetDalNo()
            Dim str As String
            Try
                str = " select * from  DPFabricDbMst"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerForStyleDatabase()
            Dim str As String
            Try
                str = "  select Distinct C.CustomerName,C.CustomerID from DPStyleDatabase SD Join Customer C on C.CustomerID= SD.CustomerID"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPONO(ByVal SupplierID As Long)
            Dim str As String
            Try
                str = "select DPPOMstID,PONO from DPPOMst Where SupplierID='" & SupplierID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function Deletedetail(ByVal POReceiveDtlID As Long)
            Dim str As String
            str = " Delete  from DPPOReceiveDtl where POReceiveDtlID ='" & POReceiveDtlID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFBDataforFabStockSumry(ByVal SupplierDatabaseID As String)
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where V.SupplierDatabaseID='" & SupplierDatabaseID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetOpenQTy(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where FM.DalNo='" & DalNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEdit(ByVal POReceiveMstID As Long)
            Dim str As String
            Try
                str = " select * from  DPPOReceiveMst dr"
                str &= " join DPPOReceiveDtl drd on drd.POReceiveMstID =dr.POReceiveMstID "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =dr.SupplierID "
                str &= " join DPPOMst dm on dm.DPPOMstID =drd.DPPOMstID "
                str &= " join DPPODtl dd on dd.DPPOMstID =dm.DPPOMstID "
                str &= " where dr.POReceiveMstID ='" & POReceiveMstID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierComboN()
            Dim str As String
            Try
                str = "select Distinct V.VenderLibraryID,V.VenderName  from Vender V "
                str &= " order by V.VenderName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierComboNNew()
            Dim str As String
            Try
                str = " select Distinct CustomerID,CustomerName from Customer "
                str &= " order by CustomerName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierComboNNeww()
            Dim str As String
            Try
               
                str = " select Distinct SupplierDatabaseId,SupplierName from SupplierDatabase "
                str &= " order by SupplierName  ASC"
               
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemCategory()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSItemCategoryID,IMC.ItemCategoryname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMC On IMC.IMSItemClassID=IM.IMSItemClassID"
                str &= " where IM.StoreTypeId=1"
                str &= " order by IMC.ItemCategoryname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemCategoryforAStore()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSItemCategoryID,IMC.ItemCategoryname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMC On IMC.IMSItemClassID=IM.IMSItemClassID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.ItemCategoryname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemCategoryforAStoreDeadStock()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSItemCategoryID,IMC.ItemCategoryname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMC On IMC.IMSItemClassID=IM.IMSItemClassID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.ItemCategoryname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemName(ByVal ItemCategoryID As Long)
            Dim str As String
            Try

                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=1 and IMC.IMSItemCategoryID='" & ItemCategoryID & "'"
                str &= " order by IMC.Itemname  ASC"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameForAStore(ByVal ItemCategoryID As Long)
            Dim str As String
            Try

                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2 and IMC.IMSItemCategoryID='" & ItemCategoryID & "'"
                str &= " order by IMC.Itemname  ASC"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameForAStoreDeadStock(ByVal ItemCategoryID As Long)
            Dim str As String
            Try

                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2 and IMC.IMSItemCategoryID='" & ItemCategoryID & "'"
                str &= " order by IMC.Itemname  ASC"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameaLL()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=1"
                str &= " order by IMC.Itemname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        
        Public Function GetBindItemNameaLLForAStore()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.Itemname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameaLLForAStoreDeadStock()
            Dim str As String
            Try
                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2"
                str &= " order by IMC.Itemname  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNoForFabricReceive()
            Dim str As String
            Try
                str = "  select distinct POM.DalNo from DPPOReceiveMst FM "
                str &= " JOIN DPPOReceiveDtl FMD on FMD.POReceiveMstID=FM.POReceiveMstID"
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join DPPOMst POM on POM.DPPOMstID=FMD.DPPOMstID"
                str &= " JOIN DPPODtl POD on POD.DPPOMstID=POM.DPPOMstID"


           
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemForFabricReceive()
            Dim str As String
            Try
                str = "  select * from DPPOReceiveMst FM "
                str &= " JOIN DPPOReceiveDtl FMD on FMD.POReceiveMstID=FM.POReceiveMstID"
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join DPPOMst POM on POM.DPPOMstID=FMD.DPPOMstID"
                str &= " JOIN DPPODtl POD on POD.DPPOMstID=POM.DPPOMstID"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleForSampleRecv()
            Dim str As String
            Try
                str = " select Distinct POD.Style from DPPOReceiveMst FM "
                str &= " JOIN DPPOReceiveDtl FMD on FMD.POReceiveMstID=FM.POReceiveMstID"
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join DPPOMst POM on POM.DPPOMstID=FMD.DPPOMstID"
                str &= " JOIN DPPODtl POD on POD.DPPOMstID=POM.DPPOMstID"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
       
        Public Function GetStyle()
            Dim str As String
            Try
                str = " select Distinct DPRNDID,Style from TblDPRND "
                str &= " order by Style  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleForSamploeReceiveSheet()
            Dim str As String
            Try

                str = " select Distinct RND.DPRNDID,RND.Style from DPSampleReceive FR"
                str &= " join TblDPRND RND on RND.DPRNDID=FR.DPRNDID"
                str &= " order by RND.Style  ASC"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDSRNOForSamploeReceiveSheet()
            Dim str As String
            Try

                str = " select * from DPSampleReceive FR"
                str &= " join TblDPRND RND on RND.DPRNDID=FR.DPRNDID"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyerForSamploeReceiveSheet()
            Dim str As String
            Try

                str = " select * from DPSampleReceive FR"
                str &= " join TblDPRND RND on RND.DPRNDID=FR.DPRNDID"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyerForSamploeReceiveSheetNew()
            Dim str As String
            Try

                str = " select distinct RND.Buyer from DPSampleReceive FR"
                str &= " join TblDPRND RND on RND.DPRNDID=FR.DPRNDID"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemDropdown()
            Dim str As String
            Try
                str = "  select Distinct DPRNDStyleDetailID,Description from DPRNDStyleDetail "
                str &= "  order by Description  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleFroSampleProgramSheet()
            Dim str As String
            Try
                str = "  select distinct RND.Style from TblDPRND RND"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTableSampleProgram()
            Dim str As String
            Try
                str = " truncate table TemSampleProgramSheet"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNoFroSampleProgramSheet()
            Dim str As String
            Try
                str = "  select distinct RND.DalNo from TblDPRND RND"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNO(ByVal DPPOMstID As Long)
            Dim str As String
            Try
                str = "SELECT DalNo,FabricDbMstID from DPPOMst where DPPOMstID='" & DPPOMstID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemStyleUnitPOQty(ByVal DPPOMstID As Long)
            Dim str As String
            Try
                str = "select * from DPPOMst Mst"
                str &= " join DPPODtl Dtl ON Dtl.DPPOMstID=Mst.DPPOMstID where  Mst.DPPOMstID='" & DPPOMstID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemStyleUnitPOQtyData(ByVal DPPOMstID As Long, ByVal DPPODetailID As Long)
            Dim str As String
            Try
                str = "select * from DPPOMst Mst"
                str &= " join DPPODtl Dtl ON Dtl.DPPOMstID=Mst.DPPOMstID where  Mst.DPPOMstID='" & DPPOMstID & "' and DPPODtlID='" & DPPODetailID & "'"
            
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 GRNo from DPPOReceiveMst  order By POReceiveMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemRecvePOQtyData(ByVal DPPOMstID As Long, ByVal DPPODetailID As Long)
            Dim str As String
            Try

                str = " select  isnull(sum(ReceiveQty),0) as RecvQty  from DPPOReceiveMst Mst"
                str &= " join DPPOReceiveDtl Dtl ON Dtl.POReceiveMstID=Mst.POReceiveMstID "
                str &= " where  Dtl.DPPOMstID='" & DPPOMstID & "' and DPPODtlID='" & DPPODetailID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData()
            Dim str As String
            Try
                'str = "select convert (varchar,ReceiveDate,103) as ReceiveDatee, * from DPPOReceiveMst dm join SupplierDatabase v on v.SupplierDatabaseID=dm.SupplierID"
                str = " select DalNo,DM.POReceiveMstID,convert (varchar,ReceiveDate,103) as ReceiveDatee,SupplierName,sum(ReceiveQty) as TotalQty,GRNo ,DCNO from DPPOReceiveMst DM "
                str &= " join SupplierDatabase v on v.SupplierDatabaseID=dm.SupplierID"
                str &= " join DPPOReceiveDtl DR ON DR.POReceiveMstID=DM.POReceiveMstID"
                str &= " join DPFabricDBMst FD on FD.FabricDBMstId=DR.DPFabricMSTID"
                str &= " group by DM.POReceiveMstID,ReceiveDate,SupplierName,GRNo,DCNO,DalNo order by ReceiveDate DESC "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNOforSummary()
            Dim str As String
            Try
                str = "select FabricDbMstID,DalNo from DPFabricDbMst  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierforSummary()
            Dim str As String
            Try
                str = " select distinct sd.SupplierDatabaseID,sd.SupplierName from SupplierDatabase sd"
                str &= " join DPFabricDbMst dp on dp.SupplierID=sd.SupplierDatabaseID  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyerFromRNDANDFabricCon()
            Dim str As String
            Try
                str = " select distinct C.CustomerName  from Customer C"
                str &= " join TblDPRND RND ON RND.Buyer =C.CustomerName "
                str &= " LEFT JOIN FabricConsumption FC on FC.Buyerid =C.CustomerID "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleFromRNDANDFabricCon()
            Dim str As String
            Try
                str = " select distinct SD.StyleCode  from DPStyleDatabase SD"
                str &= " join TblDPRND RND on RND.Style =SD.StyleCode "
                str &= " LEFT JOIN FabricConsumption FC on FC.StyleNo =SD.StyleCode "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNoFromRNDANDFabricCon()
            Dim str As String
            Try
                str = " select distinct Mst.DalNo  from DPFabricDbMst Mst"
                str &= " join TblDPRND RND on RND.DALNo =Mst.DalNo "
                str &= " LEFT JOIN FabricConsumption FC on FC.DalNo =MST.DalNo "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierArtNoFroFabricReceiveList()
            Dim str As String
            Try
                str = " select distinct FabricName from DPFabricDbMst FD  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetDalNOforRND()
            Dim str As String
            Try
                str = " select * from TblDPRND  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierforFabricReceiveList()
            Dim str As String
            Try
                str = " select distinct FD.SupplierID,SD.SupplierName from DPFabricDbMst FD"
                str &= " join SupplierDatabase SD on SD.SupplierDatabaseId=FD.SupplierId"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleforSummary(ByVal FabricDbMstID As Long)
            Dim str As String
            Try
                If FabricDbMstID = 0 Then
                    str = "select  * from TblDPRND"
                Else
                    str = "select  * from TblDPRND where FabricDbMstID='" & FabricDbMstID & "'"
                End If

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetStylefoRND()
            Dim str As String
            Try

                str = "select  * from TblDPRND"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetWorkerNAME()
            Dim str As String
            Try

                str = " SELECT distinct FIW.WorkerName  from DPFabricIssue FI"
                str &= " join DPFabricIssueWorkerDtl FIW on FIW.FabricIssueID=FI.FabricIssueID"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyerForSampleWorkersReport()
            Dim str As String
            Try

                str = " SELECT distinct FIW.Buyer  from DPFabricIssue FI"
                str &= " join tblDPRND FIW on FIW.dprndID=FI.dprndID"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleForSampleWorkersReport()
            Dim str As String
            Try

                str = " SELECT distinct FIW.Style  from DPFabricIssue FI"
                str &= " join tblDPRND FIW on FIW.dprndID=FI.dprndID"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDescriptionforRND()
            Dim str As String
            Try

                str = "select distinct Description from DPRNDStyleDetail SD"
                str &= " join tbldprnd dp on dp.dprndid=sd.dprndid"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierForFabricLedger()
            Dim str As String
            Try
                str = " select Distinct SupplierDatabaseID,SupplierName from SupplierDatabase "
                str &= " order by SupplierName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindItemNameAstore(ByVal ItemCategoryID As Long)
            Dim str As String
            Try

                str = "  select Distinct IMC.IMSIteMID,IMC.Itemname  from IMSItemClass IM"
                str &= " join IMSItemCategory IMCC On IMCC.IMSItemClassID=IM.IMSItemClassID"
                str &= " join IMSItem IMC On IMC.IMSItemCategoryID=IMCC.IMSItemCategoryID"
                str &= " where IM.StoreTypeId=2 and IMC.IMSItemCategoryID='" & ItemCategoryID & "'"
                str &= " order by IMC.Itemname  ASC"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierCodeForFabricLedger()
            Dim str As String
            Try
                str = " select Distinct SupplierDatabaseID,SupplierCode from SupplierDatabase "
                str &= " order by SupplierCode  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierCategoryForFabricLedger()
            Dim str As String
            Try
                str = " select Distinct SC.SupplierCategory,SC.SupplierCategoryID  from SupplierDatabase SD"
                str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryID=SD.SupplierCategoryID"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDALNOForFabricLedger(ByVal SupplierID As Long)
            Dim str As String
            Try
                str = "  select * from DPFabricDbMst "
                str &= " where  SupplierID='" & SupplierID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDALNOForFabricLedgerNew()
            Dim str As String
            Try
                str = "  select * from DPFabricDbMst "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierRefNoForFabricLedgerNew()
            Dim str As String
            Try
                str = "  select * from DPFabricDbMst "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTempLedgerTable()
            Dim str As String = "TRUNCATE TABLE  TemTableFabricLedgerDetail"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTempLedgerTableFinal()
            Dim str As String = "TRUNCATE TABLE  TemTableFabricLedgerDetailFinal"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

        'Public Function InsertIssueDataNew(ByVal FabricDbMstID As Long)

        '    Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
        '    str &= " select SD.SupplierName,FDB.DalNo,isnull((DFI.FabricIssueDate),'')as FabricIssueDate,FDB.FabricQuality,isnull((DFI.TotalFabricReq),'0')as TotalFabricReq,"
        '    str &= " '0' as ReceiveQty,isnull((DFI.IssueNo),'') as IssueNo,'' as RecvNo"
        '    str &= " from DPFabricDbMst FDB "
        '    str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
        '    str &= "  join DPFabricIssue DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"
        '    str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"


        '    Try
        '        MyBase.ExecuteNonQuery(str)
        '    Catch ex As Exception
        '    End Try
        'End Function

        Public Function InsertIssueDataNew(ByVal FabricDbMstID As Long)

            'Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            'str &= " select SD.SupplierName,FDB.DalNo,DFI.FabricIssueDate,FDB.FabricQuality,DFI.TotalFabricReq,"
            'str &= " '0' as ReceiveQty"
            'str &= " from DPFabricDbMst FDB "
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            'str &= " join DPFabricIssue DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"
            'str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"

            Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            str &= " select SD.SupplierName,FDB.DalNo,isnull((DFI.FabricIssueDate),'')as FabricIssueDate,FDB.FabricQuality,isnull((DFI.TotalFabricReq),'0')as TotalFabricReq,"
            str &= " '0' as ReceiveQty,isnull((DFI.IssueNo),'') as IssueNo,'' as RecvNo"
            str &= " from DPFabricDbMst FDB "
            str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            str &= "  join DPFabricIssue DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"
            str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertIssueDataFromFabricIssueNew(ByVal FabricDbMstID As Long)

            'Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            'str &= " select SD.SupplierName,FDB.DalNo,DID.IssueDate,FDB.FabricQuality,DFI.IssueQty,"
            'str &= "   '0' as ReceiveQty"
            'str &= " from DPFabricDbMst FDB "
            'str &= " left join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            'str &= " left join DPPOIssueDTL DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"
            'str &= " left join DPPOIssueMst DID on DID.DPPOIssueMstID=DFI.DPPOIssueMstID"
            'str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"

            Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            str &= " select SD.SupplierName,FDB.DalNo,isnull((DID.IssueDate),'')as IssueDate,FDB.FabricQuality,isnull((DFI.IssueQty),'0')as IssueQty,"
            str &= "   '0' as ReceiveQty,isnull((DID.IssueVoucherNo),'') as IssueNo,'' as RecvNo"
            str &= " from DPFabricDbMst FDB "
            str &= "   left join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            str &= "   left join DPPOIssueDTL DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"
            str &= "   left join DPPOIssueMst DID on DID.DPPOIssueMstID=DFI.DPPOIssueMstID"
            str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFBData(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where fm.DalNo='" & DalNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertReceiveDataNew(ByVal FabricDbMstID As Long)

            'Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            'str &= " select SD.SupplierName,FDB.DalNo,DFI.ReceiveDate,FDB.FabricQuality,'0' as IssueQty,DFI.ReceiveQty"
            'str &= " from DPFabricDbMst FDB "
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            'str &= " join DPPOReceiveDtl DFI on DFI.FabricMstID=FDB.FabricDbMstID"
            'str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"


            'Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            'str &= "    select SD.SupplierName,FDB.DalNo,DFM.ReceiveDate,FDB.FabricQuality,'0' as IssueQty,DFI.ReceiveQty"
            'str &= " from DPFabricDbMst FDB "
            'str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            'str &= "  join DPPOReceiveDtl DFI on DFI.DPFabricMstID=FDB.FabricDbMstID"
            'str &= " join DPPOReceiveMst DFM on DFM.POReceiveMstID=DFI.POReceiveMstID"
            'str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"

            Dim str As String = " INSERT INTO TemTableFabricLedgerDetail "
            str &= "    select SD.SupplierName,FDB.DalNo,isnull((DFM.ReceiveDate),'')as ReceiveDate,FDB.FabricQuality,'0' as IssueQty,isnull((DFI.ReceiveQty),'0')as ReceiveQty,'' as IssueNo,isnull((DFM.GRNo),'') as RecvNo"
            str &= " from DPFabricDbMst FDB "
            str &= "  join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            str &= "  join DPPOReceiveDtl DFI on DFI.DPFabricMstID=FDB.FabricDbMstID"
            str &= "  join DPPOReceiveMst DFM on DFM.POReceiveMstID=DFI.POReceiveMstID"
            str &= " where FDB.FabricDbMstID = '" & FabricDbMstID & "'"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertFinalTemTable()

            'Dim str As String = " INSERT INTO TemTableFabricLedgerDetailFinal "
            'str &= " select SupplierName,DalNo,CreationDate,FabricQuality,IssueQty,ReceiveQty"
            'str &= " from TemTableFabricLedgerDetail"
            'str &= " order By CreationDate ASC"

            Dim str As String = " INSERT INTO TemTableFabricLedgerDetailFinal "
            str &= " select SupplierName,DalNo,CreationDate,FabricQuality,IssueQty,ReceiveQty, RecvNo,IssueNo"
            str &= " from TemTableFabricLedgerDetail"
            str &= " order By CreationDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDALNOForFabricLedgerDetailFormat()
            Dim str As String
            Try
                str = "  select * from DPFabricDbMst "


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function


        Public Function TruncateTempStockSummaryTable()
            Dim str As String = "TRUNCATE TABLE  TemTableFabricStockSummaryDetail"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTempStockSummaryFinal()
            Dim str As String = "TRUNCATE TABLE  TemTableFabricStockSummaryFinal"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertIssueDataNewStockSummary()

            Dim str As String = " INSERT INTO TemTableFabricStockSummaryDetail "
            str &= " select SD.SupplierName,FDB.DalNo,DFI.FabricIssueDate,FDB.FabricQuality,DFI.TotalFabricReq,"
            str &= " '0' as ReceiveQty,DFI.IssueNo as DOCNo,'ISSUE' as Type"
            str &= " from DPFabricDbMst FDB "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            str &= " join DPFabricIssue DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"



            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertIssueDataFromFabricIssueforStockSummary()

            Dim str As String = " INSERT INTO TemTableFabricStockSummaryDetail "
            str &= " select SD.SupplierName,FDB.DalNo,DID.IssueDate,FDB.FabricQuality,DFI.IssueQty,"
            str &= "   '0' as ReceiveQty,DID.IssueVoucherNo as DOCNo,'ISSUE' as Type"
            str &= " from DPFabricDbMst FDB "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            str &= " join DPPOIssueDTL DFI on DFI.FabricDbMstID=FDB.FabricDbMstID"
            str &= " join DPPOIssueMst DID on DID.DPPOIssueMstID=DFI.DPPOIssueMstID"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertReceiveDataNewforStockSummary()

            Dim str As String = " INSERT INTO TemTableFabricStockSummaryDetail "
            str &= " select SD.SupplierName,FDB.DalNo,DFM.ReceiveDate,FDB.FabricQuality,'0' as IssueQty,DFI.ReceiveQty,DFM.GRNO as DOCNo,'RECEIVE' as Type"
            str &= " from DPFabricDbMst FDB "
            str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=FDB.SupplierID"
            str &= "  join DPPOReceiveDtl DFI on DFI.DPFabricMstID=FDB.FabricDbMstID"
            str &= " join DPPOReceiveMst DFM on DFM.POReceiveMstID=DFI.POReceiveMstID"


            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InsertFinalTemTableforStockSummary()

            Dim str As String = " INSERT INTO TemTableFabricStockSummaryFinal "
            str &= " select SupplierName,DalNo,CreationDate,FabricQuality,IssueQty,ReceiveQty,DOCNo,Type"
            str &= " from TemTableFabricStockSummaryDetail"
            str &= " order By CreationDate ASC"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

