'**************************************************************************************
'*      Class Name         :    FormRoles.vb
'*      Class Description  :    Provided Business Logic related to entity "MenuBuilder"
'*      Core Table         :    RMFormRole
'**************************************************************************************
Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 
Namespace EuroCentra
    Public Class FormRoles
        Inherits SQLManager


        '************* Definition of Class Constructor *************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "RMFormRoles"
            m_strPrimaryFieldName = "FormRoleId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
        End Sub


        '************* Declaration of Member Variables / Member Objects *************

        ' Declare member variables
        Private m_nFormRoleId As Integer
        Private m_strTextToDisplay As String = ""
        Private m_sSequence As Short
        Private m_bIsActive As Boolean
        Private m_nParentFormRoleId As Integer
        Private m_nFormId As Integer
        Private m_sRoleId As Short


        '************* Defintition of Properties / Member Objects *************

        ' Define Properties
        ' -----------------


        Public Property FormRoleId() As Integer
            Get
                FormRoleId = m_nFormRoleId
            End Get
            Set(ByVal Value As Integer)
                m_nFormRoleId = Value
            End Set
        End Property

        Public Property TextToDisplay() As String
            Get
                TextToDisplay = m_strTextToDisplay
            End Get
            Set(ByVal Value As String)
                m_strTextToDisplay = Value
            End Set
        End Property

        Public Property Sequence() As Short
            Get
                Sequence = m_sSequence
            End Get
            Set(ByVal Value As Short)
                m_sSequence = Value
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

        Public Property ParentFormRoleId() As Integer
            Get
                ParentFormRoleId = m_nParentFormRoleId
            End Get
            Set(ByVal Value As Integer)
                m_nParentFormRoleId = Value
            End Set
        End Property

        Public Property FormId() As Integer
            Get
                FormId = m_nFormId
            End Get
            Set(ByVal Value As Integer)
                m_nFormId = Value
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

        '*******************************************************
        '                   Functions
        '*******************************************************

        ' Function that Save (Add / Edit) particular Record
        Public Function SaveFormRoles(Optional ByVal nFormRoleId As Integer = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function

        'Function that sets the sequence of a particular menu
        Public Sub SetSequence()
            Dim StrSql As String
            StrSql = "update RMFormRoles set sequence = " & Sequence & " where FormRoleId = " & FormRoleId

            Try
                MyBase.ExecuteNonQuery(StrSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Sub

        ' Function that returns the list of all the forms of a single Role        
        Public Function GetFormRoles(ByVal sRoleId As Short, Optional ByVal nParentId As Integer = 0) As DataTable
            Dim objDataTable As New DataTable()
            Dim strSql As String

            If nParentId = 0 Then
                strSql = "Select FormRoleId,TextToDisplay from RMFormRoles where RoleId = " & sRoleId & " and IsActive = 1 order by TextToDisplay"
            Else
                strSql = "Select FormRoleId, TextToDisplay + CASE IsActive when 0 then '(*)' else '' END FormName from RMFormRoles where ParentFormRoleId = " & nParentId & " and RoleId = " & sRoleId & " order by IsActive, sequence"
            End If

            Try
                objDataTable = MyBase.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable

        End Function

        'Function that returns the list of children of a particular menu
        Public Function GetMenuItemChildList(ByVal nMenuItemId As Integer, Optional ByVal sRoleId As Short = 0) As DataTable
            Dim objDataTable As New DataTable()
            Dim strSql As String

            If sRoleId = 0 Then
                strSql = "Select FormRoleId,TextToDisplay + CASE IsActive when 0 then '(*)' else '' END FormName from RMFormRoles where ParentFormRoleId = " & nMenuItemId & "  order by sequencee, IsActive"
            Else
                strSql = "Select FormRoleId,TextToDisplay + CASE IsActive when 0 then '(*)' else '' END FormName from RMFormRoles where ParentFormRoleId = " & nMenuItemId & "  and RoleId = " & sRoleId & "  order by sequence, IsActive"
            End If

            Try
                objDataTable = MyBase.GetDataTable(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return objDataTable

        End Function

        'Function that check whether a menu has child or not
        Public Function IsChildMenuExist() As Boolean
            Dim dreader As SqlDataReader
            Dim iCount As Integer
            Dim StrSql As String
            StrSql = "Select count(FormRoleId) count from RMFormRoles where ParentFormRoleId = " & FormRoleId

            Try
                dreader = MyBase.GetDataReader(StrSql)
                dreader.Read()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            iCount = dreader("count")
            dreader.Close()
            If iCount = 0 Then
                Return False
            Else
                Return True
            End If

        End Function
        ' Function that Delete (Add / Edit) particular Record
        Public Function DeleteFormRole() 'ByVal nMenuItemId As Integer)

            Dim StrSql As String

            StrSql = "Delete from RMFormRoles where FormRoleId = " & FormRoleId

            Try
                MyBase.ExecuteNonQuery(StrSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function


        ' Function that Get the Record through an Id
        Public Function GetFormRoleById(ByVal nFormRoleId As Integer)

            Try
                MyBase.GetById(nFormRoleId)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function
        Public Function GetReportsName()
            Dim Str As String
            Str = "Select FormRoleID,TexttoDisplay From RMFormRoles where ParentFormRoleID=44 and IsActive=1 order by Sequence"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace