Imports Microsoft.VisualBasic
Imports System.Data
Public Class TFAStitching
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "TFAStitching"
        m_strPrimaryFieldName = "TFAStitchingid"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lTFAStitchingid As Long
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
    Private m_dStitchingBit As Decimal
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
    Public Property TFAStitchingid() As Long
        Get
            TFAStitchingid = m_lTFAStitchingid
        End Get
        Set(ByVal Value As Long)
            m_lTFAStitchingid = Value
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
    Public Property StitchingBit() As Decimal
        Get
            StitchingBit = m_dStitchingBit
        End Get
        Set(ByVal value As Decimal)
            m_dStitchingBit = value
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

    Public Function ChkDataStyle(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from StyleAssortmentBarCodeDetail where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetData(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from TFAStitching where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetWashingData(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from TFAWashing where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetWashingRecvData(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from TFAWashingRecv where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function CheckStitchingData(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from TFAStitching where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function CheckWashingData(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from TFAWashing where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetFinishingData(ByVal Code As String) As DataTable
        Dim str As String

        str = " Select * from TFAFinishing where Code='" & Code & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSitichingGrid() As DataTable
        Dim str As String

        str = " select   JO.SRNO,JO.JobOrderNo as JobNo, JO.JobOrderId,(isnull((select SUM(stitchingBit) from TFAStitching tc"
        str &= " where tc.JobOrderId=JO.JobOrderId),0)) as TotalstitchingBit"
        str &= " ,(isnull((select top 1 TotalOrderQty from TFAStitching JSS"
        str &= " where JSS.JobOrderId=JO.JobOrderId),0)) as TotalQuantity"
        str &= "  from joborderdatabase JO "
        str &= " where (isnull((select SUM(stitchingBit) from TFAStitching tc"
        str &= " where tc.JobOrderId=JO.JobOrderId),0))>0"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetWashingRecvGrid() As DataTable
        Dim str As String

        str = " select   JO.SRNO,JO.JobOrderNo as JobNo, JO.JobOrderId,(isnull((select SUM(WashingRecvBit) from TFAWashingRecv tc"
        str &= " where tc.JobOrderId=JO.JobOrderId),0)) as TotalWashingBit"
        str &= " ,(isnull((select top 1 TotalOrderQty from TFAWashingRecv JSS"
        str &= "  where JSS.JobOrderId=JO.JobOrderId),0)) as TotalQuantity"
        str &= "  from joborderdatabase JO "
        str &= "  where (isnull((select SUM(WashingRecvBit) from TFAWashingRecv tc"
        str &= " where tc.JobOrderId=JO.JobOrderId),0))>0"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetWashingGrid() As DataTable
        Dim str As String

        str = " select   JO.SRNO,JO.JobOrderNo as JobNo, JO.JobOrderId,(isnull((select SUM(WashingBit) from TFAWashing tc"
        str &= " where tc.JobOrderId=JO.JobOrderId),0)) as TotalWashingBit"
        str &= " ,(isnull((select top 1 TotalOrderQty from TFAWashing JSS"
        str &= "  where JSS.JobOrderId=JO.JobOrderId),0)) as TotalQuantity"
        str &= "  from joborderdatabase JO "
        str &= "  where (isnull((select SUM(WashingBit) from TFAWashing tc"
        str &= " where tc.JobOrderId=JO.JobOrderId),0))>0"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTotalSizeQty(ByVal Code As String) As DataTable
        Dim str As String

        str = " select Sum(Quantity) as TotalStyleQTy,JD.Style from StyleAssortmentBarCodeDetail D"
        str &= " Join JobOrderdatabaseDetail JD on JD.JobOrderDetailID=D.JobOrderDetailID"
        str &= " where Code='" & Code & "'"
        str &= " group by JD.Style"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTotalScanedbyJOBstyleSizeTFAStitching(ByVal JobNo As String, ByVal Style As String, ByVal Sizes As String) As DataTable
        Dim str As String

        str = " select * from TFAStitching "
        str &= " where JobNo='" & JobNo & "' and Style='" & Style & "' and Sizes='" & Sizes & "'"

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function


End Class
