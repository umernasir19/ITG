<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BookedExchangePopup.aspx.vb" Inherits="Integra.BookedExchangePopup" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Booked Exchange Rate Popup</title>
     <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
     <table  >
     <tr>
     <td></td>
         
     <td>
     <asp:Label ID="lblMsg" cssClass="ErrorMsg" runat="server" ></asp:Label>
     </td>
     </tr>
         
<tr>
<td class="labelNew">
Exchange Rate:
</td>
<td>
    <telerik:RadTextBox ID="txtExchangeRate" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
 
</td>
<td>
 
</td>
<td>

</td>
</tr>
<tr>
<td class="labelNew">
From :
</td>
<td>
<telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"  runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
              </telerik:RadDatePicker>
 
</td>
<td class="labelNew">
To :
</td>

<td >
 <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
<Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"   runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
              </telerik:RadDatePicker>
</td>
</tr>
<tr><td></td>
<td>
 <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
</td><td></td>
<td>
    <asp:button id="cmdClose"    OnClientClick="window.close();" runat="server"
  CssClass="button" Text="Close"   ></asp:button>
</td>
</tr>
 </table>
  
 <table>
<tr><td></td>
<td class="ErrorMsg">
*: This Criteria of Date is PO Shipment Date.
</td>
</tr>
</table>
    </form>
</body>
</html>
