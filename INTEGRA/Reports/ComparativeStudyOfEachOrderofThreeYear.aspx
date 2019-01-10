<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ComparativeStudyOfEachOrderofThreeYear.aspx.vb" Inherits="Integra.ComparativeStudyOfEachOrderofThreeYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Comparative Study of Quantities of Each Order
            </th>
        </tr>
    </table>
    <br />
    <%--   <table width="100%">
        <tr>
            <td>
                Year
            </td>
            <td>
                <asp:DropDownList ID="cmbyear" runat="server">
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>--%>
    <br />
    <table width="85%">
        <tr style="height: 35px;">
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" runat="server" Style="width: 140px;" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Department
            </td>
            <td>
                <asp:DropDownList ID="cmbDept" runat="server" Style="width: 140px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="85%">
        <tr style="height: 35px;">
            <td>
                Month From
            </td>
            <td>
                <asp:DropDownList ID="cmbMonthFrom" runat="server" Style="width: 140px;">
                    <asp:ListItem Value="1" Selected ="True">JAN</asp:ListItem>
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
                    <asp:ListItem Value="1"  >JAN</asp:ListItem>
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
                    <asp:ListItem Value="12" Selected ="True">DEC</asp:ListItem>
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
