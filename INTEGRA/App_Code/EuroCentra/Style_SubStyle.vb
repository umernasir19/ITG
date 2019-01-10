Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class Style_SubStyle
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Style_SubStyle"
            m_strPrimaryFieldName = "Style_SubStyleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lStyle_SubStyleID As Long
        Private m_lStyleMasterDatabaseID As Long
        Private m_strBuyerPONO As String
        Private m_strQty As Decimal
        Private m_strPrice As Decimal
        Private m_strTotalAmount As Decimal
        Private m_lCurrencyID As Long
        Private m_strSubStyle As String
        Private m_strSMV As Decimal
        Private m_dQtyPercent As Decimal
        Private m_dTOtalQty As Decimal

        Public Property Style_SubStyleID() As Long
            Get
                Style_SubStyleID = m_lStyle_SubStyleID
            End Get
            Set(ByVal Value As Long)
                m_lStyle_SubStyleID = Value
            End Set
        End Property
        Public Property StyleMasterDatabaseID() As Long
            Get
                StyleMasterDatabaseID = m_lStyleMasterDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lStyleMasterDatabaseID = Value
            End Set
        End Property
        Public Property BuyerPONO() As String
            Get
                BuyerPONO = m_strBuyerPONO
            End Get
            Set(ByVal value As String)
                m_strBuyerPONO = value
            End Set
        End Property
        Public Property Qty() As Decimal
            Get
                Qty = m_strQty
            End Get
            Set(ByVal value As Decimal)
                m_strQty = value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_strPrice
            End Get
            Set(ByVal value As Decimal)
                m_strPrice = value
            End Set
        End Property
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = m_strTotalAmount
            End Get
            Set(ByVal value As Decimal)
                m_strTotalAmount = value
            End Set
        End Property
        Public Property CurrencyID() As Long
            Get
                CurrencyID = m_lCurrencyID
            End Get
            Set(ByVal Value As Long)
                m_lCurrencyID = Value
            End Set
        End Property
        Public Property SubStyle() As String
            Get
                SubStyle = m_strSubStyle
            End Get
            Set(ByVal value As String)
                m_strSubStyle = value
            End Set
        End Property
        Public Property SMV() As Decimal
            Get
                SMV = m_strSMV
            End Get
            Set(ByVal value As Decimal)
                m_strSMV = value
            End Set
        End Property
        Public Property QtyPercent() As Decimal
            Get
                QtyPercent = m_dQtyPercent
            End Get
            Set(ByVal value As Decimal)
                m_dQtyPercent = value
            End Set
        End Property
        Public Property TOtalQty() As Decimal
            Get
                TOtalQty = m_dTOtalQty
            End Get
            Set(ByVal value As Decimal)
                m_dTOtalQty = value
            End Set
        End Property
        Public Function SaveStyle_SubStyle()
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

        Function UpdateQty(ByVal JobOrderDetailID As Long, ByVal QtyPerNew As Decimal, ByVal TotalQtyNew As Decimal)
            Dim Str As String
            Str = "update JobOrderdatabaseDetail set QtyPerNew='" & QtyPerNew & "' , TotalQtyNew='" & TotalQtyNew & "' where JobOrderDetailID='" & JobOrderDetailID & "'"

            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace