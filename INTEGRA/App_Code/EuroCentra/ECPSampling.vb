Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class ECPSampling
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ECPSampling"
            m_strPrimaryFieldName = "ECPSamplingID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lECPSamplingID As Long
        Private m_dtCreationDate As Date
        Private m_dtEntryDate As Date
        Private m_lCustomerID As Long
        Private m_lSupplierID As Long
        Private m_strStyleNo As String
        Private m_lPDUserid As Long
        Private m_strBuyingDept As String
        Private m_lUserID As Long
        Public Property UserID() As Long
            Get
                UserID = m_lUserID
            End Get
            Set(ByVal value As Long)
                m_lUserID = value
            End Set
        End Property
        Public Property ECPSamplingID() As Long
            Get
                ECPSamplingID = m_lECPSamplingID
            End Get
            Set(ByVal value As Long)
                m_lECPSamplingID = value
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
        Public Property EntryDate() As Date
            Get
                EntryDate = m_dtEntryDate
            End Get
            Set(ByVal value As Date)
                m_dtEntryDate = value
            End Set
        End Property
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
        Public Property StyleNo() As String
            Get
                StyleNo = m_strStyleNo
            End Get
            Set(ByVal value As String)
                m_strStyleNo = value
            End Set
        End Property
        Public Property PDUserid() As Long
            Get
                PDUserid = m_lPDUserid
            End Get
            Set(ByVal value As Long)
                m_lPDUserid = value
            End Set
        End Property
        Public Function SaveECPSamplingEntry()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Property BuyingDept() As String
            Get
                BuyingDept = m_strBuyingDept
            End Get
            Set(ByVal value As String)
                m_strBuyingDept = value
            End Set
        End Property
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerCombo()
            Dim str As String
            Try
                str = "select Distinct C.CustomerID,C.CustomerName  from Customer C "
                str &= " join Purchaseorder PO on PO.Customerid=C.Customerid"
                str &= " where Year(Po.Shipmentdate) >=2013"
                str &= " order by C.CustomerName ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCustomerComboN()
            Dim str As String
            Try
                str = " select Distinct C.CustomerID,C.CustomerName  from Customer C "
                str &= " order by C.CustomerName ASC "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierCombo()
            Dim str As String
            Try
                str = "select Distinct V.VenderLibraryID,V.VenderName  from Vender V "
                str &= " join Purchaseorder PO on v.VenderLibraryID =PO.SupplierID "
                str &= " where Year(Po.Shipmentdate) >=2013"
                str &= " order by V.VenderName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierComboN()
            Dim str As String
            Try
                str = "select Distinct V.VenderLibraryID,V.VenderName  from Vender V "
                str &= " order by V.VenderName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUserCombo()
            Dim str As String
            Try
                str = "select Distinct U.UserId,U.UserName  from UMUser U "
                str &= " join Purchaseorder PO on U.UserId =PO.Marchandid "
                str &= " where Year(Po.Shipmentdate) >=2013"
                str &= " order by U.UserName  ASC"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetTypeOfSamplingCombo()
            Dim str As String
            Try
                str = "  Select * from TypeOfSampling "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllData()
            Dim str As String
            Try
                str = "select ECP.*,ECPD.*,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetECPSamplingDataForEditData(ByVal lECPSamplingID As Long)
            Dim str As String
            Try
                str = "select ECP.*,ECPD.*,Convert(Varchar,ECPD.Datee,103) as DateeN,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= "  where ECP.ECPSamplingID=" & lECPSamplingID
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function getExcelSheet()
            Try
                Dim strConnection As String = ConfigurationManager.ConnectionStrings("dbConnection").ConnectionString
                Dim objSqlConnection As New SqlConnection
                Dim sqlCmd As New SqlCommand
                objSqlConnection = New SqlConnection(strConnection)
                sqlCmd = New SqlCommand("sp_PDMSheet", objSqlConnection)
                sqlCmd.CommandType = CommandType.StoredProcedure
                objSqlConnection.Open()
                sqlCmd.ExecuteNonQuery()
                objSqlConnection.Close()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetDataForSCMMail()
            Dim str As String
            Try
                str = " select ECP.*,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= " where DatePart(wk, ECP.EntryDate) = DatePart(wk, GEtDate())"
                str &= " and ECP.Status='Pass'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForMailDistinctMerchant()
            Dim str As String
            Try
                str = " select distinct ECP.UserID "
                str &= " from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= "  where DatePart(wk, ECP.EntryDate) = DatePart(wk, GEtDate())"
                str &= " and ECP.Status='Pass'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForMailMarchant(ByVal UserID As Long)
            Dim str As String
            Try
                str = " select ECP.*,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= "  where DatePart(wk, ECP.EntryDate) = DatePart(wk, GEtDate())"
                str &= "  and ECP.UserID=" & UserID
                str &= " and ECP.Status='Pass'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForSCMMailFail()
            Dim str As String
            Try
                str = " select ECP.*,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= " where DatePart(wk, ECP.EntryDate) = DatePart(wk, GEtDate())"
                str &= " and ECP.Status='Fail'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForMailDistinctMerchantFail()
            Dim str As String
            Try
                str = " select distinct ECP.UserID "
                str &= " from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= "  where DatePart(wk, ECP.EntryDate) = DatePart(wk, GEtDate())"
                str &= " and ECP.Status='Fail'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetDataForMailMarchantFail(ByVal UserID As Long)
            Dim str As String
            Try
                str = " select ECP.*,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= "  where DatePart(wk, ECP.EntryDate) = DatePart(wk, GEtDate())"
                str &= "  and ECP.UserID=" & UserID
                str &= " and ECP.Status='Fail'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

        Public Function SendFailAlert(ByVal ECPSamplingID As Long)
            Dim str As String
            Try
                str = " select ECP.*,C.CustomerName,V.VenderName as SupplierName"
                str &= " ,U.UserName ,T.TypeName  ,Convert(Varchar,ECP.Creationdate,103) as Creationdatee,Convert(Varchar,ECP.EntryDate ,103) as EntryDatee ,uu.username as PD  from ECPSampling ECP "
                str &= " join ECPSamplingDetail ECPD on ECPD.ECPSamplingID =ECP.ECPSamplingID "
                str &= " join Customer C on C.CustomerID =ECP.CustomerID "
                str &= " join Vender V on v.VenderLibraryID =ECP.SupplierID "
                str &= " join UMUser U on U.UserId =ECP.UserID "
                str &= " join TypeOfSampling T on T.TypeOfSamplingID =ECPD.TypeOfSamplingID"
                str &= " join UMUser uU on uU.UserId =ECP.PDUserid  "
                str &= "  Where ECP.ECPSamplingID=" & ECPSamplingID

                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
    End Class
End Namespace

