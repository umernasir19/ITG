Imports System.Data

Namespace EuroCentra
    Public Class DPWashType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPWashType"
            m_strPrimaryFieldName = "WashTypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_DPWashTypeID As Long
        Private m_DPWashType As String

        Public Property WashTypeID() As Long
            Get
                WashTypeID = m_DPWashTypeID
            End Get
            Set(ByVal Value As Long)
                m_DPWashTypeID = Value
            End Set
        End Property
        Public Property WashType() As String
            Get
                WashType = m_DPWashType
            End Get
            Set(ByVal value As String)
                m_DPWashType = value
            End Set
        End Property

        Public Function SaveDPType()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
