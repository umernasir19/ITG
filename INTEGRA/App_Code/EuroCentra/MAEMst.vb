Imports Microsoft.VisualBasic
Imports System.Data

Public Class MAEMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "MAE"
        m_strPrimaryFieldName = "MAEID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lMAEID As Long
    Private m_lUserID As Long
    Private m_dtCreationDate As Date
    Private m_strTagNo As String
    Private m_strName As String
    Private m_strMAEDescription As String
    Private m_strModel As String
    Private m_strBrand As String
    Private m_dtPurchasedDate As Date
    Private m_dPurchasedPrice As Decimal
    Private m_dDepreciationPeriod As Decimal
    Private m_dHealthRate As Decimal
    Private m_dOperationalCost As Decimal
    Private m_dKWHConsumption As Decimal
    Private m_strWarrantyClaimable As String
    Private m_strDimension As String
    Private m_dGrossWait As Decimal
    Private m_lDeptDatabaseID As Long
    Private m_lUnitID As Long
    Public Property DeptDatabaseID() As Long
        Get
            DeptDatabaseID = m_lDeptDatabaseID
        End Get
        Set(ByVal Value As Long)
            m_lDeptDatabaseID = Value
        End Set
    End Property
    Public Property UnitID() As Long
        Get
            UnitID = m_lUnitID
        End Get
        Set(ByVal Value As Long)
            m_lUnitID = Value
        End Set
    End Property
    Public Property MAEID() As Long
        Get
            MAEID = m_lMAEID
        End Get
        Set(ByVal Value As Long)
            m_lMAEID = Value
        End Set
    End Property
    Public Property UserID() As Long
        Get
            UserID = m_lUserID
        End Get
        Set(ByVal Value As Long)
            m_lUserID = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal Value As Date)
            m_dtCreationDate = Value
        End Set
    End Property
    Public Property TagNo() As String
        Get
            TagNo = m_strTagNo
        End Get
        Set(ByVal Value As String)
            m_strTagNo = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Name = m_strName
        End Get
        Set(ByVal Value As String)
            m_strName = Value
        End Set
    End Property
    Public Property MAEDescription() As String
        Get
            MAEDescription = m_strMAEDescription
        End Get
        Set(ByVal Value As String)
            m_strMAEDescription = Value
        End Set
    End Property
    Public Property Model() As String
        Get
            Model = m_strModel
        End Get
        Set(ByVal Value As String)
            m_strModel = Value
        End Set
    End Property
    Public Property Brand() As String
        Get
            Brand = m_strBrand
        End Get
        Set(ByVal Value As String)
            m_strBrand = Value
        End Set
    End Property
    Public Property PurchasedDate() As Date
        Get
            PurchasedDate = m_dtPurchasedDate
        End Get
        Set(ByVal Value As Date)
            m_dtPurchasedDate = Value
        End Set
    End Property
    Public Property PurchasedPrice() As Decimal
        Get
            PurchasedPrice = m_dPurchasedPrice
        End Get
        Set(ByVal Value As Decimal)
            m_dPurchasedPrice = Value
        End Set
    End Property
    Public Property DepreciationPeriod() As Decimal
        Get
            DepreciationPeriod = m_dDepreciationPeriod
        End Get
        Set(ByVal Value As Decimal)
            m_dDepreciationPeriod = Value
        End Set
    End Property
    Public Property HealthRate() As Decimal
        Get
            HealthRate = m_dHealthRate
        End Get
        Set(ByVal Value As Decimal)
            m_dHealthRate = Value
        End Set
    End Property
    Public Property OperationalCost() As Decimal
        Get
            OperationalCost = m_dOperationalCost
        End Get
        Set(ByVal Value As Decimal)
            m_dOperationalCost = Value
        End Set
    End Property
    Public Property KWHConsumption() As Decimal
        Get
            KWHConsumption = m_dKWHConsumption
        End Get
        Set(ByVal Value As Decimal)
            m_dKWHConsumption = Value
        End Set
    End Property
    Public Property GrossWait() As Decimal
        Get
            GrossWait = m_dGrossWait
        End Get
        Set(ByVal Value As Decimal)
            m_dGrossWait = Value
        End Set
    End Property
    Public Property WarrantyClaimable() As String
        Get
            WarrantyClaimable = m_strWarrantyClaimable
        End Get
        Set(ByVal Value As String)
            m_strWarrantyClaimable = Value
        End Set
    End Property
    Public Property Dimension() As String
        Get
            Dimension = m_strDimension
        End Get
        Set(ByVal Value As String)
            m_strDimension = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Function getCustomerAttachmentList()
        Dim str As String
        str = "Select * from AttachmentList  "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function getDataa(ByVal MEID As Integer, ByVal AttachmentListID As Integer) As DataTable
        Dim str As String
        str = "select * from MEAttachment where MEID='" & MEID & "' and AttachmentListID='" & AttachmentListID & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function BindDept() As DataTable
        Dim str As String
        str = " select DeptDatabaseID,DeptDatabaseName +' ('+ DeptAbbrivation +')' as DeptDatabaseName"
        str &= " from IMSDepartmentDataBase order by DeptDatabaseName"
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindUnit() As DataTable
        Dim str As String
        str = " select *"
        str &= " from Unit "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function BindMAEPageView()
        Dim str As String
        Try

            str = " select *  From MAE"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function BindMAEPageEdit(ByVal MAEedit As String)
        Dim str As String
        Try

            str = " select *  From MAE mst"
            str &= " join IMSDepartmentDataBase D on D.DeptDatabaseID=MST.DeptDatabaseID"
            str &= " join Unit U on U.UnitID=MST.UnitID"
            str &= "  Where mst.MAEID = " & MAEedit & ""

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

End Class
