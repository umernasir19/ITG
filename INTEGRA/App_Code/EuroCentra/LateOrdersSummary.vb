Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Public Class LateOrdersSummary
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "LateOrdersSummary"
        m_strPrimaryFieldName = "LOSID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lLOSID As Long
    Private m_lSupplierID As Long
    Private m_strSupplierName As String
    Private m_lCustomerID As Long
    Private m_strCustomerName As String
    Private m_dcShippedPOsOnTime As Decimal
    Private m_dcBookedForPOs As Decimal
    Private m_strECPDivision As String
    Private m_dcDelayedByWeek1 As Decimal
    Private m_dcDelayedByWeek2 As Decimal
    Private m_dcDelayedByWeek3 As Decimal
    Private m_dcDelayedByWeek4 As Decimal
    Private m_dcDelayedByWeek4Plus As Decimal
    Private m_dtCreationDate As Date
    '-----------------------------------------------------
    Public Property LOSID() As Long
        Get
            LOSID = m_lLOSID
        End Get
        Set(ByVal value As Long)
            m_lLOSID = value
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
    Public Property SupplierID() As Long
        Get
            SupplierID = m_lSupplierID
        End Get
        Set(ByVal value As Long)
            m_lSupplierID = value
        End Set
    End Property
    Public Property SupplierName() As String
        Get
            SupplierName = m_strSupplierName
        End Get
        Set(ByVal value As String)
            m_strSupplierName = value
        End Set
    End Property
    Public Property ECPDivision() As String
        Get
            ECPDivision = m_strECPDivision
        End Get
        Set(ByVal value As String)
            m_strECPDivision = value
        End Set
    End Property
    Public Property CustomerID() As Long
        Get
            CustomerID = m_lCustomerID
        End Get
        Set(ByVal value As Long)
            m_lCustomerID = value
        End Set
    End Property
    Public Property CustomerName() As String
        Get
            CustomerName = m_strCustomerName
        End Get
        Set(ByVal value As String)
            m_strCustomerName = value
        End Set
    End Property
    Public Property ShippedPOsOnTime() As Decimal
        Get
            ShippedPOsOnTime = m_dcShippedPOsOnTime
        End Get
        Set(ByVal value As Decimal)
            m_dcShippedPOsOnTime = value
        End Set
    End Property
    Public Property BookedForPOs() As Decimal
        Get
            BookedForPOs = m_dcBookedForPOs
        End Get
        Set(ByVal value As Decimal)
            m_dcBookedForPOs = value
        End Set
    End Property
    Public Property DelayedByWeek1() As Decimal
        Get
            DelayedByWeek1 = m_dcDelayedByWeek1
        End Get
        Set(ByVal value As Decimal)
            m_dcDelayedByWeek1 = value
        End Set
    End Property
    Public Property DelayedByWeek2() As Decimal
        Get
            DelayedByWeek2 = m_dcDelayedByWeek2
        End Get
        Set(ByVal value As Decimal)
            m_dcDelayedByWeek2 = value
        End Set
    End Property
    Public Property DelayedByWeek3() As Decimal
        Get
            DelayedByWeek3 = m_dcDelayedByWeek3
        End Get
        Set(ByVal value As Decimal)
            m_dcDelayedByWeek3 = value
        End Set
    End Property
    Public Property DelayedByWeek4() As Decimal
        Get
            DelayedByWeek4 = m_dcDelayedByWeek4
        End Get
        Set(ByVal value As Decimal)
            m_dcDelayedByWeek4 = value
        End Set
    End Property
    Public Property DelayedByWeek4plus() As Decimal
        Get
            DelayedByWeek4plus = m_dcDelayedByWeek4Plus
        End Get
        Set(ByVal value As Decimal)
            m_dcDelayedByWeek4Plus = value
        End Set
    End Property
    Public Function SaveLateOrdersSummary()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function TruncateTable() As DataTable
        Dim Str As String
        Str = "Truncate table LateOrdersSummary "
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetMgtSupplierData()
        Dim Str As String
        Str = "  select Distinct  V.venderlibraryid ,V.VenderName from vender V "
        Str &= " join Purchaseorder Po on Po.SupplierID= V.venderlibraryid"
        Str &= " where Year(po.ShipmentDate) >=2013 "
        Str &= "  order by V.VenderName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMgtCustomerData(ByVal FromDate As Date, ByVal ToDate As Date, ByVal SupplierID As Long)
        Dim Str As String
        Str = "  select Distinct C.CustomerID, C.CustomerName From Customer C "
        Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID "
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel'  And PO.SupplierID = " & SupplierID
        Str &= " order by C.CustomerName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMgtCustomerDataNew(ByVal FromDate As String, ByVal ToDate As String, ByVal SupplierID As Long)
        Dim Str As String
        Str = "  select Distinct C.CustomerID, C.CustomerName From Customer C "
        Str &= " join Purchaseorder Po on Po.CustomerID= C.CustomerID "
        Str &= "   where po.ShipmentDate between '" & FromDate & "' and '" & ToDate & "'   and po.status !='Cancel'  And PO.SupplierID = " & SupplierID
        Str &= " order by C.CustomerName ASC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTime(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'   "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTShippedPOsOnTimeNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "'   "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 <=0 "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOs(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMGTBookedForPOsNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Distinct Count(PO.POID) as TotalBookedPos from PurchaseOrder PO "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= " where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDelayedPos(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal WeekNo As Decimal, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 = " & WeekNo

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDelayedPosNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal WeekNo As Decimal, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "'  and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= " ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 = " & WeekNo

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDelayedByWeek4Plus(ByVal Fromdate As Date, ByVal ToDate As Date, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "  ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 > 4 "

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDelayedByWeek4PlusNew(ByVal Fromdate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long, ByVal ECPDivision As String)
        Dim Str As String
        Str = " select  Count(Distinct PO.POID)  as ShippedPOsOnTime  from Cargodetail cd"
        Str &= " join Cargo c on c.cargoid=cd.cargoid"
        Str &= " join purchaseorder po on po.poid=cd.popoid "
        Str &= " Join UMUser UM on UM.UserId = PO.MarchandID "
        Str &= "  where PO.ShipmentDate between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "   and PO.POID in ( select  Distinct PO.POID from PurchaseOrder PO "
        Str &= " where PO.ShipmentDate  between '" & Fromdate & "' and '" & ToDate & "' and  po.status !='Close' "
        Str &= " and po.status !='Cancel' And PO.SupplierID = '" & SupplierID & "' And PO.CustomerID = '" & CustomerID & "' And UM.ECPDivistion = '" & ECPDivision & "' "
        Str &= "  ) and (DATEDIFF(dd, PO.ShipmentDate , C.ETD))/7 > 4 "

        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetECPDivision(ByVal FromDate, ByVal ToDate, ByVal SupplierID, ByVal CustomerID) As DataTable
        Dim str As String
        str = "select Distinct U.ECPDivistion from Umuser U "
        str &= " join Purchaseorder Po on Po.Marchandid=U.Userid"
        str &= " Join Customer C on C.CustomerID = PO.CustomerID"
        str &= " Join Vender V on V.VenderLibraryID = PO.SupplierID "
        str &= " where PO.ShipmentDate  between '" & FromDate & "' and '" & ToDate & "' And V.VenderLibraryID = '" & SupplierID & "'  And  C.CustomerID = '" & CustomerID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetECPDivisionNew(ByVal FromDate As String, ByVal ToDate As String, ByVal SupplierID As Long, ByVal CustomerID As Long) As DataTable
        Dim str As String
        str = "select Distinct U.ECPDivistion from Umuser U "
        str &= " join Purchaseorder Po on Po.Marchandid=U.Userid"
        str &= " Join Customer C on C.CustomerID = PO.CustomerID"
        str &= " Join Vender V on V.VenderLibraryID = PO.SupplierID "
        str &= " where PO.ShipmentDate  between '" & FromDate & "' and '" & ToDate & "' And V.VenderLibraryID = '" & SupplierID & "'  And  C.CustomerID = '" & CustomerID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
