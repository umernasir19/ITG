<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SupplierSamplingPerformance.aspx.vb" Inherits="Integra.SupplierSamplingPerformance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Supplier Sampling Performance
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 100px;">
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" Style="width: 140px; margin-left: 75px;"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Department
            </td>
            <td>
                <asp:DropDownList ID="cmbDept" runat="server" AutoPostBack="true" Style="width: 140px;
                    margin-left: 75px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbseason" runat="server" AutoPostBack="true" Style="width: 140px; margin-left: 75px;" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Supplier
            </td>
            <td>
                <asp:DropDownList ID="cmbsupplier" runat="server" Style="width: 140px; margin-left: 75px;">
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
