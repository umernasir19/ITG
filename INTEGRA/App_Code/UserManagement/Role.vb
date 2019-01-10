'**************************************************************************************
'*      Class Name         :    Role.vb
'*      Class Description  :    Provided Business Logic related to entity "Role"
'*      Core Table         :    Role
'**************************************************************************************
Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 

Namespace EuroCentra

    Public Class Role
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "RMRole"
            m_strPrimaryFieldName = "RoleId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
        End Sub


        '*******************************************************
        '                   Memory Variables
        '*******************************************************

        Private m_sRoleId As Short
        Private m_strName As String = ""
        Private m_strDescription As String = ""
        Private m_bIsActive As Boolean
        Private m_byRoleTypeId As Byte
        Private m_sHierarchySequence As Short


        '*******************************************************
        '                   Properties
        '*******************************************************


        Public Property RoleId() As Short
            Get
                RoleId = m_sRoleId
            End Get
            Set(ByVal Value As Short)
                m_sRoleId = Value
            End Set
        End Property
        
        Public Property Name() As String
            Get
                Name = m_strName
            End Get
            Set(ByVal Value As String)
                m_strName = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal Value As String)
                m_strDescription = Value
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

        Public Property RoleTypeId() As Byte
            Get
                RoleTypeId = m_byRoleTypeId
            End Get
            Set(ByVal Value As Byte)
                m_byRoleTypeId = Value
            End Set
        End Property

        Public Property HierarchySequence() As Short
            Get
                HierarchySequence = m_sHierarchySequence
            End Get
            Set(ByVal Value As Short)
                m_sHierarchySequence = Value
            End Set
        End Property


        '*******************************************************
        '                   Functions
        '*******************************************************

        ' The function that used to get the Roles according to different criterias
        Public Function GetRoles( _
           Optional ByVal byStatusId As Byte = 2, _
           Optional ByVal sRoleId As Short = 0, _
           Optional ByVal byRoleTypeId As Byte = 0, _
           Optional ByVal strOrderByClause As String = " RMRole.IsActive,RMRole.Name" _
          ) As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder()
            Dim sbWhereClause As New StringBuilder()

            Dim objDataTable As New DataTable()

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

            ' If user provides RoleTypeId
            If byRoleTypeId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("RMRoleType.RoleTypeId= " + byRoleTypeId.ToString())
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
        Public Function SaveRole(Optional ByVal sRoleId As Short = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

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


    End Class

End Namespace