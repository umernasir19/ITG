Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POProcessReceiveViewNew
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim objPORecvMaster As New POProcessRecvMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable
    Dim objPORecvMasterr As New PORecvMaster
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("PO RECEIVING VIEW")
    End Sub
    Sub GetRights()
          Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(userid, Path4)
        If dt.Rows.Count > 0 Then
            Dim Add As String = dt.Rows(0)("AddStatus")
            Dim View As String = dt.Rows(0)("ViewStatus")
            Dim Delete As String = dt.Rows(0)("DeleteStatus")
            If Add = 1 Then
                cmdAdd.Enabled = True
            Else
                cmdAdd.Enabled = False
            End If
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
                Next
            End If
            If Delete = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkRemove As ImageButton = CType(dgView.Items(x).FindControl("lnkRemove"), ImageButton)
                    lnkRemove.Enabled = False
                Next
            End If
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            objDataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrder()
        Else
            Dim DtCheck As DataTable = objPORecvMasterr.CheckDepartment(userid)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                objDataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrder()
            Else
                objDataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrder()
            End If
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    ' SortByColumn (NOT private otherwise unaccessible from the page)
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
        'BindGrid()
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

        Response.Redirect("POProcessReceiveEntry.aspx")


    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim POProcessRecvMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("POProcessReceiveEntry.aspx?POProcessRecvMasterID=" & POProcessRecvMasterID & "")




                Case "PDF"
 
                    Dim ID As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String
                    Report.Load(Server.MapPath("..\Reports/POProcessRecieveNEW.rpt"))
                    FileName = "POProcessReceieveReport"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, ID)
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
                Case "Return"



                    Dim POID As Long = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim PODetailID As Long = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim PORecvMasterID As Long = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim PORecvDetailID As Long = dgView.Items(e.Item.ItemIndex).Cells(3).Text
                    Dim ItemID As Long = dgView.Items(e.Item.ItemIndex).Cells(18).Text

                    Dim PONO As String = dgView.Items(e.Item.ItemIndex).Cells(5).Text
                    Dim Style As String = dgView.Items(e.Item.ItemIndex).Cells(7).Text
                    Dim SupplierName As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    Dim ItemName As String = dgView.Items(e.Item.ItemIndex).Cells(9).Text
                    Dim POQTY As String = dgView.Items(e.Item.ItemIndex).Cells(10).Text
                    Dim RecvQuantity As String = dgView.Items(e.Item.ItemIndex).Cells(13).Text


                    Session("PONO") = PONO
                    Session("Style") = Style
                    Session("SupplierName") = SupplierName
                    Session("ItemName") = ItemName
                    Session("POQTY") = POQTY
                    Session("RecvQuantity") = RecvQuantity
                    Response.Redirect("POProcessReturn.aspx?POID=" & POID & " &PODetailID=" & PODetailID & "&PORecvMasterID=" & PORecvMasterID & "&PORecvDetailID=" & PORecvDetailID & "&ItemID=" & ItemID & "", False)


                Case "ReturnPDF"

                    Dim PONO As String = dgView.Items(e.Item.ItemIndex).Cells(5).Text
                    Dim Style As String = dgView.Items(e.Item.ItemIndex).Cells(7).Text
                    Dim SupplierName As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    Dim ItemName As String = dgView.Items(e.Item.ItemIndex).Cells(9).Text
                    Dim POQTY As String = dgView.Items(e.Item.ItemIndex).Cells(10).Text
                    Dim RecvQuantity As String = dgView.Items(e.Item.ItemIndex).Cells(13).Text




                    Dim ProcessOrderDtlID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions
                    Dim FileName As String

                    Report.Load(Server.MapPath("..\Reports/FPOProcessReturn.rpt"))
                    FileName = "POReceieveReport"
                    Report.Refresh()
                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"

                    Report.SetParameterValue(0, PONO)
                    Report.SetParameterValue(1, Style)
                    Report.SetParameterValue(2, SupplierName)
                    Report.SetParameterValue(3, ItemName)
                    Report.SetParameterValue(4, POQTY)
                    Report.SetParameterValue(5, RecvQuantity)
                    Report.SetParameterValue(6, ProcessOrderDtlID)
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


            End Select
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData(ByVal ItemName As String) As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        If userid = 241 Then
            objDataTable = objPORecvMaster.GetItemAllInfoPORECV(ItemName)
        Else
            objDataTable = objPORecvMaster.GetPORECforViewForSearch(ItemName)
        End If

        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        Try
            Dim objDataView As DataView
            objDataView = LoadData()

            Session("objDataView") = objDataView
            BindGrid()

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            Dim dt1 As DataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrderForPONOVise(txtShowMe.Text)
            Dim dt2 As DataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrderForsUPPLIERVise(txtShowMe.Text)
            Dim dt3 As DataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrderForStyleVise(txtShowMe.Text)
            Dim dt4 As DataTable = objPORecvMaster.GetPORECforViewFabricNewForprocessOrderForItemVise(txtShowMe.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()
                GetRights()
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()
                GetRights()
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()
                GetRights()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class



