Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class JobOrderdatabaseDetail

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "JobOrderdatabaseDetail"
            m_strPrimaryFieldName = "JoborderDetailid"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lJoborderDetailid As Long
        Private m_lJoborderid As Long
        Private m_lStyleID As Long
        Private m_lItemDatabaseID As Long
        Private m_lUOMID As Long
        Private m_strStyle As String
        Private m_strContent As String
        Private m_strGSM As String
        Private m_strBuyerColor As String
        Private m_dQuantity As Decimal
        Private m_dUnitPrice As Decimal
        Private m_dValue As Decimal
        Private m_dtStyleShipmentDate As Date
        Private m_dTimespame As Decimal
        Private m_dQtyPercent As Decimal
        Private m_dTotalQty As Decimal
        Private m_strAfterWashGsm As String
        Private m_lDPRNDID As Long
        Private m_strItemDesc As String
        Private m_strContentforBuyer As String
        Private m_strColorCode As String
        Private m_strItemCode As String
        Private m_lIMSItemID As Long
        Private m_dQtyPerNew As Decimal
        Private m_dTotalQtyNew As Decimal
        Private m_strModel As String
        Private m_strParentCd As String
        Public Property ParentCd() As String
            Get
                ParentCd = m_strParentCd
            End Get
            Set(ByVal value As String)
                m_strParentCd = value
            End Set
        End Property
        Public Property Model() As String
            Get
                Model = m_strModel
            End Get
            Set(ByVal value As String)
                m_strModel = value
            End Set
        End Property
        Public Property QtyPerNew() As Decimal
            Get
                QtyPerNew = m_dQtyPerNew
            End Get
            Set(ByVal value As Decimal)
                m_dQtyPerNew = value
            End Set
        End Property
        Public Property TotalQtyNew() As Decimal
            Get
                TotalQtyNew = m_dTotalQtyNew
            End Get
            Set(ByVal value As Decimal)
                m_dTotalQtyNew = value
            End Set
        End Property
        Public Property AfterWashGsm() As String
            Get
                AfterWashGsm = m_strAfterWashGsm
            End Get
            Set(ByVal value As String)
                m_strAfterWashGsm = value
            End Set
        End Property
        Public Property DPRNDID() As Long
            Get
                DPRNDID = m_lDPRNDID
            End Get
            Set(ByVal Value As Long)
                m_lDPRNDID = Value
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
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailid = Value
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
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal Value As Long)
                m_lStyleID = Value
            End Set
        End Property
        Public Property ItemDatabaseID() As Long
            Get
                ItemDatabaseID = m_lItemDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lItemDatabaseID = Value
            End Set
        End Property
        Public Property UOMID() As Long
            Get
                UOMID = m_lUOMID
            End Get
            Set(ByVal Value As Long)
                m_lUOMID = Value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Property Content() As String
            Get
                Content = m_strContent
            End Get
            Set(ByVal value As String)
                m_strContent = value
            End Set
        End Property
        Public Property GSM() As String
            Get
                GSM = m_strGSM
            End Get
            Set(ByVal value As String)
                m_strGSM = value
            End Set
        End Property
        Public Property BuyerColor() As String
            Get
                BuyerColor = m_strBuyerColor
            End Get
            Set(ByVal value As String)
                m_strBuyerColor = value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dQuantity = value
            End Set
        End Property
        Public Property UnitPrice() As Decimal
            Get
                UnitPrice = m_dUnitPrice
            End Get
            Set(ByVal value As Decimal)
                m_dUnitPrice = value
            End Set
        End Property
        Public Property Value() As Decimal
            Get
                Value = m_dValue
            End Get
            Set(ByVal value As Decimal)
                m_dValue = value
            End Set
        End Property
        Public Property StyleShipmentDate() As Date
            Get
                StyleShipmentDate = m_dtStyleShipmentDate
            End Get
            Set(ByVal value As Date)
                m_dtStyleShipmentDate = value
            End Set
        End Property
        Public Property QtyPercent() As Decimal
            Get
                QtyPercent = m_dQtyPercent
            End Get
            Set(ByVal value As Decimal)
                m_dQtyPercent = value
            End Set
        End Property
        Public Property TotalQty() As Decimal
            Get
                TotalQty = m_dTotalQty
            End Get
            Set(ByVal value As Decimal)
                m_dTotalQty = value
            End Set
        End Property
        Public Property ItemDesc() As String
            Get
                ItemDesc = m_strItemDesc
            End Get
            Set(ByVal value As String)
                m_strItemDesc = value
            End Set
        End Property
        Public Property ContentforBuyer() As String
            Get
                ContentforBuyer = m_strContentforBuyer
            End Get
            Set(ByVal value As String)
                m_strContentforBuyer = value
            End Set
        End Property
        Public Property ColorCode() As String
            Get
                ColorCode = m_strColorCode
            End Get
            Set(ByVal value As String)
                m_strColorCode = value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                ItemCode = m_strItemCode
            End Get
            Set(ByVal Value As String)
                m_strItemCode = Value
            End Set
        End Property
        Public Property IMSItemID() As Long
            Get
                IMSItemID = m_lIMSItemID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemID = Value
            End Set
        End Property
        Public Function SaveJobOrderDetail()
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
        Function DeleteDetailFromJobOrderdatabaseDetail(ByVal JoborderDetailid As Long)
            Dim Str As String
            Str = " Delete from JobOrderdatabaseDetail where JoborderDetailid=" & JoborderDetailid
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckStyleAssortment(ByVal Joborderid As Long) As DataTable
            Dim Str As String
            Str = " select * from StyleAssortmentMaster where Joborderid=" & Joborderid
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
