Imports system.data
Namespace EuroCentra
    Public Class DPWashDtl
        Inherits sqlmanager
        Public Sub New()
            m_strTableName = "DPWashDtl"
            m_strPrimaryFieldName = "WashDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lWashDtlID As Long
        Private m_lWashMstID As Long
        Private m_lWashTypeID As Long
        Private m_lFabricDBMstID As Long
        Private m_lTblRNDID As Long
        Private m_lDPSampleReceiveID As Long
        Private m_dIssuedQty As Decimal
        Private m_dIssueQty As Decimal
        Private M_DSampleRecvQty As Decimal
        Private m_lEKNumber As String
        Private m_lDSRNO As String
        Public Property DSRNO() As String
            Get
                DSRNO = m_lDSRNO
            End Get
            Set(ByVal value As String)
                m_lDSRNO = value
            End Set
        End Property
        Public Property WashDtlID() As Long
            Get
                WashDtlID = m_lWashDtlID
            End Get
            Set(ByVal value As Long)
                m_lWashDtlID = value
            End Set
        End Property
        Public Property WashMstID() As Long
            Get
                WashMstID = m_lWashMstID
            End Get
            Set(ByVal value As Long)
                m_lWashMstID = value
            End Set
        End Property
        Public Property WashTypeID() As Long
            Get
                WashTypeID = m_lWashTypeID
            End Get
            Set(ByVal value As Long)
                m_lWashTypeID = value
            End Set
        End Property
        Public Property FabricDBMstID() As Long
            Get
                FabricDBMstID = m_lFabricDBMstID
            End Get
            Set(ByVal value As Long)
                m_lFabricDBMstID = value
            End Set
        End Property
        Public Property TblRNDID() As Long
            Get
                TblRNDID = m_lTblRNDID
            End Get
            Set(ByVal value As Long)
                m_lTblRNDID = value
            End Set
        End Property
        Public Property DPSampleReceiveID() As Long
            Get
                DPSampleReceiveID = m_lDPSampleReceiveID
            End Get
            Set(ByVal value As Long)
                m_lDPSampleReceiveID = value
            End Set
        End Property
        Public Property IssuedQty() As Decimal
            Get
                IssuedQty = m_dIssuedQty
            End Get
            Set(ByVal value As Decimal)
                m_dIssuedQty = value
            End Set
        End Property
        Public Property IssueQty() As Decimal
            Get
                IssueQty = m_dIssueQty
            End Get
            Set(ByVal value As Decimal)
                m_dIssueQty = value
            End Set
        End Property
        Public Property SampleRecvQty() As Decimal
            Get
                SampleRecvQty = M_DSampleRecvQty
            End Get
            Set(ByVal value As Decimal)
                M_DSampleRecvQty = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace


