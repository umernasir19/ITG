Imports Microsoft.VisualBasic
Imports System.Data

Public Class TempSizeWeightList
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "TempSizeWeightList"
        m_strPrimaryFieldName = "TempId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lTempId As Long
    Private m_strRowType As String
    Private m_lRowNo As Long

    Private m_strStyle As String

    Private m_strColor As String
  
    Private m_SizeRangeID As Long
    Private m_lJobOrderID As Long

    Private m_dcS1 As String
    Private m_dcS2 As String
    Private m_dcS3 As String
    Private m_dcS4 As String
    Private m_dcS5 As String
    Private m_dcS6 As String
    Private m_dcS7 As String
    Private m_dcS8 As String
    Private m_dcS9 As String
    Private m_dcS10 As String
    Private m_dcS11 As String
    Private m_dTotalQTY As Decimal
    Public Property SizeRangeID() As Long
        Get
            SizeRangeID = m_SizeRangeID
        End Get
        Set(ByVal Value As Long)
            m_SizeRangeID = Value
        End Set
    End Property
    Public Property JobOrderID() As Long
        Get
            JobOrderID = m_lJobOrderID
        End Get
        Set(ByVal Value As Long)
            m_lJobOrderID = Value
        End Set
    End Property
    Public Property S1() As String
        Get
            S1 = m_dcS1
        End Get
        Set(ByVal Value As String)
            m_dcS1 = Value
        End Set
    End Property
    Public Property S2() As String
        Get
            S2 = m_dcS2
        End Get
        Set(ByVal Value As String)
            m_dcS2 = Value
        End Set
    End Property
    Public Property S3() As String
        Get
            S3 = m_dcS3
        End Get
        Set(ByVal Value As String)
            m_dcS3 = Value
        End Set
    End Property

    Public Property S4() As String
        Get
            S4 = m_dcS4
        End Get
        Set(ByVal Value As String)
            m_dcS4 = Value
        End Set
    End Property

    Public Property S5() As String
        Get
            S5 = m_dcS5
        End Get
        Set(ByVal Value As String)
            m_dcS5 = Value
        End Set
    End Property
    Public Property S6() As String
        Get
            S6 = m_dcS6
        End Get
        Set(ByVal Value As String)
            m_dcS6 = Value
        End Set
    End Property
    Public Property S7() As String
        Get
            S7 = m_dcS7
        End Get
        Set(ByVal Value As String)
            m_dcS7 = Value
        End Set
    End Property
    Public Property S8() As String
        Get
            S8 = m_dcS8
        End Get
        Set(ByVal Value As String)
            m_dcS8 = Value
        End Set
    End Property
    Public Property S9() As String
        Get
            S9 = m_dcS9
        End Get
        Set(ByVal Value As String)
            m_dcS9 = Value
        End Set
    End Property
    Public Property S10() As String
        Get
            S10 = m_dcS10
        End Get
        Set(ByVal Value As String)
            m_dcS10 = Value
        End Set
    End Property
    Public Property S11() As String
        Get
            S11 = m_dcS11
        End Get
        Set(ByVal Value As String)
            m_dcS11 = Value
        End Set
    End Property
    Public Property TotalQTY() As Decimal
        Get
            TotalQTY = m_dTotalQTY
        End Get
        Set(ByVal Value As Decimal)
            m_dTotalQTY = Value
        End Set
    End Property
    Public Property RowType() As String
        Get
            RowType = m_strRowType
        End Get
        Set(ByVal Value As String)
            m_strRowType = Value
        End Set
    End Property
    Public Property RowNo() As Long
        Get
            RowNo = m_lRowNo
        End Get
        Set(ByVal Value As Long)
            m_lRowNo = Value
        End Set
    End Property
    Public Property Color() As String
        Get
            Color = m_strColor
        End Get
        Set(ByVal Value As String)
            m_strColor = Value
        End Set
    End Property
    Public Property TempId() As Long
        Get
            TempId = m_lTempId
        End Get
        Set(ByVal Value As Long)
            m_lTempId = Value
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
   
  
   

    Public Function Savetemp()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetALLPODetailDataDistinctColor(ByVal lJobOrderId As Long) As DataTable
        Dim Str As String

        Str = " Select  distinct POD.Color,POD.SizeRangeID  from SizeWiseWeightListMst PO"
        Str &= " Join SizeWiseWeightListDtl POD On PO.SizeWiseWeightListMstID=POD.SizeWiseWeightListMstID "
        Str &= " where  PO.JobOrderId=" & lJobOrderId


        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetJobOrderId(ByVal CargoID As Long) As DataTable
        Dim Str As String

        Str = " Select  POD.POPOID  from Cargo PO"
        Str &= " Join CargoDetail POD On POD.CargoID=PO.CargoID "
        Str &= " where  PO.CargoID=" & CargoID


        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetALLPOData(ByVal lJobOrderId As Long, ByVal BuyerColor As String, ByVal SizeRangeID As String) As DataTable
        Dim Str As String

        'Str = " Select  *   from SizeWiseWeightListMst PO"
        'Str &= " Join SizeWiseWeightListDtl POD On PO.SizeWiseWeightListMstID=POD.SizeWiseWeightListMstID "
        'Str &= "  join JobOrderdatabaseDetail jod on jod.JoborderDetailid =pod.JoborderDetailid "
        'Str &= " where  PO.JobOrderId='" & lJobOrderId & " ' and POD.Color='" & Color & "' and POD.SizeRangeID='" & SizeRangeID & "'"
        'Str &= " order by PO.SizeWiseWeightListMstid asc "

        'Str = "  select *,dtl.Weight as WeightNew from NumberingFinal  mst"
        'Str &= " join NumberingFinalDtl dtl on dtl.NumberingFinalID =mst.NumberingFinalID "
        'Str &= " join JobOrderdatabaseDetail jod on jod.JoborderDetailid =dtl.JoborderDetailid "
        'Str &= " join StyleAssortmentDetail sd on sd.StyleAssortmentDetailID =dtl.StyleAssortmentDetailID "
        'Str &= " where  dtl.JobOrderId='" & lJobOrderId & " ' and jod.BuyerColor='" & BuyerColor & "' and dtl.SizeRangeID='" & SizeRangeID & "'"

        Str = "   select jod.BuyerColor ,jod.Style ,dtl.SizeRangeId ,jod.Joborderid ,sd.Size ,"
        Str &= "  sum(dtl.Weight) as WeightNew from NumberingFinal  "
        Str &= "  mst join NumberingFinalDtl dtl on dtl.NumberingFinalID =mst.NumberingFinalID  "
        Str &= " join JobOrderdatabaseDetail jod on jod.JoborderDetailid =dtl.JoborderDetailid  "
        Str &= " join StyleAssortmentDetail sd on sd.StyleAssortmentDetailID =dtl.StyleAssortmentDetailID"
        Str &= " where  dtl.JobOrderId='" & lJobOrderId & " ' and jod.BuyerColor='" & BuyerColor & "' and dtl.SizeRangeID='" & SizeRangeID & "'"
        Str &= " group by jod.BuyerColor ,jod.Style ,dtl.SizeRangeId ,jod.Joborderid ,sd.Size "

        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
End Class
