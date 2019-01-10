Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class CuttingProgramEntry
    Inherits System.Web.UI.Page
    Dim objCuttingProMst As New CuttingProMst
    Dim objCuttingProDetail As New CuttingProDetail
    Dim lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID As Long
    Dim UserId As Long
    Dim objCuttingRevisedDate As New CuttingRevisedDate
    Dim dtCutting As DataTable
    Dim Dr As DataRow
    Dim objJobOrderdatabase As New JobOrderdatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJobOrderID = Request.QueryString("JobOrderID")
        lJoborderDetailid = Request.QueryString("JoborderDetailid")
        lStyleAssortmentMasterID = Request.QueryString("StyleAssortmentMasterID")
        UserId = Session("UserId")
        If Not IsPostBack Then
             Session("dtCutting") = Nothing
            Session("dtGrid") = Nothing
            GetMasterData()
            Dim dtcheck As DataTable = objCuttingProMst.check(lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID)
            If dtcheck.Rows.Count > 0 Then
                lblCuttingProMasterID.Text = dtcheck.Rows(0)("CuttingProMasterID")
                txtStitchingFactory.Text = dtcheck.Rows(0)("StitchingFactory")
                txtStitchingStart.Text = dtcheck.Rows(0)("StitchingStart")
                txtExtaQty.Text = dtcheck.Rows(0)("ExtraQty")
                txtRevisedDate.Text = dtcheck.Rows(0)("RevisedDate")
                Edit()

                Dim ID As Long = dtcheck.Rows(0)("PocketLiningCodeid")
                Dim dt As DataTable = objCuttingProMst.GetIMSItemID(ID)
                If dt.Rows.Count > 0 Then
                    lblPocketLiningID.Text = ID
                    txtPocketLiningCode.Text = dt.Rows(0)("ItemCodee")
                    txtPocketLining.Text = dt.Rows(0)("FabricQualityy")
                Else
                    lblPocketLiningID.Text = 0
                    txtPocketLiningCode.Text = ""
                    txtPocketLining.Text = ""
                    
                End If
                

                Dim IDD As Long = dtcheck.Rows(0)("OtherFabricid")
                Dim dtT As DataTable = objCuttingProMst.GetIMSItemID(IDD)
                If dtT.Rows.Count > 0 Then
                    lblOtherFabricID.Text = IDD
                    txtOtherFabricCode.Text = dtT.Rows(0)("ItemCodee")
                    txtOtherFabric.Text = dtT.Rows(0)("FabricQualityy")
                Else
                    lblOtherFabricID.Text = 0
                    txtOtherFabricCode.Text = ""
                    txtOtherFabric.Text = ""
                End If
               

            Else
                GetForDetail()
            End If
        End If
    End Sub
    
    Protected Sub txtPocketLiningCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtPocketLiningCode.TextChanged
        Try
            Dim dtItem As DataTable = objJobOrderdatabase.GetItemDataCodeNew(txtPocketLiningCode.Text)
            lblPocketLiningID.Text = dtItem.Rows(0)("imsitemid")
            txtPocketLining.Text = dtItem.Rows(0)("FabricQualityy")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtOtherFabricCode_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOtherFabricCode.TextChanged
        Try
            Dim dtItem As DataTable = objJobOrderdatabase.GetItemDataCodeNew(txtOtherFabricCode.Text)
            lblOtherFabricID.Text = dtItem.Rows(0)("imsitemid")
            txtOtherFabric.Text = dtItem.Rows(0)("FabricQualityy")

        Catch ex As Exception

        End Try
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
            End If
       
        Catch ex As Exception

        End Try
    End Sub
    Sub GetForDetail()

        Dim dt As DataTable = objCuttingProMst.CheckAssortQty(lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID)
        Dim dtt As DataTable = objCuttingProMst.CheckCuttingQty(lJobOrderID, lJoborderDetailid, lStyleAssortmentMasterID)
        Dim AssortQty As Decimal = dt.Rows(0)("ExtraQty")
        Dim CuttingQty As Decimal = dtt.Rows(0)("TotalQty")
        If AssortQty = CuttingQty Then
            Dim dttt As New DataTable
            dttt = objCuttingProMst.GetForDetail(lStyleAssortmentMasterID)
            txtExtaQty.Text = dttt.Rows(0)("ExtraQty")
            Session("dtGrid") = dttt
            BindGrid()
        Else
            Dim dttt As New DataTable
            dttt = objCuttingProMst.GetQty(lStyleAssortmentMasterID)
            txtExtaQty.Text = dttt.Rows(0)("ExtraQty")
            Session("dtGrid") = dttt
            BindGrid()
        End If
    End Sub
    Sub Edit()
        Dim dttt As New DataTable
        dttt = objCuttingProMst.GetQtyForNew(lStyleAssortmentMasterID)
        lblUserId.Text = dttt.Rows(0)("UserIdd")

        If dttt.Rows.Count > 0 Then
            If (Not CType(Session("dtCutting"), DataTable) Is Nothing) Then
                dtCutting = Session("dtCutting")
            Else
                dtCutting = New DataTable
                With dtCutting
                    .Columns.Add("CuttingProDetailID", GetType(Long))
                    .Columns.Add("StyleAssortmentDetailID", GetType(Long))
                    .Columns.Add("SizeRangeID", GetType(Long))
                    .Columns.Add("SizeDatabaseID", GetType(String))
                    .Columns.Add("Sizes", GetType(String))
                    .Columns.Add("TotalQty", GetType(Decimal))
                End With
            End If
            Dim y As Integer
            For y = 0 To dttt.Rows.Count - 1
                Dr = dtCutting.NewRow()
                Dr("CuttingProDetailID") = dttt.Rows(y)("CuttingProDetailID")
                Dr("StyleAssortmentDetailID") = dttt.Rows(y)("StyleAssortmentDetailID")
                Dr("SizeRangeID") = dttt.Rows(y)("SizeRangeID")
                Dr("SizeDatabaseID") = dttt.Rows(y)("SizeDatabaseID")
                Dr("Sizes") = dttt.Rows(y)("Sizes")
                Dim Extra As Decimal = 0
                Extra = (((Val(dttt.Rows(y)("Qty")) + Val(dttt.Rows(y)("Asortqty"))) * Val(txtExtaQty.Text)) / 100)
                Dr("TotalQty") = (Val(dttt.Rows(y)("Qty")) + Val(dttt.Rows(y)("Asortqty"))) + Extra
                dtCutting.Rows.Add(Dr)
            Next
            Session("dtCutting") = dtCutting
            Dim dtt As DataTable = Session("dtCutting")
            Session("dtGrid") = dtt
            BindGrid()
        End If
    End Sub
    Protected Sub txtExtaQty_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtExtaQty.TextChanged
        Try

            Session("dtCutting") = Nothing
            Dim dttt As New DataTable
            dttt = objCuttingProMst.GetQtyForNew(lStyleAssortmentMasterID)
            If dttt.Rows.Count > 0 Then
                If (Not CType(Session("dtCutting"), DataTable) Is Nothing) Then
                    dtCutting = Session("dtCutting")
                Else
                    dtCutting = New DataTable
                    With dtCutting
                        .Columns.Add("CuttingProDetailID", GetType(Long))
                        .Columns.Add("StyleAssortmentDetailID", GetType(Long))
                        .Columns.Add("SizeRangeID", GetType(Long))
                        .Columns.Add("SizeDatabaseID", GetType(String))
                        .Columns.Add("Sizes", GetType(String))
                        .Columns.Add("TotalQty", GetType(Decimal))
                    End With
                End If
                Dim y As Integer
                For y = 0 To dttt.Rows.Count - 1
                    Dr = dtCutting.NewRow()
                    Dr("CuttingProDetailID") = dttt.Rows(y)("CuttingProDetailID")
                    Dr("StyleAssortmentDetailID") = dttt.Rows(y)("StyleAssortmentDetailID")
                    Dr("SizeRangeID") = dttt.Rows(y)("SizeRangeID")
                    Dr("SizeDatabaseID") = dttt.Rows(y)("SizeDatabaseID")
                    Dr("Sizes") = dttt.Rows(y)("Sizes")
                    Dim Extra As Decimal = 0
                    Extra = (((Val(dttt.Rows(y)("Qty")) + Val(dttt.Rows(y)("Asortqty"))) * Val(txtExtaQty.Text)) / 100)
                    Dr("TotalQty") = (Val(dttt.Rows(y)("Qty")) + Val(dttt.Rows(y)("Asortqty"))) + Extra
                    dtCutting.Rows.Add(Dr)
                Next
                Session("dtCutting") = dtCutting
                Dim dtt As DataTable = Session("dtCutting")
                Session("dtGrid") = dtt
                BindGrid()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDatatable As DataTable
            If lStyleAssortmentMasterID > 0 Then
                objDatatable = Session("dtGrid")
            End If

            If objDatatable.Rows.Count > 0 Then
                dgStyleAssortment.Visible = True
                dgStyleAssortment.RecordCount = objDatatable.Rows.Count
                dgStyleAssortment.DataSource = objDatatable
                dgStyleAssortment.DataBind()
            Else
                dgStyleAssortment.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If txtStitchingStart.Text = "" Then
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("Stitiching Date Empty")
            Else
                DirectCast(Me.Page.Master, MasterPage).ShowMessgae("")
                SaveMaster()
                saveDetail()
                'saveCuttingRevisedDate()
                Response.Redirect("JOProgramView.aspx")
            End If
           
        Catch ex As Exception

        End Try
    End Sub
    Sub saveCuttingRevisedDate()
        With objCuttingRevisedDate
            .CuttingprogramRevisedDateHistoryID = 0
            If lblCuttingProMasterID.Text > 0 Then
                .CuttingProMasterID = lblCuttingProMasterID.Text
            Else
                .CuttingProMasterID = objCuttingProMst.GetID
            End If
            .RevisedDate = txtRevisedDate.Text
            .UserID = UserId
            .Save()
        End With
    End Sub
    Sub SaveMaster()
        Try
            With objCuttingProMst
                If Val(lblCuttingProMasterID.Text) > 0 Then
                    .CuttingProMasterID = lblCuttingProMasterID.Text
                Else
                    .CuttingProMasterID = 0
                End If
                .StyleAssortmentMasterID = lStyleAssortmentMasterID
                .JobOrderID = lJobOrderID
                .JoborderDetailid = lJoborderDetailid

                If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
                    If Val(lblCuttingProMasterID.Text) > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = 270
                    End If
                Else
                    If Val(lblCuttingProMasterID.Text) > 0 Then
                        .UserID = lblUserId.Text
                    Else
                        .UserID = UserId
                    End If
                End If


                .CreationDate = Date.Now
                .ExtraQty = txtExtaQty.Text
                .StitchingFactory = txtStitchingFactory.Text
                .StitchingStart = txtStitchingStart.Text
                .PocketLiningCodeid = lblPocketLiningID.Text
                .OtherFabricid = lblOtherFabricID.Text
                If txtRevisedDate.Text = "" Then
                    .RevisedDate = ""
                Else
                    .RevisedDate = txtRevisedDate.Text
                End If
                .SaveCuttingProMaster()
            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub saveDetail()
        Dim x As Integer
        Try
            For x = 0 To dgStyleAssortment.Items.Count - 1
                 
                With objCuttingProDetail
                    .CuttingProDetailID = dgStyleAssortment.Items(x).Cells(0).Text
                    If Val(lblCuttingProMasterID.Text) > 0 Then
                        .CuttingProMasterID = lblCuttingProMasterID.Text
                    Else
                        .CuttingProMasterID = objCuttingProMst.GetID
                    End If

                    .StyleAssortmentDetailID = dgStyleAssortment.Items(x).Cells(1).Text
                    .StyleAssortmentMasterID = lStyleAssortmentMasterID
                    .SizeRangeID = dgStyleAssortment.Items(x).Cells(2).Text
                    .SizeDatabaseID = dgStyleAssortment.Items(x).Cells(3).Text
                    .Size = dgStyleAssortment.Items(x).Cells(4).Text
                    .TotalQty = dgStyleAssortment.Items(x).Cells(5).Text
                    .SaveCuttingProDetail()
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("JOProgramView.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class