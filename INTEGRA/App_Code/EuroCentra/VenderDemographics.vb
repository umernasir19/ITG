Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class VenderDemographics
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderDemographics"
            m_strPrimaryFieldName = "VDID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_VDID As Long
        Private m_Factory As String
        Private m_CoveredArea As Decimal
        Private m_TownID As Long
        Private m_VenderLibraryID As Long

        Public Property VDID() As Long
            Get
                VDID = m_VDID
            End Get
            Set(ByVal value As Long)
                m_VDID = value
            End Set
        End Property
        Public Property Factory() As String
            Get
                Factory = m_Factory
            End Get
            Set(ByVal value As String)
                m_Factory = value
            End Set
        End Property
        Public Property CoveredArea() As Decimal
            Get
                CoveredArea = m_CoveredArea
            End Get
            Set(ByVal value As Decimal)
                m_CoveredArea = value
            End Set
        End Property
        Public Property TownID() As Long
            Get
                TownID = m_TownID
            End Get
            Set(ByVal value As Long)
                m_TownID = value
            End Set
        End Property
        Public Property VenderLibraryID() As Long
            Get
                VenderLibraryID = m_VenderLibraryID
            End Get
            Set(ByVal value As Long)
                m_VenderLibraryID = value
            End Set
        End Property
        Public Function SaveVenderDemographics()
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

    End Class
End Namespace