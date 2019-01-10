<%@ Page Title="Finishing Godown Carton Stock" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ShipmentReport.aspx.vb" Inherits="Integra.ShipmentReport" %>

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
                Finishing Godown Carton Stock
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="height: 35px">
                Season:
            </td>
            <td valign="top" style="padding: 8px 5px;">
                <div style="margin-left: 19px;">
                    <asp:DropDownList runat="server" ID="cmbSeason" Style="width: 140px" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div style="margin-left: 14px;">
                    Sr No:</div>
            </td>
            <td valign="top" style="padding: 8px 5px;">
                <div style="margin-left: 26px;">
                    <telerik:RadComboBox ID="cmbSrNoo" runat="server" CheckBoxes="True" Width="140" Skin="WebBlue">
                    </telerik:RadComboBox>
                    &nbsp;
                    <asp:Label ID="lblSrNo" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="height: 35px">
                Customer:
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 11px;">
                    <asp:DropDownList ID="cmbCustomer" runat="server" Width="140px" Style="margin-left: 10px;
                        margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <div style="margin-left: 32px;">
                    <asp:Label ID="lblForm" runat="server" Text="As on:"></asp:Label></div>
            </td>
            <td valign="top">
                <div style="margin-left: 31px; margin-top: 4px;">
                    <telerik:RadDatePicker ID="txtDate" runat="server" Culture="en-US">
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
            <td>
                <div style="margin-left: 310px;">
                    <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
