Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra

    Public Class HRLeaveTable
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "HRLeaveTable"
            m_strPrimaryFieldName = "HRLeaveID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lHRLeaveID As Long
        Private m_lHRID As Long
        Private m_lLeaveFiscalYear As String
        Private m_lTotalLeaveGranted As Decimal
        Private m_lTotalLeaveAvailed As Decimal
        Private m_lMedicalLeave As Decimal

        Private m_lCasualLeave As Decimal
        Private m_strDivideRule As String
        Private m_strSpecialInstructions As String

         
        '----------------Properties
        Public Property HRLeaveID() As Long
            Get
                HRLeaveID = m_lHRLeaveID
            End Get
            Set(ByVal value As Long)
                m_lHRLeaveID = value
            End Set
        End Property
        Public Property HRID() As Long
            Get
                HRID = m_lHRID
            End Get
            Set(ByVal value As Long)
                m_lHRID = value
            End Set
        End Property
        Public Property LeaveFiscalYear() As String
            Get
                LeaveFiscalYear = m_lLeaveFiscalYear
            End Get
            Set(ByVal value As String)
                m_lLeaveFiscalYear = value
            End Set
        End Property
        Public Property TotalLeaveGranted() As Decimal
            Get
                TotalLeaveGranted = m_lTotalLeaveGranted
            End Get
            Set(ByVal value As Decimal)
                m_lTotalLeaveGranted = value
            End Set
        End Property
        Public Property TotalLeaveAvailed() As Decimal
            Get
                TotalLeaveAvailed = m_lTotalLeaveAvailed
            End Get
            Set(ByVal value As Decimal)
                m_lTotalLeaveAvailed = value
            End Set
        End Property
        Public Property MedicalLeave() As Decimal
            Get
                MedicalLeave = m_lMedicalLeave
            End Get
            Set(ByVal value As Decimal)
                m_lMedicalLeave = value
            End Set
        End Property
        Public Property CasualLeave() As Decimal
            Get
                CasualLeave = m_lCasualLeave
            End Get
            Set(ByVal value As Decimal)
                m_lCasualLeave = value
            End Set
        End Property
        Public Property DivideRule() As String
            Get
                DivideRule = m_strDivideRule
            End Get
            Set(ByVal value As String)
                m_strDivideRule = value
            End Set
        End Property
        Public Property SpecialInstructions() As String
            Get
                SpecialInstructions = m_strSpecialInstructions
            End Get
            Set(ByVal value As String)
                m_strSpecialInstructions = value
            End Set
        End Property
        Public Function SaveHRLeaveTable()
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
        Function GetHRLeaveTableID(ByVal lHRID As Long)
            Dim str As String
            str = " select HRLT.HRLeaveID,HRLH.HRLeaveHistoryID  from  HRLeaveTable HRLT"
            str &= " join HRLeaveHistory HRLH on HRLH.HRLeaveID =HRLT.HRLeaveID  "
            str &= " where HRLT.HRID = " & lHRID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetHRLeaveTable(ByVal HRID As Long)
            Dim str As String
            str = " Select * From HRLeaveTable Where HRID = '" & HRID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function UpdateTotalLeaveAvailed(ByVal HRID As Long, ByVal TotalLeaveAvailed As Decimal)
            Dim Str As String
            Str = " Update HRLeaveTable set TotalLeaveAvailed = '" & TotalLeaveAvailed & "' Where HRID ='" & HRID & "' "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace
