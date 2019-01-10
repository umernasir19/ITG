Imports Microsoft.VisualBasic
Imports System.Data
Namespace EuroCentra
    Public Class FabricationMaster
        Inherits SQLManager
        Public Sub New()
            m_strTableName = "FabricationMaster"
            m_strPrimaryFieldName = "FabricationMasterID"
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType
        End Sub
        Private m_lFabricationMasterID As Long
        Private m_lJobOrderID As Long
        Private m_lJoborderDetailid As Long
        Private m_dtFabricationDate As Date
        Private m_strColor As String
        Private m_strMCUnit As String
        Private m_dTotalCPD As Decimal
        Private m_dTotalGross As Decimal

        Public Property FabricationMasterID() As Long
            Get
                FabricationMasterID = m_lFabricationMasterID
            End Get
            Set(ByVal Value As Long)
                m_lFabricationMasterID = Value
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
        Public Property FabricationDate() As Date
            Get
                FabricationDate = m_dtFabricationDate
            End Get
            Set(ByVal value As Date)
                m_dtFabricationDate = value
            End Set
        End Property
        Public Property Color() As String
            Get
                Color = m_strColor
            End Get
            Set(ByVal value As String)
                m_strColor = value
            End Set
        End Property
        Public Property MCUnit() As String
            Get
                MCUnit = m_strMCUnit
            End Get
            Set(ByVal value As String)
                m_strMCUnit = value
            End Set
        End Property
        Public Property TotalCPD() As Decimal
            Get
                TotalCPD = m_dTotalCPD
            End Get
            Set(ByVal value As Decimal)
                m_dTotalCPD = value
            End Set
        End Property
        Public Property TotalGross() As Decimal
            Get
                TotalGross = m_dTotalGross
            End Get
            Set(ByVal value As Decimal)
                m_dTotalGross = value
            End Set
        End Property
        Public Function SaveFabricationMaster()
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
        Public Function GetMasterData(ByVal JobOrderId As Long, ByVal JobOrderDetailId As Long) As DataTable
            Dim str As String
            str = "  select * from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join ItemDatabase IDB on IDB.ItemDatabaseID=JOD.ItemDatabaseID"
            str &= "  where Jo.JobOrderId = '" & JobOrderId & "' And JoD.JobOrderDetailId =  '" & JobOrderDetailId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetMasterDataOtherthenThis(ByVal JobOrderId As Long, ByVal JobOrderDetailId As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = "  select * from JobOrderdatabase JO "
            str &= " join JobOrderdatabaseDetail JOd on JOD.JobOrderId=Jo.JobOrderId"
            str &= " join SeasonDatabase SD on SD.SeasonDatabaseID=Jo.SeasonDatabaseID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=Jo.CustomerDatabaseID"
            str &= " join BrandDatabase BD on BD.BrandDatabaseID=JO.BrandDatabaseID"
            str &= " join ItemDatabase IDB on IDB.ItemDatabaseID=JOD.ItemDatabaseID"
            str &= " where Jo.JobOrderId = '" & JobOrderId & "' And JoD.JobOrderDetailId <>  '" & JobOrderDetailId & "' and JOD.Style='" & Style & "'"
            str &= " and JoD.JobOrderDetailId not in  (Select JobOrderDetailId from FabricationMaster) "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        'Public Function GetGridDetailData(ByVal ItemDatabaseID As Long) As DataTable
        '    Dim str As String
        '    str = " Select isnull(FD.FabricationDetailID,0) as FabricationDetailID,IDB.ItemDatabaseID,FP.FabricPlacementID,FP.FabricPlacementName"
        '    str &= " from ItemDatabase IDB"
        '    str &= " join ItemDatabaseBodyPart IDBP on IDBP.ItemDatabaseID=IDB.ItemDatabaseID"
        '    str &= " join FabricPlacement FP on FP.FabricPlacementID=IDBP.FabricPlacementID"
        '    str &= " left join FabricationDetail FD on FD.FabricPlacementID=IDBP.FabricPlacementID"
        '    str &= " where IDB.ItemDatabaseID =  '" & ItemDatabaseID & "' "
        '    Try
        '        Return MyBase.GetDataTable(str)

        '    Catch ex As Exception

        '    End Try
        'End Function
        Public Function GetFabricType() As DataTable
            Dim str As String
            str = " Select * from FabricType"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetContent() As DataTable
            Dim str As String
            str = " select * from BlendDropdown"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function CheckExist(ByVal JobOrderId As Long, ByVal JobOrderDetailId As Long) As DataTable
            Dim str As String
            str = "  select * from FabricationMaster "
            str &= "  where  JobOrderID = '" & JobOrderId & "' and JoborderDetailid =  '" & JobOrderDetailId & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function getEdit(ByVal FabricationMasterID As Long) As DataTable
            Dim str As String
            str = "  Select * from FabricationMaster FM"
            str &= "  join FabricationDetail FD on FD.FabricationMasterID=FM.FabricationMasterID"
            str &= " join FabricPlacement FP on FP.FabricPlacementID=FD.FabricPlacementID"
            str &= "  where  FM.FabricationMasterID=" & FabricationMasterID
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetGridDetailData(ByVal ItemDatabaseID As Long) As DataTable
            Dim str As String
            str = " Select '0' as FabricationDetailID,IDB.ItemDatabaseID,FP.FabricPlacementID,FP.FabricPlacementName"
            str &= " from ItemDatabase IDB"
            str &= " join ItemDatabaseBodyPart IDBP on IDBP.ItemDatabaseID=IDB.ItemDatabaseID"
            str &= " join FabricPlacement FP on FP.FabricPlacementID=IDBP.FabricPlacementID"
            ' str &= " left join FabricationDetail FD on FD.FabricPlacementID=IDBP.FabricPlacementID"
            str &= " where IDB.ItemDatabaseID =  '" & ItemDatabaseID & "' "
            Try
                Return MyBase.GetDataTable(str)

            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEntry(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = " Select JDD.JoborderDetailid,KnittingProgramDetailID=0, I.ItemName,JDD.Content,JDD.GSM,FT.FabricType,JDD.BuyerColor,JDD.Quantity,"
            str &= " FC.GrossCalc as Weight,FC.FabricTypeID"
            str &= " from JobOrderdatabase  JO  "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID"
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID"
            str &= " join FabricationCalculation FC on FC.JoborderDetailid=JDD.JoborderDetailid"
            str &= " join FabricType FT on FT.FabricTypeID=FC.FabricTypeID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID "
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEntryOnEdit(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = "  Select JDD.JoborderDetailid,KND.KnittingProgramDetailID, "
            str &= " I.ItemName,JDD.Content,JDD.GSM,FT.FabricType,FT.FabricTypeID,"
            str &= " JDD.BuyerColor,JDD.Quantity, KND.Weight as Weight"
            str &= " from JobOrderdatabase  JO  "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID "
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID "
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID  "
            str &= " join KnittingProgramDetail KND on KND.JoborderDetailid=JDD.JoborderDetailid "
            str &= " join FabricType FT on FT.FabricTypeID=KND.FabricTypeID "
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "'"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEntryOnEditForPRINT(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = "  Select JDD.JoborderDetailid,KND.KnittingProgramDetailID, "
            str &= " I.ItemName,JDD.Content,JDD.GSM,FT.FabricType,FT.FabricTypeID,"
            str &= " JDD.BuyerColor,JDD.Quantity, KND.Weight as Weight"
            str &= " from JobOrderdatabase  JO  "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID "
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID "
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID  "
            str &= " join KnittingProgramDetail KND on KND.JoborderDetailid=JDD.JoborderDetailid "
            str &= " join FabricType FT on FT.FabricTypeID=KND.FabricTypeID "
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "' order by FT.FabricType Desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEntrySummary(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = " Select KnittingProgramSummaryID=0, FT.FabricType ,"
            str &= " SUM(FC.GrossCalc) as Weight,FC.FabricTypeID"
            str &= " from JobOrderdatabase  JO  "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID"
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID"
            str &= " join FabricationCalculation FC on FC.JoborderDetailid=JDD.JoborderDetailid"
            str &= " join FabricType FT on FT.FabricTypeID=FC.FabricTypeID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID "
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "'"
            str &= " group by  FT.FabricType,FC.FabricTypeID"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEntrySummaryOnEdit(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = " Select KNDS.KnittingProgramSummaryID, FT.FabricType ,"
            str &= " KNDS.Weight as Weight,FC.FabricTypeID"
            str &= " from JobOrderdatabase  JO  "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID"
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID"
            str &= " join FabricationCalculation FC on FC.JoborderDetailid=JDD.JoborderDetailid"
            str &= " join FabricType FT on FT.FabricTypeID=FC.FabricTypeID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID "
            str &= " join KnittingProgramSummary KNDS on KNDS.FabricTypeID=FT.FabricTypeID"
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "'"
            str &= " group by  FT.FabricType,FC.FabricTypeID,KNDS.KnittingProgramSummaryID,KNDS.Weight"
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEntrySummaryOnEditForPrint(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = " Select KNDS.KnittingProgramSummaryID, FT.FabricType ,"
            str &= " KNDS.Weight as Weight,FC.FabricTypeID"
            str &= " from JobOrderdatabase  JO  "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID"
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID"
            str &= " join FabricationCalculation FC on FC.JoborderDetailid=JDD.JoborderDetailid"
            str &= " join FabricType FT on FT.FabricTypeID=FC.FabricTypeID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID "
            str &= " join KnittingProgramSummary KNDS on KNDS.FabricTypeID=FT.FabricTypeID"
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "'"
            str &= " group by  FT.FabricType,FC.FabricTypeID,KNDS.KnittingProgramSummaryID,KNDS.Weight  order by FT.FabricType Desc "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function LoadKnittingEdit(ByVal JoborderID As Long, ByVal Style As String) As DataTable
            Dim str As String
            str = " Select  KnittingProgramDetailID=0, I.ItemName,JDD.Content,JDD.GSM,FT.FabricType,JDD.BuyerColor,JDD.Quantity, FC.FabricTypeID,"
            str &= " FC.GrossCalc as Weight,  JDD.JoborderDetailID,GGSM,DiaGG,Width  "
            str &= " from JobOrderdatabase  JO "
            str &= " join JobOrderDatabaseDetail  JDD on JDD.JoborderID=JO.JoborderID "
            str &= " join KnittingProgramDetail KPD on KPD.JoborderDetailid=JDD.JoborderDetailid  "
            str &= " join ItemDatabase I  on I.ItemDatabaseID= JDD.ItemDatabaseID "
            str &= " join FabricationCalculation FC on FC.JoborderDetailid=JDD.JoborderDetailid"
            str &= " join FabricType FT on FT.FabricTypeID=FC.FabricTypeID"
            str &= " join CustomerDatabase CD on CD.CustomerDatabaseID=JO.CustomerDatabaseID"
            str &= " where JO.JoborderID =" & JoborderID
            str &= " and  jdd.Style='" & Style & "'"
            str &= " group by JDD.JoborderDetailid, I.ItemName,JDD.Content,JDD.GSM,FT.FabricType,JDD.BuyerColor,JDD.Quantity, FC.FabricTypeID,FC.GrossCalc , GGSM,DiaGG,Width  "

            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
        Public Function GetSeasonsForJobOrderVieeSearchingBarCodeView() As DataTable
            Dim str As String
            str = " Select Distinct SD.SeasonDatabaseID,SD.SeasonName from SeasonDatabase SD join JobOrderdatabase JO on JO.SeasonDatabaseID=SD.SeasonDatabaseID "
            Try
                Return MyBase.GetDataTable(str)
            Catch ex As Exception

            End Try
        End Function
    End Class
End Namespace
