﻿Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TempAccCheckListSize
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TempAccCheckListSize"
            m_strPrimaryFieldName = "TempId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempId As Long
        Private m_strRowType As String
        Private m_strCategoryName As String
        Private m_strItemName As String
        Private m_lAccCheckListMstID As Long
        Private m_lAccCheckListDetailID As Long
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
        Private m_lRowNo As Long
        Private m_strDescription As String
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal Value As String)
                m_strDescription = Value
            End Set
        End Property
        Public Property RowNo() As Long
            Get
                RowNo = m_lRowNo
            End Get
            Set(ByVal Value As Long)
                m_lRowNo = Value
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

        Public Property RowType() As String
            Get
                RowType = m_strRowType
            End Get
            Set(ByVal Value As String)
                m_strRowType = Value
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
            Dim str As String = "TRUNCATE TABLE  TempAccCheckListSize"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTablePIONe()
            Dim str As String = "TRUNCATE TABLE  TempPIOne"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function TruncateTablePISecond()
            Dim str As String = "TRUNCATE TABLE  TempPISecond"
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
