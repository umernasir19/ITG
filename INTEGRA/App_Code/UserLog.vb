'**************************************************************************************
'*      Class Name         :    UserLog.vb
'*      Class Description  :    Provided Business Logic related to entity "UserLog"
'*      Core Table         :    UMUserLog
'**************************************************************************************

Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 

Namespace EuroCentra

    Public Class UserLog
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "UMUserLog"
            m_strPrimaryFieldName = "UserLogId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        '*******************************************************
        '                   Memory Variables
        '*******************************************************
        ' Declare member variables
        Private m_bnUserLogId As Long
        Private m_dtLogOnDate As Date = Me.DatabaseDefaultDate
        Private m_dtLogOnTime As Date = Me.DatabaseDefaultDate
        Private m_dtLogOffDate As Date = Me.DatabaseDefaultDate
        Private m_dtLogOffTime As Date = Me.DatabaseDefaultDate
        Private m_nUserId As Integer


        '*******************************************************
        '                   Properties
        '*******************************************************

        Public Property UserLogId() As Long
            Get
                UserLogId = m_bnUserLogId
            End Get
            Set(ByVal Value As Long)
                m_bnUserLogId = Value
            End Set
        End Property

        Public Property LogOnDate() As Date
            Get
                LogOnDate = m_dtLogOnDate
            End Get
            Set(ByVal Value As Date)
                m_dtLogOnDate = Value
            End Set
        End Property

        Public Property LogOnTime() As Date
            Get
                LogOnTime = m_dtLogOnTime
            End Get
            Set(ByVal Value As Date)
                m_dtLogOnTime = Value
            End Set
        End Property

        Public Property LogOffDate() As Date
            Get
                LogOffDate = m_dtLogOffDate
            End Get
            Set(ByVal Value As Date)
                m_dtLogOffDate = Value
            End Set
        End Property

        Public Property LogOffTime() As Date
            Get
                LogOffTime = m_dtLogOffTime
            End Get
            Set(ByVal Value As Date)
                m_dtLogOffTime = Value
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

        ' Function that Save (Add / Edit) particular Record
        Public Function SaveUserLog(Optional ByVal nUserLogId As Integer = 0)

            Try
                MyBase.Save()
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try
        End Function

        Public Sub UpdatetUserLog()

            Dim strSql As String

            m_dtLogOffTime = Now
            m_dtLogOffDate = Now.Today
            strSql = "Update UMUserLog set LogOffDate = '" & m_dtLogOffDate & "', LogOffTime = '" & m_dtLogOffTime & "' where UserID = " & m_nUserId & " and LogOffDate ='" & DatabaseDefaultDate & "'"

            Try
                Me.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
            End Try

        End Sub


        '' Function that Save User log
        'Public Sub InsertUserLog()

        '    Dim StrSql As String

        '    mvarlogondate = Now.Today
        '    mvarlogontime = Now
        '    StrSql = "insert into userlog (user_code,logondate,logontime) values(" & mvaruser_code & ",'" & mvarlogondate & "', '" & mvarlogontime & "')"

        '    Try
        '        Me.ExecuteNonQuery(StrSql)
        '    Catch ex As Exception
        '        Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        '    End Try

        'End Sub

        'Public Sub UpdatetUserLog()

        '    Dim StrSql As String

        '    mvarlogofftime = Now
        '    mvarlogoffdate = Now.Today
        '    StrSql = "update userlog set logoffdate = '" & mvarlogoffdate & "', logofftime = '" & mvarlogofftime & "' where user_code = " & mvaruser_code & " and logofftime is null"

        '    Try
        '        Me.ExecuteNonQuery(StrSql)
        '    Catch ex As Exception
        '        Throw New UDException(System.Reflection.MethodBase.GetCurrentMethod(), ex)
        '    End Try

        'End Sub

    End Class


End Namespace

