Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Public Class DyeWashRecipeMst

    Inherits SQLManager
    Public Sub New()
        m_strTableName = "DyeWashRecipeMst"
        m_strPrimaryFieldName = "DyeWashRecipeMstId"
        m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
    End Sub

    Private m_lDyeWashRecipeMstId As Long
    Private m_strRecipeNo As String
    Private m_strComposition As String
    Private m_dtCreationDate As Date
    Private m_strColor As String
    Private m_lCustomerID As Long
    Private m_strIntOrdNo As String
    Private m_dQtyPcs As Decimal
    Private m_strMachineID As String
    Private m_lJobID As Long
    Private m_lStyleID As Long
    Private m_dtRecipeDate As Date
    Public Property RecipeDate() As Date
        Get
            RecipeDate = m_dtRecipeDate
        End Get
        Set(ByVal value As Date)
            m_dtRecipeDate = value
        End Set
    End Property
    Public Property StyleID() As Long
        Get
            StyleID = m_lStyleID
        End Get
        Set(ByVal value As Long)
            m_lStyleID = value
        End Set
    End Property
    Public Property DyeWashRecipeMstId() As Long
        Get
            DyeWashRecipeMstId = m_lDyeWashRecipeMstId
        End Get
        Set(ByVal value As Long)
            m_lDyeWashRecipeMstId = value
        End Set
    End Property
    Public Property RecipeNo() As String
        Get
            RecipeNo = m_strRecipeNo
        End Get
        Set(ByVal value As String)
            m_strRecipeNo = value
        End Set
    End Property
    Public Property Composition() As String
        Get
            Composition = m_strComposition
        End Get
        Set(ByVal value As String)
            m_strComposition = value
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
    Public Property Color() As String
        Get
            Color = m_strColor
        End Get
        Set(ByVal value As String)
            m_strColor = value
        End Set
    End Property
    Public Property CustomerID() As Long
        Get
            CustomerID = m_lCustomerID
        End Get
        Set(ByVal value As Long)
            m_lCustomerID = value
        End Set
    End Property
    Public Property IntOrdNo() As String
        Get
            IntOrdNo = m_strIntOrdNo
        End Get
        Set(ByVal value As String)
            m_strIntOrdNo = value
        End Set
    End Property
   
    Public Property QtyPcs() As Decimal
        Get
            QtyPcs = m_dQtyPcs
        End Get
        Set(ByVal value As Decimal)
            m_dQtyPcs = value
        End Set
    End Property
    Public Property MachineID() As String
        Get
            MachineID = m_strMachineID
        End Get
        Set(ByVal value As String)
            m_strMachineID = value
        End Set
    End Property
    Public Property JobID() As Long
        Get
            JobID = m_lJobID
        End Get
        Set(ByVal value As Long)
            m_lJobID = value
        End Set
    End Property
    Public Function SaveMst()
        Try
            MyBase.Save()
        Catch ex As Exception

        End Try
    End Function
    Public Function GetCurrentId()
        Try
            Return MyBase.GetCurrentId
        Catch ex As Exception

        End Try
    End Function
    Public Function GetCustomer()
        Dim str As String
        Try
            str = "select distinct c.CustomerID ,c.CustomerName   from Customer c"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetUnit()
        Dim str As String
        Try
            str = "select * from IMSItemUnit   jo"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetSrno()
        Dim str As String
        Try
            str = "select distinct jo.SRNO   from JobOrderdatabase  jo"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetJobId(ByVal SRNO As String)
        Dim str As String
        Try
            str = "select  jo.Joborderid    from JobOrderdatabase  jo where jo.SRNO ='" & SRNO & "'"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetStyle(ByVal Joborderid As Long)
        Dim str As String
        Try
            str = " select * from JobOrderdatabaseDetail   jo where jo.Joborderid ='" & Joborderid & "'"


            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetQty(ByVal JoborderId As Long, ByVal joborderdetailid As Long)
        Dim str As String
        Try
            str = "select jo.Quantity    from JobOrderdatabaseDetail   jo where jo.JoborderId   ='" & JoborderId & "' and jo.joborderdetailid='" & joborderdetailid & "'"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetView()
        Dim str As String
        Try
            str = " select CONVERT(varchar,dm.CreationDate ,103)as CreateDate,* from DyeWashRecipeMst dm"
            str &= " join Customer c on c.CustomerID =dm.CustomerID JOIN JobOrderdatabaseDetail JOD on JOD.JoborderDetailid =dm.styleID"

            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetEdit(ByVal DyeWashRecipeMstId As Long)
        Dim str As String
        Try
            str = " select CONVERT(varchar,dm.CreationDate ,103)as CreateDate,* from DyeWashRecipeMst dm"
            str &= " join DyeWashRecipeDtl dwt on dwt.DyeWashRecipeMstId =dm.DyeWashRecipeMstId "
            str &= " join Customer c on c.CustomerID =dm.CustomerID "
            str &= "  Join IMSITEMUNIT IMU on IMU.ItemUnitID=dwt.ItemUnitID"
            str &= " where dm.DyeWashRecipeMstId ='" & DyeWashRecipeMstId & "'"


            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
    Public Function GetSrnoAndSeason()
        Dim str As String
        Try
            str = " select  jo.Joborderid ,jo.SRNO + ' ('+SD.SeasonName+')'  AS Srnoo   from JobOrderdatabase Jo"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID =JO.SeasonDatabaseID "


            Return MyBase.GetDataTable(str)
        Catch ex As Exception
        End Try
    End Function
End Class
