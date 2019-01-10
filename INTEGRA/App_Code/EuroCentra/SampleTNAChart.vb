Imports System.Data
Public Class SampleTNAChart
    Inherits SQLManager

    Public Sub New()
        m_strTableName = "SampleTNAChart"
        m_strPrimaryFieldName = "SampleTNAChartID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lSampleTNAChartID As Long
    Private m_lTNAProcessID As Long
    Private m_lStyleID As Long
    Private m_strStatus As String
    Private m_dIdealDate As Date
    Private m_dDateEstemated As Date
    Private m_dActualDate As Date
    Private m_strRemarks As String
    Private m_lScheduleTime As Long
    Private m_bSelected As Boolean
    Private m_strSelectedStatus As String
    Private m_strSubmission As String
    Private m_dCreationDate As Date

    Public Property SampleTNAChartID() As Long
        Get
            SampleTNAChartID = m_lSampleTNAChartID
        End Get
        Set(ByVal value As Long)
            m_lSampleTNAChartID = value
        End Set
    End Property
    Public Property TNAProcessID() As Long
        Get
            TNAProcessID = m_lTNAProcessID
        End Get
        Set(ByVal value As Long)
            m_lTNAProcessID = value
        End Set
    End Property
    Public Property StyleID() As Long
        Get
            StyleID = m_lStyleID
        End Get
        Set(ByVal value As Long)
            m_lStyleID = value
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
    Public Property Selected() As Boolean
        Get
            Selected = m_bSelected
        End Get
        Set(ByVal value As Boolean)
            m_bSelected = value
        End Set
    End Property
    Public Property SelectedStatus() As String
        Get
            SelectedStatus = m_strSelectedStatus
        End Get
        Set(ByVal value As String)
            m_strSelectedStatus = value
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
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dCreationDate
        End Get
        Set(ByVal value As Date)
            m_dCreationDate = value
        End Set
    End Property
    Public Property ScheduleTime() As Long
        Get
            ScheduleTime = m_lScheduleTime
        End Get
        Set(ByVal Value As Long)
            m_lScheduleTime = Value
        End Set
    End Property
    Public Function SaveSampleTNAChart()
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
    Public Function GetSampleTNAChartById(ByVal lSampleTNAChartID As Long)
        Try
            Return MyBase.GetById(lSampleTNAChartID)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetProcessByTNAChartIdd(ByVal StyleID As Long) As DataTable
        Dim Str As String
        Str = "Select StyleID, SampleTNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,120) end) as ActualDate ,Status,Remarks,Process,Convert(Varchar,IDealDate,103)as IdealDate , DateEstemated as EstimatedDate, Selected,SelectedStatus from SampleTNAChart Chrt"
        Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID    where StyleID=" & StyleID
        Str &= " order by sequence "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetScheduleNew() As DataTable
        Dim Str As String
        Str = "     Select Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
        Str &= "    where  ProcessID  in (1,2,3,10,13,27,6,5,15,23,28) order by Sequence"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function CheckExisting(ByVal StyleID As Long) As DataTable
        Dim Str As String
        Str = " Select * from SampleTNAChart"
        Str &= " where StyleID =" & StyleID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function UpdateTNAChart(ByVal ChartID As Long, ByVal DateEstemated As Date, ByVal ActualDatee As Date)
        Dim Str As String
        Str = "Update TNAChart Set DateEstemated='" & DateEstemated & "',ActualDate='" & ActualDatee & "' where TNAChartID=" & ChartID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSampleTNAChartID(ByVal ChartID As Long)
        Dim Str As String
        Str = " select SampleTNAChartID  from SampleTNAChart where TNAChartID =" & ChartID
        Try
            MyBase.GetScaler(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSamplingActivityData(ByVal SampleTNAChartID As Long) As DataTable
        Dim Str As String
        Str = " select  *  from SampleTNAChart where SampleTNAChartID =" & SampleTNAChartID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function UpdateSelecteStatus(ByVal StyleID)
        Dim Str As String
        Str = "Update  SampleTNAChart Set SelectedStatus='SELECTED' where StyleID=" & StyleID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function UpdateSelecte(ByVal SampleTNAChartID As String)
        Dim Str As String
        Str = "Update  SampleTNAChart Set Selected=0 where SampleTNAChartID In " & SampleTNAChartID
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
End Class
