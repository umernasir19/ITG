<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="NoofOrderAndQtyPlacedWithVen.aspx.vb" Inherits="Integra.NoofOrderAndQtyPlacedWithVen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                No. of Order and Quantities Placed with Vendor
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" Style="width: 140px; margin-left: 75px;" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height:35px;">
            <td>
               Department
            </td>
            <td>
                <asp:DropDownList ID="cmbDept" runat="server" Style="width: 140px; margin-left: 75px;" >
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
