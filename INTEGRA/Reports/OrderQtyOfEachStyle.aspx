<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="OrderQtyOfEachStyle.aspx.vb" Inherits="Integra.OrderQtyOfEachStyle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Order Quantities of Each Style
            </th>
        </tr>
    </table>
    <br />
    <table width="95%">
        <tr>
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" AutoPostBack="true" Style="width: 140px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Buying Dept
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyingDept" runat="server" Style="width: 140px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table width="97%">
        <tr>
            <td>
                Month From
            </td>
            <td>
                <asp:DropDownList ID="cmbMonthFrom" runat="server" AutoPostBack="true" Style="width: 140px;">
                    <asp:ListItem Value="1" Selected="True">JAN</asp:ListItem>
                    <asp:ListItem Value="2">FEB</asp:ListItem>
                    <asp:ListItem Value="3">MAR</asp:ListItem>
                    <asp:ListItem Value="4">APR</asp:ListItem>
                    <asp:ListItem Value="5">MAY</asp:ListItem>
                    <asp:ListItem Value="6">JUN</asp:ListItem>
                    <asp:ListItem Value="7">JUL</asp:ListItem>
                    <asp:ListItem Value="8">AUG</asp:ListItem>
                    <asp:ListItem Value="9">SEP</asp:ListItem>
                    <asp:ListItem Value="10">OCT</asp:ListItem>
                    <asp:ListItem Value="11">NOV</asp:ListItem>
                    <asp:ListItem Value="12">DEC</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Month To
            </td>
            <td>
                <asp:DropDownList ID="cmbMonthTo" runat="server" Style="width: 140px;">
                    <asp:ListItem Value="1">JAN</asp:ListItem>
                    <asp:ListItem Value="2">FEB</asp:ListItem>
                    <asp:ListItem Value="3">MAR</asp:ListItem>
                    <asp:ListItem Value="4">APR</asp:ListItem>
                    <asp:ListItem Value="5">MAY</asp:ListItem>
                    <asp:ListItem Value="6">JUN</asp:ListItem>
                    <asp:ListItem Value="7">JUL</asp:ListItem>
                    <asp:ListItem Value="8">AUG</asp:ListItem>
                    <asp:ListItem Value="9">SEP</asp:ListItem>
                    <asp:ListItem Value="10">OCT</asp:ListItem>
                    <asp:ListItem Value="11">NOV</asp:ListItem>
                    <asp:ListItem Value="12" Selected="True">DEC</asp:ListItem>
                </asp:DropDownList>
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
