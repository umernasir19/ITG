Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Public Class DPCourierMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "DPCourierMst"
        m_strPrimaryFieldName = "DPCourierMstId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lDPCourierMstId As Long
    Private m_strExpRegNo As String
    Private m_strNtnNo As String
    Private m_strInvNo As String
    Private m_dCourDate As Date
    Private m_strAccountNo As String
    Private m_strInvOf As String
    Private m_strShippedPer As String
    Private m_strFrmKhiTo As String
    Private m_strWeight As String
    Private m_strCourAirBillNo As String
    Private m_lBuyerId As Long
    Private m_strAddress As String
    Private m_strDCDNo As String
    Private m_strFileName As String
    Private m_imgImage As Object
    Private m_strRemarks As String
    Public Property Remarks() As String
        Get
            Remarks = m_strRemarks
        End Get
        Set(ByVal value As String)
            m_strRemarks = value
        End Set
    End Property
    Public Property DCDNo() As String
        Get
            DCDNo = m_strDCDNo
        End Get
        Set(ByVal value As String)
            m_strDCDNo = value
        End Set
    End Property
    Public Property DPCourierMstId() As Long
        Get
            DPCourierMstId = m_lDPCourierMstId
        End Get
        Set(ByVal value As Long)
            m_lDPCourierMstId = value
        End Set
    End Property
    Public Property ExpRegNo() As String
        Get
            ExpRegNo = m_strExpRegNo
        End Get
        Set(ByVal value As String)
            m_strExpRegNo = value
        End Set
    End Property
    Public Property NtnNo() As String
        Get
            NtnNo = m_strNtnNo
        End Get
        Set(ByVal value As String)
            m_strNtnNo = value
        End Set
    End Property
    Public Property InvNo() As String
        Get
            InvNo = m_strInvNo
        End Get
        Set(ByVal value As String)
            m_strInvNo = value
        End Set
    End Property
    Public Property CourDate() As Date
        Get
            CourDate = m_dCourDate
        End Get
        Set(ByVal value As Date)
            m_dCourDate = value
        End Set
    End Property
    Public Property AccountNo() As String
        Get
            AccountNo = m_strAccountNo
        End Get
        Set(ByVal value As String)
            m_strAccountNo = value
        End Set
    End Property
    Public Property FileName() As String
        Get
            FileName = m_strFileName
        End Get
        Set(ByVal value As String)
            m_strFileName = value
        End Set
    End Property
    Public Property Image() As Object
        Get
            Image = m_imgImage
        End Get
        Set(ByVal value As Object)
            m_imgImage = value
        End Set
    End Property
    Public Property InvOf() As String
        Get
            InvOf = m_strInvOf
        End Get
        Set(ByVal value As String)
            m_strInvOf = value
        End Set
    End Property
    Public Property ShippedPer() As String
        Get
            ShippedPer = m_strShippedPer
        End Get
        Set(ByVal value As String)
            m_strShippedPer = value
        End Set
    End Property
    Public Property FrmKhiTo() As String
        Get
            FrmKhiTo = m_strFrmKhiTo
        End Get
        Set(ByVal value As String)
            m_strFrmKhiTo = value
        End Set
    End Property
    Public Property Weight() As String
        Get
            Weight = m_strWeight
        End Get
        Set(ByVal value As String)
            m_strWeight = value
        End Set
    End Property
    Public Property CourAirBillNo() As String
        Get
            CourAirBillNo = m_strCourAirBillNo
        End Get
        Set(ByVal value As String)
            m_strCourAirBillNo = value
        End Set
    End Property
    Public Property BuyerId() As Long
        Get
            BuyerId = m_lBuyerId
        End Get
        Set(ByVal value As Long)
            m_lBuyerId = value
        End Set
    End Property
    Public Property Address() As String
        Get
            Address = m_strAddress
        End Get
        Set(ByVal value As String)
            m_strAddress = value
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
    Function GetDCDNo(ByVal DCDNO As String)
        Dim Str As String
        Str = " select DCDNO AS Name from DPCourierMst where DCDNO like '" & DCDNo & "%'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetLastNo()
        Dim str As String
        str = "  select Top 1 DDCNo from DPCourierMst  order By DPCourierMstId DESC"
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetCustomer()
        Dim str As String
        Try
            str = "select * from Customer "

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetView()
        Dim str As String
        Try
            str = "select convert(varchar,CourDate,103) as CourDatee,* from DPCourierMst "

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetCurrency()
        Dim str As String
        Try
            str = "select * from Currency "

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetCourierData(ByVal DCDNo As String)
        Dim str As String
        Try
            str = " Select convert(varchar,dd.DeliveryDate ,103)as deliverDate,* from DPCourierMst dc"
            str &= " join DPCourierDtl dd on dd.DPCourierMstId =dc.DPCourierMstId "
            str &= " where dc.DCDNo ='" & DCDNo & "'"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetAddress(ByVal CustomerName As String)
        Dim str As String
        Try
            str = " select * from  Customer"
            str &= " where CustomerName ='" & CustomerName & "'"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetEdit(ByVal DPCourierMstId As Long)
        Dim str As String
        Try
            str = " Select * from DPCourierMst dc"
            str &= " join DPCourierDtl dd on dd.DPCourierMstId =dc.DPCourierMstId "
            str &= " where dc.DPCourierMstId ='" & DPCourierMstId & "'"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class
