<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="EnquiryWorksheetReport.aspx.vb" Inherits="Integra.EnquiryWorksheetReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Equiry 
                Work Sheet
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="height: 35px;">
            <td>
                Style No.
            </td>
            <td>
                <asp:DropDownList ID="cmbStyle" AutoPostBack="false" runat="server" Width="140" ToolTip="select Style No">
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
</asp:Content>
