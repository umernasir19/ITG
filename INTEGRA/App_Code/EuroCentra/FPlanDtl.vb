Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra

    Public Class FPlanDtl
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FPlanDtl"
            m_strPrimaryFieldName = "FPlanDtlID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lFPlanDtlID As Long
        Private m_lFPlanMstID As Long
        Private m_lFabricdataBaseId As Long
        ' Private m_strFabricCode As String

        ' Private m_strWeave As String
        ' Private m_strGSM As String
        Private m_strWidth As String
        'Private m_strComposition As String
        Private m_DCReqMeter As Decimal
        Private m_DCConsumption As Decimal
        Private m_DTReqDate As Date
        'Private m_DCOpeningBal As Decimal
        'Private m_DCInhandQty As Decimal
        'Private m_DCBalanceQty As Decimal
        'Private m_DCIssueQty As Decimal
        'Private m_DCStockQty As Decimal

        Private m_DCPieceQty As Decimal
        Private m_lIMSItemID As Long
        Private m_bReqStatus As Boolean
        Private m_strStyle As String




        Public Property FPlanDtlID() As Long
            Get
                FPlanDtlID = m_lFPlanDtlID
            End Get
            Set(ByVal Value As Long)
                m_lFPlanDtlID = Value
            End Set
        End Property
        Public Property FPlanMstID() As Long
            Get
                FPlanMstID = m_lFPlanMstID
            End Get
            Set(ByVal Value As Long)
                m_lFPlanMstID = Value
            End Set
        End Property
        Public Property FabricdataBaseId() As Long
            Get
                FabricdataBaseId = m_lFabricdataBaseId
            End Get
            Set(ByVal Value As Long)
                m_lFabricdataBaseId = Value
            End Set
        End Property

        'Public Property FabricCode() As String
        '    Get
        '        FabricCode = m_strFabricCode
        '    End Get
        '    Set(ByVal Value As String)
        '        m_strFabricCode = Value
        '    End Set
        'End Property

        'Public Property Weave() As String
        '    Get
        '        Weave = m_strWeave
        '    End Get
        '    Set(ByVal Value As String)
        '        m_strWeave = Value
        '    End Set
        'End Property
        'Public Property GSM() As String
        '    Get
        '        GSM = m_strGSM
        '    End Get
        '    Set(ByVal Value As String)
        '        m_strGSM = Value
        '    End Set
        'End Property

        Public Property Width() As String
            Get
                Width = m_strWidth
            End Get
            Set(ByVal Value As String)
                m_strWidth = Value
            End Set
        End Property

        'Public Property Composition() As String
        '    Get
        '        Composition = m_strComposition
        '    End Get
        '    Set(ByVal Value As String)
        '        m_strComposition = Value
        '    End Set
        'End Property

        Public Property ReqMeter() As Decimal
            Get
                ReqMeter = m_DCReqMeter
            End Get
            Set(ByVal Value As Decimal)
                m_DCReqMeter = Value
            End Set
        End Property
        Public Property Consumption() As Decimal
            Get
                Consumption = m_DCConsumption
            End Get
            Set(ByVal Value As Decimal)
                m_DCConsumption = Value
            End Set
        End Property
        Public Property ReqDate() As Date
            Get
                ReqDate = m_DTReqDate
            End Get
            Set(ByVal Value As Date)
                m_DTReqDate = Value
            End Set
        End Property
        'Public Property OpeningBal() As Decimal
        '    Get
        '        OpeningBal = m_DCOpeningBal
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        m_DCOpeningBal = Value
        '    End Set
        'End Property

        'Public Property InhandQty() As Decimal
        '    Get
        '        InhandQty = m_DCInhandQty
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        m_DCInhandQty = Value
        '    End Set
        'End Property
        'Public Property BalanceQty() As Decimal
        '    Get
        '        BalanceQty = m_DCBalanceQty
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        m_DCBalanceQty = Value
        '    End Set
        'End Property
        'Public Property IssueQty() As Decimal
        '    Get
        '        IssueQty = m_DCIssueQty
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        m_DCIssueQty = Value
        '    End Set
        'End Property
        'Public Property StockQty() As Decimal
        '    Get
        '        StockQty = m_DCStockQty
        '    End Get
        '    Set(ByVal Value As Decimal)
        '        m_DCStockQty = Value
        '    End Set
        'End Property

        Public Property PieceQty() As Decimal
            Get
                PieceQty = m_DCPieceQty
            End Get
            Set(ByVal Value As Decimal)
                m_DCPieceQty = Value
            End Set
        End Property

        Public Property IMSItemID() As Long
            Get
                IMSItemID = m_lIMSItemID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemID = Value
            End Set
        End Property
        Public Property ReqStatus() As Boolean
            Get
                ReqStatus = m_bReqStatus
            End Get
            Set(ByVal Value As Boolean)
                m_bReqStatus = Value
            End Set
        End Property
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal Value As String)
                m_strStyle = Value
            End Set
        End Property

        Public Function SaveFPlanDtl()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForEnablePDF(ByVal FPlanDtlID As Long) As DataTable
            Dim str As String

            str = "select * from tblRequisitionMst RM"
            str &= " join tblRequisitionDtl RD on RD.ReqMstId=RM.ReqMstId"
            str &= " where RD.FPlanDtlID='" & FPlanDtlID & "'and RD.ApprovedByceo=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetDataForEnablePDFForAcc(ByVal AccessoriesePlanDtlID As Long) As DataTable
            Dim str As String

            str = " select * from tblRequisitionMst RM"
            str &= " join tblRequisitiondTL RD on RD.ReqMstId=RM.ReqMstId"
            str &= " join AccessoriesePlanDtl APD on APD.AccessoriesePlanDtlID=RD.AccessoriesePlanDtlID"
            str &= " where RD.AccessoriesePlanDtlID='" & AccessoriesePlanDtlID & "'and RD.ApprovedByceo=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class




End Namespace



