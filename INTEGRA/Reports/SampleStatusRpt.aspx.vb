Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class SampleStatusRpt
    Inherits System.Web.UI.Page
    Dim ObjSamplingStatus As New SampleStatusMst
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindSeason()
            BindCustomer()


        End If
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = ObjSamplingStatus.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = ObjSamplingStatus.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = ObjSamplingStatus.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
         

            ''---Bind Byuer Name
            cmbBuyerName.DataSource = ObjSamplingStatus.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingStatus.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = ObjSamplingStatus.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
            ''---Bind Byuer Name
            cmbBuyerName.DataSource = ObjSamplingStatus.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingStatus.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try

    End Sub
    Sub BindStyle()
        Try
            Dim dtStyle As DataTable = ObjSamplingStatus.BindInqStyle(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text, cmbBrand.SelectedItem.Text, cmbSeason.SelectedValue)
            With cmbStyle
                .DataSource = dtStyle
                .DataTextField = "StyleNo"
                .DataValueField = "InquiryStyleID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        cmbBuyerName.DataSource = ObjSamplingStatus.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
        cmbBuyerName.DataTextField = "BuyerName"
        cmbBuyerName.DataValueField = "BuyerName"
        cmbBuyerName.DataBind()
        UpdatecmbBuyerName.Update()

        ''---Bind Brand 
        cmbBrand.DataSource = ObjSamplingStatus.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
        cmbBrand.DataTextField = "BrandName"
        cmbBrand.DataValueField = "BrandName"
        cmbBrand.DataBind()
        ' CmbBrand.Items.Insert(0, New ListItem("All", "0"))
        UpcmbBrand.Update()
        BindStyle()
        UpStyleNo.Update()
    End Sub
    Protected Sub cmbBuyerName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyerName.SelectedIndexChanged
        Try
            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingStatus.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub
    Sub GetDataForReport()
        Dim OBJDATE As New GeneralCode
        ObjSamplingStatus.TruncateTable()

        Dim CUSTOMERID As Long = cmbCustomer.SelectedValue
        Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text

        Dim Brand As String = cmbBrand.SelectedItem.Text
        Dim season As String = cmbSeason.SelectedItem.Text
        Dim Buyer As String = cmbBuyerName.SelectedItem.Text

        Dim InquiryStyleID As Long = cmbStyle.SelectedValue

        Dim dtStyle As DataTable

        dtStyle = ObjSamplingStatus.GetStyle(CUSTOMERID, BuyingDept, Buyer, Brand, season)


        Dim i As Integer
        Dim SamplingMasterID As Long
        Dim FabTypeid As Long
        Dim Color As String
        Dim SampleType As String
        Dim dtlapDip As DataTable
        Dim dtPhotoSp As DataTable
        Dim dtFitSp As DataTable
        Dim dtSealerSp As DataTable



        Dim dtFinal = New DataTable
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("InquiryStyleID", GetType(Long))
            .Columns.Add("SamplingMasterID", GetType(Long))
            .Columns.Add("FabrictypeID", GetType(Long))
            .Columns.Add("Color", GetType(String))
            .Columns.Add("LapDipDeadline", GetType(String))
            .Columns.Add("LapDipDisDate", GetType(String))
            .Columns.Add("LapDipSampleRemarks", GetType(String))
            .Columns.Add("FitSampleDeadline", GetType(String))
            .Columns.Add("FitSampleSize", GetType(String))
            .Columns.Add("FitSampleDisDate", GetType(String))
            .Columns.Add("FitSampleStatus", GetType(String))
            .Columns.Add("FitSampleRemarks", GetType(String))
            .Columns.Add("PhotoSampleSize", GetType(String))
            .Columns.Add("PhotoSampleDeadline", GetType(String))
            .Columns.Add("PhotoSampleDisDate", GetType(String))
            .Columns.Add("PhotoSampleStatus", GetType(String))
            .Columns.Add("PhotoSampleRemarks", GetType(String))
            .Columns.Add("SealerSampleSize", GetType(String))
            .Columns.Add("SealerSampleDeadline", GetType(String))
            .Columns.Add("SealerSampleDisDate", GetType(String))
            .Columns.Add("SealerSampleStatus", GetType(String))
            .Columns.Add("SealerSampleRemarks", GetType(String))
            .Columns.Add("SealerCommentDate", GetType(String))
            .Columns.Add("LapDipCommentDate", GetType(String))
            .Columns.Add("FitSampleCommentDate", GetType(String))
            .Columns.Add("PhotoSampleCommentDate", GetType(String))

        End With

        For i = 0 To dtStyle.Rows.Count - 1
            InquiryStyleID = dtStyle.Rows(i)("InquiryStyleID")
            FabTypeid = dtStyle.Rows(i)("FabrictypeID")
            Color = dtStyle.Rows(i)("Color")
            SamplingMasterID = dtStyle.Rows(i)("SamplingMasterID")
            dtlapDip = ObjSamplingStatus.GetDetail(InquiryStyleID, FabTypeid, Color, "Lab Dips Sample")
            dtPhotoSp = ObjSamplingStatus.GetDetail(InquiryStyleID, FabTypeid, Color, "Photo Sample")
            dtFitSp = ObjSamplingStatus.GetDetail(InquiryStyleID, FabTypeid, Color, "Fit Sample")
            dtSealerSp = ObjSamplingStatus.GetDetail(InquiryStyleID, FabTypeid, Color, "Sealer Sample")

            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("InquiryStyleID") = InquiryStyleID
            Dr("FabrictypeID") = FabTypeid
            Dr("Color") = Color
            Dr("SamplingMasterID") = SamplingMasterID
            If dtlapDip.Rows.Count > 0 Then
                Dr("LapDipDeadline") = dtlapDip.Rows(0)("Deadline")
                Dr("LapDipDisDate") = dtlapDip.Rows(0)("DispatchedDate")
                Dr("LapDipSampleRemarks") = dtlapDip.Rows(0)("SampleRemarks")
                Dr("LapDipCommentDate") = dtlapDip.Rows(0)("CommentsReceivedDate")
            Else
                Dr("LapDipDeadline") = ""
                Dr("LapDipDisDate") = ""
                Dr("LapDipSampleRemarks") = ""
                Dr("LapDipCommentDate") = ""
            End If

            If dtFitSp.Rows.Count > 0 Then
                Dr("FitSampleDeadline") = dtFitSp.Rows(0)("Deadline")
                Dr("FitSampleSize") = dtFitSp.Rows(0)("Size")
                Dr("FitSampleDisDate") = dtFitSp.Rows(0)("DispatchedDate")
                Dr("FitSampleStatus") = dtFitSp.Rows(0)("Status")
                Dr("FitSampleRemarks") = dtFitSp.Rows(0)("SampleRemarks")
                Dr("FitSampleCommentDate") = dtFitSp.Rows(0)("CommentsReceivedDate")
            Else
                Dr("FitSampleDeadline") = ""
                Dr("FitSampleSize") = 0
                Dr("FitSampleDisDate") = ""
                Dr("FitSampleStatus") = ""
                Dr("FitSampleRemarks") = ""
                Dr("FitSampleCommentDate") = ""
            End If
            If dtPhotoSp.Rows.Count > 0 Then
                Dr("PhotoSampleSize") = dtPhotoSp.Rows(0)("Size")
                Dr("PhotoSampleDeadline") = dtPhotoSp.Rows(0)("Deadline")
                Dr("PhotoSampleDisDate") = dtPhotoSp.Rows(0)("DispatchedDate")
                Dr("PhotoSampleStatus") = dtPhotoSp.Rows(0)("Status")
                Dr("PhotoSampleRemarks") = dtPhotoSp.Rows(0)("SampleRemarks")
                Dr("PhotoSampleCommentDate") = dtPhotoSp.Rows(0)("CommentsReceivedDate")
            Else
                Dr("PhotoSampleSize") = 0
                Dr("PhotoSampleDeadline") = ""
                Dr("PhotoSampleDisDate") = ""
                Dr("PhotoSampleStatus") = ""
                Dr("PhotoSampleRemarks") = ""
                Dr("PhotoSampleCommentDate") = ""
            End If
            If dtSealerSp.Rows.Count > 0 Then

                Dr("SealerSampleDeadline") = dtSealerSp.Rows(0)("Deadline")
                Dr("SealerSampleDisDate") = dtSealerSp.Rows(0)("DispatchedDate")
                Dr("SealerSampleStatus") = dtSealerSp.Rows(0)("Status")
                Dr("SealerSampleRemarks") = dtSealerSp.Rows(0)("SampleRemarks")
                Dr("SealerSampleSize") = dtSealerSp.Rows(0)("Size")
                Dr("SealerCommentDate") = dtSealerSp.Rows(0)("CommentsReceivedDate")
            Else
                Dr("SealerSampleDeadline") = ""
                Dr("SealerSampleDisDate") = ""
                Dr("SealerSampleStatus") = ""
                Dr("SealerSampleRemarks") = ""
                Dr("SealerSampleSize") = ""
                Dr("SealerCommentDate") = ""
            End If
            dtFinal.Rows.Add(Dr)
        Next
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With ObjSamplingStatus
                .TempId = 0
                .InquiryStyleID = dtFinal.Rows(A)("InquiryStyleID")
                .SamplingMasterID = dtFinal.Rows(A)("SamplingMasterID")
                .FabrictypeID = dtFinal.Rows(A)("FabrictypeID")
                .Color = dtFinal.Rows(A)("Color")
                .LapDipDeadline = dtFinal.Rows(A)("LapDipDeadline")
                .LapDipDisDate = dtFinal.Rows(A)("LapDipDisDate")
                .LapDipSampleRemarks = dtFinal.Rows(A)("LapDipSampleRemarks")

                .FitSampleDeadline = dtFinal.Rows(A)("FitSampleDeadline")
                .FitSampleSize = dtFinal.Rows(A)("FitSampleSize")
                .FitSampleDisDate = dtFinal.Rows(A)("FitSampleDisDate")
                .FitSampleStatus = dtFinal.Rows(A)("FitSampleStatus")

                .FitSampleRemarks = dtFinal.Rows(A)("FitSampleRemarks")
                .PhotoSampleSize = dtFinal.Rows(A)("PhotoSampleSize")
                .PhotoSampleDeadline = dtFinal.Rows(A)("PhotoSampleDeadline")
                .PhotoSampleDisDate = dtFinal.Rows(A)("PhotoSampleDisDate")
                .PhotoSampleStatus = dtFinal.Rows(A)("PhotoSampleStatus")
                .PhotoSampleRemarks = dtFinal.Rows(A)("PhotoSampleRemarks")
                .SealerSampleSize = dtFinal.Rows(A)("SealerSampleSize")
                .SealerSampleDeadline = dtFinal.Rows(A)("SealerSampleDeadline")
                .SealerSampleDisDate = dtFinal.Rows(A)("SealerSampleDisDate")
                .SealerSampleStatus = dtFinal.Rows(A)("SealerSampleStatus")
                .SealerSampleRemarks = dtFinal.Rows(A)("SealerSampleRemarks")
                .SealerCommentDate = dtFinal.Rows(A)("SealerCommentDate")
                .LapDipCommentDate = dtFinal.Rows(A)("LapDipCommentDate")
                .FitSampleCommentDate = dtFinal.Rows(A)("FitSampleCommentDate")
                .PhotoSampleCommentDate = dtFinal.Rows(A)("PhotoSampleCommentDate")
                .SaveSampleStatus()

            End With
        Next

    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
    
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")

            GetDataForReport()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next

            Dim Report As New ReportDocument
            Dim Options As New ExportOptions

            'Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinal.rpt"))
            Report.Load(Server.MapPath("..\Reports/SampleStatus.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "SampleStatus"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            'Report.SetParameterValue(5, txtEndDate.Text)

            Dim FileOption As New DiskFileDestinationOptions
            FileOption.DiskFileName = sTempFileName
            Options = Report.ExportOptions
            Options.ExportDestinationType = ExportDestinationType.DiskFile
            Options.ExportFormatType = ExportFormatType.PortableDocFormat
            Options.DestinationOptions = FileOption
            Options.ExportDestinationOptions = FileOption
            Report.SetDatabaseLogon("sa", "pwd")
            Report.Export()

            If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                Dim strFileSize As String = ""
                Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                Dim fi As IO.FileInfo
                For Each fi In aryFi
                    Response.ClearHeaders()
                    Response.ClearContent()
                    Response.ContentType = "application/octet-stream"
                    Response.Charset = "UTF-8"
                    Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                    Response.End()
                Next
            End If
      
    End Sub

End Class