Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class BudgetCreateMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BudgetCreateMaster"
            m_strPrimaryFieldName = "BudgetCreateMasterId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBudgetCreateMasterId As Long
        Private m_dtCreationDate As Date
        Private m_dtBudgetCreationDate As Date
        Private m_strMonth As String
        Private m_strYear As String
        Private m_dRemittance As Decimal
        Public Property BudgetCreateMasterId() As Long
            Get
                BudgetCreateMasterId = m_lBudgetCreateMasterId
            End Get
            Set(ByVal value As Long)
                m_lBudgetCreateMasterId = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property BudgetCreationDate() As Date
            Get
                BudgetCreationDate = m_dtBudgetCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtBudgetCreationDate = value
            End Set
        End Property
        Public Property Month() As String
            Get
                Month = m_strMonth
            End Get
            Set(ByVal value As String)
                m_strMonth = value
            End Set
        End Property
        Public Property Year() As String
            Get
                Year = m_strYear
            End Get
            Set(ByVal value As String)
                m_strYear = value
            End Set
        End Property
        Public Property Remittance() As Decimal
            Get
                Remittance = m_dRemittance
            End Get
            Set(ByVal value As Decimal)
                m_dRemittance = value
            End Set
        End Property

        Public Function SaveBudgetCreateMaster()
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
        Public Function GetData()
            Dim str As String
            str = "   Select  * from BudgetCreateMaster "
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteBudgetMaster(ByVal BudgetCreateMasterId)
            Dim str As String
            str = " Delete from BudgetCreateMaster where BudgetCreateMasterId=" & BudgetCreateMasterId
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteBudgetDetail(ByVal BudgetCreateMasterId)
            Dim str As String
            str = " Delete  from BudgetCreateDetail where BudgetCreateMasterId=" & BudgetCreateMasterId
            Try
                MyBase.ExecuteNonQuery(str)

            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace

