Imports System.Data

Namespace EuroCentra
    Public Class ComplainDatabaseDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ComplainDatabaseDetail"
            m_strPrimaryFieldName = "ComplainDatabaseDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lComplainDatabaseDetailID As Long
        Private m_lComplainDatabaseID As Long
        Private m_lPOID As Long
        Private m_lPoDetailID As Long
        Private m_dcFaultQty As Decimal

        Public Property ComplainDatabaseDetailID() As Long
            Get
                ComplainDatabaseDetailID = m_lComplainDatabaseDetailID
            End Get
            Set(ByVal Value As Long)
                m_lComplainDatabaseDetailID = Value
            End Set
        End Property
        Public Property ComplainDatabaseID() As Long
            Get
                ComplainDatabaseID = m_lComplainDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lComplainDatabaseID = Value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal Value As Long)
                m_lPOID = Value
            End Set
        End Property
        Public Property PoDetailID() As Long
            Get
                PoDetailID = m_lPoDetailID
            End Get
            Set(ByVal Value As Long)
                m_lPoDetailID = Value
            End Set
        End Property
        Public Property FaultQty() As Decimal
            Get
                FaultQty = m_dcFaultQty
            End Get
            Set(ByVal value As Decimal)
                m_dcFaultQty = value
            End Set
        End Property
        Public Function SaveComplainDatabaseDetail()
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
    End Class
End Namespace