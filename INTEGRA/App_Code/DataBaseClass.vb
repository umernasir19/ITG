Imports Microsoft.VisualBasic

Public Class DataBaseClass
    Inherits SQLManager
    Sub GetBackup(ByVal path As String, ByVal FileName As String)
        Dim Str As String
        Dim File As String = path + FileName
        Str = "backup database integra to DISK='" & File & "' "
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception
        End Try
    End Sub

    Function GetData(ByVal PONo As String, ByVal VenderID As Long, ByVal CustomerID As Long)
        Dim Str As String
        Str = "Select * from PurchaseOrderDetail POD,Style S  where S.StyleID=POD.StyleID and POID in("
        Str &= " Select PO.POID from PurchaseOrder PO where PONO='" & PONo & "' and SupplierID=" & VenderID & " and CustomerID=" & CustomerID & ")"
        Try
            Return MyBase.GetDataTable(Str)
        Catch ex As Exception

        End Try
    End Function
    Function insertData(ByVal CreationDate As Date, ByVal POID As Long, ByVal BoxNo As String, ByVal DateDatum As Date, ByVal ArticleNo As String, ByVal InspQty As Decimal, ByVal AQL As Decimal, ByVal TimeIn As String, ByVal TimeOut As String)
        Dim Str As String
        Str = " Insert into FinalInspection"
        Str &= " (CreationDate,POID,BoxNo,DateDatum,ArticleNo,InspQty,AQL,TimeIn,TimeOut)"
        Str &= " values('" & CreationDate & "', '" & POID & "', '" & BoxNo & "', '" & DateDatum & "','" & ArticleNo & "',  '" & InspQty & "', '" & AQL & "', '" & TimeIn & "', '" & TimeOut & "')"
        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
    Function insertDataDetail(ByVal FinalInspectionID As Long, ByVal StyleID As Long, ByVal InspectQty As Decimal, ByVal AQLQTY As Decimal)
        Dim Str As String
        Str = " Insert into FinalInspectionDetail(FinalInspectionID,StyleID,InspectQty,AQLQTY)"
        Str &= " values(" & FinalInspectionID & ", " & StyleID & ", " & InspectQty & ", " & AQLQTY & ")"

        Try
            MyBase.ExecuteNonQuery(Str)
        Catch ex As Exception

        End Try
    End Function
End Class
