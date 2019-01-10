Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Namespace EuroCentra

    Public Class SupplierDatabaseDetail

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SupplierDatabaseDetail"
            m_strPrimaryFieldName = "SupplierDatabaseDetailId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Dim m_lSupplierDatabaseDetailId As Long
        Dim m_lSupplierDatabaseId As Long
        Dim m_strContactPerson As String
        Dim m_strCellNumber As String
        Public Property SupplierDatabaseDetailId() As Long
            Get
                SupplierDatabaseDetailId = m_lSupplierDatabaseDetailId
            End Get
            Set(ByVal Value As Long)
                m_lSupplierDatabaseDetailId = Value
            End Set
        End Property
        Public Property SupplierDatabaseId() As Long
            Get
                SupplierDatabaseId = m_lSupplierDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lSupplierDatabaseId = Value
            End Set
        End Property
        Public Property ContactPerson() As String
            Get
                ContactPerson = m_strContactPerson
            End Get
            Set(ByVal Value As String)
                m_strContactPerson = Value
            End Set
        End Property
        Public Property CellNumber() As String
            Get
                CellNumber = m_strCellNumber
            End Get
            Set(ByVal Value As String)
                m_strCellNumber = Value
            End Set
        End Property
        Public Function SaveSupplierDatabaseDetail()
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
        Public Function DeleteDetail(ByVal SupplierDatabaseDetailId As Long)
            Dim Str As String
            Str = "Delete SupplierDatabaseDetail where SupplierDatabaseDetailId=" & SupplierDatabaseDetailId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace

