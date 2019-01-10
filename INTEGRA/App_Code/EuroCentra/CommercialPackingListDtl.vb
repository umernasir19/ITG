Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class CommercialPackingListDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "CommercialPackingListDtl"
        m_strPrimaryFieldName = "CommercialPackingListDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lCommercialPackingListDtlID As Long
    Private m_lCommercialPackingListMstid As Long
    Private m_dcCartonFrom As Decimal

    Private m_dcCartonTo As Decimal
    Private m_dcCTNS As Decimal
    Private m_lJobOrderDetailID As Long
    Private m_strBuyerColor As String
    Private m_strStyle As String
    Private m_lStyleAssortmentDetailID As Long
    Private m_strSize As String
    Private m_dcQuantity As Decimal
    Private m_dcPCSCTN As Decimal

    Public Property JobOrderDetailID() As Long
        Get
            JobOrderDetailID = m_lJobOrderDetailID
        End Get
        Set(ByVal value As Long)
            m_lJobOrderDetailID = value
        End Set
    End Property
    Public Property CommercialPackingListDtlID() As Long
        Get
            CommercialPackingListDtlID = m_lCommercialPackingListDtlID
        End Get
        Set(ByVal value As Long)
            m_lCommercialPackingListDtlID = value
        End Set
    End Property
    Public Property CommercialPackingListMstid() As Long
        Get
            CommercialPackingListMstid = m_lCommercialPackingListMstid
        End Get
        Set(ByVal value As Long)
            m_lCommercialPackingListMstid = value
        End Set
    End Property
    Public Property CartonFrom() As Decimal
        Get
            CartonFrom = m_dcCartonFrom
        End Get
        Set(ByVal value As Decimal)
            m_dcCartonFrom = value
        End Set
    End Property
  
    Public Property CartonTo() As Decimal
        Get
            CartonTo = m_dcCartonTo
        End Get
        Set(ByVal value As Decimal)
            m_dcCartonTo = value
        End Set
    End Property
    Public Property CTNS() As Decimal
        Get
            CTNS = m_dcCTNS
        End Get
        Set(ByVal value As Decimal)
            m_dcCTNS = value
        End Set
    End Property
    Public Property BuyerColor() As String
        Get
            BuyerColor = m_strBuyerColor
        End Get
        Set(ByVal value As String)
            m_strBuyerColor = value
        End Set
    End Property
    Public Property Style() As String
        Get
            Style = m_strStyle
        End Get
        Set(ByVal value As String)
            m_strStyle = value
        End Set
    End Property
    Public Property Size() As String
        Get
            Size = m_strSize
        End Get
        Set(ByVal value As String)
            m_strSize = value
        End Set
    End Property
    Public Property Quantity() As Decimal
        Get
            Quantity = m_dcQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dcQuantity = value
        End Set
    End Property
    Public Property PCSCTN() As Decimal
        Get
            PCSCTN = m_dcPCSCTN
        End Get
        Set(ByVal value As Decimal)
            m_dcPCSCTN = value
        End Set
    End Property
    Public Property StyleAssortmentDetailID() As Long
        Get
            StyleAssortmentDetailID = m_lStyleAssortmentDetailID
        End Get
        Set(ByVal value As Long)
            m_lStyleAssortmentDetailID = value
        End Set
    End Property
    Public Function Save()
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
    Public Function GetSeasonsFromJobOrderDatabase() As DataTable
        Dim str As String
        str = " Select distinct SD.seasondatabaseID,SD.SeasonName from SeasonDatabase SD join JobOrderDatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetforEdit(ByVal CommercialPackingListMstID As Long) As DataTable
        Dim str As String

        str = " SELECT * FROM CommercialPackingListMst Mst"
        str &= " join CommercialPackingListdTL Dtl ON dTL.CommercialPackingListMstID=Mst.CommercialPackingListMstID"
        str &= " where Mst.CommercialPackingListMstID = '" & CommercialPackingListMstID & "'  "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetforEditForCutting(ByVal TodayCuttingMstID As Long) As DataTable
        Dim str As String

        str = " SELECT *,convert(varchar,Dtl.CuttingDate,103) as CuttingDatee FROM TodayCuttingMst Mst join TodayCuttingDtl Dtl on Dtl.TodayCuttingMstID=Mst.TodayCuttingMstID"
        str &= "  join JobOrderdatabase JO on JO.Joborderid =Dtl.Joborderid"
        str &= " JOIN JobOrderdatabaseDetail JOD on JOD.JoborderDetailid =DTL.JobOrderDetailId "
        str &= " where Mst.TodayCuttingMstID = '" & TodayCuttingMstID & "'  "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetforEditForCuttingNew(ByVal TodayCuttingMstID As Long) As DataTable
        Dim str As String

        str = " SELECT *,convert(varchar,Dtl.CuttingDate,103) as CuttingDatee,Mst.UserId as UserIdd FROM TodayCuttingMst Mst join TodayCuttingDtl Dtl on Dtl.TodayCuttingMstID=Mst.TodayCuttingMstID"
        str &= "  join JobOrderdatabase JO on JO.Joborderid =Dtl.Joborderid"
        str &= " JOIN JobOrderdatabaseDetail JOD on JOD.JoborderDetailid =DTL.JobOrderDetailId "
        str &= " JOIN SeasonDatabase SD on SD.SeasonDatabaseid =JO.SeasonDatabaseid "
        str &= " where Mst.TodayCuttingMstID = '" & TodayCuttingMstID & "'  "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

End Class
