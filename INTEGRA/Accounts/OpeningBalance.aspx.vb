Imports Integra.EuroCentra

Public Class OpeningBalance
    Inherits System.Web.UI.Page
    Dim objChartOfAccount As New AcntChartOfAccount
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDataGRidView()
            Dim x As Integer
            For x = 0 To GridView1.Rows.Count - 1



                'Dim DDL As Button  = (Button)Me.GridView1.Rows(x).c .Cells[0].FindControl("DropDownList1"); 



                Dim lnkEdit As Button = DirectCast(GridView1.Rows(x).Cells(6).FindControl("btnEdit"), Button)
                Dim lnkRemove As Button = DirectCast(GridView1.Rows(x).FindControl("btnDelete"), Button)
                Dim AccountCode As String = GridView1.Rows(x).Cells(1).Text
                If (objChartOfAccount.IsRecordExistInOtherTables(AccountCode)) Then
                    lnkEdit.Visible = False
                    lnkRemove.Visible = False
                Else
                    lnkEdit.Visible = True
                    lnkRemove.Visible = True
                End If
            Next

        End If




    End Sub

    Private Sub BindDataGRidView()
        GridView1.DataSource = objChartOfAccount.GetAccountsOfDetailLevel()
        GridView1.DataBind()

    End Sub



    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try

            If e.CommandName = "Select" Then

                'Determine the RowIndex of the Row whose Button was clicked.

                Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

                'Reference the GridView Row.

                Dim row As GridViewRow = GridView1.Rows(rowIndex)

                'Fetch value of Name.

                Dim credit As String = TryCast(row.FindControl("txtcredit"), TextBox).Text

                Dim debit As String = TryCast(row.FindControl("txtdebit"), TextBox).Text

                'Fetch value of Country.

                Dim Id As String = row.Cells(0).Text

                'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Name: " & name & "\nCountry: " & country + "');", True)
                objChartOfAccount.UpdateAccountOpenings(Id, debit, credit)
                BindDataGRidView()

            ElseIf e.CommandName = "Edit" Then


                'Determine the RowIndex of the Row whose Button was clicked.

                Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

                'Reference the GridView Row.

                Dim row As GridViewRow = GridView1.Rows(rowIndex)

                'Fetch value of Name.

                Dim AccountName As String = TryCast(row.FindControl("txtaccountname"), TextBox).Text


                'Fetch value of Country.
                Dim AccountCode As String = row.Cells(1).Text
                Dim Id As String = row.Cells(0).Text
                If (objChartOfAccount.IsRecordExistInOtherTables(AccountCode)) Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + "This Bank Account IS already in Use" + "');", True)
                    BindDataGRidView()
                Else
                    objChartOfAccount.UpdateAccountName(Id, AccountName.ToUpper)
                    BindDataGRidView()
                    ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + "Updated SuccessFully" + "');", True)
                End If


                'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Name: " & name & "\nCountry: " & country + "');", True


                'delete Row Command

            ElseIf e.CommandName = "Delete" Then

                'Determine the RowIndex of the Row whose Button was clicked.

                Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

                'Reference the GridView Row.

                Dim row As GridViewRow = GridView1.Rows(rowIndex)

                'Fetch value of Country.

                Dim AccountCode As String = row.Cells(1).Text
                Dim Id As String = row.Cells(0).Text
                If (objChartOfAccount.IsRecordExistInOtherTables(AccountCode)) Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + "This Bank Account IS already in Use" + "');", True)
                    BindDataGRidView()
                Else
                    objChartOfAccount.DeleteAccount(Id)
                    BindDataGRidView()
                    ClientScript.RegisterStartupScript(Me.GetType(), "myalert", "alert('" + "Deleted SuccessFully" + "');", True)
                End If
            Else


            End If

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

    End Sub
End Class