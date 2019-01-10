Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class ItemClassView
    Inherits System.Web.UI.Page
    Dim ObjIMSItemClass As New IMSItemClass
    Dim objPORecvMaster As New PORecvMaster
    Dim UserID As Long
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        UserID = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    LoadDataFabricStore()
                    cmdAdd.Enabled = True
                    lnkPrint.Enabled = True
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserID)
                    If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        LoadDataFabricStore()
                        cmdAdd.Enabled = True
                        lnkPrint.Enabled = True
                    ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                        LoadDataAccessStore()
                        cmdAdd.Enabled = True
                        lnkPrint.Enabled = True
                    ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                        LoadDataGeneralStore()
                        cmdAdd.Enabled = True
                        lnkPrint.Enabled = True
                    ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                        LoadDataInternalAuditor()
                        cmdAdd.Enabled = False
                        lnkPrint.Enabled = True
                    Else
                        LoadDataInternalAuditor()
                        cmdAdd.Enabled = False
                        lnkPrint.Enabled = True
                    End If
                End If
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Item Class View")
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path7 As String = PathArr(PathArr.Length - 3)
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path7 + "/" + Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(UserID, Path4)
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
                For x = 0 To dgItemClass.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgItemClass.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgItemClass.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgItemClass.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = False
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
        dgItemClass.RecordCount = objDataView.Count
        dgItemClass.DataSource = objDataView
        dgItemClass.DataBind()
    End Sub
    Function LoadDataInternalAuditor() As ICollection
            Dim objDataTable As DataTable
        objDataTable = ObjIMSItemClass.GetItemAccessStoreForAuditor
            dgItemClass.DataSource = objDataTable
            dgItemClass.DataBind()
    End Function
    Function LoadDataAccessStore() As ICollection
        If UserID = 273 Then
            Dim objDataTable As DataTable
            objDataTable = ObjIMSItemClass.GetItemAccessStoreForNewAcc
            dgItemClass.DataSource = objDataTable
            dgItemClass.DataBind()
        Else
            Dim objDataTable As DataTable
            objDataTable = ObjIMSItemClass.GetItemAccessStore
            dgItemClass.DataSource = objDataTable
            dgItemClass.DataBind()
        End If
    End Function
    Function LoadDataChemicalStore() As ICollection
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemClass.GetItemChemicalStore
        dgItemClass.DataSource = objDataTable
        dgItemClass.DataBind()
    End Function
    Function LoadDataFabricStore() As ICollection
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemClass.GetItemFabricStore
        dgItemClass.DataSource = objDataTable
        dgItemClass.DataBind()
    End Function
    Function LoadDataDeadStore() As ICollection
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemClass.GetItemDeadStore
        dgItemClass.DataSource = objDataTable
        dgItemClass.DataBind()
    End Function
    Function LoadDataGeneralStore() As ICollection
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemClass.GetItemGeneralStore
        dgItemClass.DataSource = objDataTable
        dgItemClass.DataBind()
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgItemClass.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgItemClass.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgItemClass.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("ItemClassEntry.aspx")
    End Sub
    Protected Sub dgItemClass_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgItemClass.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim IMSItemClassID As Long = dgItemClass.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("ItemClassEntry.aspx?IMSItemClassID=" & IMSItemClassID & "")
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lnkPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrint.Click
        Try
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Report.Load(Server.MapPath("..\..\Reports/ItemClass.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Item Class"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
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
        Catch ex As Exception
        End Try
    End Sub
End Class
