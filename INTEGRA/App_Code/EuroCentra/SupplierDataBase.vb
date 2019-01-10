Imports System.Data.SqlClient
Imports System.Text
Imports System.Data
Namespace EuroCentra

    Public Class SupplierDataBase

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "SupplierDatabase"
            m_strPrimaryFieldName = "SupplierDatabaseId"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''Member Variables'''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim m_lSupplierDatabaseId As Long
        Dim m_strSupplierName As String
        Dim m_strSupplieAddress As String
        Dim m_bIsActive As Boolean
        Dim m_strtelephone As String
        Dim m_strEmail As String
        Dim m_lSupplierCategoryId As Long
        Dim m_strSupplierCode As String
        Dim m_strFaxNo As String
        Dim m_strAccountCode As String
        Dim m_luserid As Long
        Private m_dtCreationDate As Date
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property userid() As Long
            Get
                userid = m_luserid
            End Get
            Set(ByVal Value As Long)
                m_luserid = Value
            End Set
        End Property
        Public Property SupplierDatabaseId() As Long
            Get
                SupplierDatabaseId = m_lSupplierDatabaseId
            End Get
            Set(ByVal Value As Long)
                m_lSupplierDatabaseId = Value
            End Set
        End Property
        Public Property SupplierName() As String
            Get
                SupplierName = m_strSupplierName
            End Get
            Set(ByVal Value As String)
                m_strSupplierName = Value
            End Set
        End Property
        Public Property SupplieAddress() As String
            Get
                SupplieAddress = m_strSupplieAddress
            End Get
            Set(ByVal Value As String)
                m_strSupplieAddress = Value
            End Set
        End Property

        Public Property TelephoneNo() As String
            Get
                TelephoneNo = m_strtelephone
            End Get
            Set(ByVal Value As String)
                m_strtelephone = Value
            End Set
        End Property
        Public Property Email() As String
            Get
                Email = m_strEmail
            End Get
            Set(ByVal Value As String)
                m_strEmail = Value
            End Set
        End Property
        Public Property IsActive() As Boolean

            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal Value As Boolean)
                m_bIsActive = Value
            End Set
        End Property

        Public Property SupplierCategoryId() As Long
            Get
                SupplierCategoryId = m_lSupplierCategoryId
            End Get
            Set(ByVal Value As Long)
                m_lSupplierCategoryId = Value
            End Set
        End Property
        Public Property SupplierCode() As String
            Get
                SupplierCode = m_strSupplierCode
            End Get
            Set(ByVal Value As String)
                m_strSupplierCode = Value
            End Set
        End Property
        Public Property FaxNo() As String
            Get
                FaxNo = m_strFaxNo
            End Get
            Set(ByVal Value As String)
                m_strFaxNo = Value
            End Set
        End Property
        Public Property AccountCode() As String
            Get
                AccountCode = m_strAccountCode
            End Get
            Set(ByVal Value As String)
                m_strAccountCode = Value
            End Set
        End Property
        Public Function SaveSupplierDatabase()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTO(ByVal SupplierName As String)
            Dim Str As String
            Str = "Select SupplierName as Name from SupplierDatabase where SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function GETAUTOForSupplierName(ByVal AccountName As String)
            Dim Str As String
            Str = " SELECT AccountName,AccountCode FROM tblAccounts WHERE AccountNature=2 AND ActLevelDigit=4 AND gROUPACT=0201001 and AccountName like '" & AccountName & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierForDalAccounts()
            Dim str As String
            str = " Select * from  SupplierDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierDataBaseAllInfo(ByVal SupplierName As String)
            Dim Str As String
            Str = "select * from SupplierDatabase SD   left join SupplierDatabaseCategory SDC on"
            Str &= "  SDC.SupplierCategoryId =SD.SupplierCategoryId  where SD.SupplierName='" & SupplierName & "'"
            Try
                Return (MyBase.GetDataTable(Str))
            Catch ex As Exception

            End Try
        End Function
        Public Function DeleteSupplierDatBase(ByVal SupplierId As Long)
            Dim Str As String
            Str = " delete from SupplierDatabase where SupplierDatabaseId=" & SupplierId
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSupplierCategory()
            Dim str As String
            str = "select * from SupplierDatabaseCategory"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetails()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId "
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForAStore()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='242' "
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForGStore()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='244'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForDStore()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='243'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForFStore()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='241'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsnew()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='241' or SD.UserID='237'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsnewNew()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='241' "
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsnewNewNew()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId "
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForRND()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='237'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForRNDNewForDirectorView()
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRMFORMROLEID(ByVal FormRoleId As Long)
            Dim str As String
            str = "select * from RMFormRolesNew  "
            str &= "  WHERE FormRoleId='" & FormRoleId & "'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUserStatus(ByVal UserID As Long)
            Dim str As String
            str = "select * from UmUser  "
            str &= "  WHERE UserID='" & UserID & "'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierDatabaseDetailsForRNDNew(ByVal UserID As Long)
            Dim str As String
            str = "select * from SupplierDatabase SD "
            str &= " join SupplierDatabaseCategory SC on SC.SupplierCategoryId =SD.SupplierCategoryId WHERE SD.UserID='" & userid & "'"
            Try
                Return (MyBase.GetDataTable(str))
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierCode(ByVal Id As Long)
            Dim str As String
            str = "Select Top 1(SupplierCode) From SupplierDatabase where SupplierCategoryId='" & Id & "'  order by SupplierCode DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierById(ByVal lSupplierDatabaseID As Long)
            Dim Str As String
            Str = "select * from SupplierDatabase SD "
            Str &= " join SupplierDatabaseCategory SDC on SDC.SupplierCategoryId =SD.SupplierCategoryId "
            Str &= " join  SupplierDatabaseDetail SDD on SDD.SupplierDatabaseId=SD.SupplierDatabaseId "
            Str &= " where SD.SupplierDatabaseId=" & lSupplierDatabaseID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        ''Supplier for invoice
        Public Function GetSupplierForInvoice()
            Dim str As String
            str = "select * from SupplierDatabase "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetSupplierForStore()
            Dim str As String
            str = " select * from IMSSupplier "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        ''25 may 2015  new work
        Public Function GetSupplierIDForInvoice(ByVal SupplierName As String)
            Dim str As String
            str = "select * from SupplierDatabase  where SupplierName like '%" & SupplierName & "%'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Function GETAUTOForSupplierNameNeww(ByVal AccountName As String)
            Dim Str As String
            Str = " SELECT AccountName,AccountCode FROM tblAccounts WHERE AccountNature=2 AND ActLevelDigit=4 AND gROUPACT=0201001 and AccountName like '" & AccountName & "%'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Function gETsUPPLIERpo(ByVal SupplierName As String)
            Dim Str As String
            Str = " select * from SupplierDatabase where SupplierName='" & SupplierName & "'"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetUniqueAccountName(ByVal AccountName As String)
            Dim str As String
            str = " Select * from tblAccounts where AccountName ='" & AccountName & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class

End Namespace


