Imports System.Data
Imports Microsoft.VisualBasic

Public Class WIPChart
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "WIPChart"
        m_strPrimaryFieldName = "WIPChartId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lWIPChartId As Long
    Private m_lWIPProcessID As Long
    Private m_lPOId As Long
    Private m_strStatus As String
    Private m_dtCreationDate As Date
    Private m_lPOdetailID As Long
    Private m_lUserid As Long
    Private m_strRemarks As String
    ''---------------- Properties
    Public Property Remarks() As String
        Get
            Remarks = m_strRemarks
        End Get
        Set(ByVal value As String)
            m_strRemarks = value
        End Set
    End Property
    Public Property POdetailID() As Long
        Get
            POdetailID = m_lPOdetailID
        End Get
        Set(ByVal value As Long)
            m_lPOdetailID = value
        End Set
    End Property
    Public Property Userid() As Long
        Get
            Userid = m_lUserid
        End Get
        Set(ByVal value As Long)
            m_lUserid = value
        End Set
    End Property
    Public Property WIPChartId() As Long
        Get
            WIPChartId = m_lWIPChartId
        End Get
        Set(ByVal value As Long)
            m_lWIPChartId = value
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
            POID = m_lPOId
        End Get
        Set(ByVal Value As Long)
            m_lPOId = Value
        End Set
    End Property
    Public Property WIPProcessID() As Long
        Get
            WIPProcessID = m_lWIPProcessID
        End Get
        Set(ByVal value As Long)
            m_lWIPProcessID = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Status = m_strStatus
        End Get
        Set(ByVal value As String)
            m_strStatus = value
        End Set
    End Property
    Public Function SaveWIPChart()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTNAChartById(ByVal lWIPChartId As Long)
        Try
            Return MyBase.GetById(lWIPChartId)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Function GetCurrentWIPProcess(ByVal POID As Long, ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select Top 1 * from WIPChart WC"
        Str &= " join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
        Str &= "  where WC.POID='" & POID & "' and POdetailID= '" & PODetailID & "'"
        Str &= " order by WC.WIPChartId DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetCurrentWIPProcess1(ByVal POID As Long, ByVal Article As String) As DataTable
        Dim Str As String
        Str = " Select Top 1 * from WIPChart WC"
        Str &= " join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
        Str &= " join PurchaseorderDetail POD on WC.POdetailID=POD.POdetailID"
        Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
        Str &= "  where WC.POID='" & POID & "' and SD.Article= '" & Article & "'"
        Str &= " order by WC.WIPChartId DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetCurrentWIPProcess2(ByVal POID As Long, ByVal Article As String) As DataTable
        Dim Str As String
        Str &= " Select  * from  PurchaseorderDetail POD "
        Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
        Str &= " where POD.POID='" & POID & "'  and SD.Article=  '" & Article & "'order by POD.PODetailID DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetAllWIPProcess(ByVal POID As Long, ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select  *,upper(U.UserName)as UserNameF  from WIPChart WC"
        Str &= " join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
        Str &= " join Umuser u on u.userid=WC.Userid"
        Str &= "  where WC.Remarks <>'' and WC.POID='" & POID & "' and POdetailID= '" & PODetailID & "'"
        Str &= " order by WC.WIPChartId DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetStatusOfExistingArticleOfOrder(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = "  Select   Distinct WC.PODetailID  from WIPChart WC   "
        Str &= "  where WC.WIPProcessID  = 12 and  WC.POID='" & POID & "' "
        'Str = " Select * from WIPChart WC "
        'Str &= "  where WC.WIPProcessID  <> 12 and  WC.POID='" & POID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetWIPArticleOfOrder(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select  Distinct WC.PODetailID from   WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleOfOrder(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select  Distinct POD.PODetailID from   purchaseorderDetail POD   "
        Str &= "  where POD.POID = " & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMail(ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.PODetailID = " & PODetailID
        Str &= "  and WC.WIPProcessID  >= 6"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetPOForMasterMail(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Str &= "  and WC.WIPProcessID  >= 6"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMailCutting(ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.PODetailID = " & PODetailID
        Str &= "  and WC.WIPProcessID  >= 9"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMasterMailCutting(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Str &= "  and WC.WIPProcessID  >= 9"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetPOPacking(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Str &= "  and WC.WIPProcessID = 11"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetPOReleased(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Str &= "  and WC.WIPProcessID  = 12"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMailYarnProcurement(ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.PODetailID = " & POdetailID
        Str &= "  and WC.WIPProcessID  >= 5"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMasterMailYarnProcurement(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Str &= "  and WC.WIPProcessID  >= 5"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMasterGoodsRelease(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Str &= "  and WC.WIPProcessID  >= 12"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetWIPChartTracking(ByVal POID As Long, ByVal WIPProcessID As Long) As DataTable
        Dim Str As String
        Str = " Select Count(Distinct WC.PODetailID) as WIPArticle from   WIPChart WC   "
        Str &= " where WC.POID = " & POID
        Str &= " and WC.WIPProcessID =" & WIPProcessID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetWIPEstimatedDate(ByVal POID As Long, ByVal WIPProcessID As Long) As DataTable
        Dim Str As String
        Dim Percent As Decimal = 0
        If WIPProcessID = 1 Then
            Percent = 2
        ElseIf WIPProcessID = 2 Then
            Percent = 3
        ElseIf WIPProcessID = 3 Then
            Percent = 4
        ElseIf WIPProcessID = 4 Then
            Percent = 5
        ElseIf WIPProcessID = 5 Then
            Percent = 11
        ElseIf WIPProcessID = 6 Then
            Percent = 45
        ElseIf WIPProcessID = 7 Then
            Percent = 56
        ElseIf WIPProcessID = 8 Then
            Percent = 60
        ElseIf WIPProcessID = 9 Then
            Percent = 70
        ElseIf WIPProcessID = 10 Then
            Percent = 90
        ElseIf WIPProcessID = 11 Then
            Percent = 98
        ElseIf WIPProcessID = 12 Then
            Percent = 100
        End If

        Str = "Select Convert(Varchar,DATEADD(DAY,(Round(((" & Percent & " * PO.timespame)/100),0)),PO.PlacementDate),103) as EstimatedDate from Purchaseorder Po"
        Str &= " where PO.POID = " & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetTopWIPChartTracking(ByVal POID As Long, ByVal WIPProcessID As Long) As DataTable
        Dim Str As String
        Str = " Select top 1 Convert(Varchar,Wc.Creationdate,103) as ActivityDate  from   WIPChart WC   "
        Str &= " where WC.POID = " & POID
        Str &= " and WC.WIPProcessID =" & WIPProcessID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetBookedQty(ByVal POID As Long, ByVal WIPProcessID As Long) As DataTable
        Dim Str As String
        Str = " Select Sum(Quantity) as Quantity from purchaseorderDetail POD "
        Str &= " join WIPChart WC on WC.POdetailID=POD.POdetailID "
        Str &= " where WC.POID = " & POID
        Str &= " and WC.WIPProcessID =" & WIPProcessID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetTrackingData(ByVal StartDate As Date, ByVal Enddate As Date)
        Dim Str As String
        Str = " select Wc.WIPChartId ,Wc.POID ,po.PONO,C.Customername,V.Vendername"
        Str &= " ,Um.UserName , S.styleNo,sd.article,SD.sizerange,SD.Colorway,"
        Str &= "   pod.Quantity, WP.ProcessName, Convert(Varchar,Wc.CreationDate,106)as CreationDate"
        Str &= " ,convert(varchar,Po.ShipmentDate,106) as shipmentdate,"
        Str &= " convert(varchar,Po.PlacementDate ,106) as PlacementDate"
        Str &= " from WIPChart WC "
        Str &= " join WIPProcess Wp on wp.WIPProcessID =Wc.WIPProcessID "
        Str &= " join Purchaseorder Po on Po.POID=Wc.POID "
        Str &= " Join PurchaseorderDetail POD on POd.PODetailID =wc.POdetailID "
        Str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
        Str &= " Join Customer C on C.CustomerID=PO.Customerid     "
        Str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
        Str &= " JOIN StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID   "
        Str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
        Str &= " where Wc.CreationDate between '" & StartDate & "' and '" & Enddate & "'"
        Str &= "  order by MONTH(Wc.CreationDate) ASC, Day(Wc.CreationDate) ASC  "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function AutoFillWIP(ByVal marchandid As Long)
        Dim Str As String
        Str = " select   PO.POID,POD.PODetailID,PO.PONO, C.Customername, V.Vendername,po.marchandid,"
        Str &= " isnull((Select top 1 WIPProcessID  from WIPChart WC where"
        Str &= " WC.PODetailID=POD.PODetailID order by WC.WIPProcessID DESC),0 ) as WIPProcessID"
        Str &= " from Purchaseorder PO"
        Str &= " join PurchaseorderDetail POD on PO.POID=POD.POID"
        Str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
        Str &= " Join Customer C on C.CustomerID=PO.Customerid     "
        Str &= " where PO.status='Shipped' and Year(Shipmentdate)>=2013"
        Str &= " and po.marchandid=" & marchandid
        Str &= " and POD.PODetailID in (select Distinct POID from cargodetail)"
        Str &= " order by po.marchandid ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function DistinctMarchant()
        Dim Str As String
        Str = " select  Distinct po.marchandid "
        Str &= " from Purchaseorder PO"
        Str &= " join PurchaseorderDetail POD on PO.POID=POD.POID"
        Str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
        Str &= " Join Customer C on C.CustomerID=PO.Customerid     "
        Str &= " where PO.status='Shipped' and Year(Shipmentdate)>=2013"
        Str &= " order by po.marchandid ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function

End Class
