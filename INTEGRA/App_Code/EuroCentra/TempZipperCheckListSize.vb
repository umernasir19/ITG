Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TempZipperCheckListSize

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempZipperCheckListSize"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strCategoryName As String
        Private m_strItemName As String
        Private m_lAccCheckListMstID As Long
        Private m_lAccCheckListDetailID As Long
        Private m_strZS1 As String
        Private m_strZS2 As String
        Private m_strZS3 As String
        Private m_strZS4 As String
        Private m_strZS5 As String
        Private m_strZS6 As String
        Private m_strZS7 As String
        Private m_strZS8 As String
        Private m_strZS9 As String
        Private m_strZS10 As String
        Private m_strZS11 As String
        Private m_dS1 As Decimal
        Private m_dS2 As Decimal
        Private m_dS3 As Decimal
        Private m_dS4 As Decimal
        Private m_dS5 As Decimal
        Private m_dS6 As Decimal
        Private m_dS7 As Decimal
        Private m_dS8 As Decimal
        Private m_dS9 As Decimal
        Private m_dS10 As Decimal
        Private m_dS11 As Decimal
        Private m_strDescription As String
        Public Property S1() As Decimal
            Get
                S1 = m_dS1
            End Get
            Set(ByVal Value As Decimal)
                m_dS1 = Value
            End Set
        End Property
        Public Property S2() As Decimal
            Get
                S2 = m_dS2
            End Get
            Set(ByVal Value As Decimal)
                m_dS2 = Value
            End Set
        End Property
        Public Property S3() As Decimal
            Get
                S3 = m_dS3
            End Get
            Set(ByVal Value As Decimal)
                m_dS3 = Value
            End Set
        End Property
        Public Property S4() As Decimal
            Get
                S4 = m_dS4
            End Get
            Set(ByVal Value As Decimal)
                m_dS4 = Value
            End Set
        End Property
        Public Property S5() As Decimal
            Get
                S5 = m_dS5
            End Get
            Set(ByVal Value As Decimal)
                m_dS5 = Value
            End Set
        End Property
   
        Public Property S6() As Decimal
            Get
                S6 = m_dS6
            End Get
            Set(ByVal Value As Decimal)
                m_dS6 = Value
            End Set
        End Property
        Public Property S7() As Decimal
            Get
                S7 = m_dS7
            End Get
            Set(ByVal Value As Decimal)
                m_dS7 = Value
            End Set
        End Property
        Public Property S8() As Decimal
            Get
                S8 = m_dS8
            End Get
            Set(ByVal Value As Decimal)
                m_dS8 = Value
            End Set
        End Property
        Public Property S9() As Decimal
            Get
                S9 = m_dS9
            End Get
            Set(ByVal Value As Decimal)
                m_dS9 = Value
            End Set
        End Property
        Public Property S10() As Decimal
            Get
                S10 = m_dS10
            End Get
            Set(ByVal Value As Decimal)
                m_dS10 = Value
            End Set
        End Property
        Public Property S11() As Decimal
            Get
                S11 = m_dS11
            End Get
            Set(ByVal Value As Decimal)
                m_dS11 = Value
            End Set
        End Property
        Public Property ZS1() As String
            Get
                ZS1 = m_strZS1
            End Get
            Set(ByVal Value As String)
                m_strZS1 = Value
            End Set
        End Property
        Public Property ZS2() As String
            Get
                ZS2 = m_strZS2
            End Get
            Set(ByVal Value As String)
                m_strZS2 = Value
            End Set
        End Property
        Public Property ZS3() As String
            Get
                ZS3 = m_strZS3
            End Get
            Set(ByVal Value As String)
                m_strZS3 = Value
            End Set
        End Property
        Public Property ZS4() As String
            Get
                ZS4 = m_strZS4
            End Get
            Set(ByVal Value As String)
                m_strZS4 = Value
            End Set
        End Property
        Public Property ZS5() As String
            Get
                ZS5 = m_strZS5
            End Get
            Set(ByVal Value As String)
                m_strZS5 = Value
            End Set
        End Property
        Public Property ZS6() As String
            Get
                ZS6 = m_strZS6
            End Get
            Set(ByVal Value As String)
                m_strZS6 = Value
            End Set
        End Property
        Public Property ZS7() As String
            Get
                ZS7 = m_strZS7
            End Get
            Set(ByVal Value As String)
                m_strZS7 = Value
            End Set
        End Property
        Public Property ZS8() As String
            Get
                ZS8 = m_strZS8
            End Get
            Set(ByVal Value As String)
                m_strZS8 = Value
            End Set
        End Property
        Public Property ZS9() As String
            Get
                ZS9 = m_strZS9
            End Get
            Set(ByVal Value As String)
                m_strZS9 = Value
            End Set
        End Property
        Public Property ZS10() As String
            Get
                ZS10 = m_strZS10
            End Get
            Set(ByVal Value As String)
                m_strZS10 = Value
            End Set
        End Property
        Public Property ZS11() As String
            Get
                ZS11 = m_strZS11
            End Get
            Set(ByVal Value As String)
                m_strZS11 = Value
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
       
        Public Property TempId() As Long
            Get
                TempId = m_lTempId
            End Get
            Set(ByVal Value As Long)
                m_lTempId = Value
            End Set
        End Property

      
        Public Property CategoryName() As String
            Get
                CategoryName = m_strCategoryName
            End Get
            Set(ByVal Value As String)
                m_strCategoryName = Value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal Value As String)
                m_strItemName = Value
            End Set
        End Property

        Public Property AccCheckListMstID() As Long
            Get
                AccCheckListMstID = m_lAccCheckListMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListMstID = Value
            End Set
        End Property
        Public Property AccCheckListDetailID() As Long
            Get
                AccCheckListDetailID = m_lAccCheckListDetailID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListDetailID = Value
            End Set
        End Property
       Public Function Savetemp()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function TruncateTable()
            Dim str As String = "TRUNCATE TABLE  TempAccCheckListSize"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTableZipper()
            Dim str As String = "TRUNCATE TABLE  TempZipperCheckListSize"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
