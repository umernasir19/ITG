Imports system.data
Namespace eurocentra
    Public Class AccCheckListDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccCheckListDetail"
            m_strPrimaryFieldName = "AccCheckListDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccCheckListDetailID As Long
        Private m_lAccCheckListMstID As Long
        Private m_lIMSItemId As Long
        Private m_lIMSItemCategoryID As Long
        Private m_dUsagePC As Decimal
        Private m_dTotal As Decimal
        Private m_dPercent As Decimal
        Private m_dOrderQty As Decimal
        Private m_strRemarks As String
        Private m_dCalQTy As Decimal
        Private m_strAssortSize As String
        Private m_lStyleAssortmentDetailID As Long
        Private m_strDescription As String
        Private m_strItemCode As String
        Private m_lIMSItemClassID As Long

        Public Property IMSItemClassID() As Long
            Get
                IMSItemClassID = m_lIMSItemClassID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemClassID = Value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                ItemCode = m_strItemCode
            End Get
            Set(ByVal value As String)
                m_strItemCode = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        Public Property AccCheckListDetailID() As Long
            Get
                AccCheckListDetailID = m_lAccCheckListDetailID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListDetailID = Value
            End Set
        End Property
        Public Property AccCheckListMstID() As Long
            Get
                AccCheckListMstID = m_lAccCheckListMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListMstID = Value
            End Set
        End Property
        Public Property IMSItemId() As Long
            Get
                IMSItemId = m_lIMSItemId
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemId = Value
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
        Public Property UsagePC() As Decimal
            Get
                UsagePC = m_dUsagePC
            End Get
            Set(ByVal value As Decimal)
                m_dUsagePC = value
            End Set
        End Property
        Public Property Total() As Decimal
            Get
                Total = m_dTotal
            End Get
            Set(ByVal value As Decimal)
                m_dTotal = value
            End Set
        End Property
        Public Property Percent() As Decimal
            Get
                Percent = m_dPercent
            End Get
            Set(ByVal value As Decimal)
                m_dPercent = value
            End Set
        End Property
        Public Property OrderQty() As Decimal
            Get
                OrderQty = m_dOrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dOrderQty = value
            End Set
        End Property

        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        Public Property CalQTy() As Decimal
            Get
                CalQTy = m_dCalQTy
            End Get
            Set(ByVal value As Decimal)
                m_dCalQTy = value
            End Set
        End Property
        Public Property AssortSize() As String
            Get
                AssortSize = m_strAssortSize
            End Get
            Set(ByVal value As String)
                m_strAssortSize = value
            End Set
        End Property
        Public Property StyleAssortmentDetailID() As Long
            Get
                StyleAssortmentDetailID = m_lStyleAssortmentDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentDetailID = Value
            End Set
        End Property
        Public Function SaveAccCheckListDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTodayStitching(ByVal todaydate As String) As DataTable
            Dim str As String
            str = "  select count(TFAS.StitchingBit) as TotalStitching from TFAStitching TFAS where CONVERT(VARCHAR(10),TFAS.CreationDate,101)='" & todaydate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTodayWashing(ByVal todaydate As String) As DataTable
            Dim str As String
            str = "  select count(TFAS.WashingBit) as TotalWashing  from TFAWashing TFAS where CONVERT(VARCHAR(10),TFAS.CreationDate,101)='" & todaydate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTodayRecvWash(ByVal todaydate As String) As DataTable
            Dim str As String
            str = "  select count(TFAS.WashingRecvBit) as TFAWashingRecv  from TFAWashingRecv TFAS where CONVERT(VARCHAR(10),TFAS.CreationDate,101)='" & todaydate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTodayPacking(ByVal todaydate As String) As DataTable
            Dim str As String
            str = "  select count(TFAS.FinishingBit) as TotalFinishing  from TFAFinishing TFAS where CONVERT(VARCHAR(10),TFAS.CreationDate,101)='" & todaydate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetViewNewForGMNew() As DataTable
            Dim str As String
            str = "   select distinct '0' as Size,JOD.buyerColor, JO.JobOrderId,SAM.StyleAssortmentMasterid ,JOD.JoborderDetailid,JO.JobOrderNo,JOD.Style,CD.CustomerName,IDM.ItemName ,JOD.Quantity as StyleQuantity "
            str &= " ,isnull((select isnull((case when SAD.Breakup <>'Ratio' then   sum(SAD.AsortQty)  else   sum(SAD.Qty)  end),0)  from StyleAssortmentDetail SAD   where SAD.StyleAssortmentMasterid = SAM.StyleAssortmentMasterid group by SAD.Breakup),0) as SizeQty , "
            str &= " (select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalStitching ,"
            str &= " (((select isnull(sum(TFAPD.StitchingQty),0) from TFAProductionMaster TFAPM join TFAProductiondetail TFAPD on TFAPM.TFAProductionMasterID=TFAPD.TFAProductionMasterID where TFAPM.JobOrderId=JO.JobOrderId and  TFAPM.JobOrderId=JOD.JobOrderId and  TFAPM.JoborderDetailid=JOD.JoborderDetailid and TFAPD.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)+(JOD.Quantity))-((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid))) as BalInS ,"
            str &= " (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalWashing "
            str &= " ,(( (select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid))-( (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid))) as BalInF "
            str &= " , (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalFinishing ,(( (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid))-((select count(TFAS.FinishingBit)  from TFAFinishing TFAS  where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid))) as BalInW"
            str &= " ,(select isnull(sum(TFAPD.CuttingQTY),0)  from TFAProductionMaster TFAPM join TFAProductiondetail TFAPD on TFAPM.TFAProductionMasterID=TFAPD.TFAProductionMasterID where TFAPM.JobOrderId=JO.JobOrderId and  TFAPM.JobOrderId=JOD.JobOrderId and  TFAPM.JoborderDetailid=JOD.JoborderDetailid and TFAPD.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as CuttingQTY ,((select isnull(sum(TFAPD.StitchingQty),0) from TFAProductionMaster TFAPM join TFAProductiondetail TFAPD on TFAPM.TFAProductionMasterID=TFAPD.TFAProductionMasterID where TFAPM.JobOrderId=JO.JobOrderId and  TFAPM.JobOrderId=JOD.JobOrderId and  TFAPM.JoborderDetailid=JOD.JoborderDetailid and TFAPD.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)+(JOD.Quantity )) as StitchingQty , "
            str &= " ( select count(TFAPM.Extra)   from StyleAssortmentBarCodeDetail TFAPM where TFAPM.JobOrderId=JO.JobOrderId and  TFAPM.JobOrderId=JOD.JobOrderId and  TFAPM.JoborderDetailid=JOD.JoborderDetailid and TFAPM.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid and TFAPM.Extra<>0) as ExtraQTY "
            str &= " from  JobOrderdatabase JO  "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId "
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId  and JOD.JoborderDetailid=SAM.JoborderDetailid "
            str &= "  left join itemDatabase IDM on IDM.itemDatabaseID=JOD.itemDatabaseID where JOD.ShipmentBit = '0' "
            str &= " and((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) <>'0'"
            str &= " or (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) <>'0' "
            str &= " or (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)<>'0' )"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetproductionDateVise() As DataTable
            Dim str As String

            str = "     DECLARE @datefrom as datetime,@todate as datetime"
            str &= " set @todate =convert(date,GETDATE(),103)"
            str &= " set @datefrom = convert(date,DATEADD(d,-60,@todate),103)"

            str &= "   select  JOD.buyerColor, JO.JobOrderId,SAM.StyleAssortmentMasterid ,JOD.JoborderDetailid,JO.SRNO,"
            str &= " JOD.Style, CD.CustomerName, JOD.ItemDesc"
            str &= " ,isnull((select sum(DPD.TotalQty)  from DPCuttingProMaster DPM join DPCuttingProDetail "
            str &= " DPD on DPD.CuttingProMasterID =DPM.CuttingProMasterID"
            str &= " where    DPM.JoborderDetailid=JOD.JoborderDetailid),0)AS CuttingQty"
            str &= " ,  (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as TotalStitching"
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where   TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalWashing  "
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)   -"
            str &= " (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as BalInWashing"
            str &= " , (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalRecvWashing "
            str &= " ,(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)-"
            str &= " (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInRecvWashing"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalPacking"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -"
            str &= " (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInPacking"

            str &= "   ,(select count(TFAS.WashingBit)  from TFAWashing TFAS where   "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= "
            str &= "SAM.StyleAssortmentMasterid) -(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInDDL "


            str &= ",(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInRecvWashing "



            str &= "   ,(select count(TFAS.WashingBit)  from TFAWashing TFAS where   "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= "
            str &= "SAM.StyleAssortmentMasterid) -(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInDDL "


            str &= ",(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInRecvWashing "



            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " and JOD.JoborderDetailid=SAM.JoborderDetailid "
            str &= " where ((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid and"
            str &= " TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid) <>'0' "
            str &= "   or (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= "   and TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid) <>'0'  or "
            str &= "    (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= "      and TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid)<>'0' )"
            str &= "  and JOD.StyleShipmentDate between @datefrom and @todate"
            str &= " ORDER BY  jo.SRNOPOne ,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForProductionForSeasonViseSearchingNew(ByVal SeasonDatabaseId As Long) As DataTable
            Dim str As String

            str = "   select  JOD.buyerColor, JO.JobOrderId,SAM.StyleAssortmentMasterid ,JOD.JoborderDetailid,JO.SRNO,"
            str &= " JOD.Style, CD.CustomerName, JOD.ItemDesc"
            str &= " ,isnull((select sum(DPD.TotalQty)  from DPCuttingProMaster DPM join DPCuttingProDetail "
            str &= " DPD on DPD.CuttingProMasterID =DPM.CuttingProMasterID"
            str &= " where    DPM.JoborderDetailid=JOD.JoborderDetailid),0)AS CuttingQty"
            str &= " ,  (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as TotalStitching"
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where   TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalWashing  "
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)   -"
            str &= " (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as BalInWashing"
            str &= " , (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalRecvWashing "
            str &= " ,(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)-"
            str &= " (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInRecvWashing"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalPacking"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -"
            str &= " (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInPacking"

            str &= "   ,(select count(TFAS.WashingBit)  from TFAWashing TFAS where   "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= "
            str &= "SAM.StyleAssortmentMasterid) -(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInDDL "


            str &= ",(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInRecvWashing "



            str &= "   ,(select count(TFAS.WashingBit)  from TFAWashing TFAS where   "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= "
            str &= "SAM.StyleAssortmentMasterid) -(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInDDL "


            str &= ",(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInRecvWashing "



            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " and JOD.JoborderDetailid=SAM.JoborderDetailid "
            str &= " where ((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid and"
            str &= " TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid) <>'0' "
            str &= "   or (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= "   and TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid) <>'0'  or "
            str &= "    (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= "      and TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid)<>'0' )"
            str &= "  and JO.SeasonDatabaseID='" & SeasonDatabaseId & "' and YEAR(jo.CreationDate)='2018'"
            'str &= "   and  ((YEAR(jo.CreationDate )='2017' and MONTH(jo.CreationDate)='12') or YEAR(jo.CreationDate)='2018')"
            str &= " ORDER BY  jo.SRNOPOne ,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetDataForProductionNew() As DataTable
            Dim str As String
            str = "   select  JOD.buyerColor, JO.JobOrderId,SAM.StyleAssortmentMasterid ,JOD.JoborderDetailid,JO.SRNO,"
            str &= " JOD.Style, CD.CustomerName, JOD.ItemDesc"
            str &= " ,isnull((select sum(DPD.TotalQty)  from DPCuttingProMaster DPM join DPCuttingProDetail "
            str &= " DPD on DPD.CuttingProMasterID =DPM.CuttingProMasterID"
            str &= " where    DPM.JoborderDetailid=JOD.JoborderDetailid),0)AS CuttingQty"
            str &= " ,  (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as TotalStitching"
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where   TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalWashing  "
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)   -"
            str &= " (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as BalInWashing"
            str &= " , (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalRecvWashing "
            str &= " ,(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)-"
            str &= " (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInRecvWashing"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalPacking"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -"
            str &= " (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInPacking"

            str &= "   ,(select count(TFAS.WashingBit)  from TFAWashing TFAS where   "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= "
            str &= "SAM.StyleAssortmentMasterid) -(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInDDL "


            str &= ",(select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JoborderDetailid="
            str &= "JOD.JoborderDetailid  and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalanceInRecvWashing "


            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " and JOD.JoborderDetailid=SAM.JoborderDetailid "
            str &= " where ((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid and"
            str &= " TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid) <>'0' "
            str &= "   or (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= "   and TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid) <>'0'  or "
            str &= "    (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= "      and TFAS.StyleAssortmentMasterid=  SAM.StyleAssortmentMasterid)<>'0' )"
            str &= " ORDER BY  jo.SRNOPOne ,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForProductionForSeasonViseSearching(ByVal SeasonDatabaseId As Long) As DataTable
            Dim str As String
            str = "   select  JOD.buyerColor, JO.JobOrderId,SAM.StyleAssortmentMasterid ,JOD.JoborderDetailid,JO.SRNO,"
            str &= "  JOD.Style, CD.CustomerName, JOD.ItemDesc"
            str &= " ,isnull((select sum(DPD.TotalQty)  from DPCuttingProMaster DPM join DPCuttingProDetail DPD on DPD.CuttingProMasterID =DPM.CuttingProMasterID"
            str &= "        where DPM.JobOrderId = JO.JobOrderId And DPM.JobOrderId = JOD.JobOrderId "
            str &= " and  DPM.JoborderDetailid=JOD.JoborderDetailid),0)AS CuttingQty"
            str &= " ,  (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  "
            str &= "  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as TotalStitching"
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalWashing  "
            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= "  and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)   -"
            str &= " (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as BalInWashing"
            str &= " , (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalRecvWashing  "
            str &= " ,(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)-"
            str &= " (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= "  and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInRecvWashing"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId "
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalPacking"
            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId "
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -"
            str &= " (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInPacking"
            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " and JOD.JoborderDetailid=SAM.JoborderDetailid "
            str &= " where ((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JobOrderId=JO.JobOrderId and  "
            str &= " TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= "
            str &= " SAM.StyleAssortmentMasterid) <>'0'"
            str &= " or (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId and  "
            str &= " TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= "
            str &= " SAM.StyleAssortmentMasterid) <>'0' "
            str &= " or (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId and  "
            str &= " TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= "
            str &= " SAM.StyleAssortmentMasterid)<>'0' ) and JO.SeasonDatabaseID='" & SeasonDatabaseId & "'"
            str &= " ORDER BY  jo.SRNOPOne ,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForProduction() As DataTable
            Dim str As String
            str = "   select  JOD.buyerColor, JO.JobOrderId,SAM.StyleAssortmentMasterid ,JOD.JoborderDetailid,JO.SRNO,"
            str &= "  JOD.Style, CD.CustomerName, JOD.ItemDesc"

            str &= " ,isnull((select sum(DPD.TotalQty)  from DPCuttingProMaster DPM join DPCuttingProDetail DPD on DPD.CuttingProMasterID =DPM.CuttingProMasterID"
            str &= "        where(DPM.JobOrderId = JO.JobOrderId And DPM.JobOrderId = JOD.JobOrderId)"
            str &= " and  DPM.JoborderDetailid=JOD.JoborderDetailid),0)AS CuttingQty"

            str &= " ,  (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  "
            str &= "  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as TotalStitching"


            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalWashing  "


            str &= " , (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= "  and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)   -"
            str &= " (select count(TFAS.StitchingBit)  from TFAStitching TFAS"
            str &= " where TFAS.JobOrderId=JO.JobOrderId and  TFAS.JobOrderId=JOD.JobOrderId and  "
            str &= " TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid="
            str &= " SAM.StyleAssortmentMasterid) as BalInWashing"


            str &= " , (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalRecvWashing  "


            str &= " ,(select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid)-"
            str &= " (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= "  and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInRecvWashing"


            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId "
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as TotalPacking"


            str &= " , (select count(TFAS.FinishingBit) from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId "
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) -"
            str &= " (select count(TFAS.WashingRecvBit)  from TFAWashingRecv TFAS where TFAS.JobOrderId=JO.JobOrderId"
            str &= " and  TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid "
            str &= " and TFAS.StyleAssortmentMasterid= SAM.StyleAssortmentMasterid) as BalInPacking"


            str &= " from  JobOrderdatabase JO   "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=JO.JobOrderId  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  "
            str &= " join joborderdatabasedetail JOD on JOD.JobOrderId=JO.JobOrderId "
            str &= " and JOD.JoborderDetailid=SAM.JoborderDetailid "

            str &= " where ((select count(TFAS.StitchingBit)  from TFAStitching TFAS where TFAS.JobOrderId=JO.JobOrderId and  "
            str &= " TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= "
            str &= " SAM.StyleAssortmentMasterid) <>'0'"
            str &= " or (select count(TFAS.WashingBit)  from TFAWashing TFAS where TFAS.JobOrderId=JO.JobOrderId and  "
            str &= " TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= "
            str &= " SAM.StyleAssortmentMasterid) <>'0' "
            str &= " or (select count(TFAS.FinishingBit)  from TFAFinishing TFAS where TFAS.JobOrderId=JO.JobOrderId and  "
            str &= " TFAS.JobOrderId=JOD.JobOrderId and  TFAS.JoborderDetailid=JOD.JoborderDetailid and TFAS.StyleAssortmentMasterid= "
            str &= " SAM.StyleAssortmentMasterid)<>'0' )"
            str &= " ORDER BY  jo.SRNOPOne ,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteCheckListAccessDetail(ByVal AccCheckListDetailID As Long)
            Dim Str As String
            Str = " Delete from AccCheckListDetail where AccCheckListDetailID=" & AccCheckListDetailID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteCheckListZipperDetail(ByVal ZipperCheckListDetailID As Long)
            Dim Str As String
            Str = " Delete from ZipperCheckListDetail where ZipperCheckListDetailID=" & ZipperCheckListDetailID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteCheckListThreadDetail(ByVal ThreadCheckListID As Long)
            Dim Str As String
            Str = " Delete from ThreadCheckList where ThreadCheckListID=" & ThreadCheckListID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckAlreadyExistAccCheckListZipperIDinCost(ByVal ZipperCheckListDetailID As Long) As DataTable
            Dim str As String
            str = " select * from  ZipperCheckListCostDetail "
            str &= " WHERE ZipperCheckListDetailID = '" & ZipperCheckListDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyExistAccCheckListDtlIDinCost(ByVal AccCheckListDetailID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListCostDetail "
            str &= " WHERE AccCheckListDetailID = '" & AccCheckListDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyExistAccCheckListThtreadDtlIDinCost(ByVal ThreadCheckListID As Long) As DataTable
            Dim str As String
            str = " select * from  ThreadCheckCostList "
            str &= " WHERE ThreadCheckListID = '" & ThreadCheckListID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccDtl(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListMst AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= " WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccDtlNew(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListMst AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= " Join IMSItemClass IMS_ICC On IMS_ICC.IMSItemClassID = IMS_I.IMSItemClassID "
            str &= " WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetZipperDtlNew(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListMst AM "
            str &= " JOIN ZipperCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= " Join IMSItemClass IMS_ICC On IMS_ICC.IMSItemClassID = IMS_I.IMSItemClassID "
            str &= " WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemIDAndItemCategoryID(ByVal ItemCodee As String) As DataTable
            Dim str As String

            str = " Select * from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " where IMS_I.ItemCodee= '" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

