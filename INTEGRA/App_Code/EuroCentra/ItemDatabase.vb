Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class ItemDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ItemDatabase"
            m_strPrimaryFieldName = "ItemDatabaseID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lItemDatabaseID As Long
        Private m_strItemGroup As String
        Private m_strItemName As String
        Private m_strItemCode As String
        Private m_lGenderID As Long
        Private m_lItemDatabaseCount As Long
        Public Property ItemDatabaseCount() As Long
            Get
                ItemDatabaseCount = m_lItemDatabaseCount
            End Get
            Set(ByVal Value As Long)
                m_lItemDatabaseCount = Value
            End Set
        End Property
        Public Property GenderID() As Long
            Get
                GenderID = m_lGenderID
            End Get
            Set(ByVal Value As Long)
                m_lGenderID = Value
            End Set
        End Property
        Public Property ItemDatabaseID() As Long
            Get
                ItemDatabaseID = m_lItemDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lItemDatabaseID = Value
            End Set
        End Property
        Public Property ItemGroup() As String
            Get
                ItemGroup = m_strItemGroup
            End Get
            Set(ByVal value As String)
                m_strItemGroup = value
            End Set
        End Property
        Public Property ItemName() As String
            Get
                ItemName = m_strItemName
            End Get
            Set(ByVal value As String)
                m_strItemName = value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                ItemCode = m_strItemCode
            End Get
            Set(ByVal value As String)
                m_strItemCode = value
            End Set
        End Property
        Public Function SaveItemDatabase()
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

        Public Function GetItemGroup() As DataTable
            Dim str As String
            str = " select * from ItemGroup  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal ItemDatabaseID As String) As DataTable
            Dim str As String
            str = " select * from ItemDatabase IDB "
            str &= " left join ItemDatabaseBodyPart IDBP on IDBP.ItemDatabaseID=IDB.ItemDatabaseID"
            str &= " left join FabricPlacement FP on FP.FabricPlacementID=IDBP.FabricPlacementID"
            str &= " where IDB.ItemDatabaseID=" & ItemDatabaseID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = " Select * from ItemDatabase order by ItemDatabaseID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadAll() As DataTable
            Dim str As String
            str = " Select ItemDatabaseID,(ItemGroup + ' ' + ItemName) as ItemNames from ItemDatabase order by ItemGroup ASC  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Delete(ByVal ItemDatabaseID As String)
            Dim str As String
            str = " Delete from ItemDatabase where ItemDatabaseID=" & ItemDatabaseID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadGenders() As DataTable
            Dim str As String
            str = " Select * from Gender  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LastCode() As DataTable
            Dim str As String
            str = " Select * from ItemDatabase order by ItemDatabaseID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function LoadFabricPlacement() As DataTable
            Dim str As String
            str = " select * from FabricPlacement "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetLastItemCount()
            Dim str As String
            str = " Select top 1 ItemDatabaseCount from ItemDatabase"
            str &= " order by ItemDatabaseID DESC"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        'Public Function DeleteDetailById(ByVal YarnPurchaseContractMasterID As Long, ByVal YarnPurchaseContractDetailID As Long)
        '    Dim str As String = " Delete YarnPurchaseContractDetail where YarnPurchaseContractMasterID='" & YarnPurchaseContractMasterID & "'and YarnPurchaseContractDetailID=" & YarnPurchaseContractDetailID
        '    Try
        '        MyBase.ExecuteNonQuery(str)
        '    Catch ex As Exception

        '    End Try
        'End Function
    End Class
End Namespace