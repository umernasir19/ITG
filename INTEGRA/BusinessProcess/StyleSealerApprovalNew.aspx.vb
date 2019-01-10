Imports Integra.EuroCentra
Imports System.Data
Public Class StyleSealerApprovalNew
    Inherits System.Web.UI.Page
    Dim StyleID As Long
    Dim StyleNo As String
    Dim objPurchaseOrder As New PurchaseOrder
    Dim objStyleMaster As New StyleMaster
    Dim ObjSeason As New Season
    Dim dtBind As DataTable
    Dim Dr As DataRow
    Dim ObjStyleSealerApproval As New tblStyleSealerApproval
    Dim StyleSealerAppID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        StyleID = Request.QueryString("StyleID")
        StyleNo = Request.QueryString("StyleNo")
        If Not Page.IsPostBack Then
            Session("dtBind") = Nothing
            txtStyleNo.Text = StyleNo
            BindSeason()
            CheckStyleSealerExistance()
        End If
    End Sub
    Sub CheckStyleSealerExistance()
        Try
            Dim dtcheck As DataTable = ObjStyleSealerApproval.getData(StyleID, StyleNo)
            If dtcheck.Rows.Count > 0 Then
                dgStyleSealer.DataSource = dtcheck
                Session("dtBind") = dtcheck
                BindGridNew()
                btnSave.Visible = True
                btnSave.Text = "Update"
            Else
                Session("dtBind") = Nothing
                btnSave.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub BindSeason()
        Try
            Dim dt As DataTable = ObjSeason.GetAllh()
            cmbSeason.DataSource = dt
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataTextField = "Season"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgStyleSealer.PageIndexChanged
        BindGridNew()
    End Sub
    Sub BindGridNew()
        Try
            Dim dtt As DataTable = Session("dtBind")
            dgStyleSealer.DataSource = dtt
            dgStyleSealer.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            SaveSessionStyle()
            btnSave.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionStyle()
        If (Not CType(Session("dtBind"), DataTable) Is Nothing) Then
            dtBind = Session("dtBind")
        Else
            dtBind = New DataTable
            With dtBind
                .Columns.Add("StyleSealerAppID", GetType(Long))
                .Columns.Add("StyleID", GetType(Long))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("SeasonID", GetType(Long))
                .Columns.Add("Season", GetType(String))
                .Columns.Add("SealerApprovalDate", GetType(String))

            End With
        End If
        Dr = dtBind.NewRow()
        Dr("StyleSealerAppID") = 0
        Dr("StyleID") = StyleID
        Dr("StyleNo") = txtStyleNo.Text
        Dr("SeasonID") = cmbSeason.SelectedValue
        Dr("Season") = cmbSeason.SelectedItem.Text
        Dr("SealerApprovalDate") = txtSealerApprovalDate.SelectedDate
        dtBind.Rows.Add(Dr)

        Session("dtBind") = dtBind
        BindGridNew()

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            SaveStyleSealer()
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveStyleSealer()
        Try
            Dim dtnew As DataTable = Session("dtBind")

            Dim x As Integer
            For x = 0 To dgStyleSealer.Items.Count - 1
                With ObjStyleSealerApproval
                    .StyleSealerAppID = dgStyleSealer.Items(x).Cells(0).Text()
                    .StyleID = dgStyleSealer.Items(x).Cells(1).Text()
                    .StyleNo = dgStyleSealer.Items(x).Cells(2).Text()
                    .SeasonID = dgStyleSealer.Items(x).Cells(3).Text()
                    .Season = dgStyleSealer.Items(x).Cells(4).Text()
                    .SealerApprovalDate = dgStyleSealer.Items(x).Cells(5).Text()
                    .SaveStyleSealerApproval()
                End With
            Next

        Catch ex As Exception

        End Try
        Response.Redirect("StyleView.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("StyleView.aspx")
    End Sub
    Protected Sub dgStyleSealer_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgStyleSealer.ItemCommand


        Try
            Select Case e.CommandName
                Case Is = "Remove"
                    Dim StyleSealerAppID As Long = dgStyleSealer.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim dtStyleSealer As DataTable = Session("dtBind")
                    dtStyleSealer.Rows.RemoveAt(e.Item.ItemIndex)
                    ObjStyleSealerApproval.Delete(StyleSealerAppID)
                    Session("dtBind") = dtStyleSealer
                    If dtStyleSealer.Rows.Count > 0 Then
                        dgStyleSealer.DataSource = Session("dtBind")
                        dgStyleSealer.DataBind()
                    Else
                        dgStyleSealer.Visible = False
                    End If


            End Select
        Catch ex As Exception

        End Try

    End Sub
End Class