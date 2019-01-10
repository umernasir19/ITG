'**************************************************************************************
'*      Class Name         :    Form.vb
'*      Class Description  :    Provided Business Logic related to entity "Form"
'*      Core Table         :    Form
'**************************************************************************************
Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 

Namespace EuroCentra

    Public Class Form
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "RMForm"
            m_strPrimaryFieldName = "FormId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
        End Sub


        '*******************************************************
        '                   Memory Variables
        '*******************************************************

        Private m_nFormId As Integer
        Private m_strName As String = ""
        Private m_strDescription As String = ""
        Private m_strLink As String = ""


        '*******************************************************
        '                   Properties
        '*******************************************************


        Public Property FormId() As Integer
            Get
                FormId = m_nFormId
            End Get
            Set(ByVal Value As Integer)
                m_nFormId = Value
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

        Public Property Link() As String
            Get
                Link = m_strLink
            End Get
            Set(ByVal Value As String)
                m_strLink = Value
            End Set
        End Property

        '*******************************************************
        '                   Functions
        '*******************************************************

        ' The function that used to get the Forms according to different criterias
        Public Function GetForms( _
           Optional ByVal byStatusId As Byte = 2, _
           Optional ByVal nFormId As Integer = 0, _
                     Optional ByVal strOrderByClause As String = " RMForm.Name" _
          ) As DataTable

            ' Declare Local Variables
            Dim sbSQL As New StringBuilder()
            Dim sbWhereClause As New StringBuilder()

            Dim objDataTable As New DataTable()

            ' Define Initial Query
            sbSQL.Append("Select * from RMForm ")


            ' Creating Where Clause Dynamically
            ' ----------------------------------

            ' If user provides FormId
            If nFormId > 0 Then
                'Add the condition to Where Clause
                sbWhereClause.Append(IIf(sbWhereClause.Length = 0, "", " and "))
                sbWhereClause.Append("FormId= " + nFormId.ToString())
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
        Public Function SaveForm(Optional ByVal nFormId As Integer = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function

        ' Function that Get the Record through an Id
        Public Function GetFormById(ByVal nFormId As Integer)

            Try
                MyBase.GetById(nFormId)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Function

        ' Procedure that checks for the existance of record
        Public Function IsFormExists(ByVal strFormName As String) As Boolean
            Dim bRecordExists As Boolean

            Try
                bRecordExists = MyBase.IsRecordExists("Name", SQLManager.DataTypes.StringType, strFormName)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
            Return bRecordExists
        End Function

        ' Function that returns whether the Particular form is attched or not
        Public Function IsFormAttached(ByVal nFormId As Integer) As Boolean

            Dim bIsRecordExists As Boolean
            Dim strSql As String

            strSql = "select * from RMFormRoles where FormId = " & nFormId

            Try
                bIsRecordExists = MyBase.IsRecordExists(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

            Return bIsRecordExists

        End Function

        'Function that deletes a particular record
        Public Sub DeleteForm(ByVal nFormId)
            Dim strSql As String
            strSql = "Delete From RMForm where FormId = " & nFormId

            Try
                Me.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Sub

    End Class

End Namespace