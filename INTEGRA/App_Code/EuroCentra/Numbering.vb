Imports Microsoft.VisualBasic
Imports System.Data
Public Class Numbering
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "Numbering"
        m_strPrimaryFieldName = "NumberingID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_lNumberingID As Long
    Private m_dCreationDate As Date
    Private m_lUserId As Long
    Private m_strNumberingNo As String
    Public Property NumberingNo() As String
        Get
            NumberingNo = m_strNumberingNo
        End Get
        Set(ByVal value As String)
            m_strNumberingNo = value
        End Set
    End Property
    Public Property NumberingID() As Long
        Get
            NumberingID = m_lNumberingID
        End Get
        Set(ByVal Value As Long)
            m_lNumberingID = Value
        End Set
    End Property
    Public Property CreationDate() As Date
        Get
            CreationDate = m_dCreationDate
        End Get
        Set(ByVal Value As Date)
            m_dCreationDate = Value
        End Set
    End Property
    Public Property UserId() As Long
        Get
            UserId = m_lUserId
        End Get
        Set(ByVal Value As Long)
            m_lUserId = Value
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

