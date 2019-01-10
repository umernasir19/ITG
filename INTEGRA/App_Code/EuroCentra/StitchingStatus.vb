Imports System.Data
Namespace EuroCentra
    Public Class StitchingStatus
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StitchingStatus"
            m_strPrimaryFieldName = "StitchingStatusID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lStitchingStatusID As Long
        Private m_lPOID As Long
        Private m_dtCreationDate As Date
        Private m_dtLineInitiateDate As Date
        Private m_dtLineExitDate As Date
        Public Property StitchingStatusID() As Long
            Get
                StitchingStatusID = m_lStitchingStatusID
            End Get
            Set(ByVal value As Long)
                m_lStitchingStatusID = value
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
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property LineInitiateDate() As Date
            Get
                LineInitiateDate = m_dtLineInitiateDate
            End Get
            Set(ByVal value As Date)
                m_dtLineInitiateDate = value
            End Set
        End Property
        Public Property LineExitDate() As Date
            Get
                LineExitDate = m_dtLineExitDate
            End Get
            Set(ByVal value As Date)
                m_dtLineExitDate = value
            End Set
        End Property
        Public Function SaveStitchingStatus()
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
        Public Function SetEditMode(ByVal StitchingStatusID As Long)
            Dim Str As String
            Str = "   select *,  SSD.ProductionDate as Dates , convert(varchar,PO.ShipmentDate,103)as ShipmentDatee  from StitchingStatus SS"
            Str &= "   join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "    join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= "   join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "   join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "     where SS.StitchingStatusID = " & StitchingStatusID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetData(ByVal POID As Long) As DataTable
            Dim str As String
            str = " select * from StitchingStatus SS "
            str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID = SS.StitchingStatusID "
            str &= "  where SS.POID=" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CapacityPlanL1(ByVal StitchingStatusDetailID As Long)
            Dim Str As String
            Str = "  select   Isnull(Sum(cast(SSD.L1Plan as decimal(10,0))),0) as L1Qty    from StitchingStatus SS"
            Str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where IsNumeric(SSD.L1Actual) = 1 and SSD.StitchingStatusDetailID=" & StitchingStatusDetailID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CapacityPlanL2(ByVal StitchingStatusDetailID As Long)
            Dim Str As String
            Str = "  select   Isnull(Sum(cast(SSD.L2Plan as decimal(10,0))),0) as L1Qty    from StitchingStatus SS"
            Str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where IsNumeric(SSD.L1Actual) = 1 and SSD.StitchingStatusDetailID=" & StitchingStatusDetailID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CapacityActualL1(ByVal StitchingStatusDetailID As Long)
            Dim Str As String
            Str = "  select   Isnull(Sum(cast(SSD.L1Actual as decimal(10,0))),0) as L1Qty    from StitchingStatus SS"
            Str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where IsNumeric(SSD.L1Actual) = 1 and SSD.StitchingStatusDetailID=" & StitchingStatusDetailID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CapacityActualL2(ByVal StitchingStatusDetailID As Long)
            Dim Str As String
            Str = "  select   Isnull(Sum(cast(SSD.L2Actual as decimal(10,0))),0) as L2Qty    from StitchingStatus SS"
            Str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where IsNumeric(SSD.L2Actual) = 1 and SSD.StitchingStatusDetailID=" & StitchingStatusDetailID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal POID As Long)
            Dim Str As String
            Str = "  select * from StitchingStatus "
            Str &= "  where POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace