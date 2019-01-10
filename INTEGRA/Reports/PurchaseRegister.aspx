<%@ Page Title="PURCHASE REGISTER" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="PurchaseRegister.aspx.vb" Inherits="Integra.PurchaseRegister" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <table>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                PURCHASE REGISTER
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
            </td>
            <td valign="top">
                <div style="margin-left: 16px;">
                    <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                        <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </td>
            <td>
            </td>
            <td>
                <div style="margin-left: 50px;">
                    <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label></div>
            </td>
            <td valign="top">
                <div style="margin-left: 16px;">
                    <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                        <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td valign="top">
                <div>
                    <asp:Label ID="Label2" runat="server" Text=" GRN No :"></asp:Label></div>
            </td>
            <td valign="top">
                <div>
                    <asp:DropDownList ID="cmbGRNNo" Width="133" runat="server" TabIndex="0" AutoPostBack="false">
                    </asp:DropDownList>
                </div>
            </td>
            <td valign="top">
                <asp:Label ID="lblID" runat="Server" Text="0" Visible="false"></asp:Label>
            </td>
            <td valign="top">
                <div style="margin-left: 31px;">
                    <asp:Label ID="Label1" runat="server" Text="Item Code :"></asp:Label></div>
            </td>
            <td valign="top">
                <div style="margin-left: 16px;">
                    <asp:TextBox ID="TXTCodeEntry" Width="135px" AutoPostBack="true" CssClass="textbox"
                        runat="server"></asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTCodeEntry"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTCodeEntryForPurchase" />
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 110px;">
                <div style="margin-left: 0px; margin-top: 13px;">
                    Season</div>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <div style="margin-left: -57px; margin-top: 13px;">
                    <asp:DropDownList ID="cmbSeason" runat="server" AutoPostBack="true" Width="135px"
                        Style="margin-left: -65px; margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div style="margin-left: -25px; margin-top: 13px;">
                    Sr No:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 16px; margin-top: 13px;">
                    <asp:DropDownList ID="cmbSrNo" runat="server" AutoPostBack="false" Width="135px"
                        Style="margin-left: 0px; margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <table>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <td>
        </td>
        <tr>
            <td>
            </td>
            <td>
                <div style="margin-left: 106px;">
                    <telerik:RadButton ID="btnReport" runat="server" Style="width: 120px;" Text="Download Report"
                        Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
            <td>
                <div style="margin-left: 16px;">
                    <telerik:RadButton ID="btnExcel" Visible ="false"  runat="server" Style="width: 130px;" Text=" Download Excel "
                        Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
