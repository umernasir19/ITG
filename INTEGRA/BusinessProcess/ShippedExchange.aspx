<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="ShippedExchange.aspx.vb" Inherits="Integra.ShippedExchange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="labelNew">
                Currency
            </td>
            <td>
                <asp:DropDownList ID="cmbCurrency" CssClass="forcapital" runat="server" Width="72px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Dollar</asp:ListItem>
                    <asp:ListItem>Euro</asp:ListItem>
                    <asp:ListItem>Pound</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="labelNew">
                Exchange Rate:
            </td>
            <td class="labelNew">
                <asp:TextBox ID="txtExchangeRate" Width="90px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                From :
            </td>
            <td>
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
                To :
            </td>
            <td>
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
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
    </table>
    <table>
        <tr>
            <td>
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td><asp:Label ID="lblerror" runat ="server" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
