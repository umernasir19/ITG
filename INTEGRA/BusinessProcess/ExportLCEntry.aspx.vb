Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Public Class ExportLCEntry
    Inherits System.Web.UI.Page
    Dim dtDetail As New DataTable
    Dim Dr As DataRow
    Dim lLCExportMstID As Long
    Dim objGeneralCode As New GeneralCode
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim ObjLCExportMst As New LCExportMst
    Dim ObjLCExportDtl As New LCExportDtl
    Dim objDPFabricDbMst As New DPFabricDbMst
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lLCExportMstID = Request.QueryString("LCExportMstID")
        If Not Page.IsPostBack Then
            Session("dtDetail") = Nothing
            BindCustomer()
            If lLCExportMstID > 0 Then
                btnSave.Text = "Update"
                Edit()
                btnSave.Visible = True
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub BindCustomer()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = objDPFabricDbMst.GetLCCustomer
            CMBCUSTOMER.DataSource = dtcmbSeason
            CMBCUSTOMER.DataTextField = "CustomerName"
            CMBCUSTOMER.DataValueField = "CustomerId"
            CMBCUSTOMER.DataBind()
            CMBCUSTOMER.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub CMBCUSTOMER_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles CMBCUSTOMER.SelectedIndexChanged
        Dim dtcmbSeason As DataTable
        dtcmbSeason = objDPFabricDbMst.GetLCSeason(CMBCUSTOMER.SelectedValue)
        cmbSeason.DataSource = dtcmbSeason
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
        cmbSeason.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Dim dtCustomer As DataTable = objDPFabricDbMst.GetLCCustomerNamee(CMBCUSTOMER.SelectedValue)
        If dtCustomer.Rows.Count > 0 Then
            TXTNEGOTIATINGBANK.Text = dtCustomer.Rows(0)("BuyerBankName")
        End If
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSeason.SelectedIndexChanged
        Dim dtcmbSeason As DataTable
        dtcmbSeason = objDPFabricDbMst.GetLCSRNO(CMBCUSTOMER.SelectedValue, cmbSeason.SelectedValue)
        cmbSrNo.DataSource = dtcmbSeason
        cmbSrNo.DataTextField = "SRNO"
        cmbSrNo.DataValueField = "Joborderid"
        cmbSrNo.DataBind()
        cmbSrNo.Items.Insert(0, New RadComboBoxItem("Select", 0))
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSrNo.SelectedIndexChanged
        Dim dt As DataTable
        dt = objDPFabricDbMst.GetLCPINOO(cmbSeason.SelectedValue, CMBCUSTOMER.SelectedValue, cmbSrNo.SelectedValue)
        cmbPINo.DataSource = dt
        cmbPINo.DataTextField = "SalesContract"
        cmbPINo.DataValueField = "DPIMstID"
        cmbPINo.DataBind()
        cmbPINo.Items.Insert(0, New RadComboBoxItem("Select", 0))
    End Sub
    Protected Sub cmbPINo_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbPINo.SelectedIndexChanged
        Try
            If txtLCNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill LC No")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub Edit()
        Dim DT As DataTable = objDPFabricDbMst.GetEditForExportLc(lLCExportMstID)
        If DT.Rows.Count > 0 Then
            cmbPINo.SelectedValue = DT.Rows(0)("PIID")
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("LCExportDtlID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("SeasonDatabaseID", GetType(String))
                .Columns.Add("CurrencyID", GetType(String))
                .Columns.Add("CustomerID", GetType(String))
                .Columns.Add("PaymentTermID", GetType(String))
                .Columns.Add("DPIDtlID", GetType(String))
                .Columns.Add("Season", GetType(String))
                .Columns.Add("SRNo", GetType(String))
                .Columns.Add("Buyer", GetType(String))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("OrderNo", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ShipmentDate", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("ShipmentQty", GetType(String))
                .Columns.Add("BalanceQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("salescontractno", GetType(String))
                .Columns.Add("salesContractQty", GetType(String))
                .Columns.Add("SalesContractAmount", GetType(String))
                .Columns.Add("Paymentterm", GetType(String))
                .Columns.Add("Currency", GetType(String))
                .Columns.Add("LCNo", GetType(String))
                .Columns.Add("LCAmount", GetType(String))
                .Columns.Add("SendDate", GetType(String))
                .Columns.Add("RecvDate", GetType(String))
                .Columns.Add("ShipDate", GetType(String))
                .Columns.Add("AmdDate", GetType(String))
                .Columns.Add("NegotiateBank", GetType(String))
                .Columns.Add("IssueBank", GetType(String))
                .Columns.Add("IssueRemarks", GetType(String))
            End With
            Dim x As Integer
            For x = 0 To DT.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("LCExportDtlID") = DT.Rows(x)("LCExportDtlID")
                Dr("Joborderid") = DT.Rows(x)("Joborderid")
                Dr("JoborderDetailid") = DT.Rows(x)("JoborderDetailid")
                Dr("SeasonDatabaseID") = DT.Rows(x)("SeasonDatabaseID")
                Dr("CurrencyID") = DT.Rows(x)("CurrencyID")
                Dr("PaymentTermID") = DT.Rows(x)("PaymentTermID")
                Dr("DPIDtlID") = DT.Rows(x)("DPIDtlID")
                Dr("CustomerID") = DT.Rows(x)("CustomerID")
                Dr("Season") = DT.Rows(x)("SeasonName")
                Dr("SRNo") = DT.Rows(x)("SRNo")
                Dr("Buyer") = DT.Rows(x)("CustomerName")
                Dr("StyleNo") = DT.Rows(x)("StyleNo")
                Dr("OrderNo") = DT.Rows(x)("OrderNo")
                Dr("Description") = DT.Rows(x)("Description")
                Dr("ShipmentDate") = DT.Rows(x)("ShipmentDate")
                Dr("OrderQty") = DT.Rows(x)("OrderQty")
                Dr("ShipmentQty") = DT.Rows(x)("ShipmentQty")
                Dr("BalanceQty") = DT.Rows(x)("BalanceQty")
                Dr("Remarks") = DT.Rows(x)("Remarks")
                Dr("salescontractno") = DT.Rows(x)("salescontractNO")
                Dr("salesContractQty") = DT.Rows(x)("salesContractQty")
                Dr("SalesContractAmount") = DT.Rows(x)("SalesContractAmount")
                Dr("Paymentterm") = DT.Rows(x)("PaymentTerm")
                Dr("Currency") = DT.Rows(x)("CurrencyName")
                Dr("LCNo") = DT.Rows(x)("LCNo")
                Dr("LCAmount") = DT.Rows(x)("LCAmount")
                Dr("SendDate") = DT.Rows(x)("PISendDatee")
                Dr("RecvDate") = DT.Rows(x)("LCRecvDatee")
                Dr("ShipDate") = DT.Rows(x)("LCShipDatee")
                Dr("AmdDate") = DT.Rows(x)("LCAmdDatee")
                Dr("NegotiateBank") = DT.Rows(x)("NegotiateBank")
                Dr("IssueBank") = DT.Rows(x)("IssueBank")
                Dr("IssueRemarks") = DT.Rows(x)("IssueRemarks")
                dtDetail.Rows.Add(Dr)
                Session("dtDetail") = dtDetail
            Next
            BindGridEdit()
        End If

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("ExportLCView.aspx")
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            save()
            SaveDetail()
            Response.Redirect("ExportLCView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession()
        Dim dt As DataTable
        dt = ObjLCExportMst.GetDataNew(cmbPINo.SelectedValue)
        If dt.Rows.Count > 0 Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
            If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
                dtDetail = Session("dtDetail")
            Else
                dtDetail = New DataTable
                With dtDetail
                    .Columns.Add("LCExportDtlID", GetType(Long))
                    .Columns.Add("Joborderid", GetType(Long))
                    .Columns.Add("JoborderDetailid", GetType(String))
                    .Columns.Add("SeasonDatabaseID", GetType(String))
                    .Columns.Add("CurrencyID", GetType(String))
                    .Columns.Add("CustomerID", GetType(String))
                    .Columns.Add("PaymentTermID", GetType(String))
                    .Columns.Add("DPIDtlID", GetType(String))
                    .Columns.Add("Season", GetType(String))
                    .Columns.Add("SRNo", GetType(String))
                    .Columns.Add("Buyer", GetType(String))
                    .Columns.Add("StyleNo", GetType(String))
                    .Columns.Add("OrderNo", GetType(String))
                    .Columns.Add("Description", GetType(String))
                    .Columns.Add("ShipmentDate", GetType(String))
                    .Columns.Add("OrderQty", GetType(String))
                    .Columns.Add("ShipmentQty", GetType(String))
                    .Columns.Add("BalanceQty", GetType(String))
                    .Columns.Add("Remarks", GetType(String))
                    .Columns.Add("salescontractno", GetType(String))
                    .Columns.Add("salesContractQty", GetType(String))
                    .Columns.Add("SalesContractAmount", GetType(String))
                    .Columns.Add("Paymentterm", GetType(String))
                    .Columns.Add("Currency", GetType(String))
                    .Columns.Add("LCNo", GetType(String))
                    .Columns.Add("LCAmount", GetType(String))
                    .Columns.Add("SendDate", GetType(String))
                    .Columns.Add("RecvDate", GetType(String))
                    .Columns.Add("ShipDate", GetType(String))
                    .Columns.Add("AmdDate", GetType(String))
                    .Columns.Add("NegotiateBank", GetType(String))
                    .Columns.Add("IssueBank", GetType(String))
                    .Columns.Add("IssueRemarks", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                Dr = dtDetail.NewRow()
                Dr("LCExportDtlID") = 0
                Dr("Joborderid") = dt.Rows(x)("Joborderid")
                Dr("JoborderDetailid") = dt.Rows(x)("JoborderDetailid")
                Dr("SeasonDatabaseID") = dt.Rows(x)("SeasonDatabaseID")
                Dr("CurrencyID") = dt.Rows(x)("CurrencyID")
                Dr("PaymentTermID") = dt.Rows(x)("PaymentTermID")
                Dr("DPIDtlID") = dt.Rows(x)("DPIDtlID")
                Dr("CustomerID") = dt.Rows(x)("CustomerID")
                Dr("Season") = dt.Rows(x)("SeasonName")
                Dr("SRNo") = dt.Rows(x)("SRNo")
                Dr("Buyer") = dt.Rows(x)("CustomerName")
                Dr("StyleNo") = dt.Rows(x)("Style")
                Dr("OrderNo") = dt.Rows(x)("CustomerOrder")
                Dr("Description") = dt.Rows(x)("ItemDesc")
                Dr("ShipmentDate") = dt.Rows(x)("ShipmentDatee")
                Dr("OrderQty") = dt.Rows(x)("Quantity")
                Dr("ShipmentQty") = dt.Rows(x)("ShipQty")
                Dr("BalanceQty") = Val(dt.Rows(x)("Quantity")) - Val(dt.Rows(x)("ShipQty"))
                Dr("Remarks") = "N/A"
                Dr("salescontractno") = dt.Rows(x)("salescontract")
                Dr("salesContractQty") = 0
                Dr("SalesContractAmount") = 0
                Dr("Paymentterm") = dt.Rows(x)("PaymentTerm")
                Dr("Currency") = dt.Rows(x)("CurrencyName")
                Dr("LCNo") = txtLCNo.Text
                If txtLCAmountt.Text = "" Then
                    Dr("LCAmount") = 0
                Else
                    Dr("LCAmount") = txtLCAmountt.Text
                End If
                If txtLCISSUEDATE.SelectedDate.ToString = "" Then
                    Dr("SendDate") = "01/01/1900"
                Else
                    Dr("SendDate") = txtLCISSUEDATE.SelectedDate.Value.ToString("dd/MM/yyyy")
                End If
                If txtLCRECEIVEDATE.SelectedDate.ToString = "" Then
                    Dr("RecvDate") = "01/01/1900"
                Else
                    Dr("RecvDate") = txtLCRECEIVEDATE.SelectedDate.Value.ToString("dd/MM/yyyy")
                End If
                If txtLCSHIPMENTDATE.SelectedDate.ToString = "" Then
                    Dr("ShipDate") = "01/01/1900"
                Else
                    Dr("ShipDate") = txtLCSHIPMENTDATE.SelectedDate.Value.ToString("dd/MM/yyyy")
                End If
                If txtLCAMMENDMENTDATE.SelectedDate.ToString = "" Then
                    Dr("AmdDate") = "01/01/1900"
                Else
                    Dr("AmdDate") = txtLCAMMENDMENTDATE.SelectedDate.Value.ToString("dd/MM/yyyy")
                End If
                If TXTNEGOTIATINGBANK.Text = "" Then
                    Dr("NegotiateBank") = ""
                Else
                    Dr("NegotiateBank") = TXTNEGOTIATINGBANK.Text
                End If
                If TXTISSUINGBANK.Text = "" Then
                    Dr("IssueBank") = ""
                Else
                    Dr("IssueBank") = TXTISSUINGBANK.Text
                End If
                If TXTREMARKS.Text = "" Then
                    Dr("IssueRemarks") = ""
                Else
                    Dr("IssueRemarks") = TXTREMARKS.Text
                End If
                dtDetail.Rows.Add(Dr)
            Next
            Session("dtDetail") = dtDetail
            BindGrid()
            btnSave.Visible = True
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Data Exist")
            Session("dtDetail") = Nothing
            dgExportLCDetail.Visible = False
        End If
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgExportLCDetail.Visible = True
                dgExportLCDetail.RecordCount = objDatatble.Rows.Count
                dgExportLCDetail.DataSource = objDatatble
                dgExportLCDetail.DataBind()
                Dim x As Integer
                For x = 0 To dgExportLCDetail.Items.Count - 1
                    If dgExportLCDetail.Items(x).Cells(26).Text = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(26).Text = ""
                    End If
                    If dgExportLCDetail.Items(x).Cells(27).Text = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(27).Text = ""
                    End If
                    If dgExportLCDetail.Items(x).Cells(28).Text = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(28).Text = ""
                    End If
                    If dgExportLCDetail.Items(x).Cells(29).Text = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(29).Text = ""
                    End If
                Next
            Else
                dgExportLCDetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGridEdit()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtDetail")
            If objDatatble.Rows.Count > 0 Then
                dgExportLCDetail.Visible = True
                dgExportLCDetail.RecordCount = objDatatble.Rows.Count
                dgExportLCDetail.DataSource = objDatatble
                dgExportLCDetail.DataBind()
                Dim x As Integer
                For x = 0 To dgExportLCDetail.Items.Count - 1
                    If objDatatble.Rows(x)("SendDate") = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(26).Text = ""
                    End If
                    If objDatatble.Rows(x)("RecvDate") = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(27).Text = ""
                    End If
                    If objDatatble.Rows(x)("ShipDate") = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(28).Text = ""
                    End If
                    If objDatatble.Rows(x)("AmdDate") = "01/01/1900" Then
                        dgExportLCDetail.Items(x).Cells(29).Text = ""
                    End If
                Next
            Else
                dgExportLCDetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub save()
        Try
            With ObjLCExportMst
                If lLCExportMstID > 0 Then
                    .LCExportMstID = lLCExportMstID
                Else
                    .LCExportMstID = 0
                End If
                .PIID = cmbPINo.SelectedValue
                .CreationDate = Date.Now
                .saveMst()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveDetail()
        Try
            Dim x As Integer
            For x = 0 To dgExportLCDetail.Items.Count - 1
                With ObjLCExportDtl

                    .LCExportDtlID = dgExportLCDetail.Items(x).Cells(0).Text
                    If lLCExportMstID > 0 Then
                        .LCExportMstID = lLCExportMstID
                    Else
                        .LCExportMstID = ObjLCExportMst.GetID()
                    End If
                    .Joborderid = dgExportLCDetail.Items(x).Cells(1).Text
                    .JoborderDetailid = dgExportLCDetail.Items(x).Cells(2).Text
                    .SeasonDatabaseID = dgExportLCDetail.Items(x).Cells(3).Text
                    .DPIDtlID = dgExportLCDetail.Items(x).Cells(4).Text
                    .CurrencyID = dgExportLCDetail.Items(x).Cells(5).Text
                    .PaymentTermID = dgExportLCDetail.Items(x).Cells(6).Text
                    .CustomerID = dgExportLCDetail.Items(x).Cells(7).Text
                    .SRNo = dgExportLCDetail.Items(x).Cells(9).Text
                    .StyleNo = dgExportLCDetail.Items(x).Cells(11).Text
                    .OrderNo = dgExportLCDetail.Items(x).Cells(12).Text
                    .Description = dgExportLCDetail.Items(x).Cells(13).Text
                    .ShipmentDate = dgExportLCDetail.Items(x).Cells(14).Text
                    .OrderQty = dgExportLCDetail.Items(x).Cells(15).Text
                    .ShipmentQty = dgExportLCDetail.Items(x).Cells(16).Text
                    .BalanceQty = dgExportLCDetail.Items(x).Cells(17).Text
                    .Remarks = dgExportLCDetail.Items(x).Cells(18).Text
                    .salescontractno = dgExportLCDetail.Items(x).Cells(19).Text
                    .salesContractQty = dgExportLCDetail.Items(x).Cells(20).Text
                    .SalesContractAmount = dgExportLCDetail.Items(x).Cells(21).Text
                    .LCNo = dgExportLCDetail.Items(x).Cells(24).Text
                    .LCAmount = dgExportLCDetail.Items(x).Cells(25).Text
                    If dgExportLCDetail.Items(x).Cells(26).Text = "" Then
                        .PISendDate = "01/01/1900"
                    Else
                        .PISendDate = dgExportLCDetail.Items(x).Cells(26).Text
                    End If
                    If dgExportLCDetail.Items(x).Cells(27).Text = "" Then
                        .LCRecvDate = "01/01/1900"
                    Else
                        .LCRecvDate = dgExportLCDetail.Items(x).Cells(27).Text
                    End If
                    If dgExportLCDetail.Items(x).Cells(28).Text = "" Then
                        .LCShipDate = "01/01/1900"
                    Else
                        .LCShipDate = dgExportLCDetail.Items(x).Cells(28).Text
                    End If
                    If dgExportLCDetail.Items(x).Cells(29).Text = "" Then
                        .LCAmdDate = "01/01/1900"
                    Else
                        .LCAmdDate = dgExportLCDetail.Items(x).Cells(29).Text
                    End If
                    .NegotiateBank = dgExportLCDetail.Items(x).Cells(30).Text.Replace("&nbsp;", "")
                    .IssueBank = dgExportLCDetail.Items(x).Cells(31).Text.Replace("&nbsp;", "")
                    .IssueRemarks = dgExportLCDetail.Items(x).Cells(32).Text.Replace("&nbsp;", "")
                    .saveDtl()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgExportLCDetail_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgExportLCDetail.ItemCommand
        Select Case e.CommandName
        End Select
    End Sub
End Class