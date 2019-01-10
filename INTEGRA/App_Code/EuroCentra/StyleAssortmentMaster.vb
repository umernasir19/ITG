Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class StyleAssortmentMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleAssortmentMaster"
            m_strPrimaryFieldName = "StyleAssortmentMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lStyleAssortmentMasterID As Long
        Private m_lJobOrderID As Long
        Private m_lJoborderDetailid As Long
        Private m_lUserID As Long
        Private m_bLabDipapprovalbycustomer As Boolean
        Private m_dtCreationDate As Date
        Private m_bEmbelishmentReq As Boolean
        Private m_dcExtarQty As Decimal
        Public Property ExtraQty() As Long
            Get
                ExtraQty = m_dcExtarQty
            End Get
            Set(ByVal Value As Long)
                m_dcExtarQty = Value
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
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailid = Value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal Value As Long)
                m_lUserID = Value
            End Set
        End Property
        Public Property LabDipapprovalbycustomer() As Boolean
            Get
                LabDipapprovalbycustomer = m_bLabDipapprovalbycustomer
            End Get
            Set(ByVal value As Boolean)
                m_bLabDipapprovalbycustomer = value
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
        Public Property EmbelishmentReq() As Boolean
            Get
                EmbelishmentReq = m_bEmbelishmentReq
            End Get
            Set(ByVal value As Boolean)
                m_bEmbelishmentReq = value
            End Set
        End Property
        Public Function SaveStyleAssortmentMaster()
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
        Public Function GetNumberingFinalData() As DataTable
            Dim str As String
            str = "   select convert(varchar,MST.RECEIVEDATE,103) as ReceiveDate,*"
            str &= " ,(select top 1 jod.Style  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as Style"
            str &= "  ,(select top 1 jod.BuyerColor  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as BuyerColor"
            str &= " ,(select top 1 jod.SrNo  from NumberingFinalDtl Dtl join JobOrderdatabase jod on "
            str &= " jod.Joborderid =dtl.Joborderid where dtl.NumberingFinalID =mst.NumberingFinalID ) as SrNo"
            str &= " from NumberingFinal Mst"
            str &= " join Numbering N on N.NumberingID =MST.NumberingID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingFinalDataNumberingNo(ByVal NumberingNo As String) As DataTable
            Dim str As String
            str = "   select convert(varchar,MST.RECEIVEDATE,103) as ReceiveDate,*"
            str &= " ,(select top 1 jod.Style  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as Style"
            str &= "  ,(select top 1 jod.BuyerColor  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as BuyerColor"
            str &= " ,(select top 1 jod.SrNo  from NumberingFinalDtl Dtl join JobOrderdatabase jod on "
            str &= " jod.Joborderid =dtl.Joborderid where dtl.NumberingFinalID =mst.NumberingFinalID ) as SrNo"
            str &= " from NumberingFinal Mst"
            str &= " join Numbering N on N.NumberingID =MST.NumberingID"
            str &= "  where  N.NumberingNo='" & NumberingNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingFinalDataCustomer(ByVal CustomerName As String) As DataTable
            Dim str As String

            str = "    select convert(varchar,MST.RECEIVEDATE,103) as ReceiveDate,*"
            str &= " ,(select top 1 jod.Style  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as Style"
            str &= "  ,(select top 1 jod.BuyerColor  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as BuyerColor"
            str &= " ,(select top 1 jod.SrNo  from NumberingFinalDtl Dtl join JobOrderdatabase jod on "
            str &= " jod.Joborderid =dtl.Joborderid where dtl.NumberingFinalID =mst.NumberingFinalID ) as SrNo"
            str &= " from NumberingFinal Mst"
            str &= " join Numbering N on N.NumberingID =MST.NumberingID"
            str &= " join Customer C on C.CustomerID =Mst.CustomerID"
            str &= "  where  C.CustomerName='" & CustomerName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingFinalDataSeason(ByVal SeasonName As String) As DataTable
            Dim str As String

            str = "    select convert(varchar,MST.RECEIVEDATE,103) as ReceiveDate,*"
            str &= " ,(select top 1 jod.Style  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as Style"
            str &= "  ,(select top 1 jod.BuyerColor  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as BuyerColor"
            str &= " ,(select top 1 jod.SrNo  from NumberingFinalDtl Dtl join JobOrderdatabase jod on "
            str &= " jod.Joborderid =dtl.Joborderid where dtl.NumberingFinalID =mst.NumberingFinalID ) as SrNo"
            str &= " from NumberingFinal Mst"
            str &= " join Numbering N on N.NumberingID =MST.NumberingID"
            str &= "  where  (select top 1 sd.SeasonName  from NumberingFinalDtl  dtl join JobOrderdatabase jo on jo.joborderid=dtl.Joborderid "
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= "    where dtl.NumberingFinalID = mst.NumberingFinalID)='" & SeasonName & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingFinalDataBrand(ByVal Brand As String) As DataTable
            Dim str As String

            str = "    select convert(varchar,MST.RECEIVEDATE,103) as ReceiveDate,*"
            str &= " ,(select top 1 jod.Style  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as Style"
            str &= "  ,(select top 1 jod.BuyerColor  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as BuyerColor"
            str &= " ,(select top 1 jod.SrNo  from NumberingFinalDtl Dtl join JobOrderdatabase jod on "
            str &= " jod.Joborderid =dtl.Joborderid where dtl.NumberingFinalID =mst.NumberingFinalID ) as SrNo"
            str &= " from NumberingFinal Mst"
            str &= " join Numbering N on N.NumberingID =MST.NumberingID"
            str &= "  where  (select top 1 sd.Brand  from NumberingFinalDtl  dtl join JobOrderdatabase jo on jo.joborderid=dtl.Joborderid "
            str &= " join BrandDatabase sd on sd.BrandDatabaseID =jo.BrandDatabaseID "
            str &= "    where dtl.NumberingFinalID = mst.NumberingFinalID)='" & Brand & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingFinalDataSrno(ByVal SrNo As String) As DataTable
            Dim str As String

            str = "    select convert(varchar,MST.RECEIVEDATE,103) as ReceiveDate,*"
            str &= " ,(select top 1 jod.Style  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as Style"
            str &= "  ,(select top 1 jod.BuyerColor  from NumberingFinalDtl Dtl join JobOrderdatabaseDetail jod on "
            str &= " jod.JoborderDetailid =dtl.JoborderDetailid where dtl.NumberingFinalID =mst.NumberingFinalID ) as BuyerColor"
            str &= " ,(select top 1 jod.SrNo  from NumberingFinalDtl Dtl join JobOrderdatabase jod on "
            str &= " jod.Joborderid =dtl.Joborderid where dtl.NumberingFinalID =mst.NumberingFinalID ) as SrNo"
            str &= " from NumberingFinal Mst"
            str &= " join Numbering N on N.NumberingID =MST.NumberingID"
            str &= "  where  (select top 1 Jo.SrNo  from NumberingFinalDtl  dtl join JobOrderdatabase jo on jo.joborderid=dtl.Joborderid "
            str &= "    where dtl.NumberingFinalID = mst.NumberingFinalID)='" & SrNo & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetJoborderData(ByVal JoborderDetailid As Long)
            Dim str As String
            str = "   select * from JobOrderDatabase jo"
            str &= "  join  JobOrderDatabaseDetail jod on jod.Joborderid =jo.Joborderid "
            str &= "  where  jod.JoborderDetailid='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastNoLatestReceiveNo()
            Dim str As String
            str = "  select Top 1 ReceivingNo from NumberingFinal  order By NumberingFinalID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBrandStyleAssormentViewForChecklist(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where BD.Brand ='" & Brand & "' "
            str &= "  order by JO.SRNOPOne,jo.SRNOPTwo  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNumberingFinalId(ByVal NumberingFinalDtlID As Long) As DataTable
            Dim str As String

            str = "  select * from NumberingFinalDtl "
            str &= "  where  NumberingFinalDtlID ='" & NumberingFinalDtlID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleAssortmrntDetailId(ByVal JoborderDetailid As Long, ByVal Size As Decimal) As DataTable
            Dim str As String

            str = "  select * from StyleAssortmentMaster SAM"
            str &= "   join StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID =SAM.StyleAssortmentMasterID"
            str &= "  where  SAM.JoborderDetailid ='" & JoborderDetailid & "' AND SAD.Size ='" & Size & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateNumberingDtl(ByVal NumberingDtlID As Long, ByVal Status As String)
            Dim str As String

            str = "  Update NumberingDtl set SelectNumbering='" & Status & "'"
            str &= "  where  NumberingDtlID ='" & NumberingDtlID & "'"

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateNumberingFinalDtlMasterTable(ByVal NumberingFinalID As Long, ByVal Weight As Decimal)
            Dim str As String

            str = "  Update NumberingFinal set Weight='" & Weight & "'"
            str &= "  where  NumberingFinalID ='" & NumberingFinalID & "'"


            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateDonePacking(ByVal NumberingFinalDtlID As Long, ByVal DonePacking As String)
            Dim str As String

            str = "  Update NumberingFinalDtl set DonePacking='" & DonePacking & "'"
            str &= "  where  NumberingFinalDtlID ='" & NumberingFinalDtlID & "'"


            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateNumberingFinalDtl(ByVal NumberingFinalDtlID As Long, ByVal Weight As Decimal, ByVal SelectPacking As String)
            Dim str As String

            str = "  Update NumberingFinalDtl set Weight='" & Weight & "',SelectPacking='" & SelectPacking & "'"
            str &= "  where  NumberingFinalDtlID ='" & NumberingFinalDtlID & "'"


            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastNoLatest()
            Dim str As String
            str = "  select Top 1 NumberingNo from Numbering  order By NumberingID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBuyerStyleAssormentViewForChecklist(ByVal Buyer As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where CD.CustomerName ='" & Buyer & "' "
            str &= "  order by JO.SRNOPOne,jo.SRNOPTwo  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForStyleStyleAssormentViewForChecklist(ByVal Style As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where JOD.Style ='" & Style & "' "
            str &= "  order by JO.SRNOPOne,jo.SRNOPTwo  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSrNoStyleAssormentViewForChecklist(ByVal SrNo As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where JO.SrNo ='" & SrNo & "' "
            str &= "  order by JO.SRNOPOne,jo.SRNOPTwo  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSeasonStyleAssormentViewForChecklist(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where SD.SeasonName ='" & SeasonName & "' "
            str &= "  order by JO.SRNOPOne,jo.SRNOPTwo  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function Edit(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " Select * from StyleAssortmentMaster where StyleAssortmentMasterID=" & StyleAssortmentMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSizeWiseWeightList() As DataTable
            Dim str As String
            str = " select isnull(SAM.SizeWiseWeightListMstID,0)as SizeWiseWeightListMstID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,"
            str &= " SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO, JO.PONo,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSupplierName(ByVal SupplierName As String) As DataTable
            Dim str As String
            str = " select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId"
            str &= "  where SD.SupplierName ='" & SupplierName & "' and SD.Userid=237 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSupplierCode(ByVal SupplierCode As String) As DataTable
            Dim str As String
            str = " select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId "
            str &= "  where SD.SupplierCode ='" & SupplierCode & "' and SD.Userid=237"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSupplierCategory(ByVal SupplierCategory As String) As DataTable
            Dim str As String
            str = " select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId"
            str &= "  where SC.SupplierCategory ='" & SupplierCategory & "' and SD.Userid=237 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBrandSizeWeightView(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.SizeWiseWeightListMstID,0)as SizeWiseWeightListMstID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where BD.Brand ='" & Brand & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBrandStyleAssormentView(ByVal Brand As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where BD.Brand ='" & Brand & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBrandStyleAssormentViewForBarCodeView(ByVal Brand As String) As DataTable
            Dim str As String

            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "

            str &= "  , isnull(( select top 1 ddd.BarCodeCount  from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID order by ddd.StyleAssortmentBarCodeDetailID asc),0)  as fromm"
            str &= " ,  isnull(( select top 1 ddd.BarCodeCount from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID  order by ddd.StyleAssortmentBarCodeDetailID desc),0) as Too"

            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= "  where BD.Brand ='" & Brand & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ColorViseBarCodeView(ByVal BuyerColor As String) As DataTable
            Dim str As String

            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "

            str &= "  , isnull(( select top 1 ddd.BarCodeCount  from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID order by ddd.StyleAssortmentBarCodeDetailID asc),0)  as fromm"
            str &= " ,  isnull(( select top 1 ddd.BarCodeCount from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID  order by ddd.StyleAssortmentBarCodeDetailID desc),0) as Too"

            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= "  where JOd.BuyerColor ='" & BuyerColor & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBuyerSizeWeightView(ByVal Buyer As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.SizeWiseWeightListMstID,0)as SizeWiseWeightListMstID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where CD.CustomerName ='" & Buyer & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBuyerStyleAssormentView(ByVal Buyer As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where CD.CustomerName ='" & Buyer & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForBuyerStyleAssormentViewForBarCode(ByVal Buyer As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "

            str &= "  , isnull(( select top 1 ddd.BarCodeCount  from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID order by ddd.StyleAssortmentBarCodeDetailID asc),0)  as fromm"
            str &= " ,  isnull(( select top 1 ddd.BarCodeCount from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID  order by ddd.StyleAssortmentBarCodeDetailID desc),0) as Too"


            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= "  where CD.CustomerName ='" & Buyer & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForStyleSizeWeightView(ByVal Style As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.SizeWiseWeightListMstID,0)as SizeWiseWeightListMstID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where JOD.Style ='" & Style & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForStyleStyleAssormentView(ByVal Style As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where JOD.Style ='" & Style & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForStyleStyleAssormentViewForBarCode(ByVal Style As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "

            str &= "  , isnull(( select top 1 ddd.BarCodeCount  from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID order by ddd.StyleAssortmentBarCodeDetailID asc),0)  as fromm"
            str &= " ,  isnull(( select top 1 ddd.BarCodeCount from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID  order by ddd.StyleAssortmentBarCodeDetailID desc),0) as Too"


            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= "  where JOD.Style ='" & Style & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSrNoSizeWeightView(ByVal SrNo As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.SizeWiseWeightListMstID,0)as SizeWiseWeightListMstID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where JO.SrNo ='" & SrNo & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSrNoStyleAssormentView(ByVal SrNo As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where JO.SrNo ='" & SrNo & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSrNoStyleAssormentViewForBarCode(ByVal SrNo As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "

            str &= "  , isnull(( select top 1 ddd.BarCodeCount  from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID order by ddd.StyleAssortmentBarCodeDetailID asc),0)  as fromm"
            str &= " ,  isnull(( select top 1 ddd.BarCodeCount from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID  order by ddd.StyleAssortmentBarCodeDetailID desc),0) as Too"


            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= "  where JO.SrNo ='" & SrNo & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSeasonStyleAssormentViewForBarCode(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "

            str &= "  , isnull(( select top 1 ddd.BarCodeCount  from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID order by ddd.StyleAssortmentBarCodeDetailID asc),0)  as fromm"
            str &= " ,  isnull(( select top 1 ddd.BarCodeCount from StyleAssortmentBarCodeDetail ddd where ddd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID  order by ddd.StyleAssortmentBarCodeDetailID desc),0) as Too"


            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= "  where SD.SeasonName ='" & SeasonName & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSeasonSizeWeightView(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.SizeWiseWeightListMstID,0)as SizeWiseWeightListMstID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join SizeWiseWeightListMst SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where SD.SeasonName ='" & SeasonName & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewForSeasonStyleAssormentView(ByVal SeasonName As String) As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  where SD.SeasonName ='" & SeasonName & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function JOView() As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO, JO.PONo,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= "  order by JO.SRNOPOne,jo.SRNOPTwo  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function JOViewForNumbering() As DataTable
            Dim str As String

            str = "  select (select top 1 Mst.NumberingNo  from Numbering Mst join NumberingDtl dtl on dtl.NumberingID =mst.NumberingID where dtl.JoborderDetailid =jod.JoborderDetailid )as NumberingNoo,JOd.BuyerColor ,jod.Style ,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO"
            str &= " ,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " where jod.JoborderDetailid in (select nn.JoborderDetailid from NumberingDtl NN where nn.JoborderDetailid =jod.JoborderDetailid )"
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo  "

            'str = " select Jo.JobOrderId,Jo.JobOrderNo,"
            'str &= " JO.SRNO,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            'str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            'str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            'str &= " join NumberingDtl N on N.JobOrderId=JOd.JobOrderId AND N.JobOrderDetailId=JOD.JobOrderDetailId"
            'str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            'str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            'str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            'str &= " join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId AND"
            'str &= " SAM.StyleAssortmentMasterID = N.StyleAssortmentMasterID"
            'str &= " order by JO.SRNOPOne,jo.SRNOPTwo"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function JOViewForNumberingSesaon(ByVal SeasonName As String) As DataTable
            Dim str As String

            str = "  select (select top 1 Mst.NumberingNo  from Numbering Mst join NumberingDtl dtl on dtl.NumberingID =mst.NumberingID where dtl.JoborderDetailid =jod.JoborderDetailid )as NumberingNoo,JOd.BuyerColor ,jod.Style ,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO"
            str &= " ,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " where jod.JoborderDetailid in (select nn.JoborderDetailid from NumberingDtl NN where nn.JoborderDetailid =jod.JoborderDetailid )"
            str &= " and SD.SeasonName='" & SeasonName & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function JOViewForNumberingNumberingNo(ByVal NumberingNo As String) As DataTable
            Dim str As String

            str = "  select (select top 1 Mst.NumberingNo  from Numbering Mst join NumberingDtl dtl on dtl.NumberingID =mst.NumberingID where dtl.JoborderDetailid =jod.JoborderDetailid )as NumberingNoo,JOd.BuyerColor ,jod.Style ,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO"
            str &= " ,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " where jod.JoborderDetailid in (select nn.JoborderDetailid from NumberingDtl NN where nn.JoborderDetailid =jod.JoborderDetailid )"
            str &= " and (select top 1 nn.NumberingNo  from Numbering NN "
            str &= "  join NumberingDtl nd on nd.NumberingID =nn.NumberingID "
            str &= "  where nd.JoborderDetailid =jod.JoborderDetailid ) ='" & NumberingNo & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function JOViewForNumberingBrand(ByVal Brand As String) As DataTable
            Dim str As String

            str = "  select (select top 1 Mst.NumberingNo  from Numbering Mst join NumberingDtl dtl on dtl.NumberingID =mst.NumberingID where dtl.JoborderDetailid =jod.JoborderDetailid )as NumberingNoo,JOd.BuyerColor ,jod.Style ,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO"
            str &= " ,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " where jod.JoborderDetailid in (select nn.JoborderDetailid from NumberingDtl NN where nn.JoborderDetailid =jod.JoborderDetailid )"
            str &= " and BD.Brand='" & Brand & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function JOViewForNumberingSrNo(ByVal SrNo As String) As DataTable
            Dim str As String

            str = "  select (select top 1 Mst.NumberingNo  from Numbering Mst join NumberingDtl dtl on dtl.NumberingID =mst.NumberingID where dtl.JoborderDetailid =jod.JoborderDetailid )as NumberingNoo,JOd.BuyerColor ,jod.Style ,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO"
            str &= " ,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " where jod.JoborderDetailid in (select nn.JoborderDetailid from NumberingDtl NN where nn.JoborderDetailid =jod.JoborderDetailid )"
            str &= " and JO.SrNo='" & SrNo & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function JOViewForNumberingCustomer(ByVal CustomerName As String) As DataTable
            Dim str As String

            str = "  select (select top 1 Mst.NumberingNo  from Numbering Mst join NumberingDtl dtl on dtl.NumberingID =mst.NumberingID where dtl.JoborderDetailid =jod.JoborderDetailid )as NumberingNoo,JOd.BuyerColor ,jod.Style ,Jo.JobOrderId,Jo.JobOrderNo,JO.SRNO"
            str &= " ,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase JO "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " where jod.JoborderDetailid in (select nn.JoborderDetailid from NumberingDtl NN where nn.JoborderDetailid =jod.JoborderDetailid )"
            str &= " and CD.CustomerName='" & CustomerName & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo  "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetYarnTypeforStyleAssortment() As DataTable
            Dim str As String
            str = " select * from YarnType "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View2New() As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,SD.SeasonName,"
            str &= " CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= " ,isnull(SAD.Size,'N/A') as Size,cASE"
            str &= " WHEN sad.bREAKUP='Ratio' then"
            str &= "   isnull(sad.QTY+sad.extraQty, 0)"
            str &= " else"
            str &= " isnull(sad.Asortqty+sad.extraQty, 0)"
            str &= " End"
            str &= " as Sizeqty,isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO"
            str &= " from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View2NewNewNew() As DataTable
            Dim str As String

            str = "  DECLARE @datefrom as datetime,@todate as datetime"
            str &= " set @todate =convert(date,GETDATE(),103)"
            str &= " set @datefrom = convert(date,DATEADD(d,-60,@todate),103)"
            
            str &= " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID, "
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo, "
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103)  "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size ,cASE WHEN sad.bREAKUP='Ratio' then    "
            str &= " isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy, "
            str &= " isnull(DPD.TotalQty,0) as Sizeqty, isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "
            str &= " , 0 as fromm, 0 as Too "

            str &= " from JobOrderdatabase JO   "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId   "
            str &= "  join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID   "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= "  join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID  "
            str &= "  Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and     "
            str &= "        SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid "
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid  "
            str &= "  AND DPM.JoborderDetailid =JOD.JoborderDetailid   "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID "
            str &= " and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID   "
            str &= "  where JOd.StyleShipmentDate between @datefrom and @todate"
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View2NewNewNewForSearching(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = "  select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID, "
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo, "
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103)  "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size ,cASE WHEN sad.bREAKUP='Ratio' then    "
            str &= " isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy, "
            str &= " isnull(DPD.TotalQty,0) as Sizeqty, isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "
            str &= " , 0 as fromm, 0 as Too "
            str &= " from JobOrderdatabase JO   "
            str &= "  join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId   "
            str &= "  join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID   "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= "  join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID  "
            str &= "  Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and     "
            str &= "        SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid "
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid  "
            str &= "  AND DPM.JoborderDetailid =JOD.JoborderDetailid   "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID "
            str &= " and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID  where jo.SeasonDatabaseID ='" & SeasonDatabaseID & "' "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View2NewNew() As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,"
            str &= " isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,"
            str &= " SD.SeasonName, CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) "
            str &= " as StyleShipmentDatee ,isnull(SAD.Size,'N/A') as Size"
            str &= " ,cASE WHEN sad.bREAKUP='Ratio' then   "
            str &= "  isnull(sad.QTY+sad.extraQty, 0) else isnull(sad.Asortqty+sad.extraQty, 0) End as Sizeqtyy,"
            str &= "  isnull(DPD.TotalQty,0) as Sizeqty,"
            str &= " isnull(SAD.DownloadBit,0) as DownloadBit,JO.SRNO "
            str &= " from JobOrderdatabase JO  "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId  "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID  "
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID  "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID "
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  "
            str &= "   SAM.JobOrderDetailId = JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid"
            str &= " left join  DPCuttingProMaster DPM on DPM.JobOrderID=JO.Joborderid "
            str &= " AND DPM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  left join DPCuttingProDetail DPD on DPD.CuttingProMasterID=DPM.CuttingProMasterID and DPD.StyleAssortmentDetailID =SAD.StyleAssortmentDetailID "
            str &= " order by JO.SRNOPOne,jo.SRNOPTwo "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View2() As DataTable
            Dim str As String
            str = " select isnull(SAM.StyleAssortmentMasterID,0)as StyleAssortmentMasterID,isnull(SAD.StyleAssortmentdetailID,0)as StyleAssortmentdetailID,Jo.JobOrderId,Jo.JobOrderNo,SD.SeasonName,"
            str &= " CD.CustomerName,BD.Brand,JOd.*  ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= " ,isnull(SAD.Size,'N/A') as Size,cASE"
            str &= " WHEN sad.bREAKUP='Ratio' then"
            str &= "   isnull(sad.QTY, 0)"
            str &= " else"
            str &= " isnull(sad.Asortqty, 0)"
            str &= " End"
            str &= " as Sizeqty"
            str &= " from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID "
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=Jo.CustomerDatabaseID "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " Left join StyleAssortmentMaster SAM on SAM.JobOrderId=Jo.JobOrderId and  SAM.JobOrderDetailId=JoD.JobOrderDetailId"
            str &= " Left join StyleAssortmentdetail SAD on SAD.StyleAssortmentMasterid=SAM.StyleAssortmentMasterid "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindGender2() As DataTable
            Dim str As String
            str = " select SizeRangeId,(SizeGroup+'  ('+SizeRange+')') as SizeGroup from SizeRange "
            ' str = " select * from SizeRange "
            ' str = " select distinct SizeGroup from SizeRange"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindGender() As DataTable
            Dim str As String
            str = " select * from SizeRange "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQty(ByVal CustomerName As String) As DataTable
            Dim str As String
            str = " Select * from Customer  where CustomerName ='" & CustomerName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindAccessoriesColor() As DataTable
            Dim str As String
            str = " select * from AccessoriesColor order by colorname asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSizeRange2(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = " select distinct SizeRangeID,SizeRange from SizeRange where SizeRangeID= '" & SizeRangeID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindSizeRange(ByVal Gender As String) As DataTable
            Dim str As String
            ' str = " select distinct SizeRangeID,SizeRange from SizeRange where Gender= '" & Gender & "' "
            str = " select distinct SizeRangeID,SizeRange from SizeRange where SizeGroup= '" & Gender & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrencyForstyleassortment() As DataTable
            Dim str As String
            str = " select * from currency "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataWeight(ByVal JobOrderId As Long) As DataTable
            Dim str As String
            str = "  select JOd.ItemDesc, UOM.UOMName,IDB.DPItemName,JOd.BuyerColor AS Colorr,JO.CustomerOrder,Jo.JobOrderId,Jo.JobOrderNo,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee,JO.SRNO "
            str &= " from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " left join DPItemDatabase IDB on IDB.DPItemDatabaseID=JOD.ItemDatabaseID"
            str &= " join UnitofMeasurement UOM on UOM.UOMID=JOD.UOMID"
            str &= "  where JO.JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetData(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = "  select JOd.ItemDesc, UOM.UOMName,IDB.DPItemName,JOd.BuyerColor AS Colorr,JO.CustomerOrder,Jo.JobOrderId,Jo.JobOrderNo, JO.PONo,SD.SeasonName,CD.CustomerName,BD.Brand,JOd.* "
            str &= " ,convert(Varchar,JOD.StyleShipmentDate,103) as StyleShipmentDatee,JO.SRNO "
            str &= " from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join Customer CD on CD.CustomerID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " left join DPItemDatabase IDB on IDB.DPItemDatabaseID=JOD.ItemDatabaseID"
            str &= " join UnitofMeasurement UOM on UOM.UOMID=JOD.UOMID"
            str &= "  where JO.JobOrderId = '" & JobOrderId & "' And JOD.JoborderDetailid ='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataAuto(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = "  select * from "
            str &= " JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join ItemDatabase IDB on IDB.ItemDatabaseID=JOD.ItemDatabaseID"
            str &= " join UnitofMeasurement UOM on UOM.UOMID=JOD.UOMID"
            str &= "  where JO.JobOrderId = '" & JobOrderId & "' And JOD.JoborderDetailid <> '" & JoborderDetailid & "' and JOD.Style='" & Style & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUOMData(ByVal JobOrderId As Long, ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = "  select distinct UOM.UOMName,UOM.UOMID,UOM.Symbol"
            str &= " from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join UnitofMeasurement UOM on UOM.UOMID=JOD.UOMID"
            str &= "  where JO.JobOrderId = '" & JobOrderId & "' And JOD.JoborderDetailid ='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataAddNew(ByVal JoborderDetailid As Long, ByVal StyleAssortmentDetailID As Long) As DataTable
            Dim str As String

            str = "  SELECT SAD.SizeRangeId,SAD.SizeDatabaseId,sad.StyleAssortmentDetailID,sad.StyleAssortmentMasterID "
            str &= " ,SAD.CuttingProDetailID ,SAM.CuttingProMasterID ,jod.Joborderid ,jod.JoborderDetailid ,JOD.BuyerColor,"
            str &= " SAD.Size as Sizee ,SDD.AsortQty as Qty,JOD.Style"
            str &= "  FROM JobOrderdatabaseDetail JOD"
            str &= "  JOIN DPCuttingProMaster SAM on SAM.JoborderDetailid =JOD.JoborderDetailid "
            str &= " JOIN DPCuttingProDetail SAD on SAD.CuttingProMasterID =SAM.CuttingProMasterID "
            str &= "  JOIN StyleAssortmentMaster SMM on SMM.JoborderDetailid =SAM.JoborderDetailid "
            str &= " JOIN StyleAssortmentDetail SDD on SDD.StyleAssortmentMasterID =SMM.StyleAssortmentMasterID "
            str &= " and sdd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID and sdd.StyleAssortmentDetailID "
            str &= " =sad.StyleAssortmentDetailID"
            str &= "  where JOD.JoborderDetailid = '" & JoborderDetailid & "' and SDD.StyleAssortmentDetailID ='" & StyleAssortmentDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataAddNew2(ByVal JoborderDetailid As Long) As DataTable
            Dim str As String

            str = "  SELECT SAD.SizeRangeId,SAD.SizeDatabaseId,sad.StyleAssortmentDetailID,sad.StyleAssortmentMasterID "
            str &= " ,SAD.CuttingProDetailID ,SAM.CuttingProMasterID ,jod.Joborderid ,jod.JoborderDetailid ,JOD.BuyerColor,"
            str &= " SAD.Size as Sizee ,SDD.AsortQty as Qty,JOD.Style"
            str &= "  FROM JobOrderdatabaseDetail JOD"
            str &= "  JOIN DPCuttingProMaster SAM on SAM.JoborderDetailid =JOD.JoborderDetailid "
            str &= " JOIN DPCuttingProDetail SAD on SAD.CuttingProMasterID =SAM.CuttingProMasterID "
            str &= "  JOIN StyleAssortmentMaster SMM on SMM.JoborderDetailid =SAM.JoborderDetailid "
            str &= " JOIN StyleAssortmentDetail SDD on SDD.StyleAssortmentMasterID =SMM.StyleAssortmentMasterID "
            str &= " and sdd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID and sdd.StyleAssortmentDetailID "
            str &= " =sad.StyleAssortmentDetailID"
            str &= "  where JOD.JoborderDetailid = '" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNumberingNo(ByVal JoborderDetailid As Long)
            Dim str As String
            str = "  select * from Numbering N"
            str &= "  join NumberingDtl Dtl on dtl.NumberingID =n.NumberingID "
            str &= "  where  dtl.JoborderDetailid='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingNoNewwww(ByVal JoborderDetailid As Long)
            Dim str As String
            str = "  select * from Numbering N"
            str &= "  join NumberingDtl Dtl on dtl.NumberingID =n.NumberingID "
            str &= "  where  dtl.JoborderDetailid='" & JoborderDetailid & "'"
            str &= "  order by Dtl.NumberingDtlID Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetNumberingNoNewwwwwww(ByVal JoborderDetailid As Long)
            Dim str As String
            str = "  select * from Numbering N"
            str &= "  join NumberingDtl Dtl on dtl.NumberingID =n.NumberingID "
            str &= "  where  dtl.JoborderDetailid='" & JoborderDetailid & "' and Dtl.SerialNo<>0"
            str &= "  order by Dtl.NumberingDtlID Desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSizeFromAddQty(ByVal JoborderDetailid As Long)
            Dim str As String
            str = "  select sad.StyleAssortmentDetailID ,sad.Size  from StyleAssortmentMaster  Sam"
            str &= " join StyleAssortmentDetail Sad on Sad.StyleAssortmentMasterID =Sam.StyleAssortmentMasterID"
            str &= "  where  Sam.JoborderDetailid='" & JoborderDetailid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetReceivingNo(ByVal NumberingFinalid As Long)
            Dim str As String
            str = "  select * from NumberingFinal "
            str &= "  where  NumberingFinalid='" & NumberingFinalid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyleAssortmentDetailIDForCuttingAllCase(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  select * from DPCuttingProMaster Mst"
            str &= "  join DPCuttingProDetail Dtl on Dtl.CuttingProMasterID=Mst.CuttingProMasterID"
            str &= "  where   Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyleAssortmentDetailIDForCutting(ByVal StyleAssortmentMasterID As Long, ByVal StyleAssortmentDetailID As Long)
            Dim str As String
            str = "  select * from DPCuttingProMaster Mst"
            str &= "  join DPCuttingProDetail Dtl on Dtl.CuttingProMasterID=Mst.CuttingProMasterID"
            str &= "  where   Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "' or Dtl.StyleAssortmentDetailID='" & StyleAssortmentDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyleAssortmentDetailIDForCuttingForAssotmentView(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  select * from DPCuttingProMaster Mst"
            str &= "  where   Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyleAssortmentDetailIDForChecklistForAssotmentView(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  select * from AccCheckListMst Mst"
            str &= "  where   Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyleAssortmentDetailIDForChecklist(ByVal StyleAssortmentMasterID As Long, ByVal StyleAssortmentDetailID As Long)
            Dim str As String
            str = "  select * from AccCheckListMst Mst"
            str &= " join AccCheckListDetail Dtl on Dtl.AccCheckListMstID=Mst.AccCheckListMstID"
            str &= "  where   Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "' or Dtl.StyleAssortmentDetailID='" & StyleAssortmentDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyleAssortmentDetailIDForChecklistAllCase(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  select * from AccCheckListMst Mst"
            str &= " join AccCheckListDetail Dtl on Dtl.AccCheckListMstID=Mst.AccCheckListMstID"
            str &= "  where   Mst.StyleAssortmentMasterID='" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteSizeWiseWeightListDtl(ByVal SizeWiseWeightListDtlID As Long)
            Dim str As String
            str = "  delete from   SizeWiseWeightListDtl where   SizeWiseWeightListDtlID =' " & SizeWiseWeightListDtlID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteStyleAssortmentDetail(ByVal StyleAssortmentDetailID As Long)
            Dim str As String
            str = "  delete from   StyleAssortmentDetail where   StyleAssortmentDetailID =' " & StyleAssortmentDetailID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteStyleAssortmentDetailForAssortmentView(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  delete from   StyleAssortmentDetail where   StyleAssortmentMasterID =' " & StyleAssortmentMasterID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteSizeWiseMst(ByVal SizeWiseWeightListMstID As Long)
            Dim str As String
            str = "  delete from   SizeWiseWeightListMst where   SizeWiseWeightListMstID =' " & SizeWiseWeightListMstID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteSizeWiseDtl(ByVal SizeWiseWeightListMstID As Long)
            Dim str As String
            str = "  delete from   SizeWiseWeightListDtl where   SizeWiseWeightListMstID =' " & SizeWiseWeightListMstID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteStyleAssortmentMasterForAssortmentView(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  delete from   StyleAssortmentMaster where   StyleAssortmentMasterID =' " & StyleAssortmentMasterID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteStyleAssortmentDetailAllCase(ByVal StyleAssortmentMasterID As Long)
            Dim str As String
            str = "  delete from   StyleAssortmentDetail where   StyleAssortmentMasterID =' " & StyleAssortmentMasterID & " ' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUserInfo(ByVal userId As Long)
            Dim str As String
            str = "  select UserName from UMUSer"
            str &= "  where  UserID ='" & userId & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGridSizeDataDataForSizeWeight(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = " select '0' as SizeWiseWeightListDtlID,SR.sizerangeID, SD.SizeDatabaseID,SD.Sizes,SD.Ratio from sizerange SR"
            str &= "  join sizeRangedetail SRD on SRD.sizerangeID=SR.sizerangeID"
            str &= "  join sizedatabase SD on SD.SizeDatabaseID=SRD.SizeDatabaseID"
            '  str &= " left Join StyleAssortmentDetail SAD on SAD.SizeRangeID=SR.SizeRangeID and SAD.SizeDatabaseID=SRD.SizeDatabaseID"
            str &= "  where SR.sizerangeID = '" & SizeRangeID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckEditData(ByVal JOBORDERID As Long) As DataTable
            Dim str As String
            str = " select * from SizeWiseWeightListMst"
            str &= "  where JOBORDERID = '" & JOBORDERID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckWeightDataSummaryGrid(ByVal NumberingFinalID As Long) As DataTable
            Dim str As String
            str = " select SAM.StyleAssortmentDetailID,CASE WHEN isnull(SAM.Size,'')  = '' THEN 'Mixed' ELSE SAM.Size  END  As Sizee"
            str &= " ,count (N.CartonNo) as CartonNo"
            str &= " ,sum( CASE WHEN PcsPerCarton  = '&nbsp;' THEN 0 ELSE PcsPerCarton  END)  As PcsPerCartonn"
            str &= " ,sum (N.Weight) as Weight"
            str &= "  from NumberingFinalDtl N"
            str &= " JOIN JobOrderDatabaseDetail Jod on Jod.JoborderDetailid=N.JoborderDetailid "
            str &= " left join StyleAssortmentDetail  SAM on SAM.StyleAssortmentDetailID=N.StyleAssortmentDetailID"
            str &= "  where N.NumberingFinalID = '" & NumberingFinalID & "'"
            str &= "   and n.SelectPacking =1"
            str &= " group by SAM.StyleAssortmentDetailID ,SAM.Size"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckWeightData(ByVal NumberingFinalID As Long) As DataTable
            Dim str As String
            str = " select SAM.Size,*,"
            str &= "  CASE WHEN PcsPerCarton  = '&nbsp;' THEN 0 ELSE PcsPerCarton  END  As PcsPerCartonn,CASE WHEN isnull(SAM.Size,'')  = '' THEN 'Mixed' ELSE SAM.Size  END  As Sizee from NumberingFinalDtl N"
            str &= "  JOIN JobOrderDatabaseDetail Jod on Jod.JoborderDetailid=N.JoborderDetailid "
            str &= "  left join StyleAssortmentDetail  SAM on SAM.StyleAssortmentDetailID=N.StyleAssortmentDetailID"
            str &= "  where N.NumberingFinalID = '" & NumberingFinalID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckNumberingData(ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = " select SAM.Size,*,"
            str &= "  CASE WHEN PcsPerCarton  = '&nbsp;' THEN 0 ELSE PcsPerCarton  END  As PcsPerCartonn,CASE WHEN isnull(SAM.Size,'')  = '' THEN 'Mixed' ELSE SAM.Size  END  As Sizee from NumberingDtl N"
            str &= "  JOIN JobOrderDatabaseDetail Jod on Jod.JoborderDetailid=N.JoborderDetailid "
            str &= "  left join StyleAssortmentDetail  SAM on SAM.StyleAssortmentDetailID=N.StyleAssortmentDetailID"
            str &= "  where N.JoborderDetailid = '" & JoborderDetailid & "' and N.SelectNumbering =0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckWhiteColor(ByVal JOBORDERID As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderdatabaseDetail"
            str &= "  where JOBORDERID = '" & JOBORDERID & "' and BuyerColor ='White'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataSizeWeightWithWhiteColor(ByVal JOBORDERID As Long) As DataTable
            Dim str As String
            str = "  select isnull(CMD.SizeWiseWeightListDtlID,0) as SizeWiseWeightListDtlID, SAM.*,SAD.*,SDB.Sizes ,JOD.Style,  "
            str &= "  (case when isnull(CMD.SizeWeight,0) ='0' then '0' else SizeWeight end ) as SizeWeight  "
            str &= "  ,(case when (jod.buyercolor) ='White' then 'White' else 'Dyed' end ) as buyercolor  "
            str &= "   from StyleAssortmentMaster SAM   "
            str &= "   join StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID=SAM.StyleAssortmentMasterID "
            str &= "   join SizeRange SR on SR.SizeRangeID=SAD.SizeRangeID "
            str &= "   join SizeDatabase SDB on SDB.SizeDatabaseID=SAD.SizeDatabaseID  "
            str &= "   left JOIN  SizeWiseWeightListMst CMM ON SAM.JobOrderID=CMM.JobOrderID  "
            str &= "   left JOIN  SizeWiseWeightListDtl CMD ON CMD.SizeWiseWeightListMstID=CMM.SizeWiseWeightListMstID "
            str &= "  JOIN JobOrderdatabaseDetail JOD on JOD.JoborderDetailid =SAM.JoborderDetailid "
            str &= "  where SAM.JOBORDERID = '" & JOBORDERID & "'"
            str &= "  order by   SAM.JOBORDERID asc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataonEdit(ByVal JOBORDERID As Long) As DataTable
            Dim str As String
            str = "   select *,Dtl.Size,Dtl.color as BuyerColor from SizeWiseWeightListMst Mst"
            str &= "  join SizeWiseWeightListDtl Dtl on Dtl.SizeWiseWeightListMstID =mst.SizeWiseWeightListMstID"
            str &= "  where Mst.JOBORDERID = '" & JOBORDERID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataSizeWeightWithDyedColorNew(ByVal JOBORDERID As Long) As DataTable
            Dim str As String
            str = "  SELECT SAD.SizeRangeId,SAD.SizeDatabaseId,sad.StyleAssortmentDetailID,sad.StyleAssortmentMasterID ,SAD.CuttingProDetailID ,SAM.CuttingProMasterID ,jod.Joborderid ,jod.JoborderDetailid ,JOD.BuyerColor,SAD.Size,SDD.AsortQty as Qty"
            str &= "  ,isnull(CMD.SizeWiseWeightListDtlID,0) as SizeWiseWeightListDtlID "
            str &= "  ,(case when isnull(CMD.WeightPerPiece,0) ='0' then '0' else WeightPerPiece end ) as WeightPerPiece"
            str &= "  ,(case when isnull(CMD.Dimension,'') ='' then '' else Dimension end ) as Dimension"
            str &= "  ,(case when isnull(CMD.PcsPerCarton,0) ='0' then '0' else PcsPerCarton end ) as PcsPerCarton"
            str &= "  ,(case when isnull(CMD.NoOfCarton,0) ='0' then '0' else NoOfCarton end ) as NoOfCarton"
            str &= "  ,(case when isnull(CMD.Extra,0) ='0' then '0' else Extra end ) as Extra"
            str &= "  ,(case when isnull(CMD.TotalQtyy,0) ='0' then '0' else TotalQtyy end ) as TotalQtyy"
            str &= "  ,(case when isnull(CMD.Balance,0) ='0' then '0' else Balance end ) as Balance"
            str &= "  ,(case when isnull(CMD.Weight,0) ='0' then '0' else Weight end ) as Weight"
            str &= "  FROM JobOrderdatabaseDetail JOD"
            str &= "  JOIN DPCuttingProMaster SAM on SAM.JoborderDetailid =JOD.JoborderDetailid "
            str &= "  JOIN DPCuttingProDetail SAD on SAD.CuttingProMasterID =SAM.CuttingProMasterID "
            str &= "  JOIN StyleAssortmentMaster SMM on SMM.JoborderDetailid =SAM.JoborderDetailid "
            str &= "  JOIN StyleAssortmentDetail SDD on SDD.StyleAssortmentMasterID =SMM.StyleAssortmentMasterID  and sdd.StyleAssortmentMasterID =sam.StyleAssortmentMasterID and sdd.StyleAssortmentDetailID =sad.StyleAssortmentDetailID "
            str &= "  left JOIN  SizeWiseWeightListMst CMM ON SAM.JobOrderID=CMM.JobOrderID  "
            str &= "  left JOIN SizeWiseWeightListDtl CMD ON CMD.SizeWiseWeightListMstID=CMM.SizeWiseWeightListMstID "
            str &= "  where JOD.JOBORDERID = '" & JOBORDERID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataSizeWeightWithDyedColor(ByVal JOBORDERID As Long) As DataTable
            Dim str As String
            str = "  SELECT DISTINCT SAD.Size as Sizes,isnull(CMD.SizeWiseWeightListDtlID,0) as SizeWiseWeightListDtlID "
            str &= "  ,(case when isnull(CMD.SizeWeight,0) ='0' then '0' else SizeWeight end ) as SizeWeight"
            str &= "  ,(case when (jod.buyercolor) ='White' then 'White' else 'Dyed' end ) as buyercolor"
            str &= "  FROM JobOrderdatabaseDetail JOD"
            str &= " JOIN StyleAssortmentMaster SAM on SAM.JoborderDetailid =JOD.JoborderDetailid "
            str &= " JOIN StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID =SAM.StyleAssortmentMasterID "
          str &= "   left JOIN  SizeWiseWeightListMst CMM ON SAM.JobOrderID=CMM.JobOrderID  "
            str &= " left JOIN SizeWiseWeightListDtl CMD ON CMD.SizeWiseWeightListMstID=CMM.SizeWiseWeightListMstID "
            str &= "  where SAM.JOBORDERID = '" & JOBORDERID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGridSizeDataData(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = " select '' as LineNumber,'0' as StyleAssortmentDetailID,SR.sizerangeID, SD.SizeDatabaseID,SD.Sizes,SD.Ratio,'0' as Asortqty from sizerange SR"
            str &= "  join sizeRangedetail SRD on SRD.sizerangeID=SR.sizerangeID"
            str &= "  join sizedatabase SD on SD.SizeDatabaseID=SRD.SizeDatabaseID"
            '  str &= " left Join StyleAssortmentDetail SAD on SAD.SizeRangeID=SR.SizeRangeID and SAD.SizeDatabaseID=SRD.SizeDatabaseID"
            str &= "  where SR.sizerangeID = '" & SizeRangeID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetForEdit(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = "  select SAD.ExtraQTY AS ExtraQtyy, SAM.*,SAD.*,SDB.Sizes "
            str &= " from StyleAssortmentMaster SAM "
            str &= " join StyleAssortmentDetail SAD on SAD.StyleAssortmentMasterID=SAM.StyleAssortmentMasterID"
            str &= " join UnitofMeasurement UOM on  UOM.Symbol=SAD.Unit"
            str &= " join SizeRange SR on SR.SizeRangeID=SAD.SizeRangeID"
            str &= " join SizeDatabase SDB on SDB.SizeDatabaseID=SAD.SizeDatabaseID"
            str &= " where SAD.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' order by   SAD.StyleAssortmentDetailID asc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetForEditForSizeWiseWeightList(ByVal SizeWiseWeightListMstID As Long) As DataTable
            Dim str As String
            str = "  select  SAM.*,SAD.*,SDB.Sizes as Size,SAD.SizeWeight "
            str &= " from SizeWiseWeightListMst SAM "
            str &= " join SizeWiseWeightListDtl SAD on SAD.SizeWiseWeightListMstID=SAM.SizeWiseWeightListMstID"
            str &= " join SizeRange SR on SR.SizeRangeID=SAD.SizeRangeID"
            str &= " join SizeDatabase SDB on SDB.SizeDatabaseID=SAD.SizeDatabaseID"
            str &= " where SAD.SizeWiseWeightListMstID = '" & SizeWiseWeightListMstID & "' order by   SAD.SizeWiseWeightListMstID asc "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Getcolor(ByVal AccessoriesColorID As Long) As DataTable
            Dim str As String
            str = " select * from AccessoriesColor "
            str &= "  where AccessoriesColorID= '" & AccessoriesColorID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBRKup(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = "  select * from styleassortmentdetail "
            str &= "  where StyleAssortmentMasterID= '" & StyleAssortmentMasterID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteOldNumbering(ByVal StyleAssortmentDetailID As Long)
            Dim Str As String
            Str = "update StyleAssortmentDetail set DownloadBit=1 where StyleAssortmentDetailID='" & StyleAssortmentDetailID & "'"

            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDwnloadbit(ByVal StyleAssortmentDetailID As Long)
            Dim Str As String
            Str = "update StyleAssortmentDetail set DownloadBit=1 where StyleAssortmentDetailID='" & StyleAssortmentDetailID & "'"

            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExist(ByVal JobOrderId As Long, ByVal JobOrderDetailId As Long) As DataTable
            Dim str As String
            str = "  select * from FabricationMaster "
            str &= "  where  JobOrderID = '" & JobOrderId & "' and JoborderDetailid =  '" & JobOrderDetailId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
