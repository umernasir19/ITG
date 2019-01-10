Imports System.Data
Imports Integra.EuroCentra
Imports Telerik.Web.UI
Public Class ArticlePopupNew
    Inherits System.Web.UI.Page
    Dim ObjCargoDetail As New CargoDetail
    Dim Dr As DataRow
    Dim POID As String
    Dim objUser As New User
    Dim objDPIMst As New DPIMst
    Dim DTAdd As DataTable
    Dim objDataView As DataView
    Dim ObjCommodityClass As New CommodityClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        If Not Page.IsPostBack Then
            Session("dtSelection") = Nothing
            Session("DTAdd") = Nothing
            BindSeason()
            Try
                BindUser()
                Label1.Visible = False
                txtSeach.Visible = False
                btnSearch.Visible = False
                lblUserName.Visible = False
                cmbUserName.Visible = False
                BtnData.Visible = False
                btnSelect.Visible = False
                btnStyle.Visible = False
                lblStyle.Visible = False
                style.Visible = False
                checkFuNCTION()
            Catch objUDException As UDException
            End Try
        End If
    End Sub
    Protected Sub dgArticle_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgArticle.ItemCommand
        Select Case e.CommandName
            Case Is = "AddCommdity"
                Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(e.Item.ItemIndex).FindControl("TXTCommodity"), TextBox)
                Dim imgSyleAdd As ImageButton = DirectCast(dgArticle.Items(e.Item.ItemIndex).FindControl("imgSyleAdd"), ImageButton)
                Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(e.Item.ItemIndex).FindControl("LBLCommodityID"), Label)
                If TXTCommodity.Text = "" Then
                    Errormgs.Text = "Please Fill Style."
                Else
                    Errormgs.Text = ""
                    With ObjCommodityClass
                        .Commodityid = 0
                        .Commodity = TXTCommodity.Text.ToUpper
                        .save()

                        TXTCommodity.Text = ""
                        LBLCommodityID.Text = 0
                        TXTCommodity.Focus()

                    End With
                End If

        End Select
    End Sub
    Sub SaveSession()
        'Dim dt As DataTable = ObjCargoDetail.GetCargoDetailNewSearchPONoNewForDigitalNewNew(txtSeach.Text, cmbSeason.SelectedValue)
        Dim dt As DataTable = ObjCargoDetail.GetCargoDetailNewSearchPONoNewForDigitalNewNewNew(txtSeach.Text, cmbSeason.SelectedValue)
        If (Not CType(Session("DTAdd"), DataTable) Is Nothing) Then
            DTAdd = Session("DTAdd")
        Else
            DTAdd = New DataTable
            With DTAdd
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
                .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Constr", GetType(String))
                .Columns.Add("Composition", GetType(String))
                .Columns.Add("WeightPCS", GetType(String))
                .Columns.Add("WhitePCS", GetType(String))
                .Columns.Add("PackingPCS", GetType(String))
                .Columns.Add("SeasonDatabaseID", GetType(String))
                .Columns.Add("SeasonName", GetType(String))
                .Columns.Add("StyleArticle", GetType(String))
                .Columns.Add("CommodityID", GetType(String))
                .Columns.Add("Commodity", GetType(String))
                .Columns.Add("HsCode", GetType(String))
                .Columns.Add("DetailShipDate", GetType(String))
            End With
        End If
        For x = 0 To dt.Rows.Count - 1
            Dr = DTAdd.NewRow()


            Dr("POID") = dt.Rows(0)("POID")
            Dr("StyleID") = dt.Rows(0)("StyleID")
            Dr("StyleNo") = dt.Rows(0)("Style")

            Dr("SizeRange") = dt.Rows(0)("SizeRange")
            Dr("Constr") = dt.Rows(0)("Compositionnn")
            Dr("Composition") = dt.Rows(0)("Compositionnn")
            Dr("Quantity") = Math.Round((dt.Rows(0)("Quantity") * dt.Rows(0)("AssortQty") / 100) + dt.Rows(0)("Quantity"), 0) ' dt.Rows(0)("Quantity")
            Dr("ShippedQty") = dt.Rows(0)("ShippedQty")
            Dr("ReleaseQuantity") = dt.Rows(0)("ReleaseQuantity")
            Dr("Cartons") = 0
            Dr("ShippedRate") = dt.Rows(0)("ShippedRate")
            Dr("PONO") = dt.Rows(0)("PONO")
            Dr("CustomerName") = dt.Rows(0)("CustomerName")
            Dr("SupplierName") = dt.Rows(0)("Supplier")
            Dr("CustomerID") = dt.Rows(0)("CustomerID")
            Dr("VendorID") = dt.Rows(0)("VendorID")
            Dr("POPOID") = dt.Rows(0)("POPOID")
            Dr("Currency") = dt.Rows(0)("Currency")
            Dr("sid") = dt.Rows(0)("POID")
            Dr("WeightPCS") = 0
            Dr("WhitePCS") = 0
            Dr("PackingPCS") = 0
            Dr("SeasonDatabaseID") = dt.Rows(0)("SeasonDatabaseID")
            Dr("SeasonName") = dt.Rows(0)("SeasonName")
            Dr("StyleArticle") = dt.Rows(0)("StyleArticle")
            Dr("CommodityID") = 0
            Dr("Commodity") = ""
            Dr("HsCode") = ""
            Dr("DetailShipDate") = dt.Rows(0)("DetailShipDate")
            DTAdd.Rows.Add(Dr)
        Next
        Session("DTAdd") = DTAdd
        Session("objDataView") = Session("DTAdd") 'DTAdd
    End Sub
    Protected Sub TXTCommodity_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim dtCurrentTable As DataTable = DirectCast(Session("CurrentTable"), DataTable)
        For i As Integer = 0 To dgArticle.Items.Count - 1
            Dim TXTCommodity As TextBox = DirectCast(dgArticle.Items(i).FindControl("TXTCommodity"), TextBox)
            Dim LBLCommodityID As Label = DirectCast(dgArticle.Items(i).FindControl("LBLCommodityID"), Label)
            Dim DT As DataTable = ObjCargoDetail.GetCommodity(TXTCommodity.Text)
            If DT.Rows.Count > 0 Then
                Errormgs.Text = ""
                Errormgs.Visible = False
                LBLCommodityID.Text = DT.Rows(0)("CommodityID")

            Else
                Errormgs.Visible = True
                If TXTCommodity.Text = "" Then
                Else
                    Errormgs.Text = "Commodity Not Found Please Add"
                End If

                LBLCommodityID.Text = ""
            End If
        Next
    End Sub
    
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = objDPIMst.GetSeasonsForExport
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseid"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("Select...", "0"))

        Catch ex As Exception
        End Try
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
    ' Procedure that Binds the Grid
    Private Sub BindGrid()

        'Dim dt As DataTable = ObjCargoDetail.GetCargoDetailNewSearchPONoNewForDigitalNewNew(txtSeach.Text, cmbSeason.SelectedValue)
        Dim Dtt As DataTable = Session("objDataView")
        dgArticle.DataSource = Dtt
            dgArticle.DataBind()
            Dim x As Integer
            For x = 0 To dgArticle.Items.Count - 1
                Dim TXTWeightPCS As TextBox = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
                Dim txtWhitePCS As TextBox = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
                Dim txtPackingPCS As TextBox = CType(dgArticle.Items(x).FindControl("txtPackingPCS"), TextBox)
            Dim TXTStyle As TextBox = CType(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            Dim txtWhiteCarton As TextBox = CType(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
                TXTWeightPCS.Text = 0
                txtWhitePCS.Text = 0
            txtPackingPCS.Text = 0
            txtWhiteCarton.Text = 0
            TXTStyle.Text = Dtt.Rows(x)("StyleArticle")
        Next
       
    End Sub
    Protected Sub UpdateArticle(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("dtSelection") = Nothing
        Dim x As Int64
        Dim ID As Label
        Dim chkSelect As CheckBox
        Dim txtQuantity As TextBox
        Dim txtCarton, ShippedRate, TXTCommodity, txtHsCode As TextBox
        Dim LBLCommodityID As Label
        Dim TXTWeightPCS, txtWhitePCS, txtPackingPCS, txtPCS, txtCTNS, TXTStyle, txtWhiteCarton As TextBox
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
              .Columns.Add("SizeRange", GetType(String))
                .Columns.Add("Constr", GetType(String))
                .Columns.Add("Composition", GetType(String))
                .Columns.Add("WeightPCS", GetType(String))
                .Columns.Add("WhitePCS", GetType(String))
                .Columns.Add("PackingPCS", GetType(String))
               .Columns.Add("SeasonDatabaseID", GetType(String))
                .Columns.Add("SeasonName", GetType(String))
                .Columns.Add("StyleArticle", GetType(String))
                .Columns.Add("CommodityID", GetType(String))
                .Columns.Add("Commodity", GetType(String))
                .Columns.Add("HsCode", GetType(String))
                .Columns.Add("WhiteCarton", GetType(String))
            End With
        End If
        For x = 0 To dgArticle.Items.Count - 1
            chkSelect = CType(dgArticle.Items(x).FindControl("chkSelected"), CheckBox)
            ID = CType(dgArticle.Items(x).FindControl("lblID"), Label)
            txtQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            txtCarton = CType(dgArticle.Items(x).FindControl("Cartons"), TextBox)
            ShippedRate = CType(dgArticle.Items(x).FindControl("ShippedRate"), TextBox)

            TXTWeightPCS = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
            txtWhitePCS = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
            txtPackingPCS = CType(dgArticle.Items(x).FindControl("txtPackingPCS"), TextBox)
          
            TXTCommodity = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
            txtHsCode = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
            LBLCommodityID = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
            TXTStyle = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
            txtWhiteCarton = DirectCast(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)

            If txtCarton.Text = "" Then
                txtCarton.Text = 0
            End If
            If ShippedRate.Text = "" Then
                ShippedRate.Text = 0
            End If

            If txtWhiteCarton.Text = "" Then
                txtWhiteCarton.Text = 0
            End If

            If chkSelect.Checked = True Then
                'If (Convert.ToDecimal(dgArticle.Items(x).Cells(11).Text) + Convert.ToDecimal(txtQuantity.Text)) > (Convert.ToDecimal(dgArticle.Items(x).Cells(21).Text)) Then
                '    chkSelect.Checked = False
                '    Errormgs.Text = "You are not allowed to release more than Inpspected qty. Please consult QD Head."
                '    Errormgs.Visible = True
                'Else
                If ChekIDExist(ID.Text) = False Then
                    Errormgs.Text = ""
                    Errormgs.Visible = False
                    txtQuantity.Enabled = False
                    txtCarton.Enabled = False
                    ShippedRate.Enabled = False
                    Dr = dt.NewRow()
                    Dr("StyleID") = dgArticle.Items(x).Cells(9).Text
                    Dr("StyleNo") = dgArticle.Items(x).Cells(10).Text
                    Dr("SizeRange") = dgArticle.Items(x).Cells(11).Text
                    Dr("Constr") = dgArticle.Items(x).Cells(12).Text
                    Dr("Composition") = dgArticle.Items(x).Cells(13).Text
                    Dr("Quantity") = dgArticle.Items(x).Cells(15).Text
                    Dr("ShippedQty") = dgArticle.Items(x).Cells(16).Text
                    Dr("ReleaseQuantity") = txtQuantity.Text
                    Dr("Cartons") = txtCarton.Text
                    Dr("ShippedRate") = ShippedRate.Text
                    Dr("SeasonDatabaseID") = dgArticle.Items(x).Cells(0).Text
                    Dr("SeasonName") = dgArticle.Items(x).Cells(4).Text
                    Dr("PONO") = dgArticle.Items(x).Cells(5).Text
                    Dr("POID") = dgArticle.Items(x).Cells(6).Text
                    Dr("CustomerName") = dgArticle.Items(x).Cells(7).Text
                    Dr("SupplierName") = dgArticle.Items(x).Cells(8).Text
                    Dr("CustomerID") = dgArticle.Items(x).Cells(26).Text
                    Dr("VendorID") = dgArticle.Items(x).Cells(27).Text
                    Dr("POPOID") = dgArticle.Items(x).Cells(28).Text
                    Dr("Currency") = dgArticle.Items(x).Cells(29).Text
                    Dr("sid") = ID.Text
                    Dr("WeightPCS") = TXTWeightPCS.Text
                    Dr("WhitePCS") = txtWhitePCS.Text
                    Dr("PackingPCS") = txtPackingPCS.Text
                    Dr("StyleArticle") = TXTStyle.Text
                    Dr("CommodityID") = LBLCommodityID.Text
                    Dr("Commodity") = TXTCommodity.Text
                    Dr("HsCode") = txtHsCode.Text
                    Dr("WhiteCarton") = txtWhiteCarton.Text
                    dt.Rows.Add(Dr)
                End If

            Else
                Try
                   
                Catch ex As Exception
                End Try
            End If
        Next
        Session("dtSelection") = dt
    End Sub
    Protected Sub txtPackingPCS_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer
        For x = 0 To dgArticle.Items.Count - 1
            Dim txtPackingPCS As TextBox = CType(dgArticle.Items(x).FindControl("txtPackingPCS"), TextBox)
            Dim txtReleaseQuantity As TextBox = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
            Dim Cartons As TextBox = CType(dgArticle.Items(x).FindControl("Cartons"), TextBox)

            If txtPackingPCS.Text = 0 Then
                Cartons.Text = 0
            Else
                Cartons.Text = Math.Round(Val(txtReleaseQuantity.Text) / Val(txtPackingPCS.Text), 2)
            End If

        Next
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
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgArticle.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If cmbSeason.SelectedValue = 0 Then
                Errormgs.Text = "Select Season"
            Else
                Errormgs.Text = ""

                'Session("objDataView") = Nothing
                'dgArticle.DataSource = Nothing
                Dim objDataView As DataView

                Dim objDataTable As DataTable
                objDataTable = ObjCargoDetail.GetCargoDetailNewSearchPONoNewForDigitalNewNew(txtSeach.Text, cmbSeason.SelectedValue)
                If objDataTable.Rows.Count = Nothing Then
                    Errormgs.Text = " No Record Found"
                    dgArticle.Visible = False
                    Errormgs.Visible = True
                Else
                    Errormgs.Visible = False
                    dgArticle.Visible = True
                    'objDataView = New DataView(objDataTable)
                    'Session("objDataView") = objDataView
                    SaveSession()
                    BindGrid()
                    btnSelect.Visible = True
                End If
            End If


        Catch objUDException As UDException
        End Try
    End Sub
    Protected Sub BtnData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Session("objDataView") = Nothing
        dgArticle.DataSource = Nothing
        Dim objDataView As DataView
        Try
            Dim objDataTable As DataTable
            objDataTable = ObjCargoDetail.GetCargoDetailNewSearch(cmbUserName.SelectedValue)
            If objDataTable.Rows.Count = Nothing Then
                Errormgs.Text = " No Record Found"
                dgArticle.Visible = False
                Errormgs.Visible = True
            Else
                Errormgs.Visible = False
                dgArticle.Visible = True
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                btnSelect.Visible = True
            End If
        Catch objUDException As UDException
        End Try
    End Sub
    Private Sub BindUser()
        Dim dtUser As DataTable = objUser.getALlUMUser
        cmbUserName.DataSource = dtUser
        cmbUserName.DataValueField = "UserID"
        cmbUserName.DataTextField = "UserName"
        cmbUserName.DataBind()
        cmbUserName.Items.Insert(0, New ListItem("Select...", "0"))
    End Sub
    Protected Sub btnStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStyle.Click
        Session("objDataView") = Nothing
        dgArticle.DataSource = Nothing
        Dim objDataView As DataView
        Try
            Dim objDataTable As DataTable
            objDataTable = ObjCargoDetail.GetCargoDetailByStyleNo(style.Text)
            If objDataTable.Rows.Count = Nothing Then
                Errormgs.Text = " No Record Found"
                dgArticle.Visible = False
                Errormgs.Visible = True
            Else
                Errormgs.Visible = False
                dgArticle.Visible = True
                objDataView = New DataView(objDataTable)
                Session("objDataView") = objDataView
                BindGrid()
                btnSelect.Visible = True
            End If
        Catch objUDException As UDException
        End Try
    End Sub
    Protected Sub cmbECPDivision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbECPDivision.SelectedIndexChanged
        checkFuNCTION()
    End Sub
    Sub checkFuNCTION()
        If cmbECPDivision.SelectedItem.Text = "By Style" Then
            btnStyle.Visible = True
            lblStyle.Visible = True
            style.Visible = True
            Label1.Visible = False
            txtSeach.Visible = False
            btnSearch.Visible = False
            Session("objDataView") = Nothing
        ElseIf cmbECPDivision.SelectedItem.Text = "By PO NO." Then
            Label1.Visible = True
            txtSeach.Visible = True
            btnSearch.Visible = True
            btnStyle.Visible = False
            lblStyle.Visible = False
            style.Visible = False
            Session("objDataView") = Nothing
        End If
    End Sub
    Protected Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        Try
            Session("dtSelection") = Nothing
            Dim chkSelect As CheckBox
            Dim a As Integer = 0
            For a = 0 To dgArticle.Items.Count - 1
                chkSelect = CType(dgArticle.Items(a).FindControl("chkSelected"), CheckBox)
                chkSelect.Checked = True
            Next




            Dim x As Int64
            Dim ID As Label

            Dim txtQuantity As TextBox
            Dim txtCarton, ShippedRate, TXTCommodity, txtHsCode As TextBox
            Dim TXTWeightPCS, txtWhitePCS, txtPackingPCS, txtPCS, txtCTNS, TXTStyle, txtWhiteCarton As TextBox
            Dim LBLCommodityID As Label
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
                   .Columns.Add("SizeRange", GetType(String))

                    .Columns.Add("Constr", GetType(String))
                    .Columns.Add("Composition", GetType(String))
                    .Columns.Add("WeightPCS", GetType(String))
                    .Columns.Add("WhitePCS", GetType(String))
                    .Columns.Add("PackingPCS", GetType(String))
                    
                    .Columns.Add("SeasonDatabaseID", GetType(String))
                    .Columns.Add("SeasonName", GetType(String))
                    .Columns.Add("StyleArticle", GetType(String))
                    .Columns.Add("CommodityID", GetType(String))
                    .Columns.Add("Commodity", GetType(String))
                    .Columns.Add("HsCode", GetType(String))
                    .Columns.Add("WhiteCarton", GetType(String))
                End With
            End If
            For x = 0 To dgArticle.Items.Count - 1
                chkSelect = CType(dgArticle.Items(x).FindControl("chkSelected"), CheckBox)
                ID = CType(dgArticle.Items(x).FindControl("lblID"), Label)
                If chkSelect.Checked = True Then
                    txtQuantity = CType(dgArticle.Items(x).FindControl("txtReleaseQuantity"), TextBox)
                    txtCarton = CType(dgArticle.Items(x).FindControl("Cartons"), TextBox)
                    ShippedRate = CType(dgArticle.Items(x).FindControl("ShippedRate"), TextBox)
                    TXTWeightPCS = CType(dgArticle.Items(x).FindControl("TXTWeightPCS"), TextBox)
                    txtWhitePCS = CType(dgArticle.Items(x).FindControl("txtWhitePCS"), TextBox)
                    txtPackingPCS = CType(dgArticle.Items(x).FindControl("txtPackingPCS"), TextBox)
                    txtPCS = CType(dgArticle.Items(x).FindControl("txtPCS"), TextBox)
                    txtCTNS = CType(dgArticle.Items(x).FindControl("txtCTNS"), TextBox)
                    TXTCommodity = DirectCast(dgArticle.Items(x).FindControl("TXTCommodity"), TextBox)
                    txtHsCode = DirectCast(dgArticle.Items(x).FindControl("txtHsCode"), TextBox)
                    LBLCommodityID = DirectCast(dgArticle.Items(x).FindControl("LBLCommodityID"), Label)
                    TXTStyle = DirectCast(dgArticle.Items(x).FindControl("TXTStyle"), TextBox)
                    txtWhiteCarton = DirectCast(dgArticle.Items(x).FindControl("txtWhiteCarton"), TextBox)
                    Dr = dt.NewRow()

                    Dr("POID") = dgArticle.Items(x).Cells(6).Text
                    Dr("StyleID") = dgArticle.Items(x).Cells(9).Text
                    Dr("StyleNo") = dgArticle.Items(x).Cells(10).Text
                    Dr("SizeRange") = dgArticle.Items(x).Cells(11).Text
                    Dr("Constr") = dgArticle.Items(x).Cells(12).Text
                    Dr("Composition") = dgArticle.Items(x).Cells(13).Text
                    Dr("Quantity") = dgArticle.Items(x).Cells(15).Text
                    Dr("ShippedQty") = dgArticle.Items(x).Cells(16).Text
                    Dr("ReleaseQuantity") = txtQuantity.Text
                    Dr("Cartons") = txtCarton.Text
                    Dr("ShippedRate") = ShippedRate.Text
                    Dr("PONO") = dgArticle.Items(x).Cells(5).Text
                    Dr("CustomerName") = dgArticle.Items(x).Cells(7).Text
                    Dr("SupplierName") = dgArticle.Items(x).Cells(8).Text
                    Dr("CustomerID") = dgArticle.Items(x).Cells(26).Text
                    Dr("VendorID") = dgArticle.Items(x).Cells(27).Text
                    Dr("POPOID") = dgArticle.Items(x).Cells(28).Text
                    Dr("Currency") = dgArticle.Items(x).Cells(29).Text
                    Dr("sid") = ID.Text
                    Dr("WeightPCS") = TXTWeightPCS.Text
                    Dr("WhitePCS") = txtWhitePCS.Text
                    Dr("PackingPCS") = txtPackingPCS.Text
                    Dr("SeasonDatabaseID") = dgArticle.Items(x).Cells(0).Text
                    Dr("SeasonName") = dgArticle.Items(x).Cells(4).Text
                    Dr("StyleArticle") = TXTStyle.Text
                    Dr("CommodityID") = LBLCommodityID.Text
                    Dr("Commodity") = TXTCommodity.Text
                    Dr("HsCode") = txtHsCode.Text
                    Dr("WhiteCarton") = txtWhiteCarton.Text
                    dt.Rows.Add(Dr)

                Else
                    Try

                    Catch ex As Exception
                    End Try
                End If
            Next
            Session("dtSelection") = dt
        Catch ex As Exception

        End Try

    End Sub
End Class