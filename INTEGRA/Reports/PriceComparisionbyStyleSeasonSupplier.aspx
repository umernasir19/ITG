<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="PriceComparisionbyStyleSeasonSupplier.aspx.vb" Inherits="Integra.PriceComparisionbyStyleSeasonSupplier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                             Price Comparision by Style/Season/Supplier
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 150px;">
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" Width="140px" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Buying Department
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyingDept" runat="server" Width="140px" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Buyer
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyer" runat="server" Width="140px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnViewReport" runat="server" Text="View Report"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
