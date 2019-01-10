Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class ChartOfAccount
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ChartOfAccount"
            m_strPrimaryFieldName = "ChartofAccountID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lChartofAccountID As Long
        Private m_lAccountGroupID As Long
        Private m_lAccountSubGroupID As Long
        Private m_dtCreationDate As Date
        Private m_strAccountCode As String
        Private m_strAccountType As String
        Private m_strChartOfAccountCode As String
     
        Public Property ChartofAccountID() As Long
            Get
                ChartofAccountID = m_lChartofAccountID
            End Get
            Set(ByVal value As Long)
                m_lChartofAccountID = value
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
        Public Property AccountSubGroupID() As Long
            Get
                AccountSubGroupID = m_lAccountSubGroupID
            End Get
            Set(ByVal value As Long)
                m_lAccountSubGroupID = value
            End Set
        End Property
        Public Property AccountCode() As String
            Get
                AccountCode = m_strAccountCode
            End Get
            Set(ByVal value As String)
                m_strAccountCode = value
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
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property ChartOfAccountCode() As String
            Get
                ChartOfAccountCode = m_strChartOfAccountCode
            End Get
            Set(ByVal value As String)
                m_strChartOfAccountCode = value
            End Set
        End Property
        Public Function SaveChartOfAccount()
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
        Public Function GetAccountGroup()
            Dim str As String
            str = " Select * from AccountGroup "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountSubGroup(ByVal AccountGroupId As Long)
            Dim str As String
            str = " Select  * from AccountSubGroup where AccountGroupID='" & AccountGroupId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetExisting(ByVal AccountGroupID As Long, ByVal AccountSubGroupID As Long, ByVal AccountType As String)
            Dim str As String
            str = " Select  * from ChartOfAccount "
            str &= " where AccountGroupID=" & AccountGroupID
            str &= " and AccountSubGroupID=" & AccountSubGroupID
            str &= " and AccountType ='" & AccountType & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountHead(ByVal Type As String)
            Dim str As String
            str = " Select CoA.ChartofAccountID, AG.AccountGroup + '/' + ASG.AccountSubGroup + '/' + CoA.AccountType as AccountHead "
            str &= " from ChartOfAccount CoA "
            str &= " join AccountGroup AG on AG.AccountGroupID=CoA.AccountGroupID "
            str &= " join AccountSubGroup ASG on ASG.AccountSubGroupID=CoA.AccountSubGroupID "
            'If Type = "CPV" Then
            '    str &= " where  AG.AccountGroupID=2"
            'ElseIf Type = "CRV" Then
            '    str &= " where  AG.AccountGroupID=1 "
            'End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountHeadBankTransaction(ByVal Type As String)
            Dim str As String
            str = " Select CoA.ChartofAccountID, AG.AccountGroup + '/' + ASG.AccountSubGroup + '/' + CoA.AccountType as AccountHead "
            str &= " from ChartOfAccount CoA "
            str &= " join AccountGroup AG on AG.AccountGroupID=CoA.AccountGroupID "
            str &= " join AccountSubGroup ASG on ASG.AccountSubGroupID=CoA.AccountSubGroupID "
            'If Type = "BPV" Then
            '    str &= " where  AG.AccountGroupID=2"
            'ElseIf Type = "BRV" Then
            '    str &= " where  AG.AccountGroupID=1 "
            'End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetECPCode()
            Dim str As String
            str = " Select * from ECPCode "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetHKCode()
            Dim str As String
            str = " Select * from HKCode "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData()
            Dim str As String
            'str = " select COA.ChartofAccountID,"
            'str &= " (case when cast( AG.AccountGroupID as varchar(4000))=1 and cast( COA.ChartofAccountID as varchar(4000))> 0 and  cast( COA.ChartofAccountID as varchar(4000))<= 9 then"
            'str &= "  '1000'+ convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) "
            'str &= " when cast( AG.AccountGroupID as varchar(4000))=1 and cast( COA.ChartofAccountID as varchar(4000))>= 10 and  cast( COA.ChartofAccountID as varchar(4000))<= 99 then"
            'str &= " '100'+ convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) "
            'str &= " when cast( AG.AccountGroupID as varchar(4000))=1 and cast( COA.ChartofAccountID as varchar(4000))>= 100 and  cast( COA.ChartofAccountID as varchar(4000))<= 999 then"
            'str &= "  '10'+ convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) "
            'str &= " when cast( AG.AccountGroupID as varchar(4000))=2  and cast( COA.ChartofAccountID as varchar(4000))> 0 and  cast( COA.ChartofAccountID as varchar(4000))<= 9 then"
            'str &= " '2000'+ convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) "
            'str &= " when cast( AG.AccountGroupID as varchar(4000))=2  and cast( COA.ChartofAccountID as varchar(4000))>= 10 and  cast( COA.ChartofAccountID as varchar(4000))<= 99 then"
            'str &= " '200'+ convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) "
            'str &= " when cast( AG.AccountGroupID as varchar(4000))=2  and cast( COA.ChartofAccountID as varchar(4000))> 100 and  cast( COA.ChartofAccountID as varchar(4000))<= 999 then"
            'str &= " '20'+ convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) "
            'str &= " else convert(varchar,cast( COA.ChartofAccountID as varchar(4000))) end) as AccountCode,"
            'str &= "  AG.AccountGroup, ASG.AccountSubGroup, COA.AccountType"
            'str &= " from ChartOfAccount COA"
            'str &= " join AccountGroup AG on AG.AccountGroupID=CoA.AccountGroupID "
            'str &= " join AccountSubGroup ASG on ASG.AccountSubGroupID=CoA.AccountSubGroupID "

            str = " select COA.ChartofAccountID,AccountCode, "
            str &= "  AG.AccountGroup, ASG.AccountSubGroup, COA.AccountType"
            str &= " from ChartOfAccount COA"
            str &= " join AccountGroup AG on AG.AccountGroupID=CoA.AccountGroupID "
            str &= " join AccountSubGroup ASG on ASG.AccountSubGroupID=CoA.AccountSubGroupID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetAccountCode(ByVal AccountGroupId As Long, ByVal AccountSubGroupId As Long)
            Dim str As String
            Try
                str = " select top 1 ChartofAccountID , AccountCode     from ChartOfAccount where AccountGroupID ='" & AccountGroupId & "' and AccountSubGroupID='" & AccountSubGroupId & "'"
                str &= " order by ChartofAccountID DESC  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetChartOfAccountCode(ByVal AccountGroupId As Long, ByVal AccountSubGroupId As Long)
            Dim str As String
            Try
                str = " select top 1 ChartofAccountID ,ChartOfAccountCode     from ChartOfAccount where AccountGroupID ='" & AccountGroupId & "' and AccountSubGroupID='" & AccountSubGroupId & "'"
                str &= " order by ChartofAccountID DESC  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccountHeadName(ByVal ChartofAccountID As Long)
            Dim str As String
            str = " Select  AccountType from ChartOfAccount where ChartofAccountID='" & ChartofAccountID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace