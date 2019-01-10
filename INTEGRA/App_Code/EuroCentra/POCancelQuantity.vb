Imports System.Data
Namespace EuroCentra
    Public Class POCancelQuantity
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "POCancelQuantity"
            m_strPrimaryFieldName = "CancelID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCancelID As Long
        Private m_lPOID As Long
        Private m_dQuantity As Decimal
        Private m_dtCreationDate As Date
        Private m_bIsActive As Boolean
        Private m_lMarchandID As Long
        Private m_lPODetailID As Long
        ''----------Properties

        Public Property CancelID() As Long
            Get
                CancelID = m_lCancelID
            End Get
            Set(ByVal Value As Long)
                m_lCancelID = Value
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
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dQuantity = value
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
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property
        Public Property MarchandID() As Long
            Get
                MarchandID = m_lMarchandID
            End Get
            Set(ByVal value As Long)
                m_lMarchandID = value
            End Set
        End Property
        Public Function SavePOCancelQuantity()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCancelID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCancelIDById(ByVal lCancelID As Long)
            Try
                Return MyBase.GetById(lCancelID)
            Catch ex As Exception

            End Try
        End Function
        Function GetQTYFirstTimePress()
            Dim Str As String
            Str = " Select PO.POID,PO.PONO,Po.status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate"
            Str &= " ,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate ,cast ((Select SUM(Isnull((POD.Quantity),0)) from"
            Str &= " Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))as QTY "
            Str &= " ,cast ((Select SUM(Isnull((POD.Quantity)* (POD.Rate),0)) from  Purchaseorderdetail POD"
            Str &= " where POD.POID = PO.POID)as decimal (10,2))as Amount"
            Str &= " ,cast ((Select Isnull(SUM(Isnull((POC.Quantity),0)),0)from  POCancelQuantity POC"
            Str &= " where POC.POID = PO.POID)as decimal (10,0))as CancelQTY ,"
            Str &= " cast ((Select Isnull(SUM(Isnull((CD.Quantity),0)),0)from   CargoDetail CD where "
            Str &= " CD.POPOID = PO.POID)as decimal (10,0))as ShippedQTY  , (Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from  Purchaseorderdetail POD where POD.POID = PO.POID) - "
            Str &= " (Select Isnull(SUM(Isnull((CD.Quantity),0)),0)from   CargoDetail CD where"
            Str &= " CD.POPOID = PO.POID) as Differenc"
            Str &= " from Purchaseorder PO  "
            Str &= " where year(PO.Placementdate)between 2010 and 2011"
            Str &= " order by year(PO.ShipmentDate) ASC "

            ' Str &= " where Year(Po.ShipmentDate) = 2011 "
            '  Str &= " and PO.POID  in (select Distinct POPOID from Cargodetail)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteCancelQTY(ByVal IPOID As String)
            Dim Str As String
            Str = " Delete from POCancelQuantity where POID= " & IPOID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace