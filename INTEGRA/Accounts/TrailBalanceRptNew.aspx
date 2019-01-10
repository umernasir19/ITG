<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="TrailBalanceRptNew.aspx.vb" Inherits="Integra.TrailBalanceRptNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                TRIAL BALANCE REPORT
            </th>
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
                        <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
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
                        <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
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
                <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="Print Report" Style="width: 140px;
                    margin-left: 166px; margin-top: 0px; height: 31px; float: left" />
            </td>
        </tr>
    </table>
</asp:Content>
