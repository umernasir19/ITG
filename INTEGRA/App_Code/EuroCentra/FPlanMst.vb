Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FPlanMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FPlanMst"
            m_strPrimaryFieldName = "FPlanMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFPlanMstID As Long
        Private m_lJobOrderId As Long
        Private m_strJobOrderNo As String
        Private m_dtRecvDate As Date
        Private m_dtShipDate As Date
        Private m_strSeason As String
        Private m_strBuyer As String
        Private m_strBrand As String
        Private m_strItem As String
        Private m_strContent As String
        Private m_DCQuantity As Decimal
        Private m_DCTotalFabric As Decimal
        Private m_DCCons As Decimal
        Private m_DCPercent As Decimal

        Public Property FPlanMstID() As Long
            Get
                FPlanMstID = m_lFPlanMstID
            End Get
            Set(ByVal Value As Long)
                m_lFPlanMstID = Value
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
        Public Property RecvDate() As Date
            Get
                RecvDate = m_dtRecvDate
            End Get
            Set(ByVal Value As Date)
                m_dtRecvDate = Value
            End Set
        End Property
        Public Property ShipDate() As Date
            Get
                ShipDate = m_dtShipDate
            End Get
            Set(ByVal Value As Date)
                m_dtShipDate = Value
            End Set
        End Property

        Public Property Season() As String
            Get
                Season = m_strSeason
            End Get
            Set(ByVal Value As String)
                m_strSeason = Value
            End Set
        End Property
        Public Property Buyer() As String
            Get
                Buyer = m_strBuyer
            End Get
            Set(ByVal Value As String)
                m_strBuyer = Value
            End Set
        End Property
        Public Property Brand() As String
            Get
                Brand = m_strBrand
            End Get
            Set(ByVal Value As String)
                m_strBrand = Value
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
        Public Property Content() As String
            Get
                Content = m_strContent
            End Get
            Set(ByVal Value As String)
                m_strContent = Value
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
        Public Property TotalFabric() As Decimal
            Get
                TotalFabric = m_DCTotalFabric
            End Get
            Set(ByVal Value As Decimal)
                m_DCTotalFabric = Value
            End Set
        End Property
        Public Property Cons() As Decimal
            Get
                Cons = m_DCCons
            End Get
            Set(ByVal Value As Decimal)
                m_DCCons = Value
            End Set
        End Property
        Public Property Percent() As Decimal
            Get
                Percent = m_DCPercent
            End Get
            Set(ByVal Value As Decimal)
                m_DCPercent = Value
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
            str &= " left join Customer CD ON JO.CustomerDatabaseID=CD.CustomerID "
            str &= " left JOIN ITEMDATABASE ITD ON ITD.ItemDatabaseId=JD.ItemDatabaseId where JO.JoborderID='" & Joborderid & "' "


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
        Public Function GetStyle(ByVal joborderid As Long) As DataTable
            Dim str As String
            str = "  select distinct style from JobOrderdatabaseDetail where joborderid='" & joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccessorieseCode() As DataTable
            Dim str As String
            str = " select * from   Accessories "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStockQty(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = " Select Top 1 isnull(CloseQty,0 ) as stockqty"
            str &= " from IMSStoreLedger ImSL where  ImSL.IMSItemID='" & IMSItemID & "'"
            str &= " order by StoreLedgerID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricData(ByVal FabricDatabaseID As Long) As DataTable
            Dim str As String
            str = " Select * from FabricDatabase where FabricDatabaseID='" & FabricDatabaseID & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetail(ByVal lFPlanDtlID As Long)
            Dim Str As String
            Str = " Delete from FPlanDtl where FPlanDtlID=" & lFPlanDtlID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFPLANdetail(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            'str = " select *,convert(varchar,ReqDate,103) as ReqDatee, fdb.FabricWeave as Fabric from FPlanMst FM JOIN FPlanDtl FD "
            'str &= " ON FM.FPlanMstID=FD.FPlanMstID  join FabricDatabase fdb on fdb.FabricDatabaseID =fd.FabricdataBaseId WHERE JobOrderId='" & JobOrderIdID & "' "

            str = " select *,convert(varchar,ReqDate,103) as ReqDatee, fdb.ItemName as Fabric from FPlanMst FM JOIN FPlanDtl FD "
            str &= " ON FM.FPlanMstID=FD.FPlanMstID  join  IMSItem fdb on fdb.IMSItemID =fd.FabricdataBaseId  WHERE JobOrderId='" & JobOrderIdID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFPLANHistory(ByVal JobOrderIdID As Long, ByVal FabricDatabaseID As Long) As DataTable
            Dim str As String
            str = " select *,IssueQty as IssuedQty from  FPlanHistory where JobOrderID='" & JobOrderIdID & "' AND FabricDatabaseId='" & FabricDatabaseID & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

