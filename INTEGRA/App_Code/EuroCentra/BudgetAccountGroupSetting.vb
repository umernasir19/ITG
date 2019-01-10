Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class BudgetAccountGroupSetting

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BudgetAccountGroupSetting"
            m_strPrimaryFieldName = "BudgetAccountGroupSettingID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBudgetAccountGroupSettingID As Long
        Private m_lAccountGroupID As Long
        Private m_dPercentageAllocationAccountGroup As Decimal
        Public Property BudgetAccountGroupSettingID() As Long
            Get
                BudgetAccountGroupSettingID = m_lBudgetAccountGroupSettingID
            End Get
            Set(ByVal value As Long)
                m_lBudgetAccountGroupSettingID = value
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
        Public Property PercentageAllocationAccountGroup() As Decimal
            Get
                PercentageAllocationAccountGroup = m_dPercentageAllocationAccountGroup
            End Get
            Set(ByVal value As Decimal)
                m_dPercentageAllocationAccountGroup = value
            End Set
        End Property
        Public Function SaveBudgetAccountGroupSetting()
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
        Public Function GetdataForBudgetAccountGroupSetting()
            Dim str As String
            Try
                str = " select * from BudgetAccountGroupSetting BAGS "
                str &= " join AccountGroup AG on AG.AccountGroupID =BAGS.AccountGroupID "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

