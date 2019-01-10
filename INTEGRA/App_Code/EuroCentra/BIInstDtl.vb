Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class BIInstDtl
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BIInstDtl"
        m_strPrimaryFieldName = "BIInstDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lBIInstDtlID As Long
    Private m_lBIInstMstID As Long
    Private m_lInvoiceID As Long
    Private m_strShiper As String
    Private m_strFormENo As String
    Private m_strShiperAddress As String
    Private m_dtFormEDate As Date
    Private m_strFrom As String
    Private m_strConsignee As String
    Private m_strToo As String
    Private m_dQtyCtn As Decimal
    Private m_dQtyPcs As Decimal
    Private m_dNetWt As Decimal
    Private m_dGrossWt As Decimal
    Private m_strNotify As String
    Private m_strLc As String
    Private m_dtLcDate As Date
    Private m_strContainer As String
    Private m_strVessel As String
    Private m_strDescription As String
    Private m_strFreight As String
    Private m_strMarksNo As String
    Public Property BIInstDtlID() As Long
        Get
            BIInstDtlID = m_lBIInstDtlID
        End Get
        Set(ByVal value As Long)
            m_lBIInstDtlID = value
        End Set
    End Property
    Public Property BIInstMstID() As Long
        Get
            BIInstMstID = m_lBIInstMstID
        End Get
        Set(ByVal value As Long)
            m_lBIInstMstID = value
        End Set
    End Property
    Public Property InvoiceID() As Long
        Get
            InvoiceID = m_lInvoiceID
        End Get
        Set(ByVal value As Long)
            m_lInvoiceID = value
        End Set
    End Property
    Public Property Shiper() As String
        Get
            Shiper = m_strShiper
        End Get
        Set(ByVal value As String)
            m_strShiper = value
        End Set
    End Property
    Public Property FormENo() As String
        Get
            FormENo = m_strFormENo
        End Get
        Set(ByVal value As String)
            m_strFormENo = value
        End Set
    End Property
    Public Property ShiperAddress() As String
        Get
            ShiperAddress = m_strShiperAddress
        End Get
        Set(ByVal value As String)
            m_strShiperAddress = value
        End Set
    End Property
    Public Property FormEDate() As Date
        Get
            FormEDate = m_dtFormEDate
        End Get
        Set(ByVal value As Date)
            m_dtFormEDate = value
        End Set
    End Property
    Public Property From() As String
        Get
            From = m_strFrom
        End Get
        Set(ByVal value As String)
            m_strFrom = value
        End Set
    End Property
    Public Property Consignee() As String
        Get
            Consignee = m_strConsignee
        End Get
        Set(ByVal value As String)
            m_strConsignee = value
        End Set
    End Property
    Public Property Too() As String
        Get
            Too = m_strToo
        End Get
        Set(ByVal value As String)
            m_strToo = value
        End Set
    End Property
    Public Property QtyCtn() As Decimal
        Get
            QtyCtn = m_dQtyCtn
        End Get
        Set(ByVal value As Decimal)
            m_dQtyCtn = value
        End Set
    End Property
    Public Property QtyPcs() As Decimal
        Get
            QtyPcs = m_dQtyPcs
        End Get
        Set(ByVal value As Decimal)
            m_dQtyPcs = value
        End Set
    End Property
    Public Property NetWt() As Decimal
        Get
            NetWt = m_dNetWt
        End Get
        Set(ByVal value As Decimal)
            m_dNetWt = value
        End Set
    End Property
    Public Property GrossWt() As Decimal
        Get
            GrossWt = m_dGrossWt
        End Get
        Set(ByVal value As Decimal)
            m_dGrossWt = value
        End Set
    End Property
    Public Property Notify() As String
        Get
            Notify = m_strNotify
        End Get
        Set(ByVal value As String)
            m_strNotify = value
        End Set
    End Property
    Public Property Lc() As String
        Get
            Lc = m_strLc
        End Get
        Set(ByVal value As String)
            m_strLc = value
        End Set
    End Property

    Public Property LcDate() As Date
        Get
            LcDate = m_dtLcDate
        End Get
        Set(ByVal value As Date)
            m_dtLcDate = value
        End Set
    End Property
    Public Property Container() As String
        Get
            Container = m_strContainer
        End Get
        Set(ByVal value As String)
            m_strContainer = value
        End Set
    End Property
    Public Property Vessel() As String
        Get
            Vessel = m_strVessel
        End Get
        Set(ByVal value As String)
            m_strVessel = value
        End Set
    End Property

    Public Property Freight() As String
        Get
            Freight = m_strFreight
        End Get
        Set(ByVal value As String)
            m_strFreight = value
        End Set
    End Property
    Public Property MarksNo() As String
        Get
            MarksNo = m_strMarksNo
        End Get
        Set(ByVal value As String)
            m_strMarksNo = value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception
        End Try
    End Function



   
End Class
