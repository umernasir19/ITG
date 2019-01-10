Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class IssueType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IssueType"
            m_strPrimaryFieldName = "IssueTypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lIssueTypeID As Long
        Private m_strIssueType As String
        Public Property IssueTypeID() As Long
            Get
                IssueTypeID = m_lIssueTypeID
            End Get
            Set(ByVal Value As Long)
                m_lIssueTypeID = Value
            End Set
        End Property
        Public Property IssueType() As String
            Get
                IssueType = m_strIssueType
            End Get
            Set(ByVal Value As String)
                m_strIssueType = Value
            End Set
        End Property
        Public Function SaveIssueType()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                MyBase.GetCurrentId()
            Catch ex As Exception

            End Try
        End Function
        Public Function BindIssueType() As DataTable
            Dim str As String

            str = " select * from IssueType "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function




    End Class
End Namespace

