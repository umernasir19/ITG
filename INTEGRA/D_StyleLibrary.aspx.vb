Imports System.Data
Imports Integra.EuroCentra
Imports System.Data.DataTable
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class D_StyleLibrary
    Inherits System.Web.UI.Page
    Dim objD_Style As New D_Style
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            With objD_Style
                ''Fornt Side Image
                If (Directory.Exists(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/"))) Then
                    If fpFornt.FileName = "" Then
                        .URL_Fornt = ""
                        .Thumbnail_Fornt = ""
                        .Thumbnail_Fornt_List = ""
                    Else
                        ' fpFornt.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))

                        fpFornt.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpFornt.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpFornt.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt_Thumbnail/" & fpFornt.FileName))

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt_List_Thumbnail/" & fpFornt.FileName))

                        .URL_Fornt = "Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName
                        .Thumbnail_Fornt = "Deversa/" & txtStyle.Text & "/Fornt_Thumbnail/" & fpFornt.FileName
                        .Thumbnail_Fornt_List = "Deversa/" & txtStyle.Text & "/Fornt_List_Thumbnail/" & fpFornt.FileName
                    End If
                Else
                    If fpFornt.FileName = "" Then
                        .URL_Fornt = ""
                        .Thumbnail_Fornt = ""
                        .Thumbnail_Fornt_List = ""
                    Else
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt"))
                        di.Create()

                        'fpFornt.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))

                        fpFornt.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpFornt.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpFornt.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))

                        Dim dii As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt_Thumbnail"))
                        dii.Create()

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt_Thumbnail/" & fpFornt.FileName))

                        Dim dii3 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt_List_Thumbnail"))
                        dii3.Create()

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Fornt_List_Thumbnail/" & fpFornt.FileName))

                        .URL_Fornt = "Deversa/" & txtStyle.Text & "/Fornt/" & fpFornt.FileName
                        .Thumbnail_Fornt = "Deversa/" & txtStyle.Text & "/Fornt_Thumbnail/" & fpFornt.FileName
                        .Thumbnail_Fornt_List = "Deversa/" & txtStyle.Text & "/Fornt_List_Thumbnail/" & fpFornt.FileName
                    End If
                End If

                ''  ''Back Side Image
                If (Directory.Exists(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/"))) Then
                    If fpBack.FileName = "" Then
                        .URL_Back = ""
                        .Thumbnail_Back = ""
                        .Thumbnail_Back_List = ""
                    Else
                        '  fpBack.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))
                        fpBack.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpBack.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpBack.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back_Thumbnail/" & fpBack.FileName))

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back_List_Thumbnail/" & fpBack.FileName))

                        .URL_Back = "Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName
                        .Thumbnail_Back = "Deversa/" & txtStyle.Text & "/Back_Thumbnail/" & fpBack.FileName
                        .Thumbnail_Back_List = "Deversa/" & txtStyle.Text & "/Back_List_Thumbnail/" & fpBack.FileName
                    End If
                Else
                    If fpBack.FileName = "" Then
                        .URL_Back = ""
                        .Thumbnail_Back = ""
                        .Thumbnail_Back_List = ""
                    Else
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/"))
                        di.Create()
                        '  fpBack.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))
                        fpBack.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpBack.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpBack.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))

                        Dim dii As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back_Thumbnail"))
                        dii.Create()

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back_Thumbnail/" & fpBack.FileName))

                        Dim dii3 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back_List_Thumbnail"))
                        dii3.Create()

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Back_List_Thumbnail/" & fpBack.FileName))

                        .URL_Back = "Deversa/" & txtStyle.Text & "/Back/" & fpBack.FileName
                        .Thumbnail_Back = "Deversa/" & txtStyle.Text & "/Back_Thumbnail/" & fpBack.FileName
                        .Thumbnail_Back_List = "Deversa/" & txtStyle.Text & "/Back_List_Thumbnail/" & fpBack.FileName
                    End If
                End If

                ''  ''Left Side Image
                If (Directory.Exists(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/"))) Then
                    If fpLeft.FileName = "" Then
                        .URL_Left = ""
                        .Thumbnail_Left = ""
                        .Thumbnail_Left_List = ""
                    Else
                        ' fpLeft.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))
                        fpLeft.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpLeft.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpLeft.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left_Thumbnail/" & fpLeft.FileName))

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left_List_Thumbnail/" & fpLeft.FileName))

                        .URL_Left = "Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName
                        .Thumbnail_Left = "Deversa/" & txtStyle.Text & "/Left_Thumbnail/" & fpLeft.FileName
                        .Thumbnail_Left_List = "Deversa/" & txtStyle.Text & "/Left_List_Thumbnail/" & fpLeft.FileName
                    End If
                Else
                    If fpLeft.FileName = "" Then
                        .URL_Left = ""
                        .Thumbnail_Left = ""
                        .Thumbnail_Left_List = ""
                    Else
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/"))
                        di.Create()
                        'fpLeft.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))
                        fpLeft.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpLeft.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpLeft.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))

                        Dim dii As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left_Thumbnail"))
                        dii.Create()

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left_Thumbnail/" & fpLeft.FileName))

                        Dim dii3 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left_List_Thumbnail"))
                        dii3.Create()

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Left_List_Thumbnail/" & fpLeft.FileName))

                        .URL_Left = "Deversa/" & txtStyle.Text & "/Left/" & fpLeft.FileName
                        .Thumbnail_Left = "Deversa/" & txtStyle.Text & "/Left_Thumbnail/" & fpLeft.FileName
                        .Thumbnail_Left_List = "Deversa/" & txtStyle.Text & "/Left_List_Thumbnail/" & fpLeft.FileName
                    End If
                End If

                ''  ''Right Side Image
                If (Directory.Exists(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/"))) Then
                    If fpRight.FileName = "" Then
                        .URL_Right = ""
                        .Thumbnail_Right = ""
                        .Thumbnail_Right_List = ""
                    Else
                        ' fpRight.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))
                        fpRight.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpRight.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpRight.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right_Thumbnail/" & fpRight.FileName))

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right_List_Thumbnail/" & fpRight.FileName))

                        .URL_Right = "Deversa/" & txtStyle.Text & "/Left/" & fpRight.FileName
                        .Thumbnail_Right = "Deversa/" & txtStyle.Text & "/Right_Thumbnail/" & fpRight.FileName
                        .Thumbnail_Right_List = "Deversa/" & txtStyle.Text & "/Right_List_Thumbnail/" & fpRight.FileName
                    End If
                Else
                    If fpRight.FileName = "" Then
                        .URL_Right = ""
                        .Thumbnail_Right = ""
                        .Thumbnail_Right_List = ""
                    Else
                        Dim di As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/"))
                        di.Create()
                        ' fpRight.SaveAs(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))
                        fpRight.SaveAs(Server.MapPath("~/ExtraImagesDeversa/" & fpRight.FileName))
                        Dim img2 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/ExtraImagesDeversa/" & fpRight.FileName))
                        Dim bmp2 As System.Drawing.Image = img2.GetThumbnailImage(370, 360, Nothing, IntPtr.Zero)
                        bmp2.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))

                        Dim dii As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right_Thumbnail"))
                        dii.Create()

                        Dim img1 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))
                        Dim bmp1 As System.Drawing.Image = img1.GetThumbnailImage(85, 83, Nothing, IntPtr.Zero)
                        bmp1.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right_Thumbnail/" & fpRight.FileName))

                        Dim dii3 As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right_List_Thumbnail"))
                        dii3.Create()

                        Dim img3 As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName))
                        Dim bmp3 As System.Drawing.Image = img3.GetThumbnailImage(180, 175, Nothing, IntPtr.Zero)
                        bmp3.Save(Server.MapPath("~/Deversa/" & txtStyle.Text & "/Right_List_Thumbnail/" & fpRight.FileName))

                        .URL_Right = "Deversa/" & txtStyle.Text & "/Right/" & fpRight.FileName
                        .Thumbnail_Right = "Deversa/" & txtStyle.Text & "/Right_Thumbnail/" & fpRight.FileName
                        .Thumbnail_Right_List = "Deversa/" & txtStyle.Text & "/Right_List_Thumbnail/" & fpRight.FileName
                    End If
                End If

                .DstyleID = 0
                .CreationDate = Date.Now()
                .Style = txtStyle.Text
                .Category = cmbCategory.SelectedItem.Text
                .Description = txtDescription.Text
                .Image_Fornt = SaveImginByteFornt()
                .Image_Back = SaveImginByteBack()
                .Image_Left = SaveImginByteLeft()
                .Image_Right = SaveImginByteRight()
                .Material = txtMaterial.Text
                .Price = txtPrice.Text
                .CurrencyID = 46 'Dollar
                .MOQ = txtMOQ.Text
                .SaveD_Style()
            End With

            lblmsg.Text = "Saved."
        Catch ex As Exception

        End Try
    End Sub
    Function SaveImginByteFornt() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If fpFornt.HasFile AndAlso Not fpFornt.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = fpFornt.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Function SaveImginByteBack() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If fpBack.HasFile AndAlso Not fpBack.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = fpBack.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Function SaveImginByteLeft() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If fpLeft.HasFile AndAlso Not fpLeft.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = fpLeft.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function
    Function SaveImginByteRight() As Object
        Try
            Dim imgByte As Byte() = Nothing
            If fpRight.HasFile AndAlso Not fpRight.PostedFile Is Nothing Then
                'To create a PostedFile
                Dim File As HttpPostedFile = fpRight.PostedFile
                'Create byte Array with file len
                imgByte = New Byte(File.ContentLength - 1) {}
                'force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength)
            End If
            Return imgByte
        Catch ex As Exception
        End Try
    End Function

End Class