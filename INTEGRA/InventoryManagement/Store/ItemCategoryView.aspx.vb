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
Public Class ItemCategoryView
    Inherits System.Web.UI.Page
    Dim ObjIMSItemCategory As New IMSItemCategory
    Dim lUserId As Long
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UserId = Session("UserId")
        lUserId = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                    Dim objDataTable As DataTable
                    objDataTable = ObjIMSItemCategory.GetIMSItemCategoryFabric
                    Session("objDataView") = New DataView(objDataTable)
                    BindGridMain()
                Else
                    Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                    If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                        Dim objDataTable As DataTable
                        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryFabric
                        Session("objDataView") = New DataView(objDataTable)
                        BindGridMain()
                    ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                        Dim objDataTable As DataTable
                        If lUserId = 273 Then
                            objDataTable = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAcc()
                        Else
                            objDataTable = ObjIMSItemCategory.GetIMSItemCategoryAccessories()
                        End If
                        Session("objDataView") = New DataView(objDataTable)
                        BindGridMain()

                    ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                        Dim objDataTable As DataTable
                        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryGStore()
                        Session("objDataView") = New DataView(objDataTable)
                        BindGridMain()

                    ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                        Dim objDataTable As DataTable
                        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAuditor()
                        Session("objDataView") = New DataView(objDataTable)
                        BindGridMain()
                        cmdAdd.Visible = False
                    Else
                        Dim objDataTable As DataTable
                        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAuditor()
                        Session("objDataView") = New DataView(objDataTable)
                        BindGridMain()
                        cmdAdd.Visible = False
                    End If
                End If
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Item Category View")
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path7 As String = PathArr(PathArr.Length - 3)
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path7 + "/" + Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(lUserId, Path4)
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
                For x = 0 To dgItemCategory.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgItemCategory.Items(x).FindControl("lnkEdit"), ImageButton)
                    lnkEditt.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgItemCategory.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgItemCategory.Items(x).FindControl("lnkEdit"), ImageButton)
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
    Function LoadDataFabricView() As ICollection
        Dim objDataViewFabric As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryFabric
        objDataViewFabric = New DataView(objDataTable)
        Return objDataViewFabric
    End Function
    Function LoadDataAccessoriesView() As ICollection
        Dim objDataViewAccessories As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryAccessories
        objDataViewAccessories = New DataView(objDataTable)
        Return objDataViewAccessories
    End Function
    Function LoadDataDeadView() As ICollection
        Dim objDataViewDead As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryDead
        objDataViewDead = New DataView(objDataTable)
        Return objDataViewDead
    End Function
    Function LoadDataGeneralView() As ICollection
        Dim objDataViewGeneral As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryGeneral
        objDataViewGeneral = New DataView(objDataTable)
        Return objDataViewGeneral
    End Function
    Private Sub BindGridFabric()
        Dim objDataView As DataView
        objDataView = Session("objDataViewFabric")
        dgItemCategory.RecordCount = objDataView.Count
        dgItemCategory.DataSource = objDataView
        dgItemCategory.DataBind()
        GetRights()
    End Sub
    Private Sub BindGridMain()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgItemCategory.RecordCount = objDataView.Count
        dgItemCategory.DataSource = objDataView
        dgItemCategory.DataBind()
        GetRights()
    End Sub
    Private Sub BindGridAccessories()
        Dim objDataView As DataView
        objDataView = Session("objDataViewAccessories")
        dgItemCategory.RecordCount = objDataView.Count
        dgItemCategory.DataSource = objDataView
        dgItemCategory.DataBind()
        GetRights()
    End Sub
    Private Sub BindGridDead()
        Dim objDataView As DataView
        objDataView = Session("objDataViewDead")
        dgItemCategory.RecordCount = objDataView.Count
        dgItemCategory.DataSource = objDataView
        dgItemCategory.DataBind()
        GetRights()
    End Sub
    Private Sub BindGridGeneral()
        Dim objDataView As DataView
        objDataView = Session("objDataViewGeneral")
        dgItemCategory.RecordCount = objDataView.Count
        dgItemCategory.DataSource = objDataView
        dgItemCategory.DataBind()
        GetRights()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = ObjIMSItemCategory.GetIMSItemCategoryAll
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgItemCategory.PageIndexChanged
        BindGridMain()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgItemCategory.SortCommand
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgItemCategory.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("ItemCategoryEntry.aspx")
    End Sub
    Protected Sub dgItemCategory_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgItemCategory.ItemCommand
        Try
            Select Case e.CommandName
                Case "Edit"
                    Dim IMSItemCategoryID As Long = dgItemCategory.Items(e.Item.ItemIndex).Cells(0).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("ItemCategoryEntry.aspx?IMSItemCategoryID=" & IMSItemCategoryID & "")
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
            Report.Load(Server.MapPath("..\..\Reports/ItemCategory.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Item Category"
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
    Protected Sub txtItemClassName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtItemClassName.TextChanged
        Try

            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItemCategory.GetIMSItemCLASSFabricForSearch(txtItemClassName.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemCategory.DataSource = CkDt1
                    dgItemCategory.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItemCategory.GetIMSItemCategoryFabric
                    dgItemCategory.DataSource = dt
                    dgItemCategory.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(lUserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItemCategory.GetIMSItemCLASSFabricForSearch(txtItemClassName.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt1
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItemCategory.GetIMSItemCategoryFabric
                        dgItemCategory.DataSource = dt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCLASSAccForSearch(txtItemClassName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryAccessories
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCLASSAccForSearchGstore(txtItemClassName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryGStore
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCLASSAccForSearchForAuditor(txtItemClassName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAuditor()
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCLASSAccForSearchForAuditor(txtItemClassName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAuditor()
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub txtCategoryName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtCategoryName.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim CkDt1 As DataTable = ObjIMSItemCategory.GetIMSItemCategoryFabricForSearch(txtCategoryName.Text)
                If CkDt1.Rows.Count > 0 Then
                    dgItemCategory.DataSource = CkDt1
                    dgItemCategory.DataBind()
                    GetRights()
                Else
                    Dim dt As DataTable
                    dt = ObjIMSItemCategory.GetIMSItemCategoryFabric
                    dgItemCategory.DataSource = dt
                    dgItemCategory.DataBind()
                    GetRights()
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(lUserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim CkDt1 As DataTable = ObjIMSItemCategory.GetIMSItemCategoryFabricForSearch(txtCategoryName.Text)
                    If CkDt1.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt1
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dt As DataTable
                        dt = ObjIMSItemCategory.GetIMSItemCategoryFabric
                        dgItemCategory.DataSource = dt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCategoryAccForSearch(txtCategoryName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryAccessories
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCategoryAccForSearchGStore(txtCategoryName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryGStore
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCategoryAccForSearchForAuditor(txtCategoryName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAuditor()
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                Else
                    Dim CkDt2 As DataTable = ObjIMSItemCategory.GetIMSItemCategoryAccForSearchForAuditor(txtCategoryName.Text)
                    If CkDt2.Rows.Count > 0 Then
                        dgItemCategory.DataSource = CkDt2
                        dgItemCategory.DataBind()
                        GetRights()
                    Else
                        Dim dtt As DataTable
                        dtt = ObjIMSItemCategory.GetIMSItemCategoryAccessoriesForAuditor()
                        dgItemCategory.DataSource = dtt
                        dgItemCategory.DataBind()
                        GetRights()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
