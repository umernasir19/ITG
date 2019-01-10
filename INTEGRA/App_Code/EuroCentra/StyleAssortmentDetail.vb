Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class StyleAssortmentDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleAssortmentDetail"
            m_strPrimaryFieldName = "StyleAssortmentDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lStyleAssortmentDetailID As Long
        Private m_lStyleAssortmentMasterID As Long
        Private m_lGenderID As Long
        Private m_lSizeRangeID As Long
        Private m_lSizeDatabaseID As Long
        Private m_strBreakup As String
        Private m_strRatio As String
        Private m_strSize As String
        Private m_strUnit As String
        Private m_dQty As Decimal
        Private m_dAsortqty As Decimal
        Private m_dExtraQty As Decimal
        Private m_bDownloadBit As Boolean
        Private m_strLineNumber As String
        Public Property LineNumber() As String
            Get
                LineNumber = m_strLineNumber
            End Get
            Set(ByVal Value As String)
                m_strLineNumber = Value
            End Set
        End Property
        Public Property DownloadBit() As Boolean
            Get
                DownloadBit = m_bDownloadBit
            End Get
            Set(ByVal Value As Boolean)
                m_bDownloadBit = Value
            End Set
        End Property
        Public Property StyleAssortmentDetailID() As Long
            Get
                StyleAssortmentDetailID = m_lStyleAssortmentDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentDetailID = Value
            End Set
        End Property
        Public Property StyleAssortmentMasterID() As Long
            Get
                StyleAssortmentMasterID = m_lStyleAssortmentMasterID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentMasterID = Value
            End Set
        End Property
        Public Property GenderID() As Long
            Get
                GenderID = m_lGenderID
            End Get
            Set(ByVal Value As Long)
                m_lGenderID = Value
            End Set
        End Property
        Public Property SizeRangeID() As Long
            Get
                SizeRangeID = m_lSizeRangeID
            End Get
            Set(ByVal Value As Long)
                m_lSizeRangeID = Value
            End Set
        End Property
        Public Property SizeDatabaseID() As Long
            Get
                SizeDatabaseID = m_lSizeDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSizeDatabaseID = Value
            End Set
        End Property
        Public Property Breakup() As String
            Get
                Breakup = m_strBreakup
            End Get
            Set(ByVal value As String)
                m_strBreakup = value
            End Set
        End Property
        Public Property Ratio() As String
            Get
                Ratio = m_strRatio
            End Get
            Set(ByVal value As String)
                m_strRatio = value
            End Set
        End Property
        Public Property Size() As String
            Get
                Size = m_strSize
            End Get
            Set(ByVal value As String)
                m_strSize = value
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
        Public Property Qty() As Decimal
            Get
                Qty = m_dQty
            End Get
            Set(ByVal value As Decimal)
                m_dQty = value
            End Set
        End Property
        Public Property Asortqty() As Decimal
            Get
                Asortqty = m_dAsortqty
            End Get
            Set(ByVal value As Decimal)
                m_dAsortqty = value
            End Set
        End Property
        Public Property ExtraQty() As Decimal
            Get
                ExtraQty = m_dExtraQty
            End Get
            Set(ByVal value As Decimal)
                m_dExtraQty = value
            End Set
        End Property
        Public Function SaveStyleAssortmentDetail()
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
