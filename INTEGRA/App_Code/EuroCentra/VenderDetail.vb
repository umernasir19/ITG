Imports System.Data

Namespace EuroCentra
    Public Class VenderDetail
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderDetail"
            m_strPrimaryFieldName = "VenderDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lVenderDetailID As Long
        Private m_lVenderID As Long
        Private m_lID As Long
        Private m_strType As String
        Private m_strInhouseOutSource As String
       
        Public Property VenderDetailID() As Long
            Get
                VenderDetailID = m_lVenderDetailID
            End Get
            Set(ByVal Value As Long)
                m_lVenderDetailID = Value
            End Set
        End Property
        Public Property Venderid() As Long
            Get
                Venderid = m_lVenderID
            End Get
            Set(ByVal value As Long)
                m_lVenderID = value
            End Set
        End Property
        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal Value As Long)
                m_lID = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal value As String)
                m_strType = value
            End Set
        End Property
        Public Property InhouseOutSource() As String
            Get
                InhouseOutSource = m_strInhouseOutSource
            End Get
            Set(ByVal value As String)
                m_strInhouseOutSource = value
            End Set
        End Property
        Public Function SaveVenderDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetVenderDetailById(ByVal lVenderId As Long)
            Try
                Return MyBase.GetById(lVenderId)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteVerticleIntegrationDetail(ByVal ID As Long)
            Dim str As String
            str = " Delete  from VenderDetail where ID ='" & ID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function RemovePreStarus(ByVal VenderID As Integer)
            Dim str As String
            str = "Delete VenderDetail where VenderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getData(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select * from VenderDetail where VenderID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function RecordExist() As Boolean
            Dim str As String
            str = "select * from VenderDetail where VenderID=" & Me.m_lVenderID & " and certificateid=" & Me.m_lID & " and Type='Certificate' "
            Try
                Return MyBase.IsRecordExists(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function RemoveBeforeEdit(ByVal VenderID As Integer)
            Dim str As String
            str = "Delete VenderDetail where VenderID=" & VenderID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function

       End Class
End Namespace