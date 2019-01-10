Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class CostOtherHeadMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CostOtherHeadMst"
            m_strPrimaryFieldName = "CostOtherHeadMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCostOtherHeadMstID As Long
        Private m_lJobOrderId As Long
        Private m_strJobOrderNo As String
        Private m_strItem As String
        Private m_strStyle As String
        Private m_DCQuantity As Decimal
        Private m_DCTOtalCostAmount As Decimal
        Public Property CostOtherHeadMstID() As Long
            Get
                CostOtherHeadMstID = m_lCostOtherHeadMstID
            End Get
            Set(ByVal Value As Long)
                m_lCostOtherHeadMstID = Value
            End Set
        End Property
        Public Property JobOrderId() As Long
            Get
                JobOrderId = m_lJobOrderId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderId = Value
            End Set
        End Property

        Public Property JobOrderNo() As String
            Get
                JobOrderNo = m_strJobOrderNo
            End Get
            Set(ByVal Value As String)
                m_strJobOrderNo = Value
            End Set
        End Property
        Public Property Item() As String
            Get
                Item = m_strItem
            End Get
            Set(ByVal Value As String)
                m_strItem = Value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal Value As String)
                m_strStyle = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_DCQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_DCQuantity = Value
            End Set
        End Property


        Public Property TOtalCostAmount() As Decimal
            Get
                TOtalCostAmount = m_DCTOtalCostAmount
            End Get
            Set(ByVal Value As Decimal)
                m_DCTOtalCostAmount = Value
            End Set
        End Property
        Public Function SaveCostAheadMst()
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
        Public Function GetJobOrderData(ByVal Joborderid As Long) As DataTable
            Dim str As String
            'str = "  Select * ,(select distinct Content from StyleMasterDatabase  SM where  SM.JoborderID=JO.JoborderID) as Content"
            'str &= " ,(select Top 1 ItemDiscription from StyleMasterDatabase  SM where  SM.JoborderID=JO.JoborderID order by SM.StyleMasterDatabaseID desc) as Item"
            'str &= " ,(select isnull(Sum(Qty),0) from StyleMasterDatabase  SM "
            'str &= " join Style_SubStyle SS on SS.StyleMasterDatabaseID=SM.StyleMasterDatabaseID"
            'str &= " where  SM.JoborderID=JO.JoborderID) as Qty"
            'str &= " from JobOrder JO"
            'str &= " left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID"
            'str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID"
            'str &= " left join CustomerDatabase CD ON JO.CustomerDatabaseID=CD.CustomerDatabaseID"
            'str &= " where JO.JoborderID='" & Joborderid & "' "

            str = "  select *  , convert(varchar,jo.OrderRecvDate ,103) as ReceivedDate ,(select isnull(Sum(QUANTITY),0) from JobOrderdatabase  SM  "
            str &= " join JobOrderdatabaseDetail SS on SS.JoborderID=SM.JoborderID"
            str &= " where  SM.JoborderID=JO.JoborderID) as Qty from JobOrderdatabase JO JOIN JobOrderdatabaseDetail JD  ON JO.JoborderID=JD.JoborderID"
            str &= " left JOIN SeasonDatabase SD ON JO.SeasonDatabaseID=SD.SeasonDatabaseID "
            str &= " left join BrandDatabase BD ON JO.BrandDatabaseID=BD.BrandDatabaseID "
            str &= " left join Customer CD ON JO.CustomerDatabaseID=CD.CustomerID "
            str &= " left JOIN ITEMDATABASE ITD ON ITD.ItemDatabaseId=JD.ItemDatabaseId where JO.JoborderID='" & Joborderid & "' "


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCostAhead() As DataTable
            Dim str As String
            str = " Select * from  CostAhead "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCostFrc() As DataTable
            Dim str As String
            str = " Select * from  CostFrac "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFPLANdetail(ByVal JobOrderIdID As Long) As DataTable
            Dim str As String
            str = " select * from CostOtherHeadMst COM "
            str &= " JOIN CostOtherHeadDtl COD ON COM.CostOtherHeadMstid=COD.CostOtherHeadMstid"
            str &= " join CostAhead ch on ch.CostAheadid=COD.CostAheadid"
            str &= " join CostFrac CF ON CF.CostFracID=COD.CostFracID"
            str &= "   WHERE COM.JobOrderId='" & JobOrderIdID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
