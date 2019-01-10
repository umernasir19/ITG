Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class SizeRangeDB
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SizeRangeDB"
            m_strPrimaryFieldName = "SizeRangeDBID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_SizeRangeDBID As Long
        Private m_SizeRange As String
        Private m_Sizes As String

        Public Property SizeRangeDBID() As Long
            Get
                SizeRangeDBID = m_SizeRangeDBID
            End Get
            Set(ByVal value As Long)
                m_SizeRangeDBID = value
            End Set
        End Property
        Public Property SizeRange() As String
            Get
                SizeRange = m_SizeRange
            End Get
            Set(ByVal value As String)
                m_SizeRange = value
            End Set
        End Property
        Public Property Sizes() As String
            Get
                Sizes = m_Sizes
            End Get
            Set(ByVal value As String)
                m_Sizes = value
            End Set
        End Property
        Public Function SaveSizeRangeDB()
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
        Public Function GetAll(ByVal SizeRangeDBID As String)
            Dim Str As String
            Str = "select * from SizeRangeDB where SizeRangeDBID = '" & SizeRangeDBID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        
        Public Function DeleteDetail(ByVal SizeRangeDBID As String) As DataTable
            Dim str As String
            str = " Delete from SizeRangeDB where  SizeRangeDBID ='" & SizeRangeDBID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllh() As DataTable
            Dim Str As String
            Str = "select * from SizeRangeDB "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace