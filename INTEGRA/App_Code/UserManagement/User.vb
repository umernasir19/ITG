'**************************************************************************************
'*      Class Name         :    User.vb
'*      Class Description  :    Provided Business Logic related to entity "User"
'*      Core Table         :    UMUser
'**************************************************************************************

Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 


Namespace EuroCentra

    Public Class User
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "UMUser"
            m_strPrimaryFieldName = "UserId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
        End Sub


        '*******************************************************
        '                   Memory Variables
        '*******************************************************

        Public Enum HierarchySequence
            Admin = 100
        End Enum

        Private m_nUserId As Integer
        Private m_strUserCode As String = ""
        Private m_nEmployeeId As Integer
        Private m_strPassword As String = ""
        Private m_bIsActive As Boolean
        Private m_strUserName As String
        Private m_strECPDivistion As String
        Private m_strDesignation As String
        Private m_strQuestion As String
        Private m_strAnswer As String
        Private m_strInspCode As String
        Private m_nLocationId As Integer
        Private m_nBranchCode As Integer
        Private m_nCounterID As Integer
        Private m_strimage As String
        Private m_strDepartment As String
        Private m_bViewNotification As Boolean
        Private m_bSaveNotification As Boolean
        Private m_bCancelNotification As Boolean
        '*******************************************************
        '                   Properties
        '*******************************************************
        Public Property ViewNotification() As Boolean
            Get
                ViewNotification = m_bViewNotification
            End Get
            Set(ByVal Value As Boolean)
                m_bViewNotification = Value
            End Set
        End Property
        Public Property SaveNotification() As Boolean
            Get
                SaveNotification = m_bSaveNotification
            End Get
            Set(ByVal Value As Boolean)
                m_bSaveNotification = Value
            End Set
        End Property
        Public Property CancelNotification() As Boolean
            Get
                CancelNotification = m_bCancelNotification
            End Get
            Set(ByVal Value As Boolean)
                m_bCancelNotification = Value
            End Set
        End Property
        Public Property Department() As String
            Get
                Department = m_strDepartment
            End Get
            Set(ByVal value As String)
                m_strDepartment = value
            End Set
        End Property
        Public Property LocationId() As Integer
            Get
                LocationId = m_nLocationId
            End Get
            Set(ByVal Value As Integer)
                m_nLocationId = Value
            End Set
        End Property
        Public Property BranchCode() As Integer
            Get
                BranchCode = m_nBranchCode
            End Get
            Set(ByVal Value As Integer)
                m_nBranchCode = Value
            End Set
        End Property
        Public Property CounterID() As Integer
            Get
                CounterID = m_nCounterID
            End Get
            Set(ByVal Value As Integer)
                m_nCounterID = Value
            End Set
        End Property
        Public Property image() As String
            Get
                Image = m_strimage
            End Get
            Set(ByVal Value As String)
                m_strimage = Value
            End Set
        End Property

        Public Property UserId() As Integer
            Get
                UserId = m_nUserId
            End Get
            Set(ByVal Value As Integer)
                m_nUserId = Value
            End Set
        End Property

        Public Property UserCode() As String
            Get
                UserCode = m_strUserCode
            End Get
            Set(ByVal Value As String)
                m_strUserCode = Value
            End Set
        End Property

        Public Property EmployeeId() As Integer
            Get
                EmployeeId = m_nEmployeeId
            End Get
            Set(ByVal Value As Integer)
                m_nEmployeeId = Value
            End Set
        End Property

        Public Property Password() As String
            Get
                Password = m_strPassword
            End Get
            Set(ByVal Value As String)
                m_strPassword = Value
            End Set
        End Property


        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal Value As Boolean)
                m_bIsActive = Value
            End Set
        End Property
        Public Property UserName() As String
            Get
                UserName = m_strUserName
            End Get
            Set(ByVal value As String)
                m_strUserName = value
            End Set
        End Property
        Public Property ECPDivistion() As String
            Get
                ECPDivistion = m_strECPDivistion
            End Get
            Set(ByVal value As String)
                m_strECPDivistion = value
            End Set
        End Property
        Public Property Designation() As String
            Get
                Designation = m_strDesignation
            End Get
            Set(ByVal value As String)
                m_strDesignation = value
            End Set
        End Property
        Public Property Question() As String
            Get
                Question = m_strQuestion
            End Get
            Set(ByVal value As String)
                m_strQuestion = value
            End Set
        End Property
        Public Property Answer() As String
            Get
                Answer = m_strAnswer
            End Get
            Set(ByVal value As String)
                m_strAnswer = value
            End Set
        End Property
        Public Property InspCode() As String
            Get
                InspCode = m_strInspCode
            End Get
            Set(ByVal value As String)
                m_strInspCode = value
            End Set
        End Property
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Function getPicture111New()
            Dim Str As String
            Str = " Select * From UMUser where UserId not in (271,237,238,239,240,245,246,250,251) order by  UserName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getPicture111()
            Dim Str As String
            Str = "Select * From UMUser order by  UserName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRoleID(ByVal UserID As Long) As DataTable
            Dim str As String
            str = " Select * from RMUserRoles where UserID ='" & UserID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyExist(ByVal RoleId As Long, ByVal FormRoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRolesNew where RoleID ='" & RoleId & "' and  FormRoleID='" & FormRoleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetName(ByVal UserID As Long) As DataTable
            Dim str As String
            str = " Select * from UmUser where UserID ='" & UserID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetheaderMenuNewww(ByVal FormRoleID As Long, ByVal RoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRolesNew where FormRoleID ='" & FormRoleID & "' and RoleID= '" & RoleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetheaderMenuNewwwNewfORdATA(ByVal FormRoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRoles where  FormRoleID= '" & FormRoleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetheaderMenuNewwwNewfORdATAnEW(ByVal FormRoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRoles where  FormRoleID= '" & FormRoleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetheaderMenuNewwwNew(ByVal TextToDisplay As String, ByVal RoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRolesNew where TextToDisplay ='" & TextToDisplay & "' and RoleID= '" & RoleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetheaderMenu(ByVal FormRoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRoles where FormRoleID ='" & FormRoleID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetData(ByVal FormRoleID As Long) As DataTable
            Dim str As String
            str = " Select * from RMFormRoles where FormRoleID ='" & FormRoleID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getAllData()
            Dim Str As String
            Str = " select RMR.FormRoleID as FormRoleID,RMR.RoleID as RoleID,RMR.TextToDisplay as TextToDisplay,ISNULL(RMRN.FormRoleID,0) as FormRoleNewID from RMFormRoles RMR"
            Str &= " LEFT JOIN RMFormRolesNew RMRN on RMRN.FormRoleID=RMR.FormRoleID"
            Str &= "  where RMR.RoleId =1 and RMR.FormRoleId <>1215"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteMenuNew(ByVal Id As Long)
            Dim Str As String
            Str = " Delete from RMFormRolesNew where Id=" & Id
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteMenu(ByVal FormRoleId As Long)
            Dim Str As String
            Str = " Delete from RMFormRolesNew where FormRoleId=" & FormRoleId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getAllOWEDDataNew(ByVal UserId As Long)
            Dim Str As String
            Str = " select RMR.ID,RR.UserId ,RMR.FormRoleID as FormRoleID,RMR.RoleID as RoleID,RMR.TextToDisplay as TextToDisplay,ViewStatus,DeleteStatus,AddStatus from RMFormRolesnEW RMR"
            Str &= " join RMUserRoles RR on RR.RoleId =RMR.RoleId"
            Str &= "  where RR.UserId ='" & UserId & "' and RMR.ParentFormRoleId >0 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getAllOWEDData(ByVal UserId As Long)
            Dim Str As String
            Str = " select RMR.ID,RR.UserId ,RMR.FormRoleID as FormRoleID,RMR.RoleID as RoleID,RMR.TextToDisplay as TextToDisplay from RMFormRolesnEW RMR"
            Str &= " join RMUserRoles RR on RR.RoleId =RMR.RoleId"
            Str &= "  where RR.UserId ='" & UserId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getAllDataAll()
            Dim Str As String
            Str = " select RMR.FormRoleID as FormRoleID,RMR.RoleID as RoleID,RMR.TextToDisplay as TextToDisplay from RMFormRoles RMR"
            Str &= "  where RMR.RoleId =1 and RMR.FormRoleId <>1215"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteRMFormRoleNew(ByVal RoleID As Long)
            Dim Str As String
            Str = " Delete from RMFormRolesNew  "
            Str &= " where RoleID=" & RoleID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteRMRole(ByVal RoleID As Long)
            Dim Str As String
            Str = " Delete from RMRole  "
            Str &= " where RoleID=" & RoleID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUserBy2Id(ByVal nUserId As Integer)

            Try
                MyBase.GetById(nUserId)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function

        '*******************************************************
        '                   Functions
        '*******************************************************
        Public Function GetSingleUser(ByVal nUserId As Integer) As DataRow

            Dim objDataTable As New DataTable
            Dim strsql As String
            Try

                strsql = "SELECT Designation.Name AS Designation, Role.Name AS Role,(select Role_1.Name from RMUserRoles UserRole_1,RMRole Role_1 where UMUser_1.UserId = UserRole_1.UserId and UserRole_1.RoleId = Role_1.RoleId) ReportToRole,DMCity.Name as BaseCity, UMUser_1.UserName AS toReportname, UMUser_1.UserId AS toReportNameId, Role.HierarchySequence AS Rank, Users.* FROM UMUser Users INNER JOIN UMDesignation Designation ON Users.DesignationId = Designation.DesignationId INNER JOIN DMCity ON Users.CityId = DMCity.CityId INNER JOIN RMUserRoles UserRole ON Users.UserId = UserRole.UserId INNER JOIN RMRole Role ON UserRole.RoleId = Role.RoleId LEFT OUTER JOIN  UMUser UMUser_1 ON Users.ReportToId = UMUser_1.UserId   where  Users.UserId=  " & nUserId.ToString
                objDataTable = MyBase.GetDataTable(strsql)

            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable.Rows(0)

        End Function
        Public Function DisableUser(ByVal UserID As Long) As DataTable
            Dim str As String
            str = " update  UmUser set IsActive=0 "
            str &= " where UserID ='" & UserID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        ''Function to validate User Login Information
        Public Function Validate(ByVal strUserCode As String, ByVal strPassword As String) As Boolean

            Dim objSqlDataReader As SqlDataReader
            Dim strSql As String
            Dim objEx As Exception

            strSql = "SELECT  [User].UserCode, [User].IsActive, [User].Password, UserRoles.IsActive As UserRoleStatus, Role.IsActive As RoleStatus FROM UMUser [User], RMUserRoles UserRoles, RMRole Role  WHERE  [User].UserCode = '" & strUserCode & "'  AND [User].UserId = UserRoles.UserId  AND UserRoles.RoleID = Role.RoleId"
            'Try
            objSqlDataReader = Me.GetDataReader(strSql)
            If objSqlDataReader.Read Then
                '    If mvarUserName = objSqlDataReader("username") And mvarPassword = objSqlDataReader("password") Then
                If strUserCode = objSqlDataReader("UserCode") And strPassword = objSqlDataReader("Password") Then
                    If Trim(objSqlDataReader("RoleStatus")) = True Then
                    Else
                        objEx = New Exception("You are not allowed to login because your Role Type is Currently Inactive. Please contact your System Administrator")
                        objSqlDataReader.Close()
                        Throw objEx
                    End If
                    If Trim(objSqlDataReader("UserRoleStatus")) = True Then
                    Else
                        objEx = New Exception("You are not allowed to login because your Role is Currently Inactive. Please contact your System Administrator")
                        objSqlDataReader.Close()
                        Throw objEx
                    End If
                    If objSqlDataReader("IsActive") = True Then
                    Else
                        objEx = New Exception("You are not allowed to login because your UserID is Currently Inactive. Please contact your System Administrator")
                        objSqlDataReader.Close()
                        Throw objEx
                    End If
                    Return True

                Else
                    objEx = New Exception("Invalid username or password")
                    objSqlDataReader.Close()
                    Throw objEx
                End If
            Else
                objEx = New Exception("Invalid username or password")
                objSqlDataReader.Close()
                Throw objEx
            End If
            objSqlDataReader.Close()
        End Function
        ' The function that used to get the Users according to different criterias
        Public Function GetUsers( _
           Optional ByVal byStatusId As Byte = 2, _
           Optional ByVal nUserId As Integer = 0, _
           Optional ByVal strUserCode As String = "", _
           Optional ByVal strOrderByClause As String = "Users.UserId ", _
           Optional ByVal nEmployeeId As Integer = 0 _
                     ) As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder
            Dim sbWhereClause As New StringBuilder
            Dim colQueryRecords As Collections.ArrayList
            Dim objDataTable As New DataTable

            ' Define Initial Query
            sbSQL.Append("Select * from UMUser Users ")

            ' Creating Where Clause Dynamically
            ' ----------------------------------

            ' If user provides StatusId
            If byStatusId <> StatusTypes.All Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                If byStatusId = StatusTypes.InActive Then
                    sbWhereClause.Append("Users.IsActive= 0")
                Else
                    sbWhereClause.Append("Users.IsActive= 1")
                End If

            End If

            ' If user provides UserId
            If nUserId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("Users.UserId= " + Convert.ToString(nUserId))
            End If

            ' If user provides UserId
            If strUserCode <> "" Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("Users.UserCode= '" + strUserCode + "'")
            End If


            ' Creating Order By Clause
            If Len(Trim(strOrderByClause)) <> 0 Then
                'Add the condition to Order By Clause
                strOrderByClause = " Order By " + strOrderByClause
            End If

            ' Join SQL with Where and Order By Clauses
            sbSQL.Append(IIf(sbWhereClause.Length = 0, "", " where ") + sbWhereClause.ToString + strOrderByClause)

            Try
                objDataTable = MyBase.GetDataTable(sbSQL.ToString)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        Public Function GetUnAssignedUser()
            ' Declare Local Variables
            Dim strSQL As String
            Dim sbWhereClause As New StringBuilder
            Dim objDataTable As New DataTable
            strSQL = "Select UserId, UserCode from UMUser Where UserId Not In (Select UserId from RMUserRoles) And UMUser.IsActive=1"
            Try
                objDataTable = MyBase.GetDataTable(strSQL)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        Public Function GetRoles(ByVal objUserId As Integer)
            ' Declare Local Variables
            Dim strSQL As String
            Dim sbWhereClause As New StringBuilder
            Dim objDataTable As New DataTable
            strSQL = "Select RoleId from rmuserroles ur inner join UMUser us on (ur.userid = us.userid )"
            strSQL &= "Where us.userid =  '" & objUserId & "'"
            Try
                objDataTable = MyBase.GetDataTable(strSQL)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        ' Function that Save (Add / Edit) particular Record
        Public Function SaveUser(Optional ByVal nUserId As Integer = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function
        ' Function that Get the Record through an Id
        Public Function GetUserById(ByVal nUserId As Integer)

            Try
                MyBase.GetById(nUserId)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function
        ' Function that Get the Record through an Id
        Public Function GetUserByCode(ByVal strUserCode As String)
            Dim strSql As String
            Try
                strSql = "Select Users.*, Designation.Name as DesignationName, Designation.Abbreviation as DesignationAbbreviation, Role.Name as RoleName, Department.Name as DepartmentName " & _
                        "From UMUser Users, UMDesignation Designation, UMDepartment Department, RMUserRoles UserRole, RMRole Role  " & _
                        "where Users.DesignationId = Designation.DesignationId and Users.DepartmentId = Department.DepartmentId and Users.UserId = UserRole.UserId and UserRole.RoleId = Role.RoleId and Users.UserCode= '" & strUserCode & "' " & _
                        "Order By FirstName"
                MyBase.GetById(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function
        ' Function that Get the Record through an Id
        Public Function GetUserUnderDesignation(ByVal nRank As Integer, Optional ByVal byTeamId As Byte = 0, Optional ByVal nUserId As Integer = 0, Optional ByVal strDesignationAbbreviation As String = "", Optional ByVal nGreaterSequence As Integer = 0, Optional ByVal nLesserSequence As Integer = 0)
            Dim strSql As String
            Dim objDataTable As New DataTable
            Try
                strSql = "SELECT distinct UMUser.UserId, UMUser.UserName, UMUser.UserName + '  -> ' +  UMDesignation.Abbreviation As UserFullName " & _
                        "FROM UMUser INNER JOIN RMUserRoles ON UMUser.UserId = RMUserRoles.UserId INNER JOIN " & _
                        "RMRole ON RMUserRoles.RoleId = RMRole.RoleId INNER JOIN " & _
                        "UMDesignation ON UMUser.DesignationId = UMDesignation.DesignationId INNER JOIN " & _
                        "UMUserAccount ON UMUser.UserId = UMUserAccount.UserId INNER JOIN " & _
                       "TMUserTeam ON UMUser.UserId = TMUserTeam.UserId " & _
                        "WHERE UMUserAccount.IsActive=1 and RMRole.HierarchySequence < " & nRank & " "

                If byTeamId = 0 Then
                    strSql = strSql & " and TMUserTeam.TeamId in (Select TeamId from TMUserTeam where UserId = " & nUserId & ")"
                Else
                    strSql = strSql & " AND TMUserTeam.TeamId = " & byTeamId
                End If

                If strDesignationAbbreviation = "DFM" Then
                    strSql = strSql & " AND UMUser.ReportToId = " & nUserId
                End If

                If nGreaterSequence <> 0 Then
                    strSql = strSql & " AND RMRole.HierarchySequence > " & nGreaterSequence
                End If

                If nLesserSequence <> 0 Then
                    strSql = strSql & " AND RMRole.HierarchySequence < " & nLesserSequence
                End If

                strSql = strSql & " order by UMUser.UserName"

                objDataTable = Me.GetDataTable(strSql)

            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        ' Procedure that checks for the existance of record
        Public Function IsUserCodeExists(ByVal strUserCode As String) As Boolean
            Dim bRecordExists As Boolean

            Try
                bRecordExists = MyBase.IsRecordExists("UserCode", SQLManager.DataTypes.StringType, strUserCode)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return bRecordExists
        End Function
        'Function returns the Current UserId.
        Public Function GetCurrentUserId() As Integer
            Dim nUserId As Integer

            Try
                nUserId = Convert.ToInt32(MyBase.GetCurrentId())
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return nUserId
        End Function
        'Function returns the Reportto list.
        Public Function GetReportToList(ByVal nDesignationId As Integer) As DataTable
            Dim objDataTable As New DataTable
            Dim objDataReader As SqlDataReader
            Dim strSql As String
            Dim strReportTo As String
            Dim strDesignation As String
            Try
                strSql = "Select Users.UserId, Users.UserName + ', ' + Designation.Abbreviation as Name, Designation.Abbreviation as Abbreviation " & _
                        "from UMUser Users, UMUserAccount UserAccount, UMDesignation Designation " & _
                        "Where Users.UserId = UserAccount.UserId and UserAccount.IsActive=1 and Users.DesignationId = Designation.DesignationId and Users.DesignationId IN " & _
                        "(Select DesignationId From UMDesignation Where Abbreviation=( " & _
                        "Select ReportToAbbreviation From UMDesignation Where DesignationId=" & nDesignationId & " and IsActive =1 ) )"

                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable
        End Function
        'Function that returns the Users of a particular team by designation.
        Public Function GetTeamMembers(ByVal nTeamId As Integer, ByVal strDesignationAbbreviation As String) As DataTable
            Dim strSql As String
            Dim objDataTable As DataTable

            strSql = "Select Users.UserId, Users.UserName + ', ' + Designation.Abbreviation as Name " & _
                    "From UMUser Users, UMUserAccount UserAccount, UMDesignation Designation, TMTeam Team, TMUserTeam UserTeam " & _
                    "Where Users.UserId = UserAccount.UserId And " & _
                    "UserAccount.IsActive = 1 And " & _
                    "UserTeam.TeamId = " & nTeamId & "  And " & _
                    "Team.TeamId = UserTeam.TeamId And " & _
                    "Users.UserId = UserTeam.UserId And " & _
                    "Users.DesignationId = Designation.DesignationId And " & _
                    "Designation.Abbreviation='" & strDesignationAbbreviation & "' "

            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        'Function that returns the all Users of a particular team by designation.
        Public Function GetTeamMembersbyUserId(ByVal nUserId As Integer) As DataTable
            Dim strSql As String
            Dim objDataTable As DataTable
            strSql = "Select distinct UMUser.UserId, UserName, UserName  + ' -> ' +  Abbreviation As UserFullName " & _
                     " from TMTeam, TMUserTeam, UMUser,UMUserAccount, UMDesignation " & _
                     " Where TMTeam.TeamId = TMUserTeam.TeamId and UMUserAccount.UserId =UMuser.UserId and UMUserAccount.IsActive=1  " & _
                     " and TMUserTeam.UserId = UMUser.UserId " & _
                     " and TMUserTeam.UserId <> " & nUserId & " " & _
                     " and UMUser.DesignationId= UMDesignation.DesignationId " & _
                     " and TMTeam.TeamId in (Select TeamId from TMUserTeam where UserId = " & nUserId & ")" & _
                     " Order By UMUser.UserName"

            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        'Function that returns the PSRs of a particular team by designation.
        Public Function GetTeamPSRbyUserId(ByVal nUserId As Integer, Optional ByVal nTeamId As Integer = 0) As DataTable
            Dim strSql As String
            Dim objDataTable As DataTable

            strSql = "Select UMUser.UserId, UserName As UserName,TMTeam.Name as TeamName,UserName  + ' -> ' + TMTeam.Name Search" & _
                     " from TMTeam, TMUserTeam, UMUser, UMUserAccount, UMDesignation " & _
                     " Where TMTeam.TeamId = TMUserTeam.TeamId " & _
                     " and TMUserTeam.UserId = UMUser.UserId " & _
                     " and UMUserAccount.UserId = UMUser.UserId and UMUserAccount.IsActive=1 " & _
                     " and TMUserTeam.UserId <> " & nUserId & " " & _
                     " and UMUser.DesignationId= UMDesignation.DesignationId " & _
                     " and UMDesignation.Abbreviation= 'PSR' "
            If nTeamId <> 0 Then
                strSql = strSql & " and TMTeam.TeamId = " & nTeamId
            Else
                strSql = strSql & " and TMTeam.TeamId in (Select TeamId from TMUserTeam where UserId = " & nUserId & ")"
            End If

            strSql = strSql & "  Order By UMUser.UserName"

            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        'Function that returns the all Users of a particular team by designation.
        Public Function GetPSRByBaseCity(ByVal sCityId As Short) As DataTable
            Dim strSql As String
            Dim objDataTable As DataTable

            strSql = "Select UMUser.UserId, UMUser.UserName,TMTeam.Name  as TeamName,UserName  + ' -> ' + TMTeam.Name Search" & _
                     " From UMUser, DMCity, UMDesignation, UMUserAccount,TMTeam,TMUserTeam " & _
                     " Where DMCity.CityId = UMUser.CityId " & _
                     " And UMUser.DesignationId = UMDesignation.DesignationId " & _
                     " And UMUser.UserId = UMUserAccount.UserId " & _
                     " And TMTeam.TeamId = TMUserTeam.TeamId " & _
                     " and TMUserTeam.UserId = UMUser.UserId " & _
                     " And UMUserAccount.IsActive=1 " & _
                     " And UMDesignation.Abbreviation='PSR' " & _
                     " And UMUser.UserId IN (Select UserId From UMUser Where CityId = " & sCityId & ")" & _
                     " Order By UMUser.UserName"

            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        'Function that returns Total number of user for selected Product.
        Public Function GetTotalUserofProduct(ByVal nProductId As Integer) As DataTable
            Dim strSql As String
            Dim objDataTable As DataTable

            strSql = "select count(U.UserName)as [Total Number],D.Name,D.Abbreviation " & _
                    "from UMUser U,UMDesignation D,TMTeam T,TMUserTeam UT,PMProduct P,PMTeamProducts TP " & _
                    "where(U.DesignationId = D.DesignationId) " & _
                    "and U.UserId=UT.UserId " & _
                    "and T.TeamId=UT.TeamId " & _
                    "and T.TeamId=TP.TeamId " & _
                    "and P.ProductId=" & nProductId & " " & _
                    "and P.ProductId=TP.ProductId " & _
                    "group by D.Name,D.Abbreviation"

            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        Public Function GetUnAttachedTeamMember(ByVal nTeamId As Integer, ByVal strDesignationAbbreviation As String) As DataTable
            Dim strSql As String
            Dim objDataTable As DataTable

            strSql = "Select Users.UserId, Users.UserName + ', ' + Designation.Abbreviation as Name " & _
                    "From UMUser Users, UMUserAccount UserAccount, UMDesignation Designation " & _
                    "Where Users.UserId = UserAccount.UserId And " & _
                    "UserAccount.IsActive = 1 And " & _
                    "Users.DesignationId = Designation.DesignationId And " & _
                    "Designation.Abbreviation='" & strDesignationAbbreviation & "' And " & _
                    "Users.UserId Not In ( " & _
                    "Select Users.UserId " & _
                    "From UMUser Users, UMUserAccount UserAccount, UMDesignation Designation, TMTeam Team, TMUserTeam UserTeam " & _
                    "Where Users.UserId = UserAccount.UserId And " & _
                    "UserAccount.IsActive = 1 And " & _
                    "UserTeam.TeamId = " & nTeamId & "  And " & _
                    "Team.TeamId = UserTeam.TeamId And " & _
                    "Users.UserId = UserTeam.UserId And " & _
                    "Users.DesignationId = Designation.DesignationId And " & _
                    "Designation.Abbreviation='" & strDesignationAbbreviation & "') "

            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        Public Function GetUnAttachedDFMListbyTeamId(ByVal nTeamId As Integer) As DataTable
            Dim strSql As String
            Dim objDataTable As New DataTable
            strSql = "Select distinct users.user_code, users.first_name + ' ' + IsNULL(users.middle_initial,'') + ' ' + users.last_name + ', ' + Designations.desig_abbreviation as name from users, employees, designations where users.USERNAME = employees.COMPANY_EMP_CODE AND employees.desig_id = designations.desig_id and designations.desig_abbreviation='DFM' and users.user_code NOT IN(Select users.user_code from users, employees, designations,emp_team where users.USERNAME = employees.COMPANY_EMP_CODE and users.status='Active' AND users.user_code=emp_team.user_code and emp_team.productgroupid=" & nTeamId & " and  employees.desig_id = designations.desig_id and designations.desig_abbreviation= 'DFM')"
            Try
                objDataTable = Me.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        ' Function that returns the lists of all the UnAssigned users.
        Public Function GetUnAssignedUserList() As DataTable
            Dim StrSql As String
            Dim objDataTable As New DataTable

            StrSql = "Select UserName  + ' - ' + ISNULL(UMDesignation.Abbreviation, '') AS UserName, UMUser.UserId From UMUser,UMDesignation,UMUserAccount where UMUser.DesignationId=UMDesignation.DesignationId  and UMUser.UserId = UMUserAccount.UserId and UMUser.UserId Not In (Select UserId from RMUserRoles)  and UMUserAccount.IsActive=1 ORDER BY 1 "

            Try
                objDataTable = Me.GetDataTable(StrSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        ' Function that returns the lists of all the Assigned users.
        Public Function GetAssignedUserList() As DataTable
            Dim StrSql As String
            Dim objDataTable As New DataTable

            StrSql = "Select UserName  + ' - ' + ISNULL(UMDesignation.Abbreviation, '') AS UserName, UMUser.UserId From UMUser,UMDesignation,UMUserAccount where UMUser.DesignationId=UMDesignation.DesignationId  and UMUser.UserId = UMUserAccount.UserId and UMUser.UserId  In (Select UserId from RMUserRoles)  and UMUserAccount.IsActive=1 ORDER BY 1 "

            Try
                objDataTable = Me.GetDataTable(StrSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable
        End Function
        Public Function GetTeamUsers(Optional ByVal nUserId As Integer = 0, Optional ByVal nTeamId As Integer = 0, _
         Optional ByVal nProductId As Integer = 0, Optional ByVal strOrderByClause As String = " UMUser_1.UserName,Role.Name") As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder
            Dim sbWhereClause As New StringBuilder
            Dim colQueryRecords As Collections.ArrayList
            Dim objDataTable As New DataTable

            ' Define Initial Query
            sbSQL.Append("SELECT   distinct  Designation.Name AS Designation, Role.Name AS Role, UMUser_1.UserId AS TeamMatesid, UMUser_1.UserName AS TeamMatesName, " & _
                                    "  DMCity.Name AS BaseCity  FROM         TMTeam INNER JOIN   UMUser Users INNER JOIN " & _
                                    " TMUserTeam ON Users.UserId = TMUserTeam.UserId ON TMTeam.TeamId = TMUserTeam.TeamId INNER JOIN " & _
                                    " TMUserTeam TMUserTeam_1 ON TMTeam.TeamId = TMUserTeam_1.TeamId INNER JOIN" & _
                                    " UMUser UMUser_1 ON TMUserTeam_1.UserId = UMUser_1.UserId INNER JOIN  RMRole Role INNER JOIN " & _
                                    " RMUserRoles UserRole ON Role.RoleId = UserRole.RoleId ON UMUser_1.UserId = UserRole.UserId INNER JOIN     UMDesignation Designation ON UMUser_1.DesignationId = Designation.DesignationId INNER JOIN  DMCity ON UMUser_1.CityId = DMCity.CityId INNER JOIN  UMUserAccount ON UMUser_1.userId = UMUserAccount.UserId")

            sbWhereClause.Append(" tmteam.isactive = 1 AND (UMUserAccount.IsActive = 1)  ")

            ' If user provides ProductId
            If nUserId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append(" Users.UserId= " + nUserId.ToString())
            End If

            ' If user provides ProductManagerId
            If nTeamId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append(" TMTeam.TeamId= " + nTeamId.ToString())
            End If

            ' If user provides ProductManagerId
            If nProductId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append(" PMProduct.ProductId= " + nProductId.ToString())
            End If

            ' Creating Order By Clause
            If Len(Trim(strOrderByClause)) <> 0 Then
                'Add the condition to Order By Clause
                strOrderByClause = " Order By " + strOrderByClause
            End If

            ' Join SQL with Where and Order By Clauses
            sbSQL.Append(IIf(sbWhereClause.Length = 0, "", " where ") + sbWhereClause.ToString + strOrderByClause)

            Try
                objDataTable = MyBase.GetDataTable(sbSQL.ToString)

            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        ' The function that used to get the Products according to different criterias
        Public Function GetTeamUsersforPM(Optional ByVal nUserId As Integer = 0, Optional ByVal nTeamId As Integer = 0, _
           Optional ByVal nProductId As Integer = 0, Optional ByVal strOrderByClause As String = " UMUser_1.UserName, Role.Name ", Optional ByVal nGPMId As Integer = 0) As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder
            Dim sbWhereClause As New StringBuilder
            Dim colQueryRecords As Collections.ArrayList
            Dim objDataTable As New DataTable

            ' Define Initial Query
            sbSQL.Append("SELECT DISTINCT  Designation.Abbreviation, Designation.Name AS Designation, Role.Name AS Role, UMUser_1.UserId AS TeamMatesid, UMUser_1.UserName AS TeamMatesName, DMCity.Name AS BaseCity " & _
                                    " FROM PMPMProducts INNER JOIN UMUser Users ON PMPMProducts.ProductManagerId = Users.UserId INNER JOIN " & _
                                    " PMProduct ON PMPMProducts.ProductId = PMProduct.ProductId INNER JOIN PMTeamProducts INNER JOIN " & _
                                    " TMTeam ON PMTeamProducts.TeamId = TMTeam.TeamId ON PMProduct.ProductId = PMTeamProducts.ProductId INNER JOIN " & _
                                    " TMUserTeam ON TMTeam.TeamId = TMUserTeam.TeamId INNER JOIN  RMRole Role INNER JOIN " & _
                                    " RMUserRoles UserRole ON Role.RoleId = UserRole.RoleId INNER JOIN UMUser UMUser_1 ON UserRole.UserId = UMUser_1.UserId INNER JOIN " & _
                                    "  UMDesignation Designation ON UMUser_1.DesignationId = Designation.DesignationId ON TMUserTeam.UserId = UMUser_1.UserId INNER JOIN  DMCity ON UMUser_1.CityId = DMCity.CityId  INNER JOIN  UMUserAccount ON UMUser_1.UserId = UMUserAccount.UserId")

            sbWhereClause.Append(" tmteam.isactive = 1 and umuseraccount.isactive=1 ")
            ' If user provides ProductId
            If nUserId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("Users.UserId= " + nUserId.ToString())
            End If

            ' If user provides ProductId
            If nGPMId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("Users.UserId in ( select UserId from umuser where reporttoid = " + nGPMId.ToString() + " ) ")
            End If

            ' If user provides ProductManagerId
            If nTeamId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("TMTeam.TeamId= " + nTeamId.ToString())
            End If

            ' If user provides ProductManagerId
            If nProductId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("PMProduct.ProductId= " + nProductId.ToString())
            End If

            ' Creating Order By Clause
            If Len(Trim(strOrderByClause)) <> 0 Then
                'Add the condition to Order By Clause
                strOrderByClause = " Order By " + strOrderByClause
            End If

            ' Join SQL with Where and Order By Clauses
            sbSQL.Append(IIf(sbWhereClause.Length = 0, "", " where ") + sbWhereClause.ToString + strOrderByClause)

            Try
                objDataTable = MyBase.GetDataTable(sbSQL.ToString)

            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        ' The function that used to get the Products according to different criterias
        Public Function GetUsersforUserEmployeeSearch(Optional ByVal nTeamId As Integer = 0, Optional ByVal nCityId As Integer = 0, _
           Optional ByVal strRoles As String = "", Optional ByVal strUserName As String = "", Optional ByVal strOrderByClause As String = " UMUser.UserName, RMRole.Name ") As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder
            Dim sbWhereClause As New StringBuilder
            Dim colQueryRecords As Collections.ArrayList
            Dim objDataTable As New DataTable

            ' Define Initial Query
            sbSQL.Append("SELECT  distinct UMUser.UserName, UMUser.UserId, UMUser.ReportToId, UMUser_1.UserName AS ReportToName, RMRole.Name Role, RMRole.RoleId FROM UMUser INNER JOIN RMUserRoles ON UMUser.UserId = RMUserRoles.UserId INNER JOIN RMRole ON RMUserRoles.RoleId = RMRole.RoleId INNER JOIN TMUserTeam ON UMUser.UserId = TMUserTeam.UserId INNER JOIN umuseraccount ON UMUser.UserId = umuseraccount.UserId INNER JOIN UMUser UMUser_1 ON UMUser.ReportToId = UMUser_1.UserId ")

            sbWhereClause.Append(" umuseraccount.isactive=1 ")
            ' If user provides ProductId
            If nTeamId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("TMUserTeam.TeamId= " + nTeamId.ToString())
            End If

            ' If user provides ProductManagerId
            If nCityId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("UMUser.CityId= " + nCityId.ToString())
            End If

            ' If user provides ProductManagerId
            If strRoles <> "" Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("RMRole.RoleId in ( " + strRoles + " ) ")
            End If

            If Len(strUserName) > 0 Then
                'strDocotorName
                sbWhereClause.Append(" AND (UMUser.UserName LIKE '%" & strUserName & "%')")
            End If

            ' Creating Order By Clause
            If Len(Trim(strOrderByClause)) <> 0 Then
                'Add the condition to Order By Clause
                strOrderByClause = " Order By " + strOrderByClause
            End If

            ' Join SQL with Where and Order By Clauses
            sbSQL.Append(IIf(sbWhereClause.Length = 0, "", " where ") + sbWhereClause.ToString + strOrderByClause)

            Try
                objDataTable = MyBase.GetDataTable(sbSQL.ToString)

            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        Public Function GetBindQDCombo() As DataTable
            Dim str As String
            str = "   select U.Userid, U.Username,U.ECPDivistion from Umuser U  "
            str &= "  where   U.ECPDivistion ='Quality Dept' and userid not in (72,74,75,76) "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUSerInfo(ByVal USerID) As DataTable
            Dim str As String
            str = "Select UserCode"
            str &= ",(case '" & Now.Date.Month & "' when 1 then 'Q1' "
            str &= " when 2 then 'Q1'when 3 then 'Q1'"
            str &= " when 4 then 'Q2'when 5 then 'Q2'"
            str &= " when 6 then 'Q2'when 7 then 'Q3' "
            str &= " when 8 then 'Q3'when 9 then 'Q3'"
            str &= " when 10 then 'Q4'when 11 then 'Q4'"
            str &= " when 12 then 'Q4' end )as Quarter"
            str &= " from UMUSer where USerID='" & USerID & "' and IsActive=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCurrentTime()
            Dim str As String
            str = " Select right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30) "
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2) "
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2) as CurrentTime "
            str &= "  ,(case when right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30)"
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2)"
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2)>='04:00' and"
            str &= " right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30)"
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2)"
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2)<='11:59' then"
            str &= " 'Good Morning'"
            str &= " when right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30)"
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2)"
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2)>='12:00' and"
            str &= " right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30)"
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2)"
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2)<='15:59' then"
            str &= " 'Good Afternoon'"
            str &= " when right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30)"
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2)"
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2)>='16:00' and"
            str &= " right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30)"
            str &= " ,dateadd(""hh"",10,GetDate()),109)))),2)   +':'+ right('0'+rtrim(convert(nvarchar(2)"
            str &= " ,datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,GetDate()),109)))),2)<='19:20' then"
            str &= " 'Good Evening'"
            str &= " else"
            str &= "  'Good Night' end) as Message"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUSerInfoNew(ByVal USerID) As DataTable
            Dim str As String
            str = "Select * ,(Case when Designation='Merchant' then 'BM' else Designation  end) as Designation2 "
            str &= " from UMUSer where USerID='" & USerID & "' and IsActive=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getMurchand()
            Dim Str As String
            Str = "Select UserName,U.UserID from Umuser U Join RmuserRoles UR On U.USerID=UR.USerID Where UR.userRoleID=3"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getQCInspector()
            Dim Str As String
            Str = "Select UserName,UserID from Umuser where Designation in('QD')"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getECPDivison(ByVal UserID As Long)
            Dim Str As String
            Str = "Select ECPDivistion From UMUser where UserID=" & UserID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getUserClick(ByVal UserID As Long)
            Dim Str As String
            Str = "select userName  from UMUser where userid = " & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getUserIDClick(ByVal UserID As Long)
            Dim Str As String
            Str = "select userName  from UMUser where userid = " & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getUserDivision()
            Dim Str As String
            Str = "Select Roleid,name from RMRole "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetlastRecord()
            Dim str As String
            str = "SELECT TOP 1 Userid FROM Umuser ORDER BY Userid DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSecurityQbyUserCode(ByVal UserCode As String)
            Dim str As String
            str = "select UP.Question,Up.Answer,U.Usercode from Umuser U join UserProfile UP on UP.userid=U.userid where usercode ='" & UserCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUserByCheckAnswer(ByVal UserCode As String, ByVal Answer As String)
            Dim str As String
            str = "select UP.Question,Up.Answer,U.Usercode,U.userid from Umuser U join UserProfile UP"
            str &= " on UP.userid=U.userid where usercode ='" & UserCode & "' and Up.Answer='" & Answer & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAllFields(ByVal UserCode As String)
            Dim str As String
            str = "select ECPDivistion,Designation,Question,Answer,UserName from Umuser where usercode='" & UserCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getECPDivisonByID(ByVal UserID As Long)
            Dim Str As String
            Str = "Select ECPDivistion From UMUser where UserID=" & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getALlUMUser()
            Dim Str As String
            Str = " Select UserID,UserName From UMUser where UserID!='26' and Isactive=1 order by  UserName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getALlUMUserNew()
            Dim Str As String
            Str = " Select UserID,UserName From UMUser where branchcode=1 and Isactive=1 order by  UserName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getAllECPDivision()
            Dim Str As String
            Str = " Select distinct ECPDivistion From UMUser where UserID!='26'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getAllECPDivisionNew()
            Dim Str As String
            Str = " Select distinct ECPDivistion From UMUser where  branchcode=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getPicture(ByVal UserID As Long)
            Dim Str As String
            Str = "Select * From UMUser where UserID=" & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddress(ByVal UserID As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID=" & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressMerchant(ByVal UserName As String)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserName='" & UserName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function MarchantMailAddress(ByVal Userid As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.userid=" & Userid
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressCC()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (63, 62, 24)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressCommericalInvoice()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (63,77)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressCCWeekShipment()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (63,77)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierEmail(ByVal Supplierid As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join Vender V on  EE.SupplierID=V.VenderLibraryID"
            Str &= " where EE.SupplierID=" & Supplierid
            Str &= " and EE.userid=0"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierCustomerEmail(ByVal Supplierid As Long, ByVal Customerid As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join Vender V on  EE.SupplierID=V.VenderLibraryID"
            Str &= " join Customer C on  EE.Customerid=C.Customerid"
            Str &= " where EE.SupplierID=" & Supplierid
            Str &= " and EE.Customerid=" & Customerid
            Str &= " and EE.userid=0"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUser(ByVal Supplierid As Long, ByVal Customerid As Long)
            Dim Str As String
            Str = " select Distinct PO.Marchandid,Um.UserName "
            Str &= " from PurchaseOrder po  Join Vender V on PO.SupplierID=V.VenderLibraryID "
            Str &= "    Join Customer C on C.CustomerID=PO.Customerid   "
            Str &= " join Umuser UM on UM.UserID=Po.MarchandID    "
            Str &= " where Year(PO.Shipmentdate) >= 2013 "
            Str &= " and PO.Supplierid=" & Supplierid
            Str &= " and PO.CustomerID=" & Customerid
            Str &= " and PO.POID not in (select distinct POPOID from Cargodetail)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressCCSocialCompliance()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (63)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function EmailAddressCCForRevisedShipment()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (22,63, 24)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function EmailAddressCCForRevisedShipmentt()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (22,24)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function EmailAddressCCForICR()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (77,63)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function EmailAddressCCForInspection()
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID in (22)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function EmailAddressCCForRevisedShipmentMerchant(ByRef POID As Long)
            Dim Str As String
            Str = "Select *,Convert(Varchar,PO.ShipmentDate,106) as ShipmentDatee  "
            Str &= " From EmailEngine EE "
            Str &= " join purchaseorder PO on PO.marchandid=EE.Userid"
            Str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID  "
            Str &= " Join Customer C on C.CustomerID=PO.Customerid "
            Str &= " where PO.POID=" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckUserForLeaveRequest(ByVal UserID) As DataTable
            Dim str As String
            str = " Select UserID, EmployeeID From UMUSER Where UserId = '" & UserID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierIDandMerchandID(ByVal POID As Long)
            Dim Str As String
            Str = "select SupplierID ,MarchandID  from PurchaseOrder PO "
            Str &= "  where POID =" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressSupplier(ByVal SupplierID As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where EE.Supplierid=" & SupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressMerchand(ByVal UserID As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where EE.Userid=" & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateEmailAddress(ByVal Userid As Long, ByVal SupplierID As Long, ByVal Email As String)
            Dim Str As String
            Str = "insert into EmailEngine (Userid,Supplierid,EmailAddress) values(" & Userid & "," & SupplierID & ",'" & Email & "')"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateRMUserRoles(ByVal UserId As Long)
            Dim Str As String
            Str = "insert into RMUserRoles (IsActive,UserId,RoleId) values(1," & UserId & ",25)"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetVafEmail(ByVal Userid As Long)
            Dim Str As String
            Str = "Select * From EmailEngine EE"
            Str &= " join Vender V on  EE.SupplierID=V.VenderLibraryID"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where EE.Userid=" & UserId
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getuserForPO()
            Dim Str As String
            Str = "Select Distinct Um.userid,um.username from PurchaseOrder PO Join umuser um on po.marchandID=um.userid"
            Str &= " order by um.username"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getuserForPONew(ByVal ProductPortfolioid As Long)
            Dim Str As String
            Str = " select  Distinct Um.userid,um.username from purchaseorder po  join PurchaseOrderDetail POD on POD.poid=po.poid"
            Str &= " Join umuser um on po.marchandID=um.userid"
            Str &= " join StyleProductInformation spi on spi.styleid=POD.styleid "
            Str &= "  where ProductPortfolioid = '" & ProductPortfolioid & "' order by um.username"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getuserForPONew2(ByVal ProductPortfolioid As Long, ByVal Eknumber As String)
            Dim Str As String
            Str = " select  Distinct Um.userid,um.username from purchaseorder po  join PurchaseOrderDetail POD on POD.poid=po.poid"
            Str &= " Join umuser um on po.marchandID=um.userid"
            Str &= " join StyleProductInformation spi on spi.styleid=POD.styleid "
            Str &= "  where ProductPortfolioid = '" & ProductPortfolioid & "' and po.EkNumber='" & Eknumber & "' order by um.username"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetProductPortfolioID(ByVal marchandid As Long)
            Dim Str As String
            'Str = "  select distinct ((case when pp.ProductPortfolioID=1 then"
            'Str &= " 'Hard-line' when pp.ProductPortfolioID=2 then"
            'Str &= " 'Leather Goods' when pp.ProductPortfolioID=5 then  'Home Textile' when pp.ProductPortfolioID=3 or pp.ProductPortfolioID=4   then"
            'Str &= " 'Apparel' end )) as ProductPortfolio"
            'Str &= "  from purchaseorder po"
            'Str &= " join ProductPortfolio pp on pp.ProductPortfolioID=Po.ProductPortfolioID"
            'Str &= " where Po.marchandid =" & marchandid
            'Str &= " order by ProductPortfolio asc"

            Str = " select distinct  pp.ProductPortfolioID,pp.ProductPortfolio from purchaseorder po "
            Str &= " join PurchaseOrderDetail POD on POD.poid=po.poid"
            Str &= " join StyleProductInformation spi on spi.styleid=POD.styleid"
            Str &= " join ProductPortfolio pp on pp.ProductPortfolioID=spi.ProductPortfolioID "
            Str &= " where Po.marchandid ='" & marchandid & "' order by ProductPortfolio asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetProductPortfolioNew()
            Dim Str As String
            'Str = "  select distinct ((case when pp.ProductPortfolioID=1 then"
            'Str &= " 'Hard-line' when pp.ProductPortfolioID=2 then"
            'Str &= " 'Leather Goods' when pp.ProductPortfolioID=5 then  'Home Textile' when pp.ProductPortfolioID=3 or pp.ProductPortfolioID=4   then"
            'Str &= " 'Apparel' end )) as ProductPortfolio"
            'Str &= "  from purchaseorder po"
            'Str &= " join ProductPortfolio pp on pp.ProductPortfolioID=Po.ProductPortfolioID"
            'Str &= " where Po.marchandid =" & marchandid
            'Str &= " order by ProductPortfolio asc"

            Str = " select ProductPortfolioID, ProductPortfolio from   ProductPortfolio  "
            Str &= " where ProductPortfolioID = 1 Or ProductPortfolioID = 2 Or ProductPortfolioID = 3  order by ProductPortfolio asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUSerNotification(ByVal USerID) As DataTable
            Dim str As String
            str = "Select *  "
            str &= " from UMUSer where USerID='" & USerID & "' and IsActive=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUSerMsg(ByVal USerID) As DataTable
            Dim str As String
            str = "Select *  "
            str &= " from UserMsgs where USerID='" & USerID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateUserCancelStatus(ByVal UserId As Long)
            Dim Str As String
            Str = " update umuser set CancelNotification=1 where UserId=" & UserId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateUserSaveStatus(ByVal UserId As Long)
            Dim Str As String
            Str = " update umuser set SaveNotification=1 where UserId=" & UserId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace



