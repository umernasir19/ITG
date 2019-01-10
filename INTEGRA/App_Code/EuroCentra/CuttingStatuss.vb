Imports System.Data
Namespace EuroCentra
    Public Class CuttingStatuss
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CuttingStatuss"
            m_strPrimaryFieldName = "CuttingStatusID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lCuttingStatusID As Long
        Private m_lPOID As Long
        Private m_dtCreationDate As Date

        Public Property CuttingStatusID() As Long
            Get
                CuttingStatusID = m_lCuttingStatusID
            End Get
            Set(ByVal value As Long)
                m_lCuttingStatusID = value
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
        Public Function SaveCuttingStatus()
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

        Public Function GetData(ByVal POID As Long)
            Dim Str As String
            Str = "  select *, DATEPART(WEEK, CSD.InputDate) week, CONVERT(VARCHAR(11), CSD.InputDate, 103) as InputDates,CONVERT(VARCHAR(11), CSD.OutputDate, 103) as OutputDates  from CuttingStatuss  CS"
            Str &= " join CuttingStatussDetail CSD on CSD.CuttingStatusID = CS.CuttingStatusID  "
            Str &= "  where CS.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function SetEditMode(ByVal CuttingStatusID As Long)
            Dim Str As String
            Str = "  select *  from CuttingStatuss CS"
            Str &= "  join CuttingStatussDetail CSD on CSD.CuttingStatusID=CS.CuttingStatusID"
            Str &= "  join  PurchaseOrder Po on PO.POID=CS.POID"
            Str &= " join Customer c on c.CustomerID =PO.CustomerID "
            Str &= " join Vender v on v.VenderLibraryID =po.SupplierID"
            Str &= " where CS.CuttingStatusID=" & CuttingStatusID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal POID As Long)
            Dim Str As String
            Str = "  select * from CuttingStatuss  CS"
            Str &= "  where CS.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace