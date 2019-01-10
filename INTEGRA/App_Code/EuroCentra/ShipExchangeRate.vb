Imports Microsoft.VisualBasic
Imports System.Data


Namespace EuroCentra
Public Class ShipExchangeRate
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "ShipExchangeRate"
            m_strPrimaryFieldName = "RateID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        Private m_lRateID As Long

        Private m_dtCreationDate As Date
        Private m_dtMonthStartDate As Date
        Private m_dtMonthEndDate As Date
        Private m_dcShipExchangeRate As Decimal
        Private m_strCurrency As String

        Public Property RateID() As Long
            Get
                RateID = m_lRateID
            End Get
            Set(ByVal value As Long)
                m_lRateID = value
            End Set
        End Property

        Public Property ShipExchangeRate() As Decimal
            Get
                ShipExchangeRate = m_dcShipExchangeRate
            End Get
            Set(ByVal value As Decimal)
                m_dcShipExchangeRate = value
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

        Public Property MonthStartDate() As Date
            Get
                MonthStartDate = m_dtMonthStartDate
            End Get
            Set(ByVal value As Date)
                m_dtMonthStartDate = value
            End Set
        End Property

        Public Property MonthEndDate() As Date
            Get
                MonthEndDate = m_dtMonthEndDate
            End Get
            Set(ByVal value As Date)
                m_dtMonthEndDate = value
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
        Public Function SaveShipExchangeRate()
            Try
                MyBase.Save()
            Catch ex As Exception
            End Try
        End Function
        Public Function GetRateById(ByVal lRateID As Long)
            Try
                Return MyBase.GetById(lRateID)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetId()
            Try
                Return MyBase.GetCurrentId
            Catch ex As Exception
            End Try
        End Function

        Public Function GetAllRates() As DataTable
            Dim Str As String
            Str = "  select  "
            Str &= " '< ' + Convert(Varchar,MonthStartDate,106) + ' >' + ' To ' + '< ' + Convert(Varchar,MonthEndDate,106) + ' >' as MonthRate ,* "
            Str &= " from ShipExchangeRate order by RateID DESC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetRateEdit(ByVal RateID As Long) As DataTable
            Dim Str As String
            Str = "  select  "
            Str &= " '< ' + Convert(Varchar,MonthStartDate,106) + ' >' + ' To ' + '< ' + Convert(Varchar,MonthEndDate,106) + ' >' as MonthRate ,* "
            Str &= " from ShipExchangeRate "
            Str &= " where RateID=" & RateID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfShipRate(ByVal MonthStartDate As String, ByVal MonthEndDate As String)
            Dim str As String
            Try
                str = "   Select * from ShipExchangeRate  "
                str &= " where MonthStartDate >= '" & MonthStartDate & "' and MonthStartDate <= '" & MonthEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfShipRatenew(ByVal MonthStartDate As String, ByVal MonthEndDate As String, ByVal currency As String)
            Dim str As String
            Try
                str = "   Select * from ShipExchangeRate  "
                str &= " where currency = '" & currency & "' and MonthStartDate >= '" & MonthStartDate & "' and MonthStartDate <= '" & MonthEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function ExistingOfShipRateForReport(ByVal MonthStartDate As String, ByVal MonthEndDate As String)
            Dim str As String
            Try
                str = "   Select * from ShipExchangeRate  "
                str &= " where MonthStartDate between '" & MonthStartDate & "' and '" & MonthEndDate & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
        Public Function deletepodtl(ByVal RateID As Long)
            Dim str As String
            Try
                str = " delete from ShipExchangeRate where RateID= '" & RateID & "'"

                Return MyBase.GetDataTable(str)

            Catch ex As Exception
            End Try
        End Function
End Class
End Namespace