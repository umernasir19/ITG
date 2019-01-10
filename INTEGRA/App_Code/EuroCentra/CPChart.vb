Imports System.Data
 Namespace EuroCentra
    Public Class CPChart
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CPChart"
            m_strPrimaryFieldName = "CPChartID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCPChartID As Long
        Private m_dCreationDate As Date
        Private m_lCPProcessID As Long
        Private m_lPOID As Long
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
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
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
        Public Function SaveCPChart()
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
        Public Function GetProcessFirstTime() As DataTable
            Dim Str As String
            Str = " select *,CPChartID=0 from CPProcess "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetProcessHistory(ByVal POID As Long, ByVal CPProcessID As Long) As DataTable
            Dim Str As String
            Str = " Select *,Convert(Varchar,CPH.Creationdate,103) as CreationDatee, isnull((Convert(Varchar,convert(datetime, nullif(CPH.TargetSubmission,'') , 103),103)),'') as TargetSubmissionn,"
            Str &= " isnull((Convert(Varchar,convert(datetime, nullif(CPH.IstSubmission,'') , 103),103)),'')   as IstSubmissionn,"
            Str &= " isnull((Convert(Varchar,convert(datetime, nullif(CPH.RevisedTarget,'') , 103),103)),'') as RevisedTargett,"
            Str &= " isnull((Convert(Varchar,convert(datetime, nullif(CPH.RevisedSubmission,'') , 103),103)),'') as RevisedSubmissionn"
            Str &= " from CPChartHistory CPH"
            Str &= " join CPProcess CPP on CPP.CPProcessID=CPH.CPProcessID"
            Str &= " join CPChart CPC on CPC.CPChartID=CPH.CPChartID"
            Str &= " Where CPC.POID =" & POID
            Str &= " And CPH.CPProcessID =" & CPProcessID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function POIDExistCPChart(ByVal POID As Long) As DataTable
            Dim Str As String
            Str = " select * from CPChart "
            Str &= " Where POID =" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetChartEdit(ByVal POID As Long) As DataTable
            Dim Str As String
            Str = " Select *, isnull((Convert(Varchar,convert(datetime, nullif(CPC.TargetSubmission,'') , 103),103)),'') as TargetSubmissionn,"
            Str &= " isnull((Convert(Varchar,convert(datetime, nullif(CPC.IstSubmission,'') , 103),103)),'')   as IstSubmissionn,"
            Str &= " isnull((Convert(Varchar,convert(datetime, nullif(CPC.RevisedTarget,'') , 103),103)),'') as RevisedTargett,"
            Str &= " isnull((Convert(Varchar,convert(datetime, nullif(CPC.RevisedSubmission,'') , 103),103)),'') as RevisedSubmissionn"
            Str &= " from CPChart CPC "
            Str &= " join CPProcess CPP on CPP.CPProcessID=CPC.CPProcessID"
            Str &= " Where CPC.POID =" & POID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace