Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class EnquiriesSystemDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiriesSystemDetail"
            m_strPrimaryFieldName = "EnquiriesSystemDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_EnquiriesSystemDetailID As Long
        Private m_EnquiriesSystemID As Long
        Private m_ArtName As String
        Private m_ArtNo As String
        Private m_Colorways As String
        Private m_MOQorQty As Decimal

        Public Property EnquiriesSystemDetailID() As Long
            Get
                EnquiriesSystemDetailID = m_EnquiriesSystemDetailID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemDetailID = value
            End Set
        End Property
        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_EnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemID = value
            End Set
        End Property
        Public Property ArtName() As String
            Get
                ArtName = m_ArtName
            End Get
            Set(ByVal value As String)
                m_ArtName = value
            End Set
        End Property
        Public Property ArtNo() As String
            Get
                ArtNo = m_ArtNo
            End Get
            Set(ByVal value As String)
                m_ArtNo = value
            End Set
        End Property
        Public Property Colorways() As String
            Get
                Colorways = m_Colorways
            End Get
            Set(ByVal value As String)
                m_Colorways = value
            End Set
        End Property
        Public Property MOQorQty() As String
            Get
                MOQorQty = m_MOQorQty
            End Get
            Set(ByVal value As String)
                m_MOQorQty = value
            End Set
        End Property
        Public Function SaveEnquiriesSystemDetail()
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
        Public Function DeleteDetailById(ByVal EnquiriesSystemDetailID As Long)
            Dim str As String = "Delete EnquiriesSystemDetail where EnquiriesSystemDetailID=" & EnquiriesSystemDetailID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
