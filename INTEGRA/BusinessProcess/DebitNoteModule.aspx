<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="DebitNoteModule.aspx.vb" Inherits="Integra.DebitNoteModule" %>
 <%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="Panel1" runat="server"   Width="100%">
  <table width="100%">
  <tr><td >
</td>
<td class="ErrorMsg" >
    <asp:Label ID="lblMsg" runat="server"  ></asp:Label>
</td>
</tr>
 <tr>
 <td   >
 <asp:Label ID="lblCustomer" runat="server" Text="Customer:"></asp:Label>
 </td>
 <td>
  <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbCustomer" Runat="server" AutoPostBack="True" Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
 
 </td>
 </tr>
 <tr><td   >
<asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>

</td>
<td   >
  <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbMonth" Runat="server" AutoPostBack="True" Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
 
</td>
</tr>
<tr><td   >
<asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>

</td>
<td   >
  <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbYear" Runat="server" AutoPostBack="True" Skin="WebBlue">
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
 
</td>
</tr>
<tr><td  >
<asp:Label ID="lblCurrency" runat="server" Text="Currency:"></asp:Label>

</td>
<td class="NormalBoldText" >
  <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                    <telerik:RadComboBox ID="cmbCurrency" Runat="server" AutoPostBack="True" Skin="WebBlue">
                    <Items>
                    <telerik:RadComboBoxItem Value="0" Text="Dollar" />
                      <telerik:RadComboBoxItem Value="1" Text="Euro" />
                    </Items>
                </telerik:RadComboBox>
                </ContentTemplate>
                 </asp:UpdatePanel>
</td>
</tr>
<tr>
<td></td>
<td>
 <telerik:RadButton ID="btnSearch" runat="server" Text="Proceed TO DN" 
        Skin="WebBlue"  Width="153px">
                    </telerik:RadButton>
   
</td>
<td>

</td>
</tr>
 </table>
  </asp:Panel>
  
   <asp:Panel ID="Panel2" runat="server"   Width="100%">
<table width="100%">
 <tr>
     <td  >
         Customer:
     </td>
     <td >
         <%--<asp:Label ID="lblCustomerName"  runat="server"  ></asp:Label>  --%>
         <asp:TextBox ID="txtCustomerNamePart" runat="server" CssClass="textbox"></asp:TextBox>
     </td>
     <td>
     </td>
     <td>
     </td>
     <td>
     </td>
     <td  >
         DN No.:
     </td>
     <td align="left">
         <asp:TextBox ID="txtDNNo" runat="server" CssClass="textbox"></asp:TextBox>
     </td>
    </tr>
<tr>
<td  >Department:</td>
<td>
<asp:TextBox ID="txtImportDept" CssClass="textbox" runat="server"></asp:TextBox>
</td>
<td></td><td></td><td>
</td>
<td  >
DN Date:
</td>
<td align="left">
<telerik:RadDatePicker ID="txtDNDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" runat="server"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" runat="server"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
</telerik:RadDatePicker>
</td>
</tr>
<tr>
<td  >Address Line 1:</td>
<td>
<asp:TextBox ID="txtaddressLine1"  CssClass="textbox" runat="server"></asp:TextBox>
</td>
<td></td><td></td><td>
</td>
<td  >
Customer No:
</td>
<td align="left"><asp:TextBox ID="txtCustomerNo" CssClass="textbox" runat="server" ReadOnly="True"></asp:TextBox>
</td>
</tr>
<tr>
<td  >Address Line 2:</td>
<td>
<asp:TextBox ID="txtaddressLine2" CssClass="textbox" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td  >Address Line 3:</td>
<td>
<asp:TextBox ID="txtaddressLine3" CssClass="textbox" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td  >
Attn:
</td>
<td>
<asp:TextBox ID="txtAttn" CssClass="textbox" runat="server"></asp:TextBox>
</td>
</tr>
</table>
<table width="100%">
<tr>
<td>
Description
</td>
 
<td>
<asp:Label ID="lblCurrencyName" runat="server"  ></asp:Label>

</td>
</tr>
<tr>
<td align="left">
<asp:TextBox ID="txtDescription"   CssClass="textbox" runat="server"  Width="520px" ReadOnly="True"></asp:TextBox>
</td>
 
<td align="left">
<asp:TextBox ID="txtTotalValue"  CssClass="textbox" runat="server" ReadOnly="True"></asp:TextBox>
</td>
<td align="left">
<asp:TextBox ID="txtTotalValueHide"   CssClass="textbox" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
</td>
</tr>


</table>
<table>
<tr>
<td>
    <asp:TextBox ID="txtSay"  CssClass="textbox" runat="server"  Width="520px" ReadOnly="True"></asp:TextBox>
</td>
</tr>
</table>
<table width="100%">
 <tr>
 <td align="right">
 <telerik:RadButton ID="btnSave" runat="server" Text="Save DN" Skin="WebBlue">
                  </telerik:RadButton>
 </td>
 <td>
 <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
 </td>
 </tr>
</table>
 </asp:Panel>
 
  </asp:Content>
