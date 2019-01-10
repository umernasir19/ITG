Imports System.Data
Namespace EuroCentra
    Public Class CuttingApproval
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "CuttingApproval"
            m_strPrimaryFieldName = "CuttingApprovalID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lCuttingApprovalID As Long
        Private m_dtCreationDate As Date
        Private m_lPOID As Long
        Private m_lMerchantID As Long
        Private m_strStatus As String
        ''---------------- Properties
        Public Property CuttingApprovalID() As Long
            Get
                CuttingApprovalID = m_lCuttingApprovalID
            End Get
            Set(ByVal value As Long)
                m_lCuttingApprovalID = value
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
        Public Property POID() As Long
            Get
                POID = m_lPOID
            End Get
            Set(ByVal value As Long)
                m_lPOID = value
            End Set
        End Property
        Public Property MerchantID() As Long
            Get
                MerchantID = m_lMerchantID
            End Get
            Set(ByVal value As Long)
                m_lMerchantID = value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = m_strStatus
            End Get
            Set(ByVal value As String)
                m_strStatus = value
            End Set
        End Property
        Public Function SaveCuttingApproval()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSamplingStyleNo(ByVal StyleNo As String)
            Dim str As String
            Try
                str = " select * from ECPSampling where StyleNo='" & StyleNo & "' "
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetPPSample(ByVal POID As String)
            Dim str As String
            Try
                str = " select * from TNAChart where POID='" & POID & "' and TNAProcessID=15 and Status = 'Completed'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function
        Public Function GetCDChart(ByVal POID As String)
            Dim str As String
            Try
                str = " select * from TNAChart where POID='" & POID & "' and TNAProcessID=27 and Status = 'Completed'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception
            End Try
        End Function

    End Class
End Namespace