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
Public Class ItemCategoryEntry
    Inherits System.Web.UI.Page
    Dim ObjIMSItemClass As New IMSItemClass
    Dim ObjIMSItemCategory As New IMSItemCategory
    Dim IMSItemCategoryID As Long
    Dim Userid As Long
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IMSItemCategoryID = Request.QueryString("IMSItemCategoryID")
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                BindcmbItemClassNameFabric()
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(Userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    BindcmbItemClassNameFabric()
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    BindcmbItemClassNameAccessories()
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    BindcmbItemClassNameGStore()
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    BindcmbItemClassNameAccessoriesForAuditor()
                ElseIf DtCheck.Rows(0)("Department") = "Dead Store" Then
                    BindcmbItemClassNameAccessories()
                End If
            End If
            If IMSItemCategoryID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub BindcmbItemClassNameFabric()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassFabric
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Sub BindcmbItemClassNameAccessories()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAccessories
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Sub BindcmbItemClassNameGStore()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassGStore
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Sub BindcmbItemClassNameAccessoriesForAuditor()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassAccessoriesForAuditor
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Sub BindcmbItemClassNameGeneral()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassGeneral
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Sub BindcmbItemClassNameChemical()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassChemical
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Sub BindcmbItemClassNameDead()
        Dim dt As DataTable
        dt = ObjIMSItemClass.GetItemClassDead
        cmbItemClassName.DataSource = dt
        cmbItemClassName.DataTextField = "ItemClassName"
        cmbItemClassName.DataValueField = "IMSItemClassID"
        cmbItemClassName.DataBind()
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dt As DataTable = ObjIMSItemCategory.GetIIMSItemCategoryEdit(IMSItemCategoryID)
            cmbItemClassName.SelectedValue = dt.Rows(0)("IMSItemClassID")
            txtItemCategoryName.Text = dt.Rows(0)("ItemCategoryName")
            txtItemCategoryCode.Text = dt.Rows(0)("ItemCategoryCode")
            txtRemarks.Text = dt.Rows(0)("Remarks")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtItemCategoryName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" Item Category Name empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                With ObjIMSItemCategory
                    .IMSItemCategoryID = IMSItemCategoryID
                    .CreationDate = Date.Now
                    .IMSItemClassID = cmbItemClassName.SelectedValue
                    .ItemCategoryName = txtItemCategoryName.Text.ToUpper
                    .ItemCategoryCode = txtItemCategoryCode.Text.ToUpper
                    .IsActive = True
                    .Remarks = txtRemarks.Text
                    .CategoryManagedBy = CLng(Session("Userid"))
                    .SaveIMSItemCategory()
                End With
                Response.Redirect("ItemCategoryView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            Response.Redirect("ItemCategoryView.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class
