Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class SizeRangeDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SizeRangeDetail"
            m_strPrimaryFieldName = "SizeRangeDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lSizeRangeDetailID As Long
        Private m_lSizeRangeID As Long
        Private m_strSizeDatabaseID As Long
        Private m_dRatio As Decimal
        Public Property SizeRangeDetailID() As Long
            Get
                SizeRangeDetailID = m_lSizeRangeDetailID
            End Get
            Set(ByVal Value As Long)
                m_lSizeRangeDetailID = Value
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
                SizeDatabaseID = m_strSizeDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_strSizeDatabaseID = Value
            End Set
        End Property
        Public Property Ratio() As Decimal
            Get
                Ratio = m_dRatio
            End Get
            Set(ByVal Value As Decimal)
                m_dRatio = Value
            End Set
        End Property
        Public Function SaveSizeRangeDetail()
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
        Public Function SelectAll(ByVal SizeRangeID As Long) As DataTable
            Dim str As String
            str = "Select * from SizeRangeDetail where SizeRangeID=" & SizeRangeID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
