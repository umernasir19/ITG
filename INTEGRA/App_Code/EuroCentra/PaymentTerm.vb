Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class PaymentTerm
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PaymentTerm"
            m_strPrimaryFieldName = "PaymentTermID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPaymentTermID As Long
        Private m_strPaymentTerm As String
        Public Property PaymentTermID() As Long
            Get
                PaymentTermID = m_lPaymentTermID
            End Get
            Set(ByVal Value As Long)
                m_lPaymentTermID = Value
            End Set
        End Property
        Public Property PaymentTerm() As String
            Get
                PaymentTerm = m_strPaymentTerm
            End Get
            Set(ByVal value As String)
                m_strPaymentTerm = value
            End Set
        End Property
        Public Function SavePaymentTerm()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function

        Public Function Edit(ByVal PaymentTermID As Long) As DataTable
            Dim str As String
            str = " Select * from PaymentTerm where PaymentTermID=" & PaymentTermID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = " Select * from PaymentTerm  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPaymentTerm() As DataTable
            Dim str As String
            str = " Select * from PaymentTerm "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace