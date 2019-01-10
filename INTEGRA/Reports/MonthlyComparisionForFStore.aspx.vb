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
Public Class MonthlyComparisionForFStore
    Inherits System.Web.UI.Page
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim imsCateg As New IMSItemCategory
    Dim sup As New SupplierDataBase
    Dim objPOMaster As New POMaster
    Dim objStyM As New StyleMaster
    Dim CheckDate As String
    Dim UserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            '  BindJobOrder()
            BindItemCategory()
            ' BindSupplier()
        End If
    End Sub
    Sub BindItemCategory()
        Try
            Dim dtJobNo As DataTable
            dtJobNo = imsCateg.GetIMSItemCategoryFabric()
            cmbItemCategory.DataSource = dtJobNo
            cmbItemCategory.DataTextField = "ItemCategoryName"
            cmbItemCategory.DataValueField = "IMSItemCategoryID"
            cmbItemCategory.DataBind()
            cmbItemCategory.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnGetReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetReport.Click
        Try
            If cmbYear.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Year")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                'Dim ItemID As String = cmbItemName.SelectedValue

                Dim year As String = cmbYear.SelectedValue

                Dim ItemID As String = "0"
                If TXTCodeEntry.Text <> "" Then
                    ItemID = objStyM.GetItemIDByItemCode(TXTCodeEntry.Text)
                End If

                Report.Load(Server.MapPath("..\Reports/MonthlyComparision.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "MonthlyComparisionReport"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                Report.SetParameterValue("@ItemID", ItemID)
                Report.SetParameterValue("@itemCategoryID", cmbItemCategory.SelectedValue)
                Report.SetParameterValue("@year", cmbYear.SelectedValue)
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
                End If
        Catch ex As Exception

        End Try
    End Sub
End Class