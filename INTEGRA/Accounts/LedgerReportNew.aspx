<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="LedgerReportNew.aspx.vb" Inherits="Integra.LedgerReportNew" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                LEDGER PRINT
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 100px;">
                <div class="txt_newwww" style="width: 140px;">
                    Account Code</div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 20px; margin-top: 2px;">
                    <asp:TextBox ID="txtCmbAccountCode" Style="margin-left: 3px;" runat="server" CssClass="textbox"
                        AutoPostBack="true" autocomplete="off" Width="440px" ToolTip="Voucher No" placeholder="Account Name"> </asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtCmbAccountCode"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="txtautoLedger" />
                </div>
                <asp:Label ID="lblAccountCode" runat="server" Visible="true" Style="margin-left: 407px;"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    Start Date
                </div>
            </td>
            <td>
                <div style="margin-left: 16px;">
                    <telerik:RadDatePicker ID="txtStartDatee" runat="server" Culture="en-US">
                        <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput3" DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    End Date
                </div>
            </td>
            <td>
                <div style="margin-left: 16px;">
                    <telerik:RadDatePicker ID="txtEndDatee" runat="server" Culture="en-US">
                        <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput4" DisplayDateFormat="MM/dd/yyyy" DateFormat="MM/dd/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 100px;">
                <div class="raw_btn_new_2" style="margin-left: 9px;">
                    <asp:Button ID="lnkprint" CssClass="btn" runat="server" Text="Print Report" Style="width: 140px;
                        margin-left: 158px; height: 31px; float: left" />
                </div>
                <div class="raw_btn_new_2">
                    <asp:Button ID="lnlwebReport" CssClass="btn" Visible="false" runat="server" Text="Print Web Report"
                        Style="width: 145px; margin-left: 158px; height: 31px; float: left" />
                </div>
                <asp:TextBox ID="txtAccountCode" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txtPartyID" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
