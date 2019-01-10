Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class tblJVMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tblJVMst"
            m_strPrimaryFieldName = "tblJVMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_ltblJVMstID As Long
        Private m_strCompanyId As String
        Private m_strVoucherNo As String
        Private m_dtVoucherDate As Date
        Private m_strDescription As String
        Private m_strCancel As String
        Private m_dtEntryDate As Date
        Private m_strUserId As String
        Private m_strInvoiceNo As String
        Private m_strInvoiceDate As String
        Private m_lUID As Long
        Private m_dTotalAmount As Decimal
        Private m_strVNo As String
        Private m_bChkDate As Boolean
        Private m_lCargoId As Long
        Public Property ChkDate() As Boolean
            Get
                ChkDate = m_bChkDate
            End Get
            Set(ByVal Value As Boolean)
                m_bChkDate = Value
            End Set
        End Property
        Public Property CargoId() As Long
            Get
                CargoId = m_lCargoId
            End Get
            Set(ByVal Value As Long)
                m_lCargoId = Value
            End Set
        End Property
        '  Private m_strBookAccount As String
        'Public Property BookAccount() As String
        '    Get
        '        BookAccount = m_strBookAccount
        '    End Get
        '    Set(ByVal Value As String)
        '        m_strBookAccount = Value
        '    End Set
        'End Property

        Public Property tblJVMstID() As Long
            Get
                tblJVMstID = m_ltblJVMstID
            End Get
            Set(ByVal Value As Long)
                m_ltblJVMstID = Value
            End Set
        End Property
        Public Property CompanyId() As String
            Get
                CompanyId = m_strCompanyId
            End Get
            Set(ByVal Value As String)
                m_strCompanyId = Value
            End Set
        End Property
        Public Property VoucherNo() As String
            Get
                VoucherNo = m_strVoucherNo
            End Get
            Set(ByVal Value As String)
                m_strVoucherNo = Value
            End Set
        End Property
        Public Property VoucherDate() As Date
            Get
                VoucherDate = m_dtVoucherDate
            End Get
            Set(ByVal Value As Date)
                m_dtVoucherDate = Value
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

        Public Property Cancel() As String
            Get
                Cancel = m_strCancel
            End Get
            Set(ByVal Value As String)
                m_strCancel = Value
            End Set
        End Property
        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate
            End Get
            Set(ByVal Value As Date)
                m_dtEntryDate = Value
            End Set
        End Property
        Public Property UserId() As String
            Get
                UserId = m_strUserId
            End Get
            Set(ByVal Value As String)
                m_strUserId = Value
            End Set
        End Property
        Public Property InvoiceNo() As String
            Get
                InvoiceNo = m_strInvoiceNo
            End Get
            Set(ByVal Value As String)
                m_strInvoiceNo = Value
            End Set
        End Property
        Public Property InvoiceDate() As String
            Get
                InvoiceDate = m_strInvoiceDate
            End Get
            Set(ByVal Value As String)
                m_strInvoiceDate = Value
            End Set
        End Property
        Public Property UID() As Long
            Get
                UID = m_lUID
            End Get
            Set(ByVal Value As Long)
                m_lUID = Value
            End Set
        End Property
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = m_dTotalAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dTotalAmount = Value
            End Set
        End Property
        Public Property VNo() As String
            Get
                VNo = m_strVNo
            End Get
            Set(ByVal Value As String)
                m_strVNo = Value
            End Set
        End Property
        Public Function SavetblJVMst()
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
        Public Function GetAccountName(ByVal AccountCode As String)
            Dim str As String
            str = " select AccountName from tblAccounts where AccountCode='" & AccountCode & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJournalVoucherforLedgerView(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = " select  JBM.tblJVMstID,JBM.VoucherNo,convert(varchar,JBM.VoucherDate,103) as VoucherDate"
            str &= " ,JBM.Description,JBM.UserId,JBM.TotalAmount,"
            str &= " (select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Debit"
            str &= " ,(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Credit"
            str &= " ,((select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) -(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID)) as Balance"
            str &= " from tblJVMst JBM  where  JBM.VoucherNo='" & VoucherNo & "' "
            str &= " order By tblJVMstID DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUniqueAccountName2(ByVal AccountName As String, ByVal AccountCode As String)
            Dim str As String
            str = " Select * from tblAccounts where AccountName ='" & AccountName & "'  and AccountCode ='" & AccountCode & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountNameMaster(ByVal AccountCode As String)
            Dim str As String
            str = " Select AccountName from tblAccounts where AccountCode ='" & AccountCode & "' "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetUniqueAccountName(ByVal AccountName As String)
            Dim str As String
            str = " Select AccountName ,AccountCode  from tblAccounts where AccountLevel='Detail' and  AccountName like '" & AccountName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJournalVoucherforView() As DataTable
            Dim str As String
            str = " select  JBM.tblJVMstID,JBM.VoucherNo,convert(varchar,JBM.VoucherDate,103) as VoucherDate"
            str &= " ,JBM.Description,JBM.UserId,CONVERT(varchar,CAST((JBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " (select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Debit"
            str &= " ,(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Credit"
            str &= " ,((select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) -(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID)) as Balance"
            str &= " from tblJVMst JBM where CargoId=0   "
            str &= " order By tblJVMstID DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJournalVoucherforViewNew(ByVal FirstYear As String, ByVal SecondYear As String) As DataTable
            Dim str As String
            str = " select  JBM.tblJVMstID,JBM.VoucherNo,convert(varchar,JBM.VoucherDate,103) as VoucherDate"
            str &= " ,JBM.Description,JBM.UserId,CONVERT(varchar,CAST((JBM.TotalAmount)As money),1)As TotalAmount,"
            str &= " (select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Debit"
            str &= " ,(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Credit"
            str &= " ,((select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) -(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID)) as Balance"
            str &= " from tblJVMst JBM where CargoId=0 and VoucherDate between '" & FirstYear & "' and '" & SecondYear & "' "
            str &= " order By VoucherNo DESC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBookAccountFirstTime() As DataTable
            Dim str As String
            '  str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountCode='0103002001'"
            ' str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0103002' "
            str = " select AccountCode,AccountName,(AccountCode + '  ' + AccountName) as BookAccount from tblAccounts where accountlevel='Detail' and AccountNature=1 and actleveldigit=4 and Groupact='0104003' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTopSNO()
            Dim str As String
            str = " select Top 1 SNo from tblBankDtl order by tblBankDtlID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUserName(ByVal UserID As Long)
            Dim str As String
            str = " select UserName from UMUser where UserId='" & UserID & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastVoucherNo(ByVal Month As Integer, ByVal year As Integer, ByVal Day As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblJVMst where month(VoucherDate)='" & Month & "' order By tblJVMstID DESC"
            str = " select Top 1 VoucherNo from tblJVMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' and Day(VoucherDate)='" & Day & "' AND CargoId=0 order By tblJVMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastVoucherNoSV(ByVal Month As Integer, ByVal year As Integer, ByVal Day As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblJVMst where month(VoucherDate)='" & Month & "' order By tblJVMstID DESC"
            str = " select Top 1 VoucherNo from tblJVMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' and Day(VoucherDate)='" & Day & "' AND CargoId>0 order By tblJVMstID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function Edit(ByVal tblJVMstID As Long) As DataTable
            Dim str As String
            str = "  Select * from tblJVMst JVM  "
            str &= "  join tblJVDtl JVD on JVM.tblJVMstID=JVD.tblJVMstID "
            str &= " join tblAccounts AA on AA.AccountCode=JVD.AccountCode "
            str &= " where JVM.tblJVMstID=" & tblJVMstID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Function GETAUTO(ByVal VoucherNo As String)
            Dim Str As String
            Str = " Select VoucherNo as Name from tblJVMst where VoucherNo like '%" & VoucherNo & "%'    order by tblJVMstID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckVoucherNo(ByVal VoucherNo As String)
            Dim str As String
            str = " Select * from tblJVMst where VoucherNo ='" & VoucherNo & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckCargosv(ByVal CargoId As String)
            Dim str As String
            str = " Select * from tblJVMst JVM join tblJVDtl JVD on JVM.tblJVMstID=JVD.tblJVMstID where CargoId ='" & CargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Cargodata(ByVal CargoId As String)
            Dim str As String
            str = " Select *,(case when Cr.Currency='Dollar'  then '$ '   when Cr.Currency='Pound'  then '£ ' when Cr.Currency='PKR'  then 'PKR ' else '€ ' end) + Convert(varchar,Cr.InvoiceValue)as InvoiceValuee from cargo  Cr where  Cr.CargoId ='" & CargoId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeletetblJVMst(ByVal tblJVMstID As Long)
            Dim Str As String
            Str = " delete from tblJVMst where tblJVMstID=" & tblJVMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeletetblJVDtl(ByVal tblJVMstID As Long)
            Dim Str As String
            Str = " delete from tblJVdtl where tblJVMstID=" & tblJVMstID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVoucherNoAllInfo(ByVal VoucherNo As String) As DataTable
            Dim str As String
            ' str = " select * from tblBankMst TBM left join Umuser u on U.UserID=TBM.UID   order By TBM.voucherNo DESC"
            str = " select  JBM.tblJVMstID,JBM.VoucherNo,convert(varchar,JBM.VoucherDate,103) as VoucherDate"
            str &= " ,JBM.Description,JBM.UserId,JBM.TotalAmount,"
            str &= " (select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Debit"
            str &= " ,(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) as Credit"
            str &= " ,((select isnull(sum(Debit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID) -(select isnull(sum(Credit),0) from tblJVDtl where tblJVMstID=JBM.tblJVMstID)) as Balance"
            str &= " from tblJVMst JBM "
            str &= " where VoucherNo ='" & VoucherNo & "' and CargoId=0"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMasterData() As DataTable
            Dim str As String
            str = " Select * from tblJVMst "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDetailData(ByVal VoucherNo As String) As DataTable
            Dim str As String
            str = " Select * from tblJVDtl where VoucherNo='" & VoucherNo & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateDetail(ByVal tblJVMstID As Long, ByVal tblJVDtlID As Long)
            Dim str As String
            str = " Update tblJVDtl set tblJVMstID=" & tblJVMstID & " where tblJVDtlID=" & tblJVDtlID & ""
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateAmount(ByVal tblJVMstID As Long, ByVal TotalAmount As Decimal)
            Dim str As String
            str = " Update tblJVMst set TotalAmount=" & TotalAmount & " where tblJVMstID=" & tblJVMstID & ""
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAmount(ByVal TblJvMstID As Long) As DataTable
            Dim str As String
            str = " select isnull(Sum(Debit)+Sum(Credit),0) as amount from TblJvDtl where TblJvMstID=" & TblJvMstID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDRCR()
            Dim str As String
            str = " Select * from TblJVType "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJvDataOnEdit(ByVal JvMstId As String)
            Dim str As String
            str = " select * from tbljvMst jvm "
            str &= " join tblJvDtl jvd on jvd.tblJVMstID = jvm.tblJVMstID "
            str &= " where jvm.tblJVMstID = '" & JvMstId & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetAccountNameByAccountNo(ByVal AccountCode As String)
            Dim str As String
            str = " select AccountName from tblAccounts where AccountCode = '" & AccountCode & "' "
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


