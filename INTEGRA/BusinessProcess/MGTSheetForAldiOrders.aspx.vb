Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class MGTSheetForAldiOrders
    Inherits System.Web.UI.Page
    Dim objPo As New PurchaseOrder
    Dim objFinishingLine As New FinishingLine
    Dim objCuttingStatuss As New CuttingStatuss
    Dim objStitchingStatus As New StitchingStatus
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Expires = 0
        Dim objDataview As DataView
        If Not Page.IsPostBack Then
            Try
                objDataview = LoadData()
                Session("objDataView") = objDataview
                BindGrid()
            Catch ex As Exception

            End Try
        End If
    End Sub
    ' Procedure that Binds the Grid
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgMGTSheetForAldiOrders.DataSource = objDataView
        dgMGTSheetForAldiOrders.DataBind()

    End Sub
    Function LoadData() As ICollection
        Try
            Dim objDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objPo.GetMasterOrderForAldiOrders()
            objDataView = New DataView(objDataTable)
            Return objDataView
        Catch ex As Exception
        End Try
    End Function
    Protected Sub dgMGTSheetForAldiOrders_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles dgMGTSheetForAldiOrders.NeedDataSource
        dgMGTSheetForAldiOrders.DataSource = objPo.GetMasterOrderForAldiOrders()
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgMGTSheetForAldiOrders.ItemCreated
        If TypeOf e.Item Is GridFilteringItem Then
            Dim filterItem As GridFilteringItem = DirectCast(e.Item, GridFilteringItem)
        End If
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles dgMGTSheetForAldiOrders.PageIndexChanged
        BindGrid()
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles dgMGTSheetForAldiOrders.SortCommand
        BindGrid()
    End Sub
    Protected Sub dgMGTSheetForAldiOrders_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles dgMGTSheetForAldiOrders.ItemCommand
        Select Case e.CommandName
            Case Is = "FinishingLineStatus"
                Dim dtcheck As New DataTable
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                If CLng(Session("Userid")) = 78 Then
                    'If (Directory.Exists(Server.MapPath("~/ProductionUpdate/FinishingLine"))) Then
                    '    Dim strFileSize As String = ""
                    '    Dim di As New IO.DirectoryInfo(Server.MapPath("~/ProductionUpdate/FinishingLine"))
                    '    Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                    '    Dim fi As IO.FileInfo
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    '    For Each fi In aryFi
                    '        Response.ClearHeaders()
                    '        Response.ClearContent()
                    '        Response.ContentType = "application/octet-stream"
                    '        Response.Charset = "UTF-8"
                    '        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    '        Response.WriteFile(Server.MapPath("~/ProductionUpdate/FinishingLine/" & fi.Name & ""))
                    '        Response.End()
                    '    Next
                    'Else
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                    'End If
                    Dim st As StringBuilder = New StringBuilder()
                    st.Append("<script language='javascript'>")
                    st.Append("var w = window.open('FinishingLineView.aspx?IPOID=" & lPOID & "','PopUpWindowName','left=50, top=150, height=600, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                    st.Append("w.focus()")
                    st.Append("</script>")
                    Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
                Else
                    dtcheck = objFinishingLine.CheckExisting(lPOID)
                    If dtcheck.Rows.Count > 0 Then
                        Response.Redirect("FinishingLineEntry.aspx?IFinishingLineID=" & dtcheck.Rows(0)("FinishingLineID") & "")
                    Else
                        Response.Redirect("FinishingLineEntry.aspx")
                    End If
                End If
            Case Is = "CuttingLineStatus"
                Dim dtcheck As New DataTable
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                If CLng(Session("Userid")) = 78 Then
                    Dim Report As New ReportDocument
                    Dim Options As New ExportOptions

                    Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
                    di.Create()
                    Report.Load(Server.MapPath("..\Reports/CuttingStatusReport.rpt"))

                    Dim FileName As String = "Cutting Status-" + item("PONO").Text
                    Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
                    Report.SetParameterValue(0, lPOID)
                    Dim FileOption As New DiskFileDestinationOptions
                    FileOption.DiskFileName = sTempFileName
                    Options = Report.ExportOptions
                    Options.ExportDestinationType = ExportDestinationType.DiskFile
                    Options.ExportFormatType = ExportFormatType.PortableDocFormat
                    Options.DestinationOptions = FileOption
                    Options.ExportDestinationOptions = FileOption
                    Report.SetDatabaseLogon("sa", "pwd")
                    Report.Export()

                    Dim strFileSize As String = ""
                    Dim ExistFIleName As String = "Cutting Status-" + item("PONO").Text + ".pdf"
                    Dim aryFi As IO.FileInfo() = di.GetFiles(ExistFIleName)

                    Dim fi As IO.FileInfo
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    For Each fi In aryFi
                        Response.ClearHeaders()
                        Response.ClearContent()
                        Response.ContentType = "application/octet-stream"
                        Response.Charset = "UTF-8"
                        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                        Response.WriteFile((Server.MapPath("~/TempPDF/" & fi.Name & "")))
                        Response.End()
                    Next

                    'If (Directory.Exists(Server.MapPath("~/ProductionUpdate/Cutting"))) Then
                    '    Dim strFileSize As String = ""
                    '    Dim di As New IO.DirectoryInfo(Server.MapPath("~/ProductionUpdate/Cutting"))
                    '    Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                    '    Dim fi As IO.FileInfo
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    '    For Each fi In aryFi
                    '        Response.ClearHeaders()
                    '        Response.ClearContent()
                    '        Response.ContentType = "application/octet-stream"
                    '        Response.Charset = "UTF-8"
                    '        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                    '        Response.WriteFile(Server.MapPath("~/ProductionUpdate/Cutting/" & fi.Name & ""))
                    '        Response.End()
                    '    Next
                    'Else
                    '    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                    'End If


                    'Dim st As StringBuilder = New StringBuilder()
                    'st.Append("<script language='javascript'>")
                    'st.Append("var w = window.open('CuttingStatusView.aspx?IPOID=" & lPOID & "','PopUpWindowName','left=50, top=150, height=600, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                    'st.Append("w.focus()")
                    'st.Append("</script>")
                    'Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
                Else
                    dtcheck = objCuttingStatuss.CheckExisting(lPOID)
                    If dtcheck.Rows.Count > 0 Then
                        Response.Redirect("CuttingStatus.aspx?CuttingStatusID=" & dtcheck.Rows(0)("CuttingStatusID") & "")
                    Else
                        Response.Redirect("CuttingStatus.aspx")
                    End If
                End If
            Case Is = "StitchingLineStatus"
                Dim dtcheck As New DataTable
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                If CLng(Session("Userid")) = 78 Then
                    If (Directory.Exists(Server.MapPath("~/ProductionUpdate/Stitching"))) Then
                        Dim strFileSize As String = ""
                        Dim di As New IO.DirectoryInfo(Server.MapPath("~/ProductionUpdate/Stitching"))
                        Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                        Dim fi As IO.FileInfo
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                        For Each fi In aryFi
                            Response.ClearHeaders()
                            Response.ClearContent()
                            Response.ContentType = "application/octet-stream"
                            Response.Charset = "UTF-8"
                            Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                            Response.WriteFile(Server.MapPath("~/ProductionUpdate/Stitching/" & fi.Name & ""))
                            Response.End()
                        Next
                    Else
                        DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                    End If
                    'Dim st As StringBuilder = New StringBuilder()
                    'st.Append("<script language='javascript'>")
                    'st.Append("var w = window.open('StitchingStatusView.aspx?IPOID=" & lPOID & "','PopUpWindowName','left=50, top=150, height=600, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                    'st.Append("w.focus()")
                    'st.Append("</script>")
                    'Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
                Else
                    dtcheck = objStitchingStatus.CheckExisting(lPOID)
                    If dtcheck.Rows.Count > 0 Then
                        Response.Redirect("StitchingStatusEntry.aspx?StitchingStatusID=" & dtcheck.Rows(0)("StitchingStatusID") & "")
                    Else
                        Response.Redirect("StitchingStatusEntry.aspx")
                    End If

                End If
            Case Is = "CriticalPath"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                Dim st As StringBuilder = New StringBuilder()
                st.Append("<script language='javascript'>")
                st.Append("var w = window.open('TNAChartPopup.aspx?lPOID=" & lPOID & "','PopUpWindowName','left=50, top=100, height=600, width=900, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no,titlebar=0');") '//opens the pop up
                st.Append("w.focus()")
                st.Append("</script>")
                Page.RegisterStartupScript("PopUpwindowOpen", st.ToString())
            Case Is = "PO"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                If (Directory.Exists(Server.MapPath("~/SystemGeneratedPDF/" & lPOID & "/MGT"))) Then
                    Dim strFileSize As String = ""
                    Dim di As New IO.DirectoryInfo(Server.MapPath("~/SystemGeneratedPDF/" & lPOID & "/MGT"))
                    Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                    Dim fi As IO.FileInfo
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    For Each fi In aryFi
                        Response.ClearHeaders()
                        Response.ClearContent()
                        Response.ContentType = "application/octet-stream"
                        Response.Charset = "UTF-8"
                        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                        Response.WriteFile(Server.MapPath("~/SystemGeneratedPDF/" & lPOID & "/MGT/" & fi.Name & ""))
                        Response.End()
                    Next
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                End If
            Case Is = "OriginalContract"
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lPOID As Long = item("POID").Text
                If (Directory.Exists(Server.MapPath("~/OriginalPurchaseorderPDF/" & lPOID & ""))) Then
                    Dim strFileSize As String = ""
                    Dim di As New IO.DirectoryInfo(Server.MapPath("~/OriginalPurchaseorderPDF/" & lPOID & ""))
                    Dim aryFi As IO.FileInfo() = di.GetFiles("*.pdf")
                    Dim fi As IO.FileInfo
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae(" ")
                    For Each fi In aryFi
                        Response.ClearHeaders()
                        Response.ClearContent()
                        Response.ContentType = "application/octet-stream"
                        Response.Charset = "UTF-8"
                        Response.AddHeader("content-disposition", "attachment; filename=" & fi.Name)
                        Response.WriteFile(Server.MapPath("~/OriginalPurchaseorderPDF/" & lPOID & "/" & fi.Name & ""))
                        Response.End()
                    Next
                Else
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("File Not Found")
                End If

        End Select
    End Sub

End Class