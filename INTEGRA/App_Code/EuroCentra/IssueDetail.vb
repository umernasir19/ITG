﻿Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class IssueDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IssueDetail"
            m_strPrimaryFieldName = "IssueDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lIssueDtlID As Long
        Private m_lIssueID As Long
        Private m_lItemID As Long
        Private m_lDeptDatabaseID As Long
        Private m_strContractor As String
        Private m_dRecvQty As Decimal
        Private m_dIssueQty As Decimal
        Private m_strRemarks As String
        Private m_strEntryType As String
        Private m_dcIssueReturn As Decimal
        Private m_dcRate As Decimal
        Private m_lSeasonDatabaseID As Long
        Private m_lJobOrderID As Long
        Private m_strSeasonName As String
        Private m_strSrNoo As String
        Private m_lPOID As Long
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal Value As Long)
                m_lPOID = Value
            End Set
        End Property
        Public Property SeasonName() As String
            Get
                SeasonName = m_strSeasonName
            End Get
            Set(ByVal value As String)
                m_strSeasonName = value
            End Set
        End Property
        Public Property SrNoo() As String
            Get
                SrNoo = m_strSrNoo
            End Get
            Set(ByVal value As String)
                m_strSrNoo = value
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
        Public Property Rate() As Decimal
            Get
                Rate = m_dcRate
            End Get
            Set(ByVal Value As Decimal)
                m_dcRate = Value
            End Set

        End Property
        Public Property IssueDtlID() As Long
            Get
                IssueDtlID = m_lIssueDtlID
            End Get
            Set(ByVal Value As Long)
                m_lIssueDtlID = Value
            End Set
        End Property
        Public Property IssueID() As Long
            Get
                IssueID = m_lIssueID
            End Get
            Set(ByVal Value As Long)
                m_lIssueID = Value
            End Set
        End Property
        Public Property ItemID() As Long
            Get
                ItemID = m_lItemID
            End Get
            Set(ByVal Value As Long)
                m_lItemID = Value
            End Set
        End Property
        Public Property DeptDatabaseID() As Long
            Get
                DeptDatabaseID = m_lDeptDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lDeptDatabaseID = Value
            End Set
        End Property
        Public Property Contractor() As String
            Get
                Contractor = m_strContractor
            End Get
            Set(ByVal Value As String)
                m_strContractor = Value
            End Set
        End Property
        Public Property RecvQty() As Decimal
            Get
                RecvQty = m_dRecvQty
            End Get
            Set(ByVal Value As Decimal)
                m_dRecvQty = Value
            End Set
        End Property
        Public Property IssueQty() As Decimal
            Get
                IssueQty = m_dIssueQty
            End Get
            Set(ByVal Value As Decimal)
                m_dIssueQty = Value
            End Set

        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Property EntryType() As String
            Get
                EntryType = m_strEntryType
            End Get
            Set(ByVal Value As String)
                m_strEntryType = Value
            End Set
        End Property
        Public Property IssueReturn() As Decimal
            Get
                IssueReturn = m_dcIssueReturn
            End Get
            Set(ByVal Value As Decimal)
                m_dcIssueReturn = Value
            End Set
        End Property
        Public Function saveIssueDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function deleteIssueDtl(ByVal IssueID As Long)
            Dim Str As String
            Str = " delete from IssueDetail where IssueID='" & IssueID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
