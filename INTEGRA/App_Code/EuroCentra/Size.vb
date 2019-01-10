Imports System.Data

Namespace EuroCentra
    Public Class Size
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Size"
            m_strPrimaryFieldName = "SizeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lSizeID As Long
        Private m_strSizeDescription As String
        Private m_bIsActive As Boolean


        Public Property SizeID() As Long
            Get
                SizeID = m_lSizeID
            End Get
            Set(ByVal Value As Long)
                m_lSizeID = Value
            End Set
        End Property
        Public Property SizeDescription() As String
            Get
                SizeDescription = m_strSizeDescription
            End Get
            Set(ByVal value As String)
                m_strSizeDescription = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property

        Public Function SaveSize()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetSizeById(ByVal lSizeId As Long)
            Try
                Return MyBase.GetById(lSizeId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeData(ByVal Size As Integer) As DataTable
            Dim str As String
            str = "Select * from Size where SizeID=" & Size
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSize() As DataTable
            Dim str As String
            str = "Select SizeID,SizeDescription from Size "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace