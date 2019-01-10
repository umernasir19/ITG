﻿Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail

Public Class DailyCuttingReport
    Inherits System.Web.UI.Page
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objSizeRange As New SizeRange
    Dim objtemdailyCutting As New tempdailyCutting

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                BindSeason()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjCommercialPackingListDtl.GetSeasonsFromJobOrderDatabase()
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, "Select")

            cmbColor.DataSource = Nothing
            cmbColor.Items.Clear()
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, "ALL")

            cmbColor.DataSource = Nothing
            cmbColor.Items.Clear()
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, "ALL")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable

            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
            cmbSrNoo.DataSource = dtInvoiceNo
            cmbSrNoo.DataTextField = "SrNO"
            cmbSrNoo.DataValueField = "JobOrderID"
            cmbSrNoo.DataBind()
            cmbSrNoo.Items.Insert(0, New RadComboBoxItem("All", 0))
        Catch ex As Exception

        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNoo.SelectedValue)
            cmbColor.DataSource = dtInvoiceNo
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "JobOrderDetailID"
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, "ALL")
        Catch ex As Exception
            cmbColor.DataSource = Nothing
            cmbColor.Items.Clear()
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, "ALL")
        End Try
    End Sub

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindSrNo()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try


            objSizeRange.temDailyCuttingTbaleTruncate()
            If cmbSeason.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Season")
        
            ElseIf cmbSeason.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Season")
            Else

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions

                Report.Load(Server.MapPath("..\Reports/DailyCuttingReport.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Daily_Cutting_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"


                If cmbSrNoo.CheckedItems(0).Value = 0 Then
                    Report.SetParameterValue("@SeasonID", cmbSeason.SelectedValue)
                    Report.SetParameterValue("@JobOrderId", 0)
                    Report.SetParameterValue("@FromDate", txtFromDate.SelectedDate)
                    Report.SetParameterValue("@ToDate", txtToDate.SelectedDate)
              
                Else

                    Dim xx As Integer
                    For xx = 0 To cmbSrNoo.CheckedItems.Count - 1
                        With objtemdailyCutting
                            .ID = 0
                            .No = cmbSrNoo.CheckedItems(xx).Text
                            .Save()
                        End With
                    Next
                    Report.SetParameterValue("@SeasonID", cmbSeason.SelectedValue)
                    Report.SetParameterValue("@JobOrderId", 1)
                    Report.SetParameterValue("@FromDate", txtFromDate.SelectedDate)
                    Report.SetParameterValue("@ToDate", txtToDate.SelectedDate)
                End If


            

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