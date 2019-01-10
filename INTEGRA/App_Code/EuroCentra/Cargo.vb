Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class Cargo
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Cargo"
            m_strPrimaryFieldName = "CargoID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''

        Private m_lCargoID As Long

        Private m_dtCreationDate As Date
        Private m_strInvoiceNo As String
        Private m_dtInvoiceDate As Date
        Private m_dtShipmentDate As Date
        Private m_strBillNo As String
        Private m_strRemarks As String
        Private m_bIsActive As Boolean

        Private m_strInvoiceValue As String
        Private m_strTerms As String
        Private m_strItemDescription As String
        Private m_strMode As String
        Private m_strCarrierName As String
        Private m_strVoyageFlight As String
        Private m_strContainerNo As String
        Private m_strForwarder As String

        Private m_dtETD As Date
        Private m_dtETA As Date

        Private m_dcCBM As String
        Private m_strConsolidation As String
        Private m_strContainerSize As String
        Private m_strShippingLine As String
        Private m_dcShippedExchangeRate As Decimal
        Private m_UserID As Long
        Private m_dcNetWeight As Decimal
        Private m_dcGrossWeight As Decimal
        Private m_strNetWeightUnit As String
        Private m_strGrossWeightUnit As String
        Private m_dtHandOverDate As Date
        Private m_lDestinationID As Long

        Private m_strAccountCode As String
        Private m_dcNoOfCartoon As Decimal



        Private m_strFromENO As String
        Private m_dtFromEDate As Date
        Private m_strLCNO As String
        Private m_dtDateOfIssue As Date
        Private m_strLCTerms As String
        Private m_lShipModeID As Long
        Private m_strDrawnOn As String
        Private m_strFinalDest As String

        Private m_dcWeightCTN As Decimal

        Private m_strTermOfSale As String
        Private m_strByOrderAndRisk As String
        Private m_lCurrencyid As Long
        Private m_strMarksAndNumbers As String
        Private m_strRemarksNew As String
        Private m_bWithStyleNo As Boolean
        Private m_bWithOrderNo As Boolean
        Private m_bBoth As Boolean


        Private m_strForwardingAgent As String
        Private m_dtETDDate As Date
        Private m_strClearningAgent As String

        Private m_strInvoiceNoPOne As String
        Private m_strInvoiceNoPTwo As String
        Private m_strInvoiceNoPThree As String
        Public Property InvoiceNoPOne() As String
            Get
                InvoiceNoPOne = m_strInvoiceNoPOne
            End Get
            Set(ByVal value As String)
                m_strInvoiceNoPOne = value
            End Set
        End Property
        Public Property InvoiceNoPTwo() As String
            Get
                InvoiceNoPTwo = m_strInvoiceNoPTwo
            End Get
            Set(ByVal value As String)
                m_strInvoiceNoPTwo = value
            End Set
        End Property
        Public Property InvoiceNoPThree() As String
            Get
                InvoiceNoPThree = m_strInvoiceNoPThree
            End Get
            Set(ByVal value As String)
                m_strInvoiceNoPThree = value
            End Set
        End Property
        Public Property ETDDate() As Date
            Get
                ETDDate = m_dtETDDate
            End Get
            Set(ByVal value As Date)
                m_dtETDDate = value
            End Set
        End Property
        Public Property ClearningAgent() As String
            Get
                ClearningAgent = m_strClearningAgent
            End Get
            Set(ByVal value As String)
                m_strClearningAgent = value
            End Set
        End Property
        Public Property ForwardingAgent() As String
            Get
                ForwardingAgent = m_strForwardingAgent
            End Get
            Set(ByVal value As String)
                m_strForwardingAgent = value
            End Set
        End Property
        Public Property FromENO() As String
            Get
                FromENO = m_strFromENO
            End Get
            Set(ByVal value As String)
                m_strFromENO = value
            End Set
        End Property
        Public Property FromEDate() As Date
            Get
                FromEDate = m_dtFromEDate
            End Get
            Set(ByVal value As Date)
                m_dtFromEDate = value
            End Set
        End Property
        Public Property LCNO() As String
            Get
                LCNO = m_strLCNO
            End Get
            Set(ByVal value As String)
                m_strLCNO = value
            End Set
        End Property
        Public Property DateOfIssue() As Date
            Get
                DateOfIssue = m_dtDateOfIssue
            End Get
            Set(ByVal value As Date)
                m_dtDateOfIssue = value
            End Set
        End Property
        Public Property LCTerms() As String
            Get
                LCTerms = m_strLCTerms
            End Get
            Set(ByVal value As String)
                m_strLCTerms = value
            End Set
        End Property
        Public Property TermOfSale() As String
            Get
                TermOfSale = m_strTermOfSale
            End Get
            Set(ByVal value As String)
                m_strTermOfSale = value
            End Set
        End Property
        Public Property ByOrderAndRisk() As String
            Get
                ByOrderAndRisk = m_strByOrderAndRisk
            End Get
            Set(ByVal value As String)
                m_strByOrderAndRisk = value
            End Set
        End Property
        Public Property Currencyid() As Long
            Get
                Currencyid = m_lCurrencyid
            End Get
            Set(ByVal value As Long)
                m_lCurrencyid = value
            End Set
        End Property
        Public Property MarksAndNumbers() As String
            Get
                MarksAndNumbers = m_strMarksAndNumbers
            End Get
            Set(ByVal value As String)
                m_strMarksAndNumbers = value
            End Set
        End Property
        Public Property RemarksNew() As String
            Get
                RemarksNew = m_strRemarksNew
            End Get
            Set(ByVal value As String)
                m_strRemarksNew = value
            End Set
        End Property
        Public Property WithStyleNo() As Boolean
            Get
                WithStyleNo = m_bWithStyleNo
            End Get
            Set(ByVal value As Boolean)
                m_bWithStyleNo = value
            End Set
        End Property
        Public Property WithOrderNo() As Boolean
            Get
                WithOrderNo = m_bWithOrderNo
            End Get
            Set(ByVal value As Boolean)
                m_bWithOrderNo = value
            End Set
        End Property
        Public Property Both() As Boolean
            Get
                Both = m_bBoth
            End Get
            Set(ByVal value As Boolean)
                m_bBoth = value
            End Set
        End Property
        
        Public Property WeightCTN() As Decimal
            Get
                WeightCTN = m_dcWeightCTN
            End Get
            Set(ByVal value As Decimal)
                m_dcWeightCTN = value
            End Set
        End Property
       
        Public Property DrawnOn() As String
            Get
                DrawnOn = m_strDrawnOn
            End Get
            Set(ByVal value As String)
                m_strDrawnOn = value
            End Set
        End Property
        Public Property FinalDest() As String
            Get
                FinalDest = m_strFinalDest
            End Get
            Set(ByVal value As String)
                m_strFinalDest = value
            End Set
        End Property
        Public Property ShipModeID() As Long
            Get
                ShipModeID = m_lShipModeID
            End Get
            Set(ByVal value As Long)
                m_lShipModeID = value
            End Set
        End Property


        '----------------Properties
        Public Property AccountCode() As String
            Get
                AccountCode = m_strAccountCode
            End Get
            Set(ByVal value As String)
                m_strAccountCode = value
            End Set
        End Property
        Public Property NoOfCartoon() As Decimal
            Get
                NoOfCartoon = m_dcNoOfCartoon
            End Get
            Set(ByVal value As Decimal)
                m_dcNoOfCartoon = value
            End Set
        End Property
        Public Property DestinationID() As Long
            Get
                DestinationID = m_lDestinationID
            End Get
            Set(ByVal value As Long)
                m_lDestinationID = value
            End Set
        End Property
      
        Public Property ShippedExchangeRate() As Decimal
            Get
                ShippedExchangeRate = m_dcShippedExchangeRate
            End Get
            Set(ByVal value As Decimal)
                m_dcShippedExchangeRate = value
            End Set
        End Property
        Public Property NetWeightUnit() As String
            Get
                NetWeightUnit = m_strNetWeightUnit
            End Get
            Set(ByVal value As String)
                m_strNetWeightUnit = value
            End Set
        End Property
        Public Property GrossWeightUnit() As String
            Get
                GrossWeightUnit = m_strGrossWeightUnit
            End Get
            Set(ByVal value As String)
                m_strGrossWeightUnit = value
            End Set
        End Property
        Public Property ShippingLine() As String
            Get
                ShippingLine = m_strShippingLine
            End Get
            Set(ByVal value As String)
                m_strShippingLine = value
            End Set
        End Property
        Public Property CBM() As String
            Get
                CBM = m_dcCBM
            End Get
            Set(ByVal value As String)
                m_dcCBM = value
            End Set
        End Property
        Public Property Consolidation() As String
            Get
                Consolidation = m_strConsolidation
            End Get
            Set(ByVal value As String)
                m_strConsolidation = value
            End Set
        End Property
        Public Property ContainerSize() As String
            Get
                ContainerSize = m_strContainerSize
            End Get
            Set(ByVal value As String)
                m_strContainerSize = value
            End Set
        End Property
        Public Property ETD() As Date
            Get
                ETD = m_dtETD
            End Get
            Set(ByVal value As Date)
                m_dtETD = value
            End Set
        End Property
        Public Property ETA() As Date
            Get
                ETA = m_dtETA
            End Get
            Set(ByVal value As Date)
                m_dtETA = value
            End Set
        End Property
        Public Property Forwarder() As String
            Get
                Forwarder = m_strForwarder
            End Get
            Set(ByVal value As String)
                m_strForwarder = value
            End Set
        End Property
        Public Property InvoiceValue() As String
            Get
                InvoiceValue = m_strInvoiceValue
            End Get
            Set(ByVal value As String)
                m_strInvoiceValue = value
            End Set
        End Property
        Public Property Terms() As String
            Get
                Terms = m_strTerms
            End Get
            Set(ByVal value As String)
                m_strTerms = value
            End Set
        End Property
        Public Property ItemDescription() As String
            Get
                ItemDescription = m_strItemDescription
            End Get
            Set(ByVal value As String)
                m_strItemDescription = value
            End Set
        End Property
        Public Property Mode() As String
            Get
                Mode = m_strMode
            End Get
            Set(ByVal value As String)
                m_strMode = value
            End Set
        End Property
        Public Property CarrierName() As String
            Get
                CarrierName = m_strCarrierName
            End Get
            Set(ByVal value As String)
                m_strCarrierName = value
            End Set
        End Property
        Public Property VoyageFlight() As String
            Get
                VoyageFlight = m_strVoyageFlight
            End Get
            Set(ByVal value As String)
                m_strVoyageFlight = value
            End Set
        End Property
        Public Property ContainerNo() As String
            Get
                ContainerNo = m_strContainerNo
            End Get
            Set(ByVal value As String)
                m_strContainerNo = value
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

        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property InvoiceNo() As String
            Get
                InvoiceNo = m_strInvoiceNo
            End Get
            Set(ByVal value As String)
                m_strInvoiceNo = value
            End Set
        End Property
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = m_dtInvoiceDate
            End Get
            Set(ByVal value As Date)
                m_dtInvoiceDate = value
            End Set
        End Property

        Public Property ShipmentDate() As Date
            Get
                ShipmentDate = m_dtShipmentDate
            End Get
            Set(ByVal value As Date)
                m_dtShipmentDate = value

            End Set
        End Property
        Public Property HandOverDate() As Date
            Get
                HandOverDate = m_dtHandOverDate
            End Get
            Set(ByVal value As Date)
                m_dtHandOverDate = value

            End Set
        End Property
        Public Property BillNo() As String
            Get
                BillNo = m_strBillNo
            End Get
            Set(ByVal value As String)
                m_strBillNo = value
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
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_UserID
            End Get
            Set(ByVal value As Long)
                m_UserID = value
            End Set
        End Property
        Public Property NetWeight() As Decimal
            Get
                NetWeight = m_dcNetWeight
            End Get
            Set(ByVal value As Decimal)
                m_dcNetWeight = value
            End Set
        End Property
        Public Property GrossWeight() As Decimal
            Get
                GrossWeight = m_dcGrossWeight
            End Get
            Set(ByVal value As Decimal)
                m_dcGrossWeight = value
            End Set
        End Property
        Public Function SaveCargo()
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
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfo()
            Dim str As String
            str = "Select Cr.CargoID,Convert(varchar,Cr.ShipmentDate ,106)as CargoDate,PONO,CustomerName,VenderName from Cargo Cr Join PurchaseOrder PO on Cr.POID=PO.POID  Join Customer C on C.CustomerID=PO.CustomerID Join Vender V on VenderLibraryID=PO.SupplierID where Po.Status='Confirmed'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Getweightunit()
            Dim str As String
            str = "Select * from tblunit"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFreightTerm()
            Dim str As String
            str = "select * from FreightTerm"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDestination()
            Dim str As String
            str = "select * from tblDestination"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOD()
            Dim str As String
            str = "select * from tblPOD"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBank()
            Dim str As String
            str = "select * from tblaccounts"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNew()
            Dim str As String
            str = "Select Cr.CargoID,Convert(varchar,Cr.ShipmentDate ,106)as CargoDate from Cargo Cr "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckInvoiceNo(ByVal InvoiceNo As String) As DataTable
            Dim str As String
            str = "Select * from Cargo where InvoiceNo in (" & InvoiceNo & ")"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function




        Public Function GetCargoinfoNewMaxFields()
            Dim str As String
            str = "Select * ,Convert(varchar,Cr.InvoiceDate ,106)as InvoiceDateF   from Cargo Cr "
            str &= " where Year(Cr.CreationDate)>=2012 order by cr.cargoid DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewMaxFieldsLatest()
            Dim str As String
            str = "Select *,(case when Cr.Currency='Dollar' then '$ ' Else'€ ' end) + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee ,Convert(varchar,Cr.ETD ,106)as InvoiceDateF,Convert(varchar,Cr.CreationDate ,106)as CreationDatee    from Cargo Cr "
            str &= " where Year(Cr.CreationDate)>=2012 order by cr.cargoid DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewMaxFieldsLatestUsre(ByVal UserID As Long)
            Dim str As String
            If UserID = 234 Then
                str = "Select *,(case when Cr.Currency='Dollar'  then '$ '   when Cr.Currency='Pound'  then '£ ' when Cr.Currency='PKR'  then 'PKR ' Else'€ ' end) + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee ,Convert(varchar,Cr.ETD ,106)as InvoiceDateF,Convert(varchar,Cr.CreationDate ,106)as CreationDatee    from Cargo Cr "
                str &= " where Year(Cr.CreationDate)>=2012   order by cr.cargoid DESC "
            Else
                str = "Select *,(case when Cr.Currency='Dollar'  then '$ '   when Cr.Currency='Pound'  then '£ ' when Cr.Currency='PKR'  then 'PKR ' Else'€ ' end) + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee ,Convert(varchar,Cr.ETD ,106)as InvoiceDateF,Convert(varchar,Cr.CreationDate ,106)as CreationDatee    from Cargo Cr "
                str &= " where Year(Cr.CreationDate)>=2012 AND Cr.UserID='" & UserID & "' order by cr.cargoid DESC "
            End If
          
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewMaxFieldsLatestMangemnet()
            Dim str As String

            str = " Select isnull((select Top 1 JM.tblJVMstId FROM tblJVMst JM JOIN tblJVDtl JD ON JM.tblJVMstId=JD.tblJVMstId WHERE JM.CargoId=Cr.CargoId),0) as tblJVMstId,*,(case when Cr.Currency='Dollar'  then '$ '   when Cr.Currency='Pound'  then '£ ' when Cr.Currency='PKR'  then 'PKR ' else '€ ' end) + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee ,Convert(varchar,Cr.ETD ,106)as InvoiceDateF,Convert(varchar,Cr.CreationDate ,106)as CreationDatee    from Cargo Cr "
            str &= " where Year(Cr.CreationDate)>=2012   order by cr.cargoid DESC "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewMaxFieldsLatestMangemnetNew()
            Dim str As String

            str = " Select isnull((select Top 1 JM.tblJVMstId FROM tblJVMst JM JOIN tblJVDtl JD ON JM.tblJVMstId=JD.tblJVMstId WHERE JM.CargoId=Cr.CargoId),0) as tblJVMstId,*,(case when Cr.Currency='Dollar'  then '$ '   when Cr.Currency='Pound'  then '£ ' when Cr.Currency='PKR'  then 'PKR ' else '€ ' end) + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee ,Convert(varchar,Cr.ETD ,106)as InvoiceDateF,Convert(varchar,Cr.CreationDate ,106)as CreationDatee,(select TOP 1 CD.POPOID  FROM CargoDetail CD where CD.CargoID =CR.CargoID ) as joborderid    from Cargo Cr "
            str &= " where Year(Cr.CreationDate)>=2012   order by cr.cargoid DESC "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewMaxFieldsLatestMangemnetNewForDigital()
            Dim str As String

            str = " Select isnull((select Top 1 JM.tblJVMstId FROM tblJVMst JM "
            str &= " JOIN tblJVDtl JD ON JM.tblJVMstId=JD.tblJVMstId WHERE JM.CargoId=Cr.CargoId),0) as tblJVMstId,"
            str &= " *,(case when C.CurrencyName='USD'  then '$ '   when C.CurrencyName='PUD'  then '£ ' "
            str &= " when C.CurrencyName ='PKR'  then 'PKR ' else '€ ' end) "
            str &= " + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee "
            str &= " ,Convert(varchar,Cr.ETD ,106)as InvoiceDateF"
            str &= " ,Convert(varchar,Cr.CreationDate ,106)as CreationDatee,"
            str &= " (select TOP 1 CD.POPOID  FROM CargoDetail CD where CD.CargoID =CR.CargoID ) as joborderid   "
            str &= " from Cargo Cr "
            str &= "  join Currency C on C.CurrencyID =Cr.Currencyid "
            str &= " where Year(Cr.CreationDate)>=2012   order by cr.cargoid DESC "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewForLogisticTask()
            Dim str As String
            str = "Select Cr.CargoID,Cr.InvoiceNo,Cr.BillNo,Cr.InvoiceValue,Convert(varchar,Cr.ShipmentDate ,106)as ShipmentDate ,IsActive from Cargo Cr where Cr.IsActive='0' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewForCheque()
            Dim str As String
            str = "Select Cr.CargoID,Cr.InvoiceNo,Cr.BillNo,Cr.InvoiceValue,Convert(varchar,Cr.ShipmentDate ,106)as ShipmentDate "
            str &= " ,ChequeNo='',ChequeDate='',PDC='',Amount='' "
            str &= " from Cargo Cr where Cr.IsActive='0' and Cr.GLEnterd='NO' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateCargo(ByVal lCargoId As Long)
            Dim str As String
            str = "Update cargo set GLEnterd='YES' where CargoID='" & lCargoId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateCargoFromAdmin(ByVal lCargoId As Long)
            Dim str As String
            str = "Update cargo set IsActive='1' where CargoID='" & lCargoId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoNewForLogisticTaskIC()
            Dim str As String
            str = "Select Cr.CargoID,Cr.InvoiceNo,Cr.BillNo,Cr.InvoiceValue,Convert(varchar,Cr.ShipmentDate ,106)as ShipmentDate ,IsActive from Cargo Cr "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetCargoInfoAll(ByVal lCargoId As Long)
            Dim str As String
            str = " Select C.*,CD.*,PO.PONo,PO.CustomerID,Po.SupplierID as VendorID "
            str &= "  , cast((Select Sum(Quantity) from PurchaseorderDetail POD where POD.POID=PO.POID) as decimal(10,0)) as POQTY "
            str &= " ,CC.Customername as CustomerName,v.Vendername as Suppliername,Po.Currency as poCurrency"
            str &= "  ,SM.Styleno,SD.Article,SD.Colorway,SD.SizeRange,Convert(Varchar,C.Shipmentdate,103) as ShipmentDateN  from Cargo C"
            str &= " join CargoDetail CD on Cd.CargoiD=C.cargoID"
            str &= " join Purchaseorder PO on Po.POID=CD.POPOID"

            str &= "  Join PurchaseOrderDetail POD  On CD.POID=POD.PODetailID"
            str &= "  Join StyleMaster SM on SM.StyleID=POD.StyleID "
            str &= "  JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"

            str &= " join Vender V on V.VenderlibraryID=Po.SupplierID "
            str &= " join Customer CC on CC.CustomerID=PO.CustomerID"
            str &= " where C.CargoID='" & lCargoId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoInfoAllNewNew(ByVal lCargoId As Long)
            Dim str As String

            str = " Select CD.Quantity as QuantityY,C.*,CD.*,PO.srno as PONo,CustomerDatabaseID as CustomerID  "
            str &= " ,   cast((Select Sum(Quantity) from JobOrderdatabaseDetail PODD "
            str &= " where PO.JobOrderId=PODD.JobOrderId)  as decimal(10,0)) as POQTY  "
            str &= "  ,CC.Customername as CustomerName,PO.Supplier as Suppliername,CR.CurrencyName as poCurrency  "
            str &= " ,(Select top 1 JOD.Model from JobOrderdatabaseDetail Jod where jod.Joborderid =PO.Joborderid) as Model "
            str &= "  ,'' as Article"
            str &= "  ,'' as SizeRange"
            str &= "  ,Convert(Varchar,C.Shipmentdate,103) as ShipmentDateN    "
            str &= "  from Cargo C "
            str &= "  join CargoDetail CD on Cd.CargoiD=C.cargoID   "
            str &= " join JobOrderdatabase PO on po.JobOrderId=CD.popoid     "
            str &= " join Customer CC on CC.CustomerID=PO.CustomerDatabaseID   "
            str &= "  join Currency CR on  CR.CurrencyID=PO.CurrencyID "
            str &= "  where C.CargoID='" & lCargoId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPackingCustomer()
            Dim str As String

            str = " select distinct c.CustomerID ,c.CustomerName  from PackingDtl dtl"
            str &= "  join Customer C on C.CustomerID =dtl.CustomerID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoInfoAllNew(ByVal lCargoId As Long)
            Dim str As String
            str = "  Select CD.Quantity as QuantityY,C.*,CD.*,PO.srno as PONo,CustomerDatabaseID as CustomerID   , "
            str &= "  cast((Select Sum(Quantity) from JobOrderdatabaseDetail PODD where POD.JobOrderDetailId=PODD.JobOrderDetailId)"
            str &= "  as decimal(10,0)) as POQTY  ,CC.Customername as CustomerName,PO.Supplier as Suppliername,CR.CurrencyName as poCurrency  "
            str &= "  ,POD.Style as Styleno,'' as Article,POD.BuyerColor as Colorway,'' as SizeRange,"
            str &= "  Convert(Varchar,C.Shipmentdate,103) as ShipmentDateN  "
            str &= "  from Cargo C join CargoDetail CD on Cd.CargoiD=C.cargoID "
            str &= "  join JobOrderdatabase PO on po.JobOrderId=CD.popoid "
            str &= "  Join JobOrderdatabaseDetail  POD on CD.poId=POD.JobOrderDetailId  "
            str &= "  join Customer CC on CC.CustomerID=PO.CustomerDatabaseID  "
            str &= "  join Currency CR on  CR.CurrencyID=PO.CurrencyID"
            str &= "  where C.CargoID='" & lCargoId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPackingListData(ByVal lCargoId As Long)
            Dim str As String
         
            str = "  Select CD.CargoDetailID,CD.ShippedRate,CD.PackingPCS,'0' AS PackingDtlID ,cd.Cartons ,cd.Quantity ,CD.POID ,PO.SRNO ,PO.CustomerOrder ,case when POD.buyerColor='WHITE' then 'WHITE' else 'DYED' end as Color"
            str &= "  from Cargo C join CargoDetail CD on Cd.CargoiD=C.cargoID "
            str &= "  join JobOrderdatabase PO on po.JobOrderId=CD.popoid "
            str &= "  Join JobOrderdatabaseDetail  POD on CD.poId=POD.JobOrderDetailId  "
            str &= "  join Customer CC on CC.CustomerID=PO.CustomerDatabaseID  "
            str &= "  join Currency CR on  CR.CurrencyID=PO.CurrencyID"
            str &= "  join SeasonDatabase SDD on  SDD.SeasonDatabaseID=CD.SeasonDatabaseID"
            str &= "  where C.CargoID='" & lCargoId & "' and CD.CargoDetailID not in (select CargoDetailID FROM PackingDtl)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPackingListDataNew(ByVal lCargoId As Long)
            Dim str As String

            str = "  Select CD.CargoDetailID,CD.ShippedRate,CD.PackingPCS,'0' AS PackingDtlID ,cd.Cartons ,cd.Quantity ,CD.POID ,PO.SRNO ,PO.CustomerOrder ,case when POD.buyerColor='WHITE' then 'WHITE' else 'DYED' end as Color"
            str &= "  ,isnull((select SUM(dtl.RecvPackingPCS) from  PackingDtl Dtl where"
            str &= "   Dtl.CargoDetailID =CD.CargoDetailID),0) as PackingPCSS"
            str &= "  from Cargo C join CargoDetail CD on Cd.CargoiD=C.cargoID "
            str &= "  join JobOrderdatabase PO on po.JobOrderId=CD.popoid "
            str &= "  Join JobOrderdatabaseDetail  POD on CD.poId=POD.JobOrderDetailId  "
            str &= "  join Customer CC on CC.CustomerID=PO.CustomerDatabaseID  "
            str &= "  join Currency CR on  CR.CurrencyID=PO.CurrencyID"
            str &= "  join SeasonDatabase SDD on  SDD.SeasonDatabaseID=CD.SeasonDatabaseID"
            str &= "  where C.CargoID='" & lCargoId & "' and (cd.PackingPCS- isnull((select SUM(dtl.RecvPackingPCS) "
            str &= " from  PackingDtl Dtl"
            str &= "  where  Dtl.CargoDetailID =CD.CargoDetailID),0)) <>0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateCTNSFromCargoDteail(ByVal lCargoId As Long, ByVal POPOID As Long, ByVal CTNS As Decimal)
            Dim Str As String
            Str = " update  CargoDetail Set Cartons= '" & CTNS & "' where CargoID='" & lCargoId & "' and POPOID='" & POPOID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeletePackingDtl(ByVal PackingDtlID As Long)
            Dim Str As String
            Str = " Delete from PackingDtl where PackingDtlID=" & PackingDtlID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoCTNS(ByVal lCargoId As Long, ByVal POPOID As Long)
            Dim str As String

            str = "  SELECT Cartons FROM  CargoDetail Mst"
            str &= "  where CargoID='" & lCargoId & "' and POPOID='" & POPOID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPackingListDataNewForLatest(ByVal lCargoId As Long)
            Dim str As String

            str = "   Select CD.CargoDetailID,CD.ShippedRate,'0' AS PackingDtlID ,cd.Cartons ,cd.Quantity ,CD.POID ,PO.SRNO"
            str &= " ,PO.CustomerOrder ,case when POD.buyerColor='WHITE' then 'WHITE' else 'DYED' end as Color  ,CD.POPOID"
            str &= "  ,ISNULL((select SUM(dTL.CTNS) from PackingDtl  dTL WHERE  dTL.POPOID  =CD.POPOID "
            str &= "  AND dTL.POPOID =CD.POPOID ),0) AS CTNS,POD.Style  "
            str &= "  from Cargo C   join CargoDetail CD on Cd.CargoiD=C.cargoID   "
            str &= "  join JobOrderdatabase PO on po.JobOrderId=CD.popoid   "
            str &= "  Join JobOrderdatabaseDetail  POD on CD.poId=POD.JobOrderDetailId    "
            str &= "  join Customer CC on CC.CustomerID=PO.CustomerDatabaseID    "
            str &= " join Currency CR on  CR.CurrencyID=PO.CurrencyID  "
            str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=CD.SeasonDatabaseID  "
            str &= "  where C.CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPackingListDataNewForLatestOnEditCase(ByVal lCargoId As Long)
            Dim str As String

            str = "   Select CD.CargoDetailID,CD.ShippedRate,'0' AS PackingDtlID ,cd.Cartons ,cd.Quantity ,CD.POID ,PO.SRNO"
            str &= " ,PO.CustomerOrder ,case when POD.buyerColor='WHITE' then 'WHITE' else 'DYED' end as Color  ,CD.POPOID"
            str &= "  ,ISNULL((select SUM(dTL.CTNS) from PackingDtl  dTL WHERE  dTL.POPOID  =CD.POPOID "
            str &= "  AND dTL.POPOID =CD.POPOID ),0) AS CTNS,POD.Style  "
            str &= "  from Cargo C   join CargoDetail CD on Cd.CargoiD=C.cargoID   "
            str &= "  join JobOrderdatabase PO on po.JobOrderId=CD.popoid   "
            str &= "  Join JobOrderdatabaseDetail  POD on CD.poId=POD.JobOrderDetailId    "
            str &= "  join Customer CC on CC.CustomerID=PO.CustomerDatabaseID    "
            str &= " join Currency CR on  CR.CurrencyID=PO.CurrencyID  "
            str &= " join SeasonDatabase SDD on  SDD.SeasonDatabaseID=CD.SeasonDatabaseID  "
            str &= "  where C.CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUpdateData(ByVal lCargoId As Long)
            Dim str As String

            str = "  SELECT DISTINCT Dtl.POPOID FROM  PackingmST Mst"
            str &= "  join PackingDtl Dtl on Dtl.PackingmSTID=Mst.PackingmSTID "
            str &= "  where Mst.CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPackingQty(ByVal lCargoId As Long, ByVal POPOID As Long)
            Dim str As String

            str = "  SELECT ISNULL(SUM(Dtl.CTNS),0) AS CTNS FROM  PackingmST Mst"
            str &= "  join PackingDtl Dtl on Dtl.PackingmSTID=Mst.PackingmSTID "
            str &= "  where Mst.CargoID='" & lCargoId & "' and Dtl.POPOID='" & POPOID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetData(ByVal lCargoId As Long)
            Dim str As String

            str = "  select * from Cargo mST"
            str &= "  where mST.CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCarton(ByVal lCargoId As Long)
            Dim str As String

            str = "  select isnull(sum(cartons),0) as cartons from CargoDetail mST"
            str &= "  where mST.CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPacData(ByVal lCargoId As Long)
            Dim str As String

            str = "  select * from CargoDetail mST"
            str &= "  where mST.CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUpdateOnCargo(ByVal lCargoId As Long, ByVal Cartons As Decimal, ByVal Gross As Decimal, ByVal NetWt As Decimal)
            Dim str As String

            str = "  update Cargo set NetWeight='" & Gross & "' , GrossWeight='" & NetWt & "' , NoOFCartoon='" & Cartons & "'"
            str &= "  where CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoData(ByVal lCargoId As Long)
            Dim str As String

            str = "  select * from Cargo"
            str &= "  where CargoID='" & lCargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUpdatePackingQty(ByVal lCargoId As Long, ByVal POPOID As Long, ByVal Qty As Decimal)
            Dim str As String

            str = "  update CargoDetail Set Cartons='" & Qty & "'"
            str &= "  where CargoID='" & lCargoId & "' and POPOID='" & POPOID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoinfoSearch(ByVal InvoiceNo As String)
            Dim str As String
            str = "      Select isnull((select Top 1 JM.tblJVMstId FROM tblJVMst JM "
            str &= "  JOIN tblJVDtl JD ON JM.tblJVMstId=JD.tblJVMstId WHERE JM.CargoId=Cr.CargoId),0) as tblJVMstId,"
            str &= "   *,(case when C.CurrencyName ='Dollar'  then '$ '   when C.CurrencyName='Pound'  then '£ ' "
            str &= "   when C.CurrencyName='PKR'  then 'PKR ' else '€ ' end) + "
            str &= "  Convert(varchar,Cr.InvoiceValue)as InvoiceValuee,Convert(varchar,Cr.InvoiceDate ,106)as InvoiceDateF "
            str &= "   ,Convert(varchar,Cr.CreationDate ,106)as CreationDatee  "
            str &= "    from Cargo Cr "
            str &= "  join Currency C on c.CurrencyID =cr.Currencyid "
            str &= " where InvoiceNo ='" & InvoiceNo & "'"
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateCurrency(ByVal lCargoId As Long, ByVal Currency As String)
            Dim str As String
            str = "Update cargo set Currency='" & Currency & "' where CargoID='" & lCargoId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoSearch(ByVal ReportType As Long, ByVal Customer As Long, ByVal Supplier As Long)
            Dim str As String
            str = "  Select distinct cr.cargoid, Convert(varchar,Cr.InvoiceDate ,106)as InvoiceDateF,C.customername,cr.invoiceno,v.vendername,cr.Terms   from Cargo Cr "
            str &= " join cargodetail CD on Cd.cargoid=Cr.cargoid"
            str &= " join purchaseorder Po on PO.POID=Cd.POPOID"
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid  "
            str &= " where Year(Cr.CreationDate) >=2012 and "
            If ReportType = 0 Then

                str &= " PO.Customerid ='" & Customer & "'"

            ElseIf ReportType = 1 Then
                str &= " PO.SupplierID ='" & Supplier & "'"
            End If
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoSearchByPONO(ByVal IPOID As Long)
            Dim str As String
            str = "  Select distinct cr.cargoid, Convert(varchar,Cr.InvoiceDate ,106)as InvoiceDateF,C.customername,cr.invoiceno,v.vendername,cr.Terms   from Cargo Cr "
            str &= " join cargodetail CD on Cd.cargoid=Cr.cargoid"
            str &= " join purchaseorder Po on PO.POID=Cd.POPOID"
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid  "
            str &= " where Year(Cr.CreationDate) >=2012 and "
            str &= " PO.POID ='" & IPOID & "'"

            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoForShipRate(ByVal ETDStartDate As String, ByVal ETDEndDate As String)
            Dim str As String
            Try
                str = "   Select * from Cargo  "
                str &= " where ETD between '" & ETDStartDate & "' and '" & ETDEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoForShipRateNew(ByVal ETDStartDate As String, ByVal ETDEndDate As String, ByVal Currency As String)
            Dim str As String
            Try
                str = "   Select * from Cargo  "
                str &= " where Currency='" & Currency & "' and ETD between '" & ETDStartDate & "' and '" & ETDEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoForShipRateNewforcargo(ByVal ETDStartDate As String, ByVal ETDEndDate As String, ByVal Currency As String)
            Dim str As String
            Try
                str = "   Select * from ShipExchangeRate  "
                str &= " where currency = '" & Currency & "' and MonthStartDate <= '" & ETDStartDate & "' and MonthendDate >= '" & ETDEndDate & "' "

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateShippedExchangeRate(ByVal lCargoId As Long, ByVal ShippedExchangeRate As String)
            Dim str As String
            str = "Update cargo set ShippedExchangeRate='" & ShippedExchangeRate & "' where CargoID='" & lCargoId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoMonthNames()
            Dim str As String
            Try
                str = " select distinct DATENAME(month, (ETD)) as MonthName,month(ETD)as MonthNo from Cargo"
                str &= " order by   month(ETD)   ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoYearNames()
            Dim str As String
            Try
                str = " select distinct DATENAME(year, (ETD)) as YearName,year(ETD)as YearNo from Cargo"
                str &= " where Year(Creationdate) >=2013 order by   year(ETD)   DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoCustomers()
            Dim str As String
            Try
                str = " select distinct C.CustomerName,C.CustomerID  from Cargo CC"
                str &= " join CargoDetail CD on CD.CargoID=CC.CargoID"
                str &= " join Purchaseorder PO on PO.POID=CD.POPOID"
                str &= " Join Customer C on C.CustomerID=PO.Customerid "
                str &= " where Year(CC.Creationdate) >=2013 order by  C.CustomerName   ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoExisting(ByVal CustomerID As String, ByVal MonthNo As String, ByVal YearNo As String, ByVal Currency As String)
            Dim str As String
            Try
                str &= "  Select  PO.Season    ,Po.eknumber  ,  "
                str &= " isnull((Select LKZNumber from SupplierLKZ SL"
                str &= "  where SL.CustomerID=PO.Customerid  and SL.SupplierID=PO.SupplierID ),0) as 'SupplierNo'"
                str &= " , v.vendername   ,Po.PONo  "
                str &= " ,CC.ETD,SD.Article,CD.Quantity,CD.ShippedRate,CC.Currency,"
                str &= " (case when CC.Currency='Dollar' then '$ ' Else'€ ' end) + ' ' + Convert(varchar,(CD.Quantity * CD.ShippedRate))as value"
                str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid   "
                str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
                str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID      "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " left join Cargodetail cd on pod.podetailid=cd.poid    "
                str &= " left join cargo CC on cc.cargoid=cd.cargoid    "
                str &= "  where "
                str &= " C.customerid=" & CustomerID
                str &= " and month(CC.ETD)= " & MonthNo
                str &= " and Year(CC.ETD)= " & YearNo
                str &= " and CC.Currency='" & Currency & "'"
                str &= " order by day(CC.ETD) ASC   "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getExcelSheetOfShippedStatus(ByVal CustomerID As String, ByVal MonthNo As String, ByVal YearNo As String, ByVal Currency As String)
            Try
                ' Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection")
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_LogisticDepartmentShippedStatus", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.VarChar)).Value = CustomerID
                sqlCmd.Parameters.Add(New SqlParameter("@MonthNo", SqlDbType.VarChar)).Value = MonthNo
                sqlCmd.Parameters.Add(New SqlParameter("@YearNo", SqlDbType.VarChar)).Value = YearNo
                sqlCmd.Parameters.Add(New SqlParameter("@Currency", SqlDbType.VarChar)).Value = Currency
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function getExcelSheetOfShippedStatusSCHWAB(ByVal CustomerID As String, ByVal MonthNo As String, ByVal YearNo As String, ByVal Currency As String)
            Try
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_LogisticDepartmentShippedStatusSCHWAB", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.VarChar)).Value = CustomerID
                sqlCmd.Parameters.Add(New SqlParameter("@MonthNo", SqlDbType.VarChar)).Value = MonthNo
                sqlCmd.Parameters.Add(New SqlParameter("@YearNo", SqlDbType.VarChar)).Value = YearNo
                sqlCmd.Parameters.Add(New SqlParameter("@Currency", SqlDbType.VarChar)).Value = Currency
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function checkInvoice(ByVal lInvoiceNo As String)
            Dim str As String
            str = "select * from cargo where InvoiceNo='" & lInvoiceNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDBBackup(ByVal path As String, ByVal FileName As String)
            Dim Str As String
            Dim File As String = path + FileName
            Str = "backup database GIA to DISK='" & File & "' "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace