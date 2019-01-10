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
Public Class BLInstructionAdd
    Inherits System.Web.UI.Page
    Dim objBIInstMst As New BIInstMst
    Dim objBIInstDtl As New BIInstDtl
    Dim Dr As DataRow
    Dim dt As DataTable
    Dim lBIInstMstid, userid As Long
    Dim dtBLDetail As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lBIInstMstid = Request.QueryString("BIInstMstID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindInvoiceNo()
            Session("dtBLDetail") = Nothing
            If lBIInstMstid > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                BLNoGenerateOnLoad()
                txtShiper.Text = "DIGITAL APPAREL (PVT) LTD."
                txtShiperAddress.Text = "F-528/C, S.I.T.E. KARACHI-PAKISTAN"
                txtFrom.Text = "KARACHI-PAKISTAN"
                txtQtyPcs.Text = 0
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub BLNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = objBIInstMst.GetLastNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                LastCode = LastVoucherNo.Substring(4, 4)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "" & Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "BLI" & "-" & LastCode
            txtBlNo.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub Edit()
        Dim dt As DataTable = objBIInstMst.GetEditData(lBIInstMstid)
        txtBlNo.Text = dt.Rows(0)("BlNo")
        dtBLDetail = New DataTable
        With dtBLDetail
            .Columns.Add("BIInstDtlID", GetType(Long))
            .Columns.Add("InvoiceID", GetType(String))
            .Columns.Add("InvoiceNo", GetType(String))
            .Columns.Add("Shiper", GetType(String))
            .Columns.Add("FormENo", GetType(String))
            .Columns.Add("ShiperAddress", GetType(String))
            .Columns.Add("FormEDate", GetType(String))
            .Columns.Add("From", GetType(String))
            .Columns.Add("Consignee", GetType(String))
            .Columns.Add("Too", GetType(String))
            .Columns.Add("QtyCtn", GetType(String))
            .Columns.Add("QtyPcs", GetType(String))
            .Columns.Add("NetWt", GetType(String))
            .Columns.Add("GrossWt", GetType(String))
            .Columns.Add("Notify", GetType(String))
            .Columns.Add("Lc", GetType(String))
            .Columns.Add("LcDate", GetType(String))
            .Columns.Add("Container", GetType(String))
            .Columns.Add("Vessel", GetType(String))
            .Columns.Add("Freight", GetType(String))
            .Columns.Add("MarksNo", GetType(String))
        End With
        Dim x As Integer
        For x = 0 To dt.Rows.Count - 1
            Dr = dtBLDetail.NewRow()
            Dr("BIInstDtlID") = dt.Rows(x)("BIInstDtlID")
            Dr("InvoiceID") = dt.Rows(x)("InvoiceID")
            Dr("InvoiceNo") = dt.Rows(x)("InvoiceNo")
            Dr("Shiper") = dt.Rows(x)("Shiper")
            Dr("FormENo") = dt.Rows(x)("FormENo")
            Dr("ShiperAddress") = dt.Rows(x)("ShiperAddress")
            Dr("FormEDate") = dt.Rows(x)("FormEDate")
            Dr("From") = dt.Rows(x)("From")
            Dr("Consignee") = dt.Rows(x)("Consignee")
            Dr("Too") = dt.Rows(x)("Too")
            Dr("QtyCtn") = dt.Rows(x)("QtyCtn")
            Dr("QtyPcs") = dt.Rows(x)("QtyPcs")
            Dr("NetWt") = dt.Rows(x)("NetWt")
            Dr("GrossWt") = dt.Rows(x)("GrossWt")
            Dr("Notify") = dt.Rows(x)("Notify")
            Dr("Lc") = dt.Rows(x)("Lc")
            Dr("LcDate") = dt.Rows(x)("LcDate")
            Dr("Container") = dt.Rows(x)("Container")
            Dr("Vessel") = dt.Rows(x)("Vessel")
            Dr("Freight") = dt.Rows(x)("Freight")
            Dr("MarksNo") = dt.Rows(x)("MarksNo")
            dtBLDetail.Rows.Add(Dr)
        Next
        Session("dtBLDetail") = dtBLDetail
        BindGrid()
    End Sub
    Sub BindInvoiceNo()
        Dim dt As DataTable
        dt = objBIInstMst.GetInvoiceNo()
        cmbInvoiceNo.DataSource = dt
        cmbInvoiceNo.DataTextField = "InvoiceNo"
        cmbInvoiceNo.DataValueField = "CargoID"
        cmbInvoiceNo.DataBind()
        cmbInvoiceNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try
            dt = objBIInstMst.GetDatafrmCargo(cmbInvoiceNo.SelectedValue)
            txtFormE.Text = dt.Rows(0)("FromENO")
            txtFormEDate.SelectedDate = dt.Rows(0)("FromEDate")
            txtLc.Text = dt.Rows(0)("LCNO")
            txtLcDate.SelectedDate = dt.Rows(0)("DateOfIssue")
            txtConsignee.Text = dt.Rows(0)("CustomerName")
            txtQtyCtn.Text = dt.Rows(0)("NoOfCartoon")
            txtNetWt.Text = dt.Rows(0)("NetWeight")
            txtGrossWt.Text = dt.Rows(0)("GrossWeight")
            txtConsignee.Text = dt.Rows(0)("Consignee")
            txtNotify.Text = dt.Rows(0)("Notifyparty")
            txtContainer.Text = dt.Rows(0)("ContainerNo")
            txtMarksNo.Text = dt.Rows(0)("MarksAndNumbers")
            txtMarksNo.Text = dt.Rows(0)("MarksAndNumbers")
            txtQtyPcs.Text = dt.Rows(0)("PCSS")



           Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            SaveMaster()
            SaveDetail()
            Response.Redirect("BIInstView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("BIInstView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveMaster()
        With objBIInstMst
            If lBIInstMstid > 0 Then
                .BIInstMstID = lBIInstMstid
            Else
                .BIInstMstID = 0
            End If
            .UserID = userid
            .CreationDate = Date.Now
            .BLNo = txtBlNo.Text
            .Save()
        End With
    End Sub
    Sub SaveDetail()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            With objBIInstDtl
                .BIInstDtlID = dgView.Items(x).Cells(0).Text
                If lBIInstMstid > 0 Then
                    .BIInstMstID = lBIInstMstid
                Else
                    .BIInstMstID = objBIInstMst.GetId()
                End If
                .InvoiceID = dgView.Items(x).Cells(1).Text
                .Shiper = dgView.Items(x).Cells(3).Text
                .FormENo = dgView.Items(x).Cells(4).Text
                .ShiperAddress = dgView.Items(x).Cells(5).Text
                .FormEDate = dgView.Items(x).Cells(6).Text
                .From = dgView.Items(x).Cells(7).Text
                .Consignee = dgView.Items(x).Cells(8).Text
                .Too = dgView.Items(x).Cells(9).Text
                .QtyCtn = dgView.Items(x).Cells(10).Text
                .QtyPcs = dgView.Items(x).Cells(11).Text
                .NetWt = dgView.Items(x).Cells(12).Text
                .GrossWt = dgView.Items(x).Cells(13).Text
                .Notify = dgView.Items(x).Cells(14).Text
                .Lc = dgView.Items(x).Cells(15).Text
                .LcDate = dgView.Items(x).Cells(16).Text
                .Container = dgView.Items(x).Cells(17).Text
                .Vessel = dgView.Items(x).Cells(18).Text
                .Freight = dgView.Items(x).Cells(19).Text
                .MarksNo = dgView.Items(x).Cells(20).Text
                .Save()
            End With
        Next
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtBLDetail"), DataTable) Is Nothing) Then
            dtBLDetail = Session("dtBLDetail")
        Else
            dtBLDetail = New DataTable
            With dtBLDetail
                .Columns.Add("BIInstDtlID", GetType(Long))
                .Columns.Add("InvoiceID", GetType(String))
                .Columns.Add("InvoiceNo", GetType(String))
                .Columns.Add("Shiper", GetType(String))
                .Columns.Add("FormENo", GetType(String))
                .Columns.Add("ShiperAddress", GetType(String))
                .Columns.Add("FormEDate", GetType(String))
                .Columns.Add("From", GetType(String))
                .Columns.Add("Consignee", GetType(String))
                .Columns.Add("Too", GetType(String))
                .Columns.Add("QtyCtn", GetType(String))
                .Columns.Add("QtyPcs", GetType(String))
                .Columns.Add("NetWt", GetType(String))
                .Columns.Add("GrossWt", GetType(String))
                .Columns.Add("Notify", GetType(String))
                .Columns.Add("Lc", GetType(String))
                .Columns.Add("LcDate", GetType(String))
                .Columns.Add("Container", GetType(String))
                .Columns.Add("Vessel", GetType(String))
                .Columns.Add("Freight", GetType(String))
                .Columns.Add("MarksNo", GetType(String))
            End With
        End If
        Dr = dtBLDetail.NewRow()
        Dr("BIInstDtlID") = 0
        Dr("InvoiceID") = cmbInvoiceNo.SelectedValue
        Dr("InvoiceNo") = cmbInvoiceNo.SelectedItem.Text
        Dr("Shiper") = txtShiper.Text
        Dr("FormENo") = txtFormE.Text
        Dr("ShiperAddress") = txtShiperAddress.Text
        Dr("FormEDate") = txtFormEDate.SelectedDate
        Dr("From") = txtFrom.Text
        Dr("Consignee") = txtConsignee.Text
        Dr("Too") = txtTo.Text
        Dr("QtyCtn") = txtQtyCtn.Text
        Dr("QtyPcs") = txtQtyPcs.Text
        Dr("NetWt") = txtNetWt.Text
        Dr("GrossWt") = txtGrossWt.Text
        Dr("Notify") = txtNotify.Text
        Dr("Lc") = txtLc.Text
        Dr("LcDate") = txtLcDate.SelectedDate
        Dr("Container") = txtContainer.Text
        Dr("Vessel") = txtVessel.Text
        Dr("Freight") = cmbFreight.SelectedItem.Text
        Dr("MarksNo") = txtMarksNo.Text
        dtBLDetail.Rows.Add(Dr)
        Session("dtBLDetail") = dtBLDetail
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtBLDetail")
            dgView.Visible = True
            dgView.RecordCount = objDatatble.Rows.Count
            dgView.DataSource = objDatatble
            dgView.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbInvoiceNo.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Invoice No.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindGrid()
                Clear()
                btnSave.Visible = True
                btnCancel.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Clear()
        cmbInvoiceNo.SelectedValue = 0
        txtFormE.Text = ""
        txtContainer.Text = ""
        txtVessel.Text = ""
        cmbFreight.SelectedValue = 0
        txtMarksNo.Text = ""
        txtConsignee.Text = ""
        txtTo.Text = ""
        txtQtyCtn.Text = ""
        txtNetWt.Text = ""
        txtGrossWt.Text = ""
        txtNotify.Text = ""
        txtLc.Text = ""
    End Sub
End Class