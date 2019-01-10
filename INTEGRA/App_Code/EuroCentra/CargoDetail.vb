Imports System.Data

Namespace EuroCentra
    Public Class CargoDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CargoDetail"
            m_strPrimaryFieldName = "CargoDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCargoDetailID As Long
        Private m_lCargoID As Long
        Private m_lPOID As Long
        Private m_lPOPOID As Long
        Private m_lCustomerID As Long

        Private m_dcStyleArticle As String
        Private m_lCommodityID As Long
        Private m_dcCommodity As String
        Private m_dcHsCode As String

        Private m_dcQuantity As Decimal
        Private m_dcPCS As Decimal
        Private m_dcCTNS As Decimal
        Private m_dcShippedRate As Decimal

        Private m_dcWeightPerPcs As Decimal
        Private m_dcWhitePCS As Decimal
        Private m_dcWhiteCTN As Decimal
        '----------------Properties
        Public Property CargoDetailID() As Long
            Get
                CargoDetailID = m_lCargoDetailID
            End Get
            Set(ByVal value As Long)
                m_lCargoDetailID = value
            End Set
        End Property
        Public Property CargoID() As Long
            Get
                CargoID = m_lCargoID
            End Get
            Set(ByVal value As Long)
                m_lCargoID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property POPOID() As Long
            Get
                POPOID = m_lPOPOID
            End Get
            Set(ByVal value As Long)
                m_lPOPOID = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal value As Long)
                m_lCustomerID = value
            End Set
        End Property
        Public Property StyleArticle() As String
            Get
                StyleArticle = m_dcStyleArticle
            End Get
            Set(ByVal value As String)
                m_dcStyleArticle = value
            End Set
        End Property
        Public Property CommodityID() As Long
            Get
                CommodityID = m_lCommodityID
            End Get
            Set(ByVal value As Long)
                m_lCommodityID = value
            End Set
        End Property
        Public Property Commodity() As String
            Get
                Commodity = m_dcCommodity
            End Get
            Set(ByVal value As String)
                m_dcCommodity = value
            End Set

        End Property
        Public Property HsCode() As String
            Get
                HsCode = m_dcHsCode
            End Get
            Set(ByVal value As String)
                m_dcHsCode = value
            End Set
        End Property
        Public Property ShippedRate() As Decimal
            Get
                ShippedRate = m_dcShippedRate
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedRate = value
            End Set
        End Property
        Public Property WeightPerPcs() As Decimal
            Get
                WeightPerPcs = m_dcWeightPerPcs
            End Get
            Set(ByVal value As Decimal)
                m_dcWeightPerPcs = value
            End Set
        End Property
        Public Property WhitePCS() As Decimal
            Get
                WhitePCS = m_dcWhitePCS
            End Get
            Set(ByVal value As Decimal)
                m_dcWhitePCS = value
            End Set
        End Property
        Public Property WhiteCTN() As Decimal
            Get
                WhiteCTN = m_dcWhiteCTN
            End Get
            Set(ByVal value As Decimal)
                m_dcWhiteCTN = value
            End Set
        End Property
        Public Property PCS() As Decimal
            Get
                PCS = m_dcPCS
            End Get
            Set(ByVal value As Decimal)
                m_dcPCS = value
            End Set
        End Property
        Public Property CTNS() As Decimal
            Get
                CTNS = m_dcCTNS
            End Get
            Set(ByVal value As Decimal)
                m_dcCTNS = value
            End Set
        End Property

        Public Property Quantity() As Decimal
            Get
                Quantity = m_dcQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dcQuantity = value
            End Set
        End Property
        Public Function SaveCargoDetail()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoById(ByVal lCargoId As Long)
            Try
                Return MyBase.GetById(lCargoId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCargoDetail(ByVal lPOID As Long)
            Dim Str As String
            Str = " Select  S.StyleID,PO.POID,S.StyleNo,POD.TotalPCS as Quantity "
            Str &= " ,IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PODetailID=CD.POID),0)"
            Str &= " as ReleaseQty, POD.TotalPCS-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            Str &= " POD.PODetailID=CD.POID),0) as RemainQTY,POD.Cartons,  PO.PONO,PO.CustomerID,POD.Vendorid From PurchaseORder PO Join PurchaseOrderDetail"
            Str &= " POD on PO.POID=POD.POID  Join Style S on S.StyleiD=POD.StyleID "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetCargoDetailNewPOIDWise(ByVal lPOID As String)
            Dim Str As String
            Str = "  CREATE TABLE #tempStyles("
            Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(50),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            Str &= " Cartons varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Quantity,ReleaseQty,RemainQTY,Cartons,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID)"
            Str &= " SELECT S.StyleID,POD.PODetailID as POID,S.StyleNo,S.Article,POD.Quantity as Quantity"
            Str &= ",IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PODetailID=CD.POID),0)"
            Str &= "  as ReleaseQty, POD.Quantity-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            Str &= " POD.PODetailID=CD.POID),0) as RemainQTY,Cartons='',  PO.PONO,PO.CustomerID,PO.SupplierID ,CustomerName,POD.Rate,PO.POID as POPOID From PurchaseORder PO Join PurchaseOrderDetail"
            Str &= " POD on PO.POID=POD.POID  Join Style S on S.StyleiD=POD.StyleID  join Customer CC on CC.CustomerID=PO.CustomerID"
            Str &= " select * from #tempStyles where POPoID='" & lPOID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            Finally
                Dim StrDrop As String
            End Try
        End Function
        Public Function GetCargoDetailNew()

            Dim Str As String
            Str = "  CREATE TABLE #tempStyles("
            Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(50),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            Str &= " Cartons varchar(50),ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Quantity,ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID)"
            Str &= " SELECT S.StyleID,POD.PODetailID as POID,S.StyleNo,S.Article,POD.Quantity as Quantity"
            Str &= ",IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PODetailID=CD.POID),0)"
            Str &= "  as ReleaseQty, POD.Quantity-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            Str &= " POD.PODetailID=CD.POID),0) as RemainQTY,Cartons='',ShippedRate='',  PO.PONO,PO.CustomerID,PO.SupplierID ,CustomerName,POD.Rate,PO.POID as POPOID From PurchaseORder PO Join PurchaseOrderDetail"
            Str &= " POD on PO.POID=POD.POID  Join Style S on S.StyleiD=POD.StyleID  join Customer CC on CC.CustomerID=PO.CustomerID where PO.Status !='Cancel'"
            Str &= " select * from #tempStyles "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            Finally
                Dim StrDrop As String
                ' StrDrop = " drop table #tempStyles "
            End Try
        End Function

        Public Function GetCargoDetailNewSearch(ByVal UserID As String)
            Dim Str As String
            Str = "  CREATE TABLE #tempStyles("
            Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(50),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            Str &= " Cartons varchar(50),ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Quantity,ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID)"
            Str &= " SELECT S.StyleID,POD.PODetailID as POID,S.StyleNo,S.Article,POD.Quantity as Quantity"
            Str &= ",IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PODetailID=CD.POID),0)"
            Str &= "  as ReleaseQty, POD.Quantity-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            Str &= " POD.PODetailID=CD.POID),0) as RemainQTY,Cartons='',ShippedRate='',  PO.PONO,PO.CustomerID,PO.SupplierID ,CustomerName,POD.Rate,PO.POID as POPOID From PurchaseORder PO Join PurchaseOrderDetail"
            Str &= " POD on PO.POID=POD.POID  Join Style S on S.StyleiD=POD.StyleID  join Customer CC on CC.CustomerID=PO.CustomerID where PO.Status !='Cancel' and PO.MarchandID='" & UserID & "'"
            Str &= " select * from #tempStyles "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONo(ByVal PONO As String)
            Dim Str As String
            'Str = "  CREATE TABLE #tempStyles("
            'Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(50),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            'Str &= " Cartons varchar(50),ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            'Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Quantity,ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID)"
            'Str &= " SELECT S.StyleID,POD.PODetailID as POID,S.StyleNo,S.Article,POD.Quantity as Quantity"
            'Str &= ",IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PODetailID=CD.POID),0)"
            'Str &= "  as ReleaseQty, POD.Quantity-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            'Str &= " POD.PODetailID=CD.POID),0) as RemainQTY,Cartons='',ShippedRate='',  PO.PONO,PO.CustomerID,PO.SupplierID ,CustomerName,POD.Rate,PO.POID as POPOID From PurchaseORder PO Join PurchaseOrderDetail"
            'Str &= " POD on PO.POID=POD.POID  Join Style S on S.StyleiD=POD.StyleID  join Customer CC on CC.CustomerID=PO.CustomerID where PO.Status !='Cancel' and PO.PONO='" & PONO & "'"
            'Str &= " select * from #tempStyles "

            Str = "  CREATE TABLE #tempStyles("
            Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(500),Colorway varchar(1000),SizeRange varchar(1000),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            Str &= " Cartons varchar(50),ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,venderName varchar(50),Currency varchar(50),InspectedQty varchar(500),sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Colorway,SizeRange,Quantity,ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID,venderName,Currency,InspectedQty)"
            Str &= " SELECT S.StyleID,POD.PodetailID as POID, S.StyleNo,SD.Article,SD.Colorway,SD.SizeRange, cast(Sum(POD.Quantity) as decimal(10,0)) as Quantity "
            Str &= " ,IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PodetailID=CD.POID),0)"
            Str &= "   as ReleaseQty, Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            Str &= "   POD.PodetailID=CD.POID),0) as RemainQTY,Cartons='',POD.Rate as ShippedRate ,"
            Str &= "  PO.PONO, PO.CustomerID,PO.SupplierID ,CustomerName,Rate='0',PO.POID as POPOID ,V.venderName,Po.Currency"
            Str &= " ,IsNull((Select SUM(QD.InspectedQty) From QDInspection QD Where POD.PodetailID=QD.PODetailID and QD.InspStatus='Pass'  and QD.InspectionStatus='Final'),0) as InspectedQty "
            Str &= " From PurchaseORder PO Join PurchaseOrderDetail"
            Str &= "  POD on POD.POID=PO.POID "
            Str &= " Join StyleMaster S on S.StyleiD=POD.StyleID "
            Str &= " Join StyleDetail Sd on Sd.StyleDetailiD=POD.StyleDetailID"
            Str &= " join Vender V on V.VenderlibraryID=Po.SupplierID"
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerID where  Year(PO.CreationDate) >=2012 and PO.Status !='Cancel' and"
            Str &= "  PO.POID in (Select PO.POID from Purchaseorder PO where  PO.PONO='" & PONO & "') "
            Str &= " group by SD.Colorway,SD.SizeRange,SD.Article,S.StyleID,POD.PodetailID,Po.PONO,S.StyleNO, PO.POID,POD.POID,PO.CustomerID,PO.SupplierID,CC.CustomerName,V.venderName,Po.Currency,POD.Rate"
            Str &= " select * from #tempStyles "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNew(ByVal PONO As String)
            Dim Str As String

            'Str = "  CREATE TABLE #tempStyles("
            'Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(500),Colorway varchar(1000),SizeRange varchar(1000),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            'Str &= " Cartons varchar(50),ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,venderName varchar(50),Currency varchar(50),InspectedQty varchar(500),sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            'Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Colorway,SizeRange,Quantity,ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID,venderName,Currency,InspectedQty)"
            'Str &= " SELECT S.StyleID,POD.PodetailID as POID, S.StyleNo,SD.ColorRefNo as Article,SD.Colorway,SD.Sizes as SizeRange, cast(Sum(POD.Quantity) as decimal(10,0)) as Quantity "
            'Str &= " ,IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PodetailID=CD.POID),0)"
            'Str &= "   as ReleaseQty, Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            'Str &= "   POD.PodetailID=CD.POID),0) as RemainQTY,Cartons='',POD.Rate as ShippedRate ,"
            'Str &= "  PO.PONO, PO.CustomerID,PO.SupplierID ,CustomerName,Rate='0',PO.POID as POPOID ,V.venderName,Po.Currency"
            'Str &= " ,IsNull((Select SUM(QD.InspectedQty) From QDInspection QD Where POD.PodetailID=QD.PODetailID and QD.InspStatus='Pass'  and QD.InspectionStatus='Final'),0) as InspectedQty "
            'Str &= "  From PurchaseORder PO Join PurchaseOrderDetail"
            'Str &= "  POD on POD.POID=PO.POID "
            'Str &= " Join StyleMaster S on S.StyleiD=POD.StyleID "
            'Str &= " Join StyleDetail Sd on Sd.StyleDetailiD=POD.StyleDetailID"
            'Str &= " join Vender V on V.VenderlibraryID=Po.SupplierID"
            'Str &= " join Customer CC on CC.CustomerID=PO.CustomerID where  Year(PO.CreationDate) >=2012 and PO.Status !='Cancel' and"
            'Str &= "  PO.POID in (Select PO.POID from Purchaseorder PO where  PO.PONO='" & PONO & "') "
            'Str &= " group by SD.Colorway,SD.SizeRange,SD.ColorRefNo,S.StyleID,POD.PodetailID,Po.PONO,S.StyleNO, PO.POID,POD.POID,PO.CustomerID,PO.SupplierID,CC.CustomerName,V.venderName,Po.Currency,POD.Rate,SD.Sizes"
            'Str &= " select * from #tempStyles "
            'Str = "    CREATE TABLE #tempStyles"
            'Str &= " ( StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(500),"
            'Str &= " Colorway varchar(1000),SizeRange varchar(1000),Quantity varchar(50)"
            'Str &= " ,ReleaseQty varchar(50),RemainQTY varchar(50), Cartons varchar(50)"
            'Str &= " ,ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),"
            'Str &= " Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),"
            'Str &= " POPOID bigint,venderName varchar(50),Currency varchar(50),"
            'Str &= " InspectedQty varchar(500),DetailShipDate varchar(500),sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED) "
            'Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Colorway,SizeRange,Quantity,"
            'Str &= " ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID,"
            'Str &= " venderName,Currency,InspectedQty,DetailShipDate) "
            'Str &= " SELECT S.StyleID,POD.PodetailID as POID, S.StyleNo,"
            'Str &= " SD.ColorRefNo as Article,SD.Colorway,SD.Sizes as SizeRange, "
            'Str &= " cast(Sum(POD.Quantity) as decimal(10,0)) as Quantity  ,"
            'Str &= " IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PodetailID=CD.POID),0)  "
            'Str &= " as ReleaseQty, Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD "
            'Str &= " Where    POD.PodetailID=CD.POID),0) as RemainQTY,Cartons='0',POD.Rate as ShippedRate ,  "
            'Str &= " PO.PONO, PO.CustomerID,PO.SupplierID ,CustomerName,Rate='0',PO.POID as POPOID ,"
            'Str &= " V.venderName,Po.Currency ,IsNull((Select SUM(QD.InspectedQty)"
            'Str &= "  From QDInspection QD Where POD.PodetailID=QD.PODetailID and QD.InspStatus='Pass' "
            'Str &= " and QD.InspectionStatus='Final'),0) as InspectedQty ,convert(varchar,POD.DetailShipmentDate,103)as DetailShipDate From PurchaseORder PO "
            'Str &= " Join PurchaseOrderDetail  POD on POD.POID=PO.POID  "
            'Str &= " Join StyleMaster S on S.StyleiD=POD.StyleID "
            'Str &= " Join StyleDetail Sd on Sd.StyleDetailiD=POD.StyleDetailID"
            'Str &= " join Vender V on V.VenderlibraryID=Po.SupplierID "
            'Str &= " join Customer CC on CC.CustomerID=PO.CustomerID "
            'Str &= " where  Year(PO.CreationDate) >=2012 and PO.Status !='Cancel' and"
            'Str &= "  PO.POID in (Select PO.POID from Purchaseorder PO where  PO.PONO='" & PONO & "') "
            'Str &= " group by SD.Colorway,SD.SizeRange,SD.ColorRefNo,S.StyleID,POD.PodetailID,Po.PONO,S.StyleNO,"
            'Str &= " PO.POID,POD.POID,PO.CustomerID,PO.SupplierID,CC.CustomerName,"
            'Str &= " V.venderName, Po.Currency, POD.Rate, SD.Sizes, POD.DetailShipmentDate"
            'Str &= " select * from #tempStyles"

            Str = " SELECT  POD.StyleID,POD.JobOrderDetailId as POID, POD.Style"
            Str &= " ,'' as Article,POD.BuyerColor as Colorway,'' as SizeRange"
            Str &= " ,cast(Sum(POD.Quantity) as decimal(10,0)) as Quantity  "
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.JobOrderDetailId=CD.POID),0)   as ReleaseQty, "
            Str &= " Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD  Where    POD.JobOrderDetailId=CD.POID),0) "
            Str &= " as RemainQTY,Cartons='0',POD.UnitPrice as ShippedRate ,"
            Str &= " PO.SRNO, PO.CustomerDatabaseID,'0' as SupplierID ,CustomerName,'0' as Cartons,PO.JobOrderId as POPOID ,"
            Str &= " PO.Supplier,CR.CurrencyName ,'0' as InspectedQty ,convert(varchar,POD.StyleShipmentDate,103)as DetailShipDate"
            Str &= " From JobOrderdatabase PO "
            Str &= " Join JobOrderdatabaseDetail  POD on POD.JobOrderId=PO.JobOrderId   "
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerDatabaseID  "
            Str &= " join Currency CR on  CR.CurrencyID=PO.CurrencyID"
            Str &= " where Year(PO.CreationDate) >= 2012"
            Str &= " and  PO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNO='" & PONO & "')  "
            Str &= " group by POD.StyleID,POD.JoborderDetailid,POD.Style,POD.BuyerColor"
            Str &= " ,POD.UnitPrice,PO.SRNO,PO.CustomerDatabaseID,CC.CustomerName,PO.Joborderid,PO.Supplier,"
            Str &= "    CR.CurrencyName, POD.StyleShipmentDate"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNewForDigital(ByVal PONO As String)
            Dim Str As String

            
            Str = " SELECT  POD.StyleID,POD.JobOrderDetailId as POID, POD.Style"
            Str &= " ,'' as Article,POD.BuyerColor as Colorway,'' as SizeRange"
            Str &= " ,cast(Sum(POD.Quantity) as decimal(10,0)) as Quantity  "
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.JobOrderDetailId=CD.POID),0)   as ReleaseQty, "
            Str &= " Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD  Where    POD.JobOrderDetailId=CD.POID),0) "
            Str &= " as RemainQTY,Cartons='0',POD.UnitPrice as ShippedRate ,"
            Str &= " PO.SRNO, PO.CustomerDatabaseID,'0' as SupplierID ,CustomerName,'0' as Cartons,PO.JobOrderId as POPOID ,"
            Str &= " PO.Supplier,CR.CurrencyName ,'0' as InspectedQty ,convert(varchar,POD.StyleShipmentDate,103)as DetailShipDate,POD.Content ,POD.ContentforBuyer"
            Str &= " From JobOrderdatabase PO "
            Str &= " Join JobOrderdatabaseDetail  POD on POD.JobOrderId=PO.JobOrderId   "
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerDatabaseID  "
            Str &= " join Currency CR on  CR.CurrencyID=PO.CurrencyID"
            Str &= " where Year(PO.CreationDate) >= 2012"
            Str &= " and  PO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNO='" & PONO & "')  "
            Str &= " group by POD.StyleID,POD.JoborderDetailid,POD.Style,POD.BuyerColor"
            Str &= " ,POD.UnitPrice,PO.SRNO,PO.CustomerDatabaseID,CC.CustomerName,PO.Joborderid,PO.Supplier,"
            Str &= "    CR.CurrencyName, POD.StyleShipmentDate,POD.Content ,POD.ContentforBuyer"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNewForDigitalNew(ByVal PONO As String, ByVal SeasonDatabaseID As Long)
            Dim Str As String


            Str = " SELECT  SDD.SeasonDatabaseID,SDD.SeasonName,POD.StyleID,POD.JobOrderDetailId as POID, POD.Style"
            Str &= " ,'' as Article,POD.BuyerColor as Colorway"
            Str &= "  ,(select TOP 1(SRR.SizeGroup+'  ('+SRR.SizeRange+')')  from StyleAssortmentMaster SMM"
            Str &= "  join StyleAssortmentDetail SDD on SDD.StyleAssortmentMasterID =SMM.StyleAssortmentMasterID "
            Str &= "  JOIN SizeRange SRR on SRR.SizeRangeID =SDD.SizeRangeID "
            Str &= "  WHERE SMM.JoborderDetailid =POD.JoborderDetailid) as SizeRange"
            Str &= " ,cast(Sum(POD.Quantity) as decimal(10,0)) as Quantity  "
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.JobOrderDetailId=CD.POID),0)   as ReleaseQty, "
            Str &= " Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD  Where    POD.JobOrderDetailId=CD.POID),0) "
            Str &= " as RemainQTY,Cartons='0',POD.UnitPrice as ShippedRate ,"
            Str &= " PO.SRNO, PO.CustomerDatabaseID,'0' as SupplierID ,CustomerName,'0' as Cartons,PO.JobOrderId as POPOID ,"
            Str &= " PO.Supplier,CR.CurrencyName ,'0' as InspectedQty ,convert(varchar,POD.StyleShipmentDate,103)as DetailShipDate,POD.Content ,POD.ContentforBuyer"
            Str &= " From JobOrderdatabase PO "
            Str &= " Join JobOrderdatabaseDetail  POD on POD.JobOrderId=PO.JobOrderId   "
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerDatabaseID  "
            Str &= " join Currency CR on  CR.CurrencyID=PO.CurrencyID"
            Str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=PO.SeasonDatabaseID"
            Str &= " where PO.seasonDatabaseID= ' " & SeasonDatabaseID & " '  and Year(PO.CreationDate) >= 2012"
            Str &= " and  PO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNO='" & PONO & "')  "
            Str &= " group by POD.StyleID,POD.JoborderDetailid,POD.Style,POD.BuyerColor"
            Str &= " ,POD.UnitPrice,PO.SRNO,PO.CustomerDatabaseID,CC.CustomerName,PO.Joborderid,PO.Supplier,"
            Str &= "    CR.CurrencyName, POD.StyleShipmentDate,POD.Content ,POD.ContentforBuyer,SDD.SeasonDatabaseID,SDD.SeasonName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNewForDigitalNewNew(ByVal PONO As String, ByVal SeasonDatabaseID As Long)
            Dim Str As String


            Str &= "  SELECT CR.CurrencyName as Currency,"
            Str &= "  SDD.SeasonDatabaseID, SDD.SeasonName"
            Str &= " ,(select top 1 Jod.StyleID  from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= " as StyleID"
            Str &= " ,(select top 1 Jod.JoborderDetailid   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as POID"
            Str &= "  ,(select top 1 Jod.Style   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as Style"
            Str &= "  , isnull((select top 1 SIR.sizeRange from styleassortmentmaster sm join styleassortmentdetail sd on "
            Str &= "   sd.styleassortmentmasterid = sm.styleassortmentmasterid"
            Str &= " and sm.joborderid=JO.joborderid "
            Str &= " join sizerange SIR on SIR.sizerangeid=sd.sizerangeid"
            Str &= "   where sm.joborderid=jo.joborderid),'')as SizeRange"
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD "
            Str &= " Where JO.joborderid=CD.POPOID),0)   as ReleaseQuantity"
            Str &= "  ,Cartons='0'"
            Str &= " , JO.SRNO AS PONO, JO.CustomerDatabaseID as CustomerID,'0' as VendorID ,CustomerName,'0' as Cartons,JO.JobOrderId "
            Str &= " as POPOID , JO.Supplier,CR.CurrencyName ,'0' as InspectedQty "
            Str &= " ,(select top 1 JOD.UnitPrice from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as ShippedRate "
            Str &= " ,convert(varchar,(select top 1 JOD.StyleShipmentDate from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid),103)as DetailShipDate"
            Str &= "  ,(select top 1 JOD.Content from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Constr "
            Str &= " ,(select top 1 JOD.ContentforBuyer from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Composition "
            Str &= "  ,ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= " =JO.Joborderid),0)+"
            Str &= "  isnull((select sum(SAM.ExtraQty) from StyleAssortmentMaster SAM "
            Str &= "  where SAM.joborderId=jo.joborderId),0) as Quantity"
            Str &= "   , ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= "  =JO.Joborderid),0)-IsNull((Select SUM(Quantity) From CargoDetail CD  "
            Str &= "  Where    JO.JobOrderId=CD.POPOID),0)  as ShippedQty"
            Str &= "  ,(select top 1 jod.Model + ' '+ jod.Style   from JobOrderdatabaseDetail jod where JOD.Joborderid =JO.Joborderid) as StyleArticle"

            Str &= "  ,(select top 1 IMM.ItemComposition from JobOrderdatabaseDetail JOOD join IMSItem IMM on IMM.IMSItemID =JOOD.IMSItemID "
            Str &= "     where(JOOD.Joborderid = JO.Joborderid)"
            Str &= "   ) AS Compositionnn"

            Str &= " FROM JobOrderdatabase JO"
            Str &= " join Customer CC on CC.CustomerID=JO.CustomerDatabaseID   "
            Str &= " join Currency CR on  CR.CurrencyID=JO.CurrencyID "
            Str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=JO.SeasonDatabaseID "
            Str &= " where JO.seasonDatabaseID= ' " & SeasonDatabaseID & " '  and Year(JO.CreationDate) >= 2012"
            Str &= " and  JO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNOPOne='" & PONO & "')  "
           
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNewForDigitalNewNewOnly(ByVal PONO As String, ByVal SeasonDatabaseID As Long)
            Dim Str As String


            Str &= "  SELECT CR.CurrencyName as Currency,"
            Str &= "  SDD.SeasonDatabaseID, SDD.SeasonName"
            Str &= " ,(select top 1 Jod.StyleID  from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= " as StyleID"
            Str &= " ,(select top 1 Jod.JoborderDetailid   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as POID"
            Str &= "  ,(select top 1 Jod.Style   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as Style"
            Str &= "  , isnull((select top 1 SIR.sizeRange from styleassortmentmaster sm join styleassortmentdetail sd on "
            Str &= "   sd.styleassortmentmasterid = sm.styleassortmentmasterid"
            Str &= " and sm.joborderid=JO.joborderid "
            Str &= " join sizerange SIR on SIR.sizerangeid=sd.sizerangeid"
            Str &= "   where sm.joborderid=jo.joborderid),'')as SizeRange"
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD "
            Str &= " Where JO.joborderid=CD.POPOID),0)   as ReleaseQuantity"
            Str &= "  ,Cartons='0'"
            Str &= " , JO.SRNO AS PONO, JO.CustomerDatabaseID as CustomerID,'0' as VendorID ,CustomerName,'0' as Cartons,JO.JobOrderId "
            Str &= " as POPOID , JO.Supplier,CR.CurrencyName ,'0' as InspectedQty "
            Str &= " ,(select top 1 JOD.UnitPrice from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as ShippedRate "
            Str &= " ,convert(varchar,(select top 1 JOD.StyleShipmentDate from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid),103)as DetailShipDate"
            Str &= "  ,(select top 1 JOD.Content from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Constr "
            Str &= " ,(select top 1 JOD.ContentforBuyer from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Composition "
            Str &= "  ,ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= " =JO.Joborderid),0)+"
            Str &= "  isnull((select sum(SAM.ExtraQty) from StyleAssortmentMaster SAM "
            Str &= "  where SAM.joborderId=jo.joborderId),0) as Quantity"
            Str &= "   , ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= "  =JO.Joborderid),0)-IsNull((Select SUM(Quantity) From CargoDetail CD  "
            Str &= "  Where    JO.JobOrderId=CD.POPOID),0)  as ShippedQty"
            Str &= "  ,(select top 1 jod.Model + ' '+ jod.Style   from JobOrderdatabaseDetail jod where JOD.Joborderid =JO.Joborderid) as StyleArticle"

            Str &= "  ,(select top 1 IMM.ItemComposition from JobOrderdatabaseDetail JOOD join IMSItem IMM on IMM.IMSItemID =JOOD.IMSItemID "
            Str &= "     where(JOOD.Joborderid = JO.Joborderid)"
            Str &= "   ) AS Compositionnn"

            Str &= " FROM JobOrderdatabase JO"
            Str &= " join Customer CC on CC.CustomerID=JO.CustomerDatabaseID   "
            Str &= " join Currency CR on  CR.CurrencyID=JO.CurrencyID "
            Str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=JO.SeasonDatabaseID "
            Str &= " where JO.seasonDatabaseID= ' " & SeasonDatabaseID & " '  and Year(JO.CreationDate) >= 2012"
            Str &= " and  JO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNO='" & PONO & "')  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPackingQuantites(ByVal Joborderid As Long)
            Dim Str As String

            Str &= " select SUM(DISTINCT DTL.Qty) AS Qty,"
            Str &= " sum(DISTINCT dtl.NoOfCarton)  as NoOfCarton,"
            Str &= " sum(DISTINCT dtl.Weight)  as Weight"
            Str &= " from Packingmst mst"
            Str &= " join Packingdtl dtl on dtl.PackingMstID =mst.PackingMstID "
            Str &= " join NumberingFinal N on N.NumberingFinalID =DTL.NumberingFinalID "
            Str &= " JOIN NumberingFinalDtl ND ON ND.NumberingFinalID =N.NumberingFinalID"
            Str &= " where ND.Joborderid= ' " & Joborderid & " '"



            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPackingNew(ByVal PackingMstID As Long)
            Dim Str As String

            'Str &= "  select Mst.PackingMstID ,'0' AS CargoDetailid,'0' as JoborderDetailid,jo.SRNO,C.CustomerName"
            'Str &= ",(Select top 1 JOD.Model from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid) as Model"
            'Str &= ",(Select top 1 JOD.UnitPrice from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid) as UnitPrice"
            'Str &= ",(Select SUM(Jod.Quantity) from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid) as Quantity"
            'Str &= ", IsNull((Select SUM(Quantity) From CargoDetail CD  Where JO.joborderid=CD.POPOID),0)   as ShippedQuantity"
            'Str &= ",C.CustomerID  ,C.CustomerName ,JO.joborderid"
            'Str &= " from Packingmst Mst "
            'Str &= " join PackingDtl Dtl on dtl.PackingMstID =mst.PackingMstID "
            'Str &= " join NumberingFinal N on N.NumberingFinalID =DTL.NumberingFinalID  "
            'Str &= " JOIN NumberingFinalDtl ND on ND.NumberingFinalID =N.NumberingFinalID "
            'Str &= " JOIN JobOrderdatabase JO on JO.Joborderid =ND.Joborderid  "
            'Str &= " join Customer C on C.CustomerID =JO.CustomerDatabaseID  "
            'Str &= " where MST.PackingMstID= ' " & PackingMstID & " '"
            'Str &= "  GROUP BY Mst.PackingMstID ,jo.Joborderid  ,jo.SRNO,C.CustomerName"
            'Str &= " ,C.CustomerID  ,C.CustomerName"

            Str &= "  select Mst.PackingMstID ,'0' AS CargoDetailid,"
            Str &= " '0' as JoborderDetailid,jo.SRNO,C.CustomerName"
            Str &= " ,(Select top 1 JOD.Model from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid) as Model"
            Str &= " ,(Select top 1 JOD.UnitPrice from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid) as UnitPrice"
            Str &= " ,(Select SUM(Jod.Quantity) from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid) as Quantity"
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD  Where JO.joborderid=CD.POPOID),0)   as ShippedQuantity"
            Str &= " ,C.CustomerID  ,C.CustomerName ,JO.joborderid "
            Str &= " ,sum(dtl.Qty) as  Qty,SUM(dtl.Weight) as Weight,count(dtl.PackingDtlID) as NoOfCarton"
            Str &= " from Packingmst Mst  "
            Str &= " join PackingDtl Dtl on dtl.PackingMstID =mst.PackingMstID  "
            Str &= " JOIN JobOrderdatabase JO on JO.Joborderid =Dtl.Joborderid   "
            Str &= " join Customer C on C.CustomerID =JO.CustomerDatabaseID   "
            Str &= " where MST.PackingMstID= '" & PackingMstID & "' "
            Str &= " GROUP BY Mst.PackingMstID ,jo.Joborderid  ,jo.SRNO,C.CustomerName ,C.CustomerID  ,C.CustomerName"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForPacking(ByVal PackingMstID As Long)
            Dim Str As String
            Str &= "  select '0' AS CargoDetailid,JOD.Model,jo.SRNO,C.CustomerName,JOD.Quantity "
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD "
            Str &= " Where JO.joborderid=CD.POPOID AND JOD.JoborderDetailid =CD.POID),0)   as ShippedQuantity,JOD.UnitPrice"
            Str &= " ,Dtl.Qty ,DTL.NoOfCarton ,DTL.Weight,C.CustomerID  ,C.CustomerName,JOD.JoborderDetailid ,JO.joborderid"
            Str &= " from Packingmst Mst"
            Str &= " join PackingDtl Dtl on dtl.PackingMstID =mst.PackingMstID"
            Str &= " join NumberingFinal N on N.NumberingFinalID =DTL.NumberingFinalID "
            Str &= " JOIN NumberingFinalDtl ND on ND.NumberingFinalID =N.NumberingFinalID"
            Str &= " JOIN JobOrderdatabase JO on JO.Joborderid =ND.Joborderid "
            Str &= " JOIN JobOrderdatabaseDetail JOD on JOD.JoborderDetailid =ND.JoborderDetailid "
            Str &= " join Customer C on C.CustomerID =JO.CustomerDatabaseID "
            Str &= " where MST.PackingMstID= ' " & PackingMstID & " '"
            Str &= " GROUP BY JOD .JoborderDetailid,JOD.Model ,jo.SRNO,C.CustomerName,JOD.Quantity,JO.joborderid,JOD.UnitPrice "
            Str &= " ,Dtl.Qty ,DTL.NoOfCarton ,DTL.Weight ,C.CustomerID  ,C.CustomerName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNewForDigitalNewNewNEWFOYASIR(ByVal PONO As String, ByVal SeasonDatabaseID As Long)
            Dim Str As String
            Str &= "  SELECT CR.CurrencyName as Currency,"
            Str &= "  SDD.SeasonDatabaseID, SDD.SeasonName"
            Str &= " ,(select top 1 Jod.StyleID  from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= " as StyleID"
            Str &= " ,(select top 1 Jod.JoborderDetailid   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as POID"
            Str &= "  ,(select top 1 Jod.Style   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as Style"
            Str &= "  , isnull((select top 1 SIR.sizeRange from styleassortmentmaster sm join styleassortmentdetail sd on "
            Str &= "   sd.styleassortmentmasterid = sm.styleassortmentmasterid"
            Str &= " and sm.joborderid=JO.joborderid "
            Str &= " join sizerange SIR on SIR.sizerangeid=sd.sizerangeid"
            Str &= "   where sm.joborderid=jo.joborderid),'')as SizeRange"
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD "
            Str &= " Where JO.joborderid=CD.POPOID),0)   as ReleaseQuantity"
            Str &= "  ,Cartons='0'"
            Str &= " , JO.SRNO AS PONO, JO.CustomerDatabaseID as CustomerID,'0' as VendorID ,CustomerName,'0' as Cartons,JO.JobOrderId "
            Str &= " as POPOID , JO.Supplier,CR.CurrencyName ,'0' as InspectedQty "
            Str &= " ,(select top 1 JOD.UnitPrice from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as ShippedRate "
            Str &= " ,convert(varchar,(select top 1 JOD.StyleShipmentDate from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid),103)as DetailShipDate"
            Str &= "  ,(select top 1 JOD.Content from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Constr "
            Str &= " ,(select top 1 JOD.ContentforBuyer from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Composition "
            Str &= "  ,ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= " =JO.Joborderid),0)+"
            Str &= "  isnull((select sum(SAM.ExtraQty) from StyleAssortmentMaster SAM "
            Str &= "  where SAM.joborderId=jo.joborderId),0) as Quantity"
            Str &= "   , ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= "  =JO.Joborderid),0)-IsNull((Select SUM(Quantity) From CargoDetail CD  "
            Str &= "  Where    JO.JobOrderId=CD.POPOID),0)  as ShippedQty"
            Str &= "  ,(select top 1 jod.Model + ' '+ jod.Style   from JobOrderdatabaseDetail jod where JOD.Joborderid =JO.Joborderid) as StyleArticle"

            Str &= "  ,(select top 1 IMM.ItemComposition from JobOrderdatabaseDetail JOOD join IMSItem IMM on IMM.IMSItemID =JOOD.IMSItemID "
            Str &= "     where(JOOD.Joborderid = JO.Joborderid)"
            Str &= "   ) AS Compositionnn"

            Str &= " FROM JobOrderdatabase JO"
            Str &= " join Customer CC on CC.CustomerID=JO.CustomerDatabaseID   "
            Str &= " join Currency CR on  CR.CurrencyID=JO.CurrencyID "
            Str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=JO.SeasonDatabaseID "
            Str &= " where JO.seasonDatabaseID= ' " & SeasonDatabaseID & " '  and Year(JO.CreationDate) >= 2012"
            Str &= " and  JO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNO='" & PONO & "')  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailNewSearchPONoNewForDigitalNewNewNew(ByVal PONO As String, ByVal SeasonDatabaseID As Long)
            Dim Str As String


            Str &= "  SELECT '0' as CargoDetailid,CR.CurrencyName as Currency,"
            Str &= "  SDD.SeasonDatabaseID, SDD.SeasonName"
            Str &= " ,(select top 1 Jod.StyleID  from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= " as StyleID"
            Str &= " ,(select top 1 Jod.JoborderDetailid   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as POID"
            Str &= "  ,(select top 1 Jod.Style   from JobOrderdatabaseDetail Jod where jod.Joborderid =jo.Joborderid)"
            Str &= "  as Style"
            Str &= "  , isnull((select top 1 SIR.sizeRange from styleassortmentmaster sm join styleassortmentdetail sd on "
            Str &= "   sd.styleassortmentmasterid = sm.styleassortmentmasterid"
            Str &= " and sm.joborderid=JO.joborderid "
            Str &= " join sizerange SIR on SIR.sizerangeid=sd.sizerangeid"
            Str &= "   where sm.joborderid=jo.joborderid),'')as SizeRange"
            Str &= " , IsNull((Select SUM(Quantity) From CargoDetail CD "
            Str &= " Where JO.joborderid=CD.POPOID),0)   as ReleaseQuantity"
            Str &= "  ,Cartons='0'"
            Str &= " , JO.SRNO AS PONO, JO.CustomerDatabaseID as CustomerID,'0' as VendorID ,CustomerName,'0' as Cartons,JO.JobOrderId "
            Str &= " as POPOID , JO.Supplier,CR.CurrencyName ,'0' as InspectedQty "
            Str &= " ,(select top 1 JOD.UnitPrice from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as ShippedRate "
            Str &= " ,convert(varchar,(select top 1 JOD.StyleShipmentDate from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid),103)as DetailShipDate"
            Str &= "  ,(select top 1 JOD.Content from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Constr "
            Str &= " ,(select top 1 JOD.ContentforBuyer from JobOrderdatabaseDetail JOD where JOD.Joborderid =JO.Joborderid)as Composition "


            Str &= "  ,ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail "
            Str &= " jod where jod.Joborderid  =JO.Joborderid),0) as Quantity"
            Str &= " ,  isnull((select top 1 (SAM.ExtraQty) "
            Str &= " from StyleAssortmentMaster SAM   where SAM.joborderId=jo.joborderId),0) as AssortQty   "
            Str &= "   , ISNULL((select SUM(jod.Quantity) from JobOrderdatabaseDetail jod where jod.Joborderid "
            Str &= "  =JO.Joborderid),0)-IsNull((Select SUM(Quantity) From CargoDetail CD  "
            Str &= "  Where    JO.JobOrderId=CD.POPOID),0)  as ShippedQty"
            Str &= "  ,(select top 1 jod.Model + ' '+ jod.Style   from JobOrderdatabaseDetail jod where JOD.Joborderid =JO.Joborderid) as StyleArticle"

            Str &= "  ,(select top 1 IMM.ItemComposition from JobOrderdatabaseDetail JOOD join IMSItem IMM on IMM.IMSItemID =JOOD.IMSItemID "
            Str &= "     where(JOOD.Joborderid = JO.Joborderid)"
            Str &= "   ) AS Compositionnn"

            Str &= " FROM JobOrderdatabase JO"
            Str &= " join Customer CC on CC.CustomerID=JO.CustomerDatabaseID   "
            Str &= " join Currency CR on  CR.CurrencyID=JO.CurrencyID "
            Str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=JO.SeasonDatabaseID "
            Str &= " where JO.seasonDatabaseID= ' " & SeasonDatabaseID & " '  and Year(JO.CreationDate) >= 2012"
            Str &= " and  JO.JobOrderId in (Select PO.JobOrderId from JobOrderdatabase PO where  PO.SRNO='" & PONO & "')  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommodity(ByVal Commodity As String)
            Dim Str As String


            Str = " SELECT  * FROM Commodity"
            Str &= " where Commodity= '" & Commodity & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoDetailByStyleNo(ByVal Style As String)
            Dim Str As String
            Str = "  CREATE TABLE #tempStyles("
            Str &= " StyleID bigint,POID bigint,StyleNo varchar(4000),Article varchar(500),Colorway varchar(1000),SizeRange varchar(1000),Quantity varchar(50),ReleaseQty varchar(50),RemainQTY varchar(50),"
            Str &= " Cartons varchar(50),ShippedRate varchar(50),PONO varchar(50),CustomerID varchar(50),Vendorid varchar(50),CustomerName varchar(50),Rate varchar(50),POPOID bigint,venderName varchar(50),Currency varchar(50),sid bigint IDENTITY(1,1)PRIMARY KEY CLUSTERED)"
            Str &= " INSERT INTO #tempStyles (StyleID,POID,StyleNo,Article,Colorway,SizeRange,Quantity,ReleaseQty,RemainQTY,Cartons,ShippedRate,PONO,CustomerID,Vendorid,CustomerName,Rate,POPOID,venderName,Currency)"
            Str &= " SELECT S.StyleID,POD.PodetailID as POID, S.StyleNo,SD.Article,SD.Colorway,SD.SizeRange, Sum(POD.Quantity) as Quantity"
            Str &= " ,IsNull((Select SUM(Quantity) From CargoDetail CD Where POD.PodetailID=CD.POID),0)"
            Str &= "   as ReleaseQty, Sum(POD.Quantity)-IsNull((Select SUM(Quantity) From CargoDetail CD Where "
            Str &= "   POD.PodetailID=CD.POID),0) as RemainQTY,Cartons='',POD.Rate as ShippedRate ,"
            Str &= "  PO.PONO, PO.CustomerID,PO.SupplierID ,CustomerName,Rate='0',PO.POID as POPOID ,V.venderName,Po.Currency"
            Str &= " From PurchaseORder PO Join PurchaseOrderDetail"
            Str &= "  POD on POD.POID=PO.POID "
            'new
            ' Str &= " Join Style S on S.StyleiD=POD.StyleID"
            Str &= " Join StyleMaster S on S.StyleiD=POD.StyleID"
            Str &= "   Join StyleDetail Sd on Sd.StyleDetailiD=POD.StyleDetailID"
            'end
            Str &= " join Vender V on V.VenderlibraryID=Po.SupplierID"
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerID where  Year(PO.CreationDate) >=2012 and S.StyleNo= '" & Style & "'"
            Str &= " group by SD.Colorway,SD.SizeRange,SD.Article,Po.PONO,S.StyleNO, PO.POID,POD.POID,PO.CustomerID,PO.SupplierID,CC.CustomerName,V.venderName,Po.Currency ,POD.PodetailID,S.StyleID,POD.Rate"
            Str &= " select * from #tempStyles "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function DeleteCargoDetailbyID(ByVal lCargoId As String)
            Dim Str As String
            Str = " Delete from CargoDetail where CargoID='" & lCargoId & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Getalldata(ByVal lCargoId As String)
            Dim Str As String
            Str = " Select distinct currency from Purchaseorder where poid in "
            Str &= " (select POPOID from Cargodetail where Cargoid= '" & lCargoId & "')"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataforLogisticStatus()
            Dim Str As String
            Str = " SELECT  Po.POID,PO.PONO,v.vendername, CC.customername,Po.ShipmentDate,PO.Placementdate"
            Str &= " ,POD.PODetailID,SD.article,SD.sizerange,Sd.colorway,S.StyleNO,S.styleName"
            Str &= " , cast(Sum(POD.Quantity) as decimal(10,0)) as OrderQuantity ,"
            Str &= " IsNull((Select SUM(Quantity) From CargoDetail CD Where  POD.PodetailID=CD.POID),0)   as ReleaseQty"
            Str &= "  From PurchaseORder PO"
            Str &= " Join PurchaseOrderDetail  POD  on POD.POID=PO.POID  "
            Str &= " Join StyleMaster S on S.StyleiD=POD.StyleID "
            Str &= "  Join StyleDetail Sd on Sd.StyleDetailiD=POD.StyleDetailID"
            Str &= " join Vender V on V.VenderlibraryID=Po.SupplierID"
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerID "
            Str &= " where   PO.POID in (select distinct POPOID from cargodetail"
            Str &= " CD join cargo c on c.cargoID=cd.cargoid "
            Str &= " where year(c.creationdate) >=2012 )"
            'After Demo Enable this Line
            ' Str &= " --and year(PO.shipmentdate)>=2013"
            Str &= " group by Po.POID,PO.PONO,v.vendername, CC.customername,Po.ShipmentDate,PO.Placementdate"
            Str &= " ,POD.PODetailID,SD.article,SD.sizerange,Sd.colorway,S.StyleNO,S.styleName"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataforLogisticStatusNew(ByVal IPODetailID As String)
            Dim Str As String
            Str = " SELECT  Po.POID,PO.PONO,v.vendername, CC.customername,Po.ShipmentDate,PO.Placementdate"
            Str &= " ,POD.PODetailID,SD.article,SD.sizerange,Sd.colorway,S.StyleNO,S.styleName"
            Str &= " , cast(Sum(POD.Quantity) as decimal(10,0)) as OrderQuantity ,"
            Str &= " IsNull((Select SUM(Quantity) From CargoDetail CD Where  POD.PodetailID=CD.POID),0)   as ReleaseQty"
            Str &= "  From PurchaseORder PO"
            Str &= " Join PurchaseOrderDetail  POD  on POD.POID=PO.POID  "
            Str &= " Join StyleMaster S on S.StyleiD=POD.StyleID "
            Str &= "  Join StyleDetail Sd on Sd.StyleDetailiD=POD.StyleDetailID"
            Str &= " join Vender V on V.VenderlibraryID=Po.SupplierID"
            Str &= " join Customer CC on CC.CustomerID=PO.CustomerID "
            Str &= " where POD.PODetailID in " & IPODetailID & ""
            Str &= " group by Po.POID,PO.PONO,v.vendername, CC.customername,Po.ShipmentDate,PO.Placementdate"
            Str &= " ,POD.PODetailID,SD.article,SD.sizerange,Sd.colorway,S.StyleNO,S.styleName"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace