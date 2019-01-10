Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class QDInspectionErrorMinor
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "QDInspectionErrorMinor"
            m_strPrimaryFieldName = "QDErrorMinorID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lQDErrorMinorID As Long
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
        Public Property QDErrorMinorID() As Long
            Get
                QDErrorMinorID = m_lQDErrorMinorID
            End Get
            Set(ByVal value As Long)
                m_lQDErrorMinorID = value
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