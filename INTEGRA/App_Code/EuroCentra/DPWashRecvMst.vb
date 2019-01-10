Imports System.Data
Namespace EuroCentra

    Public Class DPWashRecvMst
        Inherits sqlmanager
        Public Sub New()
            m_strTableName = "DPWashRecvMst"
            m_strPrimaryFieldName = "DPWashRecvMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPWashRecvMstID As Long
        Private m_dCreationDate As Date
        Private m_strWashRecvNo As String
        Private m_strWashNo As String
        Private m_dRecvDate As Date
        Private m_lWashMstID As Long
        
        Public Property DPWashRecvMstID() As Long
            Get
                DPWashRecvMstID = m_lDPWashRecvMstID
            End Get
            Set(ByVal value As Long)
                m_lDPWashRecvMstID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal value As Date)
                m_dCreationDate = value
            End Set
        End Property
        Public Property WashRecvNo() As String
            Get
                WashRecvNo = m_strWashRecvNo
            End Get
            Set(ByVal value As String)
                m_strWashRecvNo = value
            End Set
        End Property
        Public Property WashNo() As String
            Get
                WashNo = m_strWashNo
            End Get
            Set(ByVal value As String)
                m_strWashNo = value
            End Set
        End Property
        Public Property RecvDate() As Date
            Get
                RecvDate = m_dRecvDate
            End Get
            Set(ByVal value As Date)
                m_dRecvDate = value
            End Set
        End Property
        Public Property WashMstID() As Long
            Get
                WashMstID = m_lWashMstID
            End Get
            Set(ByVal value As Long)
                m_lWashMstID = value
            End Set
        End Property
        Public Function Save()
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
        Public Function GetLastVoucherNo(ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            str = " select Top 1 WashRecvNo from DPWashRecvMst where year(CreationDate)='" & year & "' order By DPWashRecvMstID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 WashRecvNo from DPWashRecvMst  order By DPWashRecvMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function Deletedetail(ByVal DPWashRecvDtlID As Long)
            Dim str As String
            str = " Delete  from DPWashRecvDtl where DPWashRecvDtlID ='" & DPWashRecvDtlID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function WashIssueNo(ByVal WashNo As String)
            Dim str As String
            Try
                str = "select * from DPWashMst WR"
                '  str &= " join TblDPRND DPR on DPR.DPRNDID=FI.DPRNDID"
                str &= " where  WR.WashNo='" & WashNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function DalNo(ByVal WashIssueNo As String)
            Dim str As String
            Try
                str = " select * from DPWashMst wi "
                str &= " join DPWashDtl dt on dt.WashMstID =wi.WashMstID "
                str &= " join DPFabricDbMst fdb on fdb.FabricDBMstId =dt.FabricDBMstID "
                str &= " where wi.WashIssueNo ='" & WashIssueNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEdit(ByVal DPWashRecvMstID As String)
            Dim str As String
            Try
                str = " select * from DPWashRecvMst Mst"
                str &= " join DPWashRecvDtl Dtl on Dtl.DPWashRecvMstID=Mst.DPWashRecvMstID"
                str &= " where Mst.DPWashRecvMstID ='" & DPWashRecvMstID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ReceivedQty(ByVal WashMstID As Long, ByVal DalID As Long, ByVal StyleID As Long)
            Dim str As String
            Try
                str = " select isnull(sum (wd.ReceiveQuantity),0) as ReceiveQuantity,isnull(sum (wd.RejectQty),0) as RejectQty from DPWashRecvMst  wm"
                str &= " join DPWashRecvDtl wd on wd.DPWashRecvMstID =wm.DPWashRecvMstID "
                str &= " where wm.WashMstID ='" & WashMstID & "' and wd.DalID ='" & DalID & "' and wd.StyleID ='" & StyleID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function StyleNo(ByVal WashIssueNo As String, ByVal DalNo As String)
            Dim str As String
            Try

                str = " select  rnd.Style ,rnd.DPRNDID ,wt.WashType,dt.IssueQty,*   from DPWashMst wi "
                str &= " join DPWashDtl dt on dt.WashMstID =wi.WashMstID "
                str &= " join DPFabricDbMst fdb on fdb.FabricDBMstId =dt.FabricDBMstID "
                str &= " join TblDPRND rnd on rnd .DPRNDID =dt.tblRNDID "
                str &= " join DPWashType wt on wt.WashTypeID =dt.WashTypeID "
                str &= " where wi.WashIssueNo ='" & WashIssueNo & "' and fdb.DalNo ='" & DalNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getdataStyleNo(ByVal WashIssueNo As String, ByVal DalNo As String, ByVal Styleid As Long)
            Dim str As String
            Try

                str = " select  rnd.Style ,rnd.DPRNDID ,wt.WashType,dt.IssueQty,*   from DPWashMst wi "
                str &= " join DPWashDtl dt on dt.WashMstID =wi.WashMstID "
                str &= " join DPFabricDbMst fdb on fdb.FabricDBMstId =dt.FabricDBMstID "
                str &= " join TblDPRND rnd on rnd .DPRNDID =dt.tblRNDID "
                str &= " join DPWashType wt on wt.WashTypeID =dt.WashTypeID "
                str &= " where wi.WashIssueNo ='" & WashIssueNo & "' and fdb.DalNo ='" & DalNo & "' and dt.TblRNDID='" & Styleid & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGridForWash()
            Dim str As String
            Try
                'str = "select convert(varchar,RecvDate,103) as RecvDatee,* from DPWashRecvMst Mst"
                ' str &= "  join DPWashRecvDtl Dtl on Dtl.DPWashRecvMstID=Mst.DPWashRecvMstID"
                str = " select Ms.DPWashRecvMstID,convert(varchar,RecvDate,103) as RecvDatee,WashRecvNo,sum(ReceiveQuantity) as ReceiveQuantity"
                str &= "  from DPWashRecvMst Ms join DPWashRecvDtl RD ON  Ms.DPWashRecvMstID=RD.DPWashRecvMstID"
                str &= "  GROUP BY Ms.DPWashRecvMstID,RecvDate,WashRecvNo order by RecvDate  DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetBindGridForWashNew()
            Dim str As String
            Try
                'str = "select convert(varchar,RecvDate,103) as RecvDatee,* from DPWashRecvMst Mst"
                ' str &= "  join DPWashRecvDtl Dtl on Dtl.DPWashRecvMstID=Mst.DPWashRecvMstID"
                str = "  select *,convert(varchar,Ms.RecvDate,103) as RecvDatee from DPWashRecvMst Ms "
                str &= "  join DPWashRecvDtl RD ON  Ms.DPWashRecvMstID=RD.DPWashRecvMstID  "
                ' str &= "  GROUP BY Ms.DPWashRecvMstID,RecvDate,WashRecvNo order by RecvDate  DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace