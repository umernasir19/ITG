Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Public Class POReceiveView
    Inherits System.Web.UI.Page
    Dim objPOMaster As New POMaster
    Dim objPORecvMaster As New PORecvMaster
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim userid As Long
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Dim ObjSupplier As New SupplierDataBase
    Dim FormRoleId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        userid = Session("UserId")
        If Not Page.IsPostBack Then
            Try
                GetRights()
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
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
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
            Else
                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
            End If
        Next
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim dt As DataTable = ObjSupplier.GetUserStatus(userid)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    objDataTable = objPORecvMaster.GetPORECforViewFabricNewNew()
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    objDataTable = objPORecvMaster.GetPORECforViewFabricNewNewForAcc()
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    objDataTable = objPORecvMaster.GetPORECforViewFabricNewNewForAccGStore()
                Else
                    objDataTable = objPORecvMaster.GetPORECforViewFabricNewNewForAll()
                End If
            End If
        End If
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If userid = 19 Then
            Response.Redirect("FabricPOReceiveEntry.aspx")
        Else
            Response.Redirect("POReceiveEntry.aspx")
        End If
    End Sub
    Protected Sub txtShowMe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShowMe.TextChanged
        Try
            If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
                Dim dt1 As DataTable = objPORecvMaster.GetPOStatusPONOVise(txtShowMe.Text)
                Dim dt2 As DataTable = objPORecvMaster.GetPOStatusStyleVise(txtShowMe.Text)
                Dim dt3 As DataTable = objPORecvMaster.GetPOStatusItemVise(txtShowMe.Text)
                Dim dt4 As DataTable = objPORecvMaster.GetPOStatusSupplierVise(txtShowMe.Text)
                If dt1.Rows.Count > 0 Then
                    dgView.DataSource = dt1
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                        ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                        Else
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                        End If
                    Next
                ElseIf dt2.Rows.Count > 0 Then
                    dgView.DataSource = dt2
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                        ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                        Else
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                        End If
                    Next
                ElseIf dt3.Rows.Count > 0 Then
                    dgView.DataSource = dt3
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                        ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                        Else
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                        End If
                    Next
                ElseIf dt4.Rows.Count > 0 Then
                    dgView.DataSource = dt4
                    dgView.DataBind()
                    Dim x As Integer
                    For x = 0 To dgView.Items.Count - 1
                        If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                        ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                        Else
                            dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                            dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                        End If
                    Next
                End If
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    Dim dt1 As DataTable = objPORecvMaster.GetPOStatusPONOVise(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetPOStatusStyleVise(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetPOStatusItemVise(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetPOStatusSupplierVise(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then

                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    Dim dt1 As DataTable = objPORecvMaster.GetPOStatusPONOViseForAcc(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetPOStatusStyleViseForAcc(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetPOStatusItemViseForAcc(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetPOStatusSupplierViseForAcc(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    End If
                ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                    Dim dt1 As DataTable = objPORecvMaster.GetPOStatusPONOViseForAccGstore(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetPOStatusStyleViseForAccGStore(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetPOStatusItemViseForAccGStore(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetPOStatusSupplierViseForAccGStore(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    End If
                Else
                    Dim dt1 As DataTable = objPORecvMaster.GetPOStatusPONOViseForAll(txtShowMe.Text)
                    Dim dt2 As DataTable = objPORecvMaster.GetPOStatusStyleViseForAll(txtShowMe.Text)
                    Dim dt3 As DataTable = objPORecvMaster.GetPOStatusItemViseForAll(txtShowMe.Text)
                    Dim dt4 As DataTable = objPORecvMaster.GetPOStatusSupplierViseForAll(txtShowMe.Text)
                    If dt1.Rows.Count > 0 Then
                        dgView.DataSource = dt1
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt2.Rows.Count > 0 Then
                        dgView.DataSource = dt2
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt3.Rows.Count > 0 Then
                        dgView.DataSource = dt3
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    ElseIf dt4.Rows.Count > 0 Then
                        dgView.DataSource = dt4
                        dgView.DataBind()
                        Dim x As Integer
                        For x = 0 To dgView.Items.Count - 1
                            If Val(dgView.Items(x).Cells(8).Text) <= 0 Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Green
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Green
                            ElseIf Val(dgView.Items(x).Cells(8).Text) > Val(dgView.Items(x).Cells(7).Text) Then
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Red
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Red
                            Else
                                dgView.Items(x).Cells(7).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(9).BackColor = Drawing.Color.Yellow
                                dgView.Items(x).Cells(8).BackColor = Drawing.Color.Yellow
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class



