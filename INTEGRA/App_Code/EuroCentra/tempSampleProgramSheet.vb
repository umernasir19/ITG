Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class tempSampleProgramSheet
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TemSampleProgramSheet"
            m_strPrimaryFieldName = "Tempid"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lTempid As Long
        Private m_strDalNo As String
        Private m_strBuyer As String
        Private m_strStyle As String
        Private m_strDescriptionn As String
        Private m_strSizee As String
        Private m_dcQuantity As Decimal
        Private m_strCompositionName As String
        Private m_strFabricName As String
        Private m_strPocketLining As String
        Private m_strWashingDetail As String
        Private m_strRemarks As String
        Private m_strThreadsNew As String
        Private m_strWidthCutable As String
        Private m_dtCreatDatee As Date
        Public Property Tempid() As Long
            Get
                Tempid = m_lTempid
            End Get
            Set(ByVal value As Long)
                m_lTempid = value
            End Set
        End Property
        Public Property DalNo() As String
            Get
                DalNo = m_strDalNo
            End Get
            Set(ByVal value As String)
                m_strDalNo = value
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
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Property Descriptionn() As String
            Get
                Descriptionn = m_strDescriptionn
            End Get
            Set(ByVal value As String)
                m_strDescriptionn = value
            End Set
        End Property
        Public Property Sizee() As String
            Get
                Sizee = m_strSizee
            End Get
            Set(ByVal value As String)
                m_strSizee = value
            End Set
        End Property
        Public Property Quantity() As Decimal
            Get
                Quantity = m_dcQuantity
            End Get
            Set(ByVal value As Decimal)
                m_dcQuantity = value
            End Set
        End Property
        Public Property CompositionName() As String
            Get
                CompositionName = m_strCompositionName
            End Get
            Set(ByVal value As String)
                m_strCompositionName = value
            End Set
        End Property
        Public Property FabricName() As String
            Get
                FabricName = m_strFabricName
            End Get
            Set(ByVal value As String)
                m_strFabricName = value
            End Set
        End Property
        Public Property PocketLining() As String
            Get
                PocketLining = m_strPocketLining
            End Get
            Set(ByVal value As String)
                m_strPocketLining = value
            End Set
        End Property
        Public Property WashingDetail() As String
            Get
                WashingDetail = m_strWashingDetail
            End Get
            Set(ByVal value As String)
                m_strWashingDetail = value
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
        Public Property ThreadsNew() As String
            Get
                ThreadsNew = m_strThreadsNew
            End Get
            Set(ByVal value As String)
                m_strThreadsNew = value
            End Set
        End Property
        Public Property WidthCutable() As String
            Get
                WidthCutable = m_strWidthCutable
            End Get
            Set(ByVal value As String)
                m_strWidthCutable = value
            End Set
        End Property
        Public Property CreatDatee() As Date
            Get
                CreatDatee = m_dtCreatDatee
            End Get
            Set(ByVal value As Date)
                m_dtCreatDatee = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
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
End Namespace
