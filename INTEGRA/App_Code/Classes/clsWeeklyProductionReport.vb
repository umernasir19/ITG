
Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsWeeklyProductionReport
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "TempProduction"
        m_strPrimaryFieldName = "TempProductionID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_TempProductionID As Long
    Private m_TempDate As DateTime
    Private m_LineA As Long
    Private m_LineB As Long
    Private m_LineC As Long
    Private m_LineD As Long
    Private m_LineE As Long
    Private m_LineF As Long
    Private m_LineG As Long
    Private m_LineH As Long
    Private m_LineI As Long
    Private m_LineJ As Long
    Private m_LineK As Long
    Private m_LineL As Long
    Private m_DAL3 As Long
    Private m_GrandTotal As Long

    Public Property TempProductionID() As Long
        Get
            TempProductionID = m_TempProductionID
        End Get
        Set(ByVal value As Long)
            m_TempProductionID = value
        End Set
    End Property
    Public Property TempDate() As DateTime
        Get
            TempDate = m_TempDate
        End Get
        Set(ByVal value As DateTime)
            m_TempDate = value
        End Set
    End Property
    Public Property LineA() As Long
        Get
            LineA = m_LineA
        End Get
        Set(ByVal value As Long)
            m_LineA = value
        End Set
    End Property
    Public Property LineB() As Long
        Get
            LineB = m_LineB
        End Get
        Set(ByVal value As Long)
            m_LineB = value
        End Set
    End Property
    Public Property LineC() As Long
        Get
            LineC = m_LineC
        End Get
        Set(ByVal value As Long)
            m_LineC = value
        End Set
    End Property
    Public Property LineD() As Long
        Get
            LineD = m_LineD
        End Get
        Set(ByVal value As Long)
            m_LineD = value
        End Set
    End Property
    Public Property LineE() As Long
        Get
            LineE = m_LineE
        End Get
        Set(ByVal value As Long)
            m_LineE = value
        End Set
    End Property
    Public Property LineF() As Long
        Get
            LineF = m_LineF
        End Get
        Set(ByVal value As Long)
            m_LineF = value
        End Set
    End Property
    Public Property LineG() As Long
        Get
            LineG = m_LineG
        End Get
        Set(ByVal value As Long)
            m_LineG = value
        End Set
    End Property
    Public Property LineH() As Long
        Get
            LineH = m_LineH
        End Get
        Set(ByVal value As Long)
            m_LineH = value
        End Set
    End Property
    Public Property LineI() As Long
        Get
            LineI = m_LineI
        End Get
        Set(ByVal value As Long)
            m_LineI = value
        End Set
    End Property
    Public Property LineJ() As Long
        Get
            LineJ = m_LineJ
        End Get
        Set(ByVal value As Long)
            m_LineJ = value
        End Set
    End Property
    Public Property LineK() As Long
        Get
            LineK = m_LineK
        End Get
        Set(ByVal value As Long)
            m_LineK = value
        End Set
    End Property
    Public Property LineL() As Long
        Get
            LineL = m_LineL
        End Get
        Set(ByVal value As Long)
            m_LineL = value
        End Set
    End Property
    Public Property DAL3() As Long
        Get
            DAL3 = m_DAL3
        End Get
        Set(ByVal value As Long)
            m_DAL3 = value
        End Set
    End Property
    Public Property GrandTotal() As Long
        Get
            GrandTotal = m_GrandTotal
        End Get
        Set(ByVal value As Long)
            m_GrandTotal = value
        End Set
    End Property

    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function

    Public Function GetDateAndQty(ByVal txtLineNumber As String, ByVal txtYear As String) As DataTable
        Dim str As String

        str = " select convert(varchar,stitch.CreationDate,103) as TempDate ,sum(stitch.StitchingBit) as TotalQty from TFAStitching stitch "
        str &= " JOIN StyleAssortmentBarCodeDetail styleAss ON styleAss.StyleAssortmentBarCodeDetailID = stitch.StyleAssortmentBarCodeDetailID "
        str &= " where DATEPART(YEAR,stitch.CreationDate) = '" & txtYear & "'  and  styleAss.LineNumber ='" & txtLineNumber & "' "
        str &= " group by convert(varchar,stitch.CreationDate,103),stitch.StitchingBit "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function

    Public Function CheckDate(ByVal txtDate As String) As DataTable
        Dim str As String
        str = " select * from TempProduction where convert(varchar,TempDate,103) = '" & txtDate & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

    Public Function UpdateRecord(ByVal txtQuery As String)
        Try
            MyBase.ExecuteNonQuery(txtQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetLineNumber(ByVal txtYear As String) As DataTable
        Dim str As String
        str = " select distinct styleAss.LineNumber from TFAStitching stitch"
        str &= " JOIN StyleAssortmentBarCodeDetail styleAss ON styleAss.StyleAssortmentBarCodeDetailID = stitch.StyleAssortmentBarCodeDetailID "
        str &= " where DATEPART(YEAR,stitch.CreationDate) = '" & txtYear & "' AND LineNumber <> '' "

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function


    'Public Function GetTotalQty(ByVal txtLineNumber As String, ByVal txtYear As String) As DataTable
    '    Dim str As String
    '    str = " select ISNULL(SUM(stitch.StitchingBit),0) as TotalQty from TFAStitching stitch "
    '    str &= " JOIN StyleAssortmentBarCodeDetail styleAss ON styleAss.StyleAssortmentBarCodeDetailID = stitch.StyleAssortmentBarCodeDetailID "
    '    str &= " where DATEPART(YEAR,stitch.CreationDate)= '" & txtYear & "' and styleAss.LineNumber = '" & txtLineNumber & "'  "

    '    Try
    '        Return MyBase.GetDataTable(str)
    '    Catch ex As Exception

    '    End Try
    'End Function

    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
End Class
