Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class BudgetCreateDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BudgetCreateDetail"
            m_strPrimaryFieldName = "BudgetCreateDetailId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBudgetCreateDetailId As Long
        Private m_lBudgetCreateMasterId As Long
        Private m_lBudgetSettingId As Long
        Private m_lChartofAccountID As Long
        Private m_lAccountSubGroupID As Long
        Private m_lAccountGroupID As Long
        Private m_strAccountGroup As String
        Private m_dPercentageAllocationAccountGroup As Decimal
        Private m_dAmountCCH As Decimal
        Private m_strAccountSubGroup As String
        Private m_dPercentageAllocationAccountSubGroup As Decimal
        Private m_dAmountSCH As Decimal
        Private m_strAccountType As String
        Private m_dPercentageAllocationChartOfAccount As Decimal
        Private m_dAmountCHB As Decimal
        Public Property BudgetCreateDetailId() As Long
            Get
                BudgetCreateDetailId = m_lBudgetCreateDetailId
            End Get
            Set(ByVal value As Long)
                m_lBudgetCreateDetailId = value
            End Set
        End Property
        Public Property BudgetCreateMasterId() As Long
            Get
                BudgetCreateMasterId = m_lBudgetCreateMasterId
            End Get
            Set(ByVal value As Long)
                m_lBudgetCreateMasterId = value
            End Set
        End Property
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
        Public Property AccountGroup() As String
            Get
                AccountGroup = m_strAccountGroup
            End Get
            Set(ByVal value As String)
                m_strAccountGroup = value
            End Set
        End Property
        Public Property PercentageAllocationAccountGroup() As Decimal
            Get
                PercentageAllocationAccountGroup = m_dPercentageAllocationAccountGroup
            End Get
            Set(ByVal value As Decimal)
                m_dPercentageAllocationAccountGroup = value
            End Set
        End Property
        Public Property AmountCCH() As Decimal
            Get
                AmountCCH = m_dAmountCCH
            End Get
            Set(ByVal value As Decimal)
                m_dAmountCCH = value
            End Set
        End Property
        Public Property AccountSubGroup() As String
            Get
                AccountSubGroup = m_strAccountSubGroup
            End Get
            Set(ByVal value As String)
                m_strAccountSubGroup = value
            End Set
        End Property
        Public Property PercentageAllocationAccountSubGroup() As Decimal
            Get
                PercentageAllocationAccountSubGroup = m_dPercentageAllocationAccountSubGroup
            End Get
            Set(ByVal value As Decimal)
                m_dPercentageAllocationAccountSubGroup = value
            End Set
        End Property
        Public Property AmountSCH() As Decimal
            Get
                AmountSCH = m_dAmountSCH
            End Get
            Set(ByVal value As Decimal)
                m_dAmountSCH = value
            End Set
        End Property
        Public Property AccountType() As String
            Get
                AccountType = m_strAccountType
            End Get
            Set(ByVal value As String)
                m_strAccountType = value
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
        Public Property AmountCHB() As Decimal
            Get
                AmountCHB = m_dAmountCHB
            End Get
            Set(ByVal value As Decimal)
                m_dAmountCHB = value
            End Set
        End Property

        Public Function SaveBudgetCreateDetail()
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

