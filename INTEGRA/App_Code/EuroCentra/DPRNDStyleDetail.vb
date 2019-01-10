Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
Public Class DPRNDStyleDetail

  Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPRNDStyleDetail"
            m_strPrimaryFieldName = "DPRNDStyleDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPRNDStyleDetailID As Long
        Private m_lDPRNDID As Long
        Private m_strDescription As String
        Private m_IsBodyFabric As Boolean
        Private m_strSizes As String
        Private m_strStyleWidth As String
        Private m_strShrinkageLength As String
        Private m_strShrinkageWidth As String
        Private m_strMarkerLengthWithSize As String
        Private m_strConsumptionPerPcs As Decimal
        Private m_strOtherDetail As String
        Private m_dcPrice As Decimal
        Private m_lConsumptionUnitid As Long
      
        Public Property ConsumptionUnitid() As Long
            Get
                ConsumptionUnitid = m_lConsumptionUnitid
            End Get
            Set(ByVal value As Long)
                m_lConsumptionUnitid = value
            End Set
        End Property
        Public Property DPRNDStyleDetailID() As Long
            Get
                DPRNDStyleDetailID = m_lDPRNDStyleDetailID
            End Get
            Set(ByVal value As Long)
                m_lDPRNDStyleDetailID = value
            End Set
        End Property
        
        Public Property DPRNDID() As Long
            Get
                DPRNDID = m_lDPRNDID
            End Get
            Set(ByVal value As Long)
                m_lDPRNDID = value
            End Set
        End Property
       
        
        Public Property Description() As String
            Get
                DESCRIPTION = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set

        End Property
        Public Property IsBodyFabric() As Boolean
            Get
                IsBodyFabric = m_IsBodyFabric
            End Get
            Set(ByVal value As Boolean)
                m_IsBodyFabric = value
            End Set
        End Property
        Public Property Sizes() As String
            Get
                Sizes = m_strSizes
            End Get
            Set(ByVal value As String)
                m_strSizes = value
            End Set

        End Property
        Public Property StyleWidth() As String
            Get
                StyleWidth = m_strStyleWidth
            End Get
            Set(ByVal value As String)
                m_strStyleWidth = value
            End Set

        End Property

        Public Property ShrinkageLength() As String
            Get
                ShrinkageLength = m_strShrinkageLength
            End Get
            Set(ByVal value As String)
                m_strShrinkageLength = value
            End Set

        End Property
        Public Property ShrinkageWidth() As String
            Get
                ShrinkageWidth = m_strShrinkageWidth
            End Get
            Set(ByVal value As String)
                m_strShrinkageWidth = value
            End Set

        End Property

        Public Property MarkerLengthWithSize() As String
            Get
                MarkerLengthWithSize = m_strMarkerLengthWithSize
            End Get
            Set(ByVal value As String)
                m_strMarkerLengthWithSize = value
            End Set

        End Property
        Public Property ConsumptionPerPcs() As Decimal
            Get
                ConsumptionPerPcs = m_strConsumptionPerPcs
            End Get
            Set(ByVal value As Decimal)
                m_strConsumptionPerPcs = value
            End Set

        End Property
       
        Public Property OtherDetail() As String
            Get
                OtherDetail = m_strOtherDetail
            End Get
            Set(ByVal value As String)
                m_strOtherDetail = value
            End Set

        End Property
        
        Public Property Price() As Decimal
            Get
                Price = m_dcPrice
            End Get
            Set(ByVal value As Decimal)
                m_dcPrice = value
            End Set
        End Property
        Public Function SaveStyleDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        

        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace


