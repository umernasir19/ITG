
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class DPRNDAccessDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPRNDAccessDetail"
            m_strPrimaryFieldName = "DPRNDAccessDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPRNDAccessDetailID As Long
        Private m_lDPItemDatabaseID As Long
        Private m_lDPRNDID As Long
        Private m_strDESCRIPTION As String
        Private m_dcCONSPER As Decimal
        Private m_dcPrice As Decimal
        Private m_strItemName As String

        
        
        Public Property DPRNDAccessDetailID() As Long
            Get
                DPRNDAccessDetailID = m_lDPRNDAccessDetailID
            End Get
            Set(ByVal value As Long)
                m_lDPRNDAccessDetailID = value
            End Set
        End Property
        Public Property DPItemDatabaseID() As Long
            Get
                DPItemDatabaseID = m_lDPItemDatabaseID
            End Get
            Set(ByVal value As Long)
                m_lDPItemDatabaseID = value
            End Set
        End Property
        Public Property DPRNDID() As Long
            Get
                DPRNDID = m_lDPRNDID
            End Get
            Set(ByVal value As Long)
                m_lDPRNDID = value
            End Set
        End Property
       
        
        Public Property DESCRIPTION() As String
            Get
                DESCRIPTION = m_strDESCRIPTION
            End Get
            Set(ByVal value As String)
                m_strDESCRIPTION = value
            End Set

        End Property
        Public Property CONSPER() As Decimal
            Get
                CONSPER = m_dcCONSPER
            End Get
            Set(ByVal value As Decimal)
                m_dcCONSPER = value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_dcPrice
            End Get
            Set(ByVal value As Decimal)
                m_dcPrice = value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal value As String)
                m_strItemName = value
            End Set

        End Property
        Public Function SaveAcc()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        
    End Class
End Namespace

