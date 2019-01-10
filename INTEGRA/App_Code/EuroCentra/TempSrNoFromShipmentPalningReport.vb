Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TempSrNoFromShipmentPalningReport
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempSrNoFromShipmentPalningReport"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lID As Long
        Private m_strNo As String
        Private m_lJobOrderId As Long
        Public Property JobOrderId() As Long
            Get
                JobOrderId = m_lJobOrderId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderId = Value
            End Set
        End Property
        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal Value As Long)
                m_lID = Value
            End Set
        End Property
        Public Property No() As String
            Get
                No = m_strNo
            End Get
            Set(ByVal value As String)
                m_strNo = value
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
        Public Function GetCustomerDatabase() As DataTable
            Dim str As String
            str = " select distinct c.CustomerID ,c.CustomerName  from NumberingFinal mst"
            str &= " join customer c on c.customerid=mst.customerid"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonsFromJobOrderDatabase() As DataTable
            Dim str As String

            str = "  select distinct sd.SeasonDatabaseID ,sd.SeasonName  from SeasonDatabase sd"
            str &= " join JobOrderdatabase jo on jo.SeasonDatabaseID =sd.SeasonDatabaseID"
            str &= " join NumberingFinaldtl dtl on dtl.Joborderid =jo.Joborderid "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSrnOForCuttingNew(ByVal SeasonDatabaseID As Long) As DataTable
            Dim str As String

            str = " select distinct jo.Joborderid ,jo.SRNO  from NumberingFinaldtl dtl"
            str &= " join JobOrderdatabase jo on jo.Joborderid =dtl.Joborderid "
            str &= " where jo.SeasonDatabaseID =" & SeasonDatabaseID


            Try
                Return MyBase.GetDataTable(str)
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
        Public Function GetALLPODatanew(ByVal JobOrderId As Long, ByVal JobOrderDetailId As String) As DataTable
            Dim Str As String


            Str = "  SELECT * FROM NumberingFinal  Mst"
            Str &= " join NumberingFinalDtl Dtl on Dtl.NumberingFinalID =Mst.NumberingFinalID"
            Str &= " join StyleAssortmentDetail sad on sad.StyleAssortmentDetailID =dtl.StyleAssortmentDetailID "
            Str &= "  join JobOrderdatabaseDetail jod on jod.JoborderDetailid =dtl.JoborderDetailid "
            Str &= " join JobOrderdatabase jo on jo.Joborderid =jod.Joborderid "
            Str &= "  where dtl.SelectNumbering = 1 And Dtl.Joborderid = '" & JobOrderId & "' And dtl.JoborderDetailid = '" & JobOrderDetailId & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
