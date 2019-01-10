Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Imports Microsoft.VisualBasic

Namespace EuroCentra
    Public Class IMSItemClass
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "IMSItemClass"
            m_strPrimaryFieldName = "IMSItemClassID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.ByteType
        End Sub
        Private m_lIMSItemClassID As Long
        Private m_dtCreationDate As Date
        Dim m_strItemClassName As String
        Dim m_strItemCode As String
        Private m_bIsActive As Boolean
        Dim m_strRemarks As String
        Private m_lStoreTypeID As Long
        Public Property StoreTypeID() As Long
            Get
                StoreTypeID = m_lStoreTypeID
            End Get
            Set(ByVal Value As Long)
                m_lStoreTypeID = Value
            End Set
        End Property
        Public Property IMSItemClassID() As Long
            Get
                IMSItemClassID = m_lIMSItemClassID
            End Get
            Set(ByVal Value As Long)
                m_lIMSItemClassID = Value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal Value As Date)
                m_dtCreationDate = Value
            End Set
        End Property
        Public Property ItemClassName() As String
            Get
                ItemClassName = m_strItemClassName
            End Get
            Set(ByVal Value As String)
                m_strItemClassName = Value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                ItemCode = m_strItemCode
            End Get
            Set(ByVal Value As String)
                m_strItemCode = Value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal Value As Boolean)
                m_bIsActive = Value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal Value As String)
                m_strRemarks = Value
            End Set
        End Property
        Public Function SaveIMSItemClass()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassEdit(ByVal IMSItemClassID As String) As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where IMSItemClassID=" & IMSItemClassID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemFabricStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=1"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemDeadStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=3"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemGeneralStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=4"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemAccessStoreForNewAcc() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=2 and ItemClassName ='DYEING PROCESS'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemAccessStoreForAuditor() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemAccessStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=2"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemChemicalStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=5"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStoreType() As DataTable
            Dim str As String
            str = " Select * from DPStoreType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllForFabric() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=1  order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllForChemical() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=5  order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllForAccessories() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=2  order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllForGStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=4  order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllForDead() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=3  order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllForGeneral() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=4  order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAllNew() As DataTable
            Dim str As String
            str = " select * from IMSItemClass where IMSItemClassID= '6' order by IMSItemClassID DESC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassItemCode(ByVal IMSItemClassID As String)
            Dim str As String
            str = " Select ItemCode    from IMSItemClass where IMSItemClassID=" & IMSItemClassID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAll() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassFabric() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=1 order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAccessories() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=2 order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassGStore() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=4 order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassAccessoriesForAuditor() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassDead() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=3 order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassGeneral() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=4 order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetItemClassChemical() As DataTable
            Dim str As String
            str = " Select * from IMSItemClass where StoreTypeID=5 order by IMSItemClassID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace