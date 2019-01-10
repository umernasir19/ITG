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

Public Class WeekWiseInquiries
    Inherits System.Web.UI.Page
    Dim ObjCustomer As New Customer
    Dim ObjPO As New PurchaseOrder
    Dim ObjCargo As New Cargo
    Dim ObjCargoDetail As New CargoDetail
    Dim GeneralCode As New GeneralCode
    Dim objEnquiriesSystemAddclass As New EnquiriesSystemAddclass
    Dim objInquiriesEntryClass As New InquiriesEntryClass
    Dim Dr As DataRow
    Dim ObjTempWeekWiseInquiry As New TempWeekWiseInquiry
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindCustomer()
        End If

    End Sub
    Sub BindCustomer()
        Try
            Dim dtCustomer As DataTable
            dtCustomer = ObjCustomer.GetBindCombo
            cmbCustomer.DataSource = dtCustomer
            cmbCustomer.DataTextField = "CustomerName"
            cmbCustomer.DataValueField = "CustomerID"
            cmbCustomer.DataBind()


            ''---Bind BuyingDept
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            ' cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))

            cmbBuyer.DataSource = objInquiriesEntryClass.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCustomer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCustomer.SelectedIndexChanged
        Try
            cmbBuyingDept.DataSource = objEnquiriesSystemAddclass.GetBuyingDept(cmbCustomer.SelectedValue)
            cmbBuyingDept.DataTextField = "BuyingDept"
            cmbBuyingDept.DataValueField = "BuyingDept"
            cmbBuyingDept.DataBind()
            'cmbBuyingDept.Items.Insert(0, New ListItem("Select", "0"))



            cmbBuyer.DataSource = objInquiriesEntryClass.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
            cmbBuyer.DataTextField = "BuyerName"
            cmbBuyer.DataValueField = "BuyerName"
            cmbBuyer.DataBind()




            'txtStartDate.Text = ""
            'txtEndDate.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewReport.Click
        Try

            ObjTempWeekWiseInquiry.TruncateTable()
            Dim GetDay As Integer = System.DateTime.DaysInMonth(cmbYear.SelectedItem.Text, cmbMonth.SelectedValue)
            Dim Month As String = cmbMonth.SelectedValue
            Dim Year As String = cmbYear.SelectedItem.Text

            Dim Week1Date1 As String = 1 & "/" & Month & "/" & Year
            Dim Week1Datee1 As String = Month & "/" & 1 & "/" & Year
            Dim Week1Date2 As String = 7 & "/" & Month & "/" & Year
            Dim Week1Datee2 As String = Month & "/" & 7 & "/" & Year
            Dim Week2Date1 As String = 8 & "/" & Month & "/" & Year
            Dim Week2Datee1 As String = Month & "/" & 8 & "/" & Year
            Dim Week2Date2 As String = 14 & "/" & Month & "/" & Year
            Dim Week2Datee2 As String = Month & "/" & 14 & "/" & Year
            Dim Week3Date1 As String = 15 & "/" & Month & "/" & Year
            Dim Week3Datee1 As String = Month & "/" & 15 & "/" & Year
            Dim Week3Date2 As String = 21 & "/" & Month & "/" & Year
            Dim Week3Datee2 As String = Month & "/" & 21 & "/" & Year
            Dim Week4Date1 As String = 22 & "/" & Month & "/" & Year
            Dim Week4Datee1 As String = Month & "/" & 22 & "/" & Year
            Dim Week4Date2 As String = 28 & "/" & Month & "/" & Year
            Dim Week4Datee2 As String = Month & "/" & 28 & "/" & Year
            Dim Week5Date1 As String = 29 & "/" & Month & "/" & Year
            Dim Week5Datee1 As String = Month & "/" & 29 & "/" & Year
            Dim Week5Date2 As String = GetDay & "/" & Month & "/" & Year
            Dim Week5Datee2 As String = Month & "/" & GetDay & "/" & Year


            Dim dtWeek1NoOfInqRecvd As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqRecvd(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week1Datee1, Week1Datee2)
            Dim dtWeek2NoOfInqRecvd As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqRecvd(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week2Datee1, Week2Datee2)
            Dim dtWeek3NoOfInqRecvd As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqRecvd(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week3Datee1, Week3Datee2)
            Dim dtWeek4NoOfInqRecvd As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqRecvd(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week4Datee1, Week4Datee2)
            Dim dtWeek5NoOfInqRecvd As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqRecvd(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week5Datee1, Week5Datee2)

            Dim dtWeek1NoOfInqGen As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqGeneral(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week1Datee1, Week1Datee2)
            Dim dtWeek2NoOfInqGen As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqGeneral(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week2Datee1, Week2Datee2)
            Dim dtWeek3NoOfInqGen As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqGeneral(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week3Datee1, Week3Datee2)
            Dim dtWeek4NoOfInqGen As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqGeneral(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week4Datee1, Week4Datee2)
            Dim dtWeek5NoOfInqGen As DataTable = ObjTempWeekWiseInquiry.GetNoOFinqGeneral(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week5Datee1, Week5Datee2)


            Dim dtWeek1NoOfConfOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFConfrmOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week1Datee1, Week1Datee2)
            Dim dtWeek2NoOfConfOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFConfrmOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week2Datee1, Week2Datee2)
            Dim dtWeek3NoOfConfOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFConfrmOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week3Datee1, Week3Datee2)
            Dim dtWeek4NoOfConfOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFConfrmOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week4Datee1, Week4Datee2)
            Dim dtWeek5NoOfConfOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFConfrmOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week5Datee1, Week5Datee2)

            Dim dtWeek1NoOfShipOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFShipedOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week1Datee1, Week1Datee2)
            Dim dtWeek2NoOfShipOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFShipedOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week2Datee1, Week2Datee2)
            Dim dtWeek3NoOfShipOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFShipedOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week3Datee1, Week3Datee2)
            Dim dtWeek4NoOfShipOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFShipedOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week4Datee1, Week4Datee2)
            Dim dtWeek5NoOfShipOrderAndCnfrmQty As DataTable = ObjTempWeekWiseInquiry.GetNoOFShipedOrderAndQuantity(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text, cmbBuyer.SelectedItem.Text, Week5Datee1, Week5Datee2)

            Dim dtFinal = New DataTable
            With dtFinal
                .Columns.Add("TempId", GetType(Long))
                .Columns.Add("Period", GetType(String))
                .Columns.Add("NoOFinq", GetType(String))
                .Columns.Add("NoOFConfrmOrdr", GetType(String))
                .Columns.Add("ConfrmQty", GetType(String))
                .Columns.Add("ShippedOrder", GetType(String))
                .Columns.Add("ShippedQty", GetType(String))

            End With

            Dr = dtFinal.NewRow()

            Dr("TempId") = 0
            Dr("Period") = Week1Date1 + " to " + Week1Date2
            'If dtWeek1NoOfInqRecvd.Rows.Count > 0 Then
            '    Dr("NoOFinq") = dtWeek1NoOfInqRecvd.Rows(0)("NoOfInq")
            'Else
            '    Dr("NoOFinq") = 0
            'End If
            If dtWeek1NoOfInqRecvd.Rows.Count > 0 Then
                If dtWeek1NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek1NoOfInqRecvd.Rows(0)("NoOfInq")) + Val(dtWeek1NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = dtWeek1NoOfInqRecvd.Rows(0)("NoOfInq")
                End If
            Else
                If dtWeek1NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek1NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = 0
                End If
            End If
           
            If dtWeek1NoOfConfOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim x As Integer = 0
                Dim NoOFConfrmOrdr1 As Decimal = 0
                Dim ConfrmQty1 As Decimal = 0
                For x = 0 To dtWeek1NoOfConfOrderAndCnfrmQty.Rows.Count - 1
                    NoOFConfrmOrdr1 = NoOFConfrmOrdr1 + dtWeek1NoOfConfOrderAndCnfrmQty.Rows(x)("NoOfConfOrder")
                    ConfrmQty1 = ConfrmQty1 + dtWeek1NoOfConfOrderAndCnfrmQty.Rows(x)("Qty")
                    Dr("NoOFConfrmOrdr") = NoOFConfrmOrdr1
                    Dr("ConfrmQty") = ConfrmQty1
                Next
            Else
                Dr("NoOFConfrmOrdr") = 0
                Dr("ConfrmQty") = 0

            End If

          

            If dtWeek1NoOfShipOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim a As Integer = 0
                Dim ShippedOrder1 As Decimal = 0
                Dim ShippedQty1 As Decimal = 0
                For a = 0 To dtWeek1NoOfShipOrderAndCnfrmQty.Rows.Count - 1
                    ShippedOrder1 = ShippedOrder1 + dtWeek1NoOfShipOrderAndCnfrmQty(0)("NoOfShipOrder")
                    ShippedQty1 = ShippedQty1 + dtWeek1NoOfShipOrderAndCnfrmQty(0)("Qty")
                    Dr("ShippedOrder") = ShippedOrder1
                    Dr("ShippedQty") = ShippedQty1
                Next
            Else
                Dr("ShippedOrder") = 0
                Dr("ShippedQty") = 0
            End If
           

            dtFinal.Rows.Add(Dr)

            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Period") = Week2Date1 + " to " + Week2Date2
            'If dtWeek2NoOfInqRecvd.Rows.Count > 0 Then
            '    Dr("NoOFinq") = dtWeek2NoOfInqRecvd.Rows(0)("NoOfInq")
            'Else
            '    Dr("NoOFinq") = 0
            'End If
            If dtWeek2NoOfInqRecvd.Rows.Count > 0 Then
                If dtWeek2NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek2NoOfInqRecvd.Rows(0)("NoOfInq")) + Val(dtWeek2NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = dtWeek2NoOfInqRecvd.Rows(0)("NoOfInq")
                End If
            Else
                If dtWeek2NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek2NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = 0
                End If
            End If
            If dtWeek2NoOfConfOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim b As Integer = 0
                Dim NoOFConfrmOrdr2 As Decimal = 0
                Dim ConfrmQty2 As Decimal = 0
                For b = 0 To dtWeek2NoOfConfOrderAndCnfrmQty.Rows.Count - 1
                    NoOFConfrmOrdr2 = NoOFConfrmOrdr2 + dtWeek2NoOfConfOrderAndCnfrmQty.Rows(0)("NoOfConfOrder")
                    ConfrmQty2 = ConfrmQty2 + dtWeek2NoOfConfOrderAndCnfrmQty.Rows(0)("Qty")
                    Dr("NoOFConfrmOrdr") = NoOFConfrmOrdr2
                    Dr("ConfrmQty") = ConfrmQty2
                Next
            Else
                Dr("NoOFConfrmOrdr") = 0
                Dr("ConfrmQty") = 0
            End If

           
            If dtWeek2NoOfShipOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim c As Integer = 0
                Dim ShippedOrder2 As Decimal = 0
                Dim ShippedQty As Decimal = 0
                For c = 0 To dtWeek2NoOfShipOrderAndCnfrmQty.Rows.Count - 1
                    ShippedOrder2 = ShippedOrder2 + dtWeek2NoOfShipOrderAndCnfrmQty(0)("NoOfShipOrder")
                    ShippedQty = ShippedQty + dtWeek2NoOfShipOrderAndCnfrmQty(0)("Qty")
                    Dr("ShippedOrder") = ShippedOrder2
                    Dr("ShippedQty") = ShippedQty
                Next
            Else
                Dr("ShippedOrder") = 0
                Dr("ShippedQty") = 0
            End If
           
            dtFinal.Rows.Add(Dr)


            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Period") = Week3Date1 + " to " + Week3Date2
            'If dtWeek3NoOfInqRecvd.Rows.Count > 0 Then
            '    Dr("NoOFinq") = dtWeek3NoOfInqRecvd.Rows(0)("NoOfInq")
            'Else
            '    Dr("NoOFinq") = 0
            'End If
            If dtWeek3NoOfInqRecvd.Rows.Count > 0 Then
                If dtWeek3NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek3NoOfInqRecvd.Rows(0)("NoOfInq")) + Val(dtWeek3NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = dtWeek3NoOfInqRecvd.Rows(0)("NoOfInq")
                End If
            Else
                If dtWeek3NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek3NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = 0
                End If
            End If
            If dtWeek3NoOfConfOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim d As Integer = 0
                Dim NoOFConfrmOrdr3 As Decimal = 0
                Dim ConfrmQty3 As Decimal = 0
                For d = 0 To dtWeek3NoOfConfOrderAndCnfrmQty.Rows.Count - 1
                    NoOFConfrmOrdr3 = NoOFConfrmOrdr3 + dtWeek3NoOfConfOrderAndCnfrmQty.Rows(0)("NoOfConfOrder")
                    ConfrmQty3 = ConfrmQty3 + dtWeek3NoOfConfOrderAndCnfrmQty.Rows(0)("Qty")
                    Dr("NoOFConfrmOrdr") = NoOFConfrmOrdr3
                    Dr("ConfrmQty") = ConfrmQty3
                Next
            Else
                Dr("NoOFConfrmOrdr") = 0
                Dr("ConfrmQty") = 0
            End If
           
            If dtWeek3NoOfShipOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim ee As Integer = 0
                Dim ShippedOrder3 As Decimal = 0
                Dim ShippedQty3 As Decimal = 0
                For ee = 0 To dtWeek3NoOfShipOrderAndCnfrmQty.Rows.Count - 1
                    ShippedOrder3 = ShippedOrder3 + dtWeek3NoOfShipOrderAndCnfrmQty(0)("NoOfShipOrder")
                    ShippedQty3 = ShippedQty3 + dtWeek3NoOfShipOrderAndCnfrmQty(0)("Qty")
                    Dr("ShippedOrder") = ShippedOrder3
                    Dr("ShippedQty") = ShippedQty3
                Next
            Else
                Dr("ShippedOrder") = 0
                Dr("ShippedQty") = 0
            End If
           
            dtFinal.Rows.Add(Dr)
            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Period") = Week4Date1 + " to " + Week4Date2
            'If dtWeek4NoOfInqRecvd.Rows.Count > 0 Then
            '    Dr("NoOFinq") = dtWeek4NoOfInqRecvd.Rows(0)("NoOfInq")
            'Else
            '    Dr("NoOFinq") = 0
            'End If
            If dtWeek4NoOfInqRecvd.Rows.Count > 0 Then
                If dtWeek4NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek4NoOfInqRecvd.Rows(0)("NoOfInq")) + Val(dtWeek4NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = dtWeek4NoOfInqRecvd.Rows(0)("NoOfInq")
                End If
            Else
                If dtWeek4NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek4NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = 0
                End If
            End If
            If dtWeek4NoOfConfOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim f As Integer = 0
                Dim NoOFConfrmOrdr4 As Decimal = 0
                Dim ConfrmQty4 As Decimal = 0
                For f = 0 To dtWeek4NoOfConfOrderAndCnfrmQty.Rows.Count - 1
                    NoOFConfrmOrdr4 = NoOFConfrmOrdr4 + dtWeek4NoOfConfOrderAndCnfrmQty.Rows(0)("NoOfConfOrder")
                    ConfrmQty4 = ConfrmQty4 + dtWeek4NoOfConfOrderAndCnfrmQty.Rows(0)("Qty")
                    Dr("NoOFConfrmOrdr") = NoOFConfrmOrdr4
                    Dr("ConfrmQty") = ConfrmQty4
                Next
            Else
                Dr("NoOFConfrmOrdr") = 0
                Dr("ConfrmQty") = 0
            End If
           
            If dtWeek4NoOfShipOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim g As Integer = 0
                Dim ShippedOrder4 As Decimal = 0
                Dim ShippedQty4 As Decimal = 0
                For g = 0 To dtWeek4NoOfShipOrderAndCnfrmQty.Rows.Count - 1
                    ShippedOrder4 = ShippedOrder4 + dtWeek4NoOfShipOrderAndCnfrmQty(0)("NoOfShipOrder")
                    ShippedQty4 = ShippedQty4 + dtWeek4NoOfShipOrderAndCnfrmQty(0)("Qty")
                    Dr("ShippedOrder") = ShippedOrder4
                    Dr("ShippedQty") = ShippedQty4
                Next
            Else
                Dr("ShippedOrder") = 0
                Dr("ShippedQty") = 0
            End If
          
            dtFinal.Rows.Add(Dr)

            Dr = dtFinal.NewRow()
            Dr("TempId") = 0
            Dr("Period") = Week5Date1 + " to " + Week5Date2
            'If dtWeek5NoOfInqRecvd.Rows.Count > 0 Then
            '    Dr("NoOFinq") = dtWeek5NoOfInqRecvd.Rows(0)("NoOfInq")
            'Else
            '    Dr("NoOFinq") = 0
            'End If
            If dtWeek5NoOfInqRecvd.Rows.Count > 0 Then
                If dtWeek4NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek5NoOfInqRecvd.Rows(0)("NoOfInq")) + Val(dtWeek5NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = dtWeek5NoOfInqRecvd.Rows(0)("NoOfInq")
                End If
            Else
                If dtWeek4NoOfInqGen.Rows.Count Then
                    Dr("NoOFinq") = Val(dtWeek4NoOfInqGen.Rows(0)("NoOfInq"))
                Else
                    Dr("NoOFinq") = 0
                End If
            End If
            If dtWeek5NoOfConfOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim h As Integer = 0
                Dim NoOFConfrmOrdr5 As Decimal = 0
                Dim ConfrmQty5 As Decimal = 0
                For h = 0 To dtWeek5NoOfConfOrderAndCnfrmQty.Rows.Count - 1
                    NoOFConfrmOrdr5 = NoOFConfrmOrdr5 + dtWeek5NoOfConfOrderAndCnfrmQty.Rows(0)("NoOfConfOrder")
                    ConfrmQty5 = ConfrmQty5 + dtWeek5NoOfConfOrderAndCnfrmQty.Rows(0)("Qty")
                    Dr("NoOFConfrmOrdr") = NoOFConfrmOrdr5
                    Dr("ConfrmQty") = ConfrmQty5
                Next
            Else
                Dr("NoOFConfrmOrdr") = 0
                Dr("ConfrmQty") = 0
            End If
          
            If dtWeek5NoOfShipOrderAndCnfrmQty.Rows.Count > 0 Then
                Dim ii As Integer = 0
                Dim ShippedOrder5 As Decimal = 0
                Dim ShippedQty5 As Decimal = 0
                For ii = 0 To dtWeek5NoOfShipOrderAndCnfrmQty.Rows.Count - 1
                    ShippedOrder5 = ShippedOrder5 + dtWeek5NoOfShipOrderAndCnfrmQty(0)("NoOfShipOrder")
                    ShippedQty5 = ShippedQty5 + dtWeek5NoOfShipOrderAndCnfrmQty(0)("Qty")
                    Dr("ShippedOrder") = ShippedOrder5
                    Dr("ShippedQty") = ShippedQty5
                Next
            Else
                Dr("ShippedOrder") = 0
                Dr("ShippedQty") = 0
            End If
          
            dtFinal.Rows.Add(Dr)


            For A As Integer = 0 To dtFinal.Rows.Count - 1
                With ObjTempWeekWiseInquiry
                    .TempId = 0
                    .Period = dtFinal.Rows(A)("Period")
                    .NoOFinq = dtFinal.Rows(A)("NoOFinq")

                    .NoOFConfrmOrdr = dtFinal.Rows(A)("NoOFConfrmOrdr")
                    .ConfrmQty = dtFinal.Rows(A)("ConfrmQty")
                    .ShippedOrder = dtFinal.Rows(A)("ShippedOrder")
                    .ShippedQty = dtFinal.Rows(A)("ShippedQty")

                    .SaveweekInquiry()
                End With

            Next


            If cmbBuyingDept.SelectedItem.Text = "Select" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Select Dept.")
            Else
                Dim BuyingDept As String = cmbBuyingDept.SelectedItem.Text
                Dim CustomerID As Long = cmbCustomer.SelectedValue
                Dim Monthly As String = cmbMonth.SelectedValue
                Dim yearly As String = cmbYear.SelectedItem.Text
                BuyingDept = cmbBuyingDept.SelectedItem.Text

                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                    System.IO.File.Delete(Uploadedfiles)
                Next

                Dim Report As New ReportDocument
                Dim Options As New ExportOptions
                Report.Load(Server.MapPath("..\Reports/WeeklyWiseSummaryofInquiriesOrder.rpt"))
                Report.Refresh()
                Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                di.Create()
                Dim FileName As String = "Weekly Wise Summary of Inquiries Order"
                Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                Report.SetParameterValue(0, cmbCustomer.SelectedItem.Text)
                Report.SetParameterValue(1, cmbBuyingDept.SelectedItem.Text)
                Report.SetParameterValue(2, cmbBuyer.SelectedItem.Text)
                Report.SetParameterValue(3, cmbMonth.SelectedItem.Text)
                Report.SetParameterValue(4, cmbYear.SelectedItem.Text)

                'Report.SetParameterValue(5, txtEndDatee.SelectedDate)
                'Report.SetParameterValue(6, cmbReportType.SelectedItem.Text)
                'Report.SetParameterValue(7, Heading)
                Dim FileOption As New DiskFileDestinationOptions
                FileOption.DiskFileName = sTempFileName
                Options = Report.ExportOptions
                Options.ExportDestinationType = ExportDestinationType.DiskFile
                Options.ExportFormatType = ExportFormatType.PortableDocFormat
                Options.DestinationOptions = FileOption
                Options.ExportDestinationOptions = FileOption
                Report.SetDatabaseLogon("sa", "pwd")
                Report.Export()

                If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
                    Dim strFileSize As String = ""
                    Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
                    Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
                    Dim fi As IO.FileInfo
                    For Each fi In aryFi
                        Response.ClearHeaders()
                        Response.ClearContent()
                        Response.ContentType = "application/octet-stream"
                        Response.Charset = "UTF-8"
                        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                        Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
                        Response.End()
                    Next
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbBuyingDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBuyingDept.SelectedIndexChanged
        cmbBuyer.DataSource = ObjTempWeekWiseInquiry.GetBuyerInfoNo(cmbCustomer.SelectedValue, cmbBuyingDept.SelectedItem.Text)
        cmbBuyer.DataTextField = "BuyerName"
        cmbBuyer.DataValueField = "BuyerName"
        cmbBuyer.DataBind()
    End Sub
End Class