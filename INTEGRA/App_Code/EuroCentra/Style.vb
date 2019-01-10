Imports System.Data

Namespace EuroCentra
    Public Class Style
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "Style"
            m_strPrimaryFieldName = "StyleID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lStyleID As Long
        Private m_strStyleNo As String
        Private m_strItemDescription As String
        Private m_strArticle As String
        Private m_strColorway As String
        Private m_strSize As String
        Private m_strItemPrice As Decimal
        Private m_bIsactive As Boolean

        ''---------------- Properties
        Public Property StyleID() As Long
            Get
                StyleID = m_lStyleID
            End Get
            Set(ByVal value As Long)
                m_lStyleID = value
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
        Public Property ItemDescription() As String
            Get
                ItemDescription = m_strItemDescription
            End Get
            Set(ByVal value As String)
                m_strItemDescription = value
            End Set
        End Property
        Public Property Article() As String
            Get
                Article = m_strArticle
            End Get
            Set(ByVal value As String)
                m_strArticle = value
            End Set
        End Property
        Public Property Colorway() As String
            Get
                Colorway = m_strColorway
            End Get
            Set(ByVal value As String)
                m_strColorway = value
            End Set
        End Property
        Public Property Size() As String
            Get
                Size = m_strSize
            End Get
            Set(ByVal value As String)
                m_strSize = value
            End Set
        End Property
        Public Property ItemPrice() As Decimal
            Get
                ItemPrice = m_strItemPrice
            End Get
            Set(ByVal value As Decimal)
                m_strItemPrice = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsactive
            End Get
            Set(ByVal value As Boolean)
                m_bIsactive = value
            End Set
        End Property

        Public Function SaveStyle()
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

        Public Function GetStyleById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleData(ByVal StyleID As Integer) As DataTable
            Dim str As String
            str = "select * from Style where StyleID=" & StyleID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetStyle() As DataTable
            Dim str As String
            str = "Select StyleID,Article+'/'+ITemDescription as StyleNo from Style "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleSampleDev(ByVal CustomerID As Long, ByVal SamplesDevelopmentID As Long) As DataTable
            Dim str As String
            '  str = "Select * from SampleDevelopment where CustomerID=" & CustomerID & " and DevelopmentStartDate='" & DevelopmentStartDate & "' and DevelopmentdeadlineDate='" & DevelopmentdeadlineDate & "'"
            str = "Select Article,SamplesDevelopmentID  From SampleDevelopment where SamplesDevelopmentID=" & SamplesDevelopmentID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByInspection(ByVal POID As Long) As DataTable
            Dim str As String
            ' str = "Select S.StyleID,Article+'/'+ITemDescription as Article from Style S Join Inspection I on I.StyleID=S.StyleID where POID=" & POID & " Group By S.StyleID,Article,ITemDescription "
            str = "Select S.StyleID,Article+'/'+ITemDescription as Article from PurchaseOrderdetail POD Join Style S on POD.StyleID=S.StyleID where POID=" & POID & " and S.StyleiD in(Select Distinct StyleID from Inspection where POID=" & POID & ")"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByInspectionNew(ByVal POID As Long) As DataTable
            Dim str As String
            str = " Select S.StyleID,Article+'/'+ITemDescription as Article from "
            str &= " PurchaseOrderdetail POD Join Style S on POD.StyleID=S.StyleID "
            str &= " where POID='" & POID & "' and S.StyleiD in(Select Distinct StyleID"
            str &= " from InspectionDetailNew where POID='" & POID & "')"

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetStyleCombo(ByVal POID As Long) As DataTable
            Dim str As String
            str = "Select S.StyleID,S.Article"
            str &= " from PurchaseOrderDetail POD Join  Style S on POD.StyleID=S.StyleID where POID=" & POID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function GetStyleByPOID(ByVal POID As Long) As DataTable
            Dim str As String
            str = "Select S.StyleID,Article+'/ Size:'+ Size as StyleNo"
            str &= " from PurchaseOrderDetail POD Join  Style S on POD.StyleID=S.StyleID where POID=" & POID

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetArticleByPOID(ByVal POID As Long) As DataTable
            Dim str As String
            str = "Select POID,Article from PurchaseOrderDetail POD Join  Style S on POD.StyleID=S.StyleID where POID=" & POID & " Group by  POID,Article"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByPO(ByVal UserID As Long, ByVal RoleID As Long, Optional ByVal POID As Long = 0) As DataTable
            '(Optional ByVal POID As Long = 0) as function may lagana hai orignl k leye
            Dim str As String
            If POID = 0 Then
                ' str = "Select *,Status='False',PurchaseOrderDetailID=0 from Style "
                If RoleID = 1 Or RoleID = 4 Then
                    str = "Select *,Status='False',PurchaseOrderDetailID=0 from Style "
                Else
                    str = "Select S.*,Status='False',PurchaseOrderDetailID=0 from Style S"
                    str &= " join StyleRole SR on S.styleId=SR.StyleID where"
                    str &= " Userid='" & UserID & "' and Roleid='" & RoleID & "'"
                End If

            Else
                str = "Select  St.StyleID,StyleNo,ItemDescription,Article,Colorway,Size,ItemPrice ,ISnull(PODetailID,0)as PurchaseOrderDetailID,"
                str &= "(case IsNull(POID,0) when 0 then 'False' else 'True' end  )as Status"
                str &= " from Style St left Join PurchaseOrderDetail PO on PO.StyleID=St.StyleID   where POID=" & POID
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetStyleByStyleNo(ByVal StyleNo As String) As DataTable
            Dim str As String
            str = "Select *,Status='False',PurchaseOrderDetailID=0 from Style Where StyleNo in" & StyleNo & ""
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetlastRecord()
            Dim str As String
            str = "SELECT TOP 1 StyleID FROM Style ORDER BY StyleID DESC"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function SearchByArticleNo(ByVal ArticleNO As String)
            Dim str As String
            str = " select PO.POID,s.Article,PO.pono,PO.customerid,PO.supplierid,CustomerName,venderName from purchaseorder PO join purchaseorderdetail "
            str &= "  POD on PO.PoID=POD.POid join (Select CustomerID,CustomerName from Customer)as c on"
            str &= "  c.customerid=PO.CustomerId join (select venderLibraryID,VenderName from Vender)as v"
            str &= "  on v.venderLibraryID=PO.supplierid join  style S "
            str &= "  on s.styleid=pod.styleid where s.Article='" & ArticleNO & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Function StyleNoForPoPopu(ByVal UserID As String)
            Dim str As String
            If UserID = 26 Or UserID = 28 Or UserID = 93 Then
                str = "  select Distinct StyleNo from StyleMaster "

            Else
                str = " select Distinct S.StyleNo from StyleMaster S"
                str &= "  join PurchaseorderDetail POD on POD.StyleID=S.StyleID"
                str &= "  join Purchaseorder Po on Po.POID=POD.POID"
                str &= "  where Po.marchandID='" & UserID & "'"
            End If

          
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function


    End Class
End Namespace