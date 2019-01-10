Imports System.Data

Namespace EuroCentra
    Public Class CustomerAttachment
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "MEAttachment"
            m_strPrimaryFieldName = "AttachmentID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_AttachmentID As Long
        Private m_AttachmentListID As Long
        Private m_MEID As Long
        Private m_AttachmentFile As Object
        Private m_Description As String
        Private m_CreationDate As DateTime
        Private m_UserID As Long
        Public Property AttachmentID() As Long
            Get
                AttachmentID = m_AttachmentID
            End Get
            Set(ByVal value As Long)
                m_AttachmentID = value
            End Set
        End Property
        Public Property AttachmentListID() As Long
            Get
                AttachmentListID = m_AttachmentListID
            End Get
            Set(ByVal value As Long)
                m_AttachmentListID = value
            End Set
        End Property
        Public Property MEID() As Long
            Get
                MEID = m_MEID
            End Get
            Set(ByVal value As Long)
                m_MEID = value
            End Set
        End Property
        Public Property AttachmentFile() As Object
            Get
                AttachmentFile = m_AttachmentFile
            End Get
            Set(ByVal value As Object)
                m_AttachmentFile = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property
        Public Property CreationDate() As DateTime
            Get
                CreationDate = m_CreationDate
            End Get
            Set(ByVal value As DateTime)
                m_CreationDate = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_UserID
            End Get
            Set(ByVal value As Long)
                m_UserID = value
            End Set
        End Property
        Public Function SaveCustomerAttachment()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataa(ByVal CustomerID As Integer, ByVal CustomerAttachmentListID As Integer) As DataTable
            Dim str As String
            str = "select * from CustomerAttachment where CustomerID='" & CustomerID & "' and CustomerAttachmentListID='" & CustomerAttachmentListID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetviewCertfcte(ByVal MEID As Long) As DataTable
            Dim str As String
            str = " select CONVERT(Varchar,CreationDate,103)as CreationDatee,  * from MEAttachment  VC "
            str &= "join AttachmentList cc on cc.AttachmentListID=vc.AttachmentListID "
            str &= "join umuser u on u.userid=vc.Userid "
            str &= " where vc.MEID=" & MEID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deleteCertficate(ByVal AttachmentListID As Integer)
            Dim str As String
            str = "Delete from AttachmentList where AttachmentListID=" & AttachmentListID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace