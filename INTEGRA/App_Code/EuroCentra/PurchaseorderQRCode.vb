Imports System.Data

Namespace EuroCentra
    Public Class PurchaseorderQRCode
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PurchaseorderQRCode"
            m_strPrimaryFieldName = "QRCodeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lQRCodeID As Long
        Private m_lPOID As Long
        Private m_dtCreationDate As Date
        Private m_imgQRMGT As Object
        Private m_imgQRMerchant As Object
        Private m_imgQRQD As Object

        Public Property QRCodeID() As Long
            Get
                QRCodeID = m_lQRCodeID
            End Get
            Set(ByVal value As Long)
                m_lQRCodeID = value
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
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property QRMGT() As Object
            Get
                QRMGT = m_imgQRMGT
            End Get
            Set(ByVal value As Object)
                m_imgQRMGT = value
            End Set
        End Property
        Public Property QRMerchant() As Object
            Get
                QRMerchant = m_imgQRMerchant
            End Get
            Set(ByVal value As Object)
                m_imgQRMerchant = value
            End Set
        End Property
        Public Property QRQD() As Object
            Get
                QRQD = m_imgQRQD
            End Get
            Set(ByVal value As Object)
                m_imgQRQD = value
            End Set
        End Property
        Public Function SavePurchaseorderQRCode()
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
        Public Function CheckExisting(ByVal IPOID As Long) As DataTable
            Dim str As String
            str = "Select * from PurchaseorderQRCode where POID=" & IPOID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class

End Namespace

