Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class PatternDepartTaskListMstNew
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "PATTERNDEPARTMENTTASKLISTMst"
        m_strPrimaryFieldName = "PATTERNDEPARTMENTTASKLISTMstid"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lPATTERNDEPARTMENTTASKLISTMstid As Long
    Private m_dtCreationDate As Date
    Private m_lUserId As Long
    Private m_lTypeID As Long
    Private m_strTaskNo As String
    Private m_dcPriority As Decimal
    Private m_strStyle As String
    Private m_lStyleID As Long
    Private m_strSRNO As String
    Private m_lJobOrderId As Long
    Private m_strBuyer As String
    Private m_lBuyerID As Long
    Private m_dtDateTimeStamp As Date
    Private m_strCreationTime As String
    Private m_dtReadByGGTDept As Date
    Private m_strFinishTimeStamp As String
    Private m_strRemarks As String
    Private m_strSample As Byte
    Private m_strPattern As Byte
    Private m_strDossier As Byte
    Private m_strSizeSpecs As Byte

    Private m_strPrinting As Byte
    Private m_strDyeing As Byte
    Private m_strEmbroidery As Byte

    Private m_strBit As String
    Private m_lDPRNDId As Long
    Private m_lFabricCosumFstoreID As Long
    Private m_lFabricCosumMerchID As Long
    Public Property Printing() As Boolean
        Get
            Printing = m_strPrinting
        End Get
        Set(ByVal value As Boolean)
            m_strPrinting = value
        End Set
    End Property
    Public Property Dyeing() As Boolean
        Get
            Dyeing = m_strDyeing
        End Get
        Set(ByVal value As Boolean)
            m_strDyeing = value
        End Set
    End Property
    Public Property Embroidery() As Boolean
        Get
            Embroidery = m_strEmbroidery
        End Get
        Set(ByVal value As Boolean)
            m_strEmbroidery = value
        End Set
    End Property

    Public Property DPRNDId() As Long
        Get
            DPRNDId = m_lDPRNDId
        End Get
        Set(ByVal value As Long)
            m_lDPRNDId = value
        End Set
    End Property
    Public Property FabricCosumFstoreID() As Long
        Get
            FabricCosumFstoreID = m_lFabricCosumFstoreID
        End Get
        Set(ByVal value As Long)
            m_lFabricCosumFstoreID = value
        End Set
    End Property
    Public Property FabricCosumMerchID() As Long
        Get
            FabricCosumMerchID = m_lFabricCosumMerchID
        End Get
        Set(ByVal value As Long)
            m_lFabricCosumMerchID = value
        End Set
    End Property
    Public Property PATTERNDEPARTMENTTASKLISTMstid() As Long
        Get
            PATTERNDEPARTMENTTASKLISTMstid = m_lPATTERNDEPARTMENTTASKLISTMstid
        End Get
        Set(ByVal value As Long)
            m_lPATTERNDEPARTMENTTASKLISTMstid = value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dtCreationDate
        End Get
        Set(ByVal Value As Date)
            m_dtCreationDate = Value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal value As Long)
            m_lUserId = value
        End Set
    End Property
    Public Property TypeID() As Long
        Get
            TypeID = m_lTypeID
        End Get
        Set(ByVal value As Long)
            m_lTypeID = value
        End Set
    End Property
    Public Property TaskNo() As String
        Get
            TaskNo = m_strTaskNo
        End Get
        Set(ByVal value As String)
            m_strTaskNo = value
        End Set
    End Property
    Public Property Priority() As Decimal
        Get
            Priority = m_dcPriority
        End Get
        Set(ByVal value As Decimal)
            m_dcPriority = value
        End Set
    End Property
    Public Property Style() As String
        Get
            Style = m_strStyle
        End Get
        Set(ByVal value As String)
            m_strStyle = value
        End Set
    End Property
    Public Property StyleID() As Long
        Get
            StyleID = m_lStyleID
        End Get
        Set(ByVal value As Long)
            m_lStyleID = value
        End Set
    End Property
    Public Property SRNO() As String
        Get
            SRNO = m_strSRNO
        End Get
        Set(ByVal value As String)
            m_strSRNO = value
        End Set
    End Property
    Public Property JobOrderId() As Long
        Get
            JobOrderId = m_lJobOrderId
        End Get
        Set(ByVal value As Long)
            m_lJobOrderId = value
        End Set
    End Property
    Public Property Buyer() As String
        Get
            Buyer = m_strBuyer
        End Get
        Set(ByVal value As String)
            m_strBuyer = value
        End Set
    End Property
    Public Property BuyerID() As Long
        Get
            BuyerID = m_lBuyerID
        End Get
        Set(ByVal value As Long)
            m_lBuyerID = value
        End Set
    End Property
    Public Property DateTimeStamp() As Date
        Get
            DateTimeStamp = m_dtDateTimeStamp
        End Get
        Set(ByVal value As Date)
            m_dtDateTimeStamp = value
        End Set
    End Property
    Public Property CreationTime() As String
        Get
            CreationTime = m_strCreationTime
        End Get
        Set(ByVal value As String)
            m_strCreationTime = value
        End Set
    End Property
    Public Property FinishTimeStamp() As String
        Get
            FinishTimeStamp = m_strFinishTimeStamp
        End Get
        Set(ByVal value As String)
            m_strFinishTimeStamp = value
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
    Public Property ReadByGGTDept() As Date
        Get
            ReadByGGTDept = m_dtReadByGGTDept
        End Get
        Set(ByVal value As Date)
            m_dtReadByGGTDept = value
        End Set
    End Property
    Public Property Sample() As Boolean
        Get
            Sample = m_strSample
        End Get
        Set(ByVal value As Boolean)
            m_strSample = value
        End Set
    End Property
    Public Property Pattern() As Boolean
        Get
            Pattern = m_strPattern
        End Get
        Set(ByVal value As Boolean)
            m_strPattern = value
        End Set
    End Property
    Public Property Dossier() As Boolean
        Get
            Dossier = m_strDossier
        End Get
        Set(ByVal value As Boolean)
            m_strDossier = value
        End Set
    End Property
    Public Property SizeSpecs() As Boolean
        Get
            SizeSpecs = m_strSizeSpecs
        End Get
        Set(ByVal value As Boolean)
            m_strSizeSpecs = value
        End Set
    End Property
    Public Property Bit() As String
        Get
            Bit = m_strBit
        End Get
        Set(ByVal value As String)
            m_strBit = value
        End Set
    End Property
   Public Function Save()
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
    Public Function UpdatePriority(ByVal PATTERNDEPARTMENTTASKLISTMstID As Long, ByVal Priority As Decimal)
        Dim Str As String
        Str = " update PATTERNDEPARTMENTTASKLISTMst set Priority='" & Priority & "'"
        Str &= " where PATTERNDEPARTMENTTASKLISTMstID ='" & PATTERNDEPARTMENTTASKLISTMstid & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetFileInfoTPNew(ByVal PATTERNDEPARTMENTTASKLISTMstid As Long)
        Dim str As String
        str = "   Select * from PATTERNDEPARTMENTTASKLISTDtl D  where  D.PATTERNDEPARTMENTTASKLISTMstid =" & PATTERNDEPARTMENTTASKLISTMstid
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetFileInfoTPNewNew(ByVal PATTERNDEPARTMENTTASKLISTMstid As Long, ByVal UserId As Long)
        Dim str As String
        str = "   Select * from PATTERNDEPARTMENTTASKLISTDtl D  where D.UserId= ' " & UserId & " ' and  D.PATTERNDEPARTMENTTASKLISTMstid =" & PATTERNDEPARTMENTTASKLISTMstid
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    
    Public Function ShowFIle(ByVal PATTERNDEPARTMENTTASKLISTDtlID As Long, ByVal PATTERNDEPARTMENTTASKLISTMstID As Long)
        Dim str As String
        str = "  Select * from PATTERNDEPARTMENTTASKLISTDtl where PATTERNDEPARTMENTTASKLISTDtlID=" & PATTERNDEPARTMENTTASKLISTDtlID
        str &= " and PATTERNDEPARTMENTTASKLISTMstID=" & PATTERNDEPARTMENTTASKLISTMstID
        Try
            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class
