<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="StyleDescription.aspx.vb" Inherits="Integra.StyleDescription" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Style Category
            </td>
            <td>
                <div style="margin-left: 40px;">
                    <asp:DropDownList ID="cmbStyleCategory" Width="250" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <table>
            <br />
            <table>
                <tr>
                    <td>
                        Style Description
                    </td>
                    <td>
                        <div style="margin-left: 28px;">
                            <asp:TextBox ID="txtStyleDescription" runat="server" Width="250px" CssClass="textbox"></asp:TextBox></div>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td align="center">
                        <div style=" margin-left: 149px;">
                            <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />&nbsp; &nbsp;<asp:Button
                                ID="btnCancel" CssClass="button" runat="server" Text="Cancel" /></div>
                    </td>
                </tr>
            </table>
</asp:Content>
