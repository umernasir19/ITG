Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class ShippedExchange
    Inherits System.Web.UI.Page
    Dim ObjShipExchangeRate As New ShipExchangeRate
    Dim lRateID As Long
    Dim Dt As New DataTable
    Dim ObjCargo As New Cargo
    Dim DtCargo As New DataTable
    Dim GeneralCode As New GeneralCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lRateID = Request.QueryString("lRateID")
        If Not Page.IsPostBack Then
            PageHeader("Shipped Exchange Rate Module")
            If lRateID > 0 Then
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
    Sub SetValuesEditMod()
        Try
            Dt = ObjShipExchangeRate.GetRateEdit(lRateID)
            txtExchangeRate.Text = Dt.Rows(0)("ShipExchangeRate")
            txtDateFrom.SelectedDate = Dt.Rows(0)("MonthStartDate")
            txtDateTo.SelectedDate = Dt.Rows(0)("MonthEndDate")
            cmbCurrency.SelectedItem.Text = Dt.Rows(0)("Currency")

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbCurrency.SelectedItem.Text <> "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                With ObjShipExchangeRate
                    If txtExchangeRate.Text = "" Then

                    Else
                        ' Dim startdatee As String = GeneralCode.GetDateFormat(txtDateFrom.SelectedDate)
                        ' Dim Enddatee As String = GeneralCode.GetDateFormat(txtDateTo.SelectedDate)
                        Dim startdatee As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                        Dim Enddatee As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                        If lRateID > 0 Then
                            .RateID = lRateID
                            .CreationDate = Date.Now
                            If txtExchangeRate.Text = "" Then
                                .ShipExchangeRate = 0
                            Else
                                .ShipExchangeRate = txtExchangeRate.Text
                            End If
                            .MonthStartDate = txtDateFrom.SelectedDate
                            .MonthEndDate = txtDateTo.SelectedDate
                            .Currency = cmbCurrency.SelectedItem.Text
                            .SaveShipExchangeRate()
                            'after Saving Rate in Tale Implement on Cargo
                            'Take all Cargoids from tale in these dates
                            Dim x As Integer
                            DtCargo = ObjCargo.GetCargoForShipRateNew(startdatee, Enddatee, cmbCurrency.SelectedItem.Text)
                            For x = 0 To DtCargo.Rows.Count - 1
                                ObjCargo.UpdateShippedExchangeRate(DtCargo.Rows(x)("CargoID"), .ShipExchangeRate)
                            Next
                            'After Implement Move to View page
                            Response.Redirect("ShippedExchangeView.aspx")

                        Else
                            'CHECK IF THIS DATE HAVE ALREADY EXCHANGE RATE
                            'Dim startdate As String = GeneralCode.GetDateFormat(txtDateFrom.SelectedDate)
                            'Dim Enddate As String = GeneralCode.GetDateFormat(txtDateTo.SelectedDate)
                            Dim startdate As String = txtDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd")
                            Dim Enddate As String = txtDateTo.SelectedDate.Value.ToString("yyyy-MM-dd")
                            Dim dtCheck As New DataTable
                            'dtCheck = ObjShipExchangeRate.ExistingOfShipRate(startdate, Enddate)
                            ' dtCheck = ObjShipExchangeRate.ExistingOfShipRate(txtDateFrom.SelectedDate, txtDateTo.SelectedDate.ToString)
                            dtCheck = ObjShipExchangeRate.ExistingOfShipRatenew(startdate, Enddate, cmbCurrency.SelectedItem.Text)

                            If dtCheck.Rows.Count > 0 Then
                                'Not save
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("already Exsist")
                            Else
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                                .RateID = lRateID
                                .CreationDate = Date.Now
                                If txtExchangeRate.Text = "" Then
                                    .ShipExchangeRate = 0
                                Else
                                    .ShipExchangeRate = txtExchangeRate.Text
                                End If
                                .MonthStartDate = txtDateFrom.SelectedDate
                                .MonthEndDate = txtDateTo.SelectedDate
                                .Currency = cmbCurrency.SelectedItem.Text
                                .SaveShipExchangeRate()
                                'after Saving Rate in Tale Implement on Cargo
                                'Take all Cargoids from tale in these dates
                                Dim x As Integer
                                DtCargo = ObjCargo.GetCargoForShipRateNew(startdate, Enddate, cmbCurrency.SelectedItem.Text)
                                For x = 0 To DtCargo.Rows.Count - 1
                                    ObjCargo.UpdateShippedExchangeRate(DtCargo.Rows(x)("CargoID"), .ShipExchangeRate)
                                Next
                                'After Implement Move to View page
                                Response.Redirect("ShippedExchangeView.aspx")

                            End If
                        End If
                    End If

                End With
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Currency")
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message.ToString
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("ShippedExchangeView.aspx")
    End Sub
End Class