Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class CdDbPurchaseOrder
    Inherits System.Web.UI.Page
    Dim ObjCrdDbNotePurchaseOrder As New CrdDbNotePurchaseOrder
    Dim ObjCrdDbNotePurchaseOrderDtl As New CrdDbNotePurchaseOrderDtl
    Dim Supplier As String
    Dim gstPer As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtdatee.Text = Date.Now()
            BindSupplier()
            NoteNoGenerateOnLoad()
        End If
    End Sub

    Sub BindSupplier()
        Dim dt As DataTable
        dt = ObjCrdDbNotePurchaseOrder.GetSupplierNew()
        cmbSupplier.DataSource = dt
        cmbSupplier.DataTextField = "SupplierName"
        cmbSupplier.DataValueField = "SupplierDatabaseId"
        cmbSupplier.DataBind()
        cmbSupplier.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub NoteNoGenerateOnLoad()
        Try
            Dim LastCode As String
            Dim VoucherNo As String

            Dim Datee As Date = txtdatee.Text
            Dim year As String = Datee.Year
            Dim yearP As String = Datee.Year
            year = year.Substring(2, 2)



            'Dim lastNo As Integer = objtblBankMst.GetMaxLastNo(Month, yearP)
            Dim LastVoucherNo As String = ObjCrdDbNotePurchaseOrder.GetLastNoteNo(yearP)

            Dim PreviousMonth As Integer
            If LastVoucherNo = "" Then
                LastCode = "001"
            Else
                Dim LastCodee As Integer

                LastCodee = LastVoucherNo.Substring(2, 1)


                If LastCodee < 10 Then
                    If LastCodee = 9 Then
                        LastCode = "0" & Val(LastCodee + 1)
                    Else
                        LastCode = "00" & Val(LastCodee + 1)
                    End If

                ElseIf LastCodee < 100 Or LastCodee = 10 Then
                    If LastCodee = 99 Then
                        LastCode = "" & Val(LastCodee + 1)
                    Else
                        LastCode = "0" & Val(LastCodee + 1)
                    End If
                Else
                    LastCode = Val(LastCodee + 1)
                End If

            End If
            VoucherNo = LastCode & "-" & year
            txtNoteNo.Text = VoucherNo


        Catch ex As Exception

        End Try
    End Sub
    Sub BindInvoice()
        Dim dti As DataTable
        dti = ObjCrdDbNotePurchaseOrder.GetInvoiceNoNew(cmbSupplier.SelectedValue)
        cmbInvoiceNo.DataSource = dti
        cmbInvoiceNo.DataTextField = "VoucherNo"
        cmbInvoiceNo.DataValueField = "POInvoiceMstid"
        cmbInvoiceNo.DataBind()
        cmbInvoiceNo.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Protected Sub cmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged
        Try
            BindInvoice()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbInvoiceNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbInvoiceNo.SelectedIndexChanged
        Try
            BindItems()
            BindInvoiceitem()
            btnSave.Visible = True

            txtTot.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Sub BindItems()
        Dim dt As DataTable
        dt = ObjCrdDbNotePurchaseOrder.GetItems(cmbInvoiceNo.SelectedValue)
        cmbItems.DataSource = dt
        cmbItems.DataTextField = "ItemName"
        cmbItems.DataValueField = "ItemID"
        cmbItems.DataBind()
        cmbItems.Items.Insert(0, New ListItem("Select", "0"))

    End Sub
    Sub BindInvoiceitem()
        Dim dt As DataTable
        Dim x As Integer
        dt = ObjCrdDbNotePurchaseOrder.GetInvoiceDetail(cmbInvoiceNo.SelectedValue)
        cmbItems.DataSource = dt
        'txtPackingQty.Text = dt.Rows(x)("PackingQty")
        'txtPerUnitqty.Text = dt.Rows(x)("PerUnitqty")
        'txtQtyIssue.Text = dt.Rows(x)("Invoiceqty")
        'txtRATEE.Text = dt.Rows(x)("RATE")
        'txtAmountt.Text = dt.Rows(x)("Amount")
        'txtGstPer.Text = dt.Rows(x)("GstPer")
        'txtGSTAmountt.Text = dt.Rows(x)("GSTAmount")
        'txtCartagee.Text = dt.Rows(x)("Cartage")
        'txtDiscount.Text = dt.Rows(x)("Discount")
        'txtNetAmountt.Text = dt.Rows(x)("NetAmount")
        txtInvoiceAmount.Text = dt.Rows(x)("InvoiceAmount")



        dgItemView.DataSource = dt
        dgItemView.DataBind()
        'Dim x As Integer
        For x = 0 To dt.Rows.Count - 1

            Dim txtRATE As TextBox = CType(dgItemView.Items(x).FindControl("txtRATE"), TextBox)
            Dim txtAmount As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtAmount"), TextBox)
            Dim txtGSTAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtGSTAmount"), TextBox)
            Dim txtNetAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtNetAmount"), TextBox)
            Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
            'Dim txtCartage As TextBox = CType(dgItemView.Items(x).FindControl("txtCartage"), TextBox)
            Dim cmbWHT As DropDownList = CType(dgItemView.Items(x).FindControl("cmbWHT"), DropDownList)
            Dim txtWHTAXAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtWHTAXAmount"), TextBox)
            Dim txtPerkg As TextBox = CType(dgItemView.Items(x).FindControl("txtPerkg"), TextBox)
            Dim txtInvoiceQtyy As TextBox = CType(dgItemView.Items(x).FindControl("txtInvoiceQtyy"), TextBox)
            ' Dim GSTPER As Integer = dt.Rows(x)("GstPer")
            Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
            txtRATE.Text = ""
            txtAmount.Text = ""
            cmbGstPer.SelectedValue = ""
            txtGSTAmount.Text = ""
            'txtCartage.Text = ""
            txtWHTAXAmount.Text = ""
            txtNetAmount.Text = ""
            txtInvoiceQtyy.Text = ""
            BindGST()
            'BindcmbPackingUnit()
        Next



    End Sub


    Sub BindGST()
        Dim x As Integer
        For x = 0 To dgItemView.Items.Count - 1
            Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
            cmbGstPer.Items.Insert(0, New ListItem("0", "0"))
            cmbGstPer.Items.Insert(1, New ListItem("1", "1"))
            cmbGstPer.Items.Insert(2, New ListItem("2", "2"))
            cmbGstPer.Items.Insert(3, New ListItem("3", "3"))
            cmbGstPer.Items.Insert(4, New ListItem("4", "4"))
            cmbGstPer.Items.Insert(5, New ListItem("5", "5"))
            cmbGstPer.Items.Insert(6, New ListItem("6", "6"))
            cmbGstPer.Items.Insert(7, New ListItem("7", "7"))

            cmbGstPer.Items.Insert(8, New ListItem("8", "8"))
            cmbGstPer.Items.Insert(9, New ListItem("9", "9"))
            cmbGstPer.Items.Insert(10, New ListItem("10", "10"))
            cmbGstPer.Items.Insert(11, New ListItem("11", "11"))
            cmbGstPer.Items.Insert(12, New ListItem("12", "12"))
            cmbGstPer.Items.Insert(13, New ListItem("13", "13"))
            cmbGstPer.Items.Insert(14, New ListItem("14", "14"))
            cmbGstPer.Items.Insert(15, New ListItem("15", "15"))

            cmbGstPer.Items.Insert(16, New ListItem("16", "16"))
            cmbGstPer.Items.Insert(17, New ListItem("17", "17"))
            cmbGstPer.Items.Insert(18, New ListItem("18", "18"))
            cmbGstPer.Items.Insert(19, New ListItem("19", "19"))
            cmbGstPer.Items.Insert(20, New ListItem("20", "20"))
            cmbGstPer.Items.Insert(21, New ListItem("21", "21"))
            cmbGstPer.Items.Insert(22, New ListItem("22", "22"))
            cmbGstPer.Items.Insert(23, New ListItem("23", "23"))

            cmbGstPer.Items.Insert(24, New ListItem("24", "24"))
            cmbGstPer.Items.Insert(25, New ListItem("25", "25"))
            cmbGstPer.Items.Insert(26, New ListItem("26", "26"))
            cmbGstPer.Items.Insert(27, New ListItem("27", "27"))
            cmbGstPer.Items.Insert(28, New ListItem("28", "28"))
            cmbGstPer.Items.Insert(29, New ListItem("29", "29"))
            cmbGstPer.Items.Insert(30, New ListItem("30", "30"))


        Next
    End Sub
    Protected Sub txtRATE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim x As Integer
            For x = 0 To dgItemView.Items.Count - 1
                Dim txtRATE As TextBox = CType(dgItemView.Items(x).FindControl("txtRATE"), TextBox)
                Dim txtQtyIssuee As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtQtyIssuee"), TextBox)
                Dim txtAmount As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtAmount"), TextBox)
                Dim txtGSTAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtGSTAmount"), TextBox)
                Dim txtNetAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtNetAmount"), TextBox)
                Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
                'Dim txtCartage As TextBox = CType(dgItemView.Items(x).FindControl("txtCartage"), TextBox)
                Dim cmbWHT As DropDownList = CType(dgItemView.Items(x).FindControl("cmbWHT"), DropDownList)
                Dim txtWHTAXAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtWHTAXAmount"), TextBox)
                Dim txtInvoiceQtyy As TextBox = CType(dgItemView.Items(x).FindControl("txtInvoiceQtyy"), TextBox)
                'Dim qty As Decimal = dgItemView.Items(x).Cells(10).Text
                Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
                'If txtQtyIssuee.Text = "" Then
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Fill Req Qty")
                'Else
                '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")

                'If txtCartage.Text = "" Then
                '    txtCartage.Text = 0
                'End If

                'If txtWHTAXAmount.Text = "" Then
                'txtWHTAXAmount.Text = 0
                'End If
                txtAmount.Text = Val(txtInvoiceQtyy.text) * Val(txtRATE.Text) '(dgItemView.Items(x).Cells(3).Text)
                txtNetAmount.Text = Val(txtAmount.Text) + Val(txtRATE.Text)
                txtGSTAmount.Text = (Val(txtAmount.Text) * Val(cmbGstPer.SelectedItem.Text)) / 100
                txtWHTAXAmount.Text = (Val(txtAmount.Text) * Val(cmbWHT.SelectedItem.Text)) / 100
                txtNetAmount.Text = Val(txtGSTAmount.Text) + Val(txtAmount.Text) + Val(txtRATE.Text) + Val(txtWHTAXAmount.Text) ' Val(txtCartage.Text)  - Val(txtDiscountt.Text)
                'End If

            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbGstPer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim x As Integer
            For x = 0 To dgItemView.Items.Count - 1
                Dim txtRATE As TextBox = CType(dgItemView.Items(x).FindControl("txtRATE"), TextBox)
                Dim txtQtyIssuee As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtQtyIssuee"), TextBox)
                Dim txtAmount As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtAmount"), TextBox)
                Dim txtGSTAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtGSTAmount"), TextBox)
                Dim txtNetAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtNetAmount"), TextBox)
                Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
                'Dim txtCartage As TextBox = CType(dgItemView.Items(x).FindControl("txtCartage"), TextBox)
                Dim cmbWHT As DropDownList = CType(dgItemView.Items(x).FindControl("cmbWHT"), DropDownList)
                Dim txtWHTAXAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtWHTAXAmount"), TextBox)
                Dim txtInvoiceQtyy As TextBox = CType(dgItemView.Items(x).FindControl("txtInvoiceQtyy"), TextBox)
                'Dim qty As Decimal = dgItemView.Items(x).Cells(10).Text
                Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
                If txtAmount.Text = "" Then
                Else

                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    txtAmount.Text = Val(txtInvoiceQtyy.text) * Val(txtRATE.Text) 'dgItemView.Items(x).Cells(5).Text
                    txtGSTAmount.Text = (Val(txtAmount.Text) * Val(cmbGstPer.SelectedItem.Text)) / 100
                    txtWHTAXAmount.Text = (Val(txtAmount.Text) * Val(cmbWHT.SelectedItem.Text)) / 100
                    txtNetAmount.Text = Val(txtGSTAmount.Text) + Val(txtAmount.Text) + Val(txtRATE.Text) + Val(txtWHTAXAmount.Text) ' Val(txtCartage.Text)  - Val(txtDiscountt.Text)
                End If

            Next


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbWHT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim x As Integer
            For x = 0 To dgItemView.Items.Count - 1
                Dim txtRATE As TextBox = CType(dgItemView.Items(x).FindControl("txtRATE"), TextBox)
                Dim txtQtyIssuee As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtQtyIssuee"), TextBox)
                Dim txtAmount As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtAmount"), TextBox)
                Dim txtGSTAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtGSTAmount"), TextBox)
                Dim txtNetAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtNetAmount"), TextBox)
                Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
                'Dim txtCartage As TextBox = CType(dgItemView.Items(x).FindControl("txtCartage"), TextBox)
                Dim cmbWHT As DropDownList = CType(dgItemView.Items(x).FindControl("cmbWHT"), DropDownList)
                Dim txtWHTAXAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtWHTAXAmount"), TextBox)
                Dim txtInvoiceQtyy As TextBox = CType(dgItemView.Items(x).FindControl("txtInvoiceQtyy"), TextBox)
                ' Dim qty As Decimal = dgItemView.Items(x).Cells(10).Text
                Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
                'If txtINTAXAmount.Text = "" Then
                '    txtINTAXPer.Text = "0.00"
                '    txtINTAXAmount.Text = "0.00"
                'End If

                txtAmount.Text = Val(txtInvoiceQtyy.text) * Val(txtRATE.Text) 'dgItemView.Items(x).Cells(5).Text
                txtGSTAmount.Text = (Val(txtAmount.Text) * Val(cmbGstPer.SelectedItem.Text)) / 100
                txtWHTAXAmount.Text = (Val(txtGSTAmount.Text) * Val(cmbWHT.SelectedItem.Text)) / 100
                txtNetAmount.Text = Val(txtGSTAmount.Text) + Val(txtAmount.Text) + Val(txtRATE.Text) + Val(txtWHTAXAmount.Text) '+ Val(txtGSTAmount.Text) 'Val(txtCartage.Text)  - Val(txtDiscountt.Text)
            Next

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub UpdateStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        If cmbSupplier.SelectedValue > 0 Then
            updateststusfunction()

            Dim x As Integer
            For x = 0 To dgItemView.Items.Count - 1
                Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
                Dim cmbGstPer As DropDownList = DirectCast(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
                If ChkInvoiceStatus.Checked = True Then
                    Dim gstPer As Decimal = cmbGstPer.SelectedValue
                    updateststusfunction()
                    lblSupplierId.Text = cmbSupplier.SelectedValue
                    '---Bilal Work

                End If

            Next
            'Dim z As Integer
            'For z = 0 To dgItemView.Items.Count - 1
            '    Dim ChkInvoiceStatus2 As CheckBox = DirectCast(dgItemView.Items(z).FindControl("ChkInvoiceStatus"), CheckBox)
            '    Dim cmbGstPer2 As DropDownList = DirectCast(dgItemView.Items(z).FindControl("cmbGstPer"), DropDownList)
            '    If cmbGstPer2.SelectedValue = 0 Then
            '        ChkInvoiceStatus2.Enabled = True
            '        txtTot.Text = "0.00"
            '        cmbGstPer2.Enabled = True
            '    Else
            '        If cmbGstPer2.SelectedValue > 0 Then
            '            ChkInvoiceStatus2.Enabled = True
            '            cmbGstPer2.Enabled = False
            '            txtTot.Text = Val(txtNetAmountt.Text)
            '        Else
            '            ChkInvoiceStatus2.Enabled = False
            '            ChkInvoiceStatus2.Checked = False

            '            updateststusfunction()

            '        End If
            '    End If

            'Next
        Else

            Dim gstPer As Decimal
            Dim x As Integer
            For x = 0 To dgItemView.Items.Count - 1
                Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
                Dim cmbGstPer As DropDownList = DirectCast(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
                If ChkInvoiceStatus.Checked = True Then
                    Supplier = cmbSupplier.SelectedItem.Text
                    gstPer = cmbGstPer.SelectedValue
                    lblSupplierId.Text = cmbSupplier.SelectedValue
                    updateststusfunction()

                End If

            Next
            Dim z As Integer
            For z = 0 To dgItemView.Items.Count - 1
                Dim ChkInvoiceStatus2 As CheckBox = DirectCast(dgItemView.Items(z).FindControl("ChkInvoiceStatus"), CheckBox)
                Dim cmbGstPer2 As DropDownList = DirectCast(dgItemView.Items(z).FindControl("cmbGstPer"), DropDownList)
                If Supplier = "" Then
                    ChkInvoiceStatus2.Enabled = True
                    cmbGstPer2.Enabled = True
                    txtTot.Text = "0.00"
                Else
                    If Supplier = dgItemView.Items(z).Cells(8).Text Then
                        ChkInvoiceStatus2.Enabled = True
                        If gstPer = cmbGstPer2.SelectedValue Then
                            ChkInvoiceStatus2.Enabled = True
                            cmbGstPer2.Enabled = False
                        Else
                            ChkInvoiceStatus2.Enabled = False
                            ChkInvoiceStatus2.Checked = False
                            cmbGstPer2.Enabled = True

                        End If
                    Else
                        ChkInvoiceStatus2.Enabled = False
                        ChkInvoiceStatus2.Checked = False
                    End If
                End If
            Next

        End If

    End Sub
    Sub updateststusfunction()

        Dim x As Integer
        Dim totalamount As Decimal = 0
        Dim totalExcVal As Decimal = 0
        Dim totalGstAmount As Decimal = 0
        Dim totalCartage As Decimal = 0
        For x = 0 To dgItemView.Items.Count - 1
            Dim NoteDtlID As Integer = dgItemView.Items(x).Cells(0).Text
            Dim NetAmount As String = dgItemView.Items(x).Cells(9).Text
            Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
            Dim txtNetAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtNetAmount"), TextBox)
            Dim txtAmount As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtAmount"), TextBox)
            Dim txtGSTAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtGSTAmount"), TextBox)
            'Dim txtCartage As TextBox = CType(dgItemView.Items(x).FindControl("txtCartage"), TextBox)
            Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
            Dim cmbWHT As DropDownList = CType(dgItemView.Items(x).FindControl("cmbWHT"), DropDownList)
            Dim txtWHTAXAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtWHTAXAmount"), TextBox)
            If ChkInvoiceStatus.Checked = True Then
                ' Dim InvoiceStatus As Decimal = 1
                ' objInvoiceMst.UpdateInvoiceStatus(NoteDtlID, InvoiceStatus)
                totalamount = totalamount + Convert.ToDecimal(txtNetAmount.Text)
                totalExcVal = totalExcVal + Convert.ToDecimal(txtAmount.Text)
                totalGstAmount = totalGstAmount + Convert.ToDecimal(txtGSTAmount.Text)
                'totalCartage = totalCartage + Convert.ToDecimal(txtCartage.Text)
                'lblGstPer.Text = cmbGstPer.SelectedValue
                ' btnCancel.Visible = False
                Dim INVCAmount As Decimal = Convert.ToDecimal(txtInvoiceAmount.Text)

                If totalamount > INVCAmount Then
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Total Amount is greater then Invoice Amount")
                    ChkInvoiceStatus.Checked = False
                    ChkInvoiceStatus.Enabled = True
                    Dim txtRate As TextBox = CType(dgItemView.Items(x).FindControl("txtRate"), TextBox)
                    txtRate.Enabled = True
                    txtAmount.Enabled = True
                    cmbGstPer.Enabled = True
                    txtGSTAmount.Enabled = True
                    cmbWHT.Enabled = True
                    txtWHTAXAmount.Enabled = True
                    txtNetAmount.Enabled = True

                Else
                    ChkInvoiceStatus.Checked = True
                    ChkInvoiceStatus.Enabled = False
                    Dim txtRate As TextBox = CType(dgItemView.Items(x).FindControl("txtRate"), TextBox)
                    txtRate.Enabled = False
                    txtAmount.Enabled = False
                    cmbGstPer.Enabled = False
                    txtGSTAmount.Enabled = False
                    cmbWHT.Enabled = False
                    txtWHTAXAmount.Enabled = False
                    txtNetAmount.Enabled = False
                    txtTot.Text = totalamount.ToString("#,0.00")
                End If
            Else
                ' Dim InvoiceStatus As Decimal = 0
                ' objInvoiceMst.UpdateInvoiceStatus(StoreIssueDetailID, InvoiceStatus)
            End If
        Next

        'lblTotalExcVal.Text = totalExcVal.ToString("#,0.00")
        'lblTotalGst.Text = totalGstAmount.ToString("#,0.00")
        'lblTotalCartage.Text = totalCartage.ToString("#,0.00")

        'objDataView = LoadData()
        'Session("objDataView") = objDataView
        BindGrid()
    End Sub
    Sub BindGrid()



    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbNoteType.SelectedValue = 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Note Type")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                Save()
                Response.Redirect("CrdDbNotePOView.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Save()
        With ObjCrdDbNotePurchaseOrder
            .CrdDbNotePOID = 0
            .CDNoteNo = txtNoteNo.Text.ToUpper
            .Datee = txtdatee.Text
            .NoteTypeID = cmbNoteType.SelectedValue
            .NoteType = cmbNoteType.SelectedItem.Text
            .SupplierID = cmbSupplier.SelectedValue
            .Supplier = cmbSupplier.SelectedItem.Text
            .InvNo = cmbInvoiceNo.SelectedItem.Text
            .InvoiceNoID = cmbInvoiceNo.SelectedValue
            .InvAmt = txtInvoiceAmount.Text.ToUpper
            .Amount = txtTot.Text
            .SaveCDNotePO()
        End With

        Dim x As Integer
        For x = 0 To dgItemView.Items.Count - 1
            Dim ChkInvoiceStatus As CheckBox = DirectCast(dgItemView.Items(x).FindControl("ChkInvoiceStatus"), CheckBox)
            Dim txtQtyy As TextBox = CType(dgItemView.Items(x).FindControl("txtQtyy"), TextBox)
            Dim txtPerkg As TextBox = DirectCast(dgItemView.Items(x).FindControl("txtPerkg"), TextBox)
            Dim txtPackingQty As TextBox = CType(dgItemView.Items(x).FindControl("txtPackingQty"), TextBox)
            Dim txtQtyIssue As TextBox = CType(dgItemView.Items(x).FindControl("txtQtyIssue"), TextBox)
            Dim txtRate As TextBox = CType(dgItemView.Items(x).FindControl("txtRate"), TextBox)
            Dim txtAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtAmount"), TextBox)
            Dim cmbGstPer As DropDownList = CType(dgItemView.Items(x).FindControl("cmbGstPer"), DropDownList)
            Dim txtGSTAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtGSTAmount"), TextBox)
            'Dim txtCartage As TextBox = CType(dgItemView.Items(x).FindControl("txtCartage"), TextBox)
            Dim cmbWHT As DropDownList = CType(dgItemView.Items(x).FindControl("cmbWHT"), DropDownList)
            Dim txtWHTAXAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtWHTAXAmount"), TextBox)
            Dim txtNetAmount As TextBox = CType(dgItemView.Items(x).FindControl("txtNetAmount"), TextBox)
            Dim txtInvoiceQtyy As TextBox = CType(dgItemView.Items(x).FindControl("txtInvoiceQtyy"), TextBox)
            'Dim StoreIssueDetailID As Long = dgItemView.Items(x).Cells(1).Text
            If ChkInvoiceStatus.Checked = True Then
                With ObjCrdDbNotePurchaseOrderDtl
                    .CDNotePODtlID = dgItemView.Items(x).Cells(0).Text
                    .CrdDbNotePOID = ObjCrdDbNotePurchaseOrder.GetID()
                    .ItemID = dgItemView.Items(x).Cells(1).Text
                    .ItemName = dgItemView.Items(x).Cells(2).Text
                    .Qtyy = txtInvoiceQtyy.Text 'dgItemView.Items(x).Cells(1).Text


                    .Rate = txtRate.Text 'dgItemView.Items(x).Cells(11).Text
                    .Amount = txtAmount.Text 'dgItemView.Items(x).Cells(12).Text
                    .GstPer = cmbGstPer.SelectedItem.Text
                    .GstAmount = txtGSTAmount.Text

                    .NetAmount = txtNetAmount.Text
                    .WHT = cmbWHT.SelectedItem.Text
                    .WHTAXAmount = txtWHTAXAmount.Text
                    .UpdateStatus = ChkInvoiceStatus.Checked
                    .SaveCrdDbPODtl()

                End With
            End If
        Next


    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("CrdDbNotePOView.aspx")
    End Sub
End Class
