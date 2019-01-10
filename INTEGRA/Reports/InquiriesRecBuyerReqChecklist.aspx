<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="InquiriesRecBuyerReqChecklist.aspx.vb" Inherits="Integra.InquiriesRecBuyerReqChecklist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
        Inquiries Received Buyer's Requirements Check List
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 100px;">
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" Style="width: 140px; margin-left: 75px;"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Department
            </td>
            <td>
                <asp:DropDownList ID="cmbDept" runat="server" AutoPostBack="true" Style="width: 140px;
                    margin-left: 75px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Buyer Name
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyerName" runat="server" AutoPostBack="true" Style="width: 140px; margin-left: 75px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Supplier
            </td>
            <td>
                <asp:DropDownList ID="cmbsupplier" runat="server" Style="width: 140px; margin-left: 75px;">
                </asp:DropDownList>
            </td>
        </tr>
    <%--    <tr style="height: 35px;">
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbseason" runat="server" Style="width: 140px; margin-left: 75px;">
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td>
                Start Date
            </td>
            <td>
                <telerik:RadDatePicker ID="txtStartDatee" runat="server" Culture="en-US">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                End Date
            </td>
            <td>
                <telerik:RadDatePicker ID="txtEndDatee" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Meeting Date
            </td>
            <td>
                <telerik:RadDatePicker ID="txtMeetingDate" runat="server" Culture="en-US">
                    <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnReport" runat="server" Text="View Report" Style="margin-left: 19px;" />
            </td>
        </tr>
    </table>
</asp:Content>
