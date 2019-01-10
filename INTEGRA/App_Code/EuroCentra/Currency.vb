Imports System.Data

Namespace EuroCentra
    Public Class Currency
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Currency"
            m_strPrimaryFieldName = "CurrencyID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_CurrencyID As Long
        Private m_strCurrencyName As String
        ''---------------- Properties
        Public Property CurrencyID() As Long
            Get
                CurrencyID = m_CurrencyID
            End Get
            Set(ByVal value As Long)
                m_CurrencyID = value
            End Set
        End Property
        Public Property CurrencyName() As String
            Get
                CurrencyName = m_strCurrencyName
            End Get
            Set(ByVal value As String)
                m_strCurrencyName = value
            End Set
        End Property
        Public Function SaveCurrency()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetCurrencyById(ByVal lCurrencyID As Long)
            Try
                Return MyBase.GetById(lCurrencyID)
            Catch ex As Exception

            End Try
        End Function
        Public Function Getalldata()
            Dim Str As String
            Str = " select * from Currency  where CurrencyID=46 OR  CurrencyID=6 OR CurrencyID=149 order by CurrencyName asc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCurrency(ByVal CurrencyName As String)
            Dim Str As String
            Str = " select * from Currency where CurrencyName ='" & CurrencyName & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace