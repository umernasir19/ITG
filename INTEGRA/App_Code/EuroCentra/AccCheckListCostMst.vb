Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class AccCheckListCostMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccCheckListCostMst"
            m_strPrimaryFieldName = "AccCheckListCostMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccCheckListCostMstID As Long
        Private m_lJoborderID As Long
        Private m_dCheckDate As Date
        Private m_dCreationDate As Date
        Public Property AccCheckListCostMstID() As Long
            Get
                AccCheckListCostMstID = m_lAccCheckListCostMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListCostMstID = Value
            End Set
        End Property
       
        Public Property JoborderID() As Long
            Get
                JoborderID = m_lJoborderID
            End Get
            Set(ByVal Value As Long)
                m_lJoborderID = Value
            End Set
        End Property
  
        Public Property CheckDate() As Date
            Get
                CheckDate = m_dCheckDate
            End Get
            Set(ByVal Value As Date)
                m_dCheckDate = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dCreationDate = Value
            End Set
        End Property
        Public Function SaveAccCheckListMst()
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
        Public Function GetEdit(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListCostMst AM "
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
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
        Public Function GetAccDtlNew(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = " select '0' as AccCheckListCostDetailID,'0' as UnitPrice,* from  AccCheckListMst AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccThreadDtl(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = " select '0' as ThreadCheckCostListID,'0' as UnitPrice,* from  AccCheckListMst AM "
            str &= " JOIN ThreadCheckList AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left JOIN ImsItem IM ON IM.ImsItemid=AD.Itemid"
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccZipperDtl(ByVal JoborderID As Long) As DataTable
            Dim str As String
            str = " select '0' as ZipperCheckListCostDetailID,'0' as UnitPrice,* from  AccCheckListMst AM "
            str &= " JOIN ZipperCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left JOIN ImsItem IM ON IM.ImsItemid=AD.IMSItemid"
            str &= " WHERE AM.JoborderID = '" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
