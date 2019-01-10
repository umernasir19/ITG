Imports System.Data
    
Namespace EuroCentra

Public Class LoanMaster

   Inherits SQLManager
        Public Sub New()
            m_strTableName = "LoanMaster"
            m_strPrimaryFieldName = "LoanMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lLoanMasterID As Long
        Private m_lHRID As Long
        Private m_dtCreationDate As Date
        Private m_dPrincipalAmount As Decimal
        Private m_dInstallmentAmount As Decimal
        Private m_strInstallmentYearFrom As String
        Private m_strInstallmentMonthFrom As String
        Private m_strTotalInstallmenMonth As String
        Private m_bStatus As Boolean
        ''---------------- Properties
        Public Property LoanMasterID() As Long
            Get
                LoanMasterID = m_lLoanMasterID
            End Get
            Set(ByVal value As Long)
                m_lLoanMasterID = value
            End Set
        End Property
        Public Property HRID() As Long
            Get
                HRID = m_lHRID
            End Get
            Set(ByVal value As Long)
                m_lHRID = value
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
        Public Property PrincipalAmount() As Decimal
            Get
                PrincipalAmount = m_dPrincipalAmount
            End Get
            Set(ByVal value As Decimal)
                m_dPrincipalAmount = value
            End Set
        End Property
        Public Property InstallmentAmount() As Decimal
            Get
                InstallmentAmount = m_dInstallmentAmount
            End Get
            Set(ByVal value As Decimal)
                m_dInstallmentAmount = value
            End Set
        End Property
        Public Property InstallmentYearFrom() As String
            Get
                InstallmentYearFrom = m_strInstallmentYearFrom
            End Get
            Set(ByVal value As String)
                m_strInstallmentYearFrom = value
            End Set
        End Property
        Public Property InstallmentMonthFrom() As String
            Get
                InstallmentMonthFrom = m_strInstallmentMonthFrom
            End Get
            Set(ByVal value As String)
                m_strInstallmentMonthFrom = value
            End Set
        End Property
        Public Property TotalInstallmenMonth() As String
            Get
                TotalInstallmenMonth = m_strTotalInstallmenMonth
            End Get
            Set(ByVal value As String)
                m_strTotalInstallmenMonth = value
            End Set
        End Property
        Public Property Status() As Boolean
            Get
                Status = m_bStatus
            End Get
            Set(ByVal value As Boolean)
                m_bStatus = value
            End Set
        End Property
        Public Function SaveLoanMaster()
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
        Function GetLoanForView() As DataTable
            Dim Str As String
            Str = "select LM.*,HR.EmployeeName,HR.NICNo ,(case when LM.status=0 then 'Not Approved' else 'Approved' end ) as 'Statuss'  from LoanMaster LM  left join HRMain HR on HR.HRID =LM.HRID "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetLoanForViewNew(ByVal lHRID As Long) As DataTable
            Dim Str As String
            Str = "select LM.*,HR.EmployeeName,HR.NICNo ,(case when LM.status=0 then 'Not Approved' else 'Approved' end ) as 'Statuss'  from LoanMaster LM  left join HRMain HR on HR.HRID =LM.HRID "
            Str &= " where HR. HRID=" & lHRID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetNotApprovedLoanforView() As DataTable
            Dim Str As String
            Str = "select LM.*,HR.EmployeeName,HR.NICNo ,(case when LM.status=0 then 'Approved' else 'Approved' end ) as 'Statuss'  from LoanMaster LM  join HRMain HR on HR.HRID =LM.HRID where Status=0 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function GetApprovedLoanforView() As DataTable
            Dim Str As String
            Str = "select LM.*,HR.EmployeeName,HR.NICNo ,(case when LM.status=0 then 'Approved' else 'Approved' end ) as 'Statuss'  from LoanMaster LM  join HRMain HR on HR.HRID =LM.HRID where Status=1 "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
        Function UpdateLoan(ByVal lLoanMasterID As String)
            Dim str As String
            str = " update LoanMaster set Status= 1 where LoanMasterID='" & lLoanMasterID & "'"
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function DeleteFromLoan(ByVal lLoanMasterID As String)
            Dim str As String
            str = " Delete LoanDetail  where LoanMasterID=" & lLoanMasterID
            Try
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception
            End Try
        End Function
        Function GetValeForEdit(ByVal lLoanMasterID As Long) As DataTable
            Dim Str As String
            'Str = " select LM.*,HR.EmployeeName,HR.NICNo  from LoanMaster LM  join HRMain HR on HR.HRID =LM.HRID  where LM.LoanMasterID=" & lLoanMasterID
            Str = "  select LM.*,LD.*, HR.EmployeeName,HR.NICNo  from LoanMaster LM "
            Str &= " left join LoanDetail LD on Ld.LoanMasterID =LM.LoanMasterID "
            Str &= " left join HRMain HR on HR.HRID =LM.HRID  where LM.LoanMasterID=" & lLoanMasterID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception
            End Try
        End Function
 End Class
End Namespace

