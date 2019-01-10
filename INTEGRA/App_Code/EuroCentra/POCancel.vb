Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class POCancel
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "POCancel"
            m_strPrimaryFieldName = "POCancelID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub


        Private m_lPOCancelID As Long
        Private m_lUserid As Long
        Private m_dtCreationDate As Date

        Public Property POCancelID() As Long
            Get
                POCancelID = m_lPOCancelID
            End Get
            Set(ByVal value As Long)
                m_lPOCancelID = value
            End Set
        End Property
        Public Property Userid() As Long
            Get
                Userid = m_lUserid
            End Get
            Set(ByVal value As Long)
                m_lUserid = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function SavePOCancel()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace