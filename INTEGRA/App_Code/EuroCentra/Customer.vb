Imports System.Data

Namespace EuroCentra

    Public Class Customer

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Customer"
            m_strPrimaryFieldName = "CustomerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCustomerID As Long
        Private m_strCustomerName As String
        Private m_strAddress As String
        Private m_strContactNo As String
        Private m_strGstNo As String
        Private m_strFaxNo As String
        Private m_strEmail As String
        Private m_strWebsite As String
        Private m_strContactPerson As String
        Private m_strNTNNumber As String
        Private m_strCity As String
        Private m_strCountry As String
        Private m_strState As String
        Private m_dbCommission As Decimal
        Private m_IImage As Image

        '----------------Properties
        Public Property CustomerID() As Long
            Get
                CustomerID = m_lCustomerID
            End Get
            Set(ByVal Value As Long)
                m_lCustomerID = Value
            End Set
        End Property
        Public Property CustomerName() As String
            Get
                CustomerName = m_strCustomerName
            End Get
            Set(ByVal value As String)
                m_strCustomerName = value
            End Set
        End Property
        Public Property Address() As String
            Get
                Address = m_strAddress
            End Get
            Set(ByVal value As String)
                m_strAddress = value
            End Set
        End Property
        Public Property ContactNo() As String
            Get
                ContactNo = m_strContactNo
            End Get
            Set(ByVal value As String)
                m_strContactNo = value
            End Set
        End Property
        Public Property GstNo() As String
            Get
                GstNo = m_strGstNo
            End Get
            Set(ByVal value As String)
                m_strGstNo = value
            End Set
        End Property
        Public Property FaxNo() As String
            Get
                FaxNo = m_strFaxNo
            End Get
            Set(ByVal value As String)
                m_strFaxNo = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Email = m_strEmail
            End Get
            Set(ByVal value As String)
                m_strEmail = value
            End Set
        End Property
        Public Property Website() As String
            Get
                Website = m_strWebsite
            End Get
            Set(ByVal value As String)
                m_strWebsite = value
            End Set
        End Property
        Public Property ContactPerson() As String
            Get
                ContactPerson = m_strContactPerson
            End Get
            Set(ByVal value As String)
                m_strContactPerson = value
            End Set
        End Property
        Public Property NTNNumber() As String
            Get
                NTNNumber = m_strNTNNumber
            End Get
            Set(ByVal value As String)
                m_strNTNNumber = value
            End Set
        End Property
        Public Property City() As String
            Get
                City = m_strCity
            End Get
            Set(ByVal value As String)
                m_strCity = value
            End Set
        End Property
        Public Property Country() As String
            Get
                Country = m_strCountry
            End Get
            Set(ByVal value As String)
                m_strCountry = value
            End Set
        End Property
        Public Property State() As String
            Get
                State = m_strState
            End Get
            Set(ByVal value As String)
                m_strState = value
            End Set
        End Property
        Public Property Commission() As Decimal
            Get
                Commission = m_dbCommission
            End Get
            Set(ByVal value As Decimal)
                m_dbCommission = value
            End Set
        End Property
        Public Property Image() As Image
            Get
                Image = m_IImage
            End Get
            Set(ByVal value As Image)
                m_IImage = value
            End Set
        End Property
        Public Function SaveCustomer()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerById(ByVal lCustomerId As Long)
            Try
                Return MyBase.GetById(lCustomerId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerView() As DataTable
            Dim str As String
            str = "select * from Customer C"
            str &= " join ParentGroup PG on PG.ParentGroupID =C.ParentGroupID "
            str &= " join Geographical_Territory GT on GT.Geographical_Territory_ID =C.Geographical_Territory_ID"
            str &= " order by Customername ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerByEdit(ByVal CustomerID As Integer) As DataTable
            Dim str As String
            str = "select * from Customer where CustomerID=" & CustomerID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindCombo() As DataTable
            Dim str As String
            str = "select CustomerID,CustomerName,Aliass as CustomerFullNAME from Customer where isactive='1' order by CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonReport() As DataTable
            Dim str As String
            str = "select * from Season "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetErrorCodes() As DataTable
            Dim str As String
            str = "select * from ErrorCodes "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrentStatus() As DataTable
            Dim str As String
            str = "select * from CurrentStatus "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDept(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = "select distinct Eknumber from Purchaseorder PO "
            str &= " join Vender V on V.VenderlibraryID=PO.Supplierid"
            str &= " where PO.CustomerID=" & CustomerID
            str &= " and Year(Po.shipmentDate) >=2012"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplier(ByVal CustomerID As Long, ByVal Eknumber As String) As DataTable
            Dim str As String
            str = "select distinct Po.SupplierID,V.Vendername from Purchaseorder PO "
            str &= " join Vender V on V.VenderlibraryID=PO.Supplierid"
            str &= " where PO.CustomerID=" & CustomerID
            str &= " and PO.Eknumber='" & Eknumber & "'"
            str &= " and Year(Po.shipmentDate) >=2012"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeason(ByVal CustomerID As Long, ByVal Eknumber As String, ByVal Supplierid As Long) As DataTable
            Dim str As String
            str = "select distinct Season from Purchaseorder PO "
            str &= " join Vender V on V.VenderlibraryID=PO.Supplierid"
            str &= " where PO.CustomerID=" & CustomerID
            str &= " and PO.Supplierid=" & Supplierid
            str &= " and PO.Eknumber='" & Eknumber & "'"
            str &= " and Year(Po.shipmentDate) >=2012"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPONO(ByVal CustomerID As Long, ByVal Eknumber As String, ByVal Supplierid As Long, ByVal Season As String) As DataTable
            Dim str As String
            str = "select * from Purchaseorder PO "
            str &= " join Vender V on V.VenderlibraryID=PO.Supplierid"
            str &= " where PO.CustomerID=" & CustomerID
            str &= " and PO.Supplierid=" & Supplierid
            str &= " and PO.Eknumber='" & Eknumber & "'"
            str &= " and PO.Season='" & Season & "'"
            str &= " and Year(Po.shipmentDate) >=2012"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBindComboXL() As DataTable
            Dim str As String
            str = " select distinct C.CustomerID,C.CustomerName from Customer C"
            str &= " join PUrchaseorder PO on PO.CustomerID=C.CustomerID"
            str &= "  where   Year(PO.CreationDate)=2012 order by C.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOCustomer() As DataTable
            Dim str As String
            '' str = "Select Distinct C.CustomerID,CustomerName From PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID"
            str = "Select Distinct C.CustomerID,C.CustomerName From Customer C order by C.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCommission(ByVal CustomerID As Long) As Decimal
            Dim str As String
            str = "select Commission from Customer where CustomerID=" & CustomerID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomer(ByVal PONo As Long, ByVal UserID As Long, ByVal RoleID As Long) As DataTable
            Dim str As String
            'str = "Select CustomerID as ID,CustomerName as Name ,Status='False' from Customer"
            'str &= " where CustomerID Not in(Select C.CustomerID from PurchaseOrder PO  Join"
            'str &= " Customer C  On Po.CustomerID=c.CustomerID where PoID='" & PONo & "')"
            'str &= " Union"
            'str &= " Select C.CustomerID as ID,C.CustomerName as Name,"
            'str &= " (case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
            'str &= " from PurchaseOrder PO right Join"
            'str &= " Customer C  On Po.CustomerID=c.CustomerID "
            'str &= " where PoID = '" & PONo & "'"
            'str &= " Group By C.CustomerID,C.CustomerName,PONo"
            'Try
            '    Return MyBase.GetDataTable(str)
            'Catch ex As Exception
            'End Try

            If RoleID = 1 Or RoleID = 4 Then
                str = "Select CustomerID as ID,CustomerName as Name ,Status='False' from Customer"
                str &= " where CustomerID Not in(Select C.CustomerID from PurchaseOrder PO  Join"
                str &= " Customer C  On Po.CustomerID=c.CustomerID where PoID='" & PONo & "')"
                str &= " Union"
                str &= " Select C.CustomerID as ID,C.CustomerName as Name,"
                str &= " (case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
                str &= " from PurchaseOrder PO right Join"
                str &= " Customer C  On Po.CustomerID=c.CustomerID "
                str &= " where PoID = '" & PONo & "'"
                str &= " Group By C.CustomerID,C.CustomerName,PONo order by Name asc"
                Try
                    Return MyBase.GetDataTable(str)
                Catch ex As Exception
                End Try
            ElseIf RoleID = 0 Or RoleID = 0 Then

            Else
                'str = "Select CC.CustomerID as ID,CustomerName as Name ,Status='False' from Customer CC"
                'str &= " Join CustomerRole CR On CR.CustomerId = CC.CustomerId where CC.CustomerID Not"
                'str &= " in(Select C.CustomerID from PurchaseOrder PO  Join Customer C On "
                'str &= " Po.CustomerID=c.CustomerID where PoID='" & PONo & "') and CR.UserId = '" & UserID & "' and CR.Roleid = '" & RoleID & "'"
                'str &= " Union Select C.CustomerID as ID,C.CustomerName as Name,(case ISNull(PONo,'')"
                'str &= " when '' then 'False' else 'True' end )as Status from PurchaseOrder PO right"
                'str &= " Join Customer C Join CustomerRole CR On CR.CustomerId = C.CustomerId  "
                'str &= " On Po.CustomerID=c.CustomerID where PoID = '" & PONo & "' and UserId = '" & UserID & "' and Roleid = '" & RoleID & "'"
                'str &= " Group By C.CustomerID,C.CustomerName,PONo order by Name asc"
                str = "Select CustomerID as ID,CustomerName as Name ,Status='False' from Customer"
                str &= " where CustomerID Not in(Select C.CustomerID from PurchaseOrder PO  Join"
                str &= " Customer C  On Po.CustomerID=c.CustomerID where PoID='" & PONo & "')"
                str &= " Union"
                str &= " Select C.CustomerID as ID,C.CustomerName as Name,"
                str &= " (case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
                str &= " from PurchaseOrder PO right Join"
                str &= " Customer C  On Po.CustomerID=c.CustomerID "
                str &= " where PoID = '" & PONo & "'"
                str &= " Group By C.CustomerID,C.CustomerName,PONo order by Name asc"
                Try
                    Return MyBase.GetDataTable(str)
                Catch ex As Exception
                End Try

            End If


        End Function
        Function getCustomerForPO()
            Dim Str As String
            Str = "Select Distinct C.CustomerID,C.CustomerName from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID order by C.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getCustomerForPONew(ByVal UserID As Long, ByVal RoleID As Long)
            Dim Str As String
            If RoleID = 1 Or RoleID = 4 Then
                Str = " Select Distinct C.CustomerID,C.CustomerName from PurchaseOrder PO Join Customer C on PO.CustomerID=C.CustomerID "
                Str &= " where  Year(PO.CreationDate)>= '2012'"
                Str &= "  order by C.CustomerName ASC "
            Else
                If UserID = 68 Or UserID = 69 Or UserID = 70 Or UserID = 71 Then
                    Str = " Select Distinct C.CustomerID,C.CustomerName from PurchaseOrder PO"
                    Str &= " Join Customer C on PO.CustomerID=C.CustomerID "
                    Str &= " Join Umuser U on PO.marchandid=U.Userid"
                    Str &= "  where  U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') "
                    Str &= "  and Year(PO.CreationDate)>= '2012'"
                    Str &= " order by C.CustomerName ASC"

                Else
                    Str = " Select Distinct C.CustomerID,C.CustomerName from PurchaseOrder PO"
                    Str &= " Join Customer C on PO.CustomerID=C.CustomerID "
                    Str &= " where PO.marchandid = '" & UserID & "' "
                    Str &= "  and Year(PO.CreationDate)>= '2012'"
                    Str &= " order by C.CustomerName ASC"
                End If

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function GetlastRecord()
            Dim str As String
            str = "SELECT TOP 1 CustomerID FROM Customer ORDER BY CustomerID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerIDByName(ByVal CustomerName As String)
            Dim str As String
            str = "SELECT CustomerID,Commission FROM Customer where CustomerName='" & CustomerName & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomer()
            Dim Str As String
            Str = " select CustomerID,CustomerName from Customer "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerwithEK(ByVal UserID As String)
            Dim Str As String
            Str = " select Distinct  C.CustomerID,Upper (C.CustomerName) + '  ' + Po.EkNumber as CustomerNamewithEK from  Purchaseorder PO"
            Str &= " join Customer C On C.CustomerID=Po.CustomerID  where marchandID='" & UserID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerwithBuyer(ByVal UserID As String)
            Dim Str As String
            'Str = "  select Distinct  C.CustomerID,Upper (C.CustomerName) as CustomerName from  Purchaseorder PO"
            'Str &= "  join Customer C On C.CustomerID=Po.CustomerID  where marchandID='" & UserID & "'"

            Str = " select * from Customer C join Customerrole CR on C.CustomerID=CR.CustomerID where CR.userID='" & UserID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerwithBuyerF(ByVal UserID As String, ByVal RoleID As String)
            Dim Str As String
            'If RoleID = 1 Or RoleID = 4 Then
            '    Str = " select * from Customer C " 
            'Else
            '    Str = " select * from Customer C join Customerrole CR on C.CustomerID=CR.CustomerID where CR.userID='" & UserID & "'"

            'End If
            Str = " select * from Customer C "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetAllCustomerForTurnover()
            Dim Str As String
            Str = "select Distinct C.CustomerId,C.CustomerName  from Purchaseorder Po"
            Str &= "  Join Customer C on PO.CustomerId=C.CustomerId    "
            Str &= "  where(Year(PO.creationdate) >= 2012)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPOCustomerForClaim() As DataTable
            Dim str As String
            str = "Select Distinct C.CustomerID,C.CustomerName From Customer C  where IsActive =1 order by C.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOCustomerForClaimNew() As DataTable
            Dim str As String
            ' str = "Select Distinct C.CustomerID,C.CustomerName From Customer C  where IsActive =1 order by C.CustomerName ASC"
            str = "  Select Distinct C.CustomerId,C.CustomerName  from Purchaseorder Po"
            str &= " join CargoDetail Cd on Po.POID=Cd.POPOID "
            str &= " Join Customer C on PO.CustomerId=C.CustomerId     "
            str &= "  where Year(PO.Shipmentdate) >= 2012 order by C.CustomerName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOCustomerForCuttingStatus() As DataTable
            Dim str As String
            str = " Select Distinct C.CustomerID,C.CustomerName From Customer C  where IsActive =1 "
            str &= " and  C.CustomerID in (13,19)"
            str &= " order by C.CustomerName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOCustomerForSMC() As DataTable
            Dim str As String
            str = " Select Distinct C.CustomerID,C.CustomerName From Customer C"
            str &= " join  Purchaseorder Po on  PO.CustomerId=C.CustomerId where C.IsActive =1  and Year(Po.ShipmentDate)>=2013 "
            str &= " order by C.CustomerName ASC "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingDept(ByVal customerid As Long) As DataTable
            Dim str As String
            If customerid > 0 Then
                str = "SELECT distinct DepartmentNo as BuyingDept from   customerDetail where customerid=" & customerid
            Else
                str = "SELECT distinct DepartmentNo as BuyingDept from   customerDetail "
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetBuyerInfoNo(ByVal customerid As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid='" & customerid & "' and DepartmentNo='" & BuyingDept & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class

End Namespace

