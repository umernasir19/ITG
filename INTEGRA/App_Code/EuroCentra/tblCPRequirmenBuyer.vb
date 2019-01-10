
Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class tblCPRequirmenBuyer
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblCPRequirmenBuyer"
            m_strPrimaryFieldName = "CPRequirmentBID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCPRequirmentBID As Long
        Private m_strCPRequirementB As String

        Public Property CPRequirmentBID() As Long
            Get
                CPRequirmentBID = m_lCPRequirmentBID
            End Get
            Set(ByVal value As Long)
                m_lCPRequirmentBID = value
            End Set
        End Property
        Public Property CPRequirementB() As String
            Get
                CPRequirementB = m_strCPRequirementB
            End Get
            Set(ByVal value As String)
                m_strCPRequirementB = value
            End Set
        End Property
        Public Function SaveCPRequirmenBuyer()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal CPRequirmentBID As Long)
            Dim Str As String
            Str = "select * from tblCPRequirmenBuyer where CPRequirmentBID = '" & CPRequirmentBID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from tblCPRequirmenBuyer  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal CPRequirmentBID As Long)
            Dim Str As String
            Str = "delete from tblCPRequirmenBuyer where CPRequirmentBID='" & CPRequirmentBID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
