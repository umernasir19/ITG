Imports Microsoft.VisualBasic
'**************************************************************************************
'*      Class Name         :    CottonItemThree.vb
'*      Class Description  :    Provided Business Logic related to entity "CottonItemThree"
'*      Core Table         :    POClaim
'**************************************************************************************
Imports System.Data
Imports System.Data.SqlClient ' Only for Data Reader & Data Table
Imports System.Text  ' For StringBuilder 
Namespace EuroCentra

    Public Class POClaim
        Inherits SQLManager
        '*******************************************************
        '                   Class Constructor
        '*******************************************************
        ' Defining parameter less constructor
        Public Sub New()
            m_strTableName = "POClaim"
            m_strPrimaryFieldName = "POClaimID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lPOClaimID As Long
        Private m_lPOID As Long
        Private m_dtCreationDate As Date
        Private m_strClaimPcs As Decimal
        Private m_strClaimAmount As Decimal
        Private m_strCurrency As String
        Private m_strClaimNo As String
        Private m_strClaimReason As String
        Private m_bIsActive As Boolean
        Private m_dtClaimDate As Date
        Private m_strSettleAmount As Decimal
        Private m_strbuyingdept As String
        Private m_strseason As String
        Private m_strRemarks As String
        Private m_strNatureofClaim As String
        Private m_strJobNo As String
        Private m_lNatureofClaimid As Long
        Public Property SettleAmount() As Decimal
            Get
                SettleAmount = m_strSettleAmount
            End Get
            Set(ByVal value As Decimal)
                m_strSettleAmount = value
            End Set
        End Property
        Public Property ClaimDate() As Date
            Get
                ClaimDate = m_dtClaimDate
            End Get
            Set(ByVal value As Date)
                m_dtClaimDate = value
            End Set
        End Property
        Public Property POClaimID() As Long
            Get
                POClaimID = m_lPOClaimID
            End Get
            Set(ByVal value As Long)
                m_lPOClaimID = value
            End Set
        End Property
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
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
        Public Property ClaimAmount() As Decimal
            Get
                ClaimAmount = m_strClaimAmount
            End Get
            Set(ByVal value As Decimal)
                m_strClaimAmount = value
            End Set
        End Property
        Public Property ClaimPcs() As Decimal
            Get
                ClaimPcs = m_strClaimPcs
            End Get
            Set(ByVal value As Decimal)
                m_strClaimPcs = value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Currency = m_strCurrency
            End Get
            Set(ByVal value As String)
                m_strCurrency = value
            End Set
        End Property
        Public Property ClaimNo() As String
            Get
                ClaimNo = m_strClaimNo
            End Get
            Set(ByVal value As String)
                m_strClaimNo = value
            End Set
        End Property
        Public Property ClaimReason() As String
            Get
                ClaimReason = m_strClaimReason
            End Get
            Set(ByVal value As String)
                m_strClaimReason = value
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
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Property buyingdept() As String
            Get
                buyingdept = m_strbuyingdept
            End Get
            Set(ByVal value As String)
                m_strbuyingdept = value
            End Set
        End Property
        Public Property season() As String
            Get
                season = m_strseason
            End Get
            Set(ByVal value As String)
                m_strseason = value
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

        Public Property NatureofClaim() As String
            Get
                NatureofClaim = m_strNatureofClaim
            End Get
            Set(ByVal value As String)
                m_strNatureofClaim = value
            End Set
        End Property
        Public Property JobNo() As String
            Get
                JobNo = m_strJobNo
            End Get
            Set(ByVal value As String)
                m_strJobNo = value
            End Set
        End Property
        Public Property NatureofClaimid() As Long
            Get
                NatureofClaimid = m_lNatureofClaimid
            End Get
            Set(ByVal value As Long)
                m_lNatureofClaimid = value
            End Set
        End Property
        Public Function SavePoClaim()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetCLaim(ByVal POID As Long)
            Dim Str As String
            Str = " Select PO.Design,PO.Status,ISNull(CLD.POClaimDetailID,0)as POClaimDetailID,"
            Str &= " Po.POID, POd.PODetailID, S.StyleID, sd.StyleDetailID,s.StyleNo"
            Str &= " ,SD.ColorRefNo as Article  ,sd.Colorway ,sd.Sizes as SizeRange,pod.Quantity as POQuantity  "
            Str &= " From  PurchaseOrder PO  "
            Str &= " Join PurchaseOrderDetail POD on PO.POID=POD.POID "
            Str &= " left Join POClaimDetail CLD on CLD.PODetailID=POD.PODetailID "
            Str &= " Join StyleMaster S On S.StyleID=POD.StyleID  "
            Str &= " join StyleDetail sd on sd.StyleDetailID =pod.StyleDetailID "
            Str &= " where PO.POID =" & POID
            Str &= " order by PO.POID ASC"

            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetIDByPO(ByVal POID As Long) As Long
            Dim Str As String
            Str = " Select ISNull(POClaimID,0)as POClaimID from POClaim where POID=" & POID
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetNatureofclaim()
            Dim Str As String
            Str = " Select *   from tblNatureofclaim "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetClaimForView()
            Dim Str As String
            Str = " Select POC.*,Convert(Varchar,POC.CreationDate,106)as CreationDatee,Convert(Varchar,POC.ClaimDate,106)as ClaimDatee  from POClaim POC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetValeForEdit(ByVal POClaimID As Long)
            Dim Str As String
            Str = " Select Po.CustomerID,po.SupplierID,PO.PONO,C.CustomerName ,V.VenderName, PO.Design,PO.Status,s.StyleNo"
            Str &= " ,SD.ColorRefNo as Article  ,sd.Colorway ,sd.Sizes as SizeRange "
            Str &= " ,POc.*,POCD.* from POClaim POC"
            Str &= " join POClaimDetail POCD on POC.POClaimID =POCd.POClaimID "
            Str &= " join PurchaseOrder PO  on po.POID=poc.POID "
            Str &= " Join PurchaseOrderDetail POD on POD.PODetailID =POCD.PODetailID "
            Str &= " Join StyleMaster S On S.StyleID=POCD.StyleID  "
            Str &= " join StyleDetail sd on sd.StyleDetailID =POCD.StyleDetailID "
            Str &= " join Customer C on c.CustomerID =Po.CustomerID "
            Str &= " join Vender V on V.VenderLibraryID =po.SupplierID "
            Str &= " where POc.POClaimID = " & POClaimID
            Str &= " order by PO.POID ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function checkclaimAlreadyexist(ByVal claimno As String)
            Dim Str As String
            Str = "Select POC.ClaimNo  from POClaim POC where POC.ClaimNo ='" & claimno & "'"
            Try
                Return MyBase.GetScaler(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetClaimForPopUpView()
            Dim Str As String
            Str = " Select POC.*, PO.PONO, C.Aliass, V.ShortName,Convert(Varchar,POC.CreationDate,106)as CreationDatee,Convert(Varchar,POC.ClaimDate,106)as ClaimDatee from POClaim POC"
            Str &= " join PurchaseOrder PO on PO.POID = POC.POID"
            Str &= " join Customer C on C.CustomerID = PO.CustomerID"
            Str &= " join Vender V on V.VenderLibraryID = PO.SupplierID"
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function Getseason()
            Dim Str As String
            Str = " select distinct season from PurchaseOrder "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace