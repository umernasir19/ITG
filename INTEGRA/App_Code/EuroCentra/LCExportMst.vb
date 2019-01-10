Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class LCExportMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "LCExportMst"
            m_strPrimaryFieldName = "LCExportMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lLCExportMstID As Long
        Private m_lPIID As Long
        Private m_dCreationDate As Date
        Public Property LCExportMstID() As Long
            Get
                LCExportMstID = m_lLCExportMstID
            End Get
            Set(ByVal Value As Long)
                m_lLCExportMstID = Value
            End Set
        End Property
        Public Property PIID() As Long
            Get
                PIID = m_lPIID
            End Get
            Set(ByVal Value As Long)
                m_lPIID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dCreationDate = Value
            End Set
        End Property
        Public Function saveMst()
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
        Public Function GetData(ByVal DPIMstID As Long) As DataTable
            Dim str As String
            str = " select (select ISNULL (Sum(Quantity),0)from CargoDetail cd"
            str &= " where cd.POID = jd.JoborderDetailid) as ShipQty,CONVERT (varchar,StyleShipmentDate ,103)as ShipmentDatee,* from DPIMst di"
            str &= " join DPIDtl dpd on dpd .DPIMstID =di.DPIMstID "
            str &= " join JobOrderdatabase jo on jo.Joborderid =dpd.Joborderid "
            str &= " join JobOrderdatabaseDetail jd on jd.Joborderid =dpd.Joborderid "
            str &= " join Customer c on c.CustomerID =di.CustomerID "
            str &= " join PaymentTerm py on py.PaymentTermID =jo.PaymentTermId "
            str &= " join Currency cr on cr.CurrencyID =jo.CurrencyID "
            str &= " join SeasonDatabase  se on se.SeasonDatabaseID  =di.SeasonID "
            str &= " where di.DPIMstID ='" & DPIMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataNew(ByVal DPIMstID As Long) As DataTable
            Dim str As String
            str = " select "
            str &= " isnull((select SUM(jod.Quantity) from CargoDetail JOD where jod.POPOID =jo.Joborderid),0)as ShipQty"
            str &= " ,convert(varchar,(select top 1 (jod.StyleShipmentDate) from JobOrderdatabaseDetail JOD where jod.Joborderid =jo.Joborderid),103)as ShipmentDatee"
            str &= " ,isnull((select SUM(jod.Quantity) from JobOrderdatabaseDetail JOD where jod.Joborderid =jo.Joborderid),0)as Quantity"
            str &= " ,(select top 1 Style  from JobOrderdatabaseDetail jod where jod.Joborderid =jo.Joborderid) as Style"
            str &= " ,(select top 1 ItemDesc   from JobOrderdatabaseDetail jod where jod.Joborderid =jo.Joborderid) as ItemDesc"
            str &= "   ,isnull((select top 1 JoborderDetailid    from JobOrderdatabaseDetail jod where jod.Joborderid =jo.Joborderid),0) as JoborderDetailid"
            str &= " ,* from DPIMst di"
            str &= " join DPIDtl dpd on dpd .DPIMstID =di.DPIMstID "
            str &= " join JobOrderdatabase jo on jo.Joborderid =dpd.Joborderid "
            str &= " join Customer c on c.CustomerID =di.CustomerID "
            str &= " join PaymentTerm py on py.PaymentTermID =jo.PaymentTermId "
            str &= " join Currency cr on cr.CurrencyID =jo.CurrencyID "
            str &= " join SeasonDatabase  se on se.SeasonDatabaseID  =di.SeasonID "
            str &= " where di.DPIMstID ='" & DPIMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPINO() As DataTable
            Dim str As String
            str = " select distinct Mst.SalesContract,Mst.DPIMstID from DPIMst Mst join DPIDtl Dtl on Dtl.DPIMstID=Mst.DPIMstID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetView() As DataTable
            Dim str As String
            str = " select CONVERT (varchar,creationDate,103) as CreationDatee,* from LCExportMst lm"
            str &= " join DPIMst DM ON DM.DPIMstID =LM.PIID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetViewNewNew() As DataTable
            Dim str As String
            str = "  select *,"
            str &= " (SELECT top 1 lcd.LCNo  FROM LCExportDtl LCD where lcd.LCExportMstID =mst.LCExportMstID ) as LCNO"
            str &= "  from LCExportMst Mst"
            str &= " join DPIMst Dtl on Dtl.DPIMstID =mst.PIID"
            str &= "  join SeasonDatabase SD on SD.SeasonDatabaseID =DTL.SeasonID "
            str &= " JOIN Customer C on C.CustomerID =Dtl.CustomerID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetViewNew() As DataTable
            Dim str As String
            str = " select "
            str &= " CONVERT (varchar,Mst.creationDate,103) as CreationDatee,"
            str &= " CONVERT (varchar,Dtl.ShipmentDate,103) as ShipmentDatee,"
            str &= " CONVERT (varchar,Dtl.PISendDate,103) as PISendDatee,"
            str &= " CONVERT (varchar,Dtl.LCRecvDate,103) as LCRecvDatee,"
            str &= " CONVERT (varchar,Dtl.LCShipDate,103) as LCShipDatee,"
            str &= " CONVERT (varchar,Dtl.LCAMDDate,103) as LCAMDDatee,"
            str &= "  CONVERT (varchar,DM.PIDate,103) as PIDatee,Dtl.Description as Descriptionn,"
            str &= " * "
            str &= "  from LCExportMst Mst "
            str &= " join LCExportDtl Dtl on Dtl.LCExportMstID =Mst.LCExportMstID"
            str &= " join JobOrderdatabase JO on JO.Joborderid =DTL.Joborderid "
            str &= " join DPIMst DM ON DM.DPIMstID =Mst.PIID"
            str &= " JOIN Customer C on C.CustomerID =DTL.CustomerID "
            str &= " join Currency CC on CC.CurrencyID =Dtl.CurrencyID"
            str &= " JOIN PaymentTerm PT on PT.PaymentTermID =DTL.PaymentTermID "
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace