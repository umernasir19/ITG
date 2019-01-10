﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class TempWeekWiseInquiry
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempWeekWiseInquiry"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_TempId As Long
        Private m_dPeriod As String
        Private m_NoOFinq As Decimal
        Private m_NoOFConfrmOrdr As Decimal
        Private m_ConfrmQty As Decimal
        Private m_ShippedOrder As Decimal
        Private m_ShippedQty As Decimal
        Public Property TempId() As Long
            Get
                TempId = m_TempId
            End Get
            Set(ByVal value As Long)
                m_TempId = value
            End Set
        End Property
        Public Property Period() As String
            Get
                Period = m_dPeriod
            End Get
            Set(ByVal value As String)
                m_dPeriod = value
            End Set
        End Property
        Public Property NoOFinq() As Decimal
            Get
                NoOFinq = m_NoOFinq
            End Get
            Set(ByVal value As Decimal)
                m_NoOFinq = value
            End Set
        End Property
        Public Property NoOFConfrmOrdr() As Decimal
            Get
                NoOFConfrmOrdr = m_NoOFConfrmOrdr
            End Get
            Set(ByVal value As Decimal)
                m_NoOFConfrmOrdr = value
            End Set
        End Property
        Public Property ConfrmQty() As Decimal
            Get
                ConfrmQty = m_ConfrmQty
            End Get
            Set(ByVal value As Decimal)
                m_ConfrmQty = value
            End Set
        End Property
        Public Property ShippedOrder() As Decimal
            Get
                ShippedOrder = m_ShippedOrder
            End Get
            Set(ByVal value As Decimal)
                m_ShippedOrder = value
            End Set
        End Property
        Public Property ShippedQty() As Decimal
            Get
                ShippedQty = m_ShippedQty
            End Get
            Set(ByVal value As Decimal)
                m_ShippedQty = value
            End Set
        End Property
        Public Function SaveweekInquiry()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function



        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempWeekWiseInquiry"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function



        Public Function GetNoOFinqRecvd(ByVal customerid As Long, ByVal BuyingDept As String, ByVal BuyerName As String, ByVal StrtDate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = "select count(InquiryStyleID) AS NoOfInq from InquiryStyle where customerid='" & customerid & "' and BuyingDept='" & BuyingDept & "' and BuyerName= '" & BuyerName & "' and POStatus='Received' and CreationDate between '" & StrtDate & " ' and '" & EndDate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNoOFinqGeneral(ByVal customerid As Long, ByVal BuyingDept As String, ByVal BuyerName As String, ByVal StrtDate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = " select distinct count(distinct INS.GeneralInquiryMstid) AS NoOfInq "
            str &= "  from GeneralInquiryMst INS join GeneralInquiryDtl TBC ON TBC.GeneralInquiryMstid=INS.GeneralInquiryMstid"
            str &= "  join Stylemaster SM ON SM.Styleid=INS.Styleid"
            str &= "  where SM.customerid='" & customerid & "' and SM.BuyingDept='" & BuyingDept & "' and SM.BuyerName= '" & BuyerName & "' and INS.PONO='Received' and "
            str &= "  INS.CreationDate between  '" & StrtDate & " ' and '" & EndDate & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNoOFConfrmOrderAndQuantity(ByVal customerid As Long, ByVal BuyingDept As String, ByVal BuyerName As String, ByVal StrtDate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            str = "select Count(distinct Mst.MasterPO) as NoOfConfOrder ,sum(Dtl.Quantity) as Qty from PurchaseOrder Mst"
            str &= "  join PurchaseOrderDetail Dtl on Dtl.POID=Mst.POID "
            str &= "  join StyleMaster StMst on StMst.StyleID= Dtl.StyleID "
            str &= " where Mst.customerid='" & customerid & "' and Mst.EKNumber='" & BuyingDept & "' and StMst.BuyerName= '" & BuyerName & "'  and Mst.CreationDate between '" & StrtDate & " ' and '" & EndDate & " ' and (Mst.InquiryInitialID > 0 or Mst.InquiryRepeatlID > 0)"
            str &= " group by Mst.MasterPO"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetNoOFShipedOrderAndQuantity(ByVal customerid As Long, ByVal BuyingDept As String, ByVal BuyerName As String, ByVal StrtDate As String, ByVal EndDate As String) As DataTable
            Dim str As String
            'str = "select COUNT(distinct C.CargoID) as NoOfShipOrder,sum(CD.Quantity) as Qty from Cargo C"
            'str &= " join CargoDetail CD on CD.CargoID=C.CargoID"
            'str &= " JOIN PurchaseOrder PO on PO.POID=CD.POPOID"
            'str &= " join PurchaseOrderDetail Dtl on Dtl.POID=CD.POID "
            'str &= " join StyleMaster StMst on StMst.StyleID= Dtl.StyleID"
            'str &= " where StMst.customerid='" & customerid & "' and PO.EKNumber='" & BuyingDept & "' and StMst.BuyerName= '" & BuyerName & "'  and C.CreationDate between '" & StrtDate & " ' and '" & EndDate & " ' and PO.InquiryInitialID > 0 or PO.InquiryRepeatlID > 0"
            'str &= " group by C.CargoID"


            str = "select COUNT(distinct C.CargoID) as NoOfShipOrder,isnull(sum(CD.Quantity),0) as Qty from Cargo C"
            str &= " join CargoDetail CD on CD.CargoID=C.CargoID"
            str &= " JOIN PurchaseOrder PO on PO.POID=CD.POPOID"
            str &= " join PurchaseOrderDetail Dtl on Dtl.POID=CD.POID "
            str &= " join StyleMaster StMst on StMst.StyleID= Dtl.StyleID"
            str &= " where StMst.customerid='" & customerid & "' and PO.EKNumber='" & BuyingDept & "' and StMst.BuyerName= '" & BuyerName & "'  and C.CreationDate between '" & StrtDate & " ' and '" & EndDate & " ' "
            str &= " group by C.CargoID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetBuyerInfoNo(ByVal customerid As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid='" & customerid & "' and DepartmentNo='" & BuyingDept & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace