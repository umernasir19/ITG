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
Public Class ProcessPurchaseRegister
    Inherits System.Web.UI.Page
    Dim CheckDate As String
    Dim ObjGeneralCode As GeneralCode
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim objPOMaster As New POMaster
    Dim dtProcessSession As DataTable
    Dim Dr As DataRow
    Dim UserId As Long
    Dim objTempPurchaseRegisterClass As New TempPurchaseRegisterClassForProcess
    Dim objTempStockInventory As New TempStockInventoryFinal
    Dim ObjIssue As New IssueMst
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            BindGrnno()
            BindSeason()
            BindSrNo()
            txtDateFrom.SelectedDate = "01/07/2017"
            txtDateTo.SelectedDate = Date.Now
            PageHeader("Purchase Register Report")
        End If
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssueForStoreReportForGoogRecvNoteForProcess()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        cmbSeason.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAnyForStoreIssueReportForGoodRecvNoteReportForProcess()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForStoreReportForGoodRecvNoteForProcess(cmbSeason.SelectedValue)
            cmbSrNo.DataSource = dtt
            cmbSrNo.DataValueField = "JobOrderId"
            cmbSrNo.DataTextField = "SrNo"
            cmbSrNo.DataBind()
            cmbSrNo.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindGrnno()
        Try
                Dim dtJobNo As DataTable
            dtJobNo = objDPPoRecevMst.GetGrNnoFromPurchaseForProcess()
                cmbGRNNo.DataSource = dtJobNo
                cmbGRNNo.DataTextField = "GatePassNo"
            cmbGRNNo.DataValueField = "POProcessRecvMasterID"
                cmbGRNNo.DataBind()
                cmbGRNNo.Items.Insert(0, New ListItem("All", "0"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub TXTCodeEntry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCodeEntry.TextChanged
        Try
            Dim dt As DataTable
            dt = objPOMaster.GetItemFabricNew(TXTCodeEntry.Text)
            lblID.Text = dt.Rows(0)("IMSItemID")
        Catch ex As Exception

        End Try

    End Sub
    Sub SaveSession()
        Session("dtProcessSession") = Nothing
        objTempStockInventory.TruncateTempTablePurchaseRegisterForProcess()
        Dim dt As DataTable
        dt = objDPPoRecevMst.GetDataForPurchaseRegisterReportForProcess()
        If (Not CType(Session("dtProcessSession"), DataTable) Is Nothing) Then
            dtProcessSession = Session("dtProcessSession")
        Else
            dtProcessSession = New DataTable
            With dtProcessSession
                .Columns.Add("ID", GetType(String))
                .Columns.Add("GRNNo", GetType(String))
                .Columns.Add("PORecvDate", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("SupplierName", GetType(String))
                .Columns.Add("Qty", GetType(String))
                .Columns.Add("Rate", GetType(String))
                .Columns.Add("LastPurchaseDate", GetType(String))
                .Columns.Add("LastPurchaseRate", GetType(String))
                .Columns.Add("SecondLastPurchaseDate", GetType(String))
                .Columns.Add("SecondLastPurchaseRate", GetType(String))
                .Columns.Add("ProcessItemNameID", GetType(String))
                .Columns.Add("POProcessRecvMasterID", GetType(String))
                .Columns.Add("JobOrderId", GetType(String))
            End With
        End If
        Dim x As Integer
        For x = 0 To dt.Rows.Count - 1
            Dr = dtProcessSession.NewRow()
            Dr("ID") = 0
            Dr("ProcessItemNameID") = dt.Rows(x)("ProcessItemNameID")
            Dr("POProcessRecvMasterID") = dt.Rows(x)("POProcessRecvMasterID")
            Dr("GRNNo") = dt.Rows(x)("GatePassNo")
            Dr("PORecvDate") = dt.Rows(x)("PORecvDate")
            Dr("ItemCodee") = dt.Rows(x)("ItemCodee")
            Dr("ItemName") = dt.Rows(x)("ItemName")
            Dr("SupplierName") = dt.Rows(x)("SupplierName")
            Dr("Qty") = dt.Rows(x)("RecvQty")
            Dr("Rate") = dt.Rows(x)("RecvRate")
            Dr("JobOrderId") = dt.Rows(x)("JobOrderId")

            Dim date1 As Date = dt.Rows(x)("PoRecvDate")
            Dim Estdatee As String = date1.ToString("dd/MM/yyyy")

            Dim LastPurchase As DataTable = objDPPoRecevMst.GetLastPurchaseForProcess(dt.Rows(x)("ProcessItemNameID"), Estdatee)
            If LastPurchase.Rows.Count > 1 Then
                Dr("LastPurchaseRate") = LastPurchase.Rows(0)("LastPurchaseRate")
                Dr("LastPurchaseDate") = LastPurchase.Rows(0)("LastPurchaseDate")
                Dr("SecondLastPurchaseRate") = LastPurchase.Rows(1)("LastPurchaseRate")
                Dr("SecondLastPurchaseDate") = LastPurchase.Rows(1)("LastPurchaseDate")
            ElseIf LastPurchase.Rows.Count = 0 Then
                Dr("LastPurchaseRate") = 0
                Dr("LastPurchaseDate") = ""
                Dr("SecondLastPurchaseRate") = 0
                Dr("SecondLastPurchaseDate") = ""
            Else
                Dim date2 As Date = dt.Rows(x)("PoRecvDate")
                Dim Estdateee As String = date2.ToString("dd/MM/yyyy")

                Dim SecondLastPurchase As DataTable = objDPPoRecevMst.GetLastPurchaseForProcess(dt.Rows(x)("ProcessItemNameID"), Estdateee)
                Dr("LastPurchaseRate") = SecondLastPurchase.Rows(0)("LastPurchaseRate")
                Dr("LastPurchaseDate") = SecondLastPurchase.Rows(0)("LastPurchaseDate")
                Dr("SecondLastPurchaseRate") = 0
                Dr("SecondLastPurchaseDate") = ""
            End If
            dtProcessSession.Rows.Add(Dr)
        Next
        Session("dtProcessSession") = dtProcessSession
        With objTempPurchaseRegisterClass
            Dim z As Integer
            For z = 0 To dtProcessSession.Rows.Count - 1
                .ID = 0
                .GRNNo = dtProcessSession.Rows(z)("GRNNo")
                .PORecvDate = dtProcessSession.Rows(z)("PORecvDate")
                .ItemCodee = dtProcessSession.Rows(z)("ItemCodee")
                .ItemName = dtProcessSession.Rows(z)("ItemName")
                .SupplierName = dtProcessSession.Rows(z)("SupplierName")
                .Qty = dtProcessSession.Rows(z)("Qty")
                .Rate = dtProcessSession.Rows(z)("Rate")
                .LastPurchaseDate = dtProcessSession.Rows(z)("LastPurchaseDate")
                .LastPurchaseRate = dtProcessSession.Rows(z)("LastPurchaseRate")
                .SecondLastPurchaseDate = dtProcessSession.Rows(z)("SecondLastPurchaseDate")
                .SecondLastPurchaseRate = dtProcessSession.Rows(z)("SecondLastPurchaseRate")
                .ItemID = dtProcessSession.Rows(z)("ProcessItemNameID")
                .PORecvMasterID = dtProcessSession.Rows(z)("POProcessRecvMasterID")
                .JoborderId = dtProcessSession.Rows(z)("JobOrderId")
                .Save()
            Next
        End With
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
        Try
            If txtDateFrom.SelectedDate.ToString <> "" Or txtDateTo.SelectedDate.ToString <> "" Then
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                SaveSession()
                Report.Load(Server.MapPath("..\Reports/PurchaseRegisterForPurchaseForProcess.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "PurchaseRegister"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                CheckDate = 1
                Report.SetParameterValue(0, txtDateFrom.SelectedDate)
                Report.SetParameterValue(1, txtDateTo.SelectedDate)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(5, cmbSrNo.SelectedValue)


                Report.SetParameterValue(6, txtDateFrom.SelectedDate)
                Report.SetParameterValue(7, txtDateTo.SelectedDate)
                Report.SetParameterValue(8, CheckDate)
                Report.SetParameterValue(9, lblID.Text)
                Report.SetParameterValue(10, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(11, cmbSrNo.SelectedValue)

                Report.SetParameterValue(12, txtDateFrom.SelectedDate)
                Report.SetParameterValue(13, txtDateTo.SelectedDate)
                Report.SetParameterValue(14, CheckDate)
                Report.SetParameterValue(15, lblID.Text)
                Report.SetParameterValue(16, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(17, cmbSrNo.SelectedValue)

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

            Else
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next
                Dim Report As New ReportDocument
                Dim Options As New ExportOptions    
                Report.Load(Server.MapPath("..\Reports/PurchaseRegisterForProcess.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "PurchaseRegister"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                CheckDate = 0
                Report.SetParameterValue(0, Date.Now)
                Report.SetParameterValue(1, Date.Now)
                Report.SetParameterValue(2, CheckDate)
                Report.SetParameterValue(3, lblID.Text)
                Report.SetParameterValue(4, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(5, cmbSrNo.SelectedValue)
                Report.SetParameterValue(6, Date.Now)
                Report.SetParameterValue(7, Date.Now)
                Report.SetParameterValue(8, CheckDate)
                Report.SetParameterValue(9, lblID.Text)
                Report.SetParameterValue(10, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(11, cmbSrNo.SelectedValue)
                Report.SetParameterValue(12, Date.Now)
                Report.SetParameterValue(13, Date.Now)
                Report.SetParameterValue(14, CheckDate)
                Report.SetParameterValue(15, lblID.Text)
                Report.SetParameterValue(16, cmbGRNNo.SelectedValue)
                Report.SetParameterValue(17, cmbSrNo.SelectedValue)


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