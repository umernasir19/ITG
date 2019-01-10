Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_HRBreakdown
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_HRBreakdown"
            m_strPrimaryFieldName = "VAF_HRBreakdownID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_HRBreakdownID As Long
        Private m_lVAFID As Long
        Private m_lDeptID As Long
        Private m_dcNo As Decimal
        Public Property VAF_HRBreakdownID() As Long
            Get
                VAF_HRBreakdownID = m_lVAF_HRBreakdownID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_HRBreakdownID = Value
            End Set
        End Property
        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property DeptID() As Long
            Get
                DeptID = m_lDeptID
            End Get
            Set(ByVal Value As Long)
                m_lDeptID = Value
            End Set
        End Property
        Public Property No() As Decimal
            Get
                No = m_dcNo
            End Get
            Set(ByVal Value As Decimal)
                m_dcNo = Value
            End Set
        End Property
        Public Function SaveVAF_HRBreakdown()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteRow(ByVal VAF_HRBreakdownID As Long)
            Dim Str As String
            Str = "Delete from VAF_HRBreakdown  "
            Str &= " where VAF_HRBreakdownID=" & VAF_HRBreakdownID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace