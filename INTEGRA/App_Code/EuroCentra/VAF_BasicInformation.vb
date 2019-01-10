Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Namespace EuroCentra
    Public Class VAF_BasicInformation
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "VAF_BasicInformation"
            m_strPrimaryFieldName = "VAFID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lVAFID As Long
        Private m_lSupplierID As Long
        Private m_lYearID As Long
        Private m_strCode As String
        Private m_strCorporateAddress As String
        Private m_strCompany As String
        Private m_dtCreationDate As Date
        Private m_strSupplierStatus As String
        Private m_strRemarks As String
        Public Property CreationDate() As Date
            Get
                CreationDate = m_dtCreationDate
            End Get
            Set(ByVal value As Date)
                m_dtCreationDate = value
            End Set
        End Property
        Public Property SupplierStatus() As String
            Get
                SupplierStatus = m_strSupplierStatus
            End Get
            Set(ByVal value As String)
                m_strSupplierStatus = value
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

        Public Property VAFID() As Long
            Get
                VAFID = m_lVAFID
            End Get
            Set(ByVal Value As Long)
                m_lVAFID = Value
            End Set
        End Property
        Public Property SupplierID() As Long
            Get
                SupplierID = m_lSupplierID
            End Get
            Set(ByVal Value As Long)
                m_lSupplierID = Value
            End Set
        End Property
        Public Property YearID() As Long
            Get
                YearID = m_lYearID
            End Get
            Set(ByVal Value As Long)
                m_lYearID = Value
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
        Public Property CorporateAddress() As String
            Get
                CorporateAddress = m_strCorporateAddress
            End Get
            Set(ByVal value As String)
                m_strCorporateAddress = value
            End Set
        End Property
        Public Property Company() As String
            Get
                Company = m_strCompany
            End Get
            Set(ByVal value As String)
                m_strCompany = value
            End Set
        End Property
        Public Function SaveVAF()
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
        Public Function View1(ByVal SupplierID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VF join Vender V on V.VenderLibraryID=VF.SupplierID "
            Str &= " join Years y on y.YearID=VF.YearID"
            Str &= " where VF.SupplierID=" & SupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ViewEntered() As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VF join Vender V on V.VenderLibraryID=VF.SupplierID "
            Str &= " join Years y on y.YearID=VF.YearID"
            Str &= " order by V.VenderName ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function View() As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VF join Vender V on V.VenderLibraryID=VF.SupplierID "
            Str &= " order by V.VenderName ASC "
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_BasicInformation(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VF join Vender V on V.VenderLibraryID=VF.SupplierID "
            Str &= " where VF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateVAF_BasicInformation(ByVal VAFID As Long, ByVal Code As String, ByVal SupplierStatus As String, ByVal Remarks As String)
            Dim Str As String
            Str = " Update VAF_BasicInformation set Code='" & Code & "', SupplierStatus='" & SupplierStatus & "', Remarks='" & Remarks & "' "
            Str &= " where VAFID=" & VAFID
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_Business(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_Business VAF_Bu on VAF.VAFID=VAF_Bu.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_Product(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_Product VAF_Pr on VAF.VAFID=VAF_Pr.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_PrimaryContact(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_PrimaryContact VAF_PC on VAF.VAFID=VAF_PC.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_HRDetail(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_HRDetail VAF_HR on VAF.VAFID=VAF_HR.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_HRBreakdown(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_HRBreakdown VAF_HB on VAF.VAFID=VAF_HB.VAFID"
            Str &= " join V_Department Dep on Dep.DeptID=VAF_HB.DeptID "
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_Capacities(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_Capacities VAF_C on VAF.VAFID=VAF_C.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_GeneralInformation(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_GeneralInformation VAF_GI on VAF.VAFID=VAF_GI.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_TopCustomer(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_TopCustomer VAF_TC on VAF.VAFID=VAF_TC.VAFID"
            Str &= " join Countries C on C.Country_id=VAF_TC.Country_id"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_PDInfo(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_PDInfo VAF_PD on VAF.VAFID=VAF_PD.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_PreTreatment(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_PreTreatment VAF_PT on VAF.VAFID=VAF_PT.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_MachineTechnical(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_MachineTechnical VAF_MT on VAF.VAFID=VAF_MT.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_DyeingSpeciality(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_DyeingSpeciality VAF_DS on VAF.VAFID=VAF_DS.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_EmbellishmentSpecialities(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_EmbellishmentSpecialities VAF_ES on VAF.VAFID=VAF_ES.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
       
        Public Function EditVAF_StitchingLineMachine(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_StitchingLineMachine VAF_SL on VAF.VAFID=VAF_SL.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_ConceptualDesign(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_ConceptualDesign VAF_CD on VAF.VAFID=VAF_CD.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function EditVAF_Sampling(ByVal VAFID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VAF "
            Str &= " join VAF_Sampling VAF_S on VAF.VAFID=VAF_S.VAFID"
            Str &= " where VAF.VAFID=" & VAFID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateDept(ByVal Department As String)
            Dim Str As String
            Str = "insert into V_Department (Department) VALUES ('" + Department + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateCapabilities(ByVal Capabilities As String)
            Dim Str As String
            Str = "insert into V_Capabilities (Capabilities) VALUES ('" + Capabilities + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateV_Machine(ByVal MachineName As String)
            Dim Str As String
            Str = "insert into V_Machine (MachineName) VALUES ('" + MachineName + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateV_Business(ByVal Business As String)
            Dim Str As String
            Str = "insert into V_Business (Business) VALUES ('" + Business + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateV_Product(ByVal Product As String)
            Dim Str As String
            Str = "insert into V_Product (Product) VALUES ('" + Product + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateV_PD(ByVal PDinfo As String)
            Dim Str As String
            Str = "insert into V_PD (PDinfo) VALUES ('" + PDinfo + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateV_PreTreatment(ByVal PreTreatment As String)
            Dim Str As String
            Str = "insert into V_PreTreatment (PreTreatment) VALUES ('" + PreTreatment + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function UpdateV_Dyeing(ByVal Dyeing As String)
            Dim Str As String
            Str = "insert into V_Dyeing (Dyeing) VALUES ('" + Dyeing + "') "
            Try
                MyBase.ExecuteNonQuery(Str)
            Catch ex As Exception

            End Try
        End Function
        Public Function ChkSupplier(ByVal SupplierID As Long) As DataTable
            Dim Str As String
            Str = " select * from VAF_BasicInformation VF "
            Str &= " where VF.SupplierID=" & SupplierID
            Try
                Return MyBase.GetDataTable(Str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace