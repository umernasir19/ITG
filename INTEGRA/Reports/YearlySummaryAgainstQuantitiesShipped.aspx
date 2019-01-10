<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="YearlySummaryAgainstQuantitiesShipped.aspx.vb" Inherits="Integra.YearlySummaryAgainstQuantitiesShipped" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
               Yearly Summary Against Quantities Shipped
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
    <br />
    <table width="100%">
        <tr>
            <td width="100px">
                From Month
            </td>
        <td width="100px">
                <asp:DropDownList ID="cmbFromMonth" runat="server" Style="margin-left: 10px;">
                    <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">Jun</asp:ListItem>
                    <asp:ListItem Value="07">Jul</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td width="100px">
                To Month
            </td>
            <td>
                <asp:DropDownList ID="cmbToMonth" runat="server" Style="margin-left: 10px;">
                 <asp:ListItem Value="01">Jan</asp:ListItem>
                    <asp:ListItem Value="02">Feb</asp:ListItem>
                    <asp:ListItem Value="03">Mar</asp:ListItem>
                    <asp:ListItem Value="04">Apr</asp:ListItem>
                    <asp:ListItem Value="05">May</asp:ListItem>
                    <asp:ListItem Value="06">Jun</asp:ListItem>
                    <asp:ListItem Value="07">Jul</asp:ListItem>
                    <asp:ListItem Value="08">Aug</asp:ListItem>
                    <asp:ListItem Value="09">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12" Selected="True" >Dec</asp:ListItem>
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
