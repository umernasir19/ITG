<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="OIHReport.aspx.vb" Inherits="Integra.OIHReport" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table >
 <tr>
<td >
   
    <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
   </td>
<td  valign="top">
<telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
 

</td>
   <td  >
        </td>

<td  >

    <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
</td>

<td  valign="top">
<telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
<Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
  
</td>
<td>      
    </td>
    <td>
    </td>
</tr>
 <tr>
  <td style="height: 10px"></td>
  </tr>
<tr>
<td  >
Report Type:
</td>
    
<td   >
  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadComboBox ID="cmbreporttype" Runat="server" AutoPostBack="True" Skin="WebBlue">
 <Items>
 <telerik:RadComboBoxItem Value="0" Text="Select Report" />
  <telerik:RadComboBoxItem Value="1" Text="Customer Vise" />
   <telerik:RadComboBoxItem Value="2" Text="Supplier Vise" />
    <telerik:RadComboBoxItem Value="3" Text="Merchandiser Vise" />
     <telerik:RadComboBoxItem Value="4" Text="TDG Vise" />
 </Items>
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
</td>
</tr>
  <tr>
  <td style="height: 10px"></td>
  </tr>
<tr>
<td ></td>

<td  >
  <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue"  >
  </telerik:RadButton></td>
</tr>

</table> 
<table>
<tr><td></td>
<td class="labelNew" >
<b>
*: Dates range should be PO shipment date.</b>
</td>
</tr>
</table>
</asp:Content> 