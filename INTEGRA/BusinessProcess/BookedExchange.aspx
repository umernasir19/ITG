<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="BookedExchange.aspx.vb" Inherits="Integra.BookedExchange" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="labelNew">
                Currency
            </td>
            <td>
                <asp:DropDownList ID="cmbCurrency" CssClass="forcapital" runat="server" Width="160px">
                    
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Exchange Rate:
            </td>
            <td>
                <telerik:RadTextBox ID="txtExchangeRate" runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td>
            </td>
            <td>
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
            <td>
            </td>
            <td class="ErrorMsg">
                *: This Criteria of Date is PO Shipment Date.
            </td>
        </tr>
    </table>
</asp:Content>
