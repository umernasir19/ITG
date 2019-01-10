
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class DPFabricDbDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPFabricDbDtl"
            m_strPrimaryFieldName = "FabricDbDtlId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricDbDtlId As Long
        Private m_lFabricDBMstId As Long
        Private m_dcPrice As Decimal
        Private m_dtPricingDate As Date
        Private m_strPricingRemarks As String
        Private m_bConfirmPrice As Boolean
        Public Property ConfirmPrice() As Boolean
            Get
                ConfirmPrice = m_bConfirmPrice
            End Get
            Set(ByVal value As Boolean)
                m_bConfirmPrice = value
            End Set
        End Property
        Public Property FabricDbDtlId() As Long
            Get
                FabricDbDtlId = m_lFabricDbDtlId
            End Get
            Set(ByVal value As Long)
                m_lFabricDbDtlId = value
            End Set
        End Property
        Public Property FabricDBMstId() As Long
            Get
                FabricDBMstId = m_lFabricDBMstId
            End Get
            Set(ByVal value As Long)
                m_lFabricDBMstId = value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_dcPrice
            End Get
            Set(ByVal value As Decimal)
                m_dcPrice = value
            End Set
        End Property
        Public Property PricingDate() As Date
            Get
                PricingDate = m_dtPricingDate
            End Get
            Set(ByVal value As Date)
                m_dtPricingDate = value
            End Set
        End Property
        Public Property PricingRemarks() As String
            Get
                PricingRemarks = m_strPricingRemarks
            End Get
            Set(ByVal value As String)
                m_strPricingRemarks = value
            End Set

        End Property
        Public Function SaveFBdt()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function Deletedetail(ByVal FabricDbDtlId As Long)
            Dim str As String
            str = " Delete  from DPFabricDbDtl where FabricDbDtlId ='" & FabricDbDtlId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
