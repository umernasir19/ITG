Imports System.Data

Namespace EuroCentra
    Public Class Units
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Units"
            m_strPrimaryFieldName = "UnitID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_UnitID As Long
        Private m_UnitName As String

        Public Property UnitID() As Long
            Get
                UnitID = m_UnitID
            End Get
            Set(ByVal Value As Long)
                m_UnitID = Value
            End Set
        End Property
        Public Property UnitName() As String
            Get
                UnitName = m_UnitName
            End Get
            Set(ByVal value As String)
                m_UnitName = value
            End Set
        End Property
        Public Function SaveUnits()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAll(ByVal UnitID As String)
            Dim Str As String
            Str = "select * from Units where UnitID = '" & UnitID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllh()
            Dim Str As String
            Str = "select * from Units "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal UnitID As Long)
            Dim Str As String
            Str = " delete from Units where UnitID='" & UnitID & "' "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace