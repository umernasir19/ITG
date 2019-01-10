Imports System.Data

Namespace EuroCentra
    Public Class Certificate
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Certificate"
            m_strPrimaryFieldName = "CertificateID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCertificateID As Long
        Private m_strCertificate As String
        Private m_bIsActive As Boolean
        Private m_bIsLifetime As Boolean
        Public Property CertificateID() As Long
            Get
                CertificateID = m_lCertificateID
            End Get
            Set(ByVal Value As Long)
                m_lCertificateID = Value
            End Set
        End Property
        Public Property Certificate() As String
            Get
                Certificate = m_strCertificate
            End Get
            Set(ByVal value As String)
                m_strCertificate = value
            End Set
        End Property
        Public Property IsLifetime() As Boolean
            Get
                IsLifetime = m_bIsLifetime
            End Get
            Set(ByVal value As Boolean)
                m_bIsLifetime = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property

        Public Function SaveVenderCertificate()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetVenderCertificateById(ByVal lVenderCertificateId As Long)
            Try
                Return MyBase.GetById(lVenderCertificateId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderCertificateView() As DataTable
            Dim str As String
            str = "select * from Certificate"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderCertificate(Optional ByVal VenderID As Long = 0) As DataTable
            Dim str As String
            If VenderID = 0 Then
                str = "select CertificateID,Certificate,IsLifetime,Status='False' from Certificate"
            Else
                str = " Select Vc.CertificateID,Vc.Certificate,IsLifetime ,Status='True' from VenderDetail VD jOIN  Certificate VC"
                str &= " ON Vd.CertificateID=Vc.CertificateID  where VD.venderID = " & VenderID
                str &= " Union"
                str &= " Select CertificateID,Certificate ,IsLifetime ,Status='False' from  Certificate"
                str &= " where  CertificateID not in(Select Vc.CertificateID from VenderDetail VD jOIN  Certificate VC"
                str &= " ON Vd.CertificateID=Vc.CertificateID where VD.venderID= " & VenderID & ")"
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCertificateOfVender(ByVal VenderID As Long) As DataTable
            Dim str As String
            str = "Select c.CertificateID, c.Certificate from VenderCertificate VC join Certificate c on c.CertificateID = VC.CertificateID where VC.VenderID = '" & VenderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCertificateOfVenderNew(ByVal VenderID As Long) As DataTable
            Dim str As String
            str = "Select VC.VenderSocialComplianceId as CertificateID, VC.Certificatename as Certificate "
            str &= " from VenderSocialCompliance VC    where VC.VenderID = '" & VenderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace