Imports Telerik.Web.UI.RadDatePicker
Public Class DatePlus

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    Protected Sub cmbETDdate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles cmbETDdate.SelectedDateChanged
        If txtShipMode.Text = "sea" Then
            cmbShipDate.SelectedDate = cmbETDdate.SelectedDate.Value.AddDays(28)
        ElseIf txtShipMode.Text = "air" Then
            cmbShipDate.SelectedDate = cmbETDdate.SelectedDate.Value.AddDays(7)
        End If

    End Sub
End Class