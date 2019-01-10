Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class RateApprovalAdd
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim lCargoID As Long
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Dim objRateApprovalMst As New RateApprovalMst
    Dim objRateApprovalDtl As New RateApprovalDtl
    Dim objBankClass As New BankClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCargoID = Request.QueryString("CargoID")
        If Not Page.IsPostBack Then
            BindBank()
            BindFrom()
            Session("dtDetail") = Nothing

            Dim dt As DataTable = objRateApprovalMst.Getdatanew(lCargoID)
            Dim dtt As DataTable = objRateApprovalMst.GetDataDetail(lCargoID)
            If dt.Rows.Count > 0 Then
                txtInvDate.Text = dt.Rows(0)("DateOfIssue")
                If dt.Rows(0)("DateOfIssue") = "01/01/1900" Then
                Else
                    txtInvDate.Text = dt.Rows(0)("DateOfIssue")
                End If
                txtBuyer.Text = dt.Rows(0)("BuyerName")
                txtInvNo.Text = dt.Rows(0)("InvoiceNo")
                txtAmount.Text = dt.Rows(0)("InvoiceAmount")
                txtPkr.Text = dt.Rows(0)("AmountInPKR")
                txtterms.Text = dt.Rows(0)("PaymentTerms")
                BindFrom()
                cmbfrom.SelectedValue = dt.Rows(0)("FromID")
                txtFinal.Text = dt.Rows(0)("Final")

            End If

            If dtt.Rows.Count > 0 Then
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("RateApproveDtlID", GetType(Long))
                    .Columns.Add("BankID", GetType(String))
                    .Columns.Add("Banker", GetType(String))
                    .Columns.Add("Rate", GetType(String))
                End With
                For x = 0 To dtt.Rows.Count - 1
                    Dr = dtDetail.NewRow()
                    Dr("RateApproveDtlID") = dtt.Rows(x)("RateApprovalDtlID")
                    Dr("BankID") = dtt.Rows(x)("BankID")
                    Dr("Banker") = dtt.Rows(x)("Bank")
                    Dr("Rate") = dtt.Rows(x)("Rate")
                    dtDetail.Rows.Add(Dr)
                Next
                Session("dtDetail") = dtDetail
                BindGrid()

            End If
        End If
    End Sub
    Protected Sub BtnAddFROM_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddFROM.Click
        Try
            PnlFROM2.Visible = True
            PnlFROM1.Visible = False

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveFROM_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveFROM.Click
        Try
            If txtAddFROM.Text <> "" Then
                With objBankClass
                    .BankID = 0
                    .Bank = txtAddFROM.Text
                 .Save()
                End With
            End If
        Catch ex As Exception
        End Try
        PnlFROM1.Visible = True
        PnlFROM2.Visible = False
        BindFrom()
    End Sub
    Sub BindBank()
        Dim dt As DataTable
        dt = objRateApprovalMst.GetBank()
        cmbBank.DataSource = dt
        cmbBank.DataTextField = "Bank"
        cmbBank.DataValueField = "BankID"
        cmbBank.DataBind()
        cmbBank.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindFrom()
        Dim dt As DataTable
        dt = objRateApprovalMst.GetBank()
        cmbfrom.DataSource = dt
        cmbfrom.DataTextField = "Bank"
        cmbfrom.DataValueField = "BankID"
        cmbfrom.DataBind()
        cmbfrom.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            SaveSession()
            BindGrid()
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("RateApproveDtlID", GetType(Long))
                .Columns.Add("BankID", GetType(String))
                .Columns.Add("Banker", GetType(String))
                .Columns.Add("Rate", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("RateApproveDtlID") = 0
        Dr("BankID") = cmbBank.SelectedValue
        Dr("Banker") = cmbBank.SelectedItem.Text
        Dr("Rate") = txtRate.Text
        dtDetail.Rows.Add(Dr)
        Session("dtDetail") = dtDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgDetail.Visible = True
                dgDetail.VirtualItemCount = objDatatble.Rows.Count
                dgDetail.DataSource = objDatatble
                dgDetail.DataBind()
            Else
                dgDetail.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SaveData()
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            'End Delete
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/RateApprovalNegotiate.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Rate Approval Negotiate"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

            Report.SetParameterValue(0, lCargoID)

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


        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With objRateApprovalMst

            Dim dt As DataTable = objRateApprovalMst.GetData(lCargoID)
            If dt.Rows.Count > 0 Then
                .RateApprovalMstID = dt.Rows(0)("RateApprovalMstID")
            Else
                .RateApprovalMstID = 0
            End If

            If txtInvNo.Text = "" Then
                .InvNo = ""
            Else
                .InvNo = txtInvNo.Text
            End If
            If txtInvDate.Text = "" Then
                .InvDate = "01/01/1900"
            Else
                .InvDate = txtInvDate.Text
            End If
            If txtBuyer.Text = "" Then
                .Buyer = ""
            Else
                .Buyer = txtBuyer.Text
            End If
            .Amount = txtAmount.Text
            .terms = txtterms.Text
            .PKR = txtPkr.Text
            .FromID = cmbfrom.SelectedValue
            If txtFinal.Text = "" Then
                .Final = 0
            Else
                .Final = txtFinal.Text
            End If

            .CargoID = lCargoID
            .SaveMst()
        End With
        Dim x As Integer
        For x = 0 To dgDetail.Items.Count - 1


            With objRateApprovalDtl
                .RateApprovalDtlID = dgDetail.Items(x).Cells(0).Text
                .RateApprovalMstID = objRateApprovalMst.GetID
                .BankID = dgDetail.Items(x).Cells(1).Text
                .Rate = dgDetail.Items(x).Cells(3).Text
                .Save()
            End With
        Next
    End Sub


End Class