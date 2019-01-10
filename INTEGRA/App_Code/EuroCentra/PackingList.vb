Imports Microsoft.VisualBasic
Imports System.Data

Namespace EuroCentra
    Public Class PackingList
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PackingList"
            m_strPrimaryFieldName = "PackingListID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''Properties'''''''''''''''''''''''''''''''''''''''''
        Private m_lPackingListID As Long
        Private m_dtCreationDate As DateTime
        Private m_lCommercialinvoiceID As Long
        Private m_dTotalCarton As Decimal
        Private m_dGrossWeight As Decimal
        Private m_strGrossUOM As String
        Private m_dNetWeight As Decimal
        Private m_dStartSeriesNo As Decimal
        Private m_dEndSeriesNo As Decimal
        Private m_dLenght As Decimal
        Private m_strLenghtUOM As String
        Private m_dWidth As Decimal
        Private m_dHeight As Decimal
        Private m_strComments As String
        Private m_strPackingListNo As String


        Public Property PackingListID() As Long
            Get
                PackingListID = m_lPackingListID
            End Get
            Set(ByVal Value As Long)
                m_lPackingListID = Value
            End Set
        End Property
        Public Property CreationDate() As DateTime
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As DateTime)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property CommercialinvoiceID() As Long
            Get
                CommercialinvoiceID = m_lCommercialinvoiceID
            End Get
            Set(ByVal Value As Long)
                m_lCommercialinvoiceID = Value
            End Set
        End Property
        Public Property TotalCarton() As Decimal
            Get
                TotalCarton = m_dTotalCarton
            End Get
            Set(ByVal value As Decimal)
                m_dTotalCarton = value
            End Set
        End Property
        Public Property GrossWeight() As Decimal
            Get
                GrossWeight = m_dGrossWeight
            End Get
            Set(ByVal value As Decimal)
                m_dGrossWeight = value
            End Set
        End Property
        Public Property GrossUOM() As String
            Get
                GrossUOM = m_strGrossUOM
            End Get
            Set(ByVal value As String)
                m_strGrossUOM = value
            End Set
        End Property
        Public Property NetWeight() As Decimal
            Get
                NetWeight = m_dNetWeight
            End Get
            Set(ByVal value As Decimal)
                m_dNetWeight = value
            End Set
        End Property
        Public Property StartSeriesNo() As Decimal
            Get
                StartSeriesNo = m_dStartSeriesNo
            End Get
            Set(ByVal value As Decimal)
                m_dStartSeriesNo = value
            End Set
        End Property
        Public Property EndSeriesNo() As Decimal
            Get
                EndSeriesNo = m_dEndSeriesNo
            End Get
            Set(ByVal value As Decimal)
                m_dEndSeriesNo = value
            End Set
        End Property
        Public Property Lenght() As Decimal
            Get
                Lenght = m_dLenght
            End Get
            Set(ByVal value As Decimal)
                m_dLenght = value
            End Set
        End Property
        Public Property LenghtUOM() As String
            Get
                LenghtUOM = m_strLenghtUOM
            End Get
            Set(ByVal value As String)
                m_strLenghtUOM = value
            End Set
        End Property
        Public Property Width() As Decimal
            Get
                Width = m_dWidth
            End Get
            Set(ByVal value As Decimal)
                m_dWidth = value
            End Set
        End Property
        Public Property Height() As Decimal
            Get
                Height = m_dHeight
            End Get
            Set(ByVal value As Decimal)
                m_dHeight = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Comments = m_strComments
            End Get
            Set(ByVal value As String)
                m_strComments = value
            End Set
        End Property
        Public Property PackingListNo() As String
            Get
                PackingListNo = m_strPackingListNo
            End Get
            Set(ByVal value As String)
                m_strPackingListNo = value
            End Set
        End Property
        Public Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function SavePackingList()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetInvoiceNo() As DataTable
            Dim str As String
            str = "Select CommercialInvoiceID, InvoiceNo from CommercialInvoice"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPONo(ByVal CommercialInvoiceID As String) As DataTable
            Dim str As String
            str = " Select distinct PO.PONO, cd.POID  From  CommercialInvoice c"
            str &= " join CommercialInvoiceDetail cd on cd.CommercialInvoiceID=c.CommercialInvoiceID"
            str &= " join PurchaseOrder PO on PO.POID=cd.POID"
            str &= " where c.CommercialInvoiceID ='" & CommercialInvoiceID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetArticleNo(ByVal POID As Long) As DataTable
            Dim str As String
            str = " select distinct sd.Article   from CommercialInvoiceDetail CID"
            str &= " join PurchaseOrderDetail pod on pod.PODetailID=CID.PODetailID"
            str &= " join StyleDetail sd on sd.StyleDetailID =pod.StyleDetailID "
            str &= " where  CID.POID='" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetSizes(ByVal POID As Long, ByVal CommercialinvoiceID As Long, ByVal Article As String) As DataTable
            Dim str As String
            str = "select CID.CommercialInvoiceDetailID, SD.SizeRange, POD.PODetailID from CommercialInvoiceDetail CID"
            str &= " join PurchaseOrderDetail pod on pod.PODetailID=CID.PODetailID"
            str &= " join StyleDetail sd on sd.StyleDetailID =pod.StyleDetailID "
            str &= "   where CID.POID = '" & POID & "' And CID.CommercialInvoiceID = '" & CommercialinvoiceID & "' and Sd.Article='" & Article & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetQuantity(ByVal PODetailID As Long)
            Dim str As String
            str = " select sum (cid.Quantity) as Quantity from CommercialInvoiceDetail CID"
            str &= " join PurchaseOrderDetail pod on pod.PODetailID=CID.PODetailID"
            str &= " join StyleDetail sd on sd.StyleDetailID =pod.StyleDetailID "
            str &= " Where POD.PODetailID ='" & PODetailID & "'"
            Try
                Return MyBase.GetScaler(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPackingListView() As DataTable
            Dim str As String
            str = " select CI.InvoiceNo,  PL.PackingListID, PL.TotalCarton,"
            str &= " convert(varchar,PL.GrossWeight) + PL.GrossUOM as GrossUM , "
            str &= "  PL.NetWeight, PL.PackingListNo,"
            str &= "  ISNULL((Select Sum(PLD.Quantity) from PackingListDetail PLD where"
            str &= "  PLD.PackingListID = PL.PackingListID ),0) as TotalQTY"
            str &= " from PackingList PL"
            str &= " Join CommercialInvoice CI on CI.CommercialInvoiceID = PL.CommercialInvoiceID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetPackingListValueforEdit(ByVal PackingListID As Long) As DataTable
            Dim str As String
            str = "Select pl.* , pld.*, ci.InvoiceNo, po.PONO, sd.Article, sd.SizeRange  from PackingList pl join PackingListDetail pld on pld.PackingListID = pl.PackingListID"
            str &= " join CommercialInvoice ci on ci.CommercialInvoiceID = pl.CommercialInvoiceID "
            str &= " join PurchaseOrder po on po.POID = pld.POID"
            str &= " join PurchaseOrderDetail  pod on pod.PODetailID  = pld.PODetailID  "
            str &= " JOIN StyleDetail SD on SD.StyleDetailID=pod.StyleDetailID  where pl.PackingListID = '" & PackingListID & "'  "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExistingValue(ByVal PackingListNo As String, ByVal CommercialInvoiceID As Long, ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select PL.PackingListID, PL.PackingListNo, PL.CommercialInvoiceID, PLD.POID  from PackingList PL"
            str &= " join PackingListDetail PLD "
            str &= " on PL.PackingListID = PLD.PackingListID"
            str &= " where PL.PackingListNo = '" & PackingListNo & "' and PL.CommercialInvoiceID = '" & CommercialInvoiceID & "' and PLD.POID = '" & POID & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

    End Class
End Namespace
