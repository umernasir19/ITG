Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Namespace EuroCentra
    Public Class StyleUploadsTemp
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleUploadsTemp"
            m_strPrimaryFieldName = "TableID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTableID As Long
        Private m_lStyleID As Long
        Private m_strFileName As String
        Private m_strFileType As String
        Private m_dtCreationDate As Date
        Private m_UploadPicture As Object

        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
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
        Public Property FileType() As String
            Get
                FileType = m_strFileType
            End Get
            Set(ByVal value As String)
                m_strFileType = value
            End Set
        End Property
        Public Property TableID() As Long
            Get
                TableID = m_lTableID
            End Get
            Set(ByVal value As Long)
                m_lTableID = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
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
        Public Function SaveStyleUploads()
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
        Public Function GetFileInfoNew(ByVal StyleID As Long)
            Dim str As String
            str = "   Select * ,convert(varchar,Creationdate,103)as Creationdatee from StyleUploads where StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFileInfo(ByVal StyleID As Long)
            Dim str As String
            str = "   Select * from StyleUploadsTemp where StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteFile(ByVal ID As Long, ByVal StyleID As Long)
            Dim str As String
            str = "  Delete  from StyleUploads where TableID=" & ID
            str &= " and StyleID=" & StyleID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShowFIle(ByVal ID As Long, ByVal StyleID As Long)
            Dim str As String
            str = "  Select * from StyleUploads where TableID=" & ID
            str &= " and StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Deletetble()
            Dim str As String
            str = "truncate table StyleUploadsTemp "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function All()
            Dim str As String
            str = "  Select * from StyleUploadsTemp "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShowFIleNew(ByVal TableID As Long, ByVal StyleID As Long)
            Dim str As String
            str = "  Select * from StyleUploads where TableID=" & TableID
            str &= " and StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace