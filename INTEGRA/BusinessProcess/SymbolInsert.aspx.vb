Imports Telerik.Web.UI
Imports System.Data
Imports Integra.EuroCentra
Imports System.Web.UI.WebControls
Imports System
Public Class SymbolInsert
    Inherits System.Web.UI.Page
    Dim objSymbolBleaching As New SymbolBleaching
    Dim objSymbolDegreeofColour As New SymbolDegreeofColour
    Dim objSymbolDryCleaning As New SymbolDryCleaning
    Dim objSymbolIroning As New SymbolIroning
    Dim objSymbolTumbleDry As New SymbolTumbleDry
    Dim objPurchaseMaster As New PurchaseOrder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindDegree1()
        End If
    End Sub
    Sub BindDegree1()
        Try
            Dim dt As DataTable
            dt = objPurchaseMaster.GetDegree1
           
            DropDownList1.DataSource = dt
            DropDownList1.DataTextField = "DegreeofColourname"
            DropDownList1.DataValueField = "DegreeofColourID"
            DropDownList1.DataBind()
            Dim imageURL2 As String = ""
            Dim ii As Integer = 0
            Do While (ii < DropDownList1.Items.Count)
                Select Case (DropDownList1.Items(ii).Text)
                    Case "degree1.jpg"
                        imageURL2 = "~/Images/degree1.jpg"
                    Case "degree2.jpg"
                        imageURL2 = "~/Images/degree2.jpg"
                    Case "degree3.jpg"
                        imageURL2 = "~/Images/degree3.png"
                End Select

                Dim item As ListItem = DropDownList1.Items(ii)
                item.Attributes("style") = ("background: url(" _
                            + (imageURL2 + ");background-repeat:no-repeat;"))
                ii = (ii + 1)
            Loop

        Catch ex As Exception

        End Try
    End Sub
    Function SaveUploadSymbol() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If FileUpload1.HasFile AndAlso Not FileUpload1.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = FileUpload1.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Protected Sub btnBSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBSave.Click
        Try
            With objSymbolBleaching
                .BleachingSymbolID = 0
                .BleachingSymbolname = FileUpload1.FileName
                .BleachingSymbolImage = SaveUploadSymbol()
                .SaveBSymbol()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDegreeSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDegreeSave.Click
        Try
            With objSymbolDegreeofColour
                .DegreeofColourID = 0
                .DegreeofColourname = FileUpload1.FileName
                .DegreeofColourImage = SaveUploadSymbol()
                .SaveDSymbol()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDryCSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDryCSave.Click
        Try
            With objSymbolDryCleaning
                .DryCleaningSymbolID = 0
                .DryCleaningSymbolname = FileUpload1.FileName
                .DryCleaningSymbolImage = SaveUploadSymbol()
                .SaveCSymbol()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnIroningSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIroningSave.Click
        Try
            With objSymbolIroning
                .IroningSymbolID = 0
                .IroningSymbolname = FileUpload1.FileName
                .IroningSymbolImage = SaveUploadSymbol()
                .SaveISymbol()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnTumbleDrySave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTumbleDrySave.Click
        Try
            With objSymbolTumbleDry
                .TumbleDryID = 0
                .TumbleDryname = FileUpload1.FileName
                .TumbleDryImage = SaveUploadSymbol()
                .SaveTSymbol()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class