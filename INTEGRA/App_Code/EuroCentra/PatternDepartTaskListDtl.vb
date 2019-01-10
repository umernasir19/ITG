Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class PatternDepartTaskListDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PATTERNDEPARTMENTTASKLISTDtl"
        m_strPrimaryFieldName = "PATTERNDEPARTMENTTASKLISTDtlId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lPATTERNDEPARTMENTTASKLISTDtlId As Long
    Private m_lPATTERNDEPARTMENTTASKLISTMstId As Long
    Private m_lUserId As Long
    Private m_strFileNameTP As String
    Private m_ObUploadPictureTP As Object

    Public Property PATTERNDEPARTMENTTASKLISTDtlId() As Long
        Get
            PATTERNDEPARTMENTTASKLISTDtlId = m_lPATTERNDEPARTMENTTASKLISTDtlId
        End Get
        Set(ByVal value As Long)
            m_lPATTERNDEPARTMENTTASKLISTDtlId = value
        End Set
    End Property
    Public Property PATTERNDEPARTMENTTASKLISTMstId() As Long
        Get
            PATTERNDEPARTMENTTASKLISTMstId = m_lPATTERNDEPARTMENTTASKLISTMstId
        End Get
        Set(ByVal value As Long)
            m_lPATTERNDEPARTMENTTASKLISTMstId = value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal value As Long)
            m_lUserId = value
        End Set
    End Property
    Public Property FileNameTP() As String
        Get
            FileNameTP = m_strFileNameTP
        End Get
        Set(ByVal value As String)
            m_strFileNameTP = value
        End Set
    End Property
    Public Property UploadPictureTP() As Object
        Get
            UploadPictureTP = m_ObUploadPictureTP
        End Get
        Set(ByVal Value As Object)
            m_ObUploadPictureTP = Value
        End Set
    End Property
    Public Function Save()
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

    Public Function DeleteDetailTableZeroIds(ByVal UserID As Long)
        Dim str As String
        str = " delete from PATTERNDEPARTMENTTASKLISTDtl where UserId='" & UserID & "' and  PATTERNDEPARTMENTTASKLISTMstid='0' "
        Try
            MyBase.ExecuteNonQuery(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function updateSRQTeckPackDetailNew(ByVal SRQMasterid As Long, ByVal UserId As Long)
        Dim str As String
        str = "  update  SRQTeckPackDetail set  SRQMasterid ='" & SRQMasterid & " ' where SRQMasterid='0' and UserId='" & UserId & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function updateTaskListDetail(ByVal PATTERNDEPARTMENTTASKLISTMstid As Long)
        Dim str As String
        str = "  update  PATTERNDEPARTMENTTASKLISTDtl set  PATTERNDEPARTMENTTASKLISTMstid ='" & PATTERNDEPARTMENTTASKLISTMstid & " ' where PATTERNDEPARTMENTTASKLISTMstid='0' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class
