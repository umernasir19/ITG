<%@ Page Title="Payable Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="PayableReport.aspx.vb" Inherits="Integra.PayableReport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main_container">
        <div>
            <br />
            <div class="heading" style="width: 898px">
                PAYABLE REPORT</div>
            <br />
            <table cellpadding="3" style="width:100%;">
                <tr>
                    <td style="padding:8px; width:80px;">
                        Supplier
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbSupplier" Width="170px"  Style="height: 25px;" runat="server" AutoPostBack="false"
                            CssClass="combo">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding:8px;">
                        Year 
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbYear" runat="server" Width="170px" Visible="TRUE" CssClass="combo"
                            Style="height: 25px;">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">2015</asp:ListItem>
                            <asp:ListItem Value="2">2016</asp:ListItem>
                            <asp:ListItem Value="3">2017</asp:ListItem>
                            <asp:ListItem Value="4">2018</asp:ListItem>
                            <asp:ListItem Value="5">2019</asp:ListItem>
                            <asp:ListItem Value="6">2020</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding:8px;">
                        Start Date 
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="txtStartDate" runat="server" Culture="en-US">
                            <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                runat="server">
                            </Calendar>
                            <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server">
                            </DateInput>
                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td style="padding:8px;">
                        End Date 
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="txtEndDate" runat="server" Culture="en-US">
                            <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                runat="server">
                            </Calendar>
                            <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%" runat="server">
                            </DateInput>
                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="Print Report" Style="width: 150px;
                            height: 31px;" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
