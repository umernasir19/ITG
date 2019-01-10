Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
Public Class QAProfileName

 Inherits SQLManager
        Public Sub New()
            m_strTableName = "QAProfileName"
            m_strPrimaryFieldName = "QAProfileNameID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lQAProfileNameID As Long
        Private m_strQAProfileName As String
        Private m_strQAProfileGroup As String
        Private m_dtCreationDate As Date

        '.............Properties
        Public Property QAProfileNameID() As Long
            Get
                QAProfileNameID = m_lQAProfileNameID
            End Get
            Set(ByVal value As Long)
                m_lQAProfileNameID = value
            End Set
        End Property

        Public Property QAProfileName() As String
            Get
                QAProfileName = m_strQAProfileName
            End Get
            Set(ByVal value As String)
                m_strQAProfileName = value
            End Set
        End Property
        Public Property QAProfileGroup() As String
            Get
                QAProfileGroup = m_strQAProfileGroup
            End Get
            Set(ByVal value As String)
                m_strQAProfileGroup = value
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
        Public Sub SaveQAProfileName()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetQAProfileNameByID(ByVal lQAProfileNameID As Long)
            Try
                Return MyBase.GetById(lQAProfileNameID)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from QAProfileName  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetailsFromQAProfileName(ByVal QAProfileNameID As Long)
            Dim str As String
            str = " Delete From QAProfileName where QAProfileNameID='" & QAProfileNameID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetAllForEdit(ByVal QAProfileNameID As Long)
            Dim Str As String
            Str = "select * from QAProfileName where QAProfileNameID='" & QAProfileNameID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

