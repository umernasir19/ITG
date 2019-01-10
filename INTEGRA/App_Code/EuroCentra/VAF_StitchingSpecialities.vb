Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_StitchingSpecialities
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_StitchingSpecialities"
            m_strPrimaryFieldName = "VAF_StitchingSpecialitiesID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_StitchingSpecialitiesID As Long
        Private m_lVAFID As Long
        Private m_dcCapacityPerWeekmeter As Decimal
        Private m_dcCapacityPerWeekPcs As Decimal
        Public Property VAF_StitchingSpecialitiesID() As Long
            Get
                VAF_StitchingSpecialitiesID = m_lVAF_StitchingSpecialitiesID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_StitchingSpecialitiesID = Value
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
        Public Property CapacityPerWeekmeter() As Decimal
            Get
                CapacityPerWeekmeter = m_dcCapacityPerWeekmeter
            End Get
            Set(ByVal Value As Decimal)
                m_dcCapacityPerWeekmeter = Value
            End Set
        End Property
        Public Property CapacityPerWeekPcs() As Decimal
            Get
                CapacityPerWeekPcs = m_dcCapacityPerWeekPcs
            End Get
            Set(ByVal Value As Decimal)
                m_dcCapacityPerWeekPcs = Value
            End Set
        End Property
        Public Function SaveVAF_StitchingSpecialities()
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


    End Class
End Namespace