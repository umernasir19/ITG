Imports System.Data
Namespace EuroCentra
    Public Class FinishingLine
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FinishingLine"
            m_strPrimaryFieldName = "FinishingLineID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lFinishingLineID As Long
        Private m_lPOID As Long
        Private m_dtCreationDate As Date
        Private m_dtLineInitiateDate As Date
        Private m_dtLineExitDate As Date
        Public Property FinishingLineID() As Long
            Get
                FinishingLineID = m_lFinishingLineID
            End Get
            Set(ByVal value As Long)
                m_lFinishingLineID = value
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
        Public Function SaveFinishingLine()
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
        Public Function SetEditMode(ByVal FinishingLineID As Long)
            Dim Str As String
            Str = "   select *,  FLD.ProductionDate as Dates , convert(varchar,PO.ShipmentDate,103)as ShipmentDatee  from FinishingLine FL"
            Str &= "   join FinishingLineDetail FLD on FLD.FinishingLineID=FL.FinishingLineID"
            Str &= "    join  PurchaseOrder Po on PO.POID=FL.POID"
            Str &= "   join Customer c on c.CustomerID =PO.CustomerID "
            Str &= "   join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= "     where FL.FinishingLineID = " & FinishingLineID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetData(ByVal POID As Long) As DataTable
            Dim Str As String
            Str = "  select *, DATEPART(WEEK, FLD.ProductionDate) week, CONVERT(VARCHAR(11), FLD.ProductionDate, 103) as ProductionDates from FinishingLine  FL"
            Str &= "  Join FinishingLineDetail FLD on FLD.FinishingLineID = FL.FinishingLineID"
            Str &= "  where FL.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal POID As Long)
            Dim Str As String
            Str = "  select * from FinishingLine "
            Str &= "  where POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace