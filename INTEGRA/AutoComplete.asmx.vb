Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Configuration
Imports Integra.EuroCentra
Imports Integra.classes
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
'<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
'<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
'<ToolboxItem(False)> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class AutoComplete
    Inherits System.Web.Services.WebService
    Dim dt As New DataTable
    Dim objStyleMaster As New StyleMaster
    Dim objDPFabricDbMst As New DPFabricDbMst
    Dim ObjDPBuyerComment As New DPBuyerComment
    Dim objPOMaster As New POMaster
    Dim objPODetail As New PODetail
    Dim Item As String
    Dim ObjIMSItemCategory As New IMSItemCategory
    Dim YearFirst, YearSecond As String
    Dim VoucherType As String
    Dim dtDetail, dtdata As DataTable
    Dim objIMSStoreIssue As New IMSStoreIssue
    Dim SeasonDatabaseId As Long
    Dim objPORecvMaster As New PORecvMaster
    Dim ObjSupplier As New SupplierDataBase
    Dim dyewash As New DPFabricDbMst
    <WebMethod(EnableSession:=True)> _
    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
        YearFirst = Session("ClickBit")
        VoucherType = Session("VoucherType")
        SeasonDatabaseId = Session("SeasonDatabaseId")
        If count = 0 Then
            count = 10
        End If
        Dim dt As New DataTable
        If contextKey = "SearchStyle" Then
            dt = GetJournalVoucherNo(prefixText)
        ElseIf contextKey = "ENQStyle" Then
            dt = GetStyleNo(prefixText)
        ElseIf contextKey = "INQStyle" Then
            dt = GetStyleNoinq(prefixText)
        ElseIf contextKey = "INSPPO" Then
            dt = GetINSPPO(prefixText)
        ElseIf contextKey = "CargoInv" Then
            dt = GetCargoInv(prefixText)
        ElseIf contextKey = "SearchDalNo" Then
            dt = GetDalNo(prefixText)
        ElseIf contextKey = "SearchDalNoFromFStore" Then
            dt = GetDalNoFromFStore(prefixText)
        ElseIf contextKey = "SearchDSINo" Then
            dt = GetDSINo(prefixText)
        ElseIf contextKey = "SearchDSRNo" Then
            dt = GetDSRNo(prefixText)
        ElseIf contextKey = "SearchWashNo" Then
            dt = GetWashNo(prefixText)
        ElseIf contextKey = "SearchDCDNo" Then
            dt = GetDCDNo(prefixText)
        ElseIf contextKey = "SearchStyleNo" Then
            dt = GetStyleNoFromStyleDatabase(prefixText)
        ElseIf contextKey = "SupplierNameFromJobOrder" Then
            dt = GetSupplierNameFromJobOrder(prefixText)
        ElseIf contextKey = "DalNoFromJobOrder" Then
            dt = GetDALNOFromJobOrder(prefixText)
        ElseIf contextKey = "StyleNoFromJobOrder" Then
            dt = GetStyleNoFromJobOrderNew(prefixText)
        ElseIf contextKey = "PODetail" Then
            dt = GetPartyFromPODetail(prefixText)
        ElseIf contextKey = "PODetailSummary" Then
            dt = GetPartyFromPODetailSummary(prefixText)
        ElseIf contextKey = "TblPartyforInvoice" Then
            dt = GetSupplierNameFromJobOrder(prefixText)
        ElseIf contextKey = "TblPartyforInvoicee" Then
            dt = GetSupplierNameForFStore(prefixText)
        ElseIf contextKey = "FabricPlanning" Then
            dt = GetFabricForPlanning(prefixText)
        ElseIf contextKey = "Accessories" Then
            dt = GetItemFab(prefixText)
        ElseIf contextKey = "ItemFromJobOrder" Then
            dt = GetItemCodeFabNewNew(prefixText)
        ElseIf contextKey = "Searching" Then
            dt = SRNO(prefixText)
        ElseIf contextKey = "ItemNameFStore" Then
            dt = GetItemnameForFStore(prefixText)
        ElseIf contextKey = "ItemQualityFStore" Then
            dt = GetItemQualityForFStore(prefixText)
        ElseIf contextKey = "CategoryName" Then
            dt = CategoryName(prefixText)
        ElseIf contextKey = "ClassNameForItemCategory" Then
            dt = ClassName(prefixText)
        ElseIf contextKey = "ShadeForAstore" Then
            dt = ShadeForAstore(prefixText)
        ElseIf contextKey = "ItemCodeForIssue" Then
            dt = GetItemCodeForIssue(prefixText)
        ElseIf contextKey = "ItemCodeForIssueProcess" Then
            dt = GetItemCodeForIssueProcess(prefixText)
        ElseIf contextKey = "SearchSRNoForFabricConsupmtion" Then
            dt = GetSrNoForFabricConsumption(prefixText)
        ElseIf contextKey = "CodeForAstore" Then
            dt = ItemCodeeForAstore(prefixText)
        ElseIf contextKey = "DalNoForFstore" Then
            dt = DalNoForFstore(prefixText)
        ElseIf contextKey = "DalRefForFstore" Then
            dt = DalRefForFstore(prefixText)
        ElseIf contextKey = "TXTCodeEntry" Then
            dt = GetItemCodeForFStore(prefixText)
        ElseIf contextKey = "SearchBuyerName" Then
            dt = GetBuyerName(prefixText)
        ElseIf contextKey = "AccountNameForContra" Then
            dt = GetAccountNameForContra(prefixText)
        ElseIf contextKey = "ShoInfoData" Then
            dt = GetAccountInfoData(prefixText)
        ElseIf contextKey = "AccountName" Then
            dt = GetAccountName(prefixText)
        ElseIf contextKey = "INVShowme" Then
            dt = GetINVNo(prefixText)
        ElseIf contextKey = "tblBankMst" Then
            dt = GetVoucherNo(prefixText)
        ElseIf contextKey = "SearchAccessThread" Then
            dt = GetItemCodeAccessThread(prefixText)
        ElseIf contextKey = "CodeForAstoreZipper" Then
            dt = GetItemCodeAccessZipper(prefixText)
        ElseIf contextKey = "IssueCode" Then
            dt = GetIssueCode(prefixText)
        ElseIf contextKey = "AccountLedger" Then
            dt = GetAccountLedger(prefixText)
        ElseIf contextKey = "AccountNamewithcode" Then
            dt = GetAccountNameWthCode(prefixText)
        ElseIf contextKey = "AccountNameCode" Then
            dt = GetAccountNameWithCode(prefixText)
        ElseIf contextKey = "SupplierSearch" Then
            dt = GetLedgerSupplier(prefixText)
        ElseIf contextKey = "txtautoLedger" Then
            dt = GetAllLedgerForLedgerReport(prefixText)
        ElseIf contextKey = "SearchingFromStyleAssorment" Then
            dt = BrandBuyerStyleSrNoFromStyleAssorment(prefixText)
        ElseIf contextKey = "SearchingFromSizeWeight" Then
            dt = BrandBuyerStyleSrNoFromSizeWeight(prefixText)
        ElseIf contextKey = "SearchingFromStyleAssormentForBarCodeView" Then
            dt = BrandBuyerStyleSrNoFromStyleAssormentForBarCodeView(prefixText)
        ElseIf contextKey = "SearchingBarCodeViewColorVise" Then
            dt = ColorBarCodeView(prefixText)
        ElseIf contextKey = "ShowInfoDataonEntry" Then
            dt = GetAccountInfoDataonEntry(prefixText)
        ElseIf contextKey = "ItemCodeForProcessIssue" Then
            dt = GetItemCodeForProcessIssue(prefixText)
        ElseIf contextKey = "SearchingFromStyleAssormentForCheckList" Then
            dt = BrandBuyerStyleSrNoFromStyleAssormentForChecklist(prefixText)
        ElseIf contextKey = "SearchingFromRNDSupplierView" Then
            dt = RNDSupplierView(prefixText)
        ElseIf contextKey = "tblJVMst" Then
            dt = GetJournalVoucherNoNew(prefixText)
        ElseIf contextKey = "tblCV" Then
            dt = GetcASHVoucherNoNew(prefixText)
        ElseIf contextKey = "CostCenter" Then
            dt = GetCostCenter(prefixText)
        ElseIf contextKey = "FinishGSMForFDB" Then
            dt = GetFinishWidthForFDB(prefixText)
        ElseIf contextKey = "CompositionForFDB" Then
            dt = GetCompositionForFDB(prefixText)
        ElseIf contextKey = "LCNo" Then
            dt = GetLCNO(prefixText)
        ElseIf contextKey = "SearchCommodity" Then
            dt = GetCommodity(prefixText)
        ElseIf contextKey = "SearchChemName" Then
            dt = GetItemnameForChemicalStore(prefixText)
        ElseIf contextKey = "SearchChemName" Then
            dt = GetItemnameForChemicalStore(prefixText)
        ElseIf contextKey = "SearchSRNO" Then
            dt = GetSrNo(prefixText)
        ElseIf contextKey = "SearchColor" Then
            dt = GetColorway(prefixText)
        ElseIf contextKey = "ItemCodeForProcessIssueNew" Then
            dt = GetFabricCode(prefixText)
        ElseIf contextKey = "GetItems" Then
            dt = GetItemNames(prefixText)
        ElseIf contextKey = "GetPoReceivingSearching" Then
            dt = GetPoReceivingSearching(prefixText)
        ElseIf contextKey = "GetPoEntrySearching" Then
            dt = GetPoEntrySearching(prefixText)
        ElseIf contextKey = "GetPoStatusSearching" Then
            dt = GetPoStatusSearching(prefixText)
        ElseIf contextKey = "TXTCodeEntryForReport" Then
            dt = GetItemCodeForFStoreForReport(prefixText)
        ElseIf contextKey = "GetIssueSearching" Then
            dt = GetPoIssueedSearching(prefixText)
        ElseIf contextKey = "GetProcessStatusSearching" Then
            dt = GetProcessStatusSearching(prefixText)
        ElseIf contextKey = "TXTProcessCodeEntryForReport" Then
            dt = GetProcessItemCodeForFStoreForReport(prefixText)
        ElseIf contextKey = "GetPoIssuedSearching" Then
            dt = GetPoIssuedSearching(prefixText)
        ElseIf contextKey = "GetProcessEntrySearching" Then
            dt = GetProcessEntrySearching(prefixText)
        ElseIf contextKey = "GetProcessReceivingSearching" Then
            dt = GetProcessReceivingSearching(prefixText)
        ElseIf contextKey = "GetProcessIssuedSearching" Then
            dt = GetProcessIssuedSearching(prefixText)
        ElseIf contextKey = "ItemCodeForGodownSearch" Then
            dt = GetItemCodeForGodownSearch(prefixText)
        ElseIf contextKey = "GodownViewSearch" Then
            dt = GetGodownViewSearching(prefixText)
        ElseIf contextKey = "SearchDalRefNoFromFStore" Then
            dt = GetDalRefNoFromFStore(prefixText)
        ElseIf contextKey = "GodownViewSearchForProcess" Then
            dt = GetGodownViewSearchingForProcess(prefixText)
        ElseIf contextKey = "ItemCodeForGodownSearchForProcess" Then
            dt = GetItemCodeForGodownSearchForProcess(prefixText)
        ElseIf contextKey = "TXTCodeEntryForPurchase" Then
            dt = GetItemCodeForFStoreForPurchase(prefixText)
        ElseIf contextKey = "DALNoFromCalculation" Then
            dt = GetItemCodeForFStoreForPurchase(prefixText)
        ElseIf contextKey = "ItemFromJobOrderNew" Then
            dt = GetItemCodeFabNewNewNewNew(prefixText)
        ElseIf contextKey = "SrnoForAccPO" Then
            dt = GetSrNoForAccPO(prefixText)
        ElseIf contextKey = "GetPoEntrySearchingForAstore" Then
            dt = GetPoEntrySearchingForAstore(prefixText)
        ElseIf contextKey = "GetPoEntrySearchingForAuditor" Then
            dt = GetPoEntrySearchingForAuditor(prefixText)
        ElseIf contextKey = "GetPoReceivingSearchingForAuditor" Then
            dt = GetPoReceivingSearchingForAuditor(prefixText)
        ElseIf contextKey = "GetPoIssuedSearchingForAuditor" Then
            dt = GetPoIssuedSearchingForAuditor(prefixText)
        ElseIf contextKey = "TXTCodeEntryForProcessIssueReport" Then
            dt = GetCodeEntryForProcessIssueReport(prefixText)
        ElseIf contextKey = "ItemCategoryForItemInventoryReport" Then
            dt = ItemCategoryForItemInventoryReport(prefixText)
        ElseIf contextKey = "ItemCategoryForItemInventoryReportForProcess" Then
            dt = ItemCategoryForItemInventoryReportForProcess(prefixText)
        ElseIf contextKey = "DyeWash" Then
            dt = GetDyeWash(prefixText)
        ElseIf contextKey = "ShipmetView" Then
            dt = GetShipmentViewData(prefixText)
        ElseIf contextKey = "TXTPONO" Then
            dt = GetPONOOOOOOOOOO(prefixText)
        End If
        Dim items As New List(Of String)(count)
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim strName As String = dt.Rows(i)(0).ToString()
            items.Add(strName)
        Next
        Return items.ToArray()
    End Function
    Public Function GetPONOOOOOOOOOO(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        dt1 = objStyleMaster.GetPONOOOOO(strName)
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function ItemCategoryForItemInventoryReportForProcess(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetstoreItemCategoryForInventoryReportForFSTOREForProcess(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function ItemCategoryForItemInventoryReport(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetstoreItemCategoryForInventoryReportForFSTORE(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            dt1 = ObjIMSItemCategory.GetstoreItemCategoryForInventoryReportForAUDITOR(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            dt1 = ObjIMSItemCategory.GetstoreItemCategoryForInventoryReportForASTORE(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function GetCodeEntryForProcessIssueReport(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        dt1 = objStyleMaster.GetItemCodeForFStoreForProcessIssueReport(strName)
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function GetPoIssuedSearchingForAuditor(ByVal strName As String) As DataTable
       
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
        dt1 = objPODetail.GetPoissuePONOForAutitor(strName)
            dt2 = objPODetail.GetPoIssuedManualChallanNo(strName)
            dt3 = objPODetail.GetIssuedFabricCodeviseSearching(strName)
            dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWise(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
    End Function
    Public Function GetPoReceivingSearchingForAuditor(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONO(strName)
            dt2 = objPODetail.GetPoRecevStyle(strName)
            dt3 = objPODetail.GetPoRecevSupplier(strName)
            dt4 = objPODetail.GetPoRecevItem(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONOForACC(strName)
            dt2 = objPODetail.GetPoRecevStyleForAcc(strName)
            dt3 = objPODetail.GetPoRecevSupplierForACC(strName)
            dt4 = objPODetail.GetPoRecevItemForAcc(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONOForAuditor(strName)
            dt2 = objPODetail.GetPoRecevStyleForAuditor(strName)
            dt3 = objPODetail.GetPoRecevSupplierForAuditor(strName)
            dt4 = objPODetail.GetPoRecevItemForAuditor(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        End If
    End Function
    Public Function GetDalNoFromFabricPlanning(ByVal strName As String) As DataTable

        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable

        dt1 = objPOMaster.GETDalnoFromFabricPlanning(strName)
        dt2 = objPOMaster.GETAUTOItemCodeNewForDalRefno(strName)

        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If


    End Function
    Public Function GetItemCodeForGodownSearchForProcess(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        If UserId = 241 Then
            dt1 = objStyleMaster.GETItemCodeForIssueForFStoreGodownSearchForprocess(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GETItemCodeForIssueForFStoreGodownSearchForprocess(strName)
        ElseIf UserId = 242 Then
            dt1 = objStyleMaster.GETItemCodeForIssueForAStore(strName)
        End If
        Return dt1
    End Function
    Public Function GetGodownViewSearchingForProcess(ByVal strName As String) As DataTable

        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        dt1 = objPODetail.GetSivNoForProcess(strName)
        dt2 = objPODetail.GetItemCodeForGodownSearchingForProcess(strName)
        dt3 = objPODetail.GetFromLocationForGodownSearchingForProcess(strName)
        dt4 = objPODetail.GetToLocationForGodownSearchingForProcess(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        End If
    End Function
    Public Function GetDalRefNoFromFStore(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GetDalRefNoFromFStore(strName)
        Return dt

    End Function
    Public Function GetGodownViewSearching(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetSivNo(strName)
            dt2 = objPODetail.GetItemCodeForGodownSearching(strName)
            dt3 = objPODetail.GetFromLocationForGodownSearching(strName)
            dt4 = objPODetail.GetToLocationForGodownSearching(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetSivNo(strName)
                dt2 = objPODetail.GetItemCodeForGodownSearching(strName)
                dt3 = objPODetail.GetFromLocationForGodownSearching(strName)
                dt4 = objPODetail.GetToLocationForGodownSearching(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetSivNo(strName)
                dt2 = objPODetail.GetItemCodeForGodownSearching(strName)
                dt3 = objPODetail.GetFromLocationForGodownSearching(strName)
                dt4 = objPODetail.GetToLocationForGodownSearching(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If

            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetSivNo(strName)
                dt2 = objPODetail.GetItemCodeForGodownSearching(strName)
                dt3 = objPODetail.GetFromLocationForGodownSearching(strName)
                dt4 = objPODetail.GetToLocationForGodownSearching(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If

            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then

                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetSivNo(strName)
                dt2 = objPODetail.GetItemCodeForGodownSearching(strName)
                dt3 = objPODetail.GetFromLocationForGodownSearching(strName)
                dt4 = objPODetail.GetToLocationForGodownSearching(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            Else
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetSivNo(strName)
                dt2 = objPODetail.GetItemCodeForGodownSearching(strName)
                dt3 = objPODetail.GetFromLocationForGodownSearching(strName)
                dt4 = objPODetail.GetToLocationForGodownSearching(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            End If
        End If
    End Function
    Public Function GetItemCodeForGodownSearch(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GETItemCodeForIssueForFStoreGodownSearch(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = objStyleMaster.GETItemCodeForIssueForFStoreGodownSearch(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt1 = objStyleMaster.GETItemCodeForIssueForFStoreGodownSearchForAcc(strName)
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt1 = objStyleMaster.GETItemCodeForIssueForFStoreGodownSearchForGSTore(strName)
            End If
        End If
        Return dt1
    End Function
    Public Function GetProcessIssuedSearching(ByVal strName As String) As DataTable

        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable

        dt1 = objPODetail.GetProcessissuePONO(strName)
        dt2 = objPODetail.GetProcessIssuedManualChallanNo(strName)
        dt3 = objPODetail.GetIssuedFabricCodeviseSearchingProcess(strName)
        dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWiseProcess(strName)

        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        End If
    End Function
    Public Function GetProcessReceivingSearching(ByVal strName As String) As DataTable

        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        dt1 = objPODetail.GetProcessRecevPONO(strName)
        dt2 = objPODetail.GetProcessRecevStyle(strName)
        dt3 = objPODetail.GetProcessRecevSupplier(strName)
        dt4 = objPODetail.GetProcessRecevItem(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        End If
    End Function
    Public Function GetProcessEntrySearching(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        dt1 = objPODetail.GetProcessEntryPONO(strName)
        dt2 = objPODetail.GetProcessEntrySupplier(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If
    End Function
    Public Function GetPoIssuedSearching(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoissuePONO(strName)
            dt2 = objPODetail.GetPoIssuedManualChallanNo(strName)
            dt3 = objPODetail.GetIssuedFabricCodeviseSearching(strName)
            dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWise(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetPoissuePONO(strName)
                dt2 = objPODetail.GetPoIssuedManualChallanNo(strName)
                dt3 = objPODetail.GetIssuedFabricCodeviseSearching(strName)
                dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWise(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetPoissuePONOForAcc(strName)
                dt2 = objPODetail.GetPoIssuedManualChallanNoForAcc(strName)
                dt3 = objPODetail.GetIssuedFabricCodeviseSearchingForAcc(strName)
                dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWiseForAcc(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetPoissuePONOForAccGSTore(strName)
                dt2 = objPODetail.GetPoIssuedManualChallanNoForAcc(strName)
                dt3 = objPODetail.GetIssuedFabricCodeviseSearchingForAccGStore(strName)
                dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWiseForAccGStore(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            Else
                Dim dt1 As DataTable
                Dim dt2 As DataTable
                Dim dt3 As DataTable
                Dim dt4 As DataTable
                dt1 = objPODetail.GetPoissuePONOForAll(strName)
                dt2 = objPODetail.GetPoIssuedManualChallanNoForAll(strName)
                dt3 = objPODetail.GetIssuedFabricCodeviseSearchingForAll(strName)
                dt4 = objPODetail.GetIssuedFabricCodeviseSearchingdeopartmentWiseForAll(strName)
                If dt1.Rows.Count > 0 Then
                    Return dt1
                ElseIf dt2.Rows.Count > 0 Then
                    Return dt2
                ElseIf dt3.Rows.Count > 0 Then
                    Return dt3
                ElseIf dt4.Rows.Count > 0 Then
                    Return dt4
                End If
            End If
        End If
    End Function
    Public Function GetProcessItemCodeForFStoreForReport(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        If UserId = 241 Then
            dt1 = objStyleMaster.GetProcessItemCodeForFStoreForReport(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function GetProcessStatusSearching(ByVal strName As String) As DataTable

        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        dt1 = objPODetail.GetProcessStatusPONO(strName)
        dt2 = objPODetail.GetProcessStatusStyle(strName)
        dt3 = objPODetail.GetProcessStatusSupplier(strName)
        dt4 = objPODetail.GetProcessStatusItem(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        End If
    End Function
    Public Function GetPoIssueedSearching(ByVal strName As String) As DataTable

        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        dt1 = objPODetail.GetPoIssuedPONO(strName)
        dt2 = objPODetail.GetPoIssuedFabricCode(strName)
        dt3 = objPODetail.GetPoIssuedMaunalChalanNo(strName)
        dt4 = objPODetail.GetPoIssueDepartment(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        End If
    End Function
    Public Function GetItemCodeForFStoreForReport(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
           dt1 = objStyleMaster.GetItemCodeForFStoreForReport(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForReportForAcc(strName)
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForReportForAccGStore(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForReportForAccForAuditor(strName)
        Else
            dt1 = objStyleMaster.GetItemCodeForFStoreForReportForAccForAuditor(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function GetPoStatusSearching(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoStatusPONO(strName)
            dt2 = objPODetail.GetPoStatusStyle(strName)
            dt3 = objPODetail.GetPoStatusSupplier(strName)
            dt4 = objPODetail.GetPoStatusItem(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoStatusPONOForaCC(strName)
            dt2 = objPODetail.GetPoStatusStyleForAcc(strName)
            dt3 = objPODetail.GetPoStatusSupplierForAcc(strName)
            dt4 = objPODetail.GetPoStatusItemForACC(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoStatusPONOForaCCGStore(strName)
            dt2 = objPODetail.GetPoStatusStyleForAccGStore(strName)
            dt3 = objPODetail.GetPoStatusSupplierForAccGstore(strName)
            dt4 = objPODetail.GetPoStatusItemForACCGStore(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        Else
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoStatusPONOForall(strName)
            dt2 = objPODetail.GetPoStatusStyleForAll(strName)
            dt3 = objPODetail.GetPoStatusSupplierForAll(strName)
            dt4 = objPODetail.GetPoStatusItemForAll(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        End If
    End Function
    Public Function GetPoEntrySearchingForAstore(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim UserId As Long = Session("UserId")
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(userid)
        If DtCheck.Rows(0)("Department") = "Acc Store" Then
            dt1 = objPODetail.GetPoEntryPONOForAstore(strName)
            dt2 = objPODetail.GetPoEntrySupplierForAstore(strName)
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            dt1 = objPODetail.GetPoEntryPONOForAstoreGStore(strName)
            dt2 = objPODetail.GetPoEntrySupplierForAstoreGStore(strName)
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If
    End Function
    Public Function GetShipmentViewData(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable

        dt1 = objPODetail.GetShipmentViewNumberingno(strName)
        dt2 = objPODetail.GetShipmentViewSeason(strName)
        dt3 = objPODetail.GetShipmentViewCustomer(strName)
        dt4 = objPODetail.GetShipmentViewSrNo(strName)
        dt5 = objPODetail.GetShipmentViewBrand(strName)
       
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        ElseIf dt5.Rows.Count > 0 Then
            Return dt5
        End If
    End Function
    Public Function GetPoEntrySearchingForAuditor(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        dt1 = objPODetail.GetPoEntryPONO(strName)
        dt2 = objPODetail.GetPoEntrySupplier(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If
    End Function
    Public Function GetPoEntrySearching(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        dt1 = objPODetail.GetPoEntryPONO(strName)
        dt2 = objPODetail.GetPoEntrySupplier(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If
    End Function
    Public Function GetPoReceivingSearching(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONO(strName)
            dt2 = objPODetail.GetPoRecevStyle(strName)
            dt3 = objPODetail.GetPoRecevSupplier(strName)
            dt4 = objPODetail.GetPoRecevItem(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONOForACC(strName)
            dt2 = objPODetail.GetPoRecevStyleForAcc(strName)
            dt3 = objPODetail.GetPoRecevSupplierForACC(strName)
            dt4 = objPODetail.GetPoRecevItemForAcc(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONOForACCGStore(strName)
            dt2 = objPODetail.GetPoRecevStyleForAccGStore(strName)
            dt3 = objPODetail.GetPoRecevSupplierForACCGstore(strName)
            dt4 = objPODetail.GetPoRecevItemForAccGStore(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        Else
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            dt1 = objPODetail.GetPoRecevPONOForAll(strName)
            dt2 = objPODetail.GetPoRecevStyleForAll(strName)
            dt3 = objPODetail.GetPoRecevSupplierForAll(strName)
            dt4 = objPODetail.GetPoRecevItemForAll(strName)
            If dt1.Rows.Count > 0 Then
                Return dt1
            ElseIf dt2.Rows.Count > 0 Then
                Return dt2
            ElseIf dt3.Rows.Count > 0 Then
                Return dt3
            ElseIf dt4.Rows.Count > 0 Then
                Return dt4
            End If
        End If
    End Function
    Public Function GetItemNames(ByVal strName As String) As DataTable
        Try
            dt = objPOMaster.GetItemNamesList(strName)
            Return dt
        Catch ex As Exception

        End Try
    End Function
    Public Function GetSrNoForAccPO(ByVal strName As String) As DataTable
        Dim SeasonDatabaseID As String
        SeasonDatabaseID = Session("SeasonDatabaseID")
        If SeasonDatabaseID = "" Then
            dt = ObjIMSItemCategory.GETSRNoAutoSearchForGetSeasonId()
            Dim ID As Long = dt.Rows(0)("SeasondatabaseID")
            dt = ObjIMSItemCategory.GETSRNoAutoSearch(ID, strName)
        Else
            dt = ObjIMSItemCategory.GETSRNoAutoSearch(SeasonDatabaseID, strName)
        End If
        Return dt
    End Function
    Public Function GetSrNo(ByVal strName As String) As DataTable
        Dim SeasonDatabaseID As String
        SeasonDatabaseID = Session("SeasonDatabaseID")
        dt = ObjIMSItemCategory.GETSRNoAutoSearch(SeasonDatabaseID, strName)
        Return dt
    End Function
    Public Function GetColorway(ByVal strName As String) As DataTable
        Dim Joborderid As String
        Dim SeasonDatabaseID As String
        SeasonDatabaseID = Session("SeasonDatabaseID")
        Joborderid = Session("Joborderid")

        dt = ObjIMSItemCategory.GETColorAutoSearch(SeasonDatabaseID, Joborderid, strName)


        Return dt

    End Function
    Public Function GetItemnameForChemicalStore(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
       If UserId = 251 Then
            dt1 = objStyleMaster.GetItemForChemicalStore(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        End If
    End Function
    Public Function BrandBuyerStyleSrNoFromStyleAssormentForBarCodeView(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Production" Then
            dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForBarCodeView(strName)
            dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForBarCodeView(strName)
            dt3 = ObjIMSItemCategory.GetStyleFromStyleAssormentForBarCodeView(strName)
            dt4 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForBarCodeView(strName)
            dt5 = ObjIMSItemCategory.GetSrNoFromSeasonAssormentForBarCodeView(strName)
        Else
            If UserId = 248 Then
                dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForBarCodeView(strName)
                dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForBarCodeView(strName)
                dt3 = ObjIMSItemCategory.GetStyleFromStyleAssormentForBarCodeView(strName)
                dt4 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForBarCodeView(strName)
                dt5 = ObjIMSItemCategory.GetSrNoFromSeasonAssormentForBarCodeView(strName)
            End If
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        ElseIf dt5.Rows.Count > 0 Then
            Return dt5
        End If


    End Function
    Public Function ColorBarCodeView(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Production" Then
            dt1 = ObjIMSItemCategory.ColorBarCodeView(strName)
        Else
            If UserId = 248 Then
                dt1 = ObjIMSItemCategory.ColorBarCodeView(strName)
            End If
        End If
       
        If dt1.Rows.Count > 0 Then
            Return dt1
        End If
    End Function
    Public Function BrandBuyerStyleSrNoFromStyleAssorment(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(UserId)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                dt1 = ObjIMSItemCategory.GetBrandFromStyleAssorment(strName)
                dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssorment(strName)
                dt3 = ObjIMSItemCategory.GetStyleFromStyleAssorment(strName)
                dt4 = ObjIMSItemCategory.GetSrNoFromStyleAssorment(strName)
                dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentNew(strName)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Merchandising" Then
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssorment(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssorment(strName)
                    dt3 = ObjIMSItemCategory.GetStyleFromStyleAssorment(strName)
                    dt4 = ObjIMSItemCategory.GetSrNoFromStyleAssorment(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentNew(strName)
                Else
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssorment(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssorment(strName)
                    dt3 = ObjIMSItemCategory.GetStyleFromStyleAssorment(strName)
                    dt4 = ObjIMSItemCategory.GetSrNoFromStyleAssorment(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentNew(strName)
                End If
            End If
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        ElseIf dt5.Rows.Count > 0 Then
            Return dt5
        End If
    End Function
    Public Function BrandBuyerStyleSrNoFromSizeWeight(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        If UserId = 245 Then
            dt1 = ObjIMSItemCategory.GetBrandFromSizeWeight(strName)
            dt2 = ObjIMSItemCategory.GetBuyerFromSizeWeight(strName)
            dt3 = ObjIMSItemCategory.GetStyleFromSizeWeight(strName)
            dt4 = ObjIMSItemCategory.GetSrNoFromSizeWeight(strName)
            dt5 = ObjIMSItemCategory.GetSeasonFromSizeWeight(strName)
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        ElseIf dt5.Rows.Count > 0 Then
            Return dt5
        End If


    End Function
    Public Function GetCommodity(ByVal strName As String) As DataTable
        dt = ObjDPBuyerComment.GetCommodity(strName)
        Return dt

    End Function
    Public Function GetLCNO(ByVal strName As String) As DataTable
        dt = ObjDPBuyerComment.GetLCNOFromLCEntry(strName)
        Return dt

    End Function
    Public Function GetJournalVoucherNoNew(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETJV(strName)
        Return dt

    End Function
    Public Function GetcASHVoucherNoNew(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETCV(strName)
        Return dt

    End Function
    Public Function GetCostCenter(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETCostCenter(strName)
        Return dt

    End Function
    Public Function GetCompositionForFDB(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETCompositionFromFDB(strName)
        Return dt

    End Function
    Public Function GetFinishWidthForFDB(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETFinishWidthFromFDB(strName)
        Return dt

    End Function
    Public Function GetAccountInfoDataonEntry(ByVal strName As String) As DataTable

        dt = ObjIMSItemCategory.GETAUTOAllLedger(strName)
        Return dt

    End Function
    Public Function GetAllLedgerForLedgerReport(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAllLedgerForLedgerRPT(strName)
        Return dt

    End Function
    Public Function GetLedgerSupplier(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETSupplierSearch(strName)
        Return dt
    End Function
    Public Function GetAccountNameWithCode(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAccountNameSearch(strName)
        Return dt

    End Function
    Public Function GetAccountNameWthCode(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAUTOAccountNamewithCodeNew(strName)
        Return dt

    End Function
    Public Function GetAccountLedger(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAccountLedgerAutoSearch(strName)
        Return dt

    End Function
    Public Function GetIssueCode(ByVal strName As String) As DataTable
        dt = objStyleMaster.GetIssue(strName)
        Return dt

    End Function
    Public Function GetVoucherNo(ByVal strName As String) As DataTable
        dt = ObjIMSItemCategory.GETAUTOFOrDigital(strName)
        Return dt

    End Function
    Public Function GetINVNo(ByVal strName As String) As DataTable
        Dim Supplier As String
        Supplier = Session("Supplier")
        If Supplier = "" Then
            dt = ObjIMSItemCategory.GETInvAutoSearch(strName)
        Else
            dt = ObjIMSItemCategory.GETInvAutoSearch2(strName, Supplier)
        End If

        Return dt

    End Function
    Public Function GetAccountName(ByVal strName As String) As DataTable
        If VoucherType = "Contra Voucher" Then
            dt = ObjIMSItemCategory.GETAUTOAccountNameForNaeemContraVoucher(strName)
        Else
            dt = ObjIMSItemCategory.GETAUTOAccountNameForNaeem(strName)
        End If

        Return dt

    End Function

    Public Function GetAccountInfoData(ByVal strName As String) As DataTable

        dt = ObjIMSItemCategory.GETAUTO(strName, YearFirst)
        Return dt

    End Function
    Public Function GetAccountNameForContra(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GETAUTOAccountNameForNaeemContraVoucher(strName)
        Return dt

    End Function
    Public Function DalNoForFstore(ByVal strName As String) As DataTable

        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt5 = ObjIMSItemCategory.GetFstoreDalNo(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetFstoreDalNo(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = ObjIMSItemCategory.GetFstoreDalNo(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = ObjIMSItemCategory.GetFstoreDalNoForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt2 = ObjIMSItemCategory.GetAstoreDalNoForAccess(strName)
                Else
                    dt2 = ObjIMSItemCategory.GetAstoreDalNo(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then       
                dt2 = ObjIMSItemCategory.GetAstoreDalNoGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt5 = ObjIMSItemCategory.GetFstoreDalNo(strName)
            Else
                dt1 = ObjIMSItemCategory.GetFstoreDalNoForAuditor(strName)
            End If  
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2

        ElseIf IsNothing(dt5) = False Then
            Return dt5
        End If

    End Function
    Public Function DalRefForFstore(ByVal strName As String) As DataTable

        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt5 = ObjIMSItemCategory.GetFstoreDalRef(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetFstoreDalRef(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = ObjIMSItemCategory.GetFstoreDalRef(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = ObjIMSItemCategory.GetFstoreDalRefForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt2 = ObjIMSItemCategory.GetAstoreDalRefForAccess(strName)
                Else
                    dt2 = ObjIMSItemCategory.GetAstoreDalRef(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then     
                dt2 = ObjIMSItemCategory.GetAstoreDalRefGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt5 = ObjIMSItemCategory.GetFstoreDalRef(strName)
            Else
                dt1 = ObjIMSItemCategory.GetFstoreDalRefForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt5) = False Then
            Return dt5
        End If
    End Function
    Public Function RNDSupplierView(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
       
        If UserId = 237 Then
            dt1 = ObjIMSItemCategory.GetSupplierNameForRND(strName)
            dt2 = ObjIMSItemCategory.GetSuppliereCodeForRND(strName)
            dt3 = ObjIMSItemCategory.GetSuppliereCategoryForRND(strName)
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
    End If
    End Function
    Public Function RequisitionAndDepartment(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        If UserId = 245 Then
            dt1 = ObjIMSItemCategory.GetBrandFromStyleAssorment(strName)
            dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssorment(strName)
            dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssorment(strName)
            dt4 = ObjIMSItemCategory.GetStyleFromStyleAssorment(strName)
            dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssorment(strName)
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        ElseIf dt5.Rows.Count > 0 Then
            Return dt5
        End If
    End Function
    Public Function BrandBuyerStyleSrNoFromStyleAssormentForChecklist(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt As DataTable = ObjSupplier.GetUserStatus(UserId)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Department") = "Higher Management" Then
                dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForChecklist(strName)
                dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForChecklist(strName)
                dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForChecklist(strName)
                dt4 = ObjIMSItemCategory.GetStyleFromStyleAssormentForChecklist(strName)
                dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentForChecklist(strName)
            Else
                Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
                If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForChecklist(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForChecklist(strName)
                    dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForChecklist(strName)
                    dt4 = ObjIMSItemCategory.GetStyleFromStyleAssormentForChecklist(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentForChecklist(strName)
                ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForChecklist(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForChecklist(strName)
                    dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForChecklist(strName)
                    dt4 = ObjIMSItemCategory.GetStyleFromStyleAssormentForChecklist(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentForChecklist(strName)
                ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForChecklist(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForChecklist(strName)
                    dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForChecklist(strName)
                    dt4 = ObjIMSItemCategory.GetStyleFromStyleAssormentForChecklist(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentForChecklist(strName)
                ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForChecklist(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForChecklist(strName)
                    dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForChecklist(strName)
                    dt4 = ObjIMSItemCategory.GetStyleFromStyleAssormentForChecklist(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentForChecklist(strName)
                Else
                    dt1 = ObjIMSItemCategory.GetBrandFromStyleAssormentForChecklist(strName)
                    dt2 = ObjIMSItemCategory.GetBuyerFromStyleAssormentForChecklist(strName)
                    dt3 = ObjIMSItemCategory.GetSrNoFromStyleAssormentForChecklist(strName)
                    dt4 = ObjIMSItemCategory.GetStyleFromStyleAssormentForChecklist(strName)
                    dt5 = ObjIMSItemCategory.GetSeasonFromStyleAssormentForChecklist(strName)
                End If
            End If
        End If
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        ElseIf dt5.Rows.Count > 0 Then
            Return dt5
        End If
    End Function
    Public Function GetItemFab(ByVal strName As String) As DataTable
        dt = objPOMaster.GETAUTOItemFabName(strName)
        Return dt

    End Function
    Public Function GetItemCodeFab(ByVal strName As String) As DataTable
        dt = objPOMaster.GETAUTOItemCode(strName)
        Return dt

    End Function
    Public Function GetItemCodeFabNew(ByVal strName As String) As DataTable
        dt = objPOMaster.GETAUTOItemCodeNew(strName)
        Return dt

    End Function
    Public Function GetItemCodeFabNewNewNewNew(ByVal strName As String) As DataTable

        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable


        dt1 = objPOMaster.GETAUTOItemCodeNew(strName)
        dt2 = objPOMaster.GETAUTOItemCodeNewForDalRefno(strName)


        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If


    End Function
    Public Function GetItemCodeFabNewNew(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim DtCheckk As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheckk.Rows(0)("Department") = "Merchandising" Then
            dt1 = objPOMaster.GETAUTOItemCodeNew(strName)
            dt2 = objPOMaster.GETAUTOItemCodeNewForDalRefno(strName)
        End If

        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        End If
       

    End Function
    Public Function GetItemCodeAccessThread(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        dt1 = objPOMaster.GETAUTOItemCodeAccessThread(strName)
        Return dt1
    End Function
    Public Function GetItemCodeAccessZipper(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        dt1 = objPOMaster.GETAUTOItemCodeAccessZipper(strName)
        Return dt1
    End Function
    Public Function GetFabricForPlanning(ByVal strName As String) As DataTable
        dt = objStyleMaster.GetFabricItem(strName)
        Return dt

    End Function
    Public Function GetItemnameForFStore(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt5 = objStyleMaster.GetItemForFStore(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GetItemForFStore(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = objStyleMaster.GetItemForFStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = objStyleMaster.GetItemForFStoreForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt2 = objStyleMaster.GetItemForAStoreForAccess(strName)
                Else
                    dt2 = objStyleMaster.GetItemForAStore(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then    
                dt2 = objStyleMaster.GetItemForGGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt5 = objStyleMaster.GetItemForFStore(strName)
            Else
                dt1 = objStyleMaster.GetItemForFStoreForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt3) = False Then
            Return dt3
        ElseIf IsNothing(dt4) = False Then
            Return dt4
        ElseIf IsNothing(dt5) = False Then
            Return dt5
        ElseIf IsNothing(dt6) = False Then
            Return dt6
        End If
    End Function
    Public Function GetItemCodeForFStore(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            dt1 = objStyleMaster.GetItemCodeForFStore(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            dt2 = objStyleMaster.GetItemCodeForAStore(strName)
        ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
            dt2 = objStyleMaster.GetItemCodeForAStoreGStore(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForAuditor(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GetItemCodeForFStore(strName)
        Else
            dt1 = objStyleMaster.GetItemCodeForFStoreForAuditor(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        End If
    End Function
    Public Function GetItemCodeForFStoreForPurchase(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
        If DtCheck.Rows(0)("Department") = "Fabric Store" Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForPurchase(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
            dt2 = objStyleMaster.GetItemCodeForFStoreForPurchaseForAcc(strName)
        ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForPurchaseForAuditor(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GetItemCodeForFStoreForPurchase(strName)
        Else
            dt1 = objStyleMaster.GetItemCodeForFStoreForPurchaseForAuditor(strName)
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        End If
    End Function
    Public Function GetItemQualityForFStore(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt5 = objStyleMaster.GetItemQualityForFStore(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GetItemQualityForFStore(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = objStyleMaster.GetItemQualityForFStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = objStyleMaster.GetItemQualityForFStoreForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt2 = objStyleMaster.GetItemQualityForAStoreForAccess(strName)
                Else
                    dt2 = objStyleMaster.GetItemQualityForAStore(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt2 = objStyleMaster.GetItemQualityForGGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt5 = objStyleMaster.GetItemQualityForFStore(strName)
            Else
                dt1 = objStyleMaster.GetItemQualityForFStoreForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt3) = False Then
            Return dt3
        ElseIf IsNothing(dt4) = False Then
            Return dt4
        ElseIf IsNothing(dt5) = False Then
            Return dt5
        ElseIf IsNothing(dt6) = False Then
            Return dt6
        End If
    End Function
    Public Function SRNO(ByVal strName As String) As DataTable
        Dim dtSt As DataTable
        Dim dtCs As DataTable
        Dim dtSr As DataTable
        Dim dtPo As DataTable
        dtSr = objStyleMaster.GetSRNO(strName)
        dtCs = objStyleMaster.GetCustomerNmae(strName)
        dtSt = objStyleMaster.GetStyleNo(strName)
        dtPo = objStyleMaster.GetPON(strName)
        If dtSt.Rows.Count > 0 Then
            Return dtSt
        ElseIf dtCs.Rows.Count > 0 Then
            Return dtCs
        ElseIf dtSr.Rows.Count > 0 Then
            Return dtSr
        ElseIf dtPo.Rows.Count > 0 Then
            Return dtPo
        End If
        Return dt
    End Function
    Public Function CategoryName(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClass(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClass(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClass(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClassForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClassGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt1 = ObjIMSItemCategory.GetAstoreCategoryNameAndClassForAccess(strName)
                Else
                    dt1 = ObjIMSItemCategory.GetAstoreCategoryNameAndClass(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClass(strName)
            Else
                dt1 = ObjIMSItemCategory.GetFstoreCategoryNameAndClassForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt3) = False Then
            Return dt3
        ElseIf IsNothing(dt4) = False Then
            Return dt4
        ElseIf IsNothing(dt5) = False Then
            Return dt5
        ElseIf IsNothing(dt6) = False Then
            Return dt6
        End If
    End Function
    Public Function ClassName(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetFstoreClassName(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt1 = ObjIMSItemCategory.GetFstoreClassName(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = ObjIMSItemCategory.GetFstoreClassName(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = ObjIMSItemCategory.GetFstoreClassNameForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt1 = ObjIMSItemCategory.GetFstoreClassNameGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt1 = ObjIMSItemCategory.GetAstoreClassNameForAccess(strName)
                Else
                    dt1 = ObjIMSItemCategory.GetAstoreClassName(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt1 = ObjIMSItemCategory.GetFstoreClassName(strName)
            Else
                dt1 = ObjIMSItemCategory.GetFstoreClassNameForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt3) = False Then
            Return dt3
        ElseIf IsNothing(dt4) = False Then
            Return dt4
        ElseIf IsNothing(dt5) = False Then
            Return dt5
        ElseIf IsNothing(dt6) = False Then
            Return dt6
        End If
    End Function
    Public Function ShadeForAstore(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt5 = ObjIMSItemCategory.GetFstoreShade(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetFstoreShade(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = ObjIMSItemCategory.GetFstoreShade(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = ObjIMSItemCategory.GetFstoreShadeForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt2 = ObjIMSItemCategory.GetAstoreShadeForAccess(strName)
                Else
                    dt2 = ObjIMSItemCategory.GetAstoreShade(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then   
                dt2 = ObjIMSItemCategory.GetAstoreShadeGSTORE(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt5 = ObjIMSItemCategory.GetFstoreShade(strName)
            Else
                dt1 = ObjIMSItemCategory.GetFstoreShadeForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt3) = False Then
            Return dt3
        ElseIf IsNothing(dt4) = False Then
            Return dt4

        ElseIf IsNothing(dt5) = False Then
            Return dt5

        ElseIf IsNothing(dt6) = False Then
            Return dt6
        End If
    End Function
    Public Function ItemCodeeForAstore(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        Dim dt5 As DataTable
        Dim dt6 As DataTable
        If Session("RoleId") = 46 And Session("Type") = "Merchandising" Then
            dt5 = ObjIMSItemCategory.GetFstoreItemCode(strName)
        ElseIf Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = ObjIMSItemCategory.GetFstoreItemCode(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = ObjIMSItemCategory.GetFstoreItemCode(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Internal Auditor" Then
                dt1 = ObjIMSItemCategory.GetFstoreItemCodeForAuditor(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Or DtCheck.Rows(0)("Department") = "Dead Store" Then
                If UserId = 273 Then
                    dt2 = ObjIMSItemCategory.GetAstoreItemCodeeForAccess(strName)
                Else
                    dt2 = ObjIMSItemCategory.GetAstoreItemCodee(strName)
                End If
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt2 = ObjIMSItemCategory.GetAstoreItemCodeeGStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Merchandising" Then
                dt5 = ObjIMSItemCategory.GetFstoreItemCode(strName)
            Else
                dt1 = ObjIMSItemCategory.GetFstoreItemCodeForAuditor(strName)
            End If
        End If
        If IsNothing(dt1) = False Then
            Return dt1
        ElseIf IsNothing(dt2) = False Then
            Return dt2
        ElseIf IsNothing(dt3) = False Then
            Return dt3
        ElseIf IsNothing(dt4) = False Then
            Return dt4
        ElseIf IsNothing(dt5) = False Then
            Return dt5
        ElseIf IsNothing(dt6) = False Then
            Return dt6
        End If
    End Function
    Public Function GetPartyFromPODetailSummary(ByVal strName As String) As DataTable
        ' Item = Session("TxtShow")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        dt1 = objPODetail.GetPartyAccountFromPODetail(strName)
        ' dt2 = objPODetail.GetItemFromPODetail(strName)
        dt3 = objPODetail.GetPOFromPOMaster(strName)
        'dt4 = objPODetail.GetAccFromPOMaster(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
            'ElseIf dt2.Rows.Count > 0 Then
            '    Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
            'ElseIf dt4.Rows.Count > 0 Then
            '    Return dt4
        End If
    End Function
    Public Function GetPartyFromPODetail(ByVal strName As String) As DataTable
        Item = Session("TxtShow")
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim dt4 As DataTable
        dt1 = objPODetail.GetPartyAccountFromPODetail(strName)
        dt2 = objPODetail.GetItemFromPODetail(strName)
        dt3 = objPODetail.GetPOFromPOMaster(strName)
        dt4 = objPODetail.GetAccFromPOMaster(strName)
        If dt1.Rows.Count > 0 Then
            Return dt1
        ElseIf dt2.Rows.Count > 0 Then
            Return dt2
        ElseIf dt3.Rows.Count > 0 Then
            Return dt3
        ElseIf dt4.Rows.Count > 0 Then
            Return dt4
        End If
    End Function
    Public Function GetJournalVoucherNo(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAUTOStyleNo(strName)
        Return dt

    End Function
    Public Function GetBuyerName(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETBuyerName(strName)
        Return dt

    End Function
    Public Function GetSrNoForFabricConsumption(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAUTOSRNoForFabricConsumption(strName)
        Return dt

    End Function
    Public Function GetItemCodeForIssue(ByVal strName As String) As DataTable
        Dim dt1 As DataTable
        Dim UserId As Long = Session("UserId")
        If Session("RoleId") = 46 And Session("Type") = "Fabric Store" Then
            dt1 = objStyleMaster.GETItemCodeForIssueForFStore(strName)
        Else
            Dim DtCheck As DataTable = objPORecvMaster.CheckDepartment(UserId)
            If DtCheck.Rows(0)("Department") = "Fabric Store" Then
                dt1 = objStyleMaster.GETItemCodeForIssueForFStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "Acc Store" Then
                dt1 = objStyleMaster.GETItemCodeForIssueForAStore(strName)
            ElseIf DtCheck.Rows(0)("Department") = "General Store." Then
                dt1 = objStyleMaster.GETItemCodeForIssueForAStoreGStore(strName)
            End If
        End If
        Return dt1
    End Function
    Public Function GetItemCodeForProcessIssue(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        If UserId = 241 Then
            dt1 = objStyleMaster.GETItemCodeForprocessIssueForFStore(strName)
        ElseIf UserId = 242 Then
        End If
        Return dt1
    End Function
    Public Function GetItemCodeForIssueProcess(ByVal strName As String) As DataTable
        Dim UserId As Long = Session("UserId")
        Dim dt1 As DataTable
        If UserId = 241 Then
            dt1 = objStyleMaster.GETItemCodeForIssueForFStoreProces(strName)
        ElseIf UserId = 242 Then
            dt1 = objStyleMaster.GETItemCodeForIssueForAStoreProcess(strName)
        End If
        Return dt1
    End Function
    Public Function GetStyleNo(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAUTOENQStyleNo(strName)
        Return dt

    End Function
    Public Function GetStyleNoinq(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAUTOENQStyleNoINQ(strName)
        Return dt

    End Function
    Public Function GetINSPPO(ByVal strName As String) As DataTable
        dt = objStyleMaster.GETAUTOPO(strName)
        Return dt

    End Function
    Public Function GetCargoInv(ByVal strName As String) As DataTable
        dt = objStyleMaster.GetCargoInv(strName)
        Return dt

    End Function
    Public Function GetDalNo(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GetDalNo(strName)
        Return dt

    End Function
    Public Function GetDalNoFromFStore(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GetDalNoFromFStore(strName)
        Return dt

    End Function
    Public Function GetDSINo(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GetDSINo(strName)
        Return dt

    End Function
    Public Function GetDCDNo(ByVal strName As String) As DataTable
        dt = ObjDPBuyerComment.GetDCDNo(strName)
        Return dt

    End Function
    Public Function GetStyleNoFromStyleDatabase(ByVal strName As String) As DataTable
        ' dt = ObjDPBuyerComment.GetStyleNoFromStyleDatabase(strName)
        dt = ObjDPBuyerComment.GetStyleNoFromStyleDatabaseNew(strName)
        Return dt

    End Function
    Public Function GetSupplierNameFromJobOrder(ByVal strName As String) As DataTable
        dt = ObjDPBuyerComment.GetSupplierNameFromJobOrder(strName)
        Return dt

    End Function
    Public Function GetSupplierNameForFStore(ByVal strName As String) As DataTable
        dt = ObjDPBuyerComment.GetSupplierNameFromOnlyFStore(strName)
        Return dt

    End Function
    Public Function GetDALNOFromJobOrder(ByVal strName As String) As DataTable
        Dim SupplierIDD As Long = Session("SupplierID")
        dt = ObjDPBuyerComment.GetDalNoFromJobOrder(strName, SupplierIDD)
        Return dt

    End Function
    Public Function GetStyleNoFromJobOrder(ByVal strName As String) As DataTable
        Dim FabricDBMstIDD As Long = Session("FabricDBMstIDD")
        'dt = ObjDPBuyerComment.GetStyleNoFromJobOrder(strName, FabricDBMstIDD)
        dt = ObjDPBuyerComment.GetStyleNoFromJobOrderNew(strName, FabricDBMstIDD)

        Return dt

    End Function
    Public Function GetStyleNoFromJobOrderNew(ByVal strName As String) As DataTable

        'dt = ObjDPBuyerComment.GetStyleNoFromJobOrderNewNew(strName)
        dt = ObjDPBuyerComment.GetStyleNoFromJobOrderNewNewNew(strName)

        Return dt

    End Function



    Public Function GetDSRNo(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GetDSRNo(strName)
        Return dt

    End Function


    Public Function GetWashNo(ByVal strName As String) As DataTable
        dt = objDPFabricDbMst.GetWashNo(strName)
        Return dt

    End Function


    '========================ForUse scaning 
    <WebMethod(EnableSession:=True)> _
    Public Function GetValue(ByVal Textbox As String, ByVal label As Label, ByVal myGridView As GridView, ByVal TextBox2 As TextBox)
        Try
            'dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcode.Text)
            'Session("objDataView") = dtdata

            If Textbox = "" Then
                label.Text = "Select Submission"
            Else
                label.Text = ""
                SaveSession(Textbox, myGridView, label)

                TextBox2.Text = ""
                TextBox2.Focus()
            End If

        Catch ex As Exception

        End Try
    End Function

    Sub SaveSession(ByVal ss As String, ByVal myGridView As GridView, ByVal lblmsg As Label)
        Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
        Dim dr As DataRow
        If (Not CType(Session("dtDetail"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetail")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("StyleAssortmentBarCodeDetailID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("Merchandiser", GetType(String))
                .Columns.Add("JobNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Brand", GetType(String))
                .Columns.Add("StyleAssortmentMasterID", GetType(String))
                .Columns.Add("SizeRangeID", GetType(String))
                .Columns.Add("SizeDatabaseID", GetType(String))
                .Columns.Add("Code", GetType(String))
                .Columns.Add("TotalOrderQty", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("TotalSizeQty", GetType(String))
                .Columns.Add("LineNumber", GetType(String))

            End With
        End If
        dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(ss)

        Dim results As DataRow() = dtDetail.Select("Code='" & dtdata.Rows(0)("Code").ToString & "'")

        If results.Length <> 1 Then
            If dtdata.Rows.Count > 0 Then
                dr = dtDetail.NewRow()
                dr("StyleAssortmentBarCodeDetailID") = dtdata.Rows(0)("StyleAssortmentBarCodeDetailID").ToString
                dr("Joborderid") = dtdata.Rows(0)("Joborderid").ToString
                dr("JoborderDetailid") = dtdata.Rows(0)("JoborderDetailid").ToString
                dr("Merchandiser") = dtdata.Rows(0)("Merchandiser").ToString
                dr("JobNo") = dtdata.Rows(0)("SRNo").ToString
                dr("Style") = dtdata.Rows(0)("Style").ToString
                dr("Item") = dtdata.Rows(0)("Item").ToString
                dr("Brand") = dtdata.Rows(0)("Brand").ToString
                dr("StyleAssortmentMasterID") = dtdata.Rows(0)("StyleAssortmentMasterID").ToString
                dr("SizeRangeID") = dtdata.Rows(0)("SizeRangeID").ToString
                dr("SizeDatabaseID") = dtdata.Rows(0)("SizeDatabaseID").ToString
                dr("Code") = dtdata.Rows(0)("Code").ToString
                dr("TotalOrderQty") = dtdata.Rows(0)("OrderQty").ToString ' dtdata.Rows(0)("TotalOrderQty").ToString
                dr("Size") = dtdata.Rows(0)("Size").ToString
                dr("TotalSizeQty") = dtdata.Rows(0)("TotalSizeQty").ToString
                dr("LineNumber") = dtdata.Rows(0)("LineNumber").ToString
                dtDetail.Rows.Add(dr)
            End If
            Session("dtDetail") = dtDetail
            BindGrid(myGridView)
            lblmsg.Text = ""
        Else

            lblmsg.Text = "Already Scane BarCode....."
        End If



    End Sub

    Private Sub BindGrid(ByVal myGridView As GridView)
        dtDetail = Session("dtDetail")
        Dim objDataview As New DataView(dtDetail)

        myGridView.DataSource = objDataview
        myGridView.DataBind()




    End Sub



    Public Function GetValueF(ByVal Textbox As String, ByVal label As Label, ByVal myGridView As GridView, ByVal TextBox2 As TextBox)
        Try
            'dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcode.Text)
            'Session("objDataView") = dtdata

            If Textbox = "" Then
                label.Text = "Select Submission"
            Else
                label.Text = ""
                SaveSessionF(Textbox, myGridView, label)

                TextBox2.Text = ""
                TextBox2.Focus()
            End If

        Catch ex As Exception

        End Try
    End Function

    Sub SaveSessionF(ByVal ss As String, ByVal myGridView As GridView, ByVal lblmsg As Label)
        Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
        Dim dr As DataRow
        If (Not CType(Session("dtDetailF"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetailF")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("StyleAssortmentBarCodeDetailID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("Merchandiser", GetType(String))
                .Columns.Add("JobNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Brand", GetType(String))
                .Columns.Add("StyleAssortmentMasterID", GetType(String))
                .Columns.Add("SizeRangeID", GetType(String))
                .Columns.Add("SizeDatabaseID", GetType(String))
                .Columns.Add("Code", GetType(String))
                .Columns.Add("TotalOrderQty", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("TotalSizeQty", GetType(String))

            End With
        End If
        dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(ss)

        Dim results As DataRow() = dtDetail.Select("Code='" & dtdata.Rows(0)("Code").ToString & "'")

        If results.Length <> 1 Then
            If dtdata.Rows.Count > 0 Then
                dr = dtDetail.NewRow()
                dr("StyleAssortmentBarCodeDetailID") = dtdata.Rows(0)("StyleAssortmentBarCodeDetailID").ToString
                dr("Joborderid") = dtdata.Rows(0)("Joborderid").ToString
                dr("JoborderDetailid") = dtdata.Rows(0)("JoborderDetailid").ToString
                dr("Merchandiser") = dtdata.Rows(0)("Merchandiser").ToString
                dr("JobNo") = dtdata.Rows(0)("SRNo").ToString
                dr("Style") = dtdata.Rows(0)("Style").ToString
                dr("Item") = dtdata.Rows(0)("Item").ToString
                dr("Brand") = dtdata.Rows(0)("Brand").ToString
                dr("StyleAssortmentMasterID") = dtdata.Rows(0)("StyleAssortmentMasterID").ToString
                dr("SizeRangeID") = dtdata.Rows(0)("SizeRangeID").ToString
                dr("SizeDatabaseID") = dtdata.Rows(0)("SizeDatabaseID").ToString
                dr("Code") = dtdata.Rows(0)("Code").ToString
                dr("TotalOrderQty") = dtdata.Rows(0)("OrderQty").ToString ' dtdata.Rows(0)("TotalOrderQty").ToString
                dr("Size") = dtdata.Rows(0)("Size").ToString
                dr("TotalSizeQty") = dtdata.Rows(0)("TotalSizeQty").ToString

                dtDetail.Rows.Add(dr)
            End If
            Session("dtDetailF") = dtDetail
            BindGridF(myGridView)
            lblmsg.Text = ""
        Else

            lblmsg.Text = "Already Scane BarCode....."
        End If



    End Sub

    Private Sub BindGridF(ByVal myGridView As GridView)
        dtDetail = Session("dtDetailF")
        Dim objDataview As New DataView(dtDetail)

        myGridView.DataSource = objDataview
        myGridView.DataBind()




    End Sub


    Public Function GetValueW(ByVal Textbox As String, ByVal label As Label, ByVal myGridView As GridView, ByVal TextBox2 As TextBox)
        Try
            'dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcode.Text)
            'Session("objDataView") = dtdata

            If Textbox = "" Then
                label.Text = "Select Submission"
            Else
                label.Text = ""
                SaveSessionW(Textbox, myGridView, label)

                TextBox2.Text = ""
                TextBox2.Focus()
            End If

        Catch ex As Exception

        End Try
    End Function

    Sub SaveSessionW(ByVal ss As String, ByVal myGridView As GridView, ByVal lblmsg As Label)
        Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
        Dim dr As DataRow
        If (Not CType(Session("dtDetailW"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetailW")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("StyleAssortmentBarCodeDetailID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("Merchandiser", GetType(String))
                .Columns.Add("JobNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Brand", GetType(String))
                .Columns.Add("StyleAssortmentMasterID", GetType(String))
                .Columns.Add("SizeRangeID", GetType(String))
                .Columns.Add("SizeDatabaseID", GetType(String))
                .Columns.Add("Code", GetType(String))
                .Columns.Add("TotalOrderQty", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("TotalSizeQty", GetType(String))

            End With
        End If
        dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(ss)

        Dim results As DataRow() = dtDetail.Select("Code='" & dtdata.Rows(0)("Code").ToString & "'")

        If results.Length <> 1 Then
            If dtdata.Rows.Count > 0 Then
                dr = dtDetail.NewRow()
                dr("StyleAssortmentBarCodeDetailID") = dtdata.Rows(0)("StyleAssortmentBarCodeDetailID").ToString
                dr("Joborderid") = dtdata.Rows(0)("Joborderid").ToString
                dr("JoborderDetailid") = dtdata.Rows(0)("JoborderDetailid").ToString
                dr("Merchandiser") = dtdata.Rows(0)("Merchandiser").ToString
                dr("JobNo") = dtdata.Rows(0)("SRNo").ToString
                dr("Style") = dtdata.Rows(0)("Style").ToString
                dr("Item") = dtdata.Rows(0)("Item").ToString
                dr("Brand") = dtdata.Rows(0)("Brand").ToString
                dr("StyleAssortmentMasterID") = dtdata.Rows(0)("StyleAssortmentMasterID").ToString
                dr("SizeRangeID") = dtdata.Rows(0)("SizeRangeID").ToString
                dr("SizeDatabaseID") = dtdata.Rows(0)("SizeDatabaseID").ToString
                dr("Code") = dtdata.Rows(0)("Code").ToString
                dr("TotalOrderQty") = dtdata.Rows(0)("TotalOrderQty").ToString
                dr("Size") = dtdata.Rows(0)("Size").ToString
                dr("TotalSizeQty") = dtdata.Rows(0)("TotalSizeQty").ToString

                dtDetail.Rows.Add(dr)
            End If
            Session("dtDetailW") = dtDetail
            BindGridW(myGridView)
            lblmsg.Text = ""
        Else

            lblmsg.Text = "Already Scane BarCode....."
        End If



    End Sub

    Private Sub BindGridW(ByVal myGridView As GridView)
        dtDetail = Session("dtDetailW")
        Dim objDataview As New DataView(dtDetail)

        myGridView.DataSource = objDataview
        myGridView.DataBind()




    End Sub




    '==================================end
    Public Function GetValueWR(ByVal Textbox As String, ByVal label As Label, ByVal myGridView As GridView, ByVal TextBox2 As TextBox)
        Try
            'dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(txtBarcode.Text)
            'Session("objDataView") = dtdata

            If Textbox = "" Then
                label.Text = "Select Submission"
            Else
                label.Text = ""
                SaveSessionWR(Textbox, myGridView, label)

                TextBox2.Text = ""
                TextBox2.Focus()
            End If

        Catch ex As Exception

        End Try
    End Function

    Sub SaveSessionWR(ByVal ss As String, ByVal myGridView As GridView, ByVal lblmsg As Label)
        Dim objStyleAssortmentBarCodeDetail As New StyleAssortmentBarCodeDetail
        Dim dr As DataRow
        If (Not CType(Session("dtDetailRW"), DataTable) Is Nothing) Then
            dtDetail = Session("dtDetailRW")
        Else
            dtDetail = New DataTable
            With dtDetail
                .Columns.Add("StyleAssortmentBarCodeDetailID", GetType(Long))
                .Columns.Add("Joborderid", GetType(Long))
                .Columns.Add("JoborderDetailid", GetType(String))
                .Columns.Add("Merchandiser", GetType(String))
                .Columns.Add("JobNo", GetType(String))
                .Columns.Add("Style", GetType(String))
                .Columns.Add("Item", GetType(String))
                .Columns.Add("Brand", GetType(String))
                .Columns.Add("StyleAssortmentMasterID", GetType(String))
                .Columns.Add("SizeRangeID", GetType(String))
                .Columns.Add("SizeDatabaseID", GetType(String))
                .Columns.Add("Code", GetType(String))
                .Columns.Add("TotalOrderQty", GetType(String))
                .Columns.Add("Size", GetType(String))
                .Columns.Add("TotalSizeQty", GetType(String))

            End With
        End If
        dtdata = objStyleAssortmentBarCodeDetail.GettestdataSecondPage(ss)

        Dim results As DataRow() = dtDetail.Select("Code='" & dtdata.Rows(0)("Code").ToString & "'")

        If results.Length <> 1 Then
            If dtdata.Rows.Count > 0 Then
                dr = dtDetail.NewRow()
                dr("StyleAssortmentBarCodeDetailID") = dtdata.Rows(0)("StyleAssortmentBarCodeDetailID").ToString
                dr("Joborderid") = dtdata.Rows(0)("Joborderid").ToString
                dr("JoborderDetailid") = dtdata.Rows(0)("JoborderDetailid").ToString
                dr("Merchandiser") = dtdata.Rows(0)("Merchandiser").ToString
                dr("JobNo") = dtdata.Rows(0)("SRNo").ToString
                dr("Style") = dtdata.Rows(0)("Style").ToString
                dr("Item") = dtdata.Rows(0)("Item").ToString
                dr("Brand") = dtdata.Rows(0)("Brand").ToString
                dr("StyleAssortmentMasterID") = dtdata.Rows(0)("StyleAssortmentMasterID").ToString
                dr("SizeRangeID") = dtdata.Rows(0)("SizeRangeID").ToString
                dr("SizeDatabaseID") = dtdata.Rows(0)("SizeDatabaseID").ToString
                dr("Code") = dtdata.Rows(0)("Code").ToString
                dr("TotalOrderQty") = dtdata.Rows(0)("OrderQty").ToString ' dtdata.Rows(0)("TotalOrderQty").ToString
                dr("Size") = dtdata.Rows(0)("Size").ToString
                dr("TotalSizeQty") = dtdata.Rows(0)("TotalSizeQty").ToString

                dtDetail.Rows.Add(dr)
            End If
            Session("dtDetailRW") = dtDetail
            BindGridWR(myGridView)
            lblmsg.Text = ""
        Else

            lblmsg.Text = "Already Scane BarCode....."
        End If



    End Sub
    Private Sub BindGridWR(ByVal myGridView As GridView)
        dtDetail = Session("dtDetailRW")
        Dim objDataview As New DataView(dtDetail)
        myGridView.DataSource = objDataview
        myGridView.DataBind()

    End Sub

    Public Function GetFabricCode(ByVal strName As String) As DataTable
        dt = objIMSStoreIssue.FabricCode(strName)
        Return dt
    End Function
    Public Function GetDyeWash(ByVal strName As String) As DataTable
        dt = dyewash.GetDyeForSearch(strName)
        Return dt
    End Function



    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        Session.Timeout = 120
    End Sub

End Class