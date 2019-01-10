Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_DyeingSpeciality
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_DyeingSpeciality"
            m_strPrimaryFieldName = "VAF_DyeingSpecialityID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVAF_DyeingSpecialityID As Long
        Private m_lVAFID As Long
        Private m_lDyeingID As Long
        Public Property VAF_DyeingSpecialityID() As Long
            Get
                VAF_DyeingSpecialityID = m_lVAF_DyeingSpecialityID
            End Get
            Set(ByVal Value As Long)
                m_lVAF_DyeingSpecialityID = Value
            End Set
        End Property
        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property DyeingID() As Long
            Get
                DyeingID = m_lDyeingID
            End Get
            Set(ByVal Value As Long)
                m_lDyeingID = Value
            End Set
        End Property
        Public Function SaveVAF_DyeingSpeciality()
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
        Public Function Delete(ByVal VAFID As Long)
            Dim Str As String
            Str = "Delete from VAF_DyeingSpeciality  "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace