Imports System.Data
Namespace EuroCentra
    Public Class StitchingStatusDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StitchingStatusDetail"
            m_strPrimaryFieldName = "StitchingStatusDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub


        Private m_lStitchingStatusDetailID As Long
        Private m_lStitchingStatusID As Long
        Private m_strStyleNo As String
        Private m_dtProductionDate As Date
        Private m_strDayStatus As String
        Private m_strL1Plan As String
        Private m_strL1Actual As String
        Private m_strL2Plan As String
        Private m_strL2Actual As String

        Public Property StitchingStatusDetailID() As Long
            Get
                StitchingStatusDetailID = m_lStitchingStatusDetailID
            End Get
            Set(ByVal value As Long)
                m_lStitchingStatusDetailID = value
            End Set
        End Property
        Public Property StitchingStatusID() As Long
            Get
                StitchingStatusID = m_lStitchingStatusID
            End Get
            Set(ByVal value As Long)
                m_lStitchingStatusID = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Property ProductionDate() As Date
            Get
                ProductionDate = m_dtProductionDate
            End Get
            Set(ByVal value As Date)
                m_dtProductionDate = value
            End Set
        End Property
        Public Property DayStatus() As String
            Get
                DayStatus = m_strDayStatus
            End Get
            Set(ByVal value As String)
                m_strDayStatus = value
            End Set
        End Property
        Public Property L1Plan() As String
            Get
                L1Plan = m_strL1Plan
            End Get
            Set(ByVal value As String)
                m_strL1Plan = value
            End Set
        End Property
        Public Property L1Actual() As String
            Get
                L1Actual = m_strL1Actual
            End Get
            Set(ByVal value As String)
                m_strL1Actual = value
            End Set
        End Property
        Public Property L2Plan() As String
            Get
                L2Plan = m_strL2Plan
            End Get
            Set(ByVal value As String)
                m_strL2Plan = value
            End Set
        End Property
        Public Property L2Actual() As String
            Get
                L2Actual = m_strL2Actual
            End Get
            Set(ByVal value As String)
                m_strL2Actual = value
            End Set
        End Property
        Public Function SaveStitchingStatusDetail()
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
        Public Function GetStitchingQtyL1(ByVal POID As Long, ByVal StyleNo As String)
            Dim Str As String
            Str = "  select   Isnull(Sum(cast(SSD.L1Actual as decimal(10,0))),0) as L1Qty    from StitchingStatus SS"
            Str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where IsNumeric(SSD.L1Actual) = 1 and SS.POID=" & POID
            Str &= " AND SSD.StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStitchingQtyL2(ByVal POID As Long, ByVal StyleNo As String)
            Dim Str As String
            Str = "  select   Isnull(Sum(cast(SSD.L2Actual as decimal(10,0))),0) as L2Qty    from StitchingStatus SS"
            Str &= " join StitchingStatusDetail SSD on SSD.StitchingStatusID=SS.StitchingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=SS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "  join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where IsNumeric(SSD.L2Actual) = 1 and SS.POID=" & POID
            Str &= " AND SSD.StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class

End Namespace