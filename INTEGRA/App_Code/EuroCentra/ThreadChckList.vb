Imports system.data
Namespace eurocentra
    Public Class ThreadChckList
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ThreadCheckList"
            m_strPrimaryFieldName = "ThreadCheckListID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lThreadCheckListID As Long
        Private m_lAccCheckListMstID As Long
        Private m_strDescription As String
        Private m_strThreadColor As String
        Private m_strJPShade As String
        Private m_strJPCode As String
        Private m_StrCount As String
        Private m_dMtr1con As Decimal
        Private m_dConsumption As Decimal
        Private m_dThreadQtyPcs As Decimal
        Private m_dRCones As Decimal
        Private m_lItemID As Long
        Private m_dOrderQtyForThread As Decimal
        Private m_dPerForThread As Decimal
        Public Property OrderQtyForThread() As Decimal
            Get
                OrderQtyForThread = m_dOrderQtyForThread
            End Get
            Set(ByVal value As Decimal)
                m_dOrderQtyForThread = value
            End Set
        End Property
        Public Property PerForThread() As Decimal
            Get
                PerForThread = m_dPerForThread
            End Get
            Set(ByVal value As Decimal)
                m_dPerForThread = value
            End Set
        End Property
        Public Property ItemID() As Long
            Get
                ItemID = m_lItemID
            End Get
            Set(ByVal Value As Long)
                m_lItemID = Value
            End Set
        End Property
        Public Property ThreadCheckListID() As Long
            Get
                ThreadCheckListID = m_lThreadCheckListID
            End Get
            Set(ByVal Value As Long)
                m_lThreadCheckListID = Value
            End Set
        End Property
        Public Property AccCheckListMstID() As Long
            Get
                AccCheckListMstID = m_lAccCheckListMstID
            End Get
            Set(ByVal Value As Long)
                m_lAccCheckListMstID = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        Public Property ThreadColor() As String
            Get
                ThreadColor = m_strThreadColor
            End Get
            Set(ByVal value As String)
                m_strThreadColor = value
            End Set
        End Property
        Public Property JPShade() As String
            Get
                JPShade = m_strJPShade
            End Get
            Set(ByVal value As String)
                m_strJPShade = value
            End Set
        End Property
        Public Property JPCode() As String
            Get
                JPCode = m_strJPCode
            End Get
            Set(ByVal value As String)
                m_strJPCode = value
            End Set
        End Property
        Public Property Count() As String
            Get
                Count = m_StrCount
            End Get
            Set(ByVal value As String)
                m_StrCount = value
            End Set
        End Property
        Public Property Mtr1con() As Decimal
            Get
                Mtr1con = m_dMtr1con
            End Get
            Set(ByVal value As Decimal)
                m_dMtr1con = value
            End Set
        End Property
        Public Property Consumption() As Decimal
            Get
                Consumption = m_dConsumption
            End Get
            Set(ByVal value As Decimal)
                m_dConsumption = value
            End Set
        End Property
        Public Property ThreadQtyPcs() As Decimal
            Get
                ThreadQtyPcs = m_dThreadQtyPcs
            End Get
            Set(ByVal value As Decimal)
                m_dThreadQtyPcs = value
            End Set
        End Property
        Public Property RCones() As Decimal
            Get
                RCones = m_dRCones
            End Get
            Set(ByVal value As Decimal)
                m_dRCones = value
            End Set
        End Property
        Public Function SaveThreadCheckList()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccThreadDtl(ByVal AccCheckListMstID As Long) As DataTable
            Dim str As String
            str = " select * from  AccCheckListMst AM "
            str &= " JOIN ThreadCheckList AD ON AD.AccCheckListMstid=AM.AccCheckListMstid"
            str &= " left JOIN ImsItem IM ON IM.ImsItemid=AD.Itemid"
            str &= " WHERE AM.AccCheckListMstid = '" & AccCheckListMstID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAccID(ByVal ItemCodee As String) As DataTable
            Dim str As String
            str = " select * from  imsitem AM "
            str &= " join  IMSItemCategory IC on IC.IMSItemCategoryId=AM.IMSItemCategoryId"
            str &= " WHERE AM.ItemCodee = '" & ItemCodee & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace



