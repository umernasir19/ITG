Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Namespace EuroCentra
    Public Class tblStyleSealerApproval
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleSealerApproval"
            m_strPrimaryFieldName = "StyleSealerAppID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lStyleSealerAppID As Long
        Private m_lStyleID As Long
        Private m_strStyleNo As String
        Private m_lSeasonID As Long
        Private m_strSeason As String
        Private m_dtSealerApprovalDate As Date
        Public Property StyleSealerAppID() As Long
            Get
                StyleSealerAppID = m_lStyleSealerAppID
            End Get
            Set(ByVal value As Long)
                m_lStyleSealerAppID = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Property SeasonID() As Long
            Get
                SeasonID = m_lSeasonID
            End Get
            Set(ByVal value As Long)
                m_lSeasonID = value
            End Set
        End Property
        Public Property Season() As String
            Get
                Season = m_strSeason
            End Get
            Set(ByVal value As String)
                m_strSeason = value
            End Set
        End Property
        Public Property SealerApprovalDate() As Date
            Get
                SealerApprovalDate = m_dtSealerApprovalDate
            End Get
            Set(ByVal value As Date)
                m_dtSealerApprovalDate = value
            End Set
        End Property
        Public Function SaveStyleSealerApproval()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function Delete(ByVal Id As Long)
            Dim str As String
            str = " delete from StyleSealerApproval where StyleSealerAppID='" & Id & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getData(ByVal id As Long, ByVal styleno As String)
            Dim str As String
            str = " Select * from StyleSealerApproval where StyleID='" & id & "' and StyleNo='" & styleno & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

