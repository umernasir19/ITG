Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class Style2
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Style2"
            m_strPrimaryFieldName = "StyleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lStyleID As Long
        Private m_strStyle As String
        Private m_lJoborderID As Long
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal Value As Long)
                m_lStyleID = Value
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
        Public Property JoborderID() As Long
            Get
                JoborderID = m_lJoborderID
            End Get
            Set(ByVal Value As Long)
                m_lJoborderID = Value
            End Set
        End Property
        Public Function SaveStyle()
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
        Public Function CheckStyle(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = "select * from Style2 Where Style='" & Style & "' and JoborderID=" & JoborderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetRNDID() As DataTable
            Dim str As String
            str = "select TOP 1 DPRNDID from TblDPRND ORDER BY DPRNDID desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetJobOrderDetailID() As DataTable
            Dim str As String
            str = "select TOP 1 JobOrderDetailID from JobOrderdatabaseDetail ORDER BY JobOrderDetailID desc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
      
        Function UpdateStyleOnJobOrderDetail(ByVal JobOrderDetailID As Long, ByVal Style As String)
            Dim str As String
            str = " update JobOrderdatabaseDetail set Style='" & Style & "' where JobOrderDetailID ='" & JobOrderDetailID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateStyleOnRND(ByVal DPRNDID As Long, ByVal Style As String)
            Dim str As String
            str = " update TblDPRND set Style='" & Style & "' where DPRNDID ='" & DPRNDID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyle(ByVal DPRNDID As Long) As DataTable
            Dim str As String
            str = "select Style from TblDPRND where DPRNDID ='" & DPRNDID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleForJoborderDetail(ByVal JobOrderDetailID As Long) As DataTable
            Dim str As String
            str = "select Style from JobOrderdatabaseDetail where JobOrderDetailID ='" & JobOrderDetailID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace