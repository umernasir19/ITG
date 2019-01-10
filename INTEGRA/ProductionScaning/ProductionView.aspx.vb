Imports Integra.eurocentra
Imports System.Data
Imports System.Data.DataTable
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System
Imports System.Web
Imports System.Reflection
Imports System.Net
Imports System.Net.Mail
Imports System.Xml
Public Class ProductionView
    Inherits System.Web.UI.Page
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim OBJGeneralcodee As New GeneralCode
    Dim objDataView, objMasterDataView As DataView
    Dim objDataTable As DataTable
    Dim Hr As Decimal
    Dim Min As Decimal
    Dim SS As Decimal
    Dim AMPM As String
    Dim currentdatetime As Date
    Dim SendEmail As Boolean
    Dim objAccCheckListDtl As New AccCheckListDtl
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objJobOrderdatabaseDetail As New JobOrderdatabaseDetail
    Dim objSizeRange As New SizeRange
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            PageHeader("Production View")
            BinSeason()
            Dim objDataTable As DataTable
            objDataTable = objAccCheckListDtl.GetproductionDateVise()
            Dgview2.DataSource = objDataTable
            Dgview2.DataBind()
            Dim x As Integer
            For x = 0 To Dgview2.Items.Count - 1
                Dgview2.Items(x).Cells(0).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(1).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(2).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(3).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(4).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(5).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(6).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(7).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(8).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(9).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(10).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(11).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(12).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(0).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(2).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(3).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(1).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(4).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(5).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(6).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(7).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(8).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(9).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(10).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(11).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(12).Font.Size = FontUnit.Large
            Next
            Dim GeneralCode As New GeneralCode
            Dim todaydate As String
            todaydate = GeneralCode.GetDateFormat(Date.Today)
            Dim dttodayS As DataTable = objAccCheckListDtl.GetTodayStitching(todaydate)
            Dim dttodayW As DataTable = objAccCheckListDtl.GetTodayWashing(todaydate)
            Dim dttodayRF As DataTable = objAccCheckListDtl.GetTodayRecvWash(todaydate)
            Dim dttodayF As DataTable = objAccCheckListDtl.GetTodayPacking(todaydate)
            lbls.Text = dttodayS.Rows(0)("TotalStitching").ToString
            lblW.Text = dttodayW.Rows(0)("TotalWashing").ToString
            lblRW.Text = dttodayRF.Rows(0)("TFAWashingRecv").ToString
            lblF.Text = dttodayF.Rows(0)("TotalFinishing").ToString
            lbls.BackColor = Drawing.Color.Green
            lblW.BackColor = Drawing.Color.Green
            lblF.BackColor = Drawing.Color.Green
            lblRW.BackColor = Drawing.Color.Green
            Pnlgmdaily.Visible = True
        Else
        End If
    End Sub
    Sub BinSeason()
        Dim dt As DataTable
        dt = objSizeRange.GetSeasonsForJobOrderVieeSearching()
        cmbSeason.DataSource = dt
        cmbSeason.DataTextField = "SeasonName"
        cmbSeason.DataValueField = "SeasonDatabaseID"
        cmbSeason.DataBind()
        cmbSeason.Items.Insert(0, "All")
        Dim dtt As DataTable = objSizeRange.GetSeasonsForJobOrderVieeSearchingGetSeasonId
        cmbSeason.SelectedValue = dtt.Rows(0)("SeasonDatabaseID")
    End Sub
    Protected Sub cmbSeason_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeason.SelectedIndexChanged
        If cmbSeason.SelectedItem.Text = "All" Then
            Dim objDataTable As DataTable
            objDataTable = objAccCheckListDtl.GetDataForProductionNew()
            Dgview2.DataSource = objDataTable
            Dgview2.DataBind()
            Dim x As Integer
            For x = 0 To Dgview2.Items.Count - 1
                Dgview2.Items(x).Cells(0).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(1).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(2).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(3).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(4).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(5).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(6).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(7).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(8).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(9).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(10).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(11).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(12).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(0).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(2).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(3).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(1).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(4).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(5).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(6).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(7).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(8).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(9).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(10).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(11).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(12).Font.Size = FontUnit.Large
            Next
        Else
            Dim objDataTable As DataTable
            objDataTable = objAccCheckListDtl.GetDataForProductionForSeasonViseSearchingNew(cmbSeason.SelectedValue)
            Dgview2.DataSource = objDataTable
            Dgview2.DataBind()
            Dim x As Integer
            For x = 0 To Dgview2.Items.Count - 1
                Dgview2.Items(x).Cells(0).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(1).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(2).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(3).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(4).BackColor = Drawing.Color.White
                Dgview2.Items(x).Cells(5).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(6).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(7).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(8).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(9).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(10).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(11).BackColor = Drawing.Color.LightBlue
                Dgview2.Items(x).Cells(12).BackColor = Drawing.Color.Red
                Dgview2.Items(x).Cells(0).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(2).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(3).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(1).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(4).Font.Size = FontUnit.Small
                Dgview2.Items(x).Cells(5).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(6).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(7).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(8).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(9).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(10).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(11).Font.Size = FontUnit.Large
                Dgview2.Items(x).Cells(12).Font.Size = FontUnit.Large
            Next
        End If
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Function LoadMasterDataNew() As ICollection
        Try
            Dim objMasterDataView As DataView
            Dim objDataTable As DataTable
            objDataTable = objAccCheckListDtl.GetDataForProductionNew()
            objMasterDataView = New DataView(objDataTable)
            Return objMasterDataView
        Catch ex As Exception
        End Try
    End Function
    Sub BindGrid2()
        Dim strSortExpression As String
        objMasterDataView = Session("objMasterDataView")
        If objMasterDataView.Count > 0 Then
            strSortExpression = Dgview2.SortExpression
            If strSortExpression <> "" Then
                objMasterDataView.Sort = strSortExpression
                If Not Dgview2.IsSortedAscending Then
                    objMasterDataView.Sort += " DESC"
                End If
            End If
            Dgview2.RecordCount = objMasterDataView.Count
            Dgview2.DataSource = objMasterDataView
            Dgview2.DataBind()
        Else
            Dgview2.DataSource = objMasterDataView
            Dgview2.DataBind()
        End If
        Dim x As Integer
        For x = 0 To Dgview2.Items.Count - 1
            Dgview2.Items(x).Cells(0).BackColor = Drawing.Color.White
            Dgview2.Items(x).Cells(1).BackColor = Drawing.Color.White
            Dgview2.Items(x).Cells(2).BackColor = Drawing.Color.White
            Dgview2.Items(x).Cells(3).BackColor = Drawing.Color.White
            Dgview2.Items(x).Cells(4).BackColor = Drawing.Color.White
            Dgview2.Items(x).Cells(5).BackColor = Drawing.Color.LightBlue
            Dgview2.Items(x).Cells(6).BackColor = Drawing.Color.LightBlue
            Dgview2.Items(x).Cells(7).BackColor = Drawing.Color.LightBlue
            Dgview2.Items(x).Cells(8).BackColor = Drawing.Color.Red
            Dgview2.Items(x).Cells(9).BackColor = Drawing.Color.LightBlue
            Dgview2.Items(x).Cells(10).BackColor = Drawing.Color.Red
            Dgview2.Items(x).Cells(11).BackColor = Drawing.Color.LightBlue
            Dgview2.Items(x).Cells(12).BackColor = Drawing.Color.Red
            Dgview2.Items(x).Cells(0).Font.Size = FontUnit.Small
            Dgview2.Items(x).Cells(2).Font.Size = FontUnit.Small
            Dgview2.Items(x).Cells(3).Font.Size = FontUnit.Small
            Dgview2.Items(x).Cells(1).Font.Size = FontUnit.Small
            Dgview2.Items(x).Cells(4).Font.Size = FontUnit.Small
            Dgview2.Items(x).Cells(5).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(6).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(7).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(8).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(9).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(10).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(11).Font.Size = FontUnit.Large
            Dgview2.Items(x).Cells(12).Font.Size = FontUnit.Large
        Next
    End Sub
End Class