Imports System.Data

Namespace EuroCentra
    Public Class EmailReminder
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EmailReminder"
            m_strPrimaryFieldName = "ReminderID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lReminderID As Long
        Private m_lPOID As Long
        Private m_lProcessID As Long
        Private m_dNoofReminder As Decimal
        Private m_strStatus As String
        Private m_blProcessActive As Boolean
        Public Property ProcessActive() As Boolean
            Get
                ProcessActive = m_blProcessActive
            End Get
            Set(ByVal Value As Boolean)
                m_blProcessActive = Value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = m_strStatus
            End Get
            Set(ByVal Value As String)
                m_strStatus = Value
            End Set
        End Property
        Public Property ReminderID() As Long
            Get
                ReminderID = m_lReminderID
            End Get
            Set(ByVal Value As Long)
                m_lReminderID = Value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal Value As Long)
                m_lPOID = Value
            End Set
        End Property
        Public Property ProcessID() As Long
            Get
                ProcessID = m_lProcessID
            End Get
            Set(ByVal Value As Long)
                m_lProcessID = Value
            End Set
        End Property
        Public Property NoofReminder() As Decimal
            Get
                NoofReminder = m_dNoofReminder
            End Get
            Set(ByVal Value As Decimal)
                m_dNoofReminder = Value
            End Set
        End Property
        Public Function SaveEmailReminder()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierMailInfo(ByVal POID As Long, ByVal Supplierid As Long, ByVal Customerid As Long, ByVal Process As String)
            Dim str As String
            Try
                str = "  select * from EmailReminder "
                str &= " where POID=" & POID
                str &= " and Supplierid=" & Supplierid
                str &= " and Customerid=" & Customerid
                str &= " and Process= '" & Process & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteNotinList(ByVal POIDs As String, ByVal Supplierid As Long, ByVal Customerid As Long, ByVal Process As String)
            Dim str As String
            Try
                str = "  Delete from EmailReminder "
                str &= " where Supplierid=" & Supplierid
                str &= " and Customerid=" & Customerid
                str &= " and POID Not in " & POIDs & ""
                str &= " and Process= '" & Process & "'"

                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace