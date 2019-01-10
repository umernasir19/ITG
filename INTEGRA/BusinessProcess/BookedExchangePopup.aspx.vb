Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class BookedExchangePopup
    Inherits System.Web.UI.Page
    Dim ObjBookedExchangeRate As New BookedExchangeRate
    Dim Dt As New DataTable
    Dim DtPO As New DataTable
    Dim ObjPOMaster As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btnSave.Text = "Save"
            Session("dtBookedExchangeRate") = Nothing
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            'CHECK IF THIS DATE HAVE ALREADY EXCHANGE RATE
            If txtExchangeRate.Text = "" Then
                lblMsg.Text = "Rate Not Empty"
            Else
                lblMsg.Text = " "
                With ObjBookedExchangeRate
                    .BookedExchangeRateID = 0
                    .CreationDate = Date.Now
                    If txtExchangeRate.Text = "" Then
                        .BookedExchangeRate = 0
                    Else
                        .BookedExchangeRate = txtExchangeRate.Text
                    End If
                    .ShipStartDate = txtDateFrom.SelectedDate
                    .ShipEndDate = txtDateTo.SelectedDate
                    .SaveBookedExchangeRate()
                End With
                'After Implement Move to View page
            
                Session("dtBookedExchangeRate") = txtExchangeRate.Text
                lblMsg.Text = "Save Successfully"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class