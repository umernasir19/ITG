
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class DPFabricDbMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPFabricDbMst"
            m_strPrimaryFieldName = "FabricDBMstId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lFabricDBMstId As Long
        Private m_dtCreationDate As Date
        Private m_strDalNo As String
        Private m_strFabricCode As String
        Private m_strSupplierArtNo As String
        Private m_lSupplierID As Long
        Private m_strFabricQuality As String
        Private m_strColor As String
        Private m_lCompositionId As Long
        Private m_strDyeWash As String
        Private m_strFinishGSM As String
        Private m_strFabricWidth As String
        Private m_strAfterWashGsm As String
        Private m_strShrinkage As String
        Private m_strGeneralRemarks As String
        Private m_dcOPQty As Decimal
        Private m_dcPurchaseQty As Decimal
        Private m_lUserid As Long
        Private m_lFinishId As Long
        Private m_lDyeId As Long
        Private m_lDPTypeId As Long
        Private m_strBefWashGSM As String
        Private m_strMillShrinkage As String
        Private m_FabricName As String
        Private m_Onz As String
        Private m_Shade As String
       
        Public Property Onz() As String
            Get
                Onz = m_Onz
            End Get
            Set(ByVal value As String)
                m_Onz = value
            End Set
        End Property
        Public Property FabricName() As String
            Get
                FabricName = m_FabricName
            End Get
            Set(ByVal value As String)
                m_FabricName = value
            End Set
        End Property
        Public Property BefWashGSM() As String
            Get
                BefWashGSM = m_strBefWashGSM
            End Get
            Set(ByVal value As String)
                m_strBefWashGSM = value
            End Set
        End Property
        Public Property MillShrinkage() As String
            Get
                MillShrinkage = m_strMillShrinkage
            End Get
            Set(ByVal value As String)
                m_strMillShrinkage = value
            End Set
        End Property
        Public Property DPTypeId() As Long
            Get
                DPTypeId = m_lDPTypeId
            End Get
            Set(ByVal value As Long)
                m_lDPTypeId = value
            End Set
        End Property
        Public Property DyeId() As Long
            Get
                DyeId = m_lDyeId
            End Get
            Set(ByVal value As Long)
                m_lDyeId = value
            End Set
        End Property
        Public Property FinishId() As Long
            Get
                FinishId = m_lFinishId
            End Get
            Set(ByVal value As Long)
                m_lFinishId = value
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
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property DalNo() As String
            Get
                DalNo = m_strDalNo
            End Get
            Set(ByVal value As String)
                m_strDalNo = value
            End Set
        End Property

        Public Property FabricCode() As String
            Get
                FabricCode = m_strFabricCode
            End Get
            Set(ByVal value As String)
                m_strFabricCode = value
            End Set
        End Property
        Public Property SupplierArtNo() As String
            Get
                SupplierArtNo = m_strSupplierArtNo
            End Get
            Set(ByVal value As String)
                m_strSupplierArtNo = value
            End Set
        End Property

        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal value As Long)
                m_lSupplierID = value
            End Set
        End Property
        Public Property FabricQuality() As String
            Get
                FabricQuality = m_strFabricQuality
            End Get
            Set(ByVal value As String)
                m_strFabricQuality = value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal value As String)
                m_strColor = value
            End Set
        End Property
        Public Property CompositionId() As Long
            Get
                CompositionId = m_lCompositionId
            End Get
            Set(ByVal value As Long)
                m_lCompositionId = value
            End Set
        End Property
        Public Property DyeWash() As String
            Get
                DyeWash = m_strDyeWash
            End Get
            Set(ByVal value As String)
                m_strDyeWash = value
            End Set
        End Property
        Public Property FinishGSM() As String
            Get
                FinishGSM = m_strFinishGSM
            End Get
            Set(ByVal value As String)
                m_strFinishGSM = value
            End Set
        End Property
        Public Property FabricWidth() As String
            Get
                FabricWidth = m_strFabricWidth
            End Get
            Set(ByVal value As String)
                m_strFabricWidth = value
            End Set
        End Property
        
        

        Public Property AfterWashGsm() As String
            Get
                AfterWashGsm = m_strAfterWashGsm
            End Get
            Set(ByVal value As String)
                m_strAfterWashGsm = value
            End Set
        End Property
        Public Property Shrinkage() As String
            Get
                Shrinkage = m_strShrinkage
            End Get
            Set(ByVal value As String)
                m_strShrinkage = value
            End Set
        End Property
        Public Property GeneralRemarks() As String
            Get
                GeneralRemarks = m_strGeneralRemarks
            End Get
            Set(ByVal value As String)
                m_strGeneralRemarks = value
            End Set
        End Property

        Public Property OPQty() As Decimal
            Get
                OPQty = m_dcOPQty
            End Get
            Set(ByVal value As Decimal)
                m_dcOPQty = value
            End Set
        End Property
        Public Property PurchaseQty() As Decimal
            Get
                PurchaseQty = m_dcPurchaseQty
            End Get
            Set(ByVal value As Decimal)
                m_dcPurchaseQty = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_lUserid
            End Get
            Set(ByVal value As Long)
                m_lUserid = value
            End Set
        End Property
        Public Property Shade() As String
            Get
                Shade = m_Shade
            End Get
            Set(ByVal value As String)
                m_Shade = value
            End Set
        End Property
        Public Function SaveFB()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrentId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function Getcomposition()
            Dim str As String
            Try
                str = "select * from Composition  order by Compositionname"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDye()
            Dim str As String
            Try
                str = "select * from DPDye order by DyeName "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetdpTYPE()
            Dim str As String
            Try
                str = "select * from DPType  order by DPTypeName "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLCCustomer()
            Dim str As String

            str = " select distinct c.CustomerID ,c.CustomerName  from Customer C ORDER BY c.CustomerName  ASC"


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetdpTYPENEW()
            Dim str As String
            Try
                str = "select * from DPType WHERE DPTYPEID IN(1,2,7) order by DPTypeName "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFinish()
            Dim str As String
            Try
                str = "select * from DPFinish order by FinishName"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetLCCustomerNamee(ByVal CustomerID As Long)
            Dim str As String
            str = "    SELECT BuyerBankName FROM Customer"
            str &= "  WHERE CustomerID ='" & CustomerID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetLCSeason(ByVal CustomerDatabaseID As Long)
            Dim str As String
            str = "    SELECT DISTINCT SD.SeasonDatabaseID ,SD.SeasonName  FROM JobOrderdatabase JO"
            str &= "  JOIN SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= "  WHERE JO.CustomerDatabaseID ='" & CustomerDatabaseID & "'"
            str &= "  ORDER BY SD.SeasonName ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetLCSRNO(ByVal CustomerDatabaseID As Long, ByVal SeasonDatabaseID As Long)
            Dim str As String

            str = "    SELECT DISTINCT jo.Joborderid  ,jo.SRNO  FROM JobOrderdatabase JO"
            str &= "  JOIN SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= "  WHERE JO.CustomerDatabaseID ='" & CustomerDatabaseID & "' AND jo.SeasonDatabaseID ='" & SeasonDatabaseID & "'"
            str &= "  ORDER BY jo.SRNO ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetLCPINOO(ByVal SeasonID As Long, ByVal CustomerID As Long, ByVal JobOrderId As Long)
            Dim str As String

            str = "   select distinct Mst.SalesContract,Mst.DPIMstID from DPIMst Mst "
            str &= "   join DPIDtl Dtl on Dtl.DPIMstID=Mst.DPIMstID "
            str &= "  WHERE MST.SeasonID ='" & SeasonID & "' AND MST.CustomerID ='" & CustomerID & "' and DTL.JobOrderId ='" & JobOrderId & "'"
            str &= "  ORDER BY Mst.SalesContract ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDalNoFromFDB(ByVal FabricDBMstId As Long)
            Dim str As String
            str = " select DalNo from DPFabricDbMst where FabricDBMstId ='" & FabricDBMstId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForSampleIssueFromFDB(ByVal FabricDBMstId As Long)
            Dim str As String
            str = " select * from DPFabricIssue where FabricDBMstId ='" & FabricDBMstId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForConsumptionFromFDB(ByVal DalNo As String)
            Dim str As String
            str = " select * from FabricConsumption where DalNo ='" & DalNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForSampleReceiveFromFDB(ByVal FabricDbMstID As Long)
            Dim str As String
            str = " select * from DPSampleReceive where FabricDbMstID ='" & FabricDbMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForPOMstFromFDB(ByVal FabricDbMstID As Long)
            Dim str As String
            str = " select * from DPPOMst where FabricDbMstID ='" & FabricDbMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForPOReceiveMstFromFDB(ByVal DPFabricMstID As Long)
            Dim str As String
            str = " select * from DPPOReceiveMst where DPFabricMstID ='" & DPFabricMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForPOReceiveDtlFromFDB(ByVal DPFabricMstID As Long)
            Dim str As String
            str = " select * from DPPOReceiveDtl where DPFabricMstID ='" & DPFabricMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForPOIssueDtlFromFDB(ByVal FabricDbMstID As Long)
            Dim str As String
            str = " select * from DPPOIssueDtl where FabricDbMstID ='" & FabricDBMstId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForWashDtlFromFDB(ByVal FabricDBMstID As Long)
            Dim str As String
            str = " select * from DPWashDtl where FabricDBMstID ='" & FabricDBMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForWashRecvDtlFromFDB(ByVal DalID As Long)
            Dim str As String
            str = " select * from DPWashRecvDtl where DalID ='" & DalID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForDPRNDFromFDB(ByVal FabricDBMstId As Long)
            Dim str As String
            str = " select * from TblDPRND where FabricDBMstId ='" & FabricDBMstId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForimsitemFromFDB(ByVal FabricDBMstId As Long)
            Dim str As String
            str = " select * from imsitem where FabricDBMstId ='" & FabricDBMstId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Function DeletedDPFabricDbMst(ByVal FabricDBMstId As Long)
            Dim str As String
            str = " Delete  from DPFabricDbMst where FabricDBMstId ='" & FabricDBMstId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedDPFabricDbDtl(ByVal FabricDBMstId As Long)
            Dim str As String
            str = " Delete  from DPFabricDbDtl where FabricDBMstId ='" & FabricDBMstId & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierComboN()
            Dim str As String
            Try
                str = "select Distinct V.VenderLibraryID,V.VenderName  from Vender V "
                str &= " order by V.VenderName  ASC"
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
        Public Function GetAllData()
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId order by FM.creationDate desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNew()
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,*"
                str &= " ,isnull((select top 1 (Dtl.Price) from DPFabricDbMst Mst"
                str &= " left JOIN DPFabricDbDtl Dtl on Dtl.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where Mst.FabricDbMstID=FM.FabricDbMstID and Dtl.ConfirmPrice=1),0) as Pricee,"
                str &= " CASE WHEN LEN(FM.FabricName) <= 10 THEN FabricName ELSE LEFT(FM.FabricName, 10) + '...' END  As FabricNamee"
                str &= " ,CASE WHEN LEN(c.CompositionName) <= 10 THEN CompositionName ELSE LEFT(c.CompositionName, 10) + '...' END  As CompositionNamee"
                str &= " ,CASE WHEN LEN(FM.FabricQuality) <= 10 THEN FabricQuality ELSE LEFT(FM.FabricQuality, 10) + '...' END  As FabricQualityy"
                str &= " ,CASE WHEN LEN(FM.SupplierArtNo) <= 10 THEN SupplierArtNo ELSE LEFT(FM.SupplierArtNo, 10) + '...' END  As SupplierArtNoo"
                str &= " from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId order by FM.creationDate desc"

                'str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                'str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                'str &= " join Composition c on c.CompositionId=FM.CompositionId order by FM.creationDate desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewNew(ByVal DPTypeId As Long)
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,*"
                str &= " ,isnull((select top 1 (Dtl.Price) from DPFabricDbMst Mst"
                str &= " JOIN DPFabricDbDtl Dtl on Dtl.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where Mst.FabricDbMstID=FM.FabricDbMstID and Dtl.ConfirmPrice=1),0) as Pricee,"
                str &= " CASE WHEN LEN(FM.FabricName) <= 10 THEN FabricName ELSE LEFT(FM.FabricName, 10) + '...' END  As FabricNamee"
                str &= " ,CASE WHEN LEN(c.CompositionName) <= 10 THEN CompositionName ELSE LEFT(c.CompositionName, 10) + '...' END  As CompositionNamee"
                str &= " ,CASE WHEN LEN(FM.FabricQuality) <= 10 THEN FabricQuality ELSE LEFT(FM.FabricQuality, 10) + '...' END  As FabricQualityy"
                str &= " ,CASE WHEN LEN(FM.SupplierArtNo) <= 10 THEN SupplierArtNo ELSE LEFT(FM.SupplierArtNo, 10) + '...' END  As SupplierArtNoo"
                str &= " from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId where FM.DPTypeID= '" & DPTypeId & "' order by FM.creationDate desc"
               
                'str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                'str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                'str &= " join Composition c on c.CompositionId=FM.CompositionId order by FM.creationDate desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTypeID()
            Dim str As String
            Try
                str = " SELECT TOP 1 DPTypeID  FROM DPFabricDbMst ORDER BY FabricDbMstID DESC"
               
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewForSearching(ByVal TypeID As Long)
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,*"
                str &= " ,isnull((select top 1 (Dtl.Price) from DPFabricDbMst Mst"
                str &= " left JOIN DPFabricDbDtl Dtl on Dtl.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where Mst.FabricDbMstID=FM.FabricDbMstID and Dtl.ConfirmPrice=1),0) as Pricee,"
                str &= " CASE WHEN LEN(FM.FabricName) <= 10 THEN FabricName ELSE LEFT(FM.FabricName, 10) + '...' END  As FabricNamee"
                str &= " ,CASE WHEN LEN(c.CompositionName) <= 10 THEN CompositionName ELSE LEFT(c.CompositionName, 10) + '...' END  As CompositionNamee"
                str &= " ,CASE WHEN LEN(FM.FabricQuality) <= 10 THEN FabricQuality ELSE LEFT(FM.FabricQuality, 10) + '...' END  As FabricQualityy"
                str &= " ,CASE WHEN LEN(FM.SupplierArtNo) <= 10 THEN SupplierArtNo ELSE LEFT(FM.SupplierArtNo, 10) + '...' END  As SupplierArtNoo"
                str &= " from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId "
                str &= " where DPTypeID= '" & TypeID & "'"
                str &= " GROUP BY FM.CreationDate,FM.FabricDBMstId,FM.CreationDate,FM.DalNo,FM.FabricCode,FM.SupplierArtNo,FM.SupplierID,FM.FabricQuality,FM.Color,FM.CompositionId,FM.DyeWash,FM.FinishGSM,FM.FabricWidth,FM.AfterWashGsm,FM.Shrinkage,FM.GeneralRemarks,FM.OPQty,FM.PurchaseQty,FM.Userid,FM.FinishId,FM.DyeId,FM.DPTypeId,FM.BefWashGSM,FM.MillShrinkage,FM.FabricName,FM.Onz,FM.Shade,V.SupplierDatabaseId,V.SupplierName,V.SupplieAddress,V.IsActive,V.TelephoneNo,V.Email,V.SupplierCategoryId,V.SupplierCode,V.FaxNo,V.AccountCode,V.userid,c.CompositionID,c.CompositionName,FM.FabricDBMstId,v.creationdate"
                'str &= " ORDER BY MAX(CAST((substring(FM.DalNo,0,6))AS int)) DESC "
                ' ATIF WORK ON 24 JULY 2018
                str &= " ORDER BY MAX(CAST((substring(REPLACE(FM.DalNo,'IMP-',''),0,6))AS int)) DESC "

                'str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                'str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                'str &= " join Composition c on c.CompositionId=FM.CompositionId order by FM.creationDate desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRNDGGTStatusBit(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " SELECT * FROM TblDPRND  Mst"
                str &= " join DPRNDStyleDetail Dtl on Dtl.DPRNDID =Mst.DPRNDID"
                str &= "   where Dtl.GGTcannotteditRND = 1 and Mst.DPRNDID= '" & DPRNDID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewForSearchingImp(ByVal TypeID As Long)
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,*"
                str &= " ,isnull((select top 1 (Dtl.Price) from DPFabricDbMst Mst"
                str &= " left JOIN DPFabricDbDtl Dtl on Dtl.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where Mst.FabricDbMstID=FM.FabricDbMstID and Dtl.ConfirmPrice=1),0) as Pricee,"
                str &= " CASE WHEN LEN(FM.FabricName) <= 10 THEN FabricName ELSE LEFT(FM.FabricName, 10) + '...' END  As FabricNamee"
                str &= " ,CASE WHEN LEN(c.CompositionName) <= 10 THEN CompositionName ELSE LEFT(c.CompositionName, 10) + '...' END  As CompositionNamee"
                str &= " ,CASE WHEN LEN(FM.FabricQuality) <= 10 THEN FabricQuality ELSE LEFT(FM.FabricQuality, 10) + '...' END  As FabricQualityy"
                str &= " ,CASE WHEN LEN(FM.SupplierArtNo) <= 10 THEN SupplierArtNo ELSE LEFT(FM.SupplierArtNo, 10) + '...' END  As SupplierArtNoo"
                str &= " from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId "
                str &= " where DPTypeID= '" & TypeID & "'"
                str &= " GROUP BY FM.CreationDate,FM.FabricDBMstId,FM.CreationDate,FM.DalNo,FM.FabricCode,FM.SupplierArtNo,FM.SupplierID,FM.FabricQuality,FM.Color,FM.CompositionId,FM.DyeWash,FM.FinishGSM,FM.FabricWidth,FM.AfterWashGsm,FM.Shrinkage,FM.GeneralRemarks,FM.OPQty,FM.PurchaseQty,FM.Userid,FM.FinishId,FM.DyeId,FM.DPTypeId,FM.BefWashGSM,FM.MillShrinkage,FM.FabricName,FM.Onz,FM.Shade,V.SupplierDatabaseId,V.SupplierName,V.SupplieAddress,V.IsActive,V.TelephoneNo,V.Email,V.SupplierCategoryId,V.SupplierCode,V.FaxNo,V.AccountCode,V.userid,c.CompositionID,c.CompositionName,FM.FabricDBMstId,v.creationdate"
                str &= " ORDER BY MAX(FM.DalNo) DESC"
                'str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                'str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                'str &= " join Composition c on c.CompositionId=FM.CompositionId order by FM.creationDate desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewForDenim()
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,*"
                str &= " ,isnull((select top 1 (Dtl.Price) from DPFabricDbMst Mst"
                str &= " JOIN DPFabricDbDtl Dtl on Dtl.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where Mst.FabricDbMstID=FM.FabricDbMstID and Dtl.ConfirmPrice=1),0) as Pricee,"
                str &= " CASE WHEN LEN(FM.FabricName) <= 10 THEN FabricName ELSE LEFT(FM.FabricName, 10) + '...' END  As FabricNamee"
                str &= " ,CASE WHEN LEN(c.CompositionName) <= 10 THEN CompositionName ELSE LEFT(c.CompositionName, 10) + '...' END  As CompositionNamee"
                str &= " ,CASE WHEN LEN(FM.FabricQuality) <= 10 THEN FabricQuality ELSE LEFT(FM.FabricQuality, 10) + '...' END  As FabricQualityy"
                str &= " ,CASE WHEN LEN(FM.SupplierArtNo) <= 10 THEN SupplierArtNo ELSE LEFT(FM.SupplierArtNo, 10) + '...' END  As SupplierArtNoo"
                str &= " from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId "
                str &= " where DPTypeID=1  "
                str &= " GROUP BY FM.CreationDate,FM.FabricDBMstId,FM.CreationDate,FM.DalNo,FM.FabricCode,FM.SupplierArtNo,FM.SupplierID,FM.FabricQuality,FM.Color,FM.CompositionId,FM.DyeWash,FM.FinishGSM,FM.FabricWidth,FM.AfterWashGsm,FM.Shrinkage,FM.GeneralRemarks,FM.OPQty,FM.PurchaseQty,FM.Userid,FM.FinishId,FM.DyeId,FM.DPTypeId,FM.BefWashGSM,FM.MillShrinkage,FM.FabricName,FM.Onz,FM.Shade,V.SupplierDatabaseId,V.SupplierName,V.SupplieAddress,V.IsActive,V.TelephoneNo,V.Email,V.SupplierCategoryId,V.SupplierCode,V.FaxNo,V.AccountCode,V.userid,c.CompositionID,c.CompositionName,FM.FabricDBMstId"
                str &= " ORDER BY MAX(CAST((substring(FM.DalNo,0,6))AS int)) DESC"

                
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataNewForDyed()
            Dim str As String
            Try
                str = " select convert(varchar,FM.CreationDate,103) as CreationDatee,*"
                str &= " ,isnull((select top 1 (Dtl.Price) from DPFabricDbMst Mst"
                str &= " JOIN DPFabricDbDtl Dtl on Dtl.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where Mst.FabricDbMstID=FM.FabricDbMstID and Dtl.ConfirmPrice=1),0) as Pricee,"
                str &= " CASE WHEN LEN(FM.FabricName) <= 10 THEN FabricName ELSE LEFT(FM.FabricName, 10) + '...' END  As FabricNamee"
                str &= " ,CASE WHEN LEN(c.CompositionName) <= 10 THEN CompositionName ELSE LEFT(c.CompositionName, 10) + '...' END  As CompositionNamee"
                str &= " ,CASE WHEN LEN(FM.FabricQuality) <= 10 THEN FabricQuality ELSE LEFT(FM.FabricQuality, 10) + '...' END  As FabricQualityy"
                str &= " ,CASE WHEN LEN(FM.SupplierArtNo) <= 10 THEN SupplierArtNo ELSE LEFT(FM.SupplierArtNo, 10) + '...' END  As SupplierArtNoo"
                str &= " from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId "
                str &= " where DPTypeID=2 "
                str &= " GROUP BY FM.CreationDate,FM.FabricDBMstId,FM.CreationDate,FM.DalNo,FM.FabricCode,FM.SupplierArtNo,FM.SupplierID,FM.FabricQuality,FM.Color,FM.CompositionId,FM.DyeWash,FM.FinishGSM,FM.FabricWidth,FM.AfterWashGsm,FM.Shrinkage,FM.GeneralRemarks,FM.OPQty,FM.PurchaseQty,FM.Userid,FM.FinishId,FM.DyeId,FM.DPTypeId,FM.BefWashGSM,FM.MillShrinkage,FM.FabricName,FM.Onz,FM.Shade,V.SupplierDatabaseId,V.SupplierName,V.SupplieAddress,V.IsActive,V.TelephoneNo,V.Email,V.SupplierCategoryId,V.SupplierCode,V.FaxNo,V.AccountCode,V.userid,c.CompositionID,c.CompositionName,FM.FabricDBMstId"
                str &= " ORDER BY MAX(CAST((substring(FM.DalNo,0,6))AS int)) DESC"


               
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastDalnoDyedd()
            Dim str As String
            Try
                'str = " select max(substring(Mst.DalNo,0,20)) as DalNo from DPFabricDbMst Mst"
                'str &= "  where Mst.DPTypeID = 2"


                str = "  select  MAX(CAST((substring(Mst.DalNo,0,6)) AS int))  as DalNo from DPFabricDbMst Mst"
                str &= "   where Mst.DPTypeID = 2"

                'str = " select top 1 Mst.DalNo from DPFabricDbMst Mst"
                'str &= " join DPType DT on DT.DPTypeID=Mst.DPTypeID where DT.DPTypeID=2"
                'str &= " order by Mst.FabricDbMstID desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastDalnoDenimm()
            Dim str As String
            Try
                'str = " select max(substring(Mst.DalNo,0,20)) as DalNo from DPFabricDbMst Mst"
                'str &= "  where Mst.DPTypeID = 1"

                str = "  select  MAX(CAST((substring(Mst.DalNo,0,6)) AS int))  as DalNo from DPFabricDbMst Mst"
                str &= "   where Mst.DPTypeID = 1"
                'str = " select top 1 Mst.DalNo from DPFabricDbMst Mst"
                'str &= " join DPType DT on DT.DPTypeID=Mst.DPTypeID where DT.DPTypeID=1"
                'str &= " order by Mst.FabricDbMstID desc"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditForExportLc(ByVal LCExportMstID As Long)
            Dim str As String
            Try
                str = "  SELECT *,convert(varchar,Dtl.PISendDate,103) as PISendDatee,convert(varchar,Dtl.LCRecvDate,103) as LCRecvDatee,convert(varchar,Dtl.LCShipDate,103) as LCShipDatee,convert(varchar,Dtl.LCAmdDate,103) as LCAmdDatee  FROM LCExportMst Mst"
                str &= " join LCExportDtl Dtl ON dTL.LCExportMstID =Mst.LCExportMstID"
                str &= "  join DPIMst DPM on DPM.DPIMstID =mst.PIID"
                str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =Dtl.SeasonDatabaseID  "
                str &= " JOIN Customer C on C.CustomerID =Dtl.CustomerID "
                str &= "  join Currency CC on CC.CurrencyID =Dtl.CurrencyID "
                str &= "  JOIN PaymentTerm PT on PT.PaymentTermID =DTL.PaymentTermID "
                str &= " where Mst.LCExportMstID='" & LCExportMstID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEdit(ByVal FabricDBMstId As Long)
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where fm.FabricDBMstId='" & FabricDBMstId & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditDETAIL(ByVal FabricDBMstId As Long)
            Dim str As String
            Try
                str = "select convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM JOIN DPFabricDbDtl FD ON  FD.FabricDBMstId=FM.FabricDBMstId"
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where fm.FabricDBMstId='" & FabricDBMstId & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetDalRefNoFromFStore(ByVal DalRefNo As String)
            Dim Str As String
            Str = "  Select  IMS_I.DalRefNo  as Name from IMSItem IMS_I "
            Str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            Str &= "  where IMS_ICL.StoreTypeID=1 and IMS_I.DalRefNo like '" & DalRefNo & "%'  order by IMS_I.DalRefNo ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDalNoFromFStore(ByVal DalNo As String)
            Dim Str As String
            ' Str = " select DalNo AS Name from DPFabricDbMst where DalNo like '" & DalNo & "%'"

            Str = "  Select  FDB.DalNo  as Name from IMSItem IMS_I "
            Str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            Str &= " join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID "
            Str &= "  where IMS_ICL.StoreTypeID=1 and DalNo like '" & DalNo & "%'  order by FDB.DalNo ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDalNo(ByVal DalNo As String)
            Dim Str As String
            Str = " select DalNo AS Name from DPFabricDbMst where DalNo like '" & DalNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDSINo(ByVal iSSUENo As String)
            Dim Str As String
            Str = " select iSSUENo AS Name from DPFabricIssue where iSSUENo like '" & iSSUENo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingType(ByVal DPTypeName As String)
            Dim Str As String
            Str = " select  *  from  DPType where DPTypeName = '" & DPTypeName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDye(ByVal DyeName As String)
            Dim Str As String
            Str = " select  *  from  DPDye where DyeName = '" & DyeName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingFinishName(ByVal FinishName As String)
            Dim Str As String
            Str = " select  *  from  DPFinish where FinishName = '" & FinishName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingCompositionName(ByVal CompositionName As String)
            Dim Str As String
            Str = " select  *  from  Composition where CompositionName = '" & CompositionName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckLastCompositionName()
            Dim Str As String
            Str = " select  CompositionName,Compositionid  from  Composition order by Compositionid desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckLastFinishGSMName()
            Dim Str As String
            Str = " select  FinishName,Finishid  from  DPFinish order by Finishid desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetWashNo(ByVal WashIssueNo As String)
            Dim Str As String
            Str = " select WashIssueNo AS Name from DPWashMst where WashIssueNo like '" & WashIssueNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOAccountNameForNaeemContraVoucher(ByVal AccountName As String)
            Dim Str As String
            Str = " Select AccountName as Name from tblAccounts where AccountLevel='Detail' and actleveldigit=4 and Groupact='0102004' or Groupact='0102005' and AccountName like '" & AccountName & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDSRNo(ByVal DSRNO As String)
            Dim Str As String
            Str = " select DSRNO AS Name from DPSampleReceive where DSRNO like '" & DSRNO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckDal(ByVal DalNo As String)
            Dim Str As String
            Str = " select * from DPFabricDbMst where DalNo = '" & DalNo & " ' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckDPTypeID(ByVal FabricDbMstID As Long)
            Dim Str As String
            Str = " select DPTypeID from DPFabricDbMst where FabricDbMstID = '" & FabricDBMstId & " ' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDyeDyename(ByVal stra As String)
            Dim str As String
            Try
                str = "select top 1 DyeID from DPDye where DyeName = '" & stra & "' "

                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetDyeForSearch(ByVal stra As String)
            Dim str As String
            Try
                str = "select DyeName from DPDye where DyeName like('" & stra & "%') order by DyeName "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace
