Imports Integra.EuroCentra
Imports System.Data
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim dtSizeRangeDatabase As New DataTable
    Dim dr As DataRow
    Dim objSizeRange As New SizeRange
    Dim objSizeRangeDetail As New SizeRangeDetail
    Dim SizeRangeID As Long
    Dim ObjGender1 As New Gender1
    Dim ObjSizeDatabase As New SizeDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SizeRangeID = Request.QueryString("SizeRangeID")
        If Not Page.IsPostBack Then
            Session("dtSizeRangeDatabase") = Nothing
            BinSizes()
            BinGender()
            If SizeRangeID > 0 Then
                EditMode()
            End If

        End If
        'PageHeader("SIZE RANGE ENTRY FORM")
    End Sub
    Sub BinSizes()
        Dim dt As DataTable
        dt = objSizeRange.GetSizesS()
        cmbSizes.DataSource = dt
        cmbSizes.DataTextField = "Sizes"
        cmbSizes.DataValueField = "SizeDatabaseID"
        cmbSizes.DataBind()
    End Sub
    Protected Sub btnAddDeatil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDeatil.Click
        Try

            If txtSizeRange.Text = "" Then
                ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Size Range Required")
            Else
                Dim xx As Integer
                Dim existing As String = ""
                For xx = 0 To dgView.Items.Count - 1
                    If cmbSizes.SelectedValue = dgView.Items(xx).Cells(1).Text Then
                        existing = "Already"
                    End If
                Next
                If existing = "Already" Then
                    '  DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Already exist.")
                Else
                    ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    If (Not CType(Session("dtSizeRangeDatabase"), DataTable) Is Nothing) Then
                        dtSizeRangeDatabase = Session("dtSizeRangeDatabase")
                    Else
                        dtSizeRangeDatabase = New DataTable
                        With dtSizeRangeDatabase
                            .Columns.Add("SizeRangeDetailID", GetType(Long))
                            .Columns.Add("SizeDatabaseID", GetType(Long))
                            .Columns.Add("Ratio", GetType(Long))
                            .Columns.Add("Sizes", GetType(String))
                        End With
                    End If
                    dr = dtSizeRangeDatabase.NewRow()
                    dr("SizeRangeDetailID") = 0
                    dr("SizeDatabaseID") = cmbSizes.SelectedValue
                    dr("Ratio") = 1
                    dr("Sizes") = cmbSizes.SelectedItem.Text
                    dtSizeRangeDatabase.Rows.Add(dr)
                    Session("dtSizeRangeDatabase") = dtSizeRangeDatabase
                    BindGrid()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGrid()
        dtSizeRangeDatabase = Session("dtSizeRangeDatabase")
        Dim objDataview As New DataView(dtSizeRangeDatabase)
        dgView.RecordCount = objDataview.Count
        dgView.DataSource = objDataview
        dgView.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If dgView.Items.Count = 0 Then
                ' DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One Detail Required")
            Else
                If SizeRangeID > 0 Then
                    '  DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    With objSizeRange
                        .SizeRangeID = SizeRangeID
                        .Gender = cmbGender.SelectedItem.Text
                        .SizeGroup = cmbGender.SelectedItem.Text 'txtSizeGroup.Text.ToUpper()
                        .SizeRange = txtSizeRange.Text.ToUpper()
                        .SaveSizeRange()
                    End With
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        With objSizeRangeDetail
                            .SizeRangeDetailID = dgView.Items(x).Cells(0).Text
                            If SizeRangeID > 0 Then
                                .SizeRangeID = SizeRangeID
                            Else
                                .SizeRangeID = objSizeRange.GetID()
                            End If
                            .SizeDatabaseID = dgView.Items(x).Cells(1).Text
                            .Ratio = dgView.Items(x).Cells(3).Text
                            .SaveSizeRangeDetail()
                        End With
                    Next

                    Session("dtSizeRangeDatabase") = Nothing
                    ' Response.Redirect("SizeRangeView_A.aspx")
                Else
                    Dim dtExist As DataTable
                    dtExist = objSizeRange.LoadSizeRangeFirstTime(cmbGender.SelectedItem.Text, txtSizeRange.Text)
                    If dtExist.Rows.Count > 0 Then
                        'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This Size Group and  Size Range already exist.")
                    Else
                        'DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With objSizeRange
                            .SizeRangeID = SizeRangeID
                            .Gender = cmbGender.SelectedItem.Text
                            .SizeGroup = cmbGender.SelectedItem.Text
                            .SizeRange = txtSizeRange.Text.ToUpper()
                            .SaveSizeRange()
                        End With
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            With objSizeRangeDetail
                                .SizeRangeDetailID = dgView.Items(x).Cells(0).Text
                                If SizeRangeID > 0 Then
                                    .SizeRangeID = SizeRangeID
                                Else
                                    .SizeRangeID = objSizeRange.GetID()
                                End If
                                .SizeDatabaseID = dgView.Items(x).Cells(1).Text
                                .Ratio = dgView.Items(x).Cells(3).Text
                                .SaveSizeRangeDetail()
                            End With
                        Next

                        Session("dtSizeRangeDatabase") = Nothing
                        'Response.Redirect("SizeRangeView_A.aspx")
                        btnSave.Visible = False
                        BtnCancel.Visible = True
                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            Session("dtSizeRangeDatabase") = Nothing
            Response.Redirect("SizeRangeView_A.aspx")
        Catch ex As Exception

        End Try
    End Sub
    Sub EditMode()
        Try
            Dim dt As DataTable = objSizeRange.Edit(SizeRangeID)
            cmbGender.SelectedItem.Text = dt.Rows(0)("Gender")
            txtSizeRange.Text = dt.Rows(0)("SizeRange")

            If (Not CType(Session("dtSizeRangeDatabase"), DataTable) Is Nothing) Then
                dtSizeRangeDatabase = Session("dtSizeRangeDatabase")
            Else
                dtSizeRangeDatabase = New DataTable
                With dtSizeRangeDatabase
                    .Columns.Add("SizeRangeDetailID", GetType(Long))
                    .Columns.Add("SizeDatabaseID", GetType(Long))
                    .Columns.Add("Ratio", GetType(Long))
                    .Columns.Add("Sizes", GetType(String))
                End With
            End If
            Dim x As Integer
            For x = 0 To dt.Rows.Count - 1
                dr = dtSizeRangeDatabase.NewRow()
                dr("SizeRangeDetailID") = dt.Rows(x)("SizeRangeDetailID")
                dr("SizeDatabaseID") = dt.Rows(x)("SizeDatabaseID")
                dr("Ratio") = dt.Rows(x)("Ratio")
                dr("Sizes") = dt.Rows(x)("Sizes")
                dtSizeRangeDatabase.Rows.Add(dr)
                Session("dtSizeRangeDatabase") = dtSizeRangeDatabase
            Next

            BindGrid()
        Catch ex As Exception

        End Try
    End Sub

    Sub BinGender()
        Dim dt As DataTable
        dt = objSizeRange.GetGender1()
        cmbGender.DataSource = dt
        cmbGender.DataTextField = "Gender"
        cmbGender.DataValueField = "GenderId"
        cmbGender.DataBind()

    End Sub
    Protected Sub BtnAddGender_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddGender.Click
        Try
            PnlAddGender2.Visible = True
            PnlAddGender1.Visible = False
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub BtnSaveGender_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveGender.Click
        Try
            With ObjGender1
                .GenderId = 0
                .Gender = txtAddGender.Text
                .Save()
            End With
        Catch ex As Exception

        End Try

        PnlAddGender1.Visible = True
        PnlAddGender2.Visible = False
        BinGender()
    End Sub
    Protected Sub BtnAddSizes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnAddSizes.Click
        Try
            PnlSizes2.Visible = True
            PnlSizes1.Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnSaveSizes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSaveSizes.Click
        Try
            With ObjSizeDatabase
                .SizeDatabaseID = 0
                .Sizes = txtAddSizes.Text
                .Ratio = 1
                .SaveSizeDatabase()
            End With
        Catch ex As Exception

        End Try

        PnlSizes1.Visible = True
        PnlSizes2.Visible = False
        BinSizes()
    End Sub







End Class
