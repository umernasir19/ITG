Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class RequisitionerInfo
    Inherits System.Web.UI.Page
    Dim objRequisitionerInfo As New RequisitionerInfoClass
    Dim objInventoryRequestDetail As New InventoryRequestDetail
    Dim UserID As Long

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        Dim objDataView As DataView
        If Not Page.IsPostBack Then
            UserID = CLng(Session("Userid"))
            GetUserInfo(UserID)
            txtDate.SelectedDate = Date.Now.Today

            PageHeader(" Requisitioner Information")
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
            Catch objUDException As UDException
            End Try
          
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub

    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            If objDataView.Count > 0 Then
                dgRequisitionerInfo.Visible = True
                dgRequisitionerInfo.DataSource = objDataView
                dgRequisitionerInfo.DataBind()
            Else
                dgRequisitionerInfo.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objRequisitionerInfo.GetItemView
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Requisitioner()
        pnlAll.Visible = False
    End Sub

    Sub Requisitioner()


        With objRequisitionerInfo
            .CurrentDate = txtDate.SelectedDate


            .RequisitionerName = txtRequisitionerName.Text
            .Department = txtDepartment.Text
            If txtApprovalDate.SelectedDate Is Nothing Then
                .ApprovalDate = ""
            Else
                .ApprovalDate = txtApprovalDate.SelectedDate.Value
            End If

            If txtApprovedBy.Text = "" Then
                .ApprovedBy = "--"
            Else
                .ApprovedBy = txtApprovedBy.Text
            End If

            .PriorityUrgentNormal = rdPriorityUrgentNormal.SelectedValue
            .ApprovalStatus = 0
            .saveRequisitionerInfo()
        End With
        Dim ChkSelect As CheckBox
        For x = 0 To dgRequisitionerInfo.Items.Count - 1
            Dim item As GridDataItem = DirectCast(dgRequisitionerInfo.MasterTableView.Items(x), GridDataItem)
            ChkSelect = CType(dgRequisitionerInfo.Items(x).FindControl("chkRequisition"), CheckBox)

            If ChkSelect.Checked = True Then
                Dim InventoryDatabaseID As Long = item("InventoryDatabaseID").Text
                With objInventoryRequestDetail
                    .InventoryRequestDetailID = 0
                    .InventoryRequestMasterID = objRequisitionerInfo.GetlastInventoryDatabaseID
                    .InventoryDatabaseID = InventoryDatabaseID
                    .Status = InventoryDatabaseID
                    .saveInventoryRequestDetail()
                End With

            End If
        Next
        lblMsg.Visible = True
        lblMsg.Text = "Requisitioner Submitted Successfully."

        ' txtDate.Visible = False
        'txtRequisitionerName.Visible = False
        'txtDepartment.Visible = False
        'dgRequisitionerInfo.Visible = False
        'lblDate.Visible = False
        'lblRequisitionerName.Visible = False
        'lblDepartment.Visible = False
      
        ' PageHeader("Requisitioner Info Save Successfully")

        ''''''''''''''''''
       
        'Dim Report As New ReportDocument
        'Dim Options As New ExportOptions


        'Dim InventoryRequestMasterID As Long = objRequisitionerInfo.GetlastInventoryDatabaseID

        'Report.Load(Server.MapPath("..\Reports/RpInventoryRequisition.rpt"))

        'Report.Refresh()
        'Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        'di.Create()
        'Dim FileName As String = "Requisition _ " + txtRequisitionerName.Text
        'Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        'Report.SetParameterValue(0, InventoryRequestMasterID)


        'Dim FileOption As New DiskFileDestinationOptions
        'FileOption.DiskFileName = sTempFileName
        'Options = Report.ExportOptions
        'Options.ExportDestinationType = ExportDestinationType.DiskFile
        'Options.ExportFormatType = ExportFormatType.PortableDocFormat
        'Options.DestinationOptions = FileOption
        'Options.ExportDestinationOptions = FileOption
        'Report.SetDatabaseLogon("sa", "pwd")
        'Report.Export()

        'If (Directory.Exists(Server.MapPath("~/TempPDF"))) Then
        '    Dim strFileSize As String = ""
        '    Dim dii As New IO.DirectoryInfo(Server.MapPath("~/TempPDF"))
        '    Dim aryFi As IO.FileInfo() = dii.GetFiles(FileName & ".pdf")
        '    Dim fi As IO.FileInfo
        '    For Each fi In aryFi
        '        Response.ClearHeaders()
        '        Response.ClearContent()
        '        Response.ContentType = "application/octet-stream"
        '        Response.Charset = "UTF-8"
        '        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
        '        Response.WriteFile(Server.MapPath("~/TempPDF/" & fi.Name & ""))
        '        Response.End()
        '    Next
        '    Response.AddHeader("content-disposition", "inline;filename=YourPdfFileName.pdf")
        '    Response.End()
        'End If

       



    End Sub
    Sub GetUserInfo(ByVal UserID)
        Try
            Dim dt As DataTable
            dt = objRequisitionerInfo.GetUSerInfoNew(UserID)
            txtRequisitionerName.Text = dt.Rows(0)("UserName")
            txtDepartment.Text = dt.Rows(0)("ECPDivistion")

           
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgRequisitionerInfo_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgRequisitionerInfo.ItemCommand
       

       
    End Sub

    Protected Sub dgRequisitionerInfo_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgRequisitionerInfo.SortCommand
        BindGrid()
    End Sub

    Protected Sub dgRequisitionerInfo_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgRequisitionerInfo.PageIndexChanged
        BindGrid()
    End Sub

    Protected Sub dgRequisitionerInfo_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgRequisitionerInfo.NeedDataSource
        BindGrid()
    End Sub

    Protected Sub rdPriorityUrgentNormal_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rdPriorityUrgentNormal.SelectedIndexChanged

    End Sub
End Class