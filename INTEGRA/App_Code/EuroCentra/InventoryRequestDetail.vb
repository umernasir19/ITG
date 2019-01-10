Imports System.Data

Namespace EuroCentra
    Public Class InventoryRequestDetail
        Inherits SQLManager


        Public Sub New()
            m_strTableName = "InventoryRequestDetail"
            m_strPrimaryFieldName = "InventoryRequestDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lInventoryRequestDetailID As Long
        Private m_lInventoryRequestMasterID As Long
        Private m_lInventoryDatabaseID As Long
        Private m_bStatus As Boolean
        Public Property InventoryRequestDetailID() As Long
            Get
                InventoryRequestDetailID = m_lInventoryRequestDetailID
            End Get
            Set(ByVal Value As Long)
                m_lInventoryRequestDetailID = Value
            End Set
        End Property
        Public Property InventoryRequestMasterID() As Long
            Get
                InventoryRequestMasterID = m_lInventoryRequestMasterID
            End Get
            Set(ByVal Value As Long)
                m_lInventoryRequestMasterID = Value
            End Set
        End Property
        Public Property InventoryDatabaseID() As Long
            Get
                InventoryDatabaseID = m_lInventoryDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lInventoryDatabaseID = Value
            End Set
        End Property
        Public Property Status() As Boolean
            Get
                Status = m_bStatus
            End Get
            Set(ByVal Value As Boolean)
                m_bStatus = Value
            End Set
        End Property
        Public Function saveInventoryRequestDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
