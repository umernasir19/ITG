Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Public Class CommodityEntry
    Inherits System.Web.UI.Page
    Dim objCommodityClass As New CommodityClass
    Dim lCommodityid As Long
    Dim ObjTblRND As New TblDPRND
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lCommodityid = Request.QueryString("Commodityid")
        If Not Page.IsPostBack Then
            If lCommodityid > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = ObjTblRND.GetEditDataForCommodity(lCommodityid)
        If dt.Rows.Count > 0 Then
            TXTCommodity.Text = dt.Rows(0)("Commodity")
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try

            If TXTCommodity.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Commodity")
          
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                With objCommodityClass
                    If lCommodityid > 0 Then
                        .Commodityid = lCommodityid
                    Else
                        .Commodityid = 0
                    End If
                    .Commodity = TXTCommodity.Text.ToUpper

                    .save()
                End With
                Response.Redirect("CommodityView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("CommodityView.aspx")

        Catch ex As Exception

        End Try
    End Sub



End Class