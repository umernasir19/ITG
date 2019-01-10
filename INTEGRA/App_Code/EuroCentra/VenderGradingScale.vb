Imports System.Data

Namespace EuroCentra
    Public Class VenderGradingScale
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderGradingScale"
            m_strPrimaryFieldName = "SupplierGradingScaleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSupplierGradingScaleID As Long
        Private m_lVenderID As Long
        Private m_lSocialCompliance As Long
        Private m_lSupplyChain As Long
        Private m_lBusinessDevelopment As Long
        Private m_lMerchant As Long
        Private m_lQAGroup As Long
        Private m_bManagementApproval As Boolean
        Private m_strAboutSupplier As String
        Private m_bIsActive As Boolean
        Private m_strAnnualturnover As String
        Private m_strAmtSign As String
        Private m_strCapacity As String
        Private m_strCapacityUnit As String


        ''---------------- Properties
        Public Property Capacity() As String
            Get
                Capacity = m_strCapacity
            End Get
            Set(ByVal value As String)
                m_strCapacity = value
            End Set
        End Property
        Public Property CapacityUnit() As String
            Get
                CapacityUnit = m_strCapacityUnit
            End Get
            Set(ByVal value As String)
                m_strCapacityUnit = value
            End Set
        End Property
        Public Property SupplierGradingScaleID() As Long
            Get
                SupplierGradingScaleID = m_lSupplierGradingScaleID
            End Get
            Set(ByVal value As Long)
                m_lSupplierGradingScaleID = value
            End Set
        End Property
        Public Property VenderID() As Long
            Get
                VenderID = m_lVenderID
            End Get
            Set(ByVal value As Long)
                m_lVenderID = value
            End Set
        End Property
        Public Property SocialCompliance() As Long
            Get
                SocialCompliance = m_lSocialCompliance
            End Get
            Set(ByVal value As Long)
                m_lSocialCompliance = value
            End Set
        End Property
        Public Property SupplyChain() As Long
            Get
                SupplyChain = m_lSupplyChain
            End Get
            Set(ByVal value As Long)
                m_lSupplyChain = value
            End Set
        End Property
        Public Property BusinessDevelopment() As Long
            Get
                BusinessDevelopment = m_lBusinessDevelopment
            End Get
            Set(ByVal value As Long)
                m_lBusinessDevelopment = value
            End Set
        End Property
        Public Property Merchant() As Long
            Get
                Merchant = m_lMerchant
            End Get
            Set(ByVal value As Long)
                m_lMerchant = value
            End Set
        End Property
        Public Property QAGroup() As Long
            Get
                QAGroup = m_lQAGroup
            End Get
            Set(ByVal value As Long)
                m_lQAGroup = value
            End Set
        End Property
        Public Property ManagementApproval() As Boolean
            Get
                ManagementApproval = m_bManagementApproval
            End Get
            Set(ByVal value As Boolean)
                m_bManagementApproval = value
            End Set
        End Property
        Public Property AboutSupplier() As String
            Get
                AboutSupplier = m_strAboutSupplier
            End Get
            Set(ByVal value As String)
                m_strAboutSupplier = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property
        Public Property Annualturnover() As String
            Get
                Annualturnover = m_strAnnualturnover
            End Get
            Set(ByVal value As String)
                m_strAnnualturnover = value
            End Set
        End Property
        Public Property AmtSign() As String
            Get
                AmtSign = m_strAmtSign
            End Get
            Set(ByVal value As String)
                m_strAmtSign = value
            End Set
        End Property
        Public Function SaveVenderGradingScale()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorView() As DataTable
            Dim str As String
            str = "select ColorID as ID,Color as Name,TransType='Color' from Color"
            str &= " Union All"
            str &= " select SizeID as ID,SizeDescription as Name,TransType='Size' from Size"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorData(ByVal ColorID As Integer) As DataTable
            Dim str As String
            str = "select * from Color where ColorID=" & ColorID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColor() As DataTable
            Dim str As String
            str = "Select ColorID,Color from Color "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function RemoveBeforeEdit(ByVal Venderid As Integer)
            Dim str As String
            str = "delete from VenderGradingScale where VenderID=" & Venderid
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace