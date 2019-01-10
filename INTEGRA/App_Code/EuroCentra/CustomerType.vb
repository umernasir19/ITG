Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra

    Public Class CustomerType
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CustomerType"
            m_strPrimaryFieldName = "CustomerTypeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lCustomerTypeID As Long
        Private m_strCustomerType As String


        '.............Properties
        Public Property CustomerTypeID() As Long
            Get
                CustomerTypeID = m_lCustomerTypeID
            End Get
            Set(ByVal value As Long)
                m_lCustomerTypeID = value
            End Set
        End Property

        Public Property CustomerType() As String
            Get
                CustomerType = m_strCustomerType
            End Get
            Set(ByVal value As String)
                m_strCustomerType = value
            End Set
        End Property

        Public Sub SaveCustomerType()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Sub

        Public Function GetCustomerTypeByID(ByVal lCustomerTypeID As Long)
            Try
                Return MyBase.GetById(lCustomerTypeID)
            Catch ex As Exception

            End Try

        End Function

        Function DeleteDetailsFromCustomerType(ByVal CustomerTypeID As Long)
            Dim str As String
            str = "Delete From CustomerType where CustomerTypeID =" & CustomerTypeID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try

        End Function

    End Class

End Namespace
