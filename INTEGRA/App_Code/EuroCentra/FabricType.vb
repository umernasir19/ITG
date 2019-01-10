Imports System.Data

Namespace EuroCentra
    Public Class FabricType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabricType"
            m_strPrimaryFieldName = "FabricTypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricTypeID As Long
        Private m_strFabricType As String
        Private m_bIsActive As Boolean
        Public Property FabricTypeID() As Long
            Get
                FabricTypeID = m_lFabricTypeID
            End Get
            Set(ByVal value As Long)
                m_lFabricTypeID = value
            End Set
        End Property
        Public Property FabricType() As String
            Get
                FabricType = m_strFabricType
            End Get
            Set(ByVal value As String)
                m_strFabricType = value
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
        Public Function SaveFabricType()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllFabricType()
            Dim str As String
            Try
                str = " Select * from FabricType "
                str &= " order by FabricTypeID DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditFabricType(ByVal FabricTypeID As Long)
            Dim str As String
            Try
                str = " Select * from FabricType where FabricTypeID='" & FabricTypeID & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditFabricTypeCheck(ByVal FabricType As String)
            Dim str As String
            Try
                str = " Select * from FabricType where FabricType='" & FabricType & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetFabricType() As DataTable
            Dim str As String
            str = " select   * from FabricType  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function deletepodtl(ByVal FabricTypeID As Long)
            Dim Str As String
            Str = "delete from FabricType where FabricTypeID='" & FabricTypeID & "'  "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace