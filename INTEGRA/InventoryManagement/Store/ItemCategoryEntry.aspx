<%@ Page Title="Item Category Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ItemCategoryEntry.aspx.vb" Inherits="Integra.ItemCategoryEntry" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                Item Class Name
            </td>
            <td>
                <asp:DropDownList ID="cmbItemClassName" Width="310" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Item Category Name
            </td>
            <td>
                <asp:TextBox ID="txtItemCategoryName" CssClass="textbox" runat="server" Width="303px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Item Category Code
            </td>
            <td>
                <asp:TextBox ID="txtItemCategoryCode" CssClass="textbox" runat="server" Width="303px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Remarks
            </td>
            <td>
                <asp:TextBox ID="txtRemarks" CssClass="text_box_M" runat="server" Width="303px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />&nbsp;
                <asp:Button ID="BtnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
