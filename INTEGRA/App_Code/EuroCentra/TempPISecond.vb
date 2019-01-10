Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TempPISecond
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempPISecond"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strStyle As String
        Private m_strDescription As String
        Private m_strColor As String
        Private m_dcQty As Decimal
        Private m_dcPrice As Decimal
        Private m_dcAmount As Decimal
        Private m_dcS1 As Decimal
        Private m_dcS2 As Decimal
        Private m_dcS3 As Decimal
        Private m_dcS4 As Decimal
        Private m_dcS5 As Decimal
        Private m_dcS6 As Decimal
        Private m_dcS7 As Decimal
        Private m_dcS8 As Decimal
        Private m_dcS9 As Decimal
        Private m_dcS10 As Decimal
        Private m_dcS11 As Decimal
        Private m_strSRNO As String
        Private m_strModel As String
        Private m_dStyleShipmentDate As Date
        Private m_lDPIMstID As Long
        Private m_strType As String
        Private m_strColorCode As String
        Public Property ColorCode() As String
            Get
                ColorCode = m_strColorCode
            End Get
            Set(ByVal Value As String)
                m_strColorCode = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal Value As String)
                m_strType = Value
            End Set
        End Property
        Public Property DPIMstID() As Long
            Get
                DPIMstID = m_lDPIMstID
            End Get
            Set(ByVal Value As Long)
                m_lDPIMstID = Value
            End Set
        End Property
        Public Property StyleShipmentDate() As Date
            Get
                StyleShipmentDate = m_dStyleShipmentDate
            End Get
            Set(ByVal value As Date)
                m_dStyleShipmentDate = value
            End Set
        End Property
        Public Property SRNO() As String
            Get
                SRNO = m_strSRNO
            End Get
            Set(ByVal Value As String)
                m_strSRNO = Value
            End Set
        End Property
        Public Property Model() As String
            Get
                Model = m_strModel
            End Get
            Set(ByVal Value As String)
                m_strModel = Value
            End Set
        End Property

        Public Property Qty() As Decimal
            Get
                Qty = m_dcQty
            End Get
            Set(ByVal Value As Decimal)
                m_dcQty = Value
            End Set
        End Property
        Public Property Price() As Decimal
            Get
                Price = m_dcPrice
            End Get
            Set(ByVal Value As Decimal)
                m_dcPrice = Value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = m_dcAmount
            End Get
            Set(ByVal Value As Decimal)
                m_dcAmount = Value
            End Set
        End Property
        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal Value As Long)
                m_lTempId = Value
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
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal Value As String)
                m_strDescription = Value
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




        Public Property S1() As Decimal
            Get
                S1 = m_dcS1
            End Get
            Set(ByVal Value As Decimal)
                m_dcS1 = Value
            End Set
        End Property
        Public Property S2() As Decimal
            Get
                S2 = m_dcS2
            End Get
            Set(ByVal Value As Decimal)
                m_dcS2 = Value
            End Set
        End Property
        Public Property S3() As Decimal
            Get
                S3 = m_dcS3
            End Get
            Set(ByVal Value As Decimal)
                m_dcS3 = Value
            End Set
        End Property

        Public Property S4() As Decimal
            Get
                S4 = m_dcS4
            End Get
            Set(ByVal Value As Decimal)
                m_dcS4 = Value
            End Set
        End Property

        Public Property S5() As Decimal
            Get
                S5 = m_dcS5
            End Get
            Set(ByVal Value As Decimal)
                m_dcS5 = Value
            End Set
        End Property
        Public Property S6() As Decimal
            Get
                S6 = m_dcS6
            End Get
            Set(ByVal Value As Decimal)
                m_dcS6 = Value
            End Set
        End Property
        Public Property S7() As Decimal
            Get
                S7 = m_dcS7
            End Get
            Set(ByVal Value As Decimal)
                m_dcS7 = Value
            End Set
        End Property
        Public Property S8() As Decimal
            Get
                S8 = m_dcS8
            End Get
            Set(ByVal Value As Decimal)
                m_dcS8 = Value
            End Set
        End Property
        Public Property S9() As Decimal
            Get
                S9 = m_dcS9
            End Get
            Set(ByVal Value As Decimal)
                m_dcS9 = Value
            End Set
        End Property
        Public Property S10() As Decimal
            Get
                S10 = m_dcS10
            End Get
            Set(ByVal Value As Decimal)
                m_dcS10 = Value
            End Set
        End Property
        Public Property S11() As Decimal
            Get
                S11 = m_dcS11
            End Get
            Set(ByVal Value As Decimal)
                m_dcS11 = Value
            End Set
        End Property
        Public Function Savetemp()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempCuttingPro"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

