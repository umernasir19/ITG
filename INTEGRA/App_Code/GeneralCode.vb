Imports Microsoft.VisualBasic

Public Class GeneralCode
    '------------- Function For Date
    Public Function GetDate(ByVal YourDate As String)
        Try
            Dim MyDate As Date
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = New Date(Year, Month, Day)
            Return MyDate
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDateNews(ByVal YourDate As String)
        Try
            Dim MyDate As String
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = Day & "/" & Month & "/" & Year 'New Date(Year, Month, Day)
            Return MyDate
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDateCr(ByVal YourDate As String)
        Try
            Dim MyDate As Date
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Month As String = YourDate.Substring(0, 2)
            Dim Day As String = YourDate.Substring(3, 2)
            MyDate = New Date(Year, Month, Day)
            Return MyDate
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDateW(ByVal YourDate As String)
        Try
            Dim MyDate As Date
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            If Month > 12 Then
                MyDate = New Date(Year, Day, Month)
            Else
                MyDate = New Date(Year, Month, Day)
            End If
            Return MyDate
        Catch ex As Exception
            Return Date.Now.Date()
        End Try
    End Function
    Public Function GetDateN(ByVal YourDate As String)
        Try
            Dim MyDate As Date
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = New Date(Year, Month, Day)
            Return MyDate
        Catch ex As Exception

        End Try
    End Function
    Public Function GetDateForPOPopup(ByVal YourDate As String)
        Try
            Dim MyDate As Date
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = New Date(Day, Month, Year)
            Return MyDate
        Catch ex As Exception

        End Try
    End Function

    Public Function GetDateByMonth(ByVal YourDate As String)
        Try
            Dim MyDate As String
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = Month + "/" + Day + "/" + Year
            Return MyDate
        Catch ex As Exception
        End Try
    End Function

    Public Function GetYear(ByVal YourDate As String)
        Try
            Dim MyDate As String
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = Month + "/" + Day + "/" + Year
            Return Year
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDateFormatNewr(ByVal YourDate As String)
        Try
            Dim MyDate As String
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            'MyDate = Month & "/" & Day & "/" & Year
            MyDate = Year & "/" & Month & "/" & Day
            Return MyDate
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDatee(ByVal YourDate As String)
        Try
            Dim MyDate As String
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = Day + "/" + Month + "/" + Year
            Return MyDate
        Catch ex As Exception
        End Try
    End Function
    Public Function GetDateFormat(ByVal YourDate As String)
        Try
            Dim MyDate As String
            Dim Year As String = YourDate.Substring(6, 4)
            Dim Day As String = YourDate.Substring(0, 2)
            Dim Month As String = YourDate.Substring(3, 2)
            MyDate = Month & "/" & Day & "/" & Year
            'MyDate = Day & "/" & Month & "/" & Year
            Return MyDate
        Catch ex As Exception
        End Try
    End Function

End Class
