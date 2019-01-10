Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class JobOrderCertificateRequired

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "JobOrderCertificateRequired"
            m_strPrimaryFieldName = "JobOrderCertificateRequiredID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lJobOrderCertificateRequiredID As Long
        Private m_lJobOrderID As Long
        Private m_lCertificateID As Long
        Private m_lSupplierCertificateID As Long
        Public Property JobOrderCertificateRequiredID() As Long
            Get
                JobOrderCertificateRequiredID = m_lJobOrderCertificateRequiredID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderCertificateRequiredID = Value
            End Set
        End Property

        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal value As Long)
                m_lJobOrderID = value
            End Set
        End Property
        Public Property CertificateID() As Long
            Get
                CertificateID = m_lCertificateID
            End Get
            Set(ByVal value As Long)
                m_lCertificateID = value
            End Set
        End Property
        Public Property SupplierCertificateID() As Long
            Get
                SupplierCertificateID = m_lSupplierCertificateID
            End Get
            Set(ByVal value As Long)
                m_lSupplierCertificateID = value
            End Set
        End Property

        Public Function SaveCertificate()
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
