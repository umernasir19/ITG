Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabCalMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabCalMst"
            m_strPrimaryFieldName = "FabCalMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabCalMstID As Long
        Private m_dCreationDate As Date
        Private m_lUserId As Long
        Private m_dOrderConDate As Date
        Private m_lCustomerId As Long
        Private m_lIMSItemId As Long
        Public Property FabCalMstID() As Long
            Get
                FabCalMstID = m_lFabCalMstID
            End Get
            Set(ByVal Value As Long)
                m_lFabCalMstID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dCreationDate = Value
            End Set
        End Property
        Public Property UserId() As Long
            Get
                UserId = m_lUserId
            End Get
            Set(ByVal Value As Long)
                m_lUserId = Value
            End Set
        End Property
        Public Property OrderConDate() As Date
            Get
                OrderConDate = m_dOrderConDate
            End Get
            Set(ByVal Value As Date)
                m_dOrderConDate = Value
            End Set
        End Property
        Public Property CustomerId() As Long
            Get
                CustomerId = m_lCustomerId
            End Get
            Set(ByVal Value As Long)
                m_lCustomerId = Value
            End Set
        End Property
        Public Property IMSItemId() As Long
            Get
                IMSItemId = m_lIMSItemId
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemId = Value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
