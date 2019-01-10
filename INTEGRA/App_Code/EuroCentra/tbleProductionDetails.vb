Imports Microsoft.VisualBasic
Imports System.Data

Public Class tbleProductionDetails
    Inherits SQLManager

    Public Sub New()
        m_strTableName = "ProductionDetails"
        m_strPrimaryFieldName = "ProductionDetailID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lProductionDetailID As Long
    Private m_lProductionTypeID As Long
    Private m_lProductionMasterID As Long
    Private m_lJobOrderDetailID As Long
    Private str_ProductedToday As Decimal
    Private str_PreviousProduced As Decimal
    Private str_TotalProduced As Decimal
    Private str_Remarks As String
    Private m_bSelected As Boolean
    Private m_lStyle_SubStyleID As Long
    Private m_dMinimizeQty As Decimal


    Public Property ProductionDetailID() As Long
        Get
            ProductionDetailID = m_lProductionDetailID
        End Get
        Set(ByVal value As Long)
            m_lProductionDetailID = value
        End Set
    End Property
    Public Property ProductionMasterID() As Long
        Get
            ProductionMasterID = m_lProductionMasterID
        End Get
        Set(ByVal value As Long)
            m_lProductionMasterID = value
        End Set
    End Property
    Public Property ProductionTypeID() As Long
        Get
            ProductionTypeID = m_lProductionTypeID
        End Get
        Set(ByVal value As Long)
            m_lProductionTypeID = value
        End Set
    End Property

    Public Property JobOrderDetailID() As String
        Get
            JobOrderDetailID = m_lJobOrderDetailID
        End Get
        Set(ByVal value As String)
            m_lJobOrderDetailID = value
        End Set
    End Property
    Public Property ProductedToday() As Decimal
        Get
            ProductedToday = str_ProductedToday
        End Get
        Set(ByVal value As Decimal)
            str_ProductedToday = value
        End Set
    End Property
    Public Property PreviousProduced() As Decimal
        Get
            PreviousProduced = str_PreviousProduced
        End Get
        Set(ByVal value As Decimal)
            str_PreviousProduced = value
        End Set
    End Property
    Public Property TotalProduced() As Decimal
        Get
            TotalProduced = str_TotalProduced
        End Get
        Set(ByVal value As Decimal)
            str_TotalProduced = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Remarks = str_Remarks
        End Get
        Set(ByVal value As String)
            str_Remarks = value
        End Set
    End Property
    Public Property Selected() As Boolean
        Get
            Selected = m_bSelected
        End Get
        Set(ByVal value As Boolean)
            m_bSelected = value
        End Set
    End Property
    Public Property Style_SubStyleID() As Long
        Get
            Style_SubStyleID = m_lStyle_SubStyleID
        End Get
        Set(ByVal value As Long)
            m_lStyle_SubStyleID = value
        End Set
    End Property
    Public Property MinimizeQty() As Decimal
        Get
            MinimizeQty = m_dMinimizeQty
        End Get
        Set(ByVal value As Decimal)
            m_dMinimizeQty = value
        End Set
    End Property

    Public Function Saveproduction()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function

    Public Function getdataforMinimize(ByVal JobOrderDetailId As Long, ByVal ProductionTypeid As Long) As DataTable
        Dim Str As String
        Str = " select * from ProductionDetails where JobOrderDetailID='" & JobOrderDetailId & "' and ProductionTypeId='" & ProductionTypeid & "'"

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function UpdateMinimizeQty(ByVal ProductionDetailId As Long, ByVal totalMinimizeQty As Decimal)
        Dim Str As String
        Str = " update ProductionDetails set MinimizeQty='" & totalMinimizeQty & "' where ProductionDetailId='" & ProductionDetailId & "'"

        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
End Class
