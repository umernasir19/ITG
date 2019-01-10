Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class SeasonDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SeasonDatabase"
            m_strPrimaryFieldName = "SeasonDatabaseID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSeasonDatabaseID As Long
        Private m_dtCreationDate As Date
        Private m_lUmuserID As Long
        Private m_strYear As String
        Private m_strSeasonName As String
        Public Property SeasonDatabaseID() As Long
            Get
                SeasonDatabaseID = m_lSeasonDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseID = Value
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
        Public Property UmuserID() As Long
            Get
                UmuserID = m_lUmuserID
            End Get
            Set(ByVal Value As Long)
                m_lUmuserID = Value
            End Set
        End Property
        Public Property Year() As String
            Get
                Year = m_strYear
            End Get
            Set(ByVal Value As String)
                m_strYear = Value
            End Set
        End Property
        Public Property SeasonName() As String
            Get
                SeasonName = m_strSeasonName
            End Get
            Set(ByVal Value As String)
                m_strSeasonName = Value
            End Set
        End Property
        Public Function saveSeasonDatabase()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetSeasonDatabaseID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllSeasonForStyleMaste() As DataTable
            Dim str As String
            str = " select SeasonDatabaseID,(SeasonName+ ' ' + Year) as SeasonName  from SeasonDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonDatabaseView() As DataTable
            Dim str As String
            str = "   Select S.*,U.UserName,convert(varchar,S.CreationDate,103) as CreationDatee from SeasonDatabase S "
            str &= " join umuser U on u.userid=S.UmuserID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonDataBaseForEdit(ByVal lSeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = "   Select *  from SeasonDatabase S "
            str &= " join umuser U on u.userid=S.UmuserID  where SeasonDatabaseID=" & lSeasonDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteSeason(ByVal lSeasonDatabaseID As Long)
            Dim Str As String
            Str = " Delete from SeasonDatabase where SeasonDatabaseID=" & lSeasonDatabaseID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace


