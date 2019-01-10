Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class EnqCustomerACP
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnqCustomerACP"
            m_strPrimaryFieldName = "EnqCustomerACPID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lEnqCustomerACPID As Long
        Private m_lEnquiriesSystemID As Long
        Private m_strTechPackDate As String
        Private m_strOriginalSampleDate As String
        Private m_strMOQDate As String
        Private m_strCadArtworkDate As String
        Private m_strPODate As String
        Private m_strEnqCRemarks As String
        Public Property EnqCustomerACPID() As Long
            Get
                EnqCustomerACPID = m_lEnqCustomerACPID
            End Get
            Set(ByVal value As Long)
                m_lEnqCustomerACPID = value
            End Set
        End Property
        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_lEnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_lEnquiriesSystemID = value
            End Set
        End Property
        Public Property TechPackDate() As String
            Get
                TechPackDate = m_strTechPackDate
            End Get
            Set(ByVal value As String)
                m_strTechPackDate = value
            End Set
        End Property
        Public Property OriginalSampleDate() As String
            Get
                OriginalSampleDate = m_strOriginalSampleDate
            End Get
            Set(ByVal value As String)
                m_strOriginalSampleDate = value
            End Set
        End Property
        Public Property MOQDate() As String
            Get
                MOQDate = m_strMOQDate
            End Get
            Set(ByVal value As String)
                m_strMOQDate = value
            End Set
        End Property
        Public Property CadArtworkDate() As String
            Get
                CadArtworkDate = m_strCadArtworkDate
            End Get
            Set(ByVal value As String)
                m_strCadArtworkDate = value
            End Set
        End Property
        Public Property PODate() As String
            Get
                PODate = m_strPODate
            End Get
            Set(ByVal value As String)
                m_strPODate = value
            End Set
        End Property
        Public Property EnqCRemarks() As String
            Get
                EnqCRemarks = m_strEnqCRemarks
            End Get
            Set(ByVal value As String)
                m_strEnqCRemarks = value
            End Set
        End Property
        Public Function SaveEnqCustomerACP()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Function getEditCRPBUYER(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select convert (varchar,convert(datetime,TechPackDate,104),101) as TechPackDatee,"
            Str &= " convert (varchar,convert(datetime,OriginalSampleDate,104),101) as OriginalSampleDatee,"

            Str &= " convert (varchar,convert(datetime,CadArtworkDate,104),101) as CadArtworkDatee,"
            Str &= " convert (varchar,convert(datetime,PODate,104),101) as PODatee,*  from EnqCustomerACP ES WHERE ES.EnquiriesSystemID='" & EnquiriesSystemID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace


