<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="MGTEcpWiseReport.aspx.vb" Inherits="Integra.MGTEcpWiseReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table  >
    <tr>
<td  >
ECP Division:
</td>
    
<td   >
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadComboBox ID="cmbECP" Runat="server" AutoPostBack="True" Skin="WebBlue">
    <DefaultItem Value="0" Text="Select ECP" />
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
</td>
</tr>
 <tr>
  <td style="height: 3px"></td>
  </tr>
 <tr>
<td  >
Product Group:
</td>
    
<td   >
<asp:UpdatePanel ID="updProductGroup" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadComboBox ID="cmbProductGroup" Runat="server" AutoPostBack="True" Skin="WebBlue">
<%--  <DefaultItem Value="0" Text="All Product Group" />--%>
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
</td>
</tr>
<tr>
  <td style="height: 3px"></td>
  </tr>
 <tr>
<td  >
Product Categories:
</td>
    
<td   >
<asp:UpdatePanel ID="updProductCategories" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadComboBox ID="cmbProductCategories" Runat="server" AutoPostBack="True" Skin="WebBlue">
<%--   <DefaultItem Value="0" Text="All Product Categories" />--%>
 </telerik:RadComboBox> 
     </ContentTemplate>
 </asp:UpdatePanel>
</td>
</tr>
<tr>
  <td style="height: 3px"></td>
  </tr>
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

<%--<tr>
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
</tr>--%>
  
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
