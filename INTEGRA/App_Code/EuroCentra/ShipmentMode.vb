Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class ShipmentMode
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ShipmentMode"
            m_strPrimaryFieldName = "ShipmentModeID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lShipmentModeID As Long
        Private m_strShipmentMode As String
        Public Property ShipmentMode() As String
            Get
                ShipmentMode = m_strShipmentMode
            End Get
            Set(ByVal value As String)
                m_strShipmentMode = value
            End Set
        End Property
        Public Property ShipmentModeID() As Long
            Get
                ShipmentModeID = m_lShipmentModeID
            End Get
            Set(ByVal Value As Long)
                m_lShipmentModeID = Value
            End Set
        End Property
        Public Function SaveShipmentMode()
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
        Public Function Getdata(ByVal CargoID As Long) As DataTable
            Dim str As String
            str = " select c.Aliass as BuyerName,co.InvoiceNo ,s.InvoiceAmount ,s.ExchangeRate ,s.AmountInPKR ,s.Remarks ,s.BankCode ,s.LCNO  from Shipment s"
            str &= " join Cargo co on co.CargoID =s.CargoID "
            str &= " join Customer c on c.CustomerName =s.Buyer "
            str &= " where s.CargoID='" & CargoID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Edit(ByVal ShipmentModeID As Long) As DataTable
            Dim str As String
            str = " Select * from ShipmentMode where ShipmentModeID=" & ShipmentModeID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim str As String
            str = " Select * from ShipmentMode  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace