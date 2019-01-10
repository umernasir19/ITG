Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class DPIDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPIDtl"
            m_strPrimaryFieldName = "DPIDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPIDtlID As Long
        Private m_lDPIMstID As Long
        Private m_strSRNO As String
        Private m_lJoborderid As Long
       
        Public Property DPIDtlID() As Long
            Get
                DPIDtlID = m_lDPIDtlID
            End Get
            Set(ByVal Value As Long)
                m_lDPIDtlID = Value
            End Set
        End Property
        Public Property DPIMstID() As Long
            Get
                DPIMstID = m_lDPIMstID
            End Get
            Set(ByVal Value As Long)
                m_lDPIMstID = Value
            End Set
        End Property
        Public Property SRNO() As String
            Get
                SRNO = m_strSRNO
            End Get
            Set(ByVal value As String)
                m_strSRNO = value
            End Set
        End Property
        Public Property Joborderid() As Long
            Get
                Joborderid = m_lJoborderid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderid = Value
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
