Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra

Public Class AccountSubGroup

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccountSubGroup"
            m_strPrimaryFieldName = "AccountSubGroupID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccountSubGroupID As Long
        Private m_strAccountSubGroup As String
        Private m_lAccountGroupID As Long
        Private m_strAccountSubGroupCode As String
        Public Property AccountSubGroupID() As Long
            Get
                AccountSubGroupID = m_lAccountSubGroupID
            End Get
            Set(ByVal value As Long)
                m_lAccountSubGroupID = value
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
        Public Property AccountGroupID() As Long
            Get
                AccountGroupID = m_lAccountGroupID
            End Get
            Set(ByVal value As Long)
                m_lAccountGroupID = value
            End Set
        End Property
        Public Property AccountSubGroupCode() As String
            Get
                AccountSubGroupCode = m_strAccountSubGroupCode
            End Get
            Set(ByVal value As String)
                m_strAccountSubGroupCode = value
            End Set
        End Property

        Public Function SaveAccountSubGroup()
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
                str = "select Max(AccountSubGroupID) from AccountSubGroup"
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountSubGroupCode(ByVal AccountGroupId As Long)
            Dim str As String
            Try
                str = " select top 1 AccountSubGroupID,AccountSubGroupCode    from AccountSubGroup where AccountGroupID ='" & AccountGroupId & "'"
                str &= " order by AccountSubGroupID DESC  "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function LoadAll()
            Dim str As String
            Try
                str = " select * from AccountSubGroup ASG"
                str &= " join AccountGroup AG on AG.AccountGroupID=ASG.AccountGroupID"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal AccountGroupID As Long, ByVal AccountSubGroup As String)
            Dim str As String
            Try
                str = " select * from AccountSubGroup ASG where AccountGroupID ='" & AccountGroupID & "' and AccountSubGroup ='" & AccountSubGroup & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

