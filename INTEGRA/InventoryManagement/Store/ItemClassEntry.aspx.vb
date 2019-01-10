Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class ItemClassEntry
    Inherits System.Web.UI.Page
    Dim ObjIMSItemClass As New IMSItemClass
    Dim objPORecvMaster As New PORecvMaster
    Dim IMSItemClassID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IMSItemClassID = Request.QueryString("IMSItemClassID")
        Dim UserID = Session("UserId")
        If Not Page.IsPostBack Then
            BindcmbStoreType()
            If IMSItemClassID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
                BindcmbStoreType()
                If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    cmbStoreType.SelectedValue = 1
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                    If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        cmbStoreType.SelectedValue = 1
                    ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                        cmbStoreType.SelectedValue = 2
                    ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                        cmbStoreType.SelectedValue = 4
                    ElseIf DtCheck.Rows(0)("Department") = "Dead Store" Then
                        cmbStoreType.SelectedValue = 2
                    End If
                End If
            End If
            PageHeader(" ")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dt As DataTable = ObjIMSItemClass.GetItemClassEdit(IMSItemClassID)
            txtItemClassName.Text = dt.Rows(0)("ItemClassName")
            txtItemCode.Text = dt.Rows(0)("ItemCode")
            txtRemarks.Text = dt.Rows(0)("Remarks")
            BindcmbStoreType()
            cmbStoreType.SelectedValue = dt.Rows(0)("StoreTypeID")
           Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtItemClassName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Item Class Name empty")
            ElseIf cmbStoreType.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Store Type")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With ObjIMSItemClass
                    .IMSItemClassID = IMSItemClassID
                    .CreationDate = Date.Now
                    .ItemClassName = txtItemClassName.Text.ToUpper
                    .ItemCode = txtItemCode.Text
                    .IsActive = True
                    .Remarks = txtRemarks.Text
                    .StoreTypeID = cmbStoreType.SelectedValue
                    .SaveIMSItemClass()
                End With
                Response.Redirect("ItemClassView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ItemClassView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub BindcmbStoreType()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetStoreType
        cmbStoreType.DataSource = dt
        cmbStoreType.DataTextField = "StoreType"
        cmbStoreType.DataValueField = "StoreTypeID"
        cmbStoreType.DataBind()
        cmbStoreType.Items.Insert(0, "Select")
    End Sub
End Class
