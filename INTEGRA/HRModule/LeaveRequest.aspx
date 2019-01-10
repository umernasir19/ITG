<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LeaveRequest.aspx.vb" Inherits="Integra.LeaveRequest" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadAjaxManager ID="AjaxMang" runat="server">
    <AjaxSettings>
    <telerik:AjaxSetting AjaxControlID="txtLeaveFrom">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="lblErrorMsg" />
    <telerik:AjaxUpdatedControl ControlID="txtLeaveDays" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    <telerik:AjaxSetting AjaxControlID="txtLeaveTo">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="lblErrorMsg" />
    <telerik:AjaxUpdatedControl ControlID="txtLeaveDays" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    <telerik:AjaxSetting AjaxControlID="btnCancel">
    <UpdatedControls>
    <telerik:AjaxUpdatedControl ControlID="btnCancel" />
    </UpdatedControls>
    </telerik:AjaxSetting>
    </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"/>
    <div>
    <table width="100%">
     <tr>
                            <td colspan="2" id="Td2" align="center" runat="server" style="background-color:Transparent ; color:Red ; font-family:Verdana; font-weight:bold; height: 18px; width: 926px;" >
                            <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Calibri" 
                                    Font-Size="Medium"  ></asp:Label>
                             </td>   
    <tr>
    <td colspan="2">
    <asp:Label ID="lblUser" runat="server" 
            style="font-family:Calibri; font-size:14px ; font-weight:bolder ; " 
            ForeColor="#0066CC" ></asp:Label>
        &nbsp;<asp:Label ID="lblmessage" runat="server" 
            style="font-family:Calibri; font-size:14px ; font-weight:bolder ; " 
            ForeColor="#0066CC" ></asp:Label>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblDateOfNotice" Text="Date Of Notice:" runat="server" 
            Font-Names="Calibri"></asp:Label>
    </td>
    <td>
    <telerik:RadDatePicker ID="txtDateofNotice" runat="server" Skin="WebBlue" 
            BackColor="#3399FF">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
            Skin="WebBlue"></Calendar>
<DateInput DisplayDateFormat="dd-MM-yyyy" DateFormat="dd-MM-yyyy" LabelWidth="40%"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
    </td>
    </tr>
    <tr>
    <td>
     <asp:Label ID="lblTotalLeave" Text="Total Leave:" runat="server" 
            Font-Names="Calibri"></asp:Label>
    </td>
    <td>
    <telerik:RadTextBox ID="txtTotalLeave" runat="server" Skin="WebBlue" 
            BackColor="#3399FF" ReadOnly="True">
    </telerik:RadTextBox>
    </td>
    </tr>
     <tr>
    <td>
     <asp:Label ID="lblAvailed" Text="Availed:" runat="server" Font-Names="Calibri"></asp:Label>
    </td>
    <td>
    <telerik:RadTextBox ID="txtAvailed" runat="server" Skin="WebBlue" 
            BackColor="#3399FF" ReadOnly="True">
    </telerik:RadTextBox>
    </td>
    </tr>
     <tr>
    <td>
     <asp:Label ID="lblRemaining" Text="Remaining:" runat="server" Font-Names="Calibri"></asp:Label>
    </td>
    <td>
    <telerik:RadTextBox ID="txtRemaining" runat="server" Skin="WebBlue" 
            BackColor="#3399FF" ReadOnly="True">
    </telerik:RadTextBox>
    </td>
    </tr>
     <tr>
    <td>
     <asp:Label ID="lblLeaveFrom" Text="Leave From:" runat="server" 
            Font-Names="Calibri"></asp:Label>
    </td>
    <td>
<telerik:RadDatePicker ID="txtLeaveFrom" runat="server" Skin="WebBlue" AutoPostBack="true">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
            Skin="WebBlue"></Calendar>
<DateInput DisplayDateFormat="dd-MM-yyyy" DateFormat="dd-MM-yyyy" LabelWidth="40%" 
            AutoPostBack="True"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
    </td>
    </tr>
      <tr>
    <td>
     <asp:Label ID="lblLeaveTo" Text="Leave To:" runat="server" Font-Names="Calibri"></asp:Label>
    </td>
    <td>
 <telerik:RadDatePicker ID="txtLeaveTo" runat="server" Skin="WebBlue" AutoPostBack="true">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" 
            Skin="WebBlue"></Calendar>
<DateInput DisplayDateFormat="dd-MM-yyyy" DateFormat="dd-MM-yyyy" LabelWidth="40%" 
            AutoPostBack="True"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>
  
    </td>
    </tr>
      <tr>
    <td>
     <asp:Label ID="lblLeaveDays" Text="Leave Days:" runat="server" 
            Font-Names="Calibri"></asp:Label>
    </td>
    <td>
 <telerik:RadTextBox ID="txtLeaveDays" runat="server" Skin="WebBlue" 
            BackColor="#3399FF" ReadOnly="True">
    </telerik:RadTextBox>
   
    </td>
    </tr>
       <tr>
    <td>
     <asp:Label ID="lblReason" Text="Reason:" runat="server" Font-Names="Calibri"></asp:Label>
    </td>
    <td>
  <telerik:RadTextBox ID="txtReason" runat="server" Skin="WebBlue" 
            TextMode="MultiLine" Height="62px" Width="589px">
    </telerik:RadTextBox>
   </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
    <telerik:RadButton ID="btnApproval" Text="Send For Approval" runat="server" Skin="WebBlue"></telerik:RadButton>
  <asp:button id="btnClose"    OnClientClick="window.close();" runat="server"
  Text="Close" BackColor="#688CD9"   ></asp:button>
    </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
