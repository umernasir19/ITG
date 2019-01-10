Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra

    Public Class POCancelDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "POCancelDetail"
            m_strPrimaryFieldName = "POCancelDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lPOCancelDetailID As Long
        Private m_lPOCancelID As Long
        Private m_lPOID As Long
        Private m_lPODetailID As Long
        Private m_dCancelQty As Decimal

        Public Property POCancelDetailID() As Long
            Get
                POCancelDetailID = m_lPOCancelDetailID
            End Get
            Set(ByVal value As Long)
                m_lPOCancelDetailID = value
            End Set
        End Property
        Public Property POCancelID() As Long
            Get
                POCancelID = m_lPOCancelID
            End Get
            Set(ByVal value As Long)
                m_lPOCancelID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal value As Long)
                m_lPODetailID = value
            End Set
        End Property
        Public Property CancelQty() As Decimal
            Get
                CancelQty = m_dCancelQty
            End Get
            Set(ByVal value As Decimal)
                m_dCancelQty = value
            End Set
        End Property
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function SavePOCancelDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace