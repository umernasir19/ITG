Imports System.Data
Namespace EuroCentra
    Public Class TempShipmentWeightStatus
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempShipmentViewWeight"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_dtReceivingDate As Date
        Private m_lTempId As Long
        Private m_strRowType As String
        Private m_lRowNo As Long
        Private m_strColor As String
        Private m_strSrNo As String
        Private m_lJobOrderId As Long
        Private m_lCustomerId As Long
        Private m_lSeasonDatabaseId As Long
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
        Private m_dcS12 As String
        Private m_dcS13 As String
        Private m_dcS14 As String
        Private m_dcS15 As String
        Private m_dcS16 As String
        Private m_dcS17 As String
        Private m_dcS18 As String
        Private m_dcS19 As String
        Private m_dcS20 As String
        Private m_dcS21 As String
        Private m_dcS22 As String
        Private m_dTotalQTYPCS As Decimal
        Private m_dTotalQTYCTN As Decimal
        Public Property ReceivingDate() As Date
            Get
                ReceivingDate = m_dtReceivingDate
            End Get
            Set(ByVal value As Date)
                m_dtReceivingDate = value
            End Set
        End Property
        Public Property SrNo() As String
            Get
                SrNo = m_strSrNo
            End Get
            Set(ByVal Value As String)
                m_strSrNo = Value
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
        Public Property CustomerId() As Long
            Get
                CustomerId = m_lCustomerId
            End Get
            Set(ByVal Value As Long)
                m_lCustomerId = Value
            End Set
        End Property
        Public Property SeasonDatabaseId() As Long
            Get
                SeasonDatabaseId = m_lSeasonDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseId = Value
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
        Public Property S12() As String
            Get
                S12 = m_dcS12
            End Get
            Set(ByVal Value As String)
                m_dcS12 = Value
            End Set
        End Property
        Public Property S13() As String
            Get
                S13 = m_dcS13
            End Get
            Set(ByVal Value As String)
                m_dcS13 = Value
            End Set
        End Property
        Public Property S14() As String
            Get
                S14 = m_dcS14
            End Get
            Set(ByVal Value As String)
                m_dcS14 = Value
            End Set
        End Property
        Public Property S15() As String
            Get
                S15 = m_dcS15
            End Get
            Set(ByVal Value As String)
                m_dcS15 = Value
            End Set
        End Property
        Public Property S16() As String
            Get
                S16 = m_dcS16
            End Get
            Set(ByVal Value As String)
                m_dcS16 = Value
            End Set
        End Property
        Public Property S17() As String
            Get
                S17 = m_dcS17
            End Get
            Set(ByVal Value As String)
                m_dcS17 = Value
            End Set
        End Property
        Public Property S18() As String
            Get
                S18 = m_dcS18
            End Get
            Set(ByVal Value As String)
                m_dcS18 = Value
            End Set
        End Property
        Public Property S19() As String
            Get
                S19 = m_dcS19
            End Get
            Set(ByVal Value As String)
                m_dcS19 = Value
            End Set
        End Property
        Public Property S20() As String
            Get
                S20 = m_dcS20
            End Get
            Set(ByVal Value As String)
                m_dcS20 = Value
            End Set
        End Property
        Public Property S21() As String
            Get
                S21 = m_dcS21
            End Get
            Set(ByVal Value As String)
                m_dcS21 = Value
            End Set
        End Property
        Public Property S22() As String
            Get
                S22 = m_dcS22
            End Get
            Set(ByVal Value As String)
                m_dcS22 = Value
            End Set
        End Property
        Public Property TotalQTYPCS() As Decimal
            Get
                TotalQTYPCS = m_dTotalQTYPCS
            End Get
            Set(ByVal Value As Decimal)
                m_dTotalQTYPCS = Value
            End Set
        End Property
        Public Property TotalQTYCTN() As Decimal
            Get
                TotalQTYCTN = m_dTotalQTYCTN
            End Get
            Set(ByVal Value As Decimal)
                m_dTotalQTYCTN = Value
            End Set
        End Property
        Public Function Savetemp()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTableWeight()
            Dim str As String = "TRUNCATE TABLE  TempShipmentViewWeight"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempShipmentView"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTableTempSrNoFromShipmentPalningReport()
            Dim str As String = "TRUNCATE TABLE  TempSrNoFromShipmentPalningReport"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTableTempSrNoFromShipmentPalningReportWeight()
            Dim str As String = "TRUNCATE TABLE  TempSrNoFromShipmentPalningReportWeight"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSRNO() As DataTable
            Dim Str As String


            Str = "   SELECT distinct jo.Joborderid ,jo.SRNO   FROM NumberingFinalDtl Dtl"
            Str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.Joborderid "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorData(ByVal JobOrderId As Long) As DataTable
            Dim Str As String
            Str = "   SELECT  distinct jo.JoborderDetailid,jo.BuyerColor,jo.Joborderid    FROM NumberingFinalDtl Dtl"
            Str &= " join JobOrderdatabaseDetail  jo on jo.JoborderDetailid =dtl.JoborderDetailid "
            Str &= "  where jo.Joborderid = '" & JobOrderId & " ' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLPODatanew(ByVal JobOrderId As Long, ByVal JobOrderDetailId As String) As DataTable
            Dim Str As String


            Str = "  SELECT * FROM NumberingFinal  Mst"
            Str &= " join NumberingFinalDtl Dtl on Dtl.NumberingFinalID =Mst.NumberingFinalID"
            Str &= " join StyleAssortmentDetail sad on sad.StyleAssortmentDetailID =dtl.StyleAssortmentDetailID "
            Str &= "  join JobOrderdatabaseDetail jod on jod.JoborderDetailid =dtl.JoborderDetailid "
            Str &= " join JobOrderdatabase jo on jo.Joborderid =jod.Joborderid "
            Str &= "  where dtl.SelectNumbering = 1 And Dtl.Joborderid = '" & JobOrderId & "' And dtl.JoborderDetailid = '" & JobOrderDetailId & "' "


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLPODataWeight(ByVal JobOrderId As Long, ByVal JobOrderDetailId As String) As DataTable
            Dim Str As String


            Str = "  SELECT sum(CAST(Dtl.PcsPerCarton AS int)) as Quantity,sum(dtl.Weight) as Weight,sad.Size FROM NumberingFinal  Mst"
            Str &= " join NumberingFinalDtl Dtl on Dtl.NumberingFinalID =Mst.NumberingFinalID"
            Str &= " join StyleAssortmentDetail sad on sad.StyleAssortmentDetailID =dtl.StyleAssortmentDetailID "
            Str &= "  where dtl.SelectNumbering = 1 And Dtl.Joborderid = '" & JobOrderId & "' And dtl.JoborderDetailid = '" & JobOrderDetailId & "'"
            Str &= "  group by Dtl.StyleAssortmentDetailID, sad.Size "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLPOData(ByVal JobOrderId As Long, ByVal JobOrderDetailId As String) As DataTable
            Dim Str As String


            Str = "  SELECT sum(CAST(Dtl.PcsPerCarton AS int)) as Quantity,count(dtl.CartonNo) as CartonNo,sad.Size FROM NumberingFinal  Mst"
            Str &= " join NumberingFinalDtl Dtl on Dtl.NumberingFinalID =Mst.NumberingFinalID"
            Str &= " join StyleAssortmentDetail sad on sad.StyleAssortmentDetailID =dtl.StyleAssortmentDetailID "
            Str &= "  where dtl.SelectNumbering = 1 And Dtl.Joborderid = '" & JobOrderId & "' And dtl.JoborderDetailid = '" & JobOrderDetailId & "'"
            Str &= "  group by Dtl.StyleAssortmentDetailID, sad.Size "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeWiseData(ByVal lPOID As Long, ByVal ColorWay As String, ByVal Size As String) As DataTable
            Dim Str As String
            Str = " Select  *, Sty.StyleNo as Style   from PurchaseOrder PO"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID "
            Str &= " Join Style Sty on Sty.StyleID=POD.StyleID "
            Str &= " Join SizeRangeDB SDB on Sty.SizeRangeDBID = SDB.SizeRangeDBID"
            Str &= " where  PO.POID='" & lPOID & " ' and Sty.ColorWay='" & ColorWay & "' and Sty.Size='" & Size & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        ''''Packing Work
        Public Function GetALLPODetailDataDistinctColorPacking(ByVal lPOID As Long, ByVal lPackingListID As Long) As DataTable
            Dim Str As String
            Str = "   Select  distinct Sty.ColorWay,SDB.SizeRange  from"
            Str &= " PackingList PL join PackingListDetail PLD ON PL.PackingListId=PLD.PackingListId"
            Str &= " join PurchaseOrder PO on po.poid=PLD.poid"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID and pod.PODetailid= PLD.PODetailid"
            Str &= " Join Style Sty on Sty.StyleID=POD.StyleID "
            Str &= " Join SizeRangeDB SDB on Sty.SizeRangeDBID = SDB.SizeRangeDBID"
            Str &= "  where PO.POID ='" & lPOID & "' and PL.PackingListId='" & lPackingListID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetALLPacking(ByVal lPOID As Long, ByVal ColorWay As String, ByVal SizeRange As String, ByVal lPackingListID As Long) As DataTable
            Dim Str As String
            Str = "   Select  * from"
            Str &= " PackingList PL join PackingListDetail PLD ON PL.PackingListId=PLD.PackingListId"
            Str &= "  join  PurchaseOrder PO  on po.poid=PLD.poid"
            Str &= " Join PurchaseOrderDetail POD On PO.POID=POD.POID and pod.PODetailid= PLD.PODetailid"
            Str &= " Join Style Sty on Sty.StyleID=POD.StyleID "
            Str &= " Join SizeRangeDB SDB on Sty.SizeRangeDBID = SDB.SizeRangeDBID"
            Str &= " where  PO.POID='" & lPOID & "' and Sty.ColorWay='" & ColorWay & "' and SDB.SizeRange='" & SizeRange & "'"
            Str &= " and PL.PackingListId='" & lPackingListID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
