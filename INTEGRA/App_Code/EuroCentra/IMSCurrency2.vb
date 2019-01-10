Imports System.Data.SqlClient
Imports System.Text
Imports System.Data

Namespace EuroCentra
    Public Class IMSCurrency2
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSCurrency"
            m_strPrimaryFieldName = "IMSCurrencyID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Dim m_lIMSCurrencyID As Long
        Dim m_strCurrencyName As String
        Dim m_bIsActive As Boolean
        Public Property IMSCurrencyID() As Long
            Get
                IMSCurrencyID = m_lIMSCurrencyID
            End Get
            Set(ByVal Value As Long)
                m_lIMSCurrencyID = Value
            End Set
        End Property
        Public Property CurrencyName() As String
            Get
                CurrencyName = m_strCurrencyName
            End Get
            Set(ByVal Value As String)
                m_strCurrencyName = Value
            End Set
        End Property
        Public Property IsActive() As String
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal Value As String)
                m_bIsActive = Value
            End Set
        End Property
        Public Function SaveIMSCurrency()
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
        Public Function GetIMSCurrencybyID(ByVal IMSCurrencyID As Long)
            Dim Str As String
            Str = "select * from IMSCurrency where IMSCurrencyID=" & IMSCurrencyID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetIMSCurrencyAll()
            Dim Str As String
            Str = "select * from IMSCurrency "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetail(ByVal IMSCurrencyID As Long)
            Dim Str As String
            Str = "Delete IMSCurrency where IMSCurrencyID=" & IMSCurrencyID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal CurrencyName As String)
            Dim Str As String
            Str = " select * from IMSCurrency  where   CurrencyName like '" & CurrencyName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingEdit(ByVal IMSCurrencyID As Long, ByVal CurrencyName As String)
            Dim Str As String
            Str = " select * from IMSCurrency  where IMSCurrencyID <>" & IMSCurrencyID & " and CurrencyName like '" & CurrencyName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace