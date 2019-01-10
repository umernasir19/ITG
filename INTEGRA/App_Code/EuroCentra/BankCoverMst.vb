Imports Microsoft.VisualBasic
Imports System.Data
Public Class BankCoverMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "BankCoverMst"
        m_strPrimaryFieldName = "BankCoverMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lBankCoverMstID As Long
    Private m_lInvNo As String
    Private m_dtInvDate As Date
    Private m_strBankAdd As String
    Private m_lCargoID As Long
    Public Property CargoID() As Long
        Get
            CargoID = m_lCargoID
        End Get
        Set(ByVal Value As Long)
            m_lCargoID = Value
        End Set
    End Property
    Public Property BankCoverMstID() As Long
        Get
            BankCoverMstID = m_lBankCoverMstID
        End Get
        Set(ByVal Value As Long)
            m_lBankCoverMstID = Value
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
    Public Property BankAdd() As String
        Get
            BankAdd = m_strBankAdd
        End Get
        Set(ByVal Value As String)
            m_strBankAdd = Value
        End Set
    End Property
    Public Property InvDate() As Date
        Get
            InvDate = m_dtInvDate
        End Get
        Set(ByVal Value As Date)
            m_dtInvDate = Value
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
    Public Function GetList() As DataTable
        Dim str As String
        str = " Select * from tblList"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetData(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " Select * from BankCoverMst where CargoID='" & CargoID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDataCargo(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " Select * from Cargo co"
        str &= " join CargoDetail cod on cod.CargoID =co.CargoID "
        str &= " join Customer cc on cc.CustomerID =cod.CustomerID "
        str &= " where co.CargoID ='" & CargoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try

    End Function
    Public Function GetDataBuyerCoverDetail(ByVal CargoID As Long) As DataTable
        Dim str As String
        str = " Select * from BankCoverMst cm "
        str &= " join BankCoverDtl cd on cd.BankCoverMstID =cm.BankCoverMstID "
        str &= " join tblList tl on tl.ListID =cd.ListID "
        str &= " where cm.CargoID ='" & CargoID & "'"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
End Class
