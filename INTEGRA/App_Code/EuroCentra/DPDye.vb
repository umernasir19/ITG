Imports System.Data

Namespace EuroCentra
    Public Class DPDye
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPDye"
            m_strPrimaryFieldName = "DyeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_DyeID As Long
        Private m_DyeName As String

        Public Property DyeID() As Long
            Get
                DyeID = m_DyeID
            End Get
            Set(ByVal Value As Long)
                m_DyeID = Value
            End Set
        End Property
        Public Property DyeName() As String
            Get
                DyeName = m_DyeName
            End Get
            Set(ByVal value As String)
                m_DyeName = value
            End Set
        End Property

        Public Function SaveDye()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace