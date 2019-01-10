Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb

Namespace EuroCentra
    Public Class EnquiriesSystemAddclass
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "EnquiriesSystemAdd"
            m_strPrimaryFieldName = "EnquiriesSystemID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_EnquiriesSystemID As Long
        Private m_CreationDate As Date
        Private m_StyleNo As String
        Private m_RecvDate As Date
        Private m_Brand As String
        Private m_CustomerID As Long
        Private m_SupplierID As Long
        Private m_ExFactoryDate As String
        Private m_Seasonid As Long
        Private m_SpecialInstruction As String
        Private m_StyleDesc As String
        Private m_StylingSource As String
        Private m_EnquiryType As String
        Private m_ProductCategoriesID As Long
        Private m_Buyer As String
        Private m_POStatus As String
        Private m_FileName As String
        Private m_Picture As Object
        Private m_UserID As Long
        Private m_ProductConsumerID As Long
        Private m_EnquiryPurpose As String
        Private m_EnquiryConfirmDate As String
        Private m_BuyingDept As String


        Public Property EnquiriesSystemID() As Long
            Get
                EnquiriesSystemID = m_EnquiriesSystemID
            End Get
            Set(ByVal value As Long)
                m_EnquiriesSystemID = value
            End Set
        End Property
        Public Property CreationDate() As Date
            Get
                CreationDate = m_CreationDate
            End Get
            Set(ByVal value As Date)
                m_CreationDate = value
            End Set
        End Property
        Public Property StyleNo() As String
            Get
                StyleNo = m_StyleNo
            End Get
            Set(ByVal value As String)
                m_StyleNo = value
            End Set
        End Property
        Public Property RecvDate() As Date
            Get
                RecvDate = m_RecvDate
            End Get
            Set(ByVal value As Date)
                m_RecvDate = value
            End Set
        End Property
        Public Property Brand() As String
            Get
                Brand = m_Brand
            End Get
            Set(ByVal value As String)
                m_Brand = value
            End Set
        End Property
        Public Property CustomerID() As Long
            Get
                CustomerID = m_CustomerID
            End Get
            Set(ByVal value As Long)
                m_CustomerID = value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_SupplierID
            End Get
            Set(ByVal value As Long)
                m_SupplierID = value
            End Set
        End Property
        Public Property ExFactoryDate() As String
            Get
                ExFactoryDate = m_ExFactoryDate
            End Get
            Set(ByVal value As String)
                m_ExFactoryDate = value
            End Set
        End Property
        Public Property Seasonid() As Long
            Get
                Seasonid = m_Seasonid
            End Get
            Set(ByVal value As Long)
                m_Seasonid = value
            End Set
        End Property
        Public Property SpecialInstruction() As String
            Get
                SpecialInstruction = m_SpecialInstruction
            End Get
            Set(ByVal value As String)
                m_SpecialInstruction = value
            End Set
        End Property
        Public Property StyleDesc() As String
            Get
                StyleDesc = m_StyleDesc
            End Get
            Set(ByVal value As String)
                m_StyleDesc = value
            End Set
        End Property
        Public Property StylingSource() As String
            Get
                StylingSource = m_StylingSource
            End Get
            Set(ByVal value As String)
                m_StylingSource = value
            End Set
        End Property
        Public Property EnquiryType() As String
            Get
                EnquiryType = m_EnquiryType
            End Get
            Set(ByVal value As String)
                m_EnquiryType = value
            End Set
        End Property
        Public Property ProductCategoriesID() As Long
            Get
                ProductCategoriesID = m_ProductCategoriesID
            End Get
            Set(ByVal value As Long)
                m_ProductCategoriesID = value
            End Set
        End Property
        Public Property Buyer() As String
            Get
                Buyer = m_Buyer
            End Get
            Set(ByVal value As String)
                m_Buyer = value
            End Set
        End Property
        Public Property POStatus() As String
            Get
                POStatus = m_POStatus
            End Get
            Set(ByVal value As String)
                m_POStatus = value
            End Set
        End Property

        Public Property FileName() As String
            Get
                FileName = m_FileName
            End Get
            Set(ByVal value As String)
                m_FileName = value
            End Set
        End Property
        Public Property Picture() As Object
            Get
                Picture = m_Picture
            End Get
            Set(ByVal value As Object)
                m_Picture = value
            End Set
        End Property
        Public Property UserID() As Long
            Get
                UserID = m_UserID
            End Get
            Set(ByVal value As Long)
                m_UserID = value
            End Set
        End Property
        Public Property ProductConsumerID() As Long
            Get
                ProductConsumerID = m_ProductConsumerID
            End Get
            Set(ByVal value As Long)
                m_ProductConsumerID = value
            End Set
        End Property
        Public Property EnquiryPurpose() As String
            Get
                EnquiryPurpose = m_EnquiryPurpose
            End Get
            Set(ByVal value As String)
                m_EnquiryPurpose = value
            End Set
        End Property
        Public Property EnquiryConfirmDate() As String
            Get
                EnquiryConfirmDate = m_EnquiryConfirmDate
            End Get
            Set(ByVal value As String)
                m_EnquiryConfirmDate = value
            End Set
        End Property
        Public Property BuyingDept() As String
            Get
                BuyingDept = m_BuyingDept
            End Get
            Set(ByVal value As String)
                m_BuyingDept = value
            End Set
        End Property
        Public Function SaveEnquiriesSystem()
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
        Public Function GetSeason() As DataTable
            Dim str As String
            str = " select   * from season  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetWorkLDSupplier()
            Dim str As String
            str = " select VenderLibraryID, VenderName from Vender "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function Getcpreq() As DataTable
            Dim str As String
            str = " select   * from tblCPRequirmen  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetcpreqBuyer() As DataTable
            Dim str As String
            str = " select   * from tblCPRequirmenBuyer  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetailById(ByVal EnquiriesSystemDetailID As Long)
            Dim str As String = "Delete EnquiriesSystemDetailAdd where EnquiriesSystemDetailID=" & EnquiriesSystemDetailID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetailcprById(ByVal EnquiriesSystemCPRID As Long)
            Dim str As String = "Delete EnquiriesSystemCPRDetail where EnquiriesSystemCPRID=" & EnquiriesSystemCPRID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteDetailcprbUYERById(ByVal EnquiriesSystemCPRBuyerID As Long)
            Dim str As String = "Delete EnquiriesSystemCPRBuyerDetail where EnquiriesSystemCPRBuyerID=" & EnquiriesSystemCPRBuyerID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetAll()
            Dim Str As String
            Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
            Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetAllForUser(ByVal UserID As Long, ByVal Seasonid As Long, ByVal SupplierID As Long)
            Dim Str As String
            If UserID = 234 Then
                If Seasonid > 0 And SupplierID > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.seasonid='" & Seasonid & "' and ES.SupplierID='" & SupplierID & "'"
                ElseIf Seasonid > 0 And SupplierID = 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.seasonid='" & Seasonid & "'  "
                ElseIf Seasonid = 0 And SupplierID > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.SupplierID='" & SupplierID & "'"
                Else
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid  "

                End If
            Else
                If Seasonid > 0 And SupplierID > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.seasonid='" & Seasonid & "' and ES.SupplierID='" & SupplierID & "'"
                ElseIf Seasonid > 0 And SupplierID = 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.seasonid='" & Seasonid & "'  "
                ElseIf Seasonid = 0 And SupplierID > 0 Then
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.SupplierID='" & SupplierID & "'"
                Else
                    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "'"

                End If
            End If
           
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetOnlyStyleSearch(ByVal StyleNo As String, ByVal Seasonid As Long, ByVal SupplierID As Long)
            Dim Str As String
            If Seasonid > 0 And SupplierID > 0 Then
                Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid Where Es.StyleNo='" & StyleNo & "' and ES.seasonid='" & Seasonid & "' AND ES.SupplierID='" & SupplierID & "'"

            ElseIf Seasonid > 0 And SupplierID = 0 Then
                Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid Where Es.StyleNo='" & StyleNo & "' and ES.seasonid='" & Seasonid & "' "

            ElseIf Seasonid = 0 And SupplierID > 0 Then
                Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid Where Es.StyleNo='" & StyleNo & "' and ES.SupplierID='" & SupplierID & "'"

            Else
                Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
                Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
                Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid Where Es.StyleNo='" & StyleNo & "'"

            End If
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getEdit(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select  convert(varchar,ES.creationdate,101) as creationdatee ,*,convert(varchar,ES.RecvDate,103) as RecvDatee from EnquiriesSystemAdd ES"
            Str &= " left Join EnquiriesSystemDetailAdd ecp on ES.EnquiriesSystemID=ecp.EnquiriesSystemID WHERE  ES.EnquiriesSystemID='" & EnquiriesSystemID & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getEditDetail(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select  * from  EnquiriesSystemDetailAdd ecp WHERE  ecp.EnquiriesSystemID='" & EnquiriesSystemID & "' "

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getEditCRP(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select   convert(varchar,ES.CPRDate,103) as CPRDate ,*  from EnquiriesSystemCPRDetail ES WHERE ES.EnquiriesSystemID='" & EnquiriesSystemID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function getEditCRPBUYER(ByVal EnquiriesSystemID As Long)
            Dim Str As String
            Str = " select   convert(varchar,ES.CPRBDate,103) as CPRDate ,*  from EnquiriesSystemCPRBuyerDetail ES WHERE ES.EnquiriesSystemID='" & EnquiriesSystemID & "'"


            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllProductCategories() As DataTable
            Dim str As String
            str = "  Select PC.ProductCategories+' ('+ PP.ProductPortFolio+')' as ProductCategories,* from ProductCategories PC"
            str &= "  join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID"
            str &= " order by PC.ProductCategories ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetAllProductCategoriesReport() As DataTable
            Dim str As String
            str = " Select distinct PC.ProductCategories+' ('+ PP.ProductPortFolio+')' as ProductCategories ,pc.ProductCategoriesID "
            str &= "  from ProductCategories PC"
            str &= "  join ProductPortfolio PP on PP.ProductPortfolioID=PC.ProductPortfolioID"
            str &= "  join EnquiriesSystemAdd eq on eq.ProductCategoriesID=pc.ProductCategoriesID"
            str &= "  order by PC.ProductCategories ASC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyle()
            Dim str As String
            str = " select EnquiriesSystemID,StyleNo from EnquiriesSystemAdd "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleDis()
            Dim str As String
            str = " select Distinct StyleNo from EnquiriesSystemAdd "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEnqStylesheet()
            Dim str As String
            str = " select   EnquiriesSystemid,StyleNo from EnquiriesSystemAdd "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleDiscat(ByVal customerid As Long, ByVal supplierid As Long, ByVal seasonid As Long, ByVal Enquirypurpose As String, ByVal BuyingDept As String, ByVal Buyer As String, ByVal Brand As String)
            Dim str As String
            If Brand = "All" Then
                If Buyer = "All" Then
                    If customerid = 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "'"
                    ElseIf customerid = 0 And supplierid <> 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "'"
                    ElseIf customerid <> 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= "   and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "'"
                    Else
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= " and supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "'"

                    End If
                Else
                    If customerid = 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "'"
                    ElseIf customerid = 0 And supplierid <> 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "'"
                    ElseIf customerid <> 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= "   and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "'"
                    Else
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= " and supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "'"

                    End If
                End If
            Else
                If Buyer = "All" Then
                    If customerid = 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Brand='" & Brand & "'"
                    ElseIf customerid = 0 And supplierid <> 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Brand='" & Brand & "'"
                    ElseIf customerid <> 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= "   and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Brand='" & Brand & "'"
                    Else
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= " and supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Brand='" & Brand & "'"

                    End If
                Else
                    If customerid = 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "' and Brand='" & Brand & "'"
                    ElseIf customerid = 0 And supplierid <> 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where  supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "' and Brand='" & Brand & "'"
                    ElseIf customerid <> 0 And supplierid = 0 Then
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= "   and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "' and Brand='" & Brand & "'"
                    Else
                        str = " select Distinct StyleNo  from EnquiriesSystemAdd where customerid='" & customerid & "'"
                        str &= " and supplierid='" & supplierid & "' and seasonid='" & seasonid & "' and Enquirypurpose='" & Enquirypurpose & "' AND BuyingDept='" & BuyingDept & "' and Buyer='" & Buyer & "' and Brand='" & Brand & "'"

                    End If
                End If
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplier()
            Dim str As String
            str = " select  distinct V.VenderLibraryID,V.VenderName from EnquiriesSystemAdd ES Join Vender V on ES.SupplierID=V.VenderLibraryID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCustomer()
            Dim str As String
            str = " select  distinct C.CustomerID,C.CustomerName from EnquiriesSystemAdd ES Join Customer C on C.CustomerID=ES.Customerid "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerInfoNo(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerInfoNorep(ByVal customerid As Long) As DataTable
            Dim str As String
            If customerid > 0 Then
                str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid=" & customerid
            Else
                str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail "
            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerInfoNorepNew(ByVal customerid As Long, ByVal BuyingDept As String) As DataTable
            Dim str As String
            If customerid > 0 Then
                str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where customerid=' " & customerid & "' and DepartmentNo='" & BuyingDept & "'"
            Else
                str = "SELECT distinct Buyer_Name as BuyerName from   customerDetail where DepartmentNo='" & BuyingDept & "'"
            End If

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
        Public Function GetBrandInfoNo(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct BrandName from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyingDeptenq(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct DepartmentNo as BuyingDept from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandReport(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct cd.BrandName from   customerDetail cd join EnquiriesSystemAdd ed on ed.Brand=cd.BrandName where cd.customerid=' " & customerid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBrandReportNew(ByVal customerid As Long, ByVal BuyingDept As String, ByVal Buyer As String) As DataTable
            Dim str As String
            str = "SELECT distinct cd.BrandName from   customerDetail cd join EnquiriesSystemAdd ed on ed.Brand=cd.BrandName where cd.customerid=' " & customerid & "' and cd.DepartmentNo='" & BuyingDept & "' and Buyer_Name='" & Buyer & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerReport(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct cd.Buyer_Name from   customerDetail cd join EnquiriesSystemAdd ed on ed.Buyer=cd.Buyer_Name  where cd.customerid =  '" & customerid & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetBuyerEntryPage(ByVal customerid As Long, ByVal BuyingDept As String, ByVal Buyer As String) As DataTable
            Dim str As String
            str = "SELECT distinct cd.BrandName from   customerDetail cd  where cd.customerid=' " & customerid & "' and cd.DepartmentNo='" & BuyingDept & "' and Buyer_Name='" & Buyer & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetProductConsumer() As DataTable
            Dim str As String
            str = " select   * from ProductConsumer  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleNo() As DataTable
            Dim str As String
            str = " select  distinct StyleNo  from EnquiriesSystemAdd "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleNo(ByVal supplierid As Long, ByVal seasonid As Long) As DataTable
            Dim str As String
            If supplierid <> 0 And seasonid = 0 Then
                str = " select Distinct StyleNo  from EnquiriesSystemAdd where  supplierid='" & supplierid & "'  "
            ElseIf supplierid <> 0 And seasonid <> 0 Then
                str = " select Distinct StyleNo  from EnquiriesSystemAdd where  supplierid='" & supplierid & "' and seasonid='" & seasonid & "'"
            ElseIf supplierid = 0 And seasonid <> 0 Then
                str = " select Distinct StyleNo  from EnquiriesSystemAdd where   seasonid='" & seasonid & "'"
            Else
                str = " select Distinct StyleNo  from EnquiriesSystemAdd "

            End If

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetSupplierName(ByVal Styleno As String) As DataTable
            Dim str As String
            If str = "All" Then
                str = " select distinct es.SupplierID ,VenderName  from EnquiriesSystemAdd es join Vender v on v.VenderLibraryID =es.SupplierID  "
            Else
                str = " select distinct es.SupplierID ,VenderName  from EnquiriesSystemAdd es join Vender v on v.VenderLibraryID =es.SupplierID where es.styleNo='" & Styleno & "'"
            End If


            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierName() As DataTable
            Dim str As String

            str = " select distinct es.SupplierID ,VenderName  from EnquiriesSystemAdd es join Vender v on v.VenderLibraryID =es.SupplierID  "



            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
