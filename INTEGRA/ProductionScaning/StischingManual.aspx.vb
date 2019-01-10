Imports Integra.classes
Imports System.Data
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Color
Imports System.Drawing.KnownColor
Imports System.Web
Imports System.Reflection
Imports System.Drawing
Imports System
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports System.Web.Services
Imports System.Web.UI.WebControls.GridView
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class StischingManual
    Inherits System.Web.UI.Page
    Dim dr As DataRow
    Dim objDataView As DataView
    Dim dtdata, dtDetail As New DataTable
    Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
    Dim objAutoComplete As New AutoComplete
    Dim ObjTFAStitching As New TFAStitching
    Dim lUserid As Long
    Dim ObjTFAWashing As New TFAWashing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lUserid = Session("UserId")
        If Not Page.IsPostBack Then
            txtBarcodee.Focus()
            txtCreationDate.Text = Date.Now.ToString("dd/MM/yyyy")
            Session("dtDetail") = Nothing
        End If
    End Sub
    Protected Sub cmbLineNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLineNo.SelectedIndexChanged
        Try
            If cmbLineNo.SelectedItem.Text = "Select" Then
                txtBarcodee.ReadOnly = True
            Else
                txtBarcodee.ReadOnly = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("StyleAssortmentBarCodeDetailID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("Merchandiser", GetType(String))
                .Columns.Add("JobNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Brand", GetType(String))
            End With
        End If
        dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcodee.Text)
        If dtdata.Rows.Count > 0 Then
            dr = dtDetail.NewRow()
            dr("StyleAssortmentBarCodeDetailID") = dtdata.Rows(0)("StyleAssortmentBarCodeDetailID").ToString
            dr("Joborderid") = dtdata.Rows(0)("Joborderid").ToString
            dr("JoborderDetailid") = dtdata.Rows(0)("JoborderDetailid").ToString
            dr("Merchandiser") = dtdata.Rows(0)("Merchandiser").ToString
            dr("JobNo") = dtdata.Rows(0)("SrNo").ToString
            dr("Style") = dtdata.Rows(0)("Style").ToString
            dr("Item") = dtdata.Rows(0)("Item").ToString
            dr("Brand") = dtdata.Rows(0)("Brand").ToString
            dtDetail.Rows.Add(dr)
        End If
        Session("dtDetail") = dtDetail
        BindGrid()
    End Sub
    Sub clear()
        txtBarcodee.Text = ""
    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)
        dgView.DataSource = objDataview
        dgView.DataBind()
    End Sub
    Protected Sub txtBarcodee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcodee.TextChanged
        Try
            If txtCreationDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date.")
            Else
                Dim name As String = txtBarcodee.Text
                Dim dttt As DataTable
                Session("dtDetail") = Nothing
                dgView.Visible = True
                dtDetail = Session("dtDetail")
                dgView.DataSource = dtDetail
                dgView.DataBind()
                Dim dtCheckFromDd As New DataTable
                dtCheckFromDd = ObjTFAStitching.GetData(txtBarcodee.Text)
                If dtCheckFromDd.Rows.Count > 0 Then
                    txtBarcodee.Text = ""
                    txtBarcodee.Focus()
                    lblmsg.Text = "Already Scanned"
                    lblScanedPcs.Text = ""
                    System.Web.UI.ScriptManager.RegisterStartupScript(Me, [GetType](), "check_Javascript", "doJavaScript();", True)
                    txtBarcodee.Focus()
                    clear()
                Else
                    If LalblStyle.Text = "" Then
                        lblmsg.Text = ""
                        If Session("RoleId") = 46 And Session("Type") = "Production" Then
                            dttt = objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, 270, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                            objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, 270, txtCreationDate.Text)
                        Else
                            dttt = objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, lUserid, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                            objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, lUserid, txtCreationDate.Text)
                        End If
                            lblmsg.Text = "Successfully Saved "
                            txtBarcodee.Focus()
                            clear()
                            lblCounter.Text = Val(lblCounter.Text) + 1
                        'lblmsg.Text = ""
                        'dttt = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcodee.Text)
                        'If dttt.Rows.Count > 0 Then
                        '    dgView.DataSource = dttt
                        '    dgView.DataBind()
                        '    Dim z As Integer
                        '    For z = 0 To dgView.Rows.Count - 1
                        '        dgView.Rows(z).Cells(10).Text = cmbLineNo.SelectedItem.Text
                        '    Next
                        '    If Session("RoleId") = 46 And Session("Type") = "Production" Then
                        '        dttt = objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, 270, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                        '        objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, 270, txtCreationDate.Text)
                        '    Else
                        '        dttt = objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, lUserid, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                        '        objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, lUserid, txtCreationDate.Text)
                        '    End If
                        '    lblmsg.Text = "Successfully Saved "
                        '    txtBarcodee.Focus()
                        '    clear()
                        '    lblCounter.Text = Val(lblCounter.Text) + 1
                        'Else
                        'End If
                    Else
                        lblmsg.Text = ""
                        If Session("RoleId") = 46 And Session("Type") = "Production" Then
                            objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, 270, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                            objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, 270, txtCreationDate.Text)
                        Else
                            objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, lUserid, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                            objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, lUserid, txtCreationDate.Text)
                        End If
                            lblmsg.Text = "Successfully Saved "
                            txtBarcodee.Focus()
                            clear()
                            lblCounter.Text = Val(lblCounter.Text) + 1
                        'lblmsg.Text = ""
                        'dttt = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcodee.Text)
                        'If dttt.Rows.Count > 0 Then
                        '    dgView.DataSource = dttt
                        '    dgView.DataBind()
                        '    Dim z As Integer
                        '    For z = 0 To dgView.Rows.Count - 1
                        '        dgView.Rows(z).Cells(10).Text = cmbLineNo.SelectedItem.Text
                        '    Next
                        '    If Session("RoleId") = 46 And Session("Type") = "Production" Then
                        '        objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, 270, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                        '        objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, 270, txtCreationDate.Text)
                        '    Else
                        '        objStyleAssortmentBarCodeDetail.UpdateDataStitchingManualNew(txtBarcodee.Text, lUserid, txtCreationDate.Text, cmbLineNo.SelectedItem.Text)
                        '        objStyleAssortmentBarCodeDetail.UpdateDataWashingManual(txtBarcodee.Text, lUserid, txtCreationDate.Text)
                        '    End If
                        '    lblmsg.Text = "Successfully Saved "
                        '    txtBarcodee.Focus()
                        '    clear()
                        '    lblCounter.Text = Val(lblCounter.Text) + 1
                        'Else
                        'End If
                    End If
                    'dgView.Visible = True
                    'Dim x As Integer
                    lblScanedPcs.Text = ""
                    'Dim totalStyleCount As New DataTable
                    'Dim TotalRows As Decimal = 0
                    'For x = 0 To dgView.Rows.Count - 1
                    '    lblScanedPcs.Text = TotalRows
                    '    lblJobNo.Text = dgView.Rows(x).Cells(3).Text
                    '    LalblStyle.Text = dgView.Rows(x).Cells(5).Text
                    '    lblStyleQty.Text = dgView.Rows(x).Cells(4).Text
                    '    Dim size As String = ""
                    '    size = dgView.Rows(x).Cells(9).Text
                    '    totalStyleCount = ObjTFAStitching.GetTotalScanedbyJOBstyleSizeTFAStitching(lblJobNo.Text, LalblStyle.Text, size)
                    '    If totalStyleCount.Rows.Count = 1 Then
                    '        TotalRows = 1
                    '    Else
                    '        TotalRows = totalStyleCount.Rows.Count
                    '    End If
                    '    lblScanedPcs.Text = TotalRows
                    'Next
                    txtBarcodee.Focus()
                    clear()
                End If
            End If
        Catch ex As Exception
        End Try
        txtBarcodee.Focus()
    End Sub
    Protected Sub txtBarcode_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcodee.TextChanged
        Try
            If txtCreationDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date.")
            Else
                Session("dtDetail") = Nothing
                dgView.Visible = True
                dtDetail = Session("dtDetail")
                dgView.DataSource = dtDetail
                dgView.DataBind()
                Dim dtCheckFromDd As New DataTable
                dtCheckFromDd = ObjTFAStitching.GetData(txtBarcodee.Text)
                If dtCheckFromDd.Rows.Count > 0 Then
                    txtBarcodee.Text = ""
                    txtBarcodee.Focus()
                    lblmsg.Text = "Already Scanned"
                    lblScanedPcs.Text = ""
                    System.Web.UI.ScriptManager.RegisterStartupScript(Me, [GetType](), "check_Javascript", "doJavaScript();", True)
                Else
                    Dim dtcheckStyleChange As New DataTable
                    dtcheckStyleChange = ObjTFAStitching.ChkDataStyle(txtBarcodee.Text)
                    Dim ChkStyle As String = ""
                    ChkStyle = dtcheckStyleChange.Rows(0)("Style").ToString
                    If LalblStyle.Text = "" Then
                        lblmsg.Text = ""
                        objAutoComplete.GetValue(txtBarcodee.Text, lblmsg, dgView, txtBarcodee)
                    Else
                        lblmsg.Text = ""
                        objAutoComplete.GetValue(txtBarcodee.Text, lblmsg, dgView, txtBarcodee)
                    End If
                    Dim y As Integer
                    Dim row As GridViewRow
                    For Each row In dgView.Rows
                        Dim lblStyleAssortmentBarCodeDetailID As Label = CType(row.FindControl("lblStyleAssortmentBarCodeDetailID"), Label)
                        Dim lblJoborderid As Label = CType(row.FindControl("lblJoborderid"), Label)
                        Dim lblJoborderDetailid As Label = CType(row.FindControl("lblJoborderDetailid"), Label)
                        Dim lblStyleAssortmentMasterID As Label = CType(row.FindControl("lblStyleAssortmentMasterID"), Label)
                        Dim lblSizeRangeID As Label = CType(row.FindControl("lblSizeRangeID"), Label)
                        Dim lblSizeDatabaseID As Label = CType(row.FindControl("lblSizeDatabaseID"), Label)
                        With ObjTFAStitching
                            .TFAStitchingid = 0
                            .StyleAssortmentBarCodeDetailID = lblStyleAssortmentBarCodeDetailID.Text
                            .Joborderid = lblJoborderid.Text
                            .JoborderDetailid = lblJoborderDetailid.Text
                            .StyleAssortmentMasterID = lblStyleAssortmentMasterID.Text
                            .SizeRangeID = lblSizeRangeID.Text
                            .SizeDatabaseID = lblSizeDatabaseID.Text
                            .Code = dgView.Rows(y).Cells(1).Text
                            .Merchandiser = dgView.Rows(y).Cells(2).Text
                            .JobNo = dgView.Rows(y).Cells(3).Text
                            .TotalOrderQty = dgView.Rows(y).Cells(4).Text
                            .Style = dgView.Rows(y).Cells(5).Text
                            .Item = dgView.Rows(y).Cells(6).Text
                            .Brand = dgView.Rows(y).Cells(7).Text
                            .Sizes = dgView.Rows(y).Cells(9).Text
                            .TotalSizeQty = dgView.Rows(y).Cells(8).Text
                            .StitchingBit = 1
                            .CreationDate = txtCreationDate.Text
                            .Userid = lUserid
                            .Save()
                        End With
                        With ObjTFAWashing
                            .TFAWashingid = 0
                            .StyleAssortmentBarCodeDetailID = lblStyleAssortmentBarCodeDetailID.Text
                            .Joborderid = lblJoborderid.Text
                            .JoborderDetailid = lblJoborderDetailid.Text
                            .StyleAssortmentMasterID = lblStyleAssortmentMasterID.Text
                            .SizeRangeID = lblSizeRangeID.Text
                            .SizeDatabaseID = lblSizeDatabaseID.Text
                            .Code = dgView.Rows(y).Cells(1).Text
                            .Merchandiser = dgView.Rows(y).Cells(2).Text
                            .JobNo = dgView.Rows(y).Cells(3).Text
                            .TotalOrderQty = dgView.Rows(y).Cells(4).Text
                            .Style = dgView.Rows(y).Cells(5).Text
                            .Item = dgView.Rows(y).Cells(6).Text
                            .Brand = dgView.Rows(y).Cells(7).Text
                            .Sizes = dgView.Rows(y).Cells(9).Text
                            .TotalSizeQty = dgView.Rows(y).Cells(8).Text
                            .WashingBit = 1
                            .CreationDate = txtCreationDate.Text
                            .Userid = lUserid
                            .Save()
                        End With
                        y = (y + 1)
                    Next
                    lblmsg.Text = "Successfully Saved "
                    dgView.Visible = True
                    dtDetail = Session("dtDetail")
                    Dim objDataview As New DataView(dtDetail)
                    dgView.DataSource = objDataview
                    dgView.DataBind()
                    Dim x As Integer
                    lblScanedPcs.Text = ""
                    Dim totalStyleCount As New DataTable
                    Dim TotalRows As Decimal = 0
                    For x = 0 To dgView.Rows.Count - 1
                        lblScanedPcs.Text = TotalRows
                        lblJobNo.Text = dgView.Rows(x).Cells(3).Text
                        LalblStyle.Text = dgView.Rows(x).Cells(5).Text
                        lblStyleQty.Text = dgView.Rows(x).Cells(4).Text
                        Dim size As String = ""
                        size = dgView.Rows(x).Cells(9).Text
                        totalStyleCount = ObjTFAStitching.GetTotalScanedbyJOBstyleSizeTFAStitching(lblJobNo.Text, LalblStyle.Text, size)
                        If totalStyleCount.Rows.Count = 1 Then
                            TotalRows = 1
                        Else
                            TotalRows = totalStyleCount.Rows.Count
                        End If
                        lblScanedPcs.Text = TotalRows
                    Next
                    txtBarcodee.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnSAVEData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSAVEData.Click
        Try
            Dim x As Integer
            Dim row As GridViewRow
            For Each row In dgView.Rows
                Dim lblStyleAssortmentBarCodeDetailID As Label = CType(row.FindControl("lblStyleAssortmentBarCodeDetailID"), Label)
                Dim lblJoborderid As Label = CType(row.FindControl("lblJoborderid"), Label)
                Dim lblJoborderDetailid As Label = CType(row.FindControl("lblJoborderDetailid"), Label)
                Dim lblStyleAssortmentMasterID As Label = CType(row.FindControl("lblStyleAssortmentMasterID"), Label)
                Dim lblSizeRangeID As Label = CType(row.FindControl("lblSizeRangeID"), Label)
                Dim lblSizeDatabaseID As Label = CType(row.FindControl("lblSizeDatabaseID"), Label)
                With ObjTFAStitching
                    .TFAStitchingid = 0
                    .StyleAssortmentBarCodeDetailID = lblStyleAssortmentBarCodeDetailID.Text
                    .Joborderid = lblJoborderid.Text
                    .JoborderDetailid = lblJoborderDetailid.Text
                    .StyleAssortmentMasterID = lblStyleAssortmentMasterID.Text
                    .SizeRangeID = lblSizeRangeID.Text
                    .SizeDatabaseID = lblSizeDatabaseID.Text
                    .Code = dgView.Rows(x).Cells(1).Text
                    .Merchandiser = dgView.Rows(x).Cells(2).Text
                    .JobNo = dgView.Rows(x).Cells(3).Text
                    .TotalOrderQty = dgView.Rows(x).Cells(4).Text
                    .Style = dgView.Rows(x).Cells(5).Text
                    .Item = dgView.Rows(x).Cells(6).Text
                    .Brand = dgView.Rows(x).Cells(7).Text
                    .Sizes = dgView.Rows(x).Cells(9).Text
                    .TotalSizeQty = dgView.Rows(x).Cells(8).Text
                    .StitchingBit = 1
                    .CreationDate = txtCreationDate.Text
                    .Save()
                End With
                x = (x + 1)
            Next
            lblmsg.Text = "Successfully Saved "
            Session("dtDetail") = Nothing
            dgView.Visible = True
            dtDetail = Session("dtDetail")
            Dim objDataview As New DataView(dtDetail)
            dgView.DataSource = objDataview
            dgView.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class
