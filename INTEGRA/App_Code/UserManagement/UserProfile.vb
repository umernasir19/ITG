Imports System.Data

Namespace EuroCentra
    Public Class UserProfile
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "UserProfile"
            m_strPrimaryFieldName = "UserProfileID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lUserProfileID As Long
        Private m_strUserName As String
        Private m_lUserID As Long
        Private m_strECPDivistion As String
        Private m_strDesignation As String
        Private m_strQuestion As String
        Private m_strAnswer As String

        ''''''''''''''''''''''''''''''''''''''''''''''
        Public Property UserProfileID() As Long
            Get
                UserProfileID = m_lUserProfileID
            End Get
            Set(ByVal value As Long)

                m_lUserProfileID = value

            End Set
        End Property
        Public Property UserName() As String
            Get
                UserName = m_strUserName
            End Get
            Set(ByVal value As String)
                m_strUserName = value
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
        Public Property ECPDivistion() As String
            Get
                ECPDivistion = m_strECPDivistion
            End Get
            Set(ByVal value As String)
                m_strECPDivistion = value
            End Set
        End Property
        Public Property Designation() As String
            Get
                Designation = m_strDesignation
            End Get
            Set(ByVal value As String)
                m_strDesignation = value
            End Set
        End Property
        Public Property Question() As String
            Get
                Question = m_strQuestion
            End Get
            Set(ByVal value As String)
                m_strQuestion = value
            End Set
        End Property
        Public Property Answer() As String
            Get
                Answer = m_strAnswer
            End Get
            Set(ByVal value As String)
                m_strAnswer = value
            End Set
        End Property
        ''---------------- Properties

        Public Function SaveUserProfile()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace