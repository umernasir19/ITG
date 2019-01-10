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

Public Class MonthlyProductionReport
    Inherits System.Web.UI.Page
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objSizeRange As New SizeRange
    Dim objProduction As New clsWeeklyProductionReport
    Dim dtLineNumber, dtDateAndQty As DataTable
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
            'dtInvoiceNo = objSizeRange.GetSrnOForCutting(cmbSeason.SelectedValue)
            dtInvoiceNo = objSizeRange.GetSrnOForCuttingNew(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtInvoiceNo
            cmbSrNo.DataTextField = "SrNO"
            cmbSrNo.DataValueField = "JobOrderID"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, "ALL")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
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

    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSrNo.SelectedIndexChanged
        Try
            BindColor()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try

            If cmbYear.SelectedIndex = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Year")
            Else
                objProduction.UpdateRecord("truncate table TempProduction")  ' it will truncate the table 
                'Dim LineNames() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}
                Dim i As Long = 0
                dtLineNumber = objProduction.GetLineNumber(cmbYear.SelectedValue)
                For i = 0 To dtLineNumber.Rows.Count - 1
                    dtLineNumber = objProduction.GetLineNumber(cmbYear.SelectedValue)
                    Dim LineNo As String = dtLineNumber.Rows(i)(0)
                    If LineNo <> "" Then
                        dtDateAndQty = objProduction.GetDateAndQty(LineNo, cmbYear.SelectedValue)
                        Dim j As Long = 0
                        For j = 0 To dtDateAndQty.Rows.Count - 1

                            Dim currentID As Long = 0
                            Dim qty As Long = 0
                            Dim TempDateVar As Date

                            qty = Integer.Parse(dtDateAndQty.Rows(j)("TotalQty"))
                            TempDateVar = Date.Parse(dtDateAndQty.Rows(j)("TempDate"))

                            Dim dtCheckDate As DataTable = objProduction.CheckDate(dtDateAndQty.Rows(j)("TempDate"))
                            If dtCheckDate.Rows.Count > 0 Then
                                'dtDateAndQty = dtCheckDate
                                currentID = Integer.Parse(dtCheckDate.Rows(0)("TempProductionID"))
                                If LineNo = "DAL-3" Then
                                    objProduction.UpdateRecord("Update TempProduction set DAL3 = '" & qty & "' WHERE TempProductionID = '" & currentID & "'")
                                Else
                                    objProduction.UpdateRecord("Update TempProduction set Line" & LineNo & " = '" & qty & "' WHERE TempProductionID = '" & currentID & "'")
                                End If
                            Else
                                With objProduction
                                    .TempProductionID = 0
                                    .TempDate = System.DateTime.Now
                                    .LineA = 0
                                    .LineB = 0
                                    .LineC = 0
                                    .LineD = 0
                                    .LineE = 0
                                    .LineF = 0
                                    .LineG = 0
                                    .LineH = 0
                                    .LineI = 0
                                    .LineJ = 0
                                    .LineK = 0
                                    .LineL = 0
                                    .DAL3 = 0
                                    .GrandTotal = 0
                                    .Save()
                                End With


                                With objProduction
                                    .TempProductionID = objProduction.GetID()
                                    .TempDate = TempDateVar
                                    If LineNo = "A" Then
                                        .LineA = qty
                                    ElseIf LineNo = "B" Then
                                        .LineB = qty
                                    ElseIf LineNo = "C" Then
                                        .LineC = qty
                                    ElseIf LineNo = "D" Then
                                        .LineD = qty
                                    ElseIf LineNo = "E" Then
                                        .LineE = qty
                                    ElseIf LineNo = "F" Then
                                        .LineF = qty
                                    ElseIf LineNo = "G" Then
                                        .LineG = qty
                                    ElseIf LineNo = "H" Then
                                        .LineH = qty
                                    ElseIf LineNo = "I" Then
                                        .LineI = qty
                                    ElseIf LineNo = "J" Then
                                        .LineJ = qty
                                    ElseIf LineNo = "K" Then
                                        .LineK = qty
                                    ElseIf LineNo = "L" Then
                                        .LineL = qty
                                    ElseIf LineNo = "DAL-3" Then
                                        .DAL3 = qty
                                    End If
                                    .GrandTotal = 0
                                    .Save()
                                End With
                            End If
                        Next
                    End If
                Next

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                'End Delete
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                '  Report.Load(Server.MapPath("..\Reports/OfflineSheetDaily.rpt"))
                Report.Load(Server.MapPath("..\Reports/MonthlyWiseProductionReport.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Monthly_Wise_Production_Report"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                Report.SetParameterValue(0, cmbYear.SelectedValue)

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