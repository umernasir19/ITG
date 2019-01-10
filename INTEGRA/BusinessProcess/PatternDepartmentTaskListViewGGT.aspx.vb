Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Telerik.Web.UI.GridDataItem
Public Class PatternDepartmentTaskListViewGGT
    Inherits System.Web.UI.Page
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim objTblDPRND As New TblDPRND

    Dim objDPPOMst As New DPPOMst
    Dim Userid As Long
    Dim objDataView As DataView
    Dim TotalDone As Decimal = 0
    Dim TotalNotDone As Decimal = 0
    Dim Total As Decimal = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Userid = Session("UserId")
        If Not Page.IsPostBack Then
            TotalDone = 0
            TotalNotDone = 0
            Total = 0

            objDataView = LoadData()
            Session("objDataView") = objDataView
            BindGrid()
        End If

    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgRND.DataSource = objDataView
            dgRND.DataBind()

            Dim x As Integer
            For x = 0 To dgRND.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
                Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
                Dim Status As String = item("Status").Text
                Dim Bit As String = item("Bit").Text
                Dim ConStatus As String = item("ConStatus").Text
                Dim FinishTimeStamp As String = item("FinishTimeStamp").Text


                If ConStatus = 1 Then
                    item("ConStatus").Text = True
                    item("ConStatus").ForeColor = Drawing.Color.Green

                Else
                    item("ConStatus").Text = False
                    item("ConStatus").ForeColor = Drawing.Color.Red

                End If



                If Bit = 1 Then
                    If Status = 1 Then
                        ImageButton.ImageUrl = "~/Images/mail.jpg"
                    Else
                        ImageButton.ImageUrl = "~/Images/mail1.jpg"
                    End If
                End If


                If Bit = 1 Then
                    ImageButton.Visible = True
                    lnkEdit.Visible = True
                Else
                    ImageButton.Visible = False
                    lnkEdit.Visible = False
                End If


                If FinishTimeStamp <> "&nbsp;" And Bit = 1 Then
                    item("ConStatus").Text = True
                    item("ConStatus").ForeColor = Drawing.Color.Green
                End If



            Next
           

        Catch ex As Exception
        End Try
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        'objDataTable = objTblDPRND.GetBindGridForTaskListGGTViewNew()
        objDataTable = objTblDPRND.GetBindGridForTaskListGGTViewNewInProcessNew()
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Protected Sub btnAddSampling_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSampling.Click
        Try
            Response.Redirect("PatternDepartmentTaskListEntry.aspx")
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgRND_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgRND.NeedDataSource
     


        If RadioButtonList.SelectedItem.Text = "All" Then
            dgRND.DataSource = objTblDPRND.GetBindGridForTaskListGGTViewNewForNew()
            dgRND.Rebind()
            'dgRND.DataBind()
            'Dim x As Integer
            'For x = 0 To dgRND.Items.Count - 1
            '    Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
            '    Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
            '    Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
            '    Dim Status As String = item("Status").Text
            '    Dim Bit As String = item("Bit").Text
            '    Dim ConStatus As String = item("ConStatus").Text
            '    If ConStatus = 1 Then
            '        item("ConStatus").Text = True
            '        item("ConStatus").ForeColor = Drawing.Color.Green

            '        If Bit = 1 Then
            '            If Status = 1 Then
            '                ImageButton.ImageUrl = "~/Images/mail.jpg"
            '            Else
            '                ImageButton.ImageUrl = "~/Images/mail1.jpg"
            '            End If
            '        End If

            '        If Bit = 1 Then
            '            ImageButton.Visible = True
            '            lnkEdit.Visible = True
            '        Else
            '            ImageButton.Visible = False
            '            lnkEdit.Visible = False
            '        End If


            '    Else
            '        item("ConStatus").Text = False
            '        item("ConStatus").ForeColor = Drawing.Color.Red
            '        If Bit = 1 Then
            '            If Status = 1 Then
            '                ImageButton.ImageUrl = "~/Images/mail.jpg"
            '            Else
            '                ImageButton.ImageUrl = "~/Images/mail1.jpg"
            '            End If
            '        End If

            '        If Bit = 1 Then
            '            ImageButton.Visible = True
            '            lnkEdit.Visible = True
            '        Else
            '            ImageButton.Visible = False
            '            lnkEdit.Visible = False
            '        End If
            '    End If
            'Next
        ElseIf RadioButtonList.SelectedItem.Text = "Completed" Then
            dgRND.DataSource = objTblDPRND.GetBindGridForTaskListGGTViewNewProcessNew()
            dgRND.Rebind()
            '      dgRND.DataBind()
            'Dim x As Integer
            '      For x = 0 To dgRND.Items.Count - 1
            '          Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
            '          Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
            '          Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
            '          Dim Status As String = item("Status").Text
            '          Dim Bit As String = item("Bit").Text
            '          Dim ConStatus As String = item("ConStatus").Text
            '          If ConStatus = 1 Then
            '              item("ConStatus").Text = True
            '              item("ConStatus").ForeColor = Drawing.Color.Green
            '              If Bit = 1 Then
            '                  If Status = 1 Then
            '                      ImageButton.ImageUrl = "~/Images/mail.jpg"
            '                  Else
            '                      ImageButton.ImageUrl = "~/Images/mail1.jpg"
            '                  End If
            '              End If

            '              If Bit = 1 Then
            '                  ImageButton.Visible = True
            '                  lnkEdit.Visible = True
            '              Else
            '                  ImageButton.Visible = False
            '                  lnkEdit.Visible = False
            '              End If
            '          Else
            '              item("ConStatus").Text = False
            '              item("ConStatus").ForeColor = Drawing.Color.Red
            '              If Bit = 1 Then
            '                  If Status = 1 Then
            '                      ImageButton.ImageUrl = "~/Images/mail.jpg"
            '                  Else
            '                      ImageButton.ImageUrl = "~/Images/mail1.jpg"
            '                  End If
            '              End If

            '              If Bit = 1 Then
            '                  ImageButton.Visible = True
            '                  lnkEdit.Visible = True
            '              Else
            '                  ImageButton.Visible = False
            '                  lnkEdit.Visible = False
            '              End If
            '          End If
            '      Next
        ElseIf RadioButtonList.SelectedItem.Text = "In Process" Then

            dgRND.DataSource = objTblDPRND.GetBindGridForTaskListGGTViewNewInProcessNew()
          



            Dim x As Integer
            For x = 0 To dgRND.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
                Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
                Dim Status As String = item("Status").Text
                Dim Bit As String = item("Bit").Text
                Dim ConStatus As String = item("ConStatus").Text
                If ConStatus = True Then
                    item("ConStatus").ForeColor = Drawing.Color.Green
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                Else
                    item("ConStatus").Text = False
                    item("ConStatus").ForeColor = Drawing.Color.Red
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                End If
            Next


        Else

        End If
    End Sub
    Protected Sub dgRND_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgRND.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgRND_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgRND.PageIndexChanged
        'objDataView = LoadData()
        'Session("objDataView") = objDataView
        BindGrid()
    End Sub
    Protected Sub dgRND_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgRND.SortCommand
        BindGrid()
    End Sub
    'Protected Sub dgRND_ItemDataBound(ByVal source As Object, ByVal e As GridCommandEventArgs)

    '    'objDataView = LoadData()
    '    'Session("objDataView") = objDataView
    '    'BindGrid()

    '    If TypeOf e.Item Is GridFilteringItem Then
    '        Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
    '        Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(0), GridDataItem)
    '        item.Attributes.Add("OnClick", "return show();")
    '    End If
    'End Sub
    'Protected Sub dgRND_ItemDataBound(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles dgRND.ItemDataBound
    '    If TypeOf e.Item Is GridDataItem Then

    '        Dim x As Integer
    '        For x = 0 To dgRND.Items.Count - 1
    '            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
    '            Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
    '            Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
    '            Dim Status As String = item("Status").Text
    '            Dim Bit As String = item("Bit").Text

    '            If Bit = 1 Then
    '                If Status = 1 Then
    '                    ImageButton.ImageUrl = "~/Images/mail.jpg"
    '                Else
    '                    ImageButton.ImageUrl = "~/Images/mail1.jpg"
    '                End If
    '            End If

    '            If Bit = 1 Then
    '                ImageButton.Visible = True
    '                lnkEdit.Visible = True
    '            Else
    '                ImageButton.Visible = False
    '                lnkEdit.Visible = False
    '            End If


    '        Next
    '    End If
    'objDataView = LoadData()
    'Session("objDataView") = objDataView
    'BindGrid()
    'End Sub
    Protected Sub RadioButtonList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonList.SelectedIndexChanged
        If RadioButtonList.SelectedItem.Text = "All" Then
            Dim DT As DataTable = objTblDPRND.GetBindGridForTaskListGGTViewNewForNew()

            dgRND.DataSource = DT
            dgRND.DataBind()
            Dim x As Integer
            For x = 0 To dgRND.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
                Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
                Dim Status As String = item("Status").Text
                Dim Bit As String = item("Bit").Text
                Dim ConStatus As String = item("ConStatus").Text
                If ConStatus = 1 Then
                    item("ConStatus").Text = True
                    item("ConStatus").ForeColor = Drawing.Color.Green

                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If


                Else
                    item("ConStatus").Text = False
                    item("ConStatus").ForeColor = Drawing.Color.Red
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                End If
            Next
        ElseIf RadioButtonList.SelectedItem.Text = "Completed" Then
            Dim DT As DataTable = objTblDPRND.GetBindGridForTaskListGGTViewNewProcessNew()
            dgRND.DataSource = DT
            dgRND.DataBind()
            Dim x As Integer
            For x = 0 To dgRND.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
                Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
                Dim Status As String = item("Status").Text
                Dim Bit As String = item("Bit").Text
                Dim ConStatus As String = item("ConStatus").Text
                If ConStatus = 1 Then
                    item("ConStatus").Text = True
                    item("ConStatus").ForeColor = Drawing.Color.Green
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                Else
                    item("ConStatus").Text = False
                    item("ConStatus").ForeColor = Drawing.Color.Red
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                End If
            Next
        ElseIf RadioButtonList.SelectedItem.Text = "In Process" Then
            Dim DT As DataTable = objTblDPRND.GetBindGridForTaskListGGTViewNewInProcessNew()
            dgRND.DataSource = DT
            dgRND.DataBind()
            Dim x As Integer
            For x = 0 To dgRND.Items.Count - 1
                Dim item As GridDataItem = DirectCast(dgRND.MasterTableView.Items(x), GridDataItem)
                Dim ImageButton As ImageButton = CType(dgRND.Items(x).FindControl("lnkAccessoriese"), ImageButton)
                Dim lnkEdit As HyperLink = CType(dgRND.Items(x).FindControl("lnkEdit"), HyperLink)
                Dim Status As String = item("Status").Text
                Dim Bit As String = item("Bit").Text
                Dim ConStatus As String = item("ConStatus").Text
                If ConStatus = 1 Then
                    item("ConStatus").Text = True
                    item("ConStatus").ForeColor = Drawing.Color.Green
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                Else
                    item("ConStatus").Text = False
                    item("ConStatus").ForeColor = Drawing.Color.Red
                    If Bit = 1 Then
                        If Status = 1 Then
                            ImageButton.ImageUrl = "~/Images/mail.jpg"
                        Else
                            ImageButton.ImageUrl = "~/Images/mail1.jpg"
                        End If
                    End If

                    If Bit = 1 Then
                        ImageButton.Visible = True
                        lnkEdit.Visible = True
                    Else
                        ImageButton.Visible = False
                        lnkEdit.Visible = False
                    End If
                End If
            Next

        End If
    End Sub
End Class