Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class DPSampleReceive

        Inherits sqlmanager
        Public Sub New()
            m_strTableName = "DPSampleReceive"
            m_strPrimaryFieldName = "DPSampleReceiveID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPSampleReceiveID As Long
        Private m_dtCreationDate As Date

        Private m_lUserId As Long
        Private m_dtReceiveDate As Date

        Private m_strReceiveTime As String
        Private m_lFabricDbMstID As Long
        Private m_lDPRNDID As Long

        Private m_dIssueQty As Decimal
        Private m_dFabricRecvQty As Decimal
        Private m_dReceiveQty As Decimal

        Private m_strHourConsumed As String
        Private m_strDifference As String
        Private m_strRemarks As String
        Private m_strDSRNo As String
        Private m_strDSINo As String
        Private m_lFabricIssueID As Long
        Public Property FabricIssueID() As Long
            Get
                FabricIssueID = m_lFabricIssueID
            End Get
            Set(ByVal value As Long)
                m_lFabricIssueID = value
            End Set
        End Property
        Public Property DSINo() As String
            Get
                DSINo = m_strDSINo
            End Get
            Set(ByVal value As String)
                m_strDSINo = value
            End Set
        End Property
        Public Property DPSampleReceiveID() As Long
            Get
                DPSampleReceiveID = m_lDPSampleReceiveID
            End Get
            Set(ByVal value As Long)
                m_lDPSampleReceiveID = value
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
        Public Property UserId() As Long
            Get
                UserId = m_lUserId
            End Get
            Set(ByVal value As Long)
                m_lUserId = value
            End Set
        End Property
        Public Property ReceiveDate() As Date
            Get
                ReceiveDate = m_dtReceiveDate
            End Get
            Set(ByVal value As Date)
                m_dtReceiveDate = value
            End Set
        End Property
        Public Property ReceiveTime() As String
            Get
                ReceiveTime = m_strReceiveTime
            End Get
            Set(ByVal value As String)
                m_strReceiveTime = value
            End Set
        End Property

        Public Property FabricDbMstID() As Long
            Get
                FabricDbMstID = m_lFabricDbMstID
            End Get
            Set(ByVal value As Long)
                m_lFabricDbMstID = value
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
        Public Property IssueQty() As Decimal
            Get
                IssueQty = m_dIssueQty
            End Get
            Set(ByVal value As Decimal)
                m_dIssueQty = value
            End Set
        End Property
        Public Property FabricRecvQty() As Decimal
            Get
                FabricRecvQty = m_dFabricRecvQty
            End Get
            Set(ByVal value As Decimal)
                m_dFabricRecvQty = value
            End Set
        End Property
        Public Property ReceiveQty() As Decimal
            Get
                ReceiveQty = m_dReceiveQty
            End Get
            Set(ByVal value As Decimal)
                m_dReceiveQty = value
            End Set
        End Property

        Public Property DSRNo() As String
            Get
                DSRNo = m_strDSRNo
            End Get
            Set(ByVal value As String)
                m_strDSRNo = value
            End Set
        End Property
        Public Property HourConsumed() As String
            Get
                HourConsumed = m_strHourConsumed
            End Get
            Set(ByVal value As String)
                m_strHourConsumed = value
            End Set
        End Property

        Public Property Difference() As String
            Get
                Difference = m_strDifference
            End Get
            Set(ByVal value As String)
                m_strDifference = value
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
      
       
        Public Function Saved()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditData(ByVal lDPSampleReceiveID As String)
            Dim str As String
            Try
                str = "select * from DPSampleReceive SR "
                str &= "  JOIN TblDPRND RND on RND.DPRNDID=SR.DPRNDID"
                str &= " where  SR.DPSampleReceiveID='" & lDPSampleReceiveID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function StyleForSampleIssue(ByVal DalNo As String, ByVal FabicIssueID As Long)
            Dim str As String
            Try
                str = "select * from DPFabricIssue FI"
                str &= " join TblDPRND DPR on DPR.DPRNDID=FI.DPRNDID"
                str &= " where FI.Type='Issue' and DPR.DalNo='" & DalNo & "' and FI.FabricIssueID= ' " & FabicIssueID & " ' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNoForFabricIssue(ByVal IssueNo As String)
            Dim str As String
            Try
                str = "SELECT * FROM DPFabricDbMst Mst"
                str &= " join DPFabricIssue FI on FI.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where FI.IssueNo='" & IssueNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabricReceiveQty(ByVal FabricDBMstID As Long, ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "select ISNULL(SUM(ReceiveQty),0) AS FabricReceiveQty from DPSampleReceive  "
                str &= " where FabricDBMstID=' " & FabricDBMstID & "' and DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabricReceiveQtyNew(ByVal DSINo As String)
            Dim str As String
            Try
                str = "select ISNULL(SUM(ReceiveQty),0) AS FabricReceiveQty from DPSampleReceive  "
                str &= " where DSINo='" & DSINo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPreHourConsumed(ByVal DSINo As String)
            Dim str As String
            Try
                str = "select ISNULL(SUM(HourConsumed),0) AS HourConsumed from DPSampleReceive  "
                str &= " where DSINo='" & DSINo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetIssueQty(ByVal FabricDBMstID As Long, ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "select ISNULL(SUM(NoofSample),0) AS IssueQty from DPFabricIssue  "
                str &= " where FabricDBMstID=' " & FabricDBMstID & "' and DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetIssueQtyNew(ByVal IssueNo As String)
            Dim str As String
            Try
                str = "select ISNULL(SUM(NoofSample),0) AS IssueQty from DPFabricIssue  "
                str &= " where IssueNo='" & IssueNo & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetHourConsumed(ByVal FabricDBMstID As Long, ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = "select DPTime,CreationDate from DPFabricIssue  "
                str &= " where FabricDBMstID='" & FabricDBMstID & "' and DPRNDID='" & DPRNDID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function



        Public Function GetDifference(ByVal FabricDBMstID As Long, ByVal DPRNDID As Long, ByVal IssueNo As String)
            Dim str As String
            Try
                str = "select TotalTimeReq from DPFabricIssue  "
                str &= " where FabricDBMstID=' " & FabricDBMstID & "' and DPRNDID='" & DPRNDID & "' AND IssueNo='" & IssueNo & "'"
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
        Public Function GetLastInvoiceNo(ByVal Year As String)
            Dim str As String
            str = "  select Top 1 InvoiceNoPOne from Cargo where year(CreationDate) ='" & Year & "' order By CargoID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 DSRNo from DPSampleReceive  order By DPSampleReceiveID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetBindGrid()
            Dim str As String
            Try
                str = "select convert(varchar,FI.ReceiveDate,103) as ReceiveDatee,FI.ReceiveTime,* from DPSampleReceive FI"
                str &= "  join TblDPRND DPR on DPR.DPRNDID=FI.DPRNDID"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetBindGridForWash()
            Dim str As String
            Try
                str = " select convert(varchar,Mst.IssueDate,103) as IssueDatee,Mst.WashMstID,Mst.WashIssueNo,"
                str &= "  isnull((Dtl.SampleRecvQty),0) as SampleRecvQty,"
                str &= "  isnull(sum(Dtl.IssueQty),0) as IssueQty "
                str &= "  from DPWashMst Mst"
                str &= "   join DPWashDtl Dtl on Dtl.WashMstID=Mst.WashMstID"
                str &= "  group by Mst.WashMstID,Mst.WashIssueNo,Dtl.SampleRecvQty,Dtl.IssueQty,Mst.IssueDate"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace


