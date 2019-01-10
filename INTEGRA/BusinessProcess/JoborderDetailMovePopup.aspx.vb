Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data.SqlClient
Public Class JoborderDetailMovePopup
    Inherits System.Web.UI.Page
    Dim objSeasonDatabase As New SeasonDatabase
    Dim objUser As New User
    Dim GeneralCode As New GeneralCode
    Dim UserId As Long
    Dim objSizeRange As New SizeRange
    Dim objJobOrderdatabase As New JobOrderdatabase
    Dim objJobOrderdatabaseDetail As New JobOrderdatabaseDetail
    Dim objJobOrderCertificateRequired As New JobOrderCertificateRequired
    Dim objJobOrderTestRequired As New JobOrderTestRequired
    Dim objPortDestinations As New PortDestinationsEntry
    Dim objBrandDatabase As New BrandDatabase
    Dim objShipmentMode As New ShipmentMode
    Dim lJoborderDetailid As Long
    Dim dt, dtPODetail As New DataTable
    Dim objGeneralCode As New GeneralCode
    Dim objStyle As New Style2
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim ObjPaymentTerm As New PaymentTerm
    Dim ObjPortOrigin As New PortOrigin
    Dim ObjPortLoad As New PortLoad
    Dim ObjStyleDatabaseClass As New StyleDatabaseClass
    Dim Type As String
    Dim dr As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lJoborderDetailid = Request.QueryString("JoborderDetailid")
        If Not Page.IsPostBack Then

            BindSeason()

        End If
    End Sub
    Protected Sub cmbSeasonName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSeasonName.SelectedIndexChanged
        If cmbSeasonName.SelectedItem.Text = "Select" Then
            BindSeason()
        Else
            BindSRNo()
        End If

    End Sub
    Function GetTimeSpame(ByVal DateFrom As Date, ByVal DateTo As Date)
        Dim tsTimeSpan As TimeSpan
        Dim iNumberOfDays As Integer
        tsTimeSpan = DateFrom.Subtract(DateTo)
        iNumberOfDays = tsTimeSpan.Days
        Return iNumberOfDays
    End Function
    Sub BindSeason()
        Dim dt As DataTable
        dt = objSizeRange.GetSeasons()
        cmbSeasonName.DataSource = dt
        cmbSeasonName.DataTextField = "SeasonName"
        cmbSeasonName.DataValueField = "SeasonDatabaseID"
        cmbSeasonName.DataBind()
        cmbSeasonName.Items.Insert(0, "Select")
    End Sub
    Sub BindSRNo()
        Dim dt As DataTable = objJobOrderdatabase.GetSRNONewForMove(cmbSeasonName.SelectedValue)
        CMBSRNo.DataSource = dt
        CMBSRNo.DataTextField = "SRNO"
        CMBSRNo.DataValueField = "JobOrderID"
        CMBSRNo.DataBind()
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbSeasonName.SelectedItem.Text = "Select" Then
                Errormgs.Text = "Select Season"
            ElseIf CMBSRNo.SelectedValue = 0 Then
                Errormgs.Text = "Select Sr No"
            Else
                Errormgs.Text = ""
                Dim dt As DataTable = objJobOrderdatabase.GetForMovePopup(lJoborderDetailid)
                With objJobOrderdatabaseDetail
                    .JoborderDetailid = 0 'dt.Rows(0)("JoborderDetailid")
                    .Joborderid = CMBSRNo.SelectedValue
                    .Style = dt.Rows(0)("Style")
                    .ItemDatabaseID = dt.Rows(0)("ItemDatabaseID")
                    .Content = dt.Rows(0)("Content")
                    .GSM = dt.Rows(0)("GSM")
                    .BuyerColor = dt.Rows(0)("BuyerColor")
                    .Quantity = dt.Rows(0)("Quantity")
                    .UOMID = dt.Rows(0)("UOMID")
                    .UnitPrice = dt.Rows(0)("UnitPrice")
                    .Value = dt.Rows(0)("value")
                    .StyleShipmentDate = dt.Rows(0)("StyleShipmentDate")
                    .AfterWashGsm = dt.Rows(0)("AfterWashGsm")
                    .DPRNDID = dt.Rows(0)("DPRNDID")
                    .ItemDesc = dt.Rows(0)("ItemDesc")
                    .ContentforBuyer = dt.Rows(0)("ContentforBuyer")
                    .ColorCode = dt.Rows(0)("ColorCode")
                    .ItemCode = dt.Rows(0)("ItemCode")
                    .IMSItemID = dt.Rows(0)("IMSItemID")
                    .Model = dt.Rows(0)("Model")
                    .Timespame = dt.Rows(0)("Timespame")
                    .SaveJobOrderDetail()
                End With
                Errormgs.Text = "Save Successfully"
                btnSave.Visible = False
                btnCancell.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
   
End Class