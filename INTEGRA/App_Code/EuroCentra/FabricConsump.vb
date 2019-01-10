Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class FabricConsump
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabricConsumption"
            m_strPrimaryFieldName = "FabricConsumptionID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricConsumptionID As Long
        Private m_lUserID As Long
        Private m_dtCreationDate As Date
        Private m_dtFabricConDate As Date
        Private m_lTypeID As Long
        Private m_strSrNo As String
        Private m_strStyleNo As String
        Private m_strDescription As String
        Private m_strFabricConstruction As String
        Private m_strFinishedFabricWidth As String

        Private m_strRatio As String
        Private m_strTotal As String
       
        Private m_strShrinkageApprox As String
        Private m_strPreparedBy1 As String
        Private m_strPreparedBy2 As String
        Private m_strPreparedBy3 As String
        Private m_strPreparedBy4 As String
        Private m_strPreparedBy5 As String
        Private m_lBuyerid As Long
        Private m_strDalNo As String
        Private m_Supplierid As Long
        Private m_strAllowToGGTFromFStore As Byte
        Private m_strGGTStatusFromFStore As Byte
        Private m_strAllowToGGTFromMerch As Byte
        Private m_strGGTStatusFromMerch As Byte
        Private m_dtConsumptionDate As Date
        Private m_lSeasonDatabaseID As Long
        Public Property SeasonDatabaseID() As Long
            Get
                SeasonDatabaseID = m_lSeasonDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseID = Value
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
        Public Property AllowToGGTFromFStore() As Boolean
            Get
                AllowToGGTFromFStore = m_strAllowToGGTFromFStore
            End Get
            Set(ByVal value As Boolean)
                m_strAllowToGGTFromFStore = value
            End Set
        End Property
        Public Property GGTStatusFromFStore() As Boolean
            Get
                GGTStatusFromFStore = m_strGGTStatusFromFStore
            End Get
            Set(ByVal value As Boolean)
                m_strGGTStatusFromFStore = value
            End Set
        End Property
        Public Property AllowToGGTFromMerch() As Boolean
            Get
                AllowToGGTFromMerch = m_strAllowToGGTFromMerch
            End Get
            Set(ByVal value As Boolean)
                m_strAllowToGGTFromMerch = value
            End Set
        End Property
        Public Property GGTStatusFromMerch() As Boolean
            Get
                GGTStatusFromMerch = m_strGGTStatusFromMerch
            End Get
            Set(ByVal value As Boolean)
                m_strGGTStatusFromMerch = value
            End Set
        End Property
        Public Property Buyerid() As Long
            Get
                Buyerid = m_lBuyerid
            End Get
            Set(ByVal Value As Long)
                m_lBuyerid = Value
            End Set
        End Property
        Public Property DalNo() As String
            Get
                DalNo = m_strDalNo
            End Get
            Set(ByVal Value As String)
                m_strDalNo = Value
            End Set
        End Property
        Public Property Supplierid() As Long
            Get
                Supplierid = m_Supplierid
            End Get
            Set(ByVal Value As Long)
                m_Supplierid = Value
            End Set
        End Property
        Public Property FabricConDate() As Date
            Get
                FabricConDate = m_dtFabricConDate
            End Get
            Set(ByVal Value As Date)
                m_dtFabricConDate = Value
            End Set
        End Property
        Public Property FabricConsumptionID() As Long
            Get
                FabricConsumptionID = m_lFabricConsumptionID
            End Get
            Set(ByVal Value As Long)
                m_lFabricConsumptionID = Value
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
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property TypeID() As Long
            Get
                TypeID = m_lTypeID
            End Get
            Set(ByVal Value As Long)
                m_lTypeID = Value
            End Set
        End Property
        Public Property SrNo() As String
            Get
                SrNo = m_strSrNo
            End Get
            Set(ByVal Value As String)
                m_strSrNo = Value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal Value As String)
                m_strStyleNo = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal Value As String)
                m_strDescription = Value
            End Set
        End Property
        Public Property FabricConstruction() As String
            Get
                FabricConstruction = m_strFabricConstruction
            End Get
            Set(ByVal Value As String)
                m_strFabricConstruction = Value
            End Set
        End Property
        Public Property FinishedFabricWidth() As String
            Get
                FinishedFabricWidth = m_strFinishedFabricWidth
            End Get
            Set(ByVal Value As String)
                m_strFinishedFabricWidth = Value
            End Set
        End Property
       
        Public Property Ratio() As String
            Get
                Ratio = m_strRatio
            End Get
            Set(ByVal Value As String)
                m_strRatio = Value
            End Set
        End Property
        Public Property Total() As String
            Get
                Total = m_strTotal
            End Get
            Set(ByVal Value As String)
                m_strTotal = Value
            End Set
        End Property
       
       
        Public Property ShrinkageApprox() As String
            Get
                ShrinkageApprox = m_strShrinkageApprox
            End Get
            Set(ByVal Value As String)
                m_strShrinkageApprox = Value
            End Set
        End Property
        
        Public Property PreparedBy1() As String
            Get
                PreparedBy1 = m_strPreparedBy1
            End Get
            Set(ByVal Value As String)
                m_strPreparedBy1 = Value
            End Set
        End Property
        Public Property PreparedBy2() As String
            Get
                PreparedBy2 = m_strPreparedBy2
            End Get
            Set(ByVal Value As String)
                m_strPreparedBy2 = Value
            End Set
        End Property
        Public Property PreparedBy3() As String
            Get
                PreparedBy3 = m_strPreparedBy3
            End Get
            Set(ByVal Value As String)
                m_strPreparedBy3 = Value
            End Set
        End Property
        Public Property PreparedBy4() As String
            Get
                PreparedBy4 = m_strPreparedBy4
            End Get
            Set(ByVal Value As String)
                m_strPreparedBy4 = Value
            End Set
        End Property
        Public Property PreparedBy5() As String
            Get
                PreparedBy5 = m_strPreparedBy5
            End Get
            Set(ByVal Value As String)
                m_strPreparedBy5 = Value
            End Set
        End Property

        Public Function saveFabricConsmp()
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
        Function DeletedFabricConMaster(ByVal FabricConsumptionID As Long)
            Dim str As String
            str = " Delete  from FabricConsumption where FabricConsumptionID ='" & FabricConsumptionID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedFabricConDetail(ByVal FabricConsumptionID As Long)
            Dim str As String
            str = " Delete  from FabricConsumptionDetail where FabricConsumptionID ='" & FabricConsumptionID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFromStyleDatabase(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select * from DPStyleDatabase"
                str &= " where StyleCode='" & StyleCode & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUserName(ByVal UserId As Long)
            Dim str As String
            Try
                str = "select * from UmUser"
                str &= " where UserId='" & UserId & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFromJobOrderid(ByVal SRNo As String)
            Dim str As String
            Try
                str = "select * from joborderdatabase"
                str &= " where SRNo='" & SRNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFromBuyerid(ByVal CustomerName As String)
            Dim str As String
            Try
                str = "select * from Customer"
                str &= " where CustomerName='" & CustomerName & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteTaslListDetail(ByVal PATTERNDEPARTMENTTASKLISTDtlid As Long, ByVal PATTERNDEPARTMENTTASKLISTMstid As Long)
            Dim str As String
            str = "  delete from   PATTERNDEPARTMENTTASKLISTDtl where   PATTERNDEPARTMENTTASKLISTDtlid =' " & PATTERNDEPARTMENTTASKLISTDtlid & " ' and PATTERNDEPARTMENTTASKLISTMstid='" & PATTERNDEPARTMENTTASKLISTMstid & "'"
            Try
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
        Public Function GetItemDatabasedata(ByVal DalRefNo As String)
            Dim str As String
            Try
                str = " select * from IMSItem"
                str &= "  where DalRefNo='" & DalRefNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFBData(ByVal DalNo As String)
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,"
                str &= " FabricQuality+' '+DPTypeName+' '+CompositionName+' '+FinishName+' '+DyeName  as FabricQualityy,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  "
                str &= " Join DPType DPT ON DPT.DPTypeid=FM.DPTypeid"
                str &= " join DPFinish DF ON DF.FinishID=FM.FinishID"
                str &= " JOIN DPDye DDP ON DDP.DYEID=FM.DYEID"
                str &= "  where fm.DalNo='" & DalNo & "'"
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
        Public Function GetBindGridForFabricConsmp()
            Dim str As String
            Try

                str = " select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,FC.Description,"
                str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType from FabricConsumption FC"
                str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType"
                
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForFabricConsmpForFStore()
            Dim str As String
            Try

                str = "  select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo, "
                str &= " FC.Description,replace(FC.Ratio,',','-') as Ratioo,SDD.SeasonName,FC.FabricConstruction,C.CustomerName,FC.FinishedFabricWidth,"
                str &= " FC.Ratio,FC.Total,FCT.FabricConsumptionType,"
                str &= " case when FC.AllowToGGTFromFStore = 1  "
                str &= " then  'Yes' else 'No' end as Status  ,  case when FC.GGTStatusFromFStore = 1  then  'Yes'  else  'No' end "
                str &= "  as GGTStatuss"
                str &= " ,isnull((select sum(dtl.ConsumptionPerPcs) from FabricConsumptionDetail dtl "
                str &= " where dtl.FabricConsumptionID=FC.FabricConsumptionID),0) as Cosumption,"
                str &= " (select sum(1) from FabricConsumption TDDD where TDDD.FabricConsumptionid>=FC.FabricConsumptionid) as RowNo"
                str &= " ,isnull((select top 1 FCC.StyleNo from FabricConsumption FCC"
                str &= " JOIN FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FCC.FabricConsumptionID"
                str &= " WHERE FCC.FabricConsumptionID=FC.FabricConsumptionID),'') AS StyleNo"
                str &= " ,case when isnull((select top 1 FCC.StyleNo from FabricConsumption FCC"
                str &= " JOIN FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FCC.FabricConsumptionID"
                str &= " WHERE FCC.FabricConsumptionID=FC.FabricConsumptionID),'')<>''"
                str &= " THEN convert(varchar,FC.ConsumptionDate,103) else '' end as ConDate"
                str &= " ,CASE WHEN LEN(FC.FabricConstruction) <= 3 THEN FabricConstruction ELSE LEFT(FC.FabricConstruction,3) + '...' END  As FabricConstructionn"
                str &= " ,CASE WHEN LEN(FC.StyleNo) <= 3 THEN StyleNo ELSE LEFT(FC.StyleNo, 3) + '...' END  As StyleNoo"
                str &= " ,CASE WHEN LEN(FC.Total) <= 3 THEN Total ELSE LEFT(FC.Total, 3) + '...' END  As Totall"
                str &= " ,CASE WHEN LEN(SDD.SeasonName) <= 3 THEN SeasonName ELSE LEFT(SDD.SeasonName, 3) + '...' END  As SeasonNamee"
                str &= " ,CASE WHEN LEN(FC.FinishedFabricWidth) <= 3 THEN FinishedFabricWidth ELSE LEFT(FC.FinishedFabricWidth, 3) + '...' END  As FinishedFabricWidthh"
                str &= " ,CASE WHEN LEN(FC.Description) <= 3 THEN FC.Description ELSE LEFT(FC.Description, 3) + '...' END  As Descriptionn"
                str &= " from FabricConsumption FC "
                str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                str &= " join Customer C on C.CustomerID=FC.BuyerID"
                str &= " LEFT join FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FC.FabricConsumptionID"
                str &= " LEFT join SeasonDatabase SDD on SDD.SeasonDatabaseID=FC.SeasonDatabaseID"
                str &= " where FC.UserId = 241"
                str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description, "
                str &= "  FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType,"
                str &= "  FC.AllowToGGTFromFStore, FC.GGTStatusFromFStore,SDD.SeasonName,C.CustomerName, FC.ConsumptionDate,FC.Description"
                str &= "  Order by FC.CreationDate desc"
                'str = "  select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,"
                'str &= " FC.Description,"
                'str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType,isnull(FCTD.ConsumptionPerPcs,0) as Consumption,"
                'str &= " case when FC.AllowToGGTFromFStore = 1  then"
                'str &= "  'Yes'"
                'str &= " else"
                'str &= " 'No' end as Status"
                'str &= "  ,"
                'str &= "  case when FC.GGTStatusFromMerch = 1  then"
                'str &= "  'Yes'"
                'str &= "  else"
                'str &= "  'No' end as GGTStatuss"
                'str &= "  "
                'str &= " from FabricConsumption FC"
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID LEFT join FabricConsumptionDetail FCTD ON FCTD.FabricConsumptionID=FC.FabricConsumptionID where FC.UserId=241 "
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,"
                'str &= " FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType, FC.AllowToGGTFromFStore,FC.GGTStatusFromMerch,FCTD.ConsumptionPerPcs"


                'str = "    select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo, "
                'str &= " FC.Description,replace(FC.Ratio,',','-') as Ratioo, FC.FabricConstruction,C.CustomerName,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType,"
                'str &= " case when FC.AllowToGGTFromFStore = 1  "
                'str &= " then  'Yes' else 'No' end as Status  ,  case when FC.GGTStatusFromFStore = 1  then  'Yes'  else  'No' end "
                'str &= " as GGTStatuss"
                'str &= " ,isnull((select sum(dtl.ConsumptionPerPcs) from FabricConsumptionDetail dtl where dtl.FabricConsumptionID=FC.FabricConsumptionID),0) as Cosumption,(select sum(1) from FabricConsumption TDDD where TDDD.FabricConsumptionid>=FC.FabricConsumptionid) as RowNo"
                'str &= " from FabricConsumption FC "
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                'str &= "  join Customer C on C.CustomerID=FC.BuyerID"
                'str &= " where FC.UserId = 241"
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description, "
                'str &= " FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType,"
                'str &= " FC.AllowToGGTFromFStore, FC.GGTStatusFromFStore,C.CustomerName"

                'str = " select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,FC.Description,"
                'str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType from FabricConsumption FC"
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID where FC.UserId=241 "
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForFabricConsmpForMerch()
            Dim str As String
            Try

                str = "  select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo, "
                str &= " FC.Description,replace(FC.Ratio,',','-') as Ratioo, SDD.SeasonName,FC.FabricConstruction,C.CustomerName,FC.FinishedFabricWidth,"
                str &= " FC.Ratio,FC.Total,FCT.FabricConsumptionType,"
                str &= " case when FC.AllowToGGTFromMerch = 1  "
                str &= " then  'Yes' else 'No' end as Status  ,  case when FC.GGTStatusFromMerch = 1  then  'Yes'  else  'No' end "
                str &= "  as GGTStatuss"
                str &= " ,isnull((select sum(dtl.ConsumptionPerPcs) from FabricConsumptionDetail dtl "
                str &= " where dtl.FabricConsumptionID=FC.FabricConsumptionID),0) as Cosumption,"
                str &= " (select sum(1) from FabricConsumption TDDD where TDDD.FabricConsumptionid>=FC.FabricConsumptionid) as RowNo"
                str &= " ,isnull((select top 1 FCC.StyleNo from FabricConsumption FCC"
                str &= " JOIN FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FCC.FabricConsumptionID"
                str &= " WHERE FCC.FabricConsumptionID=FC.FabricConsumptionID),'') AS StyleNo"
                str &= " ,case when isnull((select top 1 FCC.StyleNo from FabricConsumption FCC"
                str &= " JOIN FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FCC.FabricConsumptionID"
                str &= " WHERE FCC.FabricConsumptionID=FC.FabricConsumptionID),'')<>''"
                str &= " THEN convert(varchar,FC.ConsumptionDate,103)  else '' end as ConDate"
                str &= " ,CASE WHEN LEN(FC.FabricConstruction) <= 3 THEN FabricConstruction ELSE LEFT(FC.FabricConstruction, 3) + '...' END  As FabricConstructionn"
                str &= " ,CASE WHEN LEN(FC.StyleNo) <= 3 THEN StyleNo ELSE LEFT(FC.StyleNo, 3) + '...' END  As StyleNoo"
                str &= " ,CASE WHEN LEN(FC.Total) <= 3 THEN Total ELSE LEFT(FC.Total, 3) + '...' END  As Totall"
                str &= " ,CASE WHEN LEN(SDD.SeasonName) <= 3 THEN SeasonName ELSE LEFT(SDD.SeasonName, 3) + '...' END  As SeasonNamee"
                str &= " from FabricConsumption FC "
                str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                str &= " join Customer C on C.CustomerID=FC.BuyerID"
                str &= " LEFT join FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FC.FabricConsumptionID"
                str &= " LEFT join SeasonDatabase SDD on SDD.SeasonDatabaseID=FC.SeasonDatabaseID"
                str &= " where FC.UserId in(245,256,257,258,259,260,261,262,263,268,269)"
                str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description, "
                str &= "  FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType,"
                str &= "  FC.AllowToGGTFromMerch, FC.GGTStatusFromMerch, C.CustomerName, FC.ConsumptionDate,SDD.SeasonName"
                str &= "  Order by FC.CreationDate desc"
                '  str = "    select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo, "
                '  str &= " FC.Description,replace(FC.Ratio,',','-') as Ratioo, FC.FabricConstruction,C.CustomerName,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType,"
                '  str &= " case when FC.AllowToGGTFromMerch = 1  "
                '  str &= " then  'Yes' else 'No' end as Status  ,  case when FC.GGTStatusFromMerch = 1  then  'Yes'  else  'No' end "
                '  str &= " as GGTStatuss"
                '  str &= " ,isnull((select sum(dtl.ConsumptionPerPcs) from FabricConsumptionDetail dtl where dtl.FabricConsumptionID=FC.FabricConsumptionID),0) as Cosumption,(select sum(1) from FabricConsumption TDDD where TDDD.FabricConsumptionid>=FC.FabricConsumptionid) as RowNo"
                'str &= " from FabricConsumption FC "
                '  str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                '  str &= " join Customer C on C.CustomerID=FC.BuyerID"
                '  str &= " where FC.UserId = 245"
                '  str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description, "
                '  str &= " FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType,"
                '  str &= " FC.AllowToGGTFromMerch, FC.GGTStatusFromMerch,C.CustomerName"



                'str = "  select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,"
                'str &= " FC.Description,"
                'str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType,isnull(FCTD.ConsumptionPerPcs,0) as Consumption,"
                'str &= " case when FC.AllowToGGTFromMerch = 1  then"
                'str &= "  'Yes'"
                'str &= " else"
                'str &= " 'No' end as Status"
                'str &= "  ,"
                'str &= "  case when FC.GGTStatusFromFStore = 1  then"
                'str &= "  'Yes'"
                'str &= "  else"
                'str &= "  'No' end as GGTStatuss"
                'str &= " from FabricConsumption FC"
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID LEFT join FabricConsumptionDetail FCTD ON FCTD.FabricConsumptionID=FC.FabricConsumptionID where FC.UserId=245 "
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,"
                'str &= " FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType, FC.AllowToGGTFromMerch,FC.GGTStatusFromFStore,FCTD.ConsumptionPerPcs"

                'str = " select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,FC.Description,"
                'str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType from FabricConsumption FC"
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID  where FC.UserId=245 "
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForFabricConsmpForMerchForDirectorView()
            Dim str As String
            Try

                str = "  select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo, "
                str &= " FC.Description,replace(FC.Ratio,',','-') as Ratioo, SDD.SeasonName,FC.FabricConstruction,C.CustomerName,FC.FinishedFabricWidth,"
                str &= " FC.Ratio,FC.Total,FCT.FabricConsumptionType,"
                str &= " case when FC.AllowToGGTFromMerch = 1  "
                str &= " then  'Yes' else 'No' end as Status  ,  case when FC.GGTStatusFromMerch = 1  then  'Yes'  else  'No' end "
                str &= "  as GGTStatuss"
                str &= " ,isnull((select sum(dtl.ConsumptionPerPcs) from FabricConsumptionDetail dtl "
                str &= " where dtl.FabricConsumptionID=FC.FabricConsumptionID),0) as Cosumption,"
                str &= " (select sum(1) from FabricConsumption TDDD where TDDD.FabricConsumptionid>=FC.FabricConsumptionid) as RowNo"
                str &= " ,isnull((select top 1 FCC.StyleNo from FabricConsumption FCC"
                str &= " JOIN FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FCC.FabricConsumptionID"
                str &= " WHERE FCC.FabricConsumptionID=FC.FabricConsumptionID),'') AS StyleNo"
                str &= " ,case when isnull((select top 1 FCC.StyleNo from FabricConsumption FCC"
                str &= " JOIN FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FCC.FabricConsumptionID"
                str &= " WHERE FCC.FabricConsumptionID=FC.FabricConsumptionID),'')<>''"
                str &= " THEN convert(varchar,FC.ConsumptionDate,103)  else '' end as ConDate"
                str &= " ,CASE WHEN LEN(FC.FabricConstruction) <= 3 THEN FabricConstruction ELSE LEFT(FC.FabricConstruction, 3) + '...' END  As FabricConstructionn"
                str &= " ,CASE WHEN LEN(FC.StyleNo) <= 3 THEN StyleNo ELSE LEFT(FC.StyleNo, 3) + '...' END  As StyleNoo"
                str &= " ,CASE WHEN LEN(FC.Total) <= 3 THEN Total ELSE LEFT(FC.Total, 3) + '...' END  As Totall"
                str &= " ,CASE WHEN LEN(SDD.SeasonName) <= 3 THEN SeasonName ELSE LEFT(SDD.SeasonName, 3) + '...' END  As SeasonNamee"
                str &= " from FabricConsumption FC "
                str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                str &= " join Customer C on C.CustomerID=FC.BuyerID"
                str &= " LEFT join FabricConsumptionDetail FCD on FCD.FabricConsumptionID=FC.FabricConsumptionID"
                str &= " LEFT join SeasonDatabase SDD on SDD.SeasonDatabaseID=FC.SeasonDatabaseID"
                str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description, "
                str &= "  FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType,"
                str &= "  FC.AllowToGGTFromMerch, FC.GGTStatusFromMerch, C.CustomerName, FC.ConsumptionDate,SDD.SeasonName"
                str &= "  Order by FC.CreationDate desc"
                '  str = "    select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo, "
                '  str &= " FC.Description,replace(FC.Ratio,',','-') as Ratioo, FC.FabricConstruction,C.CustomerName,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType,"
                '  str &= " case when FC.AllowToGGTFromMerch = 1  "
                '  str &= " then  'Yes' else 'No' end as Status  ,  case when FC.GGTStatusFromMerch = 1  then  'Yes'  else  'No' end "
                '  str &= " as GGTStatuss"
                '  str &= " ,isnull((select sum(dtl.ConsumptionPerPcs) from FabricConsumptionDetail dtl where dtl.FabricConsumptionID=FC.FabricConsumptionID),0) as Cosumption,(select sum(1) from FabricConsumption TDDD where TDDD.FabricConsumptionid>=FC.FabricConsumptionid) as RowNo"
                'str &= " from FabricConsumption FC "
                '  str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID "
                '  str &= " join Customer C on C.CustomerID=FC.BuyerID"
                '  str &= " where FC.UserId = 245"
                '  str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description, "
                '  str &= " FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType,"
                '  str &= " FC.AllowToGGTFromMerch, FC.GGTStatusFromMerch,C.CustomerName"



                'str = "  select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,"
                'str &= " FC.Description,"
                'str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType,isnull(FCTD.ConsumptionPerPcs,0) as Consumption,"
                'str &= " case when FC.AllowToGGTFromMerch = 1  then"
                'str &= "  'Yes'"
                'str &= " else"
                'str &= " 'No' end as Status"
                'str &= "  ,"
                'str &= "  case when FC.GGTStatusFromFStore = 1  then"
                'str &= "  'Yes'"
                'str &= "  else"
                'str &= "  'No' end as GGTStatuss"
                'str &= " from FabricConsumption FC"
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID LEFT join FabricConsumptionDetail FCTD ON FCTD.FabricConsumptionID=FC.FabricConsumptionID where FC.UserId=245 "
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,"
                'str &= " FC.FabricConstruction, FC.FinishedFabricWidth, FC.Ratio, FC.Total, FCT.FabricConsumptionType, FC.AllowToGGTFromMerch,FC.GGTStatusFromFStore,FCTD.ConsumptionPerPcs"

                'str = " select FC.FabricConsumptionID,FC.TypeID,convert(varchar,FC.CreationDate,103) as CreationDatee,FC.SrNo,FC.StyleNo,FC.Description,"
                'str &= " FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType from FabricConsumption FC"
                'str &= " join FabricConsumptionType FCT on FCT.FabricConsumptionTypeID=FC.TypeID  where FC.UserId=245 "
                'str &= " group by FC.FabricConsumptionID,FC.TypeID,FC.CreationDate,FC.SrNo,FC.StyleNo,FC.Description,FC.FabricConstruction,FC.FinishedFabricWidth,FC.Ratio,FC.Total,FCT.FabricConsumptionType"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForFabricConsumption(ByVal FabricConsumptionID As Long)
            Dim str As String
            Try
                str = " select * from FabricConsumption where FabricConsumptionID ='" & FabricConsumptionID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDataForRNDEntryForTaskList(ByVal PATTERNDEPARTMENTTASKLISTMstID As Long)
            Dim str As String
            Try
                str = " select * from PATTERNDEPARTMENTTASKLISTMst Mst join UmUser UM on UM.UserId=Mst.UserId where Mst.PATTERNDEPARTMENTTASKLISTMstID ='" & PATTERNDEPARTMENTTASKLISTMstID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabricConsmpType()
            Dim str As String
            Try
                str = " select * from FabricConsumptionType "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastNoForTaskListEntry()
            Dim str As String
            str = "  select Top 1 TaskNo from PATTERNDEPARTMENTTASKLISTMst  order By PATTERNDEPARTMENTTASKLISTMstid DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonForJobOrder(ByVal SrNo As String)
            Dim str As String
            Try
                str = " select SD.SeasonDatabaseID,SD.SeasonName from JobOrderdatabase JO"
                str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=JO.SeasonDatabaseID "
                str &= "  where JO.SRNO ='" & SrNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetStyleItemDisFabricQuality(ByVal SRNO As String)
            Dim str As String
            str = " select * from jobOrderdatabase JO"
            str &= " join joborderdatabasedetail jod on jod.jobOrderId=JO.jobOrderId where JO.SRNO ='" & SrNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierComboNNew()
            Dim str As String
            Try
                str = "select Distinct SupplierDatabaseID,SupplierName from SupplierDatabase"
                str &= " order by SupplierName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

