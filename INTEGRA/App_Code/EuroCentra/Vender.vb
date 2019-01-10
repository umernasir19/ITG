Imports System.Data
Imports System.Security.Cryptography
Namespace EuroCentra
    Public Class Vender
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Vender"
            m_strPrimaryFieldName = "VenderLibraryID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lVenderLibraryID As Long
        Private m_strVenderCode As String
        Private m_strSupplierStatus As String
        Private m_strVenderName As String
        Private m_strAddress1 As String
        Private m_strAddress2 As String
        Private m_strZipCode As String
        Private m_lCity As Long
        Private m_strFaxNo As String
        Private m_strPhoneNumber As String
        Private m_bIsActive As Boolean
        Private m_strLongitudeandLatitude As String
        Private m_strShortName As String
        Private m_strimgOriginalLogo As String
        Private m_strimgWaterMark As String
        Private m_strVAF As String
        Private m_strWebsite As String
        Private m_strCountryID As Long
        Private m_strVAFuploadDate As String
        Private m_strSupplierCategoryID As Long
        Private m_YearStarted As String
        Private m_dcMinQty As Decimal
        Private m_strLeadTime As String
        Private m_strTOOneYear As String
        Private m_strTOTwoYear As String
        Private m_strTOThreeYear As String
        Private m_strBankName As String
        Private m_strBankCode As String
        Private m_strBankAddress As String
        Private m_strBankFax As String
        Private m_strBankACNo As String
        Private m_strBankSwiftCode As String
        Private m_strRemarks As String
        Private m_strVAFName As String
        Private m_VAFUpload As Object
        Private m_strLastUpdatedBy As String
        Private m_strLastUpdatedOn As String
        Private m_strTown As String
        Const passphrase As String = "thisisaspecialkeyusedtohashyourcontent_changemeandmakemeunique"
        Public Property LastUpdatedBy() As String
            Get
                LastUpdatedBy = m_strLastUpdatedBy
            End Get
            Set(ByVal value As String)
                m_strLastUpdatedBy = value
            End Set
        End Property
        Public Property LastUpdatedOn() As String
            Get
                LastUpdatedOn = m_strLastUpdatedOn
            End Get
            Set(ByVal value As String)
                m_strLastUpdatedOn = value
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
        Public Property VAFName() As String
            Get
                VAFName = m_strVAFName
            End Get
            Set(ByVal value As String)
                m_strVAFName = value
            End Set
        End Property
        Public Property VAFUpload() As Object
            Get
                VAFUpload = m_VAFUpload
            End Get
            Set(ByVal value As Object)
                m_VAFUpload = value
            End Set
        End Property

        Public Property BankSwiftCode() As String
            Get
                BankSwiftCode = m_strBankSwiftCode
            End Get
            Set(ByVal value As String)
                m_strBankSwiftCode = value
            End Set
        End Property
        Public Property BankACNo() As String
            Get
                BankACNo = m_strBankACNo
            End Get
            Set(ByVal value As String)
                m_strBankACNo = value
            End Set
        End Property
        Public Property BankFax() As String
            Get
                BankFax = m_strBankFax
            End Get
            Set(ByVal value As String)
                m_strBankFax = value
            End Set
        End Property
        Public Property BankAddress() As String
            Get
                BankAddress = m_strBankAddress
            End Get
            Set(ByVal value As String)
                m_strBankAddress = value
            End Set
        End Property
        Public Property BankCode() As String
            Get
                BankCode = m_strBankCode
            End Get
            Set(ByVal value As String)
                m_strBankCode = value
            End Set
        End Property
        Public Property BankName() As String
            Get
                BankName = m_strBankName
            End Get
            Set(ByVal value As String)
                m_strBankName = value
            End Set
        End Property
        Public Property YearStarted() As String
            Get
                YearStarted = m_YearStarted
            End Get
            Set(ByVal value As String)
                m_YearStarted = value
            End Set
        End Property
        Public Property MinQty() As Decimal
            Get
                MinQty = m_dcMinQty
            End Get
            Set(ByVal value As Decimal)
                m_dcMinQty = value
            End Set
        End Property
        Public Property LeadTime() As String
            Get
                LeadTime = m_strLeadTime
            End Get
            Set(ByVal value As String)
                m_strLeadTime = value
            End Set
        End Property
        Public Property TOOneYear() As String
            Get
                TOOneYear = m_strTOOneYear
            End Get
            Set(ByVal value As String)
                m_strTOOneYear = value
            End Set
        End Property
        Public Property TOTwoYear() As String
            Get
                TOTwoYear = m_strTOTwoYear
            End Get
            Set(ByVal value As String)
                m_strTOTwoYear = value
            End Set
        End Property
        Public Property TOThreeYear() As String
            Get
                TOThreeYear = m_strTOThreeYear
            End Get
            Set(ByVal value As String)
                m_strTOThreeYear = value
            End Set
        End Property
        Public Property SupplierCategoryID() As Long
            Get
                SupplierCategoryID = m_strSupplierCategoryID
            End Get
            Set(ByVal value As Long)
                m_strSupplierCategoryID = value
            End Set
        End Property
        Public Property VenderLibraryID() As Long
            Get
                VenderLibraryID = m_lVenderLibraryID
            End Get
            Set(ByVal Value As Long)
                m_lVenderLibraryID = Value
            End Set
        End Property
        Public Property VAFuploadDate() As String
            Get
                VAFuploadDate = m_strVAFuploadDate
            End Get
            Set(ByVal value As String)
                m_strVAFuploadDate = value
            End Set
        End Property
        Public Property SupplierStatus() As String
            Get
                SupplierStatus = m_strSupplierStatus
            End Get
            Set(ByVal value As String)
                m_strSupplierStatus = value
            End Set
        End Property
        Public Property VenderCode() As String
            Get
                VenderCode = m_strVenderCode
            End Get
            Set(ByVal value As String)
                m_strVenderCode = value
            End Set
        End Property
        Public Property VenderName() As String
            Get
                VenderName = m_strVenderName
            End Get
            Set(ByVal value As String)
                m_strVenderName = value
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
        Public Property City() As Long
            Get
                City = m_lCity
            End Get
            Set(ByVal value As Long)
                m_lCity = value
            End Set
        End Property
        Public Property ZipCode() As String
            Get
                ZipCode = m_strZipCode
            End Get
            Set(ByVal value As String)
                m_strZipCode = value
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
        Public Property PhoneNumber() As String
            Get
                PhoneNumber = m_strPhoneNumber
            End Get
            Set(ByVal value As String)
                m_strPhoneNumber = value
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
        Public Property ShortName() As String
            Get
                ShortName = m_strShortName
            End Get
            Set(ByVal value As String)
                m_strShortName = value
            End Set
        End Property
        Public Property imgOriginalLogo() As String
            Get
                imgOriginalLogo = m_strimgOriginalLogo
            End Get
            Set(ByVal value As String)
                m_strimgOriginalLogo = value
            End Set
        End Property
        Public Property imgWaterMark() As String
            Get
                imgWaterMark = m_strimgWaterMark
            End Get
            Set(ByVal value As String)
                m_strimgWaterMark = value
            End Set
        End Property
        Public Property VAF() As String
            Get
                VAF = m_strVAF
            End Get
            Set(ByVal value As String)
                m_strVAF = value
            End Set
        End Property
        Public Property LongitudeandLatitude() As String
            Get
                LongitudeandLatitude = m_strLongitudeandLatitude
            End Get
            Set(ByVal value As String)
                m_strLongitudeandLatitude = value
            End Set
        End Property
        Public Property CountryID() As Long
            Get
                CountryID = m_strCountryID
            End Get
            Set(ByVal Value As Long)
                m_strCountryID = Value
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
        Public Property Town() As String
            Get
                Town = m_strTown
            End Get
            Set(ByVal value As String)
                m_strTown = value
            End Set
        End Property
        Public Function SaveVender()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCurrentId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderById(ByVal lVenderId As Long)
            Try
                Return MyBase.GetById(lVenderId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetobjVenderView(Optional ByVal Alfa As String = "", Optional ByVal City As String = "", Optional ByVal BusinessDomain As String = "", Optional ByVal VerticalIntegration As String = "", Optional ByVal Status As String = "", Optional ByVal Certificate As String = "") As DataTable
            Dim str As String
            str = " Select V.VenderLibraryID,SupplierStatus,venderName ,c.City, "
            str &= " ISNull((Select (Case when(Select SocialCompliance+SupplyChain+BusinessDevelopment+Merchant+QAGroup/5 from VenderGradingScale where VenderID=V.VenderLibraryID) >=8 then 'Excellent' when (Select SocialCompliance+SupplyChain+BusinessDevelopment+Merchant+QAGroup/5 from VenderGradingScale where VenderID=V.VenderLibraryID) Between 5 and  8 then 'Good' when (Select SocialCompliance+SupplyChain+BusinessDevelopment+Merchant+QAGroup/5 from VenderGradingScale where VenderID=V.VenderLibraryID) Between 3 and 5 then  'Fair' when (Select SocialCompliance+SupplyChain+BusinessDevelopment+Merchant+QAGroup/5 from VenderGradingScale where VenderID=V.VenderLibraryID) <3 then 'Poor' end )),'') as GPA"
            str &= " from Vender V Join Cities C On C.ID=V.City"
            str &= " Join VenderDetail VD  on VD.VenderID=V.VenderLibraryID"
            str &= " Left Join VenderVerticalIntegration VVI on VVI.VVIID=VD.ID"
            str &= " Join VenderCertificate VC on V.VenderLibraryID=VC.VenderID"
            str &= " where  V.VenderLibraryID Not in(0)"
            If Not City = "ALL" Then
                str &= " And C.ID='" & City & "'"
            End If
            If Not BusinessDomain = "ALL" And VerticalIntegration = "ALL" Then
                str &= " And VVI.VVIID =" & BusinessDomain & " "
            End If
            If Not VerticalIntegration = "ALL" And BusinessDomain = "ALL" Then
                str &= " And VVI.VVIID =" & VerticalIntegration & " "
            End If
            If Not BusinessDomain = "ALL" And Not VerticalIntegration = "ALL" Then
                str &= " And VVI.VVIID in(" & BusinessDomain & "," & VerticalIntegration & ")"
            End If
            If Not Status = "ALL" Then
                str &= " And  SupplierStatus='" & Status & "'"
            End If
            If Not Certificate = "ALL" Then
                str &= " And VC.CertificateID='" & Certificate & "' "
            End If

            If Not Alfa = "ALL" Then
                Select Case Alfa
                    Case "ABC"
                        str &= " And venderName like'[A-C]%'"
                    Case "DEF"
                        str &= " And venderName like'[D-F]%'"
                    Case "GHI"
                        str &= " And venderName like'[G-I]%'"
                    Case "JKL"
                        str &= " And venderName like'[K-L]%'"
                    Case "MNO"
                        str &= " And venderName like'[M-O]%'"
                    Case "PQR"
                        str &= " And venderName like'[P-R]%'"
                    Case "STU"
                        str &= " And venderName like'[S-U]%'"
                    Case "VWX"
                        str &= " And venderName like'[V-X]%'"
                    Case "YZ"
                        str &= " And venderName like'[Y-Z]%'"
                End Select
            End If
            str &= " Group by V.VenderLibraryID,SupplierStatus,venderName ,c.City"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getData(ByVal VenderID As Integer) As DataTable
            Dim str As String
            str = "select * from Vender where VenderLibraryID=" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataforBindCombo() As DataTable
            Dim str As String
            str = "select VenderLibraryID,VenderName from Vender where Isactive='1' order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataforBindComboNew(ByVal CustomerId As Long) As DataTable
            Dim str As String
            str = "select VenderLibraryID,VenderName from Vender where Isactive='1' order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getSupplierFoRENQ() As DataTable
            Dim str As String
            str = "select DISTINCT VenderLibraryID,VenderName from Vender V JOIN EnquiriesSystemAdd EV ON EV.sUPPLIERID=V.VenderLibraryID"
            str &= " where Isactive='1' order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataforBindCombo1() As DataTable
            Dim str As String
            str = " select VenderLibraryID,VenderName from Vender "
            str &= " where VenderLibraryID not in (Select distinct SupplierID from VAF_BasicInformation)"
            str &= " order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataforBindCombo11() As DataTable
            Dim str As String
            str = " select VenderLibraryID,VenderName from Vender "
            str &= " order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getcmbBusiness() As DataTable
            Dim str As String
            str = "select * from V_Business "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_Product() As DataTable
            Dim str As String
            str = "select * from V_Product "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_PD() As DataTable
            Dim str As String
            str = "select * from V_PD "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_PreTreatment() As DataTable
            Dim str As String
            str = "select * from V_PreTreatment "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_Dyeing() As DataTable
            Dim str As String
            str = "select * from V_Dyeing "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_Department() As DataTable
            Dim str As String
            str = "select * from V_Department "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_Capabilities() As DataTable
            Dim str As String
            str = "select * from V_Capabilities "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getV_Machine() As DataTable
            Dim str As String
            str = "select * from V_Machine "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getDataforBindComboXL() As DataTable
            Dim str As String
            str = " select distinct v.VenderLibraryID,v.VenderName from Vender V"
            str &= " join PUrchaseorder PO on PO.SupplierID=V.venderlibraryID"
            str &= " where v.SupplierStatus='Active'"
            str &= " and  Year(PO.CreationDate)=2012 "
            str &= " order by v.VenderName ASC"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOVenders(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = "Select Distinct V.venderLibraryID,VenderName From PurchaseOrder PO Join Vender V on PO.SupplierID=V.VenderLibraryID Where year(creationdate)>=2012  and CustomerID=" & CustomerID & "  order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getVendorByPO(Optional ByVal PoNo As Long = 0) As DataTable
            Dim str As String
            str = "Select VenderLibraryID as ID,VenderName as Name,Status='False' from Vender"
            str &= " where VenderLibraryID Not in(Select SupplierID from PurchaseOrder PO Join Vender V On PO.SupplierID=V.VenderLibraryID where PoID='" & PoNo & "')"
            str &= " Union"
            str &= " Select  VenderLibraryID as ID,VenderName as Name,(case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
            str &= " from PurchaseOrder PO Join Vender V On PO.SupplierID=V.VenderLibraryID where PoID='" & PoNo & "' order by Name asc"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCity() As DataTable
            Dim str As String
            str = "SELECT ID,City FROM cities Where Country=378"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAddress(ByVal VenderID As Long, ByVal Type As String) As String
            Dim str As String
            If Type = "Location" Then
                str = "Select VenderAddress+(Case when ISnull(Street,'')='' then',' else ','+Street+',' end)+Town+','+C.City From Vender V Join Cities C on C.ID=V.City where VenderLibraryID=" & VenderID
            Else
                str = "Select Town+','+C.City From Vender V Join Cities C on C.ID=V.City where VenderLibraryID=" & VenderID

            End If

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetLongitudeandLatitude(ByVal VenderID As Long) As String
            Dim str As String

            str = "Select LongitudeandLatitude  From Vender where VenderLibraryID=" & VenderID

            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetReport(ByVal ID As Long)
            Dim Str As String

            Str = "select Dt.Name as DeliveryTypeName,PM.Name as PaymentModeName, PT.name as PaymentTypeName,SM.name as ShipmentModeName,"
            Str &= " PO.*,POD.*,S.*,C.*,V.* from PurchaseOrder PO Join PurchaseOrderDetail POD"
            Str &= " On PO.POID = POD.POID Join Style S On POD.StyleID = S.StyleID "
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID Join customer c "
            Str &= " on C.CustomerID=PO.CustomerID"
            Str &= " Join PORelatedFields DT on PO.DeliveryType = DT.ID"
            Str &= " Join PORelatedFields PM on PO.PaymentMode =  PM.ID"
            Str &= " Join PORelatedFields PT on PO.PaymentType =  PT.ID"
            Str &= " Join PORelatedFields SM on PO.ShipmentMode =  SM.ID"
            Str &= " where PO.POID=26" '" & ID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetSearchGrid()
            Dim str As String
            str = "Select Alfa='ALL',City='ALL',BusinessDomain='ALL',Status='ALL',Certificate='ALL'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getVenderNameByID(ByVal VenderID As Long) As String
            Dim str As String
            str = "Select VenderName from Vender Where VenderLibraryID=" & VenderID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function VenderEdit(ByVal VenderID As Long)
            Dim str As String

            str = " Select * from Vender V"
            str &= " left Join Cities C On C.ID=V.City"
            str &= " left Join Countries CO On Co.Country_id=V.Countryid"
            str &= " left Join VenderDetail VD  on VD.VenderID=V.VenderLibraryID"
            str &= " left Join VenderVerticalIntegration VVI on VVI.VVIID=VD.ID"
            str &= " left join VenderGradingScale VGS on VGS.VenderID=V.VenderLibraryID"
            str &= " left join VenderPersonnel vp on vp.VenderLibraryID=V.VenderLibraryID"
            str &= "   where V.VenderLibraryID =" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function VenderDemographicsEdit(ByVal VenderID As Long)
            Dim str As String

            str = " Select *  from VenderDemographics V join  Vender VD on VD.VenderLibraryID=V.VenderLibraryID "
            str &= " Join Town T On T.TownID=V.TownID"
            str &= "   where V.VenderLibraryID =" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function VenderProductGroupEdit(ByVal VenderID As Long)
            Dim str As String
            str = "  Select *"
            str &= " from Vender V"
            str &= " Join VenderDetail VD  on VD.VenderID=V.VenderLibraryID"
            str &= " Join VenderVerticalIntegration VVI on VVI.VVIID=VD.ID"
            str &= "   where vvi.Type='Product Group' and V.VenderLibraryID =" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function VenderVerticalIntegrationEdit(ByVal VenderID As Long)
            Dim str As String
            str = "  Select *"
            str &= " from Vender V"
            str &= " Join VenderDetail VD  on VD.VenderID=V.VenderLibraryID"
            str &= " Join VenderVerticalIntegration VVI on VVI.VVIID=VD.ID"
            str &= "   where vvi.Type='Vertical Integration' and V.VenderLibraryID =" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function VenderPersonelEdit(ByVal VenderID As Long)
            Dim str As String
            str = "  Select *"
            str &= " from Vender V"
            str &= " join VenderPersonnel vp on vp.VenderLibraryID=V.VenderLibraryID"
            str &= "   where V.VenderLibraryID =" & VenderID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateVenderStatus(ByVal VenderID As Long)
            Dim str As String

            str = "Select POID From PurchaseOrder where SupplierID='" & VenderID & "' and Status='Confirmed'"

            Try
                If Not MyBase.GetDataTable(str).Rows.Count > 0 Then
                    MyBase.ExecuteNonQuery("Update Vender set SupplierStatus='Not Active' where venderLibraryID='" & VenderID & "'")
                End If

                'Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function ActiveSupplier(ByVal VenderID As Long)
            Dim str As String
            str = "Update Vender set SupplierStatus='Active' where venderLibraryID='" & VenderID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function getVenderForPO()
            Dim Str As String
            Str = "Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO Join Vender V on PO.SupplierID=V.venderLibraryID where V.SupplierStatus='Active' order by V.VenderName ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getVenderForPONew(ByVal UserID As Long, ByVal RoleID As Long)
            Dim Str As String
            If RoleID = 1 Or RoleID = 4 Then
                Str = "Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO Join Vender V on PO.SupplierID=V.venderLibraryID where V.SupplierStatus='Active' "
                Str &= " and Year(PO.CreationDate)>= '2012'"
                Str &= " order by V.VenderName ASC"
            Else
                If UserID = 68 Or UserID = 69 Or UserID = 70 Or UserID = 71 Then
                    Str = " Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO"
                    Str &= " Join Vender V on PO.SupplierID=V.venderLibraryID"
                    Str &= " Join Umuser U on PO.marchandid=U.Userid"
                    Str &= " where V.SupplierStatus='Active' "
                    Str &= " and  U.ECPDivistion in(Select ECPDivistion From UMUser where UserID='" & UserID & "') "
                    Str &= " and Year(PO.CreationDate)>= '2012'"
                    Str &= " order by V.VenderName ASC"

                Else
                    Str = " Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO"
                    Str &= " Join Vender V on PO.SupplierID=V.venderLibraryID"
                    Str &= " where V.SupplierStatus='Active' and PO.marchandid= '" & UserID & "' "
                    Str &= " and Year(PO.CreationDate)>= '2012'"
                    Str &= " order by V.VenderName ASC"
                End If
            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GetVenderIDnyName(ByVal VenderName As String)
            Dim Str As String
            Str = "select VenderLibraryID from Vender where VenderName='" & VenderName & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getVenderForPOPupop(ByVal UserID As String)
            Dim Str As String
            Str = "Select Distinct V.VenderLibraryID,Upper (V.VenderName) as VenderName from PurchaseOrder PO Join Vender V on PO.SupplierID=V.venderLibraryID where V.SupplierStatus='Active' and PO.MarchandID='" & UserID & "' order by V.VenderLibraryID ASC"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetActiveVendor() As DataTable
            Dim Str As String
            Str = "select VenderLibraryID,VenderName from vender where IsActive='1'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetActiveVendorNew() As DataTable
            Dim Str As String
            Str = " select v.VenderLibraryID,v.VenderCode, v.VenderName, v.Address1, v.Address2, v.PhoneNumber"
            Str &= " ,c.city  from vender v join Cities c on  C.id=v.City"
            Str &= "  where IsActive='1' order by v.vendername ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        '***Modified by Bilal***'

        Public Function GetActiveVendorNewNew() As DataTable
            Dim Str As String
            Str = "select v.VenderLibraryID,v.VenderCode, v.VenderName, v.Address1, v.Address2, v.PhoneNumber "
            Str &= " ,c.city,isnull(v.suppliercategoryid,0)as suppliercategoryid ,isnull(sc.suppliercategoryname,'N/A') as suppliercategoryname from vender v "
            Str &= " left join Cities c on  C.id=v.City "
            Str &= " left join suppliercategory sc on sc.suppliercategoryid=v.suppliercategoryid "
            Str &= " where IsActive='1' "
            Str &= " order by v.vendername ASC "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetActiveSupplierNew() As DataTable
            Dim Str As String
            Str = " select Distinct v.VenderLibraryID,v.VenderCode, v.VenderName, v.Address1, v.Address2, v.PhoneNumber"
            Str &= " ,c.city  from vender v join Cities c on  C.id=v.City"
            Str &= " join Purchaseorder Po on PO.Supplierid=v.VenderLibraryID"
            Str &= "  where v.IsActive='1' and Year(PO.Shipmentdate)>=2013 order by v.vendername ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        ''===========Neew Work
        Public Function GetSuppliers() As DataTable
            Dim Str As String
            'Str = "select VenderLibraryID,VenderName from Vender where VenderLibraryID"
            'Str &= " in(Select Distinct SupplierID as VenderLibraryID from Purchaseorder)"

            Str = " Select Distinct  VenderLibraryID,VenderName from PurchaseOrder po"
            Str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID    "
            Str &= "  where(Year(PO.CreationDate) >= 2012)"
            Str &= " and po.poid in (select popoid from cargodetail)"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetBookedDataSupplier(ByVal SupplierID As Long) As DataTable
            Dim Str As String

            'Str = " Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate"
            'Str &= " ,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,C.Vendername as Vendername,Po.SupplierID,"
            'Str &= " (case when Currency='Dollar' then '$ ' Else'€ ' end)+(Convert(varchar,(Convert(Decimal,(Select"
            'Str &= " SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD"
            'Str &= " where SbPOD.POID =PO.POID),0)))) as Amount ,(case when Currency <> 'Dollar' then (Convert(varchar,(Convert(Decimal,(Select"
            'Str &= " SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD"
            'Str &= " where SbPOD.POID =PO.POID),0))))* Po.ExchangeRate  else (Convert(varchar,(Convert(Decimal,(Select"
            'Str &= "  SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.Rate),0)) from PurchaseOrderDetail SbPOD"
            'Str &= " where SbPOD.POID =PO.POID),0))))  end) as Newvalue  from PurchaseOrder PO   "
            'Str &= " Join Vender C on PO.SupplierID=C.VenderLibraryID  Join  UMUser U on UserID=PO.MarchandID  where  status !='Cancel' and PO.SupplierID ='" & SupplierID & "'"
            'Str &= " and PO.ShipmentDate >='01/01/2012'  and PO.ShipmentDate <= '12/31/2012' and Year(PO.CreationDate) >=2012  Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate,"
            'Str &= " C.Vendername,Currency,Po.ExchangeRate,Po.SupplierID order by po.POID desc"

            Str = "  Select PO.POID,PO.PONo,PO.Status,Convert(Varchar,PO.PlacementDate,106)as PlacementDate "
            Str &= " ,Convert(Varchar,PO.ShipmentDate,106)AS ShipmentDate,C.Vendername as Vendername,Po.SupplierID,"
            Str &= "  (Convert(varchar,(Convert(Decimal,(Select SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD "
            Str &= " where SbPOD.POID =PO.POID),0)))) as Newvalue  from PurchaseOrder PO    Join Vender C on PO.SupplierID=C.VenderLibraryID  "
            Str &= " Join  UMUser U on UserID=PO.MarchandID  where  status !='Cancel' and PO.SupplierID ='" & SupplierID & "' and"
            Str &= " Year(PO.CreationDate) >=2012  Group by PO.POID,PO.PONo,PO.Status,PO.PlacementDate,PO.ShipmentDate, C.Vendername,"
            Str &= " Currency,Po.ExchangeRate,Po.SupplierID order by po.POID desc"



            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataforProduction(ByVal SupplierID As Long) As DataTable
            Dim Str As String

            Str = "   select PO.POID,PO.pONo,v.vendername,po.Supplierid,"
            Str &= " cast ((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))   as bookedQty,"
            Str &= " (Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from cargodetail POD where POD.POPOID = PO.POID)as ShipedQty,"

            Str &= " cast (round((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID) * 5 / 100,0) as decimal (10,0))  as ToleranceQTY"
            Str &= " ,"
            Str &= " cast ((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))"
            Str &= " -"
            Str &= " cast (round((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID) * 5 / 100,0) as decimal (10,0)) as LowerRange"
            Str &= " ,"
            Str &= " cast ((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)as decimal (10,0))"
            Str &= " +"
            Str &= " cast (round((Select SUM(Isnull((POD.Quantity),0))"
            Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID) * 5 / 100,0) as decimal (10,0)) as UpperRange"
            Str &= " from  Purchaseorder Po "
            Str &= " Join Customer Cs on Cs.CustomerID=PO.CustomerID"
            Str &= " Join Vender V on V.VenderLibraryID=PO.SupplierID"
            Str &= "   where(Year(po.creationDate) >= 2012)"
            Str &= " and  po.poid in "
            Str &= " (select popoid from cargodetail)"
            Str &= "  and PO.SupplierID='" & SupplierID & "' "
            Str &= " order by po.supplierid"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCheckingResult(ByVal ShipedQty As Long, ByVal LowerRange As Long, ByVal UpperRange As Long) As DataTable
            Dim Str As String
            Str = "   select 1 where " & ShipedQty & " >=  " & LowerRange & ""
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetShippedDataSupplier(ByVal SupplierID As Long) As DataTable
            Dim Str As String
            'Str = " Select PO.POID,PO.PONo,PO.Status, (case when PO.Currency <> 'Dollar' then (Convert(varchar,(Convert(Decimal,(Select"
            'Str &= " SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.ShippedRate),0)) from CargoDetail SbPOD"
            'Str &= " where SbPOD.POPOID =PO.POID),0))))* Po.ExchangeRate  else (Convert(varchar,(Convert(Decimal,(Select"
            'Str &= " SUM(Isnull((SbPOD.Quantity),0)*Isnull((SbPOD.ShippedRate),0)) from CargoDetail SbPOD"
            'Str &= " where SbPOD.POPOID =PO.POID),0))))  end) as Newvalue  from Purchaseorder PO where PO.POID "
            'Str &= " in (Select Distinct POPOID from cargodetail where SupplierID='" & SupplierID & "') and Year(PO.CreationDate) >=2012"

            Str = " Select PO.POID,PO.PONo,PO.Status, "
            Str &= " (Convert(varchar,(Convert(Decimal,(Select SUM(Isnull((SbPOD.Quantity),0)) from cargodetail SbPOD "
            Str &= " where SbPOD.POPOID =PO.POID),0))))"
            Str &= " as Newvalue  from Purchaseorder PO where PO.POID  in (Select Distinct POPOID from cargodetail )"
            Str &= " and Year(PO.CreationDate) >=2012 and PO.SupplierID='" & SupplierID & "'"



            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPercentDataSupplier(ByVal SupplierID As Long) As DataTable
            Dim Str As String

            Str = "  Select PO.POID,PO.PONo,PO.Status, (case when ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
            Str &= " where SbPOD.POPOID =PO.POID),0))) > ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= " where SbPOD.POID =PO.POID),0))) then (Convert(varchar,(Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= " where SbPOD.POID =PO.POID),0)))) else (Convert(varchar,(Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD  where SbPOD.POPOID =PO.POID),0)))) "
            Str &= " end)as ShipQTy ,(Convert(varchar,(Convert(Decimal,(Select"
            Str &= "  SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= "  where SbPOD.POID =PO.POID),0)))) as QTY , (case when ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
            Str &= " where SbPOD.POPOID =PO.POID),0))) > ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= " where SbPOD.POID =PO.POID),0))) then  ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= " where SbPOD.POID =PO.POID),0))) / ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= " where SbPOD.POID =PO.POID),0)))* 100  else ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from CargoDetail SbPOD"
            Str &= " where SbPOD.POPOID =PO.POID),0))) / ((Convert(Decimal,(Select"
            Str &= " SUM(Isnull((SbPOD.Quantity),0)) from PurchaseOrderDetail SbPOD"
            Str &= " where SbPOD.POID =PO.POID),0)))*100  end) as PercentQTY"
            'Str &= " from Purchaseorder PO where PO.POID  in (Select Distinct POPOID from cargodetail where SupplierID='" & SupplierID & "') and Year(PO.CreationDate) >=2012 and po.SupplierID='" & SupplierID & "'"
            Str &= " from Purchaseorder PO where PO.POID  in (Select Distinct POPOID from cargodetail ) and Year(PO.CreationDate) >=2012 and po.SupplierID='" & SupplierID & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetVender()
            Dim Str As String
            Str = " select VenderLibraryID,VenderName from vender "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetimgOriginalLogo(ByVal VenderLibraryID As Long)
            Dim str As String
            str = "Select imgOriginalLogo from vender where VenderLibraryID=" & VenderLibraryID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgWaterMark(ByVal VenderLibraryID As Long)
            Dim str As String
            str = "Select imgWaterMark from vender where VenderLibraryID=" & VenderLibraryID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgVAF(ByVal VenderLibraryID As Long)
            Dim str As String
            str = "Select VAF from vender where VenderLibraryID=" & VenderLibraryID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetimgVAFuploadDate(ByVal VenderLibraryID As Long)
            Dim str As String
            str = "Select VAFuploadDate from vender where VenderLibraryID=" & VenderLibraryID
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOVendersForClaim(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = " Select Distinct V.venderLibraryID,VenderName "
            str &= " From PurchaseOrder PO "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID"
            str &= "  Where Year(ShipmentDate) >= 2012 And CustomerID = " & CustomerID
            str &= " order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOVendersForClaimNew(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = " Select Distinct V.venderLibraryID,VenderName "
            str &= " From PurchaseOrder PO "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID "
            str &= " join CargoDetail Cd on Po.POID=Cd.POPOID "
            str &= "  Where Year(PO.ShipmentDate) >= 2012 And PO.CustomerID = " & CustomerID
            str &= " order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOVendersForClaimWithBuyingDeptNew(ByVal CustomerID As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            str = " Select Distinct V.venderLibraryID,VenderName "
            str &= " From PurchaseOrder PO "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID "
            str &= " join CargoDetail Cd on Po.POID=Cd.POPOID "
            str &= "  Where Year(PO.ShipmentDate) >= 2012 And PO.CustomerID = '" & CustomerID & "' and po.EKNumber='" & BuyingDept & "'"
            str &= " order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderForCertificate() As DataTable
            Dim Str As String
            Str = " select Distinct VenderLibraryID,VenderName from Vender V "
            Str &= " join VenderCertificate VC on VC.VenderID = V.VenderLibraryID"
            Str &= "  order by VenderName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderForCertificateNew() As DataTable
            Dim Str As String
            Str = "  select Distinct VenderLibraryID,VenderName from Vender V "
            Str &= " join VenderSocialCompliance VC on VC.VenderID = V.VenderLibraryID "
            Str &= " order by VenderName ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ChkSupplier(ByVal VenderLibraryID As String) As DataTable
            Dim Str As String
            Str = " select  * from Vender "
            Str &= "  Where VenderLibraryID='" & VenderLibraryID & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetPOVendersForSMC(ByVal CustomerID As Long) As DataTable
            Dim str As String
            str = " Select Distinct V.venderLibraryID,VenderName "
            str &= " From PurchaseOrder PO "
            str &= " Join Vender V on PO.SupplierID=V.VenderLibraryID"
            str &= "  Where Year(ShipmentDate) >= 2013 And CustomerID = " & CustomerID
            str &= " order by VenderName ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetVenderForNoVAF()
            Dim Str As String
            Str = "  Select Distinct V.vendername from Vender V"
            Str &= " join Purchaseorder Po on Po.Supplierid=v.Venderlibraryid  "
            Str &= " where Year(Po.Shipmentdate) >= 2013 And V.VAFuploadDate < '" & Date.Now.Year & "-01-01' "
            Str &= " order by V.Vendername ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Shared Function EncryptData(ByVal Message As String) As String
            Dim Results As Byte()
            Dim UTF8 As New System.Text.UTF8Encoding()
            Dim HashProvider As New MD5CryptoServiceProvider()
            Dim TDESKey As Byte() = HashProvider.ComputeHash(UTF8.GetBytes(passphrase))
            Dim TDESAlgorithm As New TripleDESCryptoServiceProvider()
            TDESAlgorithm.Key = TDESKey
            TDESAlgorithm.Mode = CipherMode.ECB
            TDESAlgorithm.Padding = PaddingMode.PKCS7
            Dim DataToEncrypt As Byte() = UTF8.GetBytes(Message)
            Try
                Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor()
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)
            Finally
                TDESAlgorithm.Clear()
                HashProvider.Clear()
            End Try
            Return Convert.ToBase64String(Results)
        End Function
        Public Shared Function DecryptString(ByVal Message As String) As String
            Dim aa As String()
            aa = Message.Split(" ")
            If aa.Length > 1 Then
                Message = aa(0) + "+" + aa(1)
            End If


            Dim Results As Byte()
            Dim UTF8 As New System.Text.UTF8Encoding()
            Dim HashProvider As New MD5CryptoServiceProvider()
            Dim TDESKey As Byte() = HashProvider.ComputeHash(UTF8.GetBytes(passphrase))
            Dim TDESAlgorithm As New TripleDESCryptoServiceProvider()
            TDESAlgorithm.Key = TDESKey
            TDESAlgorithm.Mode = CipherMode.ECB
            TDESAlgorithm.Padding = PaddingMode.PKCS7
            Dim DataToDecrypt As Byte() = Convert.FromBase64String(Message)
            Try
                Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor()
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)
            Finally
                TDESAlgorithm.Clear()
                HashProvider.Clear()
            End Try
            Return UTF8.GetString(Results)
        End Function
        Public Function getReclamationTypes() As DataTable
            Dim Str As String
            Str = " select  * from ReclamationTypes "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUserInfo(ByVal UserId As Long) As DataTable
            Dim Str As String
            Str = " select  *  from UMUser where UserId='" & UserId & "' "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function

        Function getVenderForPON()
            Dim Str As String
            Str = " Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO Join Vender V on PO.SupplierID=V.venderLibraryID"
            Str &= " where V.SupplierStatus='Active'"
            Str &= " order by V.VenderName"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getVenderForPONNew(ByVal ProductPOrtfolioid As Long)
            Dim Str As String
            Str = " select Distinct V.VenderLibraryID,V.VenderName from purchaseorder po  join PurchaseOrderDetail POD on POD.poid=po.poid"
            Str &= " Join Vender V on PO.SupplierID=V.venderLibraryID"
            Str &= " join StyleProductInformation spi on spi.styleid=POD.styleid "
            Str &= " where ProductPOrtfolioid = '" & ProductPOrtfolioid & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getVenderForPONNew2(ByVal ProductPOrtfolioid As Long, ByVal EKNumber As String)
            Dim Str As String
            Str = " select Distinct V.VenderLibraryID,V.VenderName from purchaseorder po  join PurchaseOrderDetail POD on POD.poid=po.poid"
            Str &= " Join Vender V on PO.SupplierID=V.venderLibraryID"
            Str &= " join StyleProductInformation spi on spi.styleid=POD.styleid "
            Str &= " where ProductPOrtfolioid = '" & ProductPOrtfolioid & "' and po.EKNumber='" & EKNumber & "'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function getVenderForPOCancel()
            Dim Str As String
            'Str &= "  Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO "
            'Str &= " Join Vender V on PO.SupplierID=V.venderLibraryID"
            'Str &= " where POID in "
            'Str &= " (Select Distinct POPOID from Cargodetail Cd"
            'Str &= " join Purchaseorder PO on PO.POID=cd.POPOID"
            'Str &= " where "
            'Str &= " (Select SUM(Isnull((CD.Quantity),0)) "
            'Str &= " from Cargodetail CD where CD.POPOID = PO.POID) < (Select SUM(Isnull((POD.Quantity),0)) "
            'Str &= " from Purchaseorderdetail POD where POD.POID = PO.POID)) "
            'Str &= " order by V.VenderName"
            Str = "   Select Distinct V.VenderLibraryID,V.VenderName from PurchaseOrder PO Join Vender V on PO.SupplierID=V.venderLibraryID"
            Str &= " where POID in  (Select Distinct POPOID from Cargodetail Cd  join Purchaseorder PO on PO.POID=cd.POPOID) "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace