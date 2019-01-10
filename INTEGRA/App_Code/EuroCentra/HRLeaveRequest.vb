Imports System.Data
Public Class HRLeaveRequest
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "HRLeaveRequest"
        m_strPrimaryFieldName = "LeaveRequestID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lLeaveRequestID As Long
    Private m_lHRID As Long
    Private m_lUserID As Long
    Private m_dtCreationDate As Date
    Private m_dtLeaveFrom As Date
    Private m_dtLeaveTo As Date
    Private m_dtDateOfNotice As Date
    Private m_strReason As String
    Private m_lLeaveDays As Long
    Private m_bApproved As Boolean
    Private m_bRejected As Boolean
    '''''''''''''''''''''''''''''''''''''''''Properties''''''''''''''''''''''''''''''''''''''''''''
    Public Property LeaveRequestID() As Long
        Get
            LeaveRequestID = m_lLeaveRequestID
        End Get
        Set(ByVal value As Long)
            m_lLeaveRequestID = value
        End Set
    End Property
    Public Property UserID() As Long
        Get
            UserID = m_lUserID
        End Get
        Set(ByVal value As Long)
            m_lUserID = value
        End Set
    End Property
    Public Property HRID() As Long
        Get
            HRID = m_lHRID
        End Get
        Set(ByVal value As Long)
            m_lHRID = value
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
    Public Property LeaveFrom() As Date
        Get
            LeaveFrom = m_dtLeaveFrom
        End Get
        Set(ByVal value As Date)
            m_dtLeaveFrom = value
        End Set
    End Property
    Public Property LeaveTo() As Date
        Get
            LeaveTo = m_dtLeaveTo
        End Get
        Set(ByVal value As Date)
            m_dtLeaveTo = value
        End Set
    End Property
    Public Property DateOfNotice() As Date
        Get
            DateOfNotice = m_dtDateOfNotice
        End Get
        Set(ByVal value As Date)
            m_dtDateOfNotice = value
        End Set
    End Property
    Public Property Reason() As String
        Get
            Reason = m_strReason
        End Get
        Set(ByVal value As String)
            m_strReason = value
        End Set
    End Property
    Public Property LeaveDays() As Long
        Get
            LeaveDays = m_lLeaveDays
        End Get
        Set(ByVal value As Long)
            m_lLeaveDays = value
        End Set
    End Property
    Public Property Approved() As Boolean
        Get
            Approved = m_bApproved
        End Get
        Set(ByVal value As Boolean)
            m_bApproved = value
        End Set
    End Property
    Public Property Rejected() As Boolean
        Get
            Rejected = m_bRejected
        End Get
        Set(ByVal value As Boolean)
            m_bRejected = value
        End Set
    End Property
    Public Function SaveLeaveRequest()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
    ''''''''''''''''''''''''''''''''''Quries''''''''''''''''''''''''''''''''''''''''''
    Public Function GetUserDetail(ByVal HRID As Long) As DataTable
        Dim str As String
        str = " Select HRM.EmployeeName ,HRLT.TotalLeaveGranted, HRLT.TotalLeaveAvailed From HRLeaveTable HRLT "
        str &= " Join HRMain HRM on HRM.HRID = HRLT.HRID Where HRM.HRID = '" & HRID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetRequestStatus(ByVal LeaveRequestID As Long) As DataTable
        Dim str As String
        str = " Select * From  HRLeaveRequest LR Where LeaveRequestId = '" & LeaveRequestID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetPendingRequests(ByVal HRID As Long) As DataTable
        Dim str As String
        str = " Select LR.Approved, LR.Rejected  from HRLeaveRequest LR"
        str &= " join HRMain HRM on HRM.HRID = LR.HRID Where Approved = 0 And Rejected = 0 And LR.HRID = '" & HRID & "'  "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function CheckLeaveStatus(ByVal HRID As Long, ByVal UserID As Long) As DataTable
        Dim str As String
        str = " Select UserID, LR.Approved, LR.Rejected from HRLeaveRequest LR"
        str &= " join HRMain HRM on HRM.HRID = LR.HRID Where LR.HRID = '" & HRID & "' And UserID = '" & UserID & "' Order By LeaveRequestID DESC "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
