Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_Sampling
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_Sampling"
            m_strPrimaryFieldName = "VAF_SamplingID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_SamplingID As Long
        Private m_lVAFID As Long
        Private m_strSamplingDepartment As String
        Private m_dcNoOfMachine As Decimal
        Private m_dcCapacity As Decimal
        Public Property VAF_SamplingID() As Long
            Get
                VAF_SamplingID = m_lVAF_SamplingID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_SamplingID = Value
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
        Public Property SamplingDepartment() As String
            Get
                SamplingDepartment = m_strSamplingDepartment
            End Get
            Set(ByVal value As String)
                m_strSamplingDepartment = value
            End Set
        End Property
        Public Property NoOfMachine() As Decimal
            Get
                NoOfMachine = m_dcNoOfMachine
            End Get
            Set(ByVal Value As Decimal)
                m_dcNoOfMachine = Value
            End Set
        End Property
        Public Property Capacity() As Decimal
            Get
                Capacity = m_dcCapacity
            End Get
            Set(ByVal Value As Decimal)
                m_dcCapacity = Value
            End Set
        End Property
        Public Function SaveVAF_Sampling()
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
            Str = "Delete from VAF_Sampling  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace