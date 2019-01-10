

 
Imports System.Data
Namespace EuroCentra
   Public Class TempCriticalReport
        Inherits SQLManager

        Public Sub New()
            m_strTableName = "TempTNAChartHistoryReport"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lID As Long
        Private m_lTNAChartID As Long
        Private m_iPOID As Integer
        Private m_iTNAProcessID As Integer
        Private m_strStatus As String
        Private m_dIdealDate As Date
        Private m_dDateEstemated As Date
        Private m_dQtyCompleted As String
        Private m_dActualDate As Date
        Private m_strRemarks As String
        Public Property TNAChartID() As Long
            Get
                TNAChartID = m_lTNAChartID
            End Get
            Set(ByVal Value As Long)
                m_lTNAChartID = Value
            End Set
        End Property
        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal Value As Long)
                m_lID = Value
            End Set
        End Property

        Public Property POID() As Integer
            Get
                POID = m_iPOID
            End Get
            Set(ByVal value As Integer)
                m_iPOID = value
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
        Public Property QtyCompleted() As String
            Get
                QtyCompleted = m_dQtyCompleted
            End Get
            Set(ByVal value As String)
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
        Public Function SaveTempTNAChartHistoryReportData()
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
        Public Function TruncateTable()
            Dim str As String
            str = "  truncate table TempTNAChartHistoryReport"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTNAChartHistoryByProcess(ByVal ProcessId As Long, ByVal POID As Long)
            Dim Str As String
            Str = "Select Po.PONo, Convert(Varchar,His.CreationDate,106)as CreationDate ,Convert(Varchar,His.IdealDate,106)as IdealDate,"
            Str &= " Convert(Varchar,His.DateEstemated,106)as DateEstemated,His.Status,His.Remarks,His.QtyCompleted,Convert(Varchar,His.ActualDate,106)as ActualDate,"
            Str &= " Prcs.Process From TNAChartHistory His Join TNAProcess Prcs On Prcs.ProcessID=His.TNAProcessID Join TNAChart Chrt on chrt.TNAChartID=His.TNAChartID "
            Str &= " Join  PurchaseOrder PO on chrt.POID=PO.POID Where  His.Status <> 'Created' and  PO.POID='" & POID & "' and His.TNAProcessID=" & ProcessId
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPONOAndProcess(ByVal ProcessId As Long, ByVal POID As Long)
            Dim Str As String
            Str = "Select Po.PONo, Convert(Varchar,His.CreationDate,106)as CreationDate ,Convert(Varchar,His.IdealDate,106)as IdealDate,"
            Str &= " Convert(Varchar,His.DateEstemated,106)as DateEstemated,His.Status,His.Remarks,His.QtyCompleted,Convert(Varchar,His.ActualDate,106)as ActualDate,"
            Str &= " Prcs.Process From TNAChartHistory His Join TNAProcess Prcs On Prcs.ProcessID=His.TNAProcessID Join TNAChart Chrt on chrt.TNAChartID=His.TNAChartID "
            Str &= " Join  PurchaseOrder PO on chrt.POID=PO.POID Where  PO.POID='" & POID & "' and His.TNAProcessID=" & ProcessId
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
