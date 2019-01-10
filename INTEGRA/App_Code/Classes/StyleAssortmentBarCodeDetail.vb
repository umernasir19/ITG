Imports Microsoft.VisualBasic
Imports System.Data
Namespace classes
    Public Class StyleAssortmentBarCodeDetail

        Inherits SQLManager
        Public Sub New()
            m_strTableName = "StyleAssortmentBarCodeDetail"
            m_strPrimaryFieldName = "StyleAssortmentBarCodeDetailID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lStyleAssortmentBarCodeDetailID As Long
        Private m_lJobOrderID As Long
        Private m_lJoborderDetailid As Long
        Private m_strMerchandiser As String
        Private m_strCustomer As String
        Private m_strJobNo As String
        Private m_strStyle As String
        Private m_strItem As String
        Private m_strBrand As String
        ' Private m_imgBarcode As Object
        Private m_lBarCodeCount As Long
        Private m_dtCreationDate As Date
        Private m_strCode As String

        Private m_lStyleAssortmentMasterID As Long
        Private m_lSizeRangeID As Long
        Private m_lSizeDatabaseID As Long
        Private m_strSize As String
        Private m_dTotalOrderQty As Decimal
        Private m_dTotalSizeQty As Decimal
        Private m_bStitching As Boolean
        Private m_bWashing As Boolean
        Private m_bFinishing As Boolean
        Private m_bPacking As Boolean
        Private m_dExtra As Decimal
        'Private m_imgBarcode As Object
        Private m_strLineNumber As String
        Private m_lStyleAssortmentDetailID As Long
        Public Property StyleAssortmentDetailID() As Long
            Get
                StyleAssortmentDetailID = m_lStyleAssortmentDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentDetailID = Value
            End Set
        End Property
        Public Property LineNumber() As String
            Get
                LineNumber = m_strLineNumber
            End Get
            Set(ByVal Value As String)
                m_strLineNumber = Value
            End Set
        End Property
        
        Public Property StyleAssortmentBarCodeDetailID() As Long
            Get
                StyleAssortmentBarCodeDetailID = m_lStyleAssortmentBarCodeDetailID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentBarCodeDetailID = Value
            End Set
        End Property
        Public Property JobOrderID() As Long
            Get
                JobOrderID = m_lJobOrderID
            End Get
            Set(ByVal Value As Long)
                m_lJobOrderID = Value
            End Set
        End Property
        Public Property JoborderDetailid() As Long
            Get
                JoborderDetailid = m_lJoborderDetailid
            End Get
            Set(ByVal Value As Long)
                m_lJoborderDetailid = Value
            End Set
        End Property
        Public Property Merchandiser() As String
            Get
                Merchandiser = m_strMerchandiser
            End Get
            Set(ByVal value As String)
                m_strMerchandiser = value
            End Set
        End Property
        Public Property Customer() As String
            Get
                Customer = m_strCustomer
            End Get
            Set(ByVal value As String)
                m_strCustomer = value
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
        Public Property Style() As String
            Get
                Style = m_strStyle
            End Get
            Set(ByVal value As String)
                m_strStyle = value
            End Set
        End Property
        Public Property Item() As String
            Get
                Item = m_strItem
            End Get
            Set(ByVal value As String)
                m_strItem = value
            End Set
        End Property
        Public Property Brand() As String
            Get
                Brand = m_strBrand
            End Get
            Set(ByVal value As String)
                m_strBrand = value
            End Set
        End Property
        'Public Property Barcode() As Object
        '    Get
        '        Barcode = m_imgBarcode
        '    End Get
        '    Set(ByVal value As Object)
        '        m_imgBarcode = value
        '    End Set
        'End Property
        Public Property BarCodeCount() As Long
            Get
                BarCodeCount = m_lBarCodeCount
            End Get
            Set(ByVal Value As Long)
                m_lBarCodeCount = Value
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
        Public Property Code() As String
            Get
                Code = m_strCode
            End Get
            Set(ByVal value As String)
                m_strCode = value
            End Set
        End Property
        Public Property StyleAssortmentMasterID() As Long
            Get
                StyleAssortmentMasterID = m_lStyleAssortmentMasterID
            End Get
            Set(ByVal Value As Long)
                m_lStyleAssortmentMasterID = Value
            End Set
        End Property
        Public Property SizeRangeID() As Long
            Get
                SizeRangeID = m_lSizeRangeID
            End Get
            Set(ByVal Value As Long)
                m_lSizeRangeID = Value
            End Set
        End Property
        Public Property SizeDatabaseID() As Long
            Get
                SizeDatabaseID = m_lSizeDatabaseID
            End Get
            Set(ByVal Value As Long)
                m_lSizeDatabaseID = Value
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
        Public Property TotalOrderQty() As Decimal
            Get
                TotalOrderQty = m_dTotalOrderQty
            End Get
            Set(ByVal value As Decimal)
                m_dTotalOrderQty = value
            End Set
        End Property
        Public Property TotalSizeQty() As Decimal
            Get
                TotalSizeQty = m_dTotalSizeQty
            End Get
            Set(ByVal value As Decimal)
                m_dTotalSizeQty = value
            End Set
        End Property
        Public Property Stitching() As Boolean
            Get
                Stitching = m_bStitching
            End Get
            Set(ByVal Value As Boolean)
                m_bStitching = Value
            End Set
        End Property
        Public Property Washing() As Boolean
            Get
                Washing = m_bWashing
            End Get
            Set(ByVal Value As Boolean)
                m_bWashing = Value
            End Set
        End Property
        Public Property Finishing() As Boolean
            Get
                Finishing = m_bFinishing
            End Get
            Set(ByVal Value As Boolean)
                m_bFinishing = Value
            End Set
        End Property
        Public Property Packing() As Boolean
            Get
                Packing = m_bPacking
            End Get
            Set(ByVal Value As Boolean)
                m_bPacking = Value
            End Set
        End Property


        Public Property Extra() As Decimal
            Get
                Extra = m_dExtra
            End Get
            Set(ByVal Value As Decimal)
                m_dExtra = Value
            End Set
        End Property
        'Public Property Barcode() As Object
        '    Get
        '        Barcode = m_imgBarcode
        '    End Get
        '    Set(ByVal value As Object)
        '        m_imgBarcode = value
        '    End Set
        'End Property
        Public Function SaveStyleAssortmentBarCodeDetail()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Function GetID()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCompleteData(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long) As DataTable
            Dim str As String
            str = " select *,(SD.Qty+SD.ExtraQty) AS Qtyy,(SD.Asortqty+SD.ExtraQty) AS Asortqtyy from StyleAssortmentMaster  SM"
            str &= "  join  StyleAssortmentDetail  SD on SM.StyleAssortmentMasterID=SD.StyleAssortmentMasterID"
            str &= "   where SM.Joborderid = '" & JoborderID & "'  And SM.JoborderDetailid =  '" & JoborderdetailID & "' And SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCompleteDataForNew(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long) As DataTable
            Dim str As String
            str = " select *,(SD.TotalQty ) AS Qtyy,ISNULL(SAD.LineNumber ,'') AS LineNumberr"
            str &= "  from DPCuttingProMaster "
            str &= "  SM"
            str &= "  join  DPCuttingProdetail  SD on SM.CuttingProMasterID=SD.CuttingProMasterID"
            str &= "  join StyleAssortmentDetail SAD on SAD.StyleAssortmentDetailID =SD.StyleAssortmentDetailID"
            str &= "  AND SAD.StyleAssortmentMasterID =SD.StyleAssortmentMasterID "
            str &= "   where SM.Joborderid = '" & JoborderID & "'  And SM.JoborderDetailid =  '" & JoborderdetailID & "' And SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCompleteDataOnEdit(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long) As DataTable
            Dim str As String
            str = " select * from StyleAssortmentMaster  SM"
            str &= "  join  StyleAssortmentDetail  SD on SM.StyleAssortmentMasterID=SD.StyleAssortmentMasterID"
            str &= "   where SM.Joborderid = '" & JoborderID & "'  And SM.JoborderDetailid =  '" & JoborderdetailID & "' And SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetEditData(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long, ByVal Size As String) As DataTable
            Dim str As String
            str = " select top 1 BarCodeCount from StyleAssortmentBarCodeDetail  SM"
            str &= "  where Joborderid = '" & JoborderID & "'  And JoborderDetailid =  '" & JoborderdetailID & "' And StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' and SM.Size='" & Size & "' order by SM.StyleAssortmentBarCodeDetailID desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSizeWiseData(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long, ByVal Size As String) As DataTable
            Dim str As String
            str = " select * from StyleAssortmentMaster  SM"
            str &= " join  StyleAssortmentDetail  SD on SM.StyleAssortmentMasterID=SD.StyleAssortmentMasterID"
            str &= "  where SM.Joborderid = '" & JoborderID & "'  And SM.JoborderDetailid =  '" & JoborderdetailID & "' And SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "'  SD.Size = '" & Size & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Public Function Gettestdata(ByVal Code As String) As DataTable
            Dim str As String
            str = " select * from StyleAssortmentBarCodeDetail  SM"
            str &= "  where SM.Code = '" & Code & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GettestdataSecondPage(ByVal Code As String) As DataTable
            Dim str As String
            'str = " select *,isnull((select (SUM(SAD.ExtraQty)+SUM(SAD.Asortqty ))    from  StyleAssortmentDetail SAD WHERE SAD.StyleAssortmentMasterID   =SM.StyleAssortmentMasterID  ),0) AS OrderQty  from StyleAssortmentBarCodeDetail  SM"
            'str &= "  join JobOrderdatabase JO ON JO.Joborderid =SM .Joborderid "
            'str &= "  where SM.Stitching='0' and SM.Code = '" & Code & "'"


            str = " select *,isnull((select SUM(SAD.Totalqty)   from DPCuttingProMaster SAM join DPCuttingProDetail SAD on SAD.CuttingProMasterID  =SAM.CuttingProMasterID WHERE SAM.JoborderDetailid =SM.JoborderDetailid),0) AS OrderQty  from StyleAssortmentBarCodeDetail  SM"
            str &= "  join JobOrderdatabase JO ON JO.Joborderid =SM .Joborderid "
            str &= "  where SM.Stitching='0' and SM.Code = '" & Code & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function UpdateDataStitchingManual(ByVal Code As String, ByVal UserID As Long, ByVal CreationDatee As Date)
            Dim Str As String
            Str = " insert into TFAStitching"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as StitchingBit"
            Str &= " '" & CreationDatee & "' ,'" & UserID & "' as UserID"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Stitching='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataStitchingManualNew(ByVal Code As String, ByVal UserID As Long, ByVal CreationDatee As Date, ByVal LineNo As String)
            Dim Str As String
            Str = " insert into TFAStitching"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as StitchingBit,"
            Str &= " '" & CreationDatee & "' as CreationDate,'" & UserID & "' as UserID,'" & LineNo & "' as Line_No"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Stitching='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataWashingManual(ByVal Code As String, ByVal UserID As Long, ByVal CreationDatee As Date)
            Dim Str As String
            Str = " insert into TFAWashing"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as WashingBit"
            Str &= " '" & CreationDatee & "' ,'" & UserID & "' as UserID"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Washing='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataStitchingNew(ByVal Code As String, ByVal UserID As Long, ByVal LineNo As String)
            Dim Str As String
            Str = " insert into TFAStitching"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as StitchingBit"
            Str &= " ,Getdate() as CreationDate ,'" & UserID & "' as UserID,'" & LineNo & "' as Line_No"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Stitching='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataStitching(ByVal Code As String, ByVal UserID As Long)
            Dim Str As String
            Str = " insert into TFAStitching"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as StitchingBit"
            Str &= " ,Getdate() as CreationDate ,'" & UserID & "' as UserID"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Stitching='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataWashing(ByVal Code As String, ByVal UserID As Long)
            Dim Str As String
            Str = " insert into TFAWashing"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as WashingBit"
            Str &= " ,Getdate() as CreationDate ,'" & UserID & "' as UserID"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Washing='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataRecevWashing(ByVal Code As String, ByVal UserID As Long)
            Dim Str As String
            Str = " insert into TFAWashingRecv"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as WashingRecvBit"
            Str &= " ,Getdate() as CreationDate ,'" & UserID & "' as UserID"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Washing='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateDataRecevFinishing(ByVal Code As String, ByVal UserID As Long)
            Dim Str As String
            Str = " insert into TFAFinishing"
            Str &= " select StyleAssortmentBarCodeDetailID,Joborderid,JoborderDetailid"
            Str &= " ,StyleAssortmentMasterID,SizeRangeID,SizeDatabaseID,Code,Merchandiser,"
            Str &= " JobNo,TotalOrderQty,Style,Item,Brand,Size as Sizes,TotalSizeQty,'1' as FinishingBit"
            Str &= " ,Getdate() as CreationDate ,'" & UserID & "' as UserID"
            Str &= "  from StyleAssortmentBarCodeDetail SM"
            Str &= " where SM.Finishing='0' and SM.Code = '" & Code & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCompleteDataOnEditNew(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long) As DataTable
            Dim str As String
            str = " select *,(SD.Qty+SD.ExtraQty) AS Qtyy,(SD.Asortqty+SD.ExtraQty) AS Asortqtyy from StyleAssortmentMaster  SM"
            str &= "  join  StyleAssortmentDetail  SD on SM.StyleAssortmentMasterID=SD.StyleAssortmentMasterID"
            str &= "   where SM.Joborderid = '" & JoborderID & "'  And SM.JoborderDetailid =  '" & JoborderdetailID & "' And SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetCompleteDataOnEditNew2(ByVal StyleAssortmentMasterID As Long, ByVal JoborderID As Long, ByVal JoborderdetailID As Long) As DataTable
            Dim str As String
            str = " select *,sd.TotalQty AS Asortqtyy from DPCuttingProMaster  SM"
            str &= "  join  DPCuttingProDetail  SD on SM.CuttingProMasterID=SD.CuttingProMasterID"
            str &= "   where SM.Joborderid = '" & JoborderID & "'  And SM.JoborderDetailid =  '" & JoborderdetailID & "' And SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ChkBarcodeTableHavedata(ByVal StyleAssortmentMasterID As Long) As DataTable
            Dim str As String
            str = " select * from StyleAssortmentBarCodeDetail SM"
            str &= "   where  SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ChkBarcodeTableHavedataNew(ByVal StyleAssortmentMasterID As Long, ByVal StyleAssortmentDetailID As Long, ByVal LineNumber As String) As DataTable
            Dim str As String
            str = " select * from StyleAssortmentBarCodeDetail SM"
            str &= "   where  SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' and SM.StyleAssortmentDetailID= '" & StyleAssortmentDetailID & "' and SM.LineNumber= '" & LineNumber & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ChkBarcodeTableHavedataNewWithOutLine(ByVal StyleAssortmentMasterID As Long, ByVal StyleAssortmentDetailID As Long) As DataTable
            Dim str As String
            str = " select * from StyleAssortmentBarCodeDetail SM"
            str &= "   where  SM.StyleAssortmentMasterID = '" & StyleAssortmentMasterID & "' and SM.StyleAssortmentDetailID= '" & StyleAssortmentDetailID & "' "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function

        Function UpdateStyleAssortmentBarCodeDetailLineNo(ByVal LineNumber As String, ByVal StyleAssortmentMasterID As Long, ByVal StyleAssortmentDetailID As Long)
            Dim Str As String
            Str = " update StyleAssortmentBarCodeDetail set LineNumber='" & LineNumber & "' where StyleAssortmentMasterID='" & StyleAssortmentMasterID & "' and StyleAssortmentDetailID='" & StyleAssortmentDetailID & "'"
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception
            End Try
        End Function
        'Function UpdateStyleAssortmentBarCodeDetail(ByVal ltblBankMstID As Long)
        '    Dim Str As String
        '    Str = " update StyleAssortmentBarCodeDetail set Stitching=1 where tblBankMstID=" & ltblBankMstID
        '    Try
        '        MyBase.ExecuteNonQuery(Str)
        '    Catch ex As Exception
        '    End Try
        'End Function

    End Class
End Namespace
