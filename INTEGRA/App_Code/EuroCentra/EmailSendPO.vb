Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports Microsoft.SqlServer
Namespace EuroCentra
    Public Class EmailSendPO
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EmailSendPO"
            m_strPrimaryFieldName = "EmailSendPOid"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lEmailSendPOid As Long
        Private m_lPOid As Long
        Private m_strpono As String
        Private m_strSUPPLIER As String
        Private m_strCUSTOMER As String
        Private m_strMERCHANDISER As String
        Private m_strShipmentdate As String
        Private m_dBookedQuantity As Decimal
        Private m_strStyleNo As String
        Private m_strBULKFABRICINHOUSEATFACTORY As String
        Private m_strCUTTINGSTARTS As String
        Private m_strSTITCHINGSTARTS As String
        Private m_lUserid As Long
        Private m_bemailstatus As Boolean
        Public Property EmailSendPOid() As Long
            Get
                EmailSendPOid = m_lEmailSendPOid
            End Get
            Set(ByVal Value As Long)
                m_lEmailSendPOid = Value
            End Set
        End Property
        Public Property POid() As Long
            Get
                POid = m_lPOid
            End Get
            Set(ByVal Value As Long)
                m_lPOid = Value
            End Set
        End Property
        Public Property pono() As String
            Get
                pono = m_strpono
            End Get
            Set(ByVal value As String)
                m_strpono = value
            End Set
        End Property
        Public Property SUPPLIER() As String
            Get
                SUPPLIER = m_strSUPPLIER
            End Get
            Set(ByVal value As String)
                m_strSUPPLIER = value
            End Set
        End Property
        Public Property CUSTOMER() As String
            Get
                Customer = m_strCUSTOMER
            End Get
            Set(ByVal value As String)
                m_strCUSTOMER = value
            End Set
        End Property
        Public Property MERCHANDISER() As String
            Get
                MERCHANDISER = m_strMERCHANDISER
            End Get
            Set(ByVal value As String)
                m_strMERCHANDISER = value
            End Set
        End Property
        Public Property Shipmentdate() As String
            Get
                Shipmentdate = m_strShipmentdate
            End Get
            Set(ByVal value As String)
                m_strShipmentdate = value
            End Set
        End Property
        Public Property BookedQuantity() As Decimal
            Get
                BookedQuantity = m_dBookedQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dBookedQuantity = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Property BULKFABRICINHOUSEATFACTORY() As String
            Get
                BULKFABRICINHOUSEATFACTORY = m_strBULKFABRICINHOUSEATFACTORY
            End Get
            Set(ByVal value As String)
                m_strBULKFABRICINHOUSEATFACTORY = value
            End Set
        End Property
        Public Property CUTTINGSTARTS() As String
            Get
                CUTTINGSTARTS = m_strCUTTINGSTARTS
            End Get
            Set(ByVal value As String)
                m_strCUTTINGSTARTS = value
            End Set
        End Property
        Public Property STITCHINGSTARTS() As String
            Get
                STITCHINGSTARTS = m_strSTITCHINGSTARTS
            End Get
            Set(ByVal value As String)
                m_strSTITCHINGSTARTS = value
            End Set
        End Property
        Public Property Userid() As Long
            Get
                Userid = m_lUserid
            End Get
            Set(ByVal Value As Long)
                m_lUserid = Value
            End Set
        End Property

        Public Property Emailstatus() As Long
            Get
                Emailstatus = m_bemailstatus
            End Get
            Set(ByVal Value As Long)
                m_bemailstatus = Value
            End Set
        End Property
        Public Function SaveEmailSendPO()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetnAMEUser(ByVal userid As Long) As DataTable
            Dim Str As String
            Str = "select *  from UmUser where userid='" & userid & "'"
           
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailSendInfoData(ByVal userid As Long) As DataTable
            Dim Str As String
            Str = "select *  from UmUserLinkLog where userid='" & userid & "' and "
            Str &= " year(MailSenddate) =" & Date.Now.Year
            Str &= " and month(MailSenddate) =" & Date.Now.Month
            Str &= " and day(MailSenddate) = " & Date.Now.Day
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEmailAlterNewForAccess(ByVal Userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = " Select Cht.Status,Cht.TNAProcessID,PO .UserID AS MarchandID,PO.Joborderid AS POID,U.UserName "
            str &= "  as Marchand"
            str &= "  ,upper(CustomerName) as CustomerName,PO.SRNO AS PONo"
            str &= "  ,isnull((select top 1 (DTL.Style) from JobOrderdatabase poo "
            str &= "   join JobOrderdatabaseDetail DTL on poo.Joborderid=dtl.Joborderid "
            str &= "  where poo.Joborderid=po.Joborderid),'') as Style"
            str &= "  ,upper(PO.Supplier ) as VenderName,Process,"
            str &= "   Convert(Varchar,DateEstemated,106)as TargetDate From  TNAChart Cht "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join JobOrderdatabase PO On Cht.POID=PO.Joborderid "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID  "
            str &= "  Join  UMUser U on U.UserID=PO.UserID "
            str &= " where Prcs.ProcessID  in(9) and convert(Varchar,DateEstemated,103)='" & EstDate & "' "
            str &= "    and Cht.Selected != 0 and Cht.Status !='Completed' "
            str &= "  and  PO .UserID  ='" & Userid & "' "
            str &= "  And  Cht.Remarks Not like '%Not Applicable%'"
            str &= "  order by po.srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try

        End Function
        Public Function GetEmailAlterNewForSwing(ByVal Userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = " Select Cht.Status,Cht.TNAProcessID,PO .UserID AS MarchandID,PO.Joborderid AS POID,U.UserName "
            str &= "  as Marchand"
            str &= "  ,upper(CustomerName) as CustomerName,PO.SRNO AS PONo"
            str &= "  ,isnull((select top 1 (DTL.Style) from JobOrderdatabase poo "
            str &= "   join JobOrderdatabaseDetail DTL on poo.Joborderid=dtl.Joborderid "
            str &= "  where poo.Joborderid=po.Joborderid),'') as Style"
            str &= "  ,upper(PO.Supplier ) as VenderName,Process,"
            str &= "   Convert(Varchar,DateEstemated,106)as TargetDate From  TNAChart Cht "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join JobOrderdatabase PO On Cht.POID=PO.Joborderid "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID  "
            str &= "  Join  UMUser U on U.UserID=PO.UserID "
            str &= " where Prcs.ProcessID  in(10) and convert(Varchar,DateEstemated,103)='" & EstDate & "' "
            str &= "    and Cht.Selected != 0 and Cht.Status !='Completed' "
            str &= "  and  PO .UserID  ='" & Userid & "' "
            str &= "  And  Cht.Remarks Not like '%Not Applicable%'"
            str &= "  order by po.srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try

        End Function
        Public Function GetEmailAlterNewForSwingAliRaza(ByVal Userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = " Select Cht.Status,Cht.TNAProcessID,PO .UserID AS MarchandID,PO.Joborderid AS POID,U.UserName "
            str &= "  as Marchand"
            str &= "  ,upper(CustomerName) as CustomerName,PO.SRNO AS PONo"
            str &= "  ,isnull((select top 1 (DTL.Style) from JobOrderdatabase poo "
            str &= "   join JobOrderdatabaseDetail DTL on poo.Joborderid=dtl.Joborderid "
            str &= "  where poo.Joborderid=po.Joborderid),'') as Style"
            str &= "  ,upper(PO.Supplier ) as VenderName,Process,"
            str &= "   Convert(Varchar,DateEstemated,106)as TargetDate From  TNAChart Cht "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join JobOrderdatabase PO On Cht.POID=PO.Joborderid "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID  "
            str &= "  Join  UMUser U on U.UserID=PO.UserID "
            str &= " where Prcs.ProcessID  in(8) and convert(Varchar,DateEstemated,103)='" & EstDate & "' "
            str &= "    and Cht.Selected != 0 and Cht.Status !='Completed' "
            str &= "  and  PO .UserID  ='" & Userid & "' "
            str &= "  And  Cht.Remarks Not like '%Not Applicable%'"
            str &= "  order by po.srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try

        End Function
        Public Function GetEmailAlterNewForFabric(ByVal Userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = " Select Cht.Status,Cht.TNAProcessID,PO .UserID AS MarchandID,PO.Joborderid AS POID,U.UserName "
            str &= "  as Marchand"
            str &= "  ,upper(CustomerName) as CustomerName,PO.SRNO AS PONo"
            str &= "  ,isnull((select top 1 (DTL.Style) from JobOrderdatabase poo "
            str &= "   join JobOrderdatabaseDetail DTL on poo.Joborderid=dtl.Joborderid "
            str &= "  where poo.Joborderid=po.Joborderid),'') as Style"
            str &= "  ,upper(PO.Supplier ) as VenderName,Process,"
            str &= "   Convert(Varchar,DateEstemated,106)as TargetDate From  TNAChart Cht "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join JobOrderdatabase PO On Cht.POID=PO.Joborderid "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID  "
            str &= "  Join  UMUser U on U.UserID=PO.UserID "
            str &= " where Prcs.ProcessID  in(6,7) and convert(Varchar,DateEstemated,103)='" & EstDate & "' "
            str &= "    and Cht.Selected != 0 and Cht.Status !='Completed' "
            str &= "  and  PO .UserID  ='" & Userid & "' "
            str &= "  And  Cht.Remarks Not like '%Not Applicable%'"
            str &= "  order by po.srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try

        End Function
        Public Function GetEmailAlterNew(ByVal Userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = " Select Cht.Status,Cht.TNAProcessID,PO .UserID AS MarchandID,PO.Joborderid AS POID,U.UserName "
            str &= "  as Marchand"
            str &= "  ,upper(CustomerName) as CustomerName,PO.SRNO AS PONo"
            str &= "  ,isnull((select top 1 (DTL.Style) from JobOrderdatabase poo "
            str &= "   join JobOrderdatabaseDetail DTL on poo.Joborderid=dtl.Joborderid "
            str &= "  where poo.Joborderid=po.Joborderid),'') as Style"
            str &= "  ,upper(PO.Supplier ) as VenderName,Process,"
            str &= "   Convert(Varchar,DateEstemated,106)as TargetDate From  TNAChart Cht "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join JobOrderdatabase PO On Cht.POID=PO.Joborderid "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID  "
            str &= "  Join  UMUser U on U.UserID=PO.UserID "
            str &= " where Prcs.ProcessID  in(1,2,3,4,5,11) and convert(Varchar,DateEstemated,103)='" & EstDate & "' "
            str &= "    and Cht.Selected != 0 and Cht.Status !='Completed' "
            str &= "  and  PO .UserID  ='" & Userid & "' "
            str &= "  And  Cht.Remarks Not like '%Not Applicable%'"
            str &= "  order by po.srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try

        End Function
        Function GetEmailCC() As DataTable
            Dim Str As String
            Str = " Select * From tblEmailcc where Type='CC' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressManager(ByVal UserID As Long) As DataTable
            Dim Str As String
            Str = " Select * From Ummanager UMM "
            Str &= " JOIN  UmUserLink EE ON EE.UserID =UMM.MANAGERID"
            Str &= " where UMM.UserID = '" & UserID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetEmailAddressnEW(ByVal UserID As Long) As DataTable
            Dim Str As String
            Str = "Select * From UmUserLink EE"
            Str &= " join UMuser u on U.userid=EE.Userid"
            Str &= " where U.UserID=" & UserID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EmailGrid2ndRemNewForaCCESS(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= "  PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= "  from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= "  JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= "  Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(9) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%' AND ER.NoofReminder =1"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid2ndRemNewForSwing(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= "  PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= "  from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= "  JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= "  Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(10) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%' AND ER.NoofReminder =1"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid2ndRemNewForSwingaLIrAZA(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= "  PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= "  from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= "  JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= "  Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(8) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%' AND ER.NoofReminder =1"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid2ndRemNewForfabric(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= "  PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= "  from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= "  JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= "  Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(6,7) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%' AND ER.NoofReminder =1"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid2ndRemNew(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= "  PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= "  from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= "  JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= "  Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= "  Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(1,2,3,4,5,11) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%' AND ER.NoofReminder =1"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdatAlertsNO(ByVal POID As Long, ByVal ProcessID As Long, ByVal NoofReminder As Long) As DataTable
            Dim Str As String
            Str = " Update EmailReminder set NoofReminder='" & NoofReminder & "' where poid= '" & POID & "' AND ProcessID='" & ProcessID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetEmailCCReminder(ByVal Type As String) As DataTable
            Dim Str As String
            Str = " Select * From tblEmailcc where Type='" & Type & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EmailGrid3rdRemNew(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= " PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= " from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= " JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= " Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= " Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(1,2,3,4,5,11) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%'"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid3rdRemNewForfabric(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= " PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= " from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= " JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= " Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= " Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(6,7) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%'"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid3rdRemNewForaCCESS(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= " PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= " from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= " JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= " Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= " Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(9) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%'"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid3rdRemNewForSwing(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= " PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= " from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= " JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= " Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= " Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(10) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%'"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function EmailGrid3rdRemNewForSwingAliRaza(ByVal userid As String, ByVal EstDate As String) As DataTable
            Dim str As String

            str = "    select distinct NoofReminder+1 as NewNoofReminder, Cht.Status,Cht.TNAProcessID,PO .UserID as"
            str &= " MarchandID,"
            str &= " PO.Joborderid as  POID,U.UserName as Marchand,upper(CustomerName) as CustomerName,po.srno as"
            str &= "  PONo ,isnull((select top 1 (DTL.Style) "
            str &= " from JobOrderdatabase  poo  "
            str &= " join JobOrderdatabaseDetail  DTL on poo.Joborderid =dtl.Joborderid  "
            str &= " where poo.Joborderid=po.Joborderid),'') as Style "
            str &= " ,upper(PO.Supplier ) as VenderName,Process,   "
            str &= " Convert(Varchar,DateEstemated,106)as TargetDate "
            str &= " from EmailReminder ER  "
            str &= " Join JobOrderdatabase PO On ER.poid=PO.Joborderid  "
            str &= " JOIN  TNAChart Cht   ON PO.Joborderid =Cht .POID AND ER.ProcessID =CHT.TNAProcessID   "
            str &= "  Join TNAPRocess Prcs on Cht.TNAProcessID=Prcs.ProcessID "
            str &= " Join Customer C on C.CustomerID=PO.CustomerDatabaseID      "
            str &= " Join  UMUser U on U.UserID=PO.userID  "
            str &= " where Prcs.ProcessID  in(8) and  Cht.Selected != 0 and Cht.Status !='Completed' and  convert(Varchar,DateEstemated,103)='" & EstDate & "'"
            str &= " and  PO .userid  ='" & userid & "' "
            str &= " and ER.ProcessActive=1 "
            str &= "  and Cht.Remarks Not like '%Not Applicable%'"
            str &= " order by srno"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetEmailCCReminder3(ByVal Type2 As String) As DataTable
            Dim Str As String
            ' Str = " Select * From tblEmailcc where Type='" & Type & "' or Type='" & Type2 & "' "

            Str = " Select * From tblEmailcc where  Type='" & Type2 & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
