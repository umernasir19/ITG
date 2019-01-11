Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.HtmlControls.HtmlTable
Imports Integra.EuroCentra
Imports Integra.classes

Partial Class TrailBalanceForNIMPEX
    Inherits System.Web.UI.Page
    Dim ObjtblBankMst As New tblBankMst
    Dim Report As New ReportDocument
    Dim Options As New ExportOptions
    Dim obGeneralCode As New GeneralCode
    Dim objDataTable As DataTable
    Dim ObjTemTrialBalance As New TemTrialBalance
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("")
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Sub SetAllVouchersData()
        Dim OBJDATE As New GeneralCode
        ObjtblBankMst.TruncatingTemTrialBalanceTables()
        Dim FiscalYear As String = cmbSession.SelectedItem.Text
        'Dim StartDate As String = txtstartdate.Text '"07/01/" + FiscalYear.Substring(0, 4)
        'Dim EndDate As String = txtEndDate.Text '"06/30/20" + FiscalYear.Substring(5, 2)
        'Dim sdatee, edate As String
        'Dim OBJDATE As New GeneralCode
        'sdatee = OBJDATE.GetDateFormatNewr(StartDate)
        'edate = OBJDATE.GetDateFormatNewr(EndDate)

        Dim StartDate As String = OBJDATE.GetDateFormat(txtstartdate.Text) '"07/01/" + FiscalYear.Substring(0, 4)
        Dim EndDate As String = OBJDATE.GetDateFormat(txtEndDate.Text) '"06/30/20" + FiscalYear.Substring(5, 2)
        Dim sdatee, edate As String

        sdatee = StartDate
        edate = EndDate

        Dim dt As New DataTable
        Session("dt") = Nothing
        Dim Dr As DataRow
        Dim x As Integer
        Try
            If (Not CType(Session("dt"), DataTable) Is Nothing) Then
                dt = Session("dt")
            Else
                dt = New DataTable
                With dt
                    .Columns.Add("TempTrialID", GetType(Long))
                    .Columns.Add("Accountcode", GetType(String))
                    .Columns.Add("DebitBPV", GetType(String))
                    .Columns.Add("CreditBPV", GetType(String))
                    .Columns.Add("JVDebit", GetType(String))
                    .Columns.Add("JVCredit", GetType(String))
                    .Columns.Add("DebitCV", GetType(String))
                    .Columns.Add("CreditCV", GetType(String))
                    .Columns.Add("DebitPV", GetType(String))
                    .Columns.Add("CreditPV", GetType(String))
                    .Columns.Add("OB", GetType(String))
                    .Columns.Add("OBCR", GetType(String))
                    .Columns.Add("DebitContra", GetType(String))
                    .Columns.Add("CreditContra", GetType(String))
                End With
            End If
            objDataTable = ObjtblBankMst.GetAllAccountsNew()
            Dim DebitBPV As Decimal = 0
            Dim CreditBPV As Decimal = 0
            Dim DebitBPVMaster As Decimal = 0
            Dim CreditBPVMaster As Decimal = 0
            Dim JVDebit As Decimal = 0
            Dim JVCredit As Decimal = 0
            Dim DebitCV As Decimal = 0
            Dim CreditCV As Decimal = 0
            Dim DebitPV As Decimal = 0
            Dim CreditPV As Decimal = 0
            Dim OB As Decimal = 0
            Dim OBCR As Decimal = 0
            Dim CreditContra As Decimal = 0
            Dim DebitContra As Decimal = 0

            Dim dtBPVDB As New DataTable
            Dim dtBPVCR As New DataTable
            Dim dtOBPVDB As New DataTable
            Dim dtOBPVCR As New DataTable
            Dim dtBPVDBMaster As New DataTable
            Dim dtBPVCRMaster As New DataTable
            Dim dtOBPVDBMaster As New DataTable
            Dim dtOBPVCRMaster As New DataTable
            Dim dtCVDB As New DataTable
            Dim dtCVCR As New DataTable
            Dim dtJVDB As New DataTable
            Dim dtJVCR As New DataTable
            Dim dtOJVDB As New DataTable
            Dim dtOJVCR As New DataTable
            Dim dtPVDB As New DataTable
            Dim dtPVCR As New DataTable
            Dim dtOBCVDb As New DataTable
            Dim dtOBCVCr As New DataTable



            Dim TotalBankDb As Decimal = 0
            Dim TotalBankCR As Decimal = 0
            Dim OpenDebitBPV As Decimal = 0
            Dim OpeningCreditBPV As Decimal = 0
            Dim OpeningCreditBPVMaster As Decimal = 0
            Dim OpeningDebitBPVMaster As Decimal = 0
            Dim OpeningJVDebit As Decimal = 0
            Dim OpeningJVCredit As Decimal = 0
            Dim OpeningCVDebit As Decimal = 0
            Dim OpeningCVCredit As Decimal = 0

            Dim dtContraDb As New DataTable
            Dim dtContraCr As New DataTable
            Dim dtOBContraDb As New DataTable
            Dim dtOBContraCr As New DataTable
            Dim OpeningContraDebit As Decimal = 0
            Dim OpeningContraCredit As Decimal = 0


            Dim dtCVDBMaster As New DataTable
            Dim dtCVCRMaster As New DataTable
            Dim dtOBCVDbMaster As New DataTable
            Dim dtOBCVCrMaster As New DataTable
            Dim DebitCVMaster As Decimal = 0
            Dim CreditCVMaster As Decimal = 0
            Dim OpeningCVDebitMaster As Decimal = 0
            Dim OpeningCVCreditMaster As Decimal = 0

            If objDataTable.Rows.Count > 0 Then
                For x = 0 To objDataTable.Rows.Count - 1
                    '---PVDB
                    dtBPVDB = ObjtblBankMst.GetSumDebitBPVNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtBPVDB.Rows.Count > 0 Then
                            DebitBPV = Convert.ToInt64(dtBPVDB.Compute("SUM(DebitBPV)", String.Empty))
                        Else
                            DebitBPV = 0
                        End If
                        '---OPEING
                    Catch ex As Exception
                        DebitBPV = 0
                    End Try

                    dtOBPVDB = ObjtblBankMst.GetOpeningSumDebitBPV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBPVDB.Rows.Count > 0 Then
                            OpenDebitBPV = Convert.ToInt64(dtOBPVDB.Compute("SUM(DebitBPV)", String.Empty))
                        Else
                            OpenDebitBPV = 0
                        End If
                        '---PVCR
                    Catch ex As Exception
                        OpenDebitBPV = 0
                    End Try

                    dtBPVCR = ObjtblBankMst.GetSumCreditBPVNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtBPVCR.Rows.Count > 0 Then
                            CreditBPV = Convert.ToInt64(dtBPVCR.Compute("SUM(CreditBPV)", String.Empty))
                        Else
                            CreditBPV = 0
                        End If
                        '---Opening
                    Catch ex As Exception
                        CreditBPV = 0
                    End Try

                    dtOBPVCR = ObjtblBankMst.GetOpeningSumCreditBPV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBPVCR.Rows.Count > 0 Then
                            OpeningCreditBPV = Convert.ToInt64(dtOBPVCR.Compute("SUM(CreditBPV)", String.Empty))
                        Else
                            OpeningCreditBPV = 0
                        End If
                    Catch ex As Exception
                        OpeningCreditBPV = 0
                    End Try


                    '---PVDB
                    dtBPVDBMaster = ObjtblBankMst.GetSumCreditBPVMasterNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtBPVDBMaster.Rows.Count > 0 Then
                            CreditBPVMaster = Convert.ToInt64(dtBPVDBMaster.Compute("SUM(DebitBPV)", String.Empty))
                        Else
                            CreditBPVMaster = 0
                        End If
                        'opening
                    Catch ex As Exception
                        CreditBPVMaster = 0
                    End Try

                    dtOBPVDBMaster = ObjtblBankMst.GetOpeningSumCreditBPVMaster(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBPVDBMaster.Rows.Count > 0 Then
                            OpeningCreditBPVMaster = Convert.ToInt64(dtOBPVDBMaster.Compute("SUM(DebitBPV)", String.Empty))
                        Else
                            OpeningCreditBPVMaster = 0
                        End If
                        '---PVCR
                    Catch ex As Exception
                        OpeningCreditBPVMaster = 0
                    End Try

                    dtBPVCRMaster = ObjtblBankMst.GetSumDebitBPVMasterNew(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtBPVCRMaster.Rows.Count > 0 Then
                            DebitBPVMaster = Convert.ToInt64(dtBPVCRMaster.Compute("SUM(CreditBPV)", String.Empty))
                        Else
                            DebitBPVMaster = 0
                        End If
                        'Opening
                    Catch ex As Exception
                        DebitBPVMaster = 0
                    End Try

                    dtOBPVCRMaster = ObjtblBankMst.GetOpeningSumDebitBPVMaster(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBPVCRMaster.Rows.Count > 0 Then
                            OpeningDebitBPVMaster = Convert.ToInt64(dtOBPVCRMaster.Compute("SUM(CreditBPV)", String.Empty))
                        Else
                            OpeningDebitBPVMaster = 0
                        End If
                    Catch ex As Exception
                        OpeningDebitBPVMaster = 0
                    End Try

                    TotalBankDb = DebitBPV + DebitBPVMaster
                    TotalBankCR = CreditBPV + CreditBPVMaster

                    '---JVDB
                    dtJVDB = ObjtblBankMst.GetSumDebitJV(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtJVDB.Rows.Count > 0 Then
                            JVDebit = Convert.ToInt64(dtJVDB.Compute("SUM(DebitJV)", String.Empty))
                        Else
                            JVDebit = 0
                        End If
                        'Opening
                    Catch ex As Exception
                        JVDebit = 0
                    End Try

                    '---JVDB
                    dtOJVDB = ObjtblBankMst.GetOpeningSumDebitJV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOJVDB.Rows.Count > 0 Then
                            OpeningJVDebit = Convert.ToInt64(dtOJVDB.Compute("SUM(DebitJV)", String.Empty))
                        Else
                            OpeningJVDebit = 0
                        End If
                        '---JVCR
                    Catch ex As Exception
                        OpeningJVDebit = 0
                    End Try

                    dtJVCR = ObjtblBankMst.GetSumCreditJV(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtJVCR.Rows.Count > 0 Then
                            JVCredit = Convert.ToInt64(dtJVCR.Compute("SUM(CreditJV)", String.Empty))
                        Else
                            JVCredit = 0
                        End If
                    Catch ex As Exception
                        JVCredit = 0
                    End Try

                    'Opeing
                    Try
                        dtOJVCR = ObjtblBankMst.GetOpeningSumCreditJV(objDataTable.Rows(x)("Accountcode"), sdatee)
                        If dtOJVCR.Rows.Count > 0 Then
                            OpeningJVCredit = Convert.ToInt64(dtOJVCR.Compute("SUM(CreditJV)", String.Empty))
                        Else
                            OpeningJVCredit = 0
                        End If
                    Catch ex As Exception
                        OpeningJVCredit = 0
                    End Try

                    '=================CV
                    '---CVDB
                    dtCVDB = ObjTemTrialBalance.GetSumDebitCPV(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtCVDB.Rows.Count > 0 Then
                            DebitCV = Convert.ToInt64(dtCVDB.Compute("SUM(DebitCPV)", String.Empty))
                        Else
                            DebitCV = 0
                        End If
                    Catch ex As Exception
                        DebitCV = 0
                    End Try
                    '---OPEING

                    dtOBCVDb = ObjTemTrialBalance.GetOpeningSumDebitCV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBCVDb.Rows.Count > 0 Then
                            OpeningCVDebit = Convert.ToInt64(dtOBCVDb.Compute("SUM(DebitCPVOB)", String.Empty))
                        Else
                            OpeningCVDebit = 0
                        End If
                    Catch ex As Exception
                        OpeningCVDebit = 0
                    End Try

                    '---CVCR
                    dtCVCR = ObjTemTrialBalance.GetSumCreditCPV(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtCVCR.Rows.Count > 0 Then
                            CreditCV = Convert.ToInt64(dtCVCR.Compute("SUM(CreditCPV)", String.Empty))
                        Else
                            CreditCV = 0
                        End If
                    Catch ex As Exception
                        CreditCV = 0
                    End Try
                    '---OPEING

                    dtOBCVCr = ObjTemTrialBalance.GetOpeningSumCreditCV(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBCVCr.Rows.Count > 0 Then
                            OpeningCVCredit = Convert.ToInt64(dtOBCVCr.Compute("SUM(CreditCPVOB)", String.Empty))
                        Else
                            OpeningCVCredit = 0
                        End If
                    Catch ex As Exception
                        OpeningCVCredit = 0
                    End Try

                    '-CV---------Master
                    '---CVDB
                    dtCVDBMaster = ObjTemTrialBalance.GetSumDebitCPVMaster(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtCVDBMaster.Rows.Count > 0 Then
                            CreditCVMaster = Convert.ToInt64(dtCVDBMaster.Compute("SUM(DebitCPV)", String.Empty))
                        Else
                            CreditCVMaster = 0
                        End If
                    Catch ex As Exception

                    End Try
                    '---OPEING

                    dtOBCVDbMaster = ObjTemTrialBalance.GetOpeningSumDebitCVMaster(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBCVDbMaster.Rows.Count > 0 Then
                            OpeningCVCreditMaster = Convert.ToInt64(dtOBCVDbMaster.Compute("SUM(DebitCPVOB)", String.Empty))
                        Else
                            OpeningCVCreditMaster = 0
                        End If
                    Catch ex As Exception
                        OpeningCVCreditMaster = 0
                    End Try
                    '---CVCR
                    dtCVCRMaster = ObjTemTrialBalance.GetSumCreditCPVMaster(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtCVCRMaster.Rows.Count > 0 Then
                            DebitCVMaster = Convert.ToInt64(dtCVCRMaster.Compute("SUM(CreditCPV)", String.Empty))
                        Else
                            DebitCVMaster = 0
                        End If
                    Catch ex As Exception
                        DebitCVMaster = 0
                    End Try
                    '---OPEING

                    dtOBCVCrMaster = ObjTemTrialBalance.GetOpeningSumCreditCVMaster(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBCVCrMaster.Rows.Count > 0 Then
                            OpeningCVDebitMaster = Convert.ToInt64(dtOBCVCrMaster.Compute("SUM(CreditCPVOB)", String.Empty))
                        Else
                            OpeningCVDebitMaster = 0
                        End If
                    Catch ex As Exception
                        OpeningCVDebitMaster = 0
                    End Try


                    '============Contra
                    '---ContraDB
                    dtContraDb = ObjTemTrialBalance.GetSumDebitContra(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtContraDb.Rows.Count > 0 Then
                            DebitContra = Convert.ToInt64(dtContraDb.Compute("SUM(DebitContra)", String.Empty))
                        Else
                            DebitContra = 0
                        End If
                    Catch ex As Exception
                        DebitContra = 0
                    End Try
                    '---Contra OPEING db

                    dtOBContraDb = ObjTemTrialBalance.GetSumDebitContraOB(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBContraDb.Rows.Count > 0 Then
                            OpeningContraDebit = Convert.ToInt64(dtOBContraDb.Compute("SUM(DebitContraOB)", String.Empty))
                        Else
                            OpeningContraDebit = 0
                        End If
                    Catch ex As Exception
                        OpeningContraDebit = 0
                    End Try

                    '---ContraCR
                    dtContraCr = ObjTemTrialBalance.GetSumCreditContra(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Try
                        If dtContraCr.Rows.Count > 0 Then
                            CreditContra = Convert.ToInt64(dtContraCr.Compute("SUM(CreditContra)", String.Empty))
                        Else
                            CreditContra = 0
                        End If
                    Catch ex As Exception
                        CreditContra = 0
                    End Try

                    '---Contra OPEING cr

                    dtOBContraCr = ObjTemTrialBalance.GetSumCreditContraOB(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If dtOBContraCr.Rows.Count > 0 Then
                            OpeningContraCredit = Convert.ToInt64(dtOBContraCr.Compute("SUM(CreditContraOB)", String.Empty))
                        Else
                            OpeningContraCredit = 0
                        End If
                    Catch ex As Exception
                        OpeningContraCredit = 0
                    End Try

                    '===============From Invoice
                    '---Inv
                    '---Inv
                    Dim dtInvAmt As DataTable
                    dtInvAmt = ObjtblBankMst.GetSumInvoiceAmountFromTransaction(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                    Dim InvAmtDebit As Decimal = 0
                    Dim InvAmtCredit As Decimal = 0
                    Try
                        If dtInvAmt.Rows.Count > 0 Then
                            InvAmtDebit = Convert.ToInt64(dtInvAmt.Compute("SUM(DebitINV)", String.Empty))
                            InvAmtCredit = Convert.ToInt64(dtInvAmt.Compute("SUM(CreditINV)", String.Empty))
                        Else
                            InvAmtDebit = 0
                            InvAmtCredit = 0
                        End If
                    Catch ex As Exception
                        InvAmtDebit = 0
                        InvAmtCredit = 0
                    End Try

                    '---Inv Opening
                    Dim DtIivOpening As DataTable
                    Dim OpeningInvAmtDebit As Decimal = 0
                    Dim OpeningInvAmtCredit As Decimal = 0
                    DtIivOpening = ObjtblBankMst.GetOpeningSumInvoiceAmountFromTransactio(objDataTable.Rows(x)("Accountcode"), sdatee)
                    Try
                        If DtIivOpening.Rows.Count > 0 Then
                            OpeningInvAmtDebit = Convert.ToInt64(DtIivOpening.Compute("SUM(OBDebitINV)", String.Empty))
                            OpeningInvAmtCredit = Convert.ToInt64(DtIivOpening.Compute("SUM(OBCreditINV)", String.Empty))
                        Else
                            OpeningInvAmtDebit = 0
                            OpeningInvAmtCredit = 0
                        End If
                    Catch ex As Exception
                        OpeningInvAmtDebit = 0
                        OpeningInvAmtCredit = 0
                    End Try

                    '======================WHT Bank data
                    '---PVDB
                    Dim dtDebitWht, dtDebitWhtOB As New DataTable
                    Dim DebitWht As Decimal = 0
                    Dim DebitWhtOB As Decimal = 0
                    Dim dtChkWHT As DataTable
                    Dim dtCreditWht, dtCreditWhtOB As New DataTable
                    Dim CreditWht As Decimal = 0
                    Dim CreditWhtOB As Decimal = 0
                    dtChkWHT = ObjtblBankMst.ChkWHT(objDataTable.Rows(x)("Accountcode"))
                    Try
                        If dtChkWHT.Rows.Count > 0 Then
                            If dtChkWHT.Rows(0)("groupact").ToString = "0202004" Then '---WHT
                                '---PVCR
                                dtCreditWht = ObjtblBankMst.GetSumCreditBPVWHT(objDataTable.Rows(x)("AccountName"), sdatee, edate)
                                Try
                                    If dtCreditWht.Rows.Count > 0 Then
                                        CreditWht = Convert.ToInt64(dtCreditWht.Compute("SUM(WHTaxAmountCr)", String.Empty))
                                    Else
                                        CreditWht = 0
                                    End If
                                Catch ex As Exception

                                End Try
                                '---Opening
                                dtCreditWhtOB = ObjtblBankMst.GetSumCreditBPVWHTOB(objDataTable.Rows(x)("AccountName"), sdatee)
                                Try
                                    If dtCreditWhtOB.Rows.Count > 0 Then
                                        CreditWhtOB = Convert.ToInt64(dtCreditWhtOB.Compute("SUM(WHTaxAmountCROB)", String.Empty))
                                    Else
                                        CreditWhtOB = 0
                                    End If
                                Catch ex As Exception

                                End Try
                            Else
                                dtDebitWht = ObjtblBankMst.GetSumDebitBPVWHT(objDataTable.Rows(x)("Accountcode"), sdatee, edate)
                                Try
                                    If dtDebitWht.Rows.Count > 0 Then
                                        DebitWht = Convert.ToInt64(dtDebitWht.Compute("SUM(WHTaxAmountDB)", String.Empty))
                                    Else
                                        DebitWht = 0
                                    End If
                                Catch ex As Exception

                                End Try

                                '---OPEING
                                dtDebitWhtOB = ObjtblBankMst.GetSumDebitBPVWHTOB(objDataTable.Rows(x)("Accountcode"), sdatee)
                                Try
                                    If dtDebitWhtOB.Rows.Count > 0 Then
                                        DebitWhtOB = Convert.ToInt64(dtDebitWhtOB.Compute("SUM(WHTaxAmountDBOB)", String.Empty))
                                    Else
                                        DebitWhtOB = 0
                                    End If
                                Catch ex As Exception

                                End Try
                            End If
                        Else
                        End If
                    Catch ex As Exception

                    End Try


                    DebitPV = 0

                    CreditPV = 0


                    Dim dtob As DataTable
                    dtob = ObjtblBankMst.GetOBNew(objDataTable.Rows(x)("Accountcode"))
                    Dim OpCre As Decimal = 0
                    Dim OpDbt As Decimal = 0
                    Try
                        OpCre = CreditWhtOB + OpeningInvAmtCredit + OpeningCVCreditMaster + 0 + OpeningCreditBPV + OpeningCreditBPVMaster + OpeningJVCredit + OpeningCVCredit + OpeningContraCredit
                        OpDbt = DebitWhtOB + OpeningCVDebitMaster + OpeningInvAmtDebit + 0 + OpenDebitBPV + OpeningDebitBPVMaster + OpeningJVDebit + OpeningCVDebit + OpeningContraDebit
                    Catch ex As Exception

                    End Try

                    ''=============End=================================
                    Try
                        Dr = dt.NewRow()
                        Dr("TempTrialID") = 0
                        Dr("Accountcode") = objDataTable.Rows(x)("Accountcode")
                        If TotalBankDb = 0 Then
                            Dr("DebitBPV") = 0 + DebitWht + DebitCVMaster
                        Else
                            Dr("DebitBPV") = TotalBankDb + DebitWht + DebitCVMaster
                        End If
                        If TotalBankCR = 0 Then
                            Dr("CreditBPV") = 0 + CreditCVMaster + CreditWht
                        Else
                            Dr("CreditBPV") = TotalBankCR + CreditCVMaster + CreditWht
                        End If
                        If JVDebit = 0 Then
                            Dr("JVDebit") = 0
                        Else
                            Dr("JVDebit") = JVDebit
                        End If
                        If JVCredit = 0 Then
                            Dr("JVCredit") = 0
                        Else
                            Dr("JVCredit") = JVCredit
                        End If

                        If DebitCV = 0 Then
                            Dr("DebitCV") = 0
                        Else
                            Dr("DebitCV") = DebitCV
                        End If
                        If CreditCV = 0 Then
                            Dr("CreditCV") = 0
                        Else
                            Dr("CreditCV") = CreditCV
                        End If
                        If DebitPV = 0 Then
                            Dr("DebitPV") = 0 + InvAmtDebit
                        Else
                            Dr("DebitPV") = DebitPV + InvAmtDebit
                        End If

                        If CreditPV = 0 Then
                            Dr("CreditPV") = 0 + InvAmtCredit
                        Else
                            Dr("CreditPV") = CreditPV + InvAmtCredit
                        End If

                        If DebitContra = 0 Then
                            Dr("DebitContra") = 0
                        Else
                            Dr("DebitContra") = DebitContra
                        End If
                        If CreditContra = 0 Then
                            Dr("CreditContra") = 0
                        Else
                            Dr("CreditContra") = CreditContra
                        End If

                        If OpDbt = 0 Then
                            Dr("OB") = 0
                        Else
                            Dr("OB") = OpDbt
                        End If
                        If OpCre = 0 Then
                            Dr("OBCr") = 0
                        Else
                            Dr("OBCr") = OpCre
                        End If
                        dt.Rows.Add(Dr)
                    Catch ex As Exception

                    End Try
                Next
            End If
            Session("dt") = dt

            For x = 0 To dt.Rows.Count - 1
                With ObjTemTrialBalance
                    Try
                        .TempTrialID = 0
                        .Accountcode = dt.Rows(x)("Accountcode")
                        .DebitBPV = dt.Rows(x)("DebitBPV")
                        .CreditBPV = dt.Rows(x)("CreditBPV")
                        .JVDebit = dt.Rows(x)("JVDebit")
                        .JVCredit = dt.Rows(x)("JVCredit")
                        .DebitCV = dt.Rows(x)("DebitCV")
                        .CreditCV = dt.Rows(x)("CreditCV")
                        .DebitPV = dt.Rows(x)("DebitPV")
                        .CreditPV = dt.Rows(x)("CreditPV")
                        .DebitContra = dt.Rows(x)("DebitContra")
                        .CreditContra = dt.Rows(x)("CreditContra")
                        .OB = dt.Rows(x)("OB")
                        .OBCR = dt.Rows(x)("OBCr")
                        .SaveTemTrialBalance()
                    Catch ex As Exception

                    End Try
                End With
            Next

            '==========================================Again insert in Final
            ObjtblBankMst.TruncatingTemTrialBalancefinalTables()

            Dim Dt0 As DataTable
            Dim ObjTemTrialBalanceFinal As New TemTrialBalanceFinal
            Dt0 = ObjtblBankMst.GetMainHeadForTB()
            If Dt0.Rows.Count > 0 Then
                Dim X0 As Integer
                For X0 = 0 To Dt0.Rows.Count - 1
                    Dim Dt1Data, Dt1Qty As DataTable
                    Dt1Data = ObjtblBankMst.GetNAmeForTB(Dt0.Rows(X0)("accountcode").ToString)

                    '-----
                    If Dt1Data.Rows.Count > 0 Then
                        Dim dt2data, Dt2Qty As DataTable
                        Dim X2 As Integer
                        For X2 = 0 To Dt1Data.Rows.Count - 1
                            Dt1Qty = ObjtblBankMst.GetQTYForTB(Dt1Data.Rows(X2)("accountcode").ToString)
                            Try
                                With ObjTemTrialBalanceFinal
                                    .TempTrialID = 0
                                    .Accountcode = Dt1Data.Rows(X2)("Accountcode")
                                    .AccountName = Dt1Data.Rows(X2)("AccountName")
                                    If Dt1Qty.Rows.Count > 0 Then
                                        .Debit = Convert.ToInt64(Dt1Qty.Compute("SUM(DB)", String.Empty))
                                        .Credit = Convert.ToInt64(Dt1Qty.Compute("SUM(CR)", String.Empty))
                                        .OB = Convert.ToInt64(Dt1Qty.Compute("SUM(OB)", String.Empty))
                                    Else
                                        .Debit = 0
                                        .Credit = 0
                                        .OB = 0
                                    End If
                                    .LevelGroup = 0
                                    .SaveTemTrialBalance()
                                End With
                            Catch ex As Exception

                            End Try

                            dt2data = ObjTemTrialBalance.GetNAmeForTBNotin2(Dt1Data.Rows(X2)("accountcode").ToString)
                            Try
                                If dt2data.Rows.Count > 0 Then
                                    Dim y As Integer
                                    For y = 0 To dt2data.Rows.Count - 1
                                        Dt2Qty = ObjTemTrialBalance.GetQTYForTBNotin2(dt2data.Rows(y)("accountcode").ToString)
                                        If Dt2Qty.Rows.Count > 0 Then
                                            With ObjTemTrialBalanceFinal
                                                .TempTrialID = 0
                                                .Accountcode = Dt2Qty.Rows(0)("Accountcode")
                                                .AccountName = Dt2Qty.Rows(0)("AccountName")
                                                If Dt2Qty.Rows.Count > 0 Then
                                                    .Debit = Convert.ToInt64(Dt2Qty.Compute("SUM(DB)", String.Empty))
                                                    .Credit = Convert.ToInt64(Dt2Qty.Compute("SUM(CR)", String.Empty))
                                                    .OB = Convert.ToInt64(Dt2Qty.Compute("SUM(OB)", String.Empty))
                                                Else
                                                    .Debit = 0
                                                    .Credit = 0
                                                    .OB = 0
                                                End If
                                                .LevelGroup = 1
                                                .SaveTemTrialBalance()
                                            End With
                                        End If
                                    Next
                                End If
                            Catch ex As Exception

                            End Try
                        Next
                    End If

                Next '----1Next
            End If '----1Endif




        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            SetAllVouchersData()

            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim FINANCIALYEAR As String

            FINANCIALYEAR = cmbSession.SelectedItem.Text

            Dim StartDate As Date = txtstartdate.Text
            Dim EndDate As Date = txtEndDate.Text

            Report.Load(Server.MapPath("~/Reports/Report11111111111.rpt"))


            Report.Refresh()

            Report.SetParameterValue(0, StartDate)
            Report.SetParameterValue(1, EndDate)
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Trial Balance Report"
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

            '''' '-------Code for PDf open same Tab not download--------Start 
            Dim path As String = (Server.MapPath("~/TempPDF") + "/" + FileName + ".pdf")
            Dim fs As FileStream = New FileStream(path, FileMode.Open)
            Dim fileSize As Long
            fileSize = fs.Length
            Dim Buffer() As Byte = New Byte((CType(fileSize, Integer)) - 1) {}
            fs.Read(Buffer, 0, CType(fs.Length, Integer))
            fs.Close()
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", ("inline; filename=" + FileName))
            Response.BinaryWrite(Buffer)
            Response.Flush()
            Response.End()


        Catch ex As Exception

        End Try
    End Sub
End Class

