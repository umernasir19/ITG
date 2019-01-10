Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Namespace EuroCentra
    Public Class PurchaseOrderReviseShipment
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PurchaseOrderReviseShipment"
            m_strPrimaryFieldName = "POReviseShipmentID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPOReviseShipmentID As Long
        Private m_dtCreationDate As Date
        Private m_lPOId As Long
        Private m_DShipmentDate As Date
        Public Property POReviseShipmentID() As Long
            Get
                POReviseShipmentID = m_lPOReviseShipmentID
            End Get
            Set(ByVal Value As Long)
                m_lPOReviseShipmentID = Value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOId
            End Get
            Set(ByVal Value As Long)
                m_lPOId = Value
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
        Public Property ShipmentDate() As Date
            Get
                ShipmentDate = m_DShipmentDate
            End Get
            Set(ByVal value As Date)
                m_DShipmentDate = value
            End Set
        End Property
        Public Function SavePurchaseOrderReviseShipment()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOReviseShipID(ByVal lPOReviseShipmentID As Long)
            Try
                Return MyBase.GetById(lPOReviseShipmentID)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPurchaseOrderShipDateTop(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select * from PurchaseOrderReviseShipment  where  POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExisting(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select * ,Convert(Varchar,ShipmentDate,103) AS ShipmentDatee  from PurchaseOrderReviseShipment  where  POID=" & lPOID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckRevisedShipDate(ByVal lPOID As Long) As DataTable
            Dim Str As String
            Str = " Select Convert(Varchar,ShipmentDate,106) AS ShipmentDate from PurchaseOrderReviseShipment  where  POID=" & lPOID
            Str &= " order by POReviseShipmentID desc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOForEcistingShipmetDatee(Optional ByVal lPOID As Long = 0, Optional ByVal ShipmentDate As String = "") As DataTable
            Dim Str As String

            ' ShipmentDate = ShipmentDate.Substring(6, 4) & "-" & ShipmentDate.Substring(3, 2) & "-" & ShipmentDate.Substring(0, 2)
            Str = " Select * from  PurchaseOrderReviseShipment Where POID= '" & lPOID & "' and ShipmentDate = '" & ShipmentDate & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOForEcistingShipmetDate(Optional ByVal lPOID As Long = 0, Optional ByVal ShipmentDate As String = "") As DataTable
            Dim Str As String

            ShipmentDate = ShipmentDate.Substring(6, 4) & "-" & ShipmentDate.Substring(3, 2) & "-" & ShipmentDate.Substring(0, 2)
            Str = "Select * from  PurchaseOrderReviseShipment Where POID= '" & lPOID & "' and ShipmentDate = '" & ShipmentDate & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace
