Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class ECPSamplingDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ECPSamplingDetail"
            m_strPrimaryFieldName = "ECPSamplingDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lECPSamplingDetail As Long
        Private m_lECPSamplingID As Long
        Private m_dNoOfPieces As Decimal
        Private m_lTypeOfSamplingID As Long
        Private m_strStatus As String
        Private m_strProgress As String
        Private m_strRemarks As String
        Private m_strSubmission As String
        Private m_dtDatee As Date
        Private m_strSampleLocation As String
        Public Property Datee() As Date
            Get
                Datee = m_dtDatee
            End Get
            Set(ByVal value As Date)
                m_dtDatee = value
            End Set
        End Property
        Public Property ECPSamplingDetailID() As Long
            Get
                ECPSamplingDetailID = m_lECPSamplingDetail
            End Get
            Set(ByVal value As Long)
                m_lECPSamplingDetail = value
            End Set
        End Property
        Public Property ECPSamplingID() As Long
            Get
                ECPSamplingID = m_lECPSamplingID
            End Get
            Set(ByVal value As Long)
                m_lECPSamplingID = value
            End Set
        End Property
        Public Property NoOfPieces() As Decimal
            Get
                NoOfPieces = m_dNoOfPieces
            End Get
            Set(ByVal value As Decimal)
                m_dNoOfPieces = value
            End Set
        End Property
        Public Property TypeOfSamplingID() As Long
            Get
                TypeOfSamplingID = m_lTypeOfSamplingID
            End Get
            Set(ByVal value As Long)
                m_lTypeOfSamplingID = value
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
        Public Property Progress() As String
            Get
                Progress = m_strProgress
            End Get
            Set(ByVal value As String)
                m_strProgress = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
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
        Public Property SampleLocation() As String
            Get
                SampleLocation = m_strSampleLocation
            End Get
            Set(ByVal value As String)
                m_strSampleLocation = value
            End Set
        End Property
        Public Function SaveECPSamplingDetail()
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