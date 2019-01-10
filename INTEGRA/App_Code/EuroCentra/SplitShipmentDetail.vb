Imports System.Data
Imports Microsoft.VisualBasic

Public Class SplitShipmentDetail
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "SplitShipmentDetail"
        m_strPrimaryFieldName = "SplitID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lSplitID As Long
    Private m_lPODetailID As Long
    Private m_lPOID As Long
    Private m_dQuantity As Decimal
    Private m_dRate As Decimal
    Private m_lStyleId As Long
    Private m_lStyleDetailID As Long
    Private m_dtSplitShipmentDate As Date
    Private m_strSplitMode As String
    Private m_strReason As String
    Private m_dtCreationdate As Date
    Private m_dSplitNo As Decimal
    Public Property SplitID() As Long
        Get
            SplitID = m_lSplitID
        End Get
        Set(ByVal value As Long)
            m_lSplitID = value
        End Set
    End Property
    Public Property StyleDetailID() As Long
        Get
            StyleDetailID = m_lStyleDetailID
        End Get
        Set(ByVal Value As Long)
            m_lStyleDetailID = Value
        End Set
    End Property
    Public Property PODetailID() As Long
        Get
            PODetailID = m_lPODetailID
        End Get
        Set(ByVal Value As Long)
            m_lPODetailID = Value
        End Set
    End Property
    Public Property POID() As Long
        Get
            POID = m_lPOID
        End Get
        Set(ByVal value As Long)
            m_lPOID = value
        End Set
    End Property
    Public Property Quantity() As Decimal
        Get
            Quantity = m_dQuantity
        End Get
        Set(ByVal value As Decimal)
            m_dQuantity = value
        End Set
    End Property
    Public Property Rate() As Decimal
        Get
            Rate = m_dRate
        End Get
        Set(ByVal value As Decimal)
            m_dRate = value
        End Set
    End Property
    Public Property StyleID() As Long
        Get
            StyleID = m_lStyleId
        End Get
        Set(ByVal value As Long)
            m_lStyleId = value
        End Set
    End Property
    Public Property SplitShipmentDate() As Date
        Get
            SplitShipmentDate = m_dtSplitShipmentDate
        End Get
        Set(ByVal value As Date)
            m_dtSplitShipmentDate = value
        End Set
    End Property
    Public Property SplitMode() As String
        Get
            SplitMode = m_strSplitMode
        End Get
        Set(ByVal value As String)
            m_strSplitMode = value
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
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal value As Date)
            m_dtCreationDate = value
        End Set
    End Property
    Public Property SplitNo() As Decimal
        Get
            SplitNo = m_dSplitNo
        End Get
        Set(ByVal value As Decimal)
            m_dSplitNo = value
        End Set
    End Property
    Public Function SaveSplitShipmentDetail()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSplitID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception
        End Try
    End Function
    Public Function CheckSplitNo(ByVal IPODetailID As Long) As DataTable
        Dim str As String
        str = "  Select Top 1 * from SplitShipmentDetail  where PODetailID ='" & IPODetailID & "' order by SplitID DESC "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function


End Class
