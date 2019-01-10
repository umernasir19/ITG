Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_GeneralInformation
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_GeneralInformation"
            m_strPrimaryFieldName = "VAF_GeneralInformationID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_GeneralInformationID As Long
        Private m_lVAFID As Long
        Private m_dcCompanyCoverdAreasqm As Decimal
        Private m_dcFactoryAreasqm As Decimal
        Private m_dcYear1 As Decimal
        Private m_dcAnnualTurnover1 As Decimal
        Private m_dcYear2 As Decimal
        Private m_dcAnnualTurnover2 As Decimal
        Private m_dcYear3 As Decimal
        Private m_dcAnnualTurnover3 As Decimal
        Private m_dcTotalAnnualShipmentsVolumeGlobally As Decimal
        Private m_dcTotalAnnualShipmentsEurope As Decimal
        Public Property VAF_GeneralInformationID() As Long
            Get
                VAF_GeneralInformationID = m_lVAF_GeneralInformationID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_GeneralInformationID = Value
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
        Public Property CompanyCoverdAreasqm() As Decimal
            Get
                CompanyCoverdAreasqm = m_dcCompanyCoverdAreasqm
            End Get
            Set(ByVal Value As Decimal)
                m_dcCompanyCoverdAreasqm = Value
            End Set
        End Property
        Public Property FactoryAreasqm() As Decimal
            Get
                FactoryAreasqm = m_dcFactoryAreasqm
            End Get
            Set(ByVal Value As Decimal)
                m_dcFactoryAreasqm = Value
            End Set
        End Property
        Public Property Year1() As Decimal
            Get
                Year1 = m_dcYear1
            End Get
            Set(ByVal Value As Decimal)
                m_dcYear1 = Value
            End Set
        End Property
        Public Property AnnualTurnover1() As Decimal
            Get
                AnnualTurnover1 = m_dcAnnualTurnover1
            End Get
            Set(ByVal Value As Decimal)
                m_dcAnnualTurnover1 = Value
            End Set
        End Property
        Public Property Year2() As Decimal
            Get
                Year2 = m_dcYear2
            End Get
            Set(ByVal Value As Decimal)
                m_dcYear2 = Value
            End Set
        End Property
        Public Property AnnualTurnover2() As Decimal
            Get
                AnnualTurnover2 = m_dcAnnualTurnover2
            End Get
            Set(ByVal Value As Decimal)
                m_dcAnnualTurnover2 = Value
            End Set
        End Property
        Public Property Year3() As Decimal
            Get
                Year3 = m_dcYear3
            End Get
            Set(ByVal Value As Decimal)
                m_dcYear3 = Value
            End Set
        End Property
        Public Property AnnualTurnover3() As Decimal
            Get
                AnnualTurnover3 = m_dcAnnualTurnover3
            End Get
            Set(ByVal Value As Decimal)
                m_dcAnnualTurnover3 = Value
            End Set
        End Property
        Public Property TotalAnnualShipmentsVolumeGlobally() As Decimal
            Get
                TotalAnnualShipmentsVolumeGlobally = m_dcTotalAnnualShipmentsVolumeGlobally
            End Get
            Set(ByVal Value As Decimal)
                m_dcTotalAnnualShipmentsVolumeGlobally = Value
            End Set
        End Property
        Public Property TotalAnnualShipmentsEurope() As Decimal
            Get
                TotalAnnualShipmentsEurope = m_dcTotalAnnualShipmentsEurope
            End Get
            Set(ByVal Value As Decimal)
                m_dcTotalAnnualShipmentsEurope = Value
            End Set
        End Property
        Public Function SaveVAF_GeneralInformation()
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
            Str = "Delete from VAF_GeneralInformation  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace