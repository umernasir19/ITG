Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class UmUserLinkLog
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "UmUserLinkLog"
            m_strPrimaryFieldName = "Logid"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_iLogid As Integer
        Private m_iUserid As Integer
        Private m_DMailSenddate As Date
        Private m_strEmailStatus As String

        Public Property MailSenddate() As Date
            Get
                MailSenddate = m_DMailSenddate
            End Get
            Set(ByVal value As Date)
                m_DMailSenddate = value
            End Set
        End Property
        Public Property EmailStatus() As String
            Get
                EmailStatus = m_strEmailStatus
            End Get
            Set(ByVal value As String)
                m_strEmailStatus = value
            End Set
        End Property

        Public Property Userid() As Integer
            Get
                Userid = m_iUserid
            End Get
            Set(ByVal value As Integer)
                m_iUserid = value
            End Set
        End Property
        Public Property Logid() As Integer
            Get
                Logid = m_iLogid
            End Get
            Set(ByVal value As Integer)
                m_iLogid = value
            End Set
        End Property
        Public Function SaveEmailSendInfo()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailSendInfo()
            Dim Str As String
            Str = "select *  from UmUserLinkLog where "
            Str &= " year(MailSenddate) =" & Date.Now.Year
            Str &= " and month(MailSenddate) =" & Date.Now.Month
            Str &= " and day(MailSenddate) = " & Date.Now.Day
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteEmailSendInfo()
            Dim Str As String
            Str = "Delete from UmUserLinkLog where "
            Str &= " year(MailSenddate) =" & Date.Now.Year
            Str &= " and month(MailSenddate) =" & Date.Now.Month
            Str &= " and day(MailSenddate) = " & Date.Now.Day
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace