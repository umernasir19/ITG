<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SummaryofTotalQuantitiesandStyles.aspx.vb" Inherits="Integra.SummaryofTotalQuantitiesandStyles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Summary of Total Quantities and Styles
            </th>
        </tr>
    </table>
    <br />
    <table width="75%">
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
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnReport" runat="server" Text="View Report" Style="margin-left: 19px;" />
            </td>
        </tr>
    </table>
</asp:Content>
