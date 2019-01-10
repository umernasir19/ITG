imports system.data
Namespace EuroCentra
    Public Class DPPODtl
        Inherits sqlmanager
        Public Sub New()
            m_strTableName = "DPPODtl"
            m_strPrimaryFieldName = "DPPODtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lDPPODtlID As Long
        Private m_lDPPOMstID As Long
        Private m_strItemName As String
        Private m_lUnitID As Long
        Private m_strUnit As String
        Private m_dQuantity As Decimal
        Private m_dRate As Decimal
        Private m_dAmount As Decimal
        Private m_dDelDate As Date

        Private m_lDPRNDID As Long
        Private m_strStyle As String
        Private m_strDCNO As String

        Public Property DPPODtlID() As Long
            Get
                DPPODtlID = m_lDPPODtlID
            End Get
            Set(ByVal value As Long)
                m_lDPPODtlID = value
            End Set
        End Property
        Public Property DPPOMstID() As Long
            Get
                DPPOMstID = m_lDPPOMstID
            End Get
            Set(ByVal value As Long)
                m_lDPPOMstID = value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal value As String)
                m_strItemName = value
            End Set
        End Property
        Public Property DCNO() As String
            Get
                DCNO = m_strDCNO
            End Get
            Set(ByVal value As String)
                m_strDCNO = value
            End Set
        End Property
        Public Property UnitID() As Long
            Get
                UnitID = m_lUnitID
            End Get
            Set(ByVal value As Long)
                m_lUnitID = value
            End Set
        End Property
    
        Public Property Unit() As String
            Get
                Unit = m_strUnit
            End Get
            Set(ByVal value As String)
                m_strUnit = value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dQuantity = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = m_dRate
            End Get
            Set(ByVal value As Decimal)
                m_dRate = value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dAmount
            End Get
            Set(ByVal value As Decimal)
                m_dAmount = value
            End Set
        End Property
        Public Property DelDate() As Date
            Get
                DelDate = m_dDelDate
            End Get
            Set(ByVal value As Date)
                m_dDelDate = value
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
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Function SavedTL()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

