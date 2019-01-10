Imports Integra.EuroCentra
Imports System.Data
Imports Telerik.Web.UI.Upload
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Data.DataTable
Imports System.IO
Imports Telerik.Web.UI.Barcode
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net
Imports System.Net.Mail
Public Class MandEentry
    Inherits System.Web.UI.Page
    Dim objMAEMst As New MAEMst    
    Dim dtDetail As DataTable
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim MAEID As Long
    Dim Dr As DataRow
    Dim userid As Integer
    Dim objCustomerAttachment As New CustomerAttachment
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MAEID = Request.QueryString("MAEID")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            ClearControls()
            BindAttachmentList()
            BindDepartment()
            BindUnit()
            If MAEID > 0 Then
                Edit()
                If MAEID > 0 Then
                    BindCertificateview(MAEID)
                    pnlcertificate.Visible = True
                    btnSave.Text = "Update"
                Else
                    pnlcertificate.Visible = False
                    btnSave.Text = "Save"
                End If
            End If
            PageHeader("Fixed Assets / Machine & Equipments / Declaration Form")
        End If
    End Sub
    Sub BindDepartment()
        Try
            Dim dt As DataTable
            dt = objMAEMst.BindDept
            CMBDepartment.DataSource = dt
            CMBDepartment.DataTextField = "DeptDatabaseName"
            CMBDepartment.DataValueField = "DeptDatabaseID"
            CMBDepartment.DataBind()
            CMBDepartment.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindUnit()
        Try
            Dim dtType As DataTable
            dtType = objMAEMst.BindUnit
            cmbUnit.DataSource = dtType
            cmbUnit.DataTextField = "Unit"
            cmbUnit.DataValueField = "UnitID"
            cmbUnit.DataBind()
            cmbUnit.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindAttachmentList()
        Try
            Dim dtMarchandizer As DataTable = objMAEMst.getCustomerAttachmentList
            cmbCertificate.DataSource = dtMarchandizer
            cmbCertificate.DataTextField = "AttachmentName"
            cmbCertificate.DataValueField = "AttachmentListID"
            cmbCertificate.DataBind()
            cmbCertificate.Items.Insert(0, New RadComboBoxItem("Select", 0))
        Catch ex As Exception
        End Try
    End Sub
    Sub Edit()
        Try
            Dim dt As DataTable = objMAEMst.BindMAEPageEdit(MAEID)
            txtTagNo.Text = dt.Rows(0)("TagNo")
            txtName.Text = dt.Rows(0)("Name")
            txtDescription.Text = dt.Rows(0)("MAEDescription")
            txtModel.Text = dt.Rows(0)("Model")
            txtBrands.Text = dt.Rows(0)("Brand")
            txtPurchaseDate.SelectedDate = dt.Rows(0)("PurchasedDate")
            txtPurchasedPricee.Text = dt.Rows(0)("PurchasedPrice")
            txtDepreciationPeriodd.Text = dt.Rows(0)("DepreciationPeriod")
            txtHealthRate.Text = dt.Rows(0)("HealthRate")
            txtOperationalCostt.Text = dt.Rows(0)("OperationalCost")
            txtKWHConsumptionn.Text = dt.Rows(0)("KWHConsumption")
            txtWarrantyClaimable.Text = dt.Rows(0)("WarrantyClaimable")
            txtDimension.Text = dt.Rows(0)("Dimension")
            txtGrossWt.Text = dt.Rows(0)("GrossWait")
            CMBDepartment.SelectedValue = dt.Rows(0)("DeptDatabaseID")
            cmbUnit.SelectedValue = dt.Rows(0)("UnitID")
        Catch ex As Exception
        End Try
    End Sub
    Sub Save()
        If txtTagNo.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Type Tag No...")
        ElseIf txtName.Text = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Type Name...")
        ElseIf txtPurchaseDate.SelectedDate.ToString() = "" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Type Purchased Date...")
        ElseIf cmbUnit.SelectedItem.Text = "Select" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Unit...")
        ElseIf CMBDepartment.SelectedItem.Text = "Select" Then
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Please Select Department...")
        Else
            DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
            With objMAEMst
                If MAEID > 0 Then
                    .MAEID = MAEID
                Else
                    .MAEID = 0
                End If
                .UserID = userid
                .CreationDate = Date.Now
                .TagNo = txtTagNo.Text
                .Name = txtName.Text
                .MAEDescription = txtDescription.Text
                .Model = txtModel.Text
                .Brand = txtBrands.Text
                .PurchasedDate = txtPurchaseDate.SelectedDate.ToString()
                .PurchasedPrice = txtPurchasedPricee.Text
                .DepreciationPeriod = txtDepreciationPeriodd.Text
                .HealthRate = txtHealthRate.Text
                .OperationalCost = txtOperationalCostt.Text
                .KWHConsumption = txtKWHConsumptionn.Text
                .WarrantyClaimable = txtWarrantyClaimable.Text
                .Dimension = txtDimension.Text
                .GrossWait = txtGrossWt.Text
                .DeptDatabaseID = CMBDepartment.SelectedValue
                .UnitID = cmbUnit.SelectedValue
                .Save()
                Response.Redirect("MandEentryView.aspx")
            End With
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Save()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("MandEentryView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Sub ClearControls()
        txtPurchasedPricee.Text = 0
        txtDepreciationPeriodd.Text = 0
        txtHealthRate.Text = 0
        txtOperationalCostt.Text = 0
        txtKWHConsumptionn.Text = 0
        txtGrossWt.Text = 0
    End Sub
    Protected Sub btnAddCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddCertificate.Click
        Try
            UserID = CLng(Session("UserId"))
            If MAEID > 0 Then
                MAEID = MAEID
                If FileUpload1.FileName = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Not Save")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Dim dtExist As DataTable
                    dtExist = objMAEMst.getDataa(MAEID, cmbCertificate.SelectedValue)
                    If dtExist.Rows.Count > 0 Then
                        With objCustomerAttachment
                            .AttachmentID = dtExist.Rows(0)("MEID")
                            .AttachmentFile = SaveImginByte()
                            .AttachmentListID = cmbCertificate.SelectedValue
                            .Description = txtDescriptionAttachment.Text
                            .MEID = MAEID
                            .SaveCustomerAttachment()
                        End With
                    Else
                        With objCustomerAttachment
                            .AttachmentID = 0
                            .AttachmentListID = cmbCertificate.SelectedValue
                            .MEID = MAEID
                            .AttachmentFile = SaveImginByte()
                            .Description = txtDescriptionAttachment.Text
                            .CreationDate = Date.Now
                            .UserID = userid
                            .SaveCustomerAttachment()
                        End With
                    End If
                    BindCertificateview(MAEID)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCertificateview(ByVal MAEID As Long)
        Try
            Dim dt As DataTable = objCustomerAttachment.GetviewCertfcte(MAEID)
            If dt.Rows.Count > 0 Then
                dgCertificate.DataSource = dt
                dgCertificate.RecordCount = dt.Rows.Count
                dgCertificate.DataBind()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function SaveImginByte() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If FileUpload1.HasFile AndAlso Not FileUpload1.PostedFile Is Nothing Then
                Dim File As HttpPostedFile = FileUpload1.PostedFile
                imgByte = New Byte(File.ContentLength - 1) {}
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgCertificate_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCertificate.ItemCommand
        Select Case e.CommandName
            Case Is = "ViewCertificate"
                Dim AttachmentID As Integer = dgCertificate.Items(e.Item.ItemIndex).Cells(1).Text
                Dim MEID As Integer = dgCertificate.Items(e.Item.ItemIndex).Cells(2).Text
                Response.Write("<script> window.open('CertificatePopup.aspx?MEID=" & MEID & "&AttachmentID=" & AttachmentID & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
            Case Is = "Remove"
                Dim AttachmentID As Long = dgCertificate.Items(e.Item.ItemIndex).Cells(0).Text
                objCustomerAttachment.deleteCertficate(AttachmentID)
                BindCertificateview(MAEID)
        End Select
    End Sub
End Class