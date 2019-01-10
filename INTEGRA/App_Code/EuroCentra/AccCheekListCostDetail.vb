Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class AccCheekListCostDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccCheckListCostDetail"
            m_strPrimaryFieldName = "AccCheckListCostDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccCheckListCostDetailID As Long
        Private m_lAccCheckListDetailID As Long
        Private m_dUnitPrice As Decimal
        Private m_lJobOrderID As Long
        Private m_lAccCheckListCostMstID As Long
        Public Property AccCheckListCostDetailID() As Long
            Get
                AccCheckListCostDetailID = m_lAccCheckListCostDetailID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListCostDetailID = Value
            End Set
        End Property
        Public Property AccCheckListDetailID() As Long
            Get
                AccCheckListDetailID = m_lAccCheckListDetailID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListDetailID = Value
            End Set
        End Property
        Public Property UnitPrice() As Decimal
            Get
                UnitPrice = m_dUnitPrice
            End Get
            Set(ByVal Value As Decimal)
                m_dUnitPrice = Value
            End Set
        End Property
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property AccCheckListCostMstID() As Long
            Get
                AccCheckListCostMstID = m_lAccCheckListCostMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListCostMstID = Value
            End Set
        End Property
        Public Function SaveAccCheckListCostDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccDtlEdit(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = " select  * from  AccCheckListCostDetail AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListDetailID=AM.AccCheckListDetailID"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace