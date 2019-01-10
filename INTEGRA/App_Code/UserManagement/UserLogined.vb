'**************************************************************************************
'*      Class Name         :    User.vb
'*      Class Description  :    Provided Business Logic related to entity "User"
'*      Core Table         :    UMUser
'**************************************************************************************

Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 


Namespace EuroCentra

    Public Class UserLogined
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "UserLogined"
            m_strPrimaryFieldName = "UserLoginId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.IntegerType
        End Sub


        '*******************************************************
        '                   Memory Variables
        '*******************************************************

        Public Enum HierarchySequence
            Admin = 100
        End Enum
        Private m_lUserLoginId As Long
        Private m_lUserID As Long
        Private m_strLoginTime As String
        Private m_dtloginedDate As Date

        '*******************************************************
        '                   Properties
        '*******************************************************
        Public Property UserLoginId() As Long
            Get
                UserLoginId = m_lUserLoginId
            End Get
            Set(ByVal value As Long)
                m_lUserLoginId = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal value As Long)
                m_lUserID = value
            End Set
        End Property
        Public Property LoginTime() As String
            Get
                LoginTime = m_strLoginTime
            End Get
            Set(ByVal value As String)
                m_strLoginTime = value
            End Set
        End Property
        Public Property loginedDate() As Date
            Get
                loginedDate = m_dtloginedDate
            End Get
            Set(ByVal value As Date)
                m_dtloginedDate = value
            End Set
        End Property
        '*******************************************************
        '                   Functions
        '*******************************************************
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
        Public Function GetLastTime(ByVal UserId As Long)
            Dim Str As String
            Str = "Select LoginTime,Convert(varchar,LoginedDate,106)as LoginedDate From 	UserLogined where UserLoginID=(Select MAx(UserLoginID) From UserLogined Where UserID=" & UserId & ")"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getMarchandNew() As DataTable
            Dim Str As String
            '  Str = " select * from UMUser where userID =245  "
            Str = " select * from UMUser where  Designation='Merchandising'  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getMarchand() As DataTable
            Dim Str As String
            Str = " select * from UMUser where Designation ='Merchant'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Sub SetUpdate()
            Dim dt, dtStyle As New DataTable
            Dim Str, ChkStr, UpdateStr As String
            Dim x, PoDetailID, CurrentSID As Integer
            Dim ObjStyle As New Style
            Str = "Select * ,((PODetailID)+1979) as NewPD From PurchaseOrderDetail POD Join Style S on POD.StyleID=S.StyleID where POID>=2010 order By POID"
            Dim objSqlConnection As New SqlConnection()
            Dim objSqlCommand As SqlCommand
            Dim objDataTable As New DataTable()
            Dim objSqlDataAdapter As SqlDataAdapter
            Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection2")
            objSqlConnection.ConnectionString = strConnection
            objSqlCommand = New SqlCommand(Str, objSqlConnection)
            objSqlDataAdapter = New SqlDataAdapter(objSqlCommand)
            objSqlDataAdapter.Fill(dt)




            Try
                ' dt = MyBase.GetDataTable(Str)
                For x = 0 To dt.Rows.Count - 1
                    ChkStr = "Select StyleID From Style  where StyleNo='" & dt.Rows(x)("StyleNo") & "' and Itemdescription='" & dt.Rows(x)("Itemdescription") & "' and Article='" & dt.Rows(x)("Article") & "' and Colorway ='" & dt.Rows(x)("Colorway") & "' and Size='" & dt.Rows(x)("Size") & "' and ItemPrice=" & dt.Rows(x)("ItemPrice") & ""
                    CurrentSID = MyBase.GetScaler(ChkStr)
                    'CurrentSID = dtStyle.Rows(x)("StyleiD")
                    PoDetailID = dt.Rows(x)("NewPD")
                    If CurrentSID = 0 Then  '---------------- Insert New Rec
                        With ObjStyle
                            .Article = dt.Rows(x)("Article")
                            .Colorway = dt.Rows(x)("Colorway")
                            .IsActive = True
                            .ItemDescription = dt.Rows(x)("Itemdescription")
                            .ItemPrice = dt.Rows(x)("ItemPrice")
                            .Size = dt.Rows(x)("Size")
                            .StyleNo = dt.Rows(x)("StyleNo")
                            .SaveStyle()
                            CurrentSID = .GetID
                            UpdateStr = "Update PurchaseOrderDetail set styleID=" & CurrentSID & "  where PODetailID =" & PoDetailID & ""
                            MyBase.ExecuteNonQuery(UpdateStr)
                        End With
                    Else '----- Else Update ID
                        UpdateStr = "Update PurchaseOrderDetail set styleID=" & CurrentSID & "  where PODetailID =" & PoDetailID & ""
                        MyBase.ExecuteNonQuery(UpdateStr)
                    End If
                Next
            Catch ex As Exception
            End Try
        End Sub
        Sub EXcute()
            Dim dt As DataTable
            Dim Str, StrSelecet As String
            StrSelecet = "Select POID,PODetailID from PurchaseOrderDetail where PODetailID>15774 "
            dt = MyBase.GetDataTable(StrSelecet)

            Dim CuttentPOID, x As Long
            For x = 0 To dt.Rows.Count - 1
                CuttentPOID = dt.Rows(x)("POID") + 516
                Str = "Update PurchaseOrderDetail Set POID=" & CuttentPOID & " where PODetailID=" & dt.Rows(x)("PODetailID") & ""
                MyBase.ExecuteNonQuery(Str)
            Next
        End Sub
        Public Function GetAllLogindUser(ByVal UserID, ByVal Department, ByVal Fromdate, ByVal ToDate)
            Dim Str As String
            Str = "Select  UM.UserName, UM.ECPDivistion,"
            Str &= "  right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30),dateadd(""hh"",10,LoginTime),109)))),2) "
            Str &= "  +':'+ right('0'+rtrim(convert(nvarchar(2),datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,LoginTime),109)))),2)"
            Str &= " as LoginTime, Convert(varchar,LoginedDate,106) as LoginedDate From UserLogined UL join UmUSer UM on UM.UserID=UL.UserID where"
            If Not UserID = "0" Then
                Str &= " UM.UserID ='" & UserID & "'"
            ElseIf Not Department = "0" Then
                Str &= "  UM.ECPDivistion='" & Department & "'"
            Else
                Str &= "  UM.UserID !='26' and UL.LoginedDate >='" & Format(CDate(Fromdate), "yyyy/MM/dd") & "' and"
                Str &= "  UL.LoginedDate<='" & Format(CDate(ToDate), "yyyy/MM/dd") & "'"
            End If
                Try
                    Return MyBase.GetDataTable(Str)
                Catch ex As Exception
                End Try
        End Function
        Public Function GetAllCurrentMonthLogindUser(ByVal UserID)
            Dim Str As String
            Dim a, b As String
            a = Now.Month.ToString() + "/" + Now.Day.ToString() + "/" + Now.Year.ToString()
            b = Now.Month.ToString() + "/01" + "/" + Now.Year.ToString()

            'Str = "Select  UM.UserName, UM.ECPDivistion,LoginTime ,Convert(varchar,LoginedDate,106)as LoginedDate ,Um.Image  From UserLogined UL"
            'Str &= " join UmUSer UM on UM.UserID=UL.UserID where UM.UserID ='" & UserID & "'"
            'Str &= " and LoginedDate >='" & b & "' and LoginedDate<='" & a & "'"

            Str = "Select  UM.UserName, UM.ECPDivistion,"
            Str &= "  right('0'+rtrim(convert(nvarchar(2),datepart(hh,convert(nvarchar(30),dateadd(""hh"",10,LoginTime),109)))),2) "
            Str &= "  +':'+ right('0'+rtrim(convert(nvarchar(2),datepart(mi,convert(nvarchar(30),dateadd(""hh"",10,LoginTime),109)))),2)"
            Str &= " as LoginTime, Convert(varchar,LoginedDate,106) as LoginedDate ,Um.Image From UserLogined UL join UmUSer UM on UM.UserID=UL.UserID where UM.UserID ='" & UserID & "'"
            Str &= " and LoginedDate >='" & b & "' and LoginedDate<='" & a & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace



