Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class ParentGroupp
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ParentGroup"
            m_strPrimaryFieldName = "ParentGroupID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lParentGroupID As Long
        Private m_strParent As String


        '.............Properties
        Public Property ParentGroupID() As Long
            Get
                ParentGroupID = m_lParentGroupID
            End Get
            Set(ByVal value As Long)
                m_lParentGroupID = value
            End Set
        End Property

        Public Property Parent() As String
            Get
                Parent = m_strParent
            End Get
            Set(ByVal value As String)
                m_strParent = value
            End Set
        End Property

        Public Sub SaveParentGroup()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetParentGroupByID(ByVal lParentGroupID As Long)
            Try
                Return MyBase.GetById(lParentGroupID)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from ParentGroup  "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetailsFromParentGroup(ByVal ParentGroupID As Long)
            Dim str As String
            str = " Delete From ParentGroup where ParentGroupID='" & ParentGroupID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try

        End Function
        Public Function GetAllForEdit(ByVal ParentGroupID As Long)
            Dim Str As String
            Str = "select * from ParentGroup where ParentGroupID='" & ParentGroupID & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
