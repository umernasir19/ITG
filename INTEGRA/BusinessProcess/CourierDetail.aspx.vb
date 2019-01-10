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
Imports System.Web.UI.WebControls
Public Class CourierDetail
    Inherits System.Web.UI.Page
    Dim ObjDPCourierMst As New DPCourierMst
    Dim ObjDPCourierDtl As New DPCourierDtl
    Dim dtCourier As DataTable
    Dim Dr As DataRow
    Dim lDPCourierMstId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPCourierMstId = Request.QueryString("DPCourierMstId")
        If Not Page.IsPostBack Then
            Session("dtCourier") = Nothing
            Session("FileNameDPRN") = Nothing
            Session("ImageByteP") = Nothing

            If lDPCourierMstId > 0 Then
                Edit()
                btnSave.Text = "Update"
                PnlRemarks.Visible = True
                lnkFIlePicture.Visible = True
                dgCourier.Columns(7).Visible = True
                btnAddMore.Visible = True
                btnAdd.Visible = False
            Else
                btnSave.Text = "Save"
                btnAddMore.Visible = False
                btnAdd.Visible = True
            End If

            txtExRegNo.Text = "W088716"
            txtNtnNo.Text = "14-06-0676758"
            BindCustomer()
            BindCurrency()
            VoucherNoGenerateOnLoad()
        End If
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = ObjDPCourierMst.GetEdit(lDPCourierMstId)

        If dt.Rows.Count > 0 Then
            txtDatee.SelectedDate = dt.Rows(0)("CourDate")
            txtExRegNo.Text = dt.Rows(0)("ExpRegNo")
            txtNtnNo.Text = dt.Rows(0)("NtnNo")
            txtInvNo.Text = dt.Rows(0)("InvNo")
            txtAccountNo.Text = dt.Rows(0)("AccountNo")
            txtInvOf.Text = dt.Rows(0)("InvOf")
            txtShippedPer.Text = dt.Rows(0)("ShippedPer")
            txtFrmKhi.Text = dt.Rows(0)("FrmKhiTo")
            txtWeight.Text = dt.Rows(0)("Weight")
            txtCourAirBillNo.Text = dt.Rows(0)("CourAirBillNo")
            BindCustomer()
            cmbBuyerName.SelectedValue = dt.Rows(0)("BuyerId")
            txtAddress.Text = dt.Rows(0)("Address")
            txtDcdNo.Text = dt.Rows(0)("DCDNo")
            If dt.Rows(0)("FileName") = "" Then
                pictureNotAvialable()
            Else
                Session("FileNameDPRN") = dt.Rows(0)("FileName")
                Session("ImageByteP") = dt.Rows(0)("Image")
            End If
            txtBuyerComment.Text = dt.Rows(0)("Remarks")
        End If
        dtCourier = New DataTable
        With dtCourier
            .Columns.Add("DPCourierDtlId", GetType(Long))
            .Columns.Add("NoOfPackage", GetType(String))
            .Columns.Add("Qty", GetType(Decimal))
            .Columns.Add("Rate", GetType(Decimal))
            .Columns.Add("QtyType", GetType(String))
            .Columns.Add("Desc", GetType(String))
            .Columns.Add("DeliveryDate", GetType(String))
            .Columns.Add("ConvergeRate", GetType(Decimal))
            .Columns.Add("Amount", GetType(Decimal))
            .Columns.Add("CurrencyID", GetType(Long))
        End With
        For x = 0 To dt.Rows.Count - 1
            Dr = dtCourier.NewRow()

            Dr = dtCourier.NewRow()
            Dr("DPCourierDtlId") = dt.Rows(x)("DPCourierDtlId")
            Dr("NoOfPackage") = dt.Rows(x)("NoOfPackage")
            Dr("Qty") = dt.Rows(x)("Qty")
            Dr("Rate") = dt.Rows(x)("Rate")
            Dr("QtyType") = dt.Rows(x)("QtyType")
            Dr("Desc") = dt.Rows(x)("Desc")
            Dr("DeliveryDate") = dt.Rows(x)("DeliveryDate")
            Dr("ConvergeRate") = dt.Rows(x)("ConvergeRate")
            Dr("Amount") = dt.Rows(x)("Amount")
            Dr("CurrencyID") = dt.Rows(x)("CurrencyID")
            dtCourier.Rows.Add(Dr)
        Next
        Session("dtCourier") = dtCourier
        BindGrid()
  

        Dim y As Integer
        For y = 0 To dgCourier.Items.Count - 1
            Dim DeliveryDate As RadDatePicker = CType(dgCourier.Items(y).FindControl("txtDeliveryDate"), RadDatePicker)


            If dt.Rows(y)("DeliveryDate") = "" Then



            Else
                Dim DDate As Date = dt.Rows(y)("DeliveryDate")
                DeliveryDate.SelectedDate = DDate
            End If


        Next

    End Sub
    Protected Sub lnkFIlePicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFIlePicture.Click
        Try
            '  ScriptManager.RegisterClientScriptBlock(Me.UpdatePanel11, Me.UpdatePanel11.GetType(), "New ClientScript", "window.open('SRQTechPackUploadShow.aspx?FileName=" & Session("FileNameTP") & "&Byte=" & Session("ImageByteTP") & "', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
            'Response.Write("<script> window.open('SRQTechPackUploadShow.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")

            ScriptManager.RegisterClientScriptBlock(Me.UpPic, Me.UpPic.GetType(), "New ClientScript", "window.open('DPCourierPicturePopup.aspx', 'newwindow', 'left=12, top=60, height=600, width=980, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no');", True)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        Try
            Session("FileNameDPRN") = Nothing
            Session("ImageByteP") = Nothing
            Dim fileExt As String = System.IO.Path.GetExtension(FileUpload2.FileName)
            If FileUpload2.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                pictureNotAvialable()
                lnkFIlePicture.Visible = True
            ElseIf fileExt = ".jpg" Or fileExt = ".pdf" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileNameTP As String = ""
                Dim fs As System.IO.Stream = FileUpload2.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytesTP As Byte() = br.ReadBytes(CType(fs.Length, Integer))

                FileNameTP = FileUpload2.FileName
                Session("FileNameDPRN") = FileNameTP
                Session("ImageByteP") = bytesTP
                lnkFIlePicture.Visible = True
                ' btnUploadNew.Visible = False

            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Only jpg or Pdf file allow to upload")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub pictureNotAvialable()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
       Session("ImageByteP") = GetFileContent(path)
        Session("FileNameDPRN") = "no-image.jpg"

    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Sub BindCustomer()
        Dim dtsupplier As DataTable
        dtsupplier = ObjDPCourierMst.GetCustomer
        cmbBuyerName.DataSource = dtsupplier
        cmbBuyerName.DataTextField = "CustomerName"
        cmbBuyerName.DataValueField = "CustomerID"
        cmbBuyerName.DataBind()

        Dim dtAddress As DataTable
        dtAddress = ObjDPCourierMst.GetAddress(cmbBuyerName.SelectedItem.Text)
        txtAddress.Text = dtAddress.Rows(0)("Address1") & " " & dtAddress.Rows(0)("Address2")


    End Sub
    Protected Sub cmbBuyerName_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbBuyerName.SelectedIndexChanged
        Try
            Dim dtAddress As DataTable
            dtAddress = ObjDPCourierMst.GetAddress(cmbBuyerName.SelectedItem.Text)
            txtAddress.Text = dtAddress.Rows(0)("Address1") & " " & dtAddress.Rows(0)("Address2")
        Catch ex As Exception

        End Try
    End Sub
    Sub BindCurrency()
        Dim dt As DataTable
        dt = ObjDPCourierMst.GetCurrency
        cmbCurrency.DataSource = dt
        cmbCurrency.DataTextField = "CurrencyName"
        cmbCurrency.DataValueField = "CurrencyID"
        cmbCurrency.DataBind()
    End Sub
    Sub VoucherNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            ' Dim year As String = Voucherdate.Year
            ' Dim yearv As String = year.Substring(2, 2)
            Dim LastVoucherNo As String = ObjDPCourierMst.GetLastNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0001"
            Else
                ' PreviousMonth = LastVoucherNo.Substring(7, 2)
                LastCode = LastVoucherNo.Substring(4, 4)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "" & Val(LastCode + 1)
                    Else
                        LastCode = "0" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "DCD" & "-" & LastCode
            txtDcdNo.Text = VoucherNo
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If txtDatee.ValidationDate = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
            ElseIf txtExRegNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Export Reg.No")
            ElseIf txtAccountNo.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Account No.")
            ElseIf txtWeight.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Weight")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                SaveData()
                Response.Redirect("DPCourierView.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            
            If txtPackage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill No.Of Packages")
            ElseIf txtQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill QTy")
            ElseIf txtQtyType.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill QTy.Type")
            ElseIf txtRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Rate")
            ElseIf txtConvergRate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Converging Rate")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAddMore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddMore.Click
        Try

           AddNewRowToGrid()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0

        If Session("dtCourier") IsNot Nothing Then
            Dim dtCourier As DataTable = DirectCast(Session("dtCourier"), DataTable)
            Dim drCurrentRow As DataRow = Nothing
            If dtCourier.Rows.Count > 0 Then
                For i As Integer = 1 To dtCourier.Rows.Count
                    Dim item As GridDataItem = DirectCast(dgCourier.MasterTableView.Items(rowIndex), GridDataItem)
                    Dim DeliveryDate As RadDatePicker = CType(dgCourier.Items(rowIndex).FindControl("txtDeliveryDate"), RadDatePicker)
                    Dim DPCourierDtlId As String = item("DPCourierDtlId").Text

                        drCurrentRow = dtCourier.NewRow()
                        If lDPCourierMstId > 0 Then
                            drCurrentRow("DPCourierDtlId") = 0
                        Else
                            drCurrentRow("DPCourierDtlId") = DPCourierDtlId
                    End If

                    drCurrentRow("CurrencyID") = cmbCurrency.SelectedValue
                    drCurrentRow("NoOfPackage") = txtPackage.Text
                    drCurrentRow("Qty") = txtQty.Text

                    If txtQtyType.Text = "" Then
                        drCurrentRow("QtyType") = "N/A"
                    Else
                        drCurrentRow("QtyType") = txtQtyType.Text
                    End If

                    If txtDesc.Text = "" Then
                        drCurrentRow("Desc") = 0
                    Else
                        drCurrentRow("Desc") = txtDesc.Text
                    End If

                    drCurrentRow("DeliveryDate") = " "


                    drCurrentRow("ConvergeRate") = txtConvergRate.Text
                    drCurrentRow("Amount") = txtAmount.Text
                    drCurrentRow("Rate") = txtRate.Text
                        dtCourier.Rows(i - 1)("DeliveryDate") = DeliveryDate.SelectedDate
                        rowIndex += 1
                Next
                dtCourier.Rows.Add(drCurrentRow)
                Session("dtCourier") = dtCourier

                dgCourier.DataSource = dtCourier
                dgCourier.DataBind()
            End If
        Else
            Response.Write("ViewState is null")
        End If

        'Set Previous Data on Postbacks
        SetPreviousData()
    End Sub
    Private Sub SetPreviousData()
      
        Dim rowIndex As Integer = 0
        If Session("dtCourier") IsNot Nothing Then
            Dim dt As DataTable = DirectCast(Session("dtCourier"), DataTable)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim item As GridDataItem = DirectCast(dgCourier.MasterTableView.Items(rowIndex), GridDataItem)
                    Dim DeliveryDate As RadDatePicker = DirectCast(dgCourier.Items(rowIndex).FindControl("txtDeliveryDate"), RadDatePicker)
                    Dim DPCourierDtlId As String = item("DPCourierDtlId").Text




                    If dt.Rows(rowIndex)("DeliveryDate").ToString = "" Then
                    Else
                        Dim DDate As Date = dt.Rows(i)("DeliveryDate")
                        DeliveryDate.SelectedDate = DDate
                    End If

                    rowIndex += 1
                Next

            End If
        End If
    End Sub
    Sub SaveSession()

        If (Not CType(Session("dtCourier"), DataTable) Is Nothing) Then
            dtCourier = Session("dtCourier")
        Else
            dtCourier = New DataTable
            With dtCourier
                .Columns.Add("DPCourierDtlId", GetType(Long))
                .Columns.Add("CurrencyID", GetType(Long))
                .Columns.Add("NoOfPackage", GetType(String))
                .Columns.Add("Qty", GetType(Decimal))
                .Columns.Add("QtyType", GetType(String))
                .Columns.Add("Desc", GetType(String))
                .Columns.Add("DeliveryDate", GetType(String))
                .Columns.Add("ConvergeRate", GetType(Decimal))
                .Columns.Add("Amount", GetType(Decimal))
                .Columns.Add("Rate", GetType(Decimal))


            End With
        End If
        Dr = dtCourier.NewRow()

        Dr("DPCourierDtlId") = 0
        Dr("CurrencyID") = cmbCurrency.SelectedValue
        Dr("NoOfPackage") = txtPackage.Text
        Dr("Qty") = txtQty.Text

        If txtQtyType.Text = "" Then
            Dr("QtyType") = "N/A"
        Else
            Dr("QtyType") = txtQtyType.Text
        End If

        If txtDesc.Text = "" Then
            Dr("Desc") = 0
        Else
            Dr("Desc") = txtDesc.Text
        End If

        Dr("DeliveryDate") = " "
     

        Dr("ConvergeRate") = txtConvergRate.Text
        Dr("Amount") = txtAmount.Text
        Dr("Rate") = txtRate.Text

        dtCourier.Rows.Add(Dr)

        Session("dtCourier") = dtCourier
        BindGrid()
        clear()
    End Sub
    Sub clear()
        txtPackage.Text = ""
        txtQty.Text = ""
        txtRate.Text = ""
        txtQtyType.Text = ""
        txtConvergRate.Text = ""
        txtDesc.Text = ""
    End Sub

    Private Sub BindGrid()
        Try
            Dim objDatatble As DataTable
            objDatatble = Session("dtCourier")
            If objDatatble.Rows.Count > 0 Then
                dgCourier.Visible = True
                dgCourier.VirtualItemCount = objDatatble.Rows.Count
                dgCourier.DataSource = objDatatble
                dgCourier.DataBind()


               


            Else
                dgCourier.Visible = False
            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtRate_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtRate.TextChanged
        Try
            txtAmount.Text = Val(txtQty.Text) * Val(txtRate.Text)
            'txtAmount.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Sub SaveData()
        With ObjDPCourierMst
            If lDPCourierMstId > 0 Then
                .DPCourierMstId = lDPCourierMstId
            Else
                .DPCourierMstId = 0
            End If

            .CourDate = txtDatee.SelectedDate
            .ExpRegNo = txtExRegNo.Text.ToUpper
            .NtnNo = txtNtnNo.Text.ToUpper
            .InvNo = txtInvNo.Text.ToUpper
            .AccountNo = txtAccountNo.Text.ToUpper
            .InvOf = txtInvOf.Text.ToUpper
            .ShippedPer = txtShippedPer.Text.ToUpper
            .FrmKhiTo = txtFrmKhi.Text.ToUpper
            .Weight = txtWeight.Text.ToUpper
            .CourAirBillNo = txtCourAirBillNo.Text.ToUpper
            .BuyerId = cmbBuyerName.SelectedValue
            .Address = txtAddress.Text.ToUpper
            .DCDNo = txtDcdNo.Text.ToUpper
            If Session("FileNameDPRN") = "" Then
                pictureNotAvialable()
                .FileName = Session("FileNameDPRN")
                .Image = Session("ImageByteP")
            Else
                .FileName = Session("FileNameDPRN")
                .Image = Session("ImageByteP")
            End If
            If txtBuyerComment.Text = "" Then
                .Remarks = " "
            Else
                .Remarks = txtBuyerComment.Text
            End If

            .Save()
        End With
        Dim x As Integer
        For x = 0 To dgCourier.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgCourier.MasterTableView.Items(x), GridDataItem)
            Dim DeliveryDate As RadDatePicker = CType(dgCourier.Items(x).FindControl("txtDeliveryDate"), RadDatePicker)
            With ObjDPCourierDtl
                .DPCourierDtlId = item("DPCourierDtlId").Text
                If lDPCourierMstId > 0 Then
                    .DPCourierMstId = lDPCourierMstId
                Else
                    .DPCourierMstId = ObjDPCourierMst.GetID
                End If
                .NoOfPackage = item("NoOfPackage").Text
                .Qty = item("Qty").Text
                .Rate = item("Rate").Text
                .QtyType = item("QtyType").Text
                .Desc = item("Desc").Text
                If DeliveryDate.ValidationDate = "" Then
                    .DeliveryDate = ""
                Else
                    .DeliveryDate = DeliveryDate.SelectedDate
                End If

                .Qty = item("Qty").Text
                .ConvergeRate = item("ConvergeRate").Text
                .Amount = item("Amount").Text
                .CurrencyID = item("CurrencyID").Text
                .Save()
            End With
        Next
    End Sub
End Class