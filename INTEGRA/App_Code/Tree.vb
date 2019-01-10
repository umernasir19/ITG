Imports Microsoft.VisualBasic

Public Class Tree
    Inherits SQLManager
    Public Function GetMembersTree(ByVal UserID As Integer, Optional ByVal memberid As String = "0")
        Dim Str As String
        'If memberid = "0" Then

        '    Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=0 and a.IsActive=1  ORDER BY a.Sequence "
        'Else
        '    Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=" & memberid & " and a.IsActive=1    ORDER BY a.Sequence "
        'End If

        If memberid = "0" Then

            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=0 and a.IsActive=1"
        Else
            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=" & memberid & " and a.IsActive=1 "
        End If

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMembersTreeNew(ByVal UserID As Integer, Optional ByVal memberid As String = "0")
        Dim Str As String

        Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & " and FormRoleId =1215) and a.ParentFormRoleId=0 and a.IsActive=1"

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetMembersTreeNewForNewUsers(ByVal UserID As Integer, Optional ByVal memberid As String = "0")
        Dim Str As String
        If memberid = "0" Then
            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRolesNew WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRolesNew a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & " ) and a.ParentFormRoleId=0 and a.IsActive=1"
        Else
            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRolesNew WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRolesNew a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=" & memberid & " and a.IsActive=1 "
        End If

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetFormThroughURLNew(ByVal FormID) As String
        Dim Str As String
        Str = "Select Link from RMFormRolesNew FR Join RMForm F on F.FormID=Fr.FormID where FormRoleId=" & FormID & " order by FR.FormRoleId "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GetFormThroughURL(ByVal FormID) As String
        Dim Str As String
        Str = "Select Link from RMFormRoles FR Join RMForm F on F.FormID=Fr.FormID where FormRoleId=" & FormID & " order by FR.FormRoleId "
        Try
            Return MyBase.GetScaler(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GetFormByRoleNew(ByVal RoleID As Long)
        Dim Str As String
        Try
            Str = "SELECT distinct  a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRolesNew WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount"
            Str &= " FROM RMForm c RIGHT OUTER JOIN RMFormRolesNew a INNER JOIN RMUserRoles b  ON a.RoleId "
            Str &= " = b.RoleId ON c.Formid = a.FormId WHERE (b.Roleid = '" & RoleID & "') and"
            Str &= " a.IsActive=1 and link!='NULL'  ORDER BY a.Sequence "
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function GetFormByRole(ByVal RoleID As Long)
        Dim Str As String
        Try
            Str = "SELECT distinct  a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount"
            Str &= " FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId "
            Str &= " = b.RoleId ON c.Formid = a.FormId WHERE (b.Roleid = '" & RoleID & "') and"
            Str &= " a.IsActive=1 and link!='NULL' and link Not like 'Report%' ORDER BY a.Sequence "
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
        'If RoleID = 1 Or RoleID = 4 Then
        '    Str = "Select * from RMFormRoles where FormID not in(0) and  RoleID='" & RoleID & "' and Isactive = 1 "
        '    Str &= " and parentFormRoleID in(Select FormRoleID from RMFormRoles where  RoleID='" & RoleID & "' "
        '    Str &= " and parentFormRoleID=11)"
        '    Str &= " Union"
        '    Str &= " Select * from RMFormRoles where FormID not in(0) and Isactive = 1 and  RoleID='" & RoleID & "'  And parentFormRoleID = 11"
        '    Str &= "  Union "
        '    Str &= " Select * from RMFormRoles where FormID not in(0) and Isactive = 1 and  RoleID='" & RoleID & "' "
        '    Str &= " and parentFormRoleID in"
        '    Str &= " (Select FormRoleID from RMFormRoles where  RoleID='" & RoleID & "' and Isactive = 1 "
        '    Str &= " and parentFormRoleID in(Select FormRoleID from RMFormRoles where  RoleID='" & RoleID & "' "
        '    Str &= " and parentFormRoleID=11)) order by sequence"
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception

        '    End Try
        'Else
        '    Str = "SELECT distinct  a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount"
        '    Str &= " FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId "
        '    Str &= " = b.RoleId ON c.Formid = a.FormId WHERE (b.Roleid = '" & RoleID & "') and"
        '    Str &= " a.IsActive=1 and link!='NULL' and link Not like 'Report%' ORDER BY a.Sequence "
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception

        '    End Try
        'End If
    End Function
    Public Function GetMembersTreeDaily(ByVal UserID As Integer, Optional ByVal memberid As String = "0")
        Dim Str As String
        If memberid = "0" Then
           
            Str = " Select distinct  MarchandID,image,usercode,username,userid,ECPDivistion,Designation from PurchaseOrder join UMUser U on UserID=MarchandID "
            Str &= " where ECPDivistion='ECP 01' order by Designation "
        Else
            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=" & memberid & " and a.IsActive=1    ORDER BY a.Sequence "
        End If
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function

    Public Function GetMembersTreeDailyECP02(ByVal UserID As Integer, Optional ByVal memberid As String = "0")
        Dim Str As String
        If memberid = "0" Then
            Str = " Select distinct  MarchandID,image,usercode,username,userid,ECPDivistion,Designation from PurchaseOrder join UMUser U on UserID=MarchandID "
            Str &= " where ECPDivistion='ECP 02' order by Designation "
        Else
            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=" & memberid & " and a.IsActive=1    ORDER BY a.Sequence "
        End If
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function

    Public Function GetMembersTreeDailyECP03(ByVal UserID As Integer, Optional ByVal memberid As String = "0")
        Dim Str As String
        If memberid = "0" Then
            Str = " Select distinct  MarchandID,image,usercode,username,userid,ECPDivistion,Designation from PurchaseOrder join UMUser U on UserID=MarchandID "
            Str &= " where ECPDivistion='ECP 03' order by Designation "
        Else
            Str = "SELECT a.*,'   '+ a.TextToDisplay as NodeName, c.link AS link,(select count(*) FROM RMFormRoles WHERE ParentFormRoleId=a.ParentFormRoleId) childnodecount  FROM RMForm c RIGHT OUTER JOIN RMFormRoles a INNER JOIN RMUserRoles b  ON a.RoleId = b.RoleId ON c.Formid = a.FormId WHERE (b.UserId =" & UserID & ") and a.ParentFormRoleId=" & memberid & " and a.IsActive=1    ORDER BY a.Sequence "
        End If
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function


    Function GetUser4lable(ByVal UserID As Long)
        Dim Str As String
        Str = "select userCode,UserName,image from umuser where userid='" & UserID & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function UpdateRMForm(ByVal FormId As Long, ByVal Link As String)
        Dim Str As String
        Str = "Update RMForm set Link='" & Link & "'  where FormId=" & FormId
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function


End Class
