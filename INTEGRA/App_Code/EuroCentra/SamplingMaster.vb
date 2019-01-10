Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class SamplingMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SamplingMaster"
            m_strPrimaryFieldName = "SamplingMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSamplingMasterID As Long
        Private m_lCustomerID As Long
        Private m_lInquiryStyleID As Long
        Private m_lSeasonID As Long
        Private m_lSupplierID As Long
        Private m_dCreationDate As Date
        Private m_strBuyingDept As String
        Private m_strBuyer As String
        Private m_strBrand As String
        Private m_strDesignName As String
        Private m_strStyleDescription As String
        Private m_strInquiryType As String
        Private m_strSamplePageType As String
        Private m_lUserID As Long
        Private m_strStyleNo As String
        Public Property SamplingMasterID() As Long
            Get
                SamplingMasterID = m_lSamplingMasterID
            End Get
            Set(ByVal value As Long)
                m_lSamplingMasterID = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal value As Long)
                m_lCustomerID = value
            End Set
        End Property
        Public Property InquiryStyleID() As Long
            Get
                InquiryStyleID = m_lInquiryStyleID
            End Get
            Set(ByVal value As Long)
                m_lInquiryStyleID = value
            End Set
        End Property
        Public Property SeasonID() As Long
            Get
                SeasonID = m_lSeasonID
            End Get
            Set(ByVal value As Long)
                m_lSeasonID = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal value As Long)
                m_lSupplierID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal value As Date)
                m_dCreationDate = value
            End Set
        End Property
        Public Property BuyingDept() As String
            Get
                BuyingDept = m_strBuyingDept
            End Get
            Set(ByVal value As String)
                m_strBuyingDept = value
            End Set
        End Property
        Public Property Buyer() As String
            Get
                Buyer = m_strBuyer
            End Get
            Set(ByVal value As String)
                m_strBuyer = value
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
        Public Property DesignName() As String
            Get
                DesignName = m_strDesignName
            End Get
            Set(ByVal value As String)
                m_strDesignName = value
            End Set
        End Property
        Public Property StyleDescription() As String
            Get
                StyleDescription = m_strStyleDescription
            End Get
            Set(ByVal value As String)
                m_strStyleDescription = value
            End Set
        End Property
        Public Property InquiryType() As String
            Get
                InquiryType = m_strInquiryType
            End Get
            Set(ByVal value As String)
                m_strInquiryType = value
            End Set
        End Property
        Public Property SamplePageType() As String
            Get
                SamplePageType = m_strSamplePageType
            End Get
            Set(ByVal value As String)
                m_strSamplePageType = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal value As Long)
                m_lUserID = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Function SaveSampleMaster()
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
        Public Function GetBindCombo() As DataTable
            Dim str As String
            str = "select CustomerID,CustomerName from Customer where isactive='1' order by CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingDeptenq(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct DepartmentNo as BuyingDept from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerInfoNorepNew(ByVal customerid As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            If customerid > 0 Then
                str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid=' " & customerid & "' and DepartmentNo='" & BuyingDept & "'"
            Else
                str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where DepartmentNo='" & BuyingDept & "'"
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerEntryPage(ByVal customerid As Long, ByVal BuyingDept As String, ByVal Buyer As String) As DataTable
            Dim str As String
            str = "SELECT distinct cd.BrandName from   customerDetail cd  where cd.customerid=' " & customerid & "' and cd.DepartmentNo='" & BuyingDept & "' and Buyer_Name='" & Buyer & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeason() As DataTable
            Dim str As String
            str = " select   * from season  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getSupplier(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = "select DISTINCT V.VenderLibraryID,V.VenderName from TblInquiryConfirmed TC join "
            str &= " Vender V ON V.VenderLibraryID=TC.SupplierId"
            str &= " WHERE InquiryStyleID='" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getSupplierPage1() As DataTable
            Dim str As String
            str = "select  V.VenderLibraryID,V.VenderName from Vender V "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindInqStyle(ByVal customerid As Long, ByVal BuyingDept As String, ByVal BuyerName As String, ByVal BrandName As String, ByVal SeasonID As Long) As DataTable
            Dim str As String
            str = "select InquiryStyleID,StyleNo from InquiryStyle "
            str &= " where CustomerId='" & customerid & "' and BuyingDept='" & BuyingDept & "' "
            str &= " and BrandName='" & BrandName & "' and BuyerName='" & BuyerName & "' and Seasonid='" & SeasonID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyledata(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = "select * from InquiryStyle where InquiryStyleID='" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricType(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = " select distinct ft.FabricTypeid,ft.FabricType from TblInquiryConfirmed tb "
            str &= " join InquiryStyleProductInformation Sy on Sy.InquiryStyleID=tb.InquiryStyleID and sy.InquirySproductID=tb.InquirySproductID"
            str &= " join  FabricType ft on ft.FabricTypeid=Sy.FabricTypeid"
            str &= " where tb.InquiryStyleID='" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForView(ByVal SamplePageType As String) As DataTable
            Dim str As String
            'str = " select * from SamplingMaster sm "
            'str &= " Join Customer C on C.CustomerID=sm.Customerid join season sa on sa.seasonid=sm.seasonid "
            'str &= " left join InquiryStyle IQS ON IQS.InquiryStyleID=sm.InquiryStyleID"
            'str &= " where SamplePageType='" & SamplePageType & "'"

            str = " select * from SamplingMaster sm "
            str &= " Join Customer C on C.CustomerID=sm.Customerid join season sa on sa.seasonid=sm.seasonid "

            str &= " where SamplePageType='" & SamplePageType & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMaster(ByVal SamplingMasterID As Long) As DataTable
            Dim str As String
            str = "  Select * from SamplingMaster  where SamplingMasterID=" & SamplingMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDetail(ByVal SamplingMasterID As Long) As DataTable
            Dim str As String
            str = "  Select * from SamplingDetail sd join FabricType ft on ft.FabricTypeId=sd.FabricTypeId where SamplingMasterID=" & SamplingMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDetailPage1(ByVal SamplingMasterID As Long) As DataTable
            Dim str As String
            str = "  Select * from SamplingDetail sd where SamplingMasterID=" & SamplingMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
