Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TemSRNO

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TemSRNO"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lID As Long
        Private m_strNo As String


        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal Value As Long)
                m_lID = Value
            End Set
        End Property
        Public Property No() As String
            Get
                No = m_strNo
            End Get
            Set(ByVal value As String)
                m_strNo = value
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
        Public Function GetSupplier() As DataTable
            Dim str As String
            str = " Select * from SupplierDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCertificates() As DataTable
            Dim str As String
            str = "select CertificateID,Certificate,IsLifetime,Status='False' from Certificate"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyer() As DataTable
            Dim str As String
            str = " Select * from Customer "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasons() As DataTable
            Dim str As String
            str = " Select * from SeasonDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonsForPanal() As DataTable
            Dim str As String
            str = " Select distinct SD.SeasonDatabaseID,SeasonName from SeasonDatabase SD join Joborderdatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPlacement() As DataTable
            Dim str As String
            str = " Select * from Placement "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonsForJobOrderVieeSearching() As DataTable
            Dim str As String
            str = " Select Distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD join JobOrderdatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID join StyleAssortmentMaster SA on SA.JobOrderID =JO.Joborderid "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrand() As DataTable
            Dim str As String
            str = " Select * from BrandDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeason() As DataTable
            Dim str As String
            str = " Select * from SeasonDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPaymentTerm() As DataTable
            Dim str As String
            str = " Select * from PaymentTerm "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetShipmentMode() As DataTable
            Dim str As String
            str = " Select * from ShipmentMode "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetInvoiceNo() As DataTable
            Dim str As String
            str = " Select * from Cargo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCommericalPacking(ByVal CargoID As Long) As DataTable
            Dim str As String
            str = " select * from Cargo C"
            str &= " join CargoDetail CC on CC.CargoID =C.CargoID "
            str &= " join JobOrderdatabase Jo on JO.Joborderid =CC.POPOID  "
            str &= " where C.CargoID=" & CargoID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCutting(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " select DISTINCT JO.Joborderid,JO.SRNO   from JobOrderdatabase jo"
            str &= " join SeasonDatabase sd on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= " where sd.SeasonDatabaseID=" & SeasonDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCuttingNew(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " select  JO.Joborderid,JO.SRNO   from JobOrderdatabase jo"
            str &= " join SeasonDatabase sd on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= " where sd.SeasonDatabaseID=" & SeasonDatabaseID
            str &= "   order by jo.SRNOPOne ,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function temSRNOTbaleTruncate() As DataTable
            Dim str As String
            str = " truncate table   TemSRNO"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorForCutting(ByVal seasondatabaseid As Long, ByVal JobOrderId As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderdatabase jo"
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid "
            str &= " where jo.Joborderid='" & JobOrderId & "' and Jo.seasondatabaseid='" & seasondatabaseid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorForCuttingWithoutJoborderId(ByVal seasondatabaseid As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderdatabase jo"
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid "
            str &= " where Jo.seasondatabaseid='" & seasondatabaseid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorForCommericalPacking(ByVal CargoID As Long, ByVal JobOrderId As Long) As DataTable
            Dim str As String
            str = " select * from Cargo C"
            str &= " join CargoDetail CC on CC.CargoID =C.CargoID "
            str &= " join JobOrderdatabase Jo on JO.Joborderid =CC.POPOID  "
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid And JOD.JoborderDetailid = CC.POID"
            str &= " where C.CargoID='" & CargoID & "' and Jo.Joborderid='" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeForCommericalPacking(ByVal CargoID As Long, ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = " select * from Cargo C"
            str &= " join CargoDetail CC on CC.CargoID =C.CargoID "
            str &= " join JobOrderdatabase Jo on JO.Joborderid =CC.POPOID "
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid And JOD.JoborderDetailid = CC.POID "
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderID =JO.Joborderid AND SAM.JoborderDetailid =JOD.JoborderDetailid"
            str &= " JOIN  StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID =SAM.StyleAssortmentMasterID "
            str &= " where C.CargoID='" & CargoID & "' and Jo.Joborderid='" & JobOrderId & "' and JOD.JoborderDetailid='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleForCommericalPacking(ByVal CargoID As Long, ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = " select * from Cargo C"
            str &= " join CargoDetail CC on CC.CargoID =C.CargoID "
            str &= " join JobOrderdatabase Jo on JO.Joborderid =CC.POPOID "
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid And JOD.JoborderDetailid = CC.POID "
            str &= " where C.CargoID='" & CargoID & "' and Jo.Joborderid='" & JobOrderId & "' and JOD.JoborderDetailid='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleForCutting(ByVal seasondatabaseid As Long, ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String

            str = " select * from JobOrderdatabase jo"
            str &= " join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid "
            str &= " where jo.Joborderid='" & JobOrderId & "' and Jo.seasondatabaseid='" & seasondatabaseid & "'and JOD.JoborderDetailid='" & JoborderDetailid & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTotalQuantityForCutting(ByVal seasondatabaseid As Long, ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String

            str = " select isnull(SUM(dtl.TotalQty),0) as Quantity from DPCuttingProMaster mst"
            str &= " join DPCuttingProDetail Dtl On dtl.CuttingProMasterID =mst.CuttingProMasterID"
            str &= "  join JobOrderdatabase jo on jo.Joborderid =mst.JobOrderID "
            str &= " where mst.Joborderid='" & JobOrderId & "' and Jo.seasondatabaseid='" & seasondatabaseid & "'and mst.JoborderDetailid='" & JoborderDetailid & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAlreadyCutForCutting(ByVal seasondatabaseid As Long, ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String

            str = "  select isnull(SUM(Dtl.Todaycut),0) as TodayQty from TodayCuttingMst mst"
            str &= " join TodayCuttingDtl Dtl on Dtl.TodayCuttingMstID =mst.TodayCuttingMstID "
            str &= " where Dtl.Joborderid='" & JobOrderId & "' and mst.seasondatabaseid='" & seasondatabaseid & "'"
            str &= " and Dtl.JoborderDetailid='" & JoborderDetailid & "'"

            'str = " select isnull(SUM(mst.TodayQty),0) as TodayQty from TodayCuttingMst mst"
            'str &= " where mst.Joborderid='" & JobOrderId & "' and mst.seasondatabaseid='" & seasondatabaseid & "'and mst.JoborderDetailid='" & JoborderDetailid & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetsrnoForPanal(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " Select * from JobOrderdatabase "
            str &= " where SeasonDatabaseID=" & SeasonDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditForPanal(ByVal PanalMstID As Long) As DataTable
            Dim str As String
            str = "  select *,convert(varchar,dTL.PanalDate,103) as PanalDatee  from PanalMst Mst join "
            str &= " PanalDtl dTL ON dTL.PanalMstID=Mst.PanalMstID"
            str &= " where Mst.PanalMstID=" & PanalMstID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInvoiceDate(ByVal CargoID As Long) As DataTable
            Dim str As String
            str = " Select * from Cargo "
            str &= " where CargoID=" & CargoID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditData(ByVal ShipmentID As Long) As DataTable
            Dim str As String
            str = " Select * "
            str &= " from Shipment C"
            str &= " join Cargo CD on CD.CargoID =C.CargoID"
            str &= " where C.ShipmentID=" & ShipmentID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetInvoiceData(ByVal CargoID As Long) As DataTable
            Dim str As String
            str = " Select *,isnull((SELECT sum(CDD.Quantity)  FROM Cargodetail CDD where CDD.CargoID =c.CargoID),0)"
            str &= " as Qty"
            str &= " from Cargo C"
            str &= " join Cargodetail CD on CD.CargoID =C.CargoID"
            str &= " join Customer CC on CC.CustomerID =CD.CustomerID  "
            str &= " join Currency CUR on CUR.CurrencyID =C.Currencyid  "
            str &= "  join ShipmentMode SM on SM.ShipmentModeID =C.ShipModeID "
            str &= "  join JobOrderdatabase JO on JO.JoborderID =CD.POPOID "
            str &= "  join DeliveryTerm DT on DT.DeliveryTermID =JO.DeliveryTermID "
            str &= " where C.CargoID=" & CargoID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPortOrigin() As DataTable
            Dim str As String
            str = " Select * from PortOrigin "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPortLoad() As DataTable
            Dim str As String
            str = " Select * from PortLoad "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDeliveryTerm() As DataTable
            Dim str As String
            str = " Select * from DeliveryTerm "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPortDestinations() As DataTable
            Dim str As String
            str = " Select * from PortDestinations "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizesS() As DataTable
            Dim str As String
            str = " Select * from SizeDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function View() As DataTable
            Dim str As String
            str = " Select * from SizeRange  SR "
            str &= " join SizeRangeDetail SRD on SRD.SizeRangeID=SR.SizeRangeID"
            str &= " join SizeDatabase SD on SD.SizeDatabaseID=SRD.SizeDatabaseID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGender1() As DataTable
            Dim str As String
            str = " Select * from Gender1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = " Select * from SizeRange  SR "
            str &= " join SizeRangeDetail SRD on SRD.SizeRangeID=SR.SizeRangeID"
            str &= " join SizeDatabase SD on SD.SizeDatabaseID=SRD.SizeDatabaseID"
            str &= " where SR.SizeRangeID=" & SizeRangeID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadSizeGroup() As DataTable
            Dim str As String
            str = "  Select Distinct SizeGroup from SizeRange  SR   order by SizeGroup ASC   "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadSizeGroupN(ByVal BrandDatabaseID As Long) As DataTable
            Dim str As String
            str = "  Select Distinct SizeGroup from SizeRange SR  where BrandDatabaseID=" & BrandDatabaseID
            str &= "  order by SizeGroup ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadSizeRange(ByVal SizeGroup As String) As DataTable
            Dim str As String
            str = " Select * from SizeRange where SizeGroup='" & SizeGroup & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SizeRangeSizes(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = " Select * from SizeRange  SR "
            str &= " join SizeRangeDetail SRD on SRD.SizeRangeID=SR.SizeRangeID"
            str &= " join SizeDatabase SD on SD.SizeDatabaseID=SRD.SizeDatabaseID"
            str &= " where SR.SizeRangeID=" & SizeRangeID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditSA(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = " Select * from SizeRange  SR "
            str &= " join SizeRangeDetail SRD on SRD.SizeRangeID=SR.SizeRangeID"
            str &= " join SizeDatabase SD on SD.SizeDatabaseID=SRD.SizeDatabaseID"
            str &= " where SR.SizeRangeID=" & SizeRangeID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadSizeRangeFirstTime(ByVal SizeGroup As String, ByVal SizeRange As String) As DataTable
            Dim str As String
            str = " Select * from SizeRange where SizeGroup='" & SizeGroup & "' and SizeRange='" & SizeRange & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadSizeRangeEditTime(ByVal SizeGroup As String, ByVal SizeRange As String, ByVal SizeRangeID As String) As DataTable
            Dim str As String
            str = " Select * from SizeRange where SizeGroup='" & SizeGroup & "' and SizeRange='" & SizeRange & "' and SizeRangeID <>" & SizeRangeID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGender() As DataTable
            Dim str As String
            str = " Select * from Gender "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
