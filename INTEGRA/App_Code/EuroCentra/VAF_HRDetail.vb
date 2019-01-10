Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_HRDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_HRDetail"
            m_strPrimaryFieldName = "VAF_HRDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_HRDetailID As Long
        Private m_lVAFID As Long
        Private m_dcTotalWorker As Decimal
        Private m_dcMale As Decimal
        Private m_dcFemale As Decimal
        Private m_dcPermanentStaff As Decimal
        Private m_dcNoofShift As Decimal
        Private m_strTiming As String
        Public Property VAF_HRDetailID() As Long
            Get
                VAF_HRDetailID = m_lVAF_HRDetailID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_HRDetailID = Value
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
        Public Property TotalWorker() As Decimal
            Get
                TotalWorker = m_dcTotalWorker
            End Get
            Set(ByVal Value As Decimal)
                m_dcTotalWorker = Value
            End Set
        End Property
        Public Property Male() As Decimal
            Get
                Male = m_dcMale
            End Get
            Set(ByVal Value As Decimal)
                m_dcMale = Value
            End Set
        End Property
        Public Property Female() As Decimal
            Get
                Female = m_dcFemale
            End Get
            Set(ByVal Value As Decimal)
                m_dcFemale = Value
            End Set
        End Property
        Public Property PermanentStaff() As Decimal
            Get
                PermanentStaff = m_dcPermanentStaff
            End Get
            Set(ByVal Value As Decimal)
                m_dcPermanentStaff = Value
            End Set
        End Property
        Public Property NoofShift() As Decimal
            Get
                NoofShift = m_dcNoofShift
            End Get
            Set(ByVal Value As Decimal)
                m_dcNoofShift = Value
            End Set
        End Property
        Public Property Timing() As String
            Get
                Timing = m_strTiming
            End Get
            Set(ByVal value As String)
                m_strTiming = value
            End Set
        End Property
        Public Function SaveVAF_HRDetail()
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
            Str = "Delete from VAF_HRDetail  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace