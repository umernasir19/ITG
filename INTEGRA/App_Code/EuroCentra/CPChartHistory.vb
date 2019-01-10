Imports System.Data
Namespace EuroCentra
    Public Class CPChartHistory
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CPChartHistory"
            m_strPrimaryFieldName = "CPChartHistoryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCPChartID As Long
        Private m_dCreationDate As Date
        Private m_lCPProcessID As Long
        Private m_lCPChartHistoryID As Long
        Private m_lQuantity As Decimal
        Private m_dtTargetSubmission As String
        Private m_dtIstSubmission As String
        Private m_strDHLorFEDEX As String
        Private m_strFeedBackReceived As String
        Private m_dtRevisedTarget As String
        Private m_dtRevisedSubmission As String
        Private m_strDHLorFEDEX1 As String
        Private m_strFeedBackReceived1 As String
        Private m_strRemarks As String
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dCreationDate
            End Get
            Set(ByVal value As Date)
                m_dCreationDate = value
            End Set
        End Property
        Public Property CPChartID() As Long
            Get
                CPChartID = m_lCPChartID
            End Get
            Set(ByVal value As Long)
                m_lCPChartID = value
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
        Public Property CPChartHistoryID() As Long
            Get
                CPChartHistoryID = m_lCPChartHistoryID
            End Get
            Set(ByVal value As Long)
                m_lCPChartHistoryID = value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_lQuantity
            End Get
            Set(ByVal value As Decimal)
                m_lQuantity = value
            End Set
        End Property
        Public Property TargetSubmission() As String
            Get
                TargetSubmission = m_dtTargetSubmission
            End Get
            Set(ByVal value As String)
                m_dtTargetSubmission = value
            End Set
        End Property
        Public Property IstSubmission() As String
            Get
                IstSubmission = m_dtIstSubmission
            End Get
            Set(ByVal value As String)
                m_dtIstSubmission = value
            End Set
        End Property
        Public Property DHLorFEDEX() As String
            Get
                DHLorFEDEX = m_strDHLorFEDEX
            End Get
            Set(ByVal value As String)
                m_strDHLorFEDEX = value
            End Set
        End Property
        Public Property FeedBackReceived() As String
            Get
                FeedBackReceived = m_strFeedBackReceived
            End Get
            Set(ByVal value As String)
                m_strFeedBackReceived = value
            End Set
        End Property
        Public Property RevisedTarget() As String
            Get
                RevisedTarget = m_dtRevisedTarget
            End Get
            Set(ByVal value As String)
                m_dtRevisedTarget = value
            End Set
        End Property
        Public Property RevisedSubmission() As String
            Get
                RevisedSubmission = m_dtRevisedSubmission
            End Get
            Set(ByVal value As String)
                m_dtRevisedSubmission = value
            End Set
        End Property
        Public Property DHLorFEDEX1() As String
            Get
                DHLorFEDEX1 = m_strDHLorFEDEX1
            End Get
            Set(ByVal value As String)
                m_strDHLorFEDEX1 = value
            End Set
        End Property
        Public Property FeedBackReceived1() As String
            Get
                FeedBackReceived1 = m_strFeedBackReceived1
            End Get
            Set(ByVal value As String)
                m_strFeedBackReceived1 = value
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
        Public Function SaveCPChartHistory()
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
    End Class
End Namespace