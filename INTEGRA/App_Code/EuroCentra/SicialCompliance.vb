Imports System.Data

Namespace EuroCentra
    Public Class VenderSocialCompliance
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderSocialCompliance"
            m_strPrimaryFieldName = "VenderSocialComplianceID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lVenderSocialComplianceID As Long
        Private m_lVenderID As Long
        Private m_StrCertificateNameName As String
        Private m_strFileName As String
        Private m_imgCertificateImage As Object
        Private m_dtCreationDate As Date
        Private m_dtExpiryDate As Date

        Public Property VenderSocialComplianceID() As Long
            Get
                VenderSocialComplianceID = m_lVenderSocialComplianceID
            End Get
            Set(ByVal value As Long)
                m_lVenderSocialComplianceID = value
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
        Public Property CertificateName() As String
            Get
                CertificateName = m_StrCertificateNameName
            End Get
            Set(ByVal Value As String)
                m_StrCertificateNameName = Value
            End Set
        End Property
        Public Property FileName() As String
            Get
                FileName = m_strFileName
            End Get
            Set(ByVal Value As String)
                m_strFileName = Value
            End Set
        End Property
        Public Property CertificateImage() As Object
            Get
                CertificateImage = m_imgCertificateImage
            End Get
            Set(ByVal Value As Object)
                m_imgCertificateImage = Value
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
        Public Property ExpiryDate() As Date
            Get
                ExpiryDate = m_dtExpiryDate
            End Get
            Set(ByVal value As Date)
                m_dtExpiryDate = value
            End Set
        End Property

        Public Function SaveVenderSocialCompliance()
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

            str = "Select VenderSocialComplianceID,Certificate From VenderSocialCompliance VC Join Certificate C On C.CertificateID=VC.CertificateID where venderID=" & VenderID
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
            str = "select * from VenderSocialCompliance where VenderID='" & VenderID & "' and CertificateID='" & CertificateID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCertificateData() As DataTable
            Dim str As String
            str = "select * from VenderSocialCompliance VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function getCertificateSupplierData(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select * from VenderSocialCompliance VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= " where V.Venderlibraryid=" & VenderID
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getCertificateDistinctSupplier() As DataTable
            Dim str As String
            str = "select Distinct V.Venderlibraryid,V.Vendername  from VenderSocialCompliance VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getVendorCertificateInfo(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select Distinct C.Certificate,C.CertificateID from VenderSocialCompliance VC join Vender v on v.Venderlibraryid=VC.Venderid join Certificate C on C.CertificateID=VC.CertificateID "
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
            str &= " (select distinct VC.Venderid from VenderSocialCompliance VC )"
            str &= " order by V.vendername asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFileInfoNew(ByVal VenderID As Long)
            Dim str As String
            str = "   Select * ,convert(varchar,ExpiryDate,103)as ExpiryDatee,convert(varchar,Creationdate,103)as Creationdatee from VenderSocialCompliance where VenderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteStyleUploadDetailTable()
            Dim str As String
            str = " delete from VenderSocialCompliance where VenderID='0' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteStyleUploadTableonAddPage(ByVal VenderSocialComplianceID As Long, ByVal VenderID As Long)
            Dim str As String
            str = "  delete from   VenderSocialCompliance where   VenderSocialComplianceID =' " & VenderSocialComplianceID & " ' and VenderID='" & VenderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShowFIleNew(ByVal VenderSocialComplianceID As Long, ByVal VenderID As Long)
            Dim str As String
            str = "  Select * from VenderSocialCompliance where VenderSocialComplianceID=" & VenderSocialComplianceID
            str &= " and VenderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace
