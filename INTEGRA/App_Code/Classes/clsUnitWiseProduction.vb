
Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsUnitWiseProduction
    Inherits SQLManager

    Friend DAL1Total As Integer

    Public Sub New()
        m_strTableName = "TempUnitWiseProduction"
        m_strPrimaryFieldName = "TempUnitID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_TempUnitID As Long
    Private m_TempUnitDate As DateTime
    Private m_LineA As Long
    Private m_LineB As Long
    Private m_LineC As Long
    Private m_LineD As Long
    Private m_LineE As Long
    Private m_LineF As Long
    Private m_DAL1 As Long
    Private m_LineG As Long
    Private m_LineH As Long
    Private m_LineI As Long
    Private m_LineJ As Long
    Private m_LineK As Long
    Private m_LineL As Long
    Private m_DAL2 As Long
    Private m_LineM As Long
    Private m_LineN As Long
    Private m_LineO As Long
    Private m_LineP As Long
    Private m_LineQ As Long
    Private m_DAL3 As Long
    Private m_GrandTotal As Long

    Public Property TempUnitID() As Long
        Get
            TempUnitID = m_TempUnitID
        End Get
        Set(ByVal value As Long)
            m_TempUnitID = value
        End Set
    End Property
    Public Property TempUnitDate() As DateTime
        Get
            TempUnitDate = m_TempUnitDate
        End Get
        Set(ByVal value As DateTime)
            m_TempUnitDate = value
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
    Public Property DAL1() As Long
        Get
            DAL1 = m_DAL1
        End Get
        Set(ByVal value As Long)
            m_DAL1 = value
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
    Public Property DAL2() As Long
        Get
            DAL2 = m_DAL2
        End Get
        Set(ByVal value As Long)
            m_DAL2 = value
        End Set
    End Property
    Public Property LineM() As Long
        Get
            LineM = m_LineM
        End Get
        Set(ByVal value As Long)
            m_LineM = value
        End Set
    End Property
    Public Property LineN() As Long
        Get
            LineN = m_LineN
        End Get
        Set(ByVal value As Long)
            m_LineN = value
        End Set
    End Property
    Public Property LineO() As Long
        Get
            LineO = m_LineO
        End Get
        Set(ByVal value As Long)
            m_LineO = value
        End Set
    End Property
    Public Property LineP() As Long
        Get
            LineP = m_LineP
        End Get
        Set(ByVal value As Long)
            m_LineP = value
        End Set
    End Property
    Public Property LineQ() As Long
        Get
            LineQ = m_LineQ
        End Get
        Set(ByVal value As Long)
            m_LineQ = value
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

    Public Function GetDateAndQty(ByVal txtLineNumber As String, ByVal txtYear As String, ByVal txtMonth As String) As DataTable
        Dim str As String

        str = " select convert(varchar,stitch.CreationDate,103) as TempUnitDate ,sum(stitch.StitchingBit) as TotalQty from TFAStitching stitch "
        str &= " JOIN StyleAssortmentBarCodeDetail styleAss ON styleAss.StyleAssortmentBarCodeDetailID = stitch.StyleAssortmentBarCodeDetailID "
        str &= " where DATEPART(YEAR,stitch.CreationDate) = '" & txtYear & "'  and  styleAss.LineNumber ='" & txtLineNumber & "' and "
        str &= " DATEPART(Month,stitch.CreationDate) = '" & txtMonth & "'"
        str &= " group by convert(varchar,stitch.CreationDate,103),stitch.StitchingBit "

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

    Public Function CheckDate(ByVal txtDate As String) As DataTable
        Dim str As String
        str = "  select * from TempUnitWiseProduction where convert(varchar,TempUnitDate,103) = '" & txtDate & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function


    Public Function CheckDay(ByVal txtDay As String) As DataTable
        Dim str As String
        str = " select * from  TempUnitWiseProduction where DATEPART(DAY,tempunitDate) = '" & txtDay & "' "
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function

    Function GetID()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
End Class

