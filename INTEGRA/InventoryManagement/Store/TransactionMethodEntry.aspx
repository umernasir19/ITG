<%@ Page Title="Transaction Method Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="TransactionMethodEntry.aspx.vb" Inherits="Integra.TransactionMethodEntry" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="100%">
<tr>
<td>
Item Name
</td>
<td>
    <asp:DropDownList ID="cmbItem"  Width="310"  runat="server" AutoPostBack="true">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
Transaction Method 
</td>
<td>
      <asp:DropDownList ID="cmbTransactionMethod"  Width="310"  runat="server" AutoPostBack="true">
      <asp:ListItem Value="0" Text="Average Method"></asp:ListItem>
        <asp:ListItem Value="1" Text="LIFO Method"></asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
 
<tr>
<td></td>
<td>
    <asp:Button ID="btnSave" CssClass="button"  runat="server" Text="Save" />&nbsp;
      <asp:Button ID="BtnCancel"  CssClass="button"  runat="server" Text="Cancel" />
</td>
</tr>
</table>
</asp:Content>

