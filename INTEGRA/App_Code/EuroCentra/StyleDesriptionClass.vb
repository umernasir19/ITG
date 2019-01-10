Imports System.Data
Public Class StyleDesriptionClass
    Inherits SQLManager
    Public Sub New()
        m_strTableName = "StyleDescription"
        m_strPrimaryFieldName = "StyleDescriptionID"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub
    Private m_StyleDescriptionID As Long
    Private m_StyleDescription As String
    Private m_StyleCategoryId As Long
    Public Property StyleDescriptionID() As Long
        Get
            StyleDescriptionID = m_StyleDescriptionID
        End Get
        Set(ByVal Value As Long)
            m_StyleDescriptionID = Value
        End Set
    End Property
    Public Property StyleDescription() As String
        Get
            StyleDescription = m_StyleDescription
        End Get
        Set(ByVal value As String)
            m_StyleDescription = value
        End Set
    End Property
    Public Property StyleCategoryId() As Long
        Get
            StyleCategoryId = m_StyleCategoryId
        End Get
        Set(ByVal Value As Long)
            m_StyleCategoryId = Value
        End Set
    End Property
    Public Function Save()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetEdit(ByVal StyleDescriptionId As String)
        Dim Str As String
        Str = "select * from StyleDescription where StyleDescriptionId = '" & StyleDescriptionId & "'"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
End Class
