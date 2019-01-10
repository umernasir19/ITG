Imports System.Data

Namespace EuroCentra
    Public Class LogisticStatus
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "LogisticStatus"
            m_strPrimaryFieldName = "LogisticStatusID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lLogisticStatusID As Long
        Private m_dtCreationDate As Date
        Private m_lPOID As Long
        Private m_lPODetailID As Long
        Private m_strLogisticStatus As String
        Private m_lUserID As Long


        Public Property LogisticStatusID() As Long
            Get
                LogisticStatusID = m_lLogisticStatusID
            End Get
            Set(ByVal value As Long)
                m_lLogisticStatusID = value
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
        Public Property PODetailID() As Long
            Get
                PODetailID = m_lPODetailID
            End Get
            Set(ByVal value As Long)
                m_lPODetailID = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal value As Long)
                m_lUserID = value
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
        Public Property LogisticStatus() As String
            Get
                LogisticStatus = m_strLogisticStatus
            End Get
            Set(ByVal value As String)
                m_strLogisticStatus = value
            End Set
        End Property
        Public Function SaveLogisticStatus()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function


    End Class
End Namespace