Imports Microsoft.VisualBasic
Imports System.Data
Public Class NumberingDtl

    Inherits SQLManager
    Public Sub New()
        m_strTableName = "NumberingDtl"
        m_strPrimaryFieldName = "NumberingDtlID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lNumberingDtlID As Long
    Private m_lNumberingID As Long
    Private m_dCartonNo As Decimal
    Private m_lSizeRangeId As Long
    Private m_lSizeDatabaseId As Long
    Private m_lStyleAssortmentDetailID As Long
    Private m_lStyleAssortmentMasterID As Long
    Private m_lCuttingProDetailID As Long
    Private m_lCuttingProMasterID As Long
    Private m_lJoborderid As Long
    Private m_lJoborderDetailid As Long
    Private m_strCode As String
    Private m_strPcsPerCarton As String
    Private m_lSerialNo As Long
    Private m_strSelectNumbering As String
    Private m_dWeight As Decimal
    Public Property Weight() As Decimal
        Get
            Weight = m_dWeight
        End Get
        Set(ByVal value As Decimal)
            m_dWeight = value
        End Set
    End Property
    Public Property SelectNumbering() As String
        Get
            SelectNumbering = m_strSelectNumbering
        End Get
        Set(ByVal value As String)
            m_strSelectNumbering = value
        End Set
    End Property
    Public Property NumberingDtlID() As Long
        Get
            NumberingDtlID = m_lNumberingDtlID
        End Get
        Set(ByVal Value As Long)
            m_lNumberingDtlID = Value
        End Set
    End Property
    Public Property SerialNo() As Long
        Get
            SerialNo = m_lSerialNo
        End Get
        Set(ByVal Value As Long)
            m_lSerialNo = Value
        End Set
    End Property
    Public Property PcsPerCarton() As String
        Get
            PcsPerCarton = m_strPcsPerCarton
        End Get
        Set(ByVal value As String)
            m_strPcsPerCarton = value
        End Set
    End Property
    Public Property Code() As String
        Get
            Code = m_strCode
        End Get
        Set(ByVal value As String)
            m_strCode = value
        End Set
    End Property

    Public Property CartonNo() As Decimal
        Get
            CartonNo = m_dCartonNo
        End Get
        Set(ByVal value As Decimal)
            m_dCartonNo = value
        End Set
    End Property

    Public Property NumberingID() As Long
        Get
            NumberingID = m_lNumberingID
        End Get
        Set(ByVal Value As Long)
            m_lNumberingID = Value
        End Set
    End Property
    Public Property JoborderDetailid() As Long
        Get
            JoborderDetailid = m_lJoborderDetailid
        End Get
        Set(ByVal Value As Long)
            m_lJoborderDetailid = Value
        End Set
    End Property
    Public Property Joborderid() As Long
        Get
            Joborderid = m_lJoborderid
        End Get
        Set(ByVal Value As Long)
            m_lJoborderid = Value
        End Set
    End Property
    Public Property CuttingProMasterID() As Long
        Get
            CuttingProMasterID = m_lCuttingProMasterID
        End Get
        Set(ByVal Value As Long)
            m_lCuttingProMasterID = Value
        End Set
    End Property
    Public Property CuttingProDetailID() As Long
        Get
            CuttingProDetailID = m_lCuttingProDetailID
        End Get
        Set(ByVal Value As Long)
            m_lCuttingProDetailID = Value
        End Set
    End Property
    Public Property StyleAssortmentMasterID() As Long
        Get
            StyleAssortmentMasterID = m_lStyleAssortmentMasterID
        End Get
        Set(ByVal Value As Long)
            m_lStyleAssortmentMasterID = Value
        End Set
    End Property
    Public Property StyleAssortmentDetailID() As Long
        Get
            StyleAssortmentDetailID = m_lStyleAssortmentDetailID
        End Get
        Set(ByVal Value As Long)
            m_lStyleAssortmentDetailID = Value
        End Set
    End Property
    Public Property SizeRangeId() As Long
        Get
            SizeRangeId = m_lSizeRangeId
        End Get
        Set(ByVal Value As Long)
            m_lSizeRangeId = Value
        End Set
    End Property
    Public Property SizeDatabaseId() As Long
        Get
            SizeDatabaseId = m_lSizeDatabaseId
        End Get
        Set(ByVal Value As Long)
            m_lSizeDatabaseId = Value
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
End Class


