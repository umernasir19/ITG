Imports System.Data

Namespace EuroCentra
    Public Class VenderPersonnel
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VenderPersonnel"
            m_strPrimaryFieldName = "VenderPersonnelID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lVenderPersonnelID As Long
        Private m_lVenderLibraryID As Long
        Private m_strContactType As String
        Private m_strPersonName As String
        Private m_strDesignation As String
        Private m_strCellNo As String
        Private m_strEmailAddress As String


        ''---------------- Properties
        Public Property EmailAddress() As String
            Get
                EmailAddress = m_strEmailAddress
            End Get
            Set(ByVal value As String)
                m_strEmailAddress = value
            End Set
        End Property
        Public Property CellNo() As String
            Get
                CellNo = m_strCellNo
            End Get
            Set(ByVal value As String)
                m_strCellNo = value
            End Set
        End Property
        Public Property VenderPersonnelID() As Long
            Get
                VenderPersonnelID = m_lVenderPersonnelID
            End Get
            Set(ByVal value As Long)
                m_lVenderPersonnelID = value
            End Set
        End Property
        Public Property VenderLibraryID() As Long
            Get
                VenderLibraryID = m_lVenderLibraryID
            End Get
            Set(ByVal value As Long)
                m_lVenderLibraryID = value
            End Set
        End Property
        Public Property ContactType() As String
            Get
                ContactType = m_strContactType
            End Get
            Set(ByVal value As String)
                m_strContactType = value
            End Set
        End Property
        Public Property PersonName() As String
            Get
                PersonName = m_strPersonName
            End Get
            Set(ByVal value As String)
                m_strPersonName = value
            End Set
        End Property
        Public Property Designation() As String
            Get
                Designation = m_strDesignation
            End Get
            Set(ByVal value As String)
                m_strDesignation = value
            End Set
        End Property
        Public Function SaveVenderPersonnel()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderPersonnelID(ByVal VenderPersonnelID As Long)
            Try
                Return MyBase.GetById(VenderPersonnelID)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteVenderPersonalDetail(ByVal VenderPersonnelID As Long)
            Dim str As String
            str = " Delete  from VenderPersonnel where VenderPersonnelID ='" & VenderPersonnelID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteVerticleIntegrationDetail(ByVal ID As Long)
            Dim str As String
            str = " Delete  from VenderPersonnel where VenderPersonnelID ='" & VenderPersonnelID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function DeleteVendergraphicsDetail(ByVal VDID As Long)
            Dim str As String
            str = " Delete  from VenderDemographics where VDID ='" & VDID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace