<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="MilestoneSummary.aspx.vb" Inherits="Integra.MilestoneSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="60%">
        <tr>
            <td style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="ErrorMsg">
            </td>
        </tr>
        <tr>
            <td style="width: 109px; height: 20px;">
                Buying Dept. :
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbBuyingDetp" runat="server" AutoPostBack="true" Width="178px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 109px; height: 20px;">
                Report Type :
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbReportType" runat="server" AutoPostBack="true" Width="178px">
                    <asp:ListItem>Merchandiser Wise</asp:ListItem>
                    <asp:ListItem>Supplier Wise</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 140px; height: 20px;">
                <asp:Label ID="Label1" runat="server" Text="Product Portfolio:"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbProductPortfolio" runat="server" AutoPostBack="true" Width="130px">
                    <%--  <asp:ListItem Value="1" Text="Hard-line"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Leather Goods"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Textile"></asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblHeadingSupplier" runat="server" Text="Supplier:"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbSupplier" runat="server" AutoPostBack="true" Width="178px">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblMerchandiser" runat="server" Text="Merchandiser:"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbMarchandiser" runat="server" AutoPostBack="true" Visible="false"
                    Width="178px">
                </asp:DropDownList>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="lblReport" runat="server" Text="Report:"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbReport" runat="server" AutoPostBack="false" Visible="false"
                    Width="178px">
                    <asp:ListItem>General</asp:ListItem>
                    <asp:ListItem>With Follow-up Remarks</asp:ListItem>
                    <asp:ListItem>With Last/Current Follow-up</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFrom" runat="server" Text="From:"></asp:Label>
            </td>
            <td align="left">
                <%--   <asp:TextBox ID="txtDateFrom" Text="01/01/2015" CssClass="textbox" runat="server"
                    Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDateFrom"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.jpg"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDateFrom"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
                <telerik:RadDatePicker ID="txtDateFromm" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td align="left">
                <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
            </td>
            <td align="left">
                <%--  <asp:TextBox ID="txtDateTo" Text="31/12/2015" CssClass="textbox" runat="server" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDateTo"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.jpg"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDateTo"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>--%>
                <telerik:RadDatePicker ID="txtDateToo" runat="server" Culture="en-US">
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
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 20px">
            </td>
            <td align="left">
                <asp:Button ID="btnReport" runat="server" Text="Get Report" CssClass="button" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblheading" runat="server" Text="*- This Date belong to Customer Shipment Date.">
                </asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
