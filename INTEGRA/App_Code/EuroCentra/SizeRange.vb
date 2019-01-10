Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class SizeRange
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SizeRange"
            m_strPrimaryFieldName = "SizeRangeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSizeRangeID As Long
        Private m_strGender As String
        Private m_strSizeGroup As String
        Private m_strSizeRange As String

        Public Property SizeRangeID() As Long
            Get
                SizeRangeID = m_lSizeRangeID
            End Get
            Set(ByVal Value As Long)
                m_lSizeRangeID = Value
            End Set
        End Property
        Public Property Gender() As String
            Get
                Gender = m_strGender
            End Get
            Set(ByVal value As String)
                m_strGender = value
            End Set
        End Property
        Public Property SizeGroup() As String
            Get
                SizeGroup = m_strSizeGroup
            End Get
            Set(ByVal value As String)
                m_strSizeGroup = value
            End Set
        End Property
        Public Property SizeRange() As String
            Get
                SizeRange = m_strSizeRange
            End Get
            Set(ByVal value As String)
                m_strSizeRange = value
            End Set
        End Property

        Public Function SaveSizeRange()
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
        Public Function GetSeasonsForJobOrderVieeSearchingGetSeasonId() As DataTable
            Dim str As String
            str = " Select top 1 SD.SeasonDatabaseID from SeasonDatabase SD join JobOrderdatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID join StyleAssortmentMaster SA on SA.JobOrderID =JO.Joborderid order by SD.SeasonDatabaseID Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonsForJobOrderVieeSearchingGetSeasonIdNeweeeeee() As DataTable
            Dim str As String
            str = " Select top 1 SD.SeasonDatabaseID from SeasonDatabase SD  order by SD.SeasonDatabaseID Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonsForJobOrderVieeSearchingGetSeasonIdNew() As DataTable
            Dim str As String
            str = " Select top 1 SD.SeasonDatabaseID from SeasonDatabase SD join JobOrderdatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID join StyleAssortmentMaster SA on SA.JobOrderID =JO.Joborderid order by SD.SeasonDatabaseID Desc"
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
        Public Function GetSeasonsForJobOrderVieeSearchingNew() As DataTable
            Dim str As String
            str = " Select Distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD join JobOrderdatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID  "
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
        Public Function GetCustomerDatabaseNew() As DataTable
            Dim str As String
         

            str = "   select distinct c.CustomerID ,c.CustomerName  from Customer c"
            str &= " join NumberingFinal jo on jo.CustomerID =c.CustomerID "

            Try

                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletePackingDetail(ByVal PackingDtlId As Long)
            Dim Str As String
            Str = " Delete from PackingDtl where PackingDtlId=" & PackingDtlId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerDatabase() As DataTable
            Dim str As String
            str = " select distinct c.CustomerID ,c.CustomerName  from Customer c"
            str &= " join JobOrderdatabase jo on jo.CustomerDatabaseID =c.CustomerID "

          

            Try

                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerViseData(ByVal seasondatabaseid As Long) As DataTable
            Dim Str As String
            Str = " SELECT  c.CustomerID ,c.CustomerName "
            Str &= " ,sum((jod.Quantity)) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where jo.seasondatabaseid = " & seasondatabaseid
            Str &= " group by c.CustomerName,c.CustomerID  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSRNODataDistinct(ByVal seasondatabaseid As Long) As DataTable
            Dim Str As String
            Str = " select  distinct TOP 15 Jo.Joborderid ,jo.srno  from PODetail pod"
            Str &= " join JobOrderdatabase Jo on JO.Joborderid =pod.Joborderid"
            Str &= " join POMaster pom on pom.POID =pod.POID"
            Str &= " where POM.FabricPOrder=1 AND jo.seasondatabaseid = " & seasondatabaseid

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSRNODataDistinctAstore(ByVal seasondatabaseid As Long) As DataTable
            Dim Str As String
            Str = " select  distinct TOP 15 Jo.Joborderid ,jo.srno  from PODetail pod"
            Str &= " join JobOrderdatabase Jo on JO.Joborderid =pod.Joborderid"
            Str &= " join POMaster pom on pom.POID =pod.POID"
            Str &= " where POM.FabricPOrder=0 AND jo.seasondatabaseid = " & seasondatabaseid

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSRNOData(ByVal seasondatabaseid As Long) As DataTable
            Dim Str As String
            Str = " select  distinct  Jo.Joborderid ,jo.srno  from PODetail pod"
            Str &= " join JobOrderdatabase Jo on JO.Joborderid =pod.Joborderid"
            Str &= " join POMaster pom on pom.POID =pod.POID"
            Str &= " where jo.seasondatabaseid = " & seasondatabaseid

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSRNODataNew(ByVal seasondatabaseid As Long, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Dim Str As String
            Str = " select  distinct  Jo.Joborderid ,jo.srno  from PODetail pod"
            Str &= " join JobOrderdatabase Jo on JO.Joborderid =pod.Joborderid"
            Str &= " join POMaster pom on pom.POID =pod.POID"
            Str &= " where POM.FabricPOrder=1 and POM.CreationDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' and jo.seasondatabaseid = " & seasondatabaseid

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSRNODataNewAstore(ByVal seasondatabaseid As Long, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Dim Str As String
            Str = " select  distinct  Jo.Joborderid ,jo.srno  from PODetail pod"
            Str &= " join JobOrderdatabase Jo on JO.Joborderid =pod.Joborderid"
            Str &= " join POMaster pom on pom.POID =pod.POID"
            Str &= " where POM.FabricPOrder=0 and POM.CreationDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' and jo.seasondatabaseid = " & seasondatabaseid

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerNameByFilterData() As DataTable
            Dim Str As String
            Str = " SELECT distinct c.CustomerID ,c.CustomerName "
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " where  jod.StyleShipmentDate  between '01/01/2018' and '12/31/2018' "
            Str &= " order by c.CustomerName asc  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerNameByFilterDataNew() As DataTable
            Dim Str As String
            Str = " SELECT distinct c.CustomerID ,c.CustomerName "
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " order by c.CustomerName asc  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltring(ByVal Year As String, ByVal Month As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  (isnull(sum(jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster "
            Str &= " SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 "
            Str &= " +sum(jod.Quantity) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and Month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Str &= " and c.CustomerID ='" & CustomerId & "' "
            Str &= " group by c.CustomerName,c.CustomerID,jo.Joborderid ,jod.JoborderDetailid  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringInventoryPosition(ByVal Type As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String

            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Str &= " where  jo.CustomerDatabaseID ='" & CustomerId & "' "
            If Type = "All" Then
            ElseIf Type = "Fabric Store" Then
                Str &= " and PM.FabricPOrder =1 "
            ElseIf Type = "Accessories Store" Then
                Str &= " and PM.FabricPOrder =0  "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringInventoryPositionOtherCase(ByVal Type As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String

            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Str &= "  join tempInventoryPositionSrno Temp on Temp.No =jo.SrNo "
            Str &= " where  jo.CustomerDatabaseID ='" & CustomerId & "' "
            If Type = "All" Then
            ElseIf Type = "Fabric Store" Then
                Str &= " and PM.FabricPOrder =1 "
            ElseIf Type = "Accessories Store" Then
                Str &= " and PM.FabricPOrder =0  "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringInventoryPositionForIssue(ByVal Type As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String

            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Str &= " where  jo.CustomerDatabaseID ='" & CustomerId & "' "
            If Type = "All" Then
            ElseIf Type = "Fabric Store" Then
                Str &= " and PM.FabricPOrder =1 "
            ElseIf Type = "Accessories Store" Then
                Str &= " and PM.FabricPOrder =0  "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringInventoryPositionForIssueOtherCase(ByVal Type As String, ByVal CustomerId As Long) As DataTable
            Dim Str As String

            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Str &= "  join tempInventoryPositionSrno Temp on Temp.No =jo.SrNo "
            Str &= " where  jo.CustomerDatabaseID ='" & CustomerId & "' "
            If Type = "All" Then
            ElseIf Type = "Fabric Store" Then
                Str &= " and PM.FabricPOrder =1 "
            ElseIf Type = "Accessories Store" Then
                Str &= " and PM.FabricPOrder =0  "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringInventoryPositionSrNoVise(ByVal Type As String, ByVal JoborderId As Long) As DataTable
            Dim Str As String

            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Str &= " where  jo.JoborderId ='" & JoborderId & "' "
            If Type = "All" Then
            ElseIf Type = "Fabric Store" Then
                Str &= " and PM.FabricPOrder =1 "
            ElseIf Type = "Accessories Store" Then
                Str &= " and PM.FabricPOrder =0  "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringInventoryPositionSrNoViseIssue(ByVal Type As String, ByVal JoborderId As Long) As DataTable
            Dim Str As String
            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Str &= " where  jo.JoborderId ='" & JoborderId & "' "
            If Type = "All" Then
            ElseIf Type = "Fabric Store" Then
                Str &= " and PM.FabricPOrder =1 "
            ElseIf Type = "Accessories Store" Then
                Str &= " and PM.FabricPOrder =0  "
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringForSelectCustomer(ByVal Year As String, ByVal Month As String, ByVal CustomerId As Long, ByVal JoborderId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  (isnull(sum(jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster "
            Str &= "  SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 "
            Str &= "  +sum(jod.Quantity) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and Month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Str &= " and c.CustomerId ='" & CustomerId & "' and JO.JoborderId= '" & JoborderId & "'"
            Str &= " group by c.CustomerName,c.CustomerID,jo.Joborderid ,jod.JoborderDetailid  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringForSelectCustomerOLDDDDD(ByVal CustomerId As Long, ByVal JoborderId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  (isnull(sum(jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster "
            Str &= "  SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 "
            Str &= "  +sum(jod.Quantity) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            Str &= " and c.CustomerId ='" & CustomerId & "' and JO.JoborderId= '" & JoborderId & "'"
            Str &= " group by c.CustomerName,c.CustomerID,jo.Joborderid ,jod.JoborderDetailid  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltring8888888888(ByVal SeasonDatabaseId As Long, ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  (isnull(sum(jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster "
            Str &= " SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 "
            Str &= " +sum(jod.Quantity) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            Str &= " and JO.SeasonDatabaseId ='" & SeasonDatabaseId & "' "
            Str &= " and c.CustomerID ='" & CustomerId & "' "
            Str &= " group by c.CustomerName,c.CustomerID,jo.Joborderid ,jod.JoborderDetailid  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltring8888888888AllCase(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  (isnull(sum(jod.Quantity),0) * isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster "
            Str &= " SAM where SAM.joborderId=jo.joborderId and SAM.joborderdetailid=jod.joborderdetailid ),0)) /100 "
            Str &= " +sum(jod.Quantity) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2018' and '12/31/2018' "
            Str &= " and c.CustomerID ='" & CustomerId & "' "
            Str &= " group by c.CustomerName,c.CustomerID,jo.Joborderid ,jod.JoborderDetailid  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForReceiveInChartFstore(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Str &= " where PM.FabricPORder=1  and jo.CustomerDatabaseID ='" & CustomerId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForReceiveInChartAllCaseAllData() As DataTable
            Dim Str As String
            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForReceiveInChartAllCase(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Str &= " where  jo.CustomerDatabaseID ='" & CustomerId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForReceiveInChartAstore(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = " select  "
            Str &= "  isnull(sum((IMD.RecvQuantity)*(pod.Rate * pod.ExchangeRate)),0) as Amount  "
            Str &= "  from PORecvMaster IMI  "
            Str &= "  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID "
            Str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID "
            Str &= "   join IMSItem IM on IM.IMSItemId= pod.ItemId  "
            Str &= "   join Location L on L.LocationId= IMI.LocationId  "
            Str &= "   join POMaster PM on PM.POID= IMI.POID  "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMI.joborderid "
            Str &= " where PM.FabricPORder=0  and jo.CustomerDatabaseID ='" & CustomerId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForIssueInChartFstore(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Str &= " where PM.FabricPORder=1  and jo.CustomerDatabaseID ='" & CustomerId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForIssueInChartAllCASE(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Str &= " where  jo.CustomerDatabaseID ='" & CustomerId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForIssueInChartAllCASEAllData() As DataTable
            Dim Str As String
            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForIssueInChartAstore(ByVal CustomerId As Long) As DataTable
            Dim Str As String
            Str = "  select    "
            Str &= " isnull(sum(IMD.IssueQty*IMD.Rate),0) as Amount "
            Str &= " from IssueMst IMI "
            Str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID  "
            Str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            Str &= "  join Location L on L.LocationId= IMI.LocationId  "
            Str &= "  join POMaster pm on pm.POID= IMD.POID "
            Str &= "  join JobOrderdatabase jo on jo.Joborderid =IMD.joborderid "
            Str &= " where PM.FabricPORder=0  and jo.CustomerDatabaseID ='" & CustomerId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSeasonVise(ByVal SeasonDatabaseId As Long) As DataTable
            Dim Str As String
            Str = " SELECT distinct c.CustomerID ,c.CustomerName  "
            Str &= " FROM JOBORDERDATABASE JO "
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid "
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID"
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            Str &= " and JO.SeasonDatabaseId ='" & SeasonDatabaseId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSeasonViseAllCase() As DataTable
            Dim Str As String
            Str = " SELECT distinct c.CustomerID ,c.CustomerName  "
            Str &= " FROM JOBORDERDATABASE JO "
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid "
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID"
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2018' and '12/31/2018' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSeasonViseAllCaseNew() As DataTable
            Dim Str As String
            Str = " SELECT distinct  c.CustomerID ,c.CustomerName  "
            Str &= " FROM JOBORDERDATABASE JO "
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid "
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID"
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2018' and '12/31/2018' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSeasonViseAllCaseNewStoreDashboardNeww(ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Dim Str As String
  
            Str = "  select distinct top 10 c.CustomerID ,c.CustomerName from joborderdatabase jo"
            Str &= " join Customer C on C.CustomerID =JO.CustomerDatabaseID "
            Str &= " LEFT join PORecvMaster RM on rm.JobOrderID =jo.Joborderid"
            Str &= " left join IssueDetail id on id.JobOrderID =jo.Joborderid "
            Str &= "  where RM.PORecvDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'"
            Str &= "  order by c.CustomerID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSeasonViseAllCaseNewStoreDashboard() As DataTable
            Dim Str As String
            'Str = " select distinct top 6 c.CustomerID ,c.CustomerName  from PODetail dtl"
            'Str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.joborderid"
            'Str &= " join customer c on c.CustomerID  =jo.CustomerDatabaseID "
            'Str &= " order by c.CustomerID desc"

            Str = "  select distinct  c.CustomerID ,c.CustomerName from joborderdatabase jo"
            Str &= " join Customer C on C.CustomerID =JO.CustomerDatabaseID "
            Str &= " LEFT join PORecvMaster RM on rm.JobOrderID =jo.Joborderid"
            Str &= " left join IssueDetail id on id.JobOrderID =jo.Joborderid "
            Str &= "  order by c.CustomerID desc"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltring(ByVal Year As String, ByVal Month As String) As DataTable
            Dim Str As String
            Str = " SELECT distinct c.CustomerID ,c.CustomerName  "
            Str &= " FROM JOBORDERDATABASE JO "
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid "
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID"
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and Month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSearch() As DataTable
            Dim Str As String
            Str = " SELECT * "
            Str &= " FROM tempCustomerFiltering  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSearchgetCustomername() As DataTable
            Dim Str As String
            Str = " SELECT * "
            Str &= " FROM tempInventoryPositionCustomer  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctSupplierNameeee(ByVal Type As String) As DataTable
            Dim Str As String
            Str = "  select DISTINCT SD.SupplierDatabaseId ,SD.SupplierName  from pomaster pm "
            Str &= " join podetail pd on pd.poid=pm.poid "
            Str &= "  join SupplierDatabase SD on SD.SupplierDatabaseId =PD.AccountPayablePartyID  "
            If Type = "Fabric Store" Then
                Str &= "  where PM.FabricPOrder =1"
            Else
                Str &= "  where PM.FabricPOrder =0"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerFiltringSearchgetSrnoVise() As DataTable
            Dim Str As String
            Str = " SELECT * "
            Str &= " FROM tempInventoryPositionSrno  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDistinctCustomerIdsss() As DataTable
            Dim Str As String
            Str = " SELECT distinct c.CustomerID ,c.CustomerName  FROM JobOrderdatabase jo"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID "
            Str &= " left join PORecvMaster prm on prm.JobOrderID =jo.Joborderid "
            Str &= " left join IssueDetail id on id.JobOrderID =jo.Joborderid"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDataForCustomerFiltringWithCustomer(ByVal Year As String, ByVal Month As String) As DataTable
            Dim Str As String
            Str = " SELECT  c.CustomerID ,c.CustomerName "
            Str &= " ,sum((jod.Quantity)) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " join tempCustomerFiltering cc on cc.No =c.CustomerName  "
            Str &= " where "
            Str &= " jod.StyleShipmentDate  between '01/01/2000' and '01/01/2090' "
            If Year <> "All" Then
                Str &= " and year(jod.StyleShipmentDate) ='" & Year & "' "
            End If
            If Month <> "All" Then
                Str &= " and Month(jod.StyleShipmentDate) ='" & Month & "' "
            End If
            Str &= " group by c.CustomerName,c.CustomerID  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerViseAllData(ByVal seasondatabaseid As Long) As DataTable
            Dim Str As String
            Str = " SELECT  "
            Str &= " sum((jod.Quantity)) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where jo.seasondatabaseid = " & seasondatabaseid

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerId(ByVal CustomerName As String) As DataTable
            Dim Str As String
            Str = " SELECT  * "
            Str &= "  FROM Customer "
            Str &= " where CustomerName = '" & CustomerName & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetJobOrderId(ByVal SrNo As String) As DataTable
            Dim Str As String
            Str = " SELECT  * "
            Str &= "  FROM JobOrderDatabase "
            Str &= " where SrNo = '" & SrNo & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerViseAllDataAllCase() As DataTable
            Dim Str As String
            Str = " SELECT  "
            Str &= " sum((jod.Quantity)) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where jod.StyleShipmentDate between '01/01/2018' and '12/31/2018'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerViseAllDataByFilterData(ByVal seasondatabaseid As Long) As DataTable
            Dim Str As String
            Str = " SELECT  "
            Str &= " sum((jod.Quantity)) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerViseAllDataByFilterDataNewww(ByVal CustomerDatabaseId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  "
            Str &= " sum((jod.Quantity)) as Quantity"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " where JO.CustomerDatabaseId = '" & CustomerDatabaseId & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetJobOrderNoo(ByVal JobOrderId As Long) As DataTable
            Dim Str As String

            Str = " SELECT  "
            Str &= " *"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " where JO.JobOrderId = '" & JobOrderId & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSrNoForChart(ByVal CustomerDatabaseId As Long, ByVal SeasonDatabaseId As Long) As DataTable
            Dim Str As String
            Str = " SELECT  "
            Str &= " distinct jo.Joborderid ,jo.SRNO"
            Str &= "  FROM JOBORDERDATABASE JO"
            Str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            Str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            Str &= " join tempCustomerFiltering cc on cc.No =JO.SRNO  "
            Str &= " where JO.CustomerDatabaseId = '" & CustomerDatabaseId & "' AND JO.SeasonDatabaseId= '" & SeasonDatabaseId & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetShipmentNoNew(ByVal CustomerDatabaseID As Long, ByVal Customerpono As String) As DataTable
            Dim str As String
            str = " select distinct N.NumberingFinalID,N.ReceivingNo from  NumberingFinal N"
            str &= " where N.CustomerID='" & CustomerDatabaseID & "' and N.Customerpono='" & Customerpono & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetShipmentNo(ByVal CustomerDatabaseID As Long, ByVal Customerpono As String) As DataTable
            Dim str As String
            str = " select distinct N.NumberingFinalID,N.ReceivingNo from  NumberingFinal N"
            str &= " where N.CustomerID='" & CustomerDatabaseID & "' and N.Customerpono='" & Customerpono & "' and N.NumberingFinalID not in (select NumberingFinalID from PackingDtl)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerPONo(ByVal CustomerDatabaseID As Long) As DataTable
            Dim str As String
            str = " select distinct N.CustomerPONo from  NumberingFinal N"
            str &= " where N.CustomerID=" & CustomerDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetWeight(ByVal NumberingFinalID As Long) As DataTable
            Dim str As String
            'str = " select sum((convert(int,dtl.PcsPerCarton)) * DTL.Weight) as TotalWeightfrom from Numbering N"
            'str &= " JOIN NumberingDtl DTL ON DTL.NumberingID =N.NumberingID"
            'str &= " where n.NumberingID=" & NumberingID

            str = "  select isnull(sum((convert(int,dtl.PcsPerCarton)) * DTL.Weight),0) as TotalWeightfrom from NumberingFinal N"
            str &= " JOIN NumberingFinalDtl DTL ON DTL.NumberingFinalID =N.NumberingFinalID"
            str &= " where n.NumberingFinalID=" & NumberingFinalID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingDataNew2(ByVal NumberingFinalID As Long) As DataTable
            Dim str As String
         
            str = "  select *,"
            str &= " (SELECT  top 1 jod.Style   FROM NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on"
            str &= " jod.JoborderDetailid = dtl.JoborderDetailid"
            str &= "  where N.NumberingID "
            str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as Style,"
            str &= " (SELECT  top 1 jod.BuyerColor   FROM NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on"
            str &= "  jod.JoborderDetailid = dtl.JoborderDetailid"
            str &= "  where N.NumberingID"
            str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as BuyerColor,Dtl.Weight as Weightt,Dtl.CartonNo as CartonNoo"
            str &= " ,*  from NumberingFinal N"
            str &= " join NumberingFinalDtl Dtl on Dtl.NumberingFinalID=N.NumberingFinalID"
            str &= " where Dtl.DonePacking=0 and dtl.SelectPacking =1 and N.NumberingFinalID=" & NumberingFinalID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingData(ByVal NumberingFinalID As Long) As DataTable
            Dim str As String
            'str = " select (SELECT  sum(convert(int,dtl.PcsPerCarton))  FROM NumberingDtl Dtl where N.NumberingID "
            'str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as Qty,"
            'str &= " (SELECT  COUNT(dtl.NumberingDtlID)  FROM NumberingDtl Dtl where N.NumberingID "
            'str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as NoOfCarton,"
            'str &= " (SELECT  top 1 jod.Style   FROM NumberingDtl Dtl join JobOrderdatabaseDetail jod on"
            'str &= "  jod.JoborderDetailid = dtl.JoborderDetailid"
            'str &= "  where(N.NumberingID)"
            'str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as Style,"
            'str &= " (SELECT  top 1 jod.BuyerColor   FROM NumberingDtl Dtl join JobOrderdatabaseDetail jod on"
            'str &= " jod.JoborderDetailid = dtl.JoborderDetailid"
            'str &= " where N.NumberingID"
            'str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as BuyerColor,"
            'str &= " *  from Numbering N"
            'str &= " where N.NumberingID=" & NumberingID




            str = "  select *,"
            str &= " (SELECT  top 1 jod.Style   FROM NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on"
            str &= " jod.JoborderDetailid = dtl.JoborderDetailid"
            str &= "  where N.NumberingID "
            str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as Style,"
            str &= " (SELECT  top 1 jod.BuyerColor   FROM NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on"
            str &= "  jod.JoborderDetailid = dtl.JoborderDetailid"
            str &= "  where N.NumberingID"
            str &= " =dtl.NumberingID and dtl.SelectNumbering =1) as BuyerColor,"
            str &= " *  from NumberingFinal N"
            str &= " where N.NumberingFinalID=" & NumberingFinalID

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
            str = " select DISTINCT JO.Joborderid,JO.PONO   from JobOrderdatabase jo"
            str &= " join SeasonDatabase sd on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= " where sd.SeasonDatabaseID=" & SeasonDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSRNOOOOOO() As DataTable
            Dim str As String
            str = " select *   from tempPurchasingSummarySrno "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierForSamples() As DataTable
            Dim str As String

            str = " select distinct sd.SupplierDatabaseId ,sd.SupplierName  from DPFabricDbMst mst"
            str &= "  join SupplierDatabase sd on sd.SupplierDatabaseId =mst.SupplierID"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCuttingNewgetSRNO(ByVal CustomerDatabaseID As Long) As DataTable
            Dim str As String
            str = " SELECT distinct JO.Joborderid  ,jo.SRNO  "
            str &= "  FROM JOBORDERDATABASE JO"
            str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID  "
            str &= " JOIN JobOrderdatabaseDetail  jod on jod.joborderid=jo.joborderid"
            str &= " WHERE jod.StyleShipmentDate  between '01/01/2018' and '12/31/2018' and jo.CustomerDatabaseID=" & CustomerDatabaseID
            str &= "   order by jo.SRNO "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCuttingNew(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " select  JO.Joborderid,JO.PONO   from JobOrderdatabase jo"
            str &= " join SeasonDatabase sd on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= " where sd.SeasonDatabaseID=" & SeasonDatabaseID
            str &= "   order by jo.PONO ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCuttingNewGetOrderNo(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = " select  JO.Joborderid,JO.SRNO   from JobOrderdatabase jo"
            str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID "
            str &= " where c.CustomerID=" & CustomerID
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
        Public Function temSRNOTbaleTruncateForPO() As DataTable
            Dim str As String
            str = " truncate table   TemPO"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function temSRNOTbaleTruncateForPOSupplierFollowup() As DataTable
            Dim str As String
            str = " truncate table   TempSupplierFollowup"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function temSRNOTbaleTruncateOrdersTATUS() As DataTable
            Dim str As String
            str = " truncate table   TemSRNOForOrderStatus"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function tempMonthlyClosingTbaleTruncate() As DataTable
            Dim str As String
            str = " truncate table tempMonthlyClosing"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function tempCustomerFilteringTbaleTruncate() As DataTable
            Dim str As String
            str = " truncate table tempCustomerFiltering"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncatetabletempPurchasingSummarySrno() As DataTable
            Dim str As String
            str = " truncate table tempPurchasingSummarySrno"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncatetabletempTurnover() As DataTable
            Dim str As String
            str = " truncate table tempTurnOver"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncatetabletempTotalSamples() As DataTable
            Dim str As String
            str = " truncate table TempTotalSamples"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function tempInventoryPositionTruncate() As DataTable
            Dim str As String
            str = " truncate table tempInventoryPositionCustomer"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function tempInventoryPositionTruncateSrno() As DataTable
            Dim str As String
            str = " truncate table tempInventoryPositionSrno"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function tempPurchasingSummaryTruncateSrno() As DataTable
            Dim str As String
            str = " truncate table tempPurchasingSummarySrno"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function temlineBalanceTbaleTruncate() As DataTable
            Dim str As String
            str = " truncate table   TempLineBalanceReport"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function temDailyCuttingTbaleTruncate() As DataTable
            Dim str As String
            str = " truncate table   TempdailyCutting"
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
            str &= " where Dtl.Joborderid='" & JobOrderId & "' and Dtl.seasondatabaseid='" & seasondatabaseid & "'"
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
        Public Function GetStyleCategory() As DataTable
            Dim str As String
            str = " Select * from StyleCategory "
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
        Public Function CheckSizeName(ByVal Sizes As String) As DataTable
            Dim str As String
            str = " Select * from SizeDatabase where Sizes='" & Sizes & "'"
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