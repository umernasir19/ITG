Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class CashTransactionDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CashTransactionDetail"
            m_strPrimaryFieldName = "CashTransactionDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lCashTransactionDetailID As Long
        Private m_lCashTransactionID As Long
        Private m_1ChartofAccountID As Long
        Private m_strNameOfPayee As String
        Private m_strHKCode As String
        Private m_strECPCode As String
        Private m_strNarration As String
        Private m_dAmount As Decimal
        Private m_strNotes As String

        Public Property CashTransactionDetailID() As Long
            Get
                CashTransactionDetailID = m_lCashTransactionDetailID
            End Get
            Set(ByVal value As Long)
                m_lCashTransactionDetailID = value
            End Set
        End Property
        Public Property CashTransactionID() As Long
            Get
                CashTransactionID = m_lCashTransactionID
            End Get
            Set(ByVal value As Long)
                m_lCashTransactionID = value
            End Set
        End Property
        Public Property ChartofAccountID() As Long
            Get
                ChartofAccountID = m_1ChartofAccountID
            End Get
            Set(ByVal value As Long)
                m_1ChartofAccountID = value
            End Set
        End Property
        Public Property NameOfPayee() As String
            Get
                NameOfPayee = m_strNameOfPayee
            End Get
            Set(ByVal value As String)
                m_strNameOfPayee = value
            End Set
        End Property
        Public Property HKCode() As String
            Get
                HKCode = m_strHKCode
            End Get
            Set(ByVal value As String)
                m_strHKCode = value
            End Set
        End Property
        Public Property ECPCode() As String
            Get
                ECPCode = m_strECPCode
            End Get
            Set(ByVal value As String)
                m_strECPCode = value
            End Set
        End Property
        Public Property Narration() As String
            Get
                Narration = m_strNarration
            End Get
            Set(ByVal value As String)
                m_strNarration = value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dAmount
            End Get
            Set(ByVal value As Decimal)
                m_dAmount = value
            End Set
        End Property
        Public Property Notes() As String
            Get
                Notes = m_strNotes
            End Get
            Set(ByVal value As String)
                m_strNotes = value
            End Set
        End Property
        Public Function SaveCashTransactionDetail()
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



    End Class
End Namespace