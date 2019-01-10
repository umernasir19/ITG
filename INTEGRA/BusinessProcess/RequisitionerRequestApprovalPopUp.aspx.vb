Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class RequisitionerRequestApprovalPopUp
    Inherits System.Web.UI.Page
    Dim lInventoryRequestMasterID As Long
    Dim objRequisitionerInfo As New RequisitionerInfoClass
    Dim objInventoryRequestDetail As New InventoryRequestDetail
    Dim UserID As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lInventoryRequestMasterID = Request.QueryString("lInventoryRequestMasterID")
        Dim objDataView As DataView
       
        If Not Page.IsPostBack Then

            UserID = CLng(Session("Userid"))
            GetUserInfo(UserID)
            txtApprovalDate.SelectedDate = Date.Now.Today
            FillTextBox()
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try

        End If

    End Sub
    Sub GetUserInfo(ByVal UserID)
        Try
            Dim dt As DataTable
            dt = objRequisitionerInfo.GetUSerInfoNew(UserID)
            txtApprovedBy.Text = dt.Rows(0)("UserName")



        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then

                dgApprovalPopup.Visible = True
                dgApprovalPopup.DataSource = objDataView
                dgApprovalPopup.DataBind()
                ''''''''''''''''''
                Dim ChkSelect As CheckBox


                Dim dt As New DataTable
                Dim dtview As DataView = Session("objDataView")

                Dim newTable As DataTable = dtview.ToTable
                Dim x As Integer
                For x = 0 To newTable.Rows.Count - 1
                    Dim item As GridDataItem = DirectCast(dgApprovalPopup.MasterTableView.Items(x), GridDataItem)
                    ChkSelect = CType(dgApprovalPopup.Items(x).FindControl("chkStatus"), CheckBox)
                    ChkSelect.Checked = newTable.Rows(x)("Status")
                Next
                ChkSelect.Checked = ChkSelect.Checked
               

                ''''''''''''
            Else
                dgApprovalPopup.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objRequisitionerInfo.GetRequisitionerApprovalViewPopup(lInventoryRequestMasterID)

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub FillTextBox()
        Dim dt As New DataTable
        dt = objRequisitionerInfo.GetEditPopup(lInventoryRequestMasterID)
        txtDate.SelectedDate = dt.Rows(0)("CurrentDate")
        txtRequisitionerName.Text = dt.Rows(0)("RequisitionerName")
        txtDepartment.Text = dt.Rows(0)("Department")
        rdPriorityUrgentNormal.SelectedValue = dt.Rows(0)("PriorityUrgentNormal")

    End Sub

   
    Protected Sub btnApproval_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApproval.Click
        Requisitioner()
    End Sub
    Sub Requisitioner()
        With objRequisitionerInfo
            If lInventoryRequestMasterID > 0 Then
                .InventoryRequestMasterID = lInventoryRequestMasterID
            Else
                .InventoryRequestMasterID = 0
            End If
            .CurrentDate = txtDate.SelectedDate


            .RequisitionerName = txtRequisitionerName.Text
            .Department = txtDepartment.Text
          
            .ApprovalDate = txtApprovalDate.SelectedDate.Value


           
            .ApprovedBy = txtApprovedBy.Text


            .PriorityUrgentNormal = rdPriorityUrgentNormal.SelectedValue
            .ApprovalStatus = 1
            .saveRequisitionerInfo()
        End With
        Dim chkStatus As CheckBox
        For x = 0 To dgApprovalPopup.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgApprovalPopup.MasterTableView.Items(x), GridDataItem)
            chkStatus = CType(dgApprovalPopup.Items(x).FindControl("chkStatus"), CheckBox)

            Dim InventoryDatabaseID As Long = item("InventoryDatabaseID").Text
            With objInventoryRequestDetail
                .InventoryRequestDetailID = item("InventoryRequestDetailID").Text
                .InventoryRequestMasterID = item("InventoryRequestMasterID").Text
                .InventoryDatabaseID = item("InventoryDatabaseID").Text
                .Status = chkStatus.Checked
                .saveInventoryRequestDetail()
            End With


        Next

        ''''''''''''
        '''Download pdf
        Dim Report As New ReportDocument
        Dim Options As New ExportOptions



        Dim InventoryRequestMasterID As Long = lInventoryRequestMasterID

        Report.Load(Server.MapPath("..\Reports/RpInventoryRequisitionApproved.rpt"))

        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "Requisition _ " + txtRequisitionerName.Text
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        Report.SetParameterValue(0, InventoryRequestMasterID)


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
            Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
            Response.End()
        End If
    End Sub


End Class