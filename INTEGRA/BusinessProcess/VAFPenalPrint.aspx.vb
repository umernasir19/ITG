Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Public Class VAFPenalPrint
    Inherits System.Web.UI.Page
    Dim objVender As New Vender
    Dim objPurchaseOrder As New PurchaseOrder
    Dim dtPrimaryContact As DataTable
    Dim Dr As DataRow
    Dim dtHRBreakdown, dtTopCustomer, dtMachineTechnical, dtEmbellishmentSpecialities, dtStitchingLineMachine As DataTable
    Dim objVAF_BasicInformation As New VAF_BasicInformation
    Dim objVAF_Business As New VAF_Business
    Dim objVAF_Capacities As New VAF_Capacities
    Dim objVAF_DyeingSpeciality As New VAF_DyeingSpeciality
    Dim objVAF_EmbellishmentSpecialities As New VAF_EmbellishmentSpecialities
    Dim objVAF_GeneralInformation As New VAF_GeneralInformation
    Dim objVAF_HRBreakdown As New VAF_HRBreakdown
    Dim objVAF_HRDetail As New VAF_HRDetail
    Dim objVAF_MachineTechnical As New VAF_MachineTechnical
    Dim objVAF_PDInfo As New VAF_PDInfo
    Dim objVAF_PreTreatment As New VAF_PreTreatment
    Dim objVAF_PrimaryContact As New VAF_PrimaryContact
    Dim objVAF_Product As New VAF_Product
    Dim objVAF_StitchingLineMachine As New VAF_StitchingLineMachine
    Dim objVAF_StitchingSpecialities As New VAF_StitchingSpecialities
    Dim objVAF_TopCustomer As New VAF_TopCustomer
    Dim objVAF_ConceptualDesign As New VAF_ConceptualDesign
    Dim objVAF_Sampling As New VAF_Sampling
    Dim VAFID As Long
    Dim SupplierID As Long
    Dim bit As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VAFID = Vender.DecryptString(Request.QueryString("VAFID"))
        SupplierID = Vender.DecryptString(Request.QueryString("SupplierID"))
        bit = Request.QueryString("bit")
        If Not Page.IsPostBack Then
            Session("dtPrimaryContact") = Nothing
            Session("dtHRBreakdown") = Nothing
            Session("dtTopCustomer") = Nothing
            Session("dtMachineTechnical") = Nothing
            Session("dtEmbellishmentSpecialities") = Nothing
            Session("dtStitchingLineMachine") = Nothing

            cmbSupplier.Enabled = False
            cmbYearEstablished.Enabled = False
            cmbCompany.Enabled = False
            cmbBusiness.Enabled = False
            cmbProduct.Enabled = False
            cmbFabricStockUnit.Enabled = False
            cmbProdcapacitymonthUnit.Enabled = False
            cmbConceptualDesign.Enabled = False
            chkInHouse.Enabled = False
            chkNumberOfInHouseDesigners.Enabled = False
            chkContracted.Enabled = False

            chkNumberOfOutsideDesigners.Enabled = False
            cmbSampling.Enabled = False
            cmbPD.Enabled = False
            cmbPreTreatmentSpeciality.Enabled = False

            cmbDyeingSpeciality.Enabled = False


            BindSupplier()
            BindYears()
            BindCountries()
            BindcmbBusiness()
            BindcmbProduct()
            BindcmbPD()
            BindcmbPreTreatmentSpeciality()
            BindcmbDyeingSpeciality()
            'BindcmbDept()
            BindcmbCapabilities()
            BindcmbMachine()

            lblYear1.Text = Date.Now.Year() - 1
            lblYear2.Text = Date.Now.Year() - 2
            lblYear3.Text = Date.Now.Year() - 3

            ' txtDeptMore.Visible = False
            '  btnAddDept.Visible = False
            ' txtCapabilities.Visible = False
            '  btnSaveCapabilities.Visible = False
            ' txtMachineName.Visible = False
            ' btnSaveMachine.Visible = False
            '  txtBusiness.Visible = False
            '  btnAddBusinessA.Visible = True
            '  btnSaveBusiness.Visible = False
            'txtProduct.Visible = False
            ' btnAddProductA.Visible = True
            '  btnSaveProduct.Visible = False
            '  txtPDinfo.Visible = False
            ' btnAddPDA.Visible = True
            ' btnSavePD.Visible = False
            ' txtPreTreatmentSpeciality.Visible = False
            ' btnAddPreTreatmentSpecialityA.Visible = True
            '  btnSavePreTreatmentSpeciality.Visible = False
            'txtDyeingSpecialit.Visible = False
            ' btnAddDyeingSpecialitA.Visible = True
            '  btnSaveDyeingSpecialit.Visible = False
            'Selected Pakistan
            ' cmbCustomerCountry.SelectedValue = 171


            If VAFID > 0 Then
                EditMode()
                'lnkSocialCompliances.Visible = True

            Else
                'lnkSocialCompliances.Visible = True
                cmbSupplier.Enabled = False
                cmbSupplier.SelectedValue = SupplierID
            End If

            If bit = 0 Then
                ' btnSave.Visible = False
                ' btnCancel.Visible = False
            Else
                ' btnSave.Visible = True
                ' btnCancel.Visible = True
            End If
        End If
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable
            If VAFID > 0 Then
                dtSupplier = objVender.getDataforBindCombo11
            Else
                dtSupplier = objVender.getDataforBindCombo1
            End If
            With cmbSupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindYears()
        Try
            Dim dt As DataTable = objPurchaseOrder.GetYears
            cmbYearEstablished.DataSource = dt
            cmbYearEstablished.DataTextField = "YearNo"
            cmbYearEstablished.DataValueField = "YearID"
            cmbYearEstablished.DataBind()

        Catch ex As Exception

        End Try

    End Sub
    Sub BindCountries()
        Try
            Dim dt As DataTable = objPurchaseOrder.GetCountries
            'cmbCustomerCountry.DataSource = dt
            'cmbCustomerCountry.DataTextField = "CountryName"
            'cmbCustomerCountry.DataValueField = "Country_id"
            'cmbCustomerCountry.DataBind()

        Catch ex As Exception

        End Try

    End Sub
    Sub BindcmbBusiness()
        Try
            Dim dt As DataTable = objVender.getcmbBusiness
            With cmbBusiness
                .DataSource = dt
                .DataTextField = "Business"
                .DataValueField = "BusinessID"
                .DataBind()
                ''.Items.Insert((dt.Rows.Count), New RadComboBoxItem("Others", String.Empty))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindcmbProduct()
        Try
            Dim dt As DataTable = objVender.getV_Product
            With cmbProduct
                .DataSource = dt
                .DataTextField = "Product"
                .DataValueField = "ProductID"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindcmbPD()
        Try
            Dim dt As DataTable = objVender.getV_PD
            With cmbPD
                .DataSource = dt
                .DataTextField = "PDinfo"
                .DataValueField = "PDid"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindcmbPreTreatmentSpeciality()
        Try
            Dim dt As DataTable = objVender.getV_PreTreatment
            With cmbPreTreatmentSpeciality
                .DataSource = dt
                .DataTextField = "PreTreatment"
                .DataValueField = "PreTreatmentID"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindcmbDyeingSpeciality()
        Try
            Dim dt As DataTable = objVender.getV_Dyeing
            With cmbDyeingSpeciality
                .DataSource = dt
                .DataTextField = "Dyeing"
                .DataValueField = "DyeingID"
                .DataBind()

            End With
        Catch ex As Exception
        End Try
    End Sub
    'Sub BindcmbDept()
    '    Try
    '        Dim dt As DataTable = objVender.getV_Department
    '        With cmbDept
    '            .DataSource = dt
    '            .DataTextField = "Department"
    '            .DataValueField = "DeptID"
    '            .DataBind()
    '            .Items.Insert((dt.Rows.Count), "Others")
    '        End With
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Sub BindcmbCapabilities()
        Try
            Dim dt As DataTable = objVender.getV_Capabilities
            'With cmbCapabilities
            '    .DataSource = dt
            '    .DataTextField = "Capabilities"
            '    .DataValueField = "V_CapabilitiesID"
            '    .DataBind()
            '    .Items.Insert((dt.Rows.Count), "Others")
            'End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindcmbMachine()
        Try
            Dim dt As DataTable = objVender.getV_Machine
            'With cmbMachine
            '    .DataSource = dt
            '    .DataTextField = "MachineName"
            '    .DataValueField = "V_MachineID"
            '    .DataBind()
            '    .Items.Insert((dt.Rows.Count), "Others")
            'End With
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDetail.Click
    '    Try
    '        SaveSession()
    '        BindGridPrimaryContact()
    '        UpdgPrimaryContact.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub SaveSession()
    '    If (Not CType(Session("dtPrimaryContact"), DataTable) Is Nothing) Then
    '        dtPrimaryContact = Session("dtPrimaryContact")
    '    Else
    '        dtPrimaryContact = New DataTable
    '        With dtPrimaryContact
    '            .Columns.Add("VAF_PrimaryContactID", GetType(Long))
    '            .Columns.Add("Designation", GetType(String))
    '            .Columns.Add("Name", GetType(String))
    '            .Columns.Add("Phone", GetType(String))
    '            .Columns.Add("Cell", GetType(String))
    '            .Columns.Add("Email", GetType(String))
    '        End With
    '    End If
    '    Dr = dtPrimaryContact.NewRow()
    '    Dr("VAF_PrimaryContactID") = 0
    '    Dr("Designation") = cmbDesignation.SelectedItem.Text
    '    Dr("Name") = txtName.Text
    '    Dr("Phone") = txtPhone.Text
    '    Dr("Cell") = txtEmail.Text
    '    Dr("Email") = txtCell.Text
    '    dtPrimaryContact.Rows.Add(Dr)
    '    Session("dtPrimaryContact") = dtPrimaryContact
    'End Sub
    Private Sub BindGridPrimaryContact()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtPrimaryContact")
            If objDatatble.Rows.Count > 0 Then
                dgPrimaryContact.Visible = True
                dgPrimaryContact.DataSource = objDatatble
                dgPrimaryContact.DataBind()
            Else
                dgPrimaryContact.Visible = False
            End If
            TryCast(dgPrimaryContact.MasterTableView.GetColumn("VAF_PrimaryContactID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnAddList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddList.Click
    '    Try
    '        SaveSessionHRBreakdown()
    '        BindHRBreakdown()
    '        UpdgHRBreakdown.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub SaveSessionHRBreakdown()
    '    If (Not CType(Session("dtHRBreakdown"), DataTable) Is Nothing) Then
    '        dtHRBreakdown = Session("dtHRBreakdown")
    '    Else
    '        dtHRBreakdown = New DataTable
    '        With dtHRBreakdown
    '            .Columns.Add("VAF_HRBreakdownID", GetType(Long))
    '            .Columns.Add("DeptID", GetType(Long))
    '            .Columns.Add("Department", GetType(String))
    '            .Columns.Add("No", GetType(Decimal))
    '        End With
    '    End If
    '    Dr = dtHRBreakdown.NewRow()
    '    Dr("VAF_HRBreakdownID") = 0
    '    Dr("DeptID") = cmbDept.SelectedValue
    '    Dr("Department") = cmbDept.SelectedItem.Text
    '    Dr("No") = Val(txtNo.Text)
    '    dtHRBreakdown.Rows.Add(Dr)
    '    Session("dtHRBreakdown") = dtHRBreakdown
    'End Sub
    Private Sub BindHRBreakdown()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtHRBreakdown")
            If objDatatble.Rows.Count > 0 Then
                dgHRBreakdown.Visible = True
                dgHRBreakdown.DataSource = objDatatble
                dgHRBreakdown.DataBind()
            Else
                dgHRBreakdown.Visible = False
            End If
            TryCast(dgHRBreakdown.MasterTableView.GetColumn("VAF_HRBreakdownID"), GridBoundColumn).Display = False
            TryCast(dgHRBreakdown.MasterTableView.GetColumn("DeptID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnAddGrid_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddGrid.Click
    '    Try
    '        SaveSessionTopCustomer()
    '        BindTopCustomer()
    '        UpdgTopCustomer.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub SaveSessionTopCustomer()
    '    If (Not CType(Session("dtTopCustomer"), DataTable) Is Nothing) Then
    '        dtTopCustomer = Session("dtTopCustomer")
    '    Else
    '        dtTopCustomer = New DataTable
    '        With dtTopCustomer
    '            .Columns.Add("VAF_TopCustomerID", GetType(Long))
    '            .Columns.Add("CustomerName", GetType(String))
    '            .Columns.Add("Country_id", GetType(Long))
    '            .Columns.Add("CustomerCountry", GetType(String))
    '            .Columns.Add("CustomerPercentOfBuss", GetType(String))
    '            .Columns.Add("CustomerProduct", GetType(String))
    '        End With
    '    End If
    '    Dr = dtTopCustomer.NewRow()
    '    Dr("VAF_TopCustomerID") = 0
    '    Dr("CustomerName") = txtCustomerName.Text
    '    Dr("Country_id") = cmbCustomerCountry.SelectedValue
    '    Dr("CustomerCountry") = cmbCustomerCountry.SelectedItem.Text
    '    Dr("CustomerPercentOfBuss") = txtCustomerPercentOfBuss.Text
    '    Dr("CustomerProduct") = txtCustomerProduct.Text
    '    dtTopCustomer.Rows.Add(Dr)
    '    Session("dtTopCustomer") = dtTopCustomer
    'End Sub
    Private Sub BindTopCustomer()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtTopCustomer")
            If objDatatble.Rows.Count > 0 Then
                dgTopCustomer.Visible = True
                dgTopCustomer.DataSource = objDatatble
                dgTopCustomer.DataBind()
            Else
                dgTopCustomer.Visible = False
            End If
            TryCast(dgTopCustomer.MasterTableView.GetColumn("VAF_TopCustomerID"), GridBoundColumn).Display = False
            TryCast(dgTopCustomer.MasterTableView.GetColumn("Country_id"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnAddMachineTechnical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMachineTechnical.Click
    '    Try
    '        SaveSessionMachineTechnical()
    '        BindMachineTechnical()
    '        UpdgMachineTechnical.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub SaveSessionMachineTechnical()
    '    If (Not CType(Session("dtMachineTechnical"), DataTable) Is Nothing) Then
    '        dtMachineTechnical = Session("dtMachineTechnical")
    '    Else
    '        dtMachineTechnical = New DataTable
    '        With dtMachineTechnical
    '            .Columns.Add("VAF_MachineTechnicalID", GetType(Long))
    '            .Columns.Add("Machine", GetType(String))
    '            .Columns.Add("WidthinCM", GetType(Decimal))
    '            .Columns.Add("MeterPerday", GetType(Decimal))
    '            .Columns.Add("Model", GetType(String))
    '            .Columns.Add("Year", GetType(Decimal))
    '            .Columns.Add("Type", GetType(String))
    '        End With
    '    End If
    '    Dr = dtMachineTechnical.NewRow()
    '    Dr("VAF_MachineTechnicalID") = 0
    '    Dr("Machine") = txtMachine.Text
    '    Dr("WidthinCM") = Val(txtWidth.Text)
    '    Dr("MeterPerday") = Val(txtMeter.Text)
    '    Dr("Model") = txtModel.Text
    '    Dr("Year") = Val(txtYear.Text)
    '    Dr("Type") = cmbType.SelectedItem.Text
    '    dtMachineTechnical.Rows.Add(Dr)
    '    Session("dtMachineTechnical") = dtMachineTechnical
    'End Sub
    Private Sub BindMachineTechnical()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtMachineTechnical")
            If objDatatble.Rows.Count > 0 Then
                dgMachineTechnical.Visible = True
                dgMachineTechnical.DataSource = objDatatble
                dgMachineTechnical.DataBind()
            Else
                dgMachineTechnical.Visible = False
            End If
            TryCast(dgMachineTechnical.MasterTableView.GetColumn("VAF_MachineTechnicalID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnAddEmbellishmentSpecialities_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddEmbellishmentSpecialities.Click
    '    Try
    '        SaveSessionEmbellishmentSpecialities()
    '        BindEmbellishmentSpecialities()
    '        UpdgEmbellishmentSpecialities.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub SaveSessionEmbellishmentSpecialities()
    '    If (Not CType(Session("dtEmbellishmentSpecialities"), DataTable) Is Nothing) Then
    '        dtEmbellishmentSpecialities = Session("dtEmbellishmentSpecialities")
    '    Else
    '        dtEmbellishmentSpecialities = New DataTable
    '        With dtEmbellishmentSpecialities
    '            .Columns.Add("VAF_EmbellishmentSpecialitiesID", GetType(Long))
    '            .Columns.Add("Capabilities", GetType(String))
    '            .Columns.Add("Volume", GetType(Decimal))
    '            .Columns.Add("Unit", GetType(String))
    '            .Columns.Add("NoofMac", GetType(Decimal))
    '        End With
    '    End If
    '    Dr = dtEmbellishmentSpecialities.NewRow()
    '    Dr("VAF_EmbellishmentSpecialitiesID") = 0
    '    Dr("Capabilities") = cmbCapabilities.SelectedItem.Text
    '    Dr("Volume") = Val(txtVolume.Text)
    '    Dr("Unit") = cmbVolumeUnit.SelectedItem.Text
    '    Dr("NoofMac") = Val(txtNoofMac.Text)
    '    dtEmbellishmentSpecialities.Rows.Add(Dr)
    '    Session("dtEmbellishmentSpecialities") = dtEmbellishmentSpecialities
    'End Sub
    Private Sub BindEmbellishmentSpecialities()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtEmbellishmentSpecialities")
            If objDatatble.Rows.Count > 0 Then
                dgEmbellishmentSpecialities.Visible = True
                dgEmbellishmentSpecialities.DataSource = objDatatble
                dgEmbellishmentSpecialities.DataBind()
            Else
                dgEmbellishmentSpecialities.Visible = False
            End If
            TryCast(dgEmbellishmentSpecialities.MasterTableView.GetColumn("VAF_EmbellishmentSpecialitiesID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnAddStitchingLineMachine_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddStitchingLineMachine.Click
    '    Try
    '        SaveSessionStitchingLineMachine()
    '        BindStitchingLineMachine()
    '        UpdgStitchingLineMachine.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Sub SaveSessionStitchingLineMachine()
    '    If (Not CType(Session("dtStitchingLineMachine"), DataTable) Is Nothing) Then
    '        dtStitchingLineMachine = Session("dtStitchingLineMachine")
    '    Else
    '        dtStitchingLineMachine = New DataTable
    '        With dtStitchingLineMachine
    '            .Columns.Add("VAF_StitchingLineMachineID", GetType(Long))
    '            .Columns.Add("Machine", GetType(String))
    '            .Columns.Add("MachineTotal", GetType(Decimal))
    '        End With
    '    End If
    '    Dr = dtStitchingLineMachine.NewRow()
    '    Dr("VAF_StitchingLineMachineID") = 0
    '    Dr("Machine") = cmbMachine.SelectedItem.Text
    '    Dr("MachineTotal") = Val(txtMachineTotal.Text)
    '    dtStitchingLineMachine.Rows.Add(Dr)
    '    Session("dtStitchingLineMachine") = dtStitchingLineMachine
    'End Sub
    Private Sub BindStitchingLineMachine()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtStitchingLineMachine")
            If objDatatble.Rows.Count > 0 Then
                dgStitchingLineMachine.Visible = True
                dgStitchingLineMachine.DataSource = objDatatble
                dgStitchingLineMachine.DataBind()
            Else
                dgStitchingLineMachine.Visible = False
            End If
            TryCast(dgStitchingLineMachine.MasterTableView.GetColumn("VAF_StitchingLineMachineID"), GridBoundColumn).Display = False
        Catch ex As Exception
        End Try
    End Sub
    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
    '    Try


    '        With objVAF_BasicInformation
    '            If VAFID > 0 Then
    '                .VAFID = VAFID
    '                Dim dt As DataTable
    '                dt = objVAF_BasicInformation.EditVAF_BasicInformation(VAFID)
    '                .SupplierStatus = dt.Rows(0)("SupplierStatus")
    '                .Remarks = dt.Rows(0)("Remarks")
    '            Else
    '                .VAFID = 0
    '                .SupplierStatus = "No Decision"
    '                .Remarks = ""
    '            End If
    '            .CreationDate = Date.Now()
    '            .SupplierID = cmbSupplier.SelectedValue
    '            .YearID = cmbYearEstablished.SelectedValue
    '            .Code = txtCode.Text
    '            .CorporateAddress = txtCorporateAddress.Text
    '            .Company = cmbCompany.SelectedItem.Text
    '            .SaveVAF()
    '        End With

    '        'Business
    '        objVAF_Business.Delete(VAFID)
    '        Dim x As Integer
    '        For x = 0 To cmbBusiness.CheckedItems.Count - 1
    '            With objVAF_Business
    '                .VAF_BusinessID = 0
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .BusinessID = cmbBusiness.CheckedItems(x).Value
    '                .SaveVAF_Business()
    '            End With
    '        Next

    '        'Product
    '        objVAF_Product.Delete(VAFID)
    '        Dim xx As Integer
    '        For xx = 0 To cmbProduct.CheckedItems.Count - 1
    '            With objVAF_Product
    '                .VAF_ProductID = 0
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .ProductID = cmbProduct.CheckedItems(xx).Value
    '                .SaveVAF_Product()
    '            End With
    '        Next

    '        'VAF_PrimaryContact
    '        Dim x1 As Integer
    '        For x1 = 0 To dgPrimaryContact.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(dgPrimaryContact.MasterTableView.Items(x1), GridDataItem)
    '            With objVAF_PrimaryContact
    '                .VAF_PrimaryContactID = item("VAF_PrimaryContactID").Text
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .Designation = item("Designation").Text
    '                .Name = item("Name").Text
    '                .Phone = item("Phone").Text
    '                .Cell = item("Cell").Text
    '                .Email = item("Email").Text
    '                .SaveVAF_PrimaryContact()
    '            End With
    '        Next

    '        'VAF_HRDetail
    '        objVAF_HRDetail.Delete(VAFID)
    '        With objVAF_HRDetail
    '            .VAF_HRDetailID = 0
    '            If VAFID > 0 Then
    '                .VAFID = VAFID
    '            Else
    '                .VAFID = objVAF_BasicInformation.GetId()
    '            End If
    '            .TotalWorker = Val(txtTotalWorker.Text)
    '            .Male = Val(txtMale.Text)
    '            .Female = Val(txtFemale.Text)
    '            .PermanentStaff = Val(txtPermanent.Text)
    '            .NoofShift = Val(txtNoofShifts.Text)
    '            .Timing = txtTiming.Text
    '            .SaveVAF_HRDetail()
    '        End With

    '        'VAF_HRBreakdown
    '        Dim x2 As Integer
    '        For x2 = 0 To dgHRBreakdown.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(dgHRBreakdown.MasterTableView.Items(x2), GridDataItem)
    '            With objVAF_HRBreakdown
    '                .VAF_HRBreakdownID = item("VAF_HRBreakdownID").Text
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .DeptID = item("DeptID").Text
    '                .No = item("No").Text
    '                .SaveVAF_HRBreakdown()
    '            End With
    '        Next

    '        'VAF_Capacities
    '        objVAF_Capacities.Delete(VAFID)
    '        With objVAF_Capacities
    '            .VAF_CapacitiesID = 0
    '            If VAFID > 0 Then
    '                .VAFID = VAFID
    '            Else
    '                .VAFID = objVAF_BasicInformation.GetId()
    '            End If
    '            .FabricStock = Val(txtFabricStock.Text)
    '            .FabricStockUnit = cmbFabricStockUnit.SelectedItem.Text
    '            .ProdCapacitymonth = Val(txtProdcapacitymonth.Text)
    '            .ProdCapacitymonthUnit = cmbProdcapacitymonthUnit.SelectedItem.Text
    '            .CuttingCapacitymonth = Val(txtCuttingcapacitymonth.Text)
    '            .washingCapacity = Val(txtwashingcapacity.Text)
    '            .NoOfLines = Val(txtNooflines.Text)
    '            .NoOfMachineline = Val(txtNoofmachineline.Text)
    '            .SAMorSMV = Val(txtSAMSMV.Text)
    '            .SaveVAF_Capacities()
    '        End With

    '        'VAF_GeneralInformation
    '        objVAF_GeneralInformation.Delete(VAFID)
    '        With objVAF_GeneralInformation
    '            .VAF_GeneralInformationID = 0
    '            If VAFID > 0 Then
    '                .VAFID = VAFID
    '            Else
    '                .VAFID = objVAF_BasicInformation.GetId()
    '            End If
    '            .CompanyCoverdAreasqm = Val(txtCompanycoverdArea.Text)
    '            .FactoryAreasqm = Val(txtFactoryArea.Text)
    '            .Year1 = lblYear1.Text
    '            .AnnualTurnover1 = Val(txtAnnualturnover1.Text)
    '            .Year2 = lblYear2.Text
    '            .AnnualTurnover2 = Val(txtAnnualturnover2.Text)
    '            .Year3 = lblYear3.Text
    '            .AnnualTurnover3 = Val(txtAnnualturnover3.Text)
    '            .TotalAnnualShipmentsVolumeGlobally = Val(txtTotalAnnualShipmentsvolumeglobally.Text)
    '            .TotalAnnualShipmentsEurope = Val(txtTotalAnnualShipmentstothevolumeEurope.Text)
    '            .SaveVAF_GeneralInformation()
    '        End With

    '        'VAF_TopCustomer
    '        Dim x3 As Integer
    '        For x3 = 0 To dgTopCustomer.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(dgTopCustomer.MasterTableView.Items(x3), GridDataItem)
    '            With objVAF_TopCustomer
    '                .VAF_TopCustomerID = item("VAF_TopCustomerID").Text
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .CustomerName = item("CustomerName").Text
    '                .Country_id = item("Country_id").Text
    '                .CustomerCountry = item("CustomerCountry").Text
    '                .CustomerPercentOfBuss = item("CustomerPercentOfBuss").Text
    '                .CustomerProduct = item("CustomerProduct").Text
    '                .SaveVAF_TopCustomer()
    '            End With
    '        Next

    '        'VAF_ConceptualDesign
    '        objVAF_ConceptualDesign.Delete(VAFID)
    '        With objVAF_ConceptualDesign
    '            .VAF_ConceptualDesignID = 0
    '            If VAFID > 0 Then
    '                .VAFID = VAFID
    '            Else
    '                .VAFID = objVAF_BasicInformation.GetId()
    '            End If
    '            .ConceptualDesignStaff = cmbConceptualDesign.SelectedItem.Text
    '            If chkInHouse.Checked = True Then
    '                .InHouse = 1
    '            Else
    '                .InHouse = 0
    '            End If
    '            If chkNumberOfInHouseDesigners.Checked = True Then
    '                .NumberOfInHouseDesigners = 1
    '            Else
    '                .NumberOfInHouseDesigners = 0
    '            End If
    '            .InHouseLocation = txtInHouseLocation.Text
    '            If chkContracted.Checked = True Then
    '                .Contracted = 1
    '            Else
    '                .Contracted = 0
    '            End If
    '            If chkNumberOfOutsideDesigners.Checked = True Then
    '                .NumberOfOutsideDesigners = 1
    '            Else
    '                .NumberOfOutsideDesigners = 0
    '            End If
    '            .ContractedLocation = txtContractedLocation.Text
    '            .SaveVAF_ConceptualDesign()
    '        End With

    '        'VAF_Sampling
    '        objVAF_Sampling.Delete(VAFID)
    '        With objVAF_Sampling
    '            .VAF_SamplingID = 0
    '            If VAFID > 0 Then
    '                .VAFID = VAFID
    '            Else
    '                .VAFID = objVAF_BasicInformation.GetId()
    '            End If
    '            .SamplingDepartment = cmbSampling.SelectedItem.Text
    '            .NoOfMachine = Val(txtNoOfMachineSampling.Text)
    '            .Capacity = Val(txtCapacitySampling.Text)
    '            .SaveVAF_Sampling()
    '        End With

    '        'VAF_PDInfo
    '        objVAF_PDInfo.Delete(VAFID)
    '        Dim x4 As Integer
    '        For x4 = 0 To cmbPD.CheckedItems.Count - 1
    '            With objVAF_PDInfo
    '                .VAF_PDInfoID = 0
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .PDid = cmbPD.CheckedItems(x4).Value
    '                .SaveVAF_PDInfo()
    '            End With
    '        Next

    '        'VAF_PreTreatment
    '        objVAF_PreTreatment.Delete(VAFID)
    '        Dim x5 As Integer
    '        For x5 = 0 To cmbPD.CheckedItems.Count - 1
    '            With objVAF_PreTreatment
    '                .VAF_PreTreatmentID = 0
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .PreTreatmentID = cmbPD.CheckedItems(x5).Value
    '                .SaveVAF_PreTreatment()
    '            End With
    '        Next

    '        'VAF_MachineTechnical
    '        Dim x6 As Integer
    '        For x6 = 0 To dgMachineTechnical.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(dgMachineTechnical.MasterTableView.Items(x6), GridDataItem)
    '            With objVAF_MachineTechnical
    '                .VAF_MachineTechnicalID = item("VAF_MachineTechnicalID").Text
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .Machine = item("Machine").Text
    '                .WidthinCM = item("WidthinCM").Text
    '                .MeterPerday = item("MeterPerday").Text
    '                .Model = item("Model").Text
    '                .Year = item("Year").Text
    '                .Type = item("Type").Text
    '                .SaveVAF_MachineTechnical()
    '            End With
    '        Next

    '        'VAF_DyeingSpeciality
    '        objVAF_DyeingSpeciality.Delete(VAFID)
    '        Dim x7 As Integer
    '        For x7 = 0 To cmbPD.CheckedItems.Count - 1
    '            With objVAF_DyeingSpeciality
    '                .VAF_DyeingSpecialityID = 0
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .DyeingID = cmbPD.CheckedItems(x7).Value
    '                .SaveVAF_DyeingSpeciality()
    '            End With
    '        Next

    '        'VAF_EmbellishmentSpecialities
    '        Dim x8 As Integer
    '        For x8 = 0 To dgEmbellishmentSpecialities.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(dgEmbellishmentSpecialities.MasterTableView.Items(x8), GridDataItem)
    '            With objVAF_EmbellishmentSpecialities
    '                .VAF_EmbellishmentSpecialitiesID = item("VAF_EmbellishmentSpecialitiesID").Text
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .Capabilities = item("Capabilities").Text
    '                .Volume = item("Volume").Text
    '                .Unit = cmbVolumeUnit.SelectedItem.Text
    '                .NoofMac = item("NoofMac").Text
    '                .SaveVAF_EmbellishmentSpecialities()
    '            End With
    '        Next

    '        'VAF_StitchingLineMachine
    '        Dim x9 As Integer
    '        For x9 = 0 To dgStitchingLineMachine.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(dgStitchingLineMachine.MasterTableView.Items(x9), GridDataItem)
    '            With objVAF_StitchingLineMachine
    '                .VAF_StitchingLineMachineID = item("VAF_StitchingLineMachineID").Text
    '                If VAFID > 0 Then
    '                    .VAFID = VAFID
    '                Else
    '                    .VAFID = objVAF_BasicInformation.GetId()
    '                End If
    '                .Machine = item("Machine").Text
    '                .MachineTotal = item("MachineTotal").Text
    '                .SaveVAF_StitchingLineMachine()
    '            End With
    '        Next

    '        Session("dtPrimaryContact") = Nothing
    '        Session("dtHRBreakdown") = Nothing
    '        Session("dtTopCustomer") = Nothing
    '        Session("dtMachineTechnical") = Nothing
    '        Session("dtEmbellishmentSpecialities") = Nothing
    '        Session("dtStitchingLineMachine") = Nothing

    '        Response.Redirect("VAFView.aspx?SupplierID=" & objVender.EncryptData(cmbSupplier.SelectedValue) & "")

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Sub EditMode()
        Try

            Dim dtVAF_BasicInformation As DataTable
            dtVAF_BasicInformation = objVAF_BasicInformation.EditVAF_BasicInformation(VAFID)
            If dtVAF_BasicInformation.Rows.Count > 0 Then
                cmbSupplier.SelectedValue = dtVAF_BasicInformation.Rows(0)("SupplierID")
                cmbSupplier.Enabled = False
                cmbYearEstablished.SelectedValue = dtVAF_BasicInformation.Rows(0)("YearID")
                txtCode.Text = dtVAF_BasicInformation.Rows(0)("Code")
                txtCorporateAddress.Text = dtVAF_BasicInformation.Rows(0)("CorporateAddress")
                If dtVAF_BasicInformation.Rows(0)("Company") = "KG" Then
                    cmbCompany.SelectedValue = 0
                ElseIf dtVAF_BasicInformation.Rows(0)("Company") = "KG" Then
                    cmbCompany.SelectedValue = 1
                ElseIf dtVAF_BasicInformation.Rows(0)("Company") = "KG" Then
                    cmbCompany.SelectedValue = 2
                ElseIf dtVAF_BasicInformation.Rows(0)("Company") = "KG" Then
                    cmbCompany.SelectedValue = 3
                End If
            End If

            Dim dtVAF_Business As DataTable
            dtVAF_Business = objVAF_BasicInformation.EditVAF_Business(VAFID)
            Dim x1 As Integer
            For x1 = 0 To dtVAF_Business.Rows.Count - 1
                cmbBusiness.Items.FindItemByValue(dtVAF_Business.Rows(x1)("BusinessID")).Checked = True
            Next

            Dim dtVAF_Product As DataTable
            dtVAF_Product = objVAF_BasicInformation.EditVAF_Product(VAFID)
            Dim x2 As Integer
            For x2 = 0 To dtVAF_Product.Rows.Count - 1
                cmbProduct.Items.FindItemByValue(dtVAF_Product.Rows(x2)("ProductID")).Checked = True
            Next


            Dim dtVAF_PrimaryContact As DataTable
            dtVAF_PrimaryContact = objVAF_BasicInformation.EditVAF_PrimaryContact(VAFID)
            dtPrimaryContact = New DataTable
            With dtPrimaryContact
                .Columns.Add("VAF_PrimaryContactID", GetType(Long))
                .Columns.Add("Designation", GetType(String))
                .Columns.Add("Name", GetType(String))
                .Columns.Add("Phone", GetType(String))
                .Columns.Add("Cell", GetType(String))
                .Columns.Add("Email", GetType(String))
            End With
            For x3 = 0 To dtVAF_PrimaryContact.Rows.Count - 1
                Dr = dtPrimaryContact.NewRow()
                Dr("VAF_PrimaryContactID") = dtVAF_PrimaryContact.Rows(x3)("VAF_PrimaryContactID")
                Dr("Designation") = dtVAF_PrimaryContact.Rows(x3)("Designation")
                Dr("Name") = dtVAF_PrimaryContact.Rows(x3)("Name")
                Dr("Phone") = dtVAF_PrimaryContact.Rows(x3)("Phone")
                Dr("Cell") = dtVAF_PrimaryContact.Rows(x3)("Cell")
                Dr("Email") = dtVAF_PrimaryContact.Rows(x3)("Email")
                dtPrimaryContact.Rows.Add(Dr)
                Session("dtPrimaryContact") = dtPrimaryContact
            Next
            BindGridPrimaryContact()
            UpdgPrimaryContact.Update()

            Dim dtVAF_HRDetail As DataTable
            dtVAF_HRDetail = objVAF_BasicInformation.EditVAF_HRDetail(VAFID)
            If dtVAF_HRDetail.Rows.Count > 0 Then
                txtTotalWorker.Text = dtVAF_HRDetail.Rows(0)("TotalWorker")
                txtMale.Text = dtVAF_HRDetail.Rows(0)("Male")
                txtFemale.Text = dtVAF_HRDetail.Rows(0)("Female")
                txtPermanent.Text = dtVAF_HRDetail.Rows(0)("PermanentStaff")
                txtNoofShifts.Text = dtVAF_HRDetail.Rows(0)("NoofShift")
                txtTiming.Text = dtVAF_HRDetail.Rows(0)("Timing")
            End If

            Dim dtVAF_HRBreakdown As DataTable
            dtVAF_HRBreakdown = objVAF_BasicInformation.EditVAF_HRBreakdown(VAFID)
            dtHRBreakdown = New DataTable
            With dtHRBreakdown
                .Columns.Add("VAF_HRBreakdownID", GetType(Long))
                .Columns.Add("DeptID", GetType(Long))
                .Columns.Add("Department", GetType(String))
                .Columns.Add("No", GetType(Decimal))
            End With
            For x4 = 0 To dtVAF_HRBreakdown.Rows.Count - 1
                Dr = dtHRBreakdown.NewRow()
                Dr("VAF_HRBreakdownID") = dtVAF_HRBreakdown.Rows(x4)("VAF_HRBreakdownID")
                Dr("DeptID") = dtVAF_HRBreakdown.Rows(x4)("DeptID")
                Dr("Department") = dtVAF_HRBreakdown.Rows(x4)("Department")
                Dr("No") = dtVAF_HRBreakdown.Rows(x4)("No")
                dtHRBreakdown.Rows.Add(Dr)
                Session("dtHRBreakdown") = dtHRBreakdown
            Next
            BindHRBreakdown()
            UpdgHRBreakdown.Update()

            Dim dtVAF_Capacities As DataTable
            dtVAF_Capacities = objVAF_BasicInformation.EditVAF_Capacities(VAFID)
            If dtVAF_Capacities.Rows.Count > 0 Then
                txtFabricStock.Text = dtVAF_Capacities.Rows(0)("FabricStock")
                If dtVAF_Capacities.Rows(0)("FabricStockUnit") = "KG" Then
                    cmbFabricStockUnit.SelectedValue = 0
                ElseIf dtVAF_Capacities.Rows(0)("FabricStockUnit") = "MT" Then
                    cmbFabricStockUnit.SelectedValue = 1
                ElseIf dtVAF_Capacities.Rows(0)("FabricStockUnit") = "M" Then
                    cmbFabricStockUnit.SelectedValue = 2
                ElseIf dtVAF_Capacities.Rows(0)("FabricStockUnit") = "Nos" Then
                    cmbFabricStockUnit.SelectedValue = 3
                ElseIf dtVAF_Capacities.Rows(0)("FabricStockUnit") = "PCs" Then
                    cmbFabricStockUnit.SelectedValue = 4
                End If

                txtProdcapacitymonth.Text = dtVAF_Capacities.Rows(0)("ProdCapacitymonth")
                If dtVAF_Capacities.Rows(0)("ProdCapacitymonthUnit") = "KG" Then
                    cmbProdcapacitymonthUnit.SelectedValue = 0
                ElseIf dtVAF_Capacities.Rows(0)("ProdCapacitymonthUnit") = "MT" Then
                    cmbProdcapacitymonthUnit.SelectedValue = 1
                ElseIf dtVAF_Capacities.Rows(0)("ProdCapacitymonthUnit") = "M" Then
                    cmbProdcapacitymonthUnit.SelectedValue = 2
                ElseIf dtVAF_Capacities.Rows(0)("ProdCapacitymonthUnit") = "Nos" Then
                    cmbProdcapacitymonthUnit.SelectedValue = 3
                ElseIf dtVAF_Capacities.Rows(0)("ProdCapacitymonthUnit") = "PCs" Then
                    cmbProdcapacitymonthUnit.SelectedValue = 4
                End If

                txtCuttingcapacitymonth.Text = dtVAF_Capacities.Rows(0)("CuttingCapacitymonth")
                txtwashingcapacity.Text = dtVAF_Capacities.Rows(0)("washingCapacity")
                txtNooflines.Text = dtVAF_Capacities.Rows(0)("NoOfLines")
                txtNoofmachineline.Text = dtVAF_Capacities.Rows(0)("NoOfMachineline")
                txtSAMSMV.Text = dtVAF_Capacities.Rows(0)("SAMorSMV")
            End If

            Dim dtVAF_GeneralInformation As DataTable
            dtVAF_GeneralInformation = objVAF_BasicInformation.EditVAF_GeneralInformation(VAFID)
            If dtVAF_GeneralInformation.Rows.Count > 0 Then
                txtCompanycoverdArea.Text = dtVAF_GeneralInformation.Rows(0)("CompanyCoverdAreasqm")
                txtFactoryArea.Text = dtVAF_GeneralInformation.Rows(0)("FactoryAreasqm")
                lblYear1.Text = dtVAF_GeneralInformation.Rows(0)("Year1")
                txtAnnualturnover1.Text = dtVAF_GeneralInformation.Rows(0)("AnnualTurnover1")
                lblYear2.Text = dtVAF_GeneralInformation.Rows(0)("Year2")
                txtAnnualturnover2.Text = dtVAF_GeneralInformation.Rows(0)("AnnualTurnover2")
                lblYear3.Text = dtVAF_GeneralInformation.Rows(0)("Year3")
                txtAnnualturnover3.Text = dtVAF_GeneralInformation.Rows(0)("AnnualTurnover3")
                txtTotalAnnualShipmentsvolumeglobally.Text = dtVAF_GeneralInformation.Rows(0)("TotalAnnualShipmentsVolumeGlobally")
                txtTotalAnnualShipmentstothevolumeEurope.Text = dtVAF_GeneralInformation.Rows(0)("TotalAnnualShipmentsEurope")
            End If

            Dim dtVAF_TopCustomer As DataTable
            dtVAF_TopCustomer = objVAF_BasicInformation.EditVAF_TopCustomer(VAFID)
            dtTopCustomer = New DataTable
            With dtTopCustomer
                .Columns.Add("VAF_TopCustomerID", GetType(Long))
                .Columns.Add("CustomerName", GetType(String))
                .Columns.Add("Country_id", GetType(Long))
                .Columns.Add("CustomerCountry", GetType(String))
                .Columns.Add("CustomerPercentOfBuss", GetType(String))
                .Columns.Add("CustomerProduct", GetType(String))
            End With
            For x5 = 0 To dtVAF_TopCustomer.Rows.Count - 1
                Dr = dtTopCustomer.NewRow()
                Dr("VAF_TopCustomerID") = dtVAF_TopCustomer.Rows(x5)("VAF_TopCustomerID")
                Dr("CustomerName") = dtVAF_TopCustomer.Rows(x5)("CustomerName")
                Dr("Country_id") = dtVAF_TopCustomer.Rows(x5)("Country_id")
                Dr("CustomerCountry") = dtVAF_TopCustomer.Rows(x5)("CustomerCountry")
                Dr("CustomerPercentOfBuss") = dtVAF_TopCustomer.Rows(x5)("CustomerPercentOfBuss")
                Dr("CustomerProduct") = dtVAF_TopCustomer.Rows(x5)("CustomerProduct")
                dtTopCustomer.Rows.Add(Dr)
                Session("dtTopCustomer") = dtTopCustomer
            Next
            BindTopCustomer()
            UpdgTopCustomer.Update()

            Dim dtVAF_ConceptualDesign As DataTable
            dtVAF_ConceptualDesign = objVAF_BasicInformation.EditVAF_ConceptualDesign(VAFID)
            If dtVAF_ConceptualDesign.Rows.Count > 0 Then
                If dtVAF_ConceptualDesign.Rows(0)("ConceptualDesignStaff") = "Yes" Then
                    cmbConceptualDesign.SelectedValue = 1
                Else
                    cmbConceptualDesign.SelectedValue = 0
                End If
                If dtVAF_ConceptualDesign.Rows(0)("InHouse") = True Then
                    chkInHouse.Checked = True
                Else
                    chkInHouse.Checked = False
                End If
                If dtVAF_ConceptualDesign.Rows(0)("NumberOfInHouseDesigners") = True Then
                    chkNumberOfInHouseDesigners.Checked = True
                Else
                    chkNumberOfInHouseDesigners.Checked = False
                End If
                txtInHouseLocation.Text = dtVAF_ConceptualDesign.Rows(0)("InHouseLocation")
                If dtVAF_ConceptualDesign.Rows(0)("Contracted") = True Then
                    chkContracted.Checked = True
                Else
                    chkContracted.Checked = False
                End If
                If dtVAF_ConceptualDesign.Rows(0)("NumberOfOutsideDesigners") = True Then
                    chkNumberOfOutsideDesigners.Checked = True
                Else
                    chkNumberOfOutsideDesigners.Checked = False
                End If
                txtContractedLocation.Text = dtVAF_ConceptualDesign.Rows(0)("ContractedLocation")
            End If

            Dim dtVAF_Sampling As DataTable
            dtVAF_Sampling = objVAF_BasicInformation.EditVAF_Sampling(VAFID)
            If dtVAF_Sampling.Rows.Count > 0 Then
                If dtVAF_Sampling.Rows(0)("SamplingDepartment") = "Yes" Then
                    cmbSampling.SelectedValue = 1
                Else
                    cmbSampling.SelectedValue = 0
                End If
                txtNoOfMachineSampling.Text = dtVAF_Sampling.Rows(0)("NoOfMachine")
                txtCapacitySampling.Text = dtVAF_Sampling.Rows(0)("Capacity")
            End If


            Dim dtVAF_PDInfo As DataTable
            dtVAF_PDInfo = objVAF_BasicInformation.EditVAF_PDInfo(VAFID)
            Dim x6 As Integer
            For x6 = 0 To dtVAF_PDInfo.Rows.Count - 1
                cmbPD.Items.FindItemByValue(dtVAF_PDInfo.Rows(x6)("PDid")).Checked = True
            Next

            Dim dtVAF_PreTreatment As DataTable
            dtVAF_PreTreatment = objVAF_BasicInformation.EditVAF_PreTreatment(VAFID)
            Dim x7 As Integer
            For x7 = 0 To dtVAF_PreTreatment.Rows.Count - 1
                cmbPreTreatmentSpeciality.Items.FindItemByValue(dtVAF_PreTreatment.Rows(x7)("PreTreatmentID")).Checked = True
            Next

            Dim dtVAF_MachineTechnical As DataTable
            dtVAF_MachineTechnical = objVAF_BasicInformation.EditVAF_MachineTechnical(VAFID)
            dtMachineTechnical = New DataTable
            With dtMachineTechnical
                .Columns.Add("VAF_MachineTechnicalID", GetType(Long))
                .Columns.Add("Machine", GetType(String))
                .Columns.Add("WidthinCM", GetType(Decimal))
                .Columns.Add("MeterPerday", GetType(Decimal))
                .Columns.Add("Model", GetType(String))
                .Columns.Add("Year", GetType(Decimal))
                .Columns.Add("Type", GetType(String))
            End With
            For x8 = 0 To dtVAF_MachineTechnical.Rows.Count - 1
                Dr = dtMachineTechnical.NewRow()
                Dr("VAF_MachineTechnicalID") = dtVAF_MachineTechnical.Rows(x8)("VAF_MachineTechnicalID")
                Dr("Machine") = dtVAF_MachineTechnical.Rows(x8)("Machine")
                Dr("WidthinCM") = dtVAF_MachineTechnical.Rows(x8)("WidthinCM")
                Dr("MeterPerday") = dtVAF_MachineTechnical.Rows(x8)("MeterPerday")
                Dr("Model") = dtVAF_MachineTechnical.Rows(x8)("Model")
                Dr("Year") = dtVAF_MachineTechnical.Rows(x8)("Year")
                Dr("Type") = dtVAF_MachineTechnical.Rows(x8)("Type")
                dtMachineTechnical.Rows.Add(Dr)
                Session("dtMachineTechnical") = dtMachineTechnical
            Next
            BindMachineTechnical()
            UpdgMachineTechnical.Update()

            Dim dtVAF_DyeingSpeciality As DataTable
            dtVAF_DyeingSpeciality = objVAF_BasicInformation.EditVAF_DyeingSpeciality(VAFID)
            Dim x9 As Integer
            For x9 = 0 To dtVAF_DyeingSpeciality.Rows.Count - 1
                cmbDyeingSpeciality.Items.FindItemByValue(dtVAF_DyeingSpeciality.Rows(x9)("DyeingID")).Checked = True
            Next

            Dim dtVAF_EmbellishmentSpecialities As DataTable
            dtVAF_EmbellishmentSpecialities = objVAF_BasicInformation.EditVAF_EmbellishmentSpecialities(VAFID)
            dtEmbellishmentSpecialities = New DataTable
            With dtEmbellishmentSpecialities
                .Columns.Add("VAF_EmbellishmentSpecialitiesID", GetType(Long))
                .Columns.Add("Capabilities", GetType(String))
                .Columns.Add("Volume", GetType(Decimal))
                .Columns.Add("Unit", GetType(String))
                .Columns.Add("NoofMac", GetType(Decimal))
            End With
            For x10 = 0 To dtVAF_EmbellishmentSpecialities.Rows.Count - 1
                Dr = dtEmbellishmentSpecialities.NewRow()
                Dr("VAF_EmbellishmentSpecialitiesID") = dtVAF_EmbellishmentSpecialities.Rows(x10)("VAF_EmbellishmentSpecialitiesID")
                Dr("Capabilities") = dtVAF_EmbellishmentSpecialities.Rows(x10)("Capabilities")
                Dr("Volume") = dtVAF_EmbellishmentSpecialities.Rows(x10)("Volume")
                Dr("Unit") = dtVAF_EmbellishmentSpecialities.Rows(x10)("Unit")
                Dr("NoofMac") = dtVAF_EmbellishmentSpecialities.Rows(x10)("NoofMac")
                dtEmbellishmentSpecialities.Rows.Add(Dr)
                Session("dtEmbellishmentSpecialities") = dtEmbellishmentSpecialities
            Next
            BindEmbellishmentSpecialities()
            UpdgEmbellishmentSpecialities.Update()


            Dim dtVAF_StitchingLineMachine As DataTable
            dtVAF_StitchingLineMachine = objVAF_BasicInformation.EditVAF_StitchingLineMachine(VAFID)
            dtStitchingLineMachine = New DataTable
            With dtStitchingLineMachine
                .Columns.Add("VAF_StitchingLineMachineID", GetType(Long))
                .Columns.Add("Machine", GetType(String))
                .Columns.Add("MachineTotal", GetType(Decimal))
            End With
            For x11 = 0 To dtVAF_StitchingLineMachine.Rows.Count - 1
                Dr = dtStitchingLineMachine.NewRow()
                Dr("VAF_StitchingLineMachineID") = dtVAF_StitchingLineMachine.Rows(x11)("VAF_StitchingLineMachineID")
                Dr("Machine") = dtVAF_StitchingLineMachine.Rows(x11)("Machine")
                Dr("MachineTotal") = dtVAF_StitchingLineMachine.Rows(x11)("MachineTotal")
                dtStitchingLineMachine.Rows.Add(Dr)
                Session("dtStitchingLineMachine") = dtStitchingLineMachine
            Next
            BindStitchingLineMachine()
            UpdgStitchingLineMachine.Update()
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
    '    Try
    '        Session("dtPrimaryContact") = Nothing
    '        Session("dtHRBreakdown") = Nothing
    '        Session("dtTopCustomer") = Nothing
    '        Session("dtMachineTechnical") = Nothing
    '        Session("dtEmbellishmentSpecialities") = Nothing
    '        Session("dtStitchingLineMachine") = Nothing

    '        Response.Redirect("VAFView.aspx?SupplierID=" & objVender.EncryptData(cmbSupplier.SelectedValue) & "")
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Protected Sub dgPrimaryContact_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgPrimaryContact.DeleteCommand
        Try
            dtPrimaryContact = CType(Session("dtPrimaryContact"), DataTable)
            If (Not dtPrimaryContact Is Nothing) Then
                If (dtPrimaryContact.Rows.Count > 0) Then
                    Dim VAF_PrimaryContactID As Integer = dtPrimaryContact.Rows(e.Item.ItemIndex)("VAF_PrimaryContactID")
                    dtPrimaryContact.Rows.RemoveAt(e.Item.ItemIndex)
                    objVAF_PrimaryContact.DeleteRow(VAF_PrimaryContactID)
                    BindGridPrimaryContact()
                    UpdgPrimaryContact.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgHRBreakdown_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgHRBreakdown.DeleteCommand
        Try
            dtHRBreakdown = CType(Session("dtHRBreakdown"), DataTable)
            If (Not dtHRBreakdown Is Nothing) Then
                If (dtHRBreakdown.Rows.Count > 0) Then
                    Dim VAF_HRBreakdownID As Integer = dtHRBreakdown.Rows(e.Item.ItemIndex)("VAF_HRBreakdownID")
                    dtHRBreakdown.Rows.RemoveAt(e.Item.ItemIndex)
                    objVAF_HRBreakdown.DeleteRow(VAF_HRBreakdownID)
                    BindHRBreakdown()
                    UpdgHRBreakdown.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgTopCustomer_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgTopCustomer.DeleteCommand
        Try
            dtTopCustomer = CType(Session("dtTopCustomer"), DataTable)
            If (Not dtTopCustomer Is Nothing) Then
                If (dtTopCustomer.Rows.Count > 0) Then
                    Dim VAF_TopCustomerID As Integer = dtTopCustomer.Rows(e.Item.ItemIndex)("VAF_TopCustomerID")
                    dtTopCustomer.Rows.RemoveAt(e.Item.ItemIndex)
                    objVAF_TopCustomer.DeleteRow(VAF_TopCustomerID)
                    BindTopCustomer()
                    UpdgTopCustomer.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgMachineTechnical_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgMachineTechnical.DeleteCommand
        Try
            dtMachineTechnical = CType(Session("dtMachineTechnical"), DataTable)
            If (Not dtMachineTechnical Is Nothing) Then
                If (dtMachineTechnical.Rows.Count > 0) Then
                    Dim VAF_MachineTechnicalID As Integer = dtMachineTechnical.Rows(e.Item.ItemIndex)("VAF_MachineTechnicalID")
                    dtMachineTechnical.Rows.RemoveAt(e.Item.ItemIndex)
                    objVAF_MachineTechnical.DeleteRow(VAF_MachineTechnicalID)
                    BindMachineTechnical()
                    UpdgMachineTechnical.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgEmbellishmentSpecialities_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgEmbellishmentSpecialities.DeleteCommand
        Try
            dtEmbellishmentSpecialities = CType(Session("dtEmbellishmentSpecialities"), DataTable)
            If (Not dtEmbellishmentSpecialities Is Nothing) Then
                If (dtEmbellishmentSpecialities.Rows.Count > 0) Then
                    Dim VAF_EmbellishmentSpecialitiesID As Integer = dtEmbellishmentSpecialities.Rows(e.Item.ItemIndex)("VAF_EmbellishmentSpecialitiesID")
                    dtEmbellishmentSpecialities.Rows.RemoveAt(e.Item.ItemIndex)
                    objVAF_EmbellishmentSpecialities.DeleteRow(VAF_EmbellishmentSpecialitiesID)
                    BindEmbellishmentSpecialities()
                    UpdgEmbellishmentSpecialities.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgStitchingLineMachine_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgStitchingLineMachine.DeleteCommand
        Try
            dtStitchingLineMachine = CType(Session("dtStitchingLineMachine"), DataTable)
            If (Not dtStitchingLineMachine Is Nothing) Then
                If (dtStitchingLineMachine.Rows.Count > 0) Then
                    Dim VAF_StitchingLineMachineID As Integer = dtStitchingLineMachine.Rows(e.Item.ItemIndex)("VAF_StitchingLineMachineID")
                    dtStitchingLineMachine.Rows.RemoveAt(e.Item.ItemIndex)
                    objVAF_StitchingLineMachine.DeleteRow(VAF_StitchingLineMachineID)
                    BindEmbellishmentSpecialities()
                    UpdgEmbellishmentSpecialities.Update()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub cmbDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDept.SelectedIndexChanged
    '    Try
    '        If cmbDept.SelectedItem.Text = "Others" Then
    '            cmbDept.Visible = False
    '            txtDeptMore.Visible = True
    '            '    btnAddDept.Visible = True

    '            UpcmbDept.Update()
    '            UptxtDeptMore.Update()
    '            '  UpbtnAddDept.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnAddDept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDept.Click
    '    Try
    '        If txtDeptMore.Text = "" Then
    '            BindcmbDept()

    '            cmbDept.Visible = True
    '            txtDeptMore.Visible = False
    '            '  btnAddDept.Visible = False

    '            UpcmbDept.Update()
    '            UptxtDeptMore.Update()
    '            ' UpbtnAddDept.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateDept(txtDeptMore.Text)
    '            txtDeptMore.Text = ""
    '            BindcmbDept()

    '            cmbDept.Visible = True
    '            txtDeptMore.Visible = False
    '            '   btnAddDept.Visible = False

    '            UpcmbDept.Update()
    '            UptxtDeptMore.Update()
    '            '  UpbtnAddDept.Update()

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub cmbCapabilities_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCapabilities.SelectedIndexChanged
    '    Try
    '        If cmbCapabilities.SelectedItem.Text = "Others" Then
    '            cmbCapabilities.Visible = False
    '            ' txtCapabilities.Visible = True
    '            '  btnSaveCapabilities.Visible = True

    '            ' UpcmbCapabilities.Update()
    '            ' UptxtCapabilities.Update()
    '            '  UpbtnSaveCapabilities.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSaveCapabilities_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveCapabilities.Click
    '    Try
    '        If txtCapabilities.Text = "" Then
    '            BindcmbCapabilities()

    '            cmbCapabilities.Visible = True
    '            txtCapabilities.Visible = False
    '            '  btnSaveCapabilities.Visible = False

    '            UpcmbCapabilities.Update()
    '            UptxtCapabilities.Update()
    '            ' UpbtnSaveCapabilities.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateCapabilities(txtCapabilities.Text)
    '            txtCapabilities.Text = ""
    '            BindcmbCapabilities()

    '            cmbCapabilities.Visible = True
    '            txtCapabilities.Visible = False
    '            '  btnSaveCapabilities.Visible = False

    '            UpcmbCapabilities.Update()
    '            UptxtCapabilities.Update()
    '            '   UpbtnSaveCapabilities.Update()

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub cmbMachine_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMachine.SelectedIndexChanged
    '    Try
    '        If cmbMachine.SelectedItem.Text = "Others" Then
    '            cmbMachine.Visible = False
    '            ' txtMachineName.Visible = True
    '            ' btnSaveMachine.Visible = True

    '            ' UpdcmbMachine.Update()
    '            'UptxtMachineName.Update()
    '            '  UpbtnSaveMachine.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSaveMachine_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveMachine.Click
    '    Try
    '        If txtMachineName.Text = "" Then
    '            BindcmbMachine()

    '            cmbMachine.Visible = True
    '            txtMachineName.Visible = False
    '            '  btnSaveMachine.Visible = False

    '            UpdcmbMachine.Update()
    '            UptxtMachineName.Update()
    '            '   UpbtnSaveMachine.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateV_Machine(txtMachineName.Text)
    '            txtMachineName.Text = ""
    '            BindcmbMachine()

    '            cmbMachine.Visible = True
    '            txtMachineName.Visible = False
    '            '  btnSaveMachine.Visible = False

    '            UpdcmbMachine.Update()
    '            UptxtMachineName.Update()
    '            ' UpbtnSaveMachine.Update()

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSaveBusiness_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveBusiness.Click
    '    Try
    '        If txtBusiness.Text = "" Then
    '            BindcmbBusiness()

    '            cmbBusiness.Visible = True
    '            txtBusiness.Visible = False
    '            ' btnAddBusinessA.Visible = True
    '            '  btnSaveBusiness.Visible = False

    '            UpcmbBusiness.Update()
    '            UptxtBusiness.Update()
    '            '  UpbtnAddBusiness.Update()
    '            '  UpbtnSaveBusiness.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateV_Business(txtBusiness.Text)
    '            txtBusiness.Text = ""
    '            BindcmbBusiness()

    '            cmbBusiness.Visible = True
    '            txtBusiness.Visible = False
    '            '  btnAddBusinessA.Visible = True
    '            '  btnSaveBusiness.Visible = False

    '            UpcmbBusiness.Update()
    '            UptxtBusiness.Update()
    '            ' UpbtnAddBusiness.Update()
    '            ' UpbtnSaveBusiness.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSaveProduct_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveProduct.Click
    '    Try
    '        If txtProduct.Text = "" Then
    '            BindcmbProduct()

    '            cmbProduct.Visible = True
    '            txtProduct.Visible = False
    '            '  btnAddProductA.Visible = True
    '            '  btnSaveProduct.Visible = False

    '            UpcmbProduct.Update()
    '            '  UpbtnAddProduct.Update()
    '            UptxtProduct.Update()
    '            ' UpbtnSaveProduct.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateV_Product(txtProduct.Text)
    '            txtProduct.Text = ""
    '            BindcmbProduct()

    '            cmbProduct.Visible = True
    '            txtProduct.Visible = False
    '            '  btnAddProductA.Visible = True
    '            ' btnSaveProduct.Visible = False

    '            UpcmbProduct.Update()
    '            ' UpbtnAddProduct.Update()
    '            UptxtProduct.Update()
    '            '  UpbtnSaveProduct.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSavePD_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSavePD.Click
    '    Try
    '        If txtPDinfo.Text = "" Then
    '            BindcmbPD()

    '            cmbPD.Visible = True
    '            txtPDinfo.Visible = False
    '            ' btnAddPDA.Visible = True
    '            ' btnSavePD.Visible = False

    '            UpcmbPD.Update()
    '            ' UpbtnAddPD.Update()
    '            UptxtPDinfo.Update()
    '            '  UpbtnSavePD.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateV_PD(txtPDinfo.Text)
    '            txtPDinfo.Text = ""
    '            BindcmbPD()

    '            cmbPD.Visible = True
    '            txtPDinfo.Visible = False
    '            '  btnAddPDA.Visible = True
    '            '   btnSavePD.Visible = False

    '            UpcmbPD.Update()
    '            '  UpbtnAddPD.Update()
    '            UptxtPDinfo.Update()
    '            ' UpbtnSavePD.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSavePreTreatmentSpeciality_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSavePreTreatmentSpeciality.Click
    '    Try
    '        If txtPreTreatmentSpeciality.Text = "" Then
    '            BindcmbPreTreatmentSpeciality()

    '            cmbPreTreatmentSpeciality.Visible = True
    '            txtPreTreatmentSpeciality.Visible = False
    '            '  btnAddPreTreatmentSpecialityA.Visible = True
    '            '  btnSavePreTreatmentSpeciality.Visible = False

    '            UpcmbPreTreatmentSpeciality.Update()
    '            '  UpbtnAddPreTreatmentSpeciality.Update()
    '            UptxtPreTreatmentSpeciality.Update()
    '            ' UpbtnSavePreTreatmentSpeciality.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateV_PreTreatment(txtPreTreatmentSpeciality.Text)
    '            txtPreTreatmentSpeciality.Text = ""
    '            BindcmbPreTreatmentSpeciality()

    '            cmbPreTreatmentSpeciality.Visible = True
    '            txtPreTreatmentSpeciality.Visible = False
    '            ' btnAddPreTreatmentSpecialityA.Visible = True
    '            ' btnSavePreTreatmentSpeciality.Visible = False

    '            UpcmbPreTreatmentSpeciality.Update()
    '            ' UpbtnAddPreTreatmentSpeciality.Update()
    '            UptxtPreTreatmentSpeciality.Update()
    '            ' UpbtnSavePreTreatmentSpeciality.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnSaveDyeingSpecialit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveDyeingSpecialit.Click
    '    Try
    '        If txtDyeingSpecialit.Text = "" Then
    '            BindcmbDyeingSpeciality()

    '            cmbDyeingSpeciality.Visible = True
    '            txtDyeingSpecialit.Visible = False
    '            ' btnAddDyeingSpecialitA.Visible = True
    '            ' btnSaveDyeingSpecialit.Visible = False

    '            UpcmbDyeingSpeciality.Update()
    '            ' UpbtnAddDyeingSpecialit.Update()
    '            UptxtDyeingSpecialit.Update()
    '            ' UpbtnSaveDyeingSpecialit.Update()
    '        Else
    '            objVAF_BasicInformation.UpdateV_Dyeing(txtDyeingSpecialit.Text)
    '            txtDyeingSpecialit.Text = ""
    '            BindcmbDyeingSpeciality()

    '            cmbDyeingSpeciality.Visible = True
    '            txtDyeingSpecialit.Visible = False
    '            ' btnAddDyeingSpecialitA.Visible = True
    '            ' btnSaveDyeingSpecialit.Visible = False

    '            UpcmbDyeingSpeciality.Update()
    '            '  UpbtnAddDyeingSpecialit.Update()
    '            UptxtDyeingSpecialit.Update()
    '            'UpbtnSaveDyeingSpecialit.Update()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub lnkSocialCompliances_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkSocialCompliances.Click
    '    Try
    '        ScriptManager.RegisterClientScriptBlock(Me.upCertificate, Me.upCertificate.GetType(), "New ClientScript", "window.open('SupplierCertificates.aspx?SupplierID=" & objVender.EncryptData(cmbSupplier.SelectedValue) & "', 'newwindow', 'left=50, top=30, height=520, width=800, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnAddBusinessA_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddBusinessA.Click
    '    Try
    '        cmbBusiness.Visible = False
    '        txtBusiness.Visible = True
    '        '  btnAddBusinessA.Visible = False
    '        'btnSaveBusiness.Visible = True

    '        UpcmbBusiness.Update()
    '        UptxtBusiness.Update()
    '        ' UpbtnSaveBusiness.Update()
    '        ' UpbtnAddBusiness.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnAddProductA_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddProductA.Click
    '    Try
    '        cmbProduct.Visible = False
    '        txtProduct.Visible = True
    '        ' btnAddProductA.Visible = False
    '        'btnSaveProduct.Visible = True

    '        UpcmbProduct.Update()
    '        ' UpbtnAddProduct.Update()
    '        UptxtProduct.Update()
    '        ' UpbtnSaveProduct.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnAddPDA_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddPDA.Click
    '    Try
    '        cmbPD.Visible = False
    '        txtPDinfo.Visible = True
    '        btnAddPDA.Visible = False
    '        btnSavePD.Visible = True

    '        UpcmbPD.Update()
    '        UpbtnAddPD.Update()
    '        UptxtPDinfo.Update()
    '        UpbtnSavePD.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnAddPreTreatmentSpecialityA_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddPreTreatmentSpecialityA.Click
    '    Try
    '        cmbPreTreatmentSpeciality.Visible = False
    '        txtPreTreatmentSpeciality.Visible = True
    '        btnAddPreTreatmentSpecialityA.Visible = False
    '        btnSavePreTreatmentSpeciality.Visible = True

    '        UpcmbPreTreatmentSpeciality.Update()
    '        UpbtnAddPreTreatmentSpeciality.Update()
    '        UptxtPreTreatmentSpeciality.Update()
    '        UpbtnSavePreTreatmentSpeciality.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Protected Sub btnAddDyeingSpecialitA_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddDyeingSpecialitA.Click
    '    Try
    '        cmbDyeingSpeciality.Visible = False
    '        txtDyeingSpecialit.Visible = True
    '        btnAddDyeingSpecialitA.Visible = False
    '        btnSaveDyeingSpecialit.Visible = True

    '        UpcmbDyeingSpeciality.Update()
    '        UpbtnAddDyeingSpecialit.Update()
    '        UptxtDyeingSpecialit.Update()
    '        UpbtnSaveDyeingSpecialit.Update()
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class