Imports System.Data

Namespace EuroCentra
    Public Class StyleAccessoriesList
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleAccessoriesList"
            m_strPrimaryFieldName = "AccessoriesID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_AccessoriesID As Long
        Private m_AccessoriesName As String

        Public Property AccessoriesID() As Long
            Get
                AccessoriesID = m_AccessoriesID
            End Get
            Set(ByVal Value As Long)
                m_AccessoriesID = Value
            End Set
        End Property
        Public Property AccessoriesName() As String
            Get
                AccessoriesName = m_AccessoriesName
            End Get
            Set(ByVal value As String)
                m_AccessoriesName = value
            End Set
        End Property

        Public Function SaveStyleAccessoriesList()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal AccessoriesID As String)
            Dim Str As String
            Str = "select * from StyleAccessoriesList where AccessoriesID = '" & AccessoriesID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from StyleAccessoriesList  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal AccessoriesID As Long)
            Dim Str As String
            Str = " delete from StyleAccessoriesList where AccessoriesID=  '" & AccessoriesID & "'"
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function UpdateExtraQtyInCustomer(ByVal CustomerName As String, ByVal ExtraQty As Decimal)
            Dim Str As String
            Str = " update  Customer set ExtraQty ='" & ExtraQty & "'  where CustomerName=  '" & CustomerName & "'"
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace