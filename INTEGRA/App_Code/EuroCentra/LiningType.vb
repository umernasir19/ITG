Imports System.Data
Namespace EuroCentra
    Public Class LiningType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "LiningType"
            m_strPrimaryFieldName = "LiningTypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lLiningTypeID As Long
        Private m_strLiningType As String

        Public Property LiningTypeID() As Long
            Get
                LiningTypeID = m_lLiningTypeID
            End Get
            Set(ByVal value As Long)
                m_lLiningTypeID = value
            End Set
        End Property
        Public Property LiningType() As String
            Get
                LiningType = m_strLiningType
            End Get
            Set(ByVal value As String)
                m_strLiningType = value
            End Set
        End Property

        Public Function SaveLiningType()
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
        Public Function GetLiningType() As DataTable
            Dim str As String
            str = " select   * from LiningType  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
