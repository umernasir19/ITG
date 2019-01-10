<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SummaryOfPriceRangeEachDept.aspx.vb" Inherits="Integra.SummaryOfPriceRangeEachDept" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Comparison of price
            </th>
        </tr>
    </table>
     <br />
    <table>
        <tr>
            <td style="width: 100px;">
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbseason1" runat="server" Style="width: 140px; margin-left: 75px;"
                    AutoPostBack="false" ToolTip="First Season">
                </asp:DropDownList>
                <asp:DropDownList ID="cmbseason2" runat="server" Style="width: 140px; margin-left: 75px;"
                    AutoPostBack="false" ToolTip="Second Season">
                </asp:DropDownList>
                <asp:DropDownList ID="cmbseason3" runat="server" Style="width: 140px; margin-left: 75px;"
                    AutoPostBack="false" ToolTip="Third Season">
                </asp:DropDownList>
                <asp:DropDownList ID="cmbseason4" runat="server" Style="width: 140px; margin-left: 75px;"
                    AutoPostBack="false" ToolTip="Fourth Season">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
 
    <table width="100%">
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
        <tr>
            <td>
                Buying Dept.
            </td>
            <td>
                <asp:DropDownList ID="cmbbuyingDept" runat="server">
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
