Imports Microsoft.VisualBasic
'**************************************************************************************
'*      Class Name         :    CottonItemThree.vb
'*      Class Description  :    Provided Business Logic related to entity "CottonItemThree"
'*      Core Table         :    POClaim
'**************************************************************************************
Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 
Namespace EuroCentra

    Public Class POClaimDetail
        Inherits SQLManager
        '*******************************************************
        '                   Class Constructor
        '*******************************************************
        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "POClaimDetail"
            m_strPrimaryFieldName = "POClaimDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPOClaimDetailID As Long
        Private m_lPOClaimID As Long
        Private m_lPODetailID As Long
        Private m_lStyleID As Long
        Private m_lStyleDetailID As Long
        Private m_strPOQuantity As Decimal
        Private m_dcClaimQuantity As Decimal


        Public Property POClaimDetailID() As Long
            Get
                POClaimDetailID = m_lPOClaimDetailID
            End Get
            Set(ByVal value As Long)
                m_lPOClaimDetailID = value
            End Set
        End Property
        Public Property POClaimID() As Long
            Get
                POClaimID = m_lPOClaimID
            End Get
            Set(ByVal value As Long)
                m_lPOClaimID = value
            End Set
        End Property
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal value As Long)
                m_lPODetailID = value
            End Set
        End Property
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
            End Set
        End Property
        Public Property StyleDetailID() As Long
            Get
                StyleDetailID = m_lStyleDetailID
            End Get
            Set(ByVal value As Long)
                m_lStyleDetailID = value
            End Set
        End Property
        Public Property POQuantity() As Decimal
            Get
                POQuantity = m_strPOQuantity
            End Get
            Set(ByVal value As Decimal)
                m_strPOQuantity = value
            End Set
        End Property
        Public Property ClaimQuantity() As Decimal
            Get
                ClaimQuantity = m_dcClaimQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dcClaimQuantity = value
            End Set
        End Property
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function SavePOClaimDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace