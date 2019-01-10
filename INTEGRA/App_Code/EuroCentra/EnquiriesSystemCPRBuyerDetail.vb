Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class EnquiriesSystemCPRBuyerDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiriesSystemCPRBuyerDetail"
            m_strPrimaryFieldName = "EnquiriesSystemCPRBuyerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_EnquiriesSystemCPRBuyerID As Long
        Private m_EnquiriesSystemID As Long
        Private m_CPCPRequirmentBID As Long
        Private m_CPRequirementB As String
        Private m_CPRBDate As Date
        Private m_RemarksB As String
        Public Property EnquiriesSystemCPRBuyerID() As Long
            Get
                EnquiriesSystemCPRBuyerID = m_EnquiriesSystemCPRBuyerID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemCPRBuyerID = value
            End Set
        End Property
        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_EnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemID = value
            End Set
        End Property
        Public Property CPRequirmentBID() As Long
            Get
                CPRequirmentBID = m_CPCPRequirmentBID
            End Get
            Set(ByVal value As Long)
                m_CPCPRequirmentBID = value
            End Set
        End Property
        Public Property CPRequirementB() As String
            Get
                CPRequirementB = m_CPRequirementB
            End Get
            Set(ByVal value As String)
                m_CPRequirementB = value
            End Set
        End Property
        Public Property CPRBDate() As Date
            Get
                CPRBDate = m_CPRBDate
            End Get
            Set(ByVal value As Date)
                m_CPRBDate = value
            End Set
        End Property
        Public Property RemarksB() As String
            Get
                RemarksB = m_RemarksB
            End Get
            Set(ByVal value As String)
                m_RemarksB = value
            End Set
        End Property
        Public Function SaveEnquiriesCRPSystem()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
    End Class

End Namespace
