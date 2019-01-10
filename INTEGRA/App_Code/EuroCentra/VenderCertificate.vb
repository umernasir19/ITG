Imports System.Data

Namespace EuroCentra
    Public Class VenderCertificate
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderCertificate"
            m_strPrimaryFieldName = "VenderCertificateID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lVenderCertificateID As Long
        Private m_lVenderID As Long
        Private m_imgCertificateImage As Object
        Private m_dtCertificateExpire As String
        Private m_lCertificateID As Long
        Public Property CertificateImage() As Object
            Get
                CertificateImage = m_imgCertificateImage
            End Get
            Set(ByVal value As Object)
                m_imgCertificateImage = value
            End Set
        End Property

        Public Property VenderCertificateID() As Long
            Get
                VenderCertificateID = m_lVenderCertificateID
            End Get
            Set(ByVal Value As Long)
                m_lVenderCertificateID = Value
            End Set
        End Property
        Public Property Venderid() As Long
            Get
                Venderid = m_lVenderID
            End Get
            Set(ByVal value As Long)
                m_lVenderID = value
            End Set
        End Property

        Public Property CertificateID() As Long
            Get
                CertificateID = m_lCertificateID
            End Get
            Set(ByVal Value As Long)
                m_lCertificateID = Value
            End Set
        End Property
        Public Property CertificateExpire() As String
            Get
                CertificateExpire = m_dtCertificateExpire
            End Get
            Set(ByVal value As String)
                m_dtCertificateExpire = value
            End Set
        End Property


        Public Function SaveVenderCertificate()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetVenderDetailById(ByVal lVenderId As Long)
            Try
                Return MyBase.GetById(lVenderId)
            Catch ex As Exception

            End Try
        End Function
        Public Function RemovePreStarus(ByVal VenderID As Integer)
            Dim str As String
            str = "Delete VenderDetail where VenderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getData(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select * from VenderDetail where VenderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCertificateByVender(ByVal VenderID As Integer) As DataTable
            Dim str As String

            str = "Select VenderCertificateID,Certificate From VenderCertificate VC Join Certificate C On C.CertificateID=VC.CertificateID where venderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function RecordExist() As Boolean
            Dim str As String
            str = "select * from VenderDetail where VenderID=" & Me.m_lVenderID & " "
            Try
                Return MyBase.IsRecordExists(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getDataa(ByVal VenderID As Integer, ByVal CertificateID As Integer) As DataTable
            Dim str As String
            str = "select * from VenderCertificate where VenderID='" & VenderID & "' and CertificateID='" & CertificateID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getDataaNewNew(ByVal MEID As Integer, ByVal AttachmentlistID As Integer) As DataTable
            Dim str As String
            str = "select * from MEAttachment where MEID='" & MEID & "' and AttachmentlistID='" & AttachmentlistID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getDataaNew(ByVal VenderID As Integer, ByVal CertificateID As Integer) As DataTable
            Dim str As String
            str = "select * from VenderSocialCompliance where VenderID='" & VenderID & "' and VenderSocialComplianceId='" & CertificateID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCertificateData() As DataTable
            Dim str As String
            str = "select * from VenderCertificate VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCertificateDataNew() As DataTable
            Dim str As String
            str = "select * from VenderSocialCompliance VC "
            str &= " join Vender v on v.Venderlibraryid=VC.Venderid order by V.vendername asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function getCertificateSupplierData(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select * from VenderCertificate VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= " where V.Venderlibraryid=" & VenderID
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCertificateDistinctSupplier() As DataTable
            Dim str As String
            str = "select Distinct V.Venderlibraryid,V.Vendername  from VenderCertificate VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getVendorCertificateInfo(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select Distinct C.Certificate,C.CertificateID from VenderCertificate VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= "  where v.Venderlibraryid='" & VenderID & "' "
            str &= " order by C.Certificate asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function NoCertificate() As DataTable
            Dim str As String
            str = " Select distinct V.Vendername from   Vender v "
            str &= " join Purchaseorder Po on Po.Supplierid=v.Venderlibraryid "
            str &= " where Year(Po.Shipmentdate)>=2013 and v.Venderlibraryid  not in"
            str &= " (select distinct VC.Venderid from VenderCertificate VC )"
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        
    End Class
End Namespace