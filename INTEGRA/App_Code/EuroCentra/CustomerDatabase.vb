Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra

    Public Class CustomerDatabase
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Customer"
            m_strPrimaryFieldName = "CustomerID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType

        End Sub


        ''' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCustomerID As Long
        Private m_strCustomerName As String
        Private m_strAddress1 As String
        Private m_strAddress2 As String
        Private m_strContactNo As String
        Private m_strFaxNo As String
        Private m_strWebSite As String
        Private m_strCity As String
        Private m_strCountry As String
        Private m_strCommission As String
        Private m_strRemarks As String
        Private m_lCustomerTypeID As Long
        Private m_lParentGroupID As Long
        Private m_lGeographical_Territory_ID As Long
        Private m_strAliass As String
        Private m_imgOriginalLogo As String
        Private m_imgWaterMark As String
        Private m_imgBarcode As String
        Private m_bIndustryTypeRetail As Boolean
        Private m_bIndustryTypeWholesale As Boolean
        Private m_bIndustryTypeWarehouse As Boolean
        Private m_bIndustryTypeImporter As Boolean
        Private m_bIsActive As Boolean
        Private m_IndustryTypeMailOrder As Boolean
        Private m_IndustryTypeCatalog As Boolean
        '=======New Work=================='
        Private m_LocalAgent As String
        Private m_LocalContact As String
        Private m_LocalAddress As String
        Private m_IntAgent As String
        Private m_IntContact As String
        Private m_IntAddress As String
        Private m_BuyerBankName As String
        Private m_HandlingAddress As String
        Private m_SwiftCodeIBAN As String
        Private m_dExtraQty As Decimal
        Private m_BuyerReferenceNo As String
        Private m_BankAccountNo As String
        Private m_IBANNo As String
        Private m_IASSORTMENT As String
        Private m_INEGOTIATION As String
        Private m_IPAYMENTTERMS As String
        Private m_IPAYMENTREMARKS As String
        Private m_strForaccountAndRisk As String
        Private m_strNotifyparty As String
        Private m_strPaymentTo As String
        Private m_strBrandandsection As String
        Private m_strConsignee As String

        Private m_strPaymentTerm As String
        Private m_strPortOfLoading As String
        Private m_strFinalDestination As String
        Private m_dtCreationDate As Date
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property PaymentTerm() As String
            Get
                PaymentTerm = m_strPaymentTerm
            End Get
            Set(ByVal Value As String)
                m_strPaymentTerm = Value
            End Set
        End Property
        Public Property PortOfLoading() As String
            Get
                PortOfLoading = m_strPortOfLoading
            End Get
            Set(ByVal Value As String)
                m_strPortOfLoading = Value
            End Set
        End Property
        Public Property FinalDestination() As String
            Get
                FinalDestination = m_strFinalDestination
            End Get
            Set(ByVal Value As String)
                m_strFinalDestination = Value
            End Set
        End Property
        Public Property Consignee() As String
            Get
                Consignee = m_strConsignee
            End Get
            Set(ByVal Value As String)
                m_strConsignee = Value
            End Set
        End Property
        Public Property ForaccountAndRisk() As String
            Get
                ForaccountAndRisk = m_strForaccountAndRisk
            End Get
            Set(ByVal Value As String)
                m_strForaccountAndRisk = Value
            End Set
        End Property
        Public Property Notifyparty() As String
            Get
                Notifyparty = m_strNotifyparty
            End Get
            Set(ByVal Value As String)
                m_strNotifyparty = Value
            End Set
        End Property
        Public Property PaymentTo() As String
            Get
                PaymentTo = m_strPaymentTo
            End Get
            Set(ByVal Value As String)
                m_strPaymentTo = Value
            End Set
        End Property
        Public Property Brandandsection() As String
            Get
                Brandandsection = m_strBrandandsection
            End Get
            Set(ByVal Value As String)
                m_strBrandandsection = Value
            End Set
        End Property
        Public Property ASSORTMENT() As String
            Get
                ASSORTMENT = m_IASSORTMENT
            End Get
            Set(ByVal value As String)
                m_IASSORTMENT = value
            End Set
        End Property
        Public Property NEGOTIATION() As String
            Get
                NEGOTIATION = m_INEGOTIATION
            End Get
            Set(ByVal value As String)
                m_INEGOTIATION = value
            End Set
        End Property
        Public Property PAYMENTTERMS() As String
            Get
                PAYMENTTERMS = m_IPAYMENTTERMS
            End Get
            Set(ByVal value As String)
                m_IPAYMENTTERMS = value
            End Set
        End Property
        Public Property PAYMENTREMARKS() As String
            Get
                PAYMENTREMARKS = m_IPAYMENTREMARKS
            End Get
            Set(ByVal value As String)
                m_IPAYMENTREMARKS = value
            End Set
        End Property

        Public Property BankAccountNo() As String
            Get
                BankAccountNo = m_BankAccountNo
            End Get
            Set(ByVal value As String)
                m_BankAccountNo = value
            End Set
        End Property
        Public Property IBANNo() As String
            Get
                IBANNo = m_IBANNo
            End Get
            Set(ByVal value As String)
                m_IBANNo = value
            End Set
        End Property
        Public Property BuyerReferenceNo() As String
            Get
                BuyerReferenceNo = m_BuyerReferenceNo
            End Get
            Set(ByVal value As String)
                m_BuyerReferenceNo = value
            End Set
        End Property
        Public Property LocalAgent() As String
            Get
                LocalAgent = m_LocalAgent
            End Get
            Set(ByVal value As String)
                m_LocalAgent = value
            End Set
        End Property
        Public Property LocalContact() As String
            Get
                LocalContact = m_LocalContact
            End Get
            Set(ByVal value As String)
                m_LocalContact = value
            End Set
        End Property
        Public Property LocalAddress() As String
            Get
                LocalAddress = m_LocalAddress
            End Get
            Set(ByVal value As String)
                m_LocalAddress = value
            End Set
        End Property
        Public Property IntAgent() As String
            Get
                IntAgent = m_IntAgent
            End Get
            Set(ByVal value As String)
                m_IntAgent = value
            End Set
        End Property
        Public Property IntContact() As String
            Get
                IntContact = m_IntContact
            End Get
            Set(ByVal value As String)
                m_IntContact = value
            End Set
        End Property
        Public Property IntAddress() As String
            Get
                IntAddress = m_IntAddress
            End Get
            Set(ByVal value As String)
                m_IntAddress = value
            End Set
        End Property
        Public Property BuyerBankName() As String
            Get
                BuyerBankName = m_BuyerBankName
            End Get
            Set(ByVal value As String)
                m_BuyerBankName = value
            End Set
        End Property
        Public Property HandlingAddress() As String
            Get
                HandlingAddress = m_HandlingAddress
            End Get
            Set(ByVal value As String)
                m_HandlingAddress = value
            End Set
        End Property
        Public Property SwiftCodeIBAN() As String
            Get
                SwiftCodeIBAN = m_SwiftCodeIBAN
            End Get
            Set(ByVal value As String)
                m_SwiftCodeIBAN = value
            End Set
        End Property
        Public Property IndustryTypeMailOrder() As Boolean
            Get
                IndustryTypeMailOrder = m_IndustryTypeMailOrder
            End Get
            Set(ByVal value As Boolean)
                m_IndustryTypeMailOrder = value
            End Set
        End Property
        Public Property IndustryTypeCatalog() As Boolean
            Get
                IndustryTypeCatalog = m_IndustryTypeCatalog
            End Get
            Set(ByVal value As Boolean)
                m_IndustryTypeCatalog = value
            End Set
        End Property

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
        Public Property Address1() As String
            Get
                Address1 = m_strAddress1
            End Get
            Set(ByVal value As String)
                m_strAddress1 = value
            End Set
        End Property
        Public Property Address2() As String
            Get
                Address2 = m_strAddress2
            End Get
            Set(ByVal value As String)
                m_strAddress2 = value
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
        Public Property FaxNo() As String
            Get
                FaxNo = m_strFaxNo
            End Get
            Set(ByVal value As String)
                m_strFaxNo = value
            End Set
        End Property
        Public Property WebSite() As String
            Get
                WebSite = m_strWebSite
            End Get
            Set(ByVal value As String)
                m_strWebSite = value
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
        Public Property Commission() As String
            Get
                Commission = m_strCommission
            End Get
            Set(ByVal value As String)
                m_strCommission = value
            End Set
        End Property
        Public Property Remarks() As String
            Get
                Remarks = m_strRemarks
            End Get
            Set(ByVal value As String)
                m_strRemarks = value
            End Set
        End Property
       
        Public Property CustomerTypeID() As String
            Get
                CustomerTypeID = m_lCustomerTypeID
            End Get
            Set(ByVal value As String)
                m_lCustomerTypeID = value
            End Set
        End Property
        Public Property ParentGroupID() As String
            Get
                ParentGroupID = m_lParentGroupID
            End Get
            Set(ByVal value As String)
                m_lParentGroupID = value
            End Set
        End Property
        Public Property Geographical_Territory_ID() As String
            Get
                Geographical_Territory_ID = m_lGeographical_Territory_ID
            End Get
            Set(ByVal value As String)
                m_lGeographical_Territory_ID = value
            End Set
        End Property
        Public Property Aliass() As String
            Get
                Aliass = m_strAliass
            End Get
            Set(ByVal value As String)
                m_strAliass = value
            End Set
        End Property
        Public Property imgOriginalLogo() As String
            Get
                imgOriginalLogo = m_imgOriginalLogo
            End Get
            Set(ByVal value As String)
                m_imgOriginalLogo = value
            End Set
        End Property
        Public Property imgWaterMark() As String
            Get
                imgWaterMark = m_imgWaterMark
            End Get
            Set(ByVal value As String)
                m_imgWaterMark = value
            End Set
        End Property
        Public Property imgBarcode() As String
            Get
                imgBarcode = m_imgBarcode
            End Get
            Set(ByVal value As String)
                m_imgBarcode = value
            End Set
        End Property
        Public Property IndustryTypeRetail() As Boolean
            Get
                IndustryTypeRetail = m_bIndustryTypeRetail
            End Get
            Set(ByVal value As Boolean)
                m_bIndustryTypeRetail = value
            End Set
        End Property
        Public Property IndustryTypeWholesale() As Boolean
            Get
                IndustryTypeWholesale = m_bIndustryTypeWholesale
            End Get
            Set(ByVal value As Boolean)
                m_bIndustryTypeWholesale = value
            End Set
        End Property
        Public Property IndustryTypeWarehouse() As Boolean
            Get
                IndustryTypeWarehouse = m_bIndustryTypeWarehouse
            End Get
            Set(ByVal value As Boolean)
                m_bIndustryTypeWarehouse = value
            End Set
        End Property
        Public Property IndustryTypeImporter() As Boolean
            Get
                IndustryTypeImporter = m_bIndustryTypeImporter
            End Get
            Set(ByVal value As Boolean)
                m_bIndustryTypeImporter = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property
        Public Property ExtraQty() As Decimal
            Get
                ExtraQty = m_dExtraQty
            End Get
            Set(ByVal value As Decimal)
                m_dExtraQty = value
            End Set
        End Property
        Public Function SaveCustomer()
            Try
                MyBase.Save()

            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomerById(ByVal lCustomerID As Long)
            Try
                Return MyBase.GetById(lCustomerID)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerForEdit(ByVal lCustomerID As Long)
            Dim str As String
            str = "Select * from Customer C"
            str &= " left join CustomerDetail CD on CD.CustomerID =C.CustomerID"
            str &= " left join CustomerType Ct on CT.CustomerTypeID =C.CustomerTypeID"
            str &= " left join ParentGroup PG on PG.ParentGroupID =C.ParentGroupID "
            str &= " left join Geographical_Territory GT on GT.Geographical_Territory_ID =C.Geographical_Territory_ID"
            str &= " left join Contact_Type CTP on CTP.Contact_Type_ID =CD.Contact_Type_ID "
            str &= " Where C.CustomerID = '" & lCustomerID & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCustomerForEditdetail(ByVal lCustomerID As Long)
            Dim str As String
            str = " Select * from  CustomerDetail   CD  join Contact_Type CTP on CTP.Contact_Type_ID =CD.Contact_Type_ID  where CD.CustomerID = '" & lCustomerID & "' "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getCountryID(ByVal CountryName As String)
            Dim str As String
            str = "Select * from Countries where CountryName= '" & CountryName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getCityID(ByVal city As String)
            Dim str As String
            str = "Select * from cities where city= '" & city & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCreationDate(ByVal CustomerID As Long) As Date
            Dim Str As String
            Str = " Select CreationDate  From  Customer where CustomerID=" & CustomerID

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCreationDateSupplier(ByVal SupplierDatabaseId As Long) As Date
            Dim Str As String
            Str = " Select CreationDate  From  SupplierDatabase where SupplierDatabaseId=" & SupplierDatabaseId

            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function CheckCostingExist(ByVal lCustomerID As Long)
            Dim Str As String
            Str = " select * from Costing where CustomerID=" & lCustomerID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAllCountries()
            Dim str As String
            str = "Select * from Countries"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetAllTown()
            Dim str As String
            str = "Select * from Town"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCustomerType()
            Dim str As String
            str = "Select * from CustomerType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetParentGroup()
            Dim str As String
            str = "Select * from ParentGroup"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetGeographicatTerritory()
            Dim str As String
            str = "Select * from Geographical_Territory"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetCities(ByVal CountryId As Long)
            Dim str As String
            str = "select ct.Country_id,ct.id,ct.city   from Countries c join cities ct on  ct.Country_id =c.Country_id  where ct.Country_id='" & CountryId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetContactType()
            Dim str As String
            str = "Select * from Contact_Type"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function CheckCustomerAlreadyExist(ByVal CustomerName As String)
            Dim Str As String
            Str = "Select * from Customer where CustomerName= '" & CustomerName & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function CheckCustomerTemp()
            Dim Str As String
            Str = "Select * from Customer "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgOriginalLogo(ByVal lCustomerID As Long)
            Dim str As String
            str = "Select imgOriginalLogo from Customer where CustomerID=" & lCustomerID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgWaterMark(ByVal lCustomerID As Long)
            Dim str As String
            str = "Select imgWaterMark from Customer where CustomerID=" & lCustomerID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgBarcode(ByVal lCustomerID As Long)
            Dim str As String
            str = "Select imgBarcode from Customer where CustomerID=" & lCustomerID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetCom(ByVal lCustomerID As Long)
            Dim str As String
            str = "Select * from Customer where CustomerID=" & lCustomerID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace