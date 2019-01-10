Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class FabricTypeEntry
    Inherits System.Web.UI.Page
    Dim objFabricType As New FabricType
    Dim FabricTypeID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FabricTypeID = Request.QueryString("lFabricTypeID")
        If Not Page.IsPostBack Then
            If FabricTypeID > 0 Then
                EditMode()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            PageHeader("Product Group Entry Form")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub EditMode()
        Try
            
            Dim dt As DataTable
            dt = objFabricType.GetEditFabricType(FabricTypeID)
            txtFabricType.Text = dt.Rows(0)("FabricType")
          
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtFabricType.Text = "" Then
                lblMsg.Text = "Empty Not Allow"
            Else
                Dim dtCheck As DataTable
                dtCheck = objFabricType.GetEditFabricTypeCheck(txtFabricType.Text)
                If FabricTypeID > 0 Then
                    Save()
                    Response.Redirect("FabricTypeView.aspx")
                    lblMsg.Text = ""
                Else
                    If dtCheck.Rows.Count > 0 Then
                        lblMsg.Text = "Already Exist"
                    Else
                        Save()
                        Response.Redirect("FabricTypeView.aspx")
                        lblMsg.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        Try
            With objFabricType
                If FabricTypeID > 0 Then
                    .FabricTypeID = FabricTypeID
                Else
                    .FabricTypeID = 0
                End If
                .FabricType = txtFabricType.Text
                .IsActive = True
                .SaveFabricType()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("FabricTypeView.aspx")
    End Sub
End Class