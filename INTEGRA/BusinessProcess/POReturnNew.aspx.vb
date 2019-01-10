Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.Net
Imports System.Net.Mail
Public Class POReturnNew
    Inherits System.Web.UI.Page
    Dim lPOID, lPODetailID, lPORecvMasterID, lPORecvDetailID, luserid, lItemID, userid As Long
    Dim ObjFPOReturn As New PoReturnClass
    Dim ObjIMSStoreLedger As New IMSStoreLedger
    Dim ObjIssue As New IssueMst
    Dim objGeneralCode As New GeneralCode
    Dim objPORecvDetail As New PORecvDetail
    Dim objPORecvMaster As New PORecvMaster
    Dim PORecvMasterID As Long
    Dim dr As DataRow
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim DtYarnPCDetail As New DataTable
    Dim objDataView As DataView
    Dim PageName As String
    Dim ObjLocation As New Location
    Dim objPORecvDetailHistory As New PORecvDetailHistory
    Dim dtRecvDetail, dtPurchaseOrder, dtStyle As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageName = Request.QueryString("PageName")
        PORecvMasterID = Request.QueryString("PORecvMasterID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            BindParty()
            BindPO(0)
            BindItem()
            BindLocation()
            BindSeason()
            BindSrNo()
            Session("dtRecvDetail") = Nothing
            Session("objDataView") = Nothing
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                lblFabItem.Text = "Fabric :"
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    lblFabItem.Text = "Fabric :"

                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    lblFabItem.Text = "Item :"

                End If
            End If
            GetMasterData()
            GetDetailData()
            btnSave.Visible = "true"
            btnCancel.Visible = "true"
            txtPOReceiveDate.Text = Date.Today
        End If
        PageHeader("PO RETURN ENTRY FORM")
    End Sub
    Sub GetMasterData()
        Try
            Dim dt As DataTable
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt = objPORecvMaster.GetEditNew(PORecvMasterID)
            Else
                dt = objPORecvMaster.GetEditNewForAstore(PORecvMasterID)
            End If
            If dt.Rows(0)("SeasonDatabaseId") <> 0 Then
                CMBSeason.SelectedValue = dt.Rows(0)("SeasonDatabaseId")
            End If
            If dt.Rows(0)("JobOrderId") <> 0 Then
                CMBSrNo.SelectedValue = dt.Rows(0)("JobOrderId")
            End If
            txtPOReceiveDate.Text = dt.Rows(0)("PORecvDate")
            txtIGPNo.Text = dt.Rows(0)("GatePassNo")
            txtpartDCNo.Text = dt.Rows(0)("PartyDCNo")
            BindParty()
            cmbPartyname.SelectedValue = dt.Rows(0)("SupplierID")
            cmbPartyname.SelectedItem.Text = dt.Rows(0)("SupplierName")
            BindPO(0)
            cmbPONo.SelectedValue = dt.Rows(0)("Poidd")
            BindItem()
            lblAuditorStatus.Text = dt.Rows(0)("AuditorStatus")
            lblAuditorID.Text = dt.Rows(0)("AuditorID")
            cmbFabric.SelectedItem.Text = dt.Rows(0)("FabricRecv")
            cmbFabric.SelectedValue = dt.Rows(0)("PoDetailId")
            Dim dtt As DataTable = objPORecvMaster.GetDeliveryDate(cmbFabric.SelectedValue, cmbPONo.SelectedValue, cmbPartyname.SelectedValue)
            txtDeliveryDate.Text = dtt.Rows(0)("DeliveryDate")
            txtTotalQty.Text = dtt.Rows(0)("Quantity")
            Dim objDataTable As DataTable = objPORecvMaster.GETGridDATANew2ForEdit(cmbPONo.SelectedValue, cmbPartyname.SelectedValue, cmbFabric.SelectedValue, PORecvMasterID)
            cmbStyle.DataSource = objDataTable
            cmbStyle.DataTextField = "Style"
            cmbStyle.DataValueField = "POID"
            cmbStyle.DataBind()
            cmbStyle.SelectedItem.Text = dt.Rows(0)("Style")
            BindLocation()
            cmbLocation.SelectedValue = dt.Rows(0)("LocationID")
        Catch ex As Exception
        End Try
    End Sub
    Sub GetDetailData()
        Dim dtEdit As DataTable = objPORecvMaster.CheckEditDataForReturn(PORecvMasterID)
        If dtEdit.Rows.Count > 0 Then
            Dim dt As DataTable = objPORecvMaster.CheckEditDataForReturnEdit(PORecvMasterID)
            dgPORecDetail.DataSource = dt
            dgPORecDetail.DataBind()
            For x = 0 To dgPORecDetail.Items.Count - 1
                Dim txtReturnQty As TextBox = CType(dgPORecDetail.Items(x).FindControl("txtReturnQty"), TextBox)
                Dim txtDcNo As TextBox = CType(dgPORecDetail.Items(x).FindControl("txtDcNo"), TextBox)
                Dim TXTRemarks As TextBox = CType(dgPORecDetail.Items(x).FindControl("TXTRemarks"), TextBox)
                txtReturnQty.Text = dt.Rows(x)("ReturnQty")
                txtDcNo.Text = dt.Rows(x)("DCNO")
                TXTRemarks.Text = dt.Rows(x)("ReturnRemarks")
            Next
        Else
            Dim dt As DataTable = objPORecvMaster.GetDataForReturn(PORecvMasterID)
            If dt.Rows.Count > 0 Then
                dgPORecDetail.DataSource = dt
                dgPORecDetail.DataBind()
                For x = 0 To dgPORecDetail.Items.Count - 1
                    Dim txtReturnQty As TextBox = CType(dgPORecDetail.Items(x).FindControl("txtReturnQty"), TextBox)
                    Dim txtDcNo As TextBox = CType(dgPORecDetail.Items(x).FindControl("txtDcNo"), TextBox)
                    Dim TXTRemarks As TextBox = CType(dgPORecDetail.Items(x).FindControl("TXTRemarks"), TextBox)
                    txtReturnQty.Text = dt.Rows(x)("ReturnQtyy")
                    txtDcNo.Text = dt.Rows(x)("DCNOO")
                    TXTRemarks.Text = dt.Rows(x)("ReturnRemarkss")
                Next
            End If
        End If
    End Sub
    Sub BindParty()
        Try
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim dt As DataTable
                dt = objPORecvMaster.BindSupplierForRecPOONew()
                cmbPartyname.DataSource = dt
                cmbPartyname.DataTextField = "SupplierName"
                cmbPartyname.DataValueField = "SupplierDatabaseid"
                cmbPartyname.DataBind()
                cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then

                Dim dt As DataTable
                dt = objPORecvMaster.BindSupplierForRecPOONewForAstore()
                cmbPartyname.DataSource = dt
                cmbPartyname.DataTextField = "SupplierName"
                cmbPartyname.DataValueField = "SupplierDatabaseid"
                cmbPartyname.DataBind()
                cmbPartyname.Items.Insert(0, New ListItem("Select", "0"))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindPO(ByVal SupplierID As Long)
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dtP As DataTable
            dtP = objPORecvMaster.BindPOSupNItemWiseDPEditNew(cmbPartyname.SelectedValue)
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "POJO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dtP As DataTable
            dtP = objPORecvMaster.BindPOSupNItemWiseDPEditNewForAcc(cmbPartyname.SelectedValue)
            cmbPONo.DataSource = dtP
            cmbPONo.DataTextField = "POJO"
            cmbPONo.DataValueField = "POID"
            cmbPONo.DataBind()
            cmbPONo.Items.Insert(0, New ListItem("Select", "0"))
        End If
    End Sub
    Protected Sub cmbPartyname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPartyname.SelectedIndexChanged
        Try

            BindPO(cmbPartyname.SelectedValue)

        Catch ex As Exception
        End Try
    End Sub
    Sub BindItem()
        Try

            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim dt As DataTable
                dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                cmbFabric.DataSource = dt
                cmbFabric.DataTextField = "ItemName"
                cmbFabric.DataValueField = "PODetailID"
                cmbFabric.DataBind()
                cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim dt As DataTable
                    dt = objPORecvMaster.BindItemFBDPNew(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                    cmbFabric.DataSource = dt
                    cmbFabric.DataTextField = "ItemName"
                    cmbFabric.DataValueField = "PODetailID"
                    cmbFabric.DataBind()
                    cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim dt As DataTable
                    dt = objPORecvMaster.BindItemFBDPNewForAcc(cmbPartyname.SelectedValue, cmbPONo.SelectedValue)
                    cmbFabric.DataSource = dt
                    cmbFabric.DataTextField = "ItemName"
                    cmbFabric.DataValueField = "PODetailID"
                    cmbFabric.DataBind()
                    cmbFabric.Items.Insert(0, New ListItem("Select", "0"))
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbPONo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPONo.SelectedIndexChanged
        Try
            
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSeason()
        Dim dt As DataTable = ObjIssue.GetSeasonFromIssue()
        CMBSeason.DataSource = dt
        CMBSeason.DataValueField = "SeasonDatabaseId"
        CMBSeason.DataTextField = "SeasonName"
        CMBSeason.DataBind()
        CMBSeason.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub BindSrNo()
        Dim dtt As DataTable = ObjIssue.GetSrNoFromIssueForAny()
        CMBSrNo.DataSource = dtt
        CMBSrNo.DataValueField = "JobOrderId"
        CMBSrNo.DataTextField = "SrNo"
        CMBSrNo.DataBind()
        CMBSrNo.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Protected Sub cmbFabric_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFabric.SelectedIndexChanged
        Try
            
        Catch ex As Exception
        End Try
    End Sub
    Sub BindLocation()
        Dim dt As DataTable
        dt = objPORecvMaster.BindLocation()
        cmbLocation.DataSource = dt
        cmbLocation.DataTextField = "Location"
        cmbLocation.DataValueField = "LocationId"
        cmbLocation.DataBind()
        cmbLocation.Items.Insert(0, New ListItem("Select", "0"))
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPORecDetail.PageIndexChanged

    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgPORecDetail.SortCommand

    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPORecDetail.ItemDataBound

    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("POReceiveViewNew.aspx")
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Save()
            Response.Redirect("POReceiveViewNew.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub Save()
        Try
            Dim x As Integer
            For x = 0 To dgPORecDetail.Items.Count - 1
                 Dim txtReturnQty As TextBox = CType(dgPORecDetail.Items(x).FindControl("txtReturnQty"), TextBox)
                Dim txtDcNo As TextBox = CType(dgPORecDetail.Items(x).FindControl("txtDcNo"), TextBox)
                Dim TXTRemarks As TextBox = CType(dgPORecDetail.Items(x).FindControl("TXTRemarks"), TextBox)
                With ObjFPOReturn
                    .POReturnId = dgPORecDetail.Items(x).Cells(0).Text
                    .PORecvMasterID = PORecvMasterID
                    .PORecvDetailID = dgPORecDetail.Items(x).Cells(1).Text
                    .PoDetailId = dgPORecDetail.Items(x).Cells(2).Text
                    .ItemID = dgPORecDetail.Items(x).Cells(3).Text
                    Dim dt As DataTable = objPORecvMaster.GetPOIDForReturn(PORecvMasterID)
                    .POID = dt.Rows(0)("POID")
                    .UserId = userid
                    .CreationDate = Date.Now
                    .ReturnDate = Date.Now
                    .ReturnQty = txtReturnQty.Text
                    .DCNO = txtDcNo.Text
                    .ReturnRemarks = TXTRemarks.Text
                    .Save()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtReturnQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            'For i As Integer = 0 To dgPORecDetail.Items.Count - 1
            '    Dim txtfreshQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtfreshQty"), TextBox)
            '    Dim txtBQualityQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtBQualityQty"), TextBox)
            '    Dim txtReceivedQty As TextBox = DirectCast(dgPORecDetail.Items(i).FindControl("txtReceivedQty"), TextBox)
            '    If txtfreshQty.Text = "" Then
            '        txtfreshQty.Text = 0
            '    End If
            '    If txtBQualityQty.Text = "" Then
            '        txtBQualityQty.Text = 0
            '    End If
            '    txtReceivedQty.Text = Val(txtfreshQty.Text) + Val(txtBQualityQty.Text)
            'Next
        Catch ex As Exception

        End Try
    End Sub
End Class







