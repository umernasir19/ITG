Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSItem
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSItem"
            m_strPrimaryFieldName = "IMSItemID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lIMSItemID As Long
        Private m_dtCreationDate As Date
        Private m_lIMSItemClassID As Long
        Private m_lIMSItemCategoryID As Long
        Dim m_strItemName As String
        Dim m_strItemCode As String
        Private m_lItemUnitId As Long
        Private m_dbUnitRate As Decimal
        Private m_dbOpeningQuantity As Decimal
        Private m_dbOpeningValue As Decimal
        Private m_dbReorderQuantity As Decimal
        Private m_dbMaxIssueQuantity As Decimal
        Private m_lIMSCurrencyID As Long
        Private m_dbItemCodePart As Decimal
        Private m_lFabricDBMstId As Long
        Private m_strItemStatus As String
        Private m_strItemQuality As String
        Private m_strItemComposition As String
        Private m_strItemWashDye As String
        Private m_strItemFinish As String
        Private m_strShade As String
        Private m_strColor As String
        Private m_strDalRefNo As String

        Private m_strWidth As String
        Private m_strGSMBeforeWash As String
        Private m_strGSMAfterWash As String
        Public Property Width() As String
            Get
                Width = m_strWidth
            End Get
            Set(ByVal Value As String)
                m_strWidth = Value
            End Set
        End Property
        Public Property GSMBeforeWash() As String
            Get
                GSMBeforeWash = m_strGSMBeforeWash
            End Get
            Set(ByVal Value As String)
                m_strGSMBeforeWash = Value
            End Set
        End Property
        Public Property GSMAfterWash() As String
            Get
                GSMAfterWash = m_strGSMAfterWash
            End Get
            Set(ByVal Value As String)
                m_strGSMAfterWash = Value
            End Set
        End Property
        Public Property DalRefNo() As String
            Get
                DalRefNo = m_strDalRefNo
            End Get
            Set(ByVal Value As String)
                m_strDalRefNo = Value
            End Set
        End Property
        Public Property Shade() As String
            Get
                Shade = m_strShade
            End Get
            Set(ByVal Value As String)
                m_strShade = Value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal Value As String)
                m_strColor = Value
            End Set
        End Property
       
        Public Property FabricDBMstId() As Long
            Get
                FabricDBMstId = m_lFabricDBMstId
            End Get
            Set(ByVal Value As Long)
                m_lFabricDBMstId = Value
            End Set
        End Property
        Public Property IMSItemID() As Long
            Get
                IMSItemID = m_lIMSItemID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemID = Value
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
        Public Property IMSItemCategoryID() As Long
            Get
                IMSItemCategoryID = m_lIMSItemCategoryID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemCategoryID = Value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal Value As String)
                m_strItemName = Value
            End Set
        End Property
        Public Property ItemCodee() As String
            Get
                ItemCodee = m_strItemCode
            End Get
            Set(ByVal Value As String)
                m_strItemCode = Value
            End Set
        End Property
        Public Property ItemUnitId() As Long
            Get
                ItemUnitId = m_lItemUnitId
            End Get
            Set(ByVal Value As Long)
                m_lItemUnitId = Value
            End Set
        End Property
        Public Property UnitRate() As Decimal
            Get
                UnitRate = m_dbUnitRate
            End Get
            Set(ByVal value As Decimal)
                m_dbUnitRate = value
            End Set
        End Property
        Public Property OpeningQuantity() As Decimal
            Get
                OpeningQuantity = m_dbOpeningQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dbOpeningQuantity = value
            End Set
        End Property
        Public Property OpeningValue() As Decimal
            Get
                OpeningValue = m_dbOpeningValue
            End Get
            Set(ByVal value As Decimal)
                m_dbOpeningValue = value
            End Set
        End Property
        Public Property ReorderQuantity() As Decimal
            Get
                ReorderQuantity = m_dbReorderQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dbReorderQuantity = value
            End Set
        End Property
        Public Property MaxIssueQuantity() As Decimal
            Get
                MaxIssueQuantity = m_dbMaxIssueQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dbMaxIssueQuantity = value
            End Set
        End Property
        Public Property IMSCurrencyID() As Long
            Get
                IMSCurrencyID = m_lIMSCurrencyID
            End Get
            Set(ByVal Value As Long)
                m_lIMSCurrencyID = Value
            End Set
        End Property
        Public Property ItemCodePart() As Decimal
            Get
                ItemCodePart = m_dbItemCodePart
            End Get
            Set(ByVal value As Decimal)
                m_dbItemCodePart = value
            End Set
        End Property
        Public Property ItemStatus() As String
            Get
                ItemStatus = m_strItemStatus
            End Get
            Set(ByVal Value As String)
                m_strItemStatus = Value
            End Set
        End Property
        Public Property ItemQuality() As String
            Get
                ItemQuality = m_strItemQuality
            End Get
            Set(ByVal Value As String)
                m_strItemQuality = Value
            End Set
        End Property
        Public Property ItemComposition() As String
            Get
                ItemComposition = m_strItemComposition
            End Get
            Set(ByVal Value As String)
                m_strItemComposition = Value
            End Set
        End Property
        Public Property ItemWashDye() As String
            Get
                ItemWashDye = m_strItemWashDye
            End Get
            Set(ByVal Value As String)
                m_strItemWashDye = Value
            End Set
        End Property
        Public Property ItemFinish() As String
            Get
                ItemFinish = m_strItemFinish
            End Get
            Set(ByVal Value As String)
                m_strItemFinish = Value
            End Set
        End Property
        Public Function SaveIMSItem()
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
        Public Function GetIMSItemEdit(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = " Select isnull(IMS_f.dalno,'') as DalNoo,* from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left  join DPFabricDbMst IMS_f on IMS_f.FabricDBMstId=IMS_I.FabricDBMstId"
            str &= " where IMS_I.IMSItemID =" & IMSItemID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNew() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.IMSItemClassID=6 "
            str &= " order by IMS_I.ItemCodee ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabric() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewChemStore() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewForChemStore() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewForChemical() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingForF(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingForChemicalStore(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 and IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingForAForAuditor(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingForA(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingForAGStore(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingForD(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=3 and IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetIMSItemAllNewFabricForSearchingForG(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForF(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForChemStore(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 and IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCateGoryID(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemCategory "
            str &= " where ItemCategoryName='" & ItemCategoryName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForF(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForChemicalStore(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 and IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForAForAuditor(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForA(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForAGStore(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForAForAuditor(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForA(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForAGStore(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForD(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=3 and IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForD(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=3 and IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItmeQualityForG(ByVal ItemQuality As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.ItemQuality='" & ItemQuality & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingShadeForG(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.Shade='" & Shade & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewForAuditor() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewAccessories() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewGStore() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewChemical() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewDead() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=3 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewGeneral() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 "
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAll() As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= "  where IMS_ICL .IMSItemClassID NOT IN(6) order by IMS_I.ItemCodee ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        'for One item 
        Public Function GetIMSItemAll(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID where IMS_I.ItemName='" & ItemName & "'"
            str &= " order by IMS_I.ItemCodee ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetIMSItemAllForIssue() As DataTable
            Dim str As String
            str = " Select *, Status='False',isnull((Select Top 1 isnull(CloseQty,0) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) as InhandQty"
            str &= " ,(case when IMS_TM.TransactionMethod='LIFO Method' then"
            str &= " case when isnull((Select Top 1 IMS_SL.ReceiveQty  from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) = 0 then"
            str &= " isnull((Select Top 1 cast(OpenAmount/OpenQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='Open' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " else isnull((Select Top 1 cast(ReceiveAmount/ReceiveQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " end else isnull((Select Top 1 cast(CloseAmount/CloseQty as decimal(10,2)) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0)  end) as AvgRate"
            str &= " ,isnull(IMS_TM.TransactionMethod,'--') as TransactionMethodd from IMSItem IMS_I "
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID "
            str &= " left join IMSTransactionMethod IMS_TM on IMS_TM.IMSItemID=IMS_I.IMSItemID"
            str &= " order by IMS_I.IMSItemID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemForSearchIssue(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *, Status='False',isnull((Select Top 1 isnull(CloseQty,0) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) as InhandQty"
            str &= " ,(case when IMS_TM.TransactionMethod='LIFO Method' then"
            str &= " case when isnull((Select Top 1 IMS_SL.ReceiveQty  from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) = 0 then"
            str &= " isnull((Select Top 1 cast(OpenAmount/OpenQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='Open' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " else isnull((Select Top 1 cast(ReceiveAmount/ReceiveQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " end else isnull((Select Top 1 cast(CloseAmount/CloseQty as decimal(10,2)) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0)  end) as AvgRate"
            str &= " ,isnull(IMS_TM.TransactionMethod,'--') as TransactionMethodd from IMSItem IMS_I "
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID "
            str &= " left join IMSTransactionMethod IMS_TM on IMS_TM.IMSItemID=IMS_I.IMSItemID where IMS_I.ItemName='" & ItemName & "' "
            str &= " order by IMS_I.IMSItemID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItem(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *, Status='False',isnull((Select Top 1 isnull(CloseQty,0) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) as InhandQty"
            str &= " ,(case when IMS_TM.TransactionMethod='LIFO Method' then"
            str &= " case when isnull((Select Top 1 IMS_SL.ReceiveQty  from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) = 0 then"
            str &= " isnull((Select Top 1 cast(OpenAmount/OpenQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='Open' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " else isnull((Select Top 1 cast(ReceiveAmount/ReceiveQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " end else isnull((Select Top 1 cast(CloseAmount/CloseQty as decimal(10,2)) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0)  end) as AvgRate"
            str &= " ,isnull(IMS_TM.TransactionMethod,'--') as TransactionMethodd from IMSItem IMS_I "
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID "
            str &= " left join IMSTransactionMethod IMS_TM on IMS_TM.IMSItemID=IMS_I.IMSItemID where IMS_I.ItemName='" & ItemName & "' "
            str &= " order by IMS_I.IMSItemID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetIMSItemNew(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = " Select *, Status='False',isnull((Select Top 1 isnull(CloseQty,0) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) as InhandQty"
            str &= " ,(case when IMS_TM.TransactionMethod='LIFO Method' then"
            str &= " case when isnull((Select Top 1 IMS_SL.ReceiveQty  from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) = 0 then"
            str &= " isnull((Select Top 1 cast(OpenAmount/OpenQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='Open' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " else isnull((Select Top 1 cast(ReceiveAmount/ReceiveQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " end else isnull((Select Top 1 cast(CloseAmount/CloseQty as decimal(10,2)) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0)  end) as AvgRate"
            str &= " ,isnull(IMS_TM.TransactionMethod,'--') as TransactionMethodd from IMSItem IMS_I "
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID "
            str &= " left join IMSTransactionMethod IMS_TM on IMS_TM.IMSItemID=IMS_I.IMSItemID where IMS_I.IMSItemID='" & IMSItemID & "' "
            str &= " order by IMS_I.IMSItemID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetIMSItemWithLocation(ByVal IMSItemID As Long, ByVal Locationid As Long) As DataTable
            Dim str As String
            str = " Select *, Status='False',isnull((Select Top 1 isnull(CloseQty,0) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID and Locationid='" & Locationid & "' order by IMS_SL.StoreLedgerID DESC),0) as InhandQty"
            str &= " ,(case when IMS_TM.TransactionMethod='LIFO Method' then"
            str &= " case when isnull((Select Top 1 IMS_SL.ReceiveQty  from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) = 0 then"
            str &= " isnull((Select Top 1 cast(OpenAmount/OpenQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='Open' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " else isnull((Select Top 1 cast(ReceiveAmount/ReceiveQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " end else isnull((Select Top 1 cast(CloseAmount/CloseQty as decimal(10,2)) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0)  end) as AvgRate"
            str &= " ,isnull(IMS_TM.TransactionMethod,'--') as TransactionMethodd from IMSItem IMS_I "
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID "
            str &= " left join IMSTransactionMethod IMS_TM on IMS_TM.IMSItemID=IMS_I.IMSItemID where IMS_I.IMSItemID='" & IMSItemID & "' "
            str &= " order by IMS_I.IMSItemID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function


        Public Function GetIMSCode(ByVal IMSItemClassID As Long, ByVal IMSItemCategoryID As Long) As DataTable
            Dim str As String
            str = " Select top 1 * from IMSItem IMS_I"
            str &= " where IMSItemClassID=" & IMSItemClassID
            str &= " and IMSItemCategoryID=" & IMSItemCategoryID
            str &= " order by IMSItemID DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCode() As DataTable
            Dim str As String
            str = " Select  * from IMSItem IMS_I"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCodeNew() As DataTable
            Dim str As String
            str = " Select  * from IMSItem IMS_I "
            str &= " where IMSItemID not in  (select distinct IMSItemID from IMSTransactionMethod)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemInfoByItemCode(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select *, StoreReceivedDetailID=0 from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_I.ItemCodee ='" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllForIssueCode(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select StoreIssueDetailID=0 ,*,isnull((Select Top 1 isnull(CloseQty,0) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) as InhandQty"
            str &= " ,(case when IMS_TM.TransactionMethod='LIFO Method' then"
            str &= " case when isnull((Select Top 1 IMS_SL.ReceiveQty  from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) = 0 then"
            str &= " isnull((Select Top 1 cast(OpenAmount/OpenQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='Open' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " else isnull((Select Top 1 cast(ReceiveAmount/ReceiveQty as decimal(10,2))   from IMSStoreLedger IMS_SL  where IMS_SL.TransactionType='SRV' and IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0) "
            str &= " end else isnull((Select Top 1 cast(CloseAmount/CloseQty as decimal(10,2)) from IMSStoreLedger IMS_SL  where IMS_SL.IMSItemID=IMS_I.IMSItemID order by IMS_SL.StoreLedgerID DESC),0)  end) as AvgRate"
            str &= " from IMSItem IMS_I "
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID "
            str &= " left join IMSTransactionMethod IMS_TM on IMS_TM.IMSItemID=IMS_I.IMSItemID"
            str &= " where IMS_I.ItemCodee ='" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemAllInfo(ByVal ItemName As String)
            Dim Str As String
            Str = " Select *, Status='False' from IMSItem IMS_I"
            Str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            Str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            Str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            Str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= " where IMS_I.ItemName ='" & ItemName & "' "
            Str &= " order by IMS_I.ItemCodee ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOItemName(ByVal ConstructionShow As String)
            Dim Str As String
            Str = " Select ItemName as Name  from IMSItem  where ItemName like '%" & ConstructionShow & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOItemNameByClass(ByVal ConstructionShow As String, ByVal ItemClassId As Long)
            Dim Str As String
            Str = " Select ItemName as Name  from IMSItem it join Accessories a "
            Str &= " on a.IMSItemId=it.ImsItemId where  it.IMSItemClassId='" & ItemClassId & "' and  it.ItemName like  '%" & ConstructionShow & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function ChkExist(ByVal ItemName As String)
            Dim Str As String
            Str = " Select * from IMSItem  where  ItemName='" & ItemName & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        ''' <summary>
        ''' get Dal no New function
        ''' </summary>
        ''' <param name="DalNo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
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
        Public Function GetIMSItemAllNewFabricForSearchingCodeForF(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_I.ItemCodee='" & ItemCodee & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingCodeForAForAuditor(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_I.ItemCodee='" & ItemCodee & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingCodeForA(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_I.ItemCodee='" & ItemCodee & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingCodeForAGstore(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.ItemCodee='" & ItemCodee & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalNoForF(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and FDB.DalNo='" & DalNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalNoForAForAuditor(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where  FDB.DalNo='" & DalNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalNoForA(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and FDB.DalNo='" & DalNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalNoForAGStore(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select *, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and FDB.DalNo='" & DalNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetIMSItemAllNewFabricForSearchingDalRefForF(ByVal DalRefNo As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_I.DalRefNo='" & DalRefNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalRefForAForAuditor(ByVal DalRefNo As String) As DataTable
            Dim str As String
            str = " Select * ,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_I.DalRefNo='" & DalRefNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalRefForA(ByVal DalRefNo As String) As DataTable
            Dim str As String
            str = " Select * ,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_I.DalRefNo='" & DalRefNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingDalRefForAGstore(ByVal DalRefNo As String) As DataTable
            Dim str As String
            str = " Select * ,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.DalRefNo='" & DalRefNo & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemCatForChemStore(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetIMSItemAllNewFabricForSearchingItemCatForF(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemCatForAForAuditor(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_IC.ItemCategoryName='" & ItemCategoryName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemCatForA(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemCatForAGStore(ByVal ItemCategoryName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_IC.ItemCategoryName='" & ItemCategoryName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemClassForF(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=1 and IMS_ICL.ItemClassName='" & ItemClassName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemClassForChemsTOREE(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=5 and IMS_ICL.ItemClassName='" & ItemClassName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemClassForAForAuditor(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where  IMS_ICL.ItemClassName='" & ItemClassName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemClassForA(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=2 and IMS_ICL.ItemClassName='" & ItemClassName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingItemClassForAGStore(ByVal ItemClassName As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo,Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_ICL.ItemClassName='" & ItemClassName & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingCodeForD(ByVal Shade As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=3 and IMS_I.ItemCodee='" & ItemCodee & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemAllNewFabricForSearchingCodeForG(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo, Status='False' from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            str &= " where IMS_ICL.StoreTypeID=4 and IMS_I.ItemCodee='" & ItemCodee & "'"
            str &= " order by IMS_I.CreationDate Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace