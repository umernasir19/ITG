Imports System.Data
Namespace EuroCentra
    Public Class StyleDatabaseClass
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPStyleDatabase"
            m_strPrimaryFieldName = "DPStyleDatabaseId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPStyleDatabaseId As Long
        Private m_strStyleCode As String
        Private m_strStyleName As String
        Private m_dtCreationDate As Date
        Private m_dtStyleDate As Date
        Private m_lUserId As Long
        Private m_strCompanyName As String
        Private m_strDescription As String
        Private m_dcEstimatedTimeReq As Decimal
        Private m_strFileNameFront As String
        Private m_imgImageFront As Object
        Private m_strFileNameBack As String
        Private m_imgImageBack As Object
        Private m_bIsactive As Boolean
        Private m_lCustomerID As Long
        Private m_strBuyerReferenceNo As String
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal value As Long)
                m_lCustomerID = value
            End Set
        End Property
        Public Property BuyerReferenceNo() As String
            Get
                BuyerReferenceNo = m_strBuyerReferenceNo
            End Get
            Set(ByVal value As String)
                m_strBuyerReferenceNo = value
            End Set

        End Property
        Public Property DPStyleDatabaseId() As Long
            Get
                DPStyleDatabaseId = m_lDPStyleDatabaseId
            End Get
            Set(ByVal value As Long)
                m_lDPStyleDatabaseId = value
            End Set
        End Property
        Public Property StyleCode() As String
            Get
                StyleCode = m_strStyleCode
            End Get
            Set(ByVal value As String)
                m_strStyleCode = value
            End Set

        End Property
        Public Property StyleName() As String
            Get
                StyleName = m_strStyleName
            End Get
            Set(ByVal value As String)
                m_strStyleName = value
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
        Public Property StyleDate() As Date
            Get
                StyleDate = m_dtStyleDate
            End Get
            Set(ByVal value As Date)
                m_dtStyleDate = value
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

        Public Property CompanyName() As String
            Get
                CompanyName = m_strCompanyName
            End Get
            Set(ByVal value As String)
                m_strCompanyName = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property



        Public Property EstimatedTimeReq() As Decimal
            Get
                EstimatedTimeReq = m_dcEstimatedTimeReq
            End Get
            Set(ByVal value As Decimal)
                m_dcEstimatedTimeReq = value
            End Set
        End Property
        Public Property FileNameFront() As String
            Get
                FileNameFront = m_strFileNameFront
            End Get
            Set(ByVal value As String)
                m_strFileNameFront = value
            End Set
        End Property

        Public Property ImageFront() As Object
            Get
                ImageFront = m_imgImageFront
            End Get
            Set(ByVal value As Object)
                m_imgImageFront = value
            End Set
        End Property
        Public Property FileNameBack() As String
            Get
                FileNameBack = m_strFileNameBack
            End Get
            Set(ByVal value As String)
                m_strFileNameBack = value
            End Set
        End Property

        Public Property ImageBack() As Object
            Get
                ImageBack = m_imgImageBack
            End Get
            Set(ByVal value As Object)
                m_imgImageBack = value
            End Set
        End Property
        Public Property Isactive() As Boolean
            Get
                Isactive = m_bIsactive
            End Get
            Set(ByVal value As Boolean)
                m_bIsactive = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetforAll() As DataTable
            Dim Str As String

            Str = "Select * from  JobOrderdatabase Where JobOrderID not in (Select POID From TNAChart) order by JobOrderID"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Getforedit(ByVal lJobOrderID As Long) As DataTable
            Dim Str As String
            If lJobOrderID = 0 Then
                Str = "Select * from  JobOrderdatabase Where JobOrderID not in (Select POID From TNAChart) order by JobOrderID"
            Else
                Str = "Select * from  JobOrderdatabase Where JobOrderID not in (Select POID From TNAChart) and JobOrderID=" & lJobOrderID & " order by JobOrderID"
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetScheduleNewwithWoven() As DataTable
            Dim Str As String

            Str = "  Select   Process,Sequence,ProcessID,ScheduleTime as SchedularTime "
            Str &= "from TNAProcess where Woven=1  AND  ACTIVE=1  order by Sequence"

            Try
                Return MyBase.GetDataTable(Str)
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
        Public Function GetPurchaseOrderByPON(ByVal ljoborderID As Long) As DataTable
            Dim Str As String
            '  Str = "Select * from PurchaseOrder PO Join PurchaseOrderDetail POD On PO.POID=POD.POID Join Style Sty on Sty.StyleID=POD.StyleID where  PO.POID=" & lPOID
            Str = " Select * from Joborderdatabase  where  joborderID=" & ljoborderID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckTNA(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select * FROM TNAChart WHERE poid='" & lPOID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyleCode(ByVal StyleCode As String)
            Dim str As String
            str = "  select * from DPStyleDatabase where StyleCode ='" & StyleCode & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function BindStyleGrid()
            Dim str As String
            Try
                str = "select convert(varchar,StyleDate,103) AS StyleDatee,* from DPStyleDatabase order by CreationDate  "

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEdit(ByVal DPStyleDatabaseId As Long)
            Dim str As String
            Try
                str = " Select * from DPStyleDatabase dc"
                str &= " where DPStyleDatabaseId ='" & DPStyleDatabaseId & "'"

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace



