<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SampleStatusRpt.aspx.vb" Inherits="Integra.SampleStatusRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function isNumericKey(e) {
            var charInp = window.event.keyCode;
            if (charInp > 31 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function isNumericKeyy(e) {
            var charInp = window.event.keyCode;
            if (charInp != 46 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
   
    </script>
    <table width="100%">
        <tr style="height: 33px;">
            <td>
                <asp:UpdatePanel ID="UpcmbCustomer" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        Customer </td>
                        <td>
                            <asp:DropDownList ID="cmbCustomer" AutoPostBack="true" runat="server" Width="140"
                                ToolTip="select Customer No">
                            </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                BuyingDept.
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbBuyingDept" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyingDept" AutoPostBack="false" runat="server" Width="140"
                            ToolTip="select BuyingDept No">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Buyer Name
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatecmbBuyerName" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyerName" AutoPostBack="false" runat="server" Width="140"
                            ToolTip="select Buyer Name">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Brand
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbBrand" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBrand" AutoPostBack="false" runat="server" Width="140" ToolTip="select Brand">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Season
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbSeason" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSeason" AutoPostBack="false" runat="server" Width="140"
                            ToolTip="select Season No">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpStyleNo" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbStyle" AutoPostBack="false" Visible="false" runat="server"
                            Width="140" ToolTip="select Style No">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="left">
                <asp:Button ID="btnReport" runat="server" Text="View Report" Style="margin-left: 477px;" />
            </td>
        </tr>
    </table>
</asp:Content>
