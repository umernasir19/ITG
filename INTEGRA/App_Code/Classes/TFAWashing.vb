Imports Microsoft.VisualBasic
Imports System.Data

Public Class TFAWashing
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "TFAWashing"
        m_strPrimaryFieldName = "TFAWashingid"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lTFAWashingid As Long
    Private m_lStyleAssortmentBarCodeDetailID As Long
    Private m_lJoborderid As Long
    Private m_lJoborderDetailid As Long
    Private m_lStyleAssortmentMasterID As Long
    Private m_lSizeRangeID As Long
    Private m_lSizeDatabaseID As Long
    Private m_strCode As String
    Private m_strMerchandiser As String
    Private m_strJobNo As String
    Private m_dTotalOrderQty As Decimal

    Private m_strStyle As String
    Private m_strItem As String
    Private m_strBrand As String

    Private m_strSizes As String
    Private m_dTotalSizeQty As Decimal
    Private m_dWashingBit As Decimal
    Private m_dtCreationDate As Date
    Private m_lUserid As Long
    Public Property Userid() As Long
        Get
            Userid = m_lUserid
        End Get
        Set(ByVal Value As Long)
            m_lUserid = Value
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
    Public Property TFAWashingid() As Long
        Get
            TFAWashingid = m_lTFAWashingid
        End Get
        Set(ByVal Value As Long)
            m_lTFAWashingid = Value
        End Set
    End Property
    Public Property StyleAssortmentBarCodeDetailID() As Long
        Get
            StyleAssortmentBarCodeDetailID = m_lStyleAssortmentBarCodeDetailID
        End Get
        Set(ByVal Value As Long)
            m_lStyleAssortmentBarCodeDetailID = Value
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
    Public Property JoborderDetailid() As Long
        Get
            JoborderDetailid = m_lJoborderDetailid
        End Get
        Set(ByVal Value As Long)
            m_lJoborderDetailid = Value
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
    Public Property SizeRangeID() As Long
        Get
            SizeRangeID = m_lSizeRangeID
        End Get
        Set(ByVal Value As Long)
            m_lSizeRangeID = Value
        End Set
    End Property
    Public Property SizeDatabaseID() As Long
        Get
            SizeDatabaseID = m_lSizeDatabaseID
        End Get
        Set(ByVal Value As Long)
            m_lSizeDatabaseID = Value
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
    Public Property Merchandiser() As String
        Get
            Merchandiser = m_strMerchandiser
        End Get
        Set(ByVal value As String)
            m_strMerchandiser = value
        End Set
    End Property
    Public Property JobNo() As String
        Get
            JobNo = m_strJobNo
        End Get
        Set(ByVal value As String)
            m_strJobNo = value
        End Set
    End Property


    Public Property TotalOrderQty() As Decimal
        Get
            TotalOrderQty = m_dTotalOrderQty
        End Get
        Set(ByVal value As Decimal)
            m_dTotalOrderQty = value
        End Set
    End Property




    Public Property Style() As String
        Get
            Style = m_strStyle
        End Get
        Set(ByVal value As String)
            m_strStyle = value
        End Set
    End Property
    Public Property Item() As String
        Get
            Item = m_strItem
        End Get
        Set(ByVal value As String)
            m_strItem = value
        End Set
    End Property
    Public Property Brand() As String
        Get
            Brand = m_strBrand
        End Get
        Set(ByVal value As String)
            m_strBrand = value
        End Set
    End Property


    Public Property Sizes() As String
        Get
            Sizes = m_strSizes
        End Get
        Set(ByVal value As String)
            m_strSizes = value
        End Set
    End Property

    Public Property TotalSizeQty() As Decimal
        Get
            TotalSizeQty = m_dTotalSizeQty
        End Get
        Set(ByVal value As Decimal)
            m_dTotalSizeQty = value
        End Set
    End Property
    Public Property WashingBit() As Decimal
        Get
            WashingBit = m_dWashingBit
        End Get
        Set(ByVal value As Decimal)
            m_dWashingBit = value
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
    Public Function GetTotalScanedbyJOBstyleSizeTFAWashing(ByVal JobNo As String, ByVal Style As String, ByVal Sizes As String) As DataTable
        Dim str As String

        str = " select * from TFAWashing "
        str &= " where JobNo='" & JobNo & "' and Style='" & Style & "' and Sizes='" & Sizes & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTotalScanedbyJOBstyleSizeTFAWashingRecv(ByVal JobNo As String, ByVal Style As String, ByVal Sizes As String) As DataTable
        Dim str As String

        str = " select * from TFAWashingRecv "
        str &= " where JobNo='" & JobNo & "' and Style='" & Style & "' and Sizes='" & Sizes & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
