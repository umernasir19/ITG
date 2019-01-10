Imports Microsoft.VisualBasic
Imports System.Data
Public Class BankClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BankName"
        m_strPrimaryFieldName = "BankID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lBankID As Long
    Private m_strBank As String

    Public Property BankID() As Long
        Get
            BankID = m_lBankID
        End Get
        Set(ByVal Value As Long)
            m_lBankID = Value
        End Set
    End Property
    Public Property Bank() As String
        Get
            Bank = m_strBank
        End Get
        Set(ByVal Value As String)
            m_strBank = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
   
End Class
