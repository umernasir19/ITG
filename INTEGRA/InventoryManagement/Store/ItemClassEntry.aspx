<%@ Page Title="Item Class Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ItemClassEntry.aspx.vb" Inherits="Integra.ItemClassEntry" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_container">
        <div class="header_columns">
            <div class="heading">
                Item Class</div>
            <br />
            <div class="colum ">
                <div class="text_colum ">
                    Item Class Name:</div>
                <div class="text_field ">
                    <asp:TextBox ID="txtItemClassName" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
                </div>
            </div>
            <div class="colum">
                <div class="text_colum">
                    Item Code:</div>
                <div class="text_field">
                    <asp:TextBox ID="txtItemCode" CssClass="textbox" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="colum">
                <div class="text_colum">
                    Store Type:</div>
                <div>
                    <asp:DropDownList ID="cmbStoreType" Width="310" runat="server" AutoPostBack="true"
                        Enabled="false">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="colum">
                <div class="text_colum">
                    Remarks:</div>
                <div class="text_field">
                    <asp:TextBox ID="txtRemarks" CssClass="textbox_M" Width="350px" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Skin="WebBlue" Text="Save" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true">
                    </asp:Button>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Skin="WebBlue" Text="Cancel" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="110px"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
