Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class SupplierLKZNo
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SupplierLKZ"
            m_strPrimaryFieldName = "LKZid"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lLKZid As Long
        Private m_lCustomerID As Long
        Private m_lSupplierID As Long
        Private str_LKZNumber As String
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
        Public Property LKZNumber() As String
            Get
                LKZNumber = str_LKZNumber
            End Get
            Set(ByVal value As String)
                str_LKZNumber = value
            End Set
        End Property
        Public Property LKZid() As Long
            Get
                LKZid = m_lLKZid
            End Get
            Set(ByVal value As Long)
                m_lLKZid = value
            End Set
        End Property
        Public Function SaveSupplierLKZNo()
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
                Str = " Select * from SupplierLKZ  where Supplierid= '" & lSupplier & "' and Customerid= '" & lCustomerID & "' "
            Else

            End If
             Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingOfSupplierCode(ByVal venderlibraryId As String) As DataTable
            Dim Str As String
            Str = " Select * from Vender  where venderlibraryId= '" & venderlibraryId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckALlLKZ(ByVal lSupplier As String, ByVal lCustomer As String) As DataTable
            Dim Str As String
            Str = "  Select * from SupplierLKZ SL"
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
        Public Function CheckContactPerson(ByVal lSupplierID As Long) As DataTable
            Dim Str As String
            Str = "  Select * from VenderPersonnel "
            Str &= "  where  venderlibraryId=" & lSupplierID
            Str &= "  order by VenderPersonnelID ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditSupplierLKZEntry(ByVal LKZid As Long)
            Dim str As String
            Try
                str = "   Select * from SupplierLKZ  "
                str &= "  where LKZid=" & LKZid

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function deletepodtl(ByVal LKZid As Long)
            Dim str As String
            Try
                str = " delete from SupplierLKZ where LKZID= '" & LKZid & "'"

                ExecuteNonQuery(str)

            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace