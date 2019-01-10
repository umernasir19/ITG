Imports System.Data

Namespace EuroCentra
    Public Class VenderVerticalIntegration
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderVerticalIntegration"
            m_strPrimaryFieldName = "VVIID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lVVIID As Long
        Private m_strName As String
        Private m_dtCreationDate As Date
        Private m_strType As String
        Private m_bIsActive As Boolean
        ''---------------- Properties
        Public Property VVIID() As Long
            Get
                VVIID = m_lVVIID
            End Get
            Set(ByVal value As Long)
                m_lVVIID = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Name = m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
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
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal value As String)
                m_strType = value
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
        Public Function SaveVenderVerticalIntegration()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function DeleteVerticleIntegrationDetail(ByVal ID As Long)
            Dim str As String
            str = " Delete  from VenderDetail where ID ='" & ID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderVerticalIntegrationByType(ByVal Type As String, ByVal VenderID As Long) As DataTable
            Dim str As String
            If VenderID = 0 Then
                str = "Select  VVIID,Name,Type,Status='false' from VenderVerticalIntegration where Type='" & Type & "'"
            Else
                str = "Select VVIID,Name,Type,Status='false' from VenderVerticalIntegration where Type='" & Type & "' "
                str &= " Union "
                str &= " Select VVI.VVIID,VVI.Name,VVI.Type,Status='True' from VenderVerticalIntegration VVI"
                str &= " Join VenderDetail VD on VVI.VVIID=VD.VVIID where Type='" & Type & "' and VenderID=" & VenderID

            End If


            
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductForEdit(ByVal VVIID As Long) As DataTable
            Dim Str As String
            Str = "Select *  from VenderVerticalIntegration where VVIID='" & VVIID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVenderVerticalIntegrationByVenderId(ByVal VenderID As Long) As DataTable
            Dim Str As String = "Select VVIID,Name from VenderVerticalIntegration VVI Join VenderDetail VD on VVI.VVIID=VD.ID Where VenderiD=" & VenderID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductGroup() As DataTable
            Dim Str As String
            Str = "Select VVIID,Name from VenderVerticalIntegration where Type='Product Group' order by name asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVerticalIntegration() As DataTable
            Dim Str As String
            Str = "Select VVIID,Name from VenderVerticalIntegration where Type='Vertical Integration' order by name asc"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetVIandPGByVender(ByVal Vender As Long, ByVal Type As String) As DataTable
            Dim Str As String
            Str = "Select VenderID,VVIID,Name from VenderVerticalIntegration VVI Join Venderdetail VD"
            Str &= " on VVI.VVIID=VD.ID and VVI.Type=VD.Type where VenderID=" & Vender & " and VD.Type='" & Type & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function deletepodtl(ByVal VVIID As Long) As DataTable
            Dim Str As String
            Str = " delete from venderverticalintegration where VVIID='" & VVIID & "' "
            Try
                ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
         
     End Class
End Namespace