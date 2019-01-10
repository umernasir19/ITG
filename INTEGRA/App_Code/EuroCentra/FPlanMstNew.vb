Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
Public Class FPlanMstNew

  Inherits SQLManager
        Public Sub New()
            m_strTableName = "FPlanMstNew"
            m_strPrimaryFieldName = "FPlanMstNewID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFPlanMstNewID As Long
        Private m_lJobOrderId As Long
        Private m_strJobOrderNo As String
        Private m_strStyle As String

        Private m_strItem As String

        Private m_DCTotalFabric As Decimal
        Private m_DCTGross As Decimal
        Private m_DCTotalAmount As Decimal
        Private m_DCUSDAmount As Decimal
        Private m_lInquiryId As Long
        Private m_dtCreationDate As Date
        Private m_DCQuantity As Decimal
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal Value As String)
                m_strStyle = Value
            End Set
        End Property
        Public Property Item() As String
            Get
                Item = m_strItem
            End Get
            Set(ByVal Value As String)
                m_strItem = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_DCQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_DCQuantity = Value
            End Set
        End Property

        Public Property FPlanMstNewID() As Long
            Get
                FPlanMstNewID = m_lFPlanMstNewID
            End Get
            Set(ByVal Value As Long)
                m_lFPlanMstNewID = Value
            End Set
        End Property
        Public Property JobOrderId() As Long
            Get
                JobOrderId = m_lJobOrderId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderId = Value
            End Set
        End Property

        Public Property JobOrderNo() As String
            Get
                JobOrderNo = m_strJobOrderNo
            End Get
            Set(ByVal Value As String)
                m_strJobOrderNo = Value
            End Set
        End Property


        Public Property TotalFabric() As Decimal
            Get
                TotalFabric = m_DCTotalFabric
            End Get
            Set(ByVal Value As Decimal)
                m_DCTotalFabric = Value
            End Set
        End Property
        Public Property TGross() As Decimal
            Get
                TGross = m_DCTGross
            End Get
            Set(ByVal Value As Decimal)
                m_DCTGross = Value
            End Set
        End Property
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = m_DCTotalAmount
            End Get
            Set(ByVal Value As Decimal)
                m_DCTotalAmount = Value
            End Set
        End Property
        Public Property USDAmount() As Decimal
            Get
                USDAmount = m_DCUSDAmount
            End Get
            Set(ByVal Value As Decimal)
                m_DCUSDAmount = Value
            End Set
        End Property
        Public Property InquiryId() As Long
            Get
                InquiryId = m_lInquiryId
            End Get
            Set(ByVal Value As Long)
                m_lInquiryId = Value
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

        Public Function SaveFPlanMst()
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
        Public Function GetJobOrderData(ByVal Joborderid As Long) As DataTable
            Dim str As String
            'str = "  Select * ,(select distinct Content from StyleMasterDatabase  SM where  SM.JoborderID=JO.JoborderID) as Content"
            'str &= " ,(select Top 1 ItemDiscription from StyleMasterDatabase  SM where  SM.JoborderID=JO.JoborderID order by SM.StyleMasterDatabaseID desc) as Item"
            'str &= " ,(select isnull(Sum(Qty),0) from StyleMasterDatabase  SM "
            'str &= " join Style_SubStyle SS on SS.StyleMasterDatabaseID=SM.StyleMasterDatabaseID"
            'str &= " where  SM.JoborderID=JO.JoborderID) as Qty"
            'str &= " from JobOrder JO"
            'str &= " left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID"
            'str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID"
            'str &= " left join CustomerDatabase CD ON JO.CustomerDatabaseID=CD.CustomerDatabaseID"
            'str &= " where JO.JoborderID='" & Joborderid & "' "

            str = "  select *  , convert(varchar,jo.OrderRecvDate ,103) as ReceivedDate ,(select isnull(Sum(QUANTITY),0) from JobOrderdatabase  SM  "
            str &= " join JobOrderdatabaseDetail SS on SS.JoborderID=SM.JoborderID"
            str &= " where  SM.JoborderID=JO.JoborderID) as Qty from JobOrderdatabase JO JOIN JobOrderdatabaseDetail JD  ON JO.JoborderID=JD.JoborderID"
            str &= " left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID "
            str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID "
            str &= " left join Customer CD ON CD.Customerid=JO.CustomerDatabaseID  "
            str &= " left JOIN DPITEMDATABASE ITD ON ITD.DPItemDatabaseId=JD.ItemDatabaseId where JO.JoborderID='" & Joborderid & "' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetINQUIRYData(ByVal INQGarmentConsumptioniD As Long) As DataTable
            Dim str As String

            str = "    select *  , convert(varchar,IQ.TobeShipAGREEDDATE ,103) as SHIPDatee   from INQGarmentConsumption IQ"
            str &= "   left join CustomerDatabase CD ON CD.CustomerDatabaseID=IQ.CustomerID"
            str &= "   left JOIN ITEMDATABASE ITD ON ITD.ItemDatabaseId=iq.ItemDatabaseId"
            str &= "        WHERE INQGarmentConsumptioniD = '" & INQGarmentConsumptioniD & "'"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFPLANdetail(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            'str = " select ims.Suppliername as IMSSupplierName,FD.Item,FD.Style,* from FabricCostMst FM JOIN FabricCostDtl FD "
            'str &= " ON FM.FabricCostMstID=FD.FabricCostMstID "
            'str &= " join SupplierDatabase ims  on ims.SupplierDatabaseid=FD.IMSSupplierid"
            'str &= " join FabricDatabase fdb on fdb.Fabricdatabaseid=FD.Fabricdatabaseid "
            ' str &= "   WHERE JobOrderId='" & JobOrderIdID & "' "


            ''str = "  select ims.Suppliername as IMSSupplierName,FD.Item,FD.Style,fdb.ItemName as FabricWeave,* from FabricCostMst FM "
            ''str &= " JOIN FabricCostDtl FD  ON FM.FabricCostMstID=FD.FabricCostMstID  "
            ''str &= " join SupplierDatabase ims  on ims.SupplierDatabaseid=FD.IMSSupplierid "
            ''str &= " join IMSItem fdb on fdb.IMSItemid=FD.Fabricdatabaseid  WHERE JobOrderId='" & JobOrderIdID & "'"
            str = "  select '' AS Construction,CMP.CompositionName as Composition,DFB.FabricWidth as Width,ims.Suppliername as IMSSupplierName,FD.Item,FD.Style,fdb.ItemName as FabricWeave,* from FPlanMstNew FM "
            str &= " JOIN FPlanDtlNew FD  ON FM.FPlanMstNewID=FD.FPlanMstNewID  "
            str &= " join SupplierDatabase ims  on ims.SupplierDatabaseid=FD.IMSSupplierid "
            str &= " join IMSItem fdb on fdb.IMSItemid=FD.Fabricdatabaseid"
            str &= " join DPFabricDbMst DFB ON DFB.FabricDbMstID=fdb.FabricDbMstID"
            str &= " join Composition CMP ON CMP.Compositionid=DFB.Compositionid"
            str &= "    WHERE JobOrderId = '" & JobOrderIdID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFPLANdetailNew(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            'str = " select ims.Suppliername as IMSSupplierName,FD.Item,FD.Style,* from FabricCostMst FM JOIN FabricCostDtl FD "
            'str &= " ON FM.FabricCostMstID=FD.FabricCostMstID "
            'str &= " join SupplierDatabase ims  on ims.SupplierDatabaseid=FD.IMSSupplierid"
            'str &= " join FabricDatabase fdb on fdb.Fabricdatabaseid=FD.Fabricdatabaseid "
            ' str &= "   WHERE JobOrderId='" & JobOrderIdID & "' "


            ''str = "  select ims.Suppliername as IMSSupplierName,FD.Item,FD.Style,fdb.ItemName as FabricWeave,* from FabricCostMst FM "
            ''str &= " JOIN FabricCostDtl FD  ON FM.FabricCostMstID=FD.FabricCostMstID  "
            ''str &= " join SupplierDatabase ims  on ims.SupplierDatabaseid=FD.IMSSupplierid "
            ''str &= " join IMSItem fdb on fdb.IMSItemid=FD.Fabricdatabaseid  WHERE JobOrderId='" & JobOrderIdID & "'"
            str = "  select '' AS Construction,fdb.ItemComposition as Composition,FD.FabricWidth as Width,ims.Suppliername as IMSSupplierName,FD.Item,FD.Style,fdb.ItemName as FabricWeave,* from FPlanMstNew FM "
            str &= " JOIN FPlanDtlNew FD  ON FM.FPlanMstNewID=FD.FPlanMstNewID  "
            str &= " join SupplierDatabase ims  on ims.SupplierDatabaseid=FD.IMSSupplierid "
            str &= " join IMSItem fdb on fdb.IMSItemid=FD.Fabricdatabaseid"
           str &= "    WHERE JobOrderId = '" & JobOrderIdID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFPLANdetailInquiry(ByVal Inquiryid As Long) As DataTable
            Dim str As String
            str = " select * from FabricCostMst FM JOIN FabricCostDtl FD "
            str &= " ON FM.FabricCostMstID=FD.FabricCostMstID "
            str &= " join IMSSupplier ims  on ims.IMSSupplierid=FD.IMSSupplierid"
            str &= " join FabricDatabase fdb on fdb.Fabricdatabaseid=FD.Fabricdatabaseid "
            str &= "   WHERE Inquiryid='" & Inquiryid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricCode() As DataTable
            Dim str As String
            str = " Select *,FabricWeave + '(' + Color + ')' as Fabric  from FabricDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricnEW() As DataTable
            Dim str As String
            str = " select * frOm IMSItem where IMSItemClassid=6"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPlacement(ByVal DPRNDID As Long) As DataTable
            Dim str As String
            str = " select DPRNDStyleDetailid,Description"
            str &= " from TblDPRND TD JOIN  DPRNDStyleDetail DS ON DS.DPRNDID=TD.DPRNDID"
            str &= " where TD.DPRNDID='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFSupplier() As DataTable
            Dim str As String
            ' str = " select * from IMSSupplier where IMSSupplierCategoryId=5"


            str = " select * from SupplierDatabase "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrency() As DataTable
            Dim str As String
            ' str = " select * from IMSSupplier where IMSSupplierCategoryId=5"


            str = " select * from Currency "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricItemId(ByVal ItemName As String) As DataTable
            Dim str As String
            str = "select * frOm IMSItem where IMSItemClassid=6  and  ItemName='" & ItemName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricData(ByVal FabricDatabaseID As Long) As DataTable
            Dim str As String
            str = " Select * from FabricDatabase Fb Join IMSItem Ims on Ims.IMSItemId=Fb.IMSItemId where FabricDatabaseID='" & FabricDatabaseID & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricDataNew(ByVal IMSItemId As Long) As DataTable
            Dim str As String
            str = " Select * from DPFabricDbMst Fb join Composition CMP ON CMP.Compositionid=Fb.Compositionid Join IMSItem Ims on Ims.FabricDbMstid=Fb.FabricDbMstid  where IMSItemId='" & IMSItemId & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricDataNew2(ByVal IMSItemId As Long) As DataTable
            Dim str As String
            str = " Select * from IMSItem where IMSItemId='" & IMSItemId & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUnit() As DataTable
            Dim str As String
            str = " Select * from  IMSItemUnit "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorWiseData(ByVal JobOrderDetailId As Long)
            Dim str As String
            str = "   select *  , convert(varchar,jo.OrderRecvDate ,103) as ReceivedDate ,(select isnull(Sum(QUANTITY),0) from JobOrderdatabase  SM  "
            str &= " join JobOrderdatabaseDetail SS on SS.JoborderID=SM.JoborderID where  SM.JoborderID=JO.JoborderID) as Qty from JobOrderdatabase JO"
            str &= " JOIN JobOrderdatabaseDetail JD  ON JO.JoborderID=JD.JoborderID left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID"
            str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID  left join Customer CD ON CD.Customerid=JO.CustomerDatabaseID  "
            str &= " left JOIN DPITEMDATABASE ITD ON ITD.DPItemDatabaseId=JD.ItemDatabaseId  where JD.JoborderDetailID = '" & JobOrderDetailId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


