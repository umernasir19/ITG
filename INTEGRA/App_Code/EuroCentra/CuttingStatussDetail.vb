Imports System.Data
Namespace EuroCentra
    Public Class CuttingStatussDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CuttingStatussDetail"
            m_strPrimaryFieldName = "CuttingStatusDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lCuttingStatusDetailID As Long
        Private m_lCuttingStatusID As Long
        Private m_strStyleNo As String
        Private m_dtInputDate As Date
        Private m_strLotNo As String
        Private m_dcInputQty As Decimal
        Private m_strOutputDate As Date
        Private m_dcConsumption As Decimal
        Private m_dcOutputQty As Decimal
        Private m_strRemarks As String

        Public Property CuttingStatusDetailID() As Long
            Get
                CuttingStatusDetailID = m_lCuttingStatusDetailID
            End Get
            Set(ByVal value As Long)
                m_lCuttingStatusDetailID = value
            End Set
        End Property
        Public Property CuttingStatusID() As Long
            Get
                CuttingStatusID = m_lCuttingStatusID
            End Get
            Set(ByVal value As Long)
                m_lCuttingStatusID = value
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
        Public Property InputDate() As Date
            Get
                InputDate = m_dtInputDate
            End Get
            Set(ByVal value As Date)
                m_dtInputDate = value
            End Set
        End Property
        Public Property LotNo() As String
            Get
                LotNo = m_strLotNo
            End Get
            Set(ByVal value As String)
                m_strLotNo = value
            End Set
        End Property
        Public Property InputQty() As Decimal
            Get
                InputQty = m_dcInputQty
            End Get
            Set(ByVal value As Decimal)
                m_dcInputQty = value
            End Set
        End Property
        Public Property OutputDate() As Date
            Get
                OutputDate = m_strOutputDate
            End Get
            Set(ByVal value As Date)
                m_strOutputDate = value
            End Set
        End Property
        Public Property Consumption() As Decimal
            Get
                Consumption = m_dcConsumption
            End Get
            Set(ByVal value As Decimal)
                m_dcConsumption = value
            End Set
        End Property
        Public Property OutputQty() As Decimal
            Get
                OutputQty = m_dcOutputQty
            End Get
            Set(ByVal value As Decimal)
                m_dcOutputQty = value
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
        Public Function SaveCuttingStatusDetail()
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
        Public Function GetCuttingQty(ByVal POID As Long, ByVal StyleNo As String)
            Dim Str As String
            Str = "  select isnull(Sum(CSD.OutputQty),0) as CuttingQty  from CuttingStatuss CS"
            Str &= "  join CuttingStatussDetail CSD on CSD.CuttingStatusID=CS.CuttingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=CS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where CS.POID=" & POID
            Str &= " AND CSD.StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace