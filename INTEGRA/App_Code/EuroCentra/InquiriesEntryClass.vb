Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class InquiriesEntryClass
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "InquiryStyle"
            m_strPrimaryFieldName = "InquiryStyleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_InquiryStyleID As Long
        Private m_CreationDate As Date
        Private m_UserID As Long
        Private m_StyleNo As String
        Private m_CoreLine As String
        Private m_BuyerName As String
        Private m_StyleDescription As String
        Private m_CustomerID As Long
        Private m_BuyingDept As String
        Private m_SeasonID As Long
        Private m_StyleSource As String
        Private m_BrandName As String
        Private m_RecvDate As Date
        Private m_ExFactoryDate As String
        Private m_EnquiryType As String
        Private m_POStatus As String
        Private m_FileName As String
        Private m_Picture As Object
        Private m_EnquiryPurpose As String
        Private m_EnquiryConfirmDate As String
        Private m_DesignName As String
        Private m_DiffcultyLevel As String
        Private m_ReasonofCancel As String
        Public Property ReasonofCancel() As String
            Get
                ReasonofCancel = m_ReasonofCancel
            End Get
            Set(ByVal value As String)
                m_ReasonofCancel = value
            End Set
        End Property
        Public Property InquiryStyleID() As Long
            Get
                InquiryStyleID = m_InquiryStyleID
            End Get
            Set(ByVal value As Long)
                m_InquiryStyleID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_CreationDate
            End Get
            Set(ByVal value As Date)
                m_CreationDate = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_UserID
            End Get
            Set(ByVal value As Long)
                m_UserID = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_StyleNo
            End Get
            Set(ByVal value As String)
                m_StyleNo = value
            End Set
        End Property
        Public Property CoreLine() As String
            Get
                CoreLine = m_CoreLine
            End Get
            Set(ByVal value As String)
                m_CoreLine = value
            End Set
        End Property
        Public Property BuyerName() As String
            Get
                BuyerName = m_BuyerName
            End Get
            Set(ByVal value As String)
                m_BuyerName = value
            End Set
        End Property
        Public Property StyleDescription() As String
            Get
                StyleDescription = m_StyleDescription
            End Get
            Set(ByVal value As String)
                m_StyleDescription = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_CustomerID
            End Get
            Set(ByVal value As Long)
                m_CustomerID = value
            End Set
        End Property

        Public Property BuyingDept() As String
            Get
                BuyingDept = m_BuyingDept
            End Get
            Set(ByVal value As String)
                m_BuyingDept = value
            End Set
        End Property
        Public Property SeasonID() As Long
            Get
                SeasonID = m_SeasonID
            End Get
            Set(ByVal value As Long)
                m_SeasonID = value
            End Set
        End Property
        Public Property StyleSource() As String
            Get
                StyleSource = m_StyleSource
            End Get
            Set(ByVal value As String)
                m_StyleSource = value
            End Set
        End Property
        Public Property BrandName() As String
            Get
                BrandName = m_BrandName
            End Get
            Set(ByVal value As String)
                m_BrandName = value
            End Set
        End Property
        Public Property RecvDate() As Date
            Get
                RecvDate = m_RecvDate
            End Get
            Set(ByVal value As Date)
                m_RecvDate = value
            End Set
        End Property
        Public Property ExFactoryDate() As String
            Get
                ExFactoryDate = m_ExFactoryDate
            End Get
            Set(ByVal value As String)
                m_ExFactoryDate = value
            End Set
        End Property
        Public Property EnquiryType() As String
            Get
                EnquiryType = m_EnquiryType
            End Get
            Set(ByVal value As String)
                m_EnquiryType = value
            End Set
        End Property
        Public Property POStatus() As String
            Get
                POStatus = m_POStatus
            End Get
            Set(ByVal value As String)
                m_POStatus = value
            End Set
        End Property

        Public Property FileName() As String
            Get
                FileName = m_FileName
            End Get
            Set(ByVal value As String)
                m_FileName = value
            End Set
        End Property
        Public Property Picture() As Object
            Get
                Picture = m_Picture
            End Get
            Set(ByVal value As Object)
                m_Picture = value
            End Set
        End Property

        Public Property EnquiryPurpose() As String
            Get
                EnquiryPurpose = m_EnquiryPurpose
            End Get
            Set(ByVal value As String)
                m_EnquiryPurpose = value
            End Set
        End Property
        Public Property EnquiryConfirmDate() As String
            Get
                EnquiryConfirmDate = m_EnquiryConfirmDate
            End Get
            Set(ByVal value As String)
                m_EnquiryConfirmDate = value
            End Set
        End Property
        Public Property DesignName() As String
            Get
                DesignName = m_DesignName
            End Get
            Set(ByVal value As String)
                m_DesignName = value
            End Set
        End Property
        Public Property DiffcultyLevel() As String
            Get
                DiffcultyLevel = m_DiffcultyLevel
            End Get
            Set(ByVal value As String)
                m_DiffcultyLevel = value
            End Set
        End Property
        Public Function SaveEnquiryStyle()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSeason() As DataTable
            Dim str As String
            str = " select   * from season  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplier(ByVal Customerid As Long, ByVal BuyerName As String, ByVal BuyingDept As String) As DataTable
            Dim str As String
            str = " Select distinct TBC.Supplierid,vendername"
            str &= " from InquiryStyle ISS "
            str &= " JOIN InquiryStyleProductInformation M ON M.InquiryStyleID=ISS.InquiryStyleID"
            str &= " JOIN TblInquiryConfirmed TBC ON TBC.InquiryStyleID=m.InquiryStyleID AND TBC.InquirySproductID=M.InquirySproductID  "
            str &= " join vender v on v.venderlibraryid=tbc.Supplierid"
            str &= " where ISS.CustomerId='" & Customerid & "' and ISS.BuyerName='" & BuyerName & "' and BuyingDept='" & BuyingDept & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFilterComboValues() As DataTable
            Dim str As String
            str = "SELECT distinct c.CustomerID  ,c.customername  from   customer c   order by customername"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingNo(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct departmentno from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerInfoNo(ByVal customerid As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid='" & customerid & "' and DepartmentNo='" & BuyingDept & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandInfoNo(ByVal customerid As Long, ByVal BuyingDept As String, ByVal Buyer As String) As DataTable
            Dim str As String
            str = "SELECT distinct BrandName from   customerDetail where customerid='" & customerid & "' and DepartmentNo='" & BuyingDept & "' and Buyer_Name='" & Buyer & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductPortfolio() As DataTable
            Dim str As String
            str = "Select * from ProductPortfolio order by ProductPortfolio ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductCategories(ByVal ProductPortfolioID As Long) As DataTable
            Dim str As String
            str = "  Select * from ProductCategories PC"
            str &= "  join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID"
            str &= "  where PC.ProductPortfolioID =" & ProductPortfolioID
            str &= " order by PC.ProductCategories ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductConsumer() As DataTable
            Dim str As String
            str = " select   * from ProductConsumer  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLiningType() As DataTable
            Dim str As String
            str = " select   * from LiningType  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUnits() As DataTable
            Dim str As String
            str = "Select * from Units order by UnitName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetComposition() As DataTable
            Dim str As String
            str = " select   * from Composition  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductType() As DataTable
            Dim str As String
            str = " Select * from ProductType order by ProductType ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFabricType() As DataTable
            Dim str As String
            str = " select   * from FabricType  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAllForUser(ByVal UserID As Long, ByVal Seasonid As Long, ByVal SupplierID As Long)
            Dim Str As String
            If UserID = 234 Then
                If Seasonid > 0 And SupplierID > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.seasonid='" & Seasonid & "' and ES.SupplierID='" & SupplierID & "'"
                ElseIf Seasonid > 0 And SupplierID = 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.seasonid='" & Seasonid & "'  "
                ElseIf Seasonid = 0 And SupplierID > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"

                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.SupplierID='" & SupplierID & "'"
                Else
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"

                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid  "

                End If
            Else
                If Seasonid > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.seasonid='" & Seasonid & "'  "
              Else
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "'"

                End If
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetOnlyStyleSearch(ByVal StyleNo As String, ByVal Seasonid As Long, ByVal SupplierID As Long)
            Dim Str As String
            If Seasonid > 0 Then
                Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"
                Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid Where Es.StyleNo='" & StyleNo & "' and ES.seasonid='" & Seasonid & "' "
            Else
                Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from InquiryStyle ES"
                Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid Where Es.StyleNo='" & StyleNo & "'"

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMaster(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from InquiryStyle  where InquiryStyleID=" & InquiryStyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductNew(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            'str = "  Select *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup from StyleProductInformation M join FabricType FT on FT.FabricTypeID=M.FabricTypeID join ProductType FF on FF.TypeID=M.FabFinishID join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId where M.StyleID=" & StyleID
            str = " Select isnull(CMP.CompositionName,'') as LiningComposition,"
            str &= " isnull(LT.LiningType,'') as LiningType,isnull(LT.LiningTypeID,0) as LiningTypeID,"
            str &= " *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup "
            str &= " from InquiryStyleProductInformation M "
            str &= " join FabricType FT on FT.FabricTypeID=M.FabricTypeID "
            str &= " join ProductType FF on FF.TypeID=M.FabFinishID "
            str &= " join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId"
            str &= " LEFT join LiningType LT ON LT.LiningTypeID=M.LiningTypeID"
            str &= " left  JOIN Composition CMP ON CMP.CompositionID=M.LiningCompId"
            str &= "  where M.InquiryStyleID = '" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductNew22(ByVal InquirySproductID As Long) As DataTable
            Dim str As String
            'str = "  Select *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup from StyleProductInformation M join FabricType FT on FT.FabricTypeID=M.FabricTypeID join ProductType FF on FF.TypeID=M.FabFinishID join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId where M.StyleID=" & StyleID
            str = " Select isnull(CMP.CompositionName,'') as LiningComposition,"
            str &= " isnull(LT.LiningType,'') as LiningType,isnull(LT.LiningTypeID,0) as LiningTypeID,"
            str &= " *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup "
            str &= " from InquiryStyleProductInformation M "
            str &= " join FabricType FT on FT.FabricTypeID=M.FabricTypeID "
            str &= " join ProductType FF on FF.TypeID=M.FabFinishID "
            str &= " join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId"
            str &= " LEFT join LiningType LT ON LT.LiningTypeID=M.LiningTypeID"
            str &= " left  JOIN Composition CMP ON CMP.CompositionID=M.LiningCompId"
            str &= "  where M.InquirySproductID = '" & InquirySproductID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductForConfromed(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            'str = "  Select *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup from StyleProductInformation M join FabricType FT on FT.FabricTypeID=M.FabricTypeID join ProductType FF on FF.TypeID=M.FabFinishID join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId where M.StyleID=" & StyleID
            str = "  Select isnull(StylingDetail,'') as StylingDetail,ISNULL(TBC.ConCompostionId,M.CompositionId) AS Compid,"
            str &= " ISNULL(TBC.ConFConstruction,M.FabicCons) AS FConstruction,"
            str &= " ISNULL(TBC.ConFwt,M.Fabicwt) AS FWT,"
            str &= " ISNULL(TBC.Price,M.BuyerTargetPrice) AS Price,ISNULL(TBC.SUPPLIERID,0) AS SUPPLIERID"
            str &= " ,ISNULL(TBC.Color,M.Color) AS Color,ISNULL(TBC.Qty,M.BuyerMOQ) AS Qty,"
            str &= " ISNULL(TBC.ConfirmRemarks,'') AS Rremarks,ISNULL(TBC.CadArtDate,'') AS CadArtDate,"
            str &= " ISNULL(TBC.TackPack,'') AS TackPack, ISNULL(TBC.InquiryConformedID,'0') as InquiryConformedID, isnull(CMP.CompositionName,'') as LiningComposition,"
            str &= " isnull(LT.LiningType,'') as LiningType,isnull(LT.LiningTypeID,0) as LiningTypeID,"
            str &= " *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup "
            str &= " from InquiryStyleProductInformation M "
            str &= " join FabricType FT on FT.FabricTypeID=M.FabricTypeID "
            str &= " join ProductType FF on FF.TypeID=M.FabFinishID "
            str &= " join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId"
            str &= " LEFT join LiningType LT ON LT.LiningTypeID=M.LiningTypeID"
            str &= " left  JOIN Composition CMP ON CMP.CompositionID=M.LiningCompId"
            str &= " Left JOIN TblInquiryConfirmed TBC ON TBC.InquiryStyleID=m.InquiryStyleID AND TBC.InquirySproductID=M.InquirySproductID"
            str &= "  where M.InquiryStyleID = '" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataforBindCombo() As DataTable
            Dim str As String
            str = "select VenderLibraryID,VenderName from Vender where Isactive='1' order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getConfroemSupllier(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = "select VenderName,VenderLibraryID,count(VenderLibraryID) as TotalCount"
            str &= " from tblStyleQuotationInformation TSQ "
            str &= " left JOIN Vender v1 on v1.VenderLibraryID=TSQ.SupplierID1 or v1.VenderLibraryID=TSQ.SupplierID2"
            str &= " or v1.VenderLibraryID=TSQ.SupplierID3"
            str &= " or v1.VenderLibraryID=TSQ.SupplierID4"
            str &= " or v1.VenderLibraryID=TSQ.SupplierID5"
            str &= "   where InquiryStyleID = '" & InquiryStyleID & "'"
            str &= " group by VenderName,VenderLibraryID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierName() As DataTable
            Dim str As String

            str = " select VenderLibraryID ,VenderName from  Vender v "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdatePOStatusAndConfirmDate(ByVal ID As Long, ByVal ConfirmDate As String, ByVal POStatus As String)
            Dim str As String
            str = " update InquiryStyle set POStatus='" & POStatus & "',EnquiryConfirmDate='" & ConfirmDate & "' where InquiryStyleID='" & ID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdatePOStatusAndConfirmDateNew(ByVal ID As Long, ByVal ConfirmDate As String, ByVal POStatus As String, ByVal ReasonOfCancel As String)
            Dim str As String
            str = " update InquiryStyle set POStatus='" & POStatus & "',EnquiryConfirmDate='" & ConfirmDate & "',ReasonofCancel='" & ReasonOfCancel & "' where InquiryStyleID='" & ID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierForPerformanceReport(ByVal Customerid As Long, ByVal BuyingDept As String, ByVal Seasonid As Long) As DataTable
            Dim str As String
            str = " SELECT distinct vendername,Supplierid from SamplingMaster sm "
            str &= " JOIN Vender V ON V.VenderLibraryID=SM.sUPPLIERID "
            str &= "  where   sm.SamplePageType=4 and sm.customerID = '" & Customerid & "'   AND sm.BuyingDept='" & BuyingDept & "' and Seasonid='" & Seasonid & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonForPerformanceReport(ByVal Customerid As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            str = " select distinct S.Seasonid,Season from SamplingMaster sm "
            str &= " JOIN Season S ON S.Seasonid=sm.Seasonid where sm.customerID= '" & Customerid & "' "
            str &= " AND sm.BuyingDept='" & BuyingDept & "' and sm.SamplePageType=4 "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
