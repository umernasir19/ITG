Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class StoreReceiptVoucherMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StoreReceiptVoucherMst"
            m_strPrimaryFieldName = "StoreReceiptVoucherMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lStoreReceiptVoucherMstID As Long
        Private m_dtStoreRecieptVoucherDate As Date
        Private m_lCreatedbyID As Long

        Public Property CreatedbyID() As Long
            Get
                CreatedbyID = m_lCreatedbyID
            End Get
            Set(ByVal value As Long)
                m_lCreatedbyID = value
            End Set
        End Property
        Public Property StoreReceiptVoucherMstID() As Long
            Get
                StoreReceiptVoucherMstID = m_lStoreReceiptVoucherMstID
            End Get
            Set(ByVal value As Long)
                m_lStoreReceiptVoucherMstID = value
            End Set
        End Property
        Public Property StoreRecieptVoucherDate() As Date
            Get
                StoreRecieptVoucherDate = m_dtStoreRecieptVoucherDate
            End Get
            Set(ByVal value As Date)
                m_dtStoreRecieptVoucherDate = value
            End Set
        End Property

        Public Function SaveStoreRecieptVoucherMst()
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
        Public Function GetSupplier() As DataTable
            Dim str As String

            str = "  select * from tblaccounts where  groupact='0202002001' order by accountname"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierNew() As DataTable
            Dim str As String

            str = "  select * from SupplierDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierFabric() As DataTable
            Dim str As String

            str = " select * from SupplierDatabase s "
            str &= " join tblaccounts a on a.AccountCode =s.AccountCode "
            str &= "   order by accountname"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplier2() As DataTable
            Dim str As String

            str = "  select * from tblaccounts where  groupact='0202002002' order by accountname"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetItemName() As DataTable
            Dim str As String
            '   str = "  Select Itm.ItemCodee as  ItemCode,Itm.IMSItemID from IMSItem Itm where Itm.IMSItemClassID=6 order by Itm.ItemCodee ASC "
            str = "  Select Itm.ItemName as  ItemName,Itm.IMSItemID from IMSItem Itm where Itm.IMSItemClassID=6 order by Itm.ItemName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemNameWithoutFabric(ByVal IMSItemClassID As Long) As DataTable
            Dim str As String
            '   str = "  Select Itm.ItemCodee as  ItemCode,Itm.IMSItemID from IMSItem Itm where Itm.IMSItemClassID=6 order by Itm.ItemCodee ASC "
            str = "  Select Itm.ItemName as  ItemName,Itm.IMSItemID from IMSItem Itm where Itm.IMSItemClassID ='" & IMSItemClassID & "' order by Itm.ItemName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemCode(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = "   Select ItemCodee  as  ItemCode,ItemUnitId from IMSItem Itm where Itm.IMSItemId='" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUnit() As DataTable
            Dim str As String
            str = "   Select * from IMSItemUnit"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassName() As DataTable
            Dim str As String
            str = "  Select ItemClassName,IMSItemClassID  from IMSItemClass where IMSItemClassID NOT IN(6)"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFabricClassName() As DataTable
            Dim str As String
            str = "  Select ItemClassName,IMSItemClassID  from IMSItemClass where IMSItemClassID =6"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = "   Select StoreReceiptVoucherMstID,Convert(varchar, StoreRecieptVoucherDate,103) as StoreRecieptVoucherDate  from StoreReceiptVoucherMst"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function View1(ByVal CreatedbyID As Long) As DataTable
            Dim str As String
            str = "   Select StoreReceiptVoucherMstID,Convert(varchar, StoreRecieptVoucherDate,103) as StoreRecieptVoucherDate  from StoreReceiptVoucherMst where CreatedbyID='" & CreatedbyID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMaxGRNNo(ByVal Month As Integer, ByVal year As Integer)
            Dim str As String
            'str = " select  isnull(Max (convert(int,substring(VoucherNo,11,20))),0) as VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "'"
            str = "  select  isnull(Max (convert(int,substring(GRNNo,1,5))),0) as GRNNo from StoreReceiptVoucherDtl where month(ReceiptDate)='" & Month & "' and year(ReceiptDate)='" & year & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastGRNNo(ByVal lastNo As Integer, ByVal Month As Integer, ByVal year As Integer)
            Dim str As String
            ' str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' order By tblBankMstID DESC"
            'str = " select Top 1 VoucherNo from tblBankMst where month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "' order By tblBankMstID DESC"
            ' str = " select VoucherNo from tblBankMst where substring(VoucherNo,11,20)=" & lastNo & " and  month(VoucherDate)='" & Month & "' and year(VoucherDate)='" & year & "'"
            str = " select GRNNo from StoreReceiptVoucherDtl where substring(GRNNo,1,5)=" & lastNo & " and  month(ReceiptDate)='" & Month & "' and year(ReceiptDate)='" & year & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function




    End Class
End Namespace
 