Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_PDInfo
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_PDInfo"
            m_strPrimaryFieldName = "VAF_PDInfoID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_PDInfoID As Long
        Private m_lVAFID As Long
        Private m_lPDid As Long
        Public Property VAF_PDInfoID() As Long
            Get
                VAF_PDInfoID = m_lVAF_PDInfoID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_PDInfoID = Value
            End Set
        End Property
        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property PDid() As Long
            Get
                PDid = m_lPDid
            End Get
            Set(ByVal Value As Long)
                m_lPDid = Value
            End Set
        End Property
        Public Function SaveVAF_PDInfo()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function

        Public Function Delete(ByVal VAFID As Long)
            Dim Str As String
            Str = "Delete from VAF_PDInfo  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace