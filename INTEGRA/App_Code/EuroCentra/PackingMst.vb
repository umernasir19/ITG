Imports System.Data
Namespace EuroCentra
    Public Class PackingMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PackingMst"
            m_strPrimaryFieldName = "PackingMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPackingMstID As Long
        Private m_lUserId As Long
        Private m_dtCreationDate As Date
        Private m_strPackingNo As String
        Private m_strDriverName As String
        Private m_strVehicleNO As String
        Private m_strTimeOut As String
        Public Property DriverName() As String
            Get
                DriverName = m_strDriverName
            End Get
            Set(ByVal Value As String)
                m_strDriverName = Value
            End Set
        End Property
        Public Property VehicleNO() As String
            Get
                VehicleNO = m_strVehicleNO
            End Get
            Set(ByVal Value As String)
                m_strVehicleNO = Value
            End Set
        End Property
        Public Property TimeOut() As String
            Get
                TimeOut = m_strTimeOut
            End Get
            Set(ByVal Value As String)
                m_strTimeOut = Value
            End Set
        End Property
        Public Property PackingNo() As String
            Get
                PackingNo = m_strPackingNo
            End Get
            Set(ByVal Value As String)
                m_strPackingNo = Value
            End Set
        End Property
        Public Property PackingMstID() As Long
            Get
                PackingMstID = m_lPackingMstID
            End Get
            Set(ByVal value As Long)
                m_lPackingMstID = value
            End Set
        End Property
        Public Property UserId() As Long
            Get
                UserId = m_lUserId
            End Get
            Set(ByVal value As Long)
                m_lUserId = value
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
        Public Function Save()
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
    End Class
End Namespace

