Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class BookedExchange
    Inherits System.Web.UI.Page
    Dim ObjBookedExchangeRate As New BookedExchangeRate
    Dim lBookedExchangeRateID As Long
    Dim Dt As New DataTable
    Dim DtPO As New DataTable
    Dim ObjPOMaster As New PurchaseOrder
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lBookedExchangeRateID = Request.QueryString("lBookedExchangeRateID")
        If Not Page.IsPostBack Then
            PageHeader("Booked Exchange Rate Module")
            BindCurrency()
            If lBookedExchangeRateID > 0 Then
                btnSave.Text = "Update"
                SetValuesEditMod()
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindCurrency()
        Dim dt As DataTable = ObjBookedExchangeRate.GetCurrency()
        cmbCurrency.DataSource = dt
        cmbCurrency.DataValueField = "CurrencyId"
        cmbCurrency.DataTextField = "CurrencyName"
        cmbCurrency.DataBind()
    End Sub
    Sub SetValuesEditMod()
        Try
            Dt = ObjBookedExchangeRate.GetRateEdit(lBookedExchangeRateID)
            txtExchangeRate.Text = Dt.Rows(0)("BookedExchangeRate")
            txtDateFrom.SelectedDate = Dt.Rows(0)("ShipStartDate")
            txtDateTo.SelectedDate = Dt.Rows(0)("ShipEndDate")
            cmbCurrency.SelectedValue = Dt.Rows(0)("CurrencyId")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtExchangeRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Exchange Rate Empty Not Allow.")
            Else
                Dim startdatee As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                Dim Enddatee As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                If lBookedExchangeRateID > 0 Then
                    With ObjBookedExchangeRate
                        .BookedExchangeRateID = lBookedExchangeRateID
                        .CreationDate = Date.Now
                        If txtExchangeRate.Text = "" Then
                            .BookedExchangeRate = 0
                        Else
                            .BookedExchangeRate = txtExchangeRate.Text
                        End If
                        .ShipStartDate = txtDateFrom.SelectedDate
                        .ShipEndDate = txtDateTo.SelectedDate
                        .CurrencyId = cmbCurrency.SelectedValue
                        .Currency = cmbCurrency.SelectedItem.Text
                        .SaveBookedExchangeRate()
                    End With
                    'after Saving Rate in Tale Implement on PO
                    'Take all POIDS from tale in these dates
                    Dim x As Integer
                    ' DtPO = ObjPOMaster.GetPOForExchangeRate(txtDateFrom.SelectedDate, txtDateTo.SelectedDate)
                    DtPO = ObjPOMaster.GetPOForExchangeRateWithCurrency(startdatee, Enddatee, cmbCurrency.SelectedItem.Text)
                    For x = 0 To DtPO.Rows.Count - 1
                        ObjPOMaster.UpdateBookedExchangeRate(DtPO.Rows(x)("POID"), txtExchangeRate.Text)
                    Next
                    'After Implement Move to View page
                    Response.Redirect("BookedExchangeView.aspx")
                Else
                    'CHECK IF THIS DATE HAVE ALREADY EXCHANGE RATE
                    Dim dtCheck As New DataTable
                    dtCheck = ObjBookedExchangeRate.ExistingOfBookedRateWithCurrency(startdatee, Enddatee, cmbCurrency.SelectedItem.Text)
                    If dtCheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Exchange Rate Already Exist.")
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        With ObjBookedExchangeRate
                            .BookedExchangeRateID = lBookedExchangeRateID
                            .CreationDate = Date.Now
                            If txtExchangeRate.Text = "" Then
                                .BookedExchangeRate = 0
                            Else
                                .BookedExchangeRate = txtExchangeRate.Text
                            End If
                            .ShipStartDate = txtDateFrom.SelectedDate
                            .ShipEndDate = txtDateTo.SelectedDate
                            .CurrencyId = cmbCurrency.SelectedValue
                            .Currency = cmbCurrency.SelectedItem.Text
                            .SaveBookedExchangeRate()
                        End With
                        'after Saving Rate in Tale Implement on PO
                        'Take all POIDS from tale in these dates
                        Dim x As Integer
                        DtPO = ObjPOMaster.GetPOForExchangeRateWithCurrency(startdatee, Enddatee, cmbCurrency.SelectedItem.Text)
                        For x = 0 To DtPO.Rows.Count - 1
                            ObjPOMaster.UpdateBookedExchangeRate(DtPO.Rows(x)("POID"), txtExchangeRate.Text)
                        Next
                        'After Implement Move to View page
                        Response.Redirect("BookedExchangeView.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("BookedExchangeView.aspx")
    End Sub

End Class