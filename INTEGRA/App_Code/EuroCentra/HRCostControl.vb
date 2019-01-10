Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class HRCostControl
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRCostControl"
            m_strPrimaryFieldName = "HRCostControlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lHRCostControlID As Long
        Private m_lHRID As Long
        Private m_strFiscalYear As String
        Private m_dTotalBudgetGranted As Decimal
        Private m_dTravelBudget As Decimal
        Private m_dCommunicationBudget As Decimal
        Private m_dCourierBudget As Decimal
        Private m_dEntertainmentBudget As Decimal
        Private m_strCostCenterRule As String
        
        '----------------Properties
        Public Property HRCostControlID() As Long
            Get
                HRCostControlID = m_lHRCostControlID
            End Get
            Set(ByVal value As Long)
                m_lHRCostControlID = value
            End Set
        End Property
        Public Property HRID() As Long
            Get
                HRID = m_lHRID
            End Get
            Set(ByVal value As Long)
                m_lHRID = value
            End Set
        End Property
        Public Property FiscalYear() As String
            Get
                FiscalYear = m_strFiscalYear
            End Get
            Set(ByVal value As String)
                m_strFiscalYear = value
            End Set
        End Property
        Public Property TotalBudgetGranted() As Decimal
            Get
                TotalBudgetGranted = m_dTotalBudgetGranted
            End Get
            Set(ByVal value As Decimal)
                m_dTotalBudgetGranted = value
            End Set
        End Property
        Public Property TravelBudget() As Decimal
            Get
                TravelBudget = m_dTravelBudget
            End Get
            Set(ByVal value As Decimal)
                m_dTravelBudget = value
            End Set
        End Property
        Public Property CommunicationBudget() As Decimal
            Get
                CommunicationBudget = m_dCommunicationBudget
            End Get
            Set(ByVal value As Decimal)
                m_dCommunicationBudget = value
            End Set
        End Property
        Public Property CourierBudget() As Decimal
            Get
                CourierBudget = m_dCourierBudget
            End Get
            Set(ByVal value As Decimal)
                m_dCourierBudget = value
            End Set
        End Property
        Public Property EntertainmentBudget() As Decimal
            Get
                EntertainmentBudget = m_dEntertainmentBudget
            End Get
            Set(ByVal value As Decimal)
                m_dEntertainmentBudget = value
            End Set
        End Property

        Public Property CostCenterRule() As String
            Get
                CostCenterRule = m_strCostCenterRule
            End Get
            Set(ByVal value As String)
                m_strCostCenterRule = value
            End Set
        End Property
        Public Function SaveHRCostControl()
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

    End Class


End Namespace
