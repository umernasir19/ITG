Imports System.Data
Namespace EuroCentra
    Public Class FinishingLineDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FinishingLineDetail"
            m_strPrimaryFieldName = "FinishingLineDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lFinishingLineDetailID As Long
        Private m_lFinishingLineID As Long
        Private m_strStyleNo As String
        Private m_dtProductionDate As Date
        Private m_strDayStatus As String
        Private m_strWashing As String
        Private m_strPressing As String
        Private m_strPacking As String
        Private m_strReadyToInspect As String
        Public Property FinishingLineDetailID() As Long
            Get
                FinishingLineDetailID = m_lFinishingLineDetailID
            End Get
            Set(ByVal value As Long)
                m_lFinishingLineDetailID = value
            End Set
        End Property
        Public Property FinishingLineID() As Long
            Get
                FinishingLineID = m_lFinishingLineID
            End Get
            Set(ByVal value As Long)
                m_lFinishingLineID = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Property ProductionDate() As Date
            Get
                ProductionDate = m_dtProductionDate
            End Get
            Set(ByVal value As Date)
                m_dtProductionDate = value
            End Set
        End Property
        Public Property DayStatus() As String
            Get
                DayStatus = m_strDayStatus
            End Get
            Set(ByVal value As String)
                m_strDayStatus = value
            End Set
        End Property
        Public Property Washing() As String
            Get
                Washing = m_strWashing
            End Get
            Set(ByVal value As String)
                m_strWashing = value
            End Set
        End Property
        Public Property Pressing() As String
            Get
                Pressing = m_strPressing
            End Get
            Set(ByVal value As String)
                m_strPressing = value
            End Set
        End Property
        Public Property Packing() As String
            Get
                Packing = m_strPacking
            End Get
            Set(ByVal value As String)
                m_strPacking = value
            End Set
        End Property
        Public Property ReadyToInspect() As String
            Get
                ReadyToInspect = m_strReadyToInspect
            End Get
            Set(ByVal value As String)
                m_strReadyToInspect = value
            End Set
        End Property
        Public Function SaveFinishingLineDetail()
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