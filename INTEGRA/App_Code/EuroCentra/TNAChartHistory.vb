Imports System.Data
Namespace EuroCentra
    Public Class TNAChartHistory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TNAChartHistory"
            m_strPrimaryFieldName = "TNAChartHistoryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lTNAChartHistoryID As Long
        Private m_dCreationDate As Date
        Private m_iTNAChartID As Integer
        Private m_iTNAProcessID As Integer
        Private m_strStatus As String
        Private m_dIdealDate As Date
        Private m_dDateEstemated As Date
        Private m_dQtyCompleted As Decimal
        Private m_dActualDate As Date
        Private m_strRemarks As String
        Private m_dcParameter As Decimal
        Private m_strParameterUnit As String
        Private m_dcTotalCapacity As Decimal
        Private m_strCapacityUnit As String
        Private m_dcRequired As Decimal
        Private m_strRequiredUnit As String
        Private m_strColor As String
        Private m_strProductionStatus As String

        Public Property ProductionStatus() As String
            Get
                ProductionStatus = m_strProductionStatus
            End Get
            Set(ByVal value As String)
                m_strProductionStatus = value
            End Set
        End Property
        Public Property TNAChartHistoryID() As Long
            Get
                TNAChartHistoryID = m_lTNAChartHistoryID
            End Get
            Set(ByVal Value As Long)
                m_lTNAChartHistoryID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal value As Date)
                m_dCreationDate = value
            End Set
        End Property
        Public Property TNAChartID() As Integer
            Get
                TNAChartID = m_iTNAChartID
            End Get
            Set(ByVal value As Integer)
                m_iTNAChartID = value
            End Set
        End Property
        Public Property TNAProcessID() As Integer
            Get
                TNAProcessID = m_iTNAProcessID
            End Get
            Set(ByVal value As Integer)
                m_iTNAProcessID = value
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
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal value As String)
                m_strColor = value
            End Set
        End Property
        Public Function SaveTNAChartHistory()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTNAChartHistoryById(ByVal lTNAChartHistoryId As Long)
            Try
                Return MyBase.GetById(lTNAChartHistoryId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTNAChartHistoryByProcess(ByVal ProcessId As Long, ByVal JobOrderID As Long, ByVal StyleID As Long)
            Dim Str As String
            Str = "Select JD.JoborderNo, Convert(Varchar,His.CreationDate,106)as CreationDate ,Convert(Varchar,His.IdealDate,106)as IdealDate,"
            Str &= " Convert(Varchar,His.DateEstemated,106)as DateEstemated,His.Status,His.Remarks,His.QtyCompleted,Convert(Varchar,His.ActualDate,106)as ActualDate,"
            Str &= " Prcs.Process From TNAChartHistory His Join TNAProcess Prcs On Prcs.ProcessID=His.TNAProcessID Join TNAChart Chrt on chrt.TNAChartID=His.TNAChartID "
            Str &= " join  JobOrderDatabase JD on JD.Joborderid=Chrt.Joborderid Where  Chrt.JobOrderID='" & JobOrderID & "' and Chrt.StyleID='" & StyleID & "' and His.TNAProcessID=" & ProcessId
            Str &= " order by  month(His.CreationDate) ASC,day(His.CreationDate) ASC , year(His.CreationDate) ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTNAChartHistoryByProcessNew(ByVal ProcessId As Long, ByVal POID As Long)
            Dim Str As String
            Str = "  Select Po.SrNo as PONO, Convert(Varchar,His.CreationDate,106)as CreationDate "
            Str &= " ,Convert(Varchar,His.IdealDate,106)as IdealDate, "
            Str &= " Convert(Varchar,His.DateEstemated,106)as DateEstemated,His.Status,His.Remarks,"
            Str &= " His.QtyCompleted,Convert(Varchar,His.ActualDate,106)as ActualDate, Prcs.Process,His.Color "
            Str &= " From TNAChartHistory His "
            Str &= " Join TNAProcess Prcs On Prcs.ProcessID=His.TNAProcessID "
            Str &= " Join TNAChart Chrt on chrt.TNAChartID=His.TNAChartID  "
            Str &= " Join  JobOrderdatabase  PO on PO.JobOrderID=Chrt.POID"
            Str &= " Where  PO.JobOrderID='" & POID & "' and His.TNAProcessID=" & ProcessId
            '' atif commented
            'Str &= " AND His.Status !='Created' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace