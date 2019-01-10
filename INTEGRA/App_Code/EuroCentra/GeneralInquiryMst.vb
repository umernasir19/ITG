Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data.OleDb
Namespace EuroCentra
    Public Class GeneralInquiryMst
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "GeneralInquiryMst"
            m_strPrimaryFieldName = "GeneralInquiryMstID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_GeneralInquiryMstID As Long
        Private m_CreationDate As Date
        Private m_InqRecvDate As Date
        Private m_InqConfDate As String
        Private m_InquiryType As String
        Private m_SeasonID As Long
        Private m_PONO As String
        Private m_StyleNo As String
        Private m_StyleId As String
        Private m_Remarks As String
        Private m_UserID As Long
        Private m_InquiryPurpose As String
        Private m_InquiryStatus As String
        Private m_ConfromationDate As String
        Public Property InquiryStatus() As String
            Get
                InquiryStatus = m_InquiryStatus
            End Get
            Set(ByVal value As String)
                m_InquiryStatus = value
            End Set
        End Property
        Public Property ConfromationDate() As String
            Get
                ConfromationDate = m_ConfromationDate
            End Get
            Set(ByVal value As String)
                m_ConfromationDate = value
            End Set
        End Property
        Public Property GeneralInquiryMstID() As Long
            Get
                GeneralInquiryMstID = m_GeneralInquiryMstID
            End Get
            Set(ByVal value As Long)
                m_GeneralInquiryMstID = value
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

        Public Property InqRecvDate() As Date
            Get
                InqRecvDate = m_InqRecvDate
            End Get
            Set(ByVal value As Date)
                m_InqRecvDate = value
            End Set
        End Property
        Public Property InqConfDate() As String
            Get
                InqConfDate = m_InqConfDate
            End Get
            Set(ByVal value As String)
                m_InqConfDate = value
            End Set
        End Property
        Public Property InquiryType() As String
            Get
                InquiryType = m_InquiryType
            End Get
            Set(ByVal value As String)
                m_InquiryType = value
            End Set
        End Property
        
        Public Property SeasonID() As Long
            Get
                SeasonID = m_SeasonID
            End Get
            Set(ByVal value As Long)
                m_SeasonID = value
            End Set
        End Property
        Public Property PONO() As String
            Get
                PONO = m_PONO
            End Get
            Set(ByVal value As String)
                m_PONO = value
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
        Public Property StyleId() As Long
            Get
                StyleId = m_StyleId
            End Get
            Set(ByVal value As Long)
                m_StyleId = value
            End Set
        End Property

        Public Property Remarks() As String
            Get
                Remarks = m_Remarks
            End Get
            Set(ByVal value As String)
                m_Remarks = value
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
        Public Property InquiryPurpose() As String
            Get
                InquiryPurpose = m_InquiryPurpose
            End Get
            Set(ByVal value As String)
                m_InquiryPurpose = value
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

        Public Function GetBindCombo1() As DataTable
            Dim str As String
            str = "select CustomerID,CustomerName from Customer where isactive='1' order by CustomerName ASC"
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
        Public Function GetBrandInfoNo(ByVal customerid As Long) As DataTable
            Dim str As String
            str = "SELECT distinct BrandName from   customerDetail where customerid=" & customerid
            Try
                Return MyBase.GetDataTable(str)
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

        Public Function GetBindCombo() As DataTable
            Dim str As String
            str = "select CustomerID,CustomerName from Customer where isactive='1' order by CustomerName ASC"
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
        Public Function GetBrandReportNew(ByVal customerid As Long, ByVal BuyingDept As String, ByVal Buyer As String) As DataTable
            Dim str As String
            str = "SELECT distinct cd.BrandName from   customerDetail cd   where cd.customerid=' " & customerid & "' and cd.DepartmentNo='" & BuyingDept & "' and Buyer_Name='" & Buyer & "'"
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
        Function GetAllForUser() 'ByVal UserID As Long, ByVal Seasonid As Long, ByVal SupplierID As Long
            Dim Str As String
            Str = " select  *,convert(varchar,ES.InqRecvDate,103) as InqRecvDatee from GeneralInquiryMst ES"
            Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid"
            Str = " select  *,convert(varchar,ES.InqRecvDate,103) as InqRecvDatee from GeneralInquiryMst ES "
            Str &= " join Stylemaster SM ON SM.sTYLEID=ES.sTYLEID"
            Str &= " Join Customer C on C.CustomerID=SM.Customerid "
            Str &= " join season sa on sa.seasonid=ES.seasonid"
            ' If UserID = 234 Then
            'If Seasonid > 0 And SupplierID > 0 Then
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.seasonid='" & Seasonid & "' and ES.SupplierID='" & SupplierID & "'"
            'ElseIf Seasonid > 0 And SupplierID = 0 Then
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.seasonid='" & Seasonid & "'  "
            'ElseIf Seasonid = 0 And SupplierID > 0 Then
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE   ES.SupplierID='" & SupplierID & "'"
            'Else
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid  "

            'End If
            '' Else
            'If Seasonid > 0 And SupplierID > 0 Then
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.seasonid='" & Seasonid & "' and ES.SupplierID='" & SupplierID & "'"
            'ElseIf Seasonid > 0 And SupplierID = 0 Then
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.seasonid='" & Seasonid & "'  "
            'ElseIf Seasonid = 0 And SupplierID > 0 Then
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "' and ES.SupplierID='" & SupplierID & "'"
            'Else
            '    Str = " select  *,convert(varchar,ES.RecvDate,103) as RecvDatee from GeneralInquiryMst ES"
            '    Str &= "  Join Vender V on ES.SupplierID=V.VenderLibraryID    "
            '    Str &= " Join Customer C on C.CustomerID=ES.Customerid join season sa on sa.seasonid=ES.seasonid WHERE ES.UserID='" & UserID & "'"

            'End If
            ' End If

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetUserWise(ByVal UserID As Long)
            Dim str As String
            str = "  select  *,convert(varchar,ES.InqRecvDate,103) as InqRecvDatee from GeneralInquiryMst ES"
            str &= " join Stylemaster SM ON SM.sTYLEID=ES.sTYLEID "
            str &= " Join Customer C on C.CustomerID=SM.Customerid  join season sa on sa.seasonid=ES.seasonid"
            str &= " WHERE ES.UserID='" & UserID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getEdit(ByVal GeneralInquiryMstID As Long)
            Dim Str As String
            Str = " select * from GeneralInquiryMst ES"
            Str &= " Join GeneralInquiryDtl ecp on ES.GeneralInquiryMstID=ecp.GeneralInquiryMstID WHERE  ES.GeneralInquiryMstID='" & GeneralInquiryMstID & "' "

            Try
                Return MyBase.GetDataTable(Str)
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
        Public Function GetStyleID(ByVal StyleNo As String) As DataTable
            Dim str As String
            str = " select * from StyleMaster where StyleNo='" & StyleNo & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace