Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class JobOrderTestRequired
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "JobOrderTestRequired"
            m_strPrimaryFieldName = "JobOrderTestRequiredID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lJobOrderTestRequiredID As Long
        Private m_lJobOrderID As Long
        Private m_lTestingdatabaseID As Long
        Public Property JobOrderTestRequiredID() As Long
            Get
                JobOrderTestRequiredID = m_lJobOrderTestRequiredID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderTestRequiredID = Value
            End Set
        End Property

        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal value As Long)
                m_lJobOrderID = value
            End Set
        End Property
        Public Property TestingdatabaseID() As Long
            Get
                TestingdatabaseID = m_lTestingdatabaseID
            End Get
            Set(ByVal value As Long)
                m_lTestingdatabaseID = value
            End Set
        End Property


        Public Function SaveTestRequired()
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

