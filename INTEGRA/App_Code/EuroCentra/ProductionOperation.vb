Imports Microsoft.VisualBasic
Imports System.Data
Public Class ProductionOperation
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ProductionOperation"
        m_strPrimaryFieldName = "ProductionOperationID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lProductionOperationID As Long
    Private m_strProductionOperation As String
  
    Public Property ProductionOperationID() As Long
        Get
            ProductionOperationID = m_lProductionOperationID
        End Get
        Set(ByVal Value As Long)
            m_lProductionOperationID = Value
        End Set
    End Property
    Public Property ProductionOperation() As String
        Get
            ProductionOperation = m_strProductionOperation
        End Get
        Set(ByVal value As String)
            m_strProductionOperation = value
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
