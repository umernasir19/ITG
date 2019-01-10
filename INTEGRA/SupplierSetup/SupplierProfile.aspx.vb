Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO

Public Class SupplierProfile
    Inherits System.Web.UI.Page
    Dim objCustomerDatabase As New CustomerDatabase
    Dim objVerticalIntegration As New VenderVerticalIntegration
    Dim objVender As New Vender
    Dim objVenderDetail As New VenderDetail
    Dim ObjVenderGradingScale As New VenderGradingScale
    Dim ObjVenderPersonnel As New VenderPersonnel
    Dim ObjVenderDemographics As New VenderDemographics
    Dim objtblSupplierCategory As New tblSupplierCategory
    Dim DtVenderPerson As DataTable
    Dim dr As DataRow
    Dim lVenderId As Long
    Dim DtVenderDemographics, DtVerticalIntegration, DtProductPortFolio As DataTable
    Dim objSicialCompliance As New VenderSocialCompliance
    Dim GeneralCode As New GeneralCode
    Dim UserId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lVenderId = Request.QueryString("lVenderLibraryID")
        UserId = Session("UserId")
        If Not Page.IsPostBack Then
            '--Get User Info by Last update by
            Dim dtuserinfo As New DataTable
            Session("DtVenderPerson") = Nothing
            Session("VAFName") = Nothing
            Session("VAFUpload") = Nothing
            Session("DtVenderDemographics") = Nothing
            Session("dtFile") = Nothing
            Session("DtVerticalIntegration") = Nothing
            Session("DtProductPortFolio") = Nothing
            Session("objDataView1") = Nothing
            dtuserinfo = objVender.GetUserInfo(UserId)
            txtLastupdatedBy.Text = dtuserinfo.Rows(0)("UserName").ToString
            txtLastUpdatedon.Text = Date.Today
            objSicialCompliance.DeleteStyleUploadDetailTable()

            BindCountry()
            BindSupplierCategory()
            BindTown()
            BindProductGroup()
            BindVerticalIntegration()
            lnkCertificate.Visible = False
            If lVenderId > 0 Then
                SetValuesEditMod()
                lnkCertificate.Visible = True
                btnSave.Enabled = True

            Else
                cmbCountry.SelectedValue = 171
                BindCities()
                SCCreationDate.Text = Date.Today
            End If

            cmbVerticalIntegration.Visible = True
            txtverticalintegration.Visible = False
            btnaddverticalintegration.Visible = False
            btnsaveverticalintegration.Visible = False

            UpcmbVerticalIntegration.Update()
            UptxtVerticalIntegration.Update()
            UpbtnAddVerticalIntegration.Update()
            UpbtnSaveVerticalIntegration.Update()

            cmbProductGroup.Visible = True
            txtProductPortfolio.Visible = False
            btnAddProductPortfolio.Visible = False
            btnSaveProductPortfolio.Visible = False

            UpcmbProductPortfolio.Update()
            UptxtProductPortfolio.Update()
            UpbtnAddProductPortfolio.Update()
            UpbtnSaveProductPortfolio.Update()

        End If
    End Sub
    Sub SetValuesEditMod()
        Dim Dt As DataTable
        Dim DtProductGroup As DataTable
        Dim DtVerticalIntegration As DataTable
        Dim DtVenderPersonel As DataTable
        Dim x As Integer
        '-----Master Values
        Try
            Dt = objVender.VenderEdit(lVenderId)
            cmbSupplierType.SelectedValue = Dt.Rows(0)("SupplierStatus")
            txtSupplierCode.Text = Dt.Rows(0)("VenderCode")
            txtShortName.Text = Dt.Rows(0)("ShortName")
            txtSupplierName.Text = Dt.Rows(0)("VenderName")
            cmbCountry.SelectedValue = Dt.Rows(0)("CountryID")
            BindCities()
            cmbCity.SelectedValue = Dt.Rows(0)("City")
            BindSupplierCategory()
            cmbSupCat.SelectedValue = Dt.Rows(0)("SupplierCategoryID")
            txtAddress1.Text = Dt.Rows(0)("Address1")
            txtAddress2.Text = Dt.Rows(0)("Address2")
            txtContactNo.Text = Dt.Rows(0)("PhoneNumber")
            txtZIPCode.Text = Dt.Rows(0)("ZipCode")
            txtWebsite.Text = Dt.Rows(0)("Website")
            txtFaxNo.Text = Dt.Rows(0)("FaxNo")
            'bilal new fields
            txtMinQty.Text = Dt.Rows(0)("MinQty")
            txtLeadTime.Text = Dt.Rows(0)("LeadTime")
            txtoneyear.Text = Dt.Rows(0)("TOOneYear")
            txttwoyear.Text = Dt.Rows(0)("TOTwoYear")
            txtthreeyear.Text = Dt.Rows(0)("TOThreeYear")
            txtBankName.Text = Dt.Rows(0)("BankName")
            txtBankCode.Text = Dt.Rows(0)("BankCode")
            txtBankAddress.Text = Dt.Rows(0)("BankAddress")
            txtBankFax.Text = Dt.Rows(0)("BankFax")
            txtBankACNo.Text = Dt.Rows(0)("BankACNo")
            txtBankSwiftCode.Text = Dt.Rows(0)("BankSwiftCode")
            txtRemarks.Text = Dt.Rows(0)("Remarks")
            'Vender Grading Scele

            txtAboutSupplier.Text = Dt.Rows(0)("AboutSupplier")
            txtCapacity.Text = Dt.Rows(0)("Capacity")
            cmbCapacityUnit.SelectedValue = Dt.Rows(0)("CapacityUnit")
            txtTurnOver.Text = Dt.Rows(0)("Annualturnover")
            cmdTurnOverUnit.SelectedValue = Dt.Rows(0)("AmtSign")
            txtYearStarted.Text = Dt.Rows(0)("YearStarted")
            txtLocation.Text = Dt.Rows(0)("Town")
            '----Use for image 
            Dim VAFName As String = ""
            Dim Vaf As String = Dt.Rows(0)("VAFName")
            If Vaf = "" Then
                lnkFIlePicture.Visible = False
            Else
                Dim bytes As Byte() = Dt.Rows(0)("VAFUpload")
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                'ImageVAF.ImageUrl = "data:image/png;base64," & base64String
                'ImageVAF.Visible = True
                lnkFIlePicture.Visible = True
                VAFName = Dt.Rows(0)("VAFName")
                Session("VAFName") = VAFName
                Session("VAFUpload") = bytes

            End If


            '---End

           

            '--------------------Vender Personel Values
            DtVenderPersonel = objVender.VenderPersonelEdit(lVenderId)
            DtVenderPerson = Nothing
            Session("DtVenderPerson") = Nothing
            DtVenderPerson = New DataTable
            With DtVenderPerson
                .Columns.Add("VenderPersonnelID", GetType(Long))
                .Columns.Add("ContactType", GetType(String))
                .Columns.Add("PersonName", GetType(String))
                .Columns.Add("Designation", GetType(String))
                .Columns.Add("EmailAddress", GetType(String))
                .Columns.Add("CellNo", GetType(String))
            End With
            For x = 0 To DtVenderPersonel.Rows.Count - 1
                dr = DtVenderPerson.NewRow()
                dr("VenderPersonnelID") = DtVenderPersonel.Rows(x)("VenderPersonnelID")
                dr("ContactType") = DtVenderPersonel.Rows(x)("ContactType")
                dr("PersonName") = DtVenderPersonel.Rows(x)("PersonName")
                dr("Designation") = DtVenderPersonel.Rows(x)("Designation")
                dr("EmailAddress") = DtVenderPersonel.Rows(x)("EmailAddress")
                dr("CellNo") = DtVenderPersonel.Rows(x)("CellNo")
                DtVenderPerson.Rows.Add(dr)
            Next
            ' DtVenderPerson.PrimaryKey = New DataColumn() {DtVenderPerson.Columns("VenderPersonnelID")}
            Session("DtVenderPerson") = DtVenderPerson
            BindVenderGrid()

            Dim dtt As DataTable = objVender.VenderDemographicsEdit(lVenderId)
            DtVenderDemographics = Nothing
            Session("DtVenderDemographics") = Nothing
            DtVenderDemographics = New DataTable

            With DtVenderDemographics
                .Columns.Add("VDID", GetType(Long))
                .Columns.Add("Factory", GetType(String))
                .Columns.Add("CoveredArea", GetType(Decimal))
                .Columns.Add("TownID", GetType(Long))
                .Columns.Add("Town", GetType(String))
            End With
            For x = 0 To dtt.Rows.Count - 1
                dr = DtVenderDemographics.NewRow()
                dr("VDID") = dtt.Rows(x)("VDID")
                dr("Factory") = dtt.Rows(x)("Factory")
                dr("CoveredArea") = dtt.Rows(x)("CoveredArea")
                dr("TownID") = dtt.Rows(x)("TownID")
                dr("Town") = dtt.Rows(x)("Town")
                DtVenderDemographics.Rows.Add(dr)
            Next
            Session("DtVenderDemographics") = DtVenderDemographics
            BindVenderGridG()


            '----Social Complince
            Dim dtRealFile As DataTable = objSicialCompliance.GetFileInfoNew(lVenderId)
            Session("dtFile") = dtRealFile
            Dim objDataView As DataView
            objDataView = New DataView(dtRealFile)
            If objDataView.Count > 0 Then
                dgSocialCompliance.Visible = True
                dgSocialCompliance.RecordCount = objDataView.Count
                dgSocialCompliance.DataSource = objDataView
                dgSocialCompliance.DataBind()
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
                dgSocialCompliance.Visible = False
            End If
            ' End If

            dtt = objDataView.ToTable
            Dim y As Integer = 0
            For y = 0 To dgSocialCompliance.Items.Count - 1
                Dim Image1 As ImageButton = DirectCast(dgSocialCompliance.Items(y).FindControl("Image1"), ImageButton)

                Dim bytess As Byte() = DirectCast(dtt.Rows(y)("CertificateImage"), Byte())
                Dim base64Strings As String = Convert.ToBase64String(bytess, 0, bytess.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64Strings

            Next

            '-----------New
           
            'For Vertical Integration
            'DtVerticalIntegration = objVender.VenderVerticalIntegrationEdit(lVenderId)
            'Dim ii As Integer
            'For ii = 0 To DtVerticalIntegration.Rows.Count - 1
            '    cmbVerticalIntegration.Items.FindItemByValue(DtVerticalIntegration.Rows(ii)("VVIID")).Checked = True
            'Next

            '--------------------Vender Vertical Integration
            Dim dtV As DataTable = objVender.VenderVerticalIntegrationEdit(lVenderId)
            DtVerticalIntegration = Nothing
            Session("DtVerticalIntegration") = Nothing
            DtVerticalIntegration = New DataTable
            With DtVerticalIntegration
                .Columns.Add("VenderDetailID", GetType(Long))
                .Columns.Add("VenderID", GetType(Long))
                .Columns.Add("ID", GetType(Long))
                .Columns.Add("Type", GetType(String))
                .Columns.Add("VerticalIntegration", GetType(String))
                .Columns.Add("InhouseOutSource", GetType(String))
            End With
            'For Vertical Integration
            Dim xx As Integer
            '  For xx = 0 To cmbVerticalIntegration.CheckedItems.Count - 1
            For xx = 0 To dtV.Rows.Count - 1
                dr = DtVerticalIntegration.NewRow()
                dr("VenderDetailID") = 0
                dr("VenderID") = 0
                dr("ID") = dtV.Rows(xx)("ID").ToString
                dr("Type") = "Vertical Integration"
                dr("VerticalIntegration") = dtV.Rows(xx)("Name").ToString
                dr("InhouseOutSource") = dtV.Rows(xx)("InhouseOutSource").ToString
                DtVerticalIntegration.Rows.Add(dr)
                Session("DtVerticalIntegration") = DtVerticalIntegration
            Next
            BindVenderGridVerticalIntegration()

            '-----------New
            'For Product Group
            DtProductGroup = objVender.VenderProductGroupEdit(lVenderId)
            Dim i As Integer
            For i = 0 To DtProductGroup.Rows.Count - 1
                cmbProductGroup.Items.FindItemByValue(DtProductGroup.Rows(i)("VVIID")).Checked = True
            Next
            '--------------------Vender Product PortFolio
            DtProductPortFolio = Nothing
            Session("DtProductPortFolio") = Nothing
            DtProductPortFolio = New DataTable
            With DtProductPortFolio
                .Columns.Add("VenderDetailID", GetType(Long))
                .Columns.Add("VenderID", GetType(Long))
                .Columns.Add("ID", GetType(Long))
                .Columns.Add("Type", GetType(String))
                .Columns.Add("ProductPortfolio", GetType(String))

            End With
            'For Vertical Integration
            Dim xxx As Integer
            For xxx = 0 To cmbProductGroup.CheckedItems.Count - 1
                dr = DtProductPortFolio.NewRow()
                dr("VenderDetailID") = 0
                dr("VenderID") = 0
                dr("ID") = cmbProductGroup.CheckedItems(xxx).Value
                dr("Type") = "Product Group"
                dr("ProductPortfolio") = cmbProductGroup.CheckedItems(xxx).Text

                DtProductPortFolio.Rows.Add(dr)
                Session("DtProductPortFolio") = DtProductPortFolio
            Next
            BindProductPortFolio()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplierCategory()
        Try
            Dim dt As DataTable
            dt = objtblSupplierCategory.GetAllCategories()
            cmbSupCat.DataSource = dt
            cmbSupCat.DataTextField = "SupplierCategoryName"
            cmbSupCat.DataValueField = "SupplierCategoryID"
            cmbSupCat.DataBind()

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
            BindCities()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindTown()
        Try
            Dim dt As DataTable
            dt = objCustomerDatabase.GetAllTown()
            cmbTown.DataSource = dt
            cmbTown.DataTextField = "Town"
            cmbTown.DataValueField = "TownID"
            cmbTown.DataBind()
            BindCities()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BindCities()
        Dim CountryId As Long = cmbCountry.SelectedValue
        Dim dtCity As DataTable
        dtCity = objCustomerDatabase.GetCities(CountryId)
        cmbCity.DataSource = dtCity
        cmbCity.DataTextField = "city"
        cmbCity.DataValueField = "id"
        cmbCity.DataBind()
    End Sub
    Protected Sub cmbCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbCountry.SelectedIndexChanged
        BindCities()
    End Sub
    Sub BindProductGroup()
        Try
            Dim dtProductGroup As DataTable
            dtProductGroup = objVerticalIntegration.GetProductGroup()
            cmbProductGroup.DataSource = dtProductGroup
            cmbProductGroup.DataTextField = "Name"
            cmbProductGroup.DataValueField = "VVIID"
            cmbProductGroup.DataBind()
            BindCities()
        Catch ex As Exception

        End Try
    End Sub
    Sub BindVerticalIntegration()
        Try
            Dim dtVerticalIntegration As DataTable
            dtVerticalIntegration = objVerticalIntegration.GetVerticalIntegration()
            cmbVerticalIntegration.DataSource = dtVerticalIntegration
            cmbVerticalIntegration.DataTextField = "Name"
            cmbVerticalIntegration.DataValueField = "VVIID"
            cmbVerticalIntegration.DataBind()
            BindCities()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txtAddMore.Click
        Try
            If txtPersonName.Text <> "" And txtDesignation.Text <> "" And txtCellNo.Text <> "" And txtEmail.Text <> "" Then
                SaveSession()
                BindVenderGrid()
                ClearControls()
                btnSave.Enabled = True
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill All Boxes In Contact Person")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSession()
        If (Not CType(Session("DtVenderPerson"), DataTable) Is Nothing) Then
            DtVenderPerson = Session("DtVenderPerson")
        Else
            DtVenderPerson = New DataTable
            With DtVenderPerson
                .Columns.Add("VenderPersonnelID", GetType(Long))
                .Columns.Add("ContactType", GetType(String))
                .Columns.Add("PersonName", GetType(String))
                .Columns.Add("Designation", GetType(String))
                .Columns.Add("EmailAddress", GetType(String))
                .Columns.Add("CellNo", GetType(String))
            End With
        End If
        dr = DtVenderPerson.NewRow()
        dr("VenderPersonnelID") = 0
        dr("ContactType") = "N/A"
        dr("PersonName") = txtPersonName.Text
        dr("Designation") = txtDesignation.Text
        dr("EmailAddress") = txtEmail.Text
        dr("CellNo") = txtCellNo.Text
        DtVenderPerson.Rows.Add(dr)

        Session("DtVenderPerson") = DtVenderPerson
    End Sub
    Private Sub BindVenderGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtVenderPerson")
            If objDatatble.Rows.Count > 0 Then
                dgVenderPersonnel.Visible = True
                dgVenderPersonnel.VirtualItemCount = objDatatble.Rows.Count
                dgVenderPersonnel.DataSource = objDatatble
                dgVenderPersonnel.DataBind()
            Else
                dgVenderPersonnel.Visible = False
            End If
            '  Session.Remove("DtBuyerDetail")
            TryCast(dgVenderPersonnel.MasterTableView.GetColumn("VenderPersonnelID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()

        txtPersonName.Text = ""
        txtDesignation.Text = ""
        txtCellNo.Text = ""
        txtEmail.Text = ""
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtSupplierName.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please enter supplier name")
            ElseIf cmbProductGroup.CheckedItems.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Product Group must selected")
                'ElseIf cmbVerticalIntegration.CheckedItems.Count = 0 Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one Vertical Integration must selected")
            ElseIf dgVenderPersonnel.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Atleast one supplier's contact person required")
            Else
                SaveVender()
                SaveVenderDetail()
                SaveVenderGradingScale()
                SaveVenderPersonel()
                SaveVenderDemographics()
                '-------------------------------- End 
                Response.Redirect("SupplierProfileView.aspx")
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveVender()
        Try
            '------------- save Master Values
            If lVenderId > 0 Then
                objVender.VenderLibraryID = lVenderId
            End If
            With objVender
                .SupplierStatus = cmbSupplierType.SelectedItem.Text
                If txtSupplierName.Text = "" Then
                    .VenderName = "N/A"
                Else
                    .VenderName = txtSupplierName.Text
                End If
                If txtSupplierCode.Text = "" Then
                    .VenderCode = "N/A"
                Else
                    .VenderCode = txtSupplierCode.Text
                End If
                If txtAddress1.Text = "" Then
                    .Address1 = "N/A"
                Else
                    .Address1 = txtAddress1.Text
                End If
                If txtAddress2.Text = "" Then
                    .Address2 = "N/A"
                Else
                    .Address2 = txtAddress2.Text
                End If
                If txtZIPCode.Text = "" Then
                    .ZipCode = "N/A"
                Else
                    .ZipCode = txtZIPCode.Text
                End If
                If txtContactNo.Text = "" Then
                    .PhoneNumber = "N/A"
                Else
                    .PhoneNumber = txtContactNo.Text
                End If

                .City = cmbCity.SelectedValue
                .CountryID = cmbCountry.SelectedValue
                If txtShortName.Text = "" Then
                    .ShortName = "N/A"
                Else
                    .ShortName = txtShortName.Text
                End If
                If txtFaxNo.Text = "" Then
                    .FaxNo = "N/A"
                Else
                    .FaxNo = txtFaxNo.Text
                End If

                .IsActive = True
                If txtWebsite.Text = "" Then
                    .Website = "N/A"
                Else
                    .Website = txtWebsite.Text
                End If

                .LongitudeandLatitude = ""
                .SupplierCategoryID = cmbSupCat.SelectedValue
                If txtYearStarted.Text = "" Then
                    .YearStarted = "N/A"
                Else
                    .YearStarted = txtYearStarted.Text
                End If

                .imgOriginalLogo = ""
                .imgWaterMark = ""
                .VAF = ""
                .VAFuploadDate = Date.Now.Year.ToString() + "-" + Date.Now.Month.ToString() + "-" + Date.Now.Day.ToString()
                If txtMinQty.Text = "" Then
                    .MinQty = "N/A"
                Else
                    .MinQty = txtMinQty.Text
                End If
                If txtLeadTime.Text = "" Then
                    .LeadTime = "N/A"
                Else
                    .LeadTime = txtLeadTime.Text
                End If
                If txtoneyear.Text = "" Then
                    .TOOneYear = "N/A"
                Else
                    .TOOneYear = txtoneyear.Text
                End If
                If txttwoyear.Text = "" Then
                    .TOTwoYear = "N/A"
                Else
                    .TOTwoYear = txttwoyear.Text
                End If
                If txtthreeyear.Text = "" Then
                    .TOThreeYear = "N/A"
                Else
                    .TOThreeYear = txtthreeyear.Text
                End If
                If txtBankName.Text = "" Then
                    .BankName = "N/A"
                Else
                    .BankName = txtBankName.Text
                End If
                If txtBankCode.Text = "" Then
                    .BankCode = "N/A"
                Else
                    .BankCode = txtBankCode.Text
                End If
                If txtBankAddress.Text = "" Then
                    .BankAddress = "N/A"
                Else
                    .BankAddress = txtBankAddress.Text
                End If
                If txtBankFax.Text = "" Then
                    .BankFax = "N/A"
                Else
                    .BankFax = txtBankFax.Text
                End If
                If txtBankACNo.Text = "" Then
                    .BankACNo = "N/A"
                Else
                    .BankACNo = txtBankACNo.Text
                End If
                If txtBankSwiftCode.Text = "" Then
                    .BankSwiftCode = "N/A"
                Else
                    .BankSwiftCode = txtBankSwiftCode.Text
                End If
                If txtRemarks.Text = "" Then
                    .Remarks = "N/A"
                Else
                    .Remarks = txtRemarks.Text
                End If

                If Session("VAFName") Is Nothing Then
                    Dim path As String = Server.MapPath("../Images/" & "no-image.JPG")
                    .VAFUpload = GetFileContentVAF(path)
                    .VAFName = "NoImage.JPEG"
                Else
                    .VAFName = Session("VAFName")
                    .VAFUpload = Session("VAFUpload")
                End If
                .LastUpdatedBy = txtLastupdatedBy.Text
                .LastUpdatedOn = txtLastUpdatedon.Text
                .Town = txtLocation.Text
                .SaveVender()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetFileContentVAF(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Sub SaveVenderDetail()
        Try
            Dim VenderID As Long
            If lVenderId > 0 Then
                VenderID = lVenderId
                objVenderDetail.RemoveBeforeEdit(lVenderId)
            Else
                VenderID = objVender.GetCurrentId
            End If
            'For Product Group
            Dim x As Integer
            For x = 0 To cmbProductGroup.CheckedItems.Count - 1
                With objVenderDetail
                    .VenderDetailID = 0
                    .ID = cmbProductGroup.CheckedItems(x).Value
                    .Type = "Product Group"
                    .Venderid = VenderID
                    .InhouseOutSource = "N/A"
                    .SaveVenderDetail()
                End With
            Next
            'For Vertical Integration
            Dim xx As Integer
            'For xx = 0 To cmbVerticalIntegration.CheckedItems.Count - 1
            '    With objVenderDetail
            '        .VenderDetailID = 0
            '        .ID = cmbVerticalIntegration.CheckedItems(xx).Value
            '        .Type = "Vertical Integration"
            '        .Venderid = VenderID
            '        .SaveVenderDetail()
            '    End With
            'Next
            For xx = 0 To dgVerticalIntegration.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgVerticalIntegration.MasterTableView.Items(xx), GridDataItem)
                With objVenderDetail
                    .VenderDetailID = 0 'item("VenderDetailID").Text
                    .ID = item("ID").Text
                    .Type = "Vertical Integration"
                    .Venderid = VenderID
                    .InhouseOutSource = item("InhouseOutSource").Text
                    .SaveVenderDetail()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveVenderGradingScale()
        Try
            Dim VenderID As Long
            If lVenderId > 0 Then
                VenderID = lVenderId
                ObjVenderGradingScale.RemoveBeforeEdit(lVenderId)
            Else
                VenderID = objVender.GetCurrentId
            End If
            With ObjVenderGradingScale
                .SupplierGradingScaleID = 0
                .VenderID = VenderID
                .SocialCompliance = 1
                .SupplyChain = 1
                .BusinessDevelopment = 1
                .Merchant = 1
                .QAGroup = 1

                .ManagementApproval = True

                .AboutSupplier = txtAboutSupplier.Text
                .Annualturnover = txtTurnOver.Text
                .AmtSign = cmdTurnOverUnit.SelectedItem.Text
                .Capacity = txtCapacity.Text
                .CapacityUnit = cmbCapacityUnit.SelectedItem.Text
                .IsActive = True
                .SaveVenderGradingScale()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveVenderPersonel()
        Try
            Dim VenderID As Long
            If lVenderId > 0 Then
                VenderID = lVenderId
            Else
                VenderID = objVender.GetCurrentId
            End If
            For x = 0 To dgVenderPersonnel.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgVenderPersonnel.MasterTableView.Items(x), GridDataItem)
                With ObjVenderPersonnel
                    .VenderPersonnelID = item("VenderPersonnelID").Text
                    .VenderLibraryID = VenderID
                    .ContactType = item("ContactType").Text
                    .PersonName = item("PersonName").Text
                    .Designation = item("Designation").Text
                    .CellNo = item("CellNo").Text
                    .EmailAddress = item("EmailAddress").Text
                    .SaveVenderPersonnel()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveVenderDemographics()
        Try

            For x = 0 To dgDemographics.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgDemographics.MasterTableView.Items(x), GridDataItem)
                With ObjVenderDemographics
                    .VDID = item("VDID").Text
                    If lVenderId > 0 Then
                        .VenderLibraryID = lVenderId
                    Else
                        .VenderLibraryID = objVender.GetCurrentId
                    End If
                    .Factory = item("Factory").Text
                    .CoveredArea = item("CoveredArea").Text
                    .TownID = item("TownID").Text
                    .SaveVenderDemographics()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub lnkCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkCertificate.Click
        ScriptManager.RegisterClientScriptBlock(Me.upCertificate, Me.upCertificate.GetType(), "New ClientScript", "window.open('VenderCertificates.aspx?', 'newwindow', 'left=50, top=30, height=520, width=600, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
    End Sub
    Protected Sub dgVenderPersonnel_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgVenderPersonnel.DeleteCommand
        DtVenderPerson = CType(Session("DtVenderPerson"), DataTable)
        If (Not DtVenderPerson Is Nothing) Then
            If (DtVenderPerson.Rows.Count > 0) Then
                Dim VenderPersonnelID As Integer = DtVenderPerson.Rows(e.Item.ItemIndex)("VenderPersonnelID")
                DtVenderPerson.Rows.RemoveAt(e.Item.ItemIndex)
                ObjVenderPersonnel.DeleteVenderPersonalDetail(VenderPersonnelID)
                BindVenderGrid()
            Else
            End If
        End If
    End Sub
    Protected Sub dgDemographics_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgDemographics.DeleteCommand
        DtVenderDemographics = CType(Session("DtVenderDemographics"), DataTable)
        If (Not DtVenderDemographics Is Nothing) Then
            If (DtVenderDemographics.Rows.Count > 0) Then
                Dim VDID As Integer = DtVenderDemographics.Rows(e.Item.ItemIndex)("VDID")
                DtVenderDemographics.Rows.RemoveAt(e.Item.ItemIndex)
                ObjVenderPersonnel.DeleteVendergraphicsDetail(VDID)
                BindVenderGridG()
            Else
            End If
        End If
    End Sub
    Protected Sub dgVerticalIntegration_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgVerticalIntegration.DeleteCommand
        DtVerticalIntegration = CType(Session("DtVerticalIntegration"), DataTable)
        If (Not DtVerticalIntegration Is Nothing) Then
            If (DtVerticalIntegration.Rows.Count > 0) Then
                Dim ID As Integer = DtVerticalIntegration.Rows(e.Item.ItemIndex)("ID")
                DtVerticalIntegration.Rows.RemoveAt(e.Item.ItemIndex)
                objVenderDetail.DeleteVerticleIntegrationDetail(ID)
                BindVenderGridVerticalIntegration()
            Else
            End If
        End If
    End Sub
    Protected Sub dgProductPortFolio_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgProductPortFolio.DeleteCommand
        DtProductPortFolio = CType(Session("DtProductPortFolio"), DataTable)
        If (Not DtProductPortFolio Is Nothing) Then
            If (DtProductPortFolio.Rows.Count > 0) Then
                Dim ID As Integer = DtProductPortFolio.Rows(e.Item.ItemIndex)("ID")
                DtProductPortFolio.Rows.RemoveAt(e.Item.ItemIndex)
                objVenderDetail.DeleteVerticleIntegrationDetail(ID)
                BindProductPortFolio()
            Else
            End If
        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("SupplierProfileView.aspx")
        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnAddDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDetail.Click
        Try
            If txtFactory.Text <> "" And txtCoveredArea.Text <> "" Then
                SaveSessionG()
                BindVenderGridG()
                ClearControlsG()

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill All Boxes In Demographics")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionG()
        If (Not CType(Session("DtVenderDemographics"), DataTable) Is Nothing) Then
            DtVenderDemographics = Session("DtVenderDemographics")
        Else
            DtVenderDemographics = New DataTable
            With DtVenderDemographics
                .Columns.Add("VDID", GetType(Long))
                .Columns.Add("Factory", GetType(String))
                .Columns.Add("CoveredArea", GetType(Decimal))
                .Columns.Add("TownID", GetType(Long))
                .Columns.Add("Town", GetType(String))
            End With
        End If
        dr = DtVenderDemographics.NewRow()
        dr("VDID") = 0
        dr("Factory") = txtFactory.Text
        dr("CoveredArea") = Val(txtCoveredArea.Text)
        dr("TownID") = cmbTown.SelectedValue
        dr("Town") = cmbTown.SelectedItem.Text
        DtVenderDemographics.Rows.Add(dr)
        Session("DtVenderDemographics") = DtVenderDemographics
    End Sub
    Private Sub BindVenderGridG()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtVenderDemographics")
            If objDatatble.Rows.Count > 0 Then
                dgDemographics.Visible = True
                dgDemographics.VirtualItemCount = objDatatble.Rows.Count
                dgDemographics.DataSource = objDatatble
                dgDemographics.DataBind()
            Else
                dgDemographics.Visible = False
            End If
            '  Session.Remove("DtBuyerDetail")
            TryCast(dgDemographics.MasterTableView.GetColumn("VDID"), GridBoundColumn).Display = False
            TryCast(dgDemographics.MasterTableView.GetColumn("TownID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControlsG()

        txtFactory.Text = ""
        txtCoveredArea.Text = ""

    End Sub
    Protected Sub btnAddVerticalIntegration_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddVerticalIntegration.Click
        Try
            cmbVerticalIntegration.Visible = False
            txtVerticalIntegration.Visible = True
            btnAddVerticalIntegration.Visible = False
            btnSaveVerticalIntegration.Visible = True

            UpcmbVerticalIntegration.Update()
            UptxtVerticalIntegration.Update()
            UpbtnAddVerticalIntegration.Update()
            UpbtnSaveVerticalIntegration.Update()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSaveVerticalIntegration_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveVerticalIntegration.Click
        Try
            If txtVerticalIntegration.Text = "" Then
                BindVerticalIntegration()

                cmbVerticalIntegration.Visible = True
                txtVerticalIntegration.Visible = False
                btnaddverticalintegration.Visible = False
                btnSaveVerticalIntegration.Visible = False

                UpcmbVerticalIntegration.Update()
                UptxtVerticalIntegration.Update()
                UpbtnAddVerticalIntegration.Update()
                UpbtnSaveVerticalIntegration.Update()
            Else
                With objVerticalIntegration
                    .VVIID = 0
                    .Name = txtVerticalIntegration.Text
                    .CreationDate = Date.Now()
                    .Type = "Vertical Integration"
                    .IsActive = True
                    .SaveVenderVerticalIntegration()
                End With

                txtVerticalIntegration.Text = ""
                BindVerticalIntegration()

                cmbVerticalIntegration.Visible = True
                txtVerticalIntegration.Visible = False
                btnaddverticalintegration.Visible = False
                btnSaveVerticalIntegration.Visible = False

                UpcmbVerticalIntegration.Update()
                UptxtVerticalIntegration.Update()
                UpbtnAddVerticalIntegration.Update()
                UpbtnSaveVerticalIntegration.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddProductPortfolio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddProductPortfolio.Click
        Try
            cmbProductGroup.Visible = False
            txtProductPortfolio.Visible = True
            btnAddProductPortfolio.Visible = False
            btnSaveProductPortfolio.Visible = True

            UpcmbProductPortfolio.Update()
            UptxtProductPortfolio.Update()
            UpbtnAddProductPortfolio.Update()
            UpbtnSaveProductPortfolio.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSaveProductPortfolio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveProductPortfolio.Click
        Try
            If txtProductPortfolio.Text = "" Then
                BindProductGroup()

                cmbProductGroup.Visible = True
                txtProductPortfolio.Visible = False
                btnAddProductPortfolio.Visible = False
                btnSaveProductPortfolio.Visible = False

                UpcmbProductPortfolio.Update()
                UptxtProductPortfolio.Update()
                UpbtnAddProductPortfolio.Update()
                UpbtnSaveProductPortfolio.Update()
            Else
                With objVerticalIntegration
                    .VVIID = 0
                    .Name = txtProductPortfolio.Text
                    .CreationDate = Date.Now()
                    .Type = "Product Group"
                    .IsActive = True
                    .SaveVenderVerticalIntegration()
                End With

                txtProductPortfolio.Text = ""
                BindProductGroup()

                cmbProductGroup.Visible = True
                txtProductPortfolio.Visible = False
                btnAddProductPortfolio.Visible = False
                btnSaveProductPortfolio.Visible = False

                UpcmbProductPortfolio.Update()
                UptxtProductPortfolio.Update()
                UpbtnAddProductPortfolio.Update()
                UpbtnSaveProductPortfolio.Update()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpload1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload1.Click
        Try
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If FileUpload1.FileName = "" Then
                lblErrorMsg.Text = "No File"
                SCCreationDate.Text = ""
                txtExpiryDate.Text = ""
            ElseIf fileExt = ".jpg" Then
                lblErrorMsg.Text = ""
                SaveUploaddata()
                SCCreationDate.Text = ""
                txtExpiryDate.Text = ""
            ElseIf fileExt = ".pdf" Then
                lblErrorMsg.Text = ""
                SaveUploaddata()
                SCCreationDate.Text = ""
                txtExpiryDate.Text = ""
                '--Noted  if we upload Xl etc then we show excel on upload popup
                '  ElseIf fileExt = ".xls" OrElse fileExt = ".xlsx" Then
                '  SaveUploaddata()
            Else
                lblErrorMsg.Text = "Only jpg or Pdf file allow to upload"
                SCCreationDate.Text = ""
                txtExpiryDate.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveUploaddata()
        Try
            Dim aVenderId As Long = 0
            With objSicialCompliance
                .VenderSocialComplianceID = 0
                .CreationDate = GeneralCode.GetDate(SCCreationDate.Text)
                If lVenderId > 0 Then
                    .Venderid = lVenderId
                    aVenderId = lVenderId
                Else
                    .Venderid = 0 'objStyleMaster.GetID()
                    aVenderId = 0 'objStyleMaster.GetID()
                End If
                .CertificateName = txtSocialComplianceName.Text
                .FileName = FileUpload1.FileName
                .CertificateImage = SaveUploadPicture()
                .ExpiryDate = GeneralCode.GetDate(txtExpiryDate.text)
                .SaveVenderSocialCompliance()
            End With

            'Show in grid
            Dim objDataView1 As DataView
            objDataView1 = LoadData1(aVenderId)
            Session("objDataView1") = objDataView1
            BindGridFileInfoSocialCompliance()

            Dim dtt As DataTable
            dtt = objDataView1.ToTable
            Dim x As Integer = 0
            For x = 0 To dgSocialCompliance.Items.Count - 1
                Dim Image1 As ImageButton = DirectCast(dgSocialCompliance.Items(x).FindControl("Image1"), ImageButton)

                Dim bytes As Byte() = DirectCast(dtt.Rows(x)("CertificateImage"), Byte())
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String

            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGridFileInfoSocialCompliance()
        Dim objDataView As DataView
        Dim strSortExpression As String
        objDataView = Session("objDataView1")
        If objDataView.Count > 0 Then
            strSortExpression = dgSocialCompliance.SortExpression
            If strSortExpression <> "" Then
                objDataView.Sort = strSortExpression
                If Not dgSocialCompliance.IsSortedAscending Then
                    objDataView.Sort += " DESC"
                End If
            End If
            dgSocialCompliance.Visible = True
            dgSocialCompliance.RecordCount = objDataView.Count
            dgSocialCompliance.DataSource = objDataView
            dgSocialCompliance.DataBind()
            btnSave.Enabled = True
        Else
            dgSocialCompliance.Visible = False
        End If
    End Sub
    Function SaveUploadPicture() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If FileUpload1.HasFile AndAlso Not FileUpload1.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = FileUpload1.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Function LoadData1(ByVal VenderID As Long) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objSicialCompliance.GetFileInfoNew(VenderID)
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub dgSocialCompliance_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgSocialCompliance.ItemCommand
        Try
            Select Case e.CommandName
                Case Is = "ShowFileOrImage"
                    Dim VenderSocialComplianceID As Integer = dgSocialCompliance.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim VenderID As Integer = dgSocialCompliance.Items(e.Item.ItemIndex).Cells(1).Text
                    ScriptManager.RegisterClientScriptBlock(Me.UpdgSocialCompliance, Me.UpdgSocialCompliance.GetType(), "New ClientScript", "window.open('SocialComplianceUploadShow.aspx?VenderSocialComplianceID=" & VenderSocialComplianceID & "&VenderID=" & VenderID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                Case Is = "DownloadFile"
                    Dim VenderSocialComplianceID As Integer = dgSocialCompliance.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim VenderID As Integer = dgSocialCompliance.Items(e.Item.ItemIndex).Cells(1).Text
                    ScriptManager.RegisterClientScriptBlock(Me.UpdgSocialCompliance, Me.UpdgSocialCompliance.GetType(), "New ClientScript", "window.open('SocialComplianceUploadShow.aspx?VenderSocialComplianceID=" & VenderSocialComplianceID & "&VenderID=" & VenderID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
                Case Is = "Remove"
                    Dim VenderCertificateID As Integer = dgSocialCompliance.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim VenderID As Integer = dgSocialCompliance.Items(e.Item.ItemIndex).Cells(1).Text

                    objSicialCompliance.DeleteStyleUploadTableonAddPage(VenderCertificateID, VenderID)

                    'Show in grid
                    Dim objDataView1 As DataView
                    objDataView1 = LoadData1(VenderID)
                    Session("objDataView1") = objDataView1
                    BindGridFileInfoSocialCompliance()

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVAF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVAF.Click
        Try
            If FileUpload2.FileName = "" Then
                'DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Choose Image For Upload.")
                lblvafmsg.Text = "Choose Image For Upload."
            Else
                lblvafmsg.Text = ""
                Dim VAFName As String = ""
                Dim fs As System.IO.Stream = FileUpload2.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                'ImageVAF.ImageUrl = "data:image/png;base64," & base64String
                'ImageVAF.Visible = True
                VAFName = FileUpload2.FileName
                Session("VAFName") = VAFName
                Session("VAFUpload") = bytes
                lnkFIlePicture.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVerticalIntegration_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVerticalIntegration.Click
        Try
            'DtVerticalIntegration = Nothing
            'Session("DtVerticalIntegration") = Nothing
            SaveSessionVerticalIntegration()
            BindVenderGridVerticalIntegration()

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionVerticalIntegration()
        If (Not CType(Session("DtVerticalIntegration"), DataTable) Is Nothing) Then
            DtVerticalIntegration = Session("DtVerticalIntegration")
        Else
            DtVerticalIntegration = New DataTable
            With DtVerticalIntegration
                .Columns.Add("VenderDetailID", GetType(Long))
                .Columns.Add("VenderID", GetType(Long))
                .Columns.Add("ID", GetType(Long))
                .Columns.Add("Type", GetType(String))
                .Columns.Add("VerticalIntegration", GetType(String))
                .Columns.Add("InhouseOutSource", GetType(String))
            End With
        End If
        'For Vertical Integration
        ' Dim xx As Integer
        '  For xx = 0 To cmbVerticalIntegration.CheckedItems.Count - 1
        dr = DtVerticalIntegration.NewRow()
        dr("VenderDetailID") = 0
        dr("VenderID") = 0
        dr("ID") = cmbVerticalIntegration.SelectedValue
        dr("Type") = "Vertical Integration"
        dr("VerticalIntegration") = cmbVerticalIntegration.SelectedItem.Text
        dr("InhouseOutSource") = cmbInHOutS.SelectedItem.Text
        DtVerticalIntegration.Rows.Add(dr)
        Session("DtVerticalIntegration") = DtVerticalIntegration
        '  Next



    End Sub
    Private Sub BindVenderGridVerticalIntegration()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtVerticalIntegration")
            If objDatatble.Rows.Count > 0 Then
                dgVerticalIntegration.Visible = True
                dgVerticalIntegration.VirtualItemCount = objDatatble.Rows.Count
                dgVerticalIntegration.DataSource = objDatatble
                dgVerticalIntegration.DataBind()
            Else
                dgVerticalIntegration.Visible = False
            End If
            '  Session.Remove("DtBuyerDetail")
            TryCast(dgVerticalIntegration.MasterTableView.GetColumn("VenderDetailID"), GridBoundColumn).Display = False
            TryCast(dgVerticalIntegration.MasterTableView.GetColumn("VenderID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnProductPortFolio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProductPortFolio.Click
        Try
            DtProductPortFolio = Nothing
            Session("DtProductPortFolio") = Nothing
            SaveSessionProductPortFolio()
            BindProductPortFolio()

        Catch ex As Exception

        End Try
    End Sub
    Sub SaveSessionProductPortFolio()
        If (Not CType(Session("DtProductPortFolio"), DataTable) Is Nothing) Then
            DtProductPortFolio = Session("DtProductPortFolio")
        Else
            DtProductPortFolio = New DataTable
            With DtProductPortFolio
                .Columns.Add("VenderDetailID", GetType(Long))
                .Columns.Add("VenderID", GetType(Long))
                .Columns.Add("ID", GetType(Long))
                .Columns.Add("Type", GetType(String))
                .Columns.Add("ProductPortfolio", GetType(String))
            End With
        End If
        'For Vertical Integration
        Dim xx As Integer
        For xx = 0 To cmbProductGroup.CheckedItems.Count - 1
            dr = DtProductPortFolio.NewRow()
            dr("VenderDetailID") = 0
            dr("VenderID") = 0
            dr("ID") = cmbProductGroup.CheckedItems(xx).Value
            dr("Type") = "Product Group"
            dr("ProductPortfolio") = cmbProductGroup.CheckedItems(xx).Text
            DtProductPortFolio.Rows.Add(dr)
            Session("DtProductPortFolio") = DtProductPortFolio
        Next

    End Sub
    Private Sub BindProductPortFolio()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("DtProductPortFolio")
            If objDatatble.Rows.Count > 0 Then
                dgProductPortFolio.Visible = True
                dgProductPortFolio.VirtualItemCount = objDatatble.Rows.Count
                dgProductPortFolio.DataSource = objDatatble
                dgProductPortFolio.DataBind()
            Else
                dgProductPortFolio.Visible = False
            End If
            '  Session.Remove("DtBuyerDetail")
            TryCast(dgProductPortFolio.MasterTableView.GetColumn("VenderDetailID"), GridBoundColumn).Display = False
            TryCast(dgProductPortFolio.MasterTableView.GetColumn("VenderID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lnkFIlePicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFIlePicture.Click
        Try
            '  ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel11, Me.UpdatePanel11.GetType(), "New ClientScript", "window.open('SRQTechPackUploadShow.aspx?FileName=" & Session("FileNameTP") & "&Byte=" & Session("ImageByteTP") & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
            'Response.Write("<script> window.open('SRQTechPackUploadShow.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

            ScriptManager.RegisterClientScriptBlock(Me.UpPic, Me.UpPic.GetType(), "New ClientScript", "window.open('VAFPicturePopUp.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
End Class