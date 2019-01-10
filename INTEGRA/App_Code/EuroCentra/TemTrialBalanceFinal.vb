Imports Microsoft.VisualBasic
Imports System.Data
Namespace eurocentra
    Public Class TemTrialBalanceFinal
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "TemTrialBalanceFinal"
            m_strPrimaryFieldName = "TempTrialID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTempTrialID As Long
        Private m_strAccountcode As String
        Private m_strAccountName As String
        Private m_dDebit As Decimal
        Private m_dCredit As Decimal
        Private m_dOB As Decimal
        Private m_dLevelGroup As Decimal
        Public Property LevelGroup() As Decimal
            Get
                LevelGroup = m_dLevelGroup
            End Get
            Set(ByVal Value As Decimal)
                m_dLevelGroup = Value
            End Set
        End Property
        Public Property TempTrialID() As Long
            Get
                TempTrialID = m_lTempTrialID
            End Get
            Set(ByVal Value As Long)
                m_lTempTrialID = Value
            End Set
        End Property
        Public Property Accountcode() As String
            Get
                Accountcode = m_strAccountcode
            End Get
            Set(ByVal Value As String)
                m_strAccountcode = Value
            End Set
        End Property
        Public Property AccountName() As String
            Get
                AccountName = m_strAccountName
            End Get
            Set(ByVal Value As String)
                m_strAccountName = Value
            End Set
        End Property
        Public Property Debit() As Decimal
            Get
                Debit = m_dDebit
            End Get
            Set(ByVal Value As Decimal)
                m_dDebit = Value
            End Set
        End Property
        Public Property Credit() As Decimal
            Get
                Credit = m_dCredit
            End Get
            Set(ByVal Value As Decimal)
                m_dCredit = Value
            End Set
        End Property
        Public Property OB() As Decimal
            Get
                OB = m_dOB
            End Get
            Set(ByVal Value As Decimal)
                m_dOB = Value
            End Set
        End Property
        Public Function SaveTemTrialBalance()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace

