
Imports System.Data
Namespace EuroCentra
    Public Class DPItemDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPItemDatabase"
            m_strPrimaryFieldName = "DPItemDatabaseID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_DPItemDatabaseID As Long
        Private m_DPItemName As String

        Public Property DPItemDatabaseID() As Long
            Get
                DPItemDatabaseID = m_DPItemDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_DPItemDatabaseID = Value
            End Set
        End Property
        Public Property DPItemName() As String
            Get
                DPItemName = m_DPItemName
            End Get
            Set(ByVal value As String)
                m_DPItemName = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function Deletedetail(ByVal DPRNDAccessDetailID As Long)
            Dim str As String
            str = " Delete  from DPRNDAccessDetail where DPRNDAccessDetailID ='" & DPRNDAccessDetailID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function

        Function DeleteStyledetail(ByVal DPRNDStyleDetailID As Long)
            Dim str As String
            str = " Delete  from DPRNDStyleDetail where DPRNDStyleDetailID ='" & DPRNDStyleDetailID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
