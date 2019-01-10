Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class QAProfileMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "QAProfileMST"
            m_strPrimaryFieldName = "QAMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_QAMstID As Long
        Private m_QAName As String
        Private m_QAAreasofExp As String
        Private m_QAID As Long
        Private m_QALevel As String
        Private m_QALevelID As Long
        Private m_Title As String
        Private m_TitleID As Long
        Public Property QAMstID() As Long
            Get
                QAMstID = m_QAMstID
            End Get
            Set(ByVal value As Long)
                m_QAMstID = value
            End Set
        End Property
        Public Property QAName() As String
            Get
                QAName = m_QAName
            End Get
            Set(ByVal value As String)
                m_QAName = value
            End Set
        End Property
        Public Property QAAreasofExp() As String
            Get
                QAAreasofExp = m_QAAreasofExp
            End Get
            Set(ByVal value As String)
                m_QAAreasofExp = value
            End Set
        End Property
        Public Property QAID() As Long
            Get
                QAID = m_QAID
            End Get
            Set(ByVal value As Long)
                m_QAID = value
            End Set
        End Property
        Public Property QALevel() As String
            Get
                QALevel = m_QALevel
            End Get
            Set(ByVal value As String)
                m_QALevel = value
            End Set
        End Property
        Public Property QALevelID() As Long
            Get
                QALevelID = m_QALevelID
            End Get
            Set(ByVal value As Long)
                m_QALevelID = value
            End Set
        End Property
        Public Property Title() As String
            Get
                Title = m_Title
            End Get
            Set(ByVal value As String)
                m_Title = value
            End Set
        End Property
        Public Property TitleID() As Long
            Get
                TitleID = m_TitleID
            End Get
            Set(ByVal value As Long)
                m_TitleID = value
            End Set
        End Property
        Public Function SaveQAProfile()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId()

            Catch ex As Exception

            End Try
        End Function
        Public Function GetEdit(ByVal QAMstID As Long)
            Dim str As String
            Try
                str = " Select CONVERT(varchar,StartDateQA, 103)as StartDateQA,CONVERT(varchar,EndDateQA, 103)as EndDateQA,* from QAProfileMst QAM"
                str &= " join QAProfileDtl QAD on QAM.QAMstID=QAD.QAMstID "
                str &= " where Qam.QAMstID ='" & QAMstID & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function GetView()
            Dim str As String
            str = " Select * from QAProfileMst QAM join QAProfileDtl QAD on QAM.QAMstID=QAD.QAMstID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindQDCombo() As DataTable
            Dim str As String
            str = "   select U.Userid, U.Username,U.ECPDivistion from Umuser U  "
            str &= "  where   U.ECPDivistion ='Quality Dept' and userid not in (72,74,75,76) "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAreaOfExpertise() As DataTable
            Dim str As String
            str = "  Select * from AreaOfExpertise  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetFactory() As DataTable
            Dim str As String
            str = "  Select * from Vender  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLocation(ByVal VenderID As Long) As DataTable
            Dim str As String
            str = "  select Town from Vender where VenderLibraryID='" & VenderID & "'  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindQDComboNew() As DataTable
            Dim str As String
            str = "   select QAProfileNameID, QAProfileName from QAProfileName   "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace


