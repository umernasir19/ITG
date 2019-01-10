Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSTransactionMethod
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSTransactionMethod"
            m_strPrimaryFieldName = "TransactionMethodID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lTransactionMethodID As Long
        Private m_dtCreationDate As Date
        Private m_lIMSItemID As Long
        Dim m_strTransactionMethod As String
        Public Property TransactionMethodID() As Long
            Get
                TransactionMethodID = m_lTransactionMethodID
            End Get
            Set(ByVal Value As Long)
                m_lTransactionMethodID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property IMSItemID() As Long
            Get
                IMSItemID = m_lIMSItemID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemID = Value
            End Set
        End Property
        Public Property TransactionMethod() As String
            Get
                TransactionMethod = m_strTransactionMethod
            End Get
            Set(ByVal Value As String)
                m_strTransactionMethod = Value
            End Set
        End Property
        Public Function SaveIMSTransactionMethod()
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
        Public Function Edit(ByVal TransactionMethodID As Long) As DataTable
            Dim str As String
            str = " Select * from IMSTransactionMethod where TransactionMethodID=" & TransactionMethodID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewAll() As DataTable
            Dim str As String
            str = " Select * from IMSTransactionMethod IMS_TM"
            str &= " join IMSItem IMS_I on IMS_TM.IMSItemID=IMS_I.IMSItemID"
            str &= " order by IMS_TM.TransactionMethodID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function AutoUpdate() As DataTable
            Dim str As String
            str = " Select * from IMSItem where IMSItemID not in (Select distinct IMSItemID from IMSTransactionMethod)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Exist(ByVal IMSItemID As String) As DataTable
            Dim str As String
            str = " Select * from IMSTransactionMethod where IMSItemID=" & IMSItemID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace