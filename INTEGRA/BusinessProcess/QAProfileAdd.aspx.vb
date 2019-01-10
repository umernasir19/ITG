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
Public Class QAProfileAdd
    Inherits System.Web.UI.Page
    Dim ObjQAProfileMst As New QAProfileMst
    Dim ObjQAProfileDtl As New QAProfileDtl
    Dim Dr As DataRow
    Dim dtQADetail As DataTable
    Dim GeneralCode As New GeneralCode
    Dim QAMstID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        QAMstID = Request.QueryString("lQAMstID")
        If Not Page.IsPostBack Then
            Session("dtQADetail") = Nothing

            BindFactory()
            BindName()
            BindAreaOfExpertise()
            If QAMstID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"


            End If

        End If

    End Sub
    Sub BindName()
        Dim dtName As DataTable
        Try
            'dtName = ObjQAProfileMst.GetBindQDCombo()
            'cmbName.DataSource = dtName
            'cmbName.DataValueField = "UserID"
            'cmbName.DataTextField = "UserName"
            'cmbName.DataBind()
            'cmbName.Items.Insert(0, "Select Name")
            dtName = ObjQAProfileMst.GetBindQDComboNew()
            cmbName.DataSource = dtName
            cmbName.DataValueField = "QAProfileNameID"
            cmbName.DataTextField = "QAProfileName"
            cmbName.DataBind()
            cmbName.Items.Insert(0, "Select Name")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindAreaOfExpertise()
        Dim dtArea As DataTable
        Try
            dtArea = ObjQAProfileMst.GetAreaOfExpertise()
            cmbAreaOFExpertise.DataSource = dtArea
            cmbAreaOFExpertise.DataValueField = "AreaOfExpertiseID"
            cmbAreaOFExpertise.DataTextField = "AreaOfExpertiseName"
            cmbAreaOFExpertise.DataBind()
            cmbAreaOFExpertise.Items.Insert(0, "Select AOE")
        Catch ex As Exception

        End Try
    End Sub

    Sub BindFactory()
        Dim dtFactory As DataTable
        Try
            dtFactory = ObjQAProfileMst.GetFactory()
            cmbFactory.DataSource = dtFactory
            cmbFactory.DataValueField = "VenderLibraryID"
            cmbFactory.DataTextField = "VenderName"
            cmbFactory.DataBind()
            cmbFactory.Items.Insert(0, "Select Factory")
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            If txtQAStartDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("End Date is Empty")
            ElseIf txtQAStartDate.Text = "" Then

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Start Date is Empty")
            ElseIf cmbFactory.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Factory")
            Else
                FillQAProfile()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub SetValuesEditMod()
        Try
            Dim dt As DataTable
            dt = ObjQAProfileMst.GetEdit(QAMstID)
            cmbName.SelectedValue = dt.Rows(0)("QAID")
            cmbName.SelectedItem.Text = dt.Rows(0)("QAName")
            cmbLevel.SelectedValue = dt.Rows(0)("QALevelID")
            cmbLevel.SelectedItem.Text = dt.Rows(0)("QALevel")
            ' cmbAreaOFExpertise.SelectedValue = dt.Rows(0)("QAAreasofExp")
            cmbAreaOFExpertise.SelectedItem.Text = dt.Rows(0)("QAAreasofExp")
            cmbTitle.SelectedValue = dt.Rows(0)("TitleID")
            cmbTitle.SelectedValue = dt.Rows(0)("TitleID")

            dtQADetail = New DataTable
            With dtQADetail
                .Columns.Add("QADetailID", GetType(Long))
                .Columns.Add("Factory", GetType(String))
                .Columns.Add("FactoryID", GetType(Long))
                .Columns.Add("Location", GetType(String))
                .Columns.Add("LocationID", GetType(Long))
                .Columns.Add("StartDateQA", GetType(String))
                .Columns.Add("EndDateQA", GetType(String))
            End With

            For x = 0 To dt.Rows.Count - 1

                Dr = dtQADetail.NewRow()
                Dr("QADetailID") = dt.Rows(x)("QADtlID")
                Dr("Factory") = dt.Rows(x)("Factory")
                Dr("FactoryID") = dt.Rows(x)("FactoryID")
                Dr("Location") = dt.Rows(x)("Location")
                Dr("LocationID") = dt.Rows(x)("LocationID")
                Dr("StartDateQA") = dt.Rows(x)("StartDateQA")
                Dr("EndDateQA") = dt.Rows(x)("EndDateQA")
                dtQADetail.Rows.Add(Dr)
            Next
            Session("dtQADetail") = dtQADetail
            BindGrid()

        Catch ex As Exception
        End Try
    End Sub
    Sub FillQAProfile()

        Try
            If (Not CType(Session("dtQADetail"), DataTable) Is Nothing) Then
                dtQADetail = Session("dtQADetail")
            Else
                dtQADetail = New DataTable
                With dtQADetail
                    .Columns.Add("QADetailID", GetType(Long))
                    .Columns.Add("Factory", GetType(String))
                    .Columns.Add("FactoryID", GetType(String))
                    .Columns.Add("Location", GetType(String))
                    .Columns.Add("LocationID", GetType(String))
                    .Columns.Add("StartDateQA", GetType(String))
                    .Columns.Add("EndDateQA", GetType(String))
                End With
            End If

            Dr = dtQADetail.NewRow()
            Dr("QADetailID") = 0
            Dr("Factory") = cmbFactory.SelectedItem.Text
            Dr("FactoryID") = cmbFactory.SelectedValue
            Dr("Location") = txtLocation.Text
            Dr("LocationID") = 0
            Dr("StartDateQA") = txtQAStartDate.Text
            Dr("EndDateQA") = txtQAEndDate.Text
            dtQADetail.Rows.Add(Dr)
            Session("dtQADetail") = dtQADetail
            BindGrid()

        Catch ex As Exception

        End Try
    End Sub
    Public Function BindGrid() As Boolean
        Dim dt As DataTable
        If (Not dtQADetail Is Nothing) Then
            If (dtQADetail.Rows.Count > 0) Then
                dt = Session("dtQADetail")
                dgViewQA.DataSource = dt
                dgViewQA.DataBind()
                dgViewQA.Visible = True

                Return (True)
            End If
        End If
        Return (False)
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If cmbName.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Name")

            Else
                With ObjQAProfileMst
                    If QAMstID > 0 Then
                        .QAMstID = QAMstID
                    Else
                        .QAMstID = 0
                    End If

                    .QAName = cmbName.SelectedItem.Text
                    .QAAreasofExp = cmbAreaOFExpertise.SelectedItem.Text
                    .QAID = cmbName.SelectedValue
                    .QALevel = cmbLevel.SelectedItem.Text
                    .QALevelID = cmbLevel.SelectedValue
                    .Title = cmbTitle.SelectedItem.Text
                    .TitleID = cmbTitle.SelectedValue
                    .SaveQAProfile()
                End With
                QADetailSave()
                Response.Redirect("QAProfileView.aspx")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub QADetailSave()
        Try
            Dim x As Integer
            For x = 0 To dgViewQA.Items.Count - 1
                With ObjQAProfileDtl
                    .QADtlID = dgViewQA.Items(x).Cells(0).Text
                    If QAMstID > 0 Then
                        .QAMstID = QAMstID
                    Else
                        .QAMstID = ObjQAProfileMst.GetID
                    End If
                    .Factory = dgViewQA.Items(x).Cells(1).Text
                    .FactoryID = dgViewQA.Items(x).Cells(5).Text
                    .Location = dgViewQA.Items(x).Cells(2).Text
                    .LocationID = 0
                    .StartDateQA = GeneralCode.GetDate(dgViewQA.Items(x).Cells(3).Text)
                    .EndDateQA = GeneralCode.GetDate(dgViewQA.Items(x).Cells(4).Text)
                    .SaveQAProfileDtl()

                End With
            Next

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbFactory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFactory.SelectedIndexChanged
        Try
            Dim dt As DataTable = ObjQAProfileMst.GetLocation(cmbFactory.SelectedValue)

            If dt.Rows.Count > 0 Then
                txtLocation.Text = dt.Rows(0)("Town")


            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("QAProfileView.aspx")
    End Sub
End Class
