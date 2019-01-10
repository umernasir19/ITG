Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class QDInspection
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "QDInspection"
            m_strPrimaryFieldName = "QDInspectionID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lQDInspectionID As Long
        Private m_dtCreationDate As Date
        Private m_lPOID As Long
        Private m_lPODetailID As Long
        Private m_dcInspectedQty As Decimal
        Private m_lQDUserid As Long
        Private m_dtInspectionDate As Date
        Private m_strInspectionStatus As String
        Private m_strInspStatus As String
        Private m_strRemarks As String
        Private m_strASubQty As String
        Public Property QDInspectionID() As Long
            Get
                QDInspectionID = m_lQDInspectionID
            End Get
            Set(ByVal value As Long)
                m_lQDInspectionID = value
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
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal value As Long)
                m_lPODetailID = value
            End Set
        End Property
        Public Property InspectedQty() As Decimal
            Get
                InspectedQty = m_dcInspectedQty
            End Get
            Set(ByVal value As Decimal)
                m_dcInspectedQty = value
            End Set
        End Property
        Public Property QDUserid() As Long
            Get
                QDUserid = m_lQDUserid
            End Get
            Set(ByVal value As Long)
                m_lQDUserid = value
            End Set
        End Property
        Public Property InspectionDate() As Date
            Get
                InspectionDate = m_dtInspectionDate
            End Get
            Set(ByVal value As Date)
                m_dtInspectionDate = value
            End Set
        End Property
        Public Property InspectionStatus() As String
            Get
                InspectionStatus = m_strInspectionStatus
            End Get
            Set(ByVal value As String)
                m_strInspectionStatus = value
            End Set
        End Property
        Public Property InspStatus() As String
            Get
                InspStatus = m_strInspStatus
            End Get
            Set(ByVal value As String)
                m_strInspStatus = value
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
        Public Property ASubQty() As String
            Get
                ASubQty = m_strASubQty
            End Get
            Set(ByVal value As String)
                m_strASubQty = value
            End Set
        End Property

        Public Function SaveQDInspection()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetQDInspectionById(ByVal QDInspectionID As Long)
            Try
                Return MyBase.GetById(QDInspectionID)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllCustomer(ByVal ECP As String, Optional ByVal DateFrom As String = "", Optional ByVal DateTO As String = "")
            Dim str As String
            str = " Select  distinct C.CustomerID,C.customerName "
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID not in (Select distinct POPOID from CargoDetail)"
            str &= " and PO.POID in "
            str &= " (Select distinct PRS.POID  from PurchaseOrderReviseShipment"
            str &= "  PRS where PRS.ShipmentDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTO.Substring(6, 4) & "-" & DateTO.Substring(3, 2) & "-" & DateTO.Substring(0, 2) & "' )"
            str &= "  and UM.ECPDivistion='" & ECP & "'"
            str &= "  order by C.customerName  ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllVendor(ByVal ECP As String, Optional ByVal DateFrom As String = "", Optional ByVal DateTO As String = "")
            Dim str As String
            str = " Select  distinct V.VenderLibraryID,V.vendername "
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID not in (Select distinct POPOID from CargoDetail)"
            str &= " and PO.POID in "
            str &= " (Select distinct PRS.POID  from PurchaseOrderReviseShipment"
            str &= "  PRS where PRS.ShipmentDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTO.Substring(6, 4) & "-" & DateTO.Substring(3, 2) & "-" & DateTO.Substring(0, 2) & "' )"
            str &= "  and UM.ECPDivistion='" & ECP & "'"
            str &= " order by V.vendername  ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllPONO(ByVal ECP As String, Optional ByVal DateFrom As String = "", Optional ByVal DateTO As String = "")
            Dim str As String
            str = " Select  distinct Po.POID,PO.PONO "
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID not in (Select distinct POPOID from CargoDetail)"
            str &= " and PO.POID in "
            str &= " (Select distinct PRS.POID  from PurchaseOrderReviseShipment"
            str &= "  PRS where PRS.ShipmentDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTO.Substring(6, 4) & "-" & DateTO.Substring(3, 2) & "-" & DateTO.Substring(0, 2) & "' )"
            str &= "  and UM.ECPDivistion='" & ECP & "'"
            str &= " order by PO.PONO ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllSeason(ByVal ECP As String, Optional ByVal DateFrom As String = "", Optional ByVal DateTO As String = "")
            Dim str As String
            str = " Select  distinct Po.Season "
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID not in (Select distinct POPOID from CargoDetail)"
            str &= " and PO.POID in "
            str &= " (Select distinct PRS.POID  from PurchaseOrderReviseShipment"
            str &= "  PRS where PRS.ShipmentDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTO.Substring(6, 4) & "-" & DateTO.Substring(3, 2) & "-" & DateTO.Substring(0, 2) & "' )"
            str &= "  and UM.ECPDivistion='" & ECP & "'"
            str &= " order by Po.Season ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData(ByVal Buyer As String, ByVal Vender As String, ByVal Season As String, ByVal POID As String, ByVal ECP As String, Optional ByVal DateFrom As String = "", Optional ByVal DateTO As String = "")
            Dim str As String
            str = "  Select Po.POID,PoD.PodetailID, "
            str &= "  C.CustomerName ,V.vendername, Po.eknumber,PO.Season  ,Po.PONo , "
            str &= " S.styleNo,SD.ColorRefNo as Article,SD.SizeRange,SD.Colorway,convert(varchar,Po.ShipmentDate,106) as shipmentdatee,  "
            str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,106) as ShipmentDate "
            str &= " from PurchaseOrderReviseShipment PRS"
            str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'RevisedShipmentDate',"
            str &= " cast(POD.Quantity as decimal(10,0)) as OrderQty,"
            str &= " isnull((Select  Sum(QDI.InspectedQty) from QDInspection QDI"
            str &= " where QDI.PoDetailID=POD.PoDetailID and QDI.InspStatus='Pass'  ),0) as 'InspectedQty'"
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID      "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID not in (Select distinct POPOID from CargoDetail)"
            If Not Buyer = "All Customer" Then
                str &= " and PO.CustomerID ='" & Buyer & "' "
            End If
            If Not Vender = "All Vendor" Then
                str &= " and PO.SupplierID='" & Vender & "' "
            End If
            If Not Season = "All Season" Then
                str &= " and PO.Season ='" & Season & "' "
            End If
            If Not POID = "All POs" Then
                str &= " and PO.POID ='" & POID & "' "
            End If

            str &= " and PO.POID in "
            str &= " (Select distinct PRS.POID  from PurchaseOrderReviseShipment"
            str &= "  PRS where PRS.ShipmentDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTO.Substring(6, 4) & "-" & DateTO.Substring(3, 2) & "-" & DateTO.Substring(0, 2) & "'  "
            str &= "  and PRS.POID not in "
            str &= " (Select distinct PRS.POID  from PurchaseOrderReviseShipment"
            str &= "  PRS where PRS.ShipmentDate not between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTO.Substring(6, 4) & "-" & DateTO.Substring(3, 2) & "-" & DateTO.Substring(0, 2) & "' ))"


            str &= " and UM.ECPDivistion='" & ECP & "'"

            str &= " Order by"
            str &= " ((Select Top 1  PRS.ShipmentDate "
            str &= " from PurchaseOrderReviseShipment PRS where PRS.POID=PO.POID "
            str &= " order by PRS.POReviseShipmentID DESC)) DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewPopup(ByVal POID As Long)
            Dim str As String
            str = "  Select S.StyleDescription,Po.POID,PoD.PodetailID, "
            str &= "  C.CustomerName ,V.vendername, Po.eknumber,PO.Season  ,Po.PONo , "
            str &= " S.styleNo,SD.ColorRefNo,SD.Sizes as SizeRange,SD.Colorway,convert(varchar,Po.ShipmentDate,106) as shipmentdatee, convert(varchar,POD.DetailShipmentDate,103)"
            str &= " as Detailshipmentdatee,   "
            str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,106) as ShipmentDate "
            str &= " from PurchaseOrderReviseShipment PRS"
            str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'RevisedShipmentDate',"
            str &= " cast(POD.Quantity as decimal(10,0)) as OrderQty,"
            str &= " isnull((Select  Sum(QDI.InspectedQty) from QDInspection QDI"
            str &= " where QDI.PoDetailID=POD.PoDetailID and QDI.InspStatus='Pass' and QDI.InspectionStatus='Final'),0) as 'InspectedQty'"
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID      "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID ='" & POID & "' "
            str &= " Order by"
            str &= " ((Select Top 1  PRS.ShipmentDate "
            str &= " from PurchaseOrderReviseShipment PRS where PRS.POID=PO.POID "
            str &= " order by PRS.POReviseShipmentID DESC)) DESC"






            'str = "  Select Po.POID,PoD.PodetailID, "
            'str &= "  C.CustomerName ,V.vendername, Po.eknumber,PO.Season  ,Po.PONo , "
            'str &= " S.styleNo,SD.Article,SD.SizeRange,SD.Colorway,convert(varchar,Po.ShipmentDate,106) as shipmentdatee,  "
            'str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,106) as ShipmentDate "
            'str &= " from PurchaseOrderReviseShipment PRS"
            'str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'RevisedShipmentDate',"
            'str &= " cast(POD.Quantity as decimal(10,0)) as OrderQty,"
            'str &= " isnull((Select  Sum(QDI.InspectedQty) from QDInspection QDI"
            'str &= " where QDI.PoDetailID=POD.PoDetailID and QDI.InspStatus='Pass' and QDI.InspectionStatus='Final'),0) as 'InspectedQty'"
            'str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            'str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            'str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            'str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
            'str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID      "
            'str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            'str &= " where  Year(PO.CreationDate) >=2012   and "
            'str &= " PO.POID ='" & POID & "' "
            'str &= " Order by"
            'str &= " ((Select Top 1  PRS.ShipmentDate "
            'str &= " from PurchaseOrderReviseShipment PRS where PRS.POID=PO.POID "
            'str &= " order by PRS.POReviseShipmentID DESC)) DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewPopupEdit(ByVal POID As Long, ByVal PODetailID As Long, ByVal QDInspectionID As Long)
            Dim str As String
            str = "  Select Po.POID,PoD.PodetailID,QD.QDInspectionID, "
            str &= "  C.CustomerName ,V.vendername, Po.eknumber,PO.Season  ,Po.PONo , "
            str &= " S.styleNo,SD.ColorRefNo as Article,SD.SizeRange,SD.Colorway,convert(varchar,Po.ShipmentDate,106) as shipmentdatee,  "
            str &= " (Select Top 1 Convert(Varchar,PRS.ShipmentDate,106) as ShipmentDate "
            str &= " from PurchaseOrderReviseShipment PRS"
            str &= " where PRS.POID=PO.POID order by PRS.POReviseShipmentID DESC) as 'RevisedShipmentDate',"
            str &= " cast(POD.Quantity as decimal(10,0)) as OrderQty,"
            str &= " isnull((Select  Sum(QDI.InspectedQty) from QDInspection QDI"
            str &= " where QDI.PoDetailID=POD.PoDetailID and QDI.InspStatus='Pass' and QDI.InspectionStatus='Final'),0) as 'InspectedQty'"
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID      "
            str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= " join QDInspection QD on QD.POID=Po.POID    "
            str &= " where  Year(PO.CreationDate) >=2012   and "
            str &= " PO.POID ='" & POID & "' "
            str &= " and POD.PODetailID ='" & PODetailID & "' "
            str &= " and QD.QDInspectionID ='" & QDInspectionID & "' "
            str &= " Order by"
            str &= " ((Select Top 1  PRS.ShipmentDate "
            str &= " from PurchaseOrderReviseShipment PRS where PRS.POID=PO.POID "
            str &= " order by PRS.POReviseShipmentID DESC)) DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetQDHistory(ByVal POID As Long, ByVal PODetailID As Long)
            Dim str As String
            str = "  Select  POD.PODetailID,QDI.QDInspectionID, PO.POID, PO.PONO, S.styleNo, SD.ColorRefNo as Article"
            str &= " , Convert(Varchar,QDI.CreationDate,106)as CreationDate ,QDI.InspectedQty"
            str &= " ,Convert(Varchar,QDI.InspectionDate,106)as InspectionDate,"
            str &= "  QDI.InspectionStatus, QDI.Remarks, Um.Username,C.customerName,V.VenderName,QDI.InspStatus"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= " join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where QDI.POID =" & POID
            str &= " And QDI.PODetailID =" & PODetailID
            str &= " order by QDI.QDInspectionID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetQDHistoryForManagement(ByVal POID As Long)
            Dim str As String
            str = "  Select  PO.POID, PO.PONO, S.styleNo, SD.ColorRefNo as Article"
            str &= " , Convert(Varchar,QDI.CreationDate,106)as CreationDate ,QDI.InspectedQty"
            str &= " ,Convert(Varchar,QDI.InspectionDate,106)as InspectionDate,"
            str &= "  QDI.InspectionStatus, QDI.Remarks, Um.Username,C.customerName,V.VenderName,QDI.InspStatus"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= " join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where QDI.POID =" & POID
            str &= " order by QDI.QDInspectionID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetQDInspLast(ByVal POID As Long, ByVal PODetailID As Long)
            Dim str As String
            str = "   Select TOP 1 * from QDInspection "
            str &= " where  POID =" & POID
            str &= " And  PODetailID =" & PODetailID
            str &= " order by  QDInspectionID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetQDInspLastEdit(ByVal POID As Long, ByVal PODetailID As Long, ByVal QDInspectionID As Long)
            Dim str As String
            str = "   Select * from QDInspection "
            str &= " where  POID =" & POID
            str &= " And  PODetailID =" & PODetailID
            str &= " And  QDInspectionID =" & QDInspectionID
            str &= " order by  QDInspectionID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetQDSearch(ByVal UserID As Long, Optional ByVal DateFrom As String = "", Optional ByVal DateTo As String = "")
            Dim str As String
            str = "  Select  PO.POID, PO.PONO, S.styleNo, SD.ColorRefNo as Article"
            str &= " , Convert(Varchar,QDI.CreationDate,106)as CreationDate ,QDI.InspectedQty"
            str &= " ,Convert(Varchar,QDI.InspectionDate,106)as InspectionDate,"
            str &= "  QDI.InspectionStatus, QDI.Remarks, Um.Username,C.customerName,V.VenderName,QDI.InspStatus"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= " join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where  "
            If Not UserID = 0 Then
                str &= " QDI.QDUserID ='" & UserID & "' and "
            End If
            If DateTo <> "" And DateFrom <> "" Then
                str &= " QDI.CreationDate between '" & DateFrom.Substring(6, 4) & "-" & DateFrom.Substring(3, 2) & "-" & DateFrom.Substring(0, 2) & "' and  '" & DateTo.Substring(6, 4) & "-" & DateTo.Substring(3, 2) & "-" & DateTo.Substring(0, 2) & "'"
            End If
            str &= " order by QDI.QDInspectionID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForInspectionTracking(ByVal StartDate As Date, ByVal EndDate As Date)
            Dim str As String
            str = "   Select Po.POID,PoD.PodetailID,  Po.eknumber,PO.Season ,"
            str &= " convert(varchar,Po.ShipmentDate,106) as shipmentdate,"
            str &= " convert(varchar,Po.PlacementDate ,106) as PlacementDate,"
            str &= " cast(POD.Quantity as decimal(10,0)) as OrderQty,"
            str &= " C.CustomerName ,V.vendername,UM.UserName ,Po.PONo , "
            str &= " S.styleNo,SD.ColorRefNo as Article,SD.SizeRange,SD.Colorway,"
            str &= "  S.styleNo,SD.Article,SD.SizeRange,SD.Colorway,"
            str &= "  convert(varchar,QDI.InspectionDate,106) as InspectionDate,"
            str &= "  convert(varchar,QDI.CreationDate,106) as CreationDate,"
            str &= "  QDi.InspectedQty ,           "
            str &= "  QDi.InspectionStatus as 'InsType' ,QDI.InspStatus "
            str &= "  from QDInspection     QDI "
            str &= "   join PurchaseOrder po  on Po.POID=QDi.poid"
            str &= "   Join PurchaseorderDetail POD on POD.PODetailID =QDI.PODetailID      "
            str &= "  Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= "  Join Customer C on C.CustomerID=PO.Customerid   "
            str &= "  Join StyleMaster S on S.StyleID=POD.StyleID    "
            str &= "  JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID      "
            str &= "  join Umuser UM on UM.UserID=QDUserid "
            str &= "  where  QDI.InspectionDate between '" & StartDate & "' and '" & EndDate & "' "
            str &= "  order by MONTH(QDI.InspectionDate) ASC, Day(QDI.InspectionDate) ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTolerence(ByVal POID As Long)
            Dim str As String
            str = "   Select Toleranceindays from PurchaseOrder "
            str &= "  where  POID =" & POID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetError(ByVal POID As Long, ByVal PODetailID As Long)
            Dim str As String
            str = "  Select distinct ErrorID FROM QDInspection QDI"
            str &= " join QDInspectionError QDE on QDE.QDInspectionID=QDI.QDInspectionID"
            str &= " where  QDI.POID =" & POID
            str &= " And  QDI.PODetailID =" & PODetailID
            str &= " order by  QDE.ErrorID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetErrorMinor(ByVal POID As Long, ByVal PODetailID As Long)
            Dim str As String
            str = "  Select distinct ErrorID FROM QDInspection QDI"
            str &= " join QDInspectionErrorMinor QDE on QDE.QDInspectionID=QDI.QDInspectionID"
            str &= " where  QDI.POID =" & POID
            str &= " And  QDI.PODetailID =" & PODetailID
            str &= " order by  QDE.ErrorID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetErrorEdit(ByVal POID As Long, ByVal PODetailID As Long, ByVal QDInspectionID As Long)
            Dim str As String
            str = "  Select distinct ErrorID FROM QDInspection QDI"
            str &= " join QDInspectionError QDE on QDE.QDInspectionID=QDI.QDInspectionID"
            str &= " where  QDI.POID =" & POID
            str &= " And  QDI.PODetailID =" & PODetailID
            str &= " And  QDI.QDInspectionID =" & QDInspectionID
            str &= " order by  QDE.ErrorID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPassInspectionSCM()
            Dim str As String
            str = " Select Convert(Varchar,QDI.CreationDate,103)as CreationDate, PO.POID, PO.PONO,C.customerName,V.VenderName,Um.Username, S.styleNo, SD.Article"
            str &= " ,QDI.InspectedQty ,Convert(Varchar,QDI.InspectionDate,103)as InspectionDate,"
            str &= " QDI.InspectionStatus, QDI.InspStatus, QDI.Remarks"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Pass' "
            str &= " order by  PO.POID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFailInspectionSCM()
            Dim str As String
            str = " Select Convert(Varchar,QDI.CreationDate,103)as CreationDate, PO.POID, PO.PONO,C.customerName,V.VenderName,Um.Username, S.styleNo, SD.Article"
            str &= " ,QDI.InspectedQty ,Convert(Varchar,QDI.InspectionDate,103)as InspectionDate,"
            str &= " QDI.InspectionStatus, QDI.InspStatus, QDI.Remarks"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Fail' "
            str &= " order by  PO.POID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPassInspectionBMDistinctMerchant()
            Dim str As String
            str = " Select Distinct PO.Marchandid "
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Pass' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPassInspectionMarchant(ByVal Marchandid As Long)
            Dim str As String
            str = " Select Convert(Varchar,QDI.CreationDate,103)as CreationDate, PO.POID, PO.PONO,C.customerName,V.VenderName,Um.Username, S.styleNo, SD.Article"
            str &= " ,QDI.InspectedQty ,Convert(Varchar,QDI.InspectionDate,103)as InspectionDate,"
            str &= " QDI.InspectionStatus, QDI.InspStatus, QDI.Remarks"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Pass' "
            str &= " and PO.Marchandid=" & Marchandid
            str &= " order by  PO.POID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFailInspectionBMDistinctMerchant()
            Dim str As String
            str = " Select Distinct PO.Marchandid "
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Fail' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFailInspectionMarchant(ByVal Marchandid As Long)
            Dim str As String
            str = " Select Convert(Varchar,QDI.CreationDate,103)as CreationDate, PO.POID, PO.PONO,C.customerName,V.VenderName,Um.Username, S.styleNo, SD.Article"
            str &= " ,QDI.InspectedQty ,Convert(Varchar,QDI.InspectionDate,103)as InspectionDate,"
            str &= " QDI.InspectionStatus, QDI.InspStatus, QDI.Remarks"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final'  and InspStatus='Fail' "
            str &= " and PO.Marchandid=" & Marchandid
            str &= " order by  PO.POID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPassInspectionDistinctSupplier()
            Dim str As String
            str = " Select Distinct PO.SupplierID,V.Vendername "
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Pass' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPassInspectionSupplier(ByVal SupplierID As Long)
            Dim str As String
            str = " Select Convert(Varchar,QDI.CreationDate,103)as CreationDate, PO.POID, PO.PONO,C.customerName,V.VenderName,Um.Username, S.styleNo, SD.Article"
            str &= " ,QDI.InspectedQty ,Convert(Varchar,QDI.InspectionDate,103)as InspectionDate,"
            str &= " QDI.InspectionStatus, QDI.InspStatus, QDI.Remarks"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Pass' "
            str &= " and PO.SupplierID=" & SupplierID
            str &= " order by  PO.POID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFailInspectionDistinctSupplier()
            Dim str As String
            str = " Select Distinct PO.SupplierID,V.Vendername "
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Fail' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFailInspectionSupplier(ByVal SupplierID As Long)
            Dim str As String
            str = " Select Convert(Varchar,QDI.CreationDate,103)as CreationDate, PO.POID, PO.PONO,C.customerName,V.VenderName,Um.Username, S.styleNo, SD.Article"
            str &= " ,QDI.InspectedQty ,Convert(Varchar,QDI.InspectionDate,103)as InspectionDate,"
            str &= " QDI.InspectionStatus, QDI.InspStatus, QDI.Remarks"
            str &= " from PurchaseOrder po "
            str &= " join QDInspection QDI on QDI.POID=PO.POID"
            str &= " Join PurchaseorderDetail POD on QDI.PODetailID=pod.PODetailID"
            str &= " Join StyleMaster S on S.StyleID=POD.StyleID   "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
            str &= "  join Umuser UM on UM.UserID=QDI.QDUserID   "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= " Join Customer C on C.CustomerID=PO.Customerid   "
            str &= " where Year(QDI.CreationDate) = Year(getdate()) And Month(QDI.CreationDate) = Month(getdate()) "
            str &= " and day(QDI.CreationDate) = day(getdate()) and InspectionStatus='Final' and InspStatus='Fail' "
            str &= " and PO.SupplierID=" & SupplierID
            str &= " order by  PO.POID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function


    End Class


End Namespace