Imports System.Data
Namespace EuroCentra
    Public Class UserConfirmation
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "UserConfirmation"
            m_strPrimaryFieldName = "ConfirmationID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lConfirmationID As Long
        Private m_lUserID As Long
        Private m_lMsgID As Long
        Private m_CreationDate As Date
        Public Property ConfirmationID() As Long
            Get
                ConfirmationID = m_lConfirmationID
            End Get
            Set(ByVal Value As Long)
                m_lConfirmationID = Value
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
        Public Property MsgID() As Long
            Get
                MsgID = m_lMsgID
            End Get
            Set(ByVal Value As Long)
                m_lMsgID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_CreationDate
            End Get
            Set(ByVal value As Date)
                m_CreationDate = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
