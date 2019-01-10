Imports system.data
Namespace EuroCentra
    Public Class DPWashMst
        Inherits sqlmanager
        Public Sub New()
            m_strTableName = "DPWashMst"
            m_strPrimaryFieldName = "WashMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lWashMstID As Long
        Private m_dCreationDate As Date
        Private m_strWashIssueNo As String
        Private m_dIssueDate As Date
        Public Property WashMstID() As Long
            Get
                WashMstID = m_lWashMstID
            End Get
            Set(ByVal value As Long)
                m_lWashMstID = value
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
        Public Property IssueDate() As Date
            Get
                IssueDate = m_dIssueDate
            End Get
            Set(ByVal value As Date)
                m_dIssueDate = value
            End Set
        End Property
        Public Property WashIssueNo() As String
            Get
                WashIssueNo = m_strWashIssueNo
            End Get
            Set(ByVal value As String)
                m_strWashIssueNo = value
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
        Public Function GetDPWashType()
            Dim str As String
            Try
                str = "select * from DPWashType "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPFabricRcv(ByVal FabricDbMstID As Long, ByVal DPRNDID As Long)
            Dim str As String
            Try
                str = " select DPSampleReceiveID,DSRNO from DPSampleReceive where FabricDbMstID='" & FabricDbMstID & "' AND DPRNDID='" & DPRNDID & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLastVoucherNo(ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            str = " select Top 1 WashIssueNo from DPWashMst where year(CreationDate)='" & year & "' order By WashMstID DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 WashIssueNo from DPWashMst  order By WashMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function



        Function Deletedetail(ByVal WashDtlID As Long)
            Dim str As String
            str = " Delete  from DPWashDtl where WashDtlID ='" & WashDtlID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDSRNo(ByVal DSRNo As String)
            Dim str As String
            Try
                str = " select * from DPFabricDbMst Mst"
                str &= " join DPSampleReceive SR on SR.FabricDbMstID=Mst.FabricDbMstID"
                str &= " where  SR.DSRNo='" & DSRNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function StyleForSampleIssue(ByVal DalNo As String, ByVal SampleReceiveID As Long)
            Dim str As String
            Try
                str = "select * from DPSampleReceive FI"
                str &= " join TblDPRND DPR on DPR.DPRNDID=FI.DPRNDID"
                str &= " where  DPR.DalNo='" & DalNo & "' AND FI.DPSampleReceiveID= ' " & SampleReceiveID & " ' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNo(ByVal DalNo As String)
            Dim str As String
            Try
                str = "select FM.FabricDBMstID from DPSampleReceive FM "
                str &= " Join tblDPRND V on  V.DPRNDID=FM.DPRNDID"
                str &= "   where V.DalNo='" & DalNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEdit(ByVal WashMstID As Long)
            Dim str As String
            Try
                str = " select * from DPWashMst Mst"
                str &= "  join DPWashDtl Dtl on Dtl.WashMstID=Mst.WashMstID"
                str &= "  join dpWashType WT on WT.WashTypeID=Dtl.WashTypeID"
                str &= "  JOIN TblDPRND RND on RND.DPRNDID=Dtl.tblRNDID"
                str &= "   where Mst.WashMstID='" & WashMstID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetQty(ByVal DSRNo As String)
            Dim str As String
            Try
                str = "select  FM.ReceiveQty  from DPSampleReceive FM "
                str &= "   where FM.DSRNo='" & DSRNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetQtyNew(ByVal DPSampleReceiveID As Long)
            Dim str As String
            Try
                str = "select  FM.ReceiveQty  from DPSampleReceive FM "
                str &= "   where FM.DPSampleReceiveID='" & DPSampleReceiveID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetIssuedQty(ByVal FabricDbMstID As Long, ByVal TBLRNDID As Long, ByVal DPSampleReceiveID As Long, ByVal DSRNo As String)
            Dim str As String
            Try
                str = " select isnull(SUM(IssueQty),0) as IssudeQty from DPWashDtl "
                str &= "  where FabricDbMstID = '" & FabricDbMstID & "' And TBLRNDID = '" & TBLRNDID & "' And DPSampleReceiveID = '" & DPSampleReceiveID & "' and DSRNo='" & DSRNo & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace


