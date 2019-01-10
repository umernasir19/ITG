<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="MGTReportTool.aspx.vb" Inherits="Integra.MGTReportTool" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
   <telerik:RadComboBoxItem Value="3" Text="TDG Vise" />
 <telerik:RadComboBoxItem Value="4" Text="Merchandiser Vise" />
 </Items>
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
</td>
</tr>
<tr>
<td>
Via:
</td>
    
<td>
<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadComboBox ID="cmbOF" Runat="server" AutoPostBack="True" Skin="WebBlue">
 <Items>
 <telerik:RadComboBoxItem Value="0" Text="ETD" />
  <telerik:RadComboBoxItem Value="1" Text="ETA" />
 </Items>
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
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
 
</asp:Content> 