Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class ProcessOrderMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ProcessOrderMst"
            m_strPrimaryFieldName = "ProcessOrderMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
        End Sub
        Private m_lProcessOrderMstID As Long
        Private m_PONo As String
        Private m_lPOTypeID As Long
        Private m_strPartyRef As String
        Private m_dtCreationDate As Date
        Private m_strComments As String
        Private m_strSample As String
        Private m_strPacking As String
        Private m_strInspection As String
        Private m_bCEOApproval As Boolean
        Private m_bFabricPOrder As Boolean
        Private m_strPayMode As String
        Private m_dcTotalQty As Decimal
        Private m_bFabricStatus As Boolean
        Private m_strInditexPONo As String
        Private m_strConsumerAge As String
        Private m_strSalesContractNo As String
        Private m_strCodeEntry As String
        Private m_strRemarks As String
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Property CodeEntry() As String
            Get
                CodeEntry = m_strCodeEntry
            End Get
            Set(ByVal Value As String)
                m_strCodeEntry = Value
            End Set
        End Property
        Public Property SalesContractNo() As String
            Get
                SalesContractNo = m_strSalesContractNo
            End Get
            Set(ByVal Value As String)
                m_strSalesContractNo = Value
            End Set
        End Property
        Public Property ConsumerAge() As String
            Get
                ConsumerAge = m_strConsumerAge
            End Get
            Set(ByVal Value As String)
                m_strConsumerAge = Value
            End Set
        End Property
        Public Property InditexPONo() As String
            Get
                InditexPONo = m_strInditexPONo
            End Get
            Set(ByVal Value As String)
                m_strInditexPONo = Value
            End Set
        End Property
       

        Public Property ProcessOrderMstID() As Long
            Get
                ProcessOrderMstID = m_lProcessOrderMstID
            End Get
            Set(ByVal Value As Long)
                m_lProcessOrderMstID = Value
            End Set
        End Property
        Public Property PONo() As String
            Get
                PONo = m_PONo
            End Get
            Set(ByVal Value As String)
                m_PONo = Value
            End Set
        End Property
        Public Property POTypeID() As Long
            Get
                POTypeID = m_lPOTypeID
            End Get
            Set(ByVal Value As Long)
                m_lPOTypeID = Value
            End Set
        End Property
        Public Property PartyRef() As String
            Get
                PartyRef = m_strPartyRef
            End Get
            Set(ByVal Value As String)
                m_strPartyRef = Value
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
        Public Property Comments() As String
            Get
                Comments = m_strComments
            End Get
            Set(ByVal Value As String)
                m_strComments = Value
            End Set
        End Property
       
        Public Property Sample() As String
            Get
                Sample = m_strSample
            End Get
            Set(ByVal Value As String)
                m_strSample = Value
            End Set
        End Property
        Public Property Packing() As String
            Get
                Packing = m_strPacking
            End Get
            Set(ByVal Value As String)
                m_strPacking = Value
            End Set
        End Property
        Public Property Inspection() As String
            Get
                Inspection = m_strInspection
            End Get
            Set(ByVal Value As String)
                m_strInspection = Value
            End Set
        End Property
        Public Property CEOApproval() As Boolean
            Get
                CEOApproval = m_bCEOApproval
            End Get
            Set(ByVal Value As Boolean)
                m_bCEOApproval = Value
            End Set
        End Property

        Public Property FabricPOrder() As Boolean
            Get
                FabricPOrder = m_bFabricPOrder
            End Get
            Set(ByVal Value As Boolean)
                m_bFabricPOrder = Value
            End Set
        End Property
        Public Property PayMode() As String
            Get
                PayMode = m_strPayMode
            End Get
            Set(ByVal Value As String)
                m_strPayMode = Value
            End Set
        End Property
        Public Property TotalQty() As Decimal
            Get
                TotalQty = m_dcTotalQty
            End Get
            Set(ByVal Value As Decimal)
                m_dcTotalQty = Value
            End Set
        End Property
        Public Property FabricStatus() As Boolean
            Get
                FabricStatus = m_bFabricStatus
            End Get
            Set(ByVal Value As Boolean)
                m_bFabricStatus = Value
            End Set
        End Property
        Public Function SaveProcessOrderMst()
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
        Public Function CheckPONOExist(ByVal PONO As String)
            Dim Str As String
            Str = "select PONO From POMAster  where PONO='" & PONO & "' "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteFromPOMAster(ByVal POID As Long)
            Dim Str As String
            Str = " Delete from POMAster where POID=" & POID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteFromPODetail(ByVal POID As Long)
            Dim Str As String
            Str = " Delete from PODetail where POID=" & POID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforView()
            Dim Str As String
            Str = "select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID WHERE FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforViewNew()
            '--Bilal Awan amended Query
            Dim Str As String
            'Str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
            'Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
            'Str &= " WHERE FabricPOrder=0  "
            'Str = "    select Upper(ISNULL(a.AccessoriesName,'N/A'))  as article,POD.Style,ISNULL(POD.ProductType,'N/A') as TYPE,UPPER(SD.SupplierName)"
            'Str &= "  as SupplierNamee, *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , "
            'Str &= " convert(varchar,PO.DeliveryDate,103) DeliveryDatee  from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            'Str &= " left  join Accessories A on  a.Accessoriesid=POD.ITEMID left  join FabricDatabase F on  F.FabricDatabaseid=POD.ITEMID"
            'Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID left join UnitOfMeasurement IU on IU.uomID=POD.uomID"
            'Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            'Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId join IMSItemCategory itc on itc.IMSItemCategoryID=POD.ProductTypeId"
            'Str &= " join IMSItemClass IMC on IMC.IMSItemClassId=a.AccessoriesCategoryID WHERE FabricPOrder=0 order by po.creationdate Desc "

            Str = " select Upper(ISNULL(F.ItemName,'N/A'))  as article,POD.Style,ISNULL(POD.ProductType,'N/A') as TYPE,UPPER(SD.SupplierName) as  SupplierNamee,"
            Str &= " *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee   "
            Str &= " from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            Str &= " left join ImsItem F on  F.IMSITEMID=POD.ITEMID "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID"
            Str &= " left join UnitOfMeasurement IU on IU.uomID=POD.uomID"
            Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId "
            Str &= " join IMSItemCategory IMC on IMC.IMSItemCategoryId=POD.ProductTypeID  WHERE FabricPOrder=0 order by  po.POID desc "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforViewSummary()

            Dim Str As String
            Str = "  select PO.InditexPONo,FabricStatus,cONVERT(VARCHAR,PO.DeliveryDate,103) AS DeliveryDatee,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where FabricStatus = 0"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,PO.DeliveryDate,FabricStatus,PO.InditexPONo"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforViewSummarySearch(ByVal Search As String)

            Dim Str As String
            Str = "select FabricStatus,cONVERT(VARCHAR,PO.DeliveryDate,103) AS DeliveryDatee,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= " where FabricStatus=0 and PO.PONo='" & Search & "' or POD.PartyAccount='" & Search & "'"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,PO.DeliveryDate,FabricStatus"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforViewNewSearch(ByVal ItemName As String)
            '--Bilal Awan amended Query
            Dim Str As String
            Str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee,IM.AccessoriesName as Article from POMAster PO "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
            Str &= " WHERE FabricPOrder=0 and IM.AccessoriesName='" & ItemName & "' or PO.PONo='" & ItemName & "' or POD.PartyAccount='" & ItemName & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function FabricEditForDigitalNew(ByVal ProcessOrderMstID As String)
            Dim Str As String

            Str = "  select convert(varchar,POD.DeliveryDate,103) as DeliveryDatee,POD.Style,pod.SRNoID,sed.SeasonName +'  '+ SRNO  as SRNo, *,PO.CreationDate as PODate,b.ItemCodee as ProcessItemCodee,b.ItemName as ProcessItemName ,pod.Remarks as DetailRemarks,po.Remarks as MasterRemarks from ProcessOrderMst PO "
            Str &= " join  ProcessOrderDtl POD on PO.ProcessOrderMstID=POD.ProcessOrderMstID   "
            Str &= " join IMSITEM A on  a.IMSITEMID=POD.ITEMID join IMSITEM B on  B.IMSITEMID=POD.ProcessItemCodeID     "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID   "
            Str &= " join IMSItemUnit IU on IU.ItemUnitID=POD.uomID    "
            Str &= " join IMSItemCLASS itc on itc.IMSItemCLASSId=POD.ProducttYPEID  "
            Str &= " left join JobOrderdatabase JO on JO.joborderID=POd.SRNoID  "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  "
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId  "
            Str &= " left join  IssueType it on it.IssueTypeID =pod.IssueTypeID "
            Str &= " left join SeasonDatabase sed on sed.SeasonDatabaseID =jo.SeasonDatabaseID"
            Str &= "  where PO.ProcessOrderMstID ='" & ProcessOrderMstID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function FabricEditForDigital(ByVal ProcessOrderMstID As String)
            Dim Str As String

            Str = "  select POD.Style,pod.SRNoID,sed.SeasonName +'  '+ SRNO  as SRNo, *,PO.CreationDate as PODate,b.ItemCodee as ProcessItemCodee,b.ItemName as ProcessItemName  from ProcessOrderMst PO "
            Str &= " join  ProcessOrderDtl POD on PO.ProcessOrderMstID=POD.ProcessOrderMstID   "
            Str &= " join IMSITEM A on  a.IMSITEMID=POD.ITEMID join IMSITEM B on  B.IMSITEMID=POD.ProcessItemCodeID     "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID   "
            Str &= " join IMSItemUnit IU on IU.ItemUnitID=POD.uomID    "
            Str &= " join IMSItemCLASS itc on itc.IMSItemCLASSId=POD.ProducttYPEID  "
            Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId  "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  "
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId  "
            Str &= " left join  IssueType it on it.IssueTypeID =pod.IssueTypeID "
            Str &= " left join SeasonDatabase sed on sed.SeasonDatabaseID =jo.SeasonDatabaseID"
            Str &= "  where PO.ProcessOrderMstID ='" & ProcessOrderMstID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemAllInfo(ByVal ItemName As String)
            '--Bilal Awan amended Query
            Dim Str As String
            Str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
            Str &= " WHERE FabricPOrder=1 and IM.AccessoriesName='" & ItemName & "' or PO.PONo='" & ItemName & "' or POD.PartyAccount='" & ItemName & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforFabricViewNew()
            '--Bilal Awan amended Query
            Dim Str As String
            'Str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
            'Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
            'Str &= " WHERE FabricPOrder=1  "
            ''Str = "  select Upper(ISNULL(F.Fabricweave,'N/A'))  as article,POD.Style,ISNULL(POD.ProductType,'N/A') as TYPE,UPPER(SD.SupplierName) as"
            ''Str &= "  SupplierNamee, *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee "
            ''Str &= "   from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            ''Str &= " left  join Accessories A on  a.Accessoriesid=POD.ITEMID left  join FabricDatabase F on  F.FabricDatabaseid=POD.ITEMID"
            ''Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID left join UnitOfMeasurement IU on IU.uomID=POD.uomID"
            ''Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            ''Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId join IMSItemCategory itc on itc.IMSItemCategoryID=POD.ProductTypeId"
            ''Str &= " join IMSItemClass IMC on IMC.IMSItemClassId=a.AccessoriesCategoryID  WHERE FabricPOrder=1 order by  po.POID desc "
            Str = " select Upper(ISNULL(F.ItemName,'N/A'))  as article,POD.Style,ISNULL(POD.ProductType,'N/A') as TYPE,UPPER(SD.SupplierName) as  SupplierNamee,"
            Str &= " *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee   "
            Str &= " from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            Str &= " left join Accessories A on  a.Accessoriesid=POD.ITEMID "
            Str &= " left join ImsItem F on  F.IMSITEMID=POD.ITEMID "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID"
            Str &= " left join UnitOfMeasurement IU on IU.uomID=POD.uomID"
            Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId "
            Str &= " join IMSItemClass IMC on IMC.IMSItemClassId=POD.ProductTypeID  WHERE FabricPOrder=1 order by  po.POID desc "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforFabricViewSummary()

            Dim Str As String

            Str = "  select PO.InditexPONo,FabricStatus,cONVERT(VARCHAR,PO.DeliveryDate,103) AS DeliveryDatee,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style,POTypeID"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where FabricStatus = 1"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,PO.DeliveryDate,FabricStatus,POTypeID,PO.InditexPONo"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforFabricViewSummarysearch(ByVal Search As String)

            Dim Str As String

            Str = "  select FabricStatus,cONVERT(VARCHAR,PO.DeliveryDate,103) AS DeliveryDatee,PO.POID,PO.PONO,CONVERT(VARCHAR,PO.CreationDate,103) AS PODATE,sum(Quantity) as POQTY"
            Str &= " ,UPPER(SD.SupplierName)  as SupplierNamee,(select top 1 Style from PODetail podd where podd.POID=PO.POID ) as Style,POTypeID"
            Str &= " from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "      where FabricStatus = 1 and PO.PONo='" & Search & "' or POD.PartyAccount='" & Search & "'"
            Str &= " GROUP BY PO.PONO,PO.POID,PO.CreationDate,SD.SupplierName,PO.DeliveryDate,FabricStatus,POTypeID"
            Str &= " order by po.creationdate Desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforFabricView()
            Dim Str As String
            Str = "select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.DeliveryDate,103) DeliveryDatee,POTypeID from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID WHERE FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Edit(ByVal POID As String)
            Dim Str As String
            Str = " select * from POMAster PO "
            Str &= " join  PODetail POD on PO.POID=POD.POID "
            Str &= " join ItemProduct IP on  IP.ItemID=POD.ITEMID"
            Str &= " join ItemUnit IU on IU.ItemUnitID=IP.ItemUnitID"
            Str &= " join SupplierDatabase SD on SD.SupplierDatabaseID=POD.AccountPayablePartyID"
            Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId"
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId"
            Str &= " where PO.POID='" & POID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EditNew(ByVal POID As String)
            Dim Str As String
            Str = "  select *,PO.CreationDate as PODate  from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            Str &= "  join Accessories A on  a.Accessoriesid=POD.ITEMID"
            Str &= " join SupplierDatabase SD"
            Str &= " on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= " join UnitOfMeasurement IU on IU.uomID=POD.uomID  join IMSItemClass itc on itc.IMSItemClassId=POD.ProducttYPEID"
            Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId"
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId"
            Str &= " where PO.POID ='" & POID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EditNeww(ByVal POID As String)
            Dim Str As String
            Str = "  select POD.Style,isnull(PO.PayMode,'N/A') AS PayMode, isnull(PO.TotalQty,0) AS TotalQty,*,PO.CreationDate as PODate  from POMAster PO  "
            Str &= " join  PODetail POD on PO.POID=POD.POID "
            Str &= "    join Accessories A on  a.Accessoriesid=POD.ITEMID"
            Str &= "  join SupplierDatabase SD"
            Str &= "  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "  left  join UnitOfMeasurement IU on IU.uomID=POD.uomID  "
            Str &= "   left join IMSItemClass itc on itc.IMSItemClassId=POD.ProducttYPEID"
            Str &= "   left join JobOrderdatabase JO on JO.joborderID=PO.joborderId"
            Str &= "   left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            Str &= "   left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId"
            Str &= " where PO.POID ='" & POID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function FabricEditNeww(ByVal POID As String)
            Dim Str As String
            'Str = "  select POD.Style, *,PO.CreationDate as PODate  from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            'Str &= "  join Accessories A on  a.Accessoriesid=POD.ITEMID"
            'Str &= " join SupplierDatabase SD"
            'Str &= " on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            'Str &= " join UnitOfMeasurement IU on IU.uomID=POD.uomID  join IMSItemClass itc on itc.IMSItemClassId=POD.ProducttYPEID"
            'Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId"
            'Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            'Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId"
            'Str &= " where PO.POID ='" & POID & "' "

            Str = "  select POD.Style, *,PO.CreationDate as PODate  from POMAster PO "
            Str &= "  join  PODetail POD on PO.POID=POD.POID "
            Str &= "  join FabricDatabase A on  a.FabricDatabaseid=POD.ITEMID"
            Str &= "  join SupplierDatabase SD"
            Str &= "  on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            Str &= "  join IMSItemUnit IU on IU.ItemUnitID=POD.uomID  "
            Str &= "  join IMSItemCategory itc on itc.IMSItemCategoryId=POD.ProducttYPEID"
            Str &= "  left join JobOrderdatabase JO on JO.joborderID=PO.joborderId"
            Str &= "  left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            Str &= "  left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId"
            Str &= "  where PO.POID ='" & POID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        'Public Function FabricEditForDigital(ByVal POID As String)
        '    Dim Str As String


        '    Str = "   select POD.Style, *,PO.CreationDate as PODate  from POMAster PO "
        '    Str &= " join  PODetail POD on PO.POID=POD.POID   "
        '    Str &= " join IMSITEM A on  a.IMSITEMID=POD.ITEMID  "
        '    Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID   "
        '    Str &= " join IMSItemUnit IU on IU.ItemUnitID=POD.uomID    "
        '    Str &= " join IMSItemCLASS itc on itc.IMSItemCLASSId=POD.ProducttYPEID  "
        '    Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId  "
        '    Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  "
        '    Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId  "
        '    Str &= "  where PO.POID ='" & POID & "' "
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function FabricEditForDigitalAccessories(ByVal POID As String)
            Dim Str As String
            'Str = "  select POD.Style, *,PO.CreationDate as PODate  from POMAster PO  join  PODetail POD on PO.POID=POD.POID "
            'Str &= "  join Accessories A on  a.Accessoriesid=POD.ITEMID"
            'Str &= " join SupplierDatabase SD"
            'Str &= " on SD.SupplierDatabaseID=POd.AccountPayablePartyID "
            'Str &= " join UnitOfMeasurement IU on IU.uomID=POD.uomID  join IMSItemClass itc on itc.IMSItemClassId=POD.ProducttYPEID"
            'Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId"
            'Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID"
            'Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId"
            'Str &= " where PO.POID ='" & POID & "' "

            Str = "   select POD.Style, *,PO.CreationDate as PODate  from POMAster PO "
            Str &= " join  PODetail POD on PO.POID=POD.POID   "
            Str &= " join IMSITEM A on  a.IMSITEMID=POD.ITEMID  "
            Str &= " join SupplierDatabase SD  on SD.SupplierDatabaseID=POd.AccountPayablePartyID   "
            Str &= " join IMSItemUnit IU on IU.ItemUnitID=POD.uomID    "
            Str &= " join IMSItemCategory itc on itc.IMSItemCategoryId=POD.ProducttYPEID     "
            Str &= " left join JobOrderdatabase JO on JO.joborderID=PO.joborderId  "
            Str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  "
            Str &= " left join IMSDepartmentDataBase DP on DP.DeptDatabaseId=POD.DeptDatabaseId  "
            Str &= "  where PO.POID ='" & POID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEmbroidery()
            Dim Str As String
            Str = "select * from itemProduct where ItemCode=14 and ItemLevel=0 and ItemNaMe='EMBROIDERY' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSelectEmbroidery()
            Dim Str As String
            Str = "select * from ItemProduct where substring(itemcode,1,2)=14 and itemlevel=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function


        Public Function GetItemCode(ByVal ItemID As String)
            Dim Str As String
            Str = "select ItemCode From ItemProduct  where ItemID='" & ItemID & "' "
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductTypeFirstLevel()
            Dim Str As String
            Str = "select ItemID,ItemCode,ItemName From ItemProduct  where ItemLevel=0 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllAccs()
            Dim Str As String
            Str = " SELECT distinct itc.IMSItemClassId,itc.ItemClassName FROM  Accessories a"
            Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllAccDP()
            Dim Str As String
            'Str = "select distinct itc.IMSItemCategoryID,itc.ItemCategoryName from FabricDatabase fb "
            'Str &= " join IMSItemCategory itc on itc.IMSItemCategoryID=fb.fABRICcATID"
            Str = " Select * from IMSItemCategory IMS_IC "
            Str &= "  join IMSItemClass IMS_ICL  on IMS_IC.IMSItemClassID=IMS_ICL.IMSItemClassID"
            Str &= " join DPStoreType ST on ST.StoreTypeID=IMS_ICL.StoreTypeID"
            Str &= " where ST.StoreTypeID =2 order by IMS_IC.ItemCategoryName asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllFabric()
            Dim Str As String
            'Str = "select distinct itc.IMSItemCategoryID,itc.ItemCategoryName from FabricDatabase fb "
            'Str &= " join IMSItemCategory itc on itc.IMSItemCategoryID=fb.fABRICcATID"
            Str = " select * from IMSItemClass WHERE IMSItemClassid=6 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessItemForEditCasse()
            Dim Str As String

            Str = " select * from  IMSItem i"
            Str &= " join IMSItemClass ic on ic.IMSItemClassID =i.IMSItemClassID "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessItem(ByVal IMSItemid As Long)
            Dim Str As String
            'Str = "select distinct itc.IMSItemCategoryID,itc.ItemCategoryName from FabricDatabase fb "
            'Str &= " join IMSItemCategory itc on itc.IMSItemCategoryID=fb.fABRICcATID"
            'Str = " select * from IMSItemClass WHERE IMSItemClassid='" & IMSItemClassid & "' "
            Str = " select * from  IMSItem i"
            Str &= " join IMSItemClass ic on ic.IMSItemClassID =i.IMSItemClassID "
            Str &= " where i.IMSItemid ='" & IMSItemid & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        'Public Function GetProcessItem(ByVal IMSItemClassid As Long)
        '    Dim Str As String

        '    Str = " select * from IMSItemClass WHERE IMSItemClassid='" & IMSItemClassid & "' "
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        'Public Function GetProcessItemName(ByVal IMSItemClassid As Long)
        '    Dim Str As String
        '    Str = " select * from  IMSItem i"
        '    Str &= " join IMSItemClass ic on ic.IMSItemClassID =i.IMSItemClassID "
        '    Str &= " where ic.IMSItemClassID ='" & IMSItemClassid & "' "
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetProcessItemName(ByVal IMSItemid As Long)
            Dim Str As String
            Str = " select * from  IMSItem i"
            Str &= " join IMSItemClass ic on ic.IMSItemClassID =i.IMSItemClassID "
            Str &= " where i.IMSItemid ='" & IMSItemid & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessItemQuality(ByVal IMSItemid As Long)
            Dim Str As String
            Str = " select * from  IMSItem i"
            Str &= " join IMSItemClass ic on ic.IMSItemClassID =i.IMSItemClassID "
            Str &= " where i.IMSItemid ='" & IMSItemid & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        'Public Function GetProcessItemQuality(ByVal IMSItemClassid As Long)
        '    Dim Str As String
        '    Str = " select * from  IMSItem i"
        '    Str &= " join IMSItemClass ic on ic.IMSItemClassID =i.IMSItemClassID "
        '    Str &= " where ic.IMSItemClassID ='" & IMSItemClassid & "' "
        '    Try
        '        Return MyBase.GetDataTable(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function
        Public Function GetItemTypeFirstLevel(ByVal JoborderID As Long)
            Dim Str As String
            Str = "select distinct ja.ItemType as ItemName,ip.ItemCode from JobOrDBAccessoriesDetail ja"
            Str &= " join ItemProduct ip on ja.ItemType=ip.ItemName and Ip.Itemlevel=0"
            Str &= " where JobOrderId='" & JoborderID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemTypeFirstLevelNew(ByVal JoborderID As Long)
            Dim Str As String
            Str = " select distinct Itemtype  ,Itemcode from JobOrDBAccessoriesDetail JOA "
            Str &= " join ItemProduct IP on IP.Itemname =JOA.Itemtype  "
            Str &= " where JobOrderId='" & JoborderID & "' and Itemlevel=0"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemTypejOBWISENew(ByVal JoborderID As Long)
            Dim Str As String
            Str = " Select  distinct itc.IMSItemClassId,itc.ItemClassName  from AccessoriesePlanMst APM "
            Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            Str &= " where JobOrderId='" & JoborderID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemTypejOBWISENewCost(ByVal JoborderID As Long)
            Dim Str As String
            'Str = " Select  distinct itc.IMSItemClassId,itc.ItemClassName  from AccessoriesePlanMst APM "
            'Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            'Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            'Str &= " where JobOrderId='" & JoborderID & "' "

            Str = "  Select  distinct itc.IMSItemClassId,itc.ItemClassName, APM.Quantity  from AccessoriesCostMst APM "
            Str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            Str &= " where JobOrderId='" & JoborderID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemTypejOBWISENewCostNEWW(ByVal JoborderID As Long)
            Dim Str As String
            'Str = " Select  distinct itc.IMSItemClassId,itc.ItemClassName  from AccessoriesePlanMst APM "
            'Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            'Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            'Str &= " where JobOrderId='" & JoborderID & "' "

            ''Str = "  Select  distinct APM.Quantity  from AccessoriesCostMst APM "
            ''Str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            ''Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            ''Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            ''Str &= " where JobOrderId='" & JoborderID & "' "
            Str = " Select  distinct APM.Quantity  from FPlanMstNew APM "
            Str &= " join  FPlanDtlNew ACP ON ACP.FPlanMstNewID=APM.FPlanMstNewID"
            Str &= " where JobOrderId='" & JoborderID & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetjOBWISEQty(ByVal JoborderID As Long)
            Dim Str As String
            'Str = " Select  distinct itc.IMSItemClassId,itc.ItemClassName  from AccessoriesePlanMst APM "
            'Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            'Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            'Str &= " where JobOrderId='" & JoborderID & "' "

            ''Str = "  Select  distinct APM.Quantity  from AccessoriesCostMst APM "
            ''Str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            ''Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            ''Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            ''Str &= " where JobOrderId='" & JoborderID & "' "
            Str = " select SUM(jod.Quantity) as Quantity from joborderdatabase JO"
            Str &= " join JobOrderdatabaseDetail jod on jod.joborderid=JO.joborderid"
            Str &= " WHERE JO.joborderid = '" & JoborderID & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAccCategoryJObVise(ByVal JoborderID As Long)
            Dim Str As String
            Str = " select Distinct IMS_IC.IMSItemCategoryID,IMS_IC.ItemCategoryName from AccCheckListMst ACM"
            Str &= " JOIN AccCheckListDetail ACD ON ACM.AccCheckListMstID=ACD.AccCheckListMstID"
            Str &= " JOIN IMSItemCategory IMS_IC ON IMS_IC.IMSItemCategoryID=ACD.IMSItemCategoryID"
            Str &= "   where JoborderID = '" & JoborderID & "' "
            Str &= " order by ItemCategoryName"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabricItemTypejOBWISENewCost(ByVal JoborderID As Long)
            Dim Str As String
            'Str = " Select  distinct itc.IMSItemClassId,itc.ItemClassName  from AccessoriesePlanMst APM "
            'Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            'Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            'Str &= " where JobOrderId='" & JoborderID & "' "

            'Str = "  Select  distinct itc.IMSItemClassId,itc.ItemClassName  from AccessoriesCostMst APM "
            'Str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            'Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID  "
            'Str &= " where JobOrderId='" & JoborderID & "' "
            'Str = "  Select  distinct itc.IMSItemCategoryID,itc.ItemCategoryName  from FabricCostMst FCM "
            'Str &= " join  FabricCostDtl FCD ON FCD.FabricCostMstid=FCM.FabricCostMstid"
            'Str &= " join FabricDatabase fb on fb.FabricDatabaseid=FCD.FabricDatabaseid"
            'Str &= " join IMSItemCategory itc on itc.IMSItemCategoryID=fb.fABRICcATID"
            'Str &= " where JobOrderId='" & JoborderID & "' "
            ''Str = " Select  distinct ITM.IMSItemID,ITM.ItemName from FPlanMstNew FCM "
            ''Str &= " join  FPlanDtlNew FCD ON FCD.FPlanMstNewID=FCM.FPlanMstNewID"
            ''Str &= " join IMSItem ITM on ITM.IMSItemid=FCD.Fabricdatabaseid"
            ''Str &= "   where JobOrderId='" & JoborderID & "' "
            Str = " select * from IMSItemClass WHERE IMSItemClassid=6"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemLevelThree(Optional ByVal ItemCode As String = "")
            Dim Str As String
            If ItemCode = "" Then
                Str = "select ItemID,ItemCode,ItemName From ItemProduct  where ItemLevel=2"
            Else
                Str = "select ItemID,ItemCode,ItemName From ItemProduct  where left(ItemCode,6)='" & ItemCode & "'   and ItemLevel=2"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductName(ByVal ItemCode As String)
            Dim Str As String
            Str = "select ItemID,ItemName  From ItemProduct  where Itemcode Like '" & ItemCode & "%' and ItemLevel <> 0 "
            'Str = " select ItemCode,ItemName From ItemProduct  where left(ItemCode,2)='" & ItemCode & "'  and ItemLevel=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemAccs(ByVal AccessoriesCategoryID As Long)
            Dim Str As String
            Str = "SELECT a.Accessoriesid,a.AccessoriesName FROM  Accessories a"
            Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID"
            Str &= "   where AccessoriesCategoryID = '" & AccessoriesCategoryID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemAccDp(ByVal IMSItemCategory As Long)
            Dim Str As String

            Str = "select * from IMSItem WHERE IMSItemCategoryID='" & IMSItemCategory & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemFabric(ByVal FabricCatID As Long)
            Dim Str As String
            'Str = "SELECT a.Accessoriesid,a.AccessoriesName FROM  Accessories a"
            'Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID"
            'Str &= "   where AccessoriesCategoryID = '" & AccessoriesCategoryID & "'"

            'Str = "SELECT a.FabricDatabaseid,a.Fabricweave FROM  FabricDatabase a"
            'Str &= " join IMSItemCategory itc on itc.IMSItemCategoryId=a.FabricCatID"
            'Str &= " where FabricCatID = '" & FabricCatID & "'"
            Str = "select * from IMSItem WHERE IMSItemClassid=6"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemFabricNew(ByVal ItemCodee As String)
            Dim Str As String

            Str = "select * from IMSItem WHERE ItemCodee='" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemFabricNewForProcess(ByVal ItemCodee As String)
            Dim Str As String

            Str = "select * from IMSItem WHERE ItemCodee='" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemFabricNewForProcessGetRate(ByVal ItemId As Long)
            Dim Str As String

            Str = " select top 1  isnull((Rate),0) as Rate from PODetail WHERE ItemId='" & ItemId & "'"
            Str &= " order by PoDetailId desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemAccsFab(ByVal AccessoriesCategoryID As Long)
            Dim Str As String
            Str = "   Select  distinct  isnull(fdb.FabricDatabaseid,a.Accessoriesid) as FaAccessoriesid ,isnull(fdb.Fabricweave,a.AccessoriesName) as fbAccessoriesName  from AccessoriesePlanMst APM "
            Str &= "  join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            Str &= "  JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            Str &= "  join FPlanMst fm on fm.JobOrderId=APM.JobOrderId"
            Str &= "  join FPlanDtl fd on fd.FPlanMstId=fm.FPlanMstId"
            Str &= "  join FabricDatabase fdb on fdb.FabricDatabaseid=fd.FabricDatabaseid"
            Str &= "  join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID or itc.IMSItemClassId=13"
            Str &= "    where itc.IMSItemClassId = '" & AccessoriesCategoryID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetItemName(ByVal JoborderID As Long, ByVal ItemCode As String)
            Dim Str As String



            Str = " select * from JobOrDBAccessoriesDetail ja"
            Str &= " join ItemProduct ip on ip.ItemId=ja.ItemId"
            Str &= " where JobOrderID='" & JoborderID & "'and Itemcode Like '" & ItemCode & "%' and ItemLevel <> 0"


            'Str = "select * from JobOrDBAccessoriesDetail ja"
            ' Str &= " join ItemProduct ip on ip.ItemId=ja.ItemId  where JobOrderId='" & JoborderID & "'  "
            'Str = " select ItemCode,ItemName From ItemProduct  where left(ItemCode,2)='" & ItemCode & "'  and ItemLevel=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameNew(ByVal JoborderID As Long, ByVal ItemCode As String)
            Dim Str As String
            Str = " select distinct IP.ItemID,IP.ItemName From JobOrDBAccessoriesDetail JOA "
            Str &= " join ItemProduct IP on IP.ItemID =JOA.ItemID  where JOA.Joborderid='" & JoborderID & "' and IP.Itemcode Like '" & ItemCode & "%' and IP.ItemLevel <> 0  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameAccs(ByVal JoborderID As Long, ByVal AccessoriesCategoryID As Long)
            Dim Str As String

            Str = "  Select   a.Accessoriesid,a.AccessoriesName  from AccessoriesePlanMst APM "
            Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            Str &= " where JobOrderId='" & JoborderID & "'  and AccessoriesCategoryID='" & AccessoriesCategoryID & "'"
            ' Str = " select distinct IP.ItemID,IP.ItemName From JobOrDBAccessoriesDetail JOA "
            ' Str &= " join ItemProduct IP on IP.ItemID =JOA.ItemID  where JOA.Joborderid='" & JoborderID & "' and IP.Itemcode Like '" & ItemCode & "%' and IP.ItemLevel <> 0  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameAccsCost(ByVal JoborderID As Long, ByVal AccessoriesCategoryID As Long)
            Dim Str As String

            Str = "  Select   a.Accessoriesid,a.AccessoriesName  from AccessoriesCostMst APM "
            Str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            Str &= " where JobOrderId='" & JoborderID & "'  and AccessoriesCategoryID='" & AccessoriesCategoryID & "'"
            ' Str = " select distinct IP.ItemID,IP.ItemName From JobOrDBAccessoriesDetail JOA "
            ' Str &= " join ItemProduct IP on IP.ItemID =JOA.ItemID  where JOA.Joborderid='" & JoborderID & "' and IP.Itemcode Like '" & ItemCode & "%' and IP.ItemLevel <> 0  "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameAccsCostNew(ByVal JoborderID As Long, ByVal AccessoriesCategoryID As Long)
            Dim Str As String

            Str = "  Select   a.Accessoriesid,a.AccessoriesName,APM.joborderid  from AccessoriesCostMst APM  join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid join joborderdatabase JO on JO.joborderid=APM.joborderid"
            Str &= " where APM.JobOrderId='" & JoborderID & "'  and AccessoriesCategoryID='" & AccessoriesCategoryID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameFabricCost(ByVal JoborderID As Long, ByVal FabricCatID As Long)
            Dim Str As String

            'Str = "  Select   a.Accessoriesid,a.AccessoriesName  from AccessoriesCostMst APM "
            'Str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid"
            'Str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'Str &= " where JobOrderId='" & JoborderID & "'  and AccessoriesCategoryID='" & AccessoriesCategoryID & "'"
            Str = " Select   a.FabricDatabaseid,a.Fabricweave  from FabricCostMst APM "
            Str &= " join  FabricCostDtl ACP ON ACP.FabricCostMstid=APM.FabricCostMstid"
            Str &= " JOIN FabricDatabase a ON a.FabricDatabaseid=ACP.FabricDatabaseid"
            Str &= " where JobOrderId='" & JoborderID & "'  and a.FabricCatID='" & FabricCatID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameFabricCostNew(ByVal JoborderID As Long, ByVal FabricCatID As Long)
            Dim Str As String
            'Str = " Select   a.FabricDatabaseid,a.Fabricweave,JO.joborderid  from FabricCostMst APM "
            'Str &= " join  FabricCostDtl ACP ON ACP.FabricCostMstid=APM.FabricCostMstid"
            'Str &= " JOIN FabricDatabase a ON a.FabricDatabaseid=ACP.FabricDatabaseid join joborderdatabase JO on JO.joborderid=APM.joborderid"
            'Str &= " where APM.JobOrderId='" & JoborderID & "'  and a.FabricCatID='" & FabricCatID & "'"
            Str = " Select  distinct ITM.IMSItemID,ITM.ItemName from FPlanMstNew FCM "
            Str &= " join  FPlanDtlNew FCD ON FCD.FPlanMstNewID=FCM.FPlanMstNewID"
            Str &= " join IMSItem ITM on ITM.IMSItemid=FCD.Fabricdatabaseid"
            Str &= " where JobOrderId='" & JoborderID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameSearch(ByVal JoborderID As Long)
            Dim Str As String

            Str = " Select  distinct ITM.IMSItemID,ITM.ItemName from FPlanMstNew FCM "
            Str &= " join  FPlanDtlNew FCD ON FCD.FPlanMstNewID=FCM.FPlanMstNewID"
            Str &= " join IMSItem ITM on ITM.IMSItemid=FCD.Fabricdatabaseid"
            Str &= " where JobOrderId='" & JoborderID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameAccDP(ByVal JoborderID As Long, ByVal IMSItemCategoryID As Long)
            Dim Str As String

            Str = " select DISTINCT  IMS_IT.IMSItemID,IMS_IT.ItemName from AccCheckListMst ACM"
            Str &= " JOIN AccCheckListDetail ACD ON ACM.AccCheckListMstID=ACD.AccCheckListMstID"
            Str &= " JOIN IMSItem IMS_IT ON IMS_IT.IMSItemID=ACD.IMSItemID"
            Str &= " where ACD.IMSItemCategoryID = '" & IMSItemCategoryID & "' And JoborderID = '" & JoborderID & "'"
            Str &= " order by ItemName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemNameAccsFab(ByVal JoborderID As Long, ByVal AccessoriesCategoryID As Long)
            Dim Str As String

            Str = "    Select  distinct  isnull(fdb.FabricDatabaseid,a.Accessoriesid) as FaAccessoriesid ,isnull(fdb.Fabricweave,a.AccessoriesName) as fbAccessoriesName  from AccessoriesePlanMst APM "
            Str &= " join  AccessoriesePlanDtl ACP ON ACP.AccessoriesePlanMstid=APM.AccessoriesePlanMstid"
            Str &= "   JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            Str &= "  join FPlanMst fm on fm.JobOrderId=APM.JobOrderId"
            Str &= " join FPlanDtl fd on fd.FPlanMstId=fm.FPlanMstId"
            Str &= " join FabricDatabase fdb on fdb.FabricDatabaseid=fd.FabricDatabaseid"
            Str &= " join IMSItemClass itc on itc.IMSItemClassId=a.AccessoriesCategoryID or itc.IMSItemClassId=13"
            Str &= "  where fm.JobOrderId='" & JoborderID & "' and itc.IMSItemClassId='" & AccessoriesCategoryID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function


        Public Function GetLastVoucherNo(ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            str = " select Top 1 PONo from POMaster where year(CreationDate)='" & year & "' order By POID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastVoucherNoForProcessOrder(ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            str = " select Top 1 PONo from ProcessOrderMst where year(CreationDate)='" & year & "' order By ProcessOrderMstID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetail(ByVal lPoDetailId As Long)
            Dim Str As String
            Str = " Delete from PODetail where PoDetailId=" & lPoDetailId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindJobOrderNo()
            Dim str As String
            str = "  select JobOrderID,sd.SeasonName +'  '+ SRNO  as SRNO from JobOrderdatabase dp"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =dp.SeasonDatabaseID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindContractType()
            Dim str As String
            str = " select * from ContractType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOforViewNotApprove()
            Dim Str As String
            Str = "select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID where PO.CEOApproval=0  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforViewApprove()
            Dim Str As String
            Str = "select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee ,convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID  where PO.CEOApproval=1"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOforViewApprove(ByVal POMasterID As Long)
            Dim Str As String
            Str = " Update POMaster set CEOApproval=1 where POID= " & POMasterID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function CheckForPO(ByVal Joborderid As Long, ByVal ItemId As Long)
            Dim str As String
            str = "  select * from POMAster FM join PODetail PD on FM.POID=PD.POID join joborderdatabase jo on jo.joborderid=FM.joborderid"
            str &= " join AccessoriesCostMst PM on PM.joborderid=FM.joborderid where FabricPOrder=0 and FM.joborderid='" & Joborderid & "' and ItemId='" & ItemId & "' and FM.FabricStatus=0  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function CheckForAccPO(ByVal Joborderid As Long, ByVal ItemId As Long, ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = "    select * from POMAster FM"
            str &= " join PODetail PD on FM.POID=PD.POID"
            str &= " join joborderdatabase jo on jo.joborderid=FM.joborderid"
            str &= " where FabricPOrder=0 and FM.joborderid='" & Joborderid & "' and ItemId='" & ItemId & "' and ProductTypeid='" & IMSItemCategoryID & "' and FM.FabricStatus=0  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function CheckForPOFabricWise(ByVal Joborderid As Long, ByVal ItemId As Long)
            Dim str As String
            ''str = "  select * from POMAster FM  join PODetail PD on FM.POID=PD.POID  join joborderdatabase jo on jo.joborderid=FM.joborderid  "
            ''str &= " join FabricCostMst PM on PM.joborderid=FM.joborderid "
            ''str &= " where FabricPOrder=1 and FM.joborderid='" & Joborderid & "' and ItemId='" & ItemId & "'  and FM.FabricStatus=1 "
            str = "  select * from POMAster FM  join PODetail PD on FM.POID=PD.POID  join joborderdatabase jo on jo.joborderid=FM.joborderid  "
            str &= " join FPlanMstNew PM on PM.joborderid=FM.joborderid "
            str &= " where FabricPOrder=1 and FM.joborderid='" & Joborderid & "' and ItemId='" & ItemId & "'  and FM.FabricStatus=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckQuality(ByVal ItemId As Long)
            Dim str As String

            str = "  select ItemQuality+' '+ ItemComposition +' '+ItemFinish+' '+ItemWashDye as Quality,*"
            str &= " from IMSItem  where IMSItemid='" & ItemId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPartyFabricWiseForcmbParty()
            Dim str As String
            str = " select distinct POD.PartyAccount,POD.POID from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            str &= "  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId WHERE FabricPOrder=1 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPartyItemWiseForcmbParty()
            Dim str As String
            str = " select distinct POD.PartyAccount,POD.POID from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            str &= "  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId WHERE FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFabricWiseForcmbItem()
            Dim str As String
            str = " select distinct IM.AccessoriesName,IM.AccessoriesId from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            str &= " join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId WHERE FabricPOrder=1  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemItemWiseForcmbItem()
            Dim str As String
            str = " select distinct IM.AccessoriesId, IM.AccessoriesName from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            str &= "  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId WHERE FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleFabricWiseForStyle()
            Dim str As String
            str = " distinct select POD.Style,POD.PODetailid  from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            str &= " join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId WHERE FabricPOrder=1  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleItemWiseForStyle()
            Dim str As String
            str = " select distinct POD.PODetailid,POD.Style  from POMAster PO left join ContractType CT on CT.ContractTypeID=PO.POTypeID "
            str &= "  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId WHERE FabricPOrder=0 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMonthWiseViewForFabric(ByVal Style As String, ByVal Item As String, ByVal Party As String)
            Dim str As String
            If Style <> "" And Item <> "" And Party <> "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.PartyAccount='" & Party & "' and POD.Style='" & Style & "' and IM.AccessoriesName='" & Item & "' "
            ElseIf Style <> "" And Item <> "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.Style='" & Style & "' and IM.AccessoriesName='" & Item & "' "

            ElseIf Style <> "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.Style='" & Style & "'  "

            ElseIf Style = "" And Item = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.PartyAccount='" & Party & "' "

            ElseIf Style = "" And Party = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1  and IM.AccessoriesName='" & Item & "' "

            ElseIf Item = "" And Party = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1  and POD.Style='" & Style & "'  "

            ElseIf Style = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.PartyAccount='" & Party & "' and IM.AccessoriesName='" & Item & "' "

            ElseIf Item = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.PartyAccount='" & Party & "' and POD.Style='" & Style & "' "

            ElseIf Party = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 and POD.Style='" & Style & "' and IM.AccessoriesName='" & Item & "' "

            Else
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=1 "

            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMonthWiseViewForItem(ByVal Style As String, ByVal Item As String, ByVal Party As String)
            Dim str As String
            If Style <> "" And Item <> "" And Party <> "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.PartyAccount='" & Party & "' and POD.Style='" & Style & "' and IM.AccessoriesName='" & Item & "' "
            ElseIf Style <> "" And Item <> "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.Style='" & Style & "' and IM.AccessoriesName='" & Item & "' "

            ElseIf Style <> "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.Style='" & Style & "'  "

            ElseIf Style = "" And Item = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.PartyAccount='" & Party & "' "

            ElseIf Style = "" And Party = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0  and IM.AccessoriesName='" & Item & "' "

            ElseIf Item = "" And Party = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0  and POD.Style='" & Style & "'  "

            ElseIf Style = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.PartyAccount='" & Party & "' and IM.AccessoriesName='" & Item & "' "

            ElseIf Item = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.PartyAccount='" & Party & "' and POD.Style='" & Style & "' "

            ElseIf Party = "" Then
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 and POD.Style='" & Style & "' and IM.AccessoriesName='" & Item & "' "

            Else
                str = " select *,CT.ContractType as POType,convert(varchar,PO.Creationdate,103) Creationdatee , convert(varchar,PO.DeliveryDate,103) DeliveryDatee from POMAster PO "
                str &= " left join ContractType CT on CT.ContractTypeID=PO.POTypeID  join PODetail POD on POD.POID=PO.POID  join Accessories IM on IM.AccessoriesId=POD.ItemId"
                str &= " WHERE FabricPOrder=0 "

            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETAUTOItemFabName(ByVal Name As String)
            Dim str As String
            str = " select AccessoriesName from Accessories  WHERE AccessoriesName like '" & Name & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try


        End Function
        Public Function GETAUTOItemCode(ByVal Name As String)
            Dim str As String
            str = " select ItemCodee  from IMSITEM WHERE FabricDBMstId >0 AND ItemCodee like '" & Name & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try


        End Function
        Public Function GETAUTOItemCodeNew(ByVal Name As String)
            Dim str As String
            str = "  select ItemCodee  from IMSITEM ITD"
            str &= " join IMSItemCategory ITC on ITC.IMSItemCategoryID=ITD.IMSItemCategoryID"
            str &= " JOIN IMSItemClass ITCL on ITCL.IMSItemClassID=ITC.IMSItemClassID"
            str &= " WHERE ITCL.StoreTypeId=1 AND ItemCodee like '" & Name & "%'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try


        End Function
        Public Function GetCmbFrom()
            Dim str As String
            str = " SELECT DeptDatabaseName+ '  ('+ DeptAbbrivation+')' as DeptDatabaseName,DeptDatabaseId FROM IMSDepartmentDataBase"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetUOMItem() As DataTable
            Dim str As String
            str = " Select * from IMSItemUnit "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetQtyandUnitByJobwiseFabricNewCostNEWWWWW(ByVal AccessoriesID As Long, ByVal Joborderid As Long)
            Dim str As String

            'str = "  Select   Sum(Gross) as Qty,ACP.ItemUnitid as UOMID,ACP.UnitCost as Unitrate,ACP.StyleId ,ACP.Style    from AccessoriesCostMst APM "
            'str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid  "
            'str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'str &= " JOIN IMSItem itm on itm.IMSItemid=a.IMSItemid"
            'str &= "   where Joborderid ='" & Joborderid & "'  and ACP.AccessoriesID='" & AccessoriesID & "'"
            'str &= " GROUP BY ACP.ItemUnitid,ACP.UnitCost ,ACP.Style ,ACP.StyleId "

            'str = "   Select   Sum(Gross) as Qty,isnull(itm.ItemUnitid,0) as UOMID,ACP.FabricCost as Unitrate ,ACP.JobOrderDetailid ,"
            'str &= " ACP.Style,APM.joborderid   from FabricCostMst APM  join  FabricCostDtl ACP ON ACP.FabricCostMstid=APM.FabricCostMstid  "
            'str &= " JOIN FabricDatabase a ON a.FabricDatabaseid=ACP.FabricDatabaseid left JOIN IMSItem itm on itm.IMSItemid=a.IMSItemid"
            'str &= " join joborderdatabase jo on jo.joborderid=APM.joborderid   where APM.Joborderid ='" & Joborderid & "'  and ACP.FabricDatabaseid='" & AccessoriesID & "' "
            'str &= " GROUP BY itm.ItemUnitid,ACP.FabricCost ,ACP.Style ,ACP.JobOrderDetailid ,itm.IMSItemid,APM.joborderid "

            str = "  Select  ACP.CurrencyId,ExchangeRate , Sum(Gross) as Qty,isnull(itm.ItemUnitid,0) as UOMID,ACP.FabricCost as Unitrate ,ACP.JobOrderDetailid ,"
            str &= " ACP.Style,APM.joborderid   from FPlanMstNew APM  "
            str &= " join  FPlanDtlNew ACP ON ACP.FPlanMstNewID=APM.FPlanMstNewID  "
            str &= " JOIN IMSItem itm on itm.IMSItemid=ACP.Fabricdatabaseid"
            str &= "  join joborderdatabase jo on jo.joborderid=APM.joborderid   "
            str &= " where APM.Joborderid ='" & Joborderid & "'  and ACP.FabricDatabaseid='" & AccessoriesID & "' "
            str &= " GROUP BY itm.ItemUnitid,ACP.FabricCost ,ACP.Style ,ACP.JobOrderDetailid ,itm.IMSItemid,APM.joborderid,ExchangeRate,ACP.CurrencyId  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        ''' <summary>
        ''' ''For Acc. Check List
        ''' </summary>
        ''' <param name="AccessoriesID"></param>
        ''' <param name="Joborderid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetQtyandUnitByJobwiseAccDP(ByVal IMSItemCategoryID As Long, ByVal IMSItemID As Long, ByVal Joborderid As Long)
            Dim str As String

            'str = "  Select   Sum(Gross) as Qty,ACP.ItemUnitid as UOMID,ACP.UnitCost as Unitrate,ACP.StyleId ,ACP.Style    from AccessoriesCostMst APM "
            'str &= " join  AccessoriesCostDtl ACP ON ACP.AccessoriesCostMstid=APM.AccessoriesCostMstid  "
            'str &= " JOIN Accessories a ON a.Accessoriesid=ACP.Accessoriesid"
            'str &= " JOIN IMSItem itm on itm.IMSItemid=a.IMSItemid"
            'str &= "   where Joborderid ='" & Joborderid & "'  and ACP.AccessoriesID='" & AccessoriesID & "'"
            'str &= " GROUP BY ACP.ItemUnitid,ACP.UnitCost ,ACP.Style ,ACP.StyleId "

            'str = "   Select   Sum(Gross) as Qty,isnull(itm.ItemUnitid,0) as UOMID,ACP.FabricCost as Unitrate ,ACP.JobOrderDetailid ,"
            'str &= " ACP.Style,APM.joborderid   from FabricCostMst APM  join  FabricCostDtl ACP ON ACP.FabricCostMstid=APM.FabricCostMstid  "
            'str &= " JOIN FabricDatabase a ON a.FabricDatabaseid=ACP.FabricDatabaseid left JOIN IMSItem itm on itm.IMSItemid=a.IMSItemid"
            'str &= " join joborderdatabase jo on jo.joborderid=APM.joborderid   where APM.Joborderid ='" & Joborderid & "'  and ACP.FabricDatabaseid='" & AccessoriesID & "' "
            'str &= " GROUP BY itm.ItemUnitid,ACP.FabricCost ,ACP.Style ,ACP.JobOrderDetailid ,itm.IMSItemid,APM.joborderid "

            str = " select SUM(ACD.OrderQty)as Qty,isnull(IMS_IT.ItemUnitid,0) as UOMID,'0' as Unitrate"
            str &= " ,Acm.JobOrderDetailid,jod.Style,Acm.joborderid,ContentForBuyer,ColorCode"
            str &= " from AccCheckListMst ACM"
            str &= " JOIN AccCheckListDetail ACD ON ACM.AccCheckListMstID=ACD.AccCheckListMstID"
            str &= " JOIN IMSItem IMS_IT ON IMS_IT.IMSItemID=ACD.IMSItemID"
            str &= " join joborderdatabase jo on jo.joborderid=Acm.joborderid "
            str &= " join JobOrderdatabaseDetail jod on jod.JobOrderDetailid=Acm.JobOrderDetailid"
            str &= " where ACD.IMSItemCategoryID = '" & IMSItemCategoryID & "' And Acm.JobOrderid = '" & Joborderid & "' and ACD.IMSItemID='" & IMSItemID & "'"
            str &= " GROUP BY IMS_IT.ItemUnitId,ACM.JoborderDetailID,Style,Acm.joborderid,ContentForBuyer,ColorCode"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetQtyandUnitByJobwiseAccDPNew(ByVal IMSItemCategoryID As Long, ByVal IMSItemID As Long, ByVal Joborderid As Long)
            Dim str As String


            str = " select SUM(ACD.OrderQty)as Qty,IMS_IT.Shade,IMS_IT.ItemQuality,isnull(IMS_IT.ItemUnitid,0) as UOMID,'0' as Unitrate"
            str &= " ,Acm.JobOrderDetailid,jod.Style,Acm.joborderid,ContentForBuyer,ColorCode"
            str &= " from AccCheckListMst ACM"
            str &= " JOIN AccCheckListDetail ACD ON ACM.AccCheckListMstID=ACD.AccCheckListMstID"
            str &= " JOIN IMSItem IMS_IT ON IMS_IT.IMSItemID=ACD.IMSItemID"
            str &= " join joborderdatabase jo on jo.joborderid=Acm.joborderid "
            str &= " join JobOrderdatabaseDetail jod on jod.JobOrderDetailid=Acm.JobOrderDetailid"
            str &= " where ACD.IMSItemCategoryID = '" & IMSItemCategoryID & "' And Acm.JobOrderid = '" & Joborderid & "' and ACD.IMSItemID='" & IMSItemID & "'"
            str &= " GROUP BY IMS_IT.ItemUnitId,ACM.JoborderDetailID,Style,Acm.joborderid,ContentForBuyer,ColorCode,IMS_IT.Shade,IMS_IT.ItemQuality"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetQtyandUnitByJobwiseAccDPNewForWithoutJobNo(ByVal IMSItemCategoryID As Long, ByVal IMSItemID As Long)
            Dim str As String


            str = " select SUM(ACD.OrderQty)as Qty,IMS_IT.Shade,IMS_IT.ItemQuality,isnull(IMS_IT.ItemUnitid,0) as UOMID,'0' as Unitrate"
            str &= " ,Acm.JobOrderDetailid,jod.Style,Acm.joborderid,ContentForBuyer,ColorCode"
            str &= " from AccCheckListMst ACM"
            str &= " JOIN AccCheckListDetail ACD ON ACM.AccCheckListMstID=ACD.AccCheckListMstID"
            str &= " JOIN IMSItem IMS_IT ON IMS_IT.IMSItemID=ACD.IMSItemID"
            str &= " join joborderdatabase jo on jo.joborderid=Acm.joborderid "
            str &= " join JobOrderdatabaseDetail jod on jod.JobOrderDetailid=Acm.JobOrderDetailid"
            str &= " where ACD.IMSItemCategoryID = '" & IMSItemCategoryID & "' And ACD.IMSItemID='" & IMSItemID & "'"
            str &= " GROUP BY IMS_IT.ItemUnitId,ACM.JoborderDetailID,Style,Acm.joborderid,ContentForBuyer,ColorCode,IMS_IT.Shade,IMS_IT.ItemQuality"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetQtyandUnitByJobwiseAccDPNewForWithoutJobNoNew(ByVal IMSItemCategoryID As Long, ByVal IMSItemID As Long)
            Dim str As String

            str = " select IMS_IT.Shade,IMS_IT.ItemQuality,isnull(IMS_IT.ItemUnitid,0) as UOMID"
            str &= " from IMSItem IMS_IT"
            str &= " where IMS_IT.IMSItemCategoryID = '" & IMSItemCategoryID & "' And IMS_IT.IMSItemID='" & IMSItemID & "'"
            str &= " GROUP BY IMS_IT.ItemUnitId,IMS_IT.Shade,IMS_IT.ItemQuality"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetCurrency() As DataTable
            Dim str As String
            ' str = " select * from IMSSupplier where IMSSupplierCategoryId=5"


            str = " select * from Currency "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricConAndCompositionFromItemDatabase(ByVal IMSItemid As String)
            Dim str As String

            str = " select ItemQuality,Shade from IMSItem WHERE IMSItemid='" & IMSItemid & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function BindIssue(ByVal ItemCodee As String) As DataTable
            Dim str As String

            str = "  select * from  IMSItem"
            str &= " where ItemCodee ='" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function



    End Class

End Namespace
