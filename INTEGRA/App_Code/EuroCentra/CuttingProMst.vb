Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CuttingProMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPCuttingProMaster"
            m_strPrimaryFieldName = "CuttingProMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCuttingProMasterID As Long
        Private m_lStyleAssortmentMasterID As Long
        Private m_lJobOrderID As Long
        Private m_lJoborderDetailid As Long
        Private m_lUserID As Long
        Private m_dtCreationDate As Date
        Private m_dcExtraQty As Decimal
        Private m_strStitchingFactory As String
        Private m_dtStitchingStart As Date
        Private m_lPocketLiningCodeid As Long
        Private m_lOtherFabricid As Long
        Private m_strRevisedDate As String
        
        Public Property RevisedDate() As String
            Get
                RevisedDate = m_strRevisedDate
            End Get
            Set(ByVal Value As String)
                m_strRevisedDate = Value
            End Set
        End Property
        Public Property PocketLiningCodeid() As Long
            Get
                PocketLiningCodeid = m_lPocketLiningCodeid
            End Get
            Set(ByVal Value As Long)
                m_lPocketLiningCodeid = Value
            End Set
        End Property
        Public Property OtherFabricid() As Long
            Get
                OtherFabricid = m_lOtherFabricid
            End Get
            Set(ByVal Value As Long)
                m_lOtherFabricid = Value
            End Set
        End Property
        Public Property CuttingProMasterID() As Long
            Get
                CuttingProMasterID = m_lCuttingProMasterID
            End Get
            Set(ByVal Value As Long)
                m_lCuttingProMasterID = Value
            End Set
        End Property
        Public Property StyleAssortmentMasterID() As Long
            Get
                StyleAssortmentMasterID = m_lStyleAssortmentMasterID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentMasterID = Value
            End Set
        End Property
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailid = Value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal Value As Long)
                m_lUserID = Value
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
        Public Property ExtraQty() As Decimal
            Get
                ExtraQty = m_dcExtraQty
            End Get
            Set(ByVal Value As Decimal)
                m_dcExtraQty = Value
            End Set
        End Property
        Public Property StitchingFactory() As String
            Get
                StitchingFactory = m_strStitchingFactory
            End Get
            Set(ByVal Value As String)
                m_strStitchingFactory = Value
            End Set
        End Property
        Public Property StitchingStart() As Date
            Get
                StitchingStart = m_dtStitchingStart
            End Get
            Set(ByVal value As Date)
                m_dtStitchingStart = value
            End Set
        End Property



        Public Function SaveCuttingProMaster()
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
        Public Function GetDataCargo(ByVal CargoID As Long) As DataTable
            Dim str As String
            str = " Select * from Cargo where CargoID ='" & CargoID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetData(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = "  select JO.SRNo,JOd.ItemDesc, UOM.UOMName,IDB.DPItemName,JOd.BuyerColor AS Colorr,JO.CustomerOrder,Jo.JobOrderId,Jo.JobOrderNo, JO.PONo,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee "
            str &= " from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " left  join DPItemDatabase IDB on IDB.DPItemDatabaseID=JOD.ItemDatabaseID"
            str &= " join UnitofMeasurement UOM on UOM.UOMID=JOD.UOMID"
            str &= "  where JO.JobOrderId = '" & JobOrderId & "' And JOD.JoborderDetailid ='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetForDetail(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select isnull(CuttingProDetailID,0) as CuttingProDetailID, isnull(CMD.totalqty ,(Sad.Qty+Sad.Asortqty+Sad.ExtraQty)) as TotalQty ,"
            str &= " SAM.*,SAD.*,SDB.Sizes "
            str &= " from StyleAssortmentMaster SAM "
            str &= " join StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID=SAM.StyleAssortmentMasterID"
            str &= " join SizeRange SR on SR.SizeRangeID=SAD.SizeRangeID"
            str &= " join SizeDatabase SDB on SDB.SizeDatabaseID=SAD.SizeDatabaseID"
            str &= " left JOIN  DPCuttingProMaster CMM ON SAM.StyleAssortmentMasterID=CMM.StyleAssortmentMasterID"
            str &= " left JOIN DPCuttingProDetail CMD ON CMD.StyleAssortmentDetailID=SAD.StyleAssortmentDetailID"
            str &= " where SAD.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' order by   SAD.StyleAssortmentDetailID asc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQty(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select isnull(CuttingProDetailID,0) as CuttingProDetailID, (Sad.Qty+Sad.Asortqty+Sad.ExtraQty) as TotalQty ,"
            str &= " SAM.*,SAD.*,SDB.Sizes "
            str &= " from StyleAssortmentMaster SAM "
            str &= " join StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID=SAM.StyleAssortmentMasterID"
            str &= " join SizeRange SR on SR.SizeRangeID=SAD.SizeRangeID"
            str &= " join SizeDatabase SDB on SDB.SizeDatabaseID=SAD.SizeDatabaseID"
            str &= " left JOIN  DPCuttingProMaster CMM ON SAM.StyleAssortmentMasterID=CMM.StyleAssortmentMasterID"
            str &= " left JOIN DPCuttingProDetail CMD ON CMD.StyleAssortmentDetailID=SAD.StyleAssortmentDetailID"
            str &= " where SAD.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' order by   SAD.StyleAssortmentDetailID asc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQtyForNew(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select isnull(CuttingProDetailID,0) as CuttingProDetailID, (Sad.Qty+Sad.Asortqty+Sad.ExtraQty) as TotalQty ,"
            str &= " SAM.*,SAD.*,SDB.Sizes,CMM.UserId as UserIdd "
            str &= " from StyleAssortmentMaster SAM "
            str &= " join StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID=SAM.StyleAssortmentMasterID"
            str &= " join SizeRange SR on SR.SizeRangeID=SAD.SizeRangeID"
            str &= " join SizeDatabase SDB on SDB.SizeDatabaseID=SAD.SizeDatabaseID"
            str &= " left JOIN  DPCuttingProMaster CMM ON SAM.StyleAssortmentMasterID=CMM.StyleAssortmentMasterID"
            str &= " left JOIN DPCuttingProDetail CMD ON CMD.StyleAssortmentDetailID=SAD.StyleAssortmentDetailID"
            str &= " where SAD.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' order by   SAD.StyleAssortmentDetailID asc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckChecklistMstIDinZipper(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select * from ZipperCheckListDetail"
            str &= " where AccCheckListMstID = '" & AccCheckListMstID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckChecklistMstIDinAccDtl(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select * from AccCheckListDetail"
            str &= " where AccCheckListMstID = '" & AccCheckListMstID & "' and StyleAssortmentDetailID<>0"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckCuttingQty(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select isnull(SUM(Dtl.TotalQty ),0) as  TotalQty from DPCuttingProMaster Mst"
            str &= " join DPCuttingProDetail Dtl on Dtl.CuttingProMasterID =mst.CuttingProMasterID "
            str &= "  where Mst.JobOrderId = '" & JobOrderId & "' And  Mst.JoborderDetailid ='" & JoborderDetailid & "' and Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAssortQty(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = "  select ISNULL(((SUM(Dtl.Asortqty ))+sum((Dtl.ExtraQty ))),0) as ExtraQty from StyleAssortmentMaster mst "
            str &= "   join StyleAssortmentDetail Dtl on Dtl.StyleAssortmentMasterID =mst.StyleAssortmentMasterID "
            str &= "  where Mst.JobOrderId = '" & JobOrderId & "' And  Mst.JoborderDetailid ='" & JoborderDetailid & "' and Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemID(ByVal IMSItemId As Long) As DataTable
            Dim str As String
            str = "  select *,ItemQuality +' '+ ItemComposition +' '+ ItemFinish +' '+ItemWashDye as FabricQualityy from IMSItem "
            str &= "  where IMSItemId = '" & IMSItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function check(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = "  select * from DPCuttingProMaster "
            str &= "  where JobOrderId = '" & JobOrderId & "' And  JoborderDetailid ='" & JoborderDetailid & "' and StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function checkSizeWeight(ByVal JobOrderId As Long) As DataTable
            Dim str As String
            str = "  select * from SizeWiseWeightListMst "
            str &= "  where JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJobOrderdata(ByVal JobOrderId As Long) As DataTable
            Dim str As String
            str = "  select  '0' as ConDtlID,jod.JoborderDetailid ,JO.SRNo,JOd.Style, JOd.Quantity ,JO.CustomerOrder,"
            str &= "   Jo.JobOrderId, SD.SeasonName, CD.CustomerName"
            str &= "  ,jo.CustomerOrder,ISNULL((CDD.Quantity),0) AS ShippedQuantity,ISNULL((DPM.StitchingFactory),'') AS StitchingFactory"
            str &= "  ,ISNULL((convert(varchar,DPM.StitchingStart,103)),'') AS StitchingDate,JOd.BuyerColor as Color  "
            str &= "  from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= "  join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= "  join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= "  left join CargoDetail CDD on CDD.POPOID =JO.Joborderid AND CDD.POID =jod.JoborderDetailid "
            str &= "  left JOIN DPCuttingProMaster DPM on DPM.JobOrderID =JO.Joborderid AND DPM.JoborderDetailid =JOD.JoborderDetailid  "
            str &= "  where JO.JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSize(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = "  select * from DPCuttingProMaster CM JOIN  DPCuttingProDetail CD ON CM.CuttingProMasterID=CD.CuttingProMasterID "
            str &= "  where JobOrderId = '" & JobOrderId & "' And  JoborderDetailid ='" & JoborderDetailid & "' and CM.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeQty(ByVal size As String, ByVal CuttingProDetailID As Long) As DataTable
            Dim str As String
            str = "   select * from DPCuttingProMaster CM JOIN  DPCuttingProDetail CD ON CM.CuttingProMasterID=CD.CuttingProMasterID"
            str &= " where size = '" & size & "' And  CuttingProDetailID ='" & CuttingProDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


