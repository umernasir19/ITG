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
Public Class BankCoverAdd
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim lCargoID As Long
    Dim ObjBankCoverMst As New BankCoverMst
    Dim objBankCoverDtl As New BankCoverDtl
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCargoID = 1 'Request.QueryString("CargoID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            BindList()
            Dim dt As DataTable = ObjBankCoverMst.GetDataCargo(lCargoID)
            Dim dtt As DataTable = ObjBankCoverMst.GetDataBuyerCoverDetail(lCargoID)
            If dt.Rows.Count > 0 Then
                txtInvoice.Text = dt.Rows(0)("InvoiceNo")
                If dt.Rows(0)("InvoiceDate") = "01/01/1900" Then
                Else
                    txtInvoiceDate.SelectedDate = dt.Rows(0)("InvoiceDate")
                End If
                txtBankAdd.Text = dt.Rows(0)("Aliass")

            End If

            If dtt.Rows.Count > 0 Then
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("BankCoverDtlId", GetType(Long))
                    .Columns.Add("ListID", GetType(String))
                    .Columns.Add("ListName", GetType(String))
                    .Columns.Add("ListNo", GetType(String))
                End With
                For x = 0 To dtt.Rows.Count - 1
                    Dr = dtDetail.NewRow()
                    Dr("BankCoverDtlId") = dtt.Rows(x)("BankCoverDtlId")
                    Dr("ListID") = dtt.Rows(x)("ListID")
                    Dr("ListName") = dtt.Rows(x)("List")
                    Dr("ListNo") = dtt.Rows(x)("ListNo")
                    dtDetail.Rows.Add(Dr)
                Next
                Session("dtDetail") = dtDetail
                BindGrid()

            End If
        End If
    End Sub

    Sub BindList()
        Dim dt As DataTable
        dt = ObjBankCoverMst.GetList()
        cmbList.DataSource = dt
        cmbList.DataTextField = "List"
        cmbList.DataValueField = "ListID"
        cmbList.DataBind()
        cmbList.Items.Insert(0, New ListItem("Select", "0"))
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
            Report.Load(Server.MapPath("..\Reports/BankCover.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Bank Cover"
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
                .Columns.Add("BankCoverDtlId", GetType(Long))
                .Columns.Add("ListID", GetType(String))
                .Columns.Add("ListName", GetType(String))
                .Columns.Add("ListNo", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("BankCoverDtlId") = 0
        Dr("ListID") = cmbList.SelectedValue
        Dr("ListName") = cmbList.SelectedItem.Text
        Dr("ListNo") = txtListNo.Text
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
    Sub SaveData()
        With ObjBankCoverMst

            Dim dt As DataTable = ObjBankCoverMst.GetData(lCargoID)
            If dt.Rows.Count > 0 Then
                .BankCoverMstID = dt.Rows(0)("BankCoverMstID")
            Else
                .BankCoverMstID = 0
            End If

            If txtInvoice.Text = "" Then
                .InvNo = ""
            Else
                .InvNo = txtInvoice.Text
            End If
            If txtInvoiceDate.SelectedDate.ToString = "" Then
                .InvDate = "01/01/1900"
            Else
                .InvDate = txtInvoiceDate.SelectedDate
            End If
            If txtBankAdd.Text = "" Then
                .BankAdd = ""
            Else
                .BankAdd = txtBankAdd.Text
            End If
            .CargoID = lCargoID
            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgDetail.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgDetail.MasterTableView.Items(x), GridDataItem)

            With objBankCoverDtl
                .BankCoverDtlID = item("BankCoverDtlID").Text
                .BankCoverMstID = ObjBankCoverMst.GetID
                .ListID = item("ListID").Text
                .ListNo = item("ListNo").Text
                .Save()
            End With
        Next
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try

            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("CargoReleaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class