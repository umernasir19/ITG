Imports System.Data

Namespace EuroCentra
    Public Class CustomerCPChart
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CustomerCPChart"
            m_strPrimaryFieldName = "CPChartID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCPChartID As Long
        Private m_lCPProcessID As Long
        Private m_strSizeDescription As String
        Private m_lPOID As Long
        Private m_strStatus As String
        Private m_dIdealDate As String
        Private m_dExpectedDate As String
        Private m_dQtyCompleted As String
        Private m_dActualDate As String
        Private m_strRemarks As String
        Private m_lScheduleTime As Long
        Private m_bSelected As Boolean
        Private m_strSelectedStatus As String
        Private m_dcParameter As Decimal
        Private m_strParameterUnit As String
        Private m_dcTotalCapacity As Decimal
        Private m_strCapacityUnit As String
        Private m_dcRequired As Decimal
        Private m_strRequiredUnit As String
        Public Property CPChartID() As Long
            Get
                CPChartID = m_lCPChartID
            End Get
            Set(ByVal Value As Long)
                m_lCPChartID = Value
            End Set
        End Property
        Public Property CPProcessID() As Long
            Get
                CPProcessID = m_lCPProcessID
            End Get
            Set(ByVal value As Long)
                m_lCPProcessID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = m_strStatus
            End Get
            Set(ByVal value As String)
                m_strStatus = value
            End Set
        End Property
        Public Property IdealDate() As String
            Get
                IdealDate = m_dIdealDate
            End Get
            Set(ByVal value As String)
                m_dIdealDate = value
            End Set
        End Property
        Public Property ExpectedDate() As String
            Get
                ExpectedDate = m_dExpectedDate

            End Get
            Set(ByVal value As String)
                m_dExpectedDate = value
            End Set
        End Property
        Public Property QtyCompleted() As String
            Get
                QtyCompleted = m_dQtyCompleted
            End Get
            Set(ByVal value As String)
                m_dQtyCompleted = value
            End Set
        End Property
        Public Property ActualDate() As String
            Get
                ActualDate = m_dActualDate
            End Get
            Set(ByVal value As String)
                m_dActualDate = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
        Public Property Selected() As Boolean
            Get
                Selected = m_bSelected
            End Get
            Set(ByVal value As Boolean)
                m_bSelected = value
            End Set
        End Property
        Public Property SelectedStatus() As String
            Get
                SelectedStatus = m_strSelectedStatus
            End Get
            Set(ByVal value As String)
                m_strSelectedStatus = value
            End Set
        End Property
        Public Property Parameter() As Decimal
            Get
                Parameter = m_dcParameter
            End Get
            Set(ByVal value As Decimal)
                m_dcParameter = value
            End Set
        End Property
        Public Property ParameterUnit() As String
            Get
                ParameterUnit = m_strParameterUnit
            End Get
            Set(ByVal value As String)
                m_strParameterUnit = value
            End Set
        End Property
        Public Property TotalCapacity() As Decimal
            Get
                TotalCapacity = m_dcTotalCapacity
            End Get
            Set(ByVal value As Decimal)
                m_dcTotalCapacity = value
            End Set
        End Property
        Public Property CapacityUnit() As String
            Get
                CapacityUnit = m_strCapacityUnit
            End Get
            Set(ByVal value As String)
                m_strCapacityUnit = value
            End Set
        End Property
        Public Property Required() As Decimal
            Get
                Required = m_dcRequired
            End Get
            Set(ByVal value As Decimal)
                m_dcRequired = value
            End Set
        End Property
        Public Property RequiredUnit() As String
            Get
                RequiredUnit = m_strRequiredUnit
            End Get
            Set(ByVal value As String)
                m_strRequiredUnit = value
            End Set
        End Property
        Public Function SaveTNAChart()
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
        Public Function GetTNAChartById(ByVal lTNAChartId As Long)
            Try
                Return MyBase.GetById(lTNAChartId)
            Catch ex As Exception

            End Try
        End Function
        Public Property ScheduleTime() As Long
            Get
                ScheduleTime = m_lScheduleTime
            End Get
            Set(ByVal Value As Long)
                m_lScheduleTime = Value
            End Set
        End Property
        Public Function GetProcessFirstTime(ByVal lPOID As Long) As DataTable
            Dim Str As String
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,IDealDate,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str = "Select '" & lPOID & "' AS POID,'0' AS  CPChartID,CPProcessID,CPProcess from CustomerCPProcess "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessInEDIT(ByVal lPOID As Long) As DataTable
            Dim Str As String
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,IDealDate,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str = "Select convert(datetime,ActualDate,103) as ActualDatee,convert(datetime,ExpectedDate,103) as ExpectedDatee,* FROM CustomerCPChart CCH JOIN CustomerCPProcess CPC ON CPC.CPProcessId=CCH.CPProcessId"
            Str &= " where POID = '" & lPOID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Check(ByVal lPOID As Long) As DataTable
            Dim Str As String
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,IDealDate,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str = "Select  * from CustomerCPChart where POID='" & lPOID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace