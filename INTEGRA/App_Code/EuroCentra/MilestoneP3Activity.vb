Imports System.Data
Namespace EuroCentra
    Public Class MilestoneP3Activity
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "MilestoneP3Activity"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lID As Long
        Private m_dCreationDate As Date
        Private m_strLoginUserName As String
        Private m_strReportType As String
        Private m_dFromDate As Date
        Private m_dToDate As Date
        Private m_strReportSelection As String

        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal value As Long)
                m_lID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal value As Date)
                m_dCreationDate = value
            End Set
        End Property
        Public Property LoginUserName() As String
            Get
                LoginUserName = m_strLoginUserName
            End Get
            Set(ByVal value As String)
                m_strLoginUserName = value
            End Set
        End Property
        Public Property ReportType() As String
            Get
                ReportType = m_strReportType
            End Get
            Set(ByVal value As String)
                m_strReportType = value
            End Set
        End Property
        Public Property FromDate() As Date
            Get
                FromDate = m_dFromDate
            End Get
            Set(ByVal value As Date)
                m_dFromDate = value
            End Set
        End Property
        Public Property ToDate() As Date
            Get
                ToDate = m_dToDate
            End Get
            Set(ByVal value As Date)
                m_dToDate = value
            End Set
        End Property
        Public Property ReportSelection() As String
            Get
                ReportSelection = m_strReportSelection
            End Get
            Set(ByVal value As String)
                m_strReportSelection = value
            End Set
        End Property
        Public Function SaveMilestoneP3Activity()
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
        Function GetUserName(ByVal Userid As Long)
            Dim Str As String
            Str = " Select Username from Umuser where Userid=" & Userid
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
