Imports System.Data

Namespace EuroCentra
    Public Class ProductType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ProductType"
            m_strPrimaryFieldName = "TypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lTypeID As Long
        Private m_strProductType As String
        Private m_bIsActive As Boolean
        Public Property TypeID() As Long
            Get
                TypeID = m_lTypeID
            End Get
            Set(ByVal value As Long)
                m_lTypeID = value
            End Set
        End Property
        Public Property ProductType() As String
            Get
                ProductType = m_strProductType
            End Get
            Set(ByVal value As String)
                m_strProductType = value
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
        Public Function SaveProductType()
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
        Public Function GetAllProductType()
            Dim str As String
            Try
                str = " Select * from ProductType "
                str &= " order by TypeID DESC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetEditProductType(ByVal ProductType As String)
            Dim str As String
            Try
                str = " Select * from ProductType where ProductType='" & ProductType & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetEditProductEntry(ByVal TypeID As Long)
            Dim str As String
            Try
                str = "   Select * from ProductType  "
                str &= "  where TypeID=" & TypeID

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function deletepodtl(ByVal TypeID As Long)
            Dim str As String
            Try
                str = "   delete from ProductType where TypeID= '" & TypeID & "'"

                ExecuteNonQuery(str)

            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace