Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Public Class ProductionLineStatusHistory
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "ProductionLineStatusHistory"
        m_strPrimaryFieldName = "PLSHID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lPLSHID As Long
    Private m_lPLSDID As Long
    Private m_strStitchedQty As Decimal
    Private m_dtCreationDate As Date
    Private m_dtStitchedDate As String
    '''''''''''''''''''''''''''''Properties''''''''''''''''''''''''''''''
    Public Property PLSHID() As Long
        Get
            PLSHID = m_lPLSHID
        End Get
        Set(ByVal value As Long)
            m_lPLSHID = value
        End Set
    End Property
    Public Property PLSDID() As Long
        Get
            PLSDID = m_lPLSDID
        End Get
        Set(ByVal value As Long)
            m_lPLSDID = value
        End Set
    End Property
  
    Public Property StitchedQty() As Decimal
        Get
            StitchedQty = m_strStitchedQty
        End Get
        Set(ByVal value As Decimal)
            m_strStitchedQty = value
        End Set
    End Property
   Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal value As Date)
            m_dtCreationDate = value
        End Set
    End Property
    Public Property StitchedDate() As String
        Get
            StitchedDate = m_dtStitchedDate
        End Get
        Set(ByVal value As String)
            m_dtStitchedDate = value
        End Set
    End Property
    ''''''''''''''''''''''''''''''''''''''''''''''Quries''''''''''''''''''''''''''''''''''''''
    Public Function SaveProductionLineStatusHistory()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetProductionPlannedHistoryView(ByVal PLSEID As Long) As DataTable
        Dim str As String
        str = " Select PLSH.PLSDID, Convert(Varchar,PLSH.CreationDate,106)as CreationDate, PLSH.StitchedQty, Convert(Varchar, PLSH.StitchedDate,106) as StitchedDate,"
        str &= " PLSD.StyleNo, PLSD.BookedLines, PLSD.BookedQuantity from ProductionLineStatusHistory PLSH"
        str &= " Join ProductionLineStatusDetail PLSD on PLSD.PLSDID = PLSH.PLSDID Where PLSD.PLSEID = " & PLSEID

        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception

        End Try
    End Function
    Public Function GetStitchedQuantity(ByVal PLSEID As Long, ByVal StitchedDate As String)
        Dim str As String
        ' str = " Select isnull(convert(varchar,SUM(PLSH.StitchedQty)),'--') as StitchedQty from ProductionLineStatusHistory PLSH"
        str = " Select isnull(SUM(PLSH.StitchedQty),0) as StitchedQty from ProductionLineStatusHistory PLSH"
        str &= "   Join ProductionLineStatusDetail PLSD on PLSD.PLSDID = PLSH.PLSDID"
        str &= " Where PLsh.StitchedDate = '" & StitchedDate & " '"
        'str &= " Where PLsh.StitchedDate = '" & StitchedDate.Substring(6, 4) & "-" & StitchedDate.Substring(3, 2) & "-" & StitchedDate.Substring(0, 2) & "'"
        str &= "  And PLSD.PLSEID =" & PLSEID
        Try
            Return MyBase.GetScaler(str)
        Catch ex As Exception

        End Try
    End Function
End Class
