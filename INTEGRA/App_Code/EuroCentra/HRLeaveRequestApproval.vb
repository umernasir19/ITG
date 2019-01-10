Imports System.Data
Public Class HRLeaveRequestApproval
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "HRLeaveRequestApproval"
        m_strPrimaryFieldName = "LeaveRequestApprovalID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lLeaveRequestApprovalID As Long
    Private m_lLeaveRequestID As Long
    Private m_lHRID As Long
    Private m_strRemarks As String
    Private m_dtActionDate As Date
    Private m_strStatus As String
    '''''''''''''''''''''''''''''''''''''''''Properties''''''''''''''''''''''''''''''''''''''''''''
    Public Property LeaveRequestApprovalID() As Long
        Get
            LeaveRequestApprovalID = m_lLeaveRequestApprovalID
        End Get
        Set(ByVal value As Long)
            m_lLeaveRequestApprovalID = value
        End Set
    End Property
    Public Property LeaveRequestID() As Long
        Get
            LeaveRequestID = m_lLeaveRequestID
        End Get
        Set(ByVal value As Long)
            m_lLeaveRequestID = value
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
    Public Property ActionDate() As Date
        Get
            ActionDate = m_dtActionDate
        End Get
        Set(ByVal value As Date)
            m_dtActionDate = value
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
    Public Property Status() As String
        Get
            Status = m_strStatus
        End Get
        Set(ByVal value As String)
            m_strStatus = value
        End Set
    End Property
    Public Function SaveLeaveRequestApproval()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function
    ''''''''''''''''''''''''''''''''''Quries'''''''''''''''''''''''''''''''''''''''''''''
    Public Function GetValuesForPendingRequests() As DataTable
        Dim str As String
        str = " Select HRM.EmployeeName, HRLT.TotalLeaveGranted,HRLT.TotalLeaveAvailed,LR.*,CONVERT (Varchar, LR.LeaveFrom, 103) as LeaveFromm,CONVERT (Varchar, LR.LeaveTo, 103) as LeaveToo from HRLeaveRequest LR "
        str &= " join HRMain HRM on HRM.HRID = LR.HRID"
        str &= " join HRLeaveTable HRLT on HRLT.HRID = HRM.HRID Where LR.Approved = 0 And LR.Rejected = 0 "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetValuesForApprovedrequest() As DataTable
        Dim str As String
        str = " Select HRM.EmployeeName, HRLT.TotalLeaveGranted,HRLT.TotalLeaveAvailed,LR.*, HRLRA.Remarks,CONVERT (Varchar, LR.LeaveFrom, 103) as LeaveFromm,CONVERT (Varchar, LR.LeaveTo, 103) as LeaveToo from HRLeaveRequest LR "
        str &= " join HRMain HRM on HRM.HRID = LR.HRID "
        str &= "  join HRLeaveRequestApproval HRLRA on HRLRA.LeaveRequestID = LR.LeaveRequestID "
        str &= " join HRLeaveTable HRLT on HRLT.HRID = HRM.HRID Where LR.Approved = 1 "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetValuesForRejectedrequest() As DataTable
        Dim str As String
        str = " Select HRM.EmployeeName, HRLT.TotalLeaveGranted,HRLT.TotalLeaveAvailed,LR.*, HRLRA.Remarks,CONVERT (Varchar, LR.LeaveFrom, 103) as LeaveFromm,CONVERT (Varchar, LR.LeaveTo, 103) as LeaveToo from HRLeaveRequest LR "
        str &= " join HRMain HRM on HRM.HRID = LR.HRID "
        str &= "  join HRLeaveRequestApproval HRLRA on HRLRA.LeaveRequestID = LR.LeaveRequestID "
        str &= " join HRLeaveTable HRLT on HRLT.HRID = HRM.HRID Where LR.Rejected = 1 "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function RemoveLeaveStatus(ByVal HRID As Long) As DataTable
        Dim str As String
        str = " Select  *  From HRLeaveRequestApproval Where HRID = '" & HRID & "' order by LeaveRequestID DESC "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
