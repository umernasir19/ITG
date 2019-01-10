Imports System.Data

Namespace EuroCentra
    Public Class RequisitionerInfoClass
        Inherits SQLManager


        Public Sub New()
            m_strTableName = "InventoryRequestMaster"
            m_strPrimaryFieldName = "InventoryRequestMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lInventoryRequestMasterID As Long

        Private m_dtCurrentDate As Date
        Private m_strRequisitionerName As String
        Private m_strDepartment As String
        Private m_strApprovalDate As String
        Private m_strApprovedBy As String
        Private m_strPriorityUrgentNormal As String
        Private m_bolApprovalStatus As Boolean


        '----------------Properties
        Public Property InventoryRequestMasterID() As Long
            Get
                InventoryRequestMasterID = m_lInventoryRequestMasterID
            End Get
            Set(ByVal Value As Long)
                m_lInventoryRequestMasterID = Value
            End Set
        End Property
      
        Public Property CurrentDate() As Date
            Get
                CurrentDate = m_dtCurrentDate
            End Get
            Set(ByVal Value As Date)
                m_dtCurrentDate = Value
            End Set
        End Property
        Public Property RequisitionerName() As String
            Get
                RequisitionerName = m_strRequisitionerName
            End Get
            Set(ByVal value As String)
                m_strRequisitionerName = value
            End Set
        End Property

        Public Property Department() As String
            Get
                Department = m_strDepartment
            End Get
            Set(ByVal value As String)
                m_strDepartment = value
            End Set
        End Property

        Public Property ApprovalDate() As String
            Get
                ApprovalDate = m_strApprovalDate
            End Get
            Set(ByVal Value As String)
                m_strApprovalDate = Value
            End Set
        End Property

        Public Property ApprovedBy() As String
            Get
                ApprovedBy = m_strApprovedBy
            End Get
            Set(ByVal value As String)
                m_strApprovedBy = value
            End Set
        End Property
        Public Property PriorityUrgentNormal() As String
            Get
                PriorityUrgentNormal = m_strPriorityUrgentNormal
            End Get
            Set(ByVal value As String)
                m_strPriorityUrgentNormal = value
            End Set
        End Property
        Public Property ApprovalStatus() As Boolean
            Get
                ApprovalStatus = m_bolApprovalStatus
            End Get
            Set(ByVal value As Boolean)
                m_bolApprovalStatus = value
            End Set
        End Property


        Public Function GetlastInventoryDatabaseID() As Long
            Return MyBase.GetCurrentId
        End Function
        Public Function saveRequisitionerInfo()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemView() As DataTable
            Dim str As String

            str = "select InventoryDatabaseID,ItemCode,ItemDescription,UnitPrice,Requisition from InventoryDatabase"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetUSerInfoNew(ByVal USerID) As DataTable
            Dim str As String
            ' str = "Select um.*,po.EKNumber  from UMUSer um join PurchaseOrder po on po.MarchandID=um.UserId where USerID='" & USerID & "' and um.IsActive=1"
            str = "select * from umuser where UserId=' " & USerID & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRequisitionerApprovalView() As DataTable
            Dim str As String

            str = "select * from InventoryRequestMaster where approvalstatus=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetRequisitionerApprovalViewPopup(ByVal InventoryRequestMasterID As Long) As DataTable
            Dim str As String

            str = "select ird.*, id.ItemDescription from InventoryRequestDetail ird join  InventoryRequestMaster irm on ird.InventoryRequestMasterID = irm.InventoryRequestMasterID join InventoryDatabase id on ird.InventoryDatabaseID = id.InventoryDatabaseID where irm.InventoryRequestMasterID = ' " & InventoryRequestMasterID & " ' and ird.Status=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


        Public Function GetEditPopup(ByVal InventoryRequestMasterID As Long) As DataTable
            Dim str As String

            str = " select * from InventoryRequestMaster where InventoryRequestMasterID= ' " & InventoryRequestMasterID & " '"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function



    End Class

End Namespace
