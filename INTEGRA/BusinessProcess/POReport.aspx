<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="POReport.aspx.vb" Inherits="Integra.POReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <CR:CrystalReportViewer ID="CRViewer" runat="server" AutoDataBind="true" 
                Style="position: absolute; z-index: 111; left: 0px; top: 0px;" HasDrillUpButton="False"  BorderColor="Silver"  DisplayBottomToolbar="False" DisplayGroupTree="False" EnableDrillDown="False" HasToggleGroupTreeButton="False" HasViewList="False"  HasZoomFactorList="False" Width="350px" />

    </div>
    </form>
</body>
</html>
