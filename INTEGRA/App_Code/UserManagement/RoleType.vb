
'**************************************************************************************
'*      Class Name         :    RoleType.vb
'*      Class Description  :    Provided Business Logic related to entity "RoleType"
'*      Core Table         :    UMRoleType
'**************************************************************************************

Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 


Namespace EuroCentra

    Public Class RoleType
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "RMRoleType"
            m_strPrimaryFieldName = "RoleTypeId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub


        '*******************************************************
        '                   Memory Variables
        '*******************************************************

        Private m_byRoleTypeId As Byte
        Private m_strDescription As String = ""
        Private m_bIsActive As Boolean

        '*******************************************************
        '                   Properties
        '*******************************************************


        Public Property RoleTypeId() As Byte
            Get
                RoleTypeId = m_byRoleTypeId
            End Get
            Set(ByVal Value As Byte)
                m_byRoleTypeId = Value
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


        '*******************************************************
        '                   Functions
        '*******************************************************




        ' The function that used to get the RoleTypes according to different criterias


        Public Function GetRoleTypes( _
           Optional ByVal byStatusId As Byte = 2, _
           Optional ByVal byRoleTypeId As Byte = 0, _
           Optional ByVal strDescription As String = "", _
           Optional ByVal strOrderByClause As String = "RoleTypes.RoleTypeId " _
                                ) As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder
            Dim sbWhereClause As New StringBuilder

            Dim objDataTable As New DataTable

            ' Define Initial Query
            sbSQL.Append("Select * from RMRoleType RoleTypes")

            ' Creating Where Clause Dynamically
            ' ----------------------------------

            ' If RoleType provides StatusId
            If byStatusId <> StatusTypes.All Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                If byStatusId = StatusTypes.InActive Then
                    sbWhereClause.Append("RoleTypes.IsActive= 0")
                Else
                    sbWhereClause.Append("RoleTypes.IsActive= 1")
                End If

            End If

            ' If RoleType provides RoleTypeId
            If byRoleTypeId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("RoleTypes.RoleTypeId= " + Convert.ToString(byRoleTypeId))
            End If

            ' If RoleType provides RoleTypeId
            If strDescription <> "" Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("RoleTypes.Description= '" + strDescription + "'")
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
        Public Function SaveRoleType(Optional ByVal byRoleTypeId As Byte = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function

        ' Function that Get the Record through an Id
        Public Function GetRoleTypeById(ByVal byRoleTypeId As Byte)

            Try
                MyBase.GetById(byRoleTypeId)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function
        ' Procedure that checks for the existance of record
        Public Function IsRoleTypeExists(ByVal strDescription As String) As Boolean
            Dim bRecordExists As Boolean

            Try
                bRecordExists = MyBase.IsRecordExists("Description", SQLManager.DataTypes.StringType, strDescription)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return bRecordExists
        End Function

    End Class

End Namespace








