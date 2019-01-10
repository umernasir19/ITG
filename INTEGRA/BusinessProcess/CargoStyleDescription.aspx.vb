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
Public Class CargoStyleDescription
    Inherits System.Web.UI.Page
    Dim objBIInstMst As New BIInstMst
    Dim Dr As DataRow
    Dim dt As DataTable
    Dim lBIInstMstid As Long
    Dim ObjBIInstDtl As New BIInstDtl
    Dim ICargoID As Long
    Dim objCargoStyleDtl As New CargoStyleDtl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ICargoID = Request.QueryString("cargoID")
        If Not Page.IsPostBack Then
            Dim dtt As DataTable = objBIInstMst.GetInvoiceNo(ICargoID)
            txtInvoiceNO.Text = dtt.Rows(0)("InvoiceNo")
            Dim dt As DataTable = objBIInstMst.GetDatafrmCargoOnEdit(ICargoID)
            If dt.Rows.Count > 0 Then
                BindGrid2()
            Else
                BindGrid()
            End If
        End If
    End Sub
    Sub SaveDetail()
        With objCargoStyleDtl
            Dim a As Integer = 0
            For a = 0 To dgDetail.Items.Count - 1
                Dim txtDesc As TextBox = DirectCast(dgDetail.Items(a).FindControl("txtDesc"), TextBox)
                .CargoStyleDtlID = dgDetail.Items(a).Cells(0).Text
                .CargoID = ICargoID
                .Style = dgDetail.Items(a).Cells(1).Text
                .Desc = txtDesc.Text
                .PCS = dgDetail.Items(a).Cells(3).Text
                .Save()
            Next
        End With
    End Sub
    Sub BindGrid2()
        Try
            Dim dt As DataTable = objBIInstMst.GetDatafrmCargoOnEdit(ICargoID)
            If (Not dt Is Nothing) Then
                If (dt.Rows.Count > 0) Then
                    dgDetail.DataSource = dt
                    dgDetail.RecordCount = dt.Rows.Count
                    dgDetail.DataBind()
                    dgDetail.Visible = True
                    Dim x As Integer
                    For x = 0 To dgDetail.Items.Count - 1
                        Dim txtDesc As TextBox = CType(dgDetail.Items(x).FindControl("txtDesc"), TextBox)
                        txtDesc.Text = dt.Rows(x)("Desc")
                        Next
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindGrid()
        Try
            Dim dt As DataTable = objBIInstMst.GetDatafrmCargoToStyleDes(ICargoID)
            If (Not dt Is Nothing) Then
                If (dt.Rows.Count > 0) Then
                    dgDetail.DataSource = dt
                    dgDetail.RecordCount = dt.Rows.Count
                    dgDetail.DataBind()
                    dgDetail.Visible = True
                  End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            SaveDetail()
            Response.Redirect("CargoReleaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CargoReleaseView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class