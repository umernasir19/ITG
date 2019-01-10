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
Public Class FinishingManual
    Inherits System.Web.UI.Page
    Dim dr As DataRow
    Dim objDataView As DataView
    Dim dtdata, dtDetail As New DataTable
    Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
    Dim objAutoComplete As New AutoComplete
    Dim ObjTFAStitching As New TFAStitching
    Dim ObjTFAWashing As New TFAWashing
    Dim ObjTFAFinishing As New TFAFinishing
    Dim lUserid As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lUserid = Session("UserId")
        If Not Page.IsPostBack Then
            txtBarcode.Focus()
            txtCreationDate.Text = Date.Now
            Session("dtDetailF") = Nothing
        End If
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtDetailF"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetailF")
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
        dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcode.Text)
        If dtdata.Rows.Count > 0 Then
            dr = dtDetail.NewRow()
            dr("StyleAssortmentBarCodeDetailID") = dtdata.Rows(0)("StyleAssortmentBarCodeDetailID").ToString
            dr("Joborderid") = dtdata.Rows(0)("Joborderid").ToString
            dr("JoborderDetailid") = dtdata.Rows(0)("JoborderDetailid").ToString
            dr("Merchandiser") = dtdata.Rows(0)("Merchandiser").ToString
            dr("JobNo") = dtdata.Rows(0)("SRNo").ToString
            dr("Style") = dtdata.Rows(0)("Style").ToString
            dr("Item") = dtdata.Rows(0)("Item").ToString
            dr("Brand") = dtdata.Rows(0)("Brand").ToString
            dtDetail.Rows.Add(dr)
        End If
        Session("dtDetailF") = dtDetail
        BindGrid()
    End Sub
    Sub clear()
        txtBarcode.Text = ""
    End Sub
    Private Sub BindGrid()
        dtDetail = Session("dtDetailF")
        Dim objDataview As New DataView(dtDetail)
        dgView.DataSource = objDataview
        dgView.DataBind()
    End Sub
    Protected Sub txtBarcode_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged
        Try
            If txtCreationDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date.")
            Else
                Session("dtDetailF") = Nothing
                dgView.Visible = True
                dtDetail = Session("dtDetailF")
                dgView.DataSource = dtDetail
                dgView.DataBind()
                lblmsg.Text = ""
                Dim dtCheckFromDd As New DataTable
                dtCheckFromDd = ObjTFAStitching.GetFinishingData(txtBarcode.Text)
                If dtCheckFromDd.Rows.Count > 0 Then
                    txtBarcode.Text = ""
                    txtBarcode.Focus()
                    lblmsg.Text = "Already Scanned"
                    lblScanedPcs.Text = ""
                    System.Web.UI.ScriptManager.RegisterStartupScript(Me, [GetType](), "check_Javascript", "doJavaScript();", True)
                Else
                    Dim dtcheckStyleChange As New DataTable
                    dtcheckStyleChange = ObjTFAStitching.ChkDataStyle(txtBarcode.Text)
                    Dim ChkStyle As String = ""
                    ChkStyle = dtcheckStyleChange.Rows(0)("Style").ToString
                    If LalblStyle.Text = "" Then
                        lblmsg.Text = ""
                        objAutoComplete.GetValueF(txtBarcode.Text, lblmsg, dgView, txtBarcode)
                    Else
                        lblmsg.Text = ""
                        objAutoComplete.GetValueF(txtBarcode.Text, lblmsg, dgView, txtBarcode)
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
                        With ObjTFAFinishing
                            .TFAFinishingid = 0
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
                            .FinishingBit = 1
                            .CreationDate = txtCreationDate.Text
                            .Userid = lUserid
                            .Save()
                        End With
                        y = (y + 1)
                    Next
                    lblmsg.Text = "Successfully Saved "
                    dgView.Visible = True
                    dtDetail = Session("dtDetailF")
                    Dim objDataview As New DataView(dtDetail)
                    dgView.DataSource = objDataview
                    dgView.DataBind()
                    lblCounter.Text = Val(lblCounter.Text) + 1
                End If
                Dim x As Integer
                lblScanedPcs.Text = ""
                Dim TotalRows As Decimal = 0
                Dim totalStyleCount As New DataTable
                For x = 0 To dgView.Rows.Count - 1
                    TotalRows = TotalRows + 1
                    lblScanedPcs.Text = TotalRows
                    lblJobNo.Text = dgView.Rows(x).Cells(3).Text
                    LalblStyle.Text = dgView.Rows(x).Cells(5).Text
                    lblStyleQty.Text = dgView.Rows(x).Cells(4).Text
                    Dim size As String = ""
                    size = dgView.Rows(x).Cells(9).Text
                    totalStyleCount = ObjTFAFinishing.GetTotalScanedbyJOBstyleSizeTFAFinishing(lblJobNo.Text, LalblStyle.Text, size)
                    If totalStyleCount.Rows.Count = 1 Then
                        TotalRows = 1
                    Else
                        TotalRows = totalStyleCount.Rows.Count
                    End If
                    lblScanedPcs.Text = TotalRows
                Next
            End If
            txtBarcode.Focus()
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
                With ObjTFAFinishing
                    .TFAFinishingid = 0
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
                    .CreationDate = txtCreationDate.Text
                    .FinishingBit = 1
                    .Save()
                End With
                x = (x + 1)
            Next
            lblmsg.Text = "Successfully Saved "
            Session("dtDetailF") = Nothing
            dgView.Visible = True
            dtDetail = Session("dtDetailF")
            Dim objDataview As New DataView(dtDetail)
            dgView.DataSource = objDataview
            dgView.DataBind()
            lblCounter.Text = Val(lblCounter.Text) + 1
        Catch ex As Exception
        End Try
    End Sub
End Class


