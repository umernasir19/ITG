<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="MGT.aspx.vb" Inherits="Integra.MGT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <table>
        <tr>
          <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblFrom" runat="server" Text="From Date"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtFromDate" runat="server" Culture="en-US">
<Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput ID="txtFromDate" runat ="server"  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
</td> 
             
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblCreationDate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtToDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

<DateInput ID="txtTodate" runat ="server"  DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
</td> 
         <td colspan="3" align="right">  <telerik:RadButton ID="btnOK" runat="server" Text="OK" 
                 Skin="WebBlue"> 
                </telerik:RadButton></td>  
            
        </tr>
    </table>
    </div>
    </asp:Content>