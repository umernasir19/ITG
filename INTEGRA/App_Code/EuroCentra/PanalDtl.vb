Imports Microsoft.VisualBasic
Imports System.Data
Public Class PanalDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PanalDtl"
        m_strPrimaryFieldName = "PanalDtlid"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPanalDtlid As Long
    Private m_lPanalMstid As Long
    Private m_lJobOrderID As Long

    Private m_strSRNO As String
    Private m_dtPanalDate As Date


    Private m_strRangNo As String
    Private m_dPanalQty As Decimal
    Private m_dRejectionQty As Decimal
    Private m_strRemarks As String
    Private m_strColor As String
    Public Property PanalDtlid() As Long
        Get
            PanalDtlid = m_lPanalDtlid
        End Get
        Set(ByVal value As Long)
            m_lPanalDtlid = value
        End Set
    End Property
    Public Property PanalMstid() As Long
        Get
            PanalMstid = m_lPanalMstid
        End Get
        Set(ByVal value As Long)
            m_lPanalMstid = value
        End Set
    End Property
    Public Property JobOrderID() As Long
        Get
            JobOrderID = m_lJobOrderID
        End Get
        Set(ByVal value As Long)
            m_lJobOrderID = value
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
    Public Property SRNO() As String
        Get
            SRNO = m_strSRNO
        End Get
        Set(ByVal value As String)
            m_strSRNO = value
        End Set
    End Property
    Public Property PanalDate() As Date
        Get
            PanalDate = m_dtPanalDate
        End Get
        Set(ByVal value As Date)
            m_dtPanalDate = value
        End Set
    End Property
    Public Property RangNo() As String
        Get
            RangNo = m_strRangNo
        End Get
        Set(ByVal value As String)
            m_strRangNo = value
        End Set
    End Property
    Public Property PanalQty() As Decimal
        Get
            PanalQty = m_dPanalQty
        End Get
        Set(ByVal Value As Decimal)
            m_dPanalQty = Value
        End Set
    End Property
    Public Property RejectionQty() As Decimal
        Get
            RejectionQty = m_dRejectionQty
        End Get
        Set(ByVal Value As Decimal)
            m_dRejectionQty = Value
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
   Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Function DeletePanalDetail(ByVal PanalDtlID As Long)
        Dim Str As String
        Str = " delete  PanalDtl  where PanalDtlID='" & PanalDtlID & "'"
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetPanalDetailByID(ByVal PanalDtlID As Long) As DataTable
        Dim Str As String
        Str = " select * from PanalDtl  where PanalDtlID='" & PanalDtlID & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
End Class
