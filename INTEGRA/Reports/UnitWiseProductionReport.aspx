<%@ Page Title="Unit Wise Production Report" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master" CodeBehind="UnitWiseProductionReport.aspx.vb"
    Inherits="Integra.UnitWiseProductionReport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function isNumericKey(e) {
            var charInp = window.event.keyCode;
            if (charInp > 31 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
        function isNumericKeyy(e) {
            var charInp = window.event.keyCode;
            if (charInp != 46 && (charInp < 48 || charInp > 57)) {
                return false;
            }
            return true;
        }
   
    </script>
    <table>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Unit Wise Production Report
            </th>
        </tr>
                <%--<tr>
            <th style="padding:8px 5px;">
                <asp:Label ID="Label2" runat="server" Text="Season"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbSeason" style="width:140px" autopostback="true">
                </asp:DropDownList>
            </td>
        
            <th style="padding:8px 5px;">
                <asp:Label ID="Label3" runat="server" Text="Sr No"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbSrNo" style="width:140px" autopostback="true">
                </asp:DropDownList>
            </td>
            <th style="padding:8px 5px;">
                <asp:Label ID="Label4" runat="server" Text="Color"></asp:Label>
            </th>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList runat="server" ID="cmbColor" style="width:140px">
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" style="margin-left:15px" Text="Month :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="cmbMonth" Style="width: 140px">
                    <asp:ListItem Value="0">-- Select Month --</asp:ListItem>
                    <asp:ListItem Value='1'>Janaury</asp:ListItem>
                    <asp:ListItem Value='2'>February</asp:ListItem>
                    <asp:ListItem Value='3'>March</asp:ListItem>
                    <asp:ListItem Value='4'>April</asp:ListItem>
                    <asp:ListItem Value='5'>May</asp:ListItem>
                    <asp:ListItem Value='6'>June</asp:ListItem>
                    <asp:ListItem Value='7'>July</asp:ListItem>
                    <asp:ListItem Value='8'>August</asp:ListItem>
                    <asp:ListItem Value='9'>September</asp:ListItem>
                    <asp:ListItem Value='10'>October</asp:ListItem>
                    <asp:ListItem Value='11'>November</asp:ListItem>
                    <asp:ListItem Value='12'>December</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblForm" runat="server"  style="margin-left:22px" Text="Year :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="cmbYear" Style="width: 140px">
                    <asp:ListItem Value="0">-- Select Year --</asp:ListItem>
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <td>
        </td>
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
</asp:Content>
