Imports System.Data
Imports Integra.EuroCentra
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class LoginedUserViewCurrentMonth
    Inherits System.Web.UI.Page
    Dim ObjUserLogined As New UserLogined
    Dim objUser As New User
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindUserName()

            lbldate.Visible = False
            lblUsername.Visible = False
            lblDepartment.Visible = False
            lblMessage.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            '  lnkPrint.Visible = False
            LabelHeading.Text = "Logined User TIME STAMP " + "( " + DateAndTime.MonthName(Now.Month) + " )"
        End If
    End Sub
    Sub BindUserName()
        Dim dtCustomer As DataTable
        dtCustomer = objUser.getALlUMUserNew
        cmbUserName.DataSource = dtCustomer
        cmbUserName.DataTextField = "UserName"
        cmbUserName.DataValueField = "UserID"
        cmbUserName.DataBind()
        'cmbUserName.Items.Insert(0, New ListItem("All User...", "0"))
    End Sub
    Protected Sub btnSreach_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSreach.Click
        Try
            Dim objDataView As DataView
            Try
                objDataView = LoadData("ALL")
                Session("objDataView") = objDataView
                BindGrid()
                ShowData()
            Catch objUDException As UDException
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindGrid()
        Try
            Dim objDataView As DataView
            objDataView = Session("objDataView")
            dgLoginedUser.DataSource = objDataView
            dgLoginedUser.DataBind()
            ' lnkPrint.Visible = True
         
        Catch ex As Exception
        End Try
    End Sub
    Function LoadData(ByVal UserName) As ICollection
        Dim objDataView As DataView
        dt = ObjUserLogined.GetAllCurrentMonthLogindUser(cmbUserName.SelectedValue)
        objDataView = New DataView(dt)
        Return objDataView
    End Function
    Sub ShowData()
        Dim DTCurrent As New DataTable
        DTCurrent = dt
        If DTCurrent.Rows.Count = Nothing Then
            Label4.Visible = True
            lblMessage.Visible = True
            lblMessage.Text = "User Not Login."

            lbldate.Visible = False
            lblUsername.Visible = False
            lblDepartment.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
        Else

            lbldate.Visible = True
            lblUsername.Visible = True
            lblDepartment.Visible = True
            lblMessage.Visible = True
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True

            lblUsername.Text = UCase(DTCurrent.Rows(0)("UserName"))
            lblDepartment.Text = UCase(DTCurrent.Rows(0)("ECPDivistion"))
            lbldate.Text = Now.Date()
            lblMessage.Text = "User Logined in Database."
            
        End If
    End Sub

End Class