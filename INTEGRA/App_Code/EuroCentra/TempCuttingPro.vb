Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TempCuttingPro
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempCuttingPro"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_lStyleAssortmentMasterID As Long
        Private m_lJobOrderID As Long
        Private m_lJoborderDetailid As Long
        Private m_strStyle As String
        Private m_strSRNo As String
        Private m_strCustomerName As String
        Private m_strCustomerOrder As String
        Private m_strDesc As String
        Private m_strFabricContent As String
        Private m_dcQuantity As Decimal
        Private m_strColor As String
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
        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal Value As Long)
                m_lTempId = Value
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
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailid = Value
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
        Public Property SRNo() As String
            Get
                SRNo = m_strSRNo
            End Get
            Set(ByVal Value As String)
                m_strSRNo = Value
            End Set
        End Property
        Public Property CustomerName() As String
            Get
                CustomerName = m_strCustomerName
            End Get
            Set(ByVal Value As String)
                m_strCustomerName = Value
            End Set
        End Property
        Public Property CustomerOrder() As String
            Get
                CustomerOrder = m_strCustomerOrder
            End Get
            Set(ByVal Value As String)
                m_strCustomerOrder = Value
            End Set
        End Property
        Public Property Desc() As String
            Get
                Desc = m_strDesc
            End Get
            Set(ByVal Value As String)
                m_strDesc = Value
            End Set
        End Property
        Public Property FabricContent() As String
            Get
                FabricContent = m_strFabricContent
            End Get
            Set(ByVal Value As String)
                m_strFabricContent = Value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dcQuantity
            End Get
            Set(ByVal Value As Decimal)
                m_dcQuantity = Value
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
