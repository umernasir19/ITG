Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class DPBuyerComment
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "DPBuyerComment"
            m_strPrimaryFieldName = "BuyerCommentID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lBuyerCommentID As Long
        Private m_lDPCourierMstId As Long
        Private m_strDCDNo As String
        Private m_strBuyerComment As String
        Private m_dCommentDate As Date
        Public Property BuyerCommentID() As Long
            Get
                BuyerCommentID = m_lBuyerCommentID
            End Get
            Set(ByVal value As Long)
                m_lBuyerCommentID = value
            End Set
        End Property
        Public Property DPCourierMstId() As Long
            Get
                DPCourierMstId = m_lDPCourierMstId
            End Get
            Set(ByVal value As Long)
                m_lDPCourierMstId = value
            End Set
        End Property
        Public Property DCDNo() As String
            Get
                DCDNo = m_strDCDNo
            End Get
            Set(ByVal value As String)
                m_strDCDNo = value
            End Set
        End Property
        Public Property BuyerComment() As String
            Get
                BuyerComment = m_strBuyerComment
            End Get
            Set(ByVal value As String)
                m_strBuyerComment = value
            End Set
        End Property
        Public Property CommentDate() As Date
            Get
                CommentDate = m_dCommentDate
            End Get
            Set(ByVal value As Date)
                m_dCommentDate = value
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
        Function GetDCDNo(ByVal DCDNO As String)
            Dim Str As String
            Str = " select DCDNO AS Name from DPCourierMst where DCDNO like '" & DCDNO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromStyleDatabase(ByVal StyleCode As String)
            Dim Str As String
            Str = " select StyleCode AS Name from DPStyleDatabase where StyleCode like '" & StyleCode & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromStyleDatabaseNew(ByVal StyleCode As String)
            Dim Str As String
            Str = " select REPLACE(StyleCode, '/', '\') AS Name from DPStyleDatabase where StyleCode like '" & StyleCode & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetLCNOFromLCEntry(ByVal LCNO As String)
            Dim Str As String
            Str = " select DISTINCT LCNO AS Name from LCExportDtl where LCNO like '" & LCNO & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCommodity(ByVal Commodity As String)
            Dim Str As String
            Str = " select DISTINCT Commodity AS Name from Commodity where Commodity like '" & Commodity & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierNameFromJobOrder(ByVal SupplierName As String)
            Dim Str As String
            Str = " select SupplierName AS Name from SupplierDatabase where SupplierName like '" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetSupplierNameFromOnlyFStore(ByVal SupplierName As String)
            Dim Str As String
            Str = " select SupplierName AS Name from SupplierDatabase where SupplierName like '" & SupplierName & "%' and Userid=241"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDalNoFromJobOrder(ByVal DalNo As String, ByVal SupplierID As Long)
            Dim Str As String
            Str = " select DalNo AS Name from DPFabricDBMst where DalNo like '" & DalNo & "%' and SupplierID='" & SupplierID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromJobOrder(ByVal Style As String, ByVal FabricDBMstID As Long)
            Dim Str As String
            Str = " select Style AS Name from TblDPRND where Style like '" & Style & "%' and FabricDBMstID='" & FabricDBMstID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromJobOrderNew(ByVal Style As String, ByVal FabricDBMstID As Long)
            Dim Str As String
            Str = " select REPLACE(StyleCode, '/', '\') AS Name from TblDPRND where Style like '" & Style & "%' and FabricDBMstID='" & FabricDBMstID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromJobOrderNew(ByVal Style As String)
            Dim Str As String
            Str = " select Style AS Name from TblDPRND where Style like '" & Style & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromJobOrderNewNew(ByVal StyleCode As String)
            Dim Str As String
            Str = " select StyleCode AS Name from DPStyleDatabase where StyleCode like '" & StyleCode & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetStyleNoFromJobOrderNewNewNew(ByVal StyleCode As String)
            Dim Str As String
            Str = " select REPLACE(StyleCode, '/', '\') AS Name from DPStyleDatabase where StyleCode like '" & StyleCode & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetView()
            Dim Str As String
            Str = " select convert(varchar,CommentDate ,103)as CommentDatee,* from DPBuyerComment"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace