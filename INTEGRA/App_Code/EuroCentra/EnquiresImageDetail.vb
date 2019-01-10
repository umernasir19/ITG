
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Namespace EuroCentra
    Public Class EnquiresImageDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiresImageDetail"
            m_strPrimaryFieldName = "EnquiresImageDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lEnquiresImageDetailID As Long
        Private m_lEnquiriesSystemID As Long
        Private m_strFileName As String
        Private m_strFileDescription As String
        Private m_UploadPicture As Object
        Private m_strFileNameWr As String
        Public Property EnquiresImageDetailID() As Long
            Get
                EnquiresImageDetailID = m_lEnquiresImageDetailID
            End Get
            Set(ByVal value As Long)
                m_lEnquiresImageDetailID = value
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
        Public Property FileName() As String
            Get
                FileName = m_strFileName
            End Get
            Set(ByVal value As String)
                m_strFileName = value
            End Set
        End Property
        Public Property FileDescription() As String
            Get
                FileDescription = m_strFileDescription
            End Get
            Set(ByVal value As String)
                m_strFileDescription = value
            End Set
        End Property
     
        Public Property UploadPicture() As Object
            Get
                UploadPicture = m_UploadPicture
            End Get
            Set(ByVal value As Object)
                m_UploadPicture = value
            End Set
        End Property
        Public Property FileNameWr() As String
            Get
                FileNameWr = m_strFileNameWr
            End Get
            Set(ByVal value As String)
                m_strFileNameWr = value
            End Set
        End Property
        Public Function SaveEnquiresImageUploads()
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
        Public Function ShowFIleNew(ByVal EnquiriesSystemID As Long, ByVal EnquiresImageDetailID As Long)
            Dim str As String
            str = "  Select * from EnquiresImageDetail where EnquiriesSystemID=" & EnquiriesSystemID
            str &= " and EnquiresImageDetailID=" & EnquiresImageDetailID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFileInfo(ByVal EnquiriesSystemID As Long)
            Dim str As String
            str = "   Select *   from EnquiresImageDetail where  EnquiriesSystemID =" & EnquiriesSystemID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteFile(ByVal EnquiresImageDetailID As Long, ByVal EnquiriesSystemID As Long)
            Dim str As String
            str = "  Delete  from EnquiresImageDetail where EnquiresImageDetailID=" & EnquiresImageDetailID
            str &= " and EnquiriesSystemID=" & EnquiriesSystemID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShowFIle(ByVal EnquiresImageDetailID As Long, ByVal EnquiriesSystemID As Long)
            Dim str As String
            str = "  Select * from EnquiresImageDetail where EnquiresImageDetailID=" & EnquiresImageDetailID
            str &= " and EnquiriesSystemID=" & EnquiriesSystemID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateStyleUploadTable(ByVal EnquiriesSystemID As Long)
            Dim str As String
            str = "  update  EnquiresImageDetail set  EnquiriesSystemID ='" & EnquiriesSystemID & " ' where EnquiriesSystemID='0'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteStyleUploadDetailTable()
            Dim str As String
            str = " delete from EnquiresImageDetail where EnquiriesSystemID='0' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteStyleUploadTableonAddPage(ByVal EnquiresImageDetailID As Long, ByVal EnquiriesSystemID As Long)
            Dim str As String
            str = "  delete from   EnquiresImageDetail where   EnquiresImageDetailID =' " & EnquiresImageDetailID & " ' and EnquiriesSystemID='" & EnquiriesSystemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFileInfoNew(ByVal EnquiriesSystemID As Long)
            Dim str As String
            str = "   Select *  from EnquiresImageDetail where EnquiriesSystemID=" & EnquiriesSystemID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace
