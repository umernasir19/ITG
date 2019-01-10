Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class BudgetAccountSubGroupSetting
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BudgetAccountSubGroupSetting"
            m_strPrimaryFieldName = "BudgetAccountSubGroupSettingID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBudgetAccountSubGroupSettingID As Long
        Private m_lAccountSubGroupID As Long
        Private m_lAccountGroupID As Long
        Private m_dPercentageAllocationAccountSubGroup As Decimal
        Public Property BudgetAccountSubGroupSettingID() As Long
            Get
                BudgetAccountSubGroupSettingID = m_lBudgetAccountSubGroupSettingID
            End Get
            Set(ByVal value As Long)
                m_lBudgetAccountSubGroupSettingID = value
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
        Public Property PercentageAllocationAccountSubGroup() As Decimal
            Get
                PercentageAllocationAccountSubGroup = m_dPercentageAllocationAccountSubGroup
            End Get
            Set(ByVal value As Decimal)
                m_dPercentageAllocationAccountSubGroup = value
            End Set
        End Property

        Public Function SaveBudgetAccountSubGroupSetting()
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
        Public Function GetSumAllocation(ByVal AccountGroupId As Long)
            Dim str As String
            Try
                str = " Select sum(PercentageAllocationAccountGroup) from BudgetAccountGroupSetting where AccountGroupID=" & AccountGroupId
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSumAllocationForSubgroup(ByVal AccountSubGroupId As Long)
            Dim str As String
            Try
                str = " Select sum(PercentageAllocationAccountSubGroup) from BudgetAccountSubGroupSetting where AccountSubGroupID=" & AccountSubGroupId
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace


