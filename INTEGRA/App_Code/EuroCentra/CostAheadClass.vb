Imports Microsoft.VisualBasic
Imports System.Data
Public Class CostAheadClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "CostAhead"
        m_strPrimaryFieldName = "CostAheadID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lCostAheadID As Long
    Private m_strCostAhead As String

    Public Property CostAheadID() As Long
        Get
            CostAheadID = m_lCostAheadID
        End Get
        Set(ByVal Value As Long)
            m_lCostAheadID = Value
        End Set
    End Property
    Public Property CostAhead() As String
        Get
            CostAhead = m_strCostAhead
        End Get
        Set(ByVal value As String)
            m_strCostAhead = value
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
