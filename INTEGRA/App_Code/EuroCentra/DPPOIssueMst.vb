Imports System.Data

Namespace EuroCentra
    Public Class DPPOIssueMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPPOIssueMst"
            m_strPrimaryFieldName = "DPPOIssueMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPPOIssueMstID As Long
        Private m_dtCreationDate As Date
        Private m_dtIssueDate As Date
        Private m_strIssueTime As String
        Private m_strDCNo As String
        Private m_strIssueVoucherNo As String
      
        Public Property DPPOIssueMstID() As Long
            Get
                DPPOIssueMstID = m_lDPPOIssueMstID
            End Get
            Set(ByVal value As Long)
                m_lDPPOIssueMstID = value
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
        Public Property IssueDate() As Date
            Get
                IssueDate = m_dtIssueDate
            End Get
            Set(ByVal value As Date)
                m_dtIssueDate = value
            End Set
        End Property


        Public Property IssueTime() As String
            Get
                IssueTime = m_strIssueTime
            End Get
            Set(ByVal value As String)
                m_strIssueTime = value
            End Set
        End Property
        Public Property DCNo() As String
            Get
                DCNo = m_strDCNo
            End Get
            Set(ByVal value As String)
                m_strDCNo = value
            End Set
        End Property
        Public Property IssueVoucherNo() As String
            Get
                IssueVoucherNo = m_strIssueVoucherNo
            End Get
            Set(ByVal value As String)
                m_strIssueVoucherNo = value
            End Set
        End Property
        Public Function Save()
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
        Public Function GetCmbFrom()
            Dim str As String
            str = " SELECT DeptDatabaseName  as DeptDatabaseName,DeptDatabaseId FROM DPDepartmentDataBase"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetLastNo()
            Dim str As String
            str = "  select Top 1 IssueVoucherNo from DPPOIssueMst  order By DPPOIssueMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllData()
            Dim str As String
            Try
                'str = "select convert (varchar,ReceiveDate,103) as ReceiveDatee, * from DPPOReceiveMst dm join SupplierDatabase v on v.SupplierDatabaseID=dm.SupplierID"
                str = " select DM.DPPOIssueMstID,convert (varchar,IssueDate,103) as IssueDatee,sum(IssueQty) as TotalQty,IssueVoucherNo ,DCNO from DPPOIssueMst DM "
                str &= " join DPPOIssueDtl DR ON DR.DPPOIssueMstID=DM.DPPOIssueMstID"
                str &= " group by DM.DPPOIssueMstID,IssueDate,IssueVoucherNo,DCNO order by IssueDate DESC "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
