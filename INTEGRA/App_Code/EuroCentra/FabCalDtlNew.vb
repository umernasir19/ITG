Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabCalDtlNew
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabCalDtl"
            m_strPrimaryFieldName = "FabCalDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabCalDtlID As Long
        Private m_lFabCalMstID As Long
        Private m_lJobOrderId As Long
        Private m_lSeasonDatabaseId As Long
        Private m_lJobOrderDetailid As Long

        Private m_strSrno As String
        Private m_strORDERNO As String
        Private m_strColor As String
        Private m_strMODEL As String
        Private m_strDESCRIPTION As String
        Private m_strSIZES As String


        Private m_dExtraQty As Decimal
        Private m_dEstCon As Decimal
        Private m_dOrderCon As Decimal
        Private m_dActCon As Decimal
        Private m_dFinalCon As Decimal
        Private m_dActlpcs As Decimal
        Private m_dMulPercnt As Decimal
        Private m_dTotalPcs As Decimal
        Private m_dFabricReq As Decimal
        Private m_dTotalRequirement As Decimal
        Public Property FabCalDtlID() As Long
            Get
                FabCalDtlId = m_lFabCalDtlID
            End Get
            Set(ByVal Value As Long)
                m_lFabCalDtlID = Value
            End Set
        End Property
        Public Property FabCalMstID() As Long
            Get
                FabCalMstID = m_lFabCalMstID
            End Get
            Set(ByVal Value As Long)
                m_lFabCalMstID = Value
            End Set
        End Property
        Public Property JobOrderId() As Long
            Get
                JobOrderId = m_lJobOrderId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderId = Value
            End Set
        End Property
        Public Property SeasonDatabaseId() As Long
            Get
                SeasonDatabaseId = m_lSeasonDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lSeasonDatabaseId = Value
            End Set
        End Property
        Public Property JobOrderDetailid() As Long
            Get
                JobOrderDetailid = m_lJobOrderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderDetailid = Value
            End Set
        End Property
        Public Property Srno() As String
            Get
                Srno = m_strSrno
            End Get
            Set(ByVal Value As String)
                m_strSrno = Value
            End Set
        End Property
        Public Property ORDERNO() As String
            Get
                ORDERNO = m_strORDERNO
            End Get
            Set(ByVal Value As String)
                m_strORDERNO = Value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal Value As String)
                m_strColor = Value
            End Set
        End Property
        Public Property MODEL() As String
            Get
                MODEL = m_strMODEL
            End Get
            Set(ByVal Value As String)
                m_strMODEL = Value
            End Set
        End Property
        Public Property DESCRIPTION() As String
            Get
                DESCRIPTION = m_strDESCRIPTION
            End Get
            Set(ByVal Value As String)
                m_strDESCRIPTION = Value
            End Set
        End Property
        Public Property SIZES() As String
            Get
                SIZES = m_strSIZES
            End Get
            Set(ByVal Value As String)
                m_strSIZES = Value
            End Set
        End Property
        Public Property ExtraQty() As Decimal
            Get
                ExtraQty = m_dExtraQty
            End Get
            Set(ByVal Value As Decimal)
                m_dExtraQty = Value
            End Set
        End Property
        Public Property EstCon() As Decimal
            Get
                EstCon = m_dEstCon
            End Get
            Set(ByVal Value As Decimal)
                m_dEstCon = Value
            End Set
        End Property
        Public Property OrderCon() As Decimal
            Get
                OrderCon = m_dOrderCon
            End Get
            Set(ByVal Value As Decimal)
                m_dOrderCon = Value
            End Set
        End Property
        Public Property ActCon() As Decimal
            Get
                ActCon = m_dActCon
            End Get
            Set(ByVal Value As Decimal)
                m_dActCon = Value
            End Set
        End Property
        Public Property FinalCon() As Decimal
            Get
                FinalCon = m_dFinalCon
            End Get
            Set(ByVal Value As Decimal)
                m_dFinalCon = Value
            End Set
        End Property
        Public Property Actlpcs() As Decimal
            Get
                Actlpcs = m_dActlpcs
            End Get
            Set(ByVal Value As Decimal)
                m_dActlpcs = Value
            End Set
        End Property
        Public Property MulPercnt() As Decimal
            Get
                MulPercnt = m_dMulPercnt
            End Get
            Set(ByVal Value As Decimal)
                m_dMulPercnt = Value
            End Set
        End Property
        Public Property TotalPcs() As Decimal
            Get
                TotalPcs = m_dTotalPcs
            End Get
            Set(ByVal Value As Decimal)
                m_dTotalPcs = Value
            End Set
        End Property
        Public Property FabricReq() As Decimal
            Get
                FabricReq = m_dFabricReq
            End Get
            Set(ByVal Value As Decimal)
                m_dFabricReq = Value
            End Set
        End Property
        Public Property TotalRequirement() As Decimal
            Get
                TotalRequirement = m_dTotalRequirement
            End Get
            Set(ByVal Value As Decimal)
                m_dTotalRequirement = Value
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
    End Class
End Namespace

