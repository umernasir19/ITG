Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class QDInspectionError
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "QDInspectionError"
            m_strPrimaryFieldName = "QDErrorID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lQDErrorID As Long
        Private m_lQDInspectionID As Long
        Private m_lErrorID As Long

        Public Property QDInspectionID() As Long
            Get
                QDInspectionID = m_lQDInspectionID
            End Get
            Set(ByVal value As Long)
                m_lQDInspectionID = value
            End Set
        End Property
        Public Property QDErrorID() As Long
            Get
                QDErrorID = m_lQDErrorID
            End Get
            Set(ByVal value As Long)
                m_lQDErrorID = value
            End Set
        End Property
        Public Property ErrorID() As Long
            Get
                ErrorID = m_lErrorID
            End Get
            Set(ByVal value As Long)
                m_lErrorID = value
            End Set
        End Property
        Public Function SaveQDInspectionError()
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

    End Class
End Namespace