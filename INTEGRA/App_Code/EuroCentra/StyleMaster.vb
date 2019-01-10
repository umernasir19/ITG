Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Namespace EuroCentra
    Public Class StyleMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleMaster"
            m_strPrimaryFieldName = "StyleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_StyleID As Long
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
        Private m_EmbellID As Long
        Private m_DimensionalStablityL As String
        Private m_DimensionalStablityW As String
        Private m_RubbingFastnessWet As String
        Private m_RubbingFastnessDry As String
        Private m_TypeOfDyesID As Long
        Private m_TypeOfPrintID As Long
        Private m_TypeOfWashingID As Long
        Private m_CartonType As String
        Private m_CartonSizeL As Decimal
        Private m_CartonSizeW As Decimal
        Private m_CartonSizeH As Decimal
        Private m_CartonSizeUnitID As Long
        Private m_QtyCarton As Decimal
        Private m_lQtyCartonUnitID As Long
        Private m_QtyPack As Decimal
        Private m_QtyPackUnitID As Long
        Private m_PolyBagSizeL As Decimal
        Private m_PolyBagSizeW As Decimal
        Private m_PolyBagSizeFlap As Decimal
        Private m_PolyBagSizeUnitID As Long
        Private m_InlayCardSize As String
        Private m_PackedPcL As Decimal
        Private m_PackedPcW As Decimal
        Private m_PackedPcUnitID As Long
        Private m_GrossWeightCarton As Decimal
        Private m_GrossWeightCartonUnitID As Long
        Private m_PolyBagStickerSizeL As Decimal
        Private m_PolyBagStickerSizeW As Decimal
        Private m_PolyBagStickerSizeH As Decimal
        Private m_PolyBagStickerSizeUnitID As Long
        Private m_BrandName As String
        Private m_InsetComplaintType As String
        Private m_Degree1ofColourID As Long
        Private m_Degree2ofColourID As Long
        Private m_Degree3ofColourID As Long
        Private m_BleachingSymbolID As Long
        Private m_IroningSymbolID As Long
        Private m_DryCleaningSymbolID As Long
        Private m_TumbleDryID As Long
        Private m_BuyerTechComments As String
        Public Property InsetComplaintType() As String
            Get
                InsetComplaintType = m_InsetComplaintType
            End Get
            Set(ByVal value As String)
                m_InsetComplaintType = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_StyleID
            End Get
            Set(ByVal value As Long)
                m_StyleID = value
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
        Public Property EmbellID() As Long
            Get
                EmbellID = m_EmbellID
            End Get
            Set(ByVal value As Long)
                m_EmbellID = value
            End Set
        End Property
        Public Property DimensionalStablityL() As String
            Get
                DimensionalStablityL = m_DimensionalStablityL
            End Get
            Set(ByVal value As String)
                m_DimensionalStablityL = value
            End Set
        End Property
        Public Property DimensionalStablityW() As String
            Get
                DimensionalStablityW = m_DimensionalStablityW
            End Get
            Set(ByVal value As String)
                m_DimensionalStablityW = value
            End Set
        End Property
        Public Property RubbingFastnessWet() As String
            Get
                RubbingFastnessWet = m_RubbingFastnessWet
            End Get
            Set(ByVal value As String)
                m_RubbingFastnessWet = value
            End Set
        End Property
        Public Property RubbingFastnessDry() As String
            Get
                RubbingFastnessDry = m_RubbingFastnessDry
            End Get
            Set(ByVal value As String)
                m_RubbingFastnessDry = value
            End Set
        End Property
        Public Property TypeOfDyesID() As Long
            Get
                TypeOfDyesID = m_TypeOfDyesID
            End Get
            Set(ByVal value As Long)
                m_TypeOfDyesID = value
            End Set
        End Property
        Public Property TypeOfPrintID() As Long
            Get
                TypeOfPrintID = m_TypeOfPrintID
            End Get
            Set(ByVal value As Long)
                m_TypeOfPrintID = value
            End Set
        End Property
        Public Property TypeOfWashingID() As Long
            Get
                TypeOfWashingID = m_TypeOfWashingID
            End Get
            Set(ByVal value As Long)
                m_TypeOfWashingID = value
            End Set
        End Property
        Public Property CartonType() As String
            Get
                CartonType = m_CartonType
            End Get
            Set(ByVal value As String)
                m_CartonType = value
            End Set
        End Property
        Public Property CartonSizeL() As Decimal
            Get
                CartonSizeL = m_CartonSizeL
            End Get
            Set(ByVal value As Decimal)
                m_CartonSizeL = value
            End Set
        End Property
        Public Property CartonSizeW() As Decimal
            Get
                CartonSizeW = m_CartonSizeW
            End Get
            Set(ByVal value As Decimal)
                m_CartonSizeW = value
            End Set
        End Property
        Public Property CartonSizeH() As Decimal
            Get
                CartonSizeH = m_CartonSizeH
            End Get
            Set(ByVal value As Decimal)
                m_CartonSizeH = value
            End Set
        End Property
        Public Property CartonSizeUnitID() As Long
            Get
                CartonSizeUnitID = m_CartonSizeUnitID
            End Get
            Set(ByVal value As Long)
                m_CartonSizeUnitID = value
            End Set
        End Property
        Public Property QtyCarton() As Decimal
            Get
                QtyCarton = m_QtyCarton
            End Get
            Set(ByVal value As Decimal)
                m_QtyCarton = value
            End Set
        End Property
        Public Property QtyCartonUnitID() As Long
            Get
                QtyCartonUnitID = m_lQtyCartonUnitID
            End Get
            Set(ByVal value As Long)
                m_lQtyCartonUnitID = value
            End Set
        End Property
        Public Property QtyPack() As Decimal
            Get
                QtyPack = m_QtyPack
            End Get
            Set(ByVal value As Decimal)
                m_QtyPack = value
            End Set
        End Property
        Public Property QtyPackUnitID() As Long
            Get
                QtyPackUnitID = m_QtyPackUnitID
            End Get
            Set(ByVal value As Long)
                m_QtyPackUnitID = value
            End Set
        End Property
        Public Property PolyBagSizeL() As Decimal
            Get
                PolyBagSizeL = m_PolyBagSizeL
            End Get
            Set(ByVal value As Decimal)
                m_PolyBagSizeL = value
            End Set
        End Property
        Public Property PolyBagSizeW() As Decimal
            Get
                PolyBagSizeW = m_PolyBagSizeW
            End Get
            Set(ByVal value As Decimal)
                m_PolyBagSizeW = value
            End Set
        End Property
        Public Property PolyBagSizeFlap() As Decimal
            Get
                PolyBagSizeFlap = m_PolyBagSizeFlap
            End Get
            Set(ByVal value As Decimal)
                m_PolyBagSizeFlap = value
            End Set
        End Property
        Public Property PolyBagSizeUnitID() As Long
            Get
                PolyBagSizeUnitID = m_PolyBagSizeUnitID
            End Get
            Set(ByVal value As Long)
                m_PolyBagSizeUnitID = value
            End Set
        End Property
        Public Property InlayCardSize() As String
            Get
                InlayCardSize = m_InlayCardSize
            End Get
            Set(ByVal value As String)
                m_InlayCardSize = value
            End Set
        End Property
        Public Property PackedPcL() As Decimal
            Get
                PackedPcL = m_PackedPcL
            End Get
            Set(ByVal value As Decimal)
                m_PackedPcL = value
            End Set
        End Property
        Public Property PackedPcW() As Decimal
            Get
                PackedPcW = m_PackedPcW
            End Get
            Set(ByVal value As Decimal)
                m_PackedPcW = value
            End Set
        End Property
        Public Property PackedPcUnitID() As Long
            Get
                PackedPcUnitID = m_PackedPcUnitID
            End Get
            Set(ByVal value As Long)
                m_PackedPcUnitID = value
            End Set
        End Property
        Public Property GrossWeightCarton() As Decimal
            Get
                GrossWeightCarton = m_GrossWeightCarton
            End Get
            Set(ByVal value As Decimal)
                m_GrossWeightCarton = value
            End Set
        End Property
        Public Property GrossWeightCartonUnitID() As Long
            Get
                GrossWeightCartonUnitID = m_GrossWeightCartonUnitID
            End Get
            Set(ByVal value As Long)
                m_GrossWeightCartonUnitID = value
            End Set
        End Property
        Public Property PolyBagStickerSizeL() As Decimal
            Get
                PolyBagStickerSizeL = m_PolyBagStickerSizeL
            End Get
            Set(ByVal value As Decimal)
                m_PolyBagStickerSizeL = value
            End Set
        End Property
        Public Property PolyBagStickerSizeW() As Decimal
            Get
                PolyBagStickerSizeW = m_PolyBagStickerSizeW
            End Get
            Set(ByVal value As Decimal)
                m_PolyBagStickerSizeW = value
            End Set
        End Property
        Public Property PolyBagStickerSizeH() As Decimal
            Get
                PolyBagStickerSizeH = m_PolyBagStickerSizeH
            End Get
            Set(ByVal value As Decimal)
                m_PolyBagStickerSizeH = value
            End Set
        End Property
        Public Property PolyBagStickerSizeUnitID() As Long
            Get
                PolyBagStickerSizeUnitID = m_PolyBagStickerSizeUnitID
            End Get
            Set(ByVal value As Long)
                m_PolyBagStickerSizeUnitID = value
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

        Public Property Degree1ofColourID() As Long
            Get
                Degree1ofColourID = m_Degree1ofColourID
            End Get
            Set(ByVal value As Long)
                m_Degree1ofColourID = value
            End Set
        End Property
         
        Public Property Degree2ofColourID() As Long
            Get
                Degree2ofColourID = m_Degree2ofColourID
            End Get
            Set(ByVal value As Long)
                m_Degree2ofColourID = value
            End Set
        End Property
 
        Public Property Degree3ofColourID() As Long
            Get
                Degree3ofColourID = m_Degree3ofColourID
            End Get
            Set(ByVal value As Long)
                m_Degree3ofColourID = value
            End Set
        End Property

        Public Property BleachingSymbolID() As Long
            Get
                BleachingSymbolID = m_BleachingSymbolID
            End Get
            Set(ByVal value As Long)
                m_BleachingSymbolID = value
            End Set
        End Property

        Public Property IroningSymbolID() As Long
            Get
                IroningSymbolID = m_IroningSymbolID
            End Get
            Set(ByVal value As Long)
                m_IroningSymbolID = value
            End Set
        End Property

        Public Property DryCleaningSymbolID() As Long
            Get
                DryCleaningSymbolID = m_DryCleaningSymbolID
            End Get
            Set(ByVal value As Long)
                m_DryCleaningSymbolID = value
            End Set
        End Property

        Public Property TumbleDryID() As Long
            Get
                TumbleDryID = m_TumbleDryID
            End Get
            Set(ByVal value As Long)
                m_TumbleDryID = value
            End Set
        End Property
        Public Property BuyerTechComments() As String
            Get
                BuyerTechComments = m_BuyerTechComments
            End Get
            Set(ByVal value As String)
                m_BuyerTechComments = value
            End Set
        End Property

        Public Function SaveStyleMaster()
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
        Public Function GetStyleById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeason()
            Dim str As String
            str = " Select * from Season "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAccountLedgerAutoSearch(ByVal ItemName As String)
            Dim Str As String

            Str = " select AccountName from 	tblaccounts where accountcode like '0501%' and Accountlevel='Detail' and accountname like '" & ItemName & "%' order by AccountName asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETFullBleachProcess(ByVal AcidName As String)
            Dim Str As String
            Str = "Select AcidName from DyeingAcid Where ProcessName='F/Bleach' and DyeingTypeId='1' and AcidName like '" & AcidName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAllLedgerForLedgerRPT(ByVal AccountName As String)
            Dim Str As String
            Str = " select   AccountName from tblaccounts where AccountName like '%" & AccountName & "%' order by AccountName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETSupplierSearch(ByVal SupplierName As String)
            Dim Str As String
            Str = " select distinct Sd.SupplierName "
            Str &= " from POInvoiceMst POM "
            Str &= " join SupplierDatabase Sd on Sd.Supplierdatabaseid=POM.AccountPayablePartyID"
            Str &= " where sd.SupplierName like '" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        
        Function GETAccountNameSearch(ByVal AccountName As String)
            Dim Str As String
            Str = "  Select (TA.AccountName+'-'+ TA.AccountCode) as AccountName ,TA.AccountCode from tblAccounts TA"
            Str &= " where AccountName like '" & AccountName & "%'"
            Str &= " order by TA.AccountName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOAccountNamewithCodeNew(ByVal AccountName As String)
            Dim Str As String
            Str = " Select (AccountName +'-'+ AccountCode) as Name,AccountName as Name2, AccountCode as Code2,ChartOfAccountID from tblAccounts where AccountLevel='Detail' and  AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetIssue(ByVal ItemCodee As String)
            Dim Str As String

            Str = " Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.IMSItemClassID = '26' and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyle(ByVal userID As String, ByVal roleID As String)
            Dim str As String
            If (roleID = 1 Or roleID = 4) And (userID = 4 Or userID = 26 Or userID = 60) Then
                str = " Select * from StyleMaster "
            Else
                str = " Select * from StyleMaster where MarchandID= " & userID
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFilterComboValue() As DataTable
            Dim str As String
            str = "SELECT  c.CustomerID  ,c.customername  from  customer c  order by C.customerID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SelectCount() As Integer

        End Function
        Public Function GetALLStyleforview(ByVal Style As String, ByVal Userid As String, ByVal RoleID As String) As DataTable
            Dim str As String
            ' str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM "
            If RoleID = 1 Or RoleID = 4 Or Userid = 4 Or Userid = 26 Or Userid = 60 Then
                str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM "
                If Not Style = "ALL" Then
                    str &= " where  SM.StyleNo= '" & Style & "'"
                End If
                str &= " order by SM.StyleID DESC"
            Else
                str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM where SM.MarchandID= '" & Userid & " '"
                If Not Style = "ALL" Then
                    str &= " and  SM.StyleNo= '" & Style & "' "
                End If
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewSearchPattern(ByVal Style As String, ByVal Userid As String, ByVal RoleID As String, ByVal Pattern As String) As DataTable
            Dim str As String
            '------According to Sir Zahid Requirement
            str = "select st.StyleID ,c.customername, c.CustomerID,st.ProductPortfolio, st.productgroup, stuff(st.stylename,10,20,'...') as stylename ,  st.Composition  as Composition,"
            str &= " st.styleno, std.article,  std.Colorway  as Colorway,"
            str &= " std.sizerange from stylemaster st join styledetail std on st.styleid=std.styleid join customer c on c.customerid=st.buyer where styleno IS NOT NULL order by St.StyleID DESC , customername,productgroup, styleno, article, sizerange"
            If Not Style = "ALL" Then
                If Pattern = "Exact" Then
                    str &= " and  SM.StyleNo = '" & Style & "'"
                ElseIf Pattern = "Like" Then
                    str &= "and SM.StyleNo Like '" & Style & "%' "
                ElseIf Pattern = "None" Then
                End If
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewSearchPattern1(ByVal Style As String, ByVal Userid As String, ByVal RoleID As String, ByVal Pattern As String) As DataTable
            Dim str As String
            '------According to Sir Zahid Requirement
            str = " select * from stylemaster st  join customer c on c.customerid=st.buyer  where styleno IS NOT NULL  "
            If Not Style = "ALL" Then
                If Pattern = "Exact" Then
                    str &= " and  SM.StyleNo = '" & Style & "'"
                ElseIf Pattern = "Like" Then
                    str &= "and SM.StyleNo Like '" & Style & "%' "
                ElseIf Pattern = "None" Then
                End If
            End If
            str &= "  order by St.StyleID DESC , customername,productgroup, styleno "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewSearchPattern22() As DataTable
            Dim str As String
            str = " select * from stylemaster  "
            str &= "  order by  styleno ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleDescription() As DataTable
            Dim str As String
            str = " select * from StyleDescription sd join StyleCategory sc on sc.StyleCategoryId =sd.StyleCategoryId "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewUSER(ByVal UserID As Long) As DataTable
            Dim str As String
            If UserID = 234 Then
                str = " select convert(varchar,creationdate,103) as creationdatee,* from stylemaster  "
                str &= "  order by  styleno ASC "
            Else
                str = " select convert(varchar,creationdate,103) as creationdatee,* from stylemaster WHERE UserID='" & UserID & "'  "
                str &= "  order by  styleno ASC "
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewManRole() As DataTable
            Dim str As String

            str = " select convert(varchar,creationdate,103) as creationdatee,* from stylemaster  "
            str &= "  order by  styleno ASC "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleNoForSearch(ByVal styleno As String) As DataTable
            Dim str As String
            str = " select convert(varchar,creationdate,103) as creationdatee,* from stylemaster where styleno='" & styleno & "'  "
            str &= "  order by  styleno ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOStyleNo(ByVal styleno As String)
            Dim Str As String
            Str = " Select styleno as Name  from stylemaster  TA   where TA.styleno like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETBuyerName(ByVal CustomerName As String)
            Dim Str As String
            Str = " Select CustomerName as Name  from Customer  TA   where TA.CustomerName like '" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOSRNoForFabricConsumption(ByVal SRNo As String)
            Dim Str As String
            Str = " Select SRNo as Name  from jobOrderdatabase  TA   where TA.SRNo like '" & SRNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForFStoreGodownSearch(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join IssueDetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= " join IssueMst IM on IM.IssueID=POD.IssueID"
            Str &= " join POMaster po on po.POID=POD.POID"
            Str &= "  where PO.fabricPOrder=1 and ISM.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForFStoreGodownSearchForAcc(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join IssueDetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= " join IssueMst IM on IM.IssueID=POD.IssueID"
            Str &= " join POMaster po on po.POID=POD.POID"
            Str &= "  where PO.fabricPOrder=0 AND po.GStoreStatus=0 and ISM.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForFStoreGodownSearchForGSTore(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join IssueDetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= " join IssueMst IM on IM.IssueID=POD.IssueID"
            Str &= " join POMaster po on po.POID=POD.POID"
            Str &= "  where  po.GStoreStatus=1 and ISM.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForFStoreGodownSearchForprocess(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join processIssueDetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForFStore(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join PODetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= " join POMaster POM on POM.POID=POD.POID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%' and POM.FabricPOrder=1"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForprocessIssueForFStore(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= "  join ProcessOrderDtl POD on POD.ItemID=ISM.IMSItemID"
            Str &= "  join ProcessOrderMst POM on POM.ProcessOrderMstID=POD.ProcessOrderMstID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%' and POM.FabricPOrder=1"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForFStoreProces(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join ProcessOrderDtl POD on POD.ProcessItemNameID=ISM.IMSItemID"
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID=POD.ProcessOrderMstID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%' and POM.FabricPOrder=1"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForAStore(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= "   join PODetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= " join POMaster POM on POM.POID=POD.POID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%' and POM.FabricPOrder=0 and POM.GStoreStatus=0"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForAStoreGStore(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= "   join PODetail POD on POD.ItemID=ISM.IMSItemID"
            Str &= " join POMaster POM on POM.POID=POD.POID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%' and  POM.GStoreStatus=1"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETItemCodeForIssueForAStoreProcess(ByVal ItemCodee As String)
            Dim Str As String
            Str = " Select distinct ISM.ItemCodee as Name  from IMSItem  ISM"
            Str &= " join ProcessOrderDtl POD on POD.ProcessItemNameID=ISM.IMSItemID"
            Str &= " join ProcessOrderMst POM on POM.ProcessOrderMstID=POD.ProcessOrderMstID"
            Str &= "  where ISM.ItemCodee like '" & ItemCodee & "%' and POM.FabricPOrder=0"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOENQStyleNo(ByVal styleno As String)
            Dim Str As String
            Str = " Select styleno as Name  from EnquiriesSystemAdd  TA   where TA.styleno like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetFabricItem(ByVal styleno As String)
            Dim Str As String
            Str = " select ItemName as Name frOm IMSItem where IMSItemClassid=6  and  ItemName like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForFStoreForAuditor(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForFStore(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 1 and  IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForChemicalStore(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 5 and  IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetProcessItemCodeForFStoreForReport(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    join ProcessOrderDtl POD on POD.ProcessItemNameID=IMS_I.IMSItemID "
            Str &= "    where IMS_ICL.StoreTypeID = 1 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForReportForAccForAuditor(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    join PODetail POD on POD.ItemID=IMS_I.IMSItemID "
            Str &= "    where   IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForReportForAcc(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    join PODetail POD on POD.ItemID=IMS_I.IMSItemID "
            Str &= "    where IMS_ICL.StoreTypeID = 2 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForReportForAccGStore(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    join PODetail POD on POD.ItemID=IMS_I.IMSItemID "
            Str &= "    where IMS_ICL.StoreTypeID = 4 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForReport(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    join PODetail POD on POD.ItemID=IMS_I.IMSItemID "
            Str &= "    where IMS_ICL.StoreTypeID = 1 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPONOOOOO(ByVal PONO As String)
            Dim Str As String

            Str = "  Select PONO as Name from POMASTER  "
            Str &= "    where PONO like '" & PONO & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForPurchaseForAcc(ByVal ItemCodee As String)
            Dim Str As String

            Str = "      select im.ItemCodee as Name from PORecvMaster Mst"
            Str &= "   join PORecvDetail pd on pd.PORecvMasterID =Mst.PORecvMasterID"
            Str &= "   join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
            Str &= "   join IMSItem im on im.IMSItemID =POD.ItemId "
            Str &= "   join IMSItemClass IMC on IMC.IMSItemClassID =IM.IMSItemClassID "
            Str &= "    where IMC.StoreTypeID=2 AND im.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForPurchaseForAuditor(ByVal ItemCodee As String)
            Dim Str As String

            Str = "      select im.ItemCodee as Name from PORecvMaster Mst"
            Str &= "   join PORecvDetail pd on pd.PORecvMasterID =Mst.PORecvMasterID"
            Str &= "   join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
            Str &= "   join IMSItem im on im.IMSItemID =POD.ItemId "
            Str &= "   join IMSItemClass IMC on IMC.IMSItemClassID =IM.IMSItemClassID "
            Str &= "    where im.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForPurchase(ByVal ItemCodee As String)
            Dim Str As String

            Str = "      select im.ItemCodee as Name from PORecvMaster Mst"
            Str &= "   join PORecvDetail pd on pd.PORecvMasterID =Mst.PORecvMasterID"
            Str &= "   join PODetail Pod On POD.PoDetailId = pd.PoDetailId"
            Str &= "   join IMSItem im on im.IMSItemID =POD.ItemId "
            Str &= "   join IMSItemClass IMC on IMC.IMSItemClassID =IM.IMSItemClassID "
            Str &= "    where IMC.StoreTypeID=1 AND im.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForAuditor(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    where IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStore(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    where IMS_ICL.StoreTypeID = 1 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForFStoreForProcessIssueReport(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "     join  processIssueDetail Dtl on Dtl.ItemID =IMS_I.IMSItemID "
            Str &= "    where  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForAStore(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    where IMS_ICL.StoreTypeID = 2 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemCodeForAStoreGStore(ByVal ItemCodee As String)
            Dim Str As String

            Str = "  Select IMS_I.ItemCodee as Name from IMSItem IMS_I "
            Str &= "    join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "    join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "    where IMS_ICL.StoreTypeID = 4 and  IMS_I.ItemCodee like '" & ItemCodee & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForAStore(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 2 and  IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForGGStore(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 4 and  IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForAStoreForAccess(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 2 and IMS_ICL.ItemClassName ='DYEING PROCESS' and IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForDStore(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 3 and  IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemForGStore(ByVal styleno As String)
            Dim Str As String

            Str = " Select IMS_I.ItemName as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 4 and  IMS_I.ItemName like '" & styleno & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForFStoreForAuditor(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForFStore(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 1 and  IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForChemStoreStore(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID =5 and  IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemIDByItemCode(ByVal ItemCodee As String) As String
            Dim Str As String
            Str = "  Select IMS_I.IMSItemID, IMS_I.ItemCodee as Name from IMSItem IMS_I  "
            Str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= " where IMS_I.ItemCodee= '" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(Str).Rows(0)(0).ToString()
            Catch ex As Exception
                Return "0"
            End Try
        End Function
        Function GetItemQualityForAStore(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 2 and  IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForGGStore(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 4 and  IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForAStoreForAccess(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 2 and IMS_ICL.ItemClassName ='DYEING PROCESS' and IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForDStore(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 3 and  IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetItemQualityForGStore(ByVal styleno As String)
            Dim Str As String
            Str = " Select IMS_I.ItemQuality as Name, Status='False' from IMSItem IMS_I "
            Str &= "  join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID "
            Str &= "  join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID "
            Str &= "  join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId "
            Str &= "  join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            Str &= "    where IMS_ICL.StoreTypeID = 4 and  IMS_I.ItemQuality like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSRNO(ByVal SRNO As String)
            Dim Str As String
            Str = " select distinct SRNO as Name frOm JobOrderdatabase where SRNO like '%" & SRNO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerNmae(ByVal CustomerName As String)
            Dim Str As String
            Str = " select distinct CustomerName as Name frOm Customer where CustomerName like '%" & CustomerName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNo(ByVal Style As String)
            Dim Str As String
            Str = " select  distinct Style as Name frOm JobOrderDatabaseDetail where Style like '%" & Style & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPON(ByVal PONo As String)
            Dim Str As String
            Str = " Select PONo as Name From JobOrderdatabase Where PONo like '%" & PONo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOENQStyleNoINQ(ByVal styleno As String)
            Dim Str As String
            Str = " Select styleno as Name  from InquiryStyle  TA   where TA.styleno like '" & styleno & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOPO(ByVal PONO As String)
            Dim Str As String
            Str = " Select PONO as Name  from PurchaseOrder TA   where TA.PONO like '" & PONO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCargoInv(ByVal InvoiceNo As String)
            Dim Str As String
            Str = " select InvoiceNO AS Name from Cargo where InvoiceNO like '" & InvoiceNo & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        'Function for bind grid filter combo'
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
        Public Function GetBuyingNoforMilestone() As DataTable
            Dim str As String
            str = "SELECT distinct EkNumber from   PurchaseOrder  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingNoNew(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct departmentno from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerInfoNo(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandInfoNo(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct BrandName from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewSearchPattern2(ByVal Style As String, ByVal Userid As String, ByVal RoleID As String, ByVal Pattern As String) As DataTable
            Dim str As String
            ' str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM "
            If RoleID = 1 Or RoleID = 4 Or Userid = 4 Or Userid = 26 Or Userid = 60 Then
                str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM "
                If Pattern = "Exact" Then
                    str &= " where  SM.StyleNo= '" & Style & "'"
                    'ElseIf Pattern = "Like" Then
                    '    str &= "where SM.StyleNo Like ='" & Style & "'   " + "%"
                    'ElseIf Pattern = "None" Then

                End If
                str &= " order by SM.StyleID DESC"
            Else
                str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM where SM.MarchandID= '" & Userid & " '"
                If Not Style = "ALL" Then
                    If Pattern = "Exact" Then
                        str &= " and  SM.StyleName = '" & Style & "'"
                        'ElseIf Pattern = "Like" Then
                        '    str &= "and SM.StyleNo Like '" & Style & "%' "
                        'ElseIf Pattern = "None" Then
                    End If
                    'str &= " and  SM.StyleNo= '" & Style & "' "
                End If
                'If Pattern = "Exact" Then
                '    str &= " where  SM.StyleNo= '" & Style & "'"
                'ElseIf Pattern = "Like" Then
                '    str &= "where SM.StyleNo Like ='" & Style & "'   " + "%"
                'ElseIf Pattern = "None" Then

                'End If
                str &= " order by SM.StyleID DESC"
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLStyleforviewSearchPatternByStyleNo(ByVal Style As String, ByVal Userid As String, ByVal RoleID As String, ByVal Pattern As String) As DataTable
            Dim str As String
            ' str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM "
            If RoleID = 1 Or RoleID = 4 Or Userid = 4 Or Userid = 26 Or Userid = 60 Then
                str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM "
                If Pattern = "Exact" Then
                    str &= " where  SM.StyleNo= '" & Style & "'"
                    'ElseIf Pattern = "Like" Then
                    '    str &= "where SM.StyleNo Like ='" & Style & "'   " + "%"
                    'ElseIf Pattern = "None" Then

                End If
                str &= " order by SM.StyleID DESC"
            Else
                str = "  Select SM.StyleID,SM.StyleNo,SM.StyleName,SM.Season,SM.ProductGroup from StyleMaster SM where SM.MarchandID= '" & Userid & " '"
                If Not Style = "ALL" Then
                    If Pattern = "Exact" Then
                        str &= " and  SM.StyleNo = '" & Style & "'"
                        'ElseIf Pattern = "Like" Then
                        '    str &= "and SM.StyleNo Like '" & Style & "%' "
                        'ElseIf Pattern = "None" Then
                    End If
                    'str &= " and  SM.StyleNo= '" & Style & "' "
                End If
                'If Pattern = "Exact" Then
                '    str &= " where  SM.StyleNo= '" & Style & "'"
                'ElseIf Pattern = "Like" Then
                '    str &= "where SM.StyleNo Like ='" & Style & "'   " + "%"
                'ElseIf Pattern = "None" Then

                'End If
                str &= " order by SM.StyleID DESC"
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleMasterByStyelID(ByVal StyleID As String) As DataTable
            Dim str As String
            str = " Select SM.*, SM.StyleID,SM.StyleNo,SM.Buyer,C.customerName,C.customerID,SM.StyleName,SM.Season,SM.ProductGroup,SM.MaterialComposition"
            str &= " from StyleMaster SM "
            str &= " join customer C on C.customerID=SM.Buyer"
            str &= "  where  SM.StyleiD='" & StyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByStyelID(ByVal StyleID As String) As DataTable
            Dim str As String
            str = " Select SM.*, SM.StyleID,SM.StyleNo,SM.Buyer,C.customerName,SM.StyleName,SM.Season,SM.ProductGroup,SM.MaterialComposition,SD.*"
            str &= " from StyleMaster SM join StyleDetail SD on SD.StyleID=SM.styleID"
            'str &= " join Season S on S.SeasonID=Sm.Season"
            str &= " join customer C on C.customerID=SM.Buyer"
            str &= "  where  SM.StyleiD='" & StyleID & "' order by SD.CreationDate"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleAcces(ByVal StyleID As String) As DataTable
            Dim str As String
            str = " Select  * "
            str &= " from StyleMaster SM join StyleAccessories Sa on SA.StyleID=SM.styleID"
            str &= "  where  SM.StyleiD='" & StyleID & "'   "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetlastRecord()
            Dim str As String
            str = "SELECT TOP 1 StyleID FROM StyleMaster ORDER BY StyleID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SaveStyleMasterwitOutImage(ByVal StyleID As Long, ByVal StyleNo As String, ByVal StyleName As String, ByVal Buyer As Long, ByVal CreationDate As String, ByVal IsActive As Boolean, ByVal MarchandID As Long, ByVal MaterialComposition As String, ByVal ProductGroup As String, ByVal Season As String)
            Try
                Dim str As String

                str = " insert into StyleMaster (StyleNo,StyleName,Buyer,CreationDate,IsActive,MarchandID,MaterialComposition,ProductGroup,Season)  "
                str &= " values ('" & StyleNo & "','" & StyleName & "','" & Buyer & "','" & CreationDate & "','1','" & MarchandID & "','" & MaterialComposition & "','" & ProductGroup & "','" & Season & "')"
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SaveStyleMasterwitOutImageUpdate(ByVal StyleID As Long, ByVal StyleNo As String, ByVal StyleName As String, ByVal Buyer As Long, ByVal CreationDate As String, ByVal IsActive As Boolean, ByVal MarchandID As Long, ByVal MaterialComposition As String, ByVal ProductGroup As String, ByVal Season As String)
            Try
                Dim str As String
                '  str = " insert into StyleMaster (StyleNo,StyleName,Buyer,CreationDate,IsActive,MarchandID,MaterialComposition,ProductGroup,Season)  "
                '  str &= " values ('" & StyleNo & "','" & StyleName & "','" & Buyer & "','" & CreationDate & "','1','" & MarchandID & "','" & MaterialComposition & "','" & ProductGroup & "','" & Season & "')"

                str = " Update StyleMaster set StyleNo='" & StyleNo & "',StyleName='" & StyleName & "', Buyer='" & Buyer & "'"
                str &= " , CreationDate='" & CreationDate & "', IsActive='1', MarchandID= '" & MarchandID & "'"
                str &= " , MaterialComposition='" & MaterialComposition & "', ProductGroup='" & ProductGroup & "', Season= '" & Season & "'"
                str &= " where styleid='" & StyleID & "'"
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByPO(ByVal UserID As Long, ByVal RoleID As Long, Optional ByVal POID As Long = 0) As DataTable
            Dim str As String
            If RoleID = 1 Or RoleID = 4 Then
                str = " Select S.MaterialComposition,S.StyleiD,SD.StyleDetailID,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID"
            Else
                str = " Select S.MaterialComposition,S.StyleiD,SD.StyleDetailID,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID"
                str &= " where S.MarchandID='" & UserID & "'"
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByStyleNo(ByVal StyleNo As String, ByVal UserID As Long, ByVal RoleID As Long) As DataTable
            Dim str As String
            If RoleID = 1 Or RoleID = 4 Then
                str = " Select S.MaterialComposition,SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID"
            Else
                str = " Select S.MaterialComposition,SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID"
                str &= " where S.StyleNo like '%" & StyleNo & "%' or S.StyleNo like '" & StyleNo & "%' or S.StyleNo like '%" & StyleNo & "' and S.MarchandID='" & UserID & "'"
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByStyleNos(ByVal StyleNo As String, ByVal Article As String, ByVal UserID As Long, ByVal RoleID As Long) As DataTable
            Dim str As String
            If StyleNo <> "" And Article <> "" Then
                str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
                str &= " where S.StyleNo='" & StyleNo & "' and SD.Article ='" & Article & "' "
            ElseIf StyleNo <> "" Then
                str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
                str &= " where S.StyleNo='" & StyleNo & "'  "
            ElseIf Article <> "" Then
                str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
                str &= " where  SD.Article ='" & Article & "' "
            End If

            'If RoleID = 1 Or RoleID = 4 Then
            '    str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
            '    str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
            '    str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
            '    str &= " where S.StyleNo like '%" & StyleNo & "%' or S.StyleNo like '" & StyleNo & "%' or S.StyleNo like '%" & StyleNo & "'"
            'Else
            '    str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
            '    str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
            '    str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID"
            '    str &= " where S.StyleNo like '%" & StyleNo & "%' or S.StyleNo like '" & StyleNo & "%' or S.StyleNo like '%" & StyleNo & "' and S.MarchandID='" & UserID & "'"
            'End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByStyleNosNew(ByVal StyleNo As String, ByVal UserID As Long, ByVal RoleID As Long) As DataTable
            Dim str As String
            If StyleNo <> "" Then
                'str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                'str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                'str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
                'str &= " where S.StyleNo='" & StyleNo & "'  "

                str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,S.StyleDescription,SD.colorway,SD.ColorRefNo,"
                str &= " SD.SizeRange,SD.Sizes,SD.Price, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
                str &= " where S.StyleNo='" & StyleNo & "' order by SD.colorway,SD.Sizes "
           
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByArticle(ByVal Article As String, ByVal UserID As Long, ByVal RoleID As Long) As DataTable
            Dim str As String
            If RoleID = 1 Or RoleID = 4 Then
                str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID "
                str &= " where SD.Article like '%" & Article & "%' or SD.Article like '" & Article & "%' or SD.Article like '%" & Article & "'"
            Else
                str = " Select SD.StyleDetailID, S.StyleiD,S.StyleNo,SD.Article,SD.ArticleDescription,SD.colorway,"
                str &= " SD.SizeRange,SD.Price,S.isactive, Status='False',PurchaseOrderDetailID=0 from"
                str &= " StyleMaster S join StyleDetail Sd on sd.StyleID=S.styleID"
                str &= " where SD.Article like '%" & Article & "%' or SD.Article like '" & Article & "%' or SD.Article like '%" & Article & "' and S.MarchandID='" & UserID & "'"
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadStyleImage(ByVal ID As String) As Byte()
            Dim str As String
            Dim strConnection As String = ConfigurationSettings.AppSettings("dbConnection")
            Dim SqlConn As New SqlConnection(strConnection)
            str = " select * from styleMaster where  StyleID = " & ID
            Dim sqlcmd As New SqlCommand(str, SqlConn)
            Try
                SqlConn.Open()
                Dim styleImage As Byte() = DirectCast(sqlcmd.ExecuteScalar(), Byte())
                SqlConn.Close()
                Return styleImage
            Catch ex As Exception
            End Try
        End Function
        Public Function RetreiveImg(ByVal id As String) As DataTable
            Dim str As String
            str = " select styleID,sketch from styleMaster where  StyleID =" & id

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeketeMaster(ByVal id As String) As DataTable
            Dim str As String
            str = " Delete from styleMaster where  StyleID =" & id
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DeleteDetail(ByVal id As String) As DataTable
            Dim str As String
            str = " Delete from styleDetail where  StyleID =" & id
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyle() As DataTable
            Dim str As String
            str = "  Select SM.* from StyleMaster SM where StyleID Not in (select styleID from  Purchaseorderdetail) "
            str &= " order by SM.StyleID DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckStyleIfUse(ByVal StyleID As Long) As DataTable
            Dim str As String
            str = "  select * from  Purchaseorderdetail where styleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleRoleWise(ByVal Roleid As String)
            Dim str As String
            If Roleid = 1 Or Roleid = 4 Then
                str = " select * from stylemaster sm JOIN UMUser UM on sm.marchandid=UM.UserId "
                str &= "order by sm.styleid desc"
            Else
                str = " select * from stylemaster sm JOIN UMUser UM on sm.marchandid=UM.UserId "
                str &= " where sm.MarchandID='" & Roleid & "'"
                str &= "order by sm.styleid desc"
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleMasterNDetail(ByVal styleid As String)
            Dim Str As String
            Str = " select * from stylemaster sm join styledetail sd  on sm.styleid=sd.styleid join Customer C on C.customerID=Sm.Buyer where sm.styleid='" & styleid & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleByStyleName(ByVal Style As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If

            Dim Str As String
            'Str = "select S.StyleID,S.StyleName,PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as "
            'Str &= " PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            'Str &= " C.CustomerName as CustomerName,V.VenderName as vendorName "
            'Str &= " ,S.styleNo,Sum(POD.Quantity)as Quantity from Purchaseorder Po  join PurchaseorderDetail POD on POD.POID=PO.POID"

            'Str &= " join StyleMaster S on S.styleID=POD.StyleID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            'Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            'Str &= " join UmUser u on U.UserID=Po.MarchandID"
            'Str &= "  where PONO<>''  "
            'Str &= " and  S.StyleName= '" & Style & "'"

            'If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
            '    Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            'End If
            'Str &= "group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID,S.StyleID,S.StyleName"

            Str = " select S.StyleID,isnull(S.StyleName,'Empty') as 'StyleName',isnull(convert(varchar,PO.POID),'Empty') as 'POID',isnull(PO.PONo,'Empty') as 'PONo',"
            Str &= " isnull(Convert(Varchar,PO.PlacementDate,106),'Emtpy')as "
            Str &= " PlacementDate,isnull(Convert(Varchar,PO.ShipmentDate,106),'Empty')AS ShipmentDate,"
            Str &= " isnull(C.CustomerName,'Empty') as CustomerName,isnull(V.VenderName,'Empty') as vendorName "
            Str &= " ,isnull(S.styleNo,'Empty') as 'styleNo',isnull(convert(varchar,sum(POD.Quantity)),'Empty')as Quantity  from stylemaster S "
            Str &= " left outer join Purchaseorderdetail POD on S.styleID=POD.StyleID"
            Str &= " left outer join  Purchaseorder PO on PO.POID=POD.POID"
            Str &= " left outer Join Customer C on PO.CustomerID=C.CustomerID "
            Str &= " left outer Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " left outer  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " join UmUser u on U.UserID=S.MarchandID"
            Str &= " where year(PO.creationdate)>= '2012' and S.StyleName= '" & Style & "'"
            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= " group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID,S.StyleID,S.StyleName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleByStyleNo2(ByVal Style As String, ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If

            Dim Str As String
            'Str = "select S.StyleID,S.StyleName,PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as "
            'Str &= " PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            'Str &= " C.CustomerName as CustomerName,V.VenderName as vendorName "
            'Str &= " ,S.styleNo,Sum(POD.Quantity)as Quantity from Purchaseorder Po  join PurchaseorderDetail POD on POD.POID=PO.POID"

            'Str &= " join StyleMaster S on S.styleID=POD.StyleID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            'Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            'Str &= " join UmUser u on U.UserID=Po.MarchandID"
            'Str &= "  where PONO<>''  "
            'Str &= " and  S.StyleNo= '" & Style & "'"

            'If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
            '    Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            'End If
            'Str &= "group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID,S.StyleID,S.StyleName"
            Str = " select S.StyleID,isnull(S.StyleName,'Empty') as 'StyleName',isnull(convert(varchar,PO.POID),'Empty') as 'POID',isnull(PO.PONo,'Empty') as 'PONo',"
            Str &= " isnull(Convert(Varchar,PO.PlacementDate,106),'Emtpy')as "
            Str &= " PlacementDate,isnull(Convert(Varchar,PO.ShipmentDate,106),'Empty')AS ShipmentDate,"
            Str &= " isnull(C.CustomerName,'Empty') as CustomerName,isnull(V.VenderName,'Empty') as vendorName "
            Str &= " ,isnull(S.styleNo,'Empty') as 'styleNo',isnull(convert(varchar,sum(POD.Quantity)),'Empty')as Quantity  from stylemaster S "
            Str &= " left outer join Purchaseorderdetail POD on S.styleID=POD.StyleID"
            Str &= " left outer join  Purchaseorder PO on PO.POID=POD.POID"
            Str &= " left outer Join Customer C on PO.CustomerID=C.CustomerID "
            Str &= " left outer Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " left outer  join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " join UmUser u on U.UserID=S.MarchandID"
            Str &= " where year(PO.creationdate)>= '2012' and S.StyleNo= '" & Style & "'"
            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= " group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID,S.StyleID,S.StyleName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleImagesByID(ByVal ID As Long) As Byte()
            Dim Str As String
            Str = "select sketch from stylemaster where styleid=" & ID
            Try
                Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("dbConnection"))
                Dim sqlcmd As New SqlCommand(Str, conn)
                conn.Open()
                Return DirectCast(sqlcmd.ExecuteScalar(), Byte())
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleNameByMarchand(ByVal USerID As String, ByVal RoleID As Long) As DataTable
            If RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                RoleID = 1
            End If

            Dim Str As String
            Str = "select S.StyleID,S.StyleName,PO.POID,PO.PONo,Convert(Varchar,PO.PlacementDate,106)as "
            Str &= " PlacementDate,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,"
            Str &= " C.CustomerName as CustomerName,V.VenderName as vendorName "
            Str &= " ,S.styleNo,Sum(POD.Quantity)as Quantity from Purchaseorder Po  join PurchaseorderDetail POD on POD.POID=PO.POID"

            Str &= " join StyleMaster S on S.styleID=POD.StyleID Join Customer C on PO.CustomerID=C.CustomerID Join Vender V on V.VenderLibraryID=PO.SupplierID "
            Str &= " join StyleDetail SD on SD.StyleDetailID=POD.StyleDetailID"
            Str &= " join UmUser u on U.UserID=Po.MarchandID"
            Str &= "  where PONO<>''  "
            'Str &= " and  S.StyleName= '" & Style & "'"
            If Not RoleID = 1 Or RoleID = 4 Or RoleID = 12 Then
                Str &= " and   U.UserID in(Select UserID From UMUser where UserID='" & USerID & "')"
            End If
            Str &= " group by Po.PONO,StyleNo,Po.PlacementDate,Po.ShipmentDate,C.CustomerName,Po.TimeSpame ,C.CustomerName,V.VenderName,Po.POID,S.StyleID,S.StyleName"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleByUser(ByVal userid As String, ByVal roleid As String) As DataTable
            Dim Str As String
            Str = " select * from stylemaster SM JOIN Customer C "
            Str &= " on C.customerid = SM.buyer"
            Str &= " JOIN UMUser UM on UM.userid=SM.Marchandid"
            If Not roleid = 1 Or roleid = 4 Or roleid = 12 Then
                Str &= " where UM.Userid = '" & userid & "'"
            End If
            Str &= " order by SM.CreationDate desc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try

        End Function
        Public Function CheckStyle11(ByVal StyleNo As String) As DataTable
            Dim str As String
            str = "  Select * from StyleMaster  where StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMaster(ByVal StyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from StyleMaster  where StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProduct(ByVal StyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from StyleProductInformation  where StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductNew(ByVal StyleID As Long) As DataTable
            Dim str As String
            'str = "  Select *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup from StyleProductInformation M join FabricType FT on FT.FabricTypeID=M.FabricTypeID join ProductType FF on FF.TypeID=M.FabFinishID join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId where M.StyleID=" & StyleID
            str = " Select isnull(CMP.CompositionName,'') as LiningComposition,"
            str &= " isnull(LT.LiningType,'') as LiningType,isnull(LT.LiningTypeID,0) as LiningTypeID,"
            str &= " *,FF.ProductType as FabFinish,pc.ProductConsumerName as ProductConsumerGroup "
            str &= " from StyleProductInformation M "
            str &= " join FabricType FT on FT.FabricTypeID=M.FabricTypeID "
            str &= " join ProductType FF on FF.TypeID=M.FabFinishID "
            str &= " join ProductConsumer pc on pc.ProductConsumerId=M.ProductConsumerId"
            str &= " LEFT join LiningType LT ON LT.LiningTypeID=M.LiningTypeID"
            str &= " left  JOIN Composition CMP ON CMP.CompositionID=M.LiningCompId"
            str &= "  where M.StyleID = '" & StyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetInquiryProduct(ByVal InquiryStyleID As Long) As DataTable
            Dim str As String
            str = "  Select '0' as SproductID, isnull(StylingDetail,'') as StylingDetail,ISNULL(TBC.ConCompostionId,M.CompositionId) AS Compid,"
            str &= " ISNULL(TBC.ConFConstruction,M.FabicCons) AS FConstruction,"
            str &= " ISNULL(TBC.ConFwt,M.Fabicwt) AS FWT,"
            str &= " ISNULL(TBC.Price,0) AS Price,ISNULL(TBC.SUPPLIERID,0) AS SUPPLIERID"
            str &= " ,ISNULL(TBC.Color,'') AS Color,ISNULL(TBC.Qty,0) AS Qty,"
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
            str &= " JOIN TblInquiryConfirmed TBC ON TBC.InquiryStyleID=m.InquiryStyleID AND TBC.InquirySproductID=M.InquirySproductID"
            str &= "  where M.InquiryStyleID = '" & InquiryStyleID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColor(ByVal StyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from StyleDetail  where StyleID='" & StyleID & "'  order by colorway,Sizes"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccess(ByVal StyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from StyleAccessories s "
            str &= " join StyleAccessoriesList sl on s.AccessoriesID=sl.AccessoriesID"
            str &= "  where s.StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GETJV(ByVal VoucherNo As String)
            Dim Str As String
            Str = " Select VoucherNo as Name from tblJVMst where VoucherNo like '%" & VoucherNo & "%' order by tblJVMstID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETCV(ByVal VoucherNo As String)
            Dim Str As String
            Str = " Select VoucherNo as Name from tblCashMst where VoucherNo like '%" & VoucherNo & "%' order by tblCashMstID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETCostCenter(ByVal VoucherNo As String)
            Dim Str As String
            Str = " Select Cost  as Name from CostCenter  where Cost like '%" & VoucherNo & "%' order by Cost DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function GETCompositionFromFDB(ByVal Compositionname As String)
            Dim Str As String
            Str = " Select Compositionname  as Name from Composition  where Compositionname like '%" & Compositionname & "%' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETFinishWidthFromFDB(ByVal FinishName As String)
            Dim Str As String
            Str = " Select FinishName  as Name from DPFinish  where FinishName like '%" & FinishName & "%'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace