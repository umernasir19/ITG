<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FifiStockReport.aspx.vb" Inherits="Integra.FifiStockReport" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Item Ledger Report
            </th>
        </tr>
    </table>
    <table>
        <tr style="height: 34px;">
            <td style="width: 110px;">
                Item Code
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="TXTCodeEntry" AutoPostBack="true" CssClass="textbox" runat="server"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTCodeEntry"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTCodeEntry" />
            </td>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
                <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <td style="width: 110px;">
            Location.
        </td>
        <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
            <telerik:RadComboBox ID="cmbGodown" runat="server" AutoPostBack="false" Skin="WebBlue">
            </telerik:RadComboBox>
        </td>
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 34px;">
            <td>
            </td>
            <td>
                <div style="margin-left: 314px;">
                    <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
