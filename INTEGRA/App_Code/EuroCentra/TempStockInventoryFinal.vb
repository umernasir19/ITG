Imports System.Data
Namespace EuroCentra
    Public Class TempStockInventoryFinal
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempStockInventoryFinal"
            m_strPrimaryFieldName = "TempTableStockId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempTableStockId As Long
        Private m_dtEntryDate As Date
        Private m_strInward As String
        Private m_strItemName As String
        Private m_lSupplierID As Long
        Private m_dcQuantity As Decimal
        Private m_dcUnitRate As Decimal
        Private m_dcUnitSold As Decimal


        Public Property TempTableStockId() As Long
            Get
                TempTableStockId = m_lTempTableStockId
            End Get
            Set(ByVal Value As Long)
                m_lTempTableStockId = Value
            End Set
        End Property

        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate

            End Get
            Set(ByVal value As Date)
                m_dtEntryDate = value
            End Set
        End Property
        Public Property Inward() As String
            Get
                Inward = m_strInward
            End Get
            Set(ByVal value As String)
                m_strInward = value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal value As String)
                m_strItemName = value
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
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dcQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dcQuantity = value
            End Set
        End Property
        Public Property UnitRate() As Decimal
            Get
                UnitRate = m_dcUnitRate
            End Get
            Set(ByVal value As Decimal)
                m_dcUnitRate = value
            End Set
        End Property
        Public Property UnitSold() As Decimal
            Get
                UnitSold = m_dcUnitSold
            End Get
            Set(ByVal value As Decimal)
                m_dcUnitSold = value
            End Set
        End Property

        Public Function SaveStockInventory()

            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempTablePurchaseRegister()
            Dim str As String
            str = " Truncate Table TempPurchaseRegisterReport "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempTablePurchaseRegisterForProcess()
            Dim str As String
            str = " Truncate Table TempPurchaseRegisterReportForProcess "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempInventoryNewForFinalInventory()
            Dim str As String
            str = " Truncate Table TempitemInventory "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempInventoryNewForFinalInventoryForAstore()
            Dim str As String
            str = " Truncate Table TempitemInventoryAstore "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempInventoryNew()
            Dim str As String
            str = " Truncate Table TempStockInventory "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNew2ForLocationForNew(ByVal OpeningBalance As Decimal, ByVal LocationId As Long) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempitemInventoryFinal TBM "
            str &= " Where TBM.LocationId='" & LocationId & "'"
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetLedgerForPrintNew2ForLocation(ByVal OpeningBalance As Decimal, ByVal LocationId As Long) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempStockInventoryFinal TBM "
            str &= " Where TBM.LocationId='" & LocationId & "'"
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNew2ForItemInventory(ByVal OpeningBalance As Decimal) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempitemInventoryFinal TBM "
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNew2(ByVal OpeningBalance As Decimal) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempStockInventoryFinal TBM "
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNewForLocationForNew(ByVal OpeningBalance As Decimal, ByVal Startdate As String, ByVal EndDate As String, ByVal LocationId As Long) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempitemInventoryFinal TBM "
            str &= " where convert(varchar,TBM.EntryDate,103) between '" & Startdate & "' and  '" & EndDate & "' and TBM.LocationId='" & LocationId & "' "
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNewForLocation(ByVal OpeningBalance As Decimal, ByVal Startdate As String, ByVal EndDate As String, ByVal LocationId As Long) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempStockInventoryFinal TBM "
            str &= " where convert(varchar,TBM.EntryDate,103) between '" & Startdate & "' and  '" & EndDate & "' and TBM.LocationId='" & LocationId & "' "
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNewForItemInventory(ByVal OpeningBalance As Decimal, ByVal Startdate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempitemInventoryFinal TBM "
            str &= " where convert(varchar,TBM.EntryDate,103) between '" & Startdate & "' and  '" & EndDate & "' "
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLedgerForPrintNew(ByVal OpeningBalance As Decimal, ByVal Startdate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = " select  TBM.*,convert(varchar,TBM.EntryDate,103) as VoucherDatee,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "') + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty) AS Balance,"
            str &= " ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= " WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + ('" & OpeningBalance & "'))) as PreviousBalance "
            str &= " from TempStockInventoryFinal TBM "
            str &= " where convert(varchar,TBM.EntryDate,103) between '" & Startdate & "' and  '" & EndDate & "' "
            str &= " order By TBM.EntryDate ASC, TBM.Type desc"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempItemInventoryFinal()
            Dim str As String
            str = " Truncate Table TempitemInventoryFinal "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempItemInventoryFinalAstore()
            Dim str As String
            str = " Truncate Table TempitemInventoryFinalAstore "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTempInventoryFinal()
            Dim str As String
            str = " Truncate Table TempStockInventoryFinal "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckInsertdataForItemInventory()
            Dim str As String
            str = " Select * from TempitemInventoryFinal"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckInsertdata()
            Dim str As String
            str = " Select * from TempStockInventoryFinal"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETDatafrrrr(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String

            'str = "  SELECT SUM((ReceiveQty -IssueQty )*UnitRate) AS Amount FROM TempitemInventoryFinal where convert(varchar,EntryDate,103) between '" & StartDate & "' and  '" & EndDate & "'"

            str = "  select ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempStockInventoryFinal a "
            str &= "  WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + 0 + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty)* unitrate AS Balance  "
            str &= " from TempStockInventoryFinal TBM"
            str &= " where convert(varchar,EntryDate,103) between '" & StartDate & "' and  '" & EndDate & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETDatafrrrrForAstore(ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            ' str = "  SELECT SUM((ReceiveQty -IssueQty )*UnitRate) AS Amount FROM TempitemInventoryFinalAstore "

            str = "  select ((ISNULL((SELECT sum(a.ReceiveQty) - sum(a.IssueQty) FROM TempitemInventoryFinalAstore a "
            str &= "  WHERE a.TempTableStockId<TBM.TempTableStockId ),0) + 0 + "
            str &= " TBM.ReceiveQty)- TBM.IssueQty)* unitrate AS Balance  "
            str &= " from TempitemInventoryFinalAstore TBM"
            str &= " where convert(varchar,EntryDate,103) between '" & StartDate & "' and  '" & EndDate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempLedgerIntoTempFinalForItemInventory()
            Dim str As String
            str = " insert into TempitemInventoryFinal select CreationDate,EntryDate,DCNo,CustomerId,IMSItemId,IssueQty,ReceiveQty,UnitRate,"
            str &= " IMSSupplierId,Type,RatioName,ItemName,Userid,LocationId,Location from TempitemInventory order by EntryDate asc, Type desc"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempLedgerIntoTempFinalForItemInventoryForAstore()
            Dim str As String
            str = " insert into TempitemInventoryFinalAstore select CreationDate,EntryDate,DCNo,CustomerId,IMSItemId,IssueQty,ReceiveQty,UnitRate,"
            str &= " IMSSupplierId,Type,RatioName,ItemName,Userid,LocationId,Location from TempitemInventoryAstore order by EntryDate asc, Type desc"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempLedgerIntoTempFinal()
            Dim str As String
            str = " insert into TempStockInventoryFinal select CreationDate,EntryDate,DCNo,CustomerId,IMSItemId,IssueQty,ReceiveQty,UnitRate,"
            str &= " IMSSupplierId,Type,RatioName,ItemName,Userid,LocationId,Location from TempStockInventory order by EntryDate asc, Type desc"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryOpen(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select Imt.CreationDate as CreationDate,'07/01/2015' as EntryDate"
            str &= " ,'Opening'as DCNo, '0' as CustomerId, Imt.IMSItemId as IMSItemId,'0' as IssueQty"
            str &= " ,OpeningQuantity as ReceiveQty,Imt.UnitRATE,0 AS IMSSUPPLIERid,'Open'as Type,"
            str &= " '' as Rationame,Imt.ItemName as ItemName,'0' as userid"
            str &= " from IMSItem Imt "
            str &= " where IMSItemId='" & ITEMID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForAny(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCase(ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPorder=1 and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempProcessRecv(ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ProcessItemNameID,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "  '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location"
            str &= " from POProcessRecvMaster IMI  "
            str &= " join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= "  join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlId "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ProcessItemNameID "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join ProcessOrderMst PM on PM.ProcessOrderMstID= IMI.ProcessOrderMstID"
            str &= " where  IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCaseFORCategoryWise(ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPorder=1 and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCaseForAuditor(ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCaseForAccForAstore(ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventoryAstore "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPorder=0 and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAllCaseForAcc(ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPorder=0 and PM.GStoreStatus=0 and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAuditor(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAcc(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPORder=0 and IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForAccForCATEGORYWISE(ByVal IMSItemCategoryID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPORder=0 and PM.GStoreStatus=0 and IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventory(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPORder=1 and IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForItemInventoryForCategoryWise(ByVal IMSItemCategoryID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "
            str &= " where PM.FabricPORder=1 and IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempProcessRecvAnyCase(ByVal IMSItemCategoryID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= " select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= "  SupplierID  as IMSSupplierId, Type='Received',"
            str &= "  '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location"
            str &= "  from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlId "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ProcessItemNameID "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join ProcessOrderMst PM on PM.ProcessOrderMstID= IMI.ProcessOrderMstID"
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWise(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForProcess(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            'str = "   insert into TempStockInventory "
            'str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            'str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            'str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.porate)  as UnitRate,"
            'str &= " SupplierID  as IMSSupplierId, Type='Received',"
            'str &= "   '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            'str &= " from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            'str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlID "
            'str &= "  join IMSItem IM on IM.IMSItemId= pod.ItemId "
            'str &= " join Location L on L.LocationId= IMI.LocationId "
            'str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "


            ' atif code 27 Dec 2017

            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, pissDtl.IssueQty as as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.porate)  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "   '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= " from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlID "
            str &= "  join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join processIssueDetail pissDtl on pissDtl.ItemID  = IM.IMSItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForLocationWiseForProcessPorcesssss(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
          

            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, '0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.porate)  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "   '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location AS Location "
            str &= " from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlID "
            str &= "  join IMSItem IM on IM.IMSItemId= pod.ProcessItemNameId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryReceiveForAllCode()
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster po on po.POID =imi.POID "
            str &= "  where po.FabricPOrder =1  "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryReceiveForAllCodeForAuditor()
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster po on po.POID =imi.POID "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryReceiveForAllCodeForAcc()
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster po on po.POID =imi.POID "
            str &= "  where po.FabricPOrder =0  "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryReceiveForAuditor(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster PO on PO.POID =IMI.POID "
            str &= " where  IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryReceiveForAcc(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster PO on PO.POID =IMI.POID "
            str &= " where po.FabricPOrder=0 and IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryReceive(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempitemInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster PO on PO.POID =IMI.POID "
            str &= " where po.FabricPOrder=1 and IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        
        Public Function InsertTempStockInventoryReceive(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= "  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,pod.Rate * pod.ExchangeRate  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "     '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PoDetailId =imd.PODetailID "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemId "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForProcessNewwwPROCESS(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, '0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.PORate)  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "    '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlId "
            str &= " join IMSItem IM on IM.IMSItemId= pod.processItemNameID "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForProcessNewww(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, '0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.PORate)  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "    '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from PORecvMaster IMI  join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID"
            str &= " join PODetail pod on pod.PODetailId =imd.PODetailId "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemID "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryReceiveForProcess(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, '0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.PORate)  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "    '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlId "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ItemID "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "

            ' atif code 27 Dec 2017

            'str = "   insert into TempStockInventory "
            'str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            'str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, pissDtl.IssueQty as IssueQty,"
            'str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.PORate)  as UnitRate,"
            'str &= " SupplierID  as IMSSupplierId, Type='Received',"
            'str &= "    '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            'str &= "  from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            'str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlId "
            'str &= " join IMSItem IM on IM.IMSItemId= pod.ProcessItemCodeID "
            'str &= " join processIssueDetail pissDtl on pissDtl.ItemID  = IM.IMSItemId "
            'str &= " join Location L on L.LocationId= IMI.LocationId "
            'str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewFrom(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,'10' as LocationId   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCaseForACC()
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMD.POID "
            str &= " Where PM.FabricPOrder=0 and PM.GStoreStatus=0"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCaseForACCForAstore()
            Dim str As String
            str = "  insert into TempitemInventoryAstore select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMD.POID "
            str &= " Where PM.FabricPOrder=0 "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCaseForAuditor()
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMI.POID "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAllCase()
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster PM on PM.POID= IMD.POID "
            str &= " Where PM.FabricPOrder=1 "

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempProcessIssue()
            Dim str As String

            str = "  insert into TempitemInventory "
            str &= " select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= " '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   "
            str &= "  from processIssueMst IMI "
            str &= "  join processIssueDetail IMD on IMi.processIssueID  =IMD.processIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join ProcessOrderMst PM on PM.ProcessOrderMstID= IMI.ProcessOrderMstID "
            str &= "  Where PM.FabricPOrder = 1"

            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAuditor(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster pm on pm.POID= IMI.POID "
            str &= " where IM.IMSItemId='" & ITEMID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAcc(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster pm on pm.POID= IMI.POID "
            str &= " where pm.FabricPorder=0 and IM.IMSItemId='" & ITEMID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForAccForCategorywise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster pm on pm.POID= IMD.POID "
            str &= " where pm.FabricPorder=0 and PM.GStoreStatus=0 and IM.IMSItemCategoryID='" & IMSItemCategoryID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventory(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster pm on pm.POID= IMI.POID "
            str &= " where pm.FabricPorder=1 and IM.IMSItemId='" & ITEMID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForitemInventoryForCategoryWise(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POMaster pm on pm.POID= IMD.POID "
            str &= " where pm.FabricPorder=1 and IM.IMSItemCategoryID='" & IMSItemCategoryID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTemp11(ByVal IMSItemCategoryID As Long)
            Dim str As String
            str = "  insert into TempitemInventory "
            str &= " select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= " '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= " '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location  "
            str &= "   from processIssueMst IMI "
            str &= "  join processIssueDetail IMD on IMI.processIssueID =IMD.processIssueID "
            str &= "   join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= "   join Location L on L.LocationId= IMI.LocationId "
            str &= "  join ProcessOrderMst pm on pm.ProcessOrderMstID= IMI.ProcessOrderMstID"
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWise(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForProcessForProcess(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,(IMD.Rate) as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from processIssueMst IMI "
            str &= " join processIssueDetail IMD on IMI.processIssueID =IMD.processIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewForLocationWiseForProcess(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNew(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,IMD.IssueQty as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNew(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempProcessIssueAllCase(ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory "
            str &= " select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= " '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= "  IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location  "
            str &= " from processIssueMst IMI "
            str &= " join processIssueDetail IMD on IMI.processIssueID =IMD.processIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join ProcessOrderMst PM on PM.ProcessOrderMstID= IMI.ProcessOrderMstID "
            str &= " where   IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForAllCase(ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POmaster PM on PM.POID= IMD.POID "
            str &= " where  PM.FabricPorder=1 and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForAllCaseForAcc(ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POmaster PM on PM.POID= IMD.POID "
            str &= " where  PM.FabricPorder=0 and PM.GStoreStatus=0 and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForAllCaseForAuditor(ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " join POmaster PM on PM.POID= IMI.POID "
            str &= " where IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventory(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTemp2222(ByVal IMSItemCategoryID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory"
            str &= " select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= " '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= " IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= "  IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from processIssueMst "
            str &= " IMI  join processIssueDetail IMD on IMI.processIssueID =IMD.processIssueID "
            str &= "   join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= "  join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWiseForItemInventoryForCategoryWise(ByVal IMSItemCategoryID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWiseForprocess(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,(IMD.Rate) as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from processIssueMst IMI "
            str &= " join processIssueDetail IMD on IMI.processIssueId =IMD.processIssueId "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToNewNewForLocationWise(ByVal ITEMID As Long, ByVal LocationId As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,'0' as IssueQty,"
            str &= "  IMD.IssueQty as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as Location   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMI.LocationId='" & LocationId & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryIssueNewToForAllCase()
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster po on po.POID =imi.POID "
            str &= "  where po.FabricPOrder =1  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryIssueNewToForAllCaseForAuditor()
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster po on po.POID =imi.POID "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryIssueNewToForAllCaseForAcc()
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster po on po.POID =imi.POID "
            str &= "  where po.FabricPOrder =0  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryIssueNewToForAuditor(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster PO on PO.POID =IMI.POID "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryIssueNewToForAcc(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster PO on PO.POID =IMI.POID "
            str &= " where  po.FabricPOrder =0 and IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempItemInventoryIssueNewTo(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= "  join POMaster PO on PO.POID =IMI.POID "
            str &= " where  po.FabricPOrder =1 and IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToReturn(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= " select IMI.ReturnDate,IMI.ReturnDate, ''  as DCNo, "
            str &= " '0' CustomerId, IMI.ItemId,(IMI.ReturnQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,PD.Rate * PD.ExchangeRate as UnitRate, '0' as IMSSupplierId, Type='Return', '' as RationName,"
            str &= "   '' as ItemName ,'0' as Userid,'0' as LocationId,'' as  Location  from POReturn IMI "
            str &= " join PODetail PD on PD.POID =IMI.POID AND PD.ItemId =IMI.ItemID "
            str &= " where IMI.ItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToReturnNew(ByVal ITEMID As Long)
            Dim str As String
            str = "   insert into TempStockInventory "
            str &= " select IMI.ReturnDate,IMI.ReturnDate, ''  as DCNo, "
            str &= " '0' CustomerId, PD.ItemId,(IMI.ReturnQty) as IssueQty,"
            str &= " '0' as ReceivedQty,PD.Rate * PD.ExchangeRate as UnitRate, '0' as IMSSupplierId, Type='Return', '' as RationName,"
            str &= "  '' as ItemName ,'0' as Userid,'0' as LocationId,'' as  Location  from POReturn IMI "
            str &= " join PODetail PD on PD.POID =IMI.POID and pd.PoDetailId =imi.PoDetailId"
            str &= " join PORecvMaster PRM on PRM.PORecvMasterID =IMI.PORecvMasterID "
            str &= " where IMI.ItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewToProcesses(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,(IMD.Rate) as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from processIssueMst IMI "
            str &= " join processIssueDetail IMD on IMI.processIssueID =IMD.processIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssueNewTo(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty) as IssueQty,"
            str &= "  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempProcessGodownRecv(ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory "
            str &= " select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= " '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= " Imd.QtyIssue as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   "
            str &= " from IMSGodownIssueForProcess IMI "
            str &= " join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID"
            str &= " where  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForAllCase(ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForAllCaseForAstore(ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventoryAstore select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroy(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' and  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForInventroyForCategoryWise(ByVal IMSItemCategoryID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTemp3333(ByVal IMSItemCategoryID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory "
            str &= " select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "   '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= " Imd.QtyIssue as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   "
            str &= " from IMSGodownIssueForProcess IMI "
            str &= " join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID"
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWise(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' and  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForprocess(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempStockInventory "
            str &= " select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= " '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= " Imd.QtyIssue as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', "
            str &= "    '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location  "
            str &= " from IMSGodownIssueForProcess IMI "
            str &= " join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' and  IMD.ToLocationID= '" & LocationID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecv(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForOpening(ByVal ItemId As Long, ByVal Startdate As String) As DataTable
            Dim str As String
            str = " select isnull(SUM(dtl.RecvQuantity),0) as RecvQuantity from PORecvMaster Mst"
            str &= " join PORecvDetail Dtl on Dtl.PORecvMasterID =Mst.PORecvMasterID"
            str &= " join PODetail POD on POD.PoDetailId =DTL.PODetailID "
            str &= " where   convert(varchar,Mst.POrecvDate, 103) < '" & Startdate & "' and POD.ItemId= '" & ItemId & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForOpeningTwo(ByVal ItemId As Long, ByVal Startdate As String) As DataTable
            Dim str As String
            str = " select isnull(SUM(dtl.IssueQty),0) as IssueQuantity from IssueMst Mst"
            str &= "  join IssueDetail Dtl on Dtl.IssueID =Mst.IssueID"
            str &= " where  Convert(varchar,Mst.CreationDate, 103) < '" & Startdate & "' and Dtl.ItemId= '" & ItemId & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForOpeningThree(ByVal ItemId As Long, ByVal Startdate As String) As DataTable
            Dim str As String
            str = " select isnull(SUM(dtl.QtyIssue),0) as RecvQuantity from IMSGodownIssue Mst"
            str &= " join IMSGodownIssueDetail Dtl on Dtl.GodownIssueID =Mst.GodownIssueID"
            str &= "  join Location L on L.LocationID=Dtl.ToLocationID"
            str &= " where  Convert(varchar, Mst.EntryDate, 103)  < '" & Startdate & "' and Dtl.IMSItemId= '" & ItemId & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForOpeningFour(ByVal ItemId As Long, ByVal Startdate As String) As DataTable
            Dim str As String
            str = " select isnull(SUM(dtl.QtyIssue),0) as IssueQuantity from IMSGodownIssue Mst"
            str &= " join IMSGodownIssueDetail Dtl on Dtl.GodownIssueID =Mst.GodownIssueID"
            str &= "  join Location L on L.LocationID=Dtl.FromLocationID"
            str &= " where  Convert(varchar, Mst.EntryDate, 103)  < '" & Startdate & "' and Dtl.IMSItemId= '" & ItemId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempProcessGodpwnIssue(ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "'0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= " 0 as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location "
            str &= " from IMSGodownIssueForProcess IMI "
            str &= "  join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= "join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= "join Location L on L.LocationID=IMD.ToLocationID "
            str &= " where  IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForAllCase(ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "  0 as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where  IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForAllCaseforASTORE(ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventoryAstore select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "  0 as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where  IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventory(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "  0 as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssueForlocationWiseForItemInventoryForCategorywise(ByVal IMSItemCategoryID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "  0 as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTemp44444(ByVal IMSItemCategoryID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempitemInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= " 0 as ReceivedQty,'IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  "
            str &= " from IMSGodownIssueForProcess IMI "
            str &= " join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID"
            str &= " where IM.IMSItemCategoryID='" & IMSItemCategoryID & "' and IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssueForlocationWise(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "  0 as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssueForlocationWiseForProcess(ByVal ITEMID As Long, ByVal LocationID As Long)
            Dim str As String
            str = "     insert into TempStockInventory "
            str &= "  select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "   0 as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' "
            str &= "   as RationName,"
            str &= "   IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as"
            str &= "    Location  from IMSGodownIssueForProcess IMI "
            str &= "  join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= "   join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= "  join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' and IMD.FromLocationID='" & LocationID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForIssue(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID, Imd.QtyIssue as IssueQty,"
            str &= "  0 as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issue Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.FromLocationID AS  LocationID,L.Location as Location  from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.ToLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryIssue(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.ItemId,(IMD.IssueQty  - IMD.IssueReturn ) as IssueQty,"
            str &= "  '0' as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid   from IssueMst IMI "
            str &= " join IssueDetail IMD on IMI.IssueID =IMD.IssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemId  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetReportdataIssue(ByVal CheckDate As Long, ByVal ItemId As Long, ByVal JobOrderId As Long, ByVal IssueId As Long, ByVal LocationID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim Str As String
            Str = " truncate table TempTableStoreIssueReportAstore"
            MyBase.ExecuteNonQuery(Str)
            If CheckDate = 0 And ItemId = 0 And JobOrderId = 0 And IssueId = 0 And LocationID = 0 Then
                Str = " insert into TempTableStoreIssueReportAstore "
                Str &= "     select prm.CreationDate as IssueDate,(ISNULL((prd.IssueQty),0) * ISNULL((prd.Rate),0))as Amount"
                Str &= " ,ISNULL((prd.IssueQty),0)as IssueQty, ISNULL((prd.Rate),0)as RecvRate,im.ItemCodee,prm.ManualChallanNo"
                Str &= " ,im.ItemName  ,DeptDatabaseName  AS  Location,prd.SrNoo from IssueMst prm"
                Str &= " join IssueDetail prd on prd .IssueID =prm.IssueID "
                Str &= " join IMSItem im on im.IMSItemID=prd.ItemId "
                Str &= " join IMSItemClass imc on imc.IMSItemClassID =im.IMSItemClassID "
                Str &= " join IMSDepartmentDataBase  L on L.DeptDatabaseId =prd.DeptDatabaseID"
                Str &= " Where imc.StoreTypeID =2 "
                Str &= " group by prm.CreationDate,im.IMSItemID,im.ItemCodee ,prm.ManualChallanNo ,im.ItemName ,l.DeptDatabaseName ,L.DeptAbbrivation,prd.IssueQty,prd.Rate,prd.SrNoo"
                Str &= " order by  MONTH(prm.CreationDate), DAY(prm.CreationDate),YEAR(prm.CreationDate) asc"
            Else
                Str = " insert into TempTableStoreIssueReportAstore "
                Str &= "     select prm.CreationDate as IssueDate,(ISNULL((prd.IssueQty),0) * ISNULL((prd.Rate),0))as Amount"
                Str &= " ,ISNULL((prd.IssueQty),0)as IssueQty, ISNULL((prd.Rate),0)as RecvRate,im.ItemCodee,prm.ManualChallanNo"
                Str &= " ,im.ItemName  ,DeptDatabaseName  AS  Location,prd.SrNoo from IssueMst prm"
                Str &= " join IssueDetail prd on prd .IssueID =prm.IssueID "
                Str &= " join IMSItem im on im.IMSItemID=prd.ItemId "
                Str &= " join IMSItemClass imc on imc.IMSItemClassID =im.IMSItemClassID "
                Str &= " join IMSDepartmentDataBase  L on L.DeptDatabaseId =prd.DeptDatabaseID"
                If CheckDate <> 0 Then
                    Str &= " where prm.CreationDate  between '" & StartDate & "' and '" & EndDate & "' "
                Else
                    Str &= " where prm.CreationDate  between '01/01/2000' and '01/01/2090' "
                End If
                If ItemId <> 0 Then
                    Str &= " and prd.ItemId ='" & ItemId & "' "
                End If
                If JobOrderId <> 0 Then
                    Str &= " and prd.JobOrderID ='" & JobOrderId & "' "
                End If
                If IssueId <> 0 Then
                    Str &= " and prm.IssueID ='" & IssueId & "' "
                End If
                If LocationID <> 0 Then
                    Str &= " and prd.DeptDatabaseID  ='" & LocationID & "' "
                End If
                Str &= " and imc.StoreTypeID =2 "
                Str &= " group by prm.CreationDate,im.IMSItemID,im.ItemCodee ,prm.ManualChallanNo ,im.ItemName ,l.DeptDatabaseName ,L.DeptAbbrivation,prd.IssueQty,prd.Rate,prd.SrNoo"
                Str &= " order by  MONTH(prm.CreationDate), DAY(prm.CreationDate),YEAR(prm.CreationDate) asc"
            End If
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetReportdataIssueNew(ByVal CheckDate As Long, ByVal JobOrderId As Long, ByVal IssueId As Long, ByVal LocationID As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim Str As String
            Str = " truncate table TempTableStoreIssueReportAstore"
            MyBase.ExecuteNonQuery(Str)
            If CheckDate = 0 And JobOrderId = 0 And IssueId = 0 And LocationID = 0 Then
                Str = " insert into TempTableStoreIssueReportAstore "
                Str &= "     select prm.CreationDate as IssueDate,(ISNULL((prd.IssueQty),0) * ISNULL((prd.Rate),0))as Amount"
                Str &= " ,ISNULL((prd.IssueQty),0)as IssueQty, ISNULL((prd.Rate),0)as RecvRate,im.ItemCodee,prm.ManualChallanNo"
                Str &= " ,im.ItemName  ,DeptDatabaseName  AS  Location,prd.SrNoo from IssueMst prm"
                Str &= " join IssueDetail prd on prd .IssueID =prm.IssueID "
                Str &= " join IMSItem im on im.IMSItemID=prd.ItemId "
                Str &= " join IMSItemClass imc on imc.IMSItemClassID =im.IMSItemClassID "
                Str &= " join IMSDepartmentDataBase  L on L.DeptDatabaseId =prd.DeptDatabaseID"
                Str &= " group by prm.CreationDate,im.IMSItemID,im.ItemCodee ,prm.ManualChallanNo ,im.ItemName ,l.DeptDatabaseName ,L.DeptAbbrivation,prd.IssueQty,prd.Rate,prd.SrNoo"
                Str &= " order by  MONTH(prm.CreationDate), DAY(prm.CreationDate),YEAR(prm.CreationDate) asc"
            Else
                Str = " insert into TempTableStoreIssueReportAstore "
                Str &= "     select prm.CreationDate as IssueDate,(ISNULL((prd.IssueQty),0) * ISNULL((prd.Rate),0))as Amount"
                Str &= " ,ISNULL((prd.IssueQty),0)as IssueQty, ISNULL((prd.Rate),0)as RecvRate,im.ItemCodee,prm.ManualChallanNo"
                Str &= " ,im.ItemName  ,DeptDatabaseName  AS  Location,prd.SrNoo from IssueMst prm"
                Str &= " join IssueDetail prd on prd .IssueID =prm.IssueID "
                Str &= " join IMSItem im on im.IMSItemID=prd.ItemId "
                Str &= " join IMSItemClass imc on imc.IMSItemClassID =im.IMSItemClassID "
                Str &= " join IMSDepartmentDataBase  L on L.DeptDatabaseId =prd.DeptDatabaseID"
                If CheckDate <> 0 Then
                    Str &= " where prm.CreationDate  between '" & StartDate & "' and '" & EndDate & "' "
                Else
                    Str &= " where prm.CreationDate  between '01/01/2000' and '01/01/2090' "
                End If
                If JobOrderId <> 0 Then
                    Str &= " and prd.JobOrderID ='" & JobOrderId & "' "
                End If
                If IssueId <> 0 Then
                    Str &= " and prm.IssueID ='" & IssueId & "' "
                End If
                If LocationID <> 0 Then
                    Str &= " and prd.DeptDatabaseID  ='" & LocationID & "' "
                End If
                Str &= " and imc.StoreTypeID =2 "
                Str &= " group by prm.CreationDate,im.IMSItemID,im.ItemCodee ,prm.ManualChallanNo ,im.ItemName ,l.DeptDatabaseName ,L.DeptAbbrivation,prd.IssueQty,prd.Rate,prd.SrNoo"
                Str &= " order by  MONTH(prm.CreationDate), DAY(prm.CreationDate),YEAR(prm.CreationDate) asc"
            End If
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetReportdataIssueGodown(ByVal CheckDate As Long, ByVal ItemId As Long, ByVal StartDate As String, ByVal EndDate As String)
            Dim Str As String
            If CheckDate = 0 And ItemId = 0 Then
                Str = " insert into TempTableStoreIssueReportAstore "
                Str &= "     select prm.CreationDate as IssueDate"
                Str &= " ,'0' as Amount"
                Str &= " ,ISNULL((prd.QtyIssue),0)as IssueQty"
                Str &= " ,'0' AS RecvRate"
                Str &= " ,im.ItemCodee,prm.ChallanNo ,IM.ItemName ,'main store 1' AS Location"
                Str &= " ,ISNULL(jo.SRNO ,'') AS SrNoo"
                Str &= "  from IMSGodownIssue  prm"
                Str &= " join IMSGodownIssueDetail prd on prd .GodownIssueID  =prm.GodownIssueID "
                Str &= " join IMSItem im on im.IMSItemID=prd.IMSItemID "
                Str &= " join IMSItemClass imc on imc.IMSItemClassID =im.IMSItemClassID "
                Str &= " LEFT JOIN JobOrderdatabase JO on jo.Joborderid =prm.JobOrderID "
            Else
                Str = " insert into TempTableStoreIssueReportAstore "
                Str &= "     select prm.CreationDate as IssueDate"
                Str &= " ,'0' as Amount"
                Str &= " ,ISNULL((prd.QtyIssue),0)as IssueQty"
                Str &= " ,'0' AS RecvRate"
                Str &= " ,im.ItemCodee,prm.ChallanNo ,IM.ItemName ,'main store 1' AS Location"
                Str &= " ,ISNULL(jo.SRNO ,'') AS SrNoo"
                Str &= "  from IMSGodownIssue  prm"
                Str &= " join IMSGodownIssueDetail prd on prd .GodownIssueID  =prm.GodownIssueID "
                Str &= " join IMSItem im on im.IMSItemID=prd.IMSItemID "
                Str &= " join IMSItemClass imc on imc.IMSItemClassID =im.IMSItemClassID "
                Str &= " LEFT JOIN JobOrderdatabase JO on jo.Joborderid =prm.JobOrderID "
                If CheckDate <> 0 Then
                    Str &= " where imc.StoreTypeID =2 and prm.CreationDate  between '" & StartDate & "' and '" & EndDate & "' "
                Else
                    Str &= " where imc.StoreTypeID =2 and prm.CreationDate  between '01/01/2000' and '01/01/2090' "
                End If
                If ItemId <> 0 Then
                    Str &= " and IM.IMSItemID  ='" & ItemId & "' "
                End If
            End If
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GETReportData()
            Dim str As String
            str = "select *  from TempStockInventory where type in('Open','Received') order by entrydate asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETRecvData()
            Dim str As String
            str = "select *, Isnull(ReceiveQty,0) as ReceiveQtyNew from TempStockInventory where type in('Open','Received') order by entrydate asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GETIssueDataWithDate(ByVal Enddate As String)
            Dim str As String
            str = "select  isnull(sum(IssueQty),0) as SalesQty  from TempStockInventory where  type in('Issued') and entrydate<='" & Enddate & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindItem()
            Dim str As String
            Try

                str = "  select  IMC.IMSIteMID,IMC.Itemname  from  IMSItem IMC "
                str &= " order by IMC.Itemname  ASC"


                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetIMSItemAllBYtype(ByVal Userid As Long) As DataTable
            Dim str As String
            str = " Select *,isnull((FDb.DalNo),'')as DalNo  from IMSItem IMS_I"
            str &= " join IMSItemCategory IMS_IC on IMS_IC.IMSItemCategoryID=IMS_I.IMSItemCategoryID"
            str &= " join IMSItemClass IMS_ICL on IMS_ICL.IMSItemClassID=IMS_I.IMSItemClassID"
            str &= " join IMSItemUnit IMS_IU on IMS_IU.ItemUnitId=IMS_I.ItemUnitId"
            str &= " join IMSCurrency IMS_C on IMS_C.IMSCurrencyID=IMS_I.IMSCurrencyID"
            str &= " left join DPFabricDbMst FDB on FDB.FabricDbMstID=IMS_I.FabricDbMstID"
            If Userid = 241 Then
                str &= " where IMS_ICL.StoreTypeID=1 "
            ElseIf Userid = 242 Then
                str &= " where IMS_ICL.StoreTypeID=2 "
            Else

            End If
            str &= "  order by  Itemname  ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        '' atif create this method for fabric 26 Dec 2017 -> just change the join with => POD.ProcessItemNameId
        Public Function InsertTempStockInventoryReceiveForProcessForFabric(ByVal ITEMID As Long)
            Dim str As String

            str = "   insert into TempStockInventory "
            str &= "  select IMI.PORecvDate ,IMI.PORecvDate, "
            str &= " IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId, '0' as IssueQty,"
            str &= " (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.PORate)  as UnitRate,"
            str &= " SupplierID  as IMSSupplierId, Type='Received',"
            str &= "    '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as  Location"
            str &= "  from POProcessRecvMaster IMI  join POProcessRecvDetail IMD on IMI.POProcessRecvMasterID =IMD.POProcessRecvMasterID"
            str &= " join ProcessOrderDtl pod on pod.ProcessOrderDtlId =imd.ProcessOrderDtlId "
            str &= " join IMSItem IM on IM.IMSItemId= pod.ProcessItemCodeID "
            str &= " join Location L on L.LocationId= IMI.LocationId "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "

            'str = "   insert into TempStockInventory " 
            'str &= "   select IMI.PORecvDate ,IMI.PORecvDate,  IMI.PartyDCNo  as DCNo, '0' as CustomerId, pod.ItemId,'0' as IssueQty, "
            'str &= "  (IMD.RecvQuantity) as ReceivedQty,(pod.Rate + pod.rate)  as UnitRate, SupplierID  as IMSSupplierId, Type='Received', "
            'str &= "  '' as RationName,IM.ItemName as ItemName ,'0' as Userid ,IMI.LocationId as LocationId,L.Location as "
            'str &= "   Location  from PORecvMaster IMI "
            'str &= " join PORecvDetail IMD on IMI.PORecvMasterID =IMD.PORecvMasterID  "
            'str &= "  join PODetail pod on pod.PoDetailId =imd.PODetailID  "
            'str &= "  join IMSItem IM on IM.IMSItemId= pod.ProcessItemCodeID    "
            'str &= " join Location L on L.LocationId= IMI.LocationId " 
            'str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function InsertTempStockInventoryReceiveForProcessForFabricIssue(ByVal ITEMID As Long)
            Dim str As String

            str = "   insert into TempStockInventory "
            str &= " select IMI.CreationDate,IMI.CreationDate, IMI.ManualChallanNo  as DCNo,   '0' CustomerId, IMD.ItemId,(IMD.IssueQty) "
            str &= " as IssueQty,  '0' as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Issued', '' as RationName, "
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMI.LocationId as LocationId,L.Location as  Location  "
            str &= " from processIssueMst IMI  "
            str &= " join processIssueDetail IMD on IMI.processIssueID =IMD.processIssueID  "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.ItemID    "
            str &= " join Location L on L.LocationId= IMI.LocationId  "
            str &= " where IM.IMSItemId='" & ITEMID & "'  "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForProcessNewToProcess(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,IMD.Rate as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssueForProcess IMI "
            str &= " join IMSGodownIssueDetailForProcess IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function InsertTempStockInventoryGodownTransferForRecvForLocationWiseForProcess(ByVal ITEMID As Long)
            Dim str As String
            str = "  insert into TempStockInventory select IMI.CreationDate,IMI.EntryDate, IMI.SIVNo  as DCNo, "
            str &= "  '0' CustomerId, IMD.IMSItemID,0 as IssueQty,"
            str &= "  Imd.QtyIssue as ReceivedQty,'0' as UnitRate, '0' as IMSSupplierId, Type='Received Transfer', '' as RationName,"
            str &= " IM.ItemName as ItemName ,'0' as Userid,IMD.ToLocationID as LocationId,L.Location as Location   from IMSGodownIssue IMI "
            str &= " join IMSGodownIssueDetail IMD on IMI.GodownIssueID =IMD.GodownIssueID "
            str &= " join IMSItem IM on IM.IMSItemId=IMD.IMSItemId  "
            str &= " join Location L on L.LocationID=IMD.FromLocationID  "
            str &= " where IM.IMSItemId='" & ITEMID & "' "
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

