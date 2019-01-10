Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class DPIMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPIMst"
            m_strPrimaryFieldName = "DPIMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPIMstID As Long
        Private m_strSalesContract As String
        Private m_dPIDate As Date
        Private m_lSeasonID As Long
        Private m_lCustomerID As Long
        Private m_strSeasonNo As String
        Private m_lReportTypeID As Long
        Private m_strForaccountAndRisk As String
        Private m_strNotifyparty As String
        Private m_strPaymentTo As String
        Private m_strBrandandsection As String
        Private m_strConsignee As String
        Private m_dRevisedDate As Date
        Private m_strPaymentTerm As String
        Private m_strPortOfLoading As String
        Private m_strFinalDestination As String
        Public Property PaymentTerm() As String
            Get
                PaymentTerm = m_strPaymentTerm
            End Get
            Set(ByVal Value As String)
                m_strPaymentTerm = Value
            End Set
        End Property
        Public Property PortOfLoading() As String
            Get
                PortOfLoading = m_strPortOfLoading
            End Get
            Set(ByVal Value As String)
                m_strPortOfLoading = Value
            End Set
        End Property
        Public Property FinalDestination() As String
            Get
                FinalDestination = m_strFinalDestination
            End Get
            Set(ByVal Value As String)
                m_strFinalDestination = Value
            End Set
        End Property
        Public Property RevisedDate() As Date
            Get
                RevisedDate = m_dRevisedDate
            End Get
            Set(ByVal Value As Date)
                m_dRevisedDate = Value
            End Set
        End Property
        Public Property Consignee() As String
            Get
                Consignee = m_strConsignee
            End Get
            Set(ByVal Value As String)
                m_strConsignee = Value
            End Set
        End Property
        Public Property ForaccountAndRisk() As String
            Get
                ForaccountAndRisk = m_strForaccountAndRisk
            End Get
            Set(ByVal Value As String)
                m_strForaccountAndRisk = Value
            End Set
        End Property
        Public Property Notifyparty() As String
            Get
                Notifyparty = m_strNotifyparty
            End Get
            Set(ByVal Value As String)
                m_strNotifyparty = Value
            End Set
        End Property
        Public Property PaymentTo() As String
            Get
                PaymentTo = m_strPaymentTo
            End Get
            Set(ByVal Value As String)
                m_strPaymentTo = Value
            End Set
        End Property
        Public Property Brandandsection() As String
            Get
                Brandandsection = m_strBrandandsection
            End Get
            Set(ByVal Value As String)
                m_strBrandandsection = Value
            End Set
        End Property
        Public Property ReportTypeID() As Long
            Get
                ReportTypeID = m_lReportTypeID
            End Get
            Set(ByVal Value As Long)
                m_lReportTypeID = Value
            End Set
        End Property
        Public Property DPIMstID() As Long
            Get
                DPIMstID = m_lDPIMstID
            End Get
            Set(ByVal Value As Long)
                m_lDPIMstID = Value
            End Set
        End Property
        Public Property SalesContract() As String
            Get
                SalesContract = m_strSalesContract
            End Get
            Set(ByVal Value As String)
                m_strSalesContract = Value
            End Set
        End Property
        Public Property PIDate() As Date
            Get
                PIDate = m_dPIDate
            End Get
            Set(ByVal Value As Date)
                m_dPIDate = Value
            End Set
        End Property
        Public Property SeasonID() As Long
            Get
                SeasonID = m_lSeasonID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonID = Value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal Value As Long)
                m_lCustomerID = Value
            End Set
        End Property
        Public Property SeasonNo() As String
            Get
                Seasonno = m_strSeasonNo
            End Get
            Set(ByVal Value As String)
                m_strSeasonNo = Value
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
        Public Function GetSRNoForOrderStatusRpt() As DataTable
            Dim str As String
            str = " select * from JobOrderdatabase "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItem() As DataTable
            Dim str As String
            str = " select * from IMSItem "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSItemCategory() As DataTable
            Dim str As String
            str = "   select distinct IMSItemCategoryID ,ItemCategoryname from IMSItemCategory  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonNameForOrderStatusRpt() As DataTable
            Dim str As String
            str = " select distinct sd.seasondatabaseId,sd.seasonname from joborderdatabase jo"
            str &= " join seasondatabase sd on sd.seasondatabaseId=jo.seasondatabaseId "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerNameForOrderStatusRpt() As DataTable
            Dim str As String
            str = " select distinct sd.CustomerId,sd.Customername from joborderdatabase jo"
            str &= " join Customer sd on sd.CustomerId=jo.CustomerdatabaseId "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerNameForShipmentSchedule() As DataTable
            Dim str As String
            str = " select * from Shipment Mst"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierForShipmentShedule() As DataTable
            Dim str As String
            str = " select distinct sd.SeasonDatabaseId,sd.Seasonname from joborderdatabase jo"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseId=jo.SeasonDatabaseId "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SeasonnoNew()
            Dim str As String
            str = " select top 1 SeasonNo from DPIMST order by SeasonNo desc"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetReportType() As DataTable
            Dim str As String
            str = " Select * from ReportType "
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
        Public Function GetSeasonsForExport() As DataTable
            Dim str As String
            str = " Select distinct Mst.SeasonDatabaseid,Mst.Seasonname from SeasonDatabase Mst join joborderdatabase Jo on Jo.SeasonDatabaseid=Mst.SeasonDatabaseid"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPackingNo(ByVal CustomerId As Long) As DataTable
            Dim str As String
            str = " select distinct Mst.PackingMstId,PackingNo from PackingDtl dtl join PackingMst Mst on Mst.PackingMstid=dtl.PackingMstid"
            str &= " where dtl.CustomerId= '" & CustomerId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetView() As DataTable
            Dim str As String
            str = " select convert(varchar, PIDate ,103)as PIDatee,dp.CustomerID as CustomID,* from DPIMst dp"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =dp.SeasonID "
            str &= " join Customer c on c.CustomerID =dp.CustomerID "
            str &= " join DPIDtl DPT on DPT.DPIMstID=dp.DPIMstID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetViewForLCView() As DataTable
            Dim str As String
            str = " SELECT * FROM LCExportMst Mst"
            str &= " JOIN LCExportDtl Dtl On dtl.LCExportMstID =mst.LCExportMstID "
            str &= " JOIN Customer C on C.CustomerID =Dtl.CustomerID "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =DTL.SeasonDatabaseID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterLCViewPage(ByVal LCExportMstID As Long) As DataTable
            Dim str As String

            str = " SELECT * FROM LCExportMst Mst"
            str &= " JOIN LCExportDtl Dtl On dtl.LCExportMstID =mst.LCExportMstID "
            str &= " JOIN Customer C on C.CustomerID =Dtl.CustomerID "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =DTL.SeasonDatabaseID "
            str &= " where Mst.LCExportMstID= '" & LCExportMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetViewNew() As DataTable
            Dim str As String
            str = " DECLARE @listStr VARCHAR(4000)"
            str &= " SELECT  "
            str &= " @listStr =COALESCE ( COALESCE(@listStr+',' ,'') + JOD.SRNO , @listStr)"
            str &= " from DPIMst JO "
            str &= " Join DPIDtl JOD on JO.DPIMstId=JOD.DPIMstId "
            str &= "  WHERE JO.DPIMstId = JOD.DPIMstId"
            str &= " select @listStr as SRNOO ,dp.DPIMstID,dp.SeasonID,dp.SalesContract,c.CustomerName,sd.SeasonName,convert(varchar, PIDate ,103)as PIDatee"
            str &= " ,dp.CustomerID as CustomID from DPIMst dp "
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =dp.SeasonID  "
            str &= " join Customer c on c.CustomerID =dp.CustomerID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterPIViewPage(ByVal DPIMstID As Long) As DataTable
            Dim str As String

            str = " select convert(varchar, PIDate ,103)as PIDatee,dp.CustomerID as CustomID,* from DPIMst dp"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =dp.SeasonID "
            str &= " join Customer c on c.CustomerID =dp.CustomerID "
            str &= " join DPIDtl DPT on DPT.DPIMstID=dp.DPIMstID"
            str &= " where dp.DPIMstID= '" & DPIMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterStyleLCViewPage(ByVal LCExportMstID As Long) As DataTable
            Dim str As String

            str = " Select Distinct SRNO from  LCExportDtl "
            str &= " where LCExportMstID= '" & LCExportMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterStylePIViewPage(ByVal DPIMstID As Long) As DataTable
            Dim str As String

            str = " Select Distinct SRNO from  DPIDtl "
            str &= " where DPIMstID= '" & DPIMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomer(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = " select distinct c.CustomerID ,c.CustomerName ,Jo.SeasonDatabaseID  from JobOrderdatabase jo"
            str &= " join Customer c on c.CustomerID =jo.CustomerDatabaseID "
            str &= " where jo.SeasonDatabaseID ='" & SeasonDatabaseID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingSRNOforPI(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " select *  from  DPIDtl"
            str &= " where Joborderid ='" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedPIDetail(ByVal DPIDtlID As Long)
            Dim str As String
            str = " Delete  from DPIDtl where DPIDtlID ='" & DPIDtlID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSRNo(ByVal SeasonDatabaseID As Long, ByVal CustomerDatabaseID As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderdatabase Jo"
            str &= " where jo.SeasonDatabaseID ='" & SeasonDatabaseID & "' and jo.CustomerDatabaseID ='" & CustomerDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSaleaContract(ByVal Seasonno As String, ByVal Season As String) As DataTable
            Dim str As String
            str = "  select '" & Seasonno & "' +'/'+ '" & Season & "' +'/2016'+ as SalesCont  from DPIMst "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        'Public Function GetBuyer() As DataTable
        '    Dim str As String
        '    str = " select Distinct c.CustomerName ,jo.CustomerDatabaseID  from JobOrderdatabase Jo"
        '    str &= " join Customer C on C.CustomerID=Jo.CustomerDatabaseID "

        '    Try
        '        Return MyBase.GetDataTable(str)
        '    Catch ex As Exception

        '    End Try
        'End Function

        'Public Function GetStyle() As DataTable
        '    Dim str As String
        '    str = " select Distinct jod.Style from JobOrderdatabase Jo"
        '    str &= " join JobOrderdatabaseDetail JOD on JOD.JobOrderId=Jo.JobOrderId"

        '    Try
        '        Return MyBase.GetDataTable(str)
        '    Catch ex As Exception

        '    End Try
        'End Function



        'Public Function GetSRNo() As DataTable
        '    Dim str As String
        '    str = " select Distinct jo.SRNO     from JobOrderdatabase Jo"

        '    Try
        '        Return MyBase.GetDataTable(str)
        '    Catch ex As Exception

        '    End Try
        'End Function


        'Public Function GetStyle() As DataTable
        '    Dim str As String
        '    str = " select Distinct jod.Style from JobOrderdatabase Jo"
        '    str &= " join JobOrderdatabaseDetail JOD on JOD.JobOrderId=Jo.JobOrderId"

        '    Try
        '        Return MyBase.GetDataTable(str)
        '    Catch ex As Exception

        '    End Try
        'End Function



        Public Function GetBuyer() As DataTable
            Dim str As String
            str = " select Distinct c.CustomerName ,jo.CustomerDatabaseID  from JobOrderdatabase Jo"
            str &= " join Customer C on C.CustomerID=Jo.CustomerDatabaseID "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function



        Public Function GetSRNo() As DataTable
            Dim str As String
            str = " select Distinct jo.SRNO     from JobOrderdatabase Jo"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetStyle() As DataTable
            Dim str As String
            str = " select Distinct jod.Style from JobOrderdatabase Jo"
            str &= " join JobOrderdatabaseDetail JOD on JOD.JobOrderId=Jo.JobOrderId"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetOrder() As DataTable
            Dim str As String
            str = "  select distinct jo.CustomerOrder   from Cargo C"
            str &= " JOIN CargoDetail CD on CD.CargoID=C.CargoID"
            str &= " JOIN JobOrderdatabase jo ON jo.JoboRDERID=CD.popoid"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetCustomer() As DataTable
            Dim str As String
            str = " select distinct cc.CustomerName ,cd.CustomerID  from Cargo C"
            str &= " JOIN CargoDetail CD on CD.CargoID=C.CargoID"
            str &= " join Customer Cc on Cc.CustomerID=cd.CustomerID "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetInvoice() As DataTable
            Dim str As String
            str = " select distinct c.InvoiceNo  from Cargo C"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetSno() As DataTable
            Dim str As String
            str = "  select distinct jo.SRNO from Cargo C"
            str &= " JOIN CargoDetail CD on CD.CargoID=C.CargoID"
            str &= " JOIN JobOrderdatabase jo ON jo.JoboRDERID=CD.popoid"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetCustomerExport() As DataTable
            Dim str As String
            str = " select distinct cc.CustomerName ,cd.CustomerID  from Cargo C"
            str &= " JOIN CargoDetail CD on CD.CargoID=C.CargoID"
            str &= " join Customer Cc on Cc.CustomerID=cd.CustomerID "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetInvoiceExport() As DataTable
            Dim str As String
            str = " select distinct c.InvoiceNo  from Cargo C"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
