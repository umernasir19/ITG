Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra

Public Class HRLeaveHistory
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRLeaveHistory"
            m_strPrimaryFieldName = "HRLeaveHistoryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lHRLeaveHistoryID As Long
        Private m_lHRLeaveID As Long
        Private m_strLeaveMonth As String
        Private m_lLeaveTotal As Decimal
        Private m_lLeaveAvailable As Decimal
        Private m_lLeaveAvailed As Decimal
        Private m_strLeaveType As String


        '----------------Properties
        Public Property HRLeaveHistoryID() As Long
            Get
                HRLeaveHistoryID = m_lHRLeaveHistoryID
            End Get
            Set(ByVal value As Long)
                m_lHRLeaveHistoryID = value
            End Set
        End Property
        Public Property HRLeaveID() As Long
            Get
                HRLeaveID = m_lHRLeaveID
            End Get
            Set(ByVal value As Long)
                m_lHRLeaveID = value
            End Set
        End Property
        Public Property LeaveMonth() As String
            Get
                LeaveMonth = m_strLeaveMonth
            End Get
            Set(ByVal value As String)
                m_strLeaveMonth = value
            End Set
        End Property
        Public Property LeaveTotal() As Decimal
            Get
                LeaveTotal = m_lLeaveTotal
            End Get
            Set(ByVal value As Decimal)
                m_lLeaveTotal = value
            End Set
        End Property
        Public Property LeaveAvailable() As Decimal
            Get
                LeaveAvailable = m_lLeaveAvailable
            End Get
            Set(ByVal value As Decimal)
                m_lLeaveAvailable = value
            End Set
        End Property
        Public Property LeaveAvailed() As Decimal
            Get
                LeaveAvailed = m_lLeaveAvailed
            End Get
            Set(ByVal value As Decimal)
                m_lLeaveAvailed = value
            End Set
        End Property
        Public Property LeaveType() As String
            Get
                LeaveType = m_strLeaveType
            End Get
            Set(ByVal value As String)
                m_strLeaveType = value
            End Set
        End Property
       
        Public Function SaveHRLeaveHistory()
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
