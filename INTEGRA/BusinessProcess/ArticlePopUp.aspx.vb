Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Imports System.IO
Public Class ArticlePopUp
    Inherits System.Web.UI.Page
    Dim ObjCargoDetail As New CargoDetail
    Dim Dr As DataRow
    Dim POID As String
    Dim objUser As New User
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        If Not Page.IsPostBack Then
            Session("dtSelection") = Nothing
            Try

            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Function LoadDataPOIDwise(ByVal Type As String, ByVal POID As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjCargoDetail.GetCargoDetailNewPOIDWise(POID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    ' Function that Loads the data and return dataview
    Function LoadData(ByVal Type As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjCargoDetail.GetCargoDetailNew()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        If objDataView.Count > 0 Then
            dgArticle.DataSource = objDataView
            dgArticle.DataBind()
            dgArticle.Visible = True
        Else
        End If
    End Sub
    Protected Sub UpdateArticle(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim x As Integer
        Dim ID As Label
        Dim chkSelect As CheckBox
        Dim txtQuantity As TextBox
        Dim txtCarton, ShippedRate As TextBox
        Dim dt As System.Data.DataTable
        Dim bShouldAdd As Boolean = True
        Dim isEmployeeExist As Boolean = False
        If (Not CType(Session("dtSelection"), DataTable) Is Nothing) Then
            dt = Session("dtSelection")
        Else
            dt = New DataTable
            With dt
                .Columns.Add("POID", GetType(Long))
                .Columns.Add("StyleID", GetType(String))
                .Columns.Add("StyleNo", GetType(String))
                .Columns.Add("Quantity", GetType(String))
                .Columns.Add("ShippedQty", GetType(String))
                .Columns.Add("ReleaseQuantity", GetType(String))
                .Columns.Add("Cartons", GetType(String))
                .Columns.Add("ShippedRate", GetType(String))
                .Columns.Add("PONO", GetType(String))
                .Columns.Add("CustomerID", GetType(String))
                .Columns.Add("VendorID", GetType(String))
                .Columns.Add("sid", GetType(String))
                .Columns.Add("POPOID", GetType(String))
                .Columns.Add("Currency", GetType(String))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("SupplierName", GetType(String))
                .Columns.Add("Article", GetType(String))
                .Columns.Add("Colorway", GetType(String))
                .Columns.Add("SizeRange", GetType(String))
            End With
        End If
        For x = 0 To dgArticle.Items.Count - 1
            chkSelect = CType(dgArticle.Items(x).FindControl("chkSelected"), CheckBox)
            ID = CType(dgArticle.Items(x).FindControl("lblID"), Label)
            txtQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            txtCarton = CType(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            ShippedRate = CType(dgArticle.Items(x).FindControl("ShippedRate"), TextBox)
            If txtCarton.Text = "" Then
                txtCarton.Text = 0
            End If
            If ShippedRate.Text = "" Then
                ShippedRate.Text = 0
            End If
            If chkSelect.Checked = True Then
                If (Convert.ToDecimal(dgArticle.Items(x).Cells(13).Text) + Convert.ToDecimal(txtQuantity.Text)) > (Convert.ToDecimal(dgArticle.Items(x).Cells(23).Text)) Then
                    chkSelect.Checked = False
                    Errormgs.Text = "You are not allowed to release more than Inpspected qty. Please consult QD Head."
                    Errormgs.Visible = True
                Else
                    If ChekIDExist(ID.Text) = False Then
                        Errormgs.Text = ""
                        Errormgs.Visible = False
                        txtQuantity.Enabled = False
                        txtCarton.Enabled = False
                        ShippedRate.Enabled = False
                        Dr = dt.NewRow()
                        'Dr("POID") = dgArticle.Items(x).Cells(1).Text
                        'Dr("StyleID") = dgArticle.Items(x).Cells(2).Text
                        'Dr("StyleNo") = dgArticle.Items(x).Cells(3).Text
                        'Dr("Quantity") = dgArticle.Items(x).Cells(5).Text
                        'Dr("ShippedQty") = dgArticle.Items(x).Cells(6).Text
                        'Dr("ReleaseQuantity") = txtQuantity.Text
                        ''Dr("Cartons") = dgArticle.Items(x).Cells(8).Text
                        'Dr("Cartons") = txtCarton.Text
                        'Dr("PONO") = dgArticle.Items(x).Cells(0).Text
                        'Dr("CustomerID") = dgArticle.Items(x).Cells(11).Text
                        'Dr("VendorID") = dgArticle.Items(x).Cells(12).Text
                        'Dr("sid") = ID.Text
                        ''Chang of CustomerName
                        Dr("POID") = dgArticle.Items(x).Cells(3).Text
                        Dr("StyleID") = dgArticle.Items(x).Cells(6).Text
                        Dr("StyleNo") = dgArticle.Items(x).Cells(7).Text
                        Dr("Quantity") = dgArticle.Items(x).Cells(12).Text
                        Dr("ShippedQty") = dgArticle.Items(x).Cells(13).Text
                        Dr("ReleaseQuantity") = txtQuantity.Text
                        'Dr("Cartons") = dgArticle.Items(x).Cells(8).Text
                        Dr("Cartons") = txtCarton.Text
                        Dr("ShippedRate") = ShippedRate.Text
                        Dr("PONO") = dgArticle.Items(x).Cells(2).Text
                        Dr("CustomerID") = dgArticle.Items(x).Cells(19).Text
                        Dr("VendorID") = dgArticle.Items(x).Cells(20).Text
                        Dr("POPOID") = dgArticle.Items(x).Cells(21).Text
                        Dr("Currency") = dgArticle.Items(x).Cells(22).Text
                        Dr("CustomerName") = dgArticle.Items(x).Cells(4).Text
                        Dr("SupplierName") = dgArticle.Items(x).Cells(5).Text
                        Dr("Article") = dgArticle.Items(x).Cells(8).Text
                        Dr("Colorway") = dgArticle.Items(x).Cells(9).Text
                        Dr("SizeRange") = dgArticle.Items(x).Cells(10).Text

                        Dr("sid") = ID.Text
                        dt.Rows.Add(Dr)
                    End If
                End If
            Else
                Try
                    'If Not dt.Rows(x)("POID") Is Nothing Then
                    '    txtQuantity.Enabled = True
                    '    dt.Rows.RemoveAt(x)
                    'End If
                Catch ex As Exception
                End Try
            End If
        Next
        Session("dtSelection") = dt
    End Sub
    Function ChekIDExist(ByVal ID As Long) As Boolean
        Dim i As Integer
        Dim idChek As Long
        Dim dt As New DataTable
        dt = Session("dtSelection")
        If Not dt Is Nothing Then
            For i = 0 To dt.Rows.Count - 1
                idChek = dt.Rows(i)("sid")
                If ID = idChek Then
                    Return True
                End If
            Next
        End If
    End Function
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Session("objDataView") = Nothing
        dgArticle.DataSource = Nothing
        Dim objDataView As DataView
        Try
            Dim objDataTable As DataTable
            objDataTable = ObjCargoDetail.GetCargoDetailNewSearchPONo(txtPONO.Text)
            If objDataTable.Rows.Count = Nothing Then
                Errormgs.Text = " No Record Found"
                dgArticle.Visible = False
                Errormgs.Visible = True
            Else
                Errormgs.Visible = False

                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                btnSelect.Visible = True

            End If
        Catch objUDException As UDException
        End Try
    End Sub
     'Protected Sub dgArticle_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgArticle.NeedDataSource
    '    BindGrid()
    'End Sub
    Protected Sub dgArticle_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgArticle.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgArticle_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgArticle.SortCommand
        BindGrid()
    End Sub
End Class