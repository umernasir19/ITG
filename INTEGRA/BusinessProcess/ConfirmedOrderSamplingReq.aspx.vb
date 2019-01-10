Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.Xml
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class ConfirmedOrderSamplingReq
    Inherits System.Web.UI.Page
    Dim ObjSamplingMaster As New SamplingMaster
    Dim ObjSamplingDetail As New SamplingDetail
    Dim objSamplingHistory As New SamplingHistory
    Dim Dr As DataRow
    Dim dtSampleDetail As DataTable
    Dim SamplingMasterID As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SamplingMasterID = Request.QueryString("SamplingMasterID")
        If Not Page.IsPostBack Then
            Session("dtSampleDetail") = Nothing
            BindSeason()
            BindCustomer()
            BindSupplier()
            If SamplingMasterID > 0 Then
                Edit()
                dgSampleDetail.Columns(16).Visible = True
                btnAddSample.Visible = False
                btnAddMoreSample.Visible = True
                cmbStyle.Enabled = False
                UpStyleNo.Update()
                cmbCustomer.Enabled = False
                UpcmbCustomer.Update()
                cmbBrand.Enabled = False
                UpcmbBrand.Update()
                cmbBuyerName.Enabled = False
                UpdatecmbBuyerName.Update()
                cmbBuyingDept.Enabled = False
                UpcmbBuyingDept.Update()
                cmbSeason.Enabled = False
                UpcmbSeason.Update()
            Else
                btnAddSample.Visible = True
                btnAddMoreSample.Visible = False
                dgSampleDetail.Columns(16).Visible = False
            End If

        End If
    End Sub
    Sub Edit()
        Dim dtMaster As DataTable = ObjSamplingMaster.GetMaster(SamplingMasterID)
        If dtMaster.Rows.Count > 0 Then
            cmbCustomer.SelectedValue = dtMaster.Rows(0)("CustomerID")
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = ObjSamplingMaster.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
            cmbBuyingDept.SelectedValue = dtMaster.Rows(0)("BuyingDept")
            ''---Bind Byuer Name
            cmbBuyerName.DataSource = ObjSamplingMaster.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()
            cmbBuyerName.SelectedValue = dtMaster.Rows(0)("Buyer")
            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingMaster.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            cmbBrand.SelectedValue = dtMaster.Rows(0)("Brand")
            cmbSeason.SelectedValue = dtMaster.Rows(0)("SeasonID")
            BindStyle()
            UpStyleNo.Update()
            cmbStyle.SelectedValue = dtMaster.Rows(0)("InquiryStyleID")

            BindSupplier()
            cmbsupplier.SelectedValue = dtMaster.Rows(0)("SupplierID")
            txtDesignName.Text = dtMaster.Rows(0)("DesignName")
            txtStyleDescription.Text = dtMaster.Rows(0)("StyleDescription")
            cmbSample.SelectedValue = dtMaster.Rows(0)("InquiryType")
        End If
        Dim dtPrduct As DataTable = ObjSamplingMaster.GetDetail(SamplingMasterID)
        If dtPrduct.Rows.Count > 0 Then
            dgSampleDetail.DataSource = dtPrduct
            dgSampleDetail.DataBind()
            dgSampleDetail.Visible = True
            BindFabricType()
            If (Not CType(Session("dtSampleDetail"), DataTable) Is Nothing) Then
                dtSampleDetail = Session("dtSampleDetail")
            Else
                dtSampleDetail = New DataTable
                With dtSampleDetail
                    .Columns.Add("SamplingDetailID", GetType(Long))
                    .Columns.Add("SampleType", GetType(String))
                    .Columns.Add("FabricTypeID", GetType(String))
                    .Columns.Add("FabricType", GetType(String))
                    .Columns.Add("NoofPieces", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("Size", GetType(String))
                    .Columns.Add("DeadLine", GetType(String))
                    .Columns.Add("ReceivedDate", GetType(String))
                    .Columns.Add("DispatchedDate", GetType(String))
                    .Columns.Add("NoofPcsDis", GetType(String))
                    .Columns.Add("Submission", GetType(String))
                    .Columns.Add("Status", GetType(String))
                    .Columns.Add("SampleRemarks", GetType(String))
                    .Columns.Add("SampleLocation", GetType(String))
                    .Columns.Add("RejConSample", GetType(String))
                    .Columns.Add("CommentsReceivedDate", GetType(String))
                    .Columns.Add("SupEstdate", GetType(String))
                    .Columns.Add("NoofPcsRecvd", GetType(String))
                End With
            End If

            For x = 0 To dtPrduct.Rows.Count - 1
                Dim cmbSampleType As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbSampleType"), DropDownList)
                Dim cmbFabricType As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbFabricType"), DropDownList)
                Dim txtNoofPieces As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtNoofPieces"), TextBox)
                Dim txtColor As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtColor"), TextBox)
                Dim txtSize As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSize"), TextBox)
                Dim txtDeadLine As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtDeadLine"), TextBox)
                Dim txtReceivedDate As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtReceivedDate"), TextBox)
                Dim txtDispatchedDate As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtDispatchedDate"), TextBox)
                Dim txtNoofPcsDis As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtNoofPcsDis"), TextBox)
                Dim cmbSubmission As DropDownList = DirectCast(dgSampleDetail.Items(x).FindControl("cmbSubmission"), DropDownList)
                Dim cmbStatus As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbStatus"), DropDownList)
                Dim txtSampleRemarks As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSampleRemarks"), TextBox)
                Dim txtSampleLocation As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSampleLocation"), TextBox)
                Dim txtCommentsReceived As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtCommentsReceived"), TextBox)
                Dim txtSupEstdate As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSupEstdate"), TextBox)
                Dim txtNoofPcsRecvd As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtNoofPcsRecvd"), TextBox)
                Dr = dtSampleDetail.NewRow()
                Dr("SamplingDetailID") = dtPrduct.Rows(x)("SamplingDetailID")
                Dr("SampleType") = dtPrduct.Rows(x)("SampleType")
                Dr("FabricTypeID") = dtPrduct.Rows(x)("FabricTypeID")
                Dr("FabricType") = dtPrduct.Rows(x)("FabricType")
                Dr("NoofPieces") = dtPrduct.Rows(x)("NoofPieces")
                Dr("Color") = dtPrduct.Rows(x)("Color")
                Dr("Size") = dtPrduct.Rows(x)("Size")
                Dr("DeadLine") = dtPrduct.Rows(x)("DeadLine")
                Dr("ReceivedDate") = dtPrduct.Rows(x)("ReceivedDate")
                Dr("DispatchedDate") = dtPrduct.Rows(x)("DispatchedDate")
                Dr("NoofPcsDis") = dtPrduct.Rows(x)("NoofPcsDis")
                Dr("Submission") = dtPrduct.Rows(x)("Submission")
                Dr("Status") = dtPrduct.Rows(x)("Status")
                Dr("SampleRemarks") = dtPrduct.Rows(x)("SampleRemarks")
                Dr("SampleLocation") = dtPrduct.Rows(x)("SampleLocation")
                Dr("RejConSample") = dtPrduct.Rows(x)("RejConSample")
                Dr("CommentsReceivedDate") = dtPrduct.Rows(x)("CommentsReceivedDate")
                Dr("SupEstdate") = dtPrduct.Rows(x)("SupEstdate")
                Dr("NoofPcsRecvd") = dtPrduct.Rows(x)("NoofPcsRecvd")
                dtSampleDetail.Rows.Add(Dr)
                txtSupEstdate.Text = dtPrduct.Rows(x)("SupEstdate")
                txtNoofPcsRecvd.Text = dtPrduct.Rows(x)("NoofPcsRecvd")
                cmbSampleType.SelectedValue = dtPrduct.Rows(x)("SampleType")
                cmbFabricType.SelectedValue = dtPrduct.Rows(x)("FabricTypeID")
                txtNoofPieces.Text = dtPrduct.Rows(x)("NoofPieces")
                txtColor.Text = dtPrduct.Rows(x)("Color")
                txtSize.Text = dtPrduct.Rows(x)("Size")
                txtDeadLine.Text = dtPrduct.Rows(x)("DeadLine")
                txtReceivedDate.Text = dtPrduct.Rows(x)("ReceivedDate")
                txtDispatchedDate.Text = dtPrduct.Rows(x)("DispatchedDate")
                txtNoofPcsDis.Text = dtPrduct.Rows(x)("NoofPcsDis")
                cmbSubmission.SelectedValue = dtPrduct.Rows(x)("Submission")
                cmbStatus.SelectedValue = dtPrduct.Rows(x)("Status")
                txtSampleRemarks.Text = dtPrduct.Rows(x)("SampleRemarks")
                txtSampleLocation.Text = dtPrduct.Rows(x)("SampleLocation")
                txtCommentsReceived.Text = dtPrduct.Rows(x)("CommentsReceivedDate")
            Next
            Session("dtSampleDetail") = dtSampleDetail
        End If
    End Sub
    Sub BindStyle()
        Try
            Dim dtStyle As DataTable = ObjSamplingMaster.BindInqStyle(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text, cmbBrand.SelectedItem.Text, cmbSeason.SelectedValue)
            With cmbStyle
                .DataSource = dtStyle
                .DataTextField = "StyleNo"
                .DataValueField = "InquiryStyleID"
                .DataBind()
                .Items.Insert(0, New ListItem("Select", "0"))
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSupplier()
        Try
            Dim dtSupplier As DataTable = ObjSamplingMaster.getSupplier(cmbStyle.SelectedValue)
            With cmbsupplier
                .DataSource = dtSupplier
                .DataTextField = "VenderName"
                .DataValueField = "VenderLibraryID"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = ObjSamplingMaster.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()
            '---Bind BuyingDept
            cmbBuyingDept.DataSource = ObjSamplingMaster.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
            '---Bind Byuer Name
            'cmbBuyer.DataSource = objEnquiresesEntryaddclass.GetBuyerInfoNo(cmbCustomer.SelectedValue)
            'cmbBuyer.DataTextField = "BuyerName"
            'cmbBuyer.DataValueField = "BuyerName"
            'cmbBuyer.DataBind()
            'UpdatecmbBuyerName.Update()
            ''---Bind Brand 
            'cmbBrand.DataSource = objEnquiresesEntryaddclass.GetBrandInfoNo(cmbCustomer.SelectedValue)
            'cmbBrand.DataTextField = "BrandName"
            'cmbBrand.DataValueField = "BrandName"
            'cmbBrand.DataBind()
            'UpcmbBrand.Update()

            ''---Bind Byuer Name
            cmbBuyerName.DataSource = ObjSamplingMaster.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingMaster.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = ObjSamplingMaster.GetBuyingDeptenq(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            UpcmbBuyingDept.Update()
            ''---Bind Byuer Name
            cmbBuyerName.DataSource = ObjSamplingMaster.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingMaster.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        Try
            ''---Bind Byuer Name
            cmbBuyerName.DataSource = ObjSamplingMaster.GetBuyerInfoNorepNew(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyerName.DataTextField = "BuyerName"
            cmbBuyerName.DataValueField = "BuyerName"
            cmbBuyerName.DataBind()
            UpdatecmbBuyerName.Update()

            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingMaster.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' CmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbBuyerName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyerName.SelectedIndexChanged
        Try
            ''---Bind Brand 
            cmbBrand.DataSource = ObjSamplingMaster.GetBuyerEntryPage(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyerName.SelectedItem.Text)
            cmbBrand.DataTextField = "BrandName"
            cmbBrand.DataValueField = "BrandName"
            cmbBrand.DataBind()
            ' cmbBrand.Items.Insert(0, New ListItem("All", "0"))
            UpcmbBrand.Update()
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub

    Sub BindSeason()
        Try
            Dim dt As DataTable
            dt = ObjSamplingMaster.GetSeason
            cmbSeason.DataSource = dt
            cmbSeason.DataTextField = "season"
            cmbSeason.DataValueField = "SeasonID"
            cmbSeason.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStyle.SelectedIndexChanged
        Try
            Dim dtStyledata As DataTable = ObjSamplingMaster.GetStyledata(cmbStyle.SelectedValue)
            If dtStyledata.Rows.Count > 0 Then
                txtStyleDescription.Text = dtStyledata.Rows(0)("StyleDescription")
                UptxtStyleDescription.Update()
              
                txtDesignName.Text = dtStyledata.Rows(0)("DesignName")
                UpDesignName.Update()
            End If
            If cmbStyle.SelectedValue > 0 Then
                BindSupplier()
                UpSupplier.Update()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddSample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSample.Click
        Try
            If cmbStyle.SelectedValue > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                FirstSession()
                bindGrid()
                BindFabricType()
                btnAddSample.Visible = False
                btnAddMoreSample.Visible = True
                cmbStyle.Enabled = False
                UpStyleNo.Update()
                cmbCustomer.Enabled = False
                UpcmbCustomer.Update()
                cmbBrand.Enabled = False
                UpcmbBrand.Update()
                cmbBuyerName.Enabled = False
                UpdatecmbBuyerName.Update()
                cmbBuyingDept.Enabled = False
                UpcmbBuyingDept.Update()
                cmbSeason.Enabled = False
                UpcmbSeason.Update()
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Style")
            End If
         
        Catch ex As Exception

        End Try
    End Sub
    Private Function bindGrid() As Boolean
        If (Not dtSampleDetail Is Nothing) Then
            If (dtSampleDetail.Rows.Count > 0) Then

                dgSampleDetail.DataSource = dtSampleDetail
                dgSampleDetail.DataBind()
                dgSampleDetail.Visible = True
                UpUpbtndgSampleDetail.Update()
                Return (True)
            Else
                dgSampleDetail.Visible = False
                UpUpbtndgSampleDetail.Update()
                Return (False)
            End If

        End If
        Return (False)


    End Function
    Sub FirstSession()
        If (Not CType(Session("dtSampleDetail"), DataTable) Is Nothing) Then
            dtSampleDetail = Session("dtSampleDetail")
        Else
            dtSampleDetail = New DataTable
            With dtSampleDetail
                .Columns.Add("SamplingDetailID", GetType(Long))

                .Columns.Add("SampleType", GetType(String))
                .Columns.Add("FabricTypeID", GetType(String))
                .Columns.Add("FabricType", GetType(String))
                .Columns.Add("NoofPieces", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("DeadLine", GetType(String))
                .Columns.Add("ReceivedDate", GetType(String))
                .Columns.Add("DispatchedDate", GetType(String))
                .Columns.Add("NoofPcsDis", GetType(String))
                .Columns.Add("Submission", GetType(String))
                .Columns.Add("Status", GetType(String))
                .Columns.Add("SampleRemarks", GetType(String))
                .Columns.Add("SampleLocation", GetType(String))
                .Columns.Add("RejConSample", GetType(String))
                .Columns.Add("CommentsReceivedDate", GetType(String))
                .Columns.Add("SupEstdate", GetType(String))
                .Columns.Add("NoofPcsRecvd", GetType(String))
            End With
        End If
        Dr = dtSampleDetail.NewRow()

        Dr("SamplingDetailID") = 0

        Dr("SampleType") = ""
        Dr("FabricTypeID") = ""
        Dr("FabricType") = ""
        Dr("NoofPieces") = 0
        Dr("Color") = ""
        Dr("Size") = ""
        Dr("DeadLine") = ""
        Dr("ReceivedDate") = ""
        Dr("DispatchedDate") = ""
        Dr("NoofPcsDis") = 0
        Dr("Submission") = ""
        Dr("Status") = ""
        Dr("SampleRemarks") = ""
        Dr("SampleLocation") = ""
        Dr("RejConSample") = ""
        Dr("CommentsReceivedDate") = ""
        Dr("SupEstdate") = ""
        Dr("NoofPcsRecvd") = ""
        dtSampleDetail.Rows.Add(Dr)
        Session("dtSampleDetail") = dtSampleDetail
    End Sub
    Sub BindFabricType()
        Try
            Dim dt As DataTable
            dt = ObjSamplingMaster.GetFabricType(cmbStyle.SelectedValue)
            Dim x As Integer
            For x = 0 To dgSampleDetail.Items.Count - 1
                Dim cmbFabricType As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbFabricType"), DropDownList)
                cmbFabricType.DataSource = dt
                cmbFabricType.DataTextField = "FabricType"
                cmbFabricType.DataValueField = "FabricTypeID"
                cmbFabricType.DataBind()
            Next

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddMoreSample_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMoreSample.Click
        Try
            AddNewRowToGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0
        Dim rowcount As Decimal
        If Session("dtSampleDetail") IsNot Nothing Then
            Dim dtSampleDetail As DataTable = DirectCast(Session("dtSampleDetail"), DataTable)
            Dim dr As DataRow = Nothing
            If dtSampleDetail.Rows.Count > 0 Then
                For i As Integer = 1 To dtSampleDetail.Rows.Count
                    'extract the TextBox values
                    Dim cmbSampleType As DropDownList = CType(dgSampleDetail.Items(rowIndex).FindControl("cmbSampleType"), DropDownList)
                    Dim cmbFabricType As DropDownList = CType(dgSampleDetail.Items(rowIndex).FindControl("cmbFabricType"), DropDownList)
                    Dim txtNoofPieces As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtNoofPieces"), TextBox)
                    Dim txtColor As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtColor"), TextBox)
                    Dim txtSize As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtSize"), TextBox)
                    Dim txtDeadLine As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtDeadLine"), TextBox)
                    Dim txtReceivedDate As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtReceivedDate"), TextBox)
                    Dim txtDispatchedDate As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtDispatchedDate"), TextBox)
                    Dim txtNoofPcsDis As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtNoofPcsDis"), TextBox)
                    Dim cmbSubmission As DropDownList = DirectCast(dgSampleDetail.Items(rowIndex).FindControl("cmbSubmission"), DropDownList)
                    Dim cmbStatus As DropDownList = CType(dgSampleDetail.Items(rowIndex).FindControl("cmbStatus"), DropDownList)
                    Dim txtSampleRemarks As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtSampleRemarks"), TextBox)
                    Dim txtSampleLocation As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtSampleLocation"), TextBox)
                    Dim txtCommentsReceived As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtCommentsReceived"), TextBox)
                    Dim SamplingDetailID As String = dgSampleDetail.Items(rowIndex).Cells(0).Text
                    Dim RejConSample As String = dgSampleDetail.Items(rowIndex).Cells(1).Text
                    Dim txtSupEstdate As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtSupEstdate"), TextBox)
                    Dim txtNoofPcsRecvd As TextBox = CType(dgSampleDetail.Items(rowIndex).FindControl("txtNoofPcsRecvd"), TextBox)
                    rowcount = Val(dtSampleDetail.Rows.Count) + 1
                    dr = dtSampleDetail.NewRow()
                    dr("SamplingDetailID") = SamplingDetailID

                    dr("SampleType") = ""
                    dr("FabricTypeID") = ""
                    dr("FabricType") = ""
                    dr("NoofPieces") = 0
                    dr("Color") = ""
                    dr("Size") = ""
                    dr("DeadLine") = ""
                    dr("ReceivedDate") = ""
                    dr("DispatchedDate") = ""
                    dr("NoofPcsDis") = 0
                    dr("Submission") = ""
                    dr("Status") = ""
                    dr("SampleRemarks") = ""
                    dr("SampleLocation") = ""
                    dr("RejConSample") = RejConSample
                    dr("CommentsReceivedDate") = ""
                    dr("SupEstdate") = ""
                    dr("NoofPcsRecvd") = ""
                    ' dr("OpeningBal") = txtBalanceQty.Text

                    dtSampleDetail.Rows(i - 1)("SampleType") = cmbSampleType.SelectedItem.Text
                    dtSampleDetail.Rows(i - 1)("FabricTypeID") = cmbFabricType.SelectedValue
                    dtSampleDetail.Rows(i - 1)("FabricType") = cmbFabricType.SelectedItem.Text
                    dtSampleDetail.Rows(i - 1)("NoofPieces") = txtNoofPieces.Text
                    dtSampleDetail.Rows(i - 1)("Color") = txtColor.Text
                    dtSampleDetail.Rows(i - 1)("Size") = txtSize.Text
                    dtSampleDetail.Rows(i - 1)("DeadLine") = txtDeadLine.Text
                    dtSampleDetail.Rows(i - 1)("ReceivedDate") = txtReceivedDate.Text
                    dtSampleDetail.Rows(i - 1)("DispatchedDate") = txtDispatchedDate.Text
                    dtSampleDetail.Rows(i - 1)("NoofPcsDis") = txtNoofPcsDis.Text
                    dtSampleDetail.Rows(i - 1)("Submission") = cmbSubmission.SelectedValue
                    dtSampleDetail.Rows(i - 1)("Status") = cmbStatus.SelectedValue
                    dtSampleDetail.Rows(i - 1)("SampleRemarks") = txtSampleRemarks.Text
                    dtSampleDetail.Rows(i - 1)("SampleLocation") = txtSampleLocation.Text
                    dtSampleDetail.Rows(i - 1)("CommentsReceivedDate") = txtCommentsReceived.Text
                    dtSampleDetail.Rows(i - 1)("SupEstdate") = txtSupEstdate.Text
                    dtSampleDetail.Rows(i - 1)("NoofPcsRecvd") = txtNoofPcsRecvd.Text
                    rowIndex += 1
                Next

                dtSampleDetail.Rows.Add(dr)
                dtSampleDetail.Rows(rowIndex)("SamplingDetailID") = 0
                Session("dtSampleDetail") = dtSampleDetail

                dgSampleDetail.DataSource = dtSampleDetail
                dgSampleDetail.DataBind()
                UpUpbtndgSampleDetail.Update()
                dgSampleDetail.Visible = True

            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()

        UpUpbtndgSampleDetail.Update()
    End Sub
    Private Sub SetPreviousData()

        BindFabricType()

        Dim rowIndex As Integer = 0
        If Session("dtSampleDetail") IsNot Nothing Then
            Dim dtSampleDetail As DataTable = DirectCast(Session("dtSampleDetail"), DataTable)
            If dtSampleDetail.Rows.Count > 0 Then
                For i As Integer = 0 To dtSampleDetail.Rows.Count - 1
                    Dim cmbSampleType As DropDownList = CType(dgSampleDetail.Items(i).FindControl("cmbSampleType"), DropDownList)
                    Dim cmbFabricType As DropDownList = CType(dgSampleDetail.Items(i).FindControl("cmbFabricType"), DropDownList)
                    Dim txtNoofPieces As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtNoofPieces"), TextBox)
                    Dim txtColor As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtColor"), TextBox)
                    Dim txtSize As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtSize"), TextBox)
                    Dim txtDeadLine As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtDeadLine"), TextBox)
                    Dim txtReceivedDate As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtReceivedDate"), TextBox)
                    Dim txtDispatchedDate As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtDispatchedDate"), TextBox)
                    Dim txtNoofPcsDis As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtNoofPcsDis"), TextBox)
                    Dim cmbSubmission As DropDownList = DirectCast(dgSampleDetail.Items(i).FindControl("cmbSubmission"), DropDownList)
                    Dim cmbStatus As DropDownList = CType(dgSampleDetail.Items(i).FindControl("cmbStatus"), DropDownList)
                    Dim txtSampleRemarks As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtSampleRemarks"), TextBox)
                    Dim txtSampleLocation As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtSampleLocation"), TextBox)
                    Dim txtCommentsReceived As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtCommentsReceived"), TextBox)
                    Dim txtSupEstdate As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtSupEstdate"), TextBox)
                    Dim txtNoofPcsRecvd As TextBox = CType(dgSampleDetail.Items(i).FindControl("txtNoofPcsRecvd"), TextBox)

                    cmbSampleType.SelectedValue = dtSampleDetail.Rows(i)("SampleType")
                    cmbFabricType.SelectedValue = dtSampleDetail.Rows(i)("FabricTypeID")
                    txtNoofPieces.Text = dtSampleDetail.Rows(i)("NoofPieces")
                    txtColor.Text = dtSampleDetail.Rows(i)("Color")
                    txtSize.Text = dtSampleDetail.Rows(i)("Size")
                    txtDeadLine.Text = dtSampleDetail.Rows(i)("DeadLine")
                    txtReceivedDate.Text = dtSampleDetail.Rows(i)("ReceivedDate")
                    txtDispatchedDate.Text = dtSampleDetail.Rows(i)("DispatchedDate")
                    txtNoofPcsDis.Text = dtSampleDetail.Rows(i)("NoofPcsDis")
                    cmbSubmission.SelectedValue = dtSampleDetail.Rows(i)("Submission")
                    cmbStatus.SelectedValue = dtSampleDetail.Rows(i)("Status")
                    txtSampleRemarks.Text = dtSampleDetail.Rows(i)("SampleRemarks")
                    txtSampleLocation.Text = dtSampleDetail.Rows(i)("SampleLocation")
                    txtCommentsReceived.Text = dtSampleDetail.Rows(i)("CommentsReceivedDate")
                    txtSupEstdate.Text = dtSampleDetail.Rows(i)("SupEstdate")
                    txtNoofPcsRecvd.Text = dtSampleDetail.Rows(i)("NoofPcsRecvd")

                    rowIndex += 1
                Next

            End If
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If dgSampleDetail.Items.Count = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("At least add one sample")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveData()
                Response.Redirect("ConfirmedOrderSamplingView.aspx")
            End If


        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With ObjSamplingMaster
            If SamplingMasterID > 0 Then
                .SamplingMasterID = SamplingMasterID
            Else
                .SamplingMasterID = 0
            End If
            .CustomerID = cmbCustomer.SelectedValue
            .InquiryStyleID = cmbStyle.SelectedValue
            .SeasonID = cmbSeason.SelectedValue
            .SupplierID = cmbsupplier.SelectedValue
            .CreationDate = Date.Now
            .BuyingDept = cmbBuyingDept.SelectedItem.Text
            .Buyer = cmbBuyerName.SelectedItem.Text
            .Brand = cmbBrand.SelectedItem.Text
            .DesignName = txtDesignName.Text
            .StyleDescription = txtStyleDescription.Text
            .InquiryType = cmbSample.SelectedItem.Text
            .SamplePageType = 4
            .UserID = CLng(Session("UserID"))
            .StyleNo = cmbStyle.SelectedItem.Text
            .SaveSampleMaster()
        End With
        Dim x As Integer = 0
        For x = 0 To dgSampleDetail.Items.Count - 1
            Dim cmbSampleType As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbSampleType"), DropDownList)
            Dim cmbFabricType As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbFabricType"), DropDownList)
            Dim txtNoofPieces As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtNoofPieces"), TextBox)
            Dim txtColor As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtColor"), TextBox)
            Dim txtSize As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSize"), TextBox)
            Dim txtDeadLine As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtDeadLine"), TextBox)
            Dim txtReceivedDate As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtReceivedDate"), TextBox)
            Dim txtDispatchedDate As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtDispatchedDate"), TextBox)
            Dim txtNoofPcsDis As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtNoofPcsDis"), TextBox)
            Dim cmbSubmission As DropDownList = DirectCast(dgSampleDetail.Items(x).FindControl("cmbSubmission"), DropDownList)
            Dim cmbStatus As DropDownList = CType(dgSampleDetail.Items(x).FindControl("cmbStatus"), DropDownList)
            Dim txtSampleRemarks As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSampleRemarks"), TextBox)
            Dim txtSampleLocation As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSampleLocation"), TextBox)
            Dim ChkUpdate As CheckBox = CType(dgSampleDetail.Items(x).FindControl("ChkUpdate"), CheckBox)
            Dim txtCommentsReceived As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtCommentsReceived"), TextBox)
            Dim txtSupEstdate As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtSupEstdate"), TextBox)
            Dim txtNoofPcsRecvd As TextBox = CType(dgSampleDetail.Items(x).FindControl("txtNoofPcsRecvd"), TextBox)

            With ObjSamplingDetail
                .SamplingDetailID = dgSampleDetail.Items(x).Cells(0).Text
                If SamplingMasterID > 0 Then
                    .SamplingMasterID = SamplingMasterID
                Else
                    .SamplingMasterID = ObjSamplingMaster.GetId
                End If
                .FabrictypeID = cmbFabricType.SelectedValue
                If txtNoofPieces.Text = "" Then
                    .NoofPieces = 0
                Else
                    .NoofPieces = txtNoofPieces.Text
                End If
                If txtNoofPcsDis.Text = "" Then
                    .NoofPcsDis = 0
                Else
                    .NoofPcsDis = txtNoofPcsDis.Text
                End If
                .SampleType = cmbSampleType.SelectedItem.Text
                .Color = txtColor.Text
                .Size = txtSize.Text
                .Deadline = txtDeadLine.Text
                .ReceivedDate = txtReceivedDate.Text
                .DispatchedDate = txtDispatchedDate.Text
                .Submission = cmbSubmission.SelectedItem.Text
                .Status = cmbStatus.SelectedItem.Text
                .SampleRemarks = txtSampleRemarks.Text
                .SampleLocation = txtSampleLocation.Text
                .RejConSample = ""
                .CommentsReceivedDate = txtCommentsReceived.Text
                .SupEstdate = txtSupEstdate.Text
                If txtNoofPcsRecvd.Text = "" Then
                    .NoofPcsRecvd = 0
                Else
                    .NoofPcsRecvd = txtNoofPcsRecvd.Text
                End If

                .SaveSamplingDetail()
            End With
            If SamplingMasterID > 0 Then
                If ChkUpdate.Checked = True Then
                    With objSamplingHistory
                        .SamplingHistoryID = 0
                        If dgSampleDetail.Items(x).Cells(0).Text > 0 Then
                            .SamplingDetailID = dgSampleDetail.Items(x).Cells(0).Text
                        Else
                            .SamplingDetailID = ObjSamplingDetail.GetId
                        End If

                        If SamplingMasterID > 0 Then
                            .SamplingMasterID = SamplingMasterID
                        Else
                            .SamplingMasterID = ObjSamplingMaster.GetId
                        End If
                        .FabrictypeID = cmbFabricType.SelectedValue
                        If txtNoofPieces.Text = "" Then
                            .NoofPieces = 0
                        Else
                            .NoofPieces = txtNoofPieces.Text
                        End If
                        If txtNoofPcsDis.Text = "" Then
                            .NoofPcsDis = 0
                        Else
                            .NoofPcsDis = txtNoofPcsDis.Text
                        End If
                        .SampleType = cmbSampleType.SelectedItem.Text
                        .Color = txtColor.Text
                        .Size = txtSize.Text
                        .Deadline = txtDeadLine.Text
                        .ReceivedDate = txtReceivedDate.Text
                        .DispatchedDate = txtDispatchedDate.Text
                        .Submission = cmbSubmission.SelectedItem.Text
                        .Status = cmbStatus.SelectedItem.Text
                        .SampleRemarks = txtSampleRemarks.Text
                        .SampleLocation = txtSampleLocation.Text
                        .RejConSample = ""
                        .CommentsReceivedDate = txtCommentsReceived.Text
                        .SupEstdate = txtSupEstdate.Text
                        If txtNoofPcsRecvd.Text = "" Then
                            .NoofPcsRecvd = 0
                        Else
                            .NoofPcsRecvd = txtNoofPcsRecvd.Text
                        End If
                        .SaveSamplingHistory()
                    End With

                End If
            Else
                With objSamplingHistory
                    .SamplingHistoryID = 0
                    If dgSampleDetail.Items(x).Cells(0).Text > 0 Then
                        .SamplingDetailID = dgSampleDetail.Items(x).Cells(0).Text
                    Else
                        .SamplingDetailID = ObjSamplingDetail.GetId
                    End If

                    If SamplingMasterID > 0 Then
                        .SamplingMasterID = SamplingMasterID
                    Else
                        .SamplingMasterID = ObjSamplingMaster.GetId
                    End If
                    .FabrictypeID = cmbFabricType.SelectedValue
                    If txtNoofPieces.Text = "" Then
                        .NoofPieces = 0
                    Else
                        .NoofPieces = txtNoofPieces.Text
                    End If
                    If txtNoofPcsDis.Text = "" Then
                        .NoofPcsDis = 0
                    Else
                        .NoofPcsDis = txtNoofPcsDis.Text
                    End If
                    .SampleType = cmbSampleType.SelectedItem.Text
                    .Color = txtColor.Text
                    .Size = txtSize.Text
                    .Deadline = txtDeadLine.Text
                    .ReceivedDate = txtReceivedDate.Text
                    .DispatchedDate = txtDispatchedDate.Text
                    .Submission = cmbSubmission.SelectedItem.Text
                    .Status = cmbStatus.SelectedItem.Text
                    .SampleRemarks = txtSampleRemarks.Text
                    .SampleLocation = txtSampleLocation.Text
                    .RejConSample = ""
                    .CommentsReceivedDate = txtCommentsReceived.Text
                    .SupEstdate = txtSupEstdate.Text
                    If txtNoofPcsRecvd.Text = "" Then
                        .NoofPcsRecvd = 0
                    Else
                        .NoofPcsRecvd = txtNoofPcsRecvd.Text
                    End If
                    .SaveSamplingHistory()
                End With

            End If
        Next
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("ConfirmedOrderSamplingView.aspx")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        Try
            BindStyle()
            UpStyleNo.Update()
        Catch ex As Exception

        End Try
    End Sub
End Class