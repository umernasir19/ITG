Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_ConceptualDesign
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_ConceptualDesign"
            m_strPrimaryFieldName = "VAF_ConceptualDesignID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_ConceptualDesignID As Long
        Private m_lVAFID As Long
        Private m_strConceptualDesignStaff As String
        Private m_bInHouse As Boolean
        Private m_bNumberOfInHouseDesigners As Boolean
        Private m_strInHouseLocation As String
        Private m_bContracted As Boolean
        Private m_bNumberOfOutsideDesigners As Boolean
        Private m_strContractedLocation As String

        Public Property VAF_ConceptualDesignID() As Long
            Get
                VAF_ConceptualDesignID = m_lVAF_ConceptualDesignID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_ConceptualDesignID = Value
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
        Public Property ConceptualDesignStaff() As String
            Get
                ConceptualDesignStaff = m_strConceptualDesignStaff
            End Get
            Set(ByVal value As String)
                m_strConceptualDesignStaff = value
            End Set
        End Property
        Public Property InHouse() As Boolean
            Get
                InHouse = m_bInHouse
            End Get
            Set(ByVal value As Boolean)
                m_bInHouse = value
            End Set
        End Property
        Public Property NumberOfInHouseDesigners() As Boolean
            Get
                NumberOfInHouseDesigners = m_bNumberOfInHouseDesigners
            End Get
            Set(ByVal value As Boolean)
                m_bNumberOfInHouseDesigners = value
            End Set
        End Property
        Public Property InHouseLocation() As String
            Get
                InHouseLocation = m_strInHouseLocation
            End Get
            Set(ByVal value As String)
                m_strInHouseLocation = value
            End Set
        End Property
        Public Property Contracted() As Boolean
            Get
                Contracted = m_bContracted
            End Get
            Set(ByVal value As Boolean)
                m_bContracted = value
            End Set
        End Property
        Public Property NumberOfOutsideDesigners() As Boolean
            Get
                NumberOfOutsideDesigners = m_bNumberOfOutsideDesigners
            End Get
            Set(ByVal value As Boolean)
                m_bNumberOfOutsideDesigners = value
            End Set
        End Property
        Public Property ContractedLocation() As String
            Get
                ContractedLocation = m_strContractedLocation
            End Get
            Set(ByVal value As String)
                m_strContractedLocation = value
            End Set
        End Property
        Public Function SaveVAF_ConceptualDesign()
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
            Str = "Delete from VAF_ConceptualDesign  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace