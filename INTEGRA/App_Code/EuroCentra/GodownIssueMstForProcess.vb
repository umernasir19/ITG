Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class GodownIssueMstForProcess
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSGodownIssueForProcess"
            m_strPrimaryFieldName = "GodownIssueID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lGodownIssueID As Long
        Private m_dtCreationDate As Date
        Private m_lCreatedbyID As Long
        Private m_dtEntryDate As Date
        Private m_strSIVNo As String
        Private m_strCCNo As String
        Private m_dbTokenNo As Decimal
        Private m_strCounterNo As String
        Private m_lSeasonDatabaseID As Long
        Private m_lJobOrderID As Long
        Private m_ChallanNo As String
        Private m_Remarks As String
        Public Property Remarks() As String
            Get
                Remarks = m_Remarks
            End Get
            Set(ByVal Value As String)
                m_Remarks = Value
            End Set
        End Property

        Public Property ChallanNo() As String
            Get
                ChallanNo = m_ChallanNo
            End Get
            Set(ByVal Value As String)
                m_ChallanNo = Value
            End Set
        End Property
        Public Property SeasonDatabaseID() As Long
            Get
                SeasonDatabaseID = m_lSeasonDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseID = Value
            End Set
        End Property
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property GodownIssueID() As Long
            Get
                GodownIssueID = m_lGodownIssueID
            End Get
            Set(ByVal Value As Long)
                m_lGodownIssueID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property CreatedbyID() As Long
            Get
                CreatedbyID = m_lCreatedbyID
            End Get
            Set(ByVal Value As Long)
                m_lCreatedbyID = Value
            End Set
        End Property
        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate
            End Get
            Set(ByVal Value As Date)
                m_dtEntryDate = Value
            End Set
        End Property
        Public Property SIVNo() As String
            Get
                SIVNo = m_strSIVNo
            End Get
            Set(ByVal Value As String)
                m_strSIVNo = Value
            End Set
        End Property

        Public Property CCNo() As String
            Get
                CCNo = m_strCCNo
            End Get
            Set(ByVal Value As String)
                m_strCCNo = Value
            End Set
        End Property
        Public Property TokenNo() As Decimal
            Get
                TokenNo = m_dbTokenNo
            End Get
            Set(ByVal value As Decimal)
                m_dbTokenNo = value
            End Set
        End Property
        Public Property CounterNo() As String
            Get
                CounterNo = m_strCounterNo
            End Get
            Set(ByVal Value As String)
                m_strCounterNo = Value
            End Set
        End Property

        Public Function SaveIMSGodownIssue()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
