'**************************************************************************************
'*      Class Name         :    Role.vb
'*      Class Description  :    Provided Business Logic related to entity "Role"
'*      Core Table         :    Role
'**************************************************************************************
Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 

Namespace EuroCentra

    Public Class UserRoles
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "RMUserRoles"
            m_strPrimaryFieldName = "UserRoleId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
        End Sub


        '*******************************************************
        '                   Memory Variables
        '*******************************************************

        Private m_nUserRoleId As Integer
        Private m_bIsActive As Boolean
        Private m_nUserId As Integer
        Private m_sRoleId As Short

        '*******************************************************
        '                   Properties
        '*******************************************************

        Public Property UserRoleId() As Integer
            Get
                UserRoleId = m_nUserRoleId
            End Get
            Set(ByVal Value As Integer)
                m_nUserRoleId = Value
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

        Public Property RoleId() As Short
            Get
                RoleId = m_sRoleId
            End Get
            Set(ByVal Value As Short)
                m_sRoleId = Value
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





        '*******************************************************
        '                   Functions
        '*******************************************************

        ' The function that used to get the Roles according to different criterias
        Public Function GetUserRoles( _
           Optional ByVal byStatusId As Byte = 2, _
           Optional ByVal sRoleId As Short = 0, _
           Optional ByVal nUserId As Integer = 0, _
           Optional ByVal strOrderByClause As String = " RMUserRole.IsActive" _
          ) As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder
            Dim sbWhereClause As New StringBuilder

            Dim objDataTable As New DataTable

            ' Define Initial Query
            'sbSQL.Append("Select UMRole.*,UMCompany.Name As CompanyName From UMRole,UMCompany")
            sbSQL.Append("Select RMRole.*,  RMRoleType.Description As RoleTypeDescription from RMRole,RMRoleType ")


            ' Creating Where Clause Dynamically
            ' ----------------------------------

            sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
            sbWhereClause.Append("RMRole.RoleTypeId=RMRoleType.RoleTypeId")

            ' If user provides StatusId
            If byStatusId <> StatusTypes.All Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                If byStatusId = StatusTypes.InActive Then
                    sbWhereClause.Append("RMRole.IsActive= 0")
                Else
                    sbWhereClause.Append("RMRole.IsActive= 1")
                End If

            End If

            ' If user provides RoleId
            If sRoleId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("RoleId= " + sRoleId.ToString())
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

        ' Function that Save (Add / Edit) particular Record
        Public Function SaveUserRole(Optional ByVal nUserRoleId As Short = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function

        ' Function that Get the Record through an Id
        Public Function GetRoleById(ByVal sRoleId As Short)

            Try
                MyBase.GetById(sRoleId)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function

        ' Procedure that checks for the existance of record
        Public Function IsRoleExists(ByVal strRoleName As String) As Boolean
            Dim bRecordExists As Boolean

            Try
                bRecordExists = MyBase.IsRecordExists("Name", SQLManager.DataTypes.StringType, strRoleName)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return bRecordExists
        End Function


        'Function returns the list of Sales designations.
        Public Function GetUnderSalesRoles(ByVal nRank As Integer) As DataTable
            Dim objDataTable As DataTable = New DataTable("ProductItem")
            Dim strSql As String

            strSql = "select distinct umdesignation.Abbreviation,HierarchySequence from rmrole,umdesignation where " & _
            "rmrole.Name = umdesignation.Abbreviation And HierarchySequence >= 10 and HierarchySequence <= 40 And " & _
            "hierarchySequence<=" & nRank & " order by HierarchySequence"

            Try
                objDataTable = MyBase.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return objDataTable

        End Function
        Public Function GetImfomation() As DataTable
            Dim strSql As String
            strSql = "select U.UserID as UserIDs,r.description,U.UserCode as UserID,U.Password from RMRole r,UmUser U,RMUserRoles Ur where Ur.RoleID = r.RoleID And Ur.UserID = U.UserID"
            Try
                Return MyBase.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function
        Public Function GetInfo(ByVal UserID As Long) As DataTable
            Dim strSql As String
            strSql = "select UserCode,password from UmUser U where UserID=" & UserID

            Try
                Return MyBase.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function
        Public Function Update(ByVal UserID As Long, ByVal UserCode As String, ByVal Password As String) As DataTable
            Dim strSql As String
            strSql = "Update UmUser set UserCode='" & UserCode & "',password='" & Password & "' where UserID=" & UserID

            Try
                MyBase.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function
        Function GetReportsNameByRole(ByVal RoleID)
            Dim Str As String
            Str = "Select TexttoDisplay as ReportName from RMFormRoles where IsActive=1 and"
            Str &= " ParentFormRoleID =(Select FormRoleID from RMFormRoles where TexttoDisPlay='Reports' and RoleID=" & RoleID & ") Order by Sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace