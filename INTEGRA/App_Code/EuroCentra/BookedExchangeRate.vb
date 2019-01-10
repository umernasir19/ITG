Imports Microsoft.VisualBasic
Imports System.Data


Namespace EuroCentra
Public Class BookedExchangeRate
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "BookedExchangeRate"
            m_strPrimaryFieldName = "BookedExchangeRateID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lBookedExchangeRateID As Long

        Private m_dtCreationDate As Date
        Private m_dtShipStartDate As Date
        Private m_dtShipEndDate As Date
        Private m_dcBookedExchangeRate As Decimal
        Private m_lCurrencyId As Long
        Private m_strCurrency As String


        Public Property BookedExchangeRateID() As Long
            Get
                BookedExchangeRateID = m_lBookedExchangeRateID
            End Get
            Set(ByVal value As Long)
                m_lBookedExchangeRateID = value
            End Set
        End Property

        Public Property BookedExchangeRate() As Decimal
            Get
                BookedExchangeRate = m_dcBookedExchangeRate
            End Get
            Set(ByVal value As Decimal)
                m_dcBookedExchangeRate = value
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

        Public Property ShipStartDate() As Date
            Get
                ShipStartDate = m_dtShipStartDate
            End Get
            Set(ByVal value As Date)
                m_dtShipStartDate = value
            End Set
        End Property

        Public Property ShipEndDate() As Date
            Get
                ShipEndDate = m_dtShipEndDate
            End Get
            Set(ByVal value As Date)
                m_dtShipEndDate = value
            End Set
        End Property

        Public Property CurrencyId() As Long
            Get
                CurrencyId = m_lCurrencyId
            End Get
            Set(ByVal value As Long)
                m_lCurrencyId = value
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
        Public Function SaveBookedExchangeRate()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRateById(ByVal lBookedExchangeRateID As Long)
            Try
                Return MyBase.GetById(lBookedExchangeRateID)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCurrency()
            Dim Str As String
            Str = " select * from Currency  where CurrencyID=46 OR  CurrencyID=6 OR CurrencyID=149 order by CurrencyName asc "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetAllRates() As DataTable
            Dim Str As String
            Str = "  select  "
            Str &= " '< ' + Convert(Varchar,ShipStartDate,106) + ' >' + ' To ' + '< ' + Convert(Varchar,ShipEndDate,106) + ' >' as MonthRate ,* "
            Str &= " from BookedExchangeRate order by BookedExchangeRateID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetRateEdit(ByVal BookedExchangeRateID As Long) As DataTable
            Dim Str As String
            Str = "  select  "
            Str &= " '< ' + Convert(Varchar,ShipStartDate,106) + ' >' + ' To ' + '< ' + Convert(Varchar,ShipEndDate,106) + ' >' as MonthRate ,* "
            Str &= " from BookedExchangeRate "
            Str &= " where BookedExchangeRateID=" & BookedExchangeRateID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfBookedRate(ByVal ShipStartDate As String, ByVal ShipEndDate As String)
            Dim str As String
            Try
                str = "   Select * from BookedExchangeRate  "
                str &= " where ShipStartDate >= '" & ShipStartDate & "' and ShipEndDate <= '" & ShipEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfBookedRateWithCurrency(ByVal ShipStartDate As String, ByVal ShipEndDate As String, ByVal Currency As String)
            Dim str As String
            Try
                str = "   Select * from BookedExchangeRate  "
                str &= " where Currency='" & Currency & "' and ShipStartDate >= '" & ShipStartDate & "' and ShipEndDate <= '" & ShipEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfBookedRateForReports(ByVal ShipStartDate As String, ByVal ShipEndDate As String)
            Dim str As String
            Try
                str = "   Select * from BookedExchangeRate  "
                str &= " where ShipStartDate between '" & ShipStartDate & "' and '" & ShipEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfBookedRateForPOO(ByVal YearMonth As String)
            Dim str As String
            Try
                Dim Month As String = YearMonth.Substring(3, 2)
                Dim Year As String = YearMonth.Substring(6, 4)

                str = "   Select * from BookedExchangeRate  "
                str &= " where month(ShipStartDate)= '" & Month & "' and  year(ShipStartDate)='" & Year & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfBookedRateForPOONew(ByVal Year As String, ByVal Month As String)
            Dim str As String
            Try
               

                str = "   Select * from BookedExchangeRate  "
                str &= " where month(ShipStartDate)= '" & Month & "' and  year(ShipStartDate)='" & Year & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfBookedRateForPO(ByVal Month As String, ByVal Year As String)
            Dim str As String
            Try
                str = "   Select * from BookedExchangeRate  "
                str &= " where month(ShipStartDate)= '" & Month & "' and  year(ShipStartDate)='" & Year & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function

End Class
End Namespace