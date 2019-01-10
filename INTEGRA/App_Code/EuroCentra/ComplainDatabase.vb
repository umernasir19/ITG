Imports System.Data

Namespace EuroCentra
    Public Class ComplainDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ComplainDatabase"
            m_strPrimaryFieldName = "ComplainDatabaseID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lComplainDatabaseID As Long
        Private m_strClaimNo As String
        Private m_lReclamationTypeID As Long
        Private m_strANZNo As String
        Private m_strInspectorName As String
        Private m_lCustomerID As Long
        Private m_strDept As String
        Private m_lSupplierID As Long
        Private m_strSeason As String
        Private m_lPOID As Long
        Private m_strArticleNo As String
        Private m_lDefectID As Long
        Private m_strDefect As String
        Private m_lCurrentStatusID As Long
        Private m_strNotes As String

        Public Property ComplainDatabaseID() As Long
            Get
                ComplainDatabaseID = m_lComplainDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lComplainDatabaseID = Value
            End Set
        End Property
        Public Property ClaimNo() As String
            Get
                ClaimNo = m_strClaimNo
            End Get
            Set(ByVal value As String)
                m_strClaimNo = value
            End Set
        End Property
        Public Property ReclamationTypeID() As Long
            Get
                ReclamationTypeID = m_lReclamationTypeID
            End Get
            Set(ByVal Value As Long)
                m_lReclamationTypeID = Value
            End Set
        End Property
        Public Property ANZNo() As String
            Get
                ANZNo = m_strANZNo
            End Get
            Set(ByVal value As String)
                m_strANZNo = value
            End Set
        End Property
        Public Property InspectorName() As String
            Get
                InspectorName = m_strInspectorName
            End Get
            Set(ByVal value As String)
                m_strInspectorName = value
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
        Public Property Dept() As String
            Get
                Dept = m_strDept
            End Get
            Set(ByVal value As String)
                m_strDept = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal Value As Long)
                m_lSupplierID = Value
            End Set
        End Property
        Public Property Season() As String
            Get
                Season = m_strSeason
            End Get
            Set(ByVal value As String)
                m_strSeason = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal Value As Long)
                m_lPOID = Value
            End Set
        End Property
        Public Property ArticleNo() As String
            Get
                ArticleNo = m_strArticleNo
            End Get
            Set(ByVal value As String)
                m_strArticleNo = value
            End Set
        End Property
        Public Property DefectID() As Long
            Get
                DefectID = m_lDefectID
            End Get
            Set(ByVal Value As Long)
                m_lDefectID = Value
            End Set
        End Property
        Public Property Defect() As String
            Get
                Defect = m_strDefect
            End Get
            Set(ByVal value As String)
                m_strDefect = value
            End Set
        End Property
        Public Property CurrentStatusID() As Long
            Get
                CurrentStatusID = m_lCurrentStatusID
            End Get
            Set(ByVal Value As Long)
                m_lCurrentStatusID = Value
            End Set
        End Property
        Public Property Notes() As String
            Get
                Notes = m_strNotes
            End Get
            Set(ByVal value As String)
                m_strNotes = value
            End Set
        End Property
        Public Function SaveComplainDatabase()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Function GetComplainDatabase()
            Dim Str As String
            Str = "  select * from ComplainDatabase CD "
            Str &= " join Purchaseorder Po on Po.POID=CD.POID"
            Str &= " join Customer c on c.customerid=Cd.customerid"
            Str &= " join vender v on v. venderlibraryid=cd.Supplierid"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetBindCommodity()
            Dim Str As String
            Str = "  select * from Commodity CD "
          
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetBindPackingListView()
            Dim Str As String

            Str = "   select * "
            Str &= " ,isnull((select SUM(Dtl.Qty) from PackingDtl Dtl where Dtl.PackingMstID =mst.PackingMstID),0) as Qtyy"
            Str &= "  ,isnull((select SUM(Dtl.Weight) from PackingDtl Dtl where Dtl.PackingMstID =mst.PackingMstID),0) as Weightt"
            Str &= "  ,isnull((select count(Dtl.PackingDtlid) from PackingDtl Dtl where Dtl.PackingMstID =mst.PackingMstID),0) as NoOfCartonn"
            Str &= " from PackingMst Mst"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetBindDataForPanal()
            Dim Str As String
            Str = "  select *,CONVERT(varchar,Mst.CreationDate,103) as CreationDatee from PanalMst Mst"
            Str &= "  join SeasonDatabase SD on SD.SeasonDatabaseID =Mst.SeasonDatabaseID "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetBindShipmentView()
            Dim Str As String
            Str = "   Select *,CONVERT(varchar,S.ExFactoryDate,103) ExFactoryDatee "
            Str &= " ,CONVERT(varchar,S.ExpectedPayRcvDate,103) ExpectedPayRcvDatee "
            Str &= "  from Shipment S"
            Str &= " join Cargo C on C.CargoID =S.CargoID "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function Edit(ByVal ComplainDatabaseID As Long)
            Dim Str As String
            Str = "  select  * ,(Select isnull(Sum(Quantity),0) from CargoDetail Cd where Cd.POID=POD.PodetailID)as ShipQty,"
            Str &= " isnull((Select top 1 InspectionStatus  from QDInspection Q where Q.PodetailID =POD.PodetailID and InspectionStatus='1st Inline' and InspStatus='Pass' "
            Str &= " order by QDInspectionID DESC ),'Missed') as Inline,"
            Str &= " isnull((Select top 1 InspectionStatus  from QDInspection Q where Q.PodetailID =POD.PodetailID and InspectionStatus='Final' and InspStatus='Pass' "
            Str &= " order by QDInspectionID DESC ),'Missed') as FRI,"
            Str &= " isnull((Select top 1 U.Username  from QDInspection Q join Umuser u on u.Userid=Q.QDUserid where Q.PodetailID =POD.PodetailID"
            Str &= "  and InspectionStatus='Final' and InspStatus='Pass'  order by QDInspectionID DESC ),'--') as FRIQDName"
            Str &= "  from ComplainDatabase CD "
            Str &= " join Purchaseorder Po on Po.POID=CD.POID"
            Str &= " join Customer c on c.customerid=Cd.customerid"
            Str &= " join vender v on v. venderlibraryid=cd.Supplierid"
            Str &= " join ComplainDatabaseDetail CDD on CDD.ComplainDatabaseID=CD.ComplainDatabaseID"
            Str &= " join Purchaseorderdetail Pod on POD.PODetailID=CDD.PODetailID"
            Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= "  where CD.ComplainDatabaseID=" & ComplainDatabaseID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function


    End Class
End Namespace