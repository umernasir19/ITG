Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class tblCPRequirmen
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblCPRequirmen"
            m_strPrimaryFieldName = "CPRequirmentId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCPRequirmentId As Long
        Private m_strCPRequirmen As String

        Public Property CPRequirmentId() As Long
            Get
                CPRequirmentId = m_lCPRequirmentId
            End Get
            Set(ByVal value As Long)
                m_lCPRequirmentId = value
            End Set
        End Property
        Public Property CPRequirmen() As String
            Get
                CPRequirmen = m_strCPRequirmen
            End Get
            Set(ByVal value As String)
                m_strCPRequirmen = value
            End Set
        End Property
        Public Function SavetblCPRequirmen()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal CPRequirmentId As Long)
            Dim Str As String
            Str = "select * from tblCPRequirmen where CPRequirmentId = '" & CPRequirmentId & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from tblCPRequirmen  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal CPRequirmentId As Long)
            Dim Str As String
            Str = "delete from tblCPRequirmen where CPRequirmentId='" & CPRequirmentId & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
