Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class AccChecklistEntry
    Inherits System.Web.UI.Page
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID As Long
    Dim UserId As Long
    Dim objCuttingProMst As New CuttingProMst
    Dim objAccCheckListMst As New AccCheckListMst
    Dim objAccCheckListDtl As New AccCheckListDtl
    Dim objThreadChckList As New ThreadChckList
    Dim objAccRevisedDate As New AccRevisedDate
    Dim objZipperCheckListDtl As New ZipperCheckListDtl
    Dim dtAccCheckListDetail, dtAccCheckListThreasDtl, dtZipperCheckListDetail As DataTable
    Dim Dr As DataRow
    Dim Type As String
    Dim objDPSampleReceive As New DPSampleReceive
    Dim objPackingMst As New PackingMst
    Dim objPackingDtl As New PackingDtl
    Dim dtPackingListDetail As DataTable
    Dim ObjCommercialPackingListMst As New CommercialPackingListMst
    Dim ObjCommercialPackingListDtl As New CommercialPackingListDtl
    Dim objTodayCutting As New TodayCutting
    Dim objTodayCuttingDtl As New TodayCuttingDtl
    Dim objSizeRange As New SizeRange
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim objPORecvMaster As New PORecvMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("JobOrderID")
        lJoborderDetailid = Request.QueryString("JoborderDetailid")
        lStyleAssortmentMasterID = Request.QueryString("StyleAssortmentMasterID")
        Type = Request.QueryString("Type")
        UserId = Session("UserId")
        If Not IsPostBack Then
            BindSeason()
            If Type = "Copy" Then
                pnlCopy.Visible = True
            Else
                pnlCopy.Visible = False
            End If
            Session("dtAccCheckListDetail") = Nothing
            Session("dtAccCheckListThreasDtl") = Nothing
            Session("dtZipperCheckListDetail") = Nothing
            txtThreadQtyPcs.Text = 0
            txtMtrCon.Text = 0
            txtCons.Text = 0
            GetMasterData()
            txtMtrCon.Text = 1000
            BindAssortColor(lJobOrderID)
            BindAssortColorZipper(lJobOrderID)
            BindItemClass()
            BindItemClass2()
            Dim dtcheck As DataTable = objAccCheckListMst.CheckMst(lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID)
            If dtcheck.Rows.Count > 0 Then
                lblAccCheclistMstId.Text = dtcheck.Rows(0)("AccCheckListMstID")
                txtDate.Text = dtcheck.Rows(0)("CheckDate")
                txtRevisedDate.Text = dtcheck.Rows(0)("RevisedDate")
                AccessDtlCheckListEdit()
                ThreadDtlEdit()
                ZipperDtlCheckListEdit()
            End If
            Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheckk.Rows(0)("Department") = "Merchandising" Then
                dgAccCheckList.Columns(2).Visible = False
                dgZipper.Columns(2).Visible = False
            End If
        End If
        PageHeader("CHECK LIST ENTRY FORM")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub BindSeason()
        Try
            Dim dtcmbSeason As DataTable
            dtcmbSeason = ObjCommercialPackingListDtl.GetSeasonsFromJobOrderDatabase
            cmbSeason.DataSource = dtcmbSeason
            cmbSeason.DataTextField = "SeasonName"
            cmbSeason.DataValueField = "SeasonDatabaseID"
            cmbSeason.DataBind()
            cmbSeason.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            BindSrNo()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbSrNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            BindColor()
        Catch ex As Exception
        End Try
    End Sub
    Sub BindSrNo()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetSrnOForCutting(cmbSeason.SelectedValue)
            CMBSRNO.DataSource = dtInvoiceNo
            CMBSRNO.DataTextField = "PONO"
            CMBSRNO.DataValueField = "JobOrderID"
            CMBSRNO.DataBind()
            CMBSRNO.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindColor()
        Try
            Dim dtInvoiceNo As DataTable
            dtInvoiceNo = objSizeRange.GetColorForCutting(cmbSeason.SelectedValue, cmbSrNo.SelectedValue)
            cmbColor.DataSource = dtInvoiceNo
            cmbColor.DataTextField = "BuyerColor"
            cmbColor.DataValueField = "JobOrderDetailID"
            cmbColor.DataBind()
            cmbColor.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCopy.Click
        Try
            Dim dt As DataTable = objAccCheckListMst.CheckAlreadyExistOnCopyCase(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            If dt.Rows.Count > 0 Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("This Sr No And Color Already Exist")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                saveAccCheckListmasterOnCopy()

                'Acc Dtl
                SaveSessionForCopy()
                BindAccessGridForCopy()
                SaveAccCheckListDetailOnCopy()

                'Zipper

                SaveSessionForZipperForCopy()
                BindAccessGridForZipperForCopy()
                SaveZipperCheckListDetailOnCopy()

                'Thread
                SaveSessionForThreadForCopy()
                BindAccessGridForThreadForCopy()
                SaveThreadCheckListDetailOnCopy()
                Response.Redirect("JOProgramView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub saveAccCheckListmasterOnCopy()
        With objAccCheckListMst
           .AccCheckListMstID = 0
            .JoborderID = CMBSRNO.SelectedValue
            .JoborderDetailID = cmbColor.SelectedValue
            Dim dt As DataTable = objAccCheckListMst.GetStyleAssortmentMasterID(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            .StyleAssortmentMasterID = dt.Rows(0)("StyleAssortmentMasterID")
            .CheckDate = txtDate.Text
            .CreationDate = Date.Now
            If txtRevisedDate.Text = "" Then
                .RevisedDate = ""
            Else
                .RevisedDate = txtRevisedDate.Text
            End If
            .SaveAccCheckListMst()
        End With
    End Sub
    Sub SaveSessionForCopy()
        Session("dtAccCheckListDetail") = Nothing
        If (Not CType(Session("dtAccCheckListDetail"), DataTable) Is Nothing) Then
            dtAccCheckListDetail = Session("dtAccCheckListDetail")
        Else
            dtAccCheckListDetail = New DataTable
            With dtAccCheckListDetail
                .Columns.Add("AccCheckListDetailID", GetType(String))
                .Columns.Add("IMSItemId", GetType(String))
                .Columns.Add("IMSItemCategoryID", GetType(String))
                .Columns.Add("ItemCategoryName", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("UsagePC", GetType(String))
                .Columns.Add("Total", GetType(String))
                .Columns.Add("Percent", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("CalQTy", GetType(String))
                .Columns.Add("AssortSize", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("IMSItemClassID", GetType(String))
                .Columns.Add("ItemClassName", GetType(String))
            End With
        End If
        Dim x As Integer
        For x = 0 To dgAccCheckList.Items.Count - 1
            Dr = dtAccCheckListDetail.NewRow()
            Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
            Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
            Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)
            If lblAccCheclistMstIdForEdit.Text = 0 Then
                Dr("AccCheckListDetailID") = 0
            Else
                Dr("AccCheckListDetailID") = lblAccCheclistMstIdForEdit.Text
            End If
            If lblItemCategoryID.Text = "" Then
                Dr("IMSItemId") = 0
                Dr("IMSItemCategoryID") = 0
                Dr("IMSItemClassID") = 0
                Dr("ItemCategoryName") = ""
                Dr("ItemName") = ""
                Dr("ItemClassName") = ""
            Else
                Dr("IMSItemId") = lblItemID.Text
                Dr("IMSItemCategoryID") = lblItemCategoryID.Text
                Dr("ItemCategoryName") = dgAccCheckList.Items(x).Cells(4).Text
                Dr("ItemName") = dgAccCheckList.Items(x).Cells(5).Text
                Dr("IMSItemClassID") = dgAccCheckList.Items(x).Cells(14).Text
                Dr("ItemClassName") = dgAccCheckList.Items(x).Cells(3).Text
            End If
            Dr("UsagePC") = dgAccCheckList.Items(x).Cells(6).Text
            Dim PerPcsAvg As Decimal = 0
            PerPcsAvg = dgAccCheckList.Items(x).Cells(7).Text
            Dim Percentage As Decimal = 0
            Percentage = dgAccCheckList.Items(x).Cells(8).Text
            Dim Total As Decimal = 0
            Dim OrderQty As Decimal = 0
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            lJobOrderID = Request.QueryString("JobOrderID")
            lJoborderDetailid = Request.QueryString("JoborderDetailid")
            lStyleAssortmentMasterID = Request.QueryString("StyleAssortmentMasterID")
            Dim dt As DataTable = objAccCheckListMst.GetStyleAssortmentMasterID(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            Dim ID As Long = dt.Rows(0)("StyleAssortmentMasterID")
            Dim Size As String = dgAccCheckList.Items(x).Cells(12).Text
            Dim dtcheck As DataTable = objAccCheckListMst.GetStyleAssortmentDetailIDAndAssortQty(CMBSRNO.SelectedValue, cmbColor.SelectedValue, ID, Size)
            Dim dtQty As DataTable = objCuttingProMst.GetData(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            Dim JobOrderDetailQty As Decimal = 0
            JobOrderDetailQty = dtQty.Rows(0)("Quantity")
            If Size = "" Or Size = "&nbsp;" Then
                FormulaQty = JobOrderDetailQty
            Else
                FormulaQty = dtcheck.Rows(0)("TotalQty")
            End If
            If Size = "" Or Size = "&nbsp;" Then
                Total = FormulaQty
            Else
                Total = FormulaQty * Val(PerPcsAvg)
            End If
            Dim extarQty As Decimal = 0
            extarQty = (Val(Total) * Val(Percentage)) / 100
            OrderQty = Val(Total) + extarQty
            Dr("Total") = Total
            Dr("Percent") = Percentage
            Dr("OrderQty") = OrderQty
            Dr("Remarks") = dgAccCheckList.Items(x).Cells(10).Text
            If Size = "" Or Size = "&nbsp;" Then
                Dr("CalQTy") = JobOrderDetailQty
                Dr("AssortSize") = ""
                Dr("StyleAssortmentDetailID") = 0
            Else
                Dr("CalQTy") = dtcheck.Rows(0)("TotalQty")
                Dr("AssortSize") = dgAccCheckList.Items(x).Cells(12).Text
                Dr("StyleAssortmentDetailID") = dtcheck.Rows(0)("StyleAssortmentDetailID")
            End If
            Dr("Description") = "N/A"
            Dr("ItemCodee") = txtItemCode.Text
            dtAccCheckListDetail.Rows.Add(Dr)
        Next
        Session("dtAccCheckListDetail") = dtAccCheckListDetail
        BindAccessGridForCopy()
    End Sub
    Sub BindAccessGridForCopy()
        Try
            If dtAccCheckListDetail.Rows.Count > 0 Then
                dgAccCheckList.DataSource = dtAccCheckListDetail
                dgAccCheckList.DataBind()
                dgAccCheckList.Visible = True
                Dim x As Integer = 0
                For x = 0 To dgAccCheckList.Items.Count - 1
                    Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
                    Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
                    Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)
                    txtItemCode.Text = dtAccCheckListDetail.Rows(x)("ItemCodee")
                    lblItemID.Text = dtAccCheckListDetail.Rows(x)("IMSItemId")
                    lblItemCategoryID.Text = dtAccCheckListDetail.Rows(x)("IMSItemCategoryID")
                Next
            Else
                dgAccCheckList.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveAccCheckListDetailOnCopy()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckList.Items.Count - 1
                Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
                Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
                Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)
                With objAccCheckListDtl
                    If Type = "Copy" Then
                        .AccCheckListDetailID = 0
                    Else
                        .AccCheckListDetailID = dgAccCheckList.Items(x).Cells(0).Text
                    End If
                    .AccCheckListMstID = objAccCheckListMst.GetID
                    .IMSItemId = lblItemID.Text
                    .IMSItemCategoryID = lblItemCategoryID.Text
                    .Description = "N/A"
                    .UsagePC = dgAccCheckList.Items(x).Cells(6).Text
                    .Total = dgAccCheckList.Items(x).Cells(7).Text
                    .Percent = dgAccCheckList.Items(x).Cells(8).Text
                    .OrderQty = dgAccCheckList.Items(x).Cells(9).Text
                    .Remarks = dgAccCheckList.Items(x).Cells(10).Text
                    .CalQTy = dgAccCheckList.Items(x).Cells(11).Text
                    .AssortSize = dgAccCheckList.Items(x).Cells(12).Text
                    .StyleAssortmentDetailID = dgAccCheckList.Items(x).Cells(13).Text
                    .ItemCode = txtItemCode.Text
                    .IMSItemClassID = dgAccCheckList.Items(x).Cells(14).Text
                    .SaveAccCheckListDetail()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSessionForZipperForCopy()
        Session("dtZipperCheckListDetail") = Nothing
        If (Not CType(Session("dtZipperCheckListDetail"), DataTable) Is Nothing) Then
            dtZipperCheckListDetail = Session("dtZipperCheckListDetail")
        Else
            dtZipperCheckListDetail = New DataTable
            With dtZipperCheckListDetail
                .Columns.Add("ZipperCheckListDetailID", GetType(String))
                .Columns.Add("IMSItemId", GetType(String))
                .Columns.Add("IMSItemCategoryID", GetType(String))
                .Columns.Add("ItemCategoryName", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("UsagePC", GetType(String))
                .Columns.Add("Total", GetType(String))
                .Columns.Add("Percent", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("CalQTy", GetType(String))
                .Columns.Add("AssortSize", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ColorZippersizes", GetType(String))
                .Columns.Add("IMSItemClassID", GetType(String))
                .Columns.Add("ItemClassName", GetType(String))
            End With
        End If
        Dim x As Integer
        For x = 0 To dgZipper.Items.Count - 1
            Dr = dtZipperCheckListDetail.NewRow()
            Dim lblItemID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemID"), Label)
            Dim lblItemCategoryID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemCategoryID"), Label)
            Dim txtItemCode As TextBox = DirectCast(dgZipper.Items(x).FindControl("txtItemCodeForZipper"), TextBox)
            If lblZipperCheclistMstIdForEdit.Text = 0 Then
                Dr("ZipperCheckListDetailID") = 0
            Else
                Dr("ZipperCheckListDetailID") = lblZipperCheclistMstIdForEdit.Text
            End If
            If lblItemCategoryID.Text = "" Then
                Dr("IMSItemId") = 0
                Dr("IMSItemCategoryID") = 0
                Dr("IMSItemClassID") = 0
                Dr("ItemCategoryName") = ""
                Dr("ItemName") = ""
                Dr("ItemClassName") = ""
            Else
                Dr("IMSItemId") = lblItemID.Text
                Dr("IMSItemCategoryID") = lblItemCategoryID.Text
                Dr("ItemCategoryName") = dgZipper.Items(x).Cells(4).Text
                Dr("ItemName") = dgZipper.Items(x).Cells(5).Text
                Dr("IMSItemClassID") = dgZipper.Items(x).Cells(15).Text
                Dr("ItemClassName") = dgZipper.Items(x).Cells(3).Text
            End If
            Dr("UsagePC") = dgZipper.Items(x).Cells(6).Text
            Dim PerPcsAvg As Decimal = 0
            PerPcsAvg = dgZipper.Items(x).Cells(6).Text
            Dim Percentage As Decimal = 0
            Percentage = dgZipper.Items(x).Cells(8).Text
            Dim Total As Decimal = 0
            Dim OrderQty As Decimal = 0
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            lJobOrderID = Request.QueryString("JobOrderID")
            lJoborderDetailid = Request.QueryString("JoborderDetailid")
            lStyleAssortmentMasterID = Request.QueryString("StyleAssortmentMasterID")
            Dim dt As DataTable = objAccCheckListMst.GetStyleAssortmentMasterID(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            Dim ID As Long = dt.Rows(0)("StyleAssortmentMasterID")
            Dim Size As String = dgZipper.Items(x).Cells(12).Text
            Dim dtcheck As DataTable = objAccCheckListMst.GetStyleAssortmentDetailIDAndAssortQty(CMBSRNO.SelectedValue, cmbColor.SelectedValue, ID, Size)
            Dim dtQty As DataTable = objCuttingProMst.GetData(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            Dim JobOrderDetailQty As Decimal = 0
            JobOrderDetailQty = dtQty.Rows(0)("Quantity")
            If Size = "" Or Size = "&nbsp;" Then
                FormulaQty = JobOrderDetailQty
            Else
                FormulaQty = dtcheck.Rows(0)("TotalQty")
            End If
            If Size = "" Or Size = "&nbsp;" Then

                Total = FormulaQty
            Else
                Total = FormulaQty * Val(PerPcsAvg)
            End If
            Dim extarQty As Decimal = 0
            extarQty = (Val(Total) * Val(Percentage)) / 100
            OrderQty = Val(Total) + extarQty
            Dr("Total") = Total
            Dr("Percent") = Percentage
            Dr("OrderQty") = OrderQty
            Dr("Remarks") = dgZipper.Items(x).Cells(10).Text
            Dr("ColorZippersizes") = dgZipper.Items(x).Cells(14).Text
            If Size = "" Or Size = "&nbsp;" Then
                Dr("CalQTy") = JobOrderDetailQty
                Dr("AssortSize") = ""
                Dr("StyleAssortmentDetailID") = 0
            Else
                Dr("CalQTy") = dtcheck.Rows(0)("TotalQty")
                Dr("AssortSize") = dgZipper.Items(x).Cells(12).Text
                Dr("StyleAssortmentDetailID") = dtcheck.Rows(0)("StyleAssortmentDetailID")
            End If
            Dr("Description") = "N/A"
            Dr("ItemCodee") = txtItemCode.Text
            dtZipperCheckListDetail.Rows.Add(Dr)
        Next
        Session("dtZipperCheckListDetail") = dtZipperCheckListDetail
        BindAccessGridForZipper()
    End Sub
    Sub BindAccessGridForZipperForCopy()
        Try
            If dtZipperCheckListDetail.Rows.Count > 0 Then
                dgZipper.DataSource = dtZipperCheckListDetail
                dgZipper.DataBind()
                dgZipper.Visible = True
                Dim x As Integer = 0
                For x = 0 To dgZipper.Items.Count - 1
                    Dim lblItemID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemID"), Label)
                    Dim lblItemCategoryID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemCategoryID"), Label)
                    Dim txtItemCode As TextBox = DirectCast(dgZipper.Items(x).FindControl("txtItemCodeForZipper"), TextBox)
                    lblItemID.Text = dtZipperCheckListDetail.Rows(x)("IMSItemId")
                    lblItemCategoryID.Text = dtZipperCheckListDetail.Rows(x)("IMSItemCategoryID")
                Next
            Else
                dgZipper.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveZipperCheckListDetailOnCopy()
        Try
            Dim x As Integer = 0
            For x = 0 To dgZipper.Items.Count - 1
                Dim lblItemID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemID"), Label)
                Dim lblItemCategoryID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemCategoryID"), Label)
                Dim txtItemCode As TextBox = DirectCast(dgZipper.Items(x).FindControl("txtItemCodeForZipper"), TextBox)
                With objZipperCheckListDtl
                    If Type = "Copy" Then
                        .ZipperCheckListDetailID = 0
                    Else
                        .ZipperCheckListDetailID = dgZipper.Items(x).Cells(0).Text
                    End If
                    .AccCheckListMstID = objAccCheckListMst.GetID
                    .IMSItemId = lblItemID.Text
                    .IMSItemCategoryID = lblItemCategoryID.Text
                    .Description = "N/A"
                    .UsagePC = dgZipper.Items(x).Cells(6).Text
                    .Total = dgZipper.Items(x).Cells(7).Text
                    .Percent = dgZipper.Items(x).Cells(8).Text
                    .OrderQty = dgZipper.Items(x).Cells(9).Text
                    .Remarks = dgZipper.Items(x).Cells(10).Text
                    .CalQTy = dgZipper.Items(x).Cells(11).Text
                    .AssortSize = dgZipper.Items(x).Cells(12).Text
                    .StyleAssortmentDetailID = dgZipper.Items(x).Cells(13).Text
                    .ColorZippersizes = dgZipper.Items(x).Cells(14).Text
                    .IMSItemClassID = dgZipper.Items(x).Cells(15).Text
                    .ItemCode = txtItemCode.Text
                    .Save()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSessionForThreadForCopy()
        Session("dtAccCheckListThreasDtl") = Nothing
        If (Not CType(Session("dtAccCheckListThreasDtl"), DataTable) Is Nothing) Then
            dtAccCheckListThreasDtl = Session("dtAccCheckListThreasDtl")
        Else
            dtAccCheckListThreasDtl = New DataTable
            With dtAccCheckListThreasDtl
                .Columns.Add("ThreadCheckListID", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ThreadColor", GetType(String))
                .Columns.Add("JPShade", GetType(String))
                .Columns.Add("JPCode", GetType(String))
                .Columns.Add("Count", GetType(String))
                .Columns.Add("Mtr1con", GetType(String))
                .Columns.Add("OrderQtyForThread", GetType(String))
                .Columns.Add("PerForThread", GetType(String))
                .Columns.Add("ThreadQtyPcs", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("RCones", GetType(String))
                .Columns.Add("ItemID", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
            End With
        End If
        Dim x As Integer
        For x = 0 To dgAccCheckListThread.Items.Count - 1
            Dr = dtAccCheckListThreasDtl.NewRow()
            If lblThreadCheckListID.Text = 0 Then
                Dr("ThreadCheckListID") = 0
            Else
                Dr("ThreadCheckListID") = lblThreadCheckListID.Text
            End If
            Dr("Description") = "N/A" 'dgAccCheckListThread.Items(x).Cells(1).Text
            Dr("ThreadColor") = dgAccCheckListThread.Items(x).Cells(2).Text
            Dr("JPShade") = dgAccCheckListThread.Items(x).Cells(3).Text
            Dr("JPCode") = dgAccCheckListThread.Items(x).Cells(4).Text
            Dr("Count") = dgAccCheckListThread.Items(x).Cells(5).Text
            Dr("Mtr1con") = dgAccCheckListThread.Items(x).Cells(6).Text
            Dim dtQty As DataTable = objCuttingProMst.GetData(CMBSRNO.SelectedValue, cmbColor.SelectedValue)
            Dim JobOrderDetailQty As Decimal = 0
            JobOrderDetailQty = dtQty.Rows(0)("Quantity")
            Dr("OrderQtyForThread") = JobOrderDetailQty
            Dr("PerForThread") = dgAccCheckListThread.Items(x).Cells(8).Text
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            Dim extarQty As Decimal = 0
            Dim Per As Decimal = 0
            Dim ThreadQty As Decimal = 0
            Per = dgAccCheckListThread.Items(x).Cells(8).Text
            extarQty = (Val(JobOrderDetailQty) * Val(Per)) / 100
            ThreadQty = Math.Round(Val(JobOrderDetailQty) + extarQty, 0)
            Dr("ThreadQtyPcs") = ThreadQty
            Dr("Consumption") = dgAccCheckListThread.Items(x).Cells(10).Text
            Dr("RCones") = dgAccCheckListThread.Items(x).Cells(11).Text
            Dr("ItemID") = dgAccCheckListThread.Items(x).Cells(12).Text
            Dr("ItemCodee") = dgAccCheckListThread.Items(x).Cells(13).Text
            dtAccCheckListThreasDtl.Rows.Add(Dr)
        Next
        Session("dtAccCheckListThreasDtl") = dtAccCheckListThreasDtl
        BindAccessGridForThreadForCopy()
    End Sub
    Sub BindAccessGridForThreadForCopy()
        Try
           If dtAccCheckListThreasDtl.Rows.Count > 0 Then
                dgAccCheckListThread.DataSource = dtAccCheckListThreasDtl
                dgAccCheckListThread.DataBind()
                dgAccCheckListThread.Visible = True
            Else
                dgAccCheckListThread.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveThreadCheckListDetailOnCopy()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckListThread.Items.Count - 1
                With objThreadChckList
                    If Type = "Copy" Then
                        .ThreadCheckListID = 0
                    Else
                        .ThreadCheckListID = dgAccCheckListThread.Items(x).Cells(0).Text
                    End If
                    .AccCheckListMstID = objAccCheckListMst.GetID
                    .Description = "N/A" ' dgAccCheckListThread.Items(x).Cells(1).Text
                    .ThreadColor = dgAccCheckListThread.Items(x).Cells(2).Text.Replace("&nbsp;", "")
                    .JPShade = dgAccCheckListThread.Items(x).Cells(3).Text.Replace("&nbsp;", "")
                    .JPCode = dgAccCheckListThread.Items(x).Cells(4).Text.Replace("&nbsp;", "")
                    .Count = dgAccCheckListThread.Items(x).Cells(5).Text.Replace("&nbsp;", "")
                    .Mtr1con = dgAccCheckListThread.Items(x).Cells(6).Text
                    .OrderQtyForThread = dgAccCheckListThread.Items(x).Cells(7).Text
                    .PerForThread = dgAccCheckListThread.Items(x).Cells(8).Text
                    .ThreadQtyPcs = dgAccCheckListThread.Items(x).Cells(9).Text
                    .Consumption = dgAccCheckListThread.Items(x).Cells(10).Text
                    .RCones = dgAccCheckListThread.Items(x).Cells(11).Text
                    .ItemID = dgAccCheckListThread.Items(x).Cells(12).Text
                    .SaveThreadCheckList()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtMtrCon_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtMtrCon.TextChanged
        Try
            txtCones.Text = Math.Round(Val(txtThreadQtyPcs.Text) * Val(txtCons.Text) / Val(txtMtrCon.Text), 2)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtThreadQtyPcs_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtThreadQtyPcs.TextChanged
        Try
            txtCones.Text = Math.Round(Val(txtThreadQtyPcs.Text) * Val(txtCons.Text) / Val(txtMtrCon.Text), 2)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtCons_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCons.TextChanged
        Try
            txtCones.Text = Math.Round(Val(txtThreadQtyPcs.Text) * Val(txtCons.Text) / Val(txtMtrCon.Text), 2)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbAssortColorZipper_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dtsizewiseqty As New DataTable
            dtsizewiseqty = objAccCheckListMst.SizewiseQTY(cmbAssortColorZipper.SelectedValue)
            If dtsizewiseqty.Rows.Count > 0 Then
                txtAssortQTYZipper.Text = dtsizewiseqty.Rows(0)("TotalQty").ToString
            Else
            End If
            If cmbAssortColorZipper.SelectedIndex = 0 Then
                txtAssortQTYZipper.Text = 0
            Else
            End If
            CheckTextZipper()
            If txtPerPcsAvgZipper.Text <> "" And txtQtyZipper.Text <> "" And txtPercentageZipper.Text <> "" And txtOrderQtyZipper.Text <> "" Then
                Dim Percentageqty As Decimal = 0
                Dim FormulaQty As Decimal = 0
                If txtPerPcsAvgZipper.Text = "" Then
                    txtPerPcsAvgZipper.Text = 1
                End If
                If cmbAssortColorZipper.SelectedIndex > 0 Then
                    FormulaQty = txtAssortQTYZipper.Text
                Else
                    FormulaQty = txtQuantity.Text
                End If
                If cmbAssortColorZipper.SelectedIndex = 0 Then
                    txtQtyZipper.Text = FormulaQty * Val(txtPerPcsAvgZipper.Text)
                Else
                    txtQtyZipper.Text = FormulaQty
                End If
                If txtQtyZipper.Text <> "" And txtPercentageZipper.Text <> "" Then
                    Dim extarQty As Decimal = 0
                    extarQty = (Val(txtQtyZipper.Text) * Val(txtPercentageZipper.Text)) / 100
                    txtOrderQtyZipper.Text = Math.Round(Val(txtQtyZipper.Text) + extarQty, 2)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtPercentageZipper_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercentageZipper.TextChanged
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            If txtPerPcsAvgZipper.Text = "" Then
                txtPerPcsAvgZipper.Text = 1
            End If
            If cmbAssortColorZipper.SelectedIndex > 0 Then
                FormulaQty = txtAssortQTYZipper.Text
            Else
                FormulaQty = txtQuantity.Text
            End If
            If cmbAssortColorZipper.SelectedIndex = 0 Then
                txtQtyZipper.Text = FormulaQty * Val(txtPerPcsAvgZipper.Text)
            Else
            End If
            If txtQtyZipper.Text <> "" And txtPercentageZipper.Text <> "" Then
                Dim extarQty As Decimal = 0
                extarQty = (Val(txtQtyZipper.Text) * Val(txtPercentageZipper.Text)) / 100
                txtOrderQtyZipper.Text = Math.Round(Val(txtQtyZipper.Text) + extarQty, 0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtPerPcsAvgZipper_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPerPcsAvgZipper.TextChanged
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            If txtPerPcsAvgZipper.Text = "" Then
                txtPerPcsAvgZipper.Text = 1
            End If
            If cmbAssortColorZipper.SelectedIndex > 0 Then
                FormulaQty = txtAssortQTYZipper.Text
            Else
                FormulaQty = txtQuantity.Text
            End If
            If cmbAssortColorZipper.SelectedIndex = 0 Then
                txtQtyZipper.Text = FormulaQty * Val(txtPerPcsAvgZipper.Text)
            Else
                txtQtyZipper.Text = FormulaQty
            End If
            If txtQtyZipper.Text <> "" And txtPercentageZipper.Text <> "" Then
                Dim extarQty As Decimal = 0
                extarQty = (Val(txtQtyZipper.Text) * Val(txtPercentageZipper.Text)) / 100
                txtOrderQtyZipper.Text = Val(txtQtyZipper.Text) + extarQty
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtQtyZipper_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtQtyZipper.TextChanged
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            If txtPerPcsAvgZipper.Text = "" Then
                txtPerPcsAvgZipper.Text = 1
            End If
            If cmbAssortColorZipper.SelectedIndex > 0 Then
                FormulaQty = txtAssortQTYZipper.Text
            Else
                FormulaQty = txtQuantity.Text
            End If
            If cmbAssortColorZipper.SelectedIndex = 0 Then
                txtQtyZipper.Text = FormulaQty * Val(txtPerPcsAvgZipper.Text)
            Else
            End If
            If txtQtyZipper.Text <> "" And txtPercentageZipper.Text <> "" Then
                Dim extarQty As Decimal = 0
                extarQty = (Val(txtQtyZipper.Text) * Val(txtPercentageZipper.Text)) / 100
                txtOrderQtyZipper.Text = Val(txtQtyZipper.Text) + extarQty
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtItemCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        For x = 0 To dgAccCheckList.Items.Count - 1
            Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
            Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
            Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)

            Dim dt As DataTable = objAccCheckListDtl.GetItemIDAndItemCategoryID(txtItemCode.Text)
            If dt.Rows.Count > 0 Then
                lblItemID.Text = dt.Rows(0)("IMSItemID")
                lblItemCategoryID.Text = dt.Rows(0)("ImsItemCategoryID")
            End If
        Next
    End Sub
    Protected Sub txtItemCodeForZipper_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Integer = 0
        For x = 0 To dgAccCheckList.Items.Count - 1
            Dim lblItemID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemID"), Label)
            Dim lblItemCategoryID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemCategoryID"), Label)
            Dim txtItemCode As TextBox = DirectCast(dgZipper.Items(x).FindControl("txtItemCodeForZipper"), TextBox)
            Dim dt As DataTable = objAccCheckListDtl.GetItemIDAndItemCategoryID(txtItemCode.Text)
            If dt.Rows.Count > 0 Then
                lblItemID.Text = dt.Rows(0)("IMSItemID")
                lblItemCategoryID.Text = dt.Rows(0)("ImsItemCategoryID")
            End If
        Next
    End Sub
    Protected Sub TXTThreadsCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXTThreadsCode.TextChanged
        Try
            Dim DT As DataTable = objThreadChckList.GetAccID(TXTThreadsCode.Text)
            lblAccItemID.Text = DT.Rows(0)("IMSItemID")
            txtDesc.Text = DT.Rows(0)("ItemName")
            txtJPShade.Text = DT.Rows(0)("Shade")
            txtThreadColor.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Sub AccessDtlCheckListEdit()
        Dim dtAccsDtl As DataTable = objAccCheckListDtl.GetAccDtlNew(lblAccCheclistMstId.Text)
        If dtAccsDtl.Rows.Count > 0 Then
            dtAccCheckListDetail = dtAccsDtl
            Session("dtAccCheckListDetail") = dtAccsDtl
            BindAccessGrid()
        End If
    End Sub
    Protected Sub dgZipper_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgZipper.ItemCommand
        Try
            Select Case e.CommandName
                Case "Delete"
                    dtZipperCheckListDetail = CType(Session("dtZipperCheckListDetail"), DataTable)
                    If (Not dtZipperCheckListDetail Is Nothing) Then
                        If (dtZipperCheckListDetail.Rows.Count > 0) Then
                            Dim ZipperCheckListDetailID As Integer = dtZipperCheckListDetail.Rows(e.Item.ItemIndex)("ZipperCheckListDetailID")
                            Dim dt As DataTable = objAccCheckListDtl.CheckAlreadyExistAccCheckListZipperIDinCost(ZipperCheckListDetailID)
                            If dt.Rows.Count > 0 Then
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Used In Costing")
                            Else
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                                dtZipperCheckListDetail.Rows.RemoveAt(e.Item.ItemIndex)
                                Session("dtZipperCheckListDetail") = dtZipperCheckListDetail
                                objAccCheckListDtl.DeleteCheckListZipperDetail(ZipperCheckListDetailID)
                                BindAccessGridForZipper()
                            End If
                        Else
                        End If
                    End If
                Case "Edit"
                    dtZipperCheckListDetail = CType(Session("dtZipperCheckListDetail"), DataTable)
                    If (Not dtZipperCheckListDetail Is Nothing) Then
                        If (dtZipperCheckListDetail.Rows.Count > 0) Then
                            Dim IssueDetailId As Integer = dgZipper.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTableForZipperCheckList(e.Item.ItemIndex)
                            dtZipperCheckListDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            BindAccessGridForZipper()
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTableForZipperCheckList(ByVal dtrowNo As Long)
        Try
            BindZipperCategory()
            If dtZipperCheckListDetail.Rows(dtrowNo)("IMSItemCategoryID") = 0 Then
                cmbZipperCat.SelectedValue = 0
            Else
                cmbZipperCat.SelectedValue = dtZipperCheckListDetail.Rows(dtrowNo)("IMSItemCategoryID")
                cmbZipperCat.SelectedItem.Text = dtZipperCheckListDetail.Rows(dtrowNo)("ItemCategoryName")
            End If
           
            If cmbZipperCat.SelectedItem.Text = "BUTTON" Or cmbZipperCat.SelectedItem.Text = "EILETS" Then
                BindProductNameForZipper(cmbZipperCat.SelectedValue)
            Else
                BindProductNameForZipper(cmbZipperCat.SelectedValue)
            End If
            lblZipperCheclistMstIdForEdit.Text = dtZipperCheckListDetail.Rows(dtrowNo)("ZipperCheckListDetailID")
            cmbZipperNameZipper.SelectedValue = dtZipperCheckListDetail.Rows(dtrowNo)("IMSItemId")
            txtPerPcsAvgZipper.Text = dtZipperCheckListDetail.Rows(dtrowNo)("UsagePC")
            txtQtyZipper.Text = dtZipperCheckListDetail.Rows(dtrowNo)("Total")
            txtPercentageZipper.Text = dtZipperCheckListDetail.Rows(dtrowNo)("Percent")
            txtOrderQtyZipper.Text = dtZipperCheckListDetail.Rows(dtrowNo)("OrderQty")
            If dtZipperCheckListDetail.Rows(dtrowNo)("Remarks") = "&nbsp;" Then
                txtRemarksZipper.Text = ""
            Else
                txtRemarksZipper.Text = dtZipperCheckListDetail.Rows(dtrowNo)("Remarks")
            End If
            txtAssortQTYZipper.Text = dtZipperCheckListDetail.Rows(dtrowNo)("CalQTy")
            If dtZipperCheckListDetail.Rows(dtrowNo)("AssortSize") = "&nbsp;" Then
                BindAssortColorZipper(lJobOrderID)
            Else
                cmbAssortColorZipper.SelectedItem.Text = dtZipperCheckListDetail.Rows(dtrowNo)("AssortSize")
            End If
            cmbAssortColorZipper.SelectedValue = dtZipperCheckListDetail.Rows(dtrowNo)("StyleAssortmentDetailID")
            If dtZipperCheckListDetail.Rows(dtrowNo)("Description") = "&nbsp;" Then
                txtDescriptionZipper.Text = ""
            Else
                txtDescriptionZipper.Text = "N/A" ' dtZipperCheckListDetail.Rows(dtrowNo)("Description")
            End If
            txtColorZippersizes.Text = dtZipperCheckListDetail.Rows(dtrowNo)("ColorZippersizes")
        Catch ex As Exception
        End Try
    End Sub
    Sub ThreadDtlEdit()
        Dim dtThreadDtl As DataTable = objThreadChckList.GetAccThreadDtl(lblAccCheclistMstId.Text)
        If dtThreadDtl.Rows.Count > 0 Then
            dtAccCheckListThreasDtl = dtThreadDtl
            Session("dtAccCheckListThreasDtl") = dtThreadDtl
            BindAccessThreadGrid()
        End If
    End Sub
    Sub GetMasterData()
        Dim dtMasterData As New DataTable
        Try
            dtMasterData = objCuttingProMst.GetData(lJobOrderID, lJoborderDetailid)
            If dtMasterData.Rows.Count > 0 Then
                txtStyle.Text = dtMasterData.Rows(0)("Style")
                txtSRNo.Text = dtMasterData.Rows(0)("PONo") '("SRNo")
                txtCustomer.Text = dtMasterData.Rows(0)("CustomerName")
                txtItem.Text = dtMasterData.Rows(0)("ItemDesc")
                txtFabricContent.Text = dtMasterData.Rows(0)("Content")
                txtQuantity.Text = dtMasterData.Rows(0)("Quantity")
                txtCustColor.Text = dtMasterData.Rows(0)("Colorr")
                txtSeason.Text = dtMasterData.Rows(0)("SeasonName")
                txtOrderQtyForThread.Text = dtMasterData.Rows(0)("Quantity")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindAssortColor(ByVal lJoborderid As Long)
        Try
            Dim DtB As DataTable
            DtB = objAccCheckListMst.GetAllStyleAssortColor(lJoborderid, lJoborderDetailid)
            If cmbAssortColor IsNot Nothing Then
                cmbAssortColor.DataSource = DtB
                cmbAssortColor.DataTextField = "TransferLabel"
                cmbAssortColor.DataValueField = "StyleAssortmentDetailID" '   
                cmbAssortColor.DataBind()
                cmbAssortColor.DataSource = DtB
                cmbAssortColor.Items.Insert(0, New ListItem("Select", "0"))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindAssortColorZipper(ByVal lJoborderid As Long)
        Try
            Dim DtB As DataTable
            DtB = objAccCheckListMst.GetAllStyleAssortColor(lJoborderid, lJoborderDetailid)
            If cmbAssortColorZipper IsNot Nothing Then
                cmbAssortColorZipper.DataSource = DtB
                cmbAssortColorZipper.DataTextField = "TransferLabel"
                cmbAssortColorZipper.DataValueField = "StyleAssortmentDetailID" '   
                cmbAssortColorZipper.DataBind()
                cmbAssortColorZipper.DataSource = DtB
                cmbAssortColorZipper.Items.Insert(0, New ListItem("Select", "0"))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgAccCheckList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAccCheckList.ItemCommand
        Try
            Select Case e.CommandName
                Case "Delete"
                    dtAccCheckListDetail = CType(Session("dtAccCheckListDetail"), DataTable)
                    If (Not dtAccCheckListDetail Is Nothing) Then
                        If (dtAccCheckListDetail.Rows.Count > 0) Then
                            Dim AccCheckListDetailID As Integer = dtAccCheckListDetail.Rows(e.Item.ItemIndex)("AccCheckListDetailID")

                            Dim dt As DataTable = objAccCheckListDtl.CheckAlreadyExistAccCheckListDtlIDinCost(AccCheckListDetailID)
                            If dt.Rows.Count > 0 Then
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Used In Costing")
                            Else
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                                dtAccCheckListDetail.Rows.RemoveAt(e.Item.ItemIndex)
                                Session("dtAccCheckListDetail") = dtAccCheckListDetail
                                objAccCheckListDtl.DeleteCheckListAccessDetail(AccCheckListDetailID)
                                BindAccessGrid()
                            End If
                        Else
                        End If
                    End If
                Case "Edit"
                    dtAccCheckListDetail = CType(Session("dtAccCheckListDetail"), DataTable)
                    If (Not dtAccCheckListDetail Is Nothing) Then
                        If (dtAccCheckListDetail.Rows.Count > 0) Then
                            Dim IssueDetailId As Integer = dgAccCheckList.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTableForAccCheckList(e.Item.ItemIndex)
                            dtAccCheckListDetail.Rows.RemoveAt(e.Item.ItemIndex)
                            BindAccessGrid()

                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTableForAccCheckList(ByVal dtrowNo As Long)
        Try
            BindAccCategory()
            If dtAccCheckListDetail.Rows(dtrowNo)("IMSItemCategoryID") = 0 Then
            Else
                cmbAccessorieseType.SelectedValue = dtAccCheckListDetail.Rows(dtrowNo)("IMSItemCategoryID")
                cmbAccessorieseType.SelectedItem.Text = dtAccCheckListDetail.Rows(dtrowNo)("ItemCategoryName")
                If cmbAccessorieseType.SelectedItem.Text = "BUTTON" Or cmbAccessorieseType.SelectedItem.Text = "EILETS" Then
                    BindProductName(cmbAccessorieseType.SelectedValue)
                Else
                    BindProductName(cmbAccessorieseType.SelectedValue)
                End If
            End If
            lblAccCheclistMstIdForEdit.Text = dtAccCheckListDetail.Rows(dtrowNo)("AccCheckListDetailID")
            cmbAccessoriese.SelectedValue = dtAccCheckListDetail.Rows(dtrowNo)("IMSItemId")
            txtPerPcsAvg.Text = dtAccCheckListDetail.Rows(dtrowNo)("UsagePC")
            txtQty.Text = dtAccCheckListDetail.Rows(dtrowNo)("Total")
            txtPercentage.Text = dtAccCheckListDetail.Rows(dtrowNo)("Percent")
            txtOrderQty.Text = dtAccCheckListDetail.Rows(dtrowNo)("OrderQty")
            If dtAccCheckListDetail.Rows(dtrowNo)("Remarks") = "&nbsp;" Then
                txtRemarks.Text = ""
            Else
                txtRemarks.Text = dtAccCheckListDetail.Rows(dtrowNo)("Remarks")
            End If
            txtdtlAssortQty.Text = dtAccCheckListDetail.Rows(dtrowNo)("CalQTy")
            If dtAccCheckListDetail.Rows(dtrowNo)("AssortSize") = "&nbsp;" Then
                BindAssortColor(lJobOrderID)
            Else
                cmbAssortColor.SelectedItem.Text = dtAccCheckListDetail.Rows(dtrowNo)("AssortSize")
            End If
            cmbAssortColor.SelectedValue = dtAccCheckListDetail.Rows(dtrowNo)("StyleAssortmentDetailID")
            If dtAccCheckListDetail.Rows(dtrowNo)("Description") = "&nbsp;" Then
                txtDescription.Text = ""
            Else
                txtDescription.Text = "N/A" 'dtAccCheckListDetail.Rows(dtrowNo)("Description")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbAssortColor_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim dtsizewiseqty As New DataTable
            dtsizewiseqty = objAccCheckListMst.SizewiseQTY(cmbAssortColor.SelectedValue)
            If dtsizewiseqty.Rows.Count > 0 Then
                txtdtlAssortQty.Text = dtsizewiseqty.Rows(0)("TotalQty").ToString
            Else
            End If
            If cmbAssortColor.SelectedIndex = 0 Then
                txtdtlAssortQty.Text = 0
            Else
            End If
            CheckText()
            If txtPerPcsAvg.Text <> "" And txtQty.Text <> "" And txtPercentage.Text <> "" And txtOrderQty.Text <> "" Then
                Dim Percentageqty As Decimal = 0
                Dim FormulaQty As Decimal = 0
                If txtPerPcsAvg.Text = "" Then
                    txtPerPcsAvg.Text = 1
                End If
                If cmbAssortColor.SelectedIndex > 0 Then
                    FormulaQty = txtdtlAssortQty.Text
                Else
                    FormulaQty = txtQuantity.Text
                End If
                If cmbAssortColor.SelectedIndex = 0 Then
                    txtQty.Text = FormulaQty * Val(txtPerPcsAvg.Text)
                Else
                    txtQty.Text = FormulaQty
                End If
                If txtQty.Text <> "" And txtPercentage.Text <> "" Then
                    Dim extarQty As Decimal = 0
                    extarQty = (Val(txtQty.Text) * Val(txtPercentage.Text)) / 100
                    txtOrderQty.Text = Math.Round(Val(txtQty.Text) + extarQty, 2)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtPerPcsAvg_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            If txtPerPcsAvg.Text = "" Then
                txtPerPcsAvg.Text = 1
            End If
            If cmbAssortColor.SelectedIndex > 0 Then
                FormulaQty = txtdtlAssortQty.Text
            Else
                FormulaQty = txtQuantity.Text
            End If
            If cmbAssortColor.SelectedIndex = 0 Then
                txtQty.Text = FormulaQty * Val(txtPerPcsAvg.Text)
            Else
                txtQty.Text = FormulaQty

            End If
            If txtQty.Text <> "" And txtPercentage.Text <> "" Then
                Dim extarQty As Decimal = 0
                extarQty = (Val(txtQty.Text) * Val(txtPercentage.Text)) / 100
                txtOrderQty.Text = Val(txtQty.Text) + extarQty
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtPercentage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPercentage.TextChanged
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            If txtPerPcsAvg.Text = "" Then
                txtPerPcsAvg.Text = 1
            End If
            If cmbAssortColor.SelectedIndex > 0 Then
                FormulaQty = txtdtlAssortQty.Text
            Else
                FormulaQty = txtQuantity.Text
            End If
            If cmbAssortColor.SelectedIndex = 0 Then
                txtQty.Text = FormulaQty * Val(txtPerPcsAvg.Text)
            Else
            End If
            If txtQty.Text <> "" And txtPercentage.Text <> "" Then
                Dim extarQty As Decimal = 0
                extarQty = (Val(txtQty.Text) * Val(txtPercentage.Text)) / 100
                txtOrderQty.Text = Math.Round(Val(txtQty.Text) + extarQty, 0)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub CheckText()
        If cmbAssortColor.SelectedIndex = 0 Then
            txtQty.ReadOnly = True
            txtOrderQty.ReadOnly = True
        Else
            txtQty.ReadOnly = False
            txtOrderQty.ReadOnly = True
        End If
    End Sub
    Sub CheckTextZipper()
        If cmbAssortColorZipper.SelectedIndex = 0 Then
            txtQtyZipper.ReadOnly = True
            txtOrderQtyZipper.ReadOnly = True
        Else
            txtQtyZipper.ReadOnly = False
            txtOrderQtyZipper.ReadOnly = True
        End If
    End Sub
    Sub BindItemClass()
        Dim dt As DataTable
        Try
            dt = objAccCheckListMst.GetItemClass()
            ddlItemClass.DataSource = dt
            ddlItemClass.DataTextField = "ItemClassName"
            ddlItemClass.DataValueField = "IMSItemClassID"
            ddlItemClass.DataBind()
            ddlItemClass.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindItemClass2()
        Dim dt As DataTable
        Try
            dt = objAccCheckListMst.GetItemClass()
            ddlItemClass2.DataSource = dt
            ddlItemClass2.DataTextField = "ItemClassName"
            ddlItemClass2.DataValueField = "IMSItemClassID"
            ddlItemClass2.DataBind()
            ddlItemClass2.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub BindAccCategory()
        Dim dt As DataTable
        Try
            dt = objAccCheckListMst.GetAccCategory(ddlItemClass.SelectedValue)
            cmbAccessorieseType.DataSource = dt
            cmbAccessorieseType.DataTextField = "ItemCategoryName"
            cmbAccessorieseType.DataValueField = "IMSItemCategoryID"
            cmbAccessorieseType.DataBind()
            cmbAccessorieseType.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Sub ZipperDtlCheckListEdit()
        Dim dtZipperDtl As DataTable = objAccCheckListDtl.GetZipperDtlNew(lblAccCheclistMstId.Text)
        If dtZipperDtl.Rows.Count > 0 Then
            dtZipperCheckListDetail = dtZipperDtl
            Session("dtZipperCheckListDetail") = dtZipperDtl
            BindAccessGridForZipper()
        End If
    End Sub
    Sub BindZipperCategory()
        Dim dt As DataTable
        Try
            dt = objAccCheckListMst.GetAccCategoryForZipper(ddlItemClass2.SelectedValue)
            cmbZipperCat.DataSource = dt
            cmbZipperCat.DataTextField = "ItemCategoryName"
            cmbZipperCat.DataValueField = "IMSItemCategoryID"
            cmbZipperCat.DataBind()
            cmbZipperCat.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub cmbZipperCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbZipperCat.SelectedIndexChanged
        Try
            BindProductNameForZipper(cmbZipperCat.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddlItemClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemClass.SelectedIndexChanged
        BindAccCategory()
    End Sub
    Protected Sub ddlItemClass2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemClass2.SelectedIndexChanged
        BindZipperCategory()
    End Sub
    Protected Sub cmbAccessorieseType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccessorieseType.SelectedIndexChanged
        Try
            If cmbAccessorieseType.SelectedItem.Text = "BUTTON" Or cmbAccessorieseType.SelectedItem.Text = "EILETS" Then
                BindProductName(cmbAccessorieseType.SelectedValue)
            Else
                BindProductName(cmbAccessorieseType.SelectedValue)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProductNameForZipper(ByVal ItemCode As String)
        Try
            Dim dt As DataTable
            dt = objAccCheckListMst.GetAccName(ItemCode)
            cmbZipperNameZipper.DataSource = dt
            cmbZipperNameZipper.DataTextField = "ItemName"
            cmbZipperNameZipper.DataValueField = "IMSItemID"
            cmbZipperNameZipper.DataBind()
            cmbZipperNameZipper.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddZipper_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddZipper.Click
        Try
            If txtPerPcsAvgZipper.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Zipper Usage Empty")
            ElseIf txtQtyZipper.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Zipper Total Empty")
            ElseIf txtPercentageZipper.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Zipper Percentage Empty")
            ElseIf txtOrderQtyZipper.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Zipper Order Qty")
            ElseIf txtColorZippersizes.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Color Zipper Sizes")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSessionForZipper()
                BindAccessGridForZipper()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSessionForZipper()

        If (Not CType(Session("dtZipperCheckListDetail"), DataTable) Is Nothing) Then
            dtZipperCheckListDetail = Session("dtZipperCheckListDetail")
        Else
            dtZipperCheckListDetail = New DataTable
            With dtZipperCheckListDetail
                .Columns.Add("ZipperCheckListDetailID", GetType(String))
                .Columns.Add("IMSItemId", GetType(String))
                .Columns.Add("IMSItemCategoryID", GetType(String))
                .Columns.Add("ItemCategoryName", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("UsagePC", GetType(String))
                .Columns.Add("Total", GetType(String))
                .Columns.Add("Percent", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("CalQTy", GetType(String))
                .Columns.Add("AssortSize", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("ColorZippersizes", GetType(String))
                .Columns.Add("IMSItemClassID", GetType(String))
                .Columns.Add("ItemClassName", GetType(String))
            End With
        End If
        Dr = dtZipperCheckListDetail.NewRow()
        If lblZipperCheclistMstIdForEdit.Text = 0 Then
            Dr("ZipperCheckListDetailID") = 0
        Else
            Dr("ZipperCheckListDetailID") = lblZipperCheclistMstIdForEdit.Text
        End If
        If cmbZipperCat.SelectedValue = 0 Then
            Dr("IMSItemId") = 0
            Dr("IMSItemCategoryID") = 0
            Dr("ItemCategoryName") = ""
            Dr("ItemName") = ""
        Else
            Dr("IMSItemId") = cmbZipperNameZipper.SelectedValue
            Dr("IMSItemCategoryID") = cmbZipperCat.SelectedValue
            Dr("ItemCategoryName") = cmbZipperCat.SelectedItem.Text
            Dr("ItemName") = cmbZipperNameZipper.SelectedItem.Text
        End If
        Dr("UsagePC") = txtPerPcsAvgZipper.Text
        Dr("Total") = txtQtyZipper.Text
        Dr("Percent") = txtPercentageZipper.Text
        Dr("OrderQty") = txtOrderQtyZipper.Text
        Dr("Remarks") = txtRemarksZipper.Text
        Dr("ColorZippersizes") = txtColorZippersizes.Text
        If cmbAssortColorZipper.SelectedIndex > 0 Then
            Dr("CalQTy") = txtAssortQTYZipper.Text
            Dr("AssortSize") = cmbAssortColorZipper.SelectedItem.Text
            Dr("StyleAssortmentDetailID") = cmbAssortColorZipper.SelectedValue
        Else
            Dr("CalQTy") = txtQuantity.Text
            Dr("AssortSize") = ""
            Dr("StyleAssortmentDetailID") = 0
        End If
        Dr("Description") = "N/A"
        Dr("ItemCodee") = ""
        Dr("IMSItemClassID") = ddlItemClass2.SelectedValue
        Dr("ItemClassName") = ddlItemClass2.SelectedItem.Text
        dtZipperCheckListDetail.Rows.Add(Dr)
        Session("dtZipperCheckListDetail") = dtZipperCheckListDetail
        BindAccessGridForZipper()
        AccChklistForZipper()
    End Sub
    Sub BindAccessGridForZipper()
        Try
            If dtZipperCheckListDetail.Rows.Count > 0 Then
                dgZipper.DataSource = dtZipperCheckListDetail
                dgZipper.DataBind()
                dgZipper.Visible = True
                Dim x As Integer = 0
                For x = 0 To dgZipper.Items.Count - 1
                    Dim lblItemID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemID"), Label)
                    Dim lblItemCategoryID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemCategoryID"), Label)
                    Dim txtItemCode As TextBox = DirectCast(dgZipper.Items(x).FindControl("txtItemCodeForZipper"), TextBox)
                    lblItemID.Text = dtZipperCheckListDetail.Rows(x)("IMSItemId")
                    lblItemCategoryID.Text = dtZipperCheckListDetail.Rows(x)("IMSItemCategoryID")
                Next
            Else
                dgZipper.DataSource = Session("dtZipperCheckListDetail")
                dgZipper.DataBind()
                dgZipper.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveZipperCheckListDetail()
        Try
            Dim x As Integer = 0
            For x = 0 To dgZipper.Items.Count - 1
                Dim lblItemID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemID"), Label)
                Dim lblItemCategoryID As Label = DirectCast(dgZipper.Items(x).FindControl("lblItemCategoryID"), Label)
                Dim txtItemCode As TextBox = DirectCast(dgZipper.Items(x).FindControl("txtItemCodeForZipper"), TextBox)
                With objZipperCheckListDtl
                    .ZipperCheckListDetailID = dgZipper.Items(x).Cells(0).Text
                    If Val(lblAccCheclistMstId.Text) > 0 Then
                        .AccCheckListMstID = lblAccCheclistMstId.Text
                    Else
                        .AccCheckListMstID = objAccCheckListMst.GetID
                    End If
                    .IMSItemId = lblItemID.Text
                    .IMSItemCategoryID = lblItemCategoryID.Text
                    .Description = "N/A"
                    .UsagePC = dgZipper.Items(x).Cells(6).Text
                    .Total = dgZipper.Items(x).Cells(7).Text
                    .Percent = dgZipper.Items(x).Cells(8).Text
                    .OrderQty = dgZipper.Items(x).Cells(9).Text
                    .Remarks = dgZipper.Items(x).Cells(10).Text
                    .CalQTy = dgZipper.Items(x).Cells(11).Text
                    .AssortSize = dgZipper.Items(x).Cells(12).Text
                    .StyleAssortmentDetailID = dgZipper.Items(x).Cells(13).Text
                    .ColorZippersizes = dgZipper.Items(x).Cells(14).Text
                    .ItemCode = txtItemCode.Text
                    .IMSItemClassID = dgZipper.Items(x).Cells(15).Text
                    .Save()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub BindProductName(ByVal ItemCode As String)
        Try
            Dim dt As DataTable
            dt = objAccCheckListMst.GetAccName(ItemCode)
            cmbAccessoriese.DataSource = dt
            cmbAccessoriese.DataTextField = "ItemName"
            cmbAccessoriese.DataValueField = "IMSItemID"
            cmbAccessoriese.DataBind()
            cmbAccessoriese.Items.Insert(0, New ListItem("Select", "0"))
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddAccessoriese_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddAccessoriese.Click
        Try
            If txtPerPcsAvg.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Usage Empty")
            ElseIf txtQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Total Empty")
            ElseIf txtPercentage.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Percentage Empty")
            ElseIf txtOrderQty.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Order Qty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                SaveSession()
                BindAccessGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub AccChklistForZipper()
        cmbZipperNameZipper.SelectedValue = 0
        cmbZipperCat.SelectedValue = 0
        cmbAssortColorZipper.SelectedValue = 0
    End Sub
    Sub SaveSession()
        If (Not CType(Session("dtAccCheckListDetail"), DataTable) Is Nothing) Then
            dtAccCheckListDetail = Session("dtAccCheckListDetail")
        Else
            dtAccCheckListDetail = New DataTable
            With dtAccCheckListDetail
                .Columns.Add("AccCheckListDetailID", GetType(String))
                .Columns.Add("IMSItemId", GetType(String))
                .Columns.Add("IMSItemCategoryID", GetType(String))
                .Columns.Add("ItemCategoryName", GetType(String))
                .Columns.Add("ItemName", GetType(String))
                .Columns.Add("UsagePC", GetType(String))
                .Columns.Add("Total", GetType(String))
                .Columns.Add("Percent", GetType(String))
                .Columns.Add("OrderQty", GetType(String))
                .Columns.Add("Remarks", GetType(String))
                .Columns.Add("CalQTy", GetType(String))
                .Columns.Add("AssortSize", GetType(String))
                .Columns.Add("StyleAssortmentDetailID", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
                .Columns.Add("IMSItemClassID", GetType(String))
                .Columns.Add("ItemClassName", GetType(String))
            End With
        End If
        Dr = dtAccCheckListDetail.NewRow()
        If lblAccCheclistMstIdForEdit.Text = 0 Then
            Dr("AccCheckListDetailID") = 0
        Else
            Dr("AccCheckListDetailID") = lblAccCheclistMstIdForEdit.Text
        End If
        If cmbAccessorieseType.SelectedValue = 0 Then
            Dr("IMSItemId") = 0
            Dr("IMSItemCategoryID") = 0
            Dr("ItemCategoryName") = ""
            Dr("ItemName") = ""
        Else
            Dr("IMSItemId") = cmbAccessoriese.SelectedValue
            Dr("IMSItemCategoryID") = cmbAccessorieseType.SelectedValue
            Dr("ItemCategoryName") = cmbAccessorieseType.SelectedItem.Text
            Dr("ItemName") = cmbAccessoriese.SelectedItem.Text
        End If
        Dr("UsagePC") = txtPerPcsAvg.Text
        Dr("Total") = txtQty.Text
        Dr("Percent") = txtPercentage.Text
        Dr("OrderQty") = txtOrderQty.Text
        Dr("Remarks") = txtRemarks.Text
        If cmbAssortColor.SelectedIndex > 0 Then
            Dr("CalQTy") = txtdtlAssortQty.Text
            Dr("AssortSize") = cmbAssortColor.SelectedItem.Text
            Dr("StyleAssortmentDetailID") = cmbAssortColor.SelectedValue
        Else
            Dr("CalQTy") = txtQuantity.Text
            Dr("AssortSize") = ""
            Dr("StyleAssortmentDetailID") = 0
        End If
        Dr("Description") = "N/A"
        Dr("ItemCodee") = ""
        Dr("IMSItemClassID") = ddlItemClass.SelectedValue
        Dr("ItemClassName") = ddlItemClass.SelectedItem.Text
        dtAccCheckListDetail.Rows.Add(Dr)
        Session("dtAccCheckListDetail") = dtAccCheckListDetail
        BindAccessGrid()
        AccChklist()
    End Sub
    Sub AccChklist()
        cmbAccessorieseType.SelectedValue = 0
        cmbAccessoriese.SelectedValue = 0
        cmbAssortColor.SelectedValue = 0
    End Sub
    Sub BindAccessGrid()
        Try
            If dtAccCheckListDetail.Rows.Count > 0 Then
                dgAccCheckList.DataSource = dtAccCheckListDetail
                dgAccCheckList.DataBind()
                dgAccCheckList.Visible = True
                Dim x As Integer = 0
                For x = 0 To dgAccCheckList.Items.Count - 1
                    Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
                    Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
                    Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)
                    txtItemCode.Text = dtAccCheckListDetail.Rows(x)("ItemCodee")
                    lblItemID.Text = dtAccCheckListDetail.Rows(x)("IMSItemId")
                    lblItemCategoryID.Text = dtAccCheckListDetail.Rows(x)("IMSItemCategoryID")
                Next
            Else
                dgAccCheckList.DataSource = Session("dtAccCheckListDetail")
                dgAccCheckList.DataBind()
                dgAccCheckList.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtQty.TextChanged
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            If txtPerPcsAvg.Text = "" Then
                txtPerPcsAvg.Text = 1
            End If
            If cmbAssortColor.SelectedIndex > 0 Then
                FormulaQty = txtdtlAssortQty.Text
            Else
                FormulaQty = txtQuantity.Text
            End If
            If cmbAssortColor.SelectedIndex = 0 Then
                txtQty.Text = FormulaQty * Val(txtPerPcsAvg.Text)
            Else

            End If
            If txtQty.Text <> "" And txtPercentage.Text <> "" Then
                Dim extarQty As Decimal = 0
                extarQty = (Val(txtQty.Text) * Val(txtPercentage.Text)) / 100
                txtOrderQty.Text = Val(txtQty.Text) + extarQty
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnAddThread_Click(sender As Object, e As EventArgs) Handles btnAddThread.Click
        Try
            SaveSessionThread()
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveSessionThread()

        If (Not CType(Session("dtAccCheckListThreasDtl"), DataTable) Is Nothing) Then
            dtAccCheckListThreasDtl = Session("dtAccCheckListThreasDtl")
        Else
            dtAccCheckListThreasDtl = New DataTable
            With dtAccCheckListThreasDtl
                .Columns.Add("ThreadCheckListID", GetType(String))
                .Columns.Add("Description", GetType(String))
                .Columns.Add("ThreadColor", GetType(String))
                .Columns.Add("JPShade", GetType(String))
                .Columns.Add("JPCode", GetType(String))
                .Columns.Add("Count", GetType(String))
                .Columns.Add("Mtr1con", GetType(String))
                .Columns.Add("OrderQtyForThread", GetType(String))
                .Columns.Add("PerForThread", GetType(String))
                .Columns.Add("ThreadQtyPcs", GetType(String))
                .Columns.Add("Consumption", GetType(String))
                .Columns.Add("RCones", GetType(String))
                .Columns.Add("ItemID", GetType(String))
                .Columns.Add("ItemCodee", GetType(String))
            End With
        End If
        Dr = dtAccCheckListThreasDtl.NewRow()
        If lblThreadCheckListID.Text = 0 Then
            Dr("ThreadCheckListID") = 0
        Else
            Dr("ThreadCheckListID") = lblThreadCheckListID.Text
        End If
        Dr("Description") = "N/A"
        Dr("ThreadColor") = txtThreadColor.Text
        Dr("JPShade") = txtJPShade.Text
        Dr("JPCode") = txtJPCode.Text
        Dr("Count") = txtCount.Text
        Dr("Mtr1con") = txtMtrCon.Text
        Dr("OrderQtyForThread") = txtOrderQtyForThread.Text
        Dr("PerForThread") = txtPerForThread.Text
        Dr("ThreadQtyPcs") = txtThreadQtyPcs.Text
        Dr("Consumption") = txtCons.Text
        Dr("RCones") = txtCones.Text
        If lblAccItemID.Text = "" Then
            Dr("ItemID") = 0
        Else
            Dr("ItemID") = lblAccItemID.Text
        End If
        Dr("ItemCodee") = TXTThreadsCode.Text
        dtAccCheckListThreasDtl.Rows.Add(Dr)
        Session("dtAccCheckListThreasDtl") = dtAccCheckListThreasDtl
        BindAccessThreadGrid()
        CLEARThreadDtl()
    End Sub
    Sub CLEARThreadDtl()
        txtDesc.Text = ""
        txtThreadColor.Text = ""
        txtJPShade.Text = ""
        txtJPCode.Text = ""
        txtCount.Text = ""
        txtCons.Text = ""
        txtThreadQtyPcs.Text = ""
        txtCones.Text = ""
        TXTThreadsCode.Text = ""
        txtPerForThread.Text = ""
        txtThreadQtyPcs.Text = ""
    End Sub
    Sub BindAccessThreadGrid()
        Try
            If dtAccCheckListThreasDtl.Rows.Count > 0 Then
                dgAccCheckListThread.DataSource = dtAccCheckListThreasDtl
                dgAccCheckListThread.DataBind()
                dgAccCheckListThread.Visible = True
            Else
                dgAccCheckListThread.DataSource = Session("dtAccCheckListThreasDtl")
                dgAccCheckListThread.DataBind()
                dgAccCheckListThread.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtPerForThread_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPerForThread.TextChanged
        Try
            Dim Percentageqty As Decimal = 0
            Dim FormulaQty As Decimal = 0
            Dim extarQty As Decimal = 0
            extarQty = (Val(txtOrderQtyForThread.Text) * Val(txtPerForThread.Text)) / 100
            txtThreadQtyPcs.Text = Math.Round(Val(txtOrderQtyForThread.Text) + extarQty, 0)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnsave.Click
        Try
            If txtDate.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Date Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                saveAccCheckListmaster()
                SaveAccCheckListDetail()
                SaveThreadCheckListDetail()
                SaveZipperCheckListDetail()
                Response.Redirect("JOProgramView.aspx")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub saveAccCheckRevisedDate()
        With objAccRevisedDate
            .AccCheckListRevisedDateHistoryID = 0
            If lblAccCheclistMstId.Text > 0 Then
                .AccCheckListMstID = lblAccCheclistMstId.Text
            Else
                .AccCheckListMstID = objAccCheckListMst.GetID
            End If
            .RevisedDate = txtRevisedDate.Text
            .UserID = UserId
                     .Save()
        End With
    End Sub
    Sub saveAccCheckListmaster()
        With objAccCheckListMst
            If Val(lblAccCheclistMstId.Text) > 0 Then
                .AccCheckListMstID = lblAccCheclistMstId.Text
            Else
                .AccCheckListMstID = 0
            End If
            .JoborderID = lJobOrderID
            .JoborderDetailID = lJoborderDetailid
            .StyleAssortmentMasterID = lStyleAssortmentMasterID
            .CheckDate = txtDate.Text
            .CreationDate = Date.Now
            If txtRevisedDate.Text = "" Then
                .RevisedDate = ""
            Else
                .RevisedDate = txtRevisedDate.Text
            End If
            .SaveAccCheckListMst()
        End With
    End Sub
    Sub SaveAccCheckListDetail()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckList.Items.Count - 1
                Dim lblItemID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemID"), Label)
                Dim lblItemCategoryID As Label = DirectCast(dgAccCheckList.Items(x).FindControl("lblItemCategoryID"), Label)
                Dim txtItemCode As TextBox = DirectCast(dgAccCheckList.Items(x).FindControl("txtItemCode"), TextBox)
                With objAccCheckListDtl
                    .AccCheckListDetailID = dgAccCheckList.Items(x).Cells(0).Text
                    If Val(lblAccCheclistMstId.Text) > 0 Then
                        .AccCheckListMstID = lblAccCheclistMstId.Text
                    Else
                        .AccCheckListMstID = objAccCheckListMst.GetID
                    End If
                    .IMSItemId = lblItemID.Text
                    .IMSItemCategoryID = lblItemCategoryID.Text
                    .Description = "N/A"
                    .UsagePC = dgAccCheckList.Items(x).Cells(6).Text
                    .Total = dgAccCheckList.Items(x).Cells(7).Text
                    .Percent = dgAccCheckList.Items(x).Cells(8).Text
                    .OrderQty = dgAccCheckList.Items(x).Cells(9).Text
                    .Remarks = dgAccCheckList.Items(x).Cells(10).Text
                    .CalQTy = dgAccCheckList.Items(x).Cells(11).Text
                    .AssortSize = dgAccCheckList.Items(x).Cells(12).Text
                    .StyleAssortmentDetailID = dgAccCheckList.Items(x).Cells(13).Text
                    .ItemCode = txtItemCode.Text
                    .IMSItemClassID = dgAccCheckList.Items(x).Cells(14).Text
                    .SaveAccCheckListDetail()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Sub SaveThreadCheckListDetail()
        Try
            Dim x As Integer = 0
            For x = 0 To dgAccCheckListThread.Items.Count - 1
                With objThreadChckList
                    .ThreadCheckListID = dgAccCheckListThread.Items(x).Cells(0).Text
                    If Val(lblAccCheclistMstId.Text) > 0 Then
                        .AccCheckListMstID = lblAccCheclistMstId.Text
                    Else
                        .AccCheckListMstID = objAccCheckListMst.GetID
                    End If
                    .Description = "N/A"
                    .ThreadColor = dgAccCheckListThread.Items(x).Cells(2).Text.Replace("&nbsp;", "")
                    .JPShade = dgAccCheckListThread.Items(x).Cells(3).Text.Replace("&nbsp;", "")
                    .JPCode = dgAccCheckListThread.Items(x).Cells(4).Text.Replace("&nbsp;", "")
                    .Count = dgAccCheckListThread.Items(x).Cells(5).Text
                    .Mtr1con = dgAccCheckListThread.Items(x).Cells(6).Text
                    .OrderQtyForThread = dgAccCheckListThread.Items(x).Cells(7).Text
                    .PerForThread = dgAccCheckListThread.Items(x).Cells(8).Text
                    .ThreadQtyPcs = dgAccCheckListThread.Items(x).Cells(9).Text
                    .Consumption = dgAccCheckListThread.Items(x).Cells(10).Text
                    .RCones = dgAccCheckListThread.Items(x).Cells(11).Text
                    .ItemID = dgAccCheckListThread.Items(x).Cells(12).Text
                    .SaveThreadCheckList()
                End With
            Next
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JOProgramView.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgAccCheckListThread_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAccCheckListThread.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    dtAccCheckListThreasDtl = CType(Session("dtAccCheckListThreasDtl"), DataTable)
                    If (Not dtAccCheckListThreasDtl Is Nothing) Then
                        If (dtAccCheckListThreasDtl.Rows.Count > 0) Then
                            Dim IssueDetailId As Integer = dgAccCheckListThread.Items(e.Item.ItemIndex).Cells(0).Text
                            SetDetailValuesByDataTable(e.Item.ItemIndex)
                            dtAccCheckListThreasDtl.Rows.RemoveAt(e.Item.ItemIndex)
                            BindAccessThreadGrid()
                            btnAddThread.Visible = True
                        End If
                    End If
                Case "Delete"
                    dtAccCheckListThreasDtl = CType(Session("dtAccCheckListThreasDtl"), DataTable)
                    If (Not dtAccCheckListThreasDtl Is Nothing) Then
                        If (dtAccCheckListThreasDtl.Rows.Count > 0) Then
                            Dim ThreadCheckListID As Integer = dtAccCheckListThreasDtl.Rows(e.Item.ItemIndex)("ThreadCheckListID")
                            Dim dtt As DataTable = objAccCheckListDtl.CheckAlreadyExistAccCheckListThtreadDtlIDinCost(ThreadCheckListID)
                            If dtt.Rows.Count > 0 Then
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Used In Costing")
                            Else
                                DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                                dtAccCheckListThreasDtl.Rows.RemoveAt(e.Item.ItemIndex)
                                Session("dtAccCheckListThreasDtl") = dtAccCheckListThreasDtl
                                objAccCheckListDtl.DeleteCheckListThreadDetail(ThreadCheckListID)
                                BindAccessThreadGrid()
                            End If
                        Else
                        End If
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Sub SetDetailValuesByDataTable(ByVal dtrowNo As Long)
        Try
            lblThreadCheckListID.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("ThreadCheckListID")
            lblAccItemID.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("ItemID")
            If lblAccItemID.Text = 0 Then
                TXTThreadsCode.Text = ""
            Else
                TXTThreadsCode.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("ItemCodee")
            End If
            txtDesc.Text = "N/A"
            txtThreadColor.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("ThreadColor")
            txtJPShade.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("JPShade")
            txtJPCode.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("JPCode")
            txtCount.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("Count")
            txtMtrCon.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("Mtr1con")
            txtCons.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("Consumption")
            txtThreadQtyPcs.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("ThreadQtyPcs")
            txtCones.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("RCones")
            txtOrderQtyForThread.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("OrderQtyForThread")
            txtPerForThread.Text = dtAccCheckListThreasDtl.Rows(dtrowNo)("PerForThread")
        Catch ex As Exception
        End Try
    End Sub
End Class