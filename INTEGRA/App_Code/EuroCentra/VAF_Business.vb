Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_Business
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_Business"
            m_strPrimaryFieldName = "VAF_BusinessID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lVAF_BusinessID As Long
        Private m_lVAFID As Long
        Private m_lBusinessID As Long
        Public Property VAF_BusinessID() As Long
            Get
                VAF_BusinessID = m_lVAF_BusinessID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_BusinessID = Value
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
        Public Property BusinessID() As Long
            Get
                BusinessID = m_lBusinessID
            End Get
            Set(ByVal Value As Long)
                m_lBusinessID = Value
            End Set
        End Property
        Public Function SaveVAF_Business()
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
            Str = "Delete from VAF_Business  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace