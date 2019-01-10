<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SymbolInsert.aspx.vb" Inherits="Integra.SymbolInsert" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .ddlstyle
        {
            width: 200px;
        }
        option
        {
            padding-left: 20px;
            font-size: 12px;
        }
    </style>
    <table width="100%">
        <tr>
            <td style="width: 125px;">
                <div class="txt_newwww" style="width: 140px;">
                    Symbols Upload:
                </div>
            </td>
            <td>
                <%-- <div class="text_box" style="">--%>
                <asp:FileUpload ID="FileUpload1" runat="server" Style="margin-left: 12px;" ToolTip="select jpg file to attach and press upload" />
                <%-- </div> --%>
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnBSave" CssClass="button" runat="server" Text="Save Bleach Symbol" />
                &nbsp;
                <asp:Button ID="btnDegreeSave" CssClass="button" runat="server" Text="Save D.O.Color Symbol" />
                &nbsp;
                <asp:Button ID="btnDryCSave" CssClass="button" runat="server" Text="Save Dry Cleaning Symbol" />
                &nbsp;
                <asp:Button ID="btnIroningSave" CssClass="button" runat="server" Text="Save Ironing Symbol" />
                &nbsp;
                <asp:Button ID="btnTumbleDrySave" CssClass="button" runat="server" Text="Save Tumble Dry Symbol" />
            </td>
        </tr>
    </table>
</asp:Content>
