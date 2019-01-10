Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class GIACodingCustomer
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "GIACodingCustomer"
            m_strPrimaryFieldName = "GIACodingCustomerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_GIACodingCustomerID As Long
        Private m_lCustomerID As Long
        Private m_lSupplierID As Long
        Private str_GIANumber As String
        '----------------Properties
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal value As Long)
                m_lCustomerID = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal value As Long)
                m_lSupplierID = value
            End Set
        End Property
        Public Property GIANumber() As String
            Get
                GIANumber = str_GIANumber
            End Get
            Set(ByVal value As String)
                str_GIANumber = value
            End Set
        End Property
        Public Property GIACodingCustomerID() As Long
            Get
                GIACodingCustomerID = m_GIACodingCustomerID
            End Get
            Set(ByVal value As Long)
                m_GIACodingCustomerID = value
            End Set
        End Property
        Public Function SavGIACodingCustomer()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLKZId(ByVal lLKZid As Long)
            Try
                Return MyBase.GetById(lLKZid)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingOfLKZNumber(ByVal lSupplier As String, ByVal lCustomerID As String) As DataTable
            Dim Str As String
            If lSupplier <> "" And lCustomerID <> "" Then
                Str = " Select * from GIACodingCustomer  where Supplierid= '" & lSupplier & "' and Customerid= '" & lCustomerID & "' "
            Else

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckALlLKZ(ByVal lSupplier As String, ByVal lCustomer As String) As DataTable
            Dim Str As String
            Str = "  Select * from GIACodingCustomer SL"
            Str &= " join vender V on V.venderlibraryId=SL.supplierid"
            Str &= " join Customer C on C.Customerid=SL.Customerid where SL.Supplierid <> '' "
            If Not lSupplier = "ALL" Then
                Str &= " and SL.SupplierID='" & lSupplier & "'"
            End If
            If Not lCustomer = "ALL" Then
                Str &= " and SL.CustomerID ='" & lCustomer & "'"
            End If
            Str &= " order by V.vendername ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function





    End Class
End Namespace