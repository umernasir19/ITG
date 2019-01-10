Imports System.Data
Namespace EuroCentra
    Public Class CustomerCPChartHistory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CustomerCPChartHistory"
            m_strPrimaryFieldName = "CPChartHistoryId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCPChartHistoryId As Long
        Private m_dCreationDate As Date
        Private m_iCPChartID As Integer
        Private m_iCPProcessID As Integer
        Private m_strStatus As String
        Private m_dIdealDate As String
        Private m_dExpectedDate As String
        Private m_dQtyCompleted As String
        Private m_dActualDate As String
        Private m_strRemarks As String
        Private m_dcParameter As Decimal
        Private m_strParameterUnit As String
        Private m_dcTotalCapacity As Decimal
        Private m_strCapacityUnit As String
        Private m_dcRequired As Decimal
        Private m_strRequiredUnit As String
        Public Property CPChartHistoryId() As Long
            Get
                CPChartHistoryId = m_lCPChartHistoryId
            End Get
            Set(ByVal Value As Long)
                m_lCPChartHistoryId = Value
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
        Public Property CPChartID() As Integer
            Get
                CPChartID = m_iCPChartID
            End Get
            Set(ByVal value As Integer)
                m_iCPChartID = value
            End Set
        End Property
        Public Property CPProcessID() As Integer
            Get
                CPProcessID = m_iCPProcessID
            End Get
            Set(ByVal value As Integer)
                m_iCPProcessID = value
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
        Public Function SaveTNAChartHistory()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetTNAChartHistoryByProcess(ByVal ProcessId As Long, ByVal POID As Long)
            Dim Str As String
            Str = "Select Po.PONo, Convert(Varchar,His.CreationDate,106)as CreationDate ,His.IdealDate as IdealDate,"
            Str &= " hIS.ExpectedDate as ExpectedDate,His.Status,His.Remarks,His.QtyCompleted,"
            Str &= " His.ActualDate as ActualDate,"
            Str &= " Prcs.CPProcess From CustomerCPChartHistory His Join CustomerCPProcess Prcs "
            Str &= " On Prcs.CPProcessID=His.CPProcessID"
            Str &= " Join CustomerCPChart Chrt on chrt.CPChartID=His.CPChartID "
            Str &= " Join  PurchaseOrder PO on chrt.POID=PO.POID Where  PO.POID='" & POID & "' and His.CPProcessID='" & ProcessId & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace