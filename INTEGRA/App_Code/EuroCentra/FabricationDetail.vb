Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabricationDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabricationDetail"
            m_strPrimaryFieldName = "FabricationDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricationDetailID As Long
        Private m_lFabricationMasterID As Long
        Private m_lFabricPlacementID As Long
        Private m_lContentID As Long
        Private m_lFabricTypeID As Long
        Private m_dGSM As Decimal
        Private m_dWidth As Decimal
        Private m_dLength As Decimal
        Private m_dWastage As Decimal
        Private m_dCPD As Decimal
        Private m_dGross As Decimal

        Public Property FabricationDetailID() As Long
            Get
                FabricationDetailID = m_lFabricationDetailID
            End Get
            Set(ByVal Value As Long)
                m_lFabricationDetailID = Value
            End Set
        End Property
        Public Property FabricationMasterID() As Long
            Get
                FabricationMasterID = m_lFabricationMasterID
            End Get
            Set(ByVal Value As Long)
                m_lFabricationMasterID = Value
            End Set
        End Property
        Public Property FabricPlacementID() As Long
            Get
                FabricPlacementID = m_lFabricPlacementID
            End Get
            Set(ByVal value As Long)
                m_lFabricPlacementID = value
            End Set
        End Property
        Public Property ContentID() As Long
            Get
                ContentID = m_lContentID
            End Get
            Set(ByVal value As Long)
                m_lContentID = value
            End Set
        End Property
        Public Property FabricTypeID() As Long
            Get
                FabricTypeID = m_lFabricTypeID
            End Get
            Set(ByVal value As Long)
                m_lFabricTypeID = value
            End Set
        End Property
        Public Property GSM() As Decimal
            Get
                GSM = m_dGSM
            End Get
            Set(ByVal value As Decimal)
                m_dGSM = value
            End Set
        End Property
        Public Property Width() As Decimal
            Get
                Width = m_dWidth
            End Get
            Set(ByVal value As Decimal)
                m_dWidth = value
            End Set
        End Property
        Public Property Length() As Decimal
            Get
                Length = m_dLength
            End Get
            Set(ByVal value As Decimal)
                m_dLength = value
            End Set
        End Property
        Public Property Wastage() As Decimal
            Get
                Wastage = m_dWastage
            End Get
            Set(ByVal value As Decimal)
                m_dWastage = value
            End Set
        End Property
        Public Property CPD() As Decimal
            Get
                CPD = m_dCPD
            End Get
            Set(ByVal value As Decimal)
                m_dCPD = value
            End Set
        End Property
        Public Property Gross() As Decimal
            Get
                Gross = m_dGross
            End Get
            Set(ByVal value As Decimal)
                m_dGross = value
            End Set
        End Property

        Public Function SaveFabricationDetail()
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
    End Class
End Namespace

