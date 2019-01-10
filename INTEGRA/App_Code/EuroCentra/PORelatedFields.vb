Imports System.Data

Namespace EuroCentra
    Public Class PORelatedFields
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "PORelatedFields"
            m_strPrimaryFieldName = "ID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub

        ''''''''''''''''''''''''''''''''''''''''''''''
        Private m_lID As Long
        Private m_strName As String
        Private m_strType As String
        Private m_bIsActive As Boolean
        ''---------------- Properties
        Public Property ID() As Long
            Get
                ID = m_lID
            End Get
            Set(ByVal value As Long)
                m_lID = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Name = m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = m_strType
            End Get
            Set(ByVal value As String)
                m_strType = value
            End Set
        End Property
        Public Property IsActive() As Boolean
            Get
                IsActive = m_bIsActive
            End Get
            Set(ByVal value As Boolean)
                m_bIsActive = value
            End Set
        End Property

        Public Function Save()
            Try
                MyBase.Save()
            Catch ex As Exception

            End Try
        End Function

        Public Function GetById(ByVal lColorId As Long)
            Try
                Return MyBase.GetById(lColorId)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetValues(ByVal Type As String, Optional ByVal POID As Long = 0) As DataTable
            Dim str As String

            If POID = 0 Then
                str = "Select *,Status='False' from PORelatedFields where Type='" & Type & "'"
            Else
                Select Case Type
                    Case Is = "Payment Type"
                        'str = " Select flds.*,(case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
                        'str &= " from PORelatedFields Flds left Join PurchaseOrder PO On PO.PaymentType=Flds.ID"
                        'str &= " where Type='Payment Type'"
                        str = "Select *,Status='False' from PORelatedFields where Type='" & Type & "'"
                    Case Is = "Payment Mode"
                        'str = " Select flds.*,(case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
                        'str &= " from PORelatedFields Flds left Join PurchaseOrder PO On PO.PaymentMode=Flds.ID"
                        'str &= " where Type='Payment Mode'"
                        str = "Select *,Status='False' from PORelatedFields where Type='" & Type & "'"
                    Case Is = "Shipment Mode"
                        'str = " Select flds.*,(case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
                        'str &= " from PORelatedFields Flds left Join PurchaseOrder PO On PO.ShipmentMode=Flds.ID"
                        'str &= " where Type='Shipment Mode'"
                        str = "Select *,Status='False' from PORelatedFields where Type='" & Type & "'"
                    Case Is = "Delivery Type"
                        'str = " Select flds.*,(case ISNull(PONo,'') when '' then 'False' else 'True' end )as Status"
                        'str &= " from PORelatedFields Flds left Join PurchaseOrder PO On PO.DeliveryType=Flds.ID"
                        'str &= " where Type='Delivery Type'"
                        str = "Select *,Status='False' from PORelatedFields where Type='" & Type & "'"
                End Select
            End If
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getShipmentMod()
            Dim str As String
            str = "Select * from PORelatedFields  where Type='Shipment Mode'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function getMod(ByVal TypeMod As String, ByVal Name As String)
            Dim str As String
            Dim ModeId As Long
            str = "Select id from PORelatedFields  where Type='" & TypeMod & "' and Name='" & Name & "'"
            Try
                ModeId = MyBase.GetScaler(str)
                If ModeId = 0 Then
                    str = "Insert into PORelatedFields(Name,Type) values('" & Name & "','" & TypeMod & "')"
                    MyBase.ExecuteNonQuery(str)
                    Return MyBase.GetCurrentId
                Else
                    Return MyBase.GetScaler(str)
                End If
            Catch ex As Exception
            End Try
        End Function
        Function GetShipmentMode()
            Try
                Dim str As String
                str = "Select * from PORelatedFields where Type='Shipment Mode'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPaymentTerm()
            Try
                Dim str As String
                str = "Select * from PORelatedFields where Type='Payment Type'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetDeliveryTerm()
            Try
                Dim str As String
                str = "Select * from PORelatedFields where Type='Delivery Type'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetShippmentTerm()
            Try
                Dim str As String
                str = "Select * from PORelatedFields where Type='Shipment Term'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Function deletepodtl(ByVal ID As Long)
            Try
                Dim str As String
                str = "Delete from PORelatedFields where ID='" & ID & "'"
                MyBase.ExecuteNonQuery(str)
            Catch ex As Exception

            End Try
        End Function
        Function GetPaymentTermForEdit(ByVal ID As Long)
            Try
                Dim str As String
                str = "Select * from PORelatedFields where ID='" & ID & "'"
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace