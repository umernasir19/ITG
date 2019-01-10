Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class ProductGroupEntry
    Inherits System.Web.UI.Page
    Dim objProductType As New ProductType
    Dim Dt As New DataTable
    Dim lTypeID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lTypeID = Request.QueryString("lTypeID")
        If Not Page.IsPostBack Then
            PageHeader("Product Group Entry Form")
            If lTypeID > 0 Then
                btnSave.Text = "Update"
                SetValuesEditMod()
            Else
                btnSave.Text = "Save"
            End If

        End If
    End Sub
    Sub SetValuesEditMod()
        Try
            Dt = objProductType.GetEditProductEntry(lTypeID)
            txtProductGroup.Text = Dt.Rows(0)("ProductType")
           
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtProductGroup.Text = "" Then
                lblMsg.Text = "Empty Not Allow"
            Else
                Dim dtCheck As DataTable
                dtCheck = objProductType.GetEditProductType(txtProductGroup.Text)
                If dtCheck.Rows.Count > 0 Then
                    lblMsg.Text = "Already Exist"
                Else


                    With objProductType
                        If lTypeID > 0 Then

                            .TypeID = lTypeID
                        Else
                            .TypeID = 0
                        End If

                        .ProductType = txtProductGroup.Text
                        .IsActive = True
                        .SaveProductType()
                    End With
                    Response.Redirect("ProductGroupView.aspx")
                    lblMsg.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ProductGroupView.aspx")
    End Sub
End Class