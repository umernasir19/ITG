Imports System.Data
Imports Microsoft.VisualBasic
Public Class RateApprovalMst

    Inherits SQLManager
    Public Sub New()
        m_strTableName = "RateApprovalMst"
        m_strPrimaryFieldName = "RateApprovalMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.ShortType
    End Sub
    Private m_lRateApprovalMstID As Long
    Private m_dInvDate As Date
    Private m_lInvNo As String
    Private m_strBuyer As String
    Private m_dAmount As Decimal
    Private m_strterms As String
    Private m_dPKR As Decimal
    Private m_lFromID As Long
    Private m_dFinal As Decimal
    Private m_lCargoID As Long
    Public Property CargoID() As Long
        Get
            CargoID = m_lCargoID
        End Get
        Set(ByVal Value As Long)
            m_lCargoID = Value
        End Set
    End Property
    Public Property FromID() As Long
        Get
            FromID = m_lFromID
        End Get
        Set(ByVal Value As Long)
            m_lFromID = Value
        End Set
    End Property
    Public Property Final() As Decimal
        Get
            Final = m_dFinal
        End Get
        Set(ByVal Value As Decimal)
            m_dFinal = Value
        End Set
    End Property
    Public Property RateApprovalMstID() As Long
        Get
            RateApprovalMstID = m_lRateApprovalMstID
        End Get
        Set(ByVal Value As Long)
            m_lRateApprovalMstID = Value
        End Set
    End Property
    Public Property InvDate() As Date
        Get
            InvDate = m_dInvDate
        End Get
        Set(ByVal Value As Date)
            m_dInvDate = Value
        End Set
    End Property
    Public Property InvNo() As String
        Get
            InvNo = m_lInvNo
        End Get
        Set(ByVal Value As String)
            m_lInvNo = Value
        End Set
    End Property
    Public Property Buyer() As String
        Get
            Buyer = m_strBuyer
        End Get
        Set(ByVal Value As String)
            m_strBuyer = Value
        End Set
    End Property
    Public Property Amount() As Decimal
        Get
            Amount = m_dAmount
        End Get
        Set(ByVal Value As Decimal)
            m_dAmount = Value
        End Set
    End Property
    Public Property terms() As String
        Get
            terms = m_strterms
        End Get
        Set(ByVal Value As String)
            m_strterms = Value
        End Set
    End Property
    Public Property PKR() As Decimal
        Get
            PKR = m_dPKR
        End Get
        Set(ByVal Value As Decimal)
            m_dPKR = Value
        End Set
    End Property
   

    Public Function SaveMst()
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
    Public Function GetBank()
        Dim Str As String
        Str = " select * From BankName  "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function Getdatanew(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " select c.Aliass as BuyerName,co.InvoiceNo ,s.InvoiceAmount ,s.ExchangeRate ,s.AmountInPKR ,s.Remarks ,s.BankCode ,s.LCNO,co.DateOfIssue,co.DateOfIssue,s.PaymentTerms,isnull((rs.FromID),0)as FromID ,isnull((rs.Final),0)as Final from Shipment s"
        str &= " join Cargo co on co.CargoID =s.CargoID "
        str &= " join Customer c on c.CustomerName =s.Buyer "
        str &= " left join RateApprovalMst rs on rs.CargoID =s.CargoID "
        str &= " where s.CargoID='" & CargoID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetData(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " Select * from RateApprovalMst where CargoID='" & CargoID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDataDetail(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " Select * from RateApprovalMst cm "
        str &= " join RateApprovalDtl cd on cd.RateApprovalMstID =cm.RateApprovalMstID "
        str &= " join BankName tl on tl.BankID =cd.BankID "
        str &= " where cm.CargoID ='" & CargoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
