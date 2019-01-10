Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class EnquiriesSystemCPRDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiriesSystemCPRDetail"
            m_strPrimaryFieldName = "EnquiriesSystemCPRID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_EnquiriesSystemCPRID As Long
        Private m_EnquiriesSystemID As Long
        Private m_CPRequirmentID As Long
        Private m_CPRequirement As String
        Private m_CPRDate As Date
        Private m_Remarks As String
        Private m_DispatchDate As String
        Public Property EnquiriesSystemCPRID() As Long
            Get
                EnquiriesSystemCPRID = m_EnquiriesSystemCPRID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemCPRID = value
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
        Public Property CPRequirmentID() As Long
            Get
                CPRequirmentID = m_CPRequirmentID
            End Get
            Set(ByVal value As Long)
                m_CPRequirmentID = value
            End Set
        End Property
        Public Property CPRequirement() As String
            Get
                CPRequirement = m_CPRequirement
            End Get
            Set(ByVal value As String)
                m_CPRequirement = value
            End Set
        End Property
        Public Property CPRDate() As Date
            Get
                CPRDate = m_CPRDate
            End Get
            Set(ByVal value As Date)
                m_CPRDate = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_Remarks
            End Get
            Set(ByVal value As String)
                m_Remarks = value
            End Set
        End Property
        Public Property DispatchDate() As String
            Get
                DispatchDate = m_DispatchDate
            End Get
            Set(ByVal value As String)
                m_DispatchDate = value
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
