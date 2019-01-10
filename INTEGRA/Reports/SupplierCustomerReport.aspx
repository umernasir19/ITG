<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SupplierCustomerReport.aspx.vb" Inherits="Integra.SupplierCustomerReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
  <table  >
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
    Periodic Type:
</td>
    
<td   >
 <telerik:RadComboBox ID="cmbPeriodicType" Runat="server" Skin="WebBlue">
 <Items>
 <telerik:RadComboBoxItem Value="0" Text="Select Criteria" />
  <telerik:RadComboBoxItem Value="1" Text="Weekly" />
   <telerik:RadComboBoxItem Value="2" Text="Monthly" />
  <telerik:RadComboBoxItem Value="3" Text="Quarterly" />
 </Items>
 </telerik:RadComboBox> 
   
</td>
</tr>
<tr>
<td>
    Marchant:
</td>
    
<td>

 <telerik:RadComboBox ID="cmbMarchand" Runat="server" Skin="WebBlue">
 <Items>
 
 </Items>
 </telerik:RadComboBox> 
</td>
</tr>
  
 <tr>
  <td style="height: 10px"></td>
  </tr>
<td ></td>
<tr>
<td></td>
<td  >
  <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue"  >
  </telerik:RadButton></td>
</tr>

</table> 
</div>
</asp:Content>
