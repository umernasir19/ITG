Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra

    Public Class AccountGroup
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "AccountGroup"
            m_strPrimaryFieldName = "AccountGroupID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lAccountGroupID As Long
        Private m_strAccountGroup As String
        Private m_strAccountGroupCode As String

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

        Public Property AccountGroupCode() As String
            Get
                AccountGroupCode = m_strAccountGroupCode
            End Get
            Set(ByVal value As String)
                m_strAccountGroupCode = value
            End Set
        End Property
       

        Public Function SaveAccountGroup()
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
        Public Function MaxId()
            Dim str As String
            Try
                str = "select Top 1 AccountGroupID from AccountGroup order by AccountGroupID DESC"
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountGroupCodeForCombo()
            Dim str As String
            Try
                str = "select Distinct AccountGroupID,AccountGroup  from AccountGroup "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountGroupCode(ByVal AccountGroupId As Long)
            Dim str As String
            Try
                str = "select AccountGroupCode  from AccountGroup where AccountGroupID='" & AccountGroupId & "'"
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountSubGroupCode(ByVal AccountSubGroupId As Long)
            Dim str As String
            Try
                str = "select AccountSubGroupCode  from AccountSubGroup where AccountSubGroupID='" & AccountSubGroupId & "'"
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function LoadAll()
            Dim str As String
            Try
                str = "select * from AccountGroup "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal AccountGroup As String)
            Dim str As String
            Try
                str = "select * from AccountGroup where AccountGroup='" & AccountGroup & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetdataForBudgetAccountGroupSetting()
            Dim str As String
            Try
                str = "select * from AccountGroup "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetdataForBudgetAccountSubGroupSetting(ByVal AccountGroupId As Long)
            Dim str As String
            Try
                str = "  Select ASG.AccountGroupID, ASG.AccountSubGroupID, ASG.AccountSubGroup "
                str &= " from  AccountGroup  AG "
                str &= " join AccountSubGroup ASG on AG.AccountGroupID =ASG.AccountGroupID "
                str &= " where ASG.AccountGroupID =" & AccountGroupId
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountSubGroupCodeForCombo(ByVal AccountGroupId As Long)
            Dim str As String
            Try
                str = "select AccountSubGroupID ,AccountSubGroup  from AccountSubGroup where AccountGroupID =" & AccountGroupId
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetdataForBudgetSetting(ByVal AccountSubGroupID As Long)
            Dim str As String
            Try
                str = "  Select ASG.AccountGroupID, ASG.AccountSubGroupID,ca.ChartofAccountID, ASG.AccountSubGroup "
                str &= "  ,ca.AccountType from ChartOfAccount CA "
                str &= "  join  AccountGroup  AG on AG.AccountGroupID =CA.AccountGroupID "
                str &= "  join AccountSubGroup ASG on ASG.AccountSubGroupID =CA.AccountSubGroupID "
                str &= "  where CA.AccountSubGroupID ='" & AccountSubGroupID & "' order by  CA.AccountSubGroupID  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetdataForCreateBudget()
            Dim str As String
            Try
                str = "  select BS.BudgetSettingId,BS.AccountGroupID ,BS.AccountSubGroupID ,BS.ChartofAccountID"
                str &= " ,AG.AccountGroup ,BAG.PercentageAllocationAccountGroup "
                str &= " ,ASG.AccountSubGroup,BASG.PercentageAllocationAccountSubGroup "
                str &= " ,CA.AccountType,BS.PercentageAllocationChartOfAccount   from BudgetSetting BS "
                str &= " join BudgetAccountGroupSetting BAG on BAG.AccountGroupID =BS.AccountGroupID "
                str &= " join BudgetAccountSubGroupSetting BASG on BASG.AccountSubGroupID =BS.AccountSubGroupID "
                str &= " join AccountGroup AG on AG.AccountGroupID =BS.AccountGroupID "
                str &= " join AccountSubGroup ASG on ASG.AccountSubGroupID =BS.AccountSubGroupID "
                str &= " join ChartOfAccount CA on CA.ChartofAccountID =BS.ChartofAccountID "
                str &= " order by BS.AccountGroupID ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
       
    End Class
End Namespace
