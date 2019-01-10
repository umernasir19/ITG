Imports System.Data

Namespace EuroCentra
Public Class Buyer
  Inherits SQLManager
        Public Sub New()
            m_strTableName = "Buyer"
            m_strPrimaryFieldName = "BuyerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_BuyerID As Long
        Private m_BuyerName As String

        Public Property BuyerID() As Long
            Get
                BuyerID = m_BuyerID
            End Get
            Set(ByVal Value As Long)
                m_BuyerID = Value
            End Set
        End Property
        Public Property BuyerName() As String
            Get
                BuyerName = m_BuyerName
            End Get
            Set(ByVal value As String)
                m_BuyerName = value
            End Set
        End Property
        Public Function SaveBuyer()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal BuyerID As String)
            Dim Str As String
            Str = "select * from Buyer where BuyerID = '" & BuyerID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from Buyer"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function checkBuyer(ByVal BuyerName As String)
            Dim Str As String
            Str = "select * from Buyer where BuyerName = '" & BuyerName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
