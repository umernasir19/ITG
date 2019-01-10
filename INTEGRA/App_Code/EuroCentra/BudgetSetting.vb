Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class BudgetSetting
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BudgetSetting"
            m_strPrimaryFieldName = "BudgetSettingId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBudgetSettingId As Long
        Private m_lChartofAccountID As Long
        Private m_lAccountSubGroupID As Long
        Private m_lAccountGroupID As Long
        Private m_dPercentageAllocationChartOfAccount As Decimal
        Public Property BudgetSettingId() As Long
            Get
                BudgetSettingId = m_lBudgetSettingId
            End Get
            Set(ByVal value As Long)
                m_lBudgetSettingId = value
            End Set
        End Property
        Public Property ChartofAccountID() As Long
            Get
                ChartofAccountID = m_lChartofAccountID
            End Get
            Set(ByVal value As Long)
                m_lChartofAccountID = value
            End Set
        End Property
        Public Property AccountSubGroupID() As Long
            Get
                AccountSubGroupID = m_lAccountSubGroupID
            End Get
            Set(ByVal value As Long)
                m_lAccountSubGroupID = value
            End Set
        End Property
        Public Property AccountGroupID() As Long
            Get
                AccountGroupID = m_lAccountGroupID
            End Get
            Set(ByVal value As Long)
                m_lAccountGroupID = value
            End Set
        End Property
        Public Property PercentageAllocationChartOfAccount() As Decimal
            Get
                PercentageAllocationChartOfAccount = m_dPercentageAllocationChartOfAccount
            End Get
            Set(ByVal value As Decimal)
                m_dPercentageAllocationChartOfAccount = value
            End Set
        End Property

        Public Function SaveBudgetSetting()
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

