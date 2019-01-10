Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class AccCheckListMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "AccCheckListMst"
            m_strPrimaryFieldName = "AccCheckListMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lAccCheckListMstID As Long
        Private m_lJoborderID As Long
        Private m_lJoborderDetailID As Long
        Private m_lStyleAssortmentMasterID As Long
        Private m_dCheckDate As Date
        Private m_dCreationDate As Date

        Private m_strRevisedDate As String
        Public Property RevisedDate() As String
            Get
                RevisedDate = m_strRevisedDate
            End Get
            Set(ByVal value As String)
                m_strRevisedDate = value
            End Set
        End Property
     
        Public Property AccCheckListMstID() As Long
            Get
                AccCheckListMstID = m_lAccCheckListMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListMstID = Value
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
        Public Property JoborderDetailID() As Long
            Get
                JoborderDetailID = m_lJoborderDetailID
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailID = Value
            End Set
        End Property
        Public Property StyleAssortmentMasterID() As Long
            Get
                StyleAssortmentMasterID = m_lStyleAssortmentMasterID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentMasterID = Value
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
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempAccCheckListSize"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTableSizeList()
            Dim str As String = "TRUNCATE TABLE  TempSizeWeightList"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllStyleAssortColor(ByVal JobOrderID As Long, ByVal JOBORDERDETAILID As Long) As DataTable
            Dim str As String
            str = " select sd.StyleAssortmentDetailID , SDB.Sizes as TransferLabel  "
            str &= " from StyleAssortmentMaster sm "
            str &= " join StyleAssortmentDetail sd on sm.StyleAssortmentMasterID=sd.StyleAssortmentMasterID "
            str &= " join sizedatabase SdB on SDB.sizedatabaseID=SD.sizedatabaseID  "
            str &= " join JobOrderdatabaseDetail JOd on JOd.JOBORDERDETAILID=sm.JOBORDERDETAILID"
            str &= " where sm.JobOrderID = '" & JobOrderID & "' and sm.JOBORDERDETAILID='" & JOBORDERDETAILID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckConData(ByVal JobOrderID As Long) As DataTable
            Dim str As String
            str = " select * "
            str &= " from ConMst"
            str &= " where JobOrderID = '" & JobOrderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyExistOnCopyCase(ByVal JobOrderID As Long, ByVal JobOrderDetailID As Long) As DataTable
            Dim str As String
            str = " select * "
            str &= " from AccCheckListMst"
            str &= " where JobOrderID = '" & JobOrderID & "' and JobOrderDetailID= '" & JobOrderDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleAssortmentMasterID(ByVal JobOrderID As Long, ByVal JobOrderDetailID As Long) As DataTable
            Dim str As String
            str = " select * "
            str &= " from StyleAssortmentMaster"
            str &= " where JobOrderID = '" & JobOrderID & "' and JobOrderDetailID= '" & JobOrderDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ConDataEdit(ByVal ConMstID As Long) As DataTable
            Dim str As String
            str = " select * "
            str &= " from ConMst mst join ConDtl Dtl on Dtl.ConMstID=mst.ConMstID  "
            str &= " where mst.ConMstID = '" & ConMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckSizeList(ByVal JobOrderID As Long) As DataTable
            Dim str As String
            str = " select * "
            str &= " from SizeWiseWeightListMst sm "
            str &= " where JobOrderID = '" & JobOrderID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleAssortmentDetailIDAndAssortQty(ByVal JobOrderID As Long, ByVal JOBORDERDETAILID As Long, ByVal StyleAssortmentMstid As Long, ByVal Size As String) As DataTable
            Dim str As String
            str = " select * ,(Dtl.Qty+Dtl.Asortqty+Dtl.ExtraQty) as  TotalQty"
            str &= " from StyleAssortmentMaster Mst join StyleAssortmentDetail Dtl on Dtl.StyleAssortmentMasterID=Mst.StyleAssortmentMasterID"
            str &= " where Mst.JobOrderID = '" & JobOrderID & "' and Mst.JOBORDERDETAILID='" & JOBORDERDETAILID & "' and Mst.StyleAssortmentMasterID='" & StyleAssortmentMstid & "' AND Dtl.Size='" & Size & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckMst(ByVal JobOrderID As Long, ByVal JOBORDERDETAILID As Long, ByVal StyleAssortmentMstid As Long) As DataTable
            Dim str As String
            str = " select * "
            str &= " from AccCheckListMst sm "
            str &= " where JobOrderID = '" & JobOrderID & "' and JOBORDERDETAILID='" & JOBORDERDETAILID & "' and StyleAssortmentMasterID='" & StyleAssortmentMstid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SizewiseQTY(ByVal StyleAssortmentDetailID As Long) As DataTable
            Dim str As String
            str = " Select (Qty+Asortqty+ExtraQty) as TotalQty,* from StyleAssortmentDetail where StyleAssortmentDetailID ='" & StyleAssortmentDetailID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Supplier()
            Dim str As String
            str = " select * from SupplierDatabase "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemClass()
            Dim Str As String
            Str = "  Select * From IMSItemClass "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccCategory(ByVal ItemCID As Integer)
            Dim Str As String
            Str = "  Select * from IMSItemCategory IMS_IC "
            Str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            Str &= " join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            Str &= " where ST.StoreTypeID =2 and IMS_ICL.IMSItemClassID = " & ItemCID & " "
            Str &= " order by IMS_IC.ItemCategoryName asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccCategoryForZipper(ByVal ItemCID As Integer)
            Dim Str As String
            Str = "  Select * from IMSItemCategory IMS_IC "
            Str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            Str &= " join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            Str &= " where ST.StoreTypeID =2 and IMS_IC.IMSItemClassID = " & ItemCID & " and IMS_IC.ItemCategoryName like '%zipper%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccName(ByVal IMSItemCategoryID As String)
            Dim Str As String
            Str = " select * from IMSItem IMS_I where IMSItemCategoryID='" & IMSItemCategoryID & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSizeZipper(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = "  select distinct AssortSize as Size,SizeDatabaseID from  AccCheckListMst AM "
            str &= " JOIN ZipperCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid  "
            str &= " JOIN StyleAssortmentDetail SDD ON SDD.StyleAssortmentDetailID=AD.StyleAssortmentDetailID"
            str &= " WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "' And AD.StyleAssortmentDetailId > 0"
            str &= " order by SizeDatabaseID ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJobOrderDetailId(ByVal DPIMstID As Long) As DataTable
            Dim str As String
            str = "  select jod.JoborderDetailid from DPIDtl Dtl"
            str &= " join JobOrderdatabaseDetail Jod on jod.Joborderid =Dtl.Joborderid "
            str &= " WHERE Dtl.DPIMstID = '" & DPIMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSize(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = "  select distinct AssortSize as Size,SizeDatabaseID from  AccCheckListMst AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid  "
            str &= " JOIN StyleAssortmentDetail SDD ON SDD.StyleAssortmentDetailID=AD.StyleAssortmentDetailID"
            str &= " WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "' And AD.StyleAssortmentDetailId > 0"
            str &= " order by SizeDatabaseID ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeForSizeWeightList(ByVal SizeWiseWeightListMstid As Long) As DataTable
            Dim str As String
            str = "  select AD.Size as Size from  SizeWiseWeightListMst AM "
            str &= " JOIN SizeWiseWeightListDtl AD ON AD.SizeWiseWeightListMstid=AM.SizeWiseWeightListMstid  "
            str &= " JOIN StyleAssortmentDetail SDD ON SDD.StyleAssortmentDetailID=AD.StyleAssortmentDetailID"
            str &= " WHERE AM.SizeWiseWeightListMstid = '" & SizeWiseWeightListMstid & "' And AD.SizeWiseWeightListDtlId > 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        'Public Function GetSize(ByVal AccCheckListMstID As Long) As DataTable
        '    Dim str As String
        '    str = " select distinct AssortSize as Size from  AccCheckListMst AM "
        '    str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
        '    str &= "  WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "' And StyleAssortmentDetailId > 0"
        '    Try
        '        Return MyBase.GetDataTable(str)
        '    Catch ex As Exception

        '    End Try
        'End Function
        Public Function Getdetailofsize(ByVal AccCheckListMstID As Long, ByVal AssortSize As String) As DataTable
            Dim str As String
            str = " select * from  AccCheckListMst AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= "  WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "' and AssortSize='" & AssortSize & "' And StyleAssortmentDetailId > 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetdetailofsizeWeightList(ByVal SizeWiseWeightListMstid As Long, ByVal Size As String) As DataTable
            Dim str As String
            str = " select * from  SizeWiseWeightListMst AM "
            str &= " JOIN SizeWiseWeightListDtl AD ON AD.SizeWiseWeightListMstid=AM.SizeWiseWeightListMstid"
            str &= " Join JobOrderdatabase jo on jo.joborderid=AM.joborderid"
            str &= " Join JobOrderdatabaseDetail jod on jod.joborderid=AM.joborderid"
            str &= "  WHERE AM.SizeWiseWeightListMstid = '" & SizeWiseWeightListMstid & "' and AD.Size='" & Size & "' And SizeWiseWeightListDtlId > 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeForPI(ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = " SELECT JOD.ColorCode,SAD.Breakup,(SAD.Asortqty +SAD.ExtraQty) AS Total,SAD.Size,jod.Style ,jod.ItemDesc ,jod.BuyerColor ,jod.Quantity ,jod.UnitPrice , isnull(jod.Model,'') as Model ,jod.StyleShipmentDate,JO.CustomerOrder FROM JobOrderdatabaseDetail JOD"
            str &= " JOIN StyleAssortmentMaster SAM on SAM.JoborderDetailid =JOD.JoborderDetailid "
            str &= " JOIN StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID =SAM.StyleAssortmentMasterID"
            str &= " join JobOrderdatabase JO on JO.Joborderid =JOD.Joborderid"
            str &= "  WHERE JOD.JoborderDetailid = '" & JoborderDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetExtraQtyForPI(ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = " select top 1 ExtraQty FROM StyleAssortmentMaster"
            str &= "  WHERE JoborderDetailid = '" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetdetailofsizeNew(ByVal AccCheckListMstID As Long, ByVal AssortSize As String) As DataTable
            Dim str As String
            str = " select *,Isnull(ItemCategoryName,'') as ItemCategoryNamee,isnull(ItemName,'') as ItemNamee from  AccCheckListMst AM "
            str &= " JOIN AccCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= "  WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "' and AssortSize='" & AssortSize & "' And StyleAssortmentDetailId > 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetdetailofsizeNewForZipper(ByVal AccCheckListMstID As Long, ByVal AssortSize As String) As DataTable
            Dim str As String
            str = " select *,Isnull(ItemCategoryName,'') as ItemCategoryNamee,isnull(ItemName,'') as ItemNamee from  AccCheckListMst AM "
            str &= " JOIN ZipperCheckListDetail AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryid=AD.IMSItemCategoryid"
            str &= " left join IMSItem IMS_I on IMS_I.IMSItemid=AD.IMSItemid"
            str &= "  WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "' and AssortSize='" & AssortSize & "' And StyleAssortmentDetailId > 0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRevisedDate(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select *,convert(varchar,RevisedDate,103) as RevisedDatee from  AccCheckListRevisedDateHistory "
            str &= "  WHERE AccCheckListMstid = '" & AccCheckListMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRevisedDateCutting(ByVal CuttingProMasterID As Long) As DataTable
            Dim str As String
            str = " select *,convert(varchar,RevisedDate,103) as RevisedDatee from  CuttingprogramRevisedDateHistory "
            str &= "  WHERE CuttingProMasterID = '" & CuttingProMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccMstID(ByVal JobOrderID As Long, ByVal JobOrderdetailID As Long, ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListMst AM "
            str &= "  WHERE AM.JobOrderID = '" & JobOrderID & "' and JobOrderdetailID='" & JobOrderdetailID & "' And StyleAssortmentMasterID ='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCuttingMstID(ByVal JobOrderID As Long, ByVal JobOrderdetailID As Long, ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select * from  DPCuttingProMaster AM "
            str &= "  WHERE AM.JobOrderID = '" & JobOrderID & "' and JobOrderdetailID='" & JobOrderdetailID & "' And StyleAssortmentMasterID ='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
