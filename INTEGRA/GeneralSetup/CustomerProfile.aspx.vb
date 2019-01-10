Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Public Class CustomerProfile
    Inherits System.Web.UI.Page
    Dim dtUserName As New DataTable
    Dim objCustomerdetail As New EuroCentra.CustomerDetail
    Dim objCustomerDatabase As New CustomerDatabase
    Dim DtBuyerDetail As DataTable
    Dim dr As DataRow
    Dim lCustomerID As Long
    Dim userRole As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lCustomerID = Request.QueryString("lCustomerID")
        userRole = Session("RoleId")
        If Not Page.IsPostBack Then
            Session("DtBuyerDetail") = Nothing
            BindCountry()
            BindCustomerType()
            BindParentGroup()
            BindGeographicalTerritory()
            If lCustomerID > 0 Then
                Dim dtForQty As DataTable = objCustomerDatabase.GetCom(lCustomerID)
                Dim ExtraQty As Long = dtForQty.Rows(0)("ExtraQty")
                txtExtraQty.Text = ExtraQty
            Else
                txtExtraQty.Text = "5"
            End If
            If userRole = 32 Then
                trCommission.Visible = True
            Else
                trCommission.Visible = False
            End If
            If lCustomerID > 0 Then
                SetValuesEditMod()
            Else
                txtForaccountAndRisk.Text = " ITX TRADING S.A. Rue Louis-d’Affry 6 1700 Fribourg"
                txtNotifyparty.Text = "SCANWELL LOGISTICS SPAIN S.L. (BARCELONA)  EDIFICIO COLON. AVDA DE DRASSANAS 6-8,  3 - 3, 08001 BARCELONA, SPAIN  TEL : 34-935149285 (DIRECT),  CONTACT: CARLOS COLMENERO"
                txtPaymentTo.Text = "DIGITAL APPAREL (PVT) LTD.  HABIB METROPOLITAN BANK LTD.  Spencer Building, I.I. Chundrigar Road,  Karachi - Pakistan.  Swift Code: MPBLPKKA."
                txtBrandandsection.Text = "Bershka"
                txtConsignee.Text = "LOLALIZARUE DU MARQUIS 1"
                cmbCountry.SelectedValue = 171
                ChkIsActive.Checked = True
                txtBuyerBankName.Text = "AL BARAKA BANK (PAKISTAN) LIMITED"
                txtFinancialHandlingAddress.Text = "Lakhani Center, I.I. Chundrigar Road, KARACHI - PAKISTAN"
                txtSwiftCodeIBAN.Text = "AIINPKKA"
                RadtxtRemarks.Text = "N/A"
                TXTbANKaCCOUNTnO.Text = "0102116008013"
                TXTIBANno.Text = "PK34AIIN0000102116008013"
                txtASSORTMENT.Text = "AS PER BUYER ORDER SHEET"
                txtNEGOTIATION.Text = "WITHIN 21 DAYS AFTER B/L DATE."
                txtPAYMENTTERMS.Text = "BY CONFIRMED IRREVOCABLE, UNRESTRICTED AND TRANSFERABLE NEGOTIABLE THROUGH ANY BANK IN PAKISTAN) AT SIGHT L/C TO BE OPENED IMMEDIATELY IN OUR FAVOUR ALLOWING PART / TRANSSHIPMENT."
                txtPAYMENTREMARKS.Text = "+/- 3 PERCENT QUANTITY AND AMOUNT ALLOWED."
                txtPaymentTerm.Text = "L/C payment, 90 days from shipping date."
                txtPortOfLoading.Text = "Port Qasim or Any Karachi Port."
                txtFinalDestination.Text = "Barcelona"
            End If
        End If
    End Sub
    Sub SetValuesEditMod()
        Dim Dt As DataTable
        Dim x As Integer
        Try
            Dt = objCustomerDatabase.GetCustomerForEdit(lCustomerID)
            Dim dtCountry As New DataTable
            Dim dtCity As New DataTable
            cmbCustomerType.SelectedValue = Dt.Rows(0)("CustomerTypeID")
            cmbGeoterritory.SelectedValue = Dt.Rows(0)("Geographical_Territory_ID")
            txtCustomerName.Text = Dt.Rows(0)("CustomerName")
            txtShortName.Text = Dt.Rows(0)("Aliass")
            cmbParentGroup.SelectedValue = Dt.Rows(0)("ParentGroupID")
            dtCountry = objCustomerDatabase.getCountryID(Dt.Rows(0)("Country"))
            cmbCountry.SelectedValue = dtCountry.Rows(0)("Country_id")
            txtcity.Text = Dt.Rows(0)("City")
            txtCommission.Text = Dt.Rows(0)("Commission")
            txtAddress1.Text = Dt.Rows(0)("Address1")
            txtAddress2.Text = Dt.Rows(0)("Address2")
            txtContactNo.Text = Dt.Rows(0)("ContactNo")
            RadtxtRemarks.Text = Dt.Rows(0)("Remarks")
            If Dt.Rows(0)("IsActive") = 0 Then
                ChkIsActive.Checked = False
            Else
                ChkIsActive.Checked = True
            End If
            txtFaxNo.Text = Dt.Rows(0)("FaxNo")
            txtWebsite.Text = Dt.Rows(0)("Website")
            ChkRetail.Checked = Dt.Rows(0)("IndustryTypeRetail")
            ChkWholeSale.Checked = Dt.Rows(0)("IndustryTypeWholesale")
            ChkWareHouse.Checked = Dt.Rows(0)("IndustryTypeWarehouse")
            ChkImporter.Checked = Dt.Rows(0)("IndustryTypeImporter")
            chkMailOrder.Checked = Dt.Rows(0)("IndustryTypeMailOrder")
            chkCatalog.Checked = Dt.Rows(0)("IndustryTypeCatalog")
            txtAgent.Text = Dt.Rows(0)("LocalAgent")
            txtLogisticHandlingContact.Text = Dt.Rows(0)("LocalContact")
            txtDescription.Text = Dt.Rows(0)("LocalAddress")
            txtIntAgent.Text = Dt.Rows(0)("IntAgent")
            txtIntContact.Text = Dt.Rows(0)("IntContact")
            txtIntAddress.Text = Dt.Rows(0)("IntAddress")
            txtBuyerBankName.Text = Dt.Rows(0)("BuyerBankName")
            txtFinancialHandlingAddress.Text = Dt.Rows(0)("HandlingAddress")
            txtSwiftCodeIBAN.Text = Dt.Rows(0)("SwiftCodeIBAN")
            txtBuyerReferenceNo.Text = Dt.Rows(0)("BuyerReferenceNo")
            TXTbANKaCCOUNTnO.Text = Dt.Rows(0)("BankAccountNo")
            TXTIBANno.Text = Dt.Rows(0)("IBANNo")
            txtASSORTMENT.Text = Dt.Rows(0)("ASSORTMENT")
            txtNEGOTIATION.Text = Dt.Rows(0)("NEGOTIATION")
            txtPAYMENTTERMS.Text = Dt.Rows(0)("PAYMENTTERMS")
            txtPAYMENTREMARKS.Text = Dt.Rows(0)("PAYMENTREMARKS")
            txtForaccountAndRisk.Text = Dt.Rows(0)("ForaccountAndRisk")
            txtNotifyparty.Text = Dt.Rows(0)("Notifyparty")
            txtPaymentTo.Text = Dt.Rows(0)("PaymentTo")
            txtBrandandsection.Text = Dt.Rows(0)("Brandandsection")
            txtConsignee.Text = Dt.Rows(0)("Consignee")
            txtPaymentTerm.Text = Dt.Rows(0)("PaymentTerm")
            txtPortOfLoading.Text = Dt.Rows(0)("PortOfLoading")
            txtFinalDestination.Text = Dt.Rows(0)("FinalDestination")
            Dim dtdtl As New DataTable
            dtdtl = objCustomerDatabase.GetCustomerForEditdetail(lCustomerID)
            DtBuyerDetail = Nothing
            Session("DtBuyerDetail") = Nothing
            DtBuyerDetail = New DataTable
            With DtBuyerDetail
                .Columns.Add("CustomerDetailID", GetType(Long))
                .Columns.Add("Contact_Type_ID", GetType(String))
                .Columns.Add("ContactType", GetType(String))
                .Columns.Add("DepartmentNo", GetType(String))
                .Columns.Add("Buyer_Name", GetType(String))
                .Columns.Add("Designation", GetType(String))
                .Columns.Add("Email", GetType(String))
                .Columns.Add("CellNo", GetType(String))
                .Columns.Add("FaxNumber", GetType(String))
                .Columns.Add("BrandName", GetType(String))
            End With
            For x = 0 To dtdtl.Rows.Count - 1
                dr = DtBuyerDetail.NewRow()
                dr("CustomerDetailID") = dtdtl.Rows(x)("CustomerDetailID")
                dr("Contact_Type_ID") = dtdtl.Rows(x)("Contact_Type_ID")
                dr("ContactType") = dtdtl.Rows(x)("Contact_Type")
                dr("DepartmentNo") = dtdtl.Rows(x)("DepartmentNo")
                dr("Buyer_Name") = dtdtl.Rows(x)("Buyer_Name")
                dr("Designation") = dtdtl.Rows(x)("Designation")
                dr("Email") = dtdtl.Rows(x)("Email")
                dr("CellNo") = dtdtl.Rows(x)("CellNo")
                dr("FaxNumber") = dtdtl.Rows(x)("FaxNumber")
                dr("BrandName") = dtdtl.Rows(x)("BrandName")
                DtBuyerDetail.Rows.Add(dr)
            Next
            Session("DtBuyerDetail") = DtBuyerDetail
            BindBuyerGrid()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCountry()
        Try
            Dim dtCountry As DataTable
            dtCountry = objCustomerDatabase.GetAllCountries()
            cmbCountry.DataSource = dtCountry
            cmbCountry.DataTextField = "CountryName"
            cmbCountry.DataValueField = "Country_id"
            cmbCountry.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomerType()
        Dim dtCustomeType As DataTable
        dtCustomeType = objCustomerDatabase.GetCustomerType()
        cmbCustomerType.DataSource = dtCustomeType
        cmbCustomerType.DataTextField = "CustomerType"
        cmbCustomerType.DataValueField = "CustomerTypeID"
        cmbCustomerType.DataBind()
    End Sub
    Sub BindParentGroup()
        Dim dtParentGroup As DataTable
        dtParentGroup = objCustomerDatabase.GetParentGroup()
        cmbParentGroup.DataSource = dtParentGroup
        cmbParentGroup.DataTextField = "Parent"
        cmbParentGroup.DataValueField = "ParentGroupID"
        cmbParentGroup.DataBind()
    End Sub
    Sub BindGeographicalTerritory()
        Dim dtTerritory As DataTable
        dtTerritory = objCustomerDatabase.GetGeographicatTerritory()
        cmbGeoterritory.DataSource = dtTerritory
        cmbGeoterritory.DataTextField = "Territory"
        cmbGeoterritory.DataValueField = "Geographical_Territory_ID"
        cmbGeoterritory.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If lCustomerID > 0 Then
                'If dgBuyerDetail.Items.Count = 0 Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One Customer’s Contact Person Required")
                'Else
                SaveCustomerDatabase()
                GetCustomerDetail()
                dgBuyerDetail.Controls.Clear()
                DtBuyerDetail = Nothing
                Session("DtBuyerDetail") = Nothing
                Response.Redirect("CustomerProfileView.aspx")
                'End If
            Else
            Dim dtcheck As New DataTable
            dtcheck = objCustomerDatabase.CheckCustomerAlreadyExist(txtCustomerName.Text)
                'If dgBuyerDetail.Items.Count = 0 Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast One Customer’s Contact Person Required")
                If txtExtraQty.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Extra")
                Else
                    If dtcheck.Rows.Count > 0 Then
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Customer Already Exist")
                    Else
                        SaveCustomerDatabase()
                        GetCustomerDetail()
                        dgBuyerDetail.Controls.Clear()
                        DtBuyerDetail = Nothing
                        Session("DtBuyerDetail") = Nothing
                        Response.Redirect("CustomerProfileView.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub GetCustomerDetail()
        Dim x As Integer
        For x = 0 To dgBuyerDetail.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgBuyerDetail.MasterTableView.Items(x), GridDataItem)
            With objCustomerdetail
                If lCustomerID > 0 Then
                    .CustomerID = lCustomerID
                Else
                    .CustomerID = objCustomerDatabase.GetCustomerID
                End If
                .CustomerDetailID = item("CustomerDetailID").Text
                .DepartmentNo = item("DepartmentNo").Text.Replace("&nbsp;", "")
                .Contact_Type_ID = item("Contact_Type_ID").Text
                .Buyer_Name = item("Buyer_Name").Text
                .Designation = item("Designation").Text.Replace("&nbsp;", "")
                .CellNo = item("CellNo").Text.Replace("&nbsp;", "")
                .Email = item("Email").Text.Replace("&nbsp;", "")
                .Img_Foto = "Image Not Use Yet"
                .FaxNumber = item("FaxNumber").Text.Replace("&nbsp;", "")
                .BrandName = item("BrandName").Text.Replace("&nbsp;", "")
                .SaveCustomerDetail()
            End With
        Next
    End Sub
    Sub SaveCustomerDatabase()
        Try
            With objCustomerDatabase
                If lCustomerID > 0 Then
                    .CustomerID = lCustomerID
                    .Commission = txtCommission.Text
                    .CreationDate = objCustomerDatabase.GetCreationDate(lCustomerID)
                Else
                    .CustomerID = 0
                    .Commission = 0
                    .CreationDate = Date.Now
                End If
                .CustomerTypeID = cmbCustomerType.SelectedValue
                .Country = cmbCountry.SelectedItem.Text
                .Geographical_Territory_ID = cmbGeoterritory.SelectedValue
                .CustomerName = txtCustomerName.Text
                .Aliass = txtShortName.Text
                .ParentGroupID = cmbParentGroup.SelectedValue
                .Address1 = txtAddress1.Text
                .Address2 = txtAddress2.Text
                If txtcity.Text = "" Then
                    .City = "N/A"
                Else
                    .City = txtcity.Text
                End If
                If txtWebsite.Text = "" Then
                    .WebSite = "N/A"
                Else
                    .WebSite = txtWebsite.Text
                End If
                If txtContactNo.Text = "" Then
                    .ContactNo = "N/A"
                Else
                    .ContactNo = txtContactNo.Text
                End If
                If txtFaxNo.Text = "" Then
                    .FaxNo = "N/A"
                Else
                    .FaxNo = txtFaxNo.Text
                End If
                If ChkWholeSale.Checked Then
                    .IndustryTypeWholesale = True
                Else
                    .IndustryTypeWholesale = False
                End If

                If ChkRetail.Checked Then
                    .IndustryTypeRetail = True
                Else
                    .IndustryTypeRetail = False
                End If
                If ChkImporter.Checked Then
                    .IndustryTypeImporter = True
                Else
                    .IndustryTypeImporter = False
                End If
                If ChkWareHouse.Checked Then
                    .IndustryTypeWarehouse = True
                Else
                    .IndustryTypeWarehouse = False
                End If
                If chkMailOrder.Checked Then
                    .IndustryTypeMailOrder = True
                Else
                    .IndustryTypeMailOrder = False
                End If
                If chkCatalog.Checked Then
                    .IndustryTypeCatalog = True
                Else
                    .IndustryTypeCatalog = False
                End If
                If txtAgent.Text = "" Then
                    .LocalAgent = "N/A"
                Else
                    .LocalAgent = txtAgent.Text
                End If
                If txtLogisticHandlingContact.Text = "" Then
                    .LocalContact = "N/A"
                Else
                    .LocalContact = txtLogisticHandlingContact.Text
                End If
                If txtDescription.Text = "" Then
                    .LocalAddress = "N/A"
                Else
                    .LocalAddress = txtDescription.Text
                End If
                If txtIntAgent.Text = "" Then
                    .IntAgent = "N/A"
                Else
                    .IntAgent = txtIntAgent.Text
                End If
                If txtIntContact.Text = "" Then
                    .IntContact = "N/A"
                Else
                    .IntContact = txtIntContact.Text
                End If
                If txtIntAddress.Text = "" Then
                    .IntAddress = "N/A"
                Else
                    .IntAddress = txtIntAddress.Text
                End If
                If txtBuyerBankName.Text = "" Then
                    .BuyerBankName = "N/A"
                Else
                    .BuyerBankName = txtBuyerBankName.Text
                End If
                If txtFinancialHandlingAddress.Text = "" Then
                    .HandlingAddress = "N/A"
                Else
                    .HandlingAddress = txtFinancialHandlingAddress.Text
                End If
                If txtSwiftCodeIBAN.Text = "" Then
                    .SwiftCodeIBAN = "N/A"
                Else
                    .SwiftCodeIBAN = txtSwiftCodeIBAN.Text
                End If
                If RadtxtRemarks.Text = "" Then
                    .Remarks = "N/A"
                Else
                    .Remarks = RadtxtRemarks.Text
                End If
                .imgOriginalLogo = ""
                .imgWaterMark = ""
                .imgBarcode = ""
                If ChkIsActive.Checked = True Then
                    .IsActive = True
                Else
                    .IsActive = False
                End If
                If txtExtraQty.Text = "" Then
                    .ExtraQty = 0
                Else
                    .ExtraQty = txtExtraQty.Text
                End If
                If txtBuyerReferenceNo.Text = "" Then
                    .BuyerReferenceNo = "N/A"
                Else
                    .BuyerReferenceNo = txtBuyerReferenceNo.Text.ToUpper
                End If
                .BankAccountNo = TXTbANKaCCOUNTnO.Text.ToUpper
                .IBANNo = TXTIBANno.Text.ToUpper
                .ASSORTMENT = txtASSORTMENT.Text.ToUpper
                .NEGOTIATION = txtNEGOTIATION.Text.ToUpper
                .PAYMENTTERMS = txtPAYMENTTERMS.Text.ToUpper
                .PAYMENTREMARKS = txtPAYMENTREMARKS.Text.ToUpper
                .ForaccountAndRisk = txtForaccountAndRisk.Text
                .Notifyparty = txtNotifyparty.Text
                .PaymentTo = txtPaymentTo.Text
                .Brandandsection = txtBrandandsection.Text
                .Consignee = txtConsignee.Text
                .PaymentTerm = txtPaymentTerm.Text
                .PortOfLoading = txtPortOfLoading.Text
                .FinalDestination = txtFinalDestination.Text
                .SaveCustomer()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNew.Click
        Try
            If txtBuyerName.Text <> "" Then
                SaveSession()
                BindBuyerGrid()
                ClearControls()
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Buyer Name")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtBuyerDetail"), DataTable) Is Nothing) Then
            DtBuyerDetail = Session("DtBuyerDetail")
        Else
            DtBuyerDetail = New DataTable
            With DtBuyerDetail
                .Columns.Add("CustomerDetailID", GetType(Long))
                .Columns.Add("Contact_Type_ID", GetType(Long))
                .Columns.Add("ContactType", GetType(String))
                .Columns.Add("Buyer_Name", GetType(String))
                .Columns.Add("Designation", GetType(String))
                .Columns.Add("Email", GetType(String))
                .Columns.Add("CellNo", GetType(String))
                .Columns.Add("FaxNumber", GetType(String))
                .Columns.Add("DepartmentNo", GetType(String))
                .Columns.Add("BrandName", GetType(String))
            End With
        End If
        dr = DtBuyerDetail.NewRow()
        dr("CustomerDetailID") = 0
        dr("Contact_Type_ID") = 1
        dr("ContactType") = ""
        dr("Buyer_Name") = txtBuyerName.Text
        If txtDesignation.Text = "" Then
            dr("Designation") = ""
        Else
            dr("Designation") = txtDesignation.Text
        End If
        If txtEmail.Text = "" Then
            dr("Email") = ""
        Else
            dr("Email") = txtEmail.Text
        End If
        If txtCellNo.Text = "" Then
            dr("CellNo") = ""
        Else
            dr("CellNo") = txtCellNo.Text
        End If
        If txtFaxNumber.Text = "" Then
            dr("FaxNumber") = ""
        Else
            dr("FaxNumber") = txtFaxNumber.Text
        End If
        If txtBuyingDept.Text = "" Then
            dr("DepartmentNo") = ""
        Else
            dr("DepartmentNo") = txtBuyingDept.Text
        End If
        If txtBrandName.Text = "" Then
            dr("BrandName") = ""
        Else
            dr("BrandName") = txtBrandName.Text
        End If
        DtBuyerDetail.Rows.Add(dr)
        Session("DtBuyerDetail") = DtBuyerDetail
    End Sub
    Private Sub BindBuyerGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtBuyerDetail")
            If objDatatble.Rows.Count > 0 Then
                dgBuyerDetail.Visible = True
                dgBuyerDetail.VirtualItemCount = objDatatble.Rows.Count
                dgBuyerDetail.DataSource = objDatatble
                dgBuyerDetail.DataBind()
            Else
                dgBuyerDetail.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtBuyingDept.Text = " "
        txtBuyerName.Text = " "
        txtDesignation.Text = " "
        txtCellNo.Text = " "
        txtEmail.Text = " "
        txtFaxNumber.Text = " "
        txtBrandName.Text = " "
    End Sub
    Protected Sub dgBuyerDetail_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgBuyerDetail.ItemCommand
        Select Case e.CommandName
            Case "Remove"
                DtBuyerDetail = CType(Session("DtBuyerDetail"), DataTable)
                If (Not DtBuyerDetail Is Nothing) Then
                    If (DtBuyerDetail.Rows.Count > 0) Then
                        Dim llCustomerDetailID As Integer = dgBuyerDetail.Items(e.Item.ItemIndex).Cells(0).Text
                        DtBuyerDetail.Rows.RemoveAt(e.Item.ItemIndex)
                        objCustomerdetail.DeleteDetailFromCustomerDetail(llCustomerDetailID)
                        Session("DtBuyerDetail") = DtBuyerDetail
                        BindBuyerGrid()
                        If DtBuyerDetail.Rows.Count = 0 Then
                            dgBuyerDetail.Controls.Clear()
                            dgBuyerDetail.Visible = False
                        End If
                    Else
                        dgBuyerDetail.Visible = False
                    End If
                End If
        End Select
    End Sub
    Sub HideRepresentedFields()
    End Sub
    Sub ShowRepresentedFields()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        dgBuyerDetail = Nothing
        Session("dgBuyerDetail") = Nothing
        Response.Redirect("CustomerProfileView.aspx")
    End Sub
    Protected Sub dgBuyerDetail_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgBuyerDetail.DeleteCommand
        DtBuyerDetail = CType(Session("DtBuyerDetail"), DataTable)
        If (Not DtBuyerDetail Is Nothing) Then
            If (DtBuyerDetail.Rows.Count > 0) Then
                Dim CustomerDetailID As Integer = DtBuyerDetail.Rows(e.Item.ItemIndex)("CustomerDetailID")
                DtBuyerDetail.Rows.RemoveAt(e.Item.ItemIndex)
                objCustomerdetail.DeleteDetailFromCustomerDetail(CustomerDetailID)
                BindBuyerGrid()
            Else
            End If
        End If
    End Sub
End Class
