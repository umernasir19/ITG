Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class SampleStatusMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "SampleStatusMst"
        m_strPrimaryFieldName = "TempId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lTempId As Long
    Private m_lInquiryStyleID As Long
    Private m_lSamplingMasterID As Long
    Private m_lFabrictypeID As Long
    Private m_strColor As String
    Private m_dLapDipDeadline As String
    Private m_lLapDipDisDate As String
    Private m_strLapDipSampleRemarks As String
    Private m_lFitSampleDeadline As String
    Private m_dFitSampleSize As String
    Private m_lFitSampleDisDate As String
    Private m_strFitSampleStatus As String
    Private m_strFitSampleRemarks As String
    Private m_dPhotoSampleSize As String
    Private m_lPhotoSampleDeadline As String
    Private m_lPhotoSampleDisDate As String
    Private m_strPhotoSampleStatus As String
    Private m_strPhotoSampleRemarks As String
    Private m_dSealerSampleSize As String
    Private m_lSealerSampleDeadline As String
    Private m_lSealerSampleDisDate As String
    Private m_strSealerSampleStatus As String
    Private m_strSealerSampleRemarks As String
    
    Private m_strSealerCommentDate As String
    Private m_strLapDipCommentDate As String
    Private m_strFitSampleCommentDate As String
    Private m_strPhotoSampleCommentDate As String
    Public Property TempId() As Long
        Get
            TempId = m_lTempId
        End Get
        Set(ByVal value As Long)
            m_lTempId = value
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
    Public Property SamplingMasterID() As Long
        Get
            SamplingMasterID = m_lSamplingMasterID
        End Get
        Set(ByVal value As Long)
            m_lSamplingMasterID = value
        End Set
    End Property
    Public Property FabrictypeID() As Long
        Get
            FabrictypeID = m_lFabrictypeID
        End Get
        Set(ByVal value As Long)
            m_lFabrictypeID = value
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
    Public Property LapDipDeadline() As String
        Get
            LapDipDeadline = m_dLapDipDeadline
        End Get
        Set(ByVal value As String)
            m_dLapDipDeadline = value
        End Set
    End Property
    Public Property LapDipDisDate() As String
        Get
            LapDipDisDate = m_lLapDipDisDate
        End Get
        Set(ByVal value As String)
            m_lLapDipDisDate = value
        End Set
    End Property
    Public Property LapDipSampleRemarks() As String
        Get
            LapDipSampleRemarks = m_strLapDipSampleRemarks
        End Get
        Set(ByVal value As String)
            m_strLapDipSampleRemarks = value
        End Set
    End Property
    Public Property FitSampleDeadline() As String
        Get
            FitSampleDeadline = m_lFitSampleDeadline
        End Get
        Set(ByVal value As String)
            m_lFitSampleDeadline = value
        End Set
    End Property
    Public Property FitSampleSize() As String
        Get
            FitSampleSize = m_dFitSampleSize
        End Get
        Set(ByVal value As String)
            m_dFitSampleSize = value
        End Set
    End Property
    Public Property FitSampleDisDate() As String
        Get
            FitSampleDisDate = m_lFitSampleDisDate
        End Get
        Set(ByVal value As String)
            m_lFitSampleDisDate = value
        End Set
    End Property
    Public Property FitSampleStatus() As String
        Get
            FitSampleStatus = m_strFitSampleStatus
        End Get
        Set(ByVal value As String)
            m_strFitSampleStatus = value
        End Set
    End Property
    Public Property FitSampleRemarks() As String
        Get
            FitSampleRemarks = m_strFitSampleRemarks
        End Get
        Set(ByVal value As String)
            m_strFitSampleRemarks = value
        End Set
    End Property
   
    
    
    Public Property PhotoSampleSize() As String
        Get
            PhotoSampleSize = m_dPhotoSampleSize
        End Get
        Set(ByVal value As String)
            m_dPhotoSampleSize = value
        End Set
    End Property
    Public Property PhotoSampleDeadline() As String
        Get
            PhotoSampleDeadline = m_lPhotoSampleDeadline
        End Get
        Set(ByVal value As String)
            m_lPhotoSampleDeadline = value
        End Set
    End Property
    Public Property PhotoSampleDisDate() As String
        Get
            PhotoSampleDisDate = m_lPhotoSampleDisDate
        End Get
        Set(ByVal value As String)
            m_lPhotoSampleDisDate = value
        End Set
    End Property
    Public Property PhotoSampleStatus() As String
        Get
            PhotoSampleStatus = m_strPhotoSampleStatus
        End Get
        Set(ByVal value As String)
            m_strPhotoSampleStatus = value
        End Set

    End Property
    Public Property PhotoSampleRemarks() As String
        Get
            PhotoSampleRemarks = m_strPhotoSampleRemarks
        End Get
        Set(ByVal value As String)
            m_strPhotoSampleRemarks = value
        End Set
    End Property
    Public Property SealerSampleSize() As String
        Get
            SealerSampleSize = m_dSealerSampleSize
        End Get
        Set(ByVal value As String)
            m_dSealerSampleSize = value
        End Set
    End Property
    Public Property SealerSampleDeadline() As String
        Get
            SealerSampleDeadline = m_lSealerSampleDeadline
        End Get
        Set(ByVal value As String)
            m_lSealerSampleDeadline = value
        End Set
    End Property
    Public Property SealerSampleDisDate() As String
        Get
            SealerSampleDisDate = m_lSealerSampleDisDate
        End Get
        Set(ByVal value As String)
            m_lSealerSampleDisDate = value
        End Set
    End Property
    Public Property SealerSampleStatus() As String
        Get
            SealerSampleStatus = m_strSealerSampleStatus
        End Get
        Set(ByVal value As String)
            m_strSealerSampleStatus = value
        End Set
    End Property
    Public Property SealerSampleRemarks() As String
        Get
            SealerSampleRemarks = m_strSealerSampleRemarks
        End Get
        Set(ByVal value As String)
            m_strSealerSampleRemarks = value
        End Set
    End Property

    Public Property SealerCommentDate() As String
        Get
            SealerCommentDate = m_strSealerCommentDate
        End Get
        Set(ByVal value As String)
            m_strSealerCommentDate = value
        End Set
    End Property
    Public Property LapDipCommentDate() As String
        Get
            LapDipCommentDate = m_strLapDipCommentDate
        End Get
        Set(ByVal value As String)
            m_strLapDipCommentDate = value
        End Set
    End Property

    Public Property FitSampleCommentDate() As String
        Get
            FitSampleCommentDate = m_strFitSampleCommentDate
        End Get
        Set(ByVal value As String)
            m_strFitSampleCommentDate = value
        End Set
    End Property
    Public Property PhotoSampleCommentDate() As String
        Get
            PhotoSampleCommentDate = m_strPhotoSampleCommentDate
        End Get
        Set(ByVal value As String)
            m_strPhotoSampleCommentDate = value
        End Set
    End Property

    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception
        End Try
    End Function
    Public Function SaveSampleStatus()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function TruncateTable()
        Dim str As String = "TRUNCATE TABLE  SampleStatusMst"
        Try
            MyBase.ExecuteNonQuery(str)
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
    Public Function GetBuyingDeptenq(ByVal customerid As Long) As DataTable
        Dim str As String
        str = "SELECT distinct DepartmentNo as BuyingDept from   customerDetail where customerid=" & customerid
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

    Public Function GetBindCombo() As DataTable
        Dim str As String
        str = "select CustomerID,CustomerName from Customer where isactive='1' order by CustomerName ASC"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetStyle(ByVal CustomerID As Long, ByVal BuyingDept As String, ByVal Buyer As String, ByVal Brand As String, ByVal Season As String) As DataTable
        Dim str As String
        str = " select distinct sm.InquiryStyleID, sm.StyleNo , sd.Color,sd.FabrictypeID,sm.SamplingMasterID from SamplingMaster sm"
        str &= " join SamplingDetail sd on sd.SamplingMasterID =sm.SamplingMasterID "
        str &= " join Season ss on ss.SeasonID =sm.SeasonID "
        str &= " where sm.CustomerID ='" & CustomerID & "' and sm.BuyingDept ='" & BuyingDept & "' and sm.Buyer ='" & Buyer & "' and sm.Brand ='" & Brand & "' and ss.Season ='" & Season & "'   and sm.SamplePageType ='4' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDetail(ByVal InquiryStyleID As Long, ByVal FabrictypeID As Long, ByVal Color As String, ByVal SampleType As String) As DataTable
        Dim str As String
        str = " select distinct sm.InquiryStyleID, sm.StyleNo , sd.Color,sd.FabrictypeID,sd.SampleRemarks,* from SamplingMaster sm"
        str &= " join SamplingDetail sd on sd.SamplingMasterID =sm.SamplingMasterID "
        str &= " where sm.InquiryStyleID ='" & InquiryStyleID & "' and sd.FabrictypeID='" & FabrictypeID & "' and sd.Color='" & Color & "' and  sd.SampleType ='" & SampleType & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetPhotoSample(ByVal InquiryStyleID As Long, ByVal FabrictypeID As Long, ByVal Color As String) As DataTable
        Dim str As String
        str = " select distinct sm.InquiryStyleID, sm.StyleNo , sd.Color,sd.FabrictypeID from SamplingMaster sm"
        str &= " join SamplingDetail sd on sd.SamplingMasterID =sm.SamplingMasterID "
        str &= " where sm.InquiryStyleID ='" & InquiryStyleID & "' and sd.FabrictypeID='" & FabrictypeID & "' and sd.Color='" & Color & "' and  sd.SampleType ='Photo Sample' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetFitSample(ByVal InquiryStyleID As Long, ByVal FabrictypeID As Long, ByVal Color As String) As DataTable
        Dim str As String
        str = " select distinct sm.InquiryStyleID, sm.StyleNo , sd.Color,sd.FabrictypeID from SamplingMaster sm"
        str &= " join SamplingDetail sd on sd.SamplingMasterID =sm.SamplingMasterID "
        str &= " where sm.InquiryStyleID ='" & InquiryStyleID & "' and sd.FabrictypeID='" & FabrictypeID & "' and sd.Color='" & Color & "' and  sd.SampleType ='Fit Sample' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSealerSample(ByVal InquiryStyleID As Long, ByVal FabrictypeID As Long, ByVal Color As String) As DataTable
        Dim str As String
        str = " select distinct sm.InquiryStyleID, sm.StyleNo , sd.Color,sd.FabrictypeID from SamplingMaster sm"
        str &= " join SamplingDetail sd on sd.SamplingMasterID =sm.SamplingMasterID "
        str &= " where sm.InquiryStyleID ='" & InquiryStyleID & "' and sd.FabrictypeID='" & FabrictypeID & "' and sd.Color='" & Color & "' and   sd.SampleType ='Sealer Sample' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
