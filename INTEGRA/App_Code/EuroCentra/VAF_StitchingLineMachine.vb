Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_StitchingLineMachine
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_StitchingLineMachine"
            m_strPrimaryFieldName = "VAF_StitchingLineMachineID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_StitchingLineMachineID As Long
        Private m_lVAFID As Long
        Private m_strMachine As String
        Private m_dcMachineTotal As Decimal
        Public Property VAF_StitchingLineMachineID() As Long
            Get
                VAF_StitchingLineMachineID = m_lVAF_StitchingLineMachineID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_StitchingLineMachineID = Value
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
        Public Property Machine() As String
            Get
                Machine = m_strMachine
            End Get
            Set(ByVal value As String)
                m_strMachine = value
            End Set
        End Property
        Public Property MachineTotal() As Decimal
            Get
                MachineTotal = m_dcMachineTotal
            End Get
            Set(ByVal Value As Decimal)
                m_dcMachineTotal = Value
            End Set
        End Property
        Public Function SaveVAF_StitchingLineMachine()
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
        Public Function DeleteRow(ByVal VAF_StitchingLineMachineID As Long)
            Dim Str As String
            Str = "Delete from VAF_StitchingLineMachine  "
            Str &= " where VAF_StitchingLineMachineID=" & VAF_StitchingLineMachineID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace