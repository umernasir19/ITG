Imports System.Data
Imports Microsoft.VisualBasic

Public Class ICR
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ICR"
        m_strPrimaryFieldName = "ICRId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''
    Private m_lICRId As Long
    Private m_lPOId As Long
    Private m_dtCreationDate As Date
    Private m_lPOdetailID As Long
    Private m_dSuppling As Decimal
    Private m_dtDateProposed As Date
    Private m_strContactPerson As String
    Private m_strEmail As String
    Private m_strCATINSP As String

    ''---------------- Properties
    
    Public Property POdetailID() As Long
        Get
            POdetailID = m_lPOdetailID
        End Get
        Set(ByVal value As Long)
            m_lPOdetailID = value
        End Set
    End Property
    Public Property ICRId() As Long
        Get
            ICRId = m_lICRId
        End Get
        Set(ByVal value As Long)
            m_lICRId = value
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
    Public Property POID() As Long
        Get
            POID = m_lPOId
        End Get
        Set(ByVal Value As Long)
            m_lPOId = Value
        End Set
    End Property
    Public Property Suppling() As Decimal
        Get
            Suppling = m_dSuppling
        End Get
        Set(ByVal Value As Decimal)
            m_dSuppling = Value
        End Set
    End Property
    Public Property DateProposed() As Date
        Get
            DateProposed = m_dtDateProposed
        End Get
        Set(ByVal value As Date)
            m_dtDateProposed = value
        End Set
    End Property
    Public Property ContactPerson() As String
        Get
            ContactPerson = m_strContactPerson
        End Get
        Set(ByVal value As String)
            m_strContactPerson = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Email = m_strEmail
        End Get
        Set(ByVal value As String)
            m_strEmail = value
        End Set
    End Property
    Public Property CATINSP() As String
        Get
            CATINSP = m_strCATINSP
        End Get
        Set(ByVal value As String)
            m_strCATINSP = value
        End Set
    End Property
    
    Public Function GetId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function SaveICR()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetTNAChartById(ByVal lWIPChartId As Long)
        Try
            Return MyBase.GetById(lWIPChartId)
        Catch ex As Exception

        End Try
    End Function
    Function GetCurrentWIPProcess(ByVal POID As Long, ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select Top 1 * from WIPChart WC"
        Str &= " join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
        Str &= "  where WC.POID='" & POID & "' and POdetailID= '" & PODetailID & "'"
        Str &= " order by WC.WIPChartId DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetAllWIPProcess(ByVal POID As Long, ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select  *,upper(U.UserName)as UserNameF  from WIPChart WC"
        Str &= " join WIPProcess WP on WP.WIPProcessID=WC.WIPProcessID"
        Str &= " join Umuser u on u.userid=WC.Userid"
        Str &= "  where WC.Remarks <>'' and WC.POID='" & POID & "' and POdetailID= '" & PODetailID & "'"
        Str &= " order by WC.WIPChartId DESC"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetStatusOfExistingArticleOfOrder(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = "  Select   Distinct WC.PODetailID  from WIPChart WC   "
        Str &= "  where WC.WIPProcessID  = 12 and  WC.POID='" & POID & "' "
        'Str = " Select * from WIPChart WC "
        'Str &= "  where WC.WIPProcessID  <> 12 and  WC.POID='" & POID & "' "
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetWIPArticleOfOrder(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select  Distinct WC.PODetailID from   WIPChart WC   "
        Str &= "  where WC.POID = " & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleOfOrder(ByVal POID As Long) As DataTable
        Dim Str As String
        Str = " Select  Distinct POD.PODetailID from   purchaseorderDetail POD   "
        Str &= "  where POD.POID = " & POID
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMail(ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.PODetailID = " & PODetailID
        Str &= "  and WC.WIPProcessID  >= 6"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Function GetArticleForMailCutting(ByVal PODetailID As Long) As DataTable
        Dim Str As String
        Str = " Select * from WIPChart WC   "
        Str &= "  where WC.PODetailID = " & PODetailID
        Str &= "  and WC.WIPProcessID  >= 9"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
End Class
