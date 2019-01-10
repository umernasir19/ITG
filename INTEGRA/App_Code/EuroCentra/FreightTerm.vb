Imports System.Data
Namespace EuroCentra
    Public Class FreightTerm
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FreightTerm"
            m_strPrimaryFieldName = "FreightTermID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_FreightTermID As Long
        Private m_strFreightTerm As String
        ''---------------- Properties
        Public Property FreightTermID() As Long
            Get
                FreightTermID = m_FreightTermID
            End Get
            Set(ByVal value As Long)
                m_FreightTermID = value
            End Set
        End Property
        Public Property FreightTerm() As String
            Get
                FreightTerm = m_strFreightTerm
            End Get
            Set(ByVal value As String)
                m_strFreightTerm = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
