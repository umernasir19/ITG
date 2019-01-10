Imports system.data

Namespace EuroCentra
    Public Class DPPOMst
        Inherits sqlmanager
        Public Sub New()
            m_strTableName = "DPPOMst"
            m_strPrimaryFieldName = "DPPOMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPPOMstID As Long
        Private m_lFabricDbMstID As Long
        Private m_lUserID As Long
        Private m_dCreationDate As Date
        Private m_dInvoiceDate As Date
        Private m_strPONo As String
        Private m_strDALNo As String
        Private m_lSupplierID As Long
        Private m_strInditexPONo As String
        Private m_lPOTypeID As Long
        Public Property POTypeID() As Long
            Get
                POTypeID = m_lPOTypeID
            End Get
            Set(ByVal Value As Long)
                m_lPOTypeID = Value
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
        Public Property DPPOMstID() As Long
            Get
                DPPOMstID = m_lDPPOMstID
            End Get
            Set(ByVal Value As Long)
                m_lDPPOMstID = Value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal Value As Long)
                m_lSupplierID = Value
            End Set
        End Property
        Public Property FabricDbMstID() As Long
            Get
                FabricDbMstID = m_lFabricDbMstID
            End Get
            Set(ByVal Value As Long)
                m_lFabricDbMstID = Value
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
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dCreationDate = Value
            End Set
        End Property
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = m_dInvoiceDate
            End Get
            Set(ByVal Value As Date)
                m_dInvoiceDate = Value
            End Set
        End Property
        Public Property PONo() As String
            Get
                PONo = m_strPONo
            End Get
            Set(ByVal Value As String)
                m_strPONo = Value
            End Set
        End Property
        Public Property DALNo() As String
            Get
                DALNo = m_strDALNo
            End Get
            Set(ByVal Value As String)
                m_strDALNo = Value
            End Set
        End Property
      
        Public Function SaveMST()
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
        Function Deletedetail(ByVal DPPODtlID As Long)
            Dim str As String
            str = " Delete  from DPPODtl where DPPODtlID ='" & DPPODtlID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedRNDMaster(ByVal DPRNDID As Long)
            Dim str As String
            str = " Delete  from TblDPRND where DPRNDID ='" & DPRNDID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedSampleReceive(ByVal DPSampleReceiveID As Long)
            Dim str As String
            str = " Delete  from DPSampleReceive where DPSampleReceiveID ='" & DPSampleReceiveID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedForPOReceiveMaster(ByVal POReceiveMstID As Long)
            Dim str As String
            str = " Delete  from DPPOReceiveMst where POReceiveMstID ='" & POReceiveMstID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedForPOReceiveDetail(ByVal POReceiveMstID As Long)
            Dim str As String
            str = " Delete  from DPPOReceiveDtl where POReceiveMstID ='" & POReceiveMstID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedFabricIssue(ByVal FabricIssueID As Long)
            Dim str As String
            str = " Delete  from DPFabricIssue where FabricIssueID ='" & FabricIssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedForPOMaster(ByVal DPPOMstID As Long)
            Dim str As String
            str = " Delete  from DPPOMst where DPPOMstID ='" & DPPOMstID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedForPODetail(ByVal DPPOMstID As Long)
            Dim str As String
            str = " Delete  from DPPODtl where DPPOMstID ='" & DPPOMstID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedForPOIssueMst(ByVal DPPOIssueMstID As Long)
            Dim str As String
            str = " Delete  from DPPOIssueMst where DPPOIssueMstID ='" & DPPOIssueMstID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedForPOIssueDtl(ByVal DPPOIssueMstID As Long)
            Dim str As String
            str = " Delete  from DPPOIssueDtl where DPPOIssueMstID ='" & DPPOIssueMstID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedFabricIssueWorkerDetail(ByVal FabricIssueID As Long)
            Dim str As String
            str = " Delete  from DPFabricIssueWorkerDtl where FabricIssueID ='" & FabricIssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function

        Function CheckExistingDataForSampleIssue(ByVal DPRNDID As Long)
            Dim str As String
            str = " select * from DPFabricIssue where DPRNDID ='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForSampleReceive(ByVal DPRNDID As Long)
            Dim str As String
            str = " select *  from DPSampleReceive where DPRNDID ='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForPurchaseOrder(ByVal DPRNDID As Long)
            Dim str As String
            str = " select * from DPPODtl where DPRNDID ='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForWashIssue(ByVal DPRNDID As Long)
            Dim str As String
            str = " select * from DPWashDtl where tblRNDID ='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForWashReceive(ByVal DPRNDID As Long)
            Dim str As String
            str = " select * from DPWashRecvDtl where StyleID ='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataForSampleReceiveForFabricReceive(ByVal FabricIssueID As Long)
            Dim str As String
            str = " select * from DPSampleReceive where FabricIssueID ='" & FabricIssueID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckExistingDataFoRPOReceive(ByVal DPPOMstID As Long)
            Dim str As String
            str = " select * from DPPOReceiveDtl where DPPOMstID ='" & DPPOMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedRNDAccDetail(ByVal DPRNDID As Long)
            Dim str As String
            str = " Delete  from DPRNDAccessDetail where DPRNDID ='" & DPRNDID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeletedRNDStyleDetail(ByVal DPRNDID As Long)
            Dim str As String
            str = " Delete  from DPRNDStyleDetail where DPRNDID ='" & DPRNDID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateGGTStatus(ByVal DPRNDID As Long)
            Dim str As String
            str = " update  tbldprnd set AllowToGGT=1  where DPRNDID ='" & DPRNDID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastVoucherNo(ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            str = " select Top 1 PONo from DPPOMst where year(CreationDate)='" & year & "' order By DPPOMstID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFBData(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select FabricName +' '+ FabricQuality+' '+ Onz as Item,convert(varchar,FM.CreationDate,103) as CreationDatee,* from DPFabricDbMst FM "
                str &= " Join SupplierDatabase V on  V.SupplierDatabaseID=FM.SupplierId"
                str &= " join Composition c on c.CompositionId=FM.CompositionId  where fm.DalNo='" & DALNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPONo(ByVal PONo As String)
            Dim str As String
            Try
                str = "select * from DPPOMst where PONo ='" & PONo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindPOType()
            Dim str As String
            str = " select * from POType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetEdit(ByVal DPPOMstID As Long)
            Dim str As String
            Try
                str = " select * from DPPOMst dp"
                str &= " join DPPODtl dd on dd.DPPOMstID =dp.DPPOMstID "
                str &= " join SupplierDatabase sd on sd.SupplierDatabaseId =dp.SupplierID "
                'str &= " join TblDPRND tr on tr.FabricDBMstId =dp.FabricDbMstID "
                str &= " where dp.DPPOMstID ='" & DPPOMstID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetReportData(ByVal CustomerName As String, ByVal Style As String, ByVal DalNo As String, ByVal CheckDate As Byte, ByVal StartDate As String, ByVal EndDate As String)
            Dim str As String
            Try

                If CustomerName <> "All" And Style <> "All" And DalNo <> "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' and RND.Style='" & Style & "' and  RND.DalNo='" & DalNo & "' "
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"


                ElseIf CustomerName <> "All" And Style <> "All" And DalNo <> "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' and RND.Style='" & Style & "' and  RND.DalNo='" & DalNo & "' "



                ElseIf CustomerName <> "All" And Style <> "All" And DalNo = "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' and RND.Style='" & Style & "'"
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"


                ElseIf CustomerName <> "All" And Style <> "All" And DalNo = "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' and RND.Style='" & Style & "'"

                ElseIf CustomerName <> "All" And Style = "All" And DalNo <> "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' and  RND.DalNo='" & DalNo & "' "
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"


                ElseIf CustomerName <> "All" And Style = "All" And DalNo <> "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' and  RND.DalNo='" & DalNo & "' "

                ElseIf CustomerName <> "All" And Style = "All" And DalNo = "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "'"
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"

                ElseIf CustomerName <> "All" And Style = "All" And DalNo = "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Buyer='" & CustomerName & "' "


                ElseIf CustomerName = "All" And Style <> "All" And DalNo <> "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where  RND.Style='" & Style & "' and  RND.DalNo='" & DalNo & "' "
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"

                ElseIf CustomerName = "All" And Style <> "All" And DalNo <> "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where  RND.Style='" & Style & "' and  RND.DalNo='" & DalNo & "' "

                ElseIf CustomerName = "All" And Style <> "All" And DalNo = "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Style='" & Style & "'"
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"


                ElseIf CustomerName = "All" And Style <> "All" And DalNo = "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.Style='" & Style & "'"

                ElseIf CustomerName = "All" And Style = "All" And DalNo <> "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.DalNo='" & DalNo & "'"
                    str &= " and RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"


                ElseIf CustomerName = "All" And Style = "All" And DalNo <> "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.DalNo='" & DalNo & "' "


                ElseIf CustomerName = "All" And Style = "All" And DalNo = "All" And CheckDate <> 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"
                    str &= " where RND.CreatDate between '" & StartDate & "' and '" & EndDate & "'"


                ElseIf CustomerName = "All" And Style = "All" And DalNo = "All" And CheckDate = 0 Then
                    str = " select '1' as SampleStatus,*,SD.Description as Descriptionn,RND.Threads as ThreadsnEW,convert(varchar,RND.CreatDate,103) as CreatDatee from TblDPRND RND"
                    str &= " join DPStyleDatabase SD on SD.StyleCode=RND.Style "
                    str &= " JOIN DPFabricDbMst FDB ON FDB.FabricDbMstid=RND.FabricDbMstid "
                    str &= " JOIN Composition C on C.CompositionID=FDB.CompositionID"

                End If

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
        Public Function GetFabricDbID(ByVal FabricIssueID As Long)
            Dim str As String
            Try
                str = "select * from DPFabricDbMst Mst"
                str &= " join DPFabricIssue FI on FI.FabricDbMstID=Mst.FabricDbMstID "
                str &= "   where FI.FabricIssueID='" & FabricIssueID & "'"
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
        Public Function GetItemData(ByVal DPRNDID As Long, ByVal DPItemDatabaseid As Long)
            Dim str As String
            Try
                str = "select * from  DPRNDAccessDetail DPRA ON ITD.DPItemDatabaseid=DPRA.DPItemDatabaseid"
                str &= "   where DPRNDID='" & DPRNDID & "' and  DPItemDatabaseid='" & DPItemDatabaseid & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleQty(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "select * from TblDPRND Where DPRNDID='" & DPRNDID & "' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRemQty(ByVal DPRNDID As Long, ByVal DALNo As String)
            Dim str As String
            Try
                str = "select Isnull(sum(FI.TotalFabricReq),0) as Quantity  from DPFabricIssue FI "
                str &= " join TblDPRND RND on RND.DPRNDID=FI.DPRNDID"
                str &= " Where  FI.DPRNDID='" & DPRNDID & "'AND RND.DALNo='" & DALNo & "' and FI.Type='Issue' "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPrice(ByVal FabricDbMstID As Long)
            Dim str As String
            Try
                str = "select isnull((Price),0) as Price from DPFabricDbDtl "
                str &= " Where  FabricDbMstID='" & FabricDbMstID & "'"

                Return MyBase.GetDataTable(str)
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
                str = " select Distinct SupplierDatabaseID,SupplierName from SupplierDatabase"
                str &= " order by SupplierName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDSINo()
            Dim str As String
            Try
                str = "select * from DPFabricIssue"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData()
            Dim str As String
            Try
                str = "select dm.DPPOMstid,InditexPONO,convert (varchar,InvoiceDate,103) as InvoiceDatee, pono,v.SupplierName,DalNo,sum(Quantity) as TotalPOQty from DPPOMst dm"
                str &= " join SupplierDatabase v on v.SupplierDatabaseID=dm.SupplierID"
                str &= " JOIN DPPODTL DPD ON DPD.DPPOMstid=dm.DPPOMstid"
                str &= " group by dm.DPPOMstid,InvoiceDate,SupplierName,PONo,DalNo,InditexPONO  order by InvoiceDate DESC "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUnit()
            Dim str As String
            Try
                str = "select * from Units "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function CheckExistingPO(ByVal DPPOMstID As Long)
            Dim str As String
            str = " select * from DPPOReceiveDtl where DPPOMstID ='" & DPPOMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

