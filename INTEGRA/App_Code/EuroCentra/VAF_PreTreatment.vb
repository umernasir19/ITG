Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_PreTreatment
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_PreTreatment"
            m_strPrimaryFieldName = "VAF_PreTreatmentID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_PreTreatmentID As Long
        Private m_lVAFID As Long
        Private m_lPreTreatmentID As Long
        Public Property VAF_PreTreatmentID() As Long
            Get
                VAF_PreTreatmentID = m_lVAF_PreTreatmentID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_PreTreatmentID = Value
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
        Public Property PreTreatmentID() As Long
            Get
                PreTreatmentID = m_lPreTreatmentID
            End Get
            Set(ByVal Value As Long)
                m_lPreTreatmentID = Value
            End Set
        End Property
        Public Function SaveVAF_PreTreatment()
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
            Str = "Delete from VAF_PreTreatment  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
