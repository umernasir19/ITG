Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_Capacities
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_Capacities"
            m_strPrimaryFieldName = "VAF_CapacitiesID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_CapacitiesID As Long
        Private m_lVAFID As Long
        Private m_dcFabricStock As Decimal
        Private m_strFabricStockUnit As String
        Private m_dcProdCapacitymonth As Decimal
        Private m_strProdCapacitymonthUnit As String
        Private m_dcCuttingCapacitymonth As Decimal
        Private m_dcwashingCapacity As Decimal
        Private m_dcNoOfLines As Decimal
        Private m_dcNoOfMachineline As Decimal
        Private m_dcSAMorSMV As Decimal
        Public Property VAF_CapacitiesID() As Long
            Get
                VAF_CapacitiesID = m_lVAF_CapacitiesID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_CapacitiesID = Value
            End Set
        End Property
        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property FabricStock() As Decimal
            Get
                FabricStock = m_dcFabricStock
            End Get
            Set(ByVal Value As Decimal)
                m_dcFabricStock = Value
            End Set
        End Property
        Public Property FabricStockUnit() As String
            Get
                FabricStockUnit = m_strFabricStockUnit
            End Get
            Set(ByVal value As String)
                m_strFabricStockUnit = value
            End Set
        End Property
        Public Property ProdCapacitymonth() As Decimal
            Get
                ProdCapacitymonth = m_dcProdCapacitymonth
            End Get
            Set(ByVal Value As Decimal)
                m_dcProdCapacitymonth = Value
            End Set
        End Property
        Public Property ProdCapacitymonthUnit() As String
            Get
                ProdCapacitymonthUnit = m_strProdCapacitymonthUnit
            End Get
            Set(ByVal value As String)
                m_strProdCapacitymonthUnit = value
            End Set
        End Property
        Public Property CuttingCapacitymonth() As Decimal
            Get
                CuttingCapacitymonth = m_dcCuttingCapacitymonth
            End Get
            Set(ByVal Value As Decimal)
                m_dcCuttingCapacitymonth = Value
            End Set
        End Property
        Public Property washingCapacity() As Decimal
            Get
                washingCapacity = m_dcwashingCapacity
            End Get
            Set(ByVal Value As Decimal)
                m_dcwashingCapacity = Value
            End Set
        End Property
        Public Property NoOfLines() As Decimal
            Get
                NoOfLines = m_dcNoOfLines
            End Get
            Set(ByVal Value As Decimal)
                m_dcNoOfLines = Value
            End Set
        End Property
        Public Property NoOfMachineline() As Decimal
            Get
                NoOfMachineline = m_dcNoOfMachineline
            End Get
            Set(ByVal Value As Decimal)
                m_dcNoOfMachineline = Value
            End Set
        End Property
        Public Property SAMorSMV() As Decimal
            Get
                SAMorSMV = m_dcSAMorSMV
            End Get
            Set(ByVal Value As Decimal)
                m_dcSAMorSMV = Value
            End Set
        End Property
        Public Function SaveVAF_Capacities()
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
        Public Function Delete(ByVal VAFID As Long)
            Dim Str As String
            Str = "Delete from VAF_Capacities  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace