Imports Microsoft.VisualBasic
Imports System.Data

Public Class tbleProductionMaster
    Inherits SQLManager

    Public Sub New()
        m_strTableName = "ProductionMaster"
        m_strPrimaryFieldName = "ProductionMasterID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lProductionMasterID As Long
    Private m_lJobOrderID As Long
    Private m_dtProductionDate As Date
    Private m_lProductionTypeID As Long

    Public Property ProductionMasterID() As Long
        Get
            ProductionMasterID = m_lProductionMasterID
        End Get
        Set(ByVal value As Long)
            m_lProductionMasterID = value
        End Set
    End Property

    Public Property JobOrderID() As Long
        Get
            JobOrderID = m_lJobOrderID
        End Get
        Set(ByVal value As Long)
            m_lJobOrderID = value
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

    Public Property ProductionTypeID() As Long
        Get
            ProductionTypeID = m_lProductionTypeID
        End Get
        Set(ByVal value As Long)
            m_lProductionTypeID = value
        End Set
    End Property
    Public Function BindProduction() As DataTable
        Dim Str As String
        Str = " select * from ProductionType"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindProductionSTBR() As DataTable
        Dim Str As String
        Str = "  select * from ProductionType where ProductionTypeID= 2 or ProductionTypeID= 3 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindProductionCutting() As DataTable
        Dim Str As String
        Str = "  select * from ProductionType where ProductionTypeID= 1 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindProductionWashing() As DataTable
        Dim Str As String
        Str = "  select * from ProductionType where ProductionTypeID= 4 "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindProduction1() As DataTable
        Dim Str As String
        Str = "  select * from ProductionType where ProductionTypeID= 5 or ProductionTypeID= 6"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindJobprder() As DataTable
        Dim Str As String
        Str = " select * from JobOrderdatabase "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindJoborder() As DataTable
        Dim Str As String
        Str = " select * from JobOrder "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function

    Public Function BindForFabricationJobprder() As DataTable
        Dim Str As String
        Str = "select * from JobOrder JO join fplanmst FMST on FMST.JobOrderId =JO.JobOrderID "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindForAccessoriesPlanJobprder() As DataTable
        Dim Str As String
        Str = "select * from joborder JO join AccessoriesePlanMst APM on APM.JobOrderId=JO.JobOrderId "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function Saveproduction()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDatebyJO(ByVal JOID As Long)
        Dim str As String
        str = " select ReceivedDAte,ShipDate from JobOrder where JobOrderid='" & JOID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
