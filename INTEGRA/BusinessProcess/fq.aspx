<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="fq.aspx.vb" Inherits="Integra.fq" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" />
    <telerik:RadFormDecorator ID="RadFormDecorator1" DecoratedControls="All" runat="server"
        Skin="Metro" EnableRoundedCorners="false"></telerik:RadFormDecorator>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="None">
    </telerik:RadAjaxLoadingPanel>
     <telerik:RadBarcode runat="server" ID="RadBarcode1" Type="QRCode" Width="371px" Height="371px"
                 OutputType="EmbeddedPNG"  >
      <QRCodeSettings   ECI="None"  Mode="Byte"  ErrorCorrectionLevel="L" Version="7"   />
     </telerik:RadBarcode>



    </form>
</body>
</html>
