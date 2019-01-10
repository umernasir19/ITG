Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class QAProfileDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "QAProfileDtl"
            m_strPrimaryFieldName = "QADtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_QADtlID As Long
        Private m_QAMstID As Long
        Private m_Factory As String
        Private m_FactoryID As Long
        Private m_Location As String
        Private m_LocationID As Long
        Private m_StartDateQA As Date
        Private m_EndDateQA As Date

        Public Property QADtlID() As Long
            Get
                QADtlID = m_QADtlID
            End Get
            Set(ByVal value As Long)
                m_QADtlID = value
            End Set
        End Property
        Public Property QAMstID() As Long
            Get
                QAMstID = m_QAMstID
            End Get
            Set(ByVal value As Long)
                m_QAMstID = value
            End Set
        End Property
        Public Property Factory() As String
            Get
                Factory = m_Factory
            End Get
            Set(ByVal value As String)
                m_Factory = value
            End Set
        End Property
        Public Property FactoryID() As Long
            Get
                FactoryID = m_FactoryID
            End Get
            Set(ByVal value As Long)
                m_FactoryID = value
            End Set
        End Property
        Public Property Location() As String
            Get
                Location = m_Location
            End Get
            Set(ByVal value As String)
                m_Location = value
            End Set
        End Property
        Public Property LocationID() As Long
            Get
                LocationID = m_LocationID
            End Get
            Set(ByVal value As Long)
                m_LocationID = value
            End Set
        End Property
        Public Property StartDateQA() As Date
            Get
                StartDateQA = m_StartDateQA
            End Get
            Set(ByVal value As Date)
                m_StartDateQA = value
            End Set
        End Property
        Public Property EndDateQA() As Date
            Get
                EndDateQA = m_EndDateQA
            End Get
            Set(ByVal value As Date)
                m_EndDateQA = value
            End Set
        End Property
        Public Function SaveQAProfileDtl()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
       
    End Class
End Namespace

