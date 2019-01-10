Imports System.Data

Namespace EuroCentra
    Public Class PurchaseOrderDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PurchaseOrderDetail"
            m_strPrimaryFieldName = "PODetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lPODetailID As Long
        Private m_lPOID As Long
        '  Private m_strArticle As String
        '  Private m_iSizeDec As String
        '  Private m_iColor As String
        Private m_dQuantity As Decimal
        Private m_dRate As Decimal
        Private m_lStyleId As Long
        ' Private m_strItemDescription As String
        Private m_strRemarks As String
        Private m_lStyleDetailID As Long

        Private m_DetailShipmentDate As Date
        Private m_DetailShipmentMode As String

        ''----------Properties
        Public Property DetailShipmentDate() As Date
            Get
                DetailShipmentDate = m_DetailShipmentDate
            End Get
            Set(ByVal Value As Date)
                m_DetailShipmentDate = Value
            End Set
        End Property
        Public Property DetailShipmentMode() As String
            Get
                DetailShipmentMode = m_DetailShipmentMode
            End Get
            Set(ByVal Value As String)
                m_DetailShipmentMode = Value
            End Set
        End Property


        Public Property StyleDetailID() As Long
            Get
                StyleDetailID = m_lStyleDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStyleDetailID = Value
            End Set
        End Property
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal Value As Long)
                m_lPODetailID = Value
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
        'Public Property Article() As String
        '    Get
        '        Article = m_strArticle
        '    End Get
        '    Set(ByVal value As String)
        '        m_strArticle = value
        '    End Set
        'End Property
        'Public Property SizeDec() As String
        '    Get
        '        SizeDec = m_iSizeDec
        '    End Get
        '    Set(ByVal value As String)
        '        m_iSizeDec = value
        '    End Set
        'End Property
        'Public Property Color() As String
        '    Get
        '        Color = m_iColor
        '    End Get
        '    Set(ByVal value As String)
        '        m_iColor = value
        '    End Set
        'End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dQuantity = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = m_dRate
            End Get
            Set(ByVal value As Decimal)
                m_dRate = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleId
            End Get
            Set(ByVal value As Long)
                m_lStyleId = value
            End Set
        End Property
        'Public Property ItemDescription() As String
        '    Get
        '        ItemDescription = m_strItemDescription
        '    End Get
        '    Set(ByVal value As String)
        '        m_strItemDescription = value
        '    End Set
        'End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        Public Function SavePODetailSetup()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPODetailId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function

        Public Function GetPODetailById(ByVal lPODetailId As Long)
            Try
                Return MyBase.GetById(lPODetailId)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetailById(ByVal lPODetailId As Long)
            Dim str As String = "Delete PurchaseOrderDetail where PODetailID=" & lPODetailId
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getPOdetailByPOID(ByVal lPOID As Long)
            Dim str As String '= "Select *,cast(rate * Quantity as decimal(10,2))Amount from  PurchaseOrderDetail POD Join Style S on S.StyleID=POD.StyleID  where POID=" & lPOID

            ' str = "Select PODetailID,S.StyleID,Article,StyleNo,Size,ItemDescription,"
            ' str &= " (case when IsNull((Select top 1  AMDD.Remarks from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.Remarks else (Select top 1 ISNull(AMDD.Remarks,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )as Remarks,"
            ' str &= " (case when IsNull((Select top 1  AMDD.Quantity from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.Quantity else (Select top 1 ISNull(AMDD.Quantity,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )as Quantity"
            ' str &= " ,(case when IsNull((Select top 1  AMDD.rate from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.rate else (Select top 1 ISNull(AMDD.rate,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )as itemprice"
            ' str &= " ,cast( (case when IsNull((Select top 1  AMDD.rate from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.rate else (Select top 1 ISNull(AMDD.rate,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )"
            ' str &= " *(case when IsNull((Select top 1  AMDD.Quantity from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.Quantity else (Select top 1 ISNull(AMDD.Quantity,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end ) as decimal(10,2))as Amount"
            ' str &= " from  PurchaseOrderDetail POD Join Style S on S.StyleID=POD.StyleID "
            ' str &= "  where POID = " & lPOID

            str = "Select PODetailID,S.StyleID,Article,StyleNo,Size,ItemDescription,"
            str &= " (case when IsNull((Select top 1  AMDD.Remarks from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.Remarks else (Select top 1 ISNull(AMDD.Remarks,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )as Remarks,"
            str &= " (Quantity-IsNull((Select SUM(AMDD.Quantity) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID ),0))as Quantity "
            str &= " ,(case when IsNull((Select top 1  AMDD.rate from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.rate else (Select top 1 ISNull(AMDD.rate,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )as itemprice"
            str &= " ,cast( (case when IsNull((Select top 1  AMDD.rate from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ),0) =0 then POD.rate else (Select top 1 ISNull(AMDD.rate,0) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID order by POAmendmentDetailID Desc ) end )"
            str &= " *(Quantity-IsNull((Select SUM(AMDD.Quantity) from POAmendmentDetail AMDD where AMDD.PODetailID=POD.PODetailID ),0) ) as decimal(10,2))as Amount"
            str &= " from  PurchaseOrderDetail POD Join Style S on S.StyleID=POD.StyleID "
            str &= "  where POID = " & lPOID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleToPO(ByVal StyleID As Long) As DataTable
            Dim str As String = " select * from StyleDetail where StyleID= " & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateRemarksFromWIP(ByVal lPODetailId As Long, ByVal Remarks As String)
            Dim str As String = "update PurchaseOrderDetail set Remarks='" & Remarks & "'  where PODetailID=" & lPODetailId
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletePurchaseOrderDetail(ByVal PODetailID As Long)
            Dim str As String
            str = " Delete  from PurchaseOrderDetail where PODetailID ='" & PODetailID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadAllStyle(ByVal POID As Long)
            Dim Str As String
            Str = "   select distinct stm.StyleID,stm.StyleNo, convert(varchar,PO.ShipmentDate,103)as ShipmentDatee"
            Str &= " from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "   join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "   join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "   join Umuser U on U.Userid=Po.Marchandid"
            Str &= "    where  POD.POID=" & POID
            Str &= "   order by stm.StyleNo ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function LoadAllStyleQty(ByVal POID As Long, ByVal StyleNo As String)
            Dim Str As String
            Str = "   select cast(Sum(POD.Quantity) as decimal(10,0))as TotalQty "
            Str &= "  from PurchaseOrder Po"
            Str &= "  join PurchaseOrderDetail POD on POD.POID =Po.POID "
            Str &= "   join StyleMaster stm on stm.StyleID =POd.StyleID "
            Str &= "  join StyleDetail std on std.StyleDetailID =POD.StyleDetailID "
            Str &= "  join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "   join Vender v on v.VenderLibraryID =po.SupplierID  "
            Str &= "   join Umuser U on U.Userid=Po.Marchandid"
            Str &= "  where  POD.POID=" & POID
            Str &= "  and stm.StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetOpenOrdersSCM()
            Dim Str As String
            Str = "  select PO.PONO,C.customername,V.vendername,(case when PO.Potype='Repeat' then 'R' else 'N' end ) as Potype,"
            Str &= " IsNull((Select Sum(POD.Quantity) From PurchaseorderDetail POD Where POD.POID=PO.POID),0)as Quantity,"
            Str &= " IsNull((Select Sum(POD.Quantity * POD.Rate) From PurchaseorderDetail POD Where POD.POID=PO.POID),0)as Value,"
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,U.username,PO.timespame "
            Str &= " from Purchaseorder PO"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid "
            Str &= "  where Year(Po.Creationdate) = Year(getdate()) And Month(Po.Creationdate) = Month(getdate()) "
            Str &= " and day(Po.Creationdate) = day(getdate()) and Po.Status='Booked'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetOpenOrdersDistinctMarchant()
            Dim Str As String
            Str = "  select Distinct PO.Marchandid "
            Str &= " from Purchaseorder PO"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid "
            Str &= "  where Year(Po.Creationdate) = Year(getdate()) And Month(Po.Creationdate) = Month(getdate()) "
            Str &= " and day(Po.Creationdate) = day(getdate()) and Po.Status='Booked'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetOpenOrdersMarchant(ByVal Marchandid As Long)
            Dim Str As String
            Str = "  select PO.PONO,C.customername,V.vendername,(case when PO.Potype='Repeat' then 'R' else 'N' end ) as Potype,"
            Str &= " IsNull((Select Sum(POD.Quantity) From PurchaseorderDetail POD Where POD.POID=PO.POID),0)as Quantity,"
            Str &= " IsNull((Select Sum(POD.Quantity * POD.Rate) From PurchaseorderDetail POD Where POD.POID=PO.POID),0)as Value,"
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,U.username,PO.timespame"
            Str &= " from Purchaseorder PO"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid "
            Str &= "  where Year(Po.Creationdate) = Year(getdate()) And Month(Po.Creationdate) = Month(getdate()) "
            Str &= " and day(Po.Creationdate) = day(getdate()) and Po.Status='Booked'"
            Str &= " and Po.Marchandid=" & Marchandid
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetOpenOrdersDistinctSupplier()
            Dim Str As String
            Str = "  select Distinct PO.SupplierID "
            Str &= " from Purchaseorder PO"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid "
            Str &= "  where Year(Po.Creationdate) = Year(getdate()) And Month(Po.Creationdate) = Month(getdate()) "
            Str &= " and day(Po.Creationdate) = day(getdate()) and Po.Status='Booked'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetOpenOrdersSupplier(ByVal SupplierID As Long)
            Dim Str As String
            Str = "  select PO.PONO,C.customername,V.vendername,(case when PO.Potype='Repeat' then 'R' else 'N' end ) as Potype,"
            Str &= " IsNull((Select Sum(POD.Quantity) From PurchaseorderDetail POD Where POD.POID=PO.POID),0)as Quantity,"
            Str &= " IsNull((Select Sum(POD.Quantity * POD.Rate) From PurchaseorderDetail POD Where POD.POID=PO.POID),0)as Value,"
            Str &= " CONVERT(VARCHAR(11), PO.PlacementDate, 103) AS PlacementDate,"
            Str &= " CONVERT(VARCHAR(11), PO.ShipmentDate, 103) AS ShipmentDate,U.username,PO.timespame"
            Str &= " from Purchaseorder PO"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " Join Customer C on C.CustomerID=PO.CustomerID "
            Str &= " join Umuser U on U.userid=Po.Marchandid "
            Str &= "  where Year(Po.Creationdate) = Year(getdate()) And Month(Po.Creationdate) = Month(getdate()) "
            Str &= " and day(Po.Creationdate) = day(getdate()) and Po.Status='Booked'"
            Str &= " and Po.SupplierID=" & SupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPODetailForClose(ByVal IPOID As Long)
            Dim str As String
            Try
                str = " select PO.POID,PO.PONO,PO.POrefNO,C.Customername,V.Vendername"
                str &= " ,PO.Placementdate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,S.styleNo,S.StyleName,sd.article,SD.sizerange, POD.PODetailID"
                str &= " ,SD.Colorway,  (Select Top 1 PRS.ShipmentDate from PurchaseOrderReviseShipment PRS  where PRS.POID=PO.POID "
                str &= " order by PRS.POReviseShipmentID DESC) as  RevisedShipmentDate "
                str &= " ,POD.Quantity as BookedQty,"
                str &= " isnull((Select Sum(Cd.Quantity) from CargoDetail CD where CD.POID=POD.PODetailID),0)As ShippedQty,"
                str &= " (POD.Quantity - isnull((Select Sum(Cd.Quantity) from CargoDetail CD where CD.POID=POD.PODetailID),0)"
                str &= " - isnull((Select Sum(POCD.CancelQty) from POCancelDetail POCD where POCD.PODetailID=POD.PODetailID),0)) as Difference ,"
                str &= "  (case when PO.status='Cancel' then"
                str &= "  'Cancel' else"
                str &= " (Case when  (Select isnull(SUM(CPOD.Quantity),0)"
                str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID)=0 and"
                str &= " (select count(distinct PODetailID) as PODetailID from POCancelDetail PCD "
                str &= " where PCD.PODetailID=POD.PODetailID)=0"
                str &= " then   'Open' "
                str &= "  when (Select isnull(SUM(CPOD.Quantity),0)"
                str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID)=0 and"
                str &= " (select count(distinct PODetailID) as PODetailID from POCancelDetail PCD "
                str &= "  where PCD.PODetailID=POD.PODetailID)>0 then "
                str &= " 'Cancel'"
                str &= " when (Select isnull(SUM(CPOD.Quantity),0)"
                str &= "  from CargoDetail CPOD where CPOD.POID =POD.PODetailID) "
                str &= " <  round((POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100),0) then "
                str &= " 'Shipped with shortfall'"
                str &= " when (Select isnull(SUM(CPOD.Quantity),0)"
                str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID) "
                str &= "  >= round((POD.Quantity - (POD.Quantity*PO.Toleranceindays)/100),0)"
                str &= " and (Select isnull(SUM(CPOD.Quantity),0)"
                str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID)<"
                str &= "  round((POD.Quantity + (POD.Quantity * PO.Toleranceindays) / 100), 0)"
                str &= " then  'Shipped'"
                str &= " when (Select isnull(SUM(CPOD.Quantity),0)"
                str &= " from CargoDetail CPOD where CPOD.POID =POD.PODetailID)="
                str &= "  round((POD.Quantity + (POD.Quantity * PO.Toleranceindays) / 100), 0)"
                str &= "  then   'Shipped'  else    'Shipped with excess'    end)end)  as ArticleStatus"
                str &= "  , isnull((Select Sum(POCD.CancelQty) from POCancelDetail POCD where POCD.PODetailID=POD.PODetailID),0) as CancelQty "
                str &= "  from Purchaseorder Po"
                str &= " Join PurchaseorderDetail POD on po.poid=pod.poid     "
                str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
                str &= " Join Customer C on C.CustomerID=PO.Customerid     "
                str &= " Join StyleMaster S on S.StyleID=POD.StyleID    "
                str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID    "
                str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID    "
                str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID    "
                str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
                str &= " where Year(PO.ShipmentDate) >= 2013"
                str &= " and PO.POID=" & IPOID
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdatePOStatus(ByVal POID As Long)
            Dim Str As String
            Str = " Update Purchaseorder Set Status='Close',creationdate='" & Date.Now & "'"
            Str &= " where POID=" & POID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace