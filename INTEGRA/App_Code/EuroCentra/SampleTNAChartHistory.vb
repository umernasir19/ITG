Imports System.Data
Public Class SampleTNAChartHistory
    Inherits SQLManager

    Public Sub New()
        m_strTableName = "SampleTNAChartHistory"
        m_strPrimaryFieldName = "SampleTNAChartHistoryID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lSampleTNAChartHistoryID As Long
    Private m_lSampleTNAChartID As Long
    Private m_dCreationDate As Date
    Private m_iTNAProcessID As Integer
    Private m_strStatus As String
    Private m_dIdealDate As Date
    Private m_dDateEstemated As Date
    Private m_dActualDate As Date
    Private m_strRemarks As String
    Private m_strSubmission As String

    Public Property SampleTNAChartHistoryID() As Long
        Get
            SampleTNAChartHistoryID = m_lSampleTNAChartHistoryID
        End Get
        Set(ByVal value As Long)
            m_lSampleTNAChartHistoryID = value
        End Set
    End Property
    Public Property SampleTNAChartID() As Long
        Get
            SampleTNAChartID = m_lSampleTNAChartID
        End Get
        Set(ByVal value As Long)
            m_lSampleTNAChartID = value
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
    Public Property TNAProcessID() As Integer
        Get
            TNAProcessID = m_iTNAProcessID
        End Get
        Set(ByVal value As Integer)
            m_iTNAProcessID = value
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
    Public Property IdealDate() As Date
        Get
            IdealDate = m_dIdealDate
        End Get
        Set(ByVal value As Date)
            m_dIdealDate = value
        End Set
    End Property
    Public Property DateEstemated() As Date
        Get
            DateEstemated = m_dDateEstemated
        End Get
        Set(ByVal value As Date)
            m_dDateEstemated = value
        End Set
    End Property
    Public Property ActualDate() As Date
        Get
            ActualDate = m_dActualDate
        End Get
        Set(ByVal value As Date)
            m_dActualDate = value
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
    Public Function SaveSampleTNAChartHistory()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetID() As Long
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTNAChartHistoryByProcess(ByVal ProcessId As Long, ByVal StyleID As Long)
        Dim Str As String
        Str = " Select Convert(Varchar,SN.CreationDate,103)as CreationDate,"
        Str &= " SN.Status,SN.Submission,Convert(Varchar,SN.DateEstemated,103)as DateEstemated,"
        Str &= " Convert(Varchar,SN.ActualDate,103)as ActualDate,SN.Remarks ,Process,STM.StyleNo"
        Str &= " from SampleTNAChartHistory SN"
        Str &= " join SampleTNAChart ST on ST.SampleTNAChartID=SN.SampleTNAChartID"
        Str &= "  Join TNAProcess Prcs On Prcs.ProcessID=SN.TNAProcessID "
        Str &= " Join  stylemaster STM on ST.StyleID=STM.StyleID"
        Str &= " Where ST.StyleID =" & StyleID
        Str &= " and ST.TNAProcessID=" & ProcessId
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function

 

End Class
