Imports System.Data
Imports Integra.EuroCentra
Public Class GIACodingSupplierEntry
    Inherits System.Web.UI.Page
    Dim objPOO As New PurchaseOrder
    Dim dtLKZ As New DataTable
    Dim dr As System.Data.DataRow
    Dim objGIACodingSupplier As New GIACodingSupplier
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Supplier GIA Number Entry Panel")
            BindBuyerWise()
            BindSupplierWise()
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindBuyerWise()
        Dim dtBuyer As DataTable
        dtBuyer = objPOO.GetAllCustomer()
        cmbBuyerWise.DataSource = dtBuyer
        cmbBuyerWise.DataTextField = "CustomerName"
        cmbBuyerWise.DataValueField = "CustomerID"
        cmbBuyerWise.DataBind()
        ' cmbBuyerWise.Items.Insert(0, New ListItem("All Customer", "0"))
    End Sub
    Sub BindSupplierWise()
        Dim dtBuyer As DataTable
        dtBuyer = objPOO.GetAllSupplier()
        cmbSupplier.DataSource = dtBuyer
        cmbSupplier.DataTextField = "VenderName"
        cmbSupplier.DataValueField = "VenderLibraryID"
        cmbSupplier.DataBind()
        'cmbSupplier.Items.Insert(0, New ListItem("All Supplier", "0"))
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtGIANo.Text = "" Then
                'Not Bind in Grid
            Else
                SaveInSession()
                BindGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SaveInSession()
        If (Not CType(Session("dtLKZ"), DataTable) Is Nothing) Then
            dtLKZ = Session("dtLKZ")
        Else
            dtLKZ = New DataTable
            With dtLKZ
                With dtLKZ
                    .Columns.Add("GIACodingSupplierID", GetType(Long))
                    .Columns.Add("SupplierID", GetType(String))
                    .Columns.Add("CustomerID", GetType(String))
                    .Columns.Add("SupplierName", GetType(String))
                    .Columns.Add("CustomerName", GetType(String))
                    .Columns.Add("GIANumber", GetType(String))
                End With
            End With
        End If
        dr = dtLKZ.NewRow()
        dr("GIACodingSupplierID") = 0
        dr("SupplierID") = cmbSupplier.SelectedValue
        dr("CustomerID") = cmbBuyerWise.SelectedValue
        dr("SupplierName") = cmbSupplier.SelectedItem.Text
        dr("CustomerName") = cmbBuyerWise.SelectedItem.Text
        dr("GIANumber") = txtGIANo.Text
        '--------------------
        dtLKZ.Rows.Add(dr)
        Session("dtLKZ") = dtLKZ
    End Sub
    Private Function BindGrid() As Boolean
        If (Not dtLKZ Is Nothing) Then
            If (dtLKZ.Rows.Count > 0) Then
                dgLKZz.DataSource = dtLKZ
                dgLKZz.RecordCount = dtLKZ.Rows.Count
                dgLKZz.DataBind()
                dgLKZz.Visible = True
                Return (True)
            End If
        End If
        Return (False)
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgLKZz.PageIndexChanged

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim GIACodingSupplierID, SupplierID, CustomerID, LKZNumber As String
            Dim x As Integer
            Dim dtCheck As New DataTable
            If dgLKZz.Items.Count > 0 Then
                For x = 0 To dgLKZz.Items.Count - 1
                    GIACodingSupplierID = dgLKZz.Items(x).Cells(0).Text
                    SupplierID = dgLKZz.Items(x).Cells(1).Text
                    CustomerID = dgLKZz.Items(x).Cells(2).Text
                    LKZNumber = dgLKZz.Items(x).Cells(5).Text
                    'Befor Save check this supplier have this Customer Already or not
                    dtCheck = objGIACodingSupplier.CheckExistingOfLKZNumber(SupplierID, CustomerID)
                    If dtCheck.Rows.Count > 0 Then
                        'Not allow more than one entry
                        lblmsg.Visible = True
                    Else
                        With objGIACodingSupplier
                            .GIACodingSupplierID = GIACodingSupplierID
                            .SupplierID = SupplierID
                            .CustomerID = CustomerID
                            .GIANumber = LKZNumber
                            .SavGIACodingSupplier()

                        End With
                        Session("dtLKZ") = Nothing
                        Response.Redirect("GIACodingSupplierView.aspx")
                    End If
                Next
            Else
                'Not Save
                lblmsg.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session("dtLKZ") = Nothing
        Response.Redirect("GIACodingSupplierView.aspx")
    End Sub

End Class