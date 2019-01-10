Imports System.Data

Namespace EuroCentra
    Public Class Season
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Season"
            m_strPrimaryFieldName = "SeasonID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_SeasonID As Long
        Private m_Season As String
        Private m_bIsActive As Boolean


        Public Property SeasonID() As Long
            Get
                SeasonID = m_SeasonID
            End Get
            Set(ByVal Value As Long)
                m_SeasonID = Value
            End Set
        End Property
        Public Property Season() As String
            Get
                Season = m_Season
            End Get
            Set(ByVal value As String)
                m_Season = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property

        Public Function SaveSeason()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal SeasonDatabaseID As String)
            Dim Str As String
            Str = "select * from SeasonDatabase where SeasonDatabaseID = '" & SeasonDatabaseID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from Season  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllNew()
            Dim Str As String
            Str = "select * from SeasonDatabase  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal SeasonDatabaseID As Long)
            Dim Str As String
            Str = "  delete from SeasonDatabase where SeasonDatabaseID='" & SeasonDatabaseID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace