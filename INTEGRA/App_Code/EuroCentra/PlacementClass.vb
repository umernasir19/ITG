Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class PlacementClass
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Placement"
            m_strPrimaryFieldName = "PlacementID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPlacementID As Long
        Private m_strPlacement As String
        Public Property PlacementID() As Long
            Get
                PlacementID = m_lPlacementID
            End Get
            Set(ByVal Value As Long)
                m_lPlacementID = Value
            End Set
        End Property
        Public Property Placement() As String
            Get
                Placement = m_strPlacement
            End Get
            Set(ByVal value As String)
                m_strPlacement = value
            End Set
        End Property
        Public Function Save()
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
    End Class
End Namespace
