Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class DepartmetDataBase
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "IMSDepartmentDataBase"
            m_strPrimaryFieldName = "DeptDatabaseId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        '*******************************************************
        '                   Member Variables
        '*******************************************************
        Dim m_lDeptDatabaseId As Long
        Dim m_strDeptDatabaseName As String
        Dim m_strDeptAbbrivation As String
        Dim m_strDeptSectionName As String
        Dim m_bIsActive As Boolean

        '*******************************************************
        '                   Properties
        '*******************************************************
        Public Property DeptDatabaseId() As Long
            Get
                DeptDatabaseId = m_lDeptDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lDeptDatabaseId = Value
            End Set
        End Property
        Public Property DeptDatabaseName() As String
            Get
                DeptDatabaseName = m_strDeptDatabaseName
            End Get
            Set(ByVal Value As String)
                m_strDeptDatabaseName = Value

            End Set
        End Property
        Public Property DeptAbbrivation() As String
            Get
                DeptAbbrivation = m_strDeptAbbrivation
            End Get
            Set(ByVal Value As String)
                m_strDeptAbbrivation = Value

            End Set
        End Property
        Public Property DeptSectionName() As String
            Get
                DeptSectionName = m_strDeptSectionName
            End Get
            Set(ByVal Value As String)
                m_strDeptSectionName = Value

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
        Public Function SaveDeptDataBase()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDepartmentDataBase()
            Dim str As String = "Select * from IMSDepartmentDataBase"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDepartmentById(ByVal lDeptDatabaseId As Long)
            Dim Str As String
            Str = "select * from IMSDepartmentDataBase  where DeptDatabaseId=" & lDeptDatabaseId
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDepartmentDatBase(ByVal lDeptDatabaseId As Long)
            Dim Str As String
            Str = " delete from IMSDepartmentDataBase where DeptDatabaseId=" & lDeptDatabaseId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssueCodeDepartments()
            Dim Str As String
            Str = "select DeptDatabaseId ,DeptDatabaseName +'-'+DeptAbbrivation  as Name from IMSDepartmentDataBase"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckdataWithAccess(ByVal UserId As String, ByVal Link As String)
            Dim Str As String

            Str = " select * from RMFormRolesNew RM"
            Str &= " join RMUserRoles UR on UR.RoleId =RM.RoleId  "
            Str &= " join RMForm rmf on rmf.FormId =RM.FormId  "
            Str &= " where   UR.UserId = '" & UserId & "' and rmf.Link='" & Link & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExisting(ByVal DeptDatabaseName As String)
            Dim Str As String
            Str = " select * from IMSDepartmentDataBase  where   DeptDatabaseName like '" & DeptDatabaseName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingEdit(ByVal lDeptDatabaseId As Long, ByVal DeptDatabaseName As String)
            Dim Str As String
            Str = " select * from IMSDepartmentDataBase  where DeptDatabaseId <>" & lDeptDatabaseId & " and DeptDatabaseName like '" & DeptDatabaseName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace
