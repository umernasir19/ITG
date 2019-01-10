Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports Telerik.Web.UI
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class JOProgramView
    Inherits System.Web.UI.Page
    Dim objStyleAssortmentMaster As New StyleAssortmentMaster
    Dim objFabricationMaster As New FabricationMaster
    Dim objCuttingProMst As New CuttingProMst
    Dim objTempAccCheckListSize As New TempAccCheckListSize
    Dim objTempCuttingPro As New TempCuttingPro
    Dim Dr As DataRow
    Dim objTempZipperCheckListSize As New TempZipperCheckListSize
    Dim objAccCheckListMst As New AccCheckListMst
    Dim Userid As Long
    Dim ObjDepartmentDataBase As New DepartmetDataBase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objDataView As DataView
        Userid = CLng(Session("Userid"))
        If Not Page.IsPostBack Then
            Try
                objDataView = LoadData()
                Session("objDataView") = objDataView
                BindGrid()
                GetRights()
            Catch objUDException As UDException
            End Try
        End If
        PageHeader("Style Assortment View")
    End Sub
    Sub GetRights()
        Dim Path As String = Request.Url.AbsolutePath()
        Dim PathArr() As String = Path.Split("/")
        Dim Path5 As String = PathArr(PathArr.Length - 2)
        Dim Path6 As String = PathArr(PathArr.Length - 1)
        Dim Path4 As String = Path5 + "/" + Path6
        Dim dt As DataTable
        dt = ObjDepartmentDataBase.CheckdataWithAccess(Userid, Path4)
        If dt.Rows.Count > 0 Then
            Dim View As String = dt.Rows(0)("ViewStatus")
            If View = 1 Then
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items(x).FindControl("lnkCopy"), ImageButton)
                    lnkEditt.Enabled = True
                    lnkOk.Enabled = True
                    lnkAccChecklist.Enabled = True
                    lnkCopy.Enabled = True
                Next
            Else
                Dim x As Long
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkEditt As ImageButton = CType(dgView.Items(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkOk As ImageButton = CType(dgView.Items(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items(x).FindControl("lnkCopy"), ImageButton)
                    lnkEditt.Enabled = False
                    lnkOk.Enabled = False
                    lnkAccChecklist.Enabled = False
                    lnkCopy.Enabled = False
                Next
            End If
        End If
    End Sub
    Sub ZipperCheckListPDF(ByVal JobOrderID As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long, ByVal RevisedDatee As String)
        Dim Style As String
        Dim SRNo As String
        Dim CustomerName As String
        Dim CustomerOrder As String
        Dim Desc As String
        Dim FabricContent As String
        Dim Quantity As String
        Dim Color As String
        Dim AccCheckListMstID As Long
        Dim Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11 As String
        Dim dtS1, dtS2, dtS3, dtS4, dtS5, dtS6, dtS7, dtS8, dtS9, dtS10, dtS11 As DataTable
        Dim dtFinal = New DataTable
        objTempAccCheckListSize.TruncateTableZipper()
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("RowType", GetType(String))
            .Columns.Add("RowNo", GetType(String))
            .Columns.Add("Description", GetType(String))
            .Columns.Add("CategoryName", GetType(String))
            .Columns.Add("ItemName", GetType(String))
            .Columns.Add("AccCheckListMstID", GetType(String))
            .Columns.Add("AccCheckListDetailID", GetType(String))
            .Columns.Add("S1", GetType(String))
            .Columns.Add("S2", GetType(String))
            .Columns.Add("S3", GetType(String))
            .Columns.Add("S4", GetType(String))
            .Columns.Add("S5", GetType(String))
            .Columns.Add("S6", GetType(String))
            .Columns.Add("S7", GetType(String))
            .Columns.Add("S8", GetType(String))
            .Columns.Add("S9", GetType(String))
            .Columns.Add("S10", GetType(String))
            .Columns.Add("S11", GetType(String))
        End With
        Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
        If dtAcccheckList.Rows.Count > 0 Then
            Dim dtsize As DataTable = objAccCheckListMst.GetSizeZipper(dtAcccheckList.Rows(0)("AccCheckListMstID"))
            AccCheckListMstID = dtAcccheckList.Rows(0)("AccCheckListMstID")
            Dim x, s As Integer
            For x = 0 To dtsize.Rows.Count - 1
                Dim dtAccDetail As DataTable = objAccCheckListMst.GetdetailofsizeNewForZipper(dtAcccheckList.Rows(0)("AccCheckListMstID"), dtsize.Rows(x)("Size"))
                ''----------Size 1
                If x = 0 Then
                    Size1 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("RowNo") = "1"
                                Dr("S1") = dtAccDetail.Rows(i)("ColorZippersizes")
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S1") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S1") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S1") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If

                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                ''----------Size 2
                If x = 1 Then
                    Size2 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S2") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S2") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S2") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S2") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                ''----------Size 3
                If x = 2 Then
                    Size3 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S3") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S3") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S3") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S3") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 4
                If x = 3 Then
                    Size4 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S4") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S4") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S4") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S4") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                '''   ''----------Size 5
                If x = 4 Then
                    Size5 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S5") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S5") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S5") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S5") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                '''   ''----------Size 6
                If x = 5 Then
                    Size6 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S6") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S6") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S6") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S6") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 7
                If x = 6 Then
                    Size7 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S7") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S7") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S7") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S7") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 8
                If x = 7 Then
                    Size8 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S8") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S8") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S8") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S8") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 9
                If x = 8 Then
                    Size9 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S9") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S9") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S9") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S9") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 10
                If x = 9 Then
                    Size10 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S10") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S10") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S10") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S10") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------

                ''----------Size 11
                If x = 10 Then
                    Size11 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S11") = dtAccDetail.Rows(i)("ColorZippersizes")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S11") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S11") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S11") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
            Next

            For A As Integer = 0 To dtFinal.Rows.Count - 1
                With objTempZipperCheckListSize
                    .TempId = 0
                    '.RowType = dtFinal.Rows(A)("RowType")
                    '.RowNo = dtFinal.Rows(A)("RowNo")
                    .Description = dtFinal.Rows(A)("Description")
                    .CategoryName = dtFinal.Rows(A)("CategoryName")
                    .ItemName = dtFinal.Rows(A)("ItemName")
                    .AccCheckListMstID = dtFinal.Rows(A)("AccCheckListMstID")
                    .AccCheckListDetailID = dtFinal.Rows(A)("ZipperCheckListDetailID")
                    .S1 = dtFinal.Rows(A)("S1")
                    .S2 = dtFinal.Rows(A)("S2")
                    .S3 = dtFinal.Rows(A)("S3")
                    .S4 = dtFinal.Rows(A)("S4")
                    .S5 = dtFinal.Rows(A)("S5")
                    .S6 = dtFinal.Rows(A)("S6")
                    .S7 = dtFinal.Rows(A)("S7")
                    .S8 = dtFinal.Rows(A)("S8")
                    .S9 = dtFinal.Rows(A)("S9")
                    .S10 = dtFinal.Rows(A)("S10")
                    .S11 = dtFinal.Rows(A)("S11")
                    .Savetemp()
                End With
            Next
        End If
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next

        Dim Report As New ReportDocument
        Dim Options As New ExportOptions

        'Report.Load(Server.MapPath("..\Reports/SummaryWorkLoadFinal.rpt"))
        Report.Load(Server.MapPath("..\Reports/AccessoriesCheckList.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "Acc.CheckList"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        Report.SetParameterValue(0, AccCheckListMstID)
        Report.SetParameterValue(1, AccCheckListMstID)
        Report.SetParameterValue(2, AccCheckListMstID)
        Report.SetParameterValue(3, Size1)
        Report.SetParameterValue(4, Size2)
        Report.SetParameterValue(5, Size3)
        Report.SetParameterValue(6, Size4)
        Report.SetParameterValue(7, Size5)
        Report.SetParameterValue(8, Size6)
        Report.SetParameterValue(9, Size7)
        Report.SetParameterValue(10, Size8)
        Report.SetParameterValue(11, Size9)
        Report.SetParameterValue(12, Size10)
        Report.SetParameterValue(13, Size11)
        Report.SetParameterValue(14, AccCheckListMstID)
        Report.SetParameterValue(15, RevisedDatee)

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
    End Sub
    Sub PageHeader(ByVal PageName As String)
        Dim lblPageHead As Label
        lblPageHead = Master.FindControl("lblPageHead")
        lblPageHead.Text = PageName
    End Sub
    Protected Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSearch.TextChanged
        Try
            Dim dt1 As DataTable = objStyleAssortmentMaster.ViewForBrandStyleAssormentViewForChecklist(txtSearch.Text)
            Dim dt2 As DataTable = objStyleAssortmentMaster.ViewForBuyerStyleAssormentViewForChecklist(txtSearch.Text)
            Dim dt3 As DataTable = objStyleAssortmentMaster.ViewForStyleStyleAssormentViewForChecklist(txtSearch.Text)
            Dim dt4 As DataTable = objStyleAssortmentMaster.ViewForSrNoStyleAssormentViewForChecklist(txtSearch.Text)
            Dim dt5 As DataTable = objStyleAssortmentMaster.ViewForSeasonStyleAssormentViewForChecklist(txtSearch.Text)
            If dt1.Rows.Count > 0 Then
                dgView.DataSource = dt1
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
                    Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text
                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.ImageUrl = "~/Images/green.png"
                    End If

                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                    Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtcutting.Rows.Count > 0 Then
                        lnkCuttingProgramPDF.Enabled = True
                        lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkOk.ImageUrl = "~/Images/green.png"
                        lnkOk.ToolTip = "Click here to edit Cutting Program"
                    Else
                        lnkCuttingProgramPDF.Enabled = False
                        lnkCuttingProgramPDF.ToolTip = "Not Available"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkOk.ImageUrl = "~/Images/red.png"
                        lnkOk.ToolTip = "Click here to Cutting Program"
                    End If
                    Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtAcccheckList.Rows.Count > 0 Then
                        lnkAccChecklistPDF.Enabled = True
                        lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/green.png"
                        lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                        lnkCopy.Visible = True
                    Else
                        lnkAccChecklistPDF.Enabled = False
                        lnkAccChecklistPDF.ToolTip = "Not Available"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/red.png"
                        lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                        lnkCopy.Visible = False
                    End If

                Next
                GetRights()
            ElseIf dt2.Rows.Count > 0 Then
                dgView.DataSource = dt2
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)

                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
                    Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.ImageUrl = "~/Images/green.png"
                    End If

                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                    Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtcutting.Rows.Count > 0 Then
                        lnkCuttingProgramPDF.Enabled = True
                        lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkOk.ImageUrl = "~/Images/green.png"
                        lnkOk.ToolTip = "Click here to edit Cutting Program"
                    Else
                        lnkCuttingProgramPDF.Enabled = False
                        lnkCuttingProgramPDF.ToolTip = "Not Available"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkOk.ImageUrl = "~/Images/red.png"
                        lnkOk.ToolTip = "Click here to Cutting Program"
                    End If
                    Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtAcccheckList.Rows.Count > 0 Then
                        lnkAccChecklistPDF.Enabled = True
                        lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/green.png"
                        lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                        lnkCopy.Visible = True
                    Else
                        lnkAccChecklistPDF.Enabled = False
                        lnkAccChecklistPDF.ToolTip = "Not Available"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/red.png"
                        lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                        lnkCopy.Visible = False
                    End If

                Next
                GetRights()
            ElseIf dt3.Rows.Count > 0 Then
                dgView.DataSource = dt3
                dgView.DataBind()
                Dim x As Integer
                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)

                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
                    Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.ImageUrl = "~/Images/green.png"
                    End If

                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                    Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtcutting.Rows.Count > 0 Then
                        lnkCuttingProgramPDF.Enabled = True
                        lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkOk.ImageUrl = "~/Images/green.png"
                        lnkOk.ToolTip = "Click here to edit Cutting Program"
                    Else
                        lnkCuttingProgramPDF.Enabled = False
                        lnkCuttingProgramPDF.ToolTip = "Not Available"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkOk.ImageUrl = "~/Images/red.png"
                        lnkOk.ToolTip = "Click here to Cutting Program"
                    End If
                    Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtAcccheckList.Rows.Count > 0 Then
                        lnkAccChecklistPDF.Enabled = True
                        lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/green.png"
                        lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                        lnkCopy.Visible = True
                    Else
                        lnkAccChecklistPDF.Enabled = False
                        lnkAccChecklistPDF.ToolTip = "Not Available"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/red.png"
                        lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                        lnkCopy.Visible = False
                    End If

                Next
                GetRights()
            ElseIf dt4.Rows.Count > 0 Then
                dgView.DataSource = dt4
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)

                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
                    Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.ImageUrl = "~/Images/green.png"
                    End If

                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                    Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtcutting.Rows.Count > 0 Then
                        lnkCuttingProgramPDF.Enabled = True
                        lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkOk.ImageUrl = "~/Images/green.png"
                        lnkOk.ToolTip = "Click here to edit Cutting Program"
                    Else
                        lnkCuttingProgramPDF.Enabled = False
                        lnkCuttingProgramPDF.ToolTip = "Not Available"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkOk.ImageUrl = "~/Images/red.png"
                        lnkOk.ToolTip = "Click here to Cutting Program"
                    End If
                    Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtAcccheckList.Rows.Count > 0 Then
                        lnkAccChecklistPDF.Enabled = True
                        lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/green.png"
                        lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                        lnkCopy.Visible = True
                    Else
                        lnkAccChecklistPDF.Enabled = False
                        lnkAccChecklistPDF.ToolTip = "Not Available"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/red.png"
                        lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                        lnkCopy.Visible = False
                    End If

                Next
                GetRights()
            ElseIf dt5.Rows.Count > 0 Then
                dgView.DataSource = dt5
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)

                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
                    Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.ImageUrl = "~/Images/green.png"
                    End If

                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                    Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtcutting.Rows.Count > 0 Then
                        lnkCuttingProgramPDF.Enabled = True
                        lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkOk.ImageUrl = "~/Images/green.png"
                        lnkOk.ToolTip = "Click here to edit Cutting Program"
                    Else
                        lnkCuttingProgramPDF.Enabled = False
                        lnkCuttingProgramPDF.ToolTip = "Not Available"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkOk.ImageUrl = "~/Images/red.png"
                        lnkOk.ToolTip = "Click here to Cutting Program"
                    End If
                    Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtAcccheckList.Rows.Count > 0 Then
                        lnkAccChecklistPDF.Enabled = True
                        lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/green.png"
                        lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                        lnkCopy.Visible = True
                    Else
                        lnkAccChecklistPDF.Enabled = False
                        lnkAccChecklistPDF.ToolTip = "Not Available"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/red.png"
                        lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                        lnkCopy.Visible = False
                    End If

                Next
                GetRights()
            Else
                Dim dt6 As DataTable = objStyleAssortmentMaster.JOView
                dgView.DataSource = dt6
                dgView.DataBind()
                Dim x As Integer

                For x = 0 To dgView.Items.Count - 1
                    Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
                    Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
                    Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
                    Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
                    Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
                    Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
                    Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
                    Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)

                    Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text

                    Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
                    If StyleAssortmentMasterID = 0 Then
                        lnkOk.Visible = False
                        lnkEdit.Visible = True
                    Else
                        lnkOk.Visible = True
                        lnkEdit.Visible = False
                        lnkOk.ImageUrl = "~/Images/green.png"
                    End If

                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
                    If dtChk.Rows.Count > 0 Then
                        lnkCreateFab.Visible = False
                        lnkEditFab.Visible = True
                    Else
                        lnkCreateFab.Visible = True
                        lnkEditFab.Visible = False
                    End If
                    Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtcutting.Rows.Count > 0 Then
                        lnkCuttingProgramPDF.Enabled = True
                        lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkOk.ImageUrl = "~/Images/green.png"
                        lnkOk.ToolTip = "Click here to edit Cutting Program"
                    Else
                        lnkCuttingProgramPDF.Enabled = False
                        lnkCuttingProgramPDF.ToolTip = "Not Available"
                        lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkOk.ImageUrl = "~/Images/red.png"
                        lnkOk.ToolTip = "Click here to Cutting Program"
                    End If
                    Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    If dtAcccheckList.Rows.Count > 0 Then
                        lnkAccChecklistPDF.Enabled = True
                        lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/green.png"
                        lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                        lnkCopy.Visible = True
                    Else
                        lnkAccChecklistPDF.Enabled = False
                        lnkAccChecklistPDF.ToolTip = "Not Available"
                        lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                        lnkAccChecklist.ImageUrl = "~/Images/red.png"
                        lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                        lnkCopy.Visible = False
                    End If

                Next
                GetRights()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindGrid()
        Dim objDataView As DataView
        objDataView = Session("objDataView")
        dgView.RecordCount = objDataView.Count
        dgView.DataSource = objDataView
        dgView.DataBind()
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim lnkOk As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkOk"), ImageButton)
            Dim lnkEdit As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEdit"), ImageButton)
            Dim lnkCuttingProgramPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCuttingProgramPDF"), ImageButton)
            Dim lnkCreateFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCreateFab"), ImageButton)
            Dim lnkEditFab As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkEditFab"), ImageButton)
            Dim lnkCopy As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkCopy"), ImageButton)
            Dim lnkAccChecklist As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklist"), ImageButton)
            Dim lnkAccChecklistPDF As ImageButton = CType(dgView.Items.Item(x).FindControl("lnkAccChecklistPDF"), ImageButton)
            Dim JobOrderID As String = dgView.Items.Item(x).Cells(1).Text
            Dim JoborderDetailid As String = dgView.Items.Item(x).Cells(2).Text
            Dim StyleAssortmentMasterID As Long = dgView.Items.Item(x).Cells(0).Text
            If StyleAssortmentMasterID = 0 Then
                lnkOk.Visible = False
                lnkEdit.Visible = True
            Else
                lnkOk.Visible = True
                lnkEdit.Visible = False
                lnkOk.ImageUrl = "~/Images/green.png"
            End If
            Dim dtChk As DataTable = objFabricationMaster.CheckExist(dgView.Items.Item(x).Cells(1).Text, dgView.Items.Item(x).Cells(2).Text)
            If dtChk.Rows.Count > 0 Then
                lnkCreateFab.Visible = False
                lnkEditFab.Visible = True
            Else
                lnkCreateFab.Visible = True
                lnkEditFab.Visible = False
            End If
            Dim dtcutting As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
            If dtcutting.Rows.Count > 0 Then
                lnkCuttingProgramPDF.Enabled = True
                lnkCuttingProgramPDF.ToolTip = "Click to Download Cutting Program PDF"
                lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                lnkOk.ImageUrl = "~/Images/green.png"
                lnkOk.ToolTip = "Click here to edit Cutting Program"
            Else
                lnkCuttingProgramPDF.Enabled = False
                lnkCuttingProgramPDF.ToolTip = "Not Available"
                lnkCuttingProgramPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                lnkOk.ImageUrl = "~/Images/red.png"
                lnkOk.ToolTip = "Click here to Cutting Program"
            End If
            Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
            If dtAcccheckList.Rows.Count > 0 Then
                lnkAccChecklistPDF.Enabled = True
                lnkAccChecklistPDF.ToolTip = "Click to Download Acc. CheckList PDF"
                lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_small.gif"
                lnkAccChecklist.ImageUrl = "~/Images/green.png"
                lnkAccChecklist.ToolTip = "Click here to edit Acc. CheckList"
                lnkCopy.Visible = True
            Else
                lnkAccChecklistPDF.Enabled = False
                lnkAccChecklistPDF.ToolTip = "Not Available"
                lnkAccChecklistPDF.ImageUrl = "~/Images/pdf_icon_NotAv.gif"
                lnkAccChecklist.ImageUrl = "~/Images/red.png"
                lnkAccChecklist.ToolTip = "Click here to Acc. CheckList"
                lnkCopy.Visible = False
            End If
        Next
        GetRights()
    End Sub
    Function LoadData() As ICollection
        Dim objDataView As DataView
        Dim objDataTable As DataTable
        objDataTable = objStyleAssortmentMaster.JOView
        objDataView = New DataView(objDataTable)
        Return objDataView
    End Function
    Public Sub PageChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgView.PageIndexChanged
        BindGrid()
        GetRights()
    End Sub
    Public Sub SortByColumn(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgView.SortCommand
        BindGrid()
        GetRights()
    End Sub
    Public Sub DataBound(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgView.ItemDataBound
    End Sub
    Protected Sub dgView_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgView.ItemCommand
        Try
            Select Case e.CommandName
                Case "StyleAssortmanr"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Styles As String = dgView.Items(e.Item.ItemIndex).Cells(8).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("StyleAssortmentEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "&Styles=" & Styles & "")
                Case "Edit"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("StyleAssortmentEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "FABRICATION"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("FabricationEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "FABRICATIONEdit"
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Dim dtChk As DataTable = objFabricationMaster.CheckExist(JobOrderID, JoborderDetailid)
                    If dtChk.Rows.Count > 0 Then
                        Response.Redirect("FabricationEntry.aspx?JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "&FabricationMasterID=" & dtChk.Rows(0)("FabricationMasterID") & "")
                    End If
                Case "CuttingProgram"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("CuttingProgramEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "AccCheckList"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("AccChecklistEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "CuttingProgramPDF"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim AccMstID As DataTable = objAccCheckListMst.GetCuttingMstID(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    Dim id As Long = AccMstID.Rows(0)("CuttingProMasterID")
                    Dim dttt As DataTable = objAccCheckListMst.GetRevisedDateCutting(id)
                    Dim RevisedCuttingDate As String = ""
                    Dim RevisedCuttingDatee As String = ""
                    For F As Integer = 0 To dttt.Rows.Count - 1
                        RevisedCuttingDate = dttt.Rows(F)("RevisedDatee") + " "
                        RevisedCuttingDatee = RevisedCuttingDatee + RevisedCuttingDate
                    Next
                    CuttingPDF(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                Case "AccCheckList"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("AccChecklistEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & "")
                Case "Copy"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text
                    Dim Type As String = "Copy"
                    DirectCast(Me.Page.Master, MasterPage).ShowMessgae("  ")
                    Response.Redirect("AccChecklistEntry.aspx?StyleAssortmentMasterID=" & StyleAssortmentMasterID & "&JobOrderID=" & JobOrderID & "&JoborderDetailid=" & JoborderDetailid & " &Type=" & Type & "")
                Case "AccChecklistPDF"
                    Dim StyleAssortmentMasterID As String = dgView.Items(e.Item.ItemIndex).Cells(0).Text
                    Dim JobOrderID As String = dgView.Items(e.Item.ItemIndex).Cells(1).Text
                    Dim JoborderDetailid As String = dgView.Items(e.Item.ItemIndex).Cells(2).Text

                    Dim AccMstID As DataTable = objAccCheckListMst.GetAccMstID(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
                    Dim id As Long = AccMstID.Rows(0)("AccCheckListMstID")
                    Dim dtt As DataTable = objAccCheckListMst.GetRevisedDate(id)
                    Dim RevisedDate As String = ""
                    Dim RevisedDatee As String = ""
                    For F As Integer = 0 To dtt.Rows.Count - 1
                        RevisedDate = dtt.Rows(F)("RevisedDatee") + " "
                        RevisedDatee = RevisedDatee + RevisedDate
                    Next
                    AccCheckListPDF(JobOrderID, JoborderDetailid, StyleAssortmentMasterID, RevisedDatee)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub UpdateStatus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim JoborderDetailid As Integer
        Dim x As Integer
        For x = 0 To dgView.Items.Count - 1
            Dim ChkMove As CheckBox = CType(dgView.Items(x).FindControl("ChkMove"), CheckBox)
            If ChkMove.Checked = True Then
                JoborderDetailid = dgView.Items(x).Cells(0).Text
                Response.Write("<script> window.open('JoborderDetailMovePopup.aspx?JoborderDetailid=" & JoborderDetailid & "', 'newwindow', 'left=100, top=180, height=200, width=300, status=no, resizable=no, scrollbars= yes, toolbar=no,location=no, menubar=no,directories=no'); </script>")
                ChkMove.Checked = False
            End If
        Next
    End Sub
    Sub AccCheckListPDF(ByVal JobOrderID As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long, ByVal RevisedDatee As String)


        Dim Style As String
        Dim SRNo As String
        Dim CustomerName As String
        Dim CustomerOrder As String
        Dim Desc As String
        Dim FabricContent As String
        Dim Quantity As String
        Dim Color As String
        Dim AccCheckListMstID As Long
        Dim Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11 As String
        Dim dtS1, dtS2, dtS3, dtS4, dtS5, dtS6, dtS7, dtS8, dtS9, dtS10, dtS11 As DataTable
        Dim dtFinal = New DataTable
        objTempAccCheckListSize.TruncateTable()
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("RowType", GetType(String))
            .Columns.Add("RowNo", GetType(String))
            .Columns.Add("Description", GetType(String))
            .Columns.Add("CategoryName", GetType(String))
            .Columns.Add("ItemName", GetType(String))
            .Columns.Add("AccCheckListMstID", GetType(String))
            .Columns.Add("AccCheckListDetailID", GetType(String))
            .Columns.Add("S1", GetType(String))
            .Columns.Add("S2", GetType(String))
            .Columns.Add("S3", GetType(String))
            .Columns.Add("S4", GetType(String))
            .Columns.Add("S5", GetType(String))
            .Columns.Add("S6", GetType(String))
            .Columns.Add("S7", GetType(String))
            .Columns.Add("S8", GetType(String))
            .Columns.Add("S9", GetType(String))
            .Columns.Add("S10", GetType(String))
            .Columns.Add("S11", GetType(String))
        End With
        Dim dtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
        If dtAcccheckList.Rows.Count > 0 Then
            Dim dtsize As DataTable = objAccCheckListMst.GetSize(dtAcccheckList.Rows(0)("AccCheckListMstID"))
            AccCheckListMstID = dtAcccheckList.Rows(0)("AccCheckListMstID")
            'If dtsize.Rows.Count > 0 Then
            '    Size1 = dtsize.Rows(0)("Size")
            '    Dim CuttingProDetailID As Long = dtsize.Rows(0)("CuttingProDetailID")
            '    dtS1 = objCuttingProMst.GetSizeQty(Size1, CuttingProDetailID)
            'End If
            Dim x, s As Integer
            For x = 0 To dtsize.Rows.Count - 1
                Dim dtAccDetail As DataTable = objAccCheckListMst.GetdetailofsizeNew(dtAcccheckList.Rows(0)("AccCheckListMstID"), dtsize.Rows(x)("Size"))
                ''----------Size 1
                If x = 0 Then
                    Size1 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("RowNo") = "1"
                                Dr("S1") = dtAccDetail.Rows(i)("UsagePC")
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S1") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S1") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S1") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If

                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                ''----------Size 2
                If x = 1 Then
                    Size2 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S2") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S2") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S2") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S2") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                ''----------Size 3
                If x = 2 Then
                    Size3 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S3") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S3") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S3") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S3") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 4
                If x = 3 Then
                    Size4 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S4") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S4") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S4") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S4") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                '''   ''----------Size 5
                If x = 4 Then
                    Size5 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S5") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S5") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S5") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S5") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                '''   ''----------Size 6
                If x = 5 Then
                    Size6 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S6") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S6") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S6") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S6") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 7
                If x = 6 Then
                    Size7 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S7") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S7") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S7") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S7") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 8
                If x = 7 Then
                    Size8 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S8") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S8") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S8") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S8") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 9
                If x = 8 Then
                    Size9 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S9") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S9") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S9") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S9") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S10") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
                ''----------Size 10
                If x = 9 Then
                    Size10 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S10") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S10") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S10") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S10") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S11") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------

                ''----------Size 11
                If x = 10 Then
                    Size11 = dtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To dtAccDetail.Rows.Count - 1
                        s = 0
                        For s = 0 To 3
                            Dr = dtFinal.NewRow()
                            Dr("TempId") = 0
                            If s = 0 Then
                                Dr("RowType") = "Usage/PC"
                                Dr("S11") = dtAccDetail.Rows(i)("UsagePC")
                                Dr("RowNo") = "1"
                            ElseIf s = 1 Then
                                Dr("RowType") = "Total"
                                Dr("S11") = dtAccDetail.Rows(i)("Total")
                                Dr("RowNo") = "2"
                            ElseIf s = 2 Then
                                Dr("RowType") = "Percent"
                                Dr("S11") = dtAccDetail.Rows(i)("Percent")
                                Dr("RowNo") = "3"
                            ElseIf s = 3 Then
                                Dr("RowType") = "OrderQty"
                                Dr("S11") = dtAccDetail.Rows(i)("OrderQty")
                                Dr("RowNo") = "4"
                            End If
                            Dr("Description") = dtAccDetail.Rows(i)("Description")
                            Dr("CategoryName") = dtAccDetail.Rows(i)("ItemCategoryNamee")
                            Dr("ItemName") = dtAccDetail.Rows(i)("ItemNamee")
                            Dr("AccCheckListMstID") = dtAccDetail.Rows(i)("AccCheckListMstID")
                            Dr("AccCheckListDetailID") = dtAccDetail.Rows(i)("AccCheckListDetailID")
                            Dr("S1") = 0
                            Dr("S2") = 0
                            Dr("S3") = 0
                            Dr("S4") = 0
                            Dr("S5") = 0
                            Dr("S6") = 0
                            Dr("S7") = 0
                            Dr("S8") = 0
                            Dr("S9") = 0
                            Dr("S10") = 0
                            dtFinal.Rows.Add(Dr)
                        Next
                    Next
                End If
                '''--------------
            Next

            For A As Integer = 0 To dtFinal.Rows.Count - 1
                With objTempAccCheckListSize
                    .TempId = 0
                    .RowType = dtFinal.Rows(A)("RowType")
                    .RowNo = dtFinal.Rows(A)("RowNo")
                    .Description = dtFinal.Rows(A)("Description")
                    .CategoryName = dtFinal.Rows(A)("CategoryName")
                    .ItemName = dtFinal.Rows(A)("ItemName")
                    .AccCheckListMstID = dtFinal.Rows(A)("AccCheckListMstID")
                    .AccCheckListDetailID = dtFinal.Rows(A)("AccCheckListDetailID")
                    .S1 = dtFinal.Rows(A)("S1")
                    .S2 = dtFinal.Rows(A)("S2")
                    .S3 = dtFinal.Rows(A)("S3")
                    .S4 = dtFinal.Rows(A)("S4")
                    .S5 = dtFinal.Rows(A)("S5")
                    .S6 = dtFinal.Rows(A)("S6")
                    .S7 = dtFinal.Rows(A)("S7")
                    .S8 = dtFinal.Rows(A)("S8")
                    .S9 = dtFinal.Rows(A)("S9")
                    .S10 = dtFinal.Rows(A)("S10")
                    .S11 = dtFinal.Rows(A)("S11")
                    .Savetemp()
                End With
            Next
        End If

        '=================================
        Dim ZStyle As String
        Dim ZSRNo As String
        Dim ZCustomerName As String
        Dim ZCustomerOrder As String
        Dim ZDesc As String
        Dim ZFabricContent As String
        Dim ZQuantity As String
        Dim ZColor As String
        Dim ZAccCheckListMstID As Long
        Dim ZSize1, ZSize2, ZSize3, ZSize4, ZSize5, ZSize6, ZSize7, ZSize8, ZSize9, ZSize10, ZSize11 As String
        Dim ZdtS1, ZdtS2, ZdtS3, ZdtS4, ZdtS5, ZdtS6, ZdtS7, ZdtS8, ZdtS9, ZdtS10, ZdtS11 As DataTable
        Dim ZdtFinal = New DataTable
        objTempAccCheckListSize.TruncateTableZipper()
        With ZdtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("Description", GetType(String))
            .Columns.Add("CategoryName", GetType(String))
            .Columns.Add("ItemName", GetType(String))
            .Columns.Add("AccCheckListMstID", GetType(String))
            .Columns.Add("AccCheckListDetailID", GetType(String))
            .Columns.Add("S1", GetType(String))
            .Columns.Add("S2", GetType(String))
            .Columns.Add("S3", GetType(String))
            .Columns.Add("S4", GetType(String))
            .Columns.Add("S5", GetType(String))
            .Columns.Add("S6", GetType(String))
            .Columns.Add("S7", GetType(String))
            .Columns.Add("S8", GetType(String))
            .Columns.Add("S9", GetType(String))
            .Columns.Add("S10", GetType(String))
            .Columns.Add("S11", GetType(String))
            .Columns.Add("ZS1", GetType(String))
            .Columns.Add("ZS2", GetType(String))
            .Columns.Add("ZS3", GetType(String))
            .Columns.Add("ZS4", GetType(String))
            .Columns.Add("ZS5", GetType(String))
            .Columns.Add("ZS6", GetType(String))
            .Columns.Add("ZS7", GetType(String))
            .Columns.Add("ZS8", GetType(String))
            .Columns.Add("ZS9", GetType(String))
            .Columns.Add("ZS10", GetType(String))
            .Columns.Add("ZS11", GetType(String))
        End With
        Dim ZdtAcccheckList As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
        If ZdtAcccheckList.Rows.Count > 0 Then
            Dim Zdtsize As DataTable = objAccCheckListMst.GetSizeZipper(ZdtAcccheckList.Rows(0)("AccCheckListMstID"))
            ZAccCheckListMstID = ZdtAcccheckList.Rows(0)("AccCheckListMstID")

            Dim x, s As Integer
            For x = 0 To Zdtsize.Rows.Count - 1
                Dim ZdtAccDetail As DataTable = objAccCheckListMst.GetdetailofsizeNewForZipper(ZdtAcccheckList.Rows(0)("AccCheckListMstID"), Zdtsize.Rows(x)("Size"))
                ''----------Size 1
                If x = 0 Then
                    ZSize1 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                       Dr = ZdtFinal.NewRow()
                        Dr("TempId") = 0
                        Dr("S1") = ZdtAccDetail.Rows(i)("OrderQty")
                        Dr("ZS1") = ZdtAccDetail.Rows(i)("ColorZippersizes")
                        Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                        Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                        Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                        Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                        Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                        Dr("S2") = 0
                        Dr("S3") = 0
                        Dr("S4") = 0
                        Dr("S5") = 0
                        Dr("S6") = 0
                        Dr("S7") = 0
                        Dr("S8") = 0
                        Dr("S9") = 0
                        Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                        ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                ''----------Size 2
                If x = 1 Then
                    ZSize2 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                      
                        Dr = ZdtFinal.NewRow()
                        Dr("TempId") = 0
                        Dr("S2") = ZdtAccDetail.Rows(i)("OrderQty")
                        Dr("ZS2") = ZdtAccDetail.Rows(i)("ColorZippersizes")

                         Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S3") = 0
                Dr("S4") = 0
                Dr("S5") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""

                ZdtFinal.Rows.Add(Dr)

            Next
                End If
                ''----------Size 3
                If x = 2 Then
                    ZSize3 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                       
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0


                        Dr("S3") = ZdtAccDetail.Rows(i)("OrderQty")
                        Dr("ZS3") = ZdtAccDetail.Rows(i)("ColorZippersizes")

                          
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S4") = 0
                Dr("S5") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                Dr("S10") = 0
                        Dr("S11") = 0

                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                ZdtFinal.Rows.Add(Dr)
            Next

                End If
                '''--------------
                ''----------Size 4
                If x = 3 Then
                    ZSize4 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                     
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0


                        Dr("ZS4") = ZdtAccDetail.Rows(i)("ColorZippersizes")
                        Dr("S4") = ZdtAccDetail.Rows(i)("OrderQty")

                       
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S3") = 0
                Dr("S5") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------
                '''   ''----------Size 5
                If x = 4 Then
                    ZSize5 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                   
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0

                        Dr("S5") = ZdtAccDetail.Rows(i)("OrderQty")
                        Dr("ZS5") = ZdtAccDetail.Rows(i)("ColorZippersizes")

                          
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S3") = 0
                Dr("S4") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------
                '''   ''----------Size 6
                If x = 5 Then
                    ZSize6 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                   
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0

                        Dr("S6") = ZdtAccDetail.Rows(i)("OrderQty")
                        Dr("ZS6") = ZdtAccDetail.Rows(i)("ColorZippersizes")

                         
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S3") = 0
                Dr("S4") = 0
                Dr("S5") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------
                ''----------Size 7
                If x = 6 Then
                    ZSize7 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                    
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0


                        Dr("ZS7") = ZdtAccDetail.Rows(i)("ColorZippersizes")
                        Dr("S7") = ZdtAccDetail.Rows(i)("OrderQty")


                        Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                        Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                        Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                        Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                        Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                        Dr("S1") = 0
                        Dr("S2") = 0
                        Dr("S3") = 0
                        Dr("S4") = 0
                        Dr("S5") = 0
                        Dr("S6") = 0
                        Dr("S8") = 0
                        Dr("S9") = 0
                        Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                        ZdtFinal.Rows.Add(Dr)
                    Next

                End If
                '''--------------
                ''----------Size 8
                If x = 7 Then
                    ZSize8 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                    
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0


                        Dr("ZS8") = ZdtAccDetail.Rows(i)("ColorZippersizes")
                        Dr("S8") = ZdtAccDetail.Rows(i)("OrderQty")


                        Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                        Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                        Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                        Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                        Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                        Dr("S1") = 0
                        Dr("S2") = 0
                        Dr("S3") = 0
                        Dr("S4") = 0
                        Dr("S5") = 0
                        Dr("S6") = 0
                        Dr("S7") = 0
                        Dr("S9") = 0
                        Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                        ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------
                ''----------Size 9
                If x = 8 Then
                    ZSize9 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                   
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0


                        Dr("ZS9") = ZdtAccDetail.Rows(i)("ColorZippersizes")
                        Dr("S9") = ZdtAccDetail.Rows(i)("OrderQty")

                         
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S3") = 0
                Dr("S4") = 0
                Dr("S5") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S10") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS10") = ""
                        Dr("ZS11") = ""
                ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------
                ''----------Size 10
                If x = 9 Then
                    ZSize10 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                    
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0

                        Dr("S10") = ZdtAccDetail.Rows(i)("OrderQty")
                        Dr("ZS10") = ZdtAccDetail.Rows(i)("ColorZippersizes")

                          
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S3") = 0
                Dr("S4") = 0
                Dr("S5") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                        Dr("S11") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS11") = ""
                ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------

                ''----------Size 11
                If x = 10 Then
                    ZSize11 = Zdtsize.Rows(x)("Size")
                    Dim i As Integer
                    For i = 0 To ZdtAccDetail.Rows.Count - 1
                       
                            Dr = ZdtFinal.NewRow()
                            Dr("TempId") = 0
                        Dr("S11") = ZdtAccDetail.Rows(i)("OrderQty")

                        Dr("ZS11") = ZdtAccDetail.Rows(i)("ColorZippersizes")

                          
                Dr("Description") = ZdtAccDetail.Rows(i)("Description")
                Dr("CategoryName") = ZdtAccDetail.Rows(i)("ItemCategoryNamee")
                Dr("ItemName") = ZdtAccDetail.Rows(i)("ItemNamee")
                Dr("AccCheckListMstID") = ZdtAccDetail.Rows(i)("AccCheckListMstID")
                Dr("AccCheckListDetailID") = ZdtAccDetail.Rows(i)("ZipperCheckListDetailID")
                Dr("S1") = 0
                Dr("S2") = 0
                Dr("S3") = 0
                Dr("S4") = 0
                Dr("S5") = 0
                Dr("S6") = 0
                Dr("S7") = 0
                Dr("S8") = 0
                Dr("S9") = 0
                        Dr("S10") = 0
                        Dr("ZS1") = ""
                        Dr("ZS2") = ""
                        Dr("ZS3") = ""
                        Dr("ZS4") = ""
                        Dr("ZS5") = ""
                        Dr("ZS6") = ""
                        Dr("ZS7") = ""
                        Dr("ZS8") = ""
                        Dr("ZS9") = ""
                        Dr("ZS10") = ""
                ZdtFinal.Rows.Add(Dr)

                    Next
                End If
                '''--------------
            Next

            For A As Integer = 0 To ZdtFinal.Rows.Count - 1
                With objTempZipperCheckListSize
                    .TempId = 0
                  .Description = ZdtFinal.Rows(A)("Description")
                    .CategoryName = ZdtFinal.Rows(A)("CategoryName")
                    .ItemName = ZdtFinal.Rows(A)("ItemName")
                    .AccCheckListMstID = ZdtFinal.Rows(A)("AccCheckListMstID")
                    .AccCheckListDetailID = ZdtFinal.Rows(A)("AccCheckListDetailID")
                    .S1 = ZdtFinal.Rows(A)("S1")
                    .S2 = ZdtFinal.Rows(A)("S2")
                    .S3 = ZdtFinal.Rows(A)("S3")
                    .S4 = ZdtFinal.Rows(A)("S4")
                    .S5 = ZdtFinal.Rows(A)("S5")
                    .S6 = ZdtFinal.Rows(A)("S6")
                    .S7 = ZdtFinal.Rows(A)("S7")
                    .S8 = ZdtFinal.Rows(A)("S8")
                    .S9 = ZdtFinal.Rows(A)("S9")
                    .S10 = ZdtFinal.Rows(A)("S10")
                    .S11 = ZdtFinal.Rows(A)("S11")
                    .ZS1 = ZdtFinal.Rows(A)("ZS1")
                    .ZS2 = ZdtFinal.Rows(A)("ZS2")
                    .ZS3 = ZdtFinal.Rows(A)("ZS3")
                    .ZS4 = ZdtFinal.Rows(A)("ZS4")
                    .ZS5 = ZdtFinal.Rows(A)("ZS5")
                    .ZS6 = ZdtFinal.Rows(A)("ZS6")
                    .ZS7 = ZdtFinal.Rows(A)("ZS7")
                    .ZS8 = ZdtFinal.Rows(A)("ZS8")
                    .ZS9 = ZdtFinal.Rows(A)("ZS9")
                    .ZS10 = ZdtFinal.Rows(A)("ZS10")
                    .ZS11 = ZdtFinal.Rows(A)("ZS11")
                    .Savetemp()
                End With
            Next
        End If

        '=================================
        'If dt.Rows.Count > 0 And dttt.Rows.Count > 0 Then
        '    Report.Load(Server.MapPath("..\Reports/AccessoriesCheckList.rpt"))
        'ElseIf dt.Rows.Count > 0 And dttt.Rows.Count = 0 Then
        '    Report.Load(Server.MapPath("..\Reports/AccessoriesCheckListWithoutZipper.rpt"))
        'ElseIf dt.Rows.Count = 0 And dttt.Rows.Count > 0 Then
        '    Report.Load(Server.MapPath("..\Reports/AccessoriesCheckListWithoutSizeWise.rpt"))
        'ElseIf dt.Rows.Count = 0 And dttt.Rows.Count = 0 Then
        '    Report.Load(Server.MapPath("..\Reports/AccessoriesCheckListWithoutZipper.rpt"))
        'End If

        Dim dtT As DataTable = objAccCheckListMst.CheckMst(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
        Dim AccCheckListMstIDD As Long = dtT.Rows(0)("AccCheckListMstID")
        Dim dt As DataTable = objCuttingProMst.CheckChecklistMstIDinZipper(AccCheckListMstIDD)
        Dim dttt As DataTable = objCuttingProMst.CheckChecklistMstIDinAccDtl(AccCheckListMstIDD)

        If dt.Rows.Count > 0 And dttt.Rows.Count > 0 Then
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/AccessoriesCheckList.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Acc.CheckList"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, AccCheckListMstID)
            Report.SetParameterValue(1, AccCheckListMstID)
            Report.SetParameterValue(2, AccCheckListMstID)
            Report.SetParameterValue(3, Size1)
            Report.SetParameterValue(4, Size2)
            Report.SetParameterValue(5, Size3)
            Report.SetParameterValue(6, Size4)
            Report.SetParameterValue(7, Size5)
            Report.SetParameterValue(8, Size6)
            Report.SetParameterValue(9, Size7)
            Report.SetParameterValue(10, Size8)
            Report.SetParameterValue(11, Size9)
            Report.SetParameterValue(12, Size10)
            Report.SetParameterValue(13, Size11)
            Report.SetParameterValue(14, AccCheckListMstID)
            Report.SetParameterValue(15, ZSize1)
            Report.SetParameterValue(16, ZSize2)
            Report.SetParameterValue(17, ZSize3)
            Report.SetParameterValue(18, ZSize4)
            Report.SetParameterValue(19, ZSize5)
            Report.SetParameterValue(20, ZSize6)
            Report.SetParameterValue(21, ZSize7)
            Report.SetParameterValue(22, ZSize8)
            Report.SetParameterValue(23, ZSize9)
            Report.SetParameterValue(24, ZSize10)
            Report.SetParameterValue(25, ZSize11)
            Report.SetParameterValue(26, AccCheckListMstID)
            Report.SetParameterValue(27, RevisedDatee)
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

            ' ElseIf dt.Rows.Count = 0 And dttt.Rows.Count > 0 Then
        ElseIf dt.Rows.Count > 0 And dttt.Rows.Count = 0 Then
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions


            Report.Load(Server.MapPath("..\Reports/AccessoriesCheckListWithoutSizeWise.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Acc.CheckList"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, AccCheckListMstID)
            Report.SetParameterValue(1, AccCheckListMstID)
            Report.SetParameterValue(2, AccCheckListMstID)
            Report.SetParameterValue(3, ZSize1)
            Report.SetParameterValue(4, ZSize2)
            Report.SetParameterValue(5, ZSize3)
            Report.SetParameterValue(6, ZSize4)
            Report.SetParameterValue(7, ZSize5)
            Report.SetParameterValue(8, ZSize6)
            Report.SetParameterValue(9, ZSize7)
            Report.SetParameterValue(10, ZSize8)
            Report.SetParameterValue(11, ZSize9)
            Report.SetParameterValue(12, ZSize10)
            Report.SetParameterValue(13, ZSize11)
            Report.SetParameterValue(14, AccCheckListMstID)
            Report.SetParameterValue(15, RevisedDatee)
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
            'ElseIf dt.Rows.Count > 0 And dttt.Rows.Count = 0 Then
        ElseIf dt.Rows.Count = 0 And dttt.Rows.Count > 0 Then
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/AccessoriesCheckListWithoutZipper.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Acc.CheckList"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, AccCheckListMstID)
            Report.SetParameterValue(1, AccCheckListMstID)
            Report.SetParameterValue(2, AccCheckListMstID)
            Report.SetParameterValue(3, Size1)
            Report.SetParameterValue(4, Size2)
            Report.SetParameterValue(5, Size3)
            Report.SetParameterValue(6, Size4)
            Report.SetParameterValue(7, Size5)
            Report.SetParameterValue(8, Size6)
            Report.SetParameterValue(9, Size7)
            Report.SetParameterValue(10, Size8)
            Report.SetParameterValue(11, Size9)
            Report.SetParameterValue(12, Size10)
            Report.SetParameterValue(13, Size11)
            Report.SetParameterValue(14, AccCheckListMstID)
            Report.SetParameterValue(15, RevisedDatee)
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
        ElseIf dt.Rows.Count = 0 And dttt.Rows.Count = 0 Then
            For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
                System.IO.File.Delete(Uploadedfiles)
            Next
            Dim Report As New ReportDocument
            Dim Options As New ExportOptions
            Report.Load(Server.MapPath("..\Reports/AccessoriesCheckListWithoutZipperandSize.rpt"))
            Report.Refresh()
            Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
            di.Create()
            Dim FileName As String = "Acc.CheckList"
            Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
            Report.SetParameterValue(0, AccCheckListMstID)
            Report.SetParameterValue(1, AccCheckListMstID)
            Report.SetParameterValue(2, AccCheckListMstID)
            Report.SetParameterValue(3, Size1)
            Report.SetParameterValue(4, Size2)
            Report.SetParameterValue(5, Size3)
            Report.SetParameterValue(6, Size4)
            Report.SetParameterValue(7, Size5)
            Report.SetParameterValue(8, Size6)
            Report.SetParameterValue(9, Size7)
            Report.SetParameterValue(10, Size8)
            Report.SetParameterValue(11, Size9)
            Report.SetParameterValue(12, Size10)
            Report.SetParameterValue(13, Size11)
            Report.SetParameterValue(14, AccCheckListMstID)
            Report.SetParameterValue(15, RevisedDatee)
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
        End If
    End Sub
    Sub CuttingPDF(ByVal JobOrderID As Long, ByVal JoborderDetailid As Long, ByVal StyleAssortmentMasterID As Long)
        Dim Style As String
        Dim SRNo As String
        Dim CustomerName As String
        Dim CustomerOrder As String
        Dim Desc As String
        Dim FabricContent As String
        Dim Quantity As String
        Dim Color As String
        Dim Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11 As String
        Dim dtS1, dtS2, dtS3, dtS4, dtS5, dtS6, dtS7, dtS8, dtS9, dtS10, dtS11 As DataTable
        Dim dtFinal = New DataTable
        objTempCuttingPro.TruncateTable()
        With dtFinal
            .Columns.Add("TempId", GetType(Long))
            .Columns.Add("StyleAssortmentMasterID", GetType(String))
            .Columns.Add("JobOrderID", GetType(String))
            .Columns.Add("JoborderDetailid", GetType(String))
            .Columns.Add("Style", GetType(String))
            .Columns.Add("SRNo", GetType(String))
            .Columns.Add("CustomerName", GetType(String))
            .Columns.Add("CustomerOrder", GetType(String))
            .Columns.Add("Desc", GetType(String))
            .Columns.Add("FabricContent", GetType(String))
            .Columns.Add("Quantity", GetType(String))
            .Columns.Add("Color", GetType(String))
            .Columns.Add("S1", GetType(String))
            .Columns.Add("S2", GetType(String))
            .Columns.Add("S3", GetType(String))
            .Columns.Add("S4", GetType(String))
            .Columns.Add("S5", GetType(String))
            .Columns.Add("S6", GetType(String))
            .Columns.Add("S7", GetType(String))
            .Columns.Add("S8", GetType(String))
            .Columns.Add("S9", GetType(String))
            .Columns.Add("S10", GetType(String))
            .Columns.Add("S11", GetType(String))
        End With
        Dim dtMasterData As DataTable = objCuttingProMst.GetData(JobOrderID, JoborderDetailid)
        If dtMasterData.Rows.Count > 0 Then
            Style = dtMasterData.Rows(0)("Style")
            SRNo = dtMasterData.Rows(0)("SRNo")
            CustomerName = dtMasterData.Rows(0)("CustomerName")
            Desc = dtMasterData.Rows(0)("ItemDesc")
            FabricContent = dtMasterData.Rows(0)("Content")
            Quantity = dtMasterData.Rows(0)("Quantity")
            Color = dtMasterData.Rows(0)("Colorr")
            CustomerOrder = dtMasterData.Rows(0)("CustomerOrder")
        End If
        Dim dtsize As DataTable = objCuttingProMst.GetSize(JobOrderID, JoborderDetailid, StyleAssortmentMasterID)
        If dtsize.Rows.Count > 0 Then
            Size1 = dtsize.Rows(0)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(0)("CuttingProDetailID")
            dtS1 = objCuttingProMst.GetSizeQty(Size1, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 1 Then
            Size2 = dtsize.Rows(1)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(1)("CuttingProDetailID")
            dtS2 = objCuttingProMst.GetSizeQty(Size2, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 2 Then
            Size3 = dtsize.Rows(2)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(2)("CuttingProDetailID")
            dtS3 = objCuttingProMst.GetSizeQty(Size3, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 3 Then
            Size4 = dtsize.Rows(3)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(3)("CuttingProDetailID")
            dtS4 = objCuttingProMst.GetSizeQty(Size4, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 4 Then
            Size5 = dtsize.Rows(4)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(4)("CuttingProDetailID")
            dtS5 = objCuttingProMst.GetSizeQty(Size5, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 5 Then
            Size6 = dtsize.Rows(5)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(5)("CuttingProDetailID")
            dtS6 = objCuttingProMst.GetSizeQty(Size6, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 6 Then
            Size7 = dtsize.Rows(6)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(6)("CuttingProDetailID")
            dtS7 = objCuttingProMst.GetSizeQty(Size7, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 7 Then
            Size8 = dtsize.Rows(7)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(7)("CuttingProDetailID")
            dtS8 = objCuttingProMst.GetSizeQty(Size8, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 8 Then
            Size9 = dtsize.Rows(8)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(8)("CuttingProDetailID")
            dtS9 = objCuttingProMst.GetSizeQty(Size9, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 9 Then
            Size10 = dtsize.Rows(9)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(9)("CuttingProDetailID")
            dtS10 = objCuttingProMst.GetSizeQty(Size10, CuttingProDetailID)
        End If
        If dtsize.Rows.Count > 10 Then
            Size11 = dtsize.Rows(10)("Size")
            Dim CuttingProDetailID As Long = dtsize.Rows(10)("CuttingProDetailID")
            dtS11 = objCuttingProMst.GetSizeQty(Size11, CuttingProDetailID)
        End If
        Dr = dtFinal.NewRow()
        Dr("TempId") = 0
        Dr("StyleAssortmentMasterID") = StyleAssortmentMasterID
        Dr("JobOrderID") = JobOrderID
        Dr("JoborderDetailid") = JoborderDetailid
        Dr("Style") = Style
        Dr("SRNo") = SRNo
        Dr("CustomerName") = CustomerName
        Dr("CustomerOrder") = CustomerOrder
        Dr("Desc") = Desc
        Dr("FabricContent") = FabricContent
        Dr("Quantity") = Quantity
        Dr("Color") = Color
        If dtS1 IsNot Nothing Then
            Dr("S1") = Math.Round((dtS1.Rows(0)("TotalQty")), 0)
        Else
            Dr("S1") = "0"
        End If
        If dtS2 IsNot Nothing Then
            Dr("S2") = Math.Round(dtS2.Rows(0)("TotalQty"), 0)
        Else
            Dr("S2") = "0"
        End If
        If dtS3 IsNot Nothing Then
            Dr("S3") = Math.Round(dtS3.Rows(0)("TotalQty"), 0)
        Else
            Dr("S3") = "0"
        End If
        If dtS4 IsNot Nothing Then
            Dr("S4") = Math.Round(dtS4.Rows(0)("TotalQty"), 0)
        Else
            Dr("S4") = "0"
        End If
        If dtS5 IsNot Nothing Then
            Dr("S5") = Math.Round(dtS5.Rows(0)("TotalQty"), 0)
        Else
            Dr("S5") = "0"
        End If
        If dtS6 IsNot Nothing Then
            Dr("S6") = Math.Round(dtS6.Rows(0)("TotalQty"), 0)
        Else
            Dr("S6") = "0"
        End If
        If dtS7 IsNot Nothing Then
            Dr("S7") = Math.Round(dtS7.Rows(0)("TotalQty"), 0)
        Else
            Dr("S7") = "0"
        End If
        If dtS8 IsNot Nothing Then
            Dr("S8") = Math.Round(dtS8.Rows(0)("TotalQty"), 0)
        Else
            Dr("S8") = "0"
        End If
        If dtS9 IsNot Nothing Then
            Dr("S9") = Math.Round(dtS9.Rows(0)("TotalQty"), 0)
        Else
            Dr("S9") = "0"
        End If
        If dtS10 IsNot Nothing Then
            Dr("S10") = Math.Round(dtS10.Rows(0)("TotalQty"), 0)
        Else
            Dr("S10") = "0"
        End If
        If dtS11 IsNot Nothing Then
            Dr("S11") = Math.Round(dtS11.Rows(0)("TotalQty"), 0)
        Else
            Dr("S11") = "0"
        End If
        dtFinal.Rows.Add(Dr)
        For A As Integer = 0 To dtFinal.Rows.Count - 1
            With objTempCuttingPro
                .TempId = 0
                .StyleAssortmentMasterID = dtFinal.Rows(A)("StyleAssortmentMasterID")
                .JobOrderID = dtFinal.Rows(A)("JobOrderID")
                .JoborderDetailid = dtFinal.Rows(A)("JoborderDetailid")
                .Style = dtFinal.Rows(A)("Style")
                .SRNo = dtFinal.Rows(A)("SRNo")
                .CustomerName = dtFinal.Rows(A)("CustomerName")
                .CustomerOrder = dtFinal.Rows(A)("CustomerOrder")
                .Desc = dtFinal.Rows(A)("Desc")
                .FabricContent = dtFinal.Rows(A)("FabricContent")
                .Quantity = dtFinal.Rows(A)("Quantity")
                .Color = dtFinal.Rows(A)("Color")
                .S1 = dtFinal.Rows(A)("S1")
                .S2 = dtFinal.Rows(A)("S2")
                .S3 = dtFinal.Rows(A)("S3")
                .S4 = dtFinal.Rows(A)("S4")
                .S5 = dtFinal.Rows(A)("S5")
                .S6 = dtFinal.Rows(A)("S6")
                .S7 = dtFinal.Rows(A)("S7")
                .S8 = dtFinal.Rows(A)("S8")
                .S9 = dtFinal.Rows(A)("S9")
                .S10 = dtFinal.Rows(A)("S10")
                .S11 = dtFinal.Rows(A)("S11")
                .Savetemp()
            End With
        Next
        For Each Uploadedfiles As String In System.IO.Directory.GetFiles(Server.MapPath("~/TempPDF/"))
            System.IO.File.Delete(Uploadedfiles)
        Next

        Dim Report As New ReportDocument
        Dim Options As New ExportOptions






        Report.Load(Server.MapPath("..\Reports/CuttingProgram.rpt"))
        Report.Refresh()
        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/TempPDF"))
        di.Create()
        Dim FileName As String = "Cuttingprogram"
        Dim sTempFileName As String = Request.PhysicalApplicationPath + "/TempPDF/" & FileName & ".pdf"
        Report.SetParameterValue(0, Size1)
        Report.SetParameterValue(1, Size2)
        Report.SetParameterValue(2, Size3)
        Report.SetParameterValue(3, Size4)
        Report.SetParameterValue(4, Size5)
        Report.SetParameterValue(5, Size6)
        Report.SetParameterValue(6, Size7)
        Report.SetParameterValue(7, Size8)
        Report.SetParameterValue(8, Size9)
        Report.SetParameterValue(9, Size10)
        Report.SetParameterValue(10, Size11)
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
    End Sub
End Class

