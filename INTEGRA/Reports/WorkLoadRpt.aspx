<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="WorkLoadRpt.aspx.vb" Inherits="Integra.WorkLoadRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="height: 35px;">
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" AutoPostBack="true" runat="server" Width="140"
                    ToolTip="select Customer No">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 25px;">
            <td>
                BuyingDept.
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyingDept" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="select BuyingDept No">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Supplier
            </td>
            <td>
                <asp:DropDownList ID="cmbSupplier" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="select Supplier No">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="select Season No">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Type
            </td>
            <td>
                <asp:DropDownList ID="cmbReportType" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="Select Report Type">
                    <asp:ListItem Value="0">Monthly</asp:ListItem>
                    <asp:ListItem Value="1">Season</asp:ListItem>
                    <asp:ListItem Value="2">Yearly</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
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
                <%--  <asp:TextBox ID="txtStartDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtStartDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
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
                <%--  <asp:TextBox ID="txtEndDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEndDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Month 1
            </td>
            <td>
                <asp:DropDownList ID="cmbMonth1" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="Select Month 1">
                    <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">Jun</asp:ListItem>
                    <asp:ListItem Value="07">Jul</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 33px;">
            <td>
                Month 2
            </td>
            <td>
                <asp:DropDownList ID="cmbMonth2" AutoPostBack="false" runat="server" Width="140"
                    ToolTip="Select Month 2">
                    <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">Jun</asp:ListItem>
                    <asp:ListItem Value="07">Jul</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnReport" runat="server" Text="View Report" Style="margin-left: 19px;" />
            </td>
            <td align="right">
            </td>
            <td align="left">
                <asp:Button ID="BtnSummaryReport" runat="server" Text="View Summary Report" Style="margin-left: 6px;" />
                <asp:Button ID="btnReportCustomerWise" runat="server" Text="View Customer Wise Report"
                    Style="margin-left: 6px;" />
                <asp:Button ID="btnReportDeptWise" runat="server" Text="View Department Wise Report"
                    Style="margin-left: 6px;" />
            </td>
        </tr>
    </table>
</asp:Content>
