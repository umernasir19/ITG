Imports System.Data
Namespace EuroCentra
    Public Class TempPurchaseRegisterClassForProcess

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempPurchaseRegisterReportForProcess"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lID As Long
        Private m_strGRNNo As String
        Private m_dtPORecvDate As Date
        Private m_strItemCodee As String
        Private m_strItemName As String
        Private m_strSupplierName As String
        Private m_dcQty As Decimal
        Private m_dcRate As Decimal
        Private m_strLastPurchaseDate As String
        Private m_strSecondLastPurchaseDate As String
        Private m_dcLastPurchaseRate As Decimal
        Private m_dcSecondLastPurchaseRate As Decimal
        Private m_lItemID As Long
        Private m_lPORecvMasterID As Long
        Private m_lJoborderId As Long
        Public Property JoborderId() As Long
            Get
                JoborderId = m_lJoborderId
            End Get
            Set(ByVal value As Long)
                m_lJoborderId = value
            End Set
        End Property
        Public Property LastPurchaseDate() As String
            Get
                LastPurchaseDate = m_strLastPurchaseDate
            End Get
            Set(ByVal value As String)
                m_strLastPurchaseDate = value
            End Set
        End Property
        Public Property SecondLastPurchaseDate() As String
            Get
                SecondLastPurchaseDate = m_strSecondLastPurchaseDate
            End Get
            Set(ByVal value As String)
                m_strSecondLastPurchaseDate = value
            End Set
        End Property
        Public Property SupplierName() As String
            Get
                SupplierName = m_strSupplierName
            End Get
            Set(ByVal value As String)
                m_strSupplierName = value
            End Set
        End Property
        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal value As Long)
                m_lID = value
            End Set
        End Property
        Public Property GRNNo() As String
            Get
                GRNNo = m_strGRNNo
            End Get
            Set(ByVal value As String)
                m_strGRNNo = value
            End Set
        End Property
        Public Property PORecvDate() As Date
            Get
                PORecvDate = m_dtPORecvDate
            End Get
            Set(ByVal value As Date)
                m_dtPORecvDate = value
            End Set
        End Property
        Public Property ItemCodee() As String
            Get
                ItemCodee = m_strItemCodee
            End Get
            Set(ByVal value As String)
                m_strItemCodee = value
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
        Public Property LastPurchaseRate() As Decimal
            Get
                LastPurchaseRate = m_dcLastPurchaseRate
            End Get
            Set(ByVal value As Decimal)
                m_dcLastPurchaseRate = value
            End Set
        End Property
        Public Property SecondLastPurchaseRate() As Decimal
            Get
                SecondLastPurchaseRate = m_dcSecondLastPurchaseRate
            End Get
            Set(ByVal value As Decimal)
                m_dcSecondLastPurchaseRate = value
            End Set
        End Property


        Public Property Qty() As Decimal
            Get
                Qty = m_dcQty
            End Get
            Set(ByVal value As Decimal)
                m_dcQty = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = m_dcRate
            End Get
            Set(ByVal value As Decimal)
                m_dcRate = value
            End Set
        End Property

        Public Property ItemID() As Long
            Get
                ItemID = m_lItemID
            End Get
            Set(ByVal value As Long)
                m_lItemID = value
            End Set
        End Property

        Public Property PORecvMasterID() As Long
            Get
                PORecvMasterID = m_lPORecvMasterID
            End Get
            Set(ByVal value As Long)
                m_lPORecvMasterID = value
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

