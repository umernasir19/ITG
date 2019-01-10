Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class AccessoriesePlanMst

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccessoriesePlanMst"
            m_strPrimaryFieldName = "AccessoriesePlanMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccessoriesePlanMstID As Long
        Private m_lJobOrderId As Long
        Private m_strJobOrderNo As String
        Private m_dtRecvDate As Date
        Private m_dtShipDate As Date
        Private m_strSeason As String
        Private m_strBuyer As String
        Private m_strBrand As String
        Private m_strContent As String
        Private m_DCQuantity As Decimal
        Public Property AccessoriesePlanMstID() As Long
            Get
                AccessoriesePlanMstID = m_lAccessoriesePlanMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesePlanMstID = Value
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
        Public Function SaveAccessoriesePlanMst()
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
        Public Function GetStyle(ByVal joborderid As Long) As DataTable
            Dim str As String
            str = "  select distinct style from JobOrderdatabaseDetail where joborderid='" & joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
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
            str &= " left join CustomerDatabase CD ON JO.CustomerDatabaseID=CD.CustomerDatabaseID "
            str &= " left JOIN ITEMDATABASE ITD ON ITD.ItemDatabaseId=JD.ItemDatabaseId where JO.JoborderID='" & Joborderid & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUOM() As DataTable
            Dim str As String
            str = " Select * from UnitofMeasurement "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricCode() As DataTable
            Dim str As String
            str = " Select * from FabricDatabase "
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
        Public Function GetAccessorieseCodee() As DataTable
            Dim str As String

            str = " Select * ,AccessoriesName + '(' + ColorName +')' as Accessories from Accessories  A "
            str &= " join AccessoriesCategory AG on AG.AccessoriesCategoryID=A.AccessoriesCategoryID "
            str &= " join AccessoriesColor AC on AC.AccessoriesColorID=A.AccessoriesColorID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccessorieseData(ByVal AccessoriesID As Long) As DataTable
            Dim str As String
            str = " Select *  from Accessories  A "
            str &= " join AccessoriesCategory AG on AG.AccessoriesCategoryID=A.AccessoriesCategoryID "
            str &= " join AccessoriesColor AC on AC.AccessoriesColorID=A.AccessoriesColorID"
            str &= "   where A.AccessoriesID='" & AccessoriesID & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccessorieseDatabyclass(ByVal AccessoriesID As Long) As DataTable
            Dim str As String
            str = " Select * from Accessories  A "
            str &= " join IMSItemClass AG on AG.IMSItemClassid=A.AccessoriesCategoryID "
            str &= " join AccessoriesColor AC on AC.AccessoriesColorID=A.AccessoriesColorID"
            str &= "   where A.AccessoriesID='" & AccessoriesID & "'  "
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
        Public Function GetAccessPLANdetail(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            'str = " select APD.Style, APD.Placement,APD.IMSItemID,APD.AccReqStatus,APD.Consumption,APD.PieceQty,APD.Percentt,APM.AccessoriesePlanMstID,APD.AccessoriesePlanDtlID,A.AccessoriesID,M.UOMID,A.AccessoriesCode,A.AccessoriesName,AC.ColorName ,convert(varchar,ReqDate,103) as ReqDatee,APD.ReqQty as 'ReqQty',(convert(varchar,APD.ReqQty) + ' '+ M.UOMNAme) as 'ReqQty2'  from AccessoriesePlanMst APM JOIN AccessoriesePlanDtl APD "
            'str &= " ON APM.AccessoriesePlanMstID=APD.AccessoriesePlanMstID "
            'str &= " join Accessories A on A.AccessoriesID=APD.AccessoriesID "
            'str &= " join IMSItemClass AG on AG.IMSItemClassid=A.AccessoriesCategoryID "
            'str &= " join AccessoriesColor AC on AC.AccessoriesColorID=A.AccessoriesColorID"
            ''  str &= "  join AccessoriesUploadFiles F on F.UploadID=A.UploadID "
            'str &= "  left join UnitOfMeasurement M on M.UOMID=APD.UOMID "

            str = "   select APD.AccReqStatus,APD.Style, APD.Percentage,APD.PerPcsAvg,APD.Qty,"
            str &= "  APD.Remarks,APM.AccessoriesePlanMstID,APD.AccessoriesePlanDtlID,A.AccessoriesID,M.UOMID,"
            str &= "  A.AccessoriesCode,A.AccessoriesName,AC.ColorName ,A.UploadPicture "
            str &= "  from AccessoriesePlanMst APM "
            str &= "  JOIN AccessoriesePlanDtl APD  ON APM.AccessoriesePlanMstID=APD.AccessoriesePlanMstID  "
            str &= "  join Accessories A on A.AccessoriesID=APD.AccessoriesID "
            str &= "   join IMSItemClass AG on AG.IMSItemClassid=A.AccessoriesCategoryID"
            str &= "   join AccessoriesColor AC on AC.AccessoriesColorID=A.AccessoriesColorID "
            str &= "  left join UnitOfMeasurement M on M.UOMID=APD.UOMID  "
            str &= "  WHERE APM.JobOrderId='" & JobOrderIdID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAPLANHistory(ByVal JobOrderIdID As Long, ByVal AccosiresdataBaseId As Long) As DataTable
            Dim str As String
            str = " select *,IssueQty as IssuedQty from  APlanHistory where JobOrderID='" & JobOrderIdID & "' AND AccosiresdataBaseId='" & AccosiresdataBaseId & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccosiresData(ByVal AccosiresDatabaseID As Long) As DataTable
            Dim str As String
            str = " Select * from Accessories where AccessoriesID='" & AccosiresDatabaseID & "'  "
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
        Public Function GetAccessory() As DataTable
            Dim str As String

            str = " Select * ,AccessoriesName + '(' + ColorName +')' as Accessories "
            str &= " from Accessories  A  "
            str &= " join IMSItemClass AG on AG.IMSItemClassid=A.AccessoriesCategoryID "
            str &= " join AccessoriesColor AC on AC.AccessoriesColorID=A.AccessoriesColorID "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForEnablePDFForAcc(ByVal AccessoriesePlanDtlID As Long) As DataTable
            Dim str As String

            str = " select * from tblRequisitionMst RM"
            str &= " join tblRequisitiondTL RD on RD.ReqMstId=RM.ReqMstId"
            str &= " join AccessoriesePlanDtl APD on APD.AccessoriesePlanDtlID=RD.AccessoriesePlanDtlID"
            str &= " where RD.AccessoriesePlanDtlID='" & AccessoriesePlanDtlID & "'and RD.ApprovedByceo=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

