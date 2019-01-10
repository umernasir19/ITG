Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class SamplingDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SamplingDetail"
            m_strPrimaryFieldName = "SamplingDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSamplingDetailID As Long
        Private m_lSamplingMasterID As Long

        Private m_lFabrictypeID As Long
        Private m_dNoofPieces As Decimal
        Private m_dNoofPcsDis As Decimal
        Private m_strSampleType As String
        Private m_strColor As String
        Private m_strSize As String
        Private m_strDeadline As String
        Private m_strReceivedDate As String
        Private m_strDispatchedDate As String
        Private m_strSubmission As String
        Private m_strStatus As String
        Private m_strSampleRemarks As String
        Private m_strSampleLocation As String
        Private m_strRejConSample As String
        Private m_strCommentsReceivedDate As String
        Private m_strSupEstdate As String
        Private m_strNoofPcsRecvd As Decimal
        Public Property SamplingDetailID() As Long
            Get
                SamplingDetailID = m_lSamplingDetailID
            End Get
            Set(ByVal value As Long)
                m_lSamplingDetailID = value
            End Set
        End Property
        Public Property SamplingMasterID() As Long
            Get
                SamplingMasterID = m_lSamplingMasterID
            End Get
            Set(ByVal value As Long)
                m_lSamplingMasterID = value
            End Set
        End Property
       
        Public Property FabrictypeID() As Long
            Get
                FabrictypeID = m_lFabrictypeID
            End Get
            Set(ByVal value As Long)
                m_lFabrictypeID = value
            End Set
        End Property
        Public Property NoofPieces() As Decimal
            Get
                NoofPieces = m_dNoofPieces
            End Get
            Set(ByVal value As Decimal)
                m_dNoofPieces = value
            End Set
        End Property
        Public Property NoofPcsDis() As Decimal
            Get
                NoofPcsDis = m_dNoofPcsDis
            End Get
            Set(ByVal value As Decimal)
                m_dNoofPcsDis = value
            End Set
        End Property
        Public Property SampleType() As String
            Get
                SampleType = m_strSampleType
            End Get
            Set(ByVal value As String)
                m_strSampleType = value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal value As String)
                m_strColor = value
            End Set
        End Property
        Public Property Size() As String
            Get
                Size = m_strSize
            End Get
            Set(ByVal value As String)
                m_strSize = value
            End Set
        End Property
        Public Property Deadline() As String
            Get
                Deadline = m_strDeadline
            End Get
            Set(ByVal value As String)
                m_strDeadline = value
            End Set
        End Property
        Public Property ReceivedDate() As String
            Get
                ReceivedDate = m_strReceivedDate
            End Get
            Set(ByVal value As String)
                m_strReceivedDate = value
            End Set
        End Property
        Public Property DispatchedDate() As String
            Get
                DispatchedDate = m_strDispatchedDate
            End Get
            Set(ByVal value As String)
                m_strDispatchedDate = value
            End Set
        End Property
        Public Property Submission() As String
            Get
                Submission = m_strSubmission
            End Get
            Set(ByVal value As String)
                m_strSubmission = value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = m_strStatus
            End Get
            Set(ByVal value As String)
                m_strStatus = value
            End Set
        End Property
        Public Property SampleRemarks() As String
            Get
                SampleRemarks = m_strSampleRemarks
            End Get
            Set(ByVal value As String)
                m_strSampleRemarks = value
            End Set
        End Property
        Public Property SampleLocation() As String
            Get
                SampleLocation = m_strSampleLocation
            End Get
            Set(ByVal value As String)
                m_strSampleLocation = value
            End Set
        End Property
        Public Property RejConSample() As String
            Get
                RejConSample = m_strRejConSample
            End Get
            Set(ByVal value As String)
                m_strRejConSample = value
            End Set
        End Property
        Public Property CommentsReceivedDate() As String
            Get
                CommentsReceivedDate = m_strCommentsReceivedDate
            End Get
            Set(ByVal value As String)
                m_strCommentsReceivedDate = value
            End Set
        End Property

        Public Property SupEstdate() As String
            Get
                SupEstdate = m_strSupEstdate
            End Get
            Set(ByVal value As String)
                m_strSupEstdate = value
            End Set
        End Property
        Public Property NoofPcsRecvd() As Decimal
            Get
                NoofPcsRecvd = m_strNoofPcsRecvd
            End Get
            Set(ByVal value As Decimal)
                m_strNoofPcsRecvd = value
            End Set
        End Property

        Public Function SaveSamplingDetail()
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
