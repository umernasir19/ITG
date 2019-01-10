<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DatePlus.aspx.vb" Inherits="Integra.DatePlus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>



    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="cmbETDdate">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="cmbShipDate" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
    </telerik:RadAjaxManager>

    <div>
    <telerik:RadTextBox ID="txtShipMode" Runat="server"></telerik:RadTextBox>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <telerik:RadDatePicker ID="cmbETDdate" Runat="server" AutoPostBack="true">



        </telerik:RadDatePicker>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <telerik:RadDatePicker ID="cmbShipDate" Runat="server"></telerik:RadDatePicker>


    </div>
    </form>
</body>
</html>
