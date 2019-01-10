Imports System.Data
Imports Telerik.Web.UI
Imports Integra.EuroCentra

Public Class PurchaseOrderView
    Inherits System.Web.UI.Page
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAddPurchaseorder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddPurchaseorder.Click
        Response.Redirect("PurchaseOrderAdd.aspx")
    End Sub

    Protected Sub btnWIP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWIP.Click
        Response.Write("<script> window.open('WIPtemprory.aspx?lPOID=9560', 'newwindow', 'left=50, top=30, height=600, width=720, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

    End Sub

    Protected Sub btnInspection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInspection.Click
        Response.Write("<script> window.open('QualityDepartmentPopup.aspx?lPOID=9560', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

    End Sub

    Protected Sub btnPoRevised_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPoRevised.Click
        Response.Write("<script> window.open('PORevisedShipment.aspx?lPOID=9560', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

    End Sub

    Protected Sub btnSpilt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSpilt.Click
        Response.Write("<script> window.open('SplitShipment.aspx?lPOID=9560', 'newwindow', 'left=12, top=30, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

    End Sub
End Class