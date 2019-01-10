Imports System.Data

Namespace EuroCentra
    Public Class TNAChart
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TNAChart"
            m_strPrimaryFieldName = "TNAChartID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lTNAChartID As Long
        Private m_lTNAProcessID As Long
        'Private m_strSizeDescription As String
        Private m_lPOID As Long
        'Private m_lStyleID As Long
        Private m_strStatus As String
        Private m_dIdealDate As Date
        Private m_dDateEstemated As Date
        Private m_dQtyCompleted As Decimal
        Private m_dActualDate As Date
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
        Private m_strProductionStatus As String
        Private m_dProcessActive As Boolean
        Public Property ProcessActive() As Boolean
            Get
                ProcessActive = m_dProcessActive
            End Get
            Set(ByVal value As Boolean)
                m_dProcessActive = value
            End Set
        End Property
        Public Property ProductionStatus() As String
            Get
                ProductionStatus = m_strProductionStatus
            End Get
            Set(ByVal value As String)
                m_strProductionStatus = value
            End Set
        End Property
        Public Property TNAChartID() As Long
            Get
                TNAChartID = m_lTNAChartID
            End Get
            Set(ByVal Value As Long)
                m_lTNAChartID = Value
            End Set
        End Property
        Public Property TNAProcessID() As Long
            Get
                TNAProcessID = m_lTNAProcessID
            End Get
            Set(ByVal value As Long)
                m_lTNAProcessID = value
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
        'Public Property StyleID() As Long
        '    Get
        '        StyleID = m_lStyleID
        '    End Get
        '    Set(ByVal value As Long)
        '        m_lStyleID = value
        '    End Set
        'End Property
        Public Property Status() As String
            Get
                Status = m_strStatus
            End Get
            Set(ByVal value As String)
                m_strStatus = value
            End Set
        End Property
        Public Property IdealDate() As Date
            Get
                IdealDate = m_dIdealDate
            End Get
            Set(ByVal value As Date)
                m_dIdealDate = value
            End Set
        End Property
        Public Property DateEstemated() As Date
            Get
                DateEstemated = m_dDateEstemated

            End Get
            Set(ByVal value As Date)
                m_dDateEstemated = value
            End Set
        End Property
        Public Property QtyCompleted() As Decimal
            Get
                QtyCompleted = m_dQtyCompleted
            End Get
            Set(ByVal value As Decimal)
                m_dQtyCompleted = value
            End Set
        End Property
        Public Property ActualDate() As Date
            Get
                ActualDate = m_dActualDate
            End Get
            Set(ByVal value As Date)
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
        Function UpdateProcessAlerts(ByVal POID As Long, ByVal Processid As Long, ByVal status As Long) As DataTable
            Dim Str As String
            Str = " Update EmailReminder set ProcessActive='" & status & "' where poid= '" & POID & "' and ProcessID='" & Processid & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessByTNAChartIddNew(ByVal lPOID As Long) As DataTable
            Dim Str As String
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,IDealDate,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Status,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,DateEstemated,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            'Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID    where POID=" & lPOID
            'Str &= " order by sequence"
            Str = " Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else ActualDate end) as ActualDate,case when QtyCompleted=0 then QtyCompleted else QtyCompleted end as QtyCompleted,  case when Status='Created' then 'Created' else Status end  as Status ,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,DateEstemated as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID   and Chrt.Selected=1 and ProcessActive=1  where Prcs.ProcessID  in(1,2,3,4,5,11) and POID=" & lPOID
            Str &= " order by sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessByTNAChartIdd(ByVal lPOID As Long) As DataTable
            Dim Str As String
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,IDealDate,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Status,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,DateEstemated,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            'Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID    where POID=" & lPOID
            'Str &= " order by sequence"
            Str = " Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else ActualDate end) as ActualDate,case when QtyCompleted=0 then QtyCompleted else QtyCompleted end as QtyCompleted,  case when Status='Created' then 'Created' else Status end  as Status ,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,DateEstemated as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID   and Chrt.Selected=1 and ProcessActive=1  where POID=" & lPOID
            Str &= " order by sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDateEstemated(ByVal TNAChartID As Long, ByVal DateEstemated As String) As DataTable
            Dim Str As String
            Str = " Update TNAchart set DateEstemated='" & DateEstemated & "' where TNAChartID=" & TNAChartID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSchedularTimeByProcessID(ByVal TNAProcessID As Long) As DataTable
            Dim Str As String

            Str = " Select  Process,Sequence,ProcessID,ScheduleTime as SchedularTime from TNAProcess     where ProcessID='" & TNAProcessID & "'  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateSelected(ByVal TNAChartID As Long) As DataTable
            Dim Str As String
            Str = " Update TNAchart set Selected=0,Remarks='Not Applicable' where TNAChartID=" & TNAChartID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOColor(ByVal joborderid As Long) As DataTable
            Dim Str As String
            Str = "select Distinct pod.BuyerColor from  joborderdatabase po  "
            Str &= " Join joborderdatabaseDetail pod on pod.joborderid=po.joborderid"
            Str &= " WHERE po.joborderid = '" & joborderid & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDateTimeSpam(ByVal POID As Long, ByVal TimeSpame As Long) As DataTable
            Dim Str As String
            Str = " Update Purchaseorder set TimeSpame='" & TimeSpame & "' where POID='" & POID & "' "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDateEstematedNewHistory(ByVal TNAChartID As Long, ByVal DateEstemated As String) As DataTable
            Dim Str As String
            Str = " Update TNAChartHistory set DateEstemated='" & DateEstemated & "' where TNAChartID=" & TNAChartID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDateEstematedNew(ByVal TNAChartID As Long, ByVal DateEstemated As String) As DataTable
            Dim Str As String
            Str = " Update TNAchart set DateEstemated='" & DateEstemated & "' where TNAChartID=" & TNAChartID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function updateProductionStatusForTNA(ByVal POID As Long, ByVal ProductionStatus As String) As DataTable
            Dim Str As String
            Str = "update TNAChart set ProductionStatus='" & ProductionStatus & "' where POID='" & POID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessByTNAChartId(ByVal lPOID As Long) As DataTable
            Dim Str As String
            'Str = "Select POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,IDealDate,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str = "Select Prcs.ScheduleTime as SchedularTime ,POID, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,DateEstemated,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID    where POID=" & lPOID
            Str &= " order by sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateChartFotChangeShipmentDate(ByVal ChartID As Long, ByVal ProcessIDOld As Long, ByVal POID As Long, ByVal FInalDateIdeal As String)
            Dim Str As String
            Str = "Update TNAChart Set IdealDate= '" & FInalDateIdeal & "', DateEstemated='" & FInalDateIdeal & "',  ActualDate='" & FInalDateIdeal & "' where TNAChartID='" & ChartID & "'"
            Str &= "  and TNAProcessID='" & ProcessIDOld & "' and POID='" & POID & "' and IdealDate=ActualDate"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForChangeShipmetDate(ByVal lPOID As Long) As DataTable
            Dim Str As String

            Str = "Select * from  joborderdatabase Where joborderiD= " & lPOID & ""

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProductionStatusForTNA(ByVal POID As Long) As DataTable
            Dim Str As String
            Str = "select * from TNAChart where POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(Str)
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
        Public Function GetProcessByTNAChartIdChange(ByVal JobOrderID As Long, ByVal StyleID As Long) As DataTable
            Dim Str As String
            Str = "Select JobOrderID,StyleID,Status, TNAChartID,ProcessID,(Case ActualDate when IdealDate then '' else Convert(Varchar,ActualDate,103) end) as ActualDate,QtyCompleted,Remarks,Process,Convert(Varchar,IDealDate,106)as IdealDate ,Convert(Varchar,DateEstemated,103)as EstimatedDate, Selected,SelectedStatus from TNAChart Chrt"
            Str &= " Join TNAProcess Prcs on Chrt.TNAProcessID= Prcs.ProcessID    where JobOrderID=" & JobOrderID
            Str &= " and StyleID=" & StyleID
            Str &= " order by Prcs.Sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function UpdateSelecteStatus(ByVal JobOrderID As Long, ByVal StyleID As Long)
            Dim Str As String
            Str = " Update  TNAChart Set SelectedStatus='SELECTED' where JobOrderID=" & JobOrderID
            Str &= " and StyleID=" & StyleID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateSelecte(ByVal TNAChartID As String)
            Dim Str As String
            Str = "Update  TNAChart Set Selected=0 where TNAChartID In" & TNAChartID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace