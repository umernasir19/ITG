Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_MachineTechnical
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_MachineTechnical"
            m_strPrimaryFieldName = "VAF_MachineTechnicalID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_MachineTechnicalID As Long
        Private m_lVAFID As Long
        Private m_strMachine As String
        Private m_dcWidthinCM As Decimal
        Private m_dcMeterPerday As Decimal
        Private m_strModel As String
        Private m_dcYear As Decimal
        Private m_strType As String
        Public Property VAF_MachineTechnicalID() As Long
            Get
                VAF_MachineTechnicalID = m_lVAF_MachineTechnicalID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_MachineTechnicalID = Value
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
        Public Property Machine() As String
            Get
                Machine = m_strMachine
            End Get
            Set(ByVal value As String)
                m_strMachine = value
            End Set
        End Property
        Public Property WidthinCM() As Decimal
            Get
                WidthinCM = m_dcWidthinCM
            End Get
            Set(ByVal Value As Decimal)
                m_dcWidthinCM = Value
            End Set
        End Property
        Public Property MeterPerday() As Decimal
            Get
                MeterPerday = m_dcMeterPerday
            End Get
            Set(ByVal Value As Decimal)
                m_dcMeterPerday = Value
            End Set
        End Property
        Public Property Model() As String
            Get
                Model = m_strModel
            End Get
            Set(ByVal value As String)
                m_strModel = value
            End Set
        End Property
        Public Property Year() As Decimal
            Get
                Year = m_dcYear
            End Get
            Set(ByVal Value As Decimal)
                m_dcYear = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal value As String)
                m_strType = value
            End Set
        End Property
        Public Function SaveVAF_MachineTechnical()
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
        Public Function DeleteRow(ByVal VAF_MachineTechnicalID As Long)
            Dim Str As String
            Str = "Delete from VAF_MachineTechnical  "
            Str &= " where VAF_MachineTechnicalID=" & VAF_MachineTechnicalID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace