Imports Microsoft.VisualBasic
Imports System.Data
Public Class SizeWiseWeightListMst
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "SizeWiseWeightListMst"
        m_strPrimaryFieldName = "SizeWiseWeightListMstID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lSizeWiseWeightListMstID As Long
    Private m_lJobOrderID As Long
    Private m_lUserID As Long
    Private m_dtCreationDate As Date
    Public Property SizeWiseWeightListMstID() As Long
        Get
            SizeWiseWeightListMstID = m_lSizeWiseWeightListMstID
        End Get
        Set(ByVal Value As Long)
            m_lSizeWiseWeightListMstID = Value
        End Set
    End Property
    Public Property JobOrderID() As Long
        Get
            JobOrderID = m_lJobOrderID
        End Get
        Set(ByVal Value As Long)
            m_lJobOrderID = Value
        End Set
    End Property
    Public Property UserID() As Long
        Get
            UserID = m_lUserID
        End Get
        Set(ByVal Value As Long)
            m_lUserID = Value
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
