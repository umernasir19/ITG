Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class BankTransactionDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BankTransactionDetail"
            m_strPrimaryFieldName = "BankTransactionDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBankTransactionDetailID As Long
        Private m_lBankTransactionID As Long
        Private m_1ChartofAccountID As Long
        Private m_strNameOfPayee As String
        Private m_strHKCode As String
        Private m_strECPCode As String
        Private m_strNarration As String
        Private m_dAmount As Decimal
        Private m_strNotes As String
        Private m_strChequeNo As String

        Public Property BankTransactionDetailID() As Long
            Get
                BankTransactionDetailID = m_lBankTransactionDetailID
            End Get
            Set(ByVal value As Long)
                m_lBankTransactionDetailID = value
            End Set
        End Property
        Public Property BankTransactionID() As Long
            Get
                BankTransactionID = m_lBankTransactionID
            End Get
            Set(ByVal value As Long)
                m_lBankTransactionID = value
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
        Public Property ChequeNo() As String
            Get
                ChequeNo = m_strChequeNo
            End Get
            Set(ByVal value As String)
                m_strChequeNo = value
            End Set
        End Property
        Public Function SaveBankTransactionDetail()
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
        Function DeleteBankTrnDetail(ByVal BankTransactionDetailID As Long)
            Dim Str As String
            Str = " Delete from BankTransactionDetail where BankTransactionDetailID=" & BankTransactionDetailID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
