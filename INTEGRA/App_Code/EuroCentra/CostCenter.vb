Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CostCenter
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CostCenter"
            m_strPrimaryFieldName = "CostCenterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCostCenterID As Long
        Private m_strCost As String
        Private m_lCategoryID As Long
        Public Property CostCenterID() As Long
            Get
                CostCenterID = m_lCostCenterID
            End Get
            Set(ByVal Value As Long)
                m_lCostCenterID = Value
            End Set
        End Property
        Public Property Cost() As String
            Get
                Cost = m_strCost
            End Get
            Set(ByVal value As String)
                m_strCost = value
            End Set
        End Property
        Public Property CategoryID() As Long
            Get
                CategoryID = m_lCategoryID
            End Get
            Set(ByVal Value As Long)
                m_lCategoryID = Value
            End Set
        End Property
        Public Function SaveCost()
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
        Public Function GetCategory() As DataTable
            Dim str As String
            str = " Select * from CostingCategory "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = " Select * from CostCenter cc"
            str &= " join CostingCategory ct on ct.CategoryID =cc.CategoryID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal CostCenterID As Long) As DataTable
            Dim str As String
            str = " Select * from CostCenter cc"
            str &= " join CostingCategory ct on ct.CategoryID =cc.CategoryID"
            str &= " where cc.CostCenterID='" & CostCenterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class

End Namespace
