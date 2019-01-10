Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class DebitNote
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DebitNote"
            m_strPrimaryFieldName = "DebitNoteID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lDebitNoteID As Long
        Private m_dtCreationDate As Date
        Private m_strDNNo As String
        Private m_dtDNDate As Date
        Private m_strImportDept As String
        Private m_strAddressLine1 As String
        Private m_strAddressLine2 As String
        Private m_strAddressLine3 As String
        Private m_strAttn As String
        Private m_strDescription As String
        Private m_dcTotalValue As Decimal
        Private m_lCustomerid As Long
        Private m_strCustomerNamePart As String
        Private m_strCommissionMonth As Long
        Private m_strCommissionYear As Long
        Private m_strCurrency As String
        Private m_strSay As String
        Public Property DebitNoteID() As Long
            Get
                DebitNoteID = m_lDebitNoteID
            End Get
            Set(ByVal value As Long)
                m_lDebitNoteID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property DNNo() As String
            Get
                DNNo = m_strDNNo
            End Get
            Set(ByVal value As String)
                m_strDNNo = value
            End Set
        End Property
        Public Property DNDate() As Date
            Get
                DNDate = m_dtDNDate
            End Get
            Set(ByVal value As Date)
                m_dtDNDate = value
            End Set
        End Property
        Public Property ImportDept() As String
            Get
                ImportDept = m_strImportDept
            End Get
            Set(ByVal value As String)
                m_strImportDept = value
            End Set
        End Property
        Public Property AddressLine1() As String
            Get
                AddressLine1 = m_strAddressLine1
            End Get
            Set(ByVal value As String)
                m_strAddressLine1 = value
            End Set
        End Property
        Public Property AddressLine2() As String
            Get
                AddressLine2 = m_strAddressLine2
            End Get
            Set(ByVal value As String)
                m_strAddressLine2 = value
            End Set
        End Property
        Public Property AddressLine3() As String
            Get
                AddressLine3 = m_strAddressLine3
            End Get
            Set(ByVal value As String)
                m_strAddressLine3 = value
            End Set
        End Property
        Public Property Attn() As String
            Get
                Attn = m_strAttn
            End Get
            Set(ByVal value As String)
                m_strAttn = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        Public Property TotalValue() As Decimal
            Get
                TotalValue = m_dcTotalValue
            End Get
            Set(ByVal value As Decimal)
                m_dcTotalValue = value
            End Set
        End Property
        Public Property Customerid() As Long
            Get
                Customerid = m_lCustomerid
            End Get
            Set(ByVal value As Long)
                m_lCustomerid = value
            End Set
        End Property
        Public Property CustomerNamePart() As String
            Get
                CustomerNamePart = m_strCustomerNamePart
            End Get
            Set(ByVal value As String)
                m_strCustomerNamePart = value
            End Set
        End Property
        Public Property CommissionMonth() As Long
            Get
                CommissionMonth = m_strCommissionMonth
            End Get
            Set(ByVal value As Long)
                m_strCommissionMonth = value
            End Set
        End Property
        Public Property CommissionYear() As Long
            Get
                CommissionYear = m_strCommissionYear
            End Get
            Set(ByVal value As Long)
                m_strCommissionYear = value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal value As String)
                m_strCurrency = value
            End Set
        End Property
        Public Property Say() As String
            Get
                Say = m_strSay
            End Get
            Set(ByVal value As String)
                m_strSay = value
            End Set
        End Property
        Public Function SaveDebitNote()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCargoById(ByVal DebitNoteID As Long)
            Try
                Return MyBase.GetById(DebitNoteID)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData(ByVal CustomerID As String, ByVal MonthNo As String, ByVal YearNo As String, ByVal Currency As String)
            Dim str As String
            str = "   Select  Po.POID,CC.ETD,CC.Currency,CD.Quantity,CD.ShippedRate,"
            str &= " (CD.Quantity* CD.ShippedRate)as Value, C.Commission"
            str &= " from PurchaseOrder po Join PurchaseorderDetail POD on po.poid=pod.poid     "
            str &= "  Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            str &= "  Join Customer C on C.CustomerID=PO.Customerid   "
            str &= "  join Umuser UM on UM.UserID=Po.MarchandID    "
            str &= "  left join Cargodetail cd on pod.podetailid=cd.poid    "
            str &= " left join cargo CC on cc.cargoid=cd.cargoid    "
            str &= " where C.customerid=" & CustomerID
            str &= " and month(CC.ETD)= " & MonthNo
            str &= " and Year(CC.ETD)= " & YearNo
            str &= " and CC.Currency='" & Currency & "'"
            str &= " order by day(CC.ETD) ASC   "
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerNo(ByVal CustomerID As String)
            Dim str As String
            str = "   Select  * from Customer"
            str &= " where  customerid=" & CustomerID
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExistingDebitNot(ByVal CustomerID As String, ByVal MonthNo As String, ByVal YearNo As String, ByVal Currency As String)
            Dim str As String
            str = "  select * from DebitNote"
            str &= " where customerid=" & CustomerID
            str &= " and CommissionMonth= " & MonthNo
            str &= " and CommissionYear= " & YearNo
            str &= " and Currency='" & Currency & "'"
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllDataForView()
            Dim str As String
            str = "   Select  *, CONVERT(varchar, CONVERT(money, Totalvalue), 1)as Totalvaluee from DebitNote order by DebitNoteID DESC"
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetDebitNoteCustomer(ByVal DebitNoteID As Long)
            Dim str As String
            str = "   Select C.customerName from DebitNote  DN"
            str &= " join Customer C on C.Customerid=DN.Customerid "
            str &= " where DN.DebitNoteID=" & DebitNoteID
            Try
                Return MyBase.GetScaler(str)

            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace