Imports Microsoft.VisualBasic
Imports System.Data
Public Class PortLoad
    Inherits SQLManager
        Public Sub New()
        m_strTableName = "PortLoad"
        m_strPrimaryFieldName = "PortLoadID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
    Private m_lPortLoadID As Long
    Private m_strPortLoad As String

    Public Property PortLoadID() As Long
        Get
            PortLoadID = m_lPortLoadID
        End Get
        Set(ByVal Value As Long)
            m_lPortLoadID = Value
        End Set
    End Property
    Public Property PortLoad() As String
        Get
            PortLoad = m_strPortLoad
        End Get
        Set(ByVal value As String)
            m_strPortLoad = value
        End Set
    End Property
    Public Function SavePortLoad()
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
