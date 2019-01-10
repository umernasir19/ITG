<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="QCWORKLOAD.aspx.vb" Inherits="Integra.QCWORKLOAD" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="97%">
     <tr>
            <td width="306px">
               Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" style="width:140px;" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height:35px;">
            <td width="306px">
                Buying Dept.
            </td>
            <td>
                <asp:DropDownList ID="cmbbuyingDept" runat="server" style="width:140px;">
                </asp:DropDownList>
            </td>
        </tr>

    </table>
    <table width="103%">
        <tr style="height:35px;">
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
        <tr style="height: 35px;">
            <td>
                End Date
            </td>
            <td>
                <asp:TextBox ID="txtEndDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEndDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnReport" runat="server" Text="View Report" Style="margin-left: 19px;" />
            </td>
            <td align="right">
            </td>
        </tr>
    </table>
</asp:Content>
