Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class DPFabricIssue
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPFabricIssue"
            m_strPrimaryFieldName = "FabricIssueID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricIssueID As Long
        Private m_lFabricDBMstId As Long
        Private m_strCreationDate As Date
        Private m_lDPRNDID As Long
        Private m_dtFabricIssueDate As Date
        Private m_strDPTime As String
        Private m_dcNoofSample As Decimal
        Private m_dcFabricReqforonePcs As Decimal
        Private m_dcTotalFabricReq As Decimal
        Private m_dcTimeReqforonePcs As Decimal
        Private m_dcNofworker As Decimal
        Private m_dcTotalTimeReq As Decimal
        Private m_strRemarks As String
        Private m_dcAvailableFabric As Decimal
        Private m_strType As String
        Private m_strIssueNo As String
        Private m_dcBalanceQty As Decimal
        Public Property FabricIssueID() As Long
            Get
                FabricIssueID = m_lFabricIssueID
            End Get
            Set(ByVal value As Long)
                m_lFabricIssueID = value
            End Set
        End Property
        Public Property BalanceQty() As Decimal
            Get
                BalanceQty = m_dcBalanceQty
            End Get
            Set(ByVal value As Decimal)
                m_dcBalanceQty = value
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
                CreationDate = m_strCreationDate
            End Get
            Set(ByVal value As Date)
                m_strCreationDate = value
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
        Public Property FabricIssueDate() As Date
            Get
                FabricIssueDate = m_dtFabricIssueDate
            End Get
            Set(ByVal value As Date)
                m_dtFabricIssueDate = value
            End Set
        End Property
        Public Property DPTime() As String
            Get
                DPTime = m_strDPTime
            End Get
            Set(ByVal value As String)
                m_strDPTime = value
            End Set
        End Property
        Public Property IssueNo() As String
            Get
                IssueNo = m_strIssueNo
            End Get
            Set(ByVal value As String)
                m_strIssueNo = value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal value As String)
                m_strType = value
            End Set
        End Property
        Public Property NoofSample() As Decimal
            Get
                NoofSample = m_dcNoofSample
            End Get
            Set(ByVal value As Decimal)
                m_dcNoofSample = value
            End Set
        End Property
        Public Property FabricReqforonePcs() As Decimal
            Get
                FabricReqforonePcs = m_dcFabricReqforonePcs
            End Get
            Set(ByVal value As Decimal)
                m_dcFabricReqforonePcs = value
            End Set
        End Property
        Public Property TotalFabricReq() As Decimal
            Get
                TotalFabricReq = m_dcTotalFabricReq
            End Get
            Set(ByVal value As Decimal)
                m_dcTotalFabricReq = value
            End Set
        End Property
        Public Property TimeReqforonePcs() As Decimal
            Get
                TimeReqforonePcs = m_dcTimeReqforonePcs
            End Get
            Set(ByVal value As Decimal)
                m_dcTimeReqforonePcs = value
            End Set
        End Property
        Public Property Nofworker() As Decimal
            Get
                Nofworker = m_dcNofworker
            End Get
            Set(ByVal value As Decimal)
                m_dcNofworker = value
            End Set
        End Property
        Public Property TotalTimeReq() As Decimal
            Get
                TotalTimeReq = m_dcTotalTimeReq
            End Get
            Set(ByVal value As Decimal)
                m_dcTotalTimeReq = value
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
        Public Property AvailableFabric() As Decimal
            Get
                AvailableFabric = m_dcAvailableFabric
            End Get
            Set(ByVal value As Decimal)
                m_dcAvailableFabric = value
            End Set
        End Property
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function

        Public Function SaveFabricIssue()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Public Function GetConsNew(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "  select * from DPRNDStyleDetail Mst     "
                str &= " where DPRNDID='" & DPRNDID & "' AND ISBODYFABRIC=1"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 IssueNo from DPFabricIssue  order By FabricIssueID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

                End Try
        End Function
        Public Function GetLastStyleNo()
            Dim str As String
            str = "  select Top 1 StyleCode from DPStyleDatabase  order By DPStyleDatabaseId DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
       
        Public Function GetWorker()
            Dim str As String
            Try
                str = "select * from DPWorker order by WorkerName"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPFBIssueQty(ByVal DalNo As String)
            Dim str As String
            Try
                str = " select isnull(sUM(IssueQty),0) as IssueQty from DPPOIssueMst DFM JOIN DPPOIssueDtl DFI ON DFI.DPPOIssueMstID=DFM.DPPOIssueMstID"
                str &= " JOIN DPFabricDbMst FD ON FD.FabricDbMstID=DFI.FabricDbMstID"
                str &= " where DFI.DALNO='" & DalNo & "' "
                Return MyBase.GetDataTable(str)
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
        Public Function GetTotalReqTime(ByVal StyleCode As String)
            Dim str As String
            Try
                str = "select EstimatedTimeReq from DPStyleDatabase  "
                str &= " where StyleCode='" & StyleCode & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFBRcvQty(ByVal DalNo As String)
            Dim str As String
            Try
                str = " select isnull(sUM(ReceiveQty),0) as ReceiveQty from DPPOReceiveMst PORCV "
                str &= " JOIN DPPOReceiveDtl PORD ON  PORD.POReceiveMstID=PORCV.POReceiveMstID"
                str &= " JOIN DPFabricDbMst FD ON FD.FabricDbMstID=PORD.DPFabricMstID"
                str &= " where DALNO='" & DalNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFBIssueQty(ByVal DalNo As String)
            Dim str As String
            Try
                str = " select isnull(sUM(TotalFabricReq),0) as IssueQty from DPFabricIssue DFI "
                str &= " JOIN DPFabricDbMst FD ON FD.FabricDbMstID=DFI.FabricDbMstID"
                str &= " where DALNO='" & DalNo & "' and Type='Issue'"
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
        Public Function GetCons(ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " select isnull(sum(Mst.ConsumptionPerPCS),0) as ConsumptionPerPCS from DPRNDStyleDetail Mst   "
                str &= " where DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTime()
            Dim str As String
            Try
                str = "select * from DPTime  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindFabricGrid()
            Dim str As String
            Try
                '   str = "select convert(varchar,CreationDate,103) as CreationDatee,* from DPFabricIssue  "
                str = " select convert(varchar,DFI.CreationDate,103) as CreationDatee, DFI.*,FD.dALNO,rnd.Style from DPFabricIssue DFI "
                str &= " JOIN DPFabricDbMst FD ON FD.FabricDbMstID=DFI.FabricDbMstID"
                str &= " jOIN TblDPRND rnd on rnd.DPRNDID=DFI.DPRNDID "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditData(ByVal DPFabricIssueId As Long)
            Dim str As String
            Try
                str = " select DFI.*,RND.dALNO,rnd.Style from DPFabricIssue DFI "
                str &= " JOIN DPFabricDbMst FD ON FD.FabricDbMstID=DFI.FabricDbMstID"
                str &= " jOIN TblDPRND rnd on rnd.DPRNDID=DFI.DPRNDID where DFI.FabricIssueid='" & DPFabricIssueId & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditForDPI(ByVal DPIMstID As Long)
            Dim str As String
            Try
                str = " select * from DPIMst MST "
                str &= " JOIN DPIDtl Dtl ON Dtl.DPIMstID=MST.DPIMstID"
                str &= " where MST.DPIMstID='" & DPIMstID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBuyerAddress(ByVal CustomerID As Long)
            Dim str As String
            Try
                str = " select *,mst.Aliass + '' + MST.address1 as Consignee from Customer MST  "
                str &= " where MST.CustomerID='" & CustomerID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetEditDatanEW(ByVal DPFabricIssueId As Long)
            Dim str As String
            Try
                str = " select DFI.*,FD.dALNO,rnd.Style,DFI.DPRNDID as DPRNDIDD from DPFabricIssue DFI "
                str &= " JOIN DPFabricDbMst FD ON FD.FabricDbMstID=DFI.FabricDbMstID"
                str &= " jOIN TblDPRND rnd on rnd.DPRNDID=DFI.DPRNDID where DFI.FabricIssueid='" & DPFabricIssueId & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditWorkerData(ByVal DPFabricIssueId As Long)
            Dim str As String
            Try
                str = " select * from DPFabricIssueWorkerDtl where FabricIssueid='" & DPFabricIssueId & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class

End Namespace
