
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class DyeWashRecipeDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "DyeWashRecipeDtl"
        m_strPrimaryFieldName = "DyeWashRecipeDtlId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lDyeWashRecipeDtlId As Long
    Private m_lDyeWashRecipeMstId As Long
    Private m_lChemPrID As Long
    Private m_strChemPrLotNo As String
    Private m_strChemPrName As String
    Private m_dQty As Decimal
    Private m_lItemUnitID As Long
    Public Property ItemUnitID() As Long
        Get
            ItemUnitID = m_lItemUnitID
        End Get
        Set(ByVal value As Long)
            m_lItemUnitID = value
        End Set
    End Property
    Public Property DyeWashRecipeDtlId() As Long
        Get
            DyeWashRecipeDtlId = m_lDyeWashRecipeDtlId
        End Get
        Set(ByVal value As Long)
            m_lDyeWashRecipeDtlId = value
        End Set
    End Property
    Public Property DyeWashRecipeMstId() As Long
        Get
            DyeWashRecipeMstId = m_lDyeWashRecipeMstId
        End Get
        Set(ByVal value As Long)
            m_lDyeWashRecipeMstId = value
        End Set
    End Property
    Public Property ChemPrID() As Long
        Get
            ChemPrID = m_lChemPrID
        End Get
        Set(ByVal value As Long)
            m_lChemPrID = value
        End Set
    End Property
    Public Property ChemPrLotNo() As String
        Get
            ChemPrLotNo = m_strChemPrLotNo
        End Get
        Set(ByVal value As String)
            m_strChemPrLotNo = value
        End Set
    End Property
    Public Property ChemPrName() As String
        Get
            ChemPrName = m_strChemPrName
        End Get
        Set(ByVal value As String)
            m_strChemPrName = value
        End Set
    End Property
   
    Public Property Qty() As Decimal
        Get
            Qty = m_dQty
        End Get
        Set(ByVal value As Decimal)
            m_dQty = value
        End Set
    End Property
    Public Function Savedtl()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
End Class
