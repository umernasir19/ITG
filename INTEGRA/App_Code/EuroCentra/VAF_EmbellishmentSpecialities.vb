Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_EmbellishmentSpecialities
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_EmbellishmentSpecialities"
            m_strPrimaryFieldName = "VAF_EmbellishmentSpecialitiesID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_EmbellishmentSpecialitiesID As Long
        Private m_lVAFID As Long
        Private m_strCapabilities As String
        Private m_dcVolume As Decimal
        Private m_strUnit As String
        Private m_dcNoofMac As Decimal
        Public Property VAF_EmbellishmentSpecialitiesID() As Long
            Get
                VAF_EmbellishmentSpecialitiesID = m_lVAF_EmbellishmentSpecialitiesID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_EmbellishmentSpecialitiesID = Value
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
        Public Property Capabilities() As String
            Get
                Capabilities = m_strCapabilities
            End Get
            Set(ByVal value As String)
                m_strCapabilities = value
            End Set
        End Property
        Public Property Unit() As String
            Get
                Unit = m_strUnit
            End Get
            Set(ByVal value As String)
                m_strUnit = value
            End Set
        End Property
        Public Property Volume() As Decimal
            Get
                Volume = m_dcVolume
            End Get
            Set(ByVal Value As Decimal)
                m_dcVolume = Value
            End Set
        End Property
        Public Property NoofMac() As Decimal
            Get
                NoofMac = m_dcNoofMac
            End Get
            Set(ByVal Value As Decimal)
                m_dcNoofMac = Value
            End Set
        End Property
        Public Function SaveVAF_EmbellishmentSpecialities()
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
        Public Function DeleteRow(ByVal VAF_EmbellishmentSpecialitiesID As Long)
            Dim Str As String
            Str = "Delete from VAF_EmbellishmentSpecialities  "
            Str &= " where VAF_EmbellishmentSpecialitiesID=" & VAF_EmbellishmentSpecialitiesID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace