Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class ZipperCheckListCostDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ZipperCheckListCostDetail"
            m_strPrimaryFieldName = "ZipperCheckListCostDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lZipperCheckListCostDetailID As Long
        Private m_lZipperCheckListDetailID As Long
        Private m_dUnitPrice As Decimal
        Private m_lJobOrderID As Long
        Private m_lAccCheckListCostMstID As Long
        Public Property ZipperCheckListCostDetailID() As Long
            Get
                ZipperCheckListCostDetailID = m_lZipperCheckListCostDetailID
            End Get
            Set(ByVal Value As Long)
                m_lZipperCheckListCostDetailID = Value
            End Set
        End Property
        Public Property ZipperCheckListDetailID() As Long
            Get
                ZipperCheckListDetailID = m_lZipperCheckListDetailID
            End Get
            Set(ByVal Value As Long)
                m_lZipperCheckListDetailID = Value
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
