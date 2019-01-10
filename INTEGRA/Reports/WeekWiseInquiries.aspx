<%@ Page Title="WeekWiseInquiries" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="WeekWiseInquiries.aspx.vb" Inherits="Integra.WeekWiseInquiries" %>

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
                Week wise Inquiries/Order/Shipped Quantity</th>
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
        <tr style="height: 35px;">
            <td>
                Month
            </td>
            <td>
                <asp:DropDownList ID="cmbMonth" runat="server" Width="140px">
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
        </tr>
        <tr style="height: 35px;">
            <td>
                Year
            </td>
            <td>
                <asp:DropDownList ID="cmbYear" runat="server" Width="140px">
                    <asp:ListItem Value="01">2012</asp:ListItem>
                    <asp:ListItem Value="02">2013</asp:ListItem>
                    <asp:ListItem Value="03">2014</asp:ListItem>
                    <asp:ListItem Value="04">2015</asp:ListItem>
                    <asp:ListItem Value="05" Selected="True">2016</asp:ListItem>
                    <asp:ListItem Value="06">2017</asp:ListItem>
                    <asp:ListItem Value="07">2018</asp:ListItem>
                    <asp:ListItem Value="08">2019</asp:ListItem>
                    <asp:ListItem Value="09">2020</asp:ListItem>
                    <asp:ListItem Value="10">2021</asp:ListItem>
                    <asp:ListItem Value="11">2022</asp:ListItem>
                    <asp:ListItem Value="12">2023</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left">
                <asp:Button ID="btnViewReport" runat="server" Text="View Report"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
