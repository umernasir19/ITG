Imports System.Data

Namespace EuroCentra
    Public Class TNAProcess
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TNAProcess"
            m_strPrimaryFieldName = "ProcessID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lProcessID As Long
        Private m_strProcess As String
        Private m_bIsActive As Boolean

        Public Property ProcessID() As Long
            Get
                ProcessID = m_lProcessID
            End Get
            Set(ByVal Value As Long)
                m_lProcessID = Value
            End Set
        End Property
        Public Property Process() As String
            Get
                Process = m_strProcess
            End Get
            Set(ByVal value As String)
                m_strProcess = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property

        Public Function SaveProcess()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetProcessById(ByVal lProcessId As Long)
            Try
                Return MyBase.GetById(lProcessId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessleft(Optional ByVal IPOID As Long = 0)
            Dim Str As String
            If IPOID = 0 Then
                ' Str = "Select ProcessID,Process,Status='True' from TNAProcess where Active=1 and Sequence<=14"
                Str = "Select top 16 ProcessID,Process,Status='True',ScheduleTime as SchedularDays"
                'Str &= " (case when ProcessID=1 then 9 when ProcessID=2 then 9 when ProcessID=4 then 7 "
                'Str &= " when ProcessID=7 then 1 when ProcessID=8 then 22 when ProcessID=9 then 1 when ProcessID=10 then 8 "
                'Str &= " when ProcessID=11 then 42 when ProcessID=12 then 21 when ProcessID=13 then 1 when ProcessID=27 then 0 "
                'Str &= " when ProcessID=14 then 7 when ProcessID=16 then 7 when ProcessID=17 then 1 when ProcessID=5 then 8 "
                'Str &= " when ProcessID=6 then 10 when ProcessID=15 then 10 when ProcessID=18 then 6 when ProcessID=19 then 10 "
                'Str &= " when ProcessID=20 then 19 when ProcessID=21 then 3 when ProcessID=22 then 8 when ProcessID=3 then 1 "
                'Str &= " when ProcessID=23 then 5 when ProcessID=24 then 1 when ProcessID=28 then 1 when ProcessID=25 then 1 when ProcessID=26 then 5 end)as SchedularDays"
                Str &= " from TNAProcess where Active=1 order by Sequence "



            Else
                Str = "Select ProcessID,Process,Status='False',ScheduleTime as SchedularDays from TNAProcess where Active=1 and Sequence<=16"
                Str &= " Union "
                Str &= " Select ProcessID,Process,Status='True',ScheduleTime as SchedularDays  from TNAChart Chrt  Join TNAProcess Prcs on TNAProcessID=ProcessID where  Sequence<=16 and POID=" & IPOID

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSampleProcess(Optional ByVal SamplesDevelopmentID As String = "", Optional ByVal POID As String = "")
            Dim Str, Strnew As String
            Strnew = "Select IsNull((Select Max(SamplesDevelopmentID) From SampleDevelopment Where POID=" & POID & "),0)as SamplesDevelopmentID"
            Try
                SamplesDevelopmentID = MyBase.GetScaler(Strnew)
            Catch ex As Exception

            End Try
            If SamplesDevelopmentID = 0 Then
                '    Str = "Select *,SamplesDevelopmentDetailID=0 ,ArtworkReceived='',IstSubmission='',ECPEvaluation='',DHLFEDEX='',CourierDetails='',ExpectedFeedBckReceived='',RevisedSubmission='',ExpectedECPEvaluation='',"
                '    Str &= " ExpectedDHLFEDEX='',ExpectedCourierDetails='',ExpectedFeedBckReceivedTwo='',StartsInWeek='',CompletesinWeek='',DaysRequired='',Remarks='',Status='',"
                '   Str &= " SamplesDevelopmentDetailID=0 from  TNAProcess P where P.IsSample=1 and Active=1"
                Str = "Select P.ProcessID ,"
                Str &= " (Case  When Process='Strike  Off / Lab Dips / Leg Panels' then  'Washed Leg Panels'   When Process='Counter Samples' then 'Counter Sample' When Process='Fit Sample' then 'Fit Sample'  When Process='Technical Sample' then 'Technical Sample / Processed Fabric' When Process='Chemical Test / SGS' then 'Chem. Test / SGS'"
                Str &= " When Process='Soft Proof of Accessories' then 'Trims (Soft Proof)' When Process='Physical Accessories' then 'Trims (Physical)' When Process='Size Set Sample' then 'Size Sets Sample' When Process='Photo Samples' then 'Photo Sample'"
                Str &= " When Process='Hohenstein Fitting / Pre Production Samples' then 'Hohenstein Fitting Sample / PP' When Process='Garment Washing' then 'Production (CMP) + Washimg' When Process='Production Sample' then 'Production Sample' When Process='Shipment Sample' then 'Shipment Sample' End ) as Process"
                Str &= " ,SamplesDevelopmentDetailID=0 ,Convert(Varchar,DateEstemated,106) as ArtworkReceived,IstSubmission='',ECPEvaluation='',DHLFEDEX='',CourierDetails='',ExpectedFeedBckReceived='',DaysRequired='',Remarks='',Status='',"
                Str &= " SamplesDevelopmentDetailID=0 from  TNAProcess P Join TNAChart Chrt on P.ProcessID=Chrt.TNAProcessID"
                Str &= " where chrt.POID = " & POID & " And P.IsSample = 1 And Active = 1 ORDER BY P.SampleSequence"

            Else
                Str = " Select P.ProcessID,"
                Str &= " (Case  When Process='Strike  Off / Lab Dips / Leg Panels' then  'Washed Leg Panels'   When Process='Counter Samples' then 'Counter Sample' When Process='Fit Sample' then 'Fit Sample'  When Process='Technical Sample' then 'Technical Sample / Processed Fabric' When Process='Chemical Test / SGS' then 'Chem. Test / SGS'"
                Str &= " When Process='Soft Proof of Accessories' then 'Trims (Soft Proof)' When Process='Physical Accessories' then 'Trims (Physical)' When Process='Size Set Sample' then 'Size Sets Sample' When Process='Photo Samples' then 'Photo Sample'"
                Str &= " When Process='Hohenstein Fitting / Pre Production Samples' then 'Hohenstein Fitting Sample / PP' When Process='Garment Washing' then 'Production (CMP) + Washimg' When Process='Production Sample' then 'Production Sample' When Process='Shipment Sample' then 'Shipment Sample' End ) as Process"
                Str &= ",SamplesDevelopmentDetailID,Convert(Varchar,DateEstemated,106) as ArtworkReceived,Sd.IstSubmission,Sd.ECPEvaluation,Sd.DHLFEDEX,Sd.CourierDetails,Sd.ExpectedFeedBckReceived,Sd.DaysRequired,Sd.Remarks,Sd.Status from TNAProcess P  Join SamplesDevelopmentDetail Sd "
                Str &= " On p.ProcessID=Sd.TNAprocessID Join SampleDevelopment S on SD.SamplesDevelopmentID=S.SamplesDevelopmentID join TNAChart Cht on Cht.TNAProcessID=P.ProcessID where P.IsSample=1 and Active=1 and Cht.POID=S.POID And S.SamplesDevelopmentID='" & SamplesDevelopmentID & "' ORDER BY P.SampleSequence"

            End If


            '  Str = "Select P.ProcessID,P.Process,sd.* from TNAProcess P left Join SamplesDevelopmentDetail Sd "
            ' Str &= "On p.ProcessID=Sd.TNAprocessID where P.IsSample=1 and Active=1 order By Sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProcessRight(Optional ByVal IPOID As Long = 0)
            Dim Str As String
            If IPOID = 0 Then
                '   Str = "Select ProcessID,Process,Status='True' from TNAProcess where Active=1 and Sequence>14"
                Str = "Select top 15 ProcessID,Process,Status='True',ScheduleTime as SchedularDays"
                'Str &= " (case when ProcessID=1 then 9 when ProcessID=2 then 9 when ProcessID=4 then 7 "
                'Str &= " when ProcessID=7 then 1 when ProcessID=8 then 22 when ProcessID=9 then 1 when ProcessID=10 then 8 "
                'Str &= " when ProcessID=11 then 42 when ProcessID=12 then 21 when ProcessID=13 then 1 when ProcessID=27 then 0 "
                'Str &= " when ProcessID=14 then 7 when ProcessID=16 then 7 when ProcessID=17 then 1 when ProcessID=5 then 8 "
                'Str &= " when ProcessID=6 then 10 when ProcessID=15 then 10 when ProcessID=18 then 6 when ProcessID=19 then 10 "
                'Str &= " when ProcessID=20 then 19 when ProcessID=21 then 3 when ProcessID=22 then 8 when ProcessID=3 then 1 "
                'Str &= " when ProcessID=23 then 5 when ProcessID=24 then 1 when ProcessID=28 then 1 when ProcessID=25 then 1 when ProcessID=26 then 5 end)as SchedularDays"
                Str &= " from TNAProcess where Active=1 "
                Str &= " and ProcessID Not in(Select top 16 ProcessID from TNAProcess where Active=1 order by Sequence )order by Sequence "



            Else
                Str = "Select ProcessID,Process,Status='False',ScheduleTime as SchedularDays from TNAProcess where Active=1 and Sequence>16"
                Str &= " Union "
                Str &= " Select ProcessID,Process,Status='True',ScheduleTime as SchedularDays  from TNAChart Chrt  Join TNAProcess Prcs on TNAProcessID=ProcessID where Sequence>16 and  POID=" & IPOID

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetReportProcess(ByVal lPOID As Long)
            Dim Str As String
           Str = "Select  P.ProcessID,P.Process,ISNull(TR.TestReportID,0)as TestReportID,TR.CreationDate,POID,TargetDate ,Convert(varchar,ActualSubmission,103)as ActualSubmission,Convert(varchar,RevisedSubmission,103)as RevisedSubmission,Remarks"
            Str &= " from TNAProcess P left Join  TestReport TR on P.ProcessID=TR.ProcessID where P.Isreport =1 "
            Str &= " Union Select  P.ProcessID,P.Process,ISNull(TR.TestReportID,0)as TestReportID,TR.CreationDate,POID,TargetDate ,Convert(varchar,ActualSubmission,103)as ActualSubmission ,Convert(varchar,RevisedSubmission,103)as RevisedSubmission,Remarks"
            Str &= " from TNAProcess P left Join  TestReport TR on P.ProcessID=TR.ProcessID where P.Isreport =1 "
            Str &= " and POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetALLProcess()
            Dim Str As String
            Str = "select * from TNAProcess order by Sequence"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetALLProcessNew(ByVal ECPDivision As String) As DataTable
            Dim Str As String

            If ECPDivision = "ECP 01" Then
                Str = "   Select top 21  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= "  where  ProcessID Not in(Select top 31 ProcessID from TNAProcess where Active=1)"

            ElseIf ECPDivision = "ECP 02" Then
                Str = "  Select top 18  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= "   where  ProcessID Not in(Select top 52 ProcessID from TNAProcess where Active=1)"

            ElseIf ECPDivision = "ECP 03" Then

                Str = "  Select top 18  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= "    where  ProcessID Not in(Select top 70 ProcessID from TNAProcess where Active=1)"

            Else
                Str = "     Select top 31  Sequence,Process,ProcessID,ScheduleTime as SchedularTime from TNAProcess "
                Str &= "    where  ProcessID  in(Select top 31 ProcessID from TNAProcess where Active=1)order by Sequence"
            End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace