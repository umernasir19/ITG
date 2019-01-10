Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class TblDPRND
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TblDPRND"
            m_strPrimaryFieldName = "DPRNDID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType

        End Sub
        Private m_lDPRNDID As Long
        Private m_strCreatDate As Date
        Private m_strCustomerId As Long
        Private m_strBuyer As String
        Private m_strStyle As String
        Private m_strContactNo As String
        Private m_strDept As String
        Private m_strDALNo As String
        Private m_strQuantity As Decimal
        Private m_strSize As String
        Private m_strPocketlining As String
        Private m_strPattern As String
        Private m_strWashingDetail As String
        Private m_strThread As String
        Private m_strWidthCutable As String
        Private m_strRemarks As String
        'Private m_strMarketLength As String
        'Private m_strConsumption As String
        'Private m_strShrinkage As String
        'Private m_strOtherDetail As String
        Private m_strFabricPrice As Decimal
        Private m_strGarmentPrice As Decimal
        Private m_strFileName As String
        Private m_imgImage As Object
        Private m_strFileNameGPD As String
        Private m_imgImageGDP As Object
        Private m_lFabricDBMstId As Long
        ' Private m_strSizes As String
        Private m_imgImageTechPack As Object
        Private m_strFileNameTP As String
        Private m_strBuyerReferenceNo As String
        Private m_strThreads As String
        Private m_strAllowToGGT As Byte
        Private m_strGGTStatus As Byte
        Private m_strCreationTime As String
        Private m_dtConsumptionDate As Date
        Private m_strDigitalSignature As Byte
        Private m_strLockToGGT As Byte
        Public Property LockToGGT() As Boolean
            Get
                LockToGGT = m_strLockToGGT
            End Get
            Set(ByVal value As Boolean)
                m_strLockToGGT = value
            End Set
        End Property
        Public Property DigitalSignature() As Boolean
            Get
                DigitalSignature = m_strDigitalSignature
            End Get
            Set(ByVal value As Boolean)
                m_strDigitalSignature = value
            End Set
        End Property
        Public Property ConsumptionDate() As Date
            Get
                ConsumptionDate = m_dtConsumptionDate
            End Get
            Set(ByVal value As Date)
                m_dtConsumptionDate = value
            End Set
        End Property
        Public Property CreationTime() As String
            Get
                CreationTime = m_strCreationTime
            End Get
            Set(ByVal value As String)
                m_strCreationTime = value
            End Set
        End Property
        Public Property GGTStatus() As Boolean
            Get
                GGTStatus = m_strGGTStatus
            End Get
            Set(ByVal value As Boolean)
                m_strGGTStatus = value
            End Set
        End Property
        Public Property AllowToGGT() As Boolean
            Get
                AllowToGGT = m_strAllowToGGT
            End Get
            Set(ByVal value As Boolean)
                m_strAllowToGGT = value
            End Set
        End Property
        Public Property Threads() As String
            Get
                Threads = m_strThreads
            End Get
            Set(ByVal value As String)
                m_strThreads = value
            End Set
        End Property
        Public Property BuyerReferenceNo() As String
            Get
                BuyerReferenceNo = m_strBuyerReferenceNo
            End Get
            Set(ByVal value As String)
                m_strBuyerReferenceNo = value
            End Set
        End Property
        Public Property FabricDBMstId() As Long
            Get
                FabricDBMstId = m_lFabricDBMstId
            End Get
            Set(ByVal value As Long)
                m_lFabricDBMstId = value
            End Set
        End Property

        Public Property DPRNDID() As Long
            Get
                DPRNDID = m_lDPRNDID
            End Get
            Set(ByVal value As Long)
                m_lDPRNDID = value
            End Set
        End Property
        Public Property CreatDate() As Date
            Get
                CreatDate = m_strCreatDate
            End Get
            Set(ByVal value As Date)
                m_strCreatDate = value
            End Set
        End Property
        Public Property CustomerId() As Long
            Get
                CustomerId = m_strCustomerId
            End Get
            Set(ByVal value As Long)
                m_strCustomerId = value
            End Set
        End Property
        Public Property Buyer() As String
            Get
                Buyer = m_strBuyer
            End Get
            Set(ByVal value As String)
                m_strBuyer = value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Property ContactNo() As String
            Get
                ContactNo = m_strContactNo
            End Get
            Set(ByVal value As String)
                m_strContactNo = value
            End Set
        End Property
        Public Property Dept() As String
            Get
                Dept = m_strDept
            End Get
            Set(ByVal value As String)
                m_strDept = value
            End Set
        End Property
        Public Property DALNo() As String
            Get
                DALNo = m_strDALNo
            End Get
            Set(ByVal value As String)
                m_strDALNo = value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_strQuantity
            End Get
            Set(ByVal value As Decimal)
                m_strQuantity = value
            End Set
        End Property
        Public Property Size() As String
            Get
                Size = m_strSize
            End Get
            Set(ByVal value As String)
                m_strSize = value
            End Set
        End Property
        Public Property Pocketlining() As String
            Get
                Pocketlining = m_strPocketlining
            End Get
            Set(ByVal value As String)
                m_strPocketlining = value
            End Set
        End Property
        Public Property Pattern() As String
            Get
                Pattern = m_strPattern
            End Get
            Set(ByVal value As String)
                m_strPattern = value
            End Set
        End Property
        Public Property WashingDetail() As String
            Get
                WashingDetail = m_strWashingDetail
            End Get
            Set(ByVal value As String)
                m_strWashingDetail = value
            End Set
        End Property
        Public Property Thread() As String
            Get
                Thread = m_strThread
            End Get
            Set(ByVal value As String)
                m_strThread = value
            End Set
        End Property
        Public Property WidthCutable() As String
            Get
                WidthCutable = m_strWidthCutable
            End Get
            Set(ByVal value As String)
                m_strWidthCutable = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        'Public Property MarketLength() As String
        '    Get
        '        MarketLength = m_strMarketLength
        '    End Get
        '    Set(ByVal value As String)
        '        m_strMarketLength = value
        '    End Set
        'End Property
        'Public Property Consumption() As String
        '    Get
        '        Consumption = m_strConsumption
        '    End Get
        '    Set(ByVal value As String)
        '        m_strConsumption = value
        '    End Set
        'End Property
        'Public Property Shrinkage() As String
        '    Get
        '        Shrinkage = m_strShrinkage
        '    End Get
        '    Set(ByVal value As String)
        '        m_strShrinkage = value
        '    End Set
        'End Property
        'Public Property OtherDetail() As String
        '    Get
        '        OtherDetail = m_strOtherDetail
        '    End Get
        '    Set(ByVal value As String)
        '        m_strOtherDetail = value
        '    End Set
        'End Property
        Public Property FabricPrice() As Decimal
            Get
                FabricPrice = m_strFabricPrice
            End Get
            Set(ByVal value As Decimal)
                m_strFabricPrice = value
            End Set
        End Property
        Public Property GarmentPrice() As Decimal
            Get
                GarmentPrice = m_strGarmentPrice
            End Get
            Set(ByVal value As Decimal)
                m_strGarmentPrice = value
            End Set
        End Property
        Public Property FileName() As String
            Get
                FileName = m_strFileName
            End Get
            Set(ByVal value As String)
                m_strFileName = value
            End Set
        End Property
        Public Property Image() As Object
            Get
                Image = m_imgImage
            End Get
            Set(ByVal value As Object)
                m_imgImage = value
            End Set
        End Property
        'Public Property Sizes() As String
        '    Get
        '        Sizes = m_strSizes
        '    End Get
        '    Set(ByVal value As String)
        '        m_strSizes = value
        '    End Set
        'End Property
        Public Property FileNameGPD() As String
            Get
                FileNameGPD = m_strFileNameGPD
            End Get
            Set(ByVal value As String)
                m_strFileNameGPD = value
            End Set
        End Property
        Public Property ImageGDP() As Object
            Get
                ImageGDP = m_imgImageGDP
            End Get
            Set(ByVal value As Object)
                m_imgImageGDP = value
            End Set
        End Property
        Public Property ImageTechPack() As Object
            Get
                ImageTechPack = m_imgImageTechPack
            End Get
            Set(ByVal value As Object)
                m_imgImageTechPack = value
            End Set
        End Property
        Public Property FileNameTP() As String
            Get
                FileNameTP = m_strFileNameTP
            End Get
            Set(ByVal value As String)
                m_strFileNameTP = value
            End Set
        End Property
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function

        Public Function SaveRND()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Public Function GetFBData(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where fm.DalNo='" & DalNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFrontImageFromStyleDatabaseNew(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select * from DPStyleDatabase"
                str &= " where REPLACE(StyleCode, '/', '\')='" & StyleCode & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFrontImageFromStyleDatabase(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select * from DPStyleDatabase"
                str &= " where StyleCode='" & StyleCode & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyerReferenceNo(ByVal CustomerName As String)
            Dim str As String
            Try
                str = "select isnull(BuyerReferenceNo,'N/A') as BuyerReferenceNoo,* from customer"
                str &= " where CustomerName='" & CustomerName & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindUnit()
            Dim str As String
            Try
                str = "select * from ConsumptionUnit"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBackImageFromStyleDatabaseNew(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select * from DPStyleDatabase"
                str &= " where REPLACE(StyleCode, '/', '\')='" & StyleCode & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBackImageFromStyleDatabase(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select * from DPStyleDatabase"
                str &= " where StyleCode='" & StyleCode & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRecvQtyForSampleIssue(ByVal FabricDBMstID As Long)
            Dim str As String
            Try
                str = " select isnull(sum(Mst.BalanceQty),0) as BalanceQty from DPFabricIssue Mst "
                str &= " where Mst.FabricDBMstID='" & FabricDBMstID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomer()
            Dim str As String
            Try
                str = "select * from Customer "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPItemDatabase()
            Dim str As String
            Try
                str = "select * from DPItemDatabase "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDepartment()
            Dim str As String
            Try
                str = "select * from UMDepartment "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDesignationNew(ByVal RoleID As Long)
            Dim str As String
            Try
                str = " SELECT * FROM RMRole RM  join UMDepartment UD on UD.UMDepartmentID=RM.UMDepartmentID"
                str &= " where RM.RoleID='" & RoleID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataonGrid()
            Dim str As String
            Try
                str = " select * from RMFormRoles where Sequence <>0"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BingMenuDropdown()
            Dim str As String
            Try
                str = " select * from RMFormRoles where Sequence =0"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDesignation()
            Dim str As String
            Try
                str = " SELECT * FROM RMRole RM "
                str &= " WHERE RM.RoleId NOT iN (1,3,4,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,31,32,33,34,36,37,38,39,40,41,42,43,44)"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForUserSetup(ByVal UserID As Long)
            Dim str As String
            Try
                str = " select * from UMUser UN"
                str &= " join RMUserRoles RMU on rmu.UserId=UN.UserId"
                str &= " join RMRole R on R.RoleId =RMU.RoleId "
                str &= " JOIN UMDepartment UD on UD.UMDepartmentID=R.UMDepartmentID  where UN.UserID='" & UserID & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForRoleSetup(ByVal RoleID As Long)
            Dim str As String
            Try
                str = " SELECT * FROM RMRole RM"
                str &= " join UMDepartment UD on UD.UMDepartmentID=RM.UMDepartmentID  where RM.RoleID='" & RoleID & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditData(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "select convert (varchar,CreatDate,103) as CreatDatee, * from TblDPRND where DPRNDID='" & DPRNDID & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForCommodity(ByVal CommodityID As Long)
            Dim str As String
            Try
                str = "select * from Commodity where CommodityID='" & CommodityID & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForPackingList(ByVal PackingMstID As Long)
            Dim str As String
            Try
                str = " select *,CD.PackingPCS - isnull((select SUM(dtll.RecvPackingPCS) from  PackingDtl Dtll where"
                str &= " Dtll.CargoDetailID =Dtl.CargoDetailID),0) as BalanceQty from PackingMst Mst"
                str &= " join PackingDtl Dtl on Dtl.PackingMstID =MST.PackingMstID  join CargoDetail CD on CD.CargoDetailID =Dtl .CargoDetailID  where MST.PackingMstID='" & PackingMstID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForSecondGrid(ByVal PackingMstID As Long)
            Dim str As String
            Try
                str = " select * from  PackingMst Mst"
                str &= " join PackingDtl Dtl on Dtl.PackingMstID =MST.PackingMstID  where MST.PackingMstID='" & PackingMstID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditForPacking(ByVal PackingMstID As Long)
            Dim str As String
            Try
                str = " select * from PackingMst Mst"
                str &= " join PackingDTL Dtl on Dtl.PackingMstID =mst.PackingMstID"
                str &= " join Customer  C on C.CustomerID =DTL.CustomerID"
                str &= " JOIN Numberingfinal N on N.NumberingfinalID =DTL.NumberingfinalID"
                str &= " where MST.PackingMstID='" & PackingMstID & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData()
            Dim str As String
            Try
                '  str = "select convert (varchar,CreatDate,103) as CreatDatee, * from TblDPRND"
                str = " select convert (varchar,CreatDate,103) as CreatDatee, * from TblDPRND TD "
                str &= " join DPFabricDbMst FD ON FD.FabricDbMstID=TD.FabricDbMstID "
                str &= "  Join SupplierDatabase V on  V.SupplierDatabaseID=FD.SupplierId"
                str &= " order by DPRNDID DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNew()
            Dim str As String
            Try
                '  str = "select convert (varchar,CreatDate,103) as CreatDatee, * from TblDPRND"
                str = " select convert (varchar,CreatDate,103) as CreatDatee, *,"
                str &= " case when TD.AllowToGGT = 1  then"
                str &= "  'Yes'"
                str &= " else"
                str &= "   'No' end as Status"
                str &= "  ,"
                str &= "  case when TD.GGTStatus = 1  then"
                str &= "  'Yes'"
                str &= "  else"
                str &= "  'No' end as GGTStatuss"
                str &= "  ,isnull((select SDD.ConsumptionPerPCS from DPRNDStyleDetail SDD WHERE SDD.DPRNDID=TD.DPRNDID and SDD.IsBodyFabric=1),0)"
                str &= "  as Consumption,(select sum(1) from TblDPRND TDDD where TDDD.DPRNDid>=TD.DPRNDid) as RowNo "

                str &= "    ,case when (select top 1 FCC.DalNo from TblDPRND FCC"
                str &= " JOIN DPRNDStyleDetail FCD on FCD.DPRNDID=FCC.DPRNDID"
                str &= " WHERE FCC.DPRNDID=TD.DPRNDID) <>''"
                str &= " THEN convert(varchar,TD.ConsumptionDate,103) else '' end as ConDate"

                str &= " from TblDPRND TD "
                str &= " join DPFabricDbMst FD ON FD.FabricDbMstID=TD.FabricDbMstID "
                str &= "  Join SupplierDatabase V on  V.SupplierDatabaseID=FD.SupplierId"
                str &= " order by DPRNDID DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForGGT()
            Dim str As String
            Try

                str = "  select convert (varchar,CreatDate,103) as CreatDatee, *, case when TD.AllowToGGT = 1  "
                str &= "  then 'Yes' else  'No' end as Status  ,  case when TD.GGTStatus = 1  then  'Yes' else  'No' end as GGTStatuss, "
                str &= "  isnull((select top 1 SDD.ConsumptionPerPCS  from DPRNDStyleDetail SDD WHERE SDD.DPRNDID=TD.DPRNDID and SDD.IsBodyFabric=1 "
                str &= " order by  sdd.DPRNDStyleDetailID DESC),0)  as Consumption, "
                str &= " (select sum(1)  from TblDPRND TDDD where TDDD.DPRNDid>=TD.DPRNDid) as RowNo ,case when (select top 1 FCC.DalNo  "
                str &= " from TblDPRND FCC JOIN DPRNDStyleDetail FCD on FCD.DPRNDID=FCC.DPRNDID  "
                str &= " WHERE FCC.DPRNDID=TD.DPRNDID) <>'' THEN convert(varchar,TD.ConsumptionDate,103) "
                str &= " else '' end as ConDate from TblDPRND TD  join DPFabricDbMst FD ON FD.FabricDbMstID=TD.FabricDbMstID   "
                str &= "  Join SupplierDatabase V on  V.SupplierDatabaseID=FD.SupplierId where TD.AllowToGGT=1 order by DPRNDID DESC "

                'str = " select convert (varchar,CreatDate,103) as CreatDatee, *,"
                'str &= " case when TD.AllowToGGT = 1  then"
                'str &= " 'Yes'"
                'str &= " else"
                'str &= "  'No' end as Status"
                'str &= "  ,"
                'str &= "  case when TD.GGTStatus = 1  then"
                'str &= "  'Yes'"
                'str &= "  else"
                'str &= "  'No' end as GGTStatuss"
                'str &= "  ,isnull((select SDD.ConsumptionPerPCS from DPRNDStyleDetail SDD WHERE SDD.DPRNDID=TD.DPRNDID and SDD.IsBodyFabric=1),0)"
                'str &= "  as Consumption,(select sum(1) from TblDPRND TDDD where TDDD.DPRNDid>=TD.DPRNDid) as RowNo"

                'str &= "    ,case when (select top 1 FCC.DalNo from TblDPRND FCC"
                'str &= " JOIN DPRNDStyleDetail FCD on FCD.DPRNDID=FCC.DPRNDID"
                'str &= " WHERE FCC.DPRNDID=TD.DPRNDID) <>''"
                'str &= " THEN convert(varchar,TD.ConsumptionDate,103) else '' end as ConDate"

                'str &= " from TblDPRND TD "
                'str &= " join DPFabricDbMst FD ON FD.FabricDbMstID=TD.FabricDbMstID "
                'str &= "  Join SupplierDatabase V on  V.SupplierDatabaseID=FD.SupplierId where TD.AllowToGGT=1"
                'str &= " order by DPRNDID DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRNDDataForTaskList()
            Dim str As String
            Try
                str = "  select *,'RND' AS UserName,convert (varchar,RND.CreatDate,103) as CreatDatee from   TblDPRND RND"
                str &= "  WHERE  RND.DPRNDID IN(select SD.DPRNDID from  DPRNDStyleDetail SD)"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMerchDataForTaskList()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee from  FabricConsumption RND   "
                str &= "  join Customer C on C.CustomerID=RND.BuyerId"
                str &= "  join UMUser U on U.UserID=RND.UserID"
                str &= "  WHERE  RND.FabricConsumptionID IN(select SD.FabricConsumptionID from  FabricConsumptionDetail SD) AND RND.UserId=245"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMerchDataAndFStoreForTaskList()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee from  FabricConsumption RND   "
                str &= "  join Customer C on C.CustomerID=RND.BuyerId"
                str &= "  join UMUser U on U.UserID=RND.UserID"
                str &= "  WHERE  RND.FabricConsumptionID IN(select SD.FabricConsumptionID from  FabricConsumptionDetail SD) AND RND.UserId=245 or  RND.UserID=241"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFStoreDataForTaskList()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee from  FabricConsumption RND   "
                str &= "  join Customer C on C.CustomerID=RND.BuyerId"
                str &= "  join UMUser U on U.UserID=RND.UserID"
                str &= "  WHERE  RND.FabricConsumptionID IN(select SD.FabricConsumptionID from  FabricConsumptionDetail SD) AND RND.UserId=241"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListRNDView()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee,convert (varchar,RND.DateTimeStamp,103) as DateTimeStampp from  PATTERNDEPARTMENTTASKLISTMst RND left join umuser um on um.userid=RND.userid join FabricConsumptionType FT on FT.FabricConsumptionTypeID=RND.TypeID  order by RND.PATTERNDEPARTMENTTASKLISTMstid desc"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListFStoreView()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee,convert (varchar,RND.DateTimeStamp,103) as DateTimeStampp from  PATTERNDEPARTMENTTASKLISTMst RND  left join umuser um on um.userid=RND.userid join FabricConsumptionType FT on FT.FabricConsumptionTypeID=RND.TypeID   order by RND.PATTERNDEPARTMENTTASKLISTMstid desc "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListMerchView()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee,convert (varchar,RND.DateTimeStamp,103) as DateTimeStampp from  PATTERNDEPARTMENTTASKLISTMst RND  left join umuser um on um.userid=RND.userid join FabricConsumptionType FT on FT.FabricConsumptionTypeID=RND.TypeID order by RND.PATTERNDEPARTMENTTASKLISTMstid desc "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTView()
            Dim str As String
            Try
                str = "  select *,convert (varchar,RND.CreationDate,103) as CreatDatee,convert (varchar,RND.DateTimeStamp,103) as"
                str &= "     DateTimeStampp"
                str &= "   ,case when RND.ReadByGGTDept = '1900-01-01'  "
                str &= "   then  '0' else '1' end as Status "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst RND "
                str &= "   Join UmUser UM on UM.UserId=RND.UserId"
                str &= "   order by RND.PATTERNDEPARTMENTTASKLISTMstid asc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNew()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.ReadByGGTDept = '1900-01-01'     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "
                str &= "    where Mst.Priority <> 0"
                str &= "    order by Mst.Priority,Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNewForNew()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.FinishTimeStamp = ''     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "
                str &= "    where Mst.Priority <> 0"
                str &= "    order by Mst.Priority,Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNewProcess()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.ReadByGGTDept = '1900-01-01'     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "
                str &= "    where Mst.Priority <> 0 and"
                str &= "    ( CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  "
                str &= "   from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "    when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail "
                str &= "    RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "   where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND "
                str &= "   JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "   else '0' END) <>0"

                str &= "    order by Mst.Priority,Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNewProcessNew()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.FinishTimeStamp = ''     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "
                str &= "    where Mst.Priority <> 0 and"
                str &= "    ( CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  "
                str &= "   from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "    when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail "
                str &= "    RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "   where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND "
                str &= "   JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "   else '0' END) <>0"

                str &= "    order by Mst.Priority,Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNewInProcess()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.ReadByGGTDept = '1900-01-01'     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "
                str &= "    where Mst.Priority <> 0 and"

                str &= "    ( CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  "
                str &= "   from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "    when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail "
                str &= "    RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "   where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND "
                str &= "   JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "   else '0' END) =0"

                str &= "    order by Mst.Priority,Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNewInProcessNew()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.FinishTimeStamp = ''     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "
                str &= "    where Mst.Priority <> 0 and"

                str &= "    ( CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  "
                str &= "   from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "    when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail "
                str &= "    RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "   where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND "
                str &= "   JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "   else '0' END) =0"

                str &= "    order by Mst.Priority,Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForTaskListGGTViewNewPriority()
            Dim str As String
            Try
                str = "  select isnull(FT.FabricConsumptionType,'') AS Typee,UM.UserName,*,convert (varchar,Mst.CreationDate,103) as CreatDatee,convert (varchar,Mst.DateTimeStamp,103) as    "
                str &= "     DateTimeStampp   ,case when Mst.ReadByGGTDept = '1900-01-01'     then  '0' else '1' end as Status "
                str &= "   ,isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0) as IDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "   where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) as IDDD"
                str &= "     ,isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "     where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0) as IDDDD"
                str &= "   , CASE when UM.UserName= 'Fabric Store' AND isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumFstoreID And RND.UserID =241),0) >0 THEN '1' "
                str &= "      when UM.UserName= 'RND' AND isnull((select TOP 1 RNDD.DPRNDID  from TBLDPRND RND JOIN DPRNDStyleDetail RNDD on RNDD.DPRNDID=RND.DPRNDID"
                str &= "    where RND.DPRNDID =Mst.DPRNDID),0)  >0 THEN '1'"
                str &= "   WHEN UM.UserName= 'Merch' and isnull((select TOP 1 RNDD.FabricConsumptionID  from FabricConsumption RND JOIN FabricConsumptionDetail RNDD on RNDD.FabricConsumptionID=RND.FabricConsumptionID"
                str &= "    where RND.FabricConsumptionID =Mst.FabricCosumMerchID  And RND.UserID =245),0)>0 then '1'"
                str &= "    else '0' END as ConStatus "
                str &= "   from  PATTERNDEPARTMENTTASKLISTMst Mst    "
                str &= "   Join UmUser UM on UM.UserId=Mst.UserId   "
                str &= "    left join FabricConsumptionType FT on FT.FabricConsumptionTypeID =MST.TypeID "

                str &= "    order by Mst.PATTERNDEPARTMENTTASKLISTMstid desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditAccStyle(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " select * from DPRNDAccessDetail dad"
                '' str &= " join DPRNDStyleDetail dst on dst.DPRNDID=dad.DPRNDID"
                str &= " where dad.DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditStyle(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " select * from DPRNDStyleDetail ds"
                ''str &= " join DPRNDStyleDetail dst on dst.DPRNDID=dad.DPRNDID"
                str &= " where ds.DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditStyleNew(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " select *,ds.ConsumptionUnitID as ConsumptionUnitIDD from DPRNDStyleDetail ds"
                str &= " left join ConsumptionUnit CU on CU.ConsumptionUnitID=ds.ConsumptionUnitID"
                str &= " where ds.DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleForRND(ByVal FabricDBMstId As Long)
            Dim str As String
            Try
                str = "select * from TblDPRND  "
                str &= "   where FabricDBMstId='" & FabricDBMstId & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPPOItem(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "select * from DPItemDatabase ITD "
                str &= "   Join DPRNDAccessDetail DPRA ON ITD.DPItemDatabaseid=DPRA.DPItemDatabaseid"
                str &= "   where DPRNDID='" & DPRNDID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function StyleAlert(ByVal Style As String)
            Dim str As String
            Try
                str = "select * from TblDPRND where Style='" & Style & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForRoleSetupView()
            Dim str As String
            Try
                str = " SELECT * FROM RMRole RM"
                str &= " join UMDepartment UD on UD.UMDepartmentID=RM.UMDepartmentID"
                str &= " WHERE RM.RoleId NOT iN (1,3,4,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,31,32,33,34,36,37,38,39,40,41,42,43,44)"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForUserSetupView()
            Dim str As String
            Try
                str = " select * from UMUser UN"
                str &= " join RMUserRoles RMU on rmu.UserId=UN.UserId"
                str &= " join RMRole R on R.RoleId =RMU.RoleId "
                str &= " JOIN UMDepartment UD on UD.UMDepartmentID=R.UMDepartmentID"
                str &= " WHERE R.RoleId NOT iN (1,3,4,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,31,32,33,34,36,37,38,39,40,41,42,43,44)"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function StyleAlertNew(ByVal Style As String, ByVal FabricDBMstId As Long)
            Dim str As String
            Try
                str = "select * from TblDPRND where Style='" & Style & "' and FabricDBMstId='" & FabricDBMstId & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExistingStyleForStyleDatabase(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select * from DPStyleDatabase where StyleCode='" & StyleCode & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExistingStyleForStyleDatabaseNew(ByVal StyleCode As String)
            Dim str As String
            Try

                str = "select * from DPStyleDatabase where REPLACE(StyleCode, '/', '\')='" & StyleCode & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExistingDalNo(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select * from DPFabricDbMst where DalNo='" & DalNo & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSRNoAndSeason() As DataTable
            Dim str As String
            str = " select  jo.Joborderid ,jo.SRNO + '('+ SD.SeasonName+')'  AS Srnoo   from JobOrderdatabase Jo"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetChemicalNameID(ByVal ITEMName As String)
            Dim str As String
            Try
                str = "select * from IMSITEM where ITEMName='" & ITEMName & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExistingLCNo(ByVal LCNo As String)
            Dim str As String
            Try
                str = "select * from LCExportDtl where LCNo='" & LCNo & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindGridForCuttingViewNew()
            Dim str As String
            Try
                
                str = " select *  ,(select top 1 convert(varchar,Dtl.CuttingDate,103)  from TodayCuttingDtl Dtl "
                str &= " where Dtl.TodayCuttingMstID =Mst.TodayCuttingMstID) as CuttingDate "
                str &= "  ,(select top 1 SD.SeasonName   from TodayCuttingDtl Dtl join SeasonDatabase SD"
                str &= "  ON sd.SeasonDatabaseID =Dtl.SeasonDatabaseID where Dtl.TodayCuttingMstID =Mst.TodayCuttingMstID) as SeasonName"
                str &= " from TodayCuttingMst Mst"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindGridForCuttingView()
            Dim str As String
            Try
                'str = "  select * from TodayCuttingMst Mst"
                'str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =Mst.SeasonDatabaseID"
                str = " select * "
                str &= " ,(select top 1 convert(varchar,Dtl.CuttingDate,103)  from TodayCuttingDtl Dtl where Dtl.TodayCuttingMstID =Mst.TodayCuttingMstID) as CuttingDate"
                str &= "  from TodayCuttingMst Mst "
                str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =Mst.SeasonDatabaseID"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindGridForCommercialPakingList()
            Dim str As String
            Try
                str = "  select * from CommercialPackingListMst Mst"
                str &= " join Cargo C on C.CargoID =Mst.CargoID"
                str &= " JOIN JobOrderdatabase JO on JO.Joborderid =MST.Joborderid "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPaymentTerm(ByVal LCNo As String)
            Dim str As String
            Try
                str = "select * from LCExportDtl Dtl join JobOrderdatabase Jo on jo.JobOrderId=Dtl.JobOrderId join PaymentTerm PT on PT.PaymentTermid=jo.PaymentTermid where LCNo='" & LCNo & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCompositionIDForFDB(ByVal CompositionName As String)
            Dim str As String
            Try
                str = "select * from Composition where CompositionName='" & CompositionName & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCheckCompositionIDForFDB(ByVal CompositionName As String)
            Dim str As String
            Try
                str = "select * from Composition where CompositionName='" & CompositionName & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCheckDALNO(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select * from DPFabricDbMst where DalNo='" & DALNo & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCheckFinsihWidthIDForFDB(ByVal FinishName As String)
            Dim str As String
            Try
                str = "select * from DPFinish where FinishName='" & FinishName & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        '------------------------
        Public Function CheckStyle(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            'Str = "   Select * from StyleMasterDatabase sd"
            ' Str &= " join Style_SubStyle ss on sd.StyleMasterDatabaseID=ss.StyleMasterDatabaseID where  JoborderID='" & JobOrderId & "'"

            Str = "  Select * from StyleAssortmentMaster sd "
            Str &= " join StyleAssortmentDetail ss on sd.StyleAssortmentMasterId=ss.StyleAssortmentMasterId"
            Str &= " where JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckFabricPlane(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from FPlanMst where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckAccessoriesePlane(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from AccessoriesePlanMst where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function CheckExistingRNDAccess(ByVal DPItemName As String) As DataTable
            Dim Str As String
            Str = "   Select * from DPItemDatabase where  DPItemName='" & DPItemName & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLocktoggt(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " select * from TblDPRND "
                str &= " where DPRNDID='" & DPRNDID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace