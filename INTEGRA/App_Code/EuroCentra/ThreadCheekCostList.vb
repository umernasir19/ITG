Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class ThreadCheckCostList
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ThreadCheckCostList"
            m_strPrimaryFieldName = "ThreadCheckCostListID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lThreadCheckCostListID As Long
        Private m_lThreadCheckListID As Long
        Private m_lJobOrderID As Long
        Private m_lAccCheckListCostMstID As Long
        Private m_dUnitPrice As Decimal
        Public Property UnitPrice() As Decimal
            Get
                UnitPrice = m_dUnitPrice
            End Get
            Set(ByVal Value As Decimal)
                m_dUnitPrice = Value
            End Set
        End Property
        Public Property ThreadCheckCostListID() As Long
            Get
                ThreadCheckCostListID = m_lThreadCheckCostListID
            End Get
            Set(ByVal Value As Long)
                m_lThreadCheckCostListID = Value
            End Set
        End Property
        Public Property ThreadCheckListID() As Long
            Get
                ThreadCheckListID = m_lThreadCheckListID
            End Get
            Set(ByVal Value As Long)
                m_lThreadCheckListID = Value
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
        Public Function SaveThreadCheckListCostDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccThreadDtlEdit(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = " select  * from  ThreadCheckCostList AM "
            str &= " JOIN ThreadCheckList AD ON AD.ThreadCheckListID=AM.ThreadCheckListID"
            str &= " left JOIN ImsItem IM ON IM.ImsItemid=AD.Itemid"
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccZipperDtlEdit(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = "  select  * from  ZipperCheckListCostDetail AM "
            str &= "  JOIN ZipperCheckListDetail AD ON AD.ZipperCheckListDetailID=AM.ZipperCheckListDetailID"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left JOIN ImsItem IM ON IM.ImsItemid=AD.IMSItemId "
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace