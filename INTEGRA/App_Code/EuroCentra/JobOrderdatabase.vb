Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class JobOrderdatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "JobOrderdatabase"
            m_strPrimaryFieldName = "Joborderid"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lJoborderid As Long
        Private m_lCustomerDatabaseID As Long
        Private m_lBrandDatabaseID As Long
        Private m_lSeasonDatabaseID As Long
        Private m_lCurrencyID As Long
        Private m_lShipmentModeID As Long
        Private m_lPaymentTermId As Long
        Private m_strJoborderNo As String
        Private m_strCustomerOrder As String
        Private m_dtOrderRecvDate As Date
        Private m_strShippingInstruction As String
        Private m_dtShipmentDate As Date
        Private m_dtCreationDate As Date
        Private m_dTimespame As Decimal
        Private m_lUserID As Long
        Private m_strSupplier As String
        Private m_strSRNO As String
        Private m_strPortOrigin As String
        Private m_strPortLoad As String
        Private m_lOriginId As Long
        Private m_lDeliveryTermId As Long
        Private m_dSRNOPOne As Decimal
        Private m_strSRNOPTwo As String
        Private m_strShipmentStatus As String
        Private m_strPONo As String
        Private m_strPORefNo As String
        Public Property PONo() As String
            Get
                PONo = m_strPONo
            End Get
            Set(ByVal value As String)
                m_strPONo = value
            End Set
        End Property
        Public Property PORefNo() As String
            Get
                PORefNo = m_strPORefNo
            End Get
            Set(ByVal value As String)
                m_strPORefNo = value
            End Set
        End Property
        Public Property ShipmentStatus() As String
            Get
                ShipmentStatus = m_strShipmentStatus
            End Get
            Set(ByVal value As String)
                m_strShipmentStatus = value
            End Set
        End Property
        Public Property SRNOPOne() As Decimal
            Get
                SRNOPOne = m_dSRNOPOne
            End Get
            Set(ByVal Value As Decimal)
                m_dSRNOPOne = Value
            End Set
        End Property
        Public Property SRNOPTwo() As String
            Get
                SRNOPTwo = m_strSRNOPTwo
            End Get
            Set(ByVal value As String)
                m_strSRNOPTwo = value
            End Set
        End Property
        Public Property DeliveryTermId() As Long
            Get
                DeliveryTermId = m_lDeliveryTermId
            End Get
            Set(ByVal Value As Long)
                m_lDeliveryTermId = Value
            End Set
        End Property
        Public Property OriginId() As Long
            Get
                OriginId = m_lOriginId
            End Get
            Set(ByVal Value As Long)
                m_lOriginId = Value
            End Set
        End Property
        Public Property Supplier() As String
            Get
                Supplier = m_strSupplier
            End Get
            Set(ByVal value As String)
                m_strSupplier = value
            End Set
        End Property
        Public Property SRNO() As String
            Get
                SRNO = m_strSRNO
            End Get
            Set(ByVal value As String)
                m_strSRNO = value
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
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property

        Public Property Joborderid() As Long
            Get
                Joborderid = m_lJoborderid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderid = Value
            End Set
        End Property
        Public Property CustomerDatabaseID() As Long
            Get
                CustomerDatabaseID = m_lCustomerDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lCustomerDatabaseID = Value
            End Set
        End Property
        Public Property BrandDatabaseID() As Long
            Get
                BrandDatabaseID = m_lBrandDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lBrandDatabaseID = Value
            End Set
        End Property
        Public Property SeasonDatabaseID() As Long
            Get
                SeasonDatabaseID = m_lSeasonDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseID = Value
            End Set
        End Property
        Public Property CurrencyID() As Long
            Get
                CurrencyID = m_lCurrencyID
            End Get
            Set(ByVal Value As Long)
                m_lCurrencyID = Value
            End Set
        End Property
        Public Property ShipmentModeID() As Long
            Get
                ShipmentModeID = m_lShipmentModeID
            End Get
            Set(ByVal Value As Long)
                m_lShipmentModeID = Value
            End Set
        End Property
        Public Property PaymentTermId() As Long
            Get
                PaymentTermId = m_lPaymentTermId
            End Get
            Set(ByVal Value As Long)
                m_lPaymentTermId = Value
            End Set
        End Property
        Public Property JoborderNo() As String
            Get
                JoborderNo = m_strJoborderNo
            End Get
            Set(ByVal value As String)
                m_strJoborderNo = value
            End Set
        End Property

        Public Property CustomerOrder() As String
            Get
                CustomerOrder = m_strCustomerOrder
            End Get
            Set(ByVal value As String)
                m_strCustomerOrder = value
            End Set
        End Property
        Public Property OrderRecvDate() As Date
            Get
                OrderRecvDate = m_dtOrderRecvDate
            End Get
            Set(ByVal value As Date)
                m_dtOrderRecvDate = value
            End Set
        End Property
        Public Property ShippingInstruction() As String
            Get
                ShippingInstruction = m_strShippingInstruction
            End Get
            Set(ByVal value As String)
                m_strShippingInstruction = value
            End Set
        End Property
        Public Property ShipmentDate() As Date
            Get
                ShipmentDate = m_dtShipmentDate
            End Get
            Set(ByVal value As Date)
                m_dtShipmentDate = value
            End Set
        End Property
        Public Property Timespame() As Decimal
            Get
                Timespame = m_dTimespame
            End Get
            Set(ByVal value As Decimal)
                m_dTimespame = value
            End Set
        End Property
        
        Public Property PortOrigin() As String
            Get
                PortOrigin = m_strPortOrigin
            End Get
            Set(ByVal Value As String)
                m_strPortOrigin = Value
            End Set
        End Property
        Public Property PortLoad() As String
            Get
                PortLoad = m_strPortLoad
            End Get
            Set(ByVal Value As String)
                m_strPortLoad = Value
            End Set
        End Property

        Public Function SaveJobOrder()
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
        Public Function GetAllItem() As DataTable
            Dim str As String
            str = " select * from  ItemDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllUOM() As DataTable
            Dim str As String
            str = "select * from UnitOfMeasurement"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonno() As DataTable
            Dim str As String
            str = "  select top 1 Season from DPIMST"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function SRNOShow(ByVal SRNO As String, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = "select * from JobOrderDatabase where SRNO='" & SRNO & "' and SeasonDatabaseID= ' " & SeasonDatabaseID & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAccessorieseCostNew(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from AccCheckListCostMst where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSRNO() As DataTable
            Dim str As String
            str = "select  top 1 SRNO,JobOrderID from JobOrderDatabase order by JoborderId desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastStyle() As DataTable
            Dim str As String
            str = "select  top 1 Style,JoborderDetailid from JobOrderdatabaseDetail order by JobOrderDetailID desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateStyle(ByVal Style As String)
            Dim str As String

            str = " UPDATE JobOrderdatabaseDetail SET Style = replace(Style,'\', '/') where Style like '%''%'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSRNONew2(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = "select  top 1 SRNO,JobOrderID,SRNOPOne,SRNOPTwo from JobOrderDatabase where SeasonDatabaseID= ' " & SeasonDatabaseID & " ' order by JoborderId desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSRNONew(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = "select  top 1 SRNO,JobOrderID from JobOrderDatabase where SeasonDatabaseID= ' " & SeasonDatabaseID & " ' order by JoborderId desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSRNONewForMove(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            str = "select   SRNO,JobOrderID from JobOrderDatabase where SeasonDatabaseID= ' " & SeasonDatabaseID & " ' order by SRNO "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllUOMss() As DataTable
            Dim str As String
            str = "select * from UnitOfMeasurement"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllStyleDescription() As DataTable
            Dim str As String
            str = "select * from StyleDescription"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrency() As DataTable
            Dim str As String
            str = " select * from Currency "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " Select * from JobOrderdatabase where Joborderid=" & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterStyle(ByVal Joborderid As Long) As DataTable
            Dim str As String

            str = " Select Distinct Style from  JobOrderDatabaseDetail "
            str &= " where Joborderid= '" & Joborderid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterStyleForFabric(ByVal Joborderid As Long) As DataTable
            Dim str As String

            str = " Select Distinct Style from  JobOrderDatabaseDetail "
            str &= " where Joborderid= '" & Joborderid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterStyleMarchandising(ByVal Joborderid As Long) As DataTable
            Dim str As String

            str = " Select Distinct Style from  JobOrderDatabaseDetail "
            str &= " where Joborderid= '" & Joborderid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterForExport(ByVal Joborderid As Long) As DataTable
            Dim str As String
            'str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,"
            'str &= " (select Sum(JOD.Quantity) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as Quantity,"
            'str &= " (select distinct Convert(varchar,JOD.StyleShipmentDate,103) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as StyleShipmentDatee"
            'str &= " from JobOrderdatabase  JO "
            'str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= "   ,isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId "
            str &= " and SAM.joborderdetailid=JDD.joborderdetailid ),0)as ExtraQuantity,JO.ShipmentStatus as ShipmentStatuss"
            str &= "  ,isnull((select top 1 InspectionDate  "
            str &= " from ConMST CMM "
            str &= " JOIN ConDtl CDD on CDD.ConMstID =cmm.ConMstID"
            str &= " where  CMM.JobOrderId =JO.Joborderid ),'') as InspectionDate"
            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.Joborderid= '" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMaster(ByVal Joborderid As Long) As DataTable
            Dim str As String
            'str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,"
            'str &= " (select Sum(JOD.Quantity) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as Quantity,"
            'str &= " (select distinct Convert(varchar,JOD.StyleShipmentDate,103) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as StyleShipmentDatee"
            'str &= " from JobOrderdatabase  JO "
            'str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
           str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.Joborderid= '" & Joborderid & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterForSearchingForExport(ByVal Joborderid As Long, ByVal SeasonName As String) As DataTable
            Dim str As String
            'str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,"
            'str &= " (select Sum(JOD.Quantity) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as Quantity,"
            'str &= " (select distinct Convert(varchar,JOD.StyleShipmentDate,103) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as StyleShipmentDatee"
            'str &= " from JobOrderdatabase  JO "
            'str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= "   ,isnull((select top 1 SAM.ExtraQty from StyleAssortmentMaster SAM where SAM.joborderId=jo.joborderId "
            str &= " and SAM.joborderdetailid=JDD.joborderdetailid ),0)as ExtraQuantity,JO.ShipmentStatus as ShipmentStatuss"

            str &= "  ,isnull((select top 1 InspectionDate  "
            str &= " from ConMST CMM "
            str &= " JOIN ConDtl CDD on CDD.ConMstID =cmm.ConMstID"
            str &= " where  CMM.JobOrderId =JO.Joborderid ),'') as InspectionDate"

            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.Joborderid= '" & Joborderid & "' AND sd.SeasonName='" & SeasonName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterForSearchingNewFor(ByVal Joborderid As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            'str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,"
            'str &= " (select Sum(JOD.Quantity) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as Quantity,"
            'str &= " (select distinct Convert(varchar,JOD.StyleShipmentDate,103) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as StyleShipmentDatee"
            'str &= " from JobOrderdatabase  JO "
            'str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.Joborderid= '" & Joborderid & "' AND JO.SeasonDatabaseID='" & SeasonDatabaseID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterForSearching(ByVal Joborderid As Long, ByVal SeasonName As String) As DataTable
            Dim str As String
            'str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,"
            'str &= " (select Sum(JOD.Quantity) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as Quantity,"
            'str &= " (select distinct Convert(varchar,JOD.StyleShipmentDate,103) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as StyleShipmentDatee"
            'str &= " from JobOrderdatabase  JO "
            'str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.Joborderid= '" & Joborderid & "' AND sd.SeasonName='" & SeasonName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMasterForFabric(ByVal Joborderid As Long) As DataTable
            Dim str As String
            'str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,"
            'str &= " (select Sum(JOD.Quantity) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as Quantity,"
            'str &= " (select distinct Convert(varchar,JOD.StyleShipmentDate,103) from JobOrderDatabaseDetail JOD "
            'str &= " where JOD.Joborderid=JO.Joborderid) as StyleShipmentDatee"
            'str &= " from JobOrderdatabase  JO "
            'str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " where JO.Joborderid= '" & Joborderid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNew() As DataTable
            Dim str As String
            If UserID = 24 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"
                str &= " where JO.JobOrderNo='TFA-JO-00010' or JO.JobOrderNo='TFA-JO-00011' or JO.JobOrderNo='TFA-JO-00012' or JO.JobOrderNo='TFA-JO-00013' or JO.JobOrderNo='TFA-JO-00015' or JO.JobOrderNo='TFA-JO-00016'"
                str &= " or JO.JobOrderNo='TFA-JO-00018' or JO.JobOrderNo='TFA-JO-00019' or JO.JobOrderNo='TFA-JO-00020' "
            ElseIf UserID = 21 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"
                str &= " where JO.JobOrderNo='TFA-JO-00014' or JO.JobOrderNo='TFA-JO-00017'"
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateShipmentStatusFalse(ByVal JobOrderID As Long)
            Dim str As String
            str = " UPDATE  JobOrderdatabase SET ShipmentStatus=0  where JobOrderID ='" & JobOrderID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorStatusFalseForPORecvGodownTransfer(ByVal GodownIssueID As Long)
            Dim str As String
            str = " UPDATE  IMSGodownIssue SET AuditorStatus=0  where GodownIssueID ='" & GodownIssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorStatusFalseForPORecvIssue(ByVal IssueID As Long)
            Dim str As String
            str = " UPDATE  IssueMst SET AuditorStatus=0  where IssueID ='" & IssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorStatusFalseForPORecv(ByVal PORecvMasterID As Long)
            Dim str As String
            str = " UPDATE  PORecvMaster SET AuditorStatus=0  where PORecvMasterID ='" & PORecvMasterID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorIDFalseForGodownIssue(ByVal GodownIssueID As Long)
            Dim str As String
            str = " UPDATE  IMSGodownIssue SET AuditorID=0  where GodownIssueID ='" & GodownIssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorIDFalseForPOIssue(ByVal IssueID As Long)
            Dim str As String
            str = " UPDATE  IssueMst SET AuditorID=0  where IssueID ='" & IssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorIDFalseForPORecv(ByVal PORecvMasterID As Long)
            Dim str As String
            str = " UPDATE  PORecvMaster SET AuditorID=0  where PORecvMasterID ='" & PORecvMasterID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDClosed(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select * from POMASTER "
            str &= " where ClosedStatus=1 AND POID='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorStatusFalseClosed(ByVal POID As Long)
            Dim str As String
            str = " UPDATE  POMAster SET ClosedStatus=0  where POID ='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorClosedStatus(ByVal POID As Long)
            Dim str As String
            str = " UPDATE  POMAster SET ClosedStatus=1  where POID ='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function AuditorIDFalse(ByVal POID As Long)
            Dim str As String
            str = " UPDATE  POMAster SET AuditorID=0  where POID ='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorStatusFalse(ByVal POID As Long)
            Dim str As String
            str = " UPDATE  POMAster SET AuditorStatus=0  where POID ='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function AuditorStatus(ByVal POID As Long)
            Dim str As String
            str = " UPDATE  POMAster SET AuditorStatus=1  where POID ='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateAuditorIDForPOGowonIssueee(ByVal GodownIssueID As Long, ByVal AuditorID As Long)
            Dim str As String
            str = " UPDATE  IMSGodownIssue SET AuditorID='" & AuditorID & "'  where GodownIssueID ='" & GodownIssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateAuditorIDForPOIssue(ByVal IssueID As Long, ByVal AuditorID As Long)
            Dim str As String
            str = " UPDATE  IssueMst SET AuditorID='" & AuditorID & "'  where IssueID ='" & IssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateAuditorIDForPORecv(ByVal PORecvMAsterID As Long, ByVal AuditorID As Long)
            Dim str As String
            str = " UPDATE  PORecvMAster SET AuditorID='" & AuditorID & "'  where PORecvMAsterID ='" & PORecvMAsterID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateAuditorID(ByVal POID As Long, ByVal AuditorID As Long)
            Dim str As String
            str = " UPDATE  POMAster SET AuditorID='" & AuditorID & "'  where POID ='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function AuditorStatusForRecvGodownTransfer(ByVal GodownIssueID As Long)
            Dim str As String
            str = " UPDATE  IMSGodownIssue SET AuditorStatus=1  where GodownIssueID ='" & GodownIssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function AuditorStatusForRecvIssue(ByVal IssueID As Long)
            Dim str As String
            str = " UPDATE  IssueMst SET AuditorStatus=1  where IssueID ='" & IssueID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function AuditorStatusForRecv(ByVal PORecvMasterID As Long)
            Dim str As String
            str = " UPDATE  PORecvMaster SET AuditorStatus=1  where PORecvMasterID ='" & PORecvMasterID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateShipmentStatus(ByVal JobOrderID As Long)
            Dim str As String
            str = " UPDATE  JobOrderdatabase SET ShipmentStatus=1  where JobOrderID ='" & JobOrderID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew() As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

          


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANewwwwwww() As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.UserID in (245) or u.Department ='Merchandising' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

           


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForLatest(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "') and or u.Department ='Merchandising' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFA222(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "')  or u.Department ='Merchandising'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFA(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269)  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew4DirectorVise() As DataTable
            Dim str As String
          
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew4(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',245)  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew2New(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where u.Department ='Merchandising'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew2(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID='" & UserID & "' or  JO.UserID=256 or  JO.UserID=257 or JO.UserID=258 or JO.UserID=259 or JO.UserID=260 or JO.UserID=261 or JO.UserID=262 or JO.UserID=263 or   JO.UserID=268 or JO.UserID=269"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew3ForDirectorView() As DataTable
            Dim str As String
      
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew3(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID='" & UserID & "' or JO.UserID=245 "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFANew(ByVal UserID) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNew() As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNewnEWW(ByVal UserID As Long) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
                str &= " from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "') OR u.Department ='Merchandising'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNew(ByVal UserID As Long) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
                str &= " from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269)"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDAL(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
               str &= " from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID='" & UserID & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNew2ForDirectorView() As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNew2(ByVal UserID) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
                str &= " from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',245)  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNew2ForExportnEWWW() As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where  u.Department ='Merchandising' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForDALNew2ForExport() As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee"
            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.UserID in (245,256,257,258,259,260,261,262,263,268,269)  "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingNew(ByVal SeasonName As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where sd.SeasonName= '" & SeasonName & "'"
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingForExportfORnEWW(ByVal SeasonName As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where  u.Department ='Merchandising' and sd.SeasonName= '" & SeasonName & "'"
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingForExportYasir(ByVal UserID As Long, ByVal SeasonName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "') or u.Department ='Merchandising' and sd.SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  sd. SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingForExport(ByVal UserID As Long, ByVal SeasonName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',256,257,258,259,260,261,262,263,268,269) and sd.SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  sd. SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearching(ByVal UserID As Long, ByVal SeasonName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID='" & UserID & "' and sd.SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  sd. SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function ViewNewForTFAForSearchingNew(ByVal UserID As Long, ByVal SeasonName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID='" & UserID & "' and sd.SeasonName= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  sd. SeasonDatabaseID= '" & SeasonName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingNew2ForDirectorView(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
          
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  JO. SeasonDatabaseID= '" & SeasonDatabaseID & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

       
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingNew2(ByVal UserID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',245)  and JO.SeasonDatabaseID= '" & SeasonDatabaseID & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  JO. SeasonDatabaseID= '" & SeasonDatabaseID & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSearchingNew(ByVal UserID As Long, ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263) and JO.SeasonDatabaseID= '" & SeasonDatabaseID & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID "
                str &= " where  JO. SeasonDatabaseID= '" & SeasonDatabaseID & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomerNew(ByVal CustomerName As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where CD.CustomerName='" & CustomerName & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomerForNMewww(ByVal CustomerName As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where   u.Department ='Merchandising' and CD.CustomerName='" & CustomerName & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
         


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomer(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269) and CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where  CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomer2222(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "')  or u.Department ='Merchandising' and CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where  CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomerNewForDirectorView(ByVal CustomerName As String) As DataTable
            Dim str As String
           
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where  CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomerNewNew(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',245) and CD.CustomerName='" & CustomerName & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where  CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForCustomerNew(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',245) and CD.CustomerName='" & CustomerName & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where  CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNONewww(ByVal SRNO As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where    u.Department ='Merchandising' and JO.SRNO='" & SRNO & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNO222(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where    JO.UserID in ('" & UserID & "')  or u.Department ='Merchandising' and JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNO(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where    JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269) and JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNONew3ForDirectorVise(ByVal SRNO As String) As DataTable
            Dim str As String
           
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNONew3(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',245) and JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNONew3Neww(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',245) and JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDNewForrecvGodownTransfer(ByVal GodownIssueID As Long) As DataTable
            Dim str As String
            str = " Select * from IMSGodownIssue "
            str &= " where AuditorStatus=0 AND GodownIssueID='" & GodownIssueID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDNewForrecvIssue(ByVal IssueID As Long) As DataTable
            Dim str As String
            str = " Select * from IssueMst "
            str &= " where AuditorStatus=0 AND IssueID='" & IssueID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDNewForrecv(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String
            str = " Select * from PORecvMaster "
            str &= " where AuditorStatus=0 AND PORecvMasterID='" & PORecvMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDNew(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select * from POMASTER "
            str &= " where AuditorStatus=0 AND POID='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDForPOrecvGodownTransfer(ByVal GodownIssueID As Long) As DataTable
            Dim str As String
            str = " Select * from IMSGodownIssue "
            str &= " where AuditorStatus=1 AND GodownIssueID='" & GodownIssueID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDForPOrecvIssue(ByVal IssueID As Long) As DataTable
            Dim str As String
            str = " Select * from IssueMst "
            str &= " where AuditorStatus=1 AND IssueID='" & IssueID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOIDForPOrecv(ByVal PORecvMasterID As Long) As DataTable
            Dim str As String
            str = " Select * from PORecvMaster "
            str &= " where AuditorStatus=1 AND PORecvMasterID='" & PORecvMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckAlreadyCheckPOID(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select * from POMASTER "
            str &= " where AuditorStatus=1 AND POID='" & POID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForSRNONew(ByVal SRNO As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.SRNO='" & SRNO & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
           


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForStyleNew(ByVal Style As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JDD.Style='" & Style & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForStyleForNew(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   u.Department ='Merchandising' and JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForPONo(ByVal UserID As Long, ByVal PONo As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   u.Department ='Merchandising' and JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForPONoNew(ByVal UserID As Long, ByVal PONo As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   u.Department ='Merchandising' and JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForStyle(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269) and JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForStyle222(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "')  or u.Department ='Merchandising' and JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForStyleNewForDirectorVise(ByVal Style As String) As DataTable
            Dim str As String
         
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
         

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAForStyleNew(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',245) and JDD.Style='" & Style & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCheckExistingModelNo(ByVal Model As String) As DataTable
            Dim str As String
            str = " Select * from joborderdatabase "
            str &= " where Model='" & Model & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ForfabricView() As DataTable
            Dim str As String
            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewMarchandising() As DataTable
            Dim str As String
            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View1() As DataTable
            Dim str As String
            str = " Select *  from JobOrderdatabase  JO "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewInfo(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " Select *  from JobOrderdatabase  JO "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " where Joborderid=" & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewInfo1(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " Select *  from JobOrderdatabase  JO "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= "  join CheckList C on C.Joborderid=JO.Joborderid"
            str &= " join CheckListDetail CL on CL.CheckListID=C.CheckListID"
            str &= " where Jo.Joborderid=" & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewKnitting() As DataTable
            Dim str As String
            str = " Select JO.JoborderID,S.StyleiD,CD.CustomerName,JO.JoborderNo,S.Style,"
            str &= " isnull((Select SUm(Quantity) from JobOrderDatabaseDetail  JDD where JDD.StyleiD=S.StyleiD),0) As Quantity,"
            str &= " Convert(varchar,jo.ShipmentDate,103) as ShipmentDate,"
            str &= " isnull((Select SUm(FC.GrossCalc) from JobOrderDatabaseDetail  JDD"
            str &= " join FabricationCalculation FC on FC.JoborderDetailID=JDD.JoborderDetailID "
            str &= " where JDD.StyleiD=S.StyleiD),0) As Weight"
            str &= " from JobOrderdatabase  JO  "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join Style S on S.JoborderID=JO.JoborderID"
            str &= " where JO.JoborderID in (Select JoborderID from FabricationMaster) and S.Style in (Select distinct Style from FabricationMaster FM join JobOrderDatabaseDetail JDD on  FM.JoborderDetailID=JDD.JoborderDetailID  ) "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierCertificate() As DataTable
            Dim str As String
            str = " select C.CertificateID,SC.SupplierCertificateID,Status='False',"
            str &= " C.Certificate,convert(varchar,SC.CertificateExpire,103) as CertificateExpire from Certificate C "
            str &= " join SupplierCertificate SC on SC.CertificateID=C.CertificateID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTestRequired() As DataTable
            Dim str As String
            str = " select *,Status='False' from testingdatabase "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetScheduleNew() As DataTable
            Dim Str As String
            Str = "  Select Process,Sequence,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
            Str &= " where ProcessID in (64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,104,105,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97)"
            Str &= " order by Sequence"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        ' Public Function GetAllPO(ByVal Joborderid As Long, ByVal StyleID As Long) As DataTable
        Public Function GetAllPO(Optional ByVal Joborderid As Long = 0) As DataTable
            Dim Str As String
            ' Str = "Select top 1 *  from  JobOrderDatabaseDetail JDD join JobOrderDatabase JD on JD.Joborderid=JDD.Joborderid Where JDD.StyleID not in (Select StyleID From TNAChart) and JD.Joborderid=" & Joborderid & " and JDD.StyleID=" & StyleID & " order by JD.Joborderid"


            If Joborderid = 0 Then

                Str = "Select * from  JobOrderDatabase Where Joborderid not in (Select Joborderid From TNAChart) order by Joborderid"
            Else
                Str = "Select * from  JobOrderDatabase Where Joborderid not in (Select Joborderid From TNAChart) and Joborderid=" & Joborderid & " order by Joborderid"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetJobInfo(ByVal Joborderid As Long) As DataTable
            Dim Str As String
            Str = "Select * from  JobOrderDatabaseDetail JDD join JobOrderDatabase JD on JD.Joborderid=JDD.Joborderid Where JDD.StyleID not in (Select StyleID From TNAChart) and JD.Joborderid=" & Joborderid
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTNAInfo(ByVal JobOrderID As Long) As DataTable
            Dim str As String
            str = " Select * from JobOrderDatabase JO "
            str &= " join JobOrderDatabaseDetail JDD on JO.Joborderid=JDD.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " where JO.JobOrderID=" & JobOrderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDescriptionAndPrice(ByVal DPRNDID As Long) As DataTable
            Dim str As String
            str = " Select Description,Price from DPRNDStyleDetail"
            str &= " where DPRNDID='" & DPRNDID & "' and IsBodyFabric=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBindGrid(ByVal DPRNDID As Long) As DataTable
            Dim str As String
            str = "  DECLARE @listStr VARCHAR(4000)"
            str &= " SELECT  "
            str &= " @listStr =COALESCE ( COALESCE(@listStr+',' ,'') + RNDAA.ItemName , @listStr)"
            str &= " from TblDPRND RNDD"
            str &= " JOIN DPRNDAccessDetail RNDAA on RNDAA.DPRNDID=RNDD.DPRNDID"
            str &= "  WHERE RNDD.DPRNDID = '" & DPRNDID & "'"
            str &= " SELECT @listStr as POOO FROM  TblDPRND  RND"
            str &= " JOIN DPRNDAccessDetail RNDA on RNDA.DPRNDID=RND.DPRNDID"
            str &= " where Rnd.DPRNDID = '" & DPRNDID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPItem(ByVal DPRNDID As String) As DataTable
            Dim str As String
            str &= " SELECT DIT.DPItemDatabaseid,DPItemName from DPRNDAccessDetail RNDAA "
            str &= " join DPItemDatabase DIT ON DIT.DPItemDatabaseid=RNDAA.DPItemDatabaseid"
            str &= " WHERE RNDAA.DPRNDID = '" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPItemDesc(ByVal StyleCode As String) As DataTable
            Dim str As String
            str = " select * from DPStyleDatabase"
            str &= " where StyleCode='" & StyleCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPItemDescNew(ByVal StyleCode As String) As DataTable
            Dim str As String
            str = " select * from DPStyleDatabase"
            str &= " where REPLACE(StyleCode, '/', '\')='" & StyleCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetSupplierArtNo(ByVal FabricDbMstID As Long, ByVal DPRNDID As Long) As DataTable
            Dim str As String
            str = " select * from DPFabricDbMst Mst"
            str &= " join TblDPRND RND on RND.FabricDbMstID=Mst.FabricDbMstID"
            str &= " where Mst.FabricDbMstID='" & FabricDbMstID & "' and RND.DPRNDID='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDalNoFromJobOrder(ByVal SupplierID As Long) As DataTable
            Dim str As String
            str = " Select * from DPFabricDbMst "
            str &= " where SupplierID=" & SupplierID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierID(ByVal SupplierName As String) As DataTable
            Dim str As String
            str = " Select SupplierDatabaseID from SupplierDatabase "
            str &= " where SupplierName='" & SupplierName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabricDBMstID(ByVal DalNo As String) As DataTable
            Dim str As String
            str = " Select FabricDBMstID from DPFabricDbMst "
            str &= " where DalNo='" & DalNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
      
        Public Function GetDPRNDID(ByVal Style As String) As DataTable
            Dim str As String
            str = " Select DPRNDID from TblDPRND "
            str &= " where Style='" & Style & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDPRNDIDNew(ByVal Style As String) As DataTable
            Dim str As String
            'str = " Select * from TblDPRND TBD JOIN DPFabricDbMst FD ON FD.FabricDBMstId =TBD.FabricDBMstId"
            'str &= " where Style='" & Style & "'"
            str = "Select FabricQuality+' '+DPTypeName+' '+CompositionName+' '+FinishName+' '+DyeName  as FabricQualityy,* from TblDPRND TBD "
            str &= " JOIN DPFabricDbMst FD ON FD.FabricDBMstId =TBD.FabricDBMstId"
            str &= " join Composition C ON C.CompositionId=FD.CompositionId"
            str &= " Join DPType DPT ON DPT.DPTypeid=fd.DPTypeid"
            str &= " join DPFinish DF ON DF.FinishID=fd.FinishID"
            str &= " JOIN DPDye DDP ON DDP.DYEID=fd.DYEID"
            str &= " where Style='" & Style & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemDataCode(ByVal Itemcode As String) As DataTable
            Dim str As String
            'str = " Select * from TblDPRND TBD JOIN DPFabricDbMst FD ON FD.FabricDBMstId =TBD.FabricDBMstId"
            'str &= " where Style='" & Style & "'"
            str = " select *,ItemQuality +' '+ ItemComposition +' '+ ItemFinish +' '+ItemWashDye as FabricQualityy"
            str &= "  from IMSITEM WHERE FabricDBMstId >0 and ItemCodee ='" & Itemcode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemDataCodeNewForFabricCalculationAndSRNO(ByVal Itemcode As String, ByVal SeasonDatabaseId As Long) As DataTable
            Dim str As String

            str = " select distinct JO.JobOrderID,JO.SRno from joborderdatabase JO"
            str &= "  join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid "
            str &= "  JOIN SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= "  WHERE JOD.ItemCode ='" & Itemcode & "' and SD.SeasonDatabaseId='" & SeasonDatabaseID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemDataCodeNewForFabricCalculation(ByVal Itemcode As String) As DataTable
            Dim str As String

            str = " select distinct SD.SeasonDatabaseID,SD.SeasonName from joborderdatabase JO"
            str &= "  join JobOrderdatabaseDetail JOD on JOD.Joborderid =JO.Joborderid "
            str &= "  JOIN SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            str &= "  WHERE JOD.ItemCode ='" & Itemcode & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemDataCodeNew(ByVal Itemcode As String) As DataTable
            Dim str As String
          

            str = " select *,ItemQuality +' '+ ItemComposition +' '+ ItemFinish +' '+ItemWashDye as FabricQualityy  "
            str &= " from IMSITEM ITD"
            str &= " join IMSItemCategory ITC on ITC.IMSItemCategoryID=ITD.IMSItemCategoryID"
            str &= " JOIN IMSItemClass ITCL on ITCL.IMSItemClassID=ITC.IMSItemClassID"
            str &= "  WHERE ITCL.StoreTypeId=1 and ItemCodee ='" & Itemcode & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemDataCodeForDalRefNo(ByVal Itemcode As String) As DataTable
            Dim str As String


            str = " select *,ItemQuality +' '+ ItemComposition +' '+ ItemFinish +' '+ItemWashDye as FabricQualityy  "
            str &= " from IMSITEM ITD"
            str &= " join IMSItemCategory ITC on ITC.IMSItemCategoryID=ITD.IMSItemCategoryID"
            str &= " JOIN IMSItemClass ITCL on ITCL.IMSItemClassID=ITC.IMSItemClassID"
            str &= "  WHERE ITCL.StoreTypeId=1 and DalRefNo ='" & Itemcode & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetForEdit(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee, "
            str &= " Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee,JDD.UOMID as UNITID from JobOrderdatabase  JO"
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid "
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID "
            str &= " join BrandDatabase BD on BD.BrandDatabaseID = jo.BrandDatabaseID "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID= jo.SeasonDatabaseID "
            str &= " join Currency C on C.CurrencyID=jo.CurrencyID "
            str &= " join ShipmentMode SM on sm.ShipmentModeID=jo.ShipmentModeID "
            str &= " left join ItemDatabase ID  on id.ItemDatabaseID= JDD.ItemDatabaseID "
            str &= " join UnitofMeasurement UOM on UOM.UOMID=JDD.UOMID "
            str &= " where JO.Joborderid=" & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetForMovePopup(ByVal JoborderDetailid As Long) As DataTable
            Dim str As String
            str = " Select * from JobOrderdatabase  JO"
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid "
            str &= " where JDD.JoborderDetailid=" & JoborderDetailid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetJobOrderCertificateRequiredPopup(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = "  select Convert(varchar,SC.CertificateExpire,103) as CertificateExpire,* from JobOrderCertificateRequired JOCR  "
            str &= "join certificate C on C.CertificateID=JOCR.CertificateID "
            str &= "join SupplierCertificate SC on SC.SupplierCertificateID=JOCR.SupplierCertificateID "
            str &= " where JOCR.JobOrderID=" & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetJobOrderTestRequiredPopup(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = "  select * from JobOrderTestRequired JOTR  "
            str &= "join TestingDatabase TD on td.TestingDatabaseID= JOTR.TestingdatabaseID "
            str &= " where JOTR.JobOrderID=" & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckJobOrderCertificateIdExist(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderCertificateRequired "
            str &= " where JobOrderID = " & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckTestRequiredIDExist(ByVal Joborderid As Long) As DataTable
            Dim str As String
            str = " select * from JobOrderTestRequired  "
            str &= "  where JobOrderID = " & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function AutoJobNo()
            Dim str As String
            str = " select top 1 JoborderNo from JobOrderdatabase order by Joborderid DESC "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function AllJobNo()
            Dim str As String
            str = " select * from JobOrderdatabase order by Joborderid DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetShipmentDate(ByVal Joborderid As Long)
            Dim str As String
            str = " select convert(varchar,ShipmentDate,103) as ShipmentDate from JobOrderdatabase   "
            str &= "  where JobOrderID = " & Joborderid
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomer(ByVal Joborderid As Long)
            Dim str As String
            str = " Select CD.CustomerName from JobOrderdatabase  JO "
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"
            str &= "  where JO.JobOrderID = " & Joborderid
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyle(ByVal Joborderid As Long)
            Dim str As String
            str = "  Select distinct JDD.style  from JobOrderdatabase  JO  "
            str &= "  join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid "
            str &= "  join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID "
            str &= "  where JO.JobOrderID = " & Joborderid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleQty(ByVal Joborderid As Long, ByVal style As String)
            Dim str As String
            str = " select Sum(quantity) as quantity from JobOrderDatabaseDetail "
            str &= " where  Joborderid = " & Joborderid
            str &= " and style='" & style & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function AllYarnCount()
            Dim str As String
            str = " select * from YarnDatabase  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function AllPendingJobNo()
            Dim str As String
            str = " select * from JobOrderdatabase  "
            str &= " where Joborderid not in (select distinct Joborderid from YarnConsumption) "
            str &= " and Joborderid in (select distinct Joborderid from KnittingProgram) "
            str &= " order by Joborderid DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetPOStyleNO(ByVal Joborderid As Long)
            Dim Str As String

            Str = " Select distinct JOD.Style"
            Str &= " ,Jo.Joborderno From JobOrderdatabase JO"
            Str &= " join JobOrderdatabaseDetail JOD on JO.Joborderid=JOD.Joborderid"
            Str &= " Where JO.Joborderid='" & Joborderid & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckNumbering(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
          
            Str = "  Select * from NumberingDtl  "
            Str &= " where JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckAssortmentData(ByVal JobOrderId As Long) As DataTable
            Dim Str As String

            Str = "  Select * from StyleAssortmentMaster  "
            Str &= " where JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckStyle(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            'Str = "   Select * from StyleMasterDatabase sd"
            ' Str &= " join Style_SubStyle ss on sd.StyleMasterDatabaseID=ss.StyleMasterDatabaseID where  JoborderID='" & JobOrderId & "'"

            Str = "  Select * from StyleAssortmentMaster sd "
            Str &= " join StyleAssortmentDetail ss on sd.StyleAssortmentMasterId=ss.StyleAssortmentMasterId"
            Str &= " where JobOrderId = '" & JobOrderId & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckFabricPlane(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from FPlanMstNew where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckFabricPlaneNew(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from FabricCostMst where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckAccessoriesePlane(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from AccessoriesePlanMst where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckAccessoriesePlaneNew(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   Select * from AccessoriesCostMst where  JoborderID='" & JobOrderId & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindGridForDigital(ByVal ddljoborder As Long, ByVal ProductionTypeid As Long) As DataTable
            Dim Str As String





            Str = " Select *,"
            Str &= " isnull((select Sum(ProductedToday) from ProductionDetails PD"
            Str &= " where(PD.JobOrderDetailID = JOD.JobOrderDetailID)"
            Str &= " and SS.Style_SubStyleID = PD.Style_SubStyleID),0.00) as ProductedToday,"

            Str &= " isnull((select Sum(ProductedToday)- Sum(MinimizeQty) from ProductionMaster PM join ProductionDetails PD"
            Str &= " on PD.ProductionMasterID=PM.ProductionMasterID where PD.JobOrderDetailID = JOD.JobOrderDetailID"
            Str &= " and SS.Style_SubStyleID = PD.Style_SubStyleID"
            Str &= " and PM.ProductionTypeID='" & ProductionTypeid & "' and PM.JobOrderID  ='" & ddljoborder & "'),0.00) as ProductedTodayIndivisiual,"

            Str &= " isnull((select distinct WD.CodeName from WashingDatabase WD "
            Str &= " join  Style_SubStyleAssortment SAM  on"
            Str &= " SAM.WashingDatabaseID = WD.WashingDatabaseID"
            Str &= " where(SAM.Style_SubStyleID = SS.Style_SubStyleID)"
            Str &= " and SAM.StyleMasterDatabaseID=SD.StyleMasterDatabaseID),'N/A') as CodeName"

            Str &= " from JobOrderdatabase JO"
            Str &= " join JobOrderDetail JOD on jo.JobOrderID = JOD.JobOrderID"
            Str &= " join StyleMasterDatabase SD on SD.JobOrderID =JO.JobOrderID"
            Str &= " join Style_SubStyle  SS on SS.StyleMasterDatabaseID = SD.StyleMasterDatabaseID"
            Str &= " where jo.JobOrderID = '" & ddljoborder & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindGridForDigitalNew(ByVal ddljoborder As Long, ByVal ProductionTypeid As Long) As DataTable
            Dim Str As String

            Str = " Select *,"

            Str &= " isnull((select Sum(ProductedToday)- Sum(MinimizeQty) from ProductionMaster PM join ProductionDetails PD"
            Str &= " on PD.ProductionMasterID=PM.ProductionMasterID where PD.JobOrderDetailID = JOD.JobOrderDetailID"
            Str &= " and PM.ProductionTypeID='" & ProductionTypeid & "' and PM.JobOrderID  ='" & ddljoborder & "'),0.00) as ProductedTodayIndivisiual"

            Str &= " from JobOrderdatabase JO"
            Str &= " join JobOrderdatabaseDetail JOD on jo.JobOrderID = JOD.JobOrderID"
            Str &= " where jo.JobOrderID = '" & ddljoborder & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function BindGrid(ByVal ddljoborder As Long, ByVal ProductionTypeid As Long) As DataTable
            Dim Str As String





            'Str = " Select *,"
            'Str &= " isnull((select Sum(ProductedToday) from ProductionDetails PD"
            'Str &= " where(PD.JobOrderDetailID = JOD.JobOrderDetailID)"
            'Str &= " and SS.Style_SubStyleID = PD.Style_SubStyleID),0.00) as ProductedToday,"

            'Str &= " isnull((select Sum(ProductedToday)- Sum(MinimizeQty) from ProductionMaster PM join ProductionDetails PD"
            'Str &= " on PD.ProductionMasterID=PM.ProductionMasterID where PD.JobOrderDetailID = JOD.JobOrderDetailID"
            'Str &= " and SS.Style_SubStyleID = PD.Style_SubStyleID"
            'Str &= " and PM.ProductionTypeID='" & ProductionTypeid & "' and PM.JobOrderID  ='" & ddljoborder & "'),0.00) as ProductedTodayIndivisiual,"

            'Str &= " isnull((select distinct WD.CodeName from WashingDatabase WD "
            'Str &= " join  Style_SubStyleAssortment SAM  on"
            'Str &= " SAM.WashingDatabaseID = WD.WashingDatabaseID"
            'Str &= " where(SAM.Style_SubStyleID = SS.Style_SubStyleID)"
            'Str &= " and SAM.StyleMasterDatabaseID=SD.StyleMasterDatabaseID),'N/A') as CodeName"

            'Str &= " from JobOrder JO"
            'Str &= " join JobOrderDetail JOD on jo.JobOrderID = JOD.JobOrderID"
            'Str &= " join StyleMasterDatabase SD on SD.JobOrderID =JO.JobOrderID"
            'Str &= " join Style_SubStyle  SS on SS.StyleMasterDatabaseID = SD.StyleMasterDatabaseID"
            'Str &= " where jo.JobOrderID = '" & ddljoborder & "'"


            'Str = " Select *, isnull((select Sum(ProductedToday) from ProductionDetails PD"
            'Str &= "  where(PD.JobOrderDetailID = JOD.JobOrderDetailID)"
            'Str &= " and SS.StyleAssortmentDetailid = PD.Style_SubStyleID),0.00) as ProductedToday,"
            'Str &= " isnull((select Sum(ProductedToday)- Sum(MinimizeQty) "
            'Str &= " from ProductionMaster PM join "
            'Str &= " ProductionDetails PD on PD.ProductionMasterID=PM.ProductionMasterID "
            'Str &= "    where(PD.JobOrderDetailID = JOD.JobOrderDetailID)"
            'Str &= " and SS.StyleAssortmentDetailid = PD.Style_SubStyleID "
            'Str &= " and PM.ProductionTypeID='" & ProductionTypeid & "' and PM.JobOrderID  ='" & ddljoborder & "'),0.00) as ProductedTodayIndivisiual"

            'Str &= " from JobOrderdatabase JO "
            'Str &= " join JobOrderdatabaseDetail JOD on jo.JobOrderID = JOD.JobOrderID "
            'Str &= " join StyleAssortmentMaster SD on SD.JobOrderID =JO.JobOrderID "
            'Str &= " join StyleAssortmentDetail  SS on SS.StyleAssortmentMasterID= SD.StyleAssortmentMasterID where jo.JobOrderID = '" & ddljoborder & "'"

            Str = " Select * ,"
            Str &= " isnull((select Sum(ProductedToday) from ProductionDetails PD  "
            Str &= " where PD.JobOrderDetailID = jd.JobOrderDetailID),0.00) as ProductedToday, "

            Str &= " isnull((select Sum(ProductedToday)- Sum(MinimizeQty)  from ProductionMaster PM "
            Str &= " join  ProductionDetails PD on PD.ProductionMasterID=PM.ProductionMasterID where"
            Str &= " PD.JobOrderDetailID = jd.JobOrderDetailID and PM.ProductionTypeID='" & ProductionTypeid & "' and PM.JobOrderID  ='" & ddljoborder & "'),0.00)"
            Str &= " as ProductedTodayIndivisiual"
            Str &= " from JobOrderdatabase jo"
            Str &= " join JobOrderdatabaseDetail jd on jo.JobOrderId=jd.JobOrderId "
            Str &= " join ItemDatabase itd on itd.ItemDatabaseID=jd.ItemDatabaseID"
            Str &= " where jo.JobOrderId='" & ddljoborder & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateQty(ByVal lJobOrderDetailID As Long, ByVal Percent As Decimal, ByVal TotalQty As Decimal)
            Dim Str As String
            Str = "update JobOrderdatabaseDetail set QtyPercent='" & Percent & "' , TotalQty='" & TotalQty & "' where JobOrderDetailID='" & lJobOrderDetailID & "'"

            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetMaxLastNo()
            Dim str As String
            str = " select  isnull(Max (convert(int,substring(JoborderNo,8,5))),0) as JoborderNo from JobOrderdatabase"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeason()
            Dim str As String
            str = " select  top 1 Season from JobOrderdatabase"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSr(ByVal SRNO As String)
            Dim str As String
            str = " select SRNO from JobOrderdatabase where SRNO Like '%" & SRNO & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function AllCustomer(ByVal CustomerName As String)
            Dim str As String
            str = "  select CustomerName from JobOrderdatabase JO"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID  where CustomerName Like '%" & CustomerName & "%' """
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetStyle(ByVal Style As String)
            Dim str As String
            str = "  select Style from JobOrderdatabase JO"
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid where Style  Like '%" & Style & "%' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ViewNewForTFACustomerNewwww(ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where  u.Department ='Merchandising'  and CD.CustomerName='" & CustomerName & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFACustomerNewwwww(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where  JO.UserID in ('" & UserID & "')  or u.Department ='Merchandising' and CD.CustomerName='" & CustomerName & "'  "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFACustomer(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where  JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269) and CD.CustomerName='" & CustomerName & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFACustomerNew2ForDirectorView(ByVal CustomerName As String) As DataTable
            Dim str As String
          
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
          

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFACustomerNew2(ByVal UserID As Long, ByVal CustomerName As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where  JO.UserID in ('" & UserID & "',245) and  CD.CustomerName='" & CustomerName & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where CD.CustomerName='" & CustomerName & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFACustomerNew(ByVal CustomerName As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JCD.CustomerName='" & CustomerName & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAStyleNew2ForDirectorView(ByVal Style As String) As DataTable
            Dim str As String
           
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAStyleNew2(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where  JO.UserID in ('" & UserID & "',245) and JDD.Style='" & Style & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAPONo(ByVal UserID As Long, ByVal PONo As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where  JO.UserID in ('" & UserID & "',245) and JO.PONo='" & PONo & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAStyleNewwww(ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   u.Department ='Merchandising' and JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAPONoNewwww(ByVal PONo As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   u.Department ='Merchandising' and JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.PONo='" & PONo & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAStyleForNew(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "')  or u.Department ='Merchandising' and JDD.Style='" & Style & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAStyle(ByVal UserID As Long, ByVal Style As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,268,269) and JDD.Style='" & Style & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JDD.Style='" & Style & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFAStyleNew(ByVal Style As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JDD.Style='" & Style & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFASrnoNewForNew(ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where    u.Department ='Merchandising' and JO.SRNO='" & SRNO & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFASrnoForlateast(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where    JO.UserID in ('" & UserID & "') or u.Department ='Merchandising' and JO.SRNO='" & SRNO & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFASrno(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where    JO.UserID in ('" & UserID & "',256 ,257 ,258 ,259,260,261,262,263,269,268) and JO.SRNO='" & SRNO & "'"
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFASrnoNewForDirectorView(ByVal SRNO As String) As DataTable
            Dim str As String
           
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "




            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFASrnoNew(ByVal UserID As Long, ByVal SRNO As String) As DataTable
            Dim str As String
            If UserID > 1 Then
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " where   JO.UserID in ('" & UserID & "',245) and JO.SRNO='" & SRNO & "'  "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "
            Else
                str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
                str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
                str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
                str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
                str &= " join UMUser u on u.UserID=JO.UserID"
                str &= " where JO.SRNO='" & SRNO & "' "
                str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "

            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewNewForTFASrnoNew(ByVal SRNO As String) As DataTable
            Dim str As String

            str = " Select *,Convert(varchar,jo.OrderRecvDate,103) as OrderRecvDatee,Convert(varchar,JDD.StyleShipmentDate,103) as StyleShipmentDatee from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail JDD on JDD.Joborderid=JO.Joborderid"
            str &= " join Customer CD on CD.CustomerID=JO.CustomerDatabaseID"
            str &= " join UMUser u on u.UserID=JO.UserID"
            str &= " join SeasonDatabase sd on sd.SeasonDatabaseID =jo.SeasonDatabaseID "
            str &= " where JO.SRNO='" & SRNO & "' "
            str &= "   order by sd.SeasonName ,jo.SRNOPONe,jo.SRNOPTwo "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class


End Namespace