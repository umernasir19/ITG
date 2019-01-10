<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="AdministrationActivity.aspx.vb" Inherits="Integra.AdministrationActivity" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../css/Authentication.css" rel="stylesheet" type="text/css" />
<asp:Panel ID="pnlAuthentication" runat="server">

<div class="slider_2">

<div class="left_container">

<div class="form-bg form"><img alt="" src="../Images/bg'.png" width="390" height="49" /></div>

<div class="field_txt"><asp:Label ID="lblmsg" runat="server" Font-Names="Calibri" Font-Bold="true" Font-Size="Medium" ForeColor="Red"></asp:Label></div>

<div class="field_1">
    <telerik:RadTextBox ID="txtAuthentication" runat="server" Skin="WebBlue" 
        TextMode="Password" Width="281px"></telerik:RadTextBox></div>

<div class="btn"><telerik:RadButton ID="btnAuthentication" runat="server" Skin="WebBlue" Text="Login"></telerik:RadButton></div>

</div>
</div>

    </asp:Panel>
    <div>

<telerik:RadAjaxManager ID="RadAjaxMang" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="btnSearch">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgAdminitrationAct" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
<%--<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="btnAuthentication">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="lblmsg" />
<telerik:AjaxUpdatedControl ControlID="cmbaction" />
<telerik:AjaxUpdatedControl ControlID="txtSearch" />
<telerik:AjaxUpdatedControl ControlID="btnSearch" />
<telerik:AjaxUpdatedControl ControlID="dgAdminitrationAct" />

</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>--%>
</telerik:RadAjaxManager>
<table width="100%">
<tr>

<td>
<telerik:RadComboBox ID="cmbaction" runat="server" Skin="WebBlue" Width="250" >
<Items>

<telerik:RadComboBoxItem Text="Revised Original Shipment Date" Value="0" />
<telerik:RadComboBoxItem Text="Delete Purchase Order" Value="1" />
</Items>
</telerik:RadComboBox>
</td>
</tr>
<tr>
<td>
PO No. &nbsp;&nbsp;
<telerik:RadTextBox ID="txtSearch" runat="server" Skin="WebBlue"></telerik:RadTextBox>
&nbsp;&nbsp;&nbsp;
<telerik:RadButton ID="btnSearch" runat="server" Text="Search" Skin="WebBlue"></telerik:RadButton>
</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td colspan="2">
<telerik:RadGrid ID="dgAdminitrationAct" runat="server" AutoGenerateColumns="false" Skin="WebBlue">
<MasterTableView>
<Columns>
<telerik:GridBoundColumn DataField="POID" HeaderText="POID" Display="false">
<ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="PONO" HeaderText="PO No." ><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="VenderName" HeaderText="Supplier"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="CustomerName" HeaderText="Customer"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="UserName" HeaderText="Merchant"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="PlacementDate" HeaderText="Placement Date"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="ShipmentDate" HeaderText="Shipment Date"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="ShipmentDatee" HeaderText="Shipment Date" Display="false"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="CreationDate" HeaderText="Creation Date"><ItemStyle Wrap="false" /></telerik:GridBoundColumn>
<telerik:GridTemplateColumn HeaderText="In Shipment">
<ItemTemplate>
<asp:Label ID="lblInShipment" runat="server" Text='<%# Eval("InShipment") %>'></asp:Label>
</ItemTemplate>
</telerik:GridTemplateColumn>
<telerik:GridTemplateColumn HeaderText="New Shipment Date">
<ItemTemplate>
<telerik:RadDatePicker ID="dpNewShipmentDate" runat="server" SelectedDate='<% #Eval("ShipmentDatee") %>'  Width="100px" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>

</telerik:RadDatePicker>
</ItemTemplate>
</telerik:GridTemplateColumn>
 <telerik:GridTemplateColumn HeaderText ="Delete"  Display="true" AllowFiltering="false">
                <ItemTemplate >
                <asp:LinkButton ID="lnkDelete"  runat ="server" CommandName ="Remove"  Text="Delete" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText ="Revised"  Display="true" AllowFiltering="false">
                <ItemTemplate >
                <asp:LinkButton ID="lnkRevised"  runat ="server" CommandName ="Revised"  Text="Revised" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
</Columns>
</MasterTableView>
</telerik:RadGrid>
</td>
</tr>
</table>
</div>
</asp:Content>
