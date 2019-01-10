Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class LCExportDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "LCExportDtl"
            m_strPrimaryFieldName = "LCExportDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lLCExportDtlID As Long
        Private m_lLCExportMstID As Long
        Private m_lJoborderid As Long
        Private m_lJoborderDetailid As Long
        Private m_lSeasonDatabaseID As Long
        Private m_lDPIDtlID As Long
        Private m_lCurrencyID As Long
        Private m_lPaymentTermID As Long
        Private m_lCustomerID As Long
        Private m_strSRNo As String
        Private m_strStyleNo As String
        Private m_strOrderNo As String
        Private m_strDescription As String
        Private m_dShipmentDate As Date
        Private m_dOrderQty As Decimal
        Private m_dShipmentQty As Decimal
        Private m_dBalanceQty As String
        Private m_strRemarks As String
        Private m_strsalescontractno As String
        Private m_dsalesContractQty As Decimal
        Private m_dSalesContractAmount As Decimal
        Private m_dLCAmount As Decimal
        Private m_strLCNo As String
        Private m_dPISendDate As Date
        Private m_dLCRecvDate As Date
        Private m_dLCShipDate As Date
        Private m_dLCAmdDate As Date
        Private m_strNegotiateBank As String
        Private m_strIssueBank As String
        Private m_strIssueRemarks As String

        Public Property LCExportDtlID() As Long
            Get
                LCExportDtlID = m_lLCExportDtlID
            End Get
            Set(ByVal Value As Long)
                m_lLCExportDtlID = Value
            End Set
        End Property
        Public Property LCExportMstID() As Long
            Get
                LCExportMstID = m_lLCExportMstID
            End Get
            Set(ByVal Value As Long)
                m_lLCExportMstID = Value
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
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailid = Value
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
        Public Property DPIDtlID() As Long
            Get
                DPIDtlID = m_lDPIDtlID
            End Get
            Set(ByVal Value As Long)
                m_lDPIDtlID = Value
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
        Public Property PaymentTermID() As Long
            Get
                PaymentTermID = m_lPaymentTermID
            End Get
            Set(ByVal Value As Long)
                m_lPaymentTermID = Value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal Value As Long)
                m_lCustomerID = Value
            End Set
        End Property
        Public Property SRNo() As String
            Get
                SRNo = m_strSRNo
            End Get
            Set(ByVal Value As String)
                m_strSRNo = Value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal Value As String)
                m_strStyleNo = Value
            End Set
        End Property
        Public Property OrderNo() As String
            Get
                OrderNo = m_strOrderNo
            End Get
            Set(ByVal Value As String)
                m_strOrderNo = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal Value As String)
                m_strDescription = Value
            End Set
        End Property
        Public Property ShipmentDate() As Date
            Get
                ShipmentDate = m_dShipmentDate
            End Get
            Set(ByVal Value As Date)
                m_dShipmentDate = Value
            End Set
        End Property
        Public Property OrderQty() As Decimal
            Get
                OrderQty = m_dOrderQty
            End Get
            Set(ByVal Value As Decimal)
                m_dOrderQty = Value
            End Set
        End Property
        Public Property ShipmentQty() As Decimal
            Get
                ShipmentQty = m_dShipmentQty
            End Get
            Set(ByVal Value As Decimal)
                m_dShipmentQty = Value
            End Set
        End Property
        Public Property BalanceQty() As Decimal
            Get
                BalanceQty = m_dBalanceQty
            End Get
            Set(ByVal Value As Decimal)
                m_dBalanceQty = Value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Property salescontractno() As String
            Get
                salescontractno = m_strsalescontractno
            End Get
            Set(ByVal Value As String)
                m_strsalescontractno = Value
            End Set
        End Property
        Public Property salesContractQty() As Decimal
            Get
                salesContractQty = m_dsalesContractQty
            End Get
            Set(ByVal Value As Decimal)
                m_dsalesContractQty = Value
            End Set
        End Property
        Public Property SalesContractAmount() As Decimal
            Get
                SalesContractAmount = m_dSalesContractAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dSalesContractAmount = Value
            End Set
        End Property
        Public Property LCAmount() As Decimal
            Get
                LCAmount = m_dLCAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dLCAmount = Value
            End Set
        End Property
        Public Property LCNo() As String
            Get
                LCNo = m_strLCNo
            End Get
            Set(ByVal Value As String)
                m_strLCNo = Value
            End Set

        End Property
        Public Property PISendDate() As Date
            Get
                PISendDate = m_dPISendDate
            End Get
            Set(ByVal Value As Date)
                m_dPISendDate = Value
            End Set
        End Property
      
        Public Property LCRecvDate() As Date
            Get
                LCRecvDate = m_dLCRecvDate
            End Get
            Set(ByVal Value As Date)
                m_dLCRecvDate = Value
            End Set
        End Property
        Public Property LCShipDate() As Date
            Get
                LCShipDate = m_dLCShipDate
            End Get
            Set(ByVal Value As Date)
                m_dLCShipDate = Value
            End Set
        End Property
        Public Property LCAmdDate() As Date
            Get
                LCAmdDate = m_dLCAmdDate
            End Get
            Set(ByVal Value As Date)
                m_dLCAmdDate = Value
            End Set
        End Property
        Public Property NegotiateBank() As String
            Get
                NegotiateBank = m_strNegotiateBank
            End Get
            Set(ByVal Value As String)
                m_strNegotiateBank = Value
            End Set
        End Property
        Public Property IssueBank() As String
            Get
                IssueBank = m_strIssueBank
            End Get
            Set(ByVal Value As String)
                m_strIssueBank = Value
            End Set
        End Property
        Public Property IssueRemarks() As String
            Get
                IssueRemarks = m_strIssueRemarks
            End Get
            Set(ByVal Value As String)
                m_strIssueRemarks = Value
            End Set
        End Property
        Public Function saveDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
