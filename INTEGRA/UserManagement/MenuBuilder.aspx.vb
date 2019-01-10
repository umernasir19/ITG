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
Public Class MenuBuilder
    Inherits System.Web.UI.Page

    Dim ObjTblRND As New TblDPRND
    Dim dtRoleSetup As DataTable
    Dim Dr As DataRow
    Dim ObjRole As New Role
    Dim lUserID As Long
    Dim objUser As New User
    Dim objUserRoles As New UserRoles
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lUserID = Request.QueryString("UserID")
        If Not Page.IsPostBack Then
            Session("dtRoleSetup") = Nothing
            BindDesignation()
            'If lUserID > 0 Then
            '    Edit()
            '    btnSave.Text = "Update"
            'Else
            '    btnSave.Text = "Save"
            'End If

        End If
    End Sub
    Protected Sub cmbDesignation_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbDesignation.SelectedIndexChanged
        Try
            Dim dt As DataTable = ObjTblRND.GetDesignationNew(cmbDesignation.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtDepartment.Text = dt.Rows(0)("UMDepartment")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindDesignation()
        Dim dtDepartment As DataTable
        dtDepartment = ObjTblRND.GetDesignation
        cmbDesignation.DataSource = dtDepartment
        cmbDesignation.DataTextField = "Name"
        cmbDesignation.DataValueField = "RoleId"
        cmbDesignation.DataBind()
        cmbDesignation.Items.Insert(0, New RadComboBoxItem("Select"))
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbDesignation.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Designation")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Session("objDataView") = Nothing
                dgMenuBuilder.DataSource = Nothing
                Dim objDataView As DataView
                Dim objDataTable As DataTable
                objDataTable = ObjTblRND.GetDataonGrid()
                If objDataTable.Rows.Count = Nothing Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("No Record Found")
                    dgMenuBuilder.Visible = False

                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    dgMenuBuilder.Visible = True
                    objDataView = New DataView(objDataTable)
                    Session("objDataView") = objDataView
                    BindGrid()

                End If
            End If


        Catch objUDException As UDException
        End Try
    End Sub
    Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgMenuBuilder.DataSource = objDataView
        dgMenuBuilder.DataBind()
        Dim x As Integer
        For x = 0 To dgMenuBuilder.Items.Count - 1

            Dim cmbModuleHeader As DropDownList = CType(dgMenuBuilder.Items(x).FindControl("cmbModuleHeader"), DropDownList)
            Dim dt As DataTable
            dt = ObjTblRND.BingMenuDropdown
            cmbDesignation.DataSource = dt
            cmbDesignation.DataTextField = "TextToDisplay"
            cmbDesignation.DataValueField = "FormRoleId"
            cmbDesignation.DataBind()
            cmbDesignation.Items.Insert(0, New RadComboBoxItem("Select"))
        Next
      
    End Sub
End Class