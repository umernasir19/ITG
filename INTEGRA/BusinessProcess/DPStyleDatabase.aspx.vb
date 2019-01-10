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
Public Class DPStyleDatabase
    Inherits System.Web.UI.Page
    Dim ObjDPFabricIssue As New DPFabricIssue
    Dim ObjStyleDatabaseClass As New StyleDatabaseClass
    Dim lDPStyleDatabaseId, userid As Long
    Dim objTblDPRND As New TblDPRND
    Dim ObjTblRND As New TblDPRND
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lDPStyleDatabaseId = Request.QueryString("DPStyleDatabaseId")
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Session("FileNameBackImage") = Nothing
            Session("ImageByteBackImage") = Nothing
            Session("ImageByteFrontImage") = Nothing
            Session("FileNameFrontImage") = Nothing
            txtCompanyName.Text = "Digital Apparel (Pvt) Ltd."
            BindCustomer()
            If lDPStyleDatabaseId > 0 Then
                Edit()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Sub Edit()
        Dim dt As DataTable
        dt = ObjStyleDatabaseClass.GetEdit(lDPStyleDatabaseId)
        If dt.Rows.Count > 0 Then
            txtStyleCode.Text = dt.Rows(0)("StyleCode")
            cmbOurStyle.SelectedItem.Text = dt.Rows(0)("StyleName")
            txtStyleDate.SelectedDate = dt.Rows(0)("StyleDate")
            txtCompanyName.Text = dt.Rows(0)("CompanyName")
            txtDescription.Text = dt.Rows(0)("Description")
            txtEstTimeReq.Text = dt.Rows(0)("EstimatedTimeReq")
            lblUserId.Text = dt.Rows(0)("UserId")
            Dim FileName As String = ""
            Dim Vaf As String = dt.Rows(0)("FileNameFront")
            If Vaf = "" Then
                Dim path As String = Server.MapPath("../Images/" & "NoImage.JPG")
                Dim bytes As Byte() = GetFileContent(path)
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
                Image1.Visible = True
                Session("FileNameFront") = "NoImage.JPEG"
                Session("ImageByte") = bytes
            Else
                Dim bytes As Byte() = dt.Rows(0)("ImageFront")
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
                Image1.Visible = True
                FileName = dt.Rows(0)("FileNameFront")
                Session("FileNameFrontImage") = FileName
                Session("ImageByteFrontImage") = bytes
            End If
            Dim FileNamee As String = ""
            Dim Vaff As String = dt.Rows(0)("FileNameBack")
            If Vaff = "" Then
                Dim path As String = Server.MapPath("../Images/" & "NoImage.JPG")
                Dim bytes As Byte() = GetFileContent(path)
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image2.ImageUrl = "data:image/png;base64," & base64String
                Image2.Visible = True
                Session("FileNameBackImage") = "NoImage.JPEG"
                Session("ImageByteBackImage") = bytes
            Else
                Dim bytes As Byte() = dt.Rows(0)("ImageBack")
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image2.ImageUrl = "data:image/png;base64," & base64String
                Image2.Visible = True
                FileNamee = dt.Rows(0)("FileNameBack")
                Session("FileNameBackImage") = FileNamee
                Session("ImageByteBackImage") = bytes
            End If
            If dt.Rows(0)("Isactive") = "True" Then

                chkIsActive.Checked = True
            Else
                chkIsActive.Checked = False
            End If
            BindCustomer()
            cmbBuyer.SelectedValue = dt.Rows(0)("CustomerID")
            txtBuyerReferenceNo.Text = dt.Rows(0)("BuyerReferenceNo")
            If cmbOurStyle.SelectedItem.Text = "Buyer Style" Then
                pnlBuyer.Visible = True
                cmbBuyer.Visible = True
                txtCompanyName.Visible = False
            ElseIf cmbOurStyle.SelectedItem.Text = "Our Style" Then
                cmbBuyer.Visible = True
                pnlBuyer.Visible = True
                txtCompanyName.Visible = True
            Else
            End If
        End If
    End Sub
    Sub StyleNoGenerateOnLoad()
        Try
            Dim VoucherNo As String
            Dim Voucherdate As Date = Date.Now
            Dim month As String = Voucherdate.Month
            Dim LastVoucherNo As String = ObjStyleDatabaseClass.GetLastStyleNo()
            Dim LastCode As String
            If LastVoucherNo = "" Then
                LastCode = "0000001"
            Else
                LastCode = LastVoucherNo.Substring(4, 7)
                If LastCode < 10 Then
                    If LastCode = 9 Then
                        LastCode = "00000" & Val(LastCode + 1)
                    Else
                        LastCode = "000000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100 Or LastCode = 10 Then
                    If LastCode = 99 Then
                        LastCode = "0000" & Val(LastCode + 1)
                    Else
                        LastCode = "00000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000 Or LastCode = 100 Then
                    If LastCode = 999 Then
                        LastCode = "000" & Val(LastCode + 1)
                    Else
                        LastCode = "0000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 10000 Or LastCode = 1000 Then
                    If LastCode = 9999 Then
                        LastCode = "00" & Val(LastCode + 1)
                    Else
                        LastCode = "000" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 100000 Or LastCode = 10000 Then
                    If LastCode = 9999 Then
                        LastCode = "0" & Val(LastCode + 1)
                    Else
                        LastCode = "00" & Val(LastCode + 1)
                    End If
                ElseIf LastCode < 1000000 Or LastCode = 100000 Then
                    If LastCode = 9999 Then
                        LastCode = Val(LastCode + 1)
                    Else
                        LastCode = "" & Val(LastCode + 1)
                    End If
                Else
                    LastCode = Val(LastCode + 1)
                End If
            End If
            VoucherNo = "STY" & "-" & LastCode
            txtStyleCode.Text = VoucherNo
        Catch ex As Exception
        End Try
    End Sub
    Sub BindCustomer()
        Dim dtsupplier As DataTable
        dtsupplier = ObjTblRND.GetCustomer
        cmbBuyer.DataSource = dtsupplier
        cmbBuyer.DataTextField = "CustomerName"
        cmbBuyer.DataValueField = "CustomerID"
        cmbBuyer.DataBind()
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        Try
            If FileUpload.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Choose Image For Upload.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileName As String = ""
                Dim fs As System.IO.Stream = FileUpload.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image1.ImageUrl = "data:image/png;base64," & base64String
                Image1.Visible = True
                FileName = FileUpload.FileName
                Session("FileNameFrontImage") = FileName
                Session("ImageByteFrontImage") = bytes
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbOurStyle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOurStyle.TextChanged
        Try
            If cmbOurStyle.SelectedItem.Text = "Buyer Style" Then
                pnlBuyer.Visible = True
                cmbBuyer.Visible = True
                BindCustomer()
                Dim dt As DataTable = ObjTblRND.GetBuyerReferenceNo(cmbBuyer.SelectedItem.Text)
                If dt.Rows.Count > 0 Then
                    txtBuyerReferenceNo.Text = dt.Rows(0)("BuyerReferenceNoo")
                Else
                    txtBuyerReferenceNo.Text = "N/A"
                End If
                txtCompanyName.Visible = False
            ElseIf cmbOurStyle.SelectedItem.Text = "Our Style" Then
                cmbBuyer.Visible = True
                pnlBuyer.Visible = True
                BindCustomer()
                txtCompanyName.Visible = True
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbBuyer_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyer.TextChanged
        Try
            Dim dt As DataTable = ObjTblRND.GetBuyerReferenceNo(cmbBuyer.SelectedItem.Text)
            If dt.Rows.Count > 0 Then
                txtBuyerReferenceNo.Text = dt.Rows(0)("BuyerReferenceNoo")
            Else
                txtBuyerReferenceNo.Text = "N/A"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnUpload2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload2.Click
        Try

            If FileUpload2.FileName = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Choose Image For Upload.")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Dim FileName As String = ""
                Dim fs As System.IO.Stream = FileUpload2.PostedFile.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(CType(fs.Length, Integer))
                Dim base64String As String = Convert.ToBase64String(bytes, 0, bytes.Length)
                Image2.ImageUrl = "data:image/png;base64," & base64String
                Image2.Visible = True
                FileName = FileUpload2.FileName
                Session("FileNameBackImage") = FileName
                Session("ImageByteBackImage") = bytes
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub pictureNotAvialableFront()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteFrontImage") = GetFileContent(path)
        Session("FileNameFrontImage") = "no-image.jpg"
    End Sub
    Sub pictureNotAvialableBack()
        Dim path As String = Server.MapPath("../Images/" & "no-image.jpg")
        Session("ImageByteBackImage") = GetFileContent(path)
        Session("FileNameBackImage") = "no-image.jpg"
    End Sub
    Private Function GetFileContent(ByVal imageFilePath As String) As Byte()
        Dim fileStream As Stream = New FileStream(imageFilePath, FileMode.Open)
        Dim fileContent As Byte() = New Byte(fileStream.Length - 1) {}
        fileStream.Read(fileContent, 0, CInt(fileStream.Length))
        fileStream.Close()
        Return fileContent
    End Function
    Sub Save()
        With ObjStyleDatabaseClass
            If lDPStyleDatabaseId > 0 Then
                .DPStyleDatabaseId = lDPStyleDatabaseId
            Else
                .DPStyleDatabaseId = 0
            End If
            .StyleCode = txtStyleCode.Text
            .StyleName = cmbOurStyle.SelectedItem.Text
            .CreationDate = Date.Now
            .StyleDate = txtStyleDate.SelectedDate
            If Session("RoleId") = 46 And Session("Type") = "R.N.D" Then
                If lDPStyleDatabaseId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = 270
                End If
            Else
                If lDPStyleDatabaseId > 0 Then
                    .UserId = lblUserId.Text
                Else
                    .UserId = userid
                End If
            End If
            If txtCompanyName.Text = "" Then
                .CompanyName = "N/A"
            Else
                .CompanyName = txtCompanyName.Text.ToUpper
            End If
            .Description = txtDescription.Text.ToUpper
            .EstimatedTimeReq = txtEstTimeReq.Text
            If Session("FileNameFrontImage") = "" Then
                pictureNotAvialableFront()
                .FileNameFront = Session("FileNameFrontImage")
                .ImageFront = Session("ImageByteFrontImage")
            Else
                .FileNameFront = Session("FileNameFrontImage")
                .ImageFront = Session("ImageByteFrontImage")
            End If
            If Session("FileNameBackImage") = "" Then
                pictureNotAvialableBack()
                .FileNameBack = Session("FileNameBackImage")
                .ImageBack = Session("ImageByteBackImage")
            Else
                .FileNameBack = Session("FileNameBackImage")
                .ImageBack = Session("ImageByteBackImage")
            End If
            .Isactive = chkIsActive.Checked
            .CustomerID = cmbBuyer.SelectedValue
            If txtBuyerReferenceNo.Text = "" Then
                .BuyerReferenceNo = "N/A"
            Else
                .BuyerReferenceNo = txtBuyerReferenceNo.Text.ToUpper
            End If
            .Save()
        End With
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            If lDPStyleDatabaseId > 0 Then
                Save()
                Response.Redirect("DPStyleDatabaseView.aspx")
            Else
                Dim dt As DataTable = ObjStyleDatabaseClass.GetStyleCode(txtStyleCode.Text)
                If dt.Rows.Count > 0 Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Style Code Already Exist")
                ElseIf txtStyleDate.ValidationDate = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Date")
                ElseIf txtDescription.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Description")
                ElseIf txtEstTimeReq.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Estimated Time Req")
                ElseIf txtEstTimeReq.Text = "" Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Estimated Time Req")
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    Save()
                    Response.Redirect("DPStyleDatabaseView.aspx")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("DPStyleDatabaseView.aspx")
        Catch ex As Exception
        End Try
    End Sub
End Class