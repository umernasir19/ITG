﻿Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class TempTurnover
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "tempTurnOver"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lID As Long
        Private m_strNo As String
        Private m_lJobOrdeId As Long
        Public Property JobOrdeId() As Long
            Get
                JobOrdeId = m_lJobOrdeId
            End Get
            Set(ByVal Value As Long)
                m_lJobOrdeId = Value
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
        Public Property No() As String
            Get
                No = m_strNo
            End Get
            Set(ByVal value As String)
                m_strNo = value
            End Set
        End Property
        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace

