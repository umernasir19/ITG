Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class EnqSupplierACP
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnqSupplierACP"
            m_strPrimaryFieldName = "EnqSupplierACPID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lEnqSupplierACPID As Long
        Private m_lEnquiriesSystemID As Long
        Private m_strFabricDate As String
        Private m_strPriceDate As String
        Private m_strProtoSampleDate As String
        Private m_strLabDipDate As String
        Private m_strPhotoSampleDate As String
        Private m_strSellerSampleDate As String
        Private m_strEnqSRemarks As String
        Public Property EnqSupplierACPID() As Long
            Get
                EnqSupplierACPID = m_lEnqSupplierACPID
            End Get
            Set(ByVal value As Long)
                m_lEnqSupplierACPID = value
            End Set
        End Property
        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_lEnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_lEnquiriesSystemID = value
            End Set
        End Property
        Public Property FabricDate() As String
            Get
                FabricDate = m_strFabricDate
            End Get
            Set(ByVal value As String)
                m_strFabricDate = value
            End Set
        End Property
        Public Property PriceDate() As String
            Get
                PriceDate = m_strPriceDate
            End Get
            Set(ByVal value As String)
                m_strPriceDate = value
            End Set
        End Property
        Public Property ProtoSampleDate() As String
            Get
                ProtoSampleDate = m_strProtoSampleDate
            End Get
            Set(ByVal value As String)
                m_strProtoSampleDate = value
            End Set
        End Property
        Public Property LabDipDate() As String
            Get
                LabDipDate = m_strLabDipDate
            End Get
            Set(ByVal value As String)
                m_strLabDipDate = value
            End Set
        End Property
        Public Property PhotoSampleDate() As String
            Get
                PhotoSampleDate = m_strPhotoSampleDate
            End Get
            Set(ByVal value As String)
                m_strPhotoSampleDate = value
            End Set
        End Property
        Public Property SellerSampleDate() As String
            Get
                SellerSampleDate = m_strSellerSampleDate
            End Get
            Set(ByVal value As String)
                m_strSellerSampleDate = value
            End Set
        End Property
        Public Property EnqSRemarks() As String
            Get
                EnqSRemarks = m_strEnqSRemarks
            End Get
            Set(ByVal value As String)
                m_strEnqSRemarks = value
            End Set
        End Property
        Public Function saveEnqSupplierACP()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Function getEditCRPSupplier(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select convert (varchar,convert(datetime,ProtoSampleDate,104),101) as ProtoSampleDatee,"
            Str &= " convert (varchar,convert(datetime,LabDipDate,104),101) as LabDipDatee,"
            Str &= " convert (varchar,convert(datetime,PhotoSampleDate,104),101) as PhotoSampleDatee,"
            Str &= " convert (varchar,convert(datetime,SellerSampleDate,104),101) as SellerSampleDatee"
            Str &= " ,*  from EnqSupplierACP ES WHERE ES.EnquiriesSystemID='" & EnquiriesSystemID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class

End Namespace

