Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class GeographicalTerritory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Geographical_Territory"
            m_strPrimaryFieldName = "Geographical_Territory_ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lGeographical_Territory_ID As Long
        Private m_strTerritory As String


        '.............Properties
        Public Property GeographicalTerritoryID() As Long
            Get
                GeographicalTerritoryID = m_lGeographical_Territory_ID
            End Get
            Set(ByVal value As Long)
                m_lGeographical_Territory_ID = value
            End Set
        End Property

        Public Property Territory() As String
            Get
                Territory = m_strTerritory
            End Get
            Set(ByVal value As String)
                m_strTerritory = value
            End Set
        End Property

        Public Sub SaveGeographicalTerritory()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetGeographicalTerritoryByID(ByVal lGeographicalTerritoryID As Long)
            Try
                Return MyBase.GetById(lGeographicalTerritoryID)
            Catch ex As Exception

            End Try

        End Function

        Function DeleteDetailsFromCustomerType(ByVal Geographical_Territory_ID As Long)
            Dim str As String
            str = "Delete From Geographical_Territory where Geographical_Territory_ID=" & Geographical_Territory_ID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try

        End Function
    End Class

End Namespace
