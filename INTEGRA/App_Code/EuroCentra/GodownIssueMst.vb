Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class GodownIssueMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSGodownIssue"
            m_strPrimaryFieldName = "GodownIssueID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lGodownIssueID As Long
        Private m_dtCreationDate As Date
        Private m_lCreatedbyID As Long
        Private m_dtEntryDate As Date
        Private m_strSIVNo As String
        Private m_strCCNo As String
        Private m_dbTokenNo As Decimal
        Private m_strCounterNo As String
        Private m_lSeasonDatabaseID As Long
        Private m_lJobOrderID As Long
        Private m_ChallanNo As String
        Private m_Remarks As String
        Private m_strAuditorStatus As String
        Private m_lAuditorID As Long
        Public Property AuditorID() As Long
            Get
                AuditorID = m_lAuditorID
            End Get
            Set(ByVal Value As Long)
                m_lAuditorID = Value
            End Set
        End Property
        Public Property AuditorStatus() As String
            Get
                AuditorStatus = m_strAuditorStatus
            End Get
            Set(ByVal value As String)
                m_strAuditorStatus = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_Remarks
            End Get
            Set(ByVal Value As String)
                m_Remarks = Value
            End Set
        End Property

        Public Property ChallanNo() As String
            Get
                ChallanNo = m_ChallanNo
            End Get
            Set(ByVal Value As String)
                m_ChallanNo = Value
            End Set
        End Property

        Public Property SeasonDatabaseID() As Long
            Get
                SeasonDatabaseID = m_lSeasonDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseID = Value
            End Set
        End Property
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property GodownIssueID() As Long
            Get
                GodownIssueID = m_lGodownIssueID
            End Get
            Set(ByVal Value As Long)
                m_lGodownIssueID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property CreatedbyID() As Long
            Get
                CreatedbyID = m_lCreatedbyID
            End Get
            Set(ByVal Value As Long)
                m_lCreatedbyID = Value
            End Set
        End Property
        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate
            End Get
            Set(ByVal Value As Date)
                m_dtEntryDate = Value
            End Set
        End Property
        Public Property SIVNo() As String
            Get
                SIVNo = m_strSIVNo
            End Get
            Set(ByVal Value As String)
                m_strSIVNo = Value
            End Set
        End Property

        Public Property CCNo() As String
            Get
                CCNo = m_strCCNo
            End Get
            Set(ByVal Value As String)
                m_strCCNo = Value
            End Set
        End Property
        Public Property TokenNo() As Decimal
            Get
                TokenNo = m_dbTokenNo
            End Get
            Set(ByVal value As Decimal)
                m_dbTokenNo = value
            End Set
        End Property
        Public Property CounterNo() As String
            Get
                CounterNo = m_strCounterNo
            End Get
            Set(ByVal Value As String)
                m_strCounterNo = Value
            End Set
        End Property
         
        Public Function SaveIMSGodownIssue()
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
        Public Function BindLocation() As DataTable
            Dim str As String

            str = " select * from Location "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetail(ByVal IMSGodownIssueDetailId As Long)
            Dim Str As String
            Str = " Delete from IMSGodownIssueDetail where IMSGodownIssueDetailId=" & IMSGodownIssueDetailId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetIssueCode(ByVal year As Integer)
            Dim str As String
            str = " select Top 1 SIVNo from IMSGodownIssue where   year(CreationDate)='" & year & "' order By GodownIssueID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIssueCodeNew(ByVal year As Integer)
            Dim str As String
            str = " select Top 1 SIVNo from IMSGodownIssueForProcess where   year(CreationDate)='" & year & "' order By GodownIssueID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserAll() As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= "  ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserAllForProcess() As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssueForProcess IMS_SI"
            str &= " join IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUser(ByVal UserId As Long) As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " join IMSDepartmentDataBase IMS_DD on IMS_DD.DeptDatabaseId=IMS_SID.DeptDatabaseId"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE cREATEDBYID ='" & UserId & "' order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForProcess() As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssueForProcess IMS_SI"
            str &= " join IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNew() As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " ,IMS_SI.ChallanNo,IMS_SI.Remarks  "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.cREATEDBYID =241"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForAll() As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForAcc() As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.cREATEDBYID =242"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForAccGStore() As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " ,IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.cREATEDBYID =244"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForSIVNoForProcess(ByVal SIVNO As String) As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssueForProcess IMS_SI"
            str &= " join IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.SIVNO ='" & SIVNO & "' "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForSIVNoForAuditor(ByVal SIVNO As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.SIVNO ='" & SIVNO & "' and IMS_SI.AuditorStatus =0 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForSIVNo(ByVal SIVNO As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.SIVNO ='" & SIVNO & "' and IMS_SI.CREATEDBYID=241 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForSIVNoForAll(ByVal SIVNO As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.SIVNO ='" & SIVNO & "'  "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForSIVNoForAcc(ByVal SIVNO As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.SIVNO ='" & SIVNO & "' and IMS_SI.CREATEDBYID=242 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForSIVNoForGStore(ByVal SIVNO As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_SI.SIVNO ='" & SIVNO & "' and IMS_SI.CREATEDBYID=244 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForItemCodeeForAuditor(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_I.ItemCodee ='" & ItemCodee & "'  and IMS_SI.AuditorStatus =0 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForItemCodee(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_I.ItemCodee ='" & ItemCodee & "'  and IMS_SI.CREATEDBYID=241 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForItemCodeeForAll(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_I.ItemCodee ='" & ItemCodee & "'  "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForItemCodeeForAcc(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_I.ItemCodee ='" & ItemCodee & "'  and IMS_SI.CREATEDBYID=242 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForItemCodeeForAccGStore(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_I.ItemCodee ='" & ItemCodee & "'  and IMS_SI.CREATEDBYID=244 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForItemCodeeForProcess(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssueForProcess IMS_SI"
            str &= " join IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE IMS_I.ItemCodee ='" & ItemCodee & "' "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForFromLocationForall(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LF.Location ='" & Location & "' "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForFromLocationForACC(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LF.Location ='" & Location & "' and IMS_SI.CREATEDBYID=242"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForFromLocationForACCGStore(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LF.Location ='" & Location & "' and IMS_SI.CREATEDBYID=244"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForFromLocationForAuditor(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LF.Location ='" & Location & "' and IMS_SI.AuditorStatus =0"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForFromLocation(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LF.Location ='" & Location & "' and IMS_SI.CREATEDBYID=241"
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForFromLocationForProcess(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssueForProcess IMS_SI"
            str &= " join IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LF.Location ='" & Location & "' "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForToLocationForProcess(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssueForProcess IMS_SI"
            str &= " join IMSGodownIssueDetailForProcess IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LT.Location ='" & Location & "' "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForToLocationForAuditor(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LT.Location ='" & Location & "' and IMS_SI.AuditorStatus =0 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForToLocation(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LT.Location ='" & Location & "' and IMS_SI.CREATEDBYID=241 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForToLocationForAll(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LT.Location ='" & Location & "' "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForToLocationForAcc(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LT.Location ='" & Location & "' and IMS_SI.CREATEDBYID=242 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserNewForToLocationForAccGstore(ByVal Location As String) As DataTable
            Dim str As String
            str = "  select IMS_SI.AuditorStatus,LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " , IMS_SI.ChallanNo,IMS_SI.Remarks "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE LT.Location ='" & Location & "' and IMS_SI.CREATEDBYID=244 "
            str &= "  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllDataNewWithUserForSearch(ByVal UserId As Long, ByVal txtSearchText As String) As DataTable
            Dim str As String
            str = "  select LT.LOCATION AS TOLocation,LF.Location as Fromlocation,*,Convert(Varchar,IMS_SI.EntryDate,103) as EntryDatee  "
            str &= " from IMSGodownIssue IMS_SI"
            str &= " join IMSGodownIssueDetail IMS_SID on IMS_SID.GodownIssueID=IMS_SI.GodownIssueID "
            str &= " join IMSItem IMS_I on IMS_I.IMSItemID=IMS_SID.IMSItemID"
            str &= " join IMSDepartmentDataBase IMS_DD on IMS_DD.DeptDatabaseId=IMS_SID.DeptDatabaseId"
            str &= " JOIN LOCATION LT ON LT.LOCATIONID=IMS_SID.ToLocationID JOIN LOCATION LF ON LF.LOCATIONID=IMS_SID.FromLocationID"
            str &= "  WHERE cREATEDBYID ='" & UserId & "' and IMS_I.ItemName = '" & txtSearchText & "'  order by IMS_SI.GodownIssueID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetDataForBeforeDelete(ByVal GodownIssueID As Long) As DataTable
            Dim str As String
            str = "  select * from IMSGodownIssue Mst"
            str &= "  join IMSGodownIssueDetail Dtl on Dtl.GodownIssueID=Mst.GodownIssueID"
            str &= "  WHERE Mst.GodownIssueID ='" & GodownIssueID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteFromDodownMAster(ByVal GodownIssueID As Long)
            Dim Str As String
            Str = " Delete from IMSGodownIssue where GodownIssueID=" & GodownIssueID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteFromDodownMAsterForProcess(ByVal GodownIssueID As Long)
            Dim Str As String
            Str = " Delete from IMSGodownIssueForProcess where GodownIssueID=" & GodownIssueID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteFromDodownDetail(ByVal GodownIssueID As Long)
            Dim Str As String
            Str = " Delete from IMSGodownIssueDetail where GodownIssueID=" & GodownIssueID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteFromDodownDetailForProcess(ByVal GodownIssueID As Long)
            Dim Str As String
            Str = " Delete from IMSGodownIssueDetailForProcess where GodownIssueID=" & GodownIssueID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
