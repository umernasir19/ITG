Imports Microsoft.VisualBasic
Imports System.Data
Public Class PortOrigin

    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PortOrigin"
        m_strPrimaryFieldName = "PortOriginID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPortOriginID As Long
    Private m_strPortOrigin As String
   
    Public Property PortOriginID() As Long
        Get
            PortOriginID = m_lPortOriginID
        End Get
        Set(ByVal Value As Long)
            m_lPortOriginID = Value
        End Set
    End Property
    Public Property PortOrigin() As String
        Get
            PortOrigin = m_strPortOrigin
        End Get
        Set(ByVal value As String)
            m_strPortOrigin = value
        End Set
    End Property
    Public Function SavePortOrigin()
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
