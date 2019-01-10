Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class EnquiriesSystem
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiriesSystem"
            m_strPrimaryFieldName = "EnquiriesSystemID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_EnquiriesSystemID As Long
        Private m_CreationDate As Date
        Private m_EnqNo As String
        Private m_EnqDate As Date
        Private m_EnqType As String
        Private m_CustomerID As Long
        Private m_SupplierID As Long
        Private m_Dept As String
        Private m_Season As String
        Private m_Status As String
        Private m_ConfirmedDate As Date
        Private m_PONO As String
        Private m_Remarks As String
        Private m_MarchandID As Long

        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_EnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_CreationDate
            End Get
            Set(ByVal value As Date)
                m_CreationDate = value
            End Set
        End Property
        Public Property EnqNo() As String
            Get
                EnqNo = m_EnqNo
            End Get
            Set(ByVal value As String)
                m_EnqNo = value
            End Set
        End Property
        Public Property EnqDate() As Date
            Get
                EnqDate = m_EnqDate
            End Get
            Set(ByVal value As Date)
                m_EnqDate = value
            End Set
        End Property
        Public Property EnqType() As String
            Get
                EnqType = m_EnqType
            End Get
            Set(ByVal value As String)
                m_EnqType = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_CustomerID
            End Get
            Set(ByVal value As Long)
                m_CustomerID = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_SupplierID
            End Get
            Set(ByVal value As Long)
                m_SupplierID = value
            End Set
        End Property
        Public Property Dept() As String
            Get
                Dept = m_Dept
            End Get
            Set(ByVal value As String)
                m_Dept = value
            End Set
        End Property
        Public Property Season() As String
            Get
                Season = m_Season
            End Get
            Set(ByVal value As String)
                m_Season = value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = m_Status
            End Get
            Set(ByVal value As String)
                m_Status = value
            End Set
        End Property
        Public Property ConfirmedDate() As Date
            Get
                ConfirmedDate = m_ConfirmedDate
            End Get
            Set(ByVal value As Date)
                m_ConfirmedDate = value
            End Set
        End Property
        Public Property PONO() As String
            Get
                PONO = m_PONO
            End Get
            Set(ByVal value As String)
                m_PONO = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_Remarks
            End Get
            Set(ByVal value As String)
                m_Remarks = value
            End Set
        End Property
        Public Property MarchandID() As Long
            Get
                MarchandID = m_MarchandID
            End Get
            Set(ByVal value As Long)
                m_MarchandID = value
            End Set
        End Property
        Public Function SaveEnquiriesSystem()
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
        Function GetAll()
            Dim Str As String
            Str = " select  *,convert(varchar,ES.EnqDate,103) as EnqDatee from EnquiriesSystem ES"
            Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            Str &= " Join Customer C on C.CustomerID=ES.Customerid     "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetEdit(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select  *,convert(varchar,ES.EnqDate,103) as EnqDatee, ES.Status as ESstatus from EnquiriesSystem ES"
            Str &= " join EnquiriesSystemDetail ESD on ESD.EnquiriesSystemID=ES.EnquiriesSystemID"
            Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            Str &= " Join Customer C on C.CustomerID=ES.Customerid     "
            Str &= " where ES.EnquiriesSystemID=" & EnquiriesSystemID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function


    End Class
End Namespace