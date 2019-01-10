Imports System.Data
    Namespace EuroCentra
    Public Class LeadTimeApproved
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "LeadTimeApproval"
            m_strPrimaryFieldName = "LeadTimeApprovalID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lLeadTimeApprovalID As Long
        Private m_dtCreationDate As Date
        Private m_lPOID As Long
        Private m_lMerchantID As Long
        Private m_strStatus As String
        ''---------------- Properties
        Public Property LeadTimeApprovalID() As Long
            Get
                LeadTimeApprovalID = m_lLeadTimeApprovalID
            End Get
            Set(ByVal value As Long)
                m_lLeadTimeApprovalID = value
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
        Public Property MerchantID() As Long
            Get
                MerchantID = m_lMerchantID
            End Get
            Set(ByVal value As Long)
                m_lMerchantID = value
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
        Public Function SaveLeadTimeApproval()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetErrorById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLeadTimeApprovalForNewOrder(ByVal Marchandid As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID, C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype ,PO.timespame"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where Day(Po.CreationDate) >= 1 And Month(Po.CreationDate) >= 10 And Year(Po.CreationDate) >= 2013"
            Str &= " and Po.Status='Booked' and Po.POtype='New' and PO.timespame <= 70 "
            Str &= " and isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0) <= 5000"
            Str &= " and PO.POID not in (select POID from LeadTimeApproval)"
            If Marchandid = 26 Then
                'ALL 
            ElseIf Marchandid = 28 Then
                'ALL 
            ElseIf Marchandid = 93 Then
                'ALL 
            ElseIf Marchandid = 93 Then
                'ALL 
            ElseIf Marchandid = 77 Then
                'ALL 
            Else
                Str &= " and Po.MarchandID=" & Marchandid
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLeadTimeApprovalForRepeatOrder(ByVal Marchandid As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID, C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype ,PO.timespame"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where Day(Po.CreationDate) >= 1 And Month(Po.CreationDate) >= 10 And Year(Po.CreationDate) >= 2013"
            Str &= " and Po.Status='Booked' and Po.POtype='Repeat' and PO.timespame <= 30 "
            Str &= " and isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0) <= 5000"
            Str &= " and PO.POID not in (select POID from LeadTimeApproval)"
            If Marchandid = 26 Then
                'ALL 
            ElseIf Marchandid = 28 Then
                'ALL 
            ElseIf Marchandid = 93 Then
                'ALL 
            ElseIf Marchandid = 77 Then
                'ALL 
            Else
                Str &= " and Po.MarchandID=" & Marchandid
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLeadTimeApprovalDistinctMarchant()
            Dim Str As String
            Str = "  Select distinct po.MarchandID,U.Username "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where Day(Po.CreationDate) >= 1 And Month(Po.CreationDate) >= 10 And Year(Po.CreationDate) >= 2013"
            Str &= " and Po.Status='Booked' and Po.POtype='Repeat' and PO.timespame <= 30 "
            Str &= " and isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0) <= 5000"
            Str &= " and PO.POID not in (select POID from LeadTimeApproval)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLeadTimeApprovalDistinctMarchant1()
            Dim Str As String
            Str = "  Select distinct po.MarchandID,U.Username "
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where Day(Po.CreationDate) >= 1 And Month(Po.CreationDate) >= 10 And Year(Po.CreationDate) >= 2013"
            Str &= " and Po.Status='Booked' and Po.POtype='New' and PO.timespame <= 70 "
            Str &= " and isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0) <= 5000"
            Str &= " and PO.POID not in (select POID from LeadTimeApproval)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLeadTimeApprovalForNewOrderAlready(ByVal Marchandid As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID, C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype ,PO.timespame"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where PO.POID in (select POID from LeadTimeApproval)"
            If Marchandid = 26 Then
                'ALL 
            ElseIf Marchandid = 28 Then
                'ALL 
            ElseIf Marchandid = 93 Then
                'ALL 
            ElseIf Marchandid = 77 Then
                'ALL 
            Else
                Str &= " and Po.MarchandID=" & Marchandid
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLeadTimeApprovalForRepeatOrderAlready(ByVal Marchandid As Long)
            Dim Str As String
            Str = "  Select po.MarchandID,PO.POID, C.Aliass as CustomerName,PO.EKNumber,  V.ShortName as VenderName"
            Str &= " ,u.ECPDivistion ,u.UserName as UserName, PO.Season,PO.Design"
            Str &= " as 'ProductPortfolio' ,stuff(PO.ProductCategories,5,40,'..') "
            Str &= " as 'ProductCategories',stuff(PO.ProductGroup,7,40,'..')  as "
            Str &= " 'ProductGroup',PO.Composition as 'Composition',  stuff(PO.Quality,7,40,'..')"
            Str &= " as 'Blend',PO.ProcessType as 'ProcessType',Po.Destination , "
            Str &= " po.PONO,  isnull((Select Sum(POD.Quantity * POD.Rate) "
            Str &= " from PurchaseorderDetail POD where POD.POID=PO.POID),0)as Value , "
            Str &= " isnull((Select Sum(POD.Quantity) from PurchaseorderDetail POD where "
            Str &= " POD.POID=PO.POID),0)as Quantity ,PO.Toleranceindays as 'Tolerance', "
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) as PlacementDate "
            Str &= " ,CONVERT(VARCHAR(11), PO.ShipmentDate, 103) as ShipmentDate   "
            Str &= " ,(Select Top 1 Convert(Varchar,PRS.ShipmentDate,103) as ShipmentDate "
            Str &= " from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
            Str &= " order by PRS.POReviseShipmentID DESC) as 'LastRev',PO.Currency  "
            Str &= " ,Convert(Varchar,PO.CreationDate,103) as CreationDate  ,Po.POtype ,PO.timespame"
            Str &= " from PurchaseOrder Po "
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " join UMUser U on u.UserId =po.MarchandID "
            Str &= " where PO.POID in (select POID from LeadTimeApproval)"
            If Marchandid = 26 Then
                'ALL 
            ElseIf Marchandid = 28 Then
                'ALL 
            ElseIf Marchandid = 93 Then
                'ALL
            ElseIf Marchandid = 77 Then
                'ALL 
            Else
                Str &= " and Po.MarchandID=" & Marchandid
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function


    End Class
End Namespace

