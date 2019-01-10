Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Namespace EuroCentra
    Public Class InqStyleAccessories
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "InqStyleAccessories"
            m_strPrimaryFieldName = "InqSAID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_InqSAID As Long
        Private m_lInquiryStyleID As Long
        Private m_AccessoriesID As Long
        Private m_AccessoriesDescription As String
        Private m_Source As String
        Private m_ConAcc As Boolean
        Private m_OnlyConAcc As Boolean

        Public Property InqSAID() As Long
            Get
                InqSAID = m_InqSAID
            End Get
            Set(ByVal value As Long)
                m_InqSAID = value
            End Set
        End Property
        Public Property InquiryStyleID() As Long
            Get
                InquiryStyleID = m_lInquiryStyleID
            End Get
            Set(ByVal value As Long)
                m_lInquiryStyleID = value
            End Set
        End Property
        Public Property AccessoriesID() As Long
            Get
                AccessoriesID = m_AccessoriesID
            End Get
            Set(ByVal value As Long)
                m_AccessoriesID = value
            End Set
        End Property
        Public Property AccessoriesDescription() As String
            Get
                AccessoriesDescription = m_AccessoriesDescription
            End Get
            Set(ByVal value As String)
                m_AccessoriesDescription = value
            End Set
        End Property
        Public Property Source() As String
            Get
                Source = m_Source
            End Get
            Set(ByVal value As String)
                m_Source = value
            End Set
        End Property

        Public Property ConAcc As Boolean
            Get
                ConAcc = m_ConAcc

            End Get
            Set(ByVal value As Boolean)
                m_ConAcc = value
            End Set
        End Property
        Public Property OnlyConAcc As Boolean
            Get
                OnlyConAcc = m_OnlyConAcc

            End Get
            Set(ByVal value As Boolean)
                m_OnlyConAcc = value
            End Set
        End Property
        Public Function SaveStyleAccessories()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function DeleteDetailFromStyleAccessDetail(ByVal InqSAID As Long)
            Dim Str As String
            Str = " Delete from InqStyleAccessories where InqSAID=' " & InqSAID & " ' "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleAccessoriesList() As DataTable
            Dim str As String
            str = "Select * from StyleAccessoriesList order by AccessoriesName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccess(ByVal m_lInquiryStyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from InqStyleAccessories s "
            str &= " join StyleAccessoriesList sl on s.AccessoriesID=sl.AccessoriesID"
            str &= "  where s.InquiryStyleID='" & m_lInquiryStyleID & "' and OnlyConAcc=0"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccessCon(ByVal m_lInquiryStyleID As Long) As DataTable
            Dim str As String
            str = "  Select * from InqStyleAccessories s "
            str &= " join StyleAccessoriesList sl on s.AccessoriesID=sl.AccessoriesID"
            str &= "  where s.InquiryStyleID='" & m_lInquiryStyleID & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
