Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class ItemUnitStore
        Inherits SQLManager

        '*******************************************************
        '                   Class Constructor
        '*******************************************************

        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "IMSItemUnit"
            m_strPrimaryFieldName = "ItemUnitId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        '*******************************************************
        '                   Memory Variables
        '*******************************************************
        Private m_byItemUnitId As Byte
        Private m_strName As String
        Private m_strSymbol As String
        Private m_bIsActive As Boolean

        '*******************************************************
        '                   Properties
        '*******************************************************
        Public Property ItemUnitId() As Byte
            Get
                ItemUnitId = m_byItemUnitId
            End Get
            Set(ByVal Value As Byte)
                m_byItemUnitId = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Name = m_strName
            End Get
            Set(ByVal Value As String)
                m_strName = Value
            End Set
        End Property
        Public Property Symbol() As String
            Get
                Symbol = m_strSymbol
            End Get
            Set(ByVal Value As String)
                m_strSymbol = Value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal Value As Boolean)
                m_bIsActive = Value
            End Set
        End Property

        '*******************************************************
        '                   Functions
        '*******************************************************
        '*******************************************************
        '                   Functions
        '*******************************************************
        Public Function SaveStoreUnits()
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
        Public Function GetItemUnits() As DataTable
            Dim str As String
            str = " Select * from IMSItemUnit"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemUnitsEdit(ByVal ItemUnitId As Long) As DataTable
            Dim str As String
            str = " Select * from IMSItemUnit where ItemUnitId=" & ItemUnitId
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetail(ByVal ItemUnitId As Long)
            Dim Str As String
            Str = "Delete IMSItemUnit where ItemUnitId=" & ItemUnitId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function CheckExisting(ByVal Name As String)
            Dim Str As String
            Str = " select * from IMSItemUnit  where   Name like '" & Name & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingEdit(ByVal ItemUnitId As Long, ByVal Name As String)
            Dim Str As String
            Str = " select * from IMSItemUnit  where ItemUnitId <>" & ItemUnitId & " and Name like '" & Name & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
