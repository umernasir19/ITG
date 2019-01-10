<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="SupplierCategory.aspx.vb" Inherits="Integra.SupplierCategory" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="RadGrid1">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="RadGrid1" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
<div style="max-width: 995px; padding-right: 10px;">
<telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="True"
             AllowFilteringByColumn="True"  CellSpacing="0" GridLines="Horizontal" 
        AutoGenerateColumns="False"></telerik:RadGrid>

</div>
</div>
</asp:Content>
