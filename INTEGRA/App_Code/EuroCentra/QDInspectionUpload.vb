Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class QDInspectionUpload
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "QDInspectionUpload"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lID As Long
        Private m_dtCreationDate As Date
        Private m_lPOID As Long
        Private m_strFileName As String
        Private m_strFileByte As Object

        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal value As Long)
                m_lID = value
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
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
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
        Public Property FileByte() As Object
            Get
                FileByte = m_strFileByte
            End Get
            Set(ByVal value As Object)
                m_strFileByte = value
            End Set
        End Property
        Public Function SaveQDInspectionUpload()
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
        Public Function GetFileInfo(ByVal POID As Long)
            Dim str As String
            str = "   Select * from QDInspectionUpload where  POID =" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ShowFIle(ByVal ID As Long, ByVal POID As Long)
            Dim str As String
            str = "  Select * from QDInspectionUpload where ID=" & ID
            str &= " and POID=" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function DeleteFile(ByVal ID As Long, ByVal POID As Long)
            Dim str As String
            str = "  Delete  from QDInspectionUpload where ID=" & ID
            str &= " and POID=" & POID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace