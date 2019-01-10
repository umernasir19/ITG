Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class PortDestinationsEntry
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PortDestinations"
            m_strPrimaryFieldName = "PortDestinationsID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPortDestinationsID As Long
        Private m_lCountryid As Long
        Private m_strMode As String
        Private m_strPort As String
        Public Property PortDestinationsID() As Long
            Get
                PortDestinationsID = m_lPortDestinationsID
            End Get
            Set(ByVal Value As Long)
                m_lPortDestinationsID = Value
            End Set
        End Property
        Public Property Countryid() As Long
            Get
                Countryid = m_lCountryid
            End Get
            Set(ByVal Value As Long)
                m_lCountryid = Value
            End Set
        End Property
        Public Property Mode() As String
            Get
                Mode = m_strMode
            End Get
            Set(ByVal value As String)
                m_strMode = value
            End Set
        End Property

        Public Property Port() As String
            Get
                Port = m_strPort
            End Get
            Set(ByVal value As String)
                m_strPort = value
            End Set
        End Property

        Public Function SavePortDestinations()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function

        Public Function Edit(ByVal PortDestinationsID As Long) As DataTable
            Dim str As String
            str = " Select * from PortDestinations where PortDestinationsID=" & PortDestinationsID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function PortDestinationsForView() As DataTable
            Dim str As String
            str = " Select * from PortDestinations PS join Countries C on C.Country_id=Ps.CountryID  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindCountry() As DataTable
            Dim str As String
            str = " Select * from Countries  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace