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
Public Class CurrencyEntry
    Inherits System.Web.UI.Page
    Dim IMSCurrencyID As Long
    Dim ObjIMSCurrency As New IMSCurrency2
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IMSCurrencyID = Request.QueryString("IMSCurrencyID")
        If Not Page.IsPostBack Then
            If IMSCurrencyID > 0 Then
                SetValuesEditMod()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
            PageHeader("Currency Entry ")
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim dtCheck As DataTable
            If txtCurrency.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Currency Empty.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If IMSCurrencyID > 0 Then
                    dtCheck = ObjIMSCurrency.CheckExistingEdit(IMSCurrencyID, txtCurrency.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Currency Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With ObjIMSCurrency
                            If IMSCurrencyID > 0 Then
                                .IMSCurrencyID = IMSCurrencyID
                            Else
                                .IMSCurrencyID = 0
                            End If
                            .CurrencyName = txtCurrency.Text
                            .IsActive = True
                            .SaveIMSCurrency()
                        End With
                        Response.Redirect("CurrencyView.aspx")
                    End If
                Else
                    dtCheck = ObjIMSCurrency.CheckExisting(txtCurrency.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Currency Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With ObjIMSCurrency
                            If IMSCurrencyID > 0 Then
                                .IMSCurrencyID = IMSCurrencyID
                            Else
                                .IMSCurrencyID = 0
                            End If
                            .CurrencyName = txtCurrency.Text
                            .IsActive = True
                            .SaveIMSCurrency()
                        End With
                        Response.Redirect("CurrencyView.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetValuesEditMod()
        Try
            Dim dt As DataTable = ObjIMSCurrency.GetIMSCurrencybyID(IMSCurrencyID)
            txtCurrency.Text = dt.Rows(0)("CurrencyName")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("CurrencyView.aspx")
    End Sub
End Class
