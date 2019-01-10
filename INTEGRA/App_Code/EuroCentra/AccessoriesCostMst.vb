Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class AccessoriesCostMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccessoriesCostMst"
            m_strPrimaryFieldName = "AccessoriesCostMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccessoriesCostMstID As Long
        Private m_lJobOrderId As Long
        Private m_strJobOrderNo As String
        Private m_strItem As String
        Private m_strStyle As String
        Private m_DCQuantity As Decimal
        Private m_DCTGross As Decimal
        Private m_DCGrossAmount As Decimal
        Private m_strMiscellaneous As String
        Private m_dMisRate As Decimal

        Public Property AccessoriesCostMstID() As Long
            Get
                AccessoriesCostMstID = m_lAccessoriesCostMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccessoriesCostMstID = Value
            End Set
        End Property
        Public Property JobOrderId() As Long
            Get
                JobOrderId = m_lJobOrderId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderId = Value
            End Set
        End Property

        Public Property JobOrderNo() As String
            Get
                JobOrderNo = m_strJobOrderNo
            End Get
            Set(ByVal Value As String)
                m_strJobOrderNo = Value
            End Set
        End Property
        Public Property Item() As String
            Get
                Item = m_strItem
            End Get
            Set(ByVal Value As String)
                m_strItem = Value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal Value As String)
                m_strStyle = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_DCQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_DCQuantity = Value
            End Set
        End Property

        Public Property TGross() As Decimal
            Get
                TGross = m_DCTGross
            End Get
            Set(ByVal Value As Decimal)
                m_DCTGross = Value
            End Set
        End Property
        Public Property GrossAmount() As Decimal
            Get
                GrossAmount = m_DCGrossAmount
            End Get
            Set(ByVal Value As Decimal)
                m_DCGrossAmount = Value
            End Set
        End Property
        Public Property Miscellaneous() As String
            Get
                Miscellaneous = m_strMiscellaneous
            End Get
            Set(ByVal Value As String)
                m_strMiscellaneous = Value
            End Set
        End Property
        Public Property MisRate() As Decimal
            Get
                MisRate = m_dMisRate
            End Get
            Set(ByVal Value As Decimal)
                m_dMisRate = Value
            End Set
        End Property

        Public Function SaveAcCostMst()
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
        Public Function GetJobOrderData(ByVal Joborderid As Long) As DataTable
            Dim str As String
            'str = "  Select * ,(select distinct Content from StyleMasterDatabase  SM where  SM.JoborderID=JO.JoborderID) as Content"
            'str &= " ,(select Top 1 ItemDiscription from StyleMasterDatabase  SM where  SM.JoborderID=JO.JoborderID order by SM.StyleMasterDatabaseID desc) as Item"
            'str &= " ,(select isnull(Sum(Qty),0) from StyleMasterDatabase  SM "
            'str &= " join Style_SubStyle SS on SS.StyleMasterDatabaseID=SM.StyleMasterDatabaseID"
            'str &= " where  SM.JoborderID=JO.JoborderID) as Qty"
            'str &= " from JobOrder JO"
            'str &= " left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID"
            'str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID"
            'str &= " left join CustomerDatabase CD ON JO.CustomerDatabaseID=CD.CustomerDatabaseID"
            'str &= " where JO.JoborderID='" & Joborderid & "' "

            str = "  select *  , convert(varchar,jo.OrderRecvDate ,103) as ReceivedDate ,(select isnull(Sum(QUANTITY),0) from JobOrderdatabase  SM  "
            str &= " join JobOrderdatabaseDetail SS on SS.JoborderID=SM.JoborderID"
            str &= " where  SM.JoborderID=JO.JoborderID) as Qty from JobOrderdatabase JO JOIN JobOrderdatabaseDetail JD  ON JO.JoborderID=JD.JoborderID"
            str &= " left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID "
            str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID "
            str &= " left join Customer CD ON JO.CustomerDatabaseID=CD.CustomerID  "
            str &= " left JOIN ITEMDATABASE ITD ON ITD.ItemDatabaseId=JD.ItemDatabaseId "
            str &= " where JO.JoborderID='" & Joborderid & "' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUnit() As DataTable
            Dim str As String
            str = " Select * from  IMSItemUnit "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUnitNEW() As DataTable
            Dim str As String
            str = " Select * from  IMSItemUnit where ItemUnitId=12 or ItemUnitId=3 or  ItemUnitId=15 or  ItemUnitId=2 or  ItemUnitId=7 order by Symbol "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetACCSCATcLASS() As DataTable
            Dim str As String
            'str = " Select distinct AG.IMSItemClassID, AG.ItemClassName  from Accessories  A "
            'str &= " join IMSItemClass AG on AG.IMSItemClassID=A.AccessoriesCategoryID "
            str = " Select * from IMSItemCategory IMS_IC "
            str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            str &= " join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            str &= " where ST.StoreTypeID =2 order by IMS_IC.ItemCategoryName asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetImsItem(ByVal IMSItemClassID As Long) As DataTable
            Dim str As String
            str = " Select it.IMSItemId,ItemName    from IMSItem it join Accessories a "
            str &= " on a.IMSItemId=it.ImsItemId where  it.IMSItemClassId='" & IMSItemClassID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetImsItemNew(ByVal IMSItemCategoryID As Long) As DataTable
            Dim str As String
            'str = " Select a.Accessoriesid,ItemName    from IMSItem it join Accessories a "
            'str &= " on a.IMSItemId=it.ImsItemId where  it.IMSItemClassId='" & IMSItemClassID & "' "
            str = "select * from IMSItem WHERE IMSItemCategoryID='" & IMSItemCategoryID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItem(ByVal ItemName As String) As DataTable
            Dim str As String
            str = " Select *  from IMSItem it join Accessories ac on ac.IMSItemid=it.IMSItemid where  it.ItemName='" & ItemName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItembYiD(ByVal IMSItemid As Long) As DataTable
            Dim str As String
            str = " Select *  from IMSItem it join Accessories ac on ac.IMSItemid=it.IMSItemid where  it.IMSItemid='" & IMSItemid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItembYiDAcc(ByVal Accessoriesid As Long) As DataTable
            Dim str As String
            str = " Select *  from IMSItem it join Accessories ac on ac.IMSItemid=it.IMSItemid where  ac.Accessoriesid='" & Accessoriesid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFPLANdetail(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            str = "  select * from AccessoriesCostMst FM JOIN AccessoriesCostDtl FD "
            str &= " ON FM.AccessoriesCostMstid=FD.AccessoriesCostMstid "
            str &= " join Accessories a on A.Accessoriesid=FD.Accessoriesid "
            str &= " JOIN IMSItemUnit iu on iu.ItemUnitId=FD.ItemUnitId"
            str &= "   WHERE JobOrderId='" & JobOrderIdID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFPLANdetailL(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            'str = "  select FD.Style,* from AccessoriesCostMst FM JOIN AccessoriesCostDtl FD "
            'str &= " ON FM.AccessoriesCostMstid=FD.AccessoriesCostMstid "
            'str &= " join Accessories a on A.Accessoriesid=FD.Accessoriesid "
            'str &= " JOIN IMSItemUnit iu on iu.ItemUnitId=FD.ItemUnitId"
            'str &= "   WHERE JobOrderId='" & JobOrderIdID & "' "
            str = "    select FD.Style,a.ItemName as AccessoriesName,* from AccessoriesCostMst FM "
            str &= " JOIN AccessoriesCostDtl FD  ON FM.AccessoriesCostMstid=FD.AccessoriesCostMstid  "
            str &= " join IMSItem a on A.IMSItemid=FD.Accessoriesid  "
            str &= " JOIN IMSItemUnit iu on iu.ItemUnitId=FD.ItemUnitId "
            str &= " WHERE JobOrderId='" & JobOrderIdID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
