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
Public Class BuyCoverAdd
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim lCargoID As Long
    Dim ObjBuyerCoverMst As New BuyerCoverMst
    Dim objBuyerCoverDtl As New BuyerCoverDtl
    Dim dtDetail As DataTable
    Dim Dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCargoID = Request.QueryString("CargoID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            BindInvoiceNo()

            Dim dt As DataTable = ObjBuyerCoverMst.GetDataCargo(lCargoID)
            Dim dtt As DataTable = ObjBuyerCoverMst.GetDataBuyerCoverDetail(lCargoID)
            If dt.Rows.Count > 0 Then
                txtInvoice.Text = dt.Rows(0)("InvoiceNo")

                If dt.Rows(0)("InvoiceDate") = "01/01/1900 00:00:00" Then
                Else
                    txtInvoiceDate.SelectedDate = dt.Rows(0)("InvoiceDate")
                End If


                txtBuyer.Text = dt.Rows(0)("Aliass")
                txtAdress.Text = dt.Rows(0)("Address1")
            End If

                If dtt.Rows.Count > 0 Then


                    dtDetail = New DataTable
                    With dtDetail
                        .Columns.Add("BuyerCoverDtlId", GetType(Long))
                        .Columns.Add("ListID", GetType(String))
                        .Columns.Add("ListName", GetType(String))
                        .Columns.Add("ListNo", GetType(String))
                    End With
                    For x = 0 To dtt.Rows.Count - 1
                        Dr = dtDetail.NewRow()
                        Dr("BuyerCoverDtlId") = dtt.Rows(x)("BuyerCoverDtlID")
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
    Sub BindInvoiceNo()
        Dim dt As DataTable
        dt = ObjBuyerCoverMst.GetList()
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
            Report.Load(Server.MapPath("..\Reports/BuyerCover.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Buyer Cover"
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
                .Columns.Add("BuyerCoverDtlId", GetType(Long))
                .Columns.Add("ListID", GetType(String))
                .Columns.Add("ListName", GetType(String))
                .Columns.Add("ListNo", GetType(String))
            End With
        End If
        Dr = dtDetail.NewRow()
        Dr("BuyerCoverDtlId") = 0
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
        With ObjBuyerCoverMst

            Dim dt As DataTable = ObjBuyerCoverMst.GetData(lCargoID)
            If dt.Rows.Count > 0 Then
                .BuyerCoverMstID = dt.Rows(0)("BuyerCoverMstID")
            Else
                .BuyerCoverMstID = 0
            End If

            If txtInvoice.Text = "" Then
                .InvNo = ""
            Else
                .InvNo = txtInvoice.Text
            End If
            If txtInvoiceDate.SelectedDate.ToString = "" Then
                .InvDate = "1/1/1900"
            Else
                .InvDate = txtInvoiceDate.SelectedDate
            End If
            If txtBuyer.Text = "" Then
                .Buyer = ""
            Else
                .Buyer = txtBuyer.Text
            End If
            If txtAdress.Text = "" Then
                .BuyerAddress = ""
            Else
                .BuyerAddress = txtAdress.Text
            End If
            .CargoID = lCargoID

            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgDetail.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgDetail.MasterTableView.Items(x), GridDataItem)

            With objBuyerCoverDtl
                .BuyerCoverDtlID = item("BuyerCoverDtlId").Text
                .BuyerCoverMstID = ObjBuyerCoverMst.GetID
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