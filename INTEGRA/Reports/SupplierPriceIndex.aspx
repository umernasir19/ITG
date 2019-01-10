<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SupplierPriceIndex.aspx.vb" Inherits="Integra.SupplierPriceIndex" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Comparative Costing Sheet
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 20px">
            <td>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                Supplier
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbSupplier" runat="server" AutoPostBack="true" Width="192px"
                    ToolTip="Select Supplier">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" runat="server" Width="192px" AutoPostBack="true" ToolTip="Select Season">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Style
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbStyle" runat="server" AutoPostBack="true" Width="192px"
                    ToolTip="Select Style">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 20px">
            <td>
                Start Date
            </td>
            <td>
                <asp:TextBox ID="txtStartDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="ImageButton3" />
                <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtStartDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                End Date
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtEndDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStyleID" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                <br />
                <asp:Button ID="btnGetReport" runat="server" Text="Comparative Costing Sheet" Width="165px" />
                <asp:Button ID="Button1" runat="server" Text="Comparative Costing Sheet Confirmed"
                    Width="221px" />
            </td>
            <td>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
