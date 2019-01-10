Imports System.Data

Namespace EuroCentra
    Public Class Color
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Color"
            m_strPrimaryFieldName = "ColorID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lColorID As Long
        Private m_strColor As String
        Private m_bIsActive As Boolean

        ''---------------- Properties
        Public Property ColorID() As Long
            Get
                ColorID = m_lColorID
            End Get
            Set(ByVal value As Long)
                m_lColorID = value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal value As String)
                m_strColor = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property

        Public Function SaveColor()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetColorById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorView() As DataTable
            Dim str As String
            str = "select ColorID as ID,Color as Name,TransType='Color' from Color"
            str &= " Union All"
            str &= " select SizeID as ID,SizeDescription as Name,TransType='Size' from Size"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetColorData(ByVal ColorID As Integer) As DataTable
            Dim str As String
            str = "select * from Color where ColorID=" & ColorID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetColor() As DataTable
            Dim str As String
            str = "Select ColorID,Color from Color "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace