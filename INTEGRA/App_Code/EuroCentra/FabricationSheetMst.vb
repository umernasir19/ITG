Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabricationSheetMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabricationSheetMst"
            m_strPrimaryFieldName = "FabricationSheetMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricationSheetMstID As Long
        Private m_dtFabricDate As Date
        Private m_strReferenceNo As String
        Private m_strBuyer As String
        'Private m_dcTotalOrderQty As Decimal
        Private m_strPONumber As String
        Private m_strItem As String
        Public Property FabricationSheetMstID() As Long
            Get
                FabricationSheetMstID = m_lFabricationSheetMstID
            End Get
            Set(ByVal value As Long)
                m_lFabricationSheetMstID = value
            End Set
        End Property
        Public Property FabricDate() As Date
            Get
                FabricDate = m_dtFabricDate
            End Get
            Set(ByVal value As Date)
                m_dtFabricDate = value
            End Set
        End Property
        Public Property ReferenceNo() As String
            Get
                ReferenceNo = m_strReferenceNo
            End Get
            Set(ByVal value As String)
                m_strReferenceNo = value
            End Set
        End Property
        Public Property Buyer() As String
            Get
                Buyer = m_strBuyer
            End Get
            Set(ByVal value As String)
                m_strBuyer = value
            End Set
        End Property
        Public Property PONumber() As String
            Get
                PONumber = m_strPONumber
            End Get
            Set(ByVal value As String)
                m_strPONumber = value
            End Set
        End Property
        'Public Property TotalOrderQty() As Decimal
        '    Get
        '        TotalOrderQty = m_dcTotalOrderQty
        '    End Get
        '    Set(ByVal value As Decimal)
        '        m_dcTotalOrderQty = value
        '    End Set
        'End Property
        Public Property Item() As String
            Get
                Item = m_strItem
            End Get
            Set(ByVal value As String)
                m_strItem = value
            End Set
        End Property
        Public Function SaveFabricationSheetMst()
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
        Public Function DeleteDetail(ByVal FabricationSheetDtlID As Long)
            Dim Str As String
            Str = "Delete FabricationSheetDtl where FabricationSheetDtlID=" & FabricationSheetDtlID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetItemCode(ByVal IMSItemID As Long) As DataTable
            Dim str As String
            str = "   Select ItemCodee  as  ItemCode from IMSItem Itm where Itm.IMSItemId='" & IMSItemID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetView() As DataTable
            Dim str As String
            str = "  select CONVERT (varchar, FabricDate ,103)as FabricDate,* from FabricationSheetMst  fm "
            ' str &= "  join FabricationSheetDtl fd on fd.FabricationSheetMstID =fm.FabricationSheetMstID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal FabricationSheetMstID As Long) As DataTable
            Dim str As String
            str = " select CONVERT (varchar, FabricDate ,103)as FabricDate,* from FabricationSheetMst  fm"
            str &= " join FabricationSheetDtl fd on fd.FabricationSheetMstID =fm.FabricationSheetMstID "
            str &= " join IMSItem im on im .IMSItemID =fd.FabricIMSItemID "
            str &= " where fm.FabricationSheetMstID ='" & FabricationSheetMstID & "'"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemName() As DataTable
            Dim str As String
            '   str = "  Select Itm.ItemCodee as  ItemCode,Itm.IMSItemID from IMSItem Itm where Itm.IMSItemClassID=6 order by Itm.ItemCodee ASC "
            str = "  Select Itm.ItemName as  ItemName,Itm.IMSItemID from IMSItem Itm where Itm.IMSItemClassID=6 order by Itm.ItemName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class


End Namespace