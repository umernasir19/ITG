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
Public Class FabricIssueToDept
    Inherits System.Web.UI.Page
    Dim Dr As DataRow
    Dim objDPPoRecevMst As New DPPoRecevMst
    Dim objDPPoRecevDtl As New DPPoRecevDtl
    Dim ObjDPPOIssueMst As New DPPOIssueMst
    Dim ObjDPPOIssueDetail As New DPPOIssueDetail
    Dim ObjDPFabricIssue As New DPFabricIssue
    Dim lDPPOIssueMstID As Long
    Dim dtDPPOIssueDetail As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPPOIssueMstID = Request.QueryString("DPPOIssueMstID")
        If Not Page.IsPostBack Then
            Session("dtDPPOIssueDetail") = Nothing
            Dim timeZoneInfo As TimeZoneInfo
            Dim dateTime As DateTime
            'Set the time zone information to US Mountain Standard Time 
            ' timeZoneInfo = timeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time")
            'Get date and time in US Mountain Standard Time 
            ' dateTime = timeZoneInfo.ConvertTime(dateTime.Now, timeZoneInfo)
            ' Dim time As String = dateTime.ToLongTimeString()
            ' txtIssueTime.Text = time   ' DateTime.Now.ToLongTimeString()
            PakistanTimezoneNew()
            BindDept()
            GRNNoGenerateOnLoad()
            If lDPPOIssueMstID > 0 Then
                '  edit()
            Else
            End If

        End If
    End Sub
    Sub PakistanTimezoneNew()
        txtIssueTime.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub
    Sub BindDept()

        Dim dt As DataTable
        dt = ObjDPPOIssueMst.GetCmbFrom()
        CmbDept.DataSource = dt
        CmbDept.DataTextField = "DeptDatabaseName"
        CmbDept.DataValueField = "DeptDatabaseId"
        CmbDept.DataBind()
        CmbDept.Items.Insert(0, New RadComboBoxItem("Select", String.Empty))
    End Sub
    Sub GRNNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            ' Dim year As String = Voucherdate.Year
            ' Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = ObjDPPOIssueMst.GetLastNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                ' PreviousMonth = LastVoucherNo.Substring(7, 2)
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
            VoucherNo = "DFI" & "-" & LastCode
            txtIssueVoucherNo.Text = VoucherNo
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtDalNo_TextChanged(sender As Object, e As EventArgs) Handles txtDalNo.TextChanged
        Try
            Changedalno()
        Catch ex As Exception

        End Try
    End Sub
    Sub Changedalno()
        Dim dtFBData As DataTable = ObjDPFabricIssue.GetFBData(txtDalNo.Text)
        Dim dtFBRecv As DataTable = ObjDPFabricIssue.GetFBRcvQty(txtDalNo.Text)
        Dim dtFBIssue As DataTable = ObjDPFabricIssue.GetFBIssueQty(txtDalNo.Text)
        Dim dtDPFBIssue As DataTable = ObjDPFabricIssue.GetDPFBIssueQty(txtDalNo.Text)
        Dim FBRecv As Decimal = 0
        Dim FBIssue As Decimal = 0
        Dim DPFBIssue As Decimal = 0
        If dtFBRecv.Rows.Count > 0 Then
            FBRecv = dtFBRecv.Rows(0)("ReceiveQty")
        End If
        If dtFBIssue.Rows.Count > 0 Then
            FBIssue = dtFBIssue.Rows(0)("IssueQty")
        End If
        If dtDPFBIssue.Rows.Count > 0 Then
            DPFBIssue = dtDPFBIssue.Rows(0)("IssueQty")
        End If
        If dtFBData.Rows.Count > 0 Then
            lblFabricMstId.Text = dtFBData.Rows(0)("FabricDBMstId")
            txtAvailableFab.Text = Val(dtFBData.Rows(0)("OPQty")) + Val(dtFBData.Rows(0)("PurchaseQty")) + FBRecv - FBIssue - DPFBIssue
        End If

    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            If Val(txtIssueQty.Text) > Val(txtAvailableFab.Text) Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Quantity exceed")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                clear()
            End If


        Catch ex As Exception

        End Try


    End Sub
    Sub SaveSession()

        If (Not CType(Session("dtDPPOIssueDetail"), DataTable) Is Nothing) Then
            dtDPPOIssueDetail = Session("dtDPPOIssueDetail")
        Else
            dtDPPOIssueDetail = New DataTable
            With dtDPPOIssueDetail
                .Columns.Add("DPPOIssueDtlID", GetType(Long))
                .Columns.Add("DeptDatabaseId", GetType(String))
                .Columns.Add("DeptDatabaseName", GetType(String))
                .Columns.Add("DalNo", GetType(String))
                .Columns.Add("FabricDbMstID", GetType(String))
                .Columns.Add("AvailableFab", GetType(String))
                .Columns.Add("IssueQty", GetType(String))
            End With
        End If
        Dr = dtDPPOIssueDetail.NewRow()
        If Val(lblDetailID.Text) > 0 Then
            Dr("DPPOIssueDtlID") = lblDetailID.Text
        Else
            Dr("DPPOIssueDtlID") = 0
        End If
        Dr("DeptDatabaseId") = CmbDept.SelectedValue
        Dr("DeptDatabaseName") = CmbDept.SelectedItem.Text
        Dr("DalNo") = txtDalNo.Text
        Dr("FabricDbMstID") = lblFabricMstId.Text
        Dr("AvailableFab") = txtAvailableFab.Text
        Dr("IssueQty") = txtIssueQty.Text
        dtDPPOIssueDetail.Rows.Add(Dr)
        Session("dtDPPOIssueDetail") = dtDPPOIssueDetail
        BindGrid()

    End Sub
    Sub BindGrid()
        Try
            If dtDPPOIssueDetail.Rows.Count > 0 Then
                dgPORecv.DataSource = dtDPPOIssueDetail
                dgPORecv.DataBind()
                dgPORecv.Visible = True
            Else

                dgPORecv.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub clear()

        txtDalNo.Text = ""
        lblFabricMstId.Text = 0
        txtAvailableFab.Text = ""
        txtIssueQty.Text = ""

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Try
                If txtIssueDate.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
                ElseIf txtDCNo.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill DC No.")
                ElseIf dgPORecv.Items.Count = 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast add one record in grid")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    save()
                    Response.Redirect("DPPoIssueView.aspx")
                End If


            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Try
                Response.Redirect("DPPoIssueView.aspx")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Sub save()
        Try
            With ObjDPPOIssueMst
                If lDPPOIssueMstID > 0 Then
                    .DPPOIssueMstID = lDPPOIssueMstID
                Else
                    .DPPOIssueMstID = 0
                End If

                .IssueDate = txtIssueDate.SelectedDate
                .CreationDate = Date.Now
                .IssueTime = txtIssueTime.Text
                .IssueVoucherNo = txtIssueVoucherNo.Text
                .DCNo = txtDCNo.Text
                .Save()
            End With


            Dim x As Integer
            For x = 0 To dgPORecv.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgPORecv.MasterTableView.Items(x), GridDataItem)
                With ObjDPPOIssueDetail
                    .DPPOIssueDtlID = item("DPPOIssueDtlID").Text
                    If lDPPOIssueMstID > 0 Then
                        .DPPOIssueMstID = lDPPOIssueMstID
                    Else
                        .DPPOIssueMstID = ObjDPPOIssueMst.GetID()
                    End If
                    .DeptDatabaseID = item("DeptDatabaseID").Text
                    .FabricDbMstID = item("FabricDbMstID").Text
                    .AvailableFabric = item("AvailableFab").Text
                    .IssueQty = item("IssueQty").Text
                    .DalNo = item("DalNo").Text
                    .SaveDPPOIssueDtl()
                End With
            Next

        Catch ex As Exception

        End Try
    End Sub
End Class