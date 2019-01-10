Imports System.Data

Namespace EuroCentra
    Public Class DPFinish
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPFinish"
            m_strPrimaryFieldName = "FinishID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_FinishID As Long
        Private m_FinishName As String

        Public Property FinishID() As Long
            Get
                FinishID = m_FinishID
            End Get
            Set(ByVal Value As Long)
                m_FinishID = Value
            End Set
        End Property
        Public Property FinishName() As String
            Get
                FinishName = m_FinishName
            End Get
            Set(ByVal value As String)
                m_FinishName = value
            End Set
        End Property

        Public Function SaveFinish()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace