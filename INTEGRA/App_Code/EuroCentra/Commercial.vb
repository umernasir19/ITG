Imports System.Data

Namespace EuroCentra
    Public Class Commercial
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CommercialInvoice"
            m_strPrimaryFieldName = "CommercialInvoiceID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCommercialInvoiceID As Long
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
        Private m_strCurrency As String
        Private m_dtETD As Date
        Private m_dtETA As Date
        Private m_strConsolidation As String
        Private m_strContainerSize As String
        Private m_strComments As String


        ''---------------- Properties
        Public Property CommercialInvoiceID() As Long
            Get
                CommercialInvoiceID = m_lCommercialInvoiceID
            End Get
            Set(ByVal value As Long)
                m_lCommercialInvoiceID = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Comments = m_strComments
            End Get
            Set(ByVal value As String)
                m_strComments = value
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

        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal value As String)
                m_strCurrency = value
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
        Public Function SaveCommercialInvoice()
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
      
        Public Function GetPurchaseOrderByPOUsingStyleMaster(ByVal lPOID As String, ByVal lPODetailID As String) As DataTable
            Dim Str As String
            Str = " Select *,'0'  as 'CommercialInvoiceDetailID',Dt.Name as DeliveryTypeName,PM.Name as PaymentModeName, PT.name as PaymentTypeName,SM.name as ShipmentModeName "
            Str &= " ,c.CustomerName,po.EKNumber as BuyingDept"
            Str &= " from PurchaseOrder PO Join PurchaseOrderDetail POD "
            Str &= " On PO.POID=POD.POID"
            Str &= " Join StyleMaster StyMaster on StyMaster.StyleID=POD.StyleID "
            Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
            Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
            Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= " where  PO.POID in  " & lPOID
            Str &= " and POD.PODetailID in " & lPODetailID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function InvoiceExist(ByVal InvoiceNo As String)
            Dim str As String
            str = "   Select *   from CommercialInvoice Ci "
            str &= " where InvoiceNo ='" & InvoiceNo & "'"
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommercialInvoiceForView() As DataTable
            Dim Str As String
            Str = " Select CI.CommercialInvoiceID ,CI.InvoiceNo ,CONVERT(VARCHAR(11), CI.InvoiceDate , 103) as InvoiceDate ,CI.BillNo ,CONVERT(VARCHAR(11), CI.ShipmentDate, 103) as ShipmentDate"
            Str &= " ,CI.Terms ,CONVERT(VARCHAR(11), CI.ETD , 103) as ETD, CI.ETD as ETDD "
            Str &= " ,(select sum(cid.Quantity * CID.Rate) from CommercialInvoiceDetail CID where  CI.CommercialInvoiceID=CID.CommercialInvoiceID) AS ShippedValue "
            Str &= " from CommercialInvoice CI "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetValeForEdit(ByVal CommercialInvoiceID As Long) As DataTable
            Dim Str As String
            Str = "  Select CI.*,CID.*,cid.Quantity *CID.Rate AS Amount,po.EKNumber as BuyingDept"
            Str &= "  ,PO.POID ,POD.PODetailID,PO.PONO,s.StyleID,s.StyleNo as Style,sd.Article,sd.SizeRange as Size"
            Str &= "  ,sd.Colorway as Color,pod.Quantity,cid.Quantity as InsertTextQTY,c.CustomerName   from CommercialInvoice CI "
            Str &= " join CommercialInvoiceDetail CID on CI.CommercialInvoiceID=CID.CommercialInvoiceID"
            Str &= " join PurchaseOrder PO on PO.POId=CID.POID"
            Str &= " left  Join PurchaseOrderDetail POD  On POD.PODetailID= cid.PODetailID "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid"
            Str &= " join StyleMaster  S on s.StyleID =POD.StyleID"
            Str &= " join StyleDetail sd on sd.StyleDetailID =pod.StyleDetailID "
            Str &= " join ProductPortfolio PPF on PPF.ProductPortfolio  =PO.ProductGroup "
            Str &= " left join cities cts on cts.id =v.City "
            Str &= " left join Countries Ctr on ctr.Country_id =cts.Country_id "
            Str &= " where CI.CommercialInvoiceID=" & CommercialInvoiceID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
 
        Public Function GetCommercialMasterdata(ByVal CommercialInvoiceID As Long) As DataTable
            Dim Str As String
            Str = "  Select * from  CommercialInvoice CI "
            Str &= " where CI.CommercialInvoiceID=" & CommercialInvoiceID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCommercialDetaildata(ByVal CommercialInvoiceID As Long) As DataTable
            Dim Str As String
            Str = " select * from CommercialInvoiceDetail "
            Str &= " where CommercialInvoiceID=" & CommercialInvoiceID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace
