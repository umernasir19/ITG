Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_PrimaryContact
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_PrimaryContact"
            m_strPrimaryFieldName = "VAF_PrimaryContactID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_PrimaryContactID As Long
        Private m_lVAFID As Long
        Private m_strDesignation As String
        Private m_strName As String
        Private m_strPhone As String
        Private m_strCell As String
        Private m_strEmail As String
        Public Property VAF_PrimaryContactID() As Long
            Get
                VAF_PrimaryContactID = m_lVAF_PrimaryContactID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_PrimaryContactID = Value
            End Set
        End Property
        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property Designation() As String
            Get
                Designation = m_strDesignation
            End Get
            Set(ByVal value As String)
                m_strDesignation = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Name = m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        Public Property Phone() As String
            Get
                Phone = m_strPhone
            End Get
            Set(ByVal value As String)
                m_strPhone = value
            End Set
        End Property
        Public Property Cell() As String
            Get
                Cell = m_strCell
            End Get
            Set(ByVal value As String)
                m_strCell = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Email = m_strEmail
            End Get
            Set(ByVal value As String)
                m_strEmail = value
            End Set
        End Property
        Public Function SaveVAF_PrimaryContact()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteRow(ByVal VAF_PrimaryContactID As Long)
            Dim Str As String
            Str = "Delete from VAF_PrimaryContact  "
            Str &= " where VAF_PrimaryContactID=" & VAF_PrimaryContactID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace