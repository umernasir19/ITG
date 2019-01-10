Imports System.Data

Namespace EuroCentra
    Public Class DPType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPType"
            m_strPrimaryFieldName = "DPTypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_DPTypeID As Long
        Private m_DPTypeName As String

        Public Property DPTypeID() As Long
            Get
                DPTypeID = m_DPTypeID
            End Get
            Set(ByVal Value As Long)
                m_DPTypeID = Value
            End Set
        End Property
        Public Property DPTypeName() As String
            Get
                DPTypeName = m_DPTypeName
            End Get
            Set(ByVal value As String)
                m_DPTypeName = value
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