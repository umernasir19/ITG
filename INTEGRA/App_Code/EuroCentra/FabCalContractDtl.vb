Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabCalContractDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabCalContractDtl"
            m_strPrimaryFieldName = "FabCalContractDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabCalContractDtlID As Long
        Private m_lFabCalMstID As Long

        Private m_strContract As String
        Private m_strPrice As String
        Private m_strBooked As String
        Private m_dtDeliveryDate As Date
        Public Property FabCalContractDtlID() As Long
            Get
                FabCalContractDtlID = m_lFabCalContractDtlID
            End Get
            Set(ByVal Value As Long)
                m_lFabCalContractDtlID = Value
            End Set
        End Property
        Public Property FabCalMstID() As Long
            Get
                FabCalMstID = m_lFabCalMstID
            End Get
            Set(ByVal Value As Long)
                m_lFabCalMstID = Value
            End Set
        End Property
        Public Property Contract() As String
            Get
                Contract = m_strContract
            End Get
            Set(ByVal Value As String)
                m_strContract = Value
            End Set
        End Property
        Public Property Price() As String
            Get
                Price = m_strPrice
            End Get
            Set(ByVal Value As String)
                m_strPrice = Value
            End Set
        End Property
        Public Property Booked() As String
            Get
                Booked = m_strBooked
            End Get
            Set(ByVal Value As String)
                m_strBooked = Value
            End Set
        End Property
        Public Property DeliveryDate() As Date
            Get
                DeliveryDate = m_dtDeliveryDate
            End Get
            Set(ByVal value As Date)
                m_dtDeliveryDate = value
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
